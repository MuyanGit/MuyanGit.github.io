---
title: '  # [教程]免费域名注册及域名解析(freenom&cloudflare)   '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-10-24 00:05:40
authorLink:
tags:
keywords:
description:
photos:
---

[Skip to content](https://zhujitips.com/328#content)

[主机贴士](https://zhujitips.com/)

搬瓦工|BandwagonHost VPS|Vps|主机推荐

[加入Telegram群组](https://t.me/BWH1NET)[关于本站](https://zhujitips.com/about)[教程](https://zhujitips.com/category/教程)[[VPS\]推荐](https://zhujitips.com/841)

# [教程]免费域名注册及域名解析(freenom&cloudflare)

4月17日更新• [cloudflare解析](https://zhujitips.com/tag/cloudflare解析) • [freenom免费域名](https://zhujitips.com/tag/freenom免费域名)•[教程](https://zhujitips.com/category/教程)•阅读:13,621次

> 看到有群友不会搞域名注册和域名解析的，特写了一份教程送上，希望有所帮助。
>
> 本教程用到3个网站：
>
> 1.免费域名注册网站https://www.freenom.com
>
> 2.免费域名解析CDN网站https://www.cloudflare.com
>
> 3.google邮箱（你也可以用别的邮箱，建议使用google邮箱）
>
> 备注：申请的域名，一定要搞个二级域名，解析到一个网站，反正大家不缺vps，搭建一个网站指向好。域名没有网站指向的话，会被回收。切记切记！
>
> 比如申请的域名是abc123.tk,那么在cf域名解析的时候，一定要指向个二级域名给实际网站，建议使用常规的www，做个A记录：www -> ip:你搭建的网站ip，这里有教你怎么[搞个自己的网站](https://zhujitips.com/340)。博主自2018.1月申请的免费域名用到现在还正常，没被回收。祝好运！

![img](https://zhujitips.com/wp-content/uploads/2018/11/freenom/01.png)

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006751.png)

输入你希望的域名，如abc123.tk，那么在上面的红框里输入abc123就行

![img](https://zhujitips.com/wp-content/uploads/2018/11/freenom/03.png)

它提供了蛮多免费域名后缀，自己选吧，点击现在获取。

![img](https://zhujitips.com/wp-content/uploads/2018/11/freenom/04.png)

点击完成

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006494.png)

点击红框里，选择12个月的免费，点击继续。

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006163.png)

输入你的邮箱，建议google邮箱，点击验证邮箱。

![img](https://zhujitips.com/wp-content/uploads/2018/11/freenom/07.png)

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006605.png)

截图的时候搞错了，不用点击箭头所指。
登录你的邮箱，查看freenom给你发来的验证邮件。其他邮箱不一定在收件箱，没有的话，去垃圾箱看看。

![img](https://zhujitips.com/wp-content/uploads/2018/11/freenom/09.png)

点击箭头所指

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006705.png)

输入你的一些信息，继续往下滚动，填写

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006540.png)

勾选，并完成

![img](https://zhujitips.com/wp-content/uploads/2018/11/freenom/12.png)

点击进入管理后台登录页面。

![img](https://zhujitips.com/wp-content/uploads/2018/11/freenom/13.png)

输入你的邮箱及相应密码，点击LOGIN登录。

![img](https://zhujitips.com/wp-content/uploads/2018/11/freenom/14.png)

在“服务”下拉菜单下“我的域名”

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006449.png)

点击“管理域名”

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006218.png)

点击如图所示，修改域名dns

切换自定义服务，输入cloudfrare的免费域名服务器地址

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006895.png)

（注:我这里按照惯性，直接输入了我原来cf账号上看的地址，结果发现今天做教程时，cf给了我新的域名服务器地址，最后有做修改）

查看状态，激活状态，freenom免费域名部分结束。

------

![img](https://zhujitips.com/wp-content/uploads/2018/11/cf/01.png)

打开https://www.cloudfrare.com；后期登陆使用谷歌的图片验证接口需要墙

修改了语言，但是我之后看到的还是英文，各位看官，随意

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006496.png)

![img](https://zhujitips.com/wp-content/uploads/2018/11/cf/03.png)

点击注册

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006665.png)

输入你的邮箱，建议还是刚搞freenom时用的google邮箱，点击创建账号

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006700.png)

到你的邮箱中，找到cf发来的验证邮件，并完成验证

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006095.png)

已完成验证，点击继续进入仪表盘

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006221.png)

点击增加站点

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006455.png)

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006691.png)

输入刚才freenom注册的域名，如abc123.tk



![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006122.png)

![img](https://zhujitips.com/wp-content/uploads/2018/11/cf/11.png)

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006235.png)

选择免费方案
点击确认



输入你要的二级域名，这里只要前缀就好，如：

你希望hk.abc123.tk解析到你的vps，那么

第一个红框里输入hk，第二个红框里输入你的vps ip地址

如果你是准备搞nat ddns，那么

第一个红框里输入hk，第二个红框里建议输入127.0.0.1，方便查看变动（也可以随意输入）

后面的橘色云朵，请点击一下，让他变灰色，表示不使用cdn，然后点击增加记录

------

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006078.png)

![img](https://zhujitips.com/wp-content/uploads/2018/11/cf/14.png)

这就是前文所说的，惯性添加了域名解析服务器，结果发现，今天教程是，cf给了我新的解析服务器，那么就更新修改它吧。

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240006457.png)

回到freenom网站，登录相关页面,不细说了，不记得的话，前文找

过了几分钟后，收到cloudflare发来邮件，说更新成功。

------

看nat ddns怎么搞的，请点击[传送门](https://zhujitips.com/299)

> 看我写的这么辛苦，请收藏一下本站吧。主机贴士https://zhujitips.com
>
> 欢迎加入[TG群讨论](https://t.me/BWH1NET)
>
> 转帖，请带上本尾巴。谢谢！
>
> 教程到此结束！

[教程](https://zhujitips.com/category/教程)

 [cloudflare解析](https://zhujitips.com/tag/cloudflare解析), [freenom免费域名](https://zhujitips.com/tag/freenom免费域名)

