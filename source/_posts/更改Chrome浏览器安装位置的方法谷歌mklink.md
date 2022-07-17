title: 更改Chrome浏览器安装位置的方法谷歌mklink
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2021-11-10 23:12:09
authorAbout:
series:
tags: Chrome
keywords:
description:

photos: https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/Snipaste_2021-11-06_01-39-32.png
---



![Snipaste_2021-11-06_01-39-32](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/Snipaste_2021-11-06_01-39-32.png)

```cmd
rd/s/q "C:\Program Files\Google\Chrome"
rd/s/q "C:\Program Files (x86)\Google" 
rd/s/q "C:\Users\HI\AppData\Local\Google"
mklink /d "C:\Program Files\Google\Chrome" "D:\MySoftware\Browsers\Google\Chrome"
mklink /d "C:\Program Files (x86)\Google" "D:\MySoftware\Browsers\Google"
mklink /d "C:\Users\HI\AppData\Local\Google" "D:\MySoftware\Browsers\Google\PersonData"
```



- 

# [谷歌浏览器移盘及mklink 命令使用](https://www.cnblogs.com/yzw625/p/15498480.html)

不把安装的谷歌浏览器程序本身从C:盘移到D:盘上，而是把缓存文件、设置等移到别的盘

如果要移动安装的谷歌浏览器程序本身，把"%ProgramFiles(x86)%\Google\Chrome"剪切到D:盘，这样就变成了绿色版了，通过快捷方式运行即可。但这样有个问题，浏览器升级是个麻烦事，另外还要设置将点击网址时关联到这个浏览器上。

如果保持程序本身在C:盘，改缓冲区、临时文件夹等，可以这样：

1. mklink命令将原缓存文件夹变为一个快捷方式，指向新定义的目录。如将"%LOCALAPPDATA%\Google\Chrome"下的"User Data"文件夹，通过管理员身份下的mklink命令改为指向D:下的某个文件夹
2. 也可通过运行参数：--disk-cache-dir=D:\XXXXXX

### 具体操作

1.把C:\Users\用户名\AppData\Local\Google\Chrome下的Chrome文件夹删除或者改名；

2.打开CMD，运行

```none
mklink /j "C:\Users\Administrator\AppData\Local\Google\Chrome" D:\Google\Chrome
```

注意：`C:\Users\Administrator\AppData\Local\Google\Chrome`**的 Chrome 文件夹先改成其它名字 比如 Chrome2, 然后当软链接创建完成后,就把这个Chrome2下面的所有东西复制到 “D:\Google\Chrome” 下面,然后再回去删除这个 Chrome2 ,创建软链接时,一定要保证 D:\Google\Chrome 这个文件夹是一个空的,里面不能有任何东西**

3.效果图：
[![image](https://img2020.cnblogs.com/blog/2074362/202111/2074362-20211102131455675-1124638750.png)](https://img2020.cnblogs.com/blog/2074362/202111/2074362-20211102131455675-1124638750.png)

image



4.**带 /J 参数，创建目录联接**。而且这个命令无需管理员权限。完成后C盘中这个文件不是快捷方式，相当于一个虚拟的文件夹，而这个文件夹真正存储位置是 `D:\Google\Chrome`，同样可以正常在C盘 `Google\Chrome`目录下进行存储文件不占用这个文件夹的空间。

参考：https://www.cnblogs.com/yzw625/p/15498480.html#scroller-0)
