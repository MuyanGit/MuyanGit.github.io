---
title: 'ping IP 带时间戳循环显示并写入日志+检测某个IP端口的实时状态（windos版+linux版） '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorLink: 
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-09-09 02:29:51
tags:
keywords:
description:
photos:
---

# 

在工作中，判断网络是否通畅，首选命令就是ping，但有时候我们需要持续ping一个或多个地址时，需要加 -t 即可，但有时候需要在ping的时候加入时间戳并把ping记录写入到日志里面，方法如下：

**windos版：**

**首选把下面代码复制到文本里去，然后把扩展名更改为.bat**



```
@echo off
@echo.----------------------------------------------------------
@echo.       一   Author： aゞ锦衣卫
@echo.       键   Reminder：请以管理员身份运行                                                                 
@echo.       ★   Description：一键ping+时间戳+写日志服务                                                     
@echo.       服   Blog：www.cnblogs.com/su-root                                               
@echo.       务   Email：1147076062@qq.com VX：zikun868686
@echo.-----------------------------------------------------------
@echo.  ※温馨提醒：终止执行请按: Ctrl+C
@echo.-----------------------------------------------------------
@echo off
set /p host=请输入需要检测的IP地址: 
set logfile=Log_%host%.log
echo Target Host = %host% >%logfile%
for /f "tokens=*" %%A in ('ping %host% -n 1 ') do (echo %%A>>%logfile% && GOTO Ping)
:Ping
for /f "tokens=* skip=2" %%A in ('ping %host% -n 1 ') do (
    echo %date% %time:~0,2%:%time:~3,2%:%time:~6,2% %%A>>%logfile%
    echo %date% %time:~0,2%:%time:~3,2%:%time:~6,2% %%A
    timeout 1 >NUL 
    GOTO Ping)
```

s



```::      这是注释 文件名 test.bat
@echo off
::      关闭回显

set /p host=myhost:
::      这是备注/p效果是 需要用户输入host，即你要ping的地址
::      设置字符串变量     =后：前为提示

set logfile=ping_%host%.log
::      设置文件名 要重用set设置的变量host 需要两边包裹%

echo Target Host=%host% > %logfile%
::       echo 输出的字符串 >到 输入的对象
::      >file.txt 输出字符串到文件；没有> 默认输出到屏幕； >nul 输出到空的对象，指令操作的提示语句不会显示


::      增强for循环
::      tokens 选择一行中的分割好的部分 *剩余全部 
::      skip 跳过开头几行
::      %date:~0,2% 日期字符串从第一个到倒数第三个2021-09-09  2:19:59
::      >>a.txt 追加到a.txt里
::      >a.txt 无创建a.txt，有清空a.txt
::      echo str 输出字符串
::      echo str >>filename 输出字符串到文件
::      timeout /t waittime /nobreak>nul 等待时间waittime 期间无法停止 >nul 意思不要打印到命令窗口 不显示
::      ":loop" "goto loop" 循环
::      pause>nul 按任意键继续，不显示提示

:loop
for /f "tokens=* skip=2" %%A in ('ping %host% -n 1') do (
	 echo %date% %time:~0,2%:%time:~3,2%:%time:~6,2% %%A>>%logfile%
    echo %date% %time:~0,2%:%time:~3,2%:%time:~6,2% %%A
	timeout /t 1 /nobreak>nul
	goto loop
)
pause>nul
```

**运行.bat文件效果如下：**

