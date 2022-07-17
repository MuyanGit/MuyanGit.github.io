title: Windows上使用bat实现备份一个月内的数据库数据到文件
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2021-11-11 16:12:33
authorAbout:
series:
tags: bat

keywords:
description:

photos: https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211111163150160.png
---





# Windows上使用bat实现备份一个月内的数据库数据到文件

![img](https://csdnimg.cn/release/blogv2/dist/pc/img/original.png)

[霸道流氓气质](https://blog.csdn.net/BADAO_LIUMANG_QIZHI) 2021-08-15 16:07:12 ![img](https://csdnimg.cn/release/blogv2/dist/pc/img/articleReadEyes.png) 32 ![img](https://csdnimg.cn/release/blogv2/dist/pc/img/tobarCollect.png) 收藏

分类专栏： [架构之路](https://blog.csdn.net/badao_liumang_qizhi/category_8401955.html) 文章标签： [bat](https://www.csdn.net/tags/MtzaMg1sMDM1MDYtYmxvZwO0O0OO0O0O.html)

版权

脚本内容：

```bash
@echo off
setlocal enabledelayedexpansion
::备份数据库名字
set dataBase=fzys
set dataBaseTwo=fzys-nacos
::间隔时间
set INTERVAL=10
 
:Again
::每7天重置一次
for /l %%i in (1,1,7) do (
 echo %date% %time:~0,8%
 ::文件名
 set FileName=%dataBase%_%%i.sql
 echo !FileName!
 "C:\Program Files\MySQL\MySQL Server 5.6\bin\mysqldump" -h 127.0.0.1 -uroot -p123456 %dataBase%> "D:\\dataBak\\!FileName!"
 
 set FileNameTwo=%dataBaseTwo%_%%i.sql
 echo !FileNameTwo!
 "C:\Program Files\MySQL\MySQL Server 5.6\bin\mysqldump" -h 127.0.0.1 -uroot -p123456 %dataBaseTwo%> "D:\\dataBak\\!FileNameTwo!"
 
 timeout %INTERVAL%
)
goto Again
```

1、注意这里的间隔时间为10秒，保存近7次的记录，如果要一天备份一次，备份一个月的，要将INTERVAL设置为86400，将下面的for循环

的7改为30，这样就会每天备份一次，累计备份30天内的。

2、这里是备份两个数据库的数据，数量可以根据自己需要修改。



# 用批处理文件自动备份文件及文件夹，并自动删除n天前的文件

```
 
@echo off 
rem 格式化日期 
rem date出来的日期是"2006-02-22 星期三"，不能直接拿来使用，所以应该先格式化一下 
rem 变成我们想要的。date:~0,4的意思是从0开始截取4个字符 
set d=%date:~0,4%%date:~5,2%%date:~8,2% 
rem 设定压缩程序路径，这里用的是WINRAR的rar.exe进行打包的 
set path=C:\Program Files\WinRAR 
rem 设定要备份的目录 
set srcDir=D:\databasc 
rem 设定备份文件所在目录 
set dstDir=E:\temp\backup 
rem 设定备份文件的前缀,目前为temp,前缀为backup 
set webPrefix= 
rem 如果文件不存在,开始备份 
if not exist %dstDir%%webPrefix%%d%.rar start Rar a -r %dstDir%%webPrefix%%d%.rar %srcDir% 
@echo on 

```



·```

```
 
@echo off 
rem ****************************** 
rem * 按时间删除文件目录的批处理 * 
rem ****************************** 
rem 设置临时目录的路径 
set tempDir=%tmp%\remove_%date:~0,10% 
if not exist %tempDir% md %tempDir% 
rem 设置处理日期的脚本文件的路径 
set scriptFile=%tempDir%\get_date.vbs 
rem 获得要保留的天数 
set days=%~1 
if "%days%" == "" goto printUsage 
rem 获得目标目录的路径 
set dirPath=%~2 
if "%dirPath%" == "" set dirPath=. 
rem 获得要操作的文件形式 
set fileSpec=%~3 
if "%fileSpec%" == "" set fileSpec=*.* 
rem 生成计算日期的脚本文件并获得删除的截止日期 
echo d=date()-%1 > %scriptFile% 
echo s=right("0000" ^& year(d),4) ^& "-" ^& right("00" ^& month(d),2) ^& "-" ^& right("00" ^& day(d),2) >> %scriptFile% 
echo wscript.echo s >> %scriptFile% 
for /f %%i in ('cscript /nologo %scriptFile%') do set lastDate=%%i 
rem 处理目标目录里的每个对象 
for /f "tokens=1,2,3* delims=<> " %%i in ('dir "%dirPath%\%fileSpec%" /a /-c /tc') do call :proc "%%i" "%%j" "%%k" "%%l" 
goto :done 
rem 处理目标目录里对象的过程 
:proc 
rem 获得对象的创建日期并判断是否为有效格式 
set fileDate=%~1 
echo %fileDate% | findstr "[0-9][0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]" > nul 
if errorlevel 1 goto end 
rem 获得对象的类型 
set fileType=%~3 
if "%fileType%" == "" goto end 
rem 获得对象的名称 
set fileName=%~4 
if "%fileName%" == "" goto end 
if "%fileName%" == "." goto end 
if "%fileName%" == ".." goto end 
if "%fileName%" == "字节" goto end 
if "%fileName%" == "可用字节" goto end 
rem 判断对象日期是否小于或等于删除的截止日期 
if "%fileDate:~0,10%" leq "%lastDate%" ( 
echo deleting "%fileName%" ... 
if "%fileType%" == "DIR" ( rd /s /q "%dirPath%\%fileName%" ) else ( del /q /f "%dirPath%\%fileName%" ) 
) 
goto end 
:error 
echo An error occurred during backuping. 
:done 
rd /s /q %tempDir% 
goto end 
:printUsage 
echo Usage: %0 ^<Days^> [Work directory] [Target file specification (can include wildcards)] 
goto end 
:end 

```





# [Windows自动备份（每天、每月最后一天、每个周日），自动清除备份命令](https://www.cnblogs.com/xuezhizhang/p/12228487.html)

直接上BAT文件的内容了，完整代码如下。

备份效果：保留最新7天的网站备份、最新4个周末的网站备份，每个月底的备份永久保留。

使用的WinRAR做文件压缩，请自行安装并注意命令中**WinRAR的路劲、备份文件夹、存放路劲、3个异地存放路劲，根据应用需要调整**。

将该BAT文件配置到Windows“任务计划程序”中，频率为每天固定时间运行（比如23点），即可实现自动备份。

下面是关于备份命令的几点简单说明（详细参数或用法请自行查询详细资料了解）：

1. 命令中::代表注释
2. set后定义的是变量名及值
3. %%之间加变量名，是取变量的值，%date:~0,4%指的是取系统时间中的前四位即年份数字
4. WinRAR压缩，排除了带.log的文件
5. xcopy即复制命令，/d指比较目标和原目录，目标目录为空则复制所有，否则只复制更新过的，/y指禁止提示确认要覆盖已存在的目标文件
6. FORFILES命令，/P指定Path ，表明要从哪里开始搜索；/M指按照条件搜索文件，默认是*.* ；/C指在每个文件上运行指定的Command 。带有空格的命令字符串必须用引号括起来。默认的Command 是"cmd /c echo @file"；/D指选择日期大于或等于(+ )（或者小于或等于(- )）指定日期的文件，不带时间参数则代表与当前日期比较
7. **代码中判断是否是周日，使用的是“日”这个字**，考虑的是中文环境，**英文环境请自行修改**
8. **闰年判断已经调整为标准的闰年判断条件**（条件1：公历年份是4的倍数，且不是100的倍数；条件2：公历年份是整百数的，必须是400的倍数），%%代表取余
9. \>>用来向文件中写日志
10. **新补充**：set /a m=%date:~5,2%*1 **这一行有BUG，8月份带出的数字是08，默认识别为八进制，且为不识别的八进制数字**。错误信息：无效数字。数字常数只能是十进制(17)，十六位进制(0x11)或 八进制(021)。调整为：set  m=%date:~5,2% 即可。因为后面已经有if %m:~0,1%==0 set /a m=%m:~1,1%*1 这句处理0开头的情况。

[![复制代码](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/copycode.gif)](javascript:void(0);)

```
@echo off
::年月日字符串
set str_date=%date:~0,4%%date:~5,2%%date:~8,2%
::星期几
set str_week_val=%date:~-1%
::本地要备份的文件夹路径
set str_webpath_local=D:\wwwroot
::本地备份文件存放路径
set str_path_local=D:\web_bak
::网站压缩包名称前缀
set str_rar_name=MH_WEB
::异地 备份路径
set str_path_day=z:\最新7天网站备份
::异地 备份路径
set str_path_weekend=z:\最新4个周末的网站备份
::异地 备份路径
set str_path_month=z:\每个月底的网站备份

::取两位月份数字
set m=%date:~5,2%
::第一位为0则只取个位数
if %m:~0,1%==0 set /a m=%m:~1,1%*1
::取四位年份数字（这个命令用不到5位数那年吧）
set /a x=%date:~0,4%
::闰年判断条件1 %%代表取余
set /a y=%x%*1%%4
set /a y2=%x%*1%%100
::闰年判断条件2 %%代表取余
set /a y3=%x%*1%%400
::默认2月份只有28天
set ld=28
::满足闰年条件1
if %y%==0  (
    if %y2% NEQ  0  set ld=29
)
::满足闰年条件2
if %y3%==0  set ld=29
for %%i in (1 3 5 7 8 10 12)do (if %m%==%%i set /a ld=31)
for %%i in (4 6 9 11)do (if %m%==%%i set /a ld=30)
::echo  日期：%ld%
::pause

::当月月底的年月日字符串
set str_monthend_val=%date:~0,4%%date:~5,2%%ld%%

c:
cd C:\Program Files\WinRAR\

echo %time%开始压缩 >>%str_path_local%\%str_date%_log.bak

rar a -u -x*.log* %str_path_local%\%str_rar_name%%str_date%.rar %str_webpath_local%

echo %time%结束压缩 >>%str_path_local%\%str_date%_log.bak
echo. >>%str_path_local%\%str_date%_log.bak

echo %time%开始复制 >>%str_path_local%\%str_date%_log.bak

if "%str_date%"=="%str_monthend_val%" (
    xcopy %str_path_local%\%str_rar_name%%str_date%.rar %str_path_month% /d/y
) else (
if "%str_week_val%"=="日" ( 
    xcopy %str_path_local%\%str_rar_name%%str_date%.rar %str_path_weekend% /d/y
    ::删除4周前的rar文件
    FORFILES /P %str_path_weekend%  /M *.rar /D -22 /C "cmd /c echo %time% deleting..@file.. &del @file">>%str_path_local%\%str_date%_del.bak

) else (
    xcopy %str_path_local%\%str_rar_name%%str_date%.rar %str_path_day% /d/y
    ::删除7天前的rar文件
    FORFILES /P %str_path_day%  /M *.rar /D -7 /C "cmd /c echo %time% deleting..@file.. &del @file">>%str_path_local%\%str_date%_del.bak
)
)

echo %time%结束复制 >>%str_path_local%\%str_date%_log.bak
echo. >>%str_path_local%\%str_date%_log.bak

::删除本地1天前的rar文件
FORFILES /P %str_path_local%  /M *.rar /D -1 /C "cmd /c echo %time% deleting..@file.. &del @file">>%str_path_local%\%str_date%_del.bak
::删除本地7天前的bak记录文件
FORFILES /P %str_path_local%  /M *.bak /D -7 /C "cmd /c echo %time% deleting..@file.. &del @file">>%str_path_local%\%str_date%_del.bak
```

[![复制代码](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/copycode.gif)](javascript:void(0);)

本文首发于我的CSDN博客：https://blog.csdn.net/n_ithero/article/details/104037999





# Windows自动压缩文件夹，备份并上传到网盘

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/ece7838a23f8d3c42254d674051f5da3)

[贰狐](https://www.aobacore.com/author/1/)

2019-12-09

/

0 评论

/

2,118 阅读

/

未收录，点击推送

12/09

> 日常生活中有一些需要定期备份的bot目录，但是手动备份太麻烦了，如果用Windows的计划任务搭配bat脚本进行自动备份，并上传到网盘呢？

首先你需要有一个Onedrive或百度网盘。我比较推荐Onedrive是因为可以白嫖。当然，用百度网盘，然后设置某个目录为自动同步的文件夹也是可以的。

微软为每个账号提供空间为5GB的Onedrive，其实也够用了。

如果不够用可以白嫖↓

[申请OneDrive 5T 网盘便民方法和邮箱](https://51.ruyo.net/8263.html)
[免费office365教育版A1子号（5Tonedrive网盘），可以自助申请](https://www.shanyemangfu.com/office365-a1.html) 

之后安装一下 [7-Zip](https://www.7-zip.org/) 和 [Onedrive](https://www.microsoft.com/zh-cn/microsoft-365/onedrive/download)

大功告成，然后复制下面的代码，按说明替换中间的目录，保存成auto_backup.bat

注意：所有目录中不得包含中文

```
@echo off
::设置7z的命令行程序路径
set zip7=C:\Program Files\7-Zip\7z.exe
::设置压缩包保存路径，即你的onedrive本地路径
set Save=D:\Onedrive\OneDrive - User\BMX_backup
::当天日期，备份文件名
set curdate=%date:~0,4%%date:~5,2%%date:~8,2%_%time:~0,2%%time:~3,2%%time:~6,2%
::设置要打包压缩的文件夹
set zipfile=D:\Mirai_bmx
 
::备份命令 -xr!.svn过滤\data\image\文件夹 mx0是存储模式压缩
"%zip7%" a -tzip "%Save%\cq_bmx_%curdate%.zip" "%zipfile%" -mx0 -xr"!*\data\image\"

::删除超过7天的备份--start--
forfiles /p "%Save%" /m *.zip -d -7 /c "cmd /c del /f @path"
```

到这里其实就可以直接设置计划任务，每天定时运行了

不过由于我这里需要对酷Q进行备份，运行中的程序是无法被压缩的。

并且程序长时运行也可能出现问题，所以我们做一个自动重启的步骤。

保存下列代码放在上述代码前面，用于强行结束Mirai（如果是骰子请设置自动保存，不然可能会丢失数据）。

```
C:\Windows\system32\taskkill.exe /f /im MiraiOK_windows_386.exe
C:\Windows\system32\taskkill.exe /f /im MiraiOK.exe
C:\Windows\system32\taskkill.exe /f /im java.exe</div>
```

如果是XQ的话，可以用，同样调用Taskkill，但是由于在某些系统上无法执行中文bat，所以需要加CHCP。不过XQ注意定时清理image目录，不然压缩时候会爆炸，几个G的图片在那压缩，可就麻烦了。

```
echo off
CHCP 65001
echo  -------------------------
echo  重启中，请稍后...
echo  -------------------------
C:\Windows\system32\taskkill.exe /f /im 先驱.exe
保存下列代码，替换目录成bot的启动快捷方式，用于在备份后顺序启动（而不是开备份脚本的同时就打开了bot）。就起名叫start_mirai.bat吧

start D:\Mirai_bmx\Mirai_bmx.lnk
```

之后给这两个bat做一个控制开关，复制并替换上面两个脚本的存放位置，起名叫switch_mirai.bat

```
C:/auto_backup/auto_backup.bat&&;C:/auto_backup/start_mirai.bat
```

然后将 switch_mirai.bat 放入计划任务或是启动项中

启动项目录可以通过Win+R打开[运行]后输入 `shell:startup` 来快速打开。

可以在Onedrive网页中将备份的目录设置为共享，这样就能在异地直接下载了！





%time:~6,2%





版权属于：

贰狐Blog - 一个笨蛋的博客

本文链接：

Windows自动压缩文件夹，备份并上传到网盘

![img](https://gravatar.loli.net/avatar/ece7838a23f8d3c42254d674051f5da3?d=mm)

[申请OneDrive 5T 网盘便民方法和邮箱](https://51.ruyo.net/8263.html)
[免费office365教育版A1子号（5Tonedrive网盘），可以自助申请](https://www.shanyemangfu.com/office365-a1.html) 

之后安装一下 [7-Zip](https://www.7-zip.org/) 和 [Onedrive](https://www.microsoft.com/zh-cn/microsoft-365/onedrive/download)

大功告成，然后复制下面的代码，按说明替换中间的目录，保存成auto_backup.bat

注意：所有目录中不得包含中文

```
@echo off
::设置7z的命令行程序路径
set zip7=C:\Program Files\7-Zip\7z.exe
::设置压缩包保存路径，即你的onedrive本地路径
set Save=D:\Onedrive\OneDrive - User\BMX_backup
::当天日期，备份文件名
set curdate=%date:~0,4%%date:~5,2%%date:~8,2%_%time:~0,2%%time:~3,2%%time:~6,2%
::设置要打包压缩的文件夹
set zipfile=D:\Mirai_bmx
 
::备份命令 -xr!.svn过滤\data\image\文件夹 mx0是存储模式压缩
"%zip7%" a -tzip "%Save%\cq_bmx_%curdate%.zip" "%zipfile%" -mx0 -xr"!*\data\image\"

::删除超过7天的备份--start--
forfiles /p "%Save%" /m *.zip -d -7 /c "cmd /c del /f @path"
```

到这里其实就可以直接设置计划任务，每天定时运行了

不过由于我这里需要对酷Q进行备份，运行中的程序是无法被压缩的。

并且程序长时运行也可能出现问题，所以我们做一个自动重启的步骤。

保存下列代码放在上述代码前面，用于强行结束Mirai（如果是骰子请设置自动保存，不然可能会丢失数据）。

```
C:\Windows\system32\taskkill.exe /f /im MiraiOK_windows_386.exe
C:\Windows\system32\taskkill.exe /f /im MiraiOK.exe
C:\Windows\system32\taskkill.exe /f /im java.exe</div>
```

如果是XQ的话，可以用，同样调用Taskkill，但是由于在某些系统上无法执行中文bat，所以需要加CHCP。不过XQ注意定时清理image目录，不然压缩时候会爆炸，几个G的图片在那压缩，可就麻烦了。

```
echo off
CHCP 65001
echo  -------------------------
echo  重启中，请稍后...
echo  -------------------------
C:\Windows\system32\taskkill.exe /f /im 先驱.exe
保存下列代码，替换目录成bot的启动快捷方式，用于在备份后顺序启动（而不是开备份脚本的同时就打开了bot）。就起名叫start_mirai.bat吧

start D:\Mirai_bmx\Mirai_bmx.lnk
```

之后给这两个bat做一个控制开关，复制并替换上面两个脚本的存放位置，起名叫switch_mirai.bat

```
C:/auto_backup/auto_backup.bat&&;C:/auto_backup/start_mirai.bat
```

然后将 switch_mirai.bat 放入计划任务或是启动项中

启动项目录可以通过Win+R打开[运行]后输入 `shell:startup` 来快速打开。

可以在Onedrive网页中将备份的目录设置为共享，这样就能在异地直接下载了！

参考资料
[windows bat脚本7zip压缩文件夹，过滤文件夹 -  黑夜的白羊](https://my.oschina.net/mosg/blog/1944455)   
[如何设置2个bat文件严格按照顺序执行 - 百度知道](https://zhidao.baidu.com/question/548649859.html)

画图模式文本

## 7天之前的所有文件空文件文件夹

删除

```
@echo off
set DestFolder="F:\本地仓库\GitbakCloud189"
forfiles /p %DestFolder% /s /d -7 /c "cmd /c del/f/s/q @path"
for /f "delims=" %%a in ('dir /ad /b /s %DestFolder%^|sort /r') do (
	   rd "%%a">nul 2>nul &&echo 空目录"%%a"成功删除！
	)
pause  
echo 任务完成!
```

