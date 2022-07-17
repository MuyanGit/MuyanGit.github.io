---
title: '   auto.js 精品基础教程 2021最新版 auto.js教程  '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorLink: 
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-09-09 02:51:33
tags:
keywords:
description:
photos:
---

set 限制解除 

[![CSDN首页](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109090252992.png)](https://www.csdn.net/)

- [ 绿化设定](javascript:void(0))
- [博客](https://blog.csdn.net/)
- [下载](https://download.csdn.net/)
- [问答](https://ask.csdn.net/)
- [社区](https://www.csdn.net/c/)
- [插件](https://so.csdn.net/marketing/download.html?invitationCode=U23CJF4&from=0802toobar)
- [认证](https://ac.csdn.net/?short_code=13271b93)

 搜索

[登入](https://passport.csdn.net/account/login)

[会员中心 ![img](https://img-home.csdnimg.cn/images/20210831040447.png)](https://mall.csdn.net/vip)

[收藏](https://i.csdn.net/#/user-center/collection-list?type=1)

[动态](https://blink.csdn.net/)

[创作](https://mp.csdn.net/)

# Auto.JS 教程（1）+auto.js 精品基础教程 2021最新版 auto.js教程

**声明：** 本教程基于b站up主-笔青居的视频。传送门：https://space.bilibili.com/21486893/video

https://www.bilibili.com/video/BV1HZ4y1c7rW?p=18

# Auto.JS

`Auto.js` 是个基于 `JavaScript` 语言运行在Android平台上的脚本框架。Auto.js主要工作原理是基于辅助服务`AccessibilityService`。

## 功能介绍：

1. 数据监控：可以监视当前手机的数据。
2. 图片监控：截图获取当前页面信息。
3. 控件操作：模拟操作手机控件。
4. 自动化工作流：编写简单的脚本，完成一系列自动化操作。如：微信/QQ自动点赞，快速抢单等。
5. 定时功能：定时执行某个脚本，来完成定时任务。如：定时打卡签到等。

## 项目介绍：

- 项目地址：https://github.com/hyb1996/Auto.js
- 官方论坛：https://www.autojs.org/
- 在线文档：https://hyb1996.github.io/AutoJs-Docs/#/
- 简介：一个支持无障碍服务的Android平台上的Javascript IDE,其发展目标是JsBox和Workflow。
- 主要功能：由无障碍服务实现的简单易用的自动操作函数
- 协议：基于Mozilla Public License Version 2.0

**手机安装使用步骤：**

① 开启无障碍服务
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109090252282.png)
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109090252492.png)
② 音量上键停止脚本：当脚本处于无法停止的状态时，使用音量上键强制停止脚本。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190212152035620.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L1FpSHNNaW5n,size_16,color_FFFFFF,t_70)
③ 开启悬浮窗：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190212152445833.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L1FpSHNNaW5n,size_16,color_FFFFFF,t_70)
**悬浮窗有4个控件：**

1）脚本列表
2）自动录制
3）`布局范围分析` 与 `布局层次分析`

4）更多

![在这里插入图片描述](https://img-blog.csdnimg.cn/20190212152915187.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L1FpSHNNaW5n,size_16,color_FFFFFF,t_70)

**auto的优点：**

1）开源:代码开源，可以查到源码。

2）无需root：Android 7.0以上功能基本不需要root。

3）免费。

4）易用：代码自动生成。

5）语言：标准的JS语法。

6）灵活。

7）扩展：提供JS转JAVA桥梁，存在无限多的扩展。

**提倡自动动手编写Auto.JS脚本**

1）安全：Auto.JS脚本拥有很大的权限，使用他人的脚本可能存在风险。

2）编写简单：JS 脚本嵌套中文，方便阅读和书写。

3）脚本升级：一旦APP版本升级，原脚本可能不使用了。

4）提升自己的编写代码能力和解决问题能力。

## PC环境的搭建

#### VS Code 安装

VS Code 入门教程：https://blog.csdn.net/QiHsMing/article/details/87064955

Visual Studio Code 官方下载地址：[https://code.visualstudio.com](https://code.visualstudio.com/) 根据你的电脑平台选择版本下载。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190212100951299.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L1FpSHNNaW5n,size_16,color_FFFFFF,t_70)
新建项目文件夹，右键点击 `Open with Code` 在VS Code 中打开。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190212101417620.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L1FpSHNNaW5n,size_16,color_FFFFFF,t_70)

#### 安装 AutoJS 插件

点击 `扩展` 搜索 `Auto.js` 或 `hyb1996` 即可找到Auto.JS插件。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190212102009209.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L1FpSHNNaW5n,size_16,color_FFFFFF,t_70)

#### 使用AutoJS插件开发

**`1.开启AutoJS插件`**

按 Ctrl+Shift+P 或点击"查看"->"命令面板"可调出命令面板，输入 Auto.js 可以看到几个命令，移动光标到命令Auto.js: Start Server，按回车键执行该命令。

![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109090252899.png)
此时VS Code会在右上角显示"Auto.js server running"，即开启服务成功。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190212123034551.png)
**`2.连接手机终端`**

将手机连接到电脑启用的Wifi或者同一局域网中。通过命令行ipconfig(或者其他操作系统的相同功能命令)查看电脑的IP地址。在Auto.js的侧拉菜单中启用调试服务，并输入IP地址，等待连接成功。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190212153240291.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L1FpSHNNaW5n,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109090252192.png)
一旦连接成功，VS Code 显示:
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109090252586.png)

在电脑上编辑JavaScript文件并通过命令Run或者按键F5在手机上运行。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190212153659730.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L1FpSHNNaW5n,size_16,color_FFFFFF,t_70)
手机终端运行结果：
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109090252817.png)

**`3.保存项目到手机终端`**
按 Ctrl+Shift+P 或点击"查看"->"命令面板"可调出命令面板，输入以下命令，会找到已连接手机终端。

```
  Auto.js:SaveToDevice
1
```

![在这里插入图片描述](https://img-blog.csdnimg.cn/20190212154206965.png)
点击已连接手机终端，项目就会保存到已连接手机终端。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190212154512743.png)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190212154531485.png)

#### AutoJS插件常用命令

按 Ctrl+Shift+P 或点击"查看"->"命令面板"可调出命令面板，输入 Auto.js 可以看到几个命令：

`Start Server`: 启动插件服务。之后在确保手机和电脑在同一区域网的情况下，在Auto.js的侧拉菜单中使用连接电脑功能连接。
`Stop Server`: 停止插件服务。
`Run` 运行当前编辑器的脚本。如果有多个设备连接，则在所有设备运行。
`Rerun` 停止当前文件对应的脚本并重新运行。如果有多个设备连接，则在所有设备重新运行。
`Stop` 停止当前文件对应的脚本。如果有多个设备连接，则在所有设备停止。
`StopAll` 停止所有正在运行的脚本。如果有多个设备连接，则在所有设备运行所有脚本。
`Save` 保存当前文件到手机的脚本默认目录（文件名会加上前缀remote)。如果有多个设备连接，则在所有设备保存。
`RunOnDevice`: 弹出设备菜单并在指定设备运行脚本。
`SaveToDevice:` 弹出设备菜单并在指定设备保存脚本。
`New Project`（新建项目）：选择一个空文件夹（或者在文件管理器中新建一个空文件夹），将会自动创建一个项目
`Run Project`（运行项目）：运行一个项目，需要Auto.js 4.0.4Alpha5以上支持
`Save Project`（保存项目）：保存一个项目，需要Auto.js 4.0.4Alpha5以上支持

以上命令一些有对应的快捷键，参照命令后面的说明即可。

**简单脚本实例：** 实现微信朋友圈点赞

**步骤：**

1. 找到评论按钮
2. 点击评论按钮
3. 找到点赞按钮
4. 点击点赞按钮

代码：

```
评论=desc("评论").findOne();
log(评论);
评论.click();
sleep(1000);
赞 = text("赞").findOne();
赞的父控件 = 赞.parent();
赞的父控件.click();	
1234567
```



 
