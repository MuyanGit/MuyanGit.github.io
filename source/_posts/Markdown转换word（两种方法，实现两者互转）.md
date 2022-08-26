---
title: ' Markdown转换word（两种方法，实现两者互转）非原创    '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorLink: 
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-09-25 02:43:30
tags:
keywords:
description:
photos:
---



# Markdown转换word（两种方法，实现两者互转）非原创

来自[Hi丶ImViper](https://blog.csdn.net/weixin_43314519) 2020-06-15 17:15:43 ![img](H:/MuyanGitBlog/MuyanGit/source/_posts/articleReadEyes-163250913096526.png) 3113 ![img](H:/MuyanGitBlog/MuyanGit/source/_posts/tobarCollect-163250913096528.png) 收藏 8





分类专栏： [Tools](https://blog.csdn.net/weixin_43314519/category_10066504.html) 文章标签： [git](https://www.csdn.net/tags/MtzaYgwsMzEzMy1ibG9n.html) [github](https://www.csdn.net/tags/MtzaUg4sNDIwOC1ibG9n.html) [windows](https://www.csdn.net/tags/MtTaEg0sNTAxMTMtYmxvZwO0O0OO0O0O.html) [markdown](https://www.csdn.net/tags/MtTaEg0sMjI3NDgtYmxvZwO0O0OO0O0O.html)



# Markdown转换成word

Typora+pandoc就可以简单的实现Markdown转换成word啦！

在日常使用过程中，需要用到其他的格式，typora默认支持 .md文件转 .pdf与 .html格式，其余的常见格式需要使用 pandoc扩展程序来支持。

## Typora安装

1.打开Typora的官网：

打开链接如下所示：下滑，选择适合自己系统的安装包。

![image-20210925025131140](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20210925025131140.png)

2.下载完成后打开exe文件安装即可。可以简单测试一下

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/70.gif)

## pandoc安装

1.pandoc官网获取安装包：https://github.com/jgm/pandoc/releases/tag/2.2.1
进入官网如下所示：选择适合自己系统的安装包(博主选择的是win-64位的.msi)

![这里写图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/70.gif)

**说明：**

因为github的服务器在国外，所以下载的速度可能会非常慢。或者链接超时，这里提供一个百度云链接。

链接：https://pan.baidu.com/s/1RmODxICewSbii5Bc_VjNOg 密码：346h

2.安装：

 双击安装，一路默认就可以了。安装完成之后测试一下安装结果。

 打开cmd控制台，输入`pandoc –-version`，出现以下结果则说明安装成功。

![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/20200615171458745.png)

## 使用Typora测试导出word

**说明：**
在安装完pandoc之后，执行导出word功能时还是提示安装pandoc，此时可重新启动电脑，或者卸载typora，然后再安装–再开始导出word文件。
完成上述操作之后，将可以方便的使用pandoc的.md转其他格式。
在前面使用Typora随便写了一个.md文件，现在进行导出word。
1：.md文件(原始文件)点击左上角文件，选择导出，选择word格式，则可以导出word文档。

![这里写1图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/70-16325090430439)

# word转换为Markdown

## 下载并安装Writage

1.打开网站www.writage.com，点击download now开始下载。

![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MzMxNDUxOQ==,size_16,color_FFFFFF,t_70.png)

2.运行安装程序，按照默认选项即可。安装完成后重启电脑。

![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MzMxNDUxOQ==,size_16,color_FFFFFF,t_70-163250904304411)
3.使用office word新建或打开任意一个文档，在文件 菜单栏下选另存为，查看保存类型中是否有Markdown格式。

，查看保存类型中是否有Markdown格式。

![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MzMxNDUxOQ==,size_16,color_FFFFFF,t_70-163250904304412)

4.选择Markdown格式保存即可。



 
