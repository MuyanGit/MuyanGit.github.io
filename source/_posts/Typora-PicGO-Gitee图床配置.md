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

# 1·**Typora+PicGO+Gitee****图床**

我们在写markdown文档的时候，如果说写的文档有插入图片的话，图片管理起来非常的麻烦，而且移动或复制文档到其他设备时必须把图片的文件夹也一起复制。图片在markdown文档中就是一个链接，这个链接可以是本地的文件路径也可以是网络路径（url)。所以我们可以把图片放到网络上集中管理（这个就叫着图床），写文档的时候插入图片只要插入相应图片的url就可以了，在其他设备查看文档只要有网络就可以加载图片。

下面我们使用Typora写Markdown文档，用PicGo上传图片，图片放在gitee仓库中。整个过程虽然看起来比较麻烦，但是只要配置好，所有的一切动作都是自动完成的。

**1. Typora****安装配置**

**1.1** **安装**

下载[Typora](https://www.typora.io/)，Typora的安装比较简单，和普通软件安装一样，可参考[B站视频（包括Markdown语法介绍）](https://www.bilibili.com/video/BV1rf4y1t7Nz?spm_id_from=333.999.0.0)

**1.2** **配置**

打开Typora，文件->偏好设置->图像

![说明: https://cdn.nlark.com/yuque/0/2021/png/21450199/1630591557445-763e3b8f-80e1-4025-9e74-e1752914881a.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109061829704.png)

按照上图的配置Typora，其中 **PicGo****路径** 的选项是安装了PicGO会自动检测的，如果没有自动检测到PicGO软件的路径可以手动填写。PicGo软件的安装和配置在下面会详细说明。

Typora软件的配置就这样完成了，安装PicGo再把PicGo路径填好就可以了

**2. PicGo****和Gitee图床配置**

**2.1 PicGo****安装**

[PicGo下载](https://github.com/Molunerfinn/picgo/releases) ， 我们可以看到在Typora的设置中也有PicGo的下载地址，这个按钮跳转的地址和我给出的是一样的。

![说明: https://cdn.nlark.com/yuque/0/2021/png/21450199/1630591557463-f09e4b40-4f7f-46c4-92f7-416c1bd08c1e.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109062129007.png)

若是失败，请检查PicGo端口

![image-20210906191027442](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109062129756.png)

**2.2 PicGo****插件安装**

安装插件之前需要安装Nodejs，因为PicGo的插件需要Nodejs才可以使用，

[下载Node.js](http://nodejs.cn/download/)，版本没有多大的关系，建议下载LTS版的

![说明: https://cdn.nlark.com/yuque/0/2021/png/21450199/1630591557514-f7a10393-3e2a-4cf0-aebe-a4a72bbe69b7.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109062129133.png)

下载安装Nodejs后，打开PicGo，在插件设置中搜索gitee，下载图中框选的那个，**一定要下载这个，其他的gitee插件的配置会有些许的不同**

![说明: https://cdn.nlark.com/yuque/0/2021/png/21450199/1630591557460-d4d47147-f0ae-4dc1-9818-e33c343f4e41.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109062129832.png)

**2.3 gitee****仓库创建**

仓库的名称可以随意写，这里以ImageBed为例，一定要初始化仓库

![说明: https://cdn.nlark.com/yuque/0/2021/png/21450199/1630591557516-aada9afe-90ba-4ab1-8256-f037cb48db65.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109062129132.png)

生成token，打开gitee的设置，点击生成新令牌

![说明: https://cdn.nlark.com/yuque/0/2021/png/21450199/1630591559340-7840fc5f-2991-4a56-836c-d0d463efb047.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109062129724.png)

Token的权限设置如下，令牌的描述同样是可以随意写的，权限设置如图，点击提交，会提示输入gitee账号密码 **把生成的token复制保存，配置PicGo需要**

![说明: https://cdn.nlark.com/yuque/0/2021/png/21450199/1630591559317-ccb01af0-e510-4f0e-9472-058c77c5433d.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109062129361.png)

![说明: https://cdn.nlark.com/yuque/0/2021/png/21450199/1630591559293-77f34d60-1254-44d3-861a-ac7894e58d28.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109061829416.png)



**2.3 PicGo****配置**，

若是不配置则自动上传到SM.SM【Error: This image has been blocked, please contact webmaster for more information.++++[PicGo Server] upload failed, see picgo.log for more detail ↑ 】

[picgo的文档l#命令行上传)](https://picgo.github.io/PicGo-Doc/zh/guide/advance.html#命令行上传)

![说明: https://cdn.nlark.com/yuque/0/2021/png/21450199/1630591559344-d6f571e2-fbdc-423a-9d0e-c15bd2ec1cef.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109062129572.png)

·     repo: 填写仓库的名称，这个名称是地址栏的一部分，**不是下面绿框中的名称**![说明: https://cdn.nlark.com/yuque/0/2021/png/21450199/1630591559486-a1c76e60-92bc-4804-86fc-955a15e4eea0.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109062129927.png)

·     branch：填写分支的名称，一般为master

·     token：填写我们刚刚生成的令牌

·     path: 如果图片是放在仓库的根目录可以不填，放在文件夹下可以填写文件夹的名字，如果仓库中没有这个文件夹，它会自动创建

·     后面两个可以不要填

**3.** **测试**

选择gitee图床，从本地上传图片测试是否可以上传成功

![说明: https://cdn.nlark.com/yuque/0/2021/png/21450199/1630591560470-8980fba9-ab75-4626-b633-8db4baa85f34.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109062129229.png)

在Typora的使用，我们不需要手动上传图片，因为前面配置过了Typora，所以只要把图片插入到markdown文档中，Typora会自动运行PicGo上传图片，并将markdown中的图片链接替换成URL。



![image-20210906191307303](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109062129465.png)

解决：picgo+gitee中出现StatusCodeError: 404 - {“message”:“Branch”}

 若是上传失败，请检查，404{“message“："Branch”}

![image-20210906191146263](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109061914812.png)

用picgo+gitee作为typora的图床时候，出现下面的错误

```------Error Stack Begin------
StatusCodeError: 404 - {"message":"Branch"}
    at new StatusCodeError (D:\Program Files\picgo\resources\app.asar\node_modules\request-promise-core\lib\errors.js:32:15)
    at Request.plumbing.callback (D:\Program Files\picgo\resources\app.asar\node_modules\request-promise-core\lib\plumbing.js:104:33)
    at Request.RP$callback [as _callback] (D:\Program Files\picgo\resources\app.asar\node_modules\request-promise-core\lib\plumbing.js:46:31)
    at Request.self.callback (D:\Program Files\picgo\resources\app.asar\node_modules\request\request.js:185:22)
    at Request.emit (events.js:200:13)
    at Request.<anonymous> (D:\Program Files\picgo\resources\app.asar\node_modules\request\request.js:1161:10)
    at Request.emit (events.js:200:13)
    at IncomingMessage.<anonymous> (D:\Program Files\picgo\resources\app.asar\node_modules\request\request.js:1083:12)
    at Object.onceWrapper (events.js:288:20)
    at IncomingMessage.emit (events.js:205:15)

原因：在创建的仓库的时候，没有初始化readme
```

解决：初始化就可以解决这个问题。
————————————————







# 1·插件无法安装-删除以下所有-git clone -https://github.com/lizhuangs/picgo-plugin-gitee-uploader.git



![image-20211106234116036](https://i.loli.net/2021/11/06/GtWBSbaCFQVjc6O.png)





# 3·再次启用插件后`确认配置

![image-20211106234635545](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211106234635545.png)
