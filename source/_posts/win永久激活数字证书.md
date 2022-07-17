title: win永久激活数字证书+启动盘制作
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2021-11-11 16:38:19
authorAbout:
series:
tags:
keywords:
description:

photos: https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211111164757165.png
---



 



![2](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/2.png)

下载HWIDGen_v61.01_CHS.exe

```cmd

Win+R 输入：

slmgr.vbs -dlv 显示：最为详尽的激活信息，包括：激活ID、安装ID、激活截止日期

slmgr.vbs -dli 显示：操作系统版本、部分产品密钥、许可证状态

slmgr.vbs -xpr 显示：是否永久激活

注意：可能部分国产杀毒软件会报毒，请关闭杀毒再使用此工具激活系统，否则可能会激活 Windows 10 失败。
```



![1](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/1.png)







# WinSetupFromUSB制作多系统U盘引导启动

***\*2016年06月06日 17:29:14\**** [***\*epsilon1\****](https://me.csdn.net/qq_20480611) ***\*阅读数 18591\**** 

***\*版权声明：本文为博主原创文章，未经博主允许不得转载。 https://blog.csdn.net/qq_20480611/article/details/51597018\**** 

***\*重装系统有各种方式，比较常见的有做系统引导U盘、刻录PE、硬盘一键安装等。但是有很多缺点，国内大部分用的Ghost系统，内含各种捆绑软件，系统极其不安全、稳定，另外制作U盘启动也只能做一个系统的安装盘，如果想换个系统还要另外刻录，费时费力。\****

0x00 简介

***\*WinSetupFromUSB是一款制作从usb磁盘(u盘和移动硬盘)启动安装操作系统的强大工具，支持各种windows、pe、linux操作系统。Windows纯净镜像请在\****[***\*MSDN我告诉你\****](http://www.itellyou.cn/)***\*下载。各种Linux镜像请在各自官网下载。（所有镜像都是ISO文件）\****

0x01 软件下载

***\*请访问官网下载最新版本\****[***\*http://www.winsetupfromusb.com\****](http://www.winsetupfromusb.com/downloads/)

0x02 操作步骤

***\*准备好一个大容量U盘（资料请备份好），容量越大越好，因为这个软件的优势就是可以写入多个系统并引导启动，打开软件，请按照如下截图勾选，请参照说明。\**** ***\*
\****![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wpsF51C.tmp.jpg)



```cmd
windows镜像选--> msdn中的择 初始发行 版本，可以直接写入，不要选择update版本
```

![image-20211111164757165](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211111164757165.png)

```cmd
***\*步骤说明：\**** ***\*
\*******\*1、第一次使用需要勾选格式化U盘（之后使用就不需要了）\**** ***\--> 之后可以直接增加写入各版本或系统镜像
\*******\*2、格式化选择FAT32，如果系统镜像大于4G\*******\*请选择NTFS\**** ***\*
\*******\*3、勾选对应系统类型\**** ***\*
\*******\*4、选择系统镜像\**** ***\*
\*******\*5、点击开始格式化并写入镜像到U盘\****
```



***\*必要说明：\**** ***\*
\*******\*1、首次使用需要格式化，之后请不要勾选Auto Format\**** ***\*
\*******\*2、可以多次使用，意味着多个相同类型系统需要分多次操作\****

0x03 删除引导记录

***\*如果系统镜像出现问题无法引导或者想删除多余的引导项，可以在官网找到完整的操作过程：\****[***\*http://www.winsetupfromusb.com/faq/\****](http://www.winsetupfromusb.com/faq/) ***\*，这里做简要描述：\**** ***\*
\*******\*1、Windows 7 及以上版本：\**** ***\*
\*******\*删除/WINSETUP/下面对应的系统目录，然后使用工具BOOTICE编辑/boot/bcd和/efi/microsoft/boot/bcd 删除不需要的引导记录。\**** ***\*
\****![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wpsF52D.tmp.jpg)***\*
\****![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wpsF52E.tmp.jpg)***\*
\****![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wpsF52F.tmp.jpg)

***\*2、Linux：\**** ***\*
\*******\*删除/ISO下面的对应文件，然后使用文本工具编辑根目录下的menu.lst文件，将下面的代码删除：（首行title 后面是镜像名称）\**** ***\*
\****![img](C:/Users/HI/AppData/Local/Temp/ksohtml/wpsF530.tmp.jpg)

0x04 手动添加纪录

***\*1、Windows：\**** ***\*
\*******\*目前我还不知道如何添加Windows的引导记录\****

***\*2、Linux：\**** ***\*
\*******\*如上所述，既然我们可以通过修改文本文件删除Linux引导，那么同样可以反过来添加引导。只需要按照格式复制一份引导记录即可，注意修改其中的镜像名称，然后把对应镜像复制到ISO目录下。\****

0x05 模拟测试

***\*启动镜像刻录完成后就可以测试了，如果都用真机未免费时，这里先用自带的Qemu测试引导记录是否存在：\**** ***\*
\*******\*选择FBinstTool，然后点击Qemu测试：\**** ***\*
\****![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wpsF531.tmp.jpg)***\*
\****![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wpsF532.tmp.jpg)

0x06 注意事项

***\*1、上面提到刻录多个同类型系统需要分开多次操作，但是我在制作过程中发现第二次竟然无法写入，Google说系统语言改成English就可以了。\**** ***\*
\****![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wpsF533.tmp.jpg)

***\*2、低版本可能会谜一样的出现找不到MBR的问题：\**** ***\*
\****![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wpsF534.tmp.jpg)***\*
\*******\*真是把我坑惨了！知道为了刻录那么多系统我重新格式化了多少遍吗！每次刻录Windows都显示这个问题，Google都找不到解决方法，然后我果断去官网，发现已经更新到1.6版本了，于是用最新的就好了。\****

 

 

 

 

## [***\*VMware Workstation 虚拟机使用无线wifi上网配置\****](https://www.cnblogs.com/hbtmwangjin/p/9129035.html) 

 

***\*参考文档：\**** [***\*转载/VMware Workstation环境下的Linux网络设置/适用于无线网络\****](https://blog.csdn.net/isiah_zhou/article/details/51169416)

　　***\*VMware Workstation 在嵌入式开发中经常会遇到，但是显示大多数人使用开发环境是Win10 + 无线网卡，针对这种情况，需要配置虚拟机的上网环境使用的是NAT模式，将配置过程进行描述：\****

***\*1. 打开Win10网络配置，操作如下：\****

![img](C:/Users/HI/AppData/Local/Temp/ksohtml/wpsF535.tmp.jpg)    ![img](C:/Users/HI/AppData/Local/Temp/ksohtml/wpsF536.tmp.jpg)

 

***\*2. 在虚拟机菜单中进行配置，选择编辑->虚拟网络编辑器 ,按照以下方法进行配置：\****

![img](C:/Users/HI/AppData/Local/Temp/ksohtml/wpsF537.tmp.jpg) 

 

![img](C:/Users/HI/AppData/Local/Temp/ksohtml/wpsF538.tmp.jpg) 

***\*3. 设置Linux系统的网络适配器，使用NAT模式，如下操作：\****

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wpsF539.tmp.jpg) 

 

 

***\*4. 进入linux 系统中进行配置，点击系统->网络设置，并进行如下设置：\****

![img](C:/Users/HI/AppData/Local/Temp/ksohtml/wpsF53A.tmp.jpg) 

 

***\*5. 重启Linux系统，完成配置过程；\****

 

 

 ***\*单文件\****

 



|      |                                                              |
| ---- | ------------------------------------------------------------ |
|      | ![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wpsF53B.tmp.jpg) |

 



***\*B\*******\*ios设置\****

 

***\*启用功能\****



|      |                                                              |
| ---- | ------------------------------------------------------------ |
|      | ![img](C:/Users/HI/AppData/Local/Temp/ksohtml/wpsF53C.tmp.jpg) |

 



 

 
