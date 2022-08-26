title: bat批处理实现守护进程 Windows使用bat批处理实现守护进程脚本分享
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2021-11-11 03:34:10
authorAbout:
series:
tags:
keywords:
description:
photos: https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211111033706808.png
---





想了解Windows使用bat批处理实现守护进程脚本讲解的相关内容吗，在本文为您仔细讲解bat批处理实现守护进程的相关知识和一些Code实例，欢迎阅读和指正，我们先划重点：Windows,bat,批处理,守护进程,脚本，下面大家一起来学习吧。

本文转自网络，由于找不到原作者，因而无法知道出处。如果有幸让原作者看到，请联系我加上。先转载至此。

最近几天加班加疯掉了，天天晚上没法睡。开发部的一个核心程序总是会自己宕机，然后需要手工去起，而这个服务的安全级别又很高，只有我可以操作，搞得我晚上老没法睡，昨晚实在受不了了，想起以前在hp-ux下写的shell守护进程，这回搞个windows下的bat版守护程序吧，当时晚上思路已经很迟钝了，就叫了个兄弟让他写了，上去后运行效果不错，至少昨晚我安心睡了7小时。

早上来把程序改完善一些，增加了记录等功能。

实现：

检查是否有notepad，要用的话就算成自己的进程名，如果进程宕了就过会自动重启（会在当前目录下生成一个start.bat）

```
@echo off

set _task=notepad.exe
set _svr=c:\windows\notepad.exe
set _des=start.bat

:checkstart
for /f "tokens=5" %%n in ('qprocess.exe ^| find "%_task%" ') do (
 if %%n==%_task% (goto checkag) else goto startsvr
)

 

:startsvr
echo %time% 
echo ********程序开始启动********
echo 程序重新启动于 %time% ,请检查系统日志 >> restart_service.txt
echo start %_svr% > %_des%
echo exit >> %_des%
start %_des%
set/p=.<nul
for /L %%i in (1 1 10) do set /p a=.<nul&ping.exe /n 2 127.0.0.1>nul
echo .
echo Wscript.Sleep WScript.Arguments(0) >%tmp%\delay.vbs 
cscript //b //nologo %tmp%\delay.vbs 10000 
del %_des% /Q
echo ********程序启动完成********
goto checkstart


:checkag
echo %time% 程序运行正常,10秒后继续检查.. 
echo Wscript.Sleep WScript.Arguments(0) >%tmp%\delay.vbs 
cscript //b //nologo %tmp%\delay.vbs 10000 
goto checkstart
```







set 限制解除 

