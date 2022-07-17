---
title: 'MUyangit的Vscode设置     '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorLink: 
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-09-16 17:01:25
tags:
keywords:
description:
photos:
---

界面设置

# 1·vscode 隐藏右侧进度条-小地图预览

Visual Studio Code（VSCode）关闭右侧预览功能

关闭方法：点击文件-首选项-设置,搜索"editor.minimap.enabled",默认值为打钩,我们只需要把钩去掉即可；

![img](https://i.loli.net/2021/09/16/Uu1YWNrZqp2FEtd.jpg)



# 2·调出菜单栏





# 3·VScode如何在浏览器中打开html文件

1.新建一个HTML文件



2.点击左侧的扩展，打开扩展栏



3.在扩展栏的搜索栏中输入open in browser，找到open in browser这款插件，点击右下角“安装”字样即可安装。

因为我已经安装了，所以再搜索不会显示安装字样


4.安装完成后可以看一下这款插件的扩展文档，里面有插件的各种信息，及插件的使用方式等

我们可以看到在默认浏览器中打开是：Alt + B，在其他浏览器中显示是：Shift+Alt+B


5.回到我们刚开始建的HTML文件，在文件中鼠标右键单击，在弹出的窗口中选择使用默认浏览器打开或者其他浏览器打开，也可以使用我们上面说的快捷键（Alt + B或Shift+Alt+B）打开。



6.假如你想用其他浏览器打开，就选择Open In Other Browsers（Shift+Alt+B，顶部会出现一个命令框，其中会显示可以使用的浏览器，选择自己需要的浏览器即可，在此，我们使用chrome打开。

![image-20210916175015037](https://i.loli.net/2021/09/16/cIminsXvBawuUR3.png)





## VSCode设置网页代码实时预览

![img](https://i.loli.net/2021/09/16/lV6MpTfoYqGPj9r.png)





![img](https://i.loli.net/2021/09/16/JC94wKZe3p1OlUE.png)

接下来修改代码我们只需要ctrl+S保存修改后的代码，浏览器自动刷新







# [VScode中配置git的路径](https://segmentfault.com/a/1190000021898415)

[![img](https://avatar-static.segmentfault.com/781/199/781199053-5f0eb6886d467_huge128)**RadiomM**](https://segmentfault.com/u/radiomm_5d22c22757383)发布于 2020-03-03

最近才开始用VScode写代码，因为之前用的都是webstorm的，虽然好用啊但是经常需要激活，而且激活码变得越来越难找的，所以就改用VScode的。

开始进入主题。今天装完插件Gitlens的时候报错了，说找不到git的路径。
![2020-03-03_111734.png](https://gitee.com/muyangit/blog-img/raw/master/img/202110220001632.png)

经过十几分钟的百度，终于知道如何配置了git的路径了（前提是你电脑已经安装好了git）。
1.打开vs的设置
![2020-03-03_112425.png](https://segmentfault.com/img/bVbD2UW)

2.搜索git.path，冰灾setting.json中打开
![2020-03-03_112509.png](https://segmentfault.com/img/bVbD2Vb)

3.找到你的git.exe的位置，如图这是我的git.exe的位置，将地址复制。
![2020-03-03_112600.png](https://gitee.com/muyangit/blog-img/raw/master/img/202110220001878.png)

4.直接复制在setting.json中
![2020-03-03_112633.png](https://segmentfault.com/img/bVbD2Vx)

明显这是个报错，不能用单斜杠，而是用双斜杠。
![2020-03-03_112652.png](https://gitee.com/muyangit/blog-img/raw/master/img/202110220001544.png)

好了，重启VScode就不会报错了，并且可以使用Gitlens的功能了。希望能帮助大家少踩坑，如果有帮助希望点了赞，谢谢。

![image-20211022000351300](https://gitee.com/muyangit/blog-img/raw/master/img/202110220003368.png)







# 在项目中无法正确导入VS code python 环境下提示找不到 module

{
    // 使用 IntelliSense 了解相关属性。 
    // 悬停以查看现有属性的描述。
    // 欲了解更多信息，请访问: https://go.microsoft.com/fwlink/?linkid=830387
    "version": "0.2.0",
    "configurations": [
    
        {
           "name": "Python",
            "type": "python",
            "request": "launch",
            "stopOnEntry": false,
            "pythonPath": "${config:python.pythonPath}",
            "program": "${file}",
            "cwd": "${workspaceRoot}",
            "env": {"PYTHONPATH":"${workspaceRoot}"},
            "envFile": "${workspaceRoot}/.env",
            "debugOptions": [
            "WaitOnAbnormalExit",
            "WaitOnNormalExit",
            "RedirectOutput"
    
        }
    ]
}
