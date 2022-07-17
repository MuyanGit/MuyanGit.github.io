title: 如何配置多个邮箱的ssh key，既能使用github，又能使用gitlab  Windows下配置多个git账号的SSH Key
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2022-07-15 21:54:04
authorAbout:
series:
tags:
keywords:
description:
photos:
---





### 了解windows中的-git-环境设置

```bash
HI@HELLO MINGW64 /
$ cd ~

HI@HELLO MINGW64 ~
$ cd ~/

HI@HELLO MINGW64 ~
$ cd ~/.ssh

HI@HELLO MINGW64 ~/.ssh
$ ls
PonyTown2020  PonyTown2020.pub  config  id_rsa  id_rsa.pub  known_hosts
# PonyTown2020  PonyTown2020.pub 与 id_rsa  id_rsa.pub 是各自邮箱生成的加密公钥私钥
# config 是配置文件

```





本文记录生成同域的多个 git账号的 ssh key 和不同域的多个 ssh key。

## 1. 生成并部署 SSH Key

### 1.1 第一个 SSH Key 的生成

打开 git bash，输入以下命令生成 github-user1 的 SSH Key：



```css
ssh-keygen -t rsa -C "github-user1@email.com"
```

第一个 ssh key 使用默认名字，三下回车，完成第一个默认的 ssh key。

在当前用户目录的 .ssh 目录下会生成 id_rsa 私钥文件和 id_rsa.pub 公钥文件，将 id_rsa.pub 公钥中的内容添加至 github-user1 的 GitHub 云端中。

然后在 git bash 中输入以下命令测试该用户的 SSH 密钥是否有效：



```css
ssh -T git@github.com
```

若连接成功则提示

> *Hi github-user1! You've successfully authenticated, but GitHub does not provide shell access.*

> `ssh -T git@github.com`
>  **注明：**该命令仅限于文件名为默认 id_rsa 的密钥

### 1.2 第二个 SSH Key 的生成

git bash 中输入以下命令，生成 gitee-user1 的密钥，注意第二个 SSH Key 不能再使用默认的文件名 id_rsa，否则会覆盖之前的密钥文件：



```jsx
ssh-keygen -t rsa -f ~/.ssh/id_rsa_gitee_one -C "gitee-user1@email.com"
```

在当前用户目录的 .ssh 目录下会生成 id_rsa_gitee_one 私钥文件和 id_rsa_gitee_one.pub 公钥文件，将 id_rsa_gitee_one.pub 公钥中的内容添加至 gitee-user1 的 Gitee 云端中。

### 1.3 第三个 SSH Key 的生成

git bash 中输入以下命令，生成 github-user2 的密钥，注意第三个 SSH Key 同样不能再使用默认的文件名 id_rsa ，否则会覆盖之前的密钥文件：



```jsx
ssh-keygen -t rsa -f ~/.ssh/id_rsa_github_two -C "github-user2@email.com"
```

在当前用户目录的 .ssh 目录下会生成 id_rsa_github_two 私钥文件和 id_rsa_github_two.pub 公钥文件，将 id_rsa_github_two.pub 公钥中的内容添加至 github-user2 的 GitHub 云端中。

### 1.4 第四个 SSH Key 的生成

git bash 中输入以下命令，生成 gitee-user2 的密钥，注意第四个 SSH Key 不能再使用默认的文件名 id_rsa ，否则会覆盖之前的密钥文件：



```jsx
ssh-keygen -t rsa -f ~/.ssh/id_rsa_gitee_two -C "gitee-user2@email.com"



```

在当前用户目录的 .ssh 目录下会生成 id_rsa_gitee_two 私钥文件和 id_rsa_gitee_two.pub 公钥文件，将 id_rsa_gitee_two.pub 公钥中的内容添加至 gitee-user2 的 Gitee 云端中。

### 1.5 测试生成的 SSH Key

ssh密钥正确生成并且都把公钥部署云端完成，可以分别测试ssh密钥的连接是否有效，使用以下这些命令测试：



```ruby
# 第二个SSH Key测试
ssh -T git@gitee.com -i ~/.ssh/id_rsa_gitee_one
# 连接成功提示
# Welcome to Gitee.com, gitee-user1!

# 第三个SSH Key测试
ssh -T git@github.com -i ~/.ssh/id_rsa_github_two
# 连接成功提示
# Hi github-user2! You've successfully authenticated, but GitHub does not provide shell access.

# 第四个SSH Key测试
ssh -T git@gitee.com -i ~/.ssh/id_rsa_gitee_two
# 连接成功提示
# Welcome to Gitee.com, gitee-user2!
```

