title: Typora使用了0号显卡，怀疑是导致其卡顿的原因Typora启动加速
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2021-11-10 23:34:13
authorAbout:
series:
tags: Typora
keywords:
description:

photos:  https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110233534082.png
---





Typora使用了0号显卡，怀疑是导致其卡顿的原因。
 于是决定关闭GPU, 找到Typora的配置文件
 大概在如下所示位置

c:\Users\\AppData\Roaming\Typora\conf\conf.user.json
打开后修改flags, 保存并重启typora，就不再使用GPU了:

 "flags": [["disable-gpu"]]
禁用GPU之后，软件启动的时候比之前慢，但是打开之后不卡顿了。
 怀疑是跟Chromium，GPU驱动有冲突。
 有兴趣的同学可以试一下换1号GPU支持来试一下。





```
/** For advanced users. */
{
  "defaultFontFamily": {
    "standard": null, //String - Defaults to "Times New Roman".
    "serif": null, // String - Defaults to "Times New Roman".
    "sansSerif": null, // String - Defaults to "Arial".
    "monospace": null // String - Defaults to "Courier New".
  },
  "autoHideMenuBar": false, //Boolean - Auto hide the menu bar unless the `Alt` key is pressed. Default is false.

  // Array - Search Service user can access from context menu after a range of text is selected. Each item is formatted as [caption, url]
  "searchService": [
    ["Search with Google", "https://google.com/search?q=%s"]
  ],

  // Custom key binding, which will override the default ones.
  // see https://support.typora.io/Shortcut-Keys/#windows--linux for detail
  "keyBinding": {
    // for example: 
    // "Always on Top": "Ctrl+Shift+P"
    // All other options are the menu items 'text label' displayed from each typora menu
  },

  "monocolorEmoji": false, //default false. Only work for Windows
  "maxFetchCountOnFileList": 500,
  "flags": [["disable-gpu"]] // default [], append Chrome launch flags, e.g: [["disable-gpu"], ["host-rules", "MAP * 127.0.0.1"]]
}

```