[![img](https://gitee.com/muyangit/blog-img/raw/master/img/1491353-20190704224802315-910955600.gif)](https://img2018.cnblogs.com/blog/1491353/201907/1491353-20190704224802315-910955600.gif)

**注：**.bat文件放到哪里执行，就会在本地生成相应的.log日志文件。

我们打开日志文件看看：

[![img](https://gitee.com/muyangit/blog-img/raw/master/img/1491353-20190704225645380-1465060532.png)](https://img2018.cnblogs.com/blog/1491353/201907/1491353-20190704225645380-1465060532.png)

 **如果我们需要检测某IP地址的指定端口可将上面代码稍加改动即可：**



```
@echo off
@echo.----------------------------------------------------------
@echo.       一   Author： aゞ锦衣卫
@echo.       键   Reminder：请以管理员身份运行                                                                 
@echo.       ★   Description：一键端口检测服务                                                     
@echo.       服   Blog：www.cnblogs.com/su-root                                               
@echo.       务   Email：1147076062@qq.com VX：zikun868686
@echo.-----------------------------------------------------------
@echo.  ※温馨提醒：终止执行请按: Ctrl+C
@echo.-----------------------------------------------------------
@echo off
set /p host=请输入需要检测的IP地址: 
set /p port=请输入需要检测的端口号:
set logfile=Log_%host%.log
echo Target Host = %host% >>%logfile%
for /f "tokens=*" %%A in ('tcping -d -t -n 1 %host% %port%') do (echo %%A>>%logfile% && GOTO Ping)
:Ping
for /f "tokens=* skip=2" %%A in ('tcping -d -t -n 1 %host% %port%') do (
    echo %date% %time:~0,2%:%time:~3,2%:%time:~6,2% %%A>>%logfile%
    echo %date% %time:~0,2%:%time:~3,2%:%time:~6,2% %%A
    timeout 1 >NUL 
    GOTO Ping)
```

**执行效果如下：**

[![img](https://gitee.com/muyangit/blog-img/raw/master/img/1491353-20190704231350175-237687828.gif)](https://img2018.cnblogs.com/blog/1491353/201907/1491353-20190704231350175-237687828.gif)

**注：**去官网下载tcping工具（根据自身系统选择32位/64位）https://elifulkerson.com/projects/tcping.php  tcping工具具体用法可参看：https://www.cnblogs.com/su-root/p/10924758.html

我们打开日志文件看看：

[![img](https://img2018.cnblogs.com/blog/1491353/201907/1491353-20190704231521074-411976195.png)](https://img2018.cnblogs.com/blog/1491353/201907/1491353-20190704231521074-411976195.png)

 

**linux版：**



```
[root@bqh-118 ~]# ping 192.168.0.117|awk '{print strftime("%c",systime()) "\t"$0}'
2019年07月04日 星期四 23时14分35秒    PING 192.168.0.117 (192.168.0.117) 56(84) bytes of data.
2019年07月04日 星期四 23时14分35秒    64 bytes from 192.168.0.117: icmp_seq=1 ttl=64 time=0.223 ms
2019年07月04日 星期四 23时14分36秒    64 bytes from 192.168.0.117: icmp_seq=2 ttl=64 time=0.385 ms
2019年07月04日 星期四 23时14分37秒    64 bytes from 192.168.0.117: icmp_seq=3 ttl=64 time=0.420 ms
2019年07月04日 星期四 23时14分38秒    64 bytes from 192.168.0.117: icmp_seq=4 ttl=64 time=0.291 ms
2019年07月04日 星期四 23时14分39秒    64 bytes from 192.168.0.117: icmp_seq=5 ttl=64 time=1.21 ms
2019年07月04日 星期四 23时14分40秒    64 bytes from 192.168.0.117: icmp_seq=6 ttl=64 time=1.45 ms
```

**把输出信息写入到log日志中：**



```
[root@bqh-118 ~]# ping 192.168.0.117 -c 6|awk '{print strftime("%c",systime()) "\t"$0}' >ping.log

[root@bqh-118 ~]# cat ping.log 
2019年07月04日 星期四 23时15分06秒    PING 192.168.0.117 (192.168.0.117) 56(84) bytes of data.
2019年07月04日 星期四 23时15分06秒    64 bytes from 192.168.0.117: icmp_seq=1 ttl=64 time=0.231 ms
2019年07月04日 星期四 23时15分07秒    64 bytes from 192.168.0.117: icmp_seq=2 ttl=64 time=0.331 ms
2019年07月04日 星期四 23时15分08秒    64 bytes from 192.168.0.117: icmp_seq=3 ttl=64 time=0.185 ms
2019年07月04日 星期四 23时15分09秒    64 bytes from 192.168.0.117: icmp_seq=4 ttl=64 time=0.347 ms
2019年07月04日 星期四 23时15分10秒    64 bytes from 192.168.0.117: icmp_seq=5 ttl=64 time=0.259 ms
2019年07月04日 星期四 23时15分11秒    64 bytes from 192.168.0.117: icmp_seq=6 ttl=64 time=0.377 ms
2019年07月04日 星期四 23时15分11秒    
2019年07月04日 星期四 23时15分11秒    --- 192.168.0.117 ping statistics ---
2019年07月04日 星期四 23时15分11秒    6 packets transmitted, 6 received, 0% packet loss, time 5038ms
2019年07月04日 星期四 23时15分11秒    rtt min/avg/max/mdev = 0.185/0.288/0.377/0.069 ms
```

**我们也可把任务放到后台运行**



```
[root@bqh-118 ~]# ping 192.168.0.117 -c 6|awk '{print strftime("%c",systime()) "\t"$0}' >ping.log &
[1] 1560
[root@bqh-118 ~]# 
```

当然也有其他方法检测，以上方法不是唯一的







# ping  百度



```

@echo off
@echo.------------------ping指定 IP baidu.com-----------------------------
@echo off
set host=baidu.com
set logfile=Log_%host%.log
echo Target Host = %host% >%logfile%
for /f "tokens=*" %%A in ('ping %host% -n 1 ') do (echo %%A>>%logfile% && GOTO Ping)
:Ping
for /f "tokens=* skip=2" %%A in ('ping %host% -n 1 ') do (
    echo %date% %time:~0,2%:%time:~3,2%:%time:~6,2% %%A>>%logfile%
    echo %date% %time:~0,2%:%time:~3,2%:%time:~6,2% %%A
    timeout 1 >NUL 
    GOTO Ping)

```



# ping  局域网



```
@Echo off
    date /t >> IPList.txt
　　time /t >> IPList.txt
　　echo =========== >> IPList.txt
　　for /L %%I in (1,1,255) do (%SystemRoot%\System32\PING.EXE -n 1 192.168.1.%%I )
    @Find "Request timed out." & echo 192.168.0.%%I Timed Out >>IPList.txt & echo off
    pause  
	
　　cls
　　Echo Finished!
　　@Echo on
　　Notepad.exe IPList.txt
```



