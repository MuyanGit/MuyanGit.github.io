---
title: ' moviepy在win上找不到ImageMagick    '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-10-20 04:06:13
authorLink:
tags:
keywords:
description: moviepy在win上找不到ImageMagick---IMAGEMAGICK_BINARY = "C:\\Program Files\\ImageMagick_VERSION\\convert.exe"
photos:
---

## moviepy在win上找不到ImageMagick---IMAGEMAGICK_BINARY = "C:\\Program Files\\ImageMagick_VERSION\\convert.exe"

2021-10-20 04:03:16 发布

您现在位置：[Python中文网](https://www.cnpython.com/)*/*[ 问答频道 ](https://www.cnpython.com/qa/)*/*正文



[网友](https://www.cnpython.com/qa/517806#)

男 | 程序猿一只，喜欢编程写python代码。

在64位Windows 7上的Anaconda3 4.1.1发行版上，我使用`pip install moviepy`安装了moviepy 0.2.2.11。现在我想用需要ImageMagick的动画文本测试一些示例。因此，我下载并安装了`ImageMagick-7.0.3-4-Q16-x64-dll.exe`，但根据windows上的https://zulko.github.io/moviepy/install.html，需要手动指定路径。如果我理解正确，这必须在编译之前完成。然而，当我使用pip进行安装时，我不知道如何告诉moviepy路径。在

第二，似乎没有转换.exe. 但是我可以使用例如`magick convert image.png image.gif`。那么这个版本的ImageMagick与moviepy完全兼容吗？在

2条回答



网友

1楼 ·

1. 找到你的moviepy目录，然后找到moviepy/config_默认值.py，打开此文件并在最后一行后添加：

   ```
   IMAGEMAGICK_BINARY = "C:\\Program Files\\ImageMagick_VERSION\\convert.exe
   ```

2. 如果你没有转换.exe，可能是您的安装造成的。安装ImageMagick时，必须勾选

   ```
   [Install legacy utilities.(e.g.convert]
   ```



网友

2楼 ·

丢失的`convert.exe`确实是问题所在。 {a1在windows中提到过创建一个旧的安装程序转换.exe. 一旦我重新安装了ImageMagick并勾选了选项，它马上就可以工作了。显然，在windows上安装moviepy时，不需要再修改配置文件了。 本教程介绍了如何在windows上运行moviepy，包括ImageMagick[here](https://www.reddit.com/r/moviepy/comments/568bvb/looking_for_tutorial_for_windows_setup_of_moviepy/)的安装。但是它没有提到安装旧组件的选项。在
