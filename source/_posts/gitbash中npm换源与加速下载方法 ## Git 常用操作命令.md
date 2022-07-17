---
title: 'gitbash中npm换源与加速下载方法 ## Git 常用操作命令    '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorLink: 
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-09-17 18:12:23
tags:
keywords:
description: gitbash中npm换源与加速下载方法 ## Git 常用操作命令
photos:
---

## 

# Git使用

## Git 常用操作命令



转载[君莫笑贪狼](https://me.csdn.net/xs20691718) 最后发布于2016-05-27 14:21:12 阅读数 471 收藏

展开

转载：http://tomhat.iteye.com/blog/2065707
稍微做了一些补充。

可以创建私有项目的git网站：
\+ [https://bitbucket.org](https://bitbucket.org/)
\+ [http://git.oschina.net](http://git.oschina.net/)

master：默认开发分支；
origin：默认远程版本库

------



 

### 3限速`完美解决github访问速度慢



[![月正明](E:/Web_Blog/blog/source/images/v2-30984d4ea6a04456d247cb31c1cefb84_xs.jpg)](https://www.zhihu.com/people/yue-zheng-ming-83)

[月正明](https://www.zhihu.com/people/yue-zheng-ming-83)

java开发工程师

21 人赞同了该文章

#### **1. 修改本地hosts文件**

```text
windows系统的hosts文件的位置如下：C:\Windows\System32\drivers\etc\hostsmac/linux系统的hosts文件的位置如下：/etc/hosts
```

**2. 增加[http://github.global.ssl.fastly.net](http://github.global.ssl.fastly.net/)和[http://github.com](http://github.com/)的映射**

```text
获取Github相关网站的ip访问https://www.ipaddress.com，拉下来，找到页面中下方的“IP Address Tools – Quick Links”分别输入github.global.ssl.fastly.net和github.com，查询ip地址下面是我的配置140.82.114.4	github.com199.232.5.194	github.global.ssl.fastly.net
```

##### 3.命令提示符中输入ping [github.com](http://github.com/)

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240015288.jpg)配置前

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240015006.jpg)配置后

再次访问流量器https://github.com/，秒出

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240015957.jpg)



- 

##### 2.直接用 [https://g.widora.cn](https://g.widora.cn/) 就好了

赞回复踩举报

- [![Jimmy](E:/Web_Blog/blog/source/images/v2-02c203614aee635b48b4a2f34612f3a5_s.jpg)](https://www.zhihu.com/people/sjniimj)\







##### 4.Git常见错误与操作：error: src refspec master does not match any解决办法

一、 出现错误 error:src refspec master does not match any

原因分析：

引起该错误的原因是目录中没有文件，空目录是不能提交上去的

解决办法：

[html] view plain copy

```
$ touch README  $ git add README  $ git commit –m’first commit’  $ git push origin master  1234
```

(来自：http://www.open-open.com/lib/view/open1366080269265.html)
实际上

[html] view plain copy

```
$ git init  1
```

这一步之后创建了一个名为.git的文件夹，不过它在默认状态下是隐藏的，系统将隐藏文件夹显示出来，可以看到有这样一个文件夹。
github上传项目方法：
http://www.oschina.net/question/159132_86728
在你的电脑上装好git

大致流程是：

[html] view plain copy

```
1、 在github上创建项目  2、 使用$ git clone https://github/xx账号/xx项目.git克隆到本地  3、 编辑项目  4、 $ git add .(将改动添加到暂存区)  5、 $ git commit –m”提交说明”  6、 $ git push origin 将本地更改推送到远程master分支  123456
```

这样你就完成了向远程仓库的推送

如果在github的remote上已经有了文件，会出现错误。此时应当先pull一下，即：

[html] view plain copy

```
$ git pull origin master  1
```

然后再进行：

[html] view plain copy

```
$ git push origin master  1
```

二、如果输入$ git remoteadd origin git@github.com:djqiang（github帐号名）/gitdemo（项目名）.git

```
提示出错信息：fatal: remoteorigin already exists.解决办法如下：123
```

[html] view plain copy

```
1、先输入$ git remote rmorigin      2、再输入$ git remote addorigin git@github.com:djqiang/gitdemo.git 就不会报错了！      3、如果输入$ git remote rmorigin 还是报错的话，error: Could not remove config section'remote.origin'. 我们需要修改gitconfig文件的内容  4、找到你的github的安装路径5、找到一个名为gitconfig的文件，打开它把里面的[remote "origin"]那一行删掉就好了！12345678
```

三、如果输入$ ssh -T git@github.com
出现错误提示：Permissiondenied (publickey).因为新生成的key不能加入ssh就会导致连接不上github。

```
解决办法如下：1、先输入$ ssh-agent，再输入$ ssh-add ~/.ssh/id_key，这样就可以了。2、如果还是不行的话，输入ssh-add~/.ssh/id_key 命令后出现报错Could not open a connection toyour authentication agent.解决方法是key用Git Gui的ssh工具生成，这样生成的时候key就直接保存在ssh中了，不需要再ssh-add命令加入了，其它的user，token等配置都用命令行来做。3、最好检查一下在你复制id_rsa.pub文件的内容时有没有产生多余的空格或空行，有些编辑器会帮你添加这些的。1234567
```

四、如果输入$ git push origin master

```
提示出错信息：error:failedto push som refs to .......解决办法如下：123
```

[html] view plain copy

```
1、先输入$ git pullorigin master //先把远程服务器github上面的文件拉下来  2、再输入$ git pushorigin master  3、如果出现报错 fatal:Couldn't find remote ref master或者fatal: 'origin' doesnot appear to be a git repository以及fatal: Could notread from remote repository.  4、则需要重新输入$ git remoteadd origingit@github.com:djqiang/gitdemo.git  1234
```

五、Git常见操作

使用git在本地创建一个项目的过程

[html] view plain copy

```
$ makdir ~/hello-world    //创建一个项目hello-world  $ cd~/hello-world       //打开这个项目  $ git init             //初始化   $ touch README  $ git add README        //更新README文件  $ git commit-m 'first commit'     //提交更新，并注释信息“first commit”   $ git remote add origin git@github.com:defnngj/hello-world.git     //连接远程github项目    $ git push -u origin master     //将本地项目更新到github项目上去  12345678
```

六、gitconfig配置文件

```
    Git有一个工具被称为git config，它允许你获得和设置配置变量；这些变量可以控制Git的外观和操作的各个方面。这些变量可以被存储在三个不同的位置：      1./etc/gitconfig 文件：包含了适用于系统所有用户和所有库的值。如果你传递参数选项’--system’ 给 git config，它将明确的读和写这个文件。      2.~/.gitconfig 文件 ：具体到你的用户。你可以通过传递--global 选项使Git 读或写这个特定的文件。     3.位于git目录的config文件 (也就是.git/config) ：无论你当前在用的库是什么，特定指向该单一的库。每个级别重写前一个级别的值。因此，在.git/config中的值覆盖了在/etc/gitconfig中的同一个值。    在Windows系统中，Git在$HOME目录中查找.gitconfig文件（对大多数人来说，位于C:\Documents and Settings\$USER下）。它也会查找/etc/gitconfig，尽管它是相对于Msys 根目录的。这可能是你在Windows中运行安装程序时决定安装Git的任何地方。12345
```

七、配置相关信息：

```
    1　当你安装Git后首先要做的事情是设置你的用户名称和e-mail地址。这是非常重要的，因为每次Git提交都会使用该信息。它被永远的嵌入到了你的提交中：1
```

[html] view plain copy

```
$ git config --global user.name "John Doe"  $ git config --global user.email johndoe@example.com    2   你的编辑器(Your Editor)123456
```

　　现在，你的标识已经设置，你可以配置你的缺省文本编辑器，Git在需要你输入一些消息时会使用该文本编辑器。缺省情况下，Git使用你的系统的缺省编辑器，这通常可能是vi 或者 vim。如果你想使用一个不同的文本编辑器，例如Emacs，你可以做如下操作：

[html] view plain copy

```
$ git config --global core.editor emacs  1
```

3 检查你的设置(Checking YourSettings)

　　如果你想检查你的设置，你可以使用 git config –list 命令来列出Git可以在该处找到的所有的设置:

[html] view plain copy

```
$ git config --list    你也可以查看Git认为的一个特定的关键字目前的值，使用如下命令 git config {key}:12345
```

[html] view plain copy

```
$ git config user.name   4 获取帮助(Getting help)12345
```

　　如果当你在使用Git时需要帮助，有三种方法可以获得任何git命令的手册页(manpage)帮助信息:

[html] view plain copy

```
$ git help <verb>  $ git <verb> --help  $ man git-<verb>  123
```

　　例如，你可以运行如下命令获取对config命令的手册页帮助:

[html] view plain copy

```
$ git help config  1
```

转载来源：http://blog.csdn.net/s164828378/article/details/52425208



##### 5.GitBash 全局使用 npm,node命令

原创[Alan_阿兰](https://me.csdn.net/sixteen_cicle) 最后发布于2017-06-14 17:41:37 阅读数 2957 收藏

展开

命令大全

http://www.cnblogs.com/darrenji/p/5286403.html


常用：

npm install --save react react-dom
npm install --save-dev gulp browserify babelify vinyl-source-stream

3.全局
$ npm install babel -g
$ npm install babelify -g
$ npm install vinyl-source-stream -g

默认安装路径
C:\Users\Administrator\AppData\Roaming\npm
修改路径：
npm config set prefix "D:\Node\npm_global_modules\node_modules"

node.js测试
http://localhost:3000/

退出出node命令行：两次ctrl+C或者一次ctrl+D
退出终端：.exit;



#### 6.[使用Git Bash for Windows](https://www.cnblogs.com/darrenji/p/5286403.html)

 

本篇体验Git Bash在Windows操作系统上的用法。

什么是Bash?

是一个Shell环境，Bourne Again Shell的缩写。

安装git for windows

→ http://git-for-windows.github.io/
→ Download，选择一个合适的版本
→ 安装
→ 安装完后有Git Bash, Git CMD, 和 Git GUI这个三个应用程序
→ 运行Git Bash,检查当前版本
git version
→ 退出
exit

安装Notepad++

→ notepad-plus-plus.org
→ download，选择合适的版本
→ 安装

在Bash中打开Notepad++

→ 找到notepad++的应用程序文件
一般在C:\Program Files(x86)\Notepad++中，把C:\Program Files(x86)\Notepad++赋值
→ 右键"我的电脑"，点击"高级系统设置", 点击"环境变量"， 双击Path,把;C:\Program Files(x86)\Notepad++加到最后，点击"确定"
→ 运行Git Bash
→ notepad++
这样，在Bash中就打开notepadd++了。

显示查看当前目录

→ 运行Git Bash
→ 查看当前目录
pwd
显示/c/Users/Darren,其中/c/相当于C:\，
→ 列出当前文件夹下的所有文件
ls
或
ls -l

更换当前目录

→ 运行Git Bash
→ 导航到其它目录
cd Videos/
→ 退回到上一级
cd ..
→ 导航到My Documents目录
cd My\ Documents/
→ 退回三级
cd ../../../
→ 回到主目录
cd ~
→ 导航到一个绝对位置上的目录
cd /c/Windows/System32/

查看命令出处

→ 查看ls命令的出处
whick ls
显示/bin/ls

显示打印

→ 显示打印环境变量
echo $PATH

查看文件内容

→ 查看一个文件内容
cat test.txt
→ 查看一个文件内容并编辑
less test.txt


创建、重命名、移动、删除文件

→ 创建一个空文件
touch demo.txt
→ 重命名一个文件
mv demo.txt demo-1.txt
→ 删除已知文件
rm demo-1.txt

创建、删除目录

→ 创建目录
mkdir projects
→ 删除目录
rmdir projects
→ 创建多级目录
mkdir projects/client-a/awesome-web-project/
→ 删除多级目录
rm -rf projects/

清空和退出

→ 清空内容
clear
→ 退出控制台
exit

控制台打印信息输出到文件

→ 打印信息输出追加到创建文件
echo "hi" >> demo.txt
→ 打印信息输入重写已知文件
echo "hello" > demo.txt

执行Bash脚本

→ 查看bash安装在哪里
which bash
显示：/bin/bash
→ 使用notepad++创建打开一个文件
notepad++ example.sh
→ 输入命令

\#!/bin/bash

echo "hi, everyone"









# gitbash中npm换源与加速下载方法

### 第一种·淘宝

使用npm 淘宝镜像（http://npm.taobao.org/）。读者可在cmd命令窗口执行：

```
npm install -g cnpm --registry=https://registry.npm.taobao.org
```

接下来读者就通过cnpm代替npm;

#### npm安装

- ##### 常用npm安装-调用taobao

HelloWorld@DESKTOP-UQPPB6C MINGW64 /e/Web_Blog
$ npm install --save react react-dom

- ##### 本地文件夹npm安装

HelloWorld@DESKTOP-UQPPB6C MINGW64 /e/Web_Blog/blog (master)
$ npm i hexo-renderer-inferno

npm http fetch GET 200 https://registry.npm.taobao.org/react 528ms

- ##### 选择安装版本

  ##### 官网：

npm i bulma-stylus@0.8.0

​	   提示：

![image-20200329001507240](C:/Users/HelloWorld/AppData/Roaming/Typora/typora-user-images/image-20200329001507240.png)

每输入一行，回车，没有任何提示，说明操作成功

```
npm config set registry https://registry.npm.taobao.org

npm config set loglevel http

npm config set progress false

 vi ~/.npmrc
```

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240009867.png)

4.npm的配置被存储在  ~/.npmrc，可以随时改

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240009815.png)



### 第二种·nrm

1.使用nrm。读者可在cmd命令窗口执行以下命令进行全局安装nrm：

```
npm i nrm -g
```


读者可以使用 nrm ls命令查看常用的镜像源：

* ```
  C:\Users\WU>nrm ls
  
  * npm ---- https://registry.npmjs.org/
    cnpm --- http://r.cnpmjs.org/
    taobao - https://registry.npm.taobao.org/
    nj ----- https://registry.nodejitsu.com/
  rednpm - http://registry.mirror.cqupt.edu.cn/
  npmMirror  https://skimdb.npmjs.com/registry/
    edunpm - http://registry.enpmjs.org/
  ```

  注：列表中的表示默认选中*
  2.使用nrm use XXXX替换默认镜像源,以淘宝（taobao）为例：

* ```
  C:\Users\WU>nrm use taobao
                           verb config Skipping project config: C:\Users\WU/.npmrc. (matches userconfig)
  
     Registry has been set to: https://registry.npm.taobao.org/
  
  
  C:\Users\WU>nrm ls
  
    npm ---- https://registry.npmjs.org/
    cnpm --- http://r.cnpmjs.org/
  
  * taobao - https://registry.npm.taobao.org/
    nj ----- https://registry.nodejitsu.com/
    rednpm - http://registry.mirror.cqupt.edu.cn/
    npmMirror  https://skimdb.npmjs.com/registry/
    edunpm - http://registry.enpmjs.org/
  ```

  接下来，读者使用npm会更加快速。

### 两种进行对比

使用nrm test XXXX,进行测速：

```
C:\Users\WU>nrm test npm

  npm ---- 1358ms


C:\Users\WU>nrm test cnpm

  cnpm --- 216ms
```

### 第三种·vpn

windows下如何代理cmd，加速npm安装

平常用npm安装模块的时候会遇到一个问题，一些库的底层会用到c或者c++，比如 `images` 模块，npm会从github上去下载这些编译好的二进制文件，下载速度会很慢，开了vpn也不行。如下图。

![img](https://user-gold-cdn.xitu.io/2019/1/19/16864344fcc965f3?imageView2/0/w/1280/h/960/format/webp/ignore-error/1)



解决办法

临时代理（推荐）cmd到vpn的端口，cmd窗口关了会恢复成原来的样子。

```
set https_proxy=http://127.0.0.1:1080  //端口指向小飞机(vpn)端口
复制代码
```

永久代理（不推荐）

```
netsh winhttp import proxy source=ie
复制代码
```



![img](https://user-gold-cdn.xitu.io/2019/1/19/1686435334dde533?imageView2/0/w/1280/h/960/format/webp/ignore-error/1)

然后就愉快的安装完了。



#### .-git全局代理[#](https://imchenway.com/2019/12/04/Git拉取代码加速/#git-quan-ju-dai-li)

```
# socks5协议，1080端口修改成自己的本地代理端口
git config --global http.proxy socks5://127.0.0.1:1086
git config --global https.proxy socks5://127.0.0.1:1086

# http协议，1081端口修改成自己的本地代理端口
git config --global http.proxy http://127.0.0.1:1087
git config --global https.proxy https://127.0.0.1:1087
```

- 以上的配置会导致所有git命令都走代理，但是如果你混合使用了国内的git仓库，甚至是局域网内部的git仓库，这就会把原来速度快的改成更慢的了；
- 下面是仅仅针对github进行配置，让github走本地代理，其他的保持不变；

#### 仅GitHub代理[#](https://imchenway.com/2019/12/04/Git拉取代码加速/#jin-github-dai-li)

```
# socks5协议，1080端口修改成自己的本地代理端口
git config --global http.https://github.com.proxy socks5://127.0.0.1:1086
git config --global https.https://github.com.proxy socks5://127.0.0.1:1086

# http协议，1081端口修改成自己的本地代理端口
git config --global http.https://github.com.proxy https://127.0.0.1:1087
git config --global https.https://github.com.proxy https://127.0.0.1:1087
```

#### 相关命令[#](https://imchenway.com/2019/12/04/Git拉取代码加速/#xiang-guan-ming-ling)

```
# 查看所有配置
git config -l
# reset 代理设置
git config --global --unset http.proxy
git config --global --unset https.proxy
```

#### 不使用代理的方法[#](https://imchenway.com/2019/12/04/Git拉取代码加速/#bu-shi-yong-dai-li-de-fang-fa)

1. 修改host

   把下面两行加到host文件末尾

   ```
   151.101.72.249 github.http://global.ssl.fastly.net
   192.30.253.112 github.com
   ```





## gitbash 全局命令-npm,node



### 常用npm安装：

```
npm install --save react react-dom
npm install --save-dev gulp browserify babelify vinyl-source-stream
```

.全局

```
$ npm install babel -g
$ npm install babelify -g
$ npm install vinyl-source-stream -g
```

全局的默认安装路径

```
C:\Users\Administrator\AppData\Roaming\npm
```

创建目录（D:\Java\node\nodejs\node_modules）

```
mkdir -p  D:/Java/node/nodejs/npm_global_modules/node_modules
```

修改路径：

```
npm config set prefix "/d/Java/node/nodejs/npm_global_modules/node_modules"
```

node.js测试

```
http://localhost:3000/
```

退出出node命令行：两次ctrl+C或者一次ctrl+D
退出终端：.exit;



## 文件目录创建

windows       => 	md + 多级目录 

linux/gitbash => 	mkdir -p 



mkdir的-p选项允许你一次性创建多层次的目录，而不是一次只创建单独的目录。例如，我们要在当前目录创建目录Projects/a/src，使用命令

| `1 ` | `mkdir -p Project/a/src` |
| ---- | ------------------------ |
|      |                          |

而不是

| `1 2 3 4 5 ` | `mkdir Project cd Project mkdir a cd a mkdir src` |
| ------------ | ------------------------------------------------- |
|              |                                                   |

　　当然，如果你有mkcd，就可以直接

| `1 ` | `mkcd Project/a/src` |
| ---- | -------------------- |
|      |                      |

　　此外，如果我们想创建多层次、多维度的目录树，mkcd也显得比较苍白了。例如我们想要建立目录Project，其中含有4个文件夹a, b, c, d，且这4个文件都含有一个src文件夹。或许，我们可以逐个创建，但我更倾向于使用单个命令来搞定，而mkdir 的-p选项和shell的参数扩展允许我这么做，例如下面的一个命令就可以完成任务。

| `1 ` | `mkdir -p Project/{a,b,c,d}/src` |
| ---- | -------------------------------- |
|      |                                  |



- 
