---
title: 'URL Schemes - 汇总,qq,tim,支付宝'
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorLink: 
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-09-08 00:39:14
tags:
keywords:
description:
photos:
---

github gitee

https://github.com/search?l=JavaScript&q=im%2Fchat%3Fchat_type%3D&type=Code

![image-20210908004143462](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109080041420.png)

qq对话框

data:"mqq://im/chat?chat_type=wpa&version=1&src_type=web&uin=" + qq, 

资料卡

https://github.com/search?q=mqqapi%3A%2F%2Fcard%2Fshow_pslcard&type=code

data:"mqqapi://card/show_pslcard?&uin=

![image-20210908004321893](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202109080043085.png)





以下转发自[Ryan](https://www.ryannn.com/)

# URL Schemes - 汇总

[iOS](https://www.ryannn.com/tag/ios/)

本文章将不定时更新、记录和分享 iOS 常用 Apps 的 URL Schemes ，主要是一些近期的新发现或一些实用动作。不同于早前独立成文的 URL Schemes 分享文章，本文章不仔细区分应用，以常用的 URL Schemes 为出发点更新，因此如果你有这方面的需求，却又没有在各大搜索平台上找到自己想要的 URL Schemes ，欢迎不定时查阅本文章哦 :)

## 更新于2018-07-07

```
/* 豆瓣搜索 */
douban:///search?q=[URL Encode]

/* 豆瓣详细页，分别为电影、影人、书籍、音乐、活动 */
douban://v2/[movie|subject|book|music|event]/[id]
```

## 更新于2018-05-08

```
/* Shared by @sky(TG) */
/* QQ 扫一扫 */
mqqapi://qrcode/scan_qrcode?version=1&src_type=app

/* TIM 扫一扫 */
tim://qrcode/scan_qrcode?version=1&src_type=app
```

## 更新于2018-04-07

```
/* Mtime 电影详细页，参数是 URL Encode 的 JSON */
mtime://scheme?applinkData=%7b%22handleType%22%3a%22jumpPage%22%2c%22pageType%22%3a%22movieDetail%22%2c%22movieId%22%3a%22[movie id]%22%7d
```

## 更新于2018-03-04

```
/* 安装已签名 IPA */
itms-services://?action=download-manifest&url=[plist URL]
```

## 更新于2017-09-01

```
/* Shared by 搪瓷铁皮 */
/* 微软翻译文字 */
translator://action

/* Shared by 能蟹仔 */
/* 小米路由器 */
miwifi://
```

## 更新于2017-08-22

```
/* 将 http(s) 换成 googlechrome(s) */
/* 由 Chrome 打开 http(s) 链接 */
googlechrome(s)://[location]

/* 或直接传递 URL */
/* 由 Chrome 打开 URL */
googlechrome://x-callback-url/open/?url=[URL]
```

## 更新于2017-08-13

```
/* Shared by Forward */
/* 打开知乎搜索，唤起键盘 */
zhihu://search?q=[URL Encode]

/* 知乎具体问题页 */
zhihu://question/[id]
```

## 更新于2017-07-27

```
/* Shared by NEO */
/* 淘宝搜索 */
taobao://s.taobao.com?q=[URL Encode]

/* 哔哩哔哩搜索 */
bilibili://search?keyword=[URL Encode]
```

## 更新于2017-06-24

```
/* Shared by Nyaa */
/* 微博私信页 */
weibo://message
```

## 更新于2017-01-22

```
/* Shared by cactus */
/* 手机充值 */
alipayqr://platformapi/startapp?saId=10000003

/* 口令红包 */
alipayqr://platformapi/startapp?saId=88886666

/* 口令红包，带口令 */
alipayqr://platformapi/startapp?saId=88886666&passcode=[code]
```

## 更新于2017-01-15

```
/* iMark 快速新建 */
clover-imark://new/[camera|latest|web|map|library|session]

/* iMark 新建画布，尺寸可更改 */
clover-imark://new/canvas?width=[1000]&height=[1000]
```

## 更新于2017-01-04

```
/* 115 App 扫一扫 */
oof.disk://scan


```

## 更新于2016-11-18

```
/* 万分注意：只能切换店面地区，并不能切换账号 */
/* App Store 店面切换，其他地区雷同，请自行修改地区缩写 */
https://itunes.apple.com/[us|jp|...]/app/region-changer/id0123456789
```

## 更新于2016-08-24

```
/* 打开AppStore并兑换 [Redeem Code] */
itms-apps://buy.itunes.apple.com/WebObjects/MZFinance.woa/wa/freeProductCodeWizard?mt=8&code=[Redeem Code]
```

## 更新于2016-06-09

```
/* 打开 Safari 并搜索内容，搜索引擎跟随系统设置 */
x-web-search://?[URL Encode]

/* 打开 AppStore 并搜索内容，显示搜索页面 */
itms-apps://search.itunes.apple.com/WebObjects/MZSearch.woa/wa/search?media=software&term=[URL Encode]
```

## 更新于2016-05-26

- 新浪微博

  ```
  /* 首页，同时可作刷新功能 */
  weibo://gotohome
  
  /* 发布页 */
  weibo://share?content=[id]
  
  /* 发现页 */
  weibo://discover
  
  /* 搜索页，可带搜索内容 */
  weibo://searchall?q=[URL Encode]
  
  /* 微博扫一扫 */
  weibo://qrcode
  
  /* 微博支付 */
  weibo://paymentcards?containerid=106403
  
  /* 我的收藏 */
  weibo://cardlist?containerid=2302592168131095&cache_need=1
  
  /* 具体文章页，需要自行分析 mblogid */
  weibo://detail?mblogid=[mblogid]
  
  /* 具体内页，如热门博客、热门话题等，需要自行分析 containerid */
  weibo://cardlist?containerid=[containerid]
  
  /* 具体个人页，需要自行分析个人 uid */
  weibo://userinfo?uid=[uid]
  ```

- 微信

  ```
  /* 微信扫一扫，免内置浏览器跳转 */
  weixin://scanqrcode
  ```

- 支付宝

  ```
  /* 付款码 */
  alipayqr://platformapi/startapp?saId=20000056
  
  /* 余额宝 */
  alipayqr://platformapi/startapp?saId=20000032
  
  /* 转账 */
  alipayqr://platformapi/startapp?saId=09999988
  
  /* 提现 */
  alipayqr://platformapi/startapp?saId=20000033
  
  /* 卡券 */
  alipayqr://platformapi/startapp?saId=20000021
  
  /* 扫一扫 */
  alipayqr://platformapi/startapp?saId=10000007
  ```

## 说明

动作类 URL Schemes 一般都难以获取，如果你有新的好的发现想要分享交流，欢迎留言哦。也敬请各位尊重大家的劳动成果，愉快交流 :)

------

