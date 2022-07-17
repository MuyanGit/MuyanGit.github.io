title: V2Ray路由器高级功能配置丨使用教程
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2021-11-10 19:42:14
authorAbout:
series:
tags: 工具
keywords:
description:

photos: https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110194238779.png
---







# 无需配置--> 直接自动配置系统代理

查看IP代理情况：http://ip111.cn/

![image-20211111141552523](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211111141552523.png)



![image-20211111141623424](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211111141623424.png)

































已经删除PAC功能的主流V2Ray客户端V2RayN，要完美实现GFW黑名单代理模式，只能启用高级路由功能。当您使用过功能更强大的高级路由，就会理解开发人员去掉PAC代理模式并非没有理由。

前面分享了我在用的高级路由规则集：

[《V2Ray路由器配置PAC代理规则集丨GFWlist黑名单模式》](https://baiyunju.cc/7523)　https://baiyunju.cc/7523

[《V2RayN高级路由器配置规则集丨黑白名单、全局直连、全局代理模式》](https://baiyunju.cc/7753)　https://baiyunju.cc/7753

配置完毕后，就可以一键在“PAC代理模式（GFW黑名单）”、“全局代理模式”、“绕过大陆模式（白名单）”等代理模式之间自由切换，如下图：

![图片丨V2RayN一键切换路由代理模式](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/V2Ray%E9%BB%91%E7%99%BD%E5%90%8D%E5%8D%95PAC%E6%A8%A1%E5%BC%8F-baiyunju.cc.jpg.jpg)图片丨V2RayN一键切换路由代理模式

只有开启了高级路由功能，才会出现“路由”菜单。

当然，如果感觉高级路由功能太复杂（实际上并不复杂），也可以参考[《可以代替PAC模式的V2Ray路由器策略代理规则配置》](https://baiyunju.cc/7501)　https://baiyunju.cc/7501　，此文介绍了仅通过基础规则设置，也可以实现非常接近PAC代理模式的分流效果。

下面介绍V2RayN电脑客户端高级路由功能的设置、添加、导入自定义代理规则的方法。

# V2Ray路由高级功能导入代理规则的方法：

首先，点击电脑底栏的V2RayN图标，进入软件界面。点击软件顶部的“设置”-“路由设置”，勾选“启用路由高级功能”，再点击菜单“高级功能”-“添加规则集”，如下图所示：

![图片丨添加高级路由规则集](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/V2RayN%E5%90%AF%E7%94%A8%E9%AB%98%E7%BA%A7%E8%B7%AF%E7%94%B1%E5%8A%9F%E8%83%BD-baiyunju.cc.jpg)图片丨添加高级路由规则集

在添加规则前，规则列表中还是空白，可以手动逐条添加，也可以导入规则集。

V2RayN支持三种导入方式：“从文件中导入规则”、“从剪贴板中导入规则”、“从订阅URL中导入规则”。现在，从本文开头提到的文章中复制了规则集代码，这里选择“从剪贴板中导入规则”，如下图：

![图片丨导入复制过来的V2Ray路由规则集代码](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/%E4%BB%8E%E5%89%AA%E8%B4%B4%E6%9D%BF%E4%B8%AD%E5%AF%BC%E5%85%A5%E8%B7%AF%E7%94%B1%E8%A7%84%E5%88%99-baiyunju.cc.jpg)图片丨导入复制过来的路由规则集代码

操作成功，导入了几行规则。可以双击每一条规则，进行添加、删减等自定义操作，相关教程见本文末。

当然，也可以点击菜单“规则功能”-“添加规则”，来一条一条添加。路由规则详情设置界面，和路由基础功能规则界面相同，路由器规则编写方法也相同，
如下图：

![图片丨在高级路由功能中手工添加路由规则](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/V2Ray%E8%B7%AF%E7%94%B1%E8%A7%84%E5%88%99%E9%9B%86%E4%B8%AD%E6%B7%BB%E5%8A%A0%E8%A7%84%E5%88%99-baiyunju.cc.jpg)图片丨在高级路由功能中手工添加路由规则

需要注意的是，在高级路由规则内，排列在上面的规则具有更高的优先级别，可以右键点击每一条规则，选择“上移”“下移”，来达到不同的分流效果。







# [V2Ray路由器配置PAC代理规则集丨GFWlist黑名单模式](https://baiyunju.cc/7523)

- 黑名单好用，国内显示国内IP，国外显示国外IP
- 坐看云起 发布于 2021-03-07
- 分类：[技](https://baiyunju.cc/ji) / [电脑技巧](https://baiyunju.cc/ji/pc-skills)
- 

最新版本的V2Ray客户端V2RayN，也可以完美支持PAC代理模式。也就是只让GFWlist列表中被封锁的网站域名走代理，其他所有国内、国外的域名流量直连。

自从V2RayN 4.0版本开始删掉PAC功能后，很多习惯使用该代理模式的朋友不习惯路由模式，希望再添加PAC代理模式功能。其实，这是还不了解路由功能的强大和便捷。

事实上，V2RayN最新版本进一步增强了路由功能，不仅可以完美支持并实现PAC黑名单GFWlist模式，而且功能更加强大，使用起来也更方便。

使用GFW黑名单代理模式的优点之一，是节省购买的V2Ray节点流量，因为只有少量被墙封锁的网站走代理，其他的全部直连。另外，使用该代理模式，不会影响BT下载，因为GFW列表外的所有流量包括BT流量在内，会全部直连。

之前白云居丨baiyunju.cc分享过[《可以代替PAC模式的V2Ray路由器策略代理规则配置》](https://baiyunju.cc/7501)　https://baiyunju.cc/7501　，文中介绍的是通过路由基础规则实现的，仅仅是接近PAC模式。

以及全部代理规则集：[《V2RayN高级路由器配置规则集丨黑白名单、全局直连、全局代理模式》](https://baiyunju.cc/7753)https://baiyunju.cc/7753

本文现在分享的，是通过高级路由功能实现的、**真正的PAC代理模式，走代理的只有GFW黑名单中的网址**。

启用V2RayN的路由高级功能后，不仅可实现PAC，而且还可以通过右键菜单一键切换代理模式，在GFWlist黑名单、大陆绕行白名单、全局代理模式之间切换，如下图所示：

![图片丨V2RayN一键切换路由代理模式黑名单白名单](https://baiyunju.cc/wp-content/uploads/2021/04/V2Ray黑白名单PAC模式-baiyunju.cc.jpg.jpg)图片丨V2RayN一键切换路由代理模式

## V2RayN高级路由策略PAC设置规则

下面分享的是白云居丨baiyunju.cc在用的路由设置代理规则集，启用路由高级功能后，复制下面代码，并在规则集设置中，从剪贴板中导入规则即可（详细导入方法见文末教程）：

```
[
  {
    "outboundTag": "proxy",
    "domain": [
      "#以下三行是GitHub网站，为了不影响下载速度走代理",
      "github.com",
      "githubassets.com",
      "githubusercontent.com"
    ]
  },
  {
    "outboundTag": "block",
    "domain": [
      "#阻止CrxMouse鼠标手势收集上网数据",
      "mousegesturesapi.com"
    ]
  },
  {
    "outboundTag": "direct",
    "domain": [
      "bitwarden.com",
      "bitwarden.net",
      "baiyunju.cc",
      "letsencrypt.org",
      "adblockplus.org",
      "safesugar.net",
      "#下两行谷歌广告",
      "googleads.g.doubleclick.net",
      "adservice.google.com",
      "#【以下全部是geo预定义域名列表】",
      "#下一行是所有私有域名",
      "geosite:private",
      "#下一行包含常见大陆站点域名和CNNIC管理的大陆域名，即geolocation-cn和tld-cn的合集",
      "geosite:cn",
      "#下一行包含所有Adobe旗下域名",
      "geosite:adobe",
      "#下一行包含所有Adobe正版激活域名",
      "geosite:adobe-activation",
      "#下一行包含所有微软旗下域名",
      "geosite:microsoft",
      "#下一行包含微软msn相关域名少数与上一行微软列表重复",
      "geosite:msn",
      "#下一行包含所有苹果旗下域名",
      "geosite:apple",
      "#下一行包含所有广告平台、提供商域名",
      "geosite:category-ads-all",
      "#下一行包含可直连访问谷歌网址，需要替换为加强版GEO文件，如已手动更新为加强版GEO文件，删除此行前面的#号使其生效",
      "#geosite:google-cn",
      "#下一行包含可直连访问苹果网址，需要替换为加强版GEO文件，如已手动更新为加强版GEO文件，删除此行前面的#号使其生效",
      "#geosite:apple-cn"
    ]
  },
  {
    "type": "field",
    "outboundTag": "proxy",
    "domain": [
      "#GFW域名列表",
      "geosite:gfw",
      "geosite:greatfire"
    ]
  },
  {
    "type": "field",
    "port": "0-65535",
    "outboundTag": "direct"
  }
]
```

说明：

- 上面V2Ray高级路由规则集，完美实现了PAC代理模式，效果完全一样。其原理是，GFW黑名单中的域名走代理，剩余的其他连接0-65535所有端口的所有国内、外网站流量全部直连。
- \#号开头的为注释行，不必删除。
- 如需要更新官方geo文件，请参考[《V2Ray路由规则加强版资源文件geoip.dat、geosite.dat下载网址、更新方法》](https://baiyunju.cc/7583)https://baiyunju.cc/7583　。
- 其中，第三行直连域名规则中的域名较多，其实这一行”direct”规则原本可以全部删掉，但是在使用中发现，有一些本来可以直连的域名，也被放入GFW列表中走代理了，为了避免有漏网域名没走直连，因此直接将之前基础路由功能中的直接域名列表复制过来，与后面两行规则并不冲突。