[![CSDN会员](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/20211108111828.gif)](https://mall.csdn.net/vip?utm_source=vip_1111_toolbar_logo)

- [首页](https://www.csdn.net/)
- [博客](https://blog.csdn.net/)
- [下载](https://download.csdn.net/)
- [问答](https://ask.csdn.net/)
- [社区](https://bbs.csdn.net/)

 搜索



[登入](https://passport.csdn.net/account/login)

# Windwos bat进程守护 解决 kafka2.8.0 Failed to clean up log for __consumer_offsets



[Don't Look Down](https://blog.csdn.net/qq_32698323) 2021-10-23 23:36:03 ![img](https://csdnimg.cn/release/blogv2/dist/pc/img/articleReadEyes.png) 77 ![img](https://csdnimg.cn/release/blogv2/dist/pc/img/tobarCollect.png) 收藏

分类专栏： [kafka](https://blog.csdn.net/qq_32698323/category_11432370.html) 文章标签： [kafka](https://www.csdn.net/tags/OtTacg0sODc5OC1ibG9n.html) [window](https://www.csdn.net/tags/MtTaEg0sMDIyMDYtYmxvZwO0O0OO0O0O.html) [1024程序员节](https://www.csdn.net/tags/Mtzacg2sNTQ2NjctYmxvZwO0O0OO0O0O.html)



### windwos环境下使用kafka2.8.0，出现 ERROR Failed to clean up log for __consumer_offsets-）

- - [问题参考](https://blog.csdn.net/qq_32698323/article/details/120927703#_2)
  - [原因](https://blog.csdn.net/qq_32698323/article/details/120927703#_13)
  - [解决： bat 进程守护运行](https://blog.csdn.net/qq_32698323/article/details/120927703#_bat__21)
  - [无黑窗口运行模式](https://blog.csdn.net/qq_32698323/article/details/120927703#_105)



## 问题参考

```bash
ERROR Failed to clean up log for __consumer_offsets-42 in dir C:\tmp\kafka-logs due to IOException (kafka.server.LogDirFailureChannel)
java.nio.file.FileSystemException: C:\tmp\kafka-logs\__consumer_offsets-42\00000000000000000000.timeindex.cleaned ->
C:\tmp\kafka-logs\__consumer_offsets-42\00000000000000000000.timeindex.swap: 另一个程序正在使用此文件，进程无法访问。
....
java.nio.file.FileSystemException
12345
```

[Windows Kafka ERROR Failed to clean up log for __consumer_offsets](https://www.itsvse.com/thread-9980-1-1.html)
[[Kafka错误\]-----kafka在window下出现另一个程序正在使用此文件,进程无法访问的错误](https://blog.csdn.net/chengtanyong4777/article/details/102542326)

## 原因

kafka日志清理策略触发，在window环境下，在打开需要清理的日志的同时，对该文件进行重命名操作是不被允许的（linux环境下可以），从而导致kafka宕机。

> 方案一：修改日志清理策略，将日志清理时间修改为无穷（-1），使kafka数据日志永久存储 缺点：（1）磁盘空间会不断增大
> 方案二：在window上搭建虚拟机（docker同理，且更麻烦），然后在虚拟机中部署kafka 缺点：（1）运维人员需要懂点linux运维知识（2）增加内存消耗
> 方案三：上面文章中有写到重新打补丁包，我试过在2.8.0-2.13.0版本中重新打包，结果还是不行。

## 解决： bat 进程守护运行

用bat脚本对kafka的运行 进行守护，每10秒检查端口运行状态，运行异常时，重新启动 **2.注意：重启时 会清空kafka的日志文件**

> kafka_run_daemon.bat

```bash
@echo off

:: 执行的命令
set _startBat=D:\software\kafka\start.bat
:: 日志所在位置
set _kafkaLogs=D:\software\kafka\tmp


:checkstart
:: 端口方式进行检查
netstat -ano | findstr 0.0.0.0 | findstr :19092 | findstr LISTENING > nul
if %ERRORLEVEL% EQU 0 ( 
echo 运行正常
GOTO checkag ) else ( 
echo 没有运行
GOTO startsvr  )

 

:startsvr
echo %time% kafka运行状态异常、正在重新启动

:: 检查 zookeeper
echo %time% 检查zookeeper状态
netstat -ano | findstr 0.0.0.0 | findstr :12181 | findstr LISTENING > nul
if %ERRORLEVEL% EQU 0 ( 
echo %time% zookeeper正在运行
FOR /F "tokens=5" %%P IN ('netstat -a -n -o ^| findstr :12181') DO TaskKill.exe  /PID %%P  -t -f 
echo %time% zookeeper结束完成
 ) else ( 
echo %time% zookeeper没有运行
)

:: 删除tmp zookeepr和kafka的运行日志
echo %time% 删除tmp zookeepr和kafka的运行日志
rd/s/q %_kafkaLogs%
echo %time% 日志清理完成

:: 开始启动
echo %time% 开始启动
start %_startBat%
set/p=.<nul
for /L %%i in (1 1 10) do set /p a=.<nul&ping.exe /n 2 127.0.0.1>nul
echo .
echo Wscript.Sleep WScript.Arguments(0) >%tmp%\delay.vbs 
cscript //b //nologo %tmp%\delay.vbs 40000 
::计划40秒完成启动
echo %time%  启动操作完成，检查存活状态
GOTO checkstart


:checkag
echo %time% 程序运行正常,10秒后继续检查...
echo Wscript.Sleep WScript.Arguments(0) >%tmp%\delay.vbs 
cscript //b //nologo %tmp%\delay.vbs 10000 
GOTO checkstart
1234567891011121314151617181920212223242526272829303132333435363738394041424344454647484950515253545556
```

> start.bat 卡夫卡启动脚本

```bash
start .\bin\windows\zookeeper-server-start.bat .\config\zookeeper.properties
timeout 10
start .\bin\windows\kafka-server-start.bat .\config\server.properties
exit
1234
```

**使用方法 ，将两个bat复制到kafka根目录，配置好bat 里面的日志位置（此处将kafka和zookeeper都放在同一tem文件夹），
直接运行 kafka_run_daemon.bat，也可添加到系统服务中去**

本地测试，挂掉后可以正常重启：

![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/09bcc09859134c428f5decb17b40890b.png)

## 无黑窗口运行模式

**在上面的进程守护基础之上**

run_zookeeper.vbs

```bash
Dim WinScriptHost
Set WinScriptHost = CreateObject("WScript.Shell") 
WinScriptHost.Run ".\bin\windows\zookeeper-server-start.bat .\config\zookeeper.properties", 0, True 
Set WinScriptHost = Nothing
1234
```

run_kafka.vbs

```bash
Dim WinScriptHost
Set WinScriptHost = CreateObject("WScript.Shell") 
WinScriptHost.Run ".\bin\windows\kafka-server-start.bat .\config\server.properties", 0, True 
Set WinScriptHost = Nothing
1234
```

start_vbs.bat

```bash
start wscript runZookeeper.vbs
timeout 10
start wscript runKafka.vbs
exit
1234
```

> **run_zookeeper.vbs和run_kafka.vbs复制到kafka根目录**， **修改 \**kafka_run_daemon.bat\**脚本中的_startBat=start_vbs.bat
> 运行kafka_run_daemon.bat后 kafka和zookeeper不会出现黑窗口。**

这不是好的解决办法 ~~有其他解决办法的话，望看到的大哥们告知一下。



 
