---
title: Typora+PicGO+Gitee图床配置
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorLink: 
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-09-06 21:28:37
tags:
keywords:
description:
photos:
---

# 



# 1·插件无法安装-删除以下所有-git clone -https://github.com/lizhuangs/picgo-plugin-gitee-uploader.git



![image-20211106234116036](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/GtWBSbaCFQVjc6O.png)





# 3·再次启用插件后`确认配置

![image-20211106234635545](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211106234635545.png)



# **Typora+PicGO+Gitee图床配置**

我们在写markdown文档的时候，如果说写的文档有插入图片的话，图片管理起来非常的麻烦，而且移动或复制文档到其他设备时必须把图片的文件夹也一起复制。图片在markdown文档中就是一个链接，这个链接可以是本地的文件路径也可以是网络路径（url)。所以我们可以把图片放到网络上集中管理（这个就叫着[图床](https://so.csdn.net/so/search?q=图床&spm=1001.2101.3001.7020)），写文档的时候插入图片只要插入相应图片的url就可以了，在其他设备查看文档只要有网络就可以加载图片。

下面我们使用[Typora](https://so.csdn.net/so/search?q=Typora&spm=1001.2101.3001.7020)写Markdown文档，用PicGo上传图片，图片放在gitee仓库中。整个过程虽然看起来比较麻烦，但是只要配置好，所有的一切动作都是自动完成的。

## 1. Typora安装配置

### 1.1 安装

下载[Typora](https://www.typora.io/)，Typora的安装比较简单，和普通软件安装一样，可参考[B站视频（包括Markdown语法介绍）](https://www.bilibili.com/video/BV1rf4y1t7Nz?spm_id_from=333.999.0.0)

### 1.2 配置

打开Typora，文件->偏好设置->图像

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/266f919b377fd1544549d24e18a92eb7.png)

按照上图的配置Typora，其中 **PicGo路径** 的选项是安装了PicGO会自动检测的，如果没有自动检测到PicGO软件的路径可以手动填写。PicGo软件的安装和配置在下面会详细说明。

Typora软件的配置就这样完成了，安装PicGo再把PicGo路径填好就可以了

## 2. PicGo和Gitee图床配置

### 2.1 PicGo安装

[PicGo下载](https://github.com/Molunerfinn/picgo/releases) ， 我们可以看到在Typora的设置中也有PicGo的下载地址，这个按钮跳转的地址和我给出的是一样的。

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/fbf2fdcfa3e8af9a61cf61c31d994ffd.png)

### 2.2 PicGo插件安装

安装插件之前需要安装Nodejs，因为PicGo的插件需要Nodejs才可以使用，

[下载Node.js](http://nodejs.cn/download/)，版本没有多大的关系，建议下载LTS版的

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/65d9fbdcd479cb45ed57eacf96c87437.png)

下载安装Nodejs后，打开PicGo，在插件设置中搜索gitee，下载图中框选的那个，**一定要下载这个，其他的gitee插件的配置会有些许的不同**

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/1502a2ce5728a2d8a1acdac042811274.png)

### 2.3 gitee仓库创建

仓库的名称可以随意写，这里以ImageBed为例，一定要初始化仓库

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/8d79e08f9fcafdc806a38dfd6e4d844d.png)

生成token，打开gitee的设置，点击生成新令牌

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/1297dd610bbb79e0c1fe273db092ddbc.png)

Token的权限设置如下，令牌的描述同样是可以随意写的，权限设置如图，点击提交，会提示输入gitee账号密码 **把生成的token复制保存，配置PicGo需要**

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/a666b601243238c7bf3e0ea91cf1eca3.png)

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/ab2c17cfa033a2d7877e68ab3d95bff5.png)

### 2.3 PicGo配置

jsdelivr加速域名配置2022年8月19日·星期5·16·16·20.png



![image-20220819164214344](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url/img202208191649264.png)



![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/5430f746350a599e2c74581e28349ef1.png)

- repo: 填写仓库的名称，这个名称是地址栏的一部分，**不是下面绿框中的名称**

- repo: 填写仓库的名称，这个名称是地址栏的一部分，**不是下面绿框中的名称**

  ![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/0a1b74a4bd50bd65925147cc96fd340f.png)

- branch：填写分支的名称，一般为master

- token：填写我们刚刚生成的令牌

- path: 如果图片是放在仓库的根目录可以不填，放在文件夹下可以填写文件夹的名字，如果仓库中没有这个文件夹，它会自动创建

- 后面两个可以不要填

## 3. 测试

选择gitee图床，从本地上传图片测试是否可以上传成功

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/62d7eb2d3d7b25a8ffb5216726ac1ebf.png)

在Typora的使用，我们不需要手动上传图片，因为前面配置过了Typora，所以只要把图片插入到markdown文档中，Typora会自动运行PicGo上传图片，并将markdown中的图片链接替换成URL。
