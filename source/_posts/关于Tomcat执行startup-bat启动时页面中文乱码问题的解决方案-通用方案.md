---
title: 关于Tomcat执行startup.bat启动时页面中文乱码问题的解决方案(通用方案)
author: MuyanGit
categories: 技术
date: 2022-07-22 20:30:33
tags:
photos:
---



**[关于Tomcat执行startup.bat启动时页面中文乱码问题的解决方案(通用方案)](https://www.cnblogs.com/Her4c/p/12671224.html)**

**本文解决方案仅用于执行startup.bat启动时**

**方案一：**

**1.****首先要知道的是，中文乱码一定是编码方式不一致导致的(废话...)**

 ps： 你：这个不影响使用为什么要改它呢？(我：影响美观，其实就是强迫征)

![https://img2020.cnblogs.com/blog/1937355/202004/1937355-20200410085211686-1379648588.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202207222140700.png)

**2.****其次我们要找到Tomcat目录下的****.properties****配置文件**

例：D:\myapp\apache-tomcat-7.0.103\conf\logging.properties

我这里用到是Sublime Text(其他编辑器也是大差不差的)，Ctrl+H 替换，Find：输入UTF-8 编辑器会高亮提醒，Replace：输入GBK，点击 Replace ALL即可完成替换

![https://img2020.cnblogs.com/blog/1937355/202004/1937355-20200410090757816-627684003.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202207222141869.png)

![https://img2020.cnblogs.com/blog/1937355/202004/1937355-20200410090812319-1256920844.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202207222140890.png)

**3.****最后，修改替换之前有必要****备份****一下原文件(****.properties****)****，替换完成记得保存文件，再次重启服务器即可**

![https://img2020.cnblogs.com/blog/1937355/202004/1937355-20200410091149567-542045342.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202207222140912.png)

 

 

 

\#以上方式理论上通用其他版本

 **方案二：**

**更改操作系统默认字符集为UTF-8**

·    这里以Win10为例：控制面板 > 时钟和区域 > 管理 > 更改系统区域设置 > (勾选)Beta版：使用Unicode UTF-8 提供全球语言支持 点击确定之后重启系统即可

·    开机之后你会发现DPI会有所改变，但这并不影响使用、有些文件目录名会有乱码的现象(不按标准的"随地大小便现象"，以及确实不方便完善的情况)；

·    以QQ为例，个人文件夹目录名会中文乱码(如果你的缓存目录为英文，则不会存在这种情况) ，但它原本的文件夹依然存在(它会复制之前的缓存目录)，进入QQ在进行一次设置即可

·    如果你参照第一种方案设置好后，就没必要用第二种方案了

·    如果你觉得麻烦，那不推荐你使用这种方法(个人觉得第二种方案更加合理)

·    同理想要改回默认，勾掉 Beta版：使用Unicode UTF-8 提供全球语言支持 点击确定，重启系统即可回到默认状态

![https://img2020.cnblogs.com/blog/1937355/202004/1937355-20200417203036899-310536633.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202207222140886.png)

 **最终效果图**

![https://img2020.cnblogs.com/blog/1937355/202004/1937355-20200417205839920-1496183287.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202207222144047.png)

 

 



