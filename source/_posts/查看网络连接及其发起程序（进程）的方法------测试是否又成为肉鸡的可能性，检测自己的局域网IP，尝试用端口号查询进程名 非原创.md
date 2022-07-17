---
title: 查看网络连接及其发起程序（进程）的方法------测试是否又成为肉鸡的可能性，检测自己的局域网IP，尝试用端口号查询进程名 非原创
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorLink: 
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-09-09 02:37:06
tags:
keywords:
description:
photos:
---

# 查看网络连接及其发起程序（进程）的方法------测试是否又成为肉鸡的可能性，检测自己的局域网IP，尝试用端口号查询进程名

 原创

[netside](https://blog.51cto.com/netside)2013-04-12 15:50:19©著作权

*文章标签*[查看进程](https://blog.51cto.com/topic/zhakanjincheng.html)[查看网络连接](https://blog.51cto.com/topic/zhakanwangluolianjie.html)[进程流量](https://blog.51cto.com/topic/jinchengliuliang.html)*文章分类*[非专业知识](https://blog.51cto.com/netside/category4)*阅读数*2.2万

一些上网行为管理设备会记录、统计用户发起的网络连接信息，常统计出一些不明的、对一些公网IP的连接请求，依经验往往是由用户机器上装的一些软件（特别是国产软件）引起的，有的还会产生很大的上传流量。部分连接会被上网行为管理设备依据设定的规则来阻止掉，这时候需要把这些进程（应用程序）纠出来，告诉用户，打消疑问。

**方法一：命令行下，使用****netstat命令。**

第一步，查看TCP连接，找出对应的PID；

netstat -ano -p tcp or：netstat -ano | find "ESTABLISHED"

注释：1.如果使用find就不用再使用-p来指定是不是tcp协议了。

2.参数-o表示显示发起连接的进程的ID（PID）。

第二步，使用tasklist命令列出发起连接的进程；

tasklist | find "PID"

当然，也可以在“任务管理器”中查看，效果一样。

**方法二：图形界面中，通过Windows自带的“资源监视器（Resource Monitor）”来查看TCP连接。**

先打开“任务管理器”（Ctrl+Shift+Esc），然后切换到“性能”，在窗口右下角就能找到。

 

[![查看网络连接及其发起程序（进程）的方法_进程流量](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109090237758.jpeg)](https://s4.51cto.com/attachment/201304/155418430.jpg)

**方法三：使用软件 TcpView。**