也可以使用 ssh agent 添加密钥后进行测试，系统默认只读取id_rsa，为了让 ssh 识别新的密钥，使用 ssh-agent 手动添加私钥：



```ruby
# 查看系统ssh-key代理
ssh-add -l
# Could not open a connection to your authentication agent.

# 如果发现上面的提示,说明系统代理里没有任何key,执行如下操作
exec ssh-agent bash

# 如果系统已经有ssh-key代理 ,执行下面的命令可以删除
ssh-agent -D

# 添加密钥到ssh-agent
ssh-add ~/.ssh/id_rsa_gitee_one
ssh-add ~/.ssh/id_rsa_gitee_two
ssh-add ~/.ssh/id_rsa_github_two



#添加成功之后是可以查询的到的
HI@HELLO MINGW64 ~/.ssh
$ ssh-add -l
3072 SHA256:Q+229iJyJO++lYAi90t9DhO0elwlsJBiim9qkwHxqF0 “MuyanGit@outlook.com” (RSA)
3072 SHA256:X3QpUc/eOvGu84lSpGycy7FAHt0/MHQzZjmvn1GEYGQ 2183227837@qq.com (RSA)

HI@HELLO MINGW64 ~/.ssh
$

```

**注明：** ssh-agent 代理的局限，仅限当前窗口有效，打开新的窗口则ssh连接失效

## 2. 配置config文件

### 2.1 编辑config文件

在 .ssh 目录下创建一个 config 文本文件，每个账号配置一个Host节点，主要配置项说明：



```bash
Host    　    #　主机别名
HostName　    #　服务器真实地址
IdentityFile　#　私钥文件路径
PreferredAuthentications　#　认证方式
User　        #　用户名
```

config 文件内容：



```bash
# ~/.ssh/config 配置多个git的ssh-key
# 第一个默认的SSH Key
Host github.com
    HostName github.com
    IdentityFile C:\\Users\\Administrator\\.ssh\\id_rsa
    PreferredAuthentications publickey

# 第二个SSH Key
Host gitee.com
    HostName gitee.com
    IdentityFile C:\\Users\\Administrator\\.ssh\\id_rsa_gitee_one
    PreferredAuthentications publickey

# 第三个SSH Key
Host two.github.com
    HostName github.com
    IdentityFile C:\\Users\\Administrator\\.ssh\\id_rsa_github_two
    PreferredAuthentications publickey

# 第四个SSH Key
Host two.gitee.com
    HostName gitee.com
    IdentityFile C:\\Users\\Administrator\\.ssh\\id_rsa_gitee_two
    PreferredAuthentications publickey
```

### 2.2 终端测试SSH Key

通过终端测试SSH Key是否生效，分别输入以下命令：



```dart
ssh -T git@github.com
ssh -T git@gitee.com
ssh -T git@two.github.com
ssh -T git@two.gitee.com
```

## 3. 项目仓库测试SSH Key

### 3.1 为各仓库配置用户名和邮箱

分别在各仓库下配置相应的用户名和邮箱

```bash
git config user.name "username"
git config user.email "username@email.com"
```

[git配置用户名邮箱，全局配置/单仓库配置](https://www.cnblogs.com/xxoome/p/9183515.html)

**在项目根目录下进行单仓库配置（作用域只在本仓库下）：**

```
git config user.name "gitlab's Name"

git config user.email "gitlab@xx.com"

git config --list
```

**配置全局的用户名和邮箱：**

```
git config --global user.name "xxxxx"

git config --global user.email "xxxxx@xx.com"

git config --list
```

**查看当前用户名/邮件配置：**

```
#查看用户名配置
git config user.name 

# 查看当前邮件配置
git config user.email
```

### 3.2 同域的远程仓库地址需修改

把同域的第二个账号推送的远程仓库地址修改为不冲突的域，相关命令如下：

```bash
# github.com域
git remote rm origin
git remote add origin git@two.github.com:github-user2/text.git

# gitee.com域
git remote rm origin
git remote add origin git@two.gitee.com:gitee-user2/text.git
PonyTown2020.github.io

git remote add origin git@two.github.com:github-user2/text.git


git add -A 
git commit -m "test main branch"
git push origin main
    

```

