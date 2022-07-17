---
title: '   # Web前端：hexo+github搭建个人博客，免费！  '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-10-24 00:03:51
authorLink:
tags:
keywords:
description:
photos:
---

# Web前端：hexo+github搭建个人博客，免费！



网上查的同类教程有不少，但是看了一下发布时间，那些教程的发布还是有些年头的了。
有些教程中的步骤现在不一定适用了，我当初就按照别人的教程搭建[Hexo](https://hexo.io/zh-cn/),不小心就掉了坑。
那就干脆自己写一个，方便记忆，顺便给需要的朋友提供参考。

首先报上一波，我开发的运行环境

#### 运行环境 Runtime environment

```
操作系统 ： Windows10
IDE: JetBrains WebStorm 2018.2.1 x64
浏览器： Google Chrome 版本 67.0.3396.99（正式版本） （64 位）&& FireFox Developer Edition 版本63.0b4  (64位)
hexo: 3.7.1
hexo-cli: 1.1.0
node: 8.11.4
```

------

# 背景

个人博客，一般来说，基本都是咱们干IT的人用得多一些。
要是从事这行业之外的人，根本也不需要吧。QQ空间，微博，微信朋友圈之类的地方就基本能够满足需求了。
受到了知乎上，一个讨论的问题的启发。[如何开始写技术博客，怎么选择？](https://www.zhihu.com/question/24629410)
所以打算自己搭建博客，自己用的东西，当然是讲究一个“顺自己心意”就好。
为了尽可能写得详细，所以教程显得很冗长，但是Hexo搭建博客真的很容易..

## 优势

为什么选择[Hexo](https://hexo.io/zh-cn/)+[Github](https://github.com/)来搭建自己的博客？
我认为有以下几点优势：

1. 不需要服务器，[Github](https://github.com/)免费提供的托管服务；
2. 不需要域名，[Github](https://github.com/)同样提供了一个.io的域名；
3. 不用将太多的心思投入到博客开发；
4. hexo主题多样且免费、又好看；
5. 不像其他博客有让人心烦的广告；
6. 便于维护更新，换风格直接换模板就行。

## 总体步骤概述

大体的就4个步骤，咱就不弄那么复杂了。

1. 下载需要的工具，并安装；
2. 创建[Github](https://github.com/)仓库；
3. 修改[Hexo](https://hexo.io/zh-cn/)配置文件；
4. 把博客部署到[Github](https://github.com/)上；

# 搭建流程

## 准备阶段

- 下载安装相关工具

1.下载[NodeJs](https://nodejs.org/zh-cn/)
点击此处[NodeJs中文下载页](https://nodejs.org/zh-cn/download/)根据自己的操作系统，下载对应版本的NodeJs。
这里是推荐使用长期维护版本（LTS）的NodeJs,
如果你看不懂，从我这里下载也一样，但是版本就可能不是最新的了，这里版本v8.12.0。
Windows系统：
64位：[NodeJs_x64](https://nodejs.org/dist/v8.12.0/node-v8.12.0-x64.msi)
32位：[NodeJs_x86](https://nodejs.org/dist/v8.12.0/node-v8.12.0-x86.msi)
Linux系统：（你都会Linux了，不会选不太可能吧？）
64位：[NodeJs_x64](https://nodejs.org/dist/v8.12.0/node-v8.12.0-linux-x64.tar.xz)
32位：[NodeJs_x86](https://nodejs.org/dist/v8.12.0/node-v8.12.0-linux-x86.tar.xz)
macOS系统：
没用过，不知道。

2.安装[Git](https://git-scm.com/downloads)
点击[Git](https://git-scm.com/download/win)根据自己的操作系统，下载对应版本的[Git](https://git-scm.com/downloads) 。
如果你看不懂，从我这里下载也一样，但是版本就可能不是最新的了，这里版本v2.19.0。
Window系统：
64位：[Git_x64](https://github.com/git-for-windows/git/releases/download/v2.19.0.windows.1/Git-2.19.0-32-bit.exe)
32位：[git_x86](https://github.com/git-for-windows/git/releases/download/v2.19.0.windows.1/Git-2.19.0-64-bit.exe)
Linux系统：
详见[安装命令](https://git-scm.com/download/linux)

下载完成以后，打开根据提示操作，Win系统直接“下一步”就OK了。

3.测试安装是否已经生效
打开cmd命令行(win+r 输入cmd回车)分别执行（Linux系统则是在终端中）复制以下命令：

```
node -v
npm -v
git --version
```

回车，稍微等下便会有以下运行结果：

```
C:\Users\DeSireFire>node -v
v8.11.4

C:\Users\DeSireFire>npm -v
5.6.0

C:\Users\DeSireFire>git --version
git version 2.18.0.windows.1
```

说明安装成功了。

4.安装[Hexo](https://hexo.io/zh-cn/)
之前做的，是为了安装[Hexo](https://hexo.io/zh-cn/)做准备。

```
https://hexo.io/zh-cn/
```

从[Hexo](https://hexo.io/zh-cn/) 官网中可以看到这些指令，咱就以人家官网的步骤行事准没错。
打开cmd命令行(win+r 输入cmd回车)分别执行（Linux系统则是在终端中），通过cd指令跳转到要存储[Hexo](https://hexo.io/zh-cn/)的位置。
如果不想琢磨，我直接写完全部指令，路径我放在D盘上（以Windows系统为例）

```
d:
npm install hexo-cli -g
hexo init blog
cd blog
npm install
hexo server
```

以上命令的意思是：

1. 跳转到D盘

2. 使用npm安装hexo

3. 使用hexo初始化一个名为blog的项目

4. 跳转到生成出的blog文件夹里

5. hexo启动服务器

   如果没有出错，一般会是以下情景：

   ```
   INFO  Start processing
   INFO  Hexo is running at http://localhost:4000 . Press Ctrl+C to stop.
   ```

   此时访问

   Hexo测试服

   即可。如果出错请严格按照步骤检查！

打开浏览器输入 [http://localhost:4000](http://localhost:4000/) 就能看到搭建好的Hexo本地博客了。
不过因为没有使用其他主题，所以Hexo会是用自带的默认Blog主题。
测试完毕记得在命令窗口上按 Ctrl+C 关闭hexo服务器。

- 创建Github仓库

*注意：*

> 1.在这里，我的做法是创建两个仓库！
> 2.一个仓库用于存放hexo的配置文件；
> 3.另一个仓库用于部署Blog的静态文件！

1. 点击[Github](https://github.com/)进入Github,登陆！（如果没有账号，自行百度一下注册方法）
2. 依照图中的位置创建仓库，如图所示：
   [![image-20200329235322725](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240004974.png)](https://blog.raxianch.moe/2018/09/12/Web前端：hexo-github搭建个人博客，免费！/newrepo.png)
3. 在Repository name中输入你要创建的仓库名字，这里我命名为“myhexo”,在Description输入仓库的描述，如图：

4. 其他的，根据自己需要来设定。最后单击Create repository来完成最后确定创建。
5. 再创建第二个仓库，重复以上1~4的步骤，这一次在Repository name中输入dafanshu.github.io（xxx为你的想起的博客名，自行修改,但是必须与你的github用户名一致！）

完成以上五步，那么在你的github首页就能看到这两个仓库了。如图：
[![image-20200329235345882](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240004011.png)](https://blog.raxianch.moe/2018/09/12/Web前端：hexo-github搭建个人博客，免费！/repos.png)
以“.github.io”结尾的为博客仓库，另一个是hexo配置文件仓库。

- 美化Hexo主题（拓展）
  点击按钮访问[Hexo主题搜索](https://github.com/search?q=hexo-theme)，在里面随便挑。
  [![image-20200329235404147](E:/Web_Blog/blog/source/images/image-20200329235404147.png)](https://blog.raxianch.moe/2018/09/12/Web前端：hexo-github搭建个人博客，免费！/hexothemes.png)
  一般主题的开发者都会在其仓库下方放上主题效果的预览图。
  这里，作为举例，选择了 https://github.com/litten/hexo-theme-yilia 主题。
  下载方法，如图所示：
  [![image-20200329235414226](E:/Web_Blog/blog/source/images/image-20200329235414226.png)](https://blog.raxianch.moe/2018/09/12/Web前端：hexo-github搭建个人博客，免费！/dltheme.png)
  下载完成后，解压得到一个名为“hexo-theme-yilia-master”的文件夹，这里我把它改名为“yilia”。
  最后，把它复制到D:\Blog\themes\文件夹下，主题安装就此完成。
  配置文件方面，之后会讲到。

## 使用阶段

下载、安装完相关工具，创建完相应的两个仓库，那么就开始进入重要的阶段。

### 修改Hexo配置文件

1.打开blog/_config.yml，参考实例进行修改

```
# Site
title: 网站标题
subtitle: 副标题
description: 个人签名
author: 姓名
language: zh-Hans
timezone:
```

需要注意的是：

> 1. 所有的配置“:”符号后面都要带空格，否则失效。
> 2. language是设置语言。zh-Hans是中文，若出现乱码需转码UTF8。

2.配置发布blog的仓库地址
如何获得github的地址呢？如图：
[![image-20200329235424754](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240004048.png)](https://blog.raxianch.moe/2018/09/12/Web前端：hexo-github搭建个人博客，免费！/blogdeloy.png)

> 注意，这里提到的仓库是用以“.github.io”结尾的用于部署Blog的仓库

将图中选中的部分复制下来，然后如示例中，写入_config.yml

```
deploy:
  type: git
  repo: https://github.com/DeSireFire/DeSireFire.github.io.git
  branch: master
```

以上这步非常重要，它关系到你最终能不能部署成功！

内容较多建议参考官方文档
https://hexo.io/zh-cn/docs/configuration.html
修改完之后，可以重新执行hexo s在浏览器查看效果。并确认无误，包括以后需要添加文章，或者更新主题等，都建议先在本地查看无误再远程部署。
根_config.yml文件中。

3.配置主题到配置文件

```
# Extensions
## Plugins: https://hexo.io/plugins/
## Themes: https://hexo.io/themes/
theme: yilia
```

需要注意的是：

> 1. theme名必须与D:\Blog\themes\下的文件夹名一致。

4.配置用于存放hexo文件的仓库地址
首先，进入[Github](https://github.com/),找到之前创建来用于存放hexo的配置文件的仓库“myhexo”，如图：
[](https://blog.raxianch.moe/2018/09/12/Web前端：hexo-github搭建个人博客，免费！/blogconfigrepo.png)
复制仓库地址，然后在D:\Blog\目录下，然后如图中打开gitbash（如果你是Linux系统，直接在相应目录下打开终端即可）：
[![image-20200329235452205](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240004089.png)](https://blog.raxianch.moe/2018/09/12/Web前端：hexo-github搭建个人博客，免费！/gitbash.png)
在之后出现的黑窗口中输入一下命令，注意根据自己的需要修改部分命令内容：

```
npm install hexo-deployer-git --save

git init

git config --global user.name "你的github用户名"
git config --global user.email XXX@qq.com（你的邮箱地址）

git add *
git commit -m "提交hexo配置文件到仓库"
git remote add origin (此处加上你的仓库地址，如我的是：https://github.com/DeSireFire/DeSireFire-sHexoWarehouse.git)
git push -u origin master
```

回车搞定，你的Hexo文件就上传到配置仓库去了！

### 本地测试Hexo是否生效

一切顺利，下一步就可以愉快写博客了。
打开cmd命令行(win+r 输入cmd回车)分别执行（Linux系统则是在终端中），
如果不想琢磨，我直接写完全部指令，路径我放在D盘上（以Windows系统为例）

```
d:
cd d:\blog\
hexo clean&&hexo g&&hexo server
```

如果没有出错，一般会是以下情景：

```
INFO  Start processing
INFO  Hexo is running at http://localhost:4000 . Press Ctrl+C to stop.
```

打开浏览器输入 [http://localhost:4000](http://localhost:4000/) 就能看到搭建好的Hexo本地博客了。
不过因为没有使用其他主题，所以Hexo会是用自带的默认Blog主题。
测试完毕记得在命令窗口上按 Ctrl+C 关闭hexo服务器。

### 部署Blog到外网

完成前面的工作，说明你离成功就只剩下最后一道命令了。
继续在本目录命令行，执行！

```
hexo clean&&hexo g&&hexo d
```

提示上传完成以后，访问[Github](https://github.com/)。打开之间说到以“.github.io”结尾的用于部署Blog的仓库。
打开该数据库的设置页面，如图：
[![image-20200330002805714](E:/Web_Blog/myhexo/source/images/image-20200330002805714.png)](https://blog.raxianch.moe/2018/09/12/Web前端：hexo-github搭建个人博客，免费！/reposetting.png)
在设置页面中，向下滚动到GitHub Pages一栏，如图：
[![image-20200330002752708](E:/Web_Blog/myhexo/source/images/image-20200330002752708.png)](https://blog.raxianch.moe/2018/09/12/Web前端：hexo-github搭建个人博客，免费！/settings.png)
刚刚上传完成时，github需要一点时间才能把blog发布到外网上，耐心等待一首歌的时间基本就OK了。
当github发布完成，会显示“Your site is published at XXXX”，
这时候访问箭头所指的位置，就能直接看到自己的博客了。

最后一项拓展：
如果你有自己购买的域名，可以在第三个箭头处的位置输入保存。这样就能用自己自定义的域名来访问博客了。



备份：

# 如何使用Hexo-Git-Backup 插件备份的Hexo博客

发布时间：2022-01-06 18:16:41 来源：亿速云 阅读：159 作者：柒染 栏目：[大数据](https://www.yisu.com/zixun/hlwkj_dsj/)

[活动：亿速云新用户活动，云服务器、香港服务器等云产品大降价，快来看看吧！](https://www.yisu.com/huodong/newuser.html?f=nature&type=zixun&plan=text)

本篇文章为大家展示了如何使用Hexo-Git-Backup 插件备份的Hexo博客，内容简明扼要并且容易理解，绝对能使你眼前一亮，通过这篇文章的详细介绍希望你能有所收获。

由于 Hexo 博客是静态托管的，所有的原始数据都保存在本地，如果哪一天电脑坏了，或者是误删了本地数据，那就是叫天天不应叫地地不灵了，此时定时备份就显得比较重要了，常见的备份方法有：打包数据保存到U盘、云盘或者其他地方，但是早就有大神开发了备份插件：hexo-git-backup ，只需要一个命令就可以将所有数据包括主题文件备份到 github 了

首先进入你博客目录，输入命令 `hexo version` 查看 Hexo 版本，如图所示，我的版本是 3.7.1：


![如何使用Hexo-Git-Backup 插件备份的Hexo博客](https://cache.yisu.com/upload/information/20210521/347/217514.png)

安装备份插件，如果你的 Hexo 版本是 2.x.x，则使用以下命令安装：

```
$ npm install hexo-git-backup@0.0.91 --save
```

如果你的 Hexo 版本是 3.x.x，则使用以下命令安装：

```
$ npm install hexo-git-backup --save
```

到 Hexo 博客根目录的 `_config.yml` 配置文件里添加以下配置：

```
backup:
 type: git
 theme: material-x-1.2.1
 message: Back up my www.itrhx.com blog
 repository:
   github: git@github.com:TRHX/TRHX.github.io.git,backup
   coding: git@git.dev.tencent.com:TRHX/TRHX.git,backup
```

参数解释：

- theme：你要备份的主题名称
- message：自定义提交信息
- repository：仓库名，注意仓库地址后面要添加一个分支名，比如我就创建了一个 backup 分支

最后使用以下命令备份你的博客：

```
$ hexo backup
```

或者使用以下简写命令也可以：

```
$ hexo b
```

备份成功后可以在你的仓库分支下看到备份的原始文件：

![image-20220717145435029](C:/Users/HI/AppData/Roaming/Typora/typora-user-images/image-20220717145435029.png)


![image-20220717145514162](C:/Users/HI/AppData/Roaming/Typora/typora-user-images/image-20220717145514162.png)

上述内容就是如何使用Hexo-Git-Backup 插件备份的Hexo博客，你们学到知识或技能了吗？如果还想学到更多技能或者丰富自己的知识储备，欢迎关注亿速云行业资讯频道。

推荐阅读：[Atom 安装使用](https://www.yisu.com/zixun/50840.html)

# 总结

到此，整个Hexo+Github搭建个人博客的教程就完成了！有没有很开心！如果有不会的地方可以直接留言提问2333！



**原始链接:**[https://desirefire.github.io/2018/09/12/Web前端：hexo-github搭建个人博客，免费！/](https://blog.raxianch.moe/2018/09/12/Web前端：hexo-github搭建个人博客，免费！/) 

**许可协议:** ["署名-非商用-相同方式共享 3.0"](http://creativecommons.org/licenses/by-nc-sa/3.0/cn/) 转载请保留原文链接及作者。

