---
title: ' 运行bat时隐藏cmd窗口    '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-10-21 04:15:10
authorLink:
tags: cmd
keywords:
description: 运行bat时隐藏cmd窗口
photos: https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110210415375.jpeg
---

## [运行bat时隐藏cmd窗口](https://www.cnblogs.com/mq0036/p/14633154.html)

运行bat时隐藏cmd窗口，开机启动bat以及隐藏运行窗口

bat隐藏窗口运行

cmd隐藏窗口运行

 

另一个方法：

隐藏运行软件，cmd隐藏运行，bat隐藏运行，命令窗口隐藏运行

 

让bat隐藏运行需要用vbs文件才能实现，
方法一：新建一个文本文档，写入
set ws=WScript.CreateObject("WScript.Shell")
ws.Run "d:\yy.bat",0
另存为vbs文件即可，其中d:\yy.bat是你需要运行的bat文件的路径。

方法二：用文本文档打开bat文件，在开头处写入
@echo off
if "%1" == "h" goto begin
mshta vbscript:createobject("wscript.shell").run("""%~nx0"" h",0)(window.close)&&exit
:begin
REM
这个方法运行bat，还是闪了一下。

 

1.在windows命令行后台运行某个命令：

在执行的命令前加上start /b，比如start /b run.bat。就相当于Linux下的run.sh &

2.开机启动bat
 新建test.bat, 文件内容如下:

 set ws=WScript.CreateObject("WScript.Shell") 
 ws.Run "D:\test.bat /start",0

 保存,然后放到Windows启动目录下,就可以了。

3.隐藏运行窗口
 bat运行后一般会有一个黑色的命令窗口,那么如何隐藏呢?有两种方式:

  方法一：新建一个vbs文件,如hello.vbs,文件内容如下:

  Set ws = CreateObject("Wscript.Shell") 
  ws.run "cmd /c D:\CI_Slave\slave.bat",vbhide 

 保存,然后放到Windows启动目录下,就可以了。

 方法二：用文本文档打开bat文件，在开头处写入

 @echo off
if "%1" == "h" goto begin
mshta vbscript:createobject("wscript.shell").run("""%~nx0"" h",0)(window.close)&&exit
:begin
REM

保存,然后放到Windows启动目录下,就可以了。

这个方法运行bat，还是会闪一下。

PS：Windows启动目录：

 WinXP: C:/Documents and Settings/Administrator/「开始」菜单/程序/启动

 Win7:  C:\Users\Administrator\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup

 Win10:C:\Users\Administrator\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup

 所有用户通用启动目录:C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp

 

出处：https://www.zhuguodong.com/?id=432

=======================================================================================

# Bat批处理文件怎么隐藏运行？隐藏运行Bat文件的几个方法

BAT文件是批处理文件，在**[Windows](http://www.xitonghe.com/)**系统下以命令行的方式执行一条或多条命令。在命令提示下键入批处理文件的名称，或者双击该批处理文件，系统就会调用cmd.exe按照该文件中各个命令出现的顺序来逐个运行它们。使用批处理文件（也被称为批处理程序或脚本），可以简化日常或重复性任务。是很多系统爱好者喜欢使用的命令！能实现的功能有很多。

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110210415375.jpeg)

然而Bat文件在运行时都会出现黑色的命令提示符窗口，让某些时候感觉不爽，如何才能隐藏运行Bat文件？下面小编介绍几种方法。


一、通过批处理命令实现。缺点：会看到一个窗口一闪而逝。优点：简单，直接添加即可。

@echo off
if "%1"=="h" goto begin
start mshta vbscript:createobject("wscript.shell").run("""%~nx0"" h",0)(window.close)&&exit
:begin
::以下为正常批处理命令，不可含有pause set/p等交互命令
pause

 

二、利用vbs脚本实现隐藏。缺点：调用麻烦点。优点：基本看不到痕迹（非绝对的，指一般用户）

HideRun.vbs

CreateObject("WScript.Shell").Run "cmd /c D:/test.bat",0
其中D:/test.bat是你的批处理路径




三、另一思路为把bat转换成vbs，然后vbs生成一个临时bat文件，然后WScript.Shell.Run隐藏启动这个临时bat。


HideRun.bat

echo CreateObject("WScript.Shell").Run "cmd /c D:/test.bat",0>tmp.vbscscript.exe/e:vbscripttmp.vbscscript.exe/e:vbscripttmp.vbs
del $tmp.vbs
这个批处理其实不能使其批处理本身隐藏，但是下面大部分隐藏调用批处理的原理和基础。


HideRun.js

new ActiveXObject('WScript.Shell').Run('cmd /c D:/Test.bat',0);
用Javascript有什么好处呢？js的字符串变量可以用单引号，从而方便命令行作为参数调用，而且js很好的支持多行语句用 ; 分隔写成一行。要注意的是：js要区分大小写，方法

必须用括号，结尾必须有分号。所以就成了下面的命令：

mshta "javascript：new ActiveXObject('WScript.Shell').Run('cmd /c D:/test.bat',0);window.close()"

 

 通常系统管理员会向用户端推送一些脚本并运行，或者拷贝批处理文件到客户端由用户自己运行。但是大部分脚本在运行时会弹出黑色背景的DOS窗口，这会让不少用户不知所

措，甚至误操作关闭正在运行的窗口。好在批处理文件的DOS窗口是可以隐藏的，以下是几种隐藏批处理运行窗口的方法。


1.基础

HideRun.vbs

CreateObject("WScript.Shell").Run "cmd /c D:/test.bat",0 www.xitonghe.com
其中D:/test.bat是你的批处理路径

另一思路为把bat转换成vbs，然后vbs生成一个临时bat文件，然后WScript.Shell.Run隐藏启动这个临时bat。


HideRun.bat

echo CreateObject("WScript.Shell").Run "cmd /c D:/test.bat",0>tmp.vbscscript.exe/e:vbscripttmp.vbscscript.exe/e:vbscripttmp.vbs
del $tmp.vbs
这个批处理其实不能使其批处理本身隐藏，但是下面大部分隐藏调用批处理的原理和基础。


HideRun.js

new ActiveXObject('WScript.Shell').Run('cmd /c D:/Test.bat',0);
用Javascript有什么好处呢？js的字符串变量可以用单引号，从而方便命令行作为参数调用，而且js很好的支持多行语句用 ; 分隔写成一行。要注意的是：js要区分大小写，方法

必须用括号，结尾必须有分号。所以就成了下面的命令：

mshta "javascript：new ActiveXObject('WScript.Shell').Run('cmd /c D:/test.bat',0);window.close()"

 

2.用快捷方式

如果要使一个批处理本身隐藏，可以参考附件里的一个快捷方式，修改附件中的相关路径即可隐藏启动你的批处理。可以用vbs来建立一个 .lnk，其实用批处理也行（先echo一个

vbs出来）

 

3.利用系统服务

可以建立一个系统服务然后启动这个服务来启动批处理。缺点是启动服务较慢，需要管理员权限

runassrv add /cmdline:"C:/Windows/System32/cmd.exe /c D:/test.bat" /name:"mysrv"
net start mysrv

 

4.利用at计划任务

用at可以建立一个计划任务，在不输入 /interactive 参数可以后台运行。但是建使用at必须有管理员权限

at 09:10 "cmd /c D:/Test.bat"

然后在 9:10 系统就会自动后台以SYSTEM权限运行这个bat

 


5.利用ftype文件关联

ftype batfile=C:/Windows/System32/mshta "javascript：new ActiveXObject('WScript.Shell').Run('cmd /c%1',0);window.close();"

 

6.其他用户

Windows 2k/XP支持多用户，如果能在后台登陆另一个账户的桌面然后运行一个批处理，就能完全达到隐藏的目的

 

7.编译成可执行文件

不少方法可以实现，可以直接利用的工具有 Quick Batch file compiler。

以上方法由系统盒[www.xitonghe.com](http://www.xitonghe.com/) 小编网络整理，希望对大家有帮助。

 

出处：http://www.xitonghe.com/jiaocheng/diannao-9298.html

=======================================================================================

# 批处理隐藏自身窗口，很无聊

批处理隐藏运行效果代码,防止出现黑窗口不建议非法用途，可以用来执行命令，提供用户体验。

 

复制代码 代码如下:


@echo oFF
::code by LZ-MyST QQ:8450919 BLOG:http://hi.baidu.com/lzmyst http://www.clxp.net.cn
if "%1" neq "1" (
\>"%temp%\tmp.vbs" echo set WshShell = WScript.CreateObject^(^"WScript.Shell^"^)
\>>"%temp%\tmp.vbs" echo WshShell.Run chr^(34^) ^& %0 ^& chr^(34^) ^& ^" 1^",0
start /d "%temp%" tmp.vbs
exit

)
::从这里开始，就是你的批处理代码了，DOS黑框一闪而过，转到后台运行了
pause
::你会在任务管理器看到有一个隐藏窗口的CMD进程


**运行bat时隐藏cmd窗口的方法**

运行bat时隐藏cmd窗口的方法 可以编辑一个vbs脚本，在其中以隐藏窗口运行批处理程序。

复制代码 代码如下:


Set ws = CreateObject("Wscript.Shell")
ws.run "cmd /c 批处理程序名",vbhide


将上面代码拷贝到记事本中，保存为"runbat.vbs"或者其它的名字（扩展名必须是.vbs），然后点击运行生成的脚本runbat.vbs，即可隐藏运行指定的批处理程序。
这个vbs脚本也可以在bat环境中直接调用，达到隐藏bat自身的目的。
自己总结一下,做几个例子，有兴趣的去试验一下啊!

复制代码 代码如下:


Set ws = CreateObject("Wscript.Shell")
wscript.sleep 1200 ws.run "cmd /c start winrar.exe",vbhide
wscript.sleep 2200 ws.run "cmd /c start msimn.exe",vbhide
wscript.sleep 1200 ws.run "cmd /c start iexplore.exe",vbhide



**下面来几个高手整理的**

 

几种隐藏批处理运行窗口的方法 .
（1）通过批处理命令实现。缺点：会看到一个窗口一闪而逝。优点：简单，直接添加即可。

 

```cmd



@echo off
if "%1"=="h" goto begin
start mshta vbscript:createobject("wscript.shell").run("""%~nx0"" h",0)(window.close)&&exit
:begin
::以下为正常批处理命令，不可含有pause set/p等交互命令
pause
```



 

（2）利用vbs脚本实现隐藏。缺点：调用麻烦点。优点：基本看不到痕迹（非绝对的，指一般用户）

HideRun.vbs

 

复制代码 代码如下:


CreateObject("WScript.Shell").Run "cmd /c D:/test.bat",0

 

其中D:/test.bat是你的批处理路径
.....................................................................................................................................
另一思路为把bat转换成vbs，然后vbs生成一个临时bat文件，然后WScript.Shell.Run隐藏启动这个临时bat。
HideRun.bat

 

复制代码 代码如下:


echo CreateObject("WScript.Shell").Run "cmd /c D:/test.bat",0>tmp.vbscscript.exe/e:vbscripttmp.vbscscript.exe/e:vbscripttmp.vbs
del $tmp.vbs

 

这个批处理其实不能使其批处理本身隐藏，但是下面大部分隐藏调用批处理的原理和基础。
HideRun.js

 

复制代码 代码如下:


new ActiveXObject('WScript.Shell').Run('cmd /c D:/Test.bat',0);

 

用Javascript有什么好处呢？js的字符串变量可以用单引号，从而方便命令行作为参数调用，而且js很好的支持多行语句用 ; 分隔写成一行。要注意的是：js要区分大小写，方法
必须用括号，结尾必须有分号。所以就成了下面的命令：

 

复制代码 代码如下:


mshta "javascript:new ActiveXObject('WScript.Shell').Run('cmd /c D:/test.bat',0);window.close()"




​    通常系统管理员会向用户端推送一些脚本并运行，或者拷贝批处理文件到客户端由用户自己运行。但是大部分脚本在运行时会弹出黑色背景的DOS窗口，这会让不少用户不知所
措，甚至误操作关闭正在运行的窗口。好在批处理文件的DOS窗口是可以隐藏的，以下是几种隐藏批处理运行窗口的方法。
1.基础
HideRun.vbs
CreateObject("WScript.Shell").Run "cmd /c D:/test.bat",0
其中D:/test.bat是你的批处理路径
另一思路为把bat转换成vbs，然后vbs生成一个临时bat文件，然后WScript.Shell.Run隐藏启动这个临时bat。
HideRun.bat

 

复制代码 代码如下:


echo CreateObject("WScript.Shell").Run "cmd /c D:/test.bat",0>tmp.vbscscript.exe/e:vbscripttmp.vbscscript.exe/e:vbscripttmp.vbs
del $tmp.vbs

 

这个批处理其实不能使其批处理本身隐藏，但是下面大部分隐藏调用批处理的原理和基础。
HideRun.js
new ActiveXObject('WScript.Shell').Run('cmd /c D:/Test.bat',0);
用Javascript有什么好处呢？js的字符串变量可以用单引号，从而方便命令行作为参数调用，而且js很好的支持多行语句用 ; 分隔写成一行。要注意的是：js要区分大小写，方法
必须用括号，结尾必须有分号。所以就成了下面的命令：
mshta "javascript:new ActiveXObject('WScript.Shell').Run('cmd /c D:/test.bat',0);window.close()"
2.用快捷方式
如果要使一个批处理本身隐藏，可以参考附件里的一个快捷方式，修改附件中的相关路径即可隐藏启动你的批处理。可以用vbs来建立一个 .lnk，其实用批处理也行（先echo一个
vbs出来）
3.利用系统服务
可以建立一个系统服务然后启动这个服务来启动批处理。缺点是启动服务较慢，需要管理员权限
runassrv add /cmdline:"C:/Windows/System32/cmd.exe /c D:/test.bat" /name:"mysrv"
net start mysrv
4.利用at计划任务
用at可以建立一个计划任务，在不输入 /interactive 参数可以后台运行。但是建使用at必须有管理员权限
at 09:10 "cmd /c D:/Test.bat"
然后在 9:10 系统就会自动后台以SYSTEM权限运行这个bat

5.利用ftype文件关联
ftype batfile=C:/Windows/System32/mshta "javascript:new ActiveXObject('WScript.Shell').Run('cmd /c%1',0);window.close();"
6.其他用户
Windows 2k/XP支持多用户，如果能在后台登陆另一个账户的桌面然后运行一个批处理，就能完全达到隐藏的目的
7.编译成可执行文件
不少方法可以实现，可以直接利用的工具有 Quick Batch file compiler。

 

出处：https://www.jb51.net/article/14352.htm
