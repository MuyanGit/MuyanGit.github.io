title: NET.core在vscode配置
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2021-11-16 22:01:12
authorAbout:
series:
tags: .NET Core
keywords:
description:

photos:
---





如何在多个.NET Core SDK 版本之间进行切换(global.json) _ The Will Will Web



## [如何在多個 .NET Core SDK 版本之間進行切換 (global.json)](https://blog.miniasp.com/post/2018/04/19/How-to-switch-between-DotNet-SDK-versions)分享

2018/04/20 05:41 [Will 保哥](https://blog.miniasp.com/author/will) [.NET Core](https://blog.miniasp.com/category/NET-Core)



[![img](https://blog.miniasp.com/Custom/Themes/Standard-2015/images/choose_the_right_partner3.png)](https://www.duotify.com/contact.html)



由於同一台電腦可以安裝多個版本的 .NET Core SDK，每個版本的 SDK 都會包含完整的工具組、執行環境、組件庫與編譯器等等，所以蠻多人詢問過我這個問題：「當安裝了許多不同版本的 .NET Core SDK 之後，要如何才能使用舊版 [dotnet](https://docs.microsoft.com/zh-tw/dotnet/core/tools/dotnet?tabs=netcore2x&WT.mc_id=DT-MVP-4015686) 命令，執行 **dotnet new** 或 **dotnet build** 之類的命令。」這部分其實並不困難，只要設定 [global.json](https://docs.microsoft.com/zh-tw/dotnet/core/tools/global-json?WT.mc_id=DT-MVP-4015686) 即可。

在 .NET Core 2.0 版以前，要查詢目前電腦所有安裝過的 SDK 版本，如果在 Windows 作業系統，可以透過控制台的「應用程式與功能」查看安裝過的 .NET Core SDK 版本，或是透過檔案總管開啟 C:\Program Files\dotnet\sdk 資料夾，查看有哪些版本。如果在 Linux 作業系統下，路徑則在 /usr/share/dotnet/sdk 目錄下。

[![image](https://blog.miniasp.com/image.axd?picture=image_thumb_242.png)](https://blog.miniasp.com/image.axd?picture=image_3110.png)

但是從 .NET Core SDK 2.1 開始，預設的 **dotnet** 命令就包含了 **dotnet --list-sdks** 命令，直接可以列出所有已安裝過的版本。

[![img](https://blog.miniasp.com/image.axd?picture=image_thumb_243.png)](https://blog.miniasp.com/image.axd?picture=image_3111.png)

查詢已經安裝過 SDK 版本號是非常重要的，當你想透過 **global.json** 切換 SDK 版本的時候，必須手動輸入這些已安裝的版本號。

首先，我們先來示範如何快速建立 **global.json** 檔案：

\1. 先利用 **dotnet new globaljson** 快速建立這個檔案

- 預設這個檔案會記錄當前目錄要使用的 .NET Core SDK 版本
- 預設的 SDK 會等同於目前執行 dotnet 命令時所用的 SDK 版本一致
  [![img](https://blog.miniasp.com/image.axd?picture=image_thumb_244.png)](https://blog.miniasp.com/image.axd?picture=image_3112.png)

\2. 然後將 **global.json** 檔案內的 "version" 修改為特定 SDK 版本即可

- 如下圖示
  [![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image.axd)](https://blog.miniasp.com/image.axd?picture=image_3113.png)

或者是你也可以利用 **--sdk-version** 參數，直接給定 SDK 版本，如下圖示：

[![img](https://blog.miniasp.com/image.axd?picture=image_thumb_246.png)](https://blog.miniasp.com/image.axd?picture=image_3114.png)

```sh
dotnet new globaljson --sdk-version 2.1.805
```

 

**請注意：**在執行 **dotnet** 命令的時候，它會自動找尋**當前目錄**與**上層目錄**的 **global.json** 檔案，這裡的**上層目錄**會一直往上找，找到**根目錄**為止！如果都找不到 **global.json** 就會預設選用目前所有已安裝 .NET Core SDK 的最新版。

 

一般來說，每一個透過 .NET Core 開發的專案，都不太需要 **global.json** 檔案的存在，因為隨著每次 .NET Core 版本升級，可以讓該專案永遠以「最新版 SDK」進行建置或發行。但是如果你還是擔心會有破壞性更新出現的話，這時你就可以建立一個 **global.json** 定義檔，將使用的 .NET Core SDK 鎖定在特定版本，以確保應用系統的穩定。

 

**相關連結**

- [global.json reference | Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/core/tools/global-json?WT.mc_id=DT-MVP-4015686)
- [global.json 參考 | Microsoft Docs](https://docs.microsoft.com/zh-tw/dotnet/core/tools/global-json?WT.mc_id=DT-MVP-4015686)





set 限制解除 



[![博客园Logo](https://www.cnblogs.com/images/logo.svg?v=R9M0WmLAIPVydmdzE2keuvnjl-bPR7_35oHqtiBzGsM)](https://www.cnblogs.com/)[首页](https://www.cnblogs.com/)[新闻](https://news.cnblogs.com/)[博问](https://q.cnblogs.com/)[专区](https://brands.cnblogs.com/)[闪存](https://ing.cnblogs.com/)[班级](https://edu.cnblogs.com/)![搜索](https://www.cnblogs.com/images/aggsite/search.svg)[注册](https://account.cnblogs.com/signup/)登录

[![返回主页](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/logo.gif)](https://www.cnblogs.com/linezero/)

# [LineZero's Blog](https://www.cnblogs.com/linezero/)

## 做自己！简单即幸福即快乐。

- [博客园](https://www.cnblogs.com/)
- [首页](https://www.cnblogs.com/linezero/)
- 
- 
- 订阅
- [管理](https://i.cnblogs.com/)

随笔 - 100 文章 - 0 评论 - 1036 阅读 - 110万

# [使用VS Code从零开始开发调试.NET 5](https://www.cnblogs.com/linezero/p/14300097.html)

使用VS Code 从零开始开发调试.NET 5。无需安装VS 2019即可开发调试.NET 5应用。

VS Code 全称是 Visual Studio Code，Visual Studio Code是一个轻量级的跨平台Web集成开发环境，可以运行在 Linux，Mac 和Windows下！

本篇为VS Code 开发调试.NET 5教程，在Windows下做实际操作，但同样适用于其它系统。

## 环境安装

本文演示开发环境: WIN10 x64 Visual Studio Code 1.55.1

.NET 5.0 SDK Windows x64 Installer:

https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.202-windows-x64-installer

更多系统版本下载：https://dotnet.microsoft.com/download



VSCode :

https://code.visualstudio.com/

VSCode C#插件：

打开扩展搜索C#， 选择C# 安装。

 ![img](https://img2020.cnblogs.com/blog/443844/202101/443844-20210119210634558-2041137445.png)

安装好插件以后重启VS Code。

## 创建项目

首先确保 .NET Core SDK 安装成功。

dotnet --version

输出如下：

5.0.202

然后就可以创建项目。

> dotnet new console -o myapp
>
> cd myapp
>
> dotnet run

![img](https://img2020.cnblogs.com/blog/443844/202101/443844-20210119211155824-156662802.png)

 

整个命令执行完成，项目就创建好了。 dotnet new会默认执行 dotnet restore ，只需要dotnet run即可。

## 使用 VS Code 开发

使用 VS Code 打开myapp文件夹，打开Program.cs 文件

如果是首次打开需耐心等待插件的安装。安装成功如下图：

 ![img](https://img2020.cnblogs.com/blog/443844/202101/443844-20210119211410010-338956512.png)

 

然后稍微等待一下，会出现如上图所示，提示 Required assets to build and debug are missing from 'myapp'. Add them?，选择Yes 即可。

插件会自动生成.vscode文件夹，并为我们配置好 launch.json 。

## 使用 VS Code 调试

接下来切换到调试窗口就可以进行调试，点击调试按钮

下断点成功断下。

 ![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/443844-20210119212646090-1244043507.png)

 

**F10 单步跳过 F11 单步调试 F5 执行.**

 

也可以选择附加调试，如下：

代码加入 Console.ReadKey();

然后在终端中执行 **dotnet .\bin\Debug\net5.0\myapp.dll**

接着在调试中切换为 **.NET Core Attach** 点击调试按钮，选择 dotnet.exe

![img](https://img2020.cnblogs.com/blog/443844/202104/443844-20210411155511487-787270754.png)

在VS Code中插入断点，然后终端输入任意键既可继续，程序也能正常走到调试状态。

![img](https://img2020.cnblogs.com/blog/443844/202104/443844-20210411155627704-506106542.png)

 

可以很方便的编写代码，C#插件为开发提供智能提示功能。这样不用安装VS 2019 也可以开发 .NET 5。

 

## VS Code插件

### 外观类插件

主题插件 GitHub Theme

![img](https://img2020.cnblogs.com/blog/443844/202104/443844-20210411144834533-1622839391.png)

 更多主题可以搜索Theme

Icon 图标插件： vscode-icons

### 开发类插件

Visual Studio IntelliCode 编码智能提示

REST Client 接口请求神器

示例：

```

```

　　```

```
POST https:``//example``.com``/comments` `HTTP``/1``.1``content-``type``: application``/json` `{``  ``"name"``: ``"sample linezero"``,``  ``"time"``: ``"Wed, 21 Oct 2020 18:27:50 GMT"``}
```



Thunder Client 像PostMan 一样请求接口

![img](https://img2020.cnblogs.com/blog/443844/202104/443844-20210411154311106-1437423367.png)

vscode-solution-explorer 像VS一样操作项目

![img](https://img2020.cnblogs.com/blog/443844/202104/443844-20210411160530623-1597839623.png)

 

ASP.NET Core 3.1 新书发布 《[ASP.NET Core项目开发实战入门](https://item.jd.com/12961032.html)》 [京东](https://item.jd.com/12961032.html) [当当](http://product.dangdang.com/29122210.html) [淘宝](https://s.taobao.com/search?q=9787121393846)

GitHub：https://github.com/linezero

博客示例代码GitHub：https://github.com/linezero/Blog





```
# 项目名字(name)里有 python 的
in:name python

# 名字(name)里有 python 的并且 stars 大于 3000 的
in:name python starts:>3000

# 名字(name)里有 python 的并且 stars 大于 3000 、forks 大于 200 的
in:name python starts:>3000 forks:>200


# 详情(readme)里面有 python 的并且 stars 大于 3000 的
in:readme python starts:>3000

# 描述(description)里面有 python 的并且 stars 大于 3000 的
in:description python starts:>3000

# 描述(description)里面有 python 的并且是 python 语言的
in:description python language:python

# 描述(description)里面有 python 的并且 2019-12-20 号之后有更新过的
in:description python pushed:>2019-12-20
```







```cmd
注意重启
```







查看源码-版本-项目还原



![image-20211117171052405](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211117171052405.png)
