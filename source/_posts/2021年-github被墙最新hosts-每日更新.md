---
title: '  2021年 github被墙最新hosts-每日更新   '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorLink: 
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-09-09 04:07:18
tags:
keywords:
description:
photos:
---

## （2）如何修改hosts

那么如何修改hosts呢？下面将介绍windows和Mac系统的设置方法：

**windows：**

1、文本编辑器“管理员权限”打开 C:\Windows\System32\drivers\etc\hosts 文件，新增一行，复制上面每日更新的内容并保存即可。

2、命令行执行 ipconfig /flushdns 刷新 dns，或者重启电脑。



**mac（苹果PC系统）：**

1、文本编辑器打开 /etc/hosts 文件，新增一行，同上，复制上面每日更新的hosts内容即可。

2、 命令行执行 sudo killall -HUP mDNSResponder ，或者重启电脑。

## （3）常见问题

当然，**ip和域名并非一直都绑定不变**，**一个ip可以绑定多个域名，一个域名也可以设置多个IP。**有一些ip在不同地方还是无法访问！所以还是需要检查下资源链接。是否都加载成功：

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109090410856.png)

可以看到 `api.github.com` 这个没有设置ip，访问就需要3s才加载完成。所以设置就好了。。。

## （3）备注

host方法并非一定有效，据我所知github采用的是 **亚马逊的服务器**，而亚马逊和google服务器由于某些总所周知的原因，分布在海外，很多都延时很大，多个数据中心访问延时也不同
