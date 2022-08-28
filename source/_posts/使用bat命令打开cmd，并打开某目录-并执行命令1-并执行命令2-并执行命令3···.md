---
title: '    使用bat命令打开cmd，并打开某目录-并执行命令1+并执行命令2+并执行命令3··· '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-09-30 01:15:36
authorLink:
tags:
keywords: bat脚本输出日志到文件只保留异常在cmd窗口 bat
description: bat脚本输出日志到文件只保留异常在cmd窗口
photos: https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20210929233835218.png
---

# bat脚本输出日志到文件只保留异常在cmd窗口

我们在使用bat进行压测的时候往往不仅需要看自己打印log，还需要在cmd看相应的报错，而我们自己打印的log往往又会覆盖掉cmd上出现的报错，这时候可以使用命令：

```cmd
cmd窗口打开bat所在的目录
-->如下执行，可以把屏幕打印到文件

D:\MySoftware\云盘\阿里云盘\阿里云盘同步\sync-alidisk\config> 启动阿里云盘.bat >>sync-alidisk-log.txt

```

# bat打开cmd指向某个目录，并执行命令

樱花博客+环境变量快捷备份



```cmd
@echo OFF
rem 注意1：命令之间只需要一个&符号
rem 注意2：cmd /k "cd /d 
cmd /k "cd /d F:\本地 & hexo s & hexo cl & hexo d"
```

下面的不行，仅供参考

```cmd
cmd /k "cd /d  F:\jm\tms-web&&npm run build-prod&&xcopy F:\jm\tms-web\dist\*  D:\nginx-1.21.3\html\jm\ /Y /E /I /Q"
```

