---
title: ' 常用Git命令清单与配置    '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-10-21 01:41:24
authorLink:
tags: git
keywords:
description:
photos:
---

1.创建项目（本地项目）
2.在github新建仓库
3.打开项目所在文件夹, 在文件夹上右键运行: git bash here
4.使用命令

- - git init
  - git add src
  - git commit -m "first commit"
  - git remote add origin git@github.com:MuyanGit/MuyanGit.github.io.git
  - git push -u origin master
  - 最后一步失败之后 git pull --rebase origin master 执行

```
有如下几种解决方法：

1.使用强制push的方法：

git push -u origin master -f 

这样会使远程修改丢失，一般是不可取的，尤其是多人协作开发的时候。

2.push前先将远程repository修改pull下来

git pull origin master

git push -u origin master

3.若不想merge远程和本地修改，可以先创建新的分支：

git branch [name]

然后push

git push -u origin [name]
```







### **常用Git命令清单**

一般来说，日常使用只要记住下图6个命令，就可以了。但是熟练使用，恐怕要记住60～100个命令。

### **名次解释**

下面是我整理的常用 Git 命令清单。

几个专用名词的译名如下: Workspace：

工作区 Index / Stage：

暂存区 Repository：

仓库区（或本地仓库） Remote：远程仓库

### **一、新建代码库**

```shell
# 在当前目录新建一个Git代码库
git init
# 新建一个目录，将其初始化为Git代码库
git init [project-name]
# 下载一个项目和它的整个代码历史
git clone [url]
```

### **二、配置**

Git的设置文件为.gitconfig，它可以在用户主目录下(全局配置)，也可以在项目目录下(项目配置)

```scss
# 显示当前的Git配置
git config --list
# 编辑Git配置文件
git config -e [--global]
# 设置提交代码时的用户信息
git config [--global] user.name "[name]"
git config [--global] user.email "[email address]"
# 颜色设置
git config --global color.ui true                         # git status等命令自动着色
git config --global color.status auto
git config --global color.diff auto
git config --global color.branch auto
git config --global color.interactive auto
git config --global --unset http.proxy                    # remove  proxy configuration on git
```

### 三、增加/删除文件

```powershell
# 添加指定文件到暂存区
git add [file1] [file2] ...
# 添加指定目录到暂存区，包括子目录
git add [dir]
# 添加当前目录的所有文件到暂存区
git add .
# 添加每个变化前，都会要求确认
# 对于同一个文件的多处变化，可以实现分次提交
git add -p
# 删除工作区文件，并且将这次删除放入暂存区
git rm [file1] [file2] ...
# 停止追踪指定文件，但该文件会保留在工作区
git rm --cached [file]
# 改名文件，并且将这个改名放入暂存区
git mv [file-original] [file-renamed]



#删除远程分支
git init 
git remote add origin git@github.com:MuyanGit/muyangit.github.io.git
删除远程分支
git push origin --delete <branchName>
覆盖本地
git fetch --all #覆盖本地
git reset --hard origin/master  #覆盖本地
git pull #覆盖本地
```

### **四、代码提交**

```cmd
# 提交暂存区到仓库区
git commit -m [message]
# 提交暂存区的指定文件到仓库区
git commit [file1] [file2] ... -m [message]
# 提交工作区自上次commit之后的变化，直接到仓库区
git commit -a
# 提交时显示所有diff信息
git commit -v
# 将add和commit合为一步
git commit -am 'message'
# 使用一次新的commit，替代上一次提交
# 如果代码没有任何新变化，则用来改写上一次commit的提交信息
git commit --amend -m [message]
# 重做上一次commit，并包括指定文件的新变化
git commit --amend [file1] [file2] ...

```

### **五、分支**

```crystal
# 列出所有本地分支
git branch
# 列出所有远程分支
git branch -r
# 列出所有本地分支和远程分支
git branch -a
# 新建一个分支，但依然停留在当前分支
git branch [branch-name]
# 新建一个分支，并切换到该分支
git checkout -b [branch]
# 新建一个分支，指向指定commit
git branch [branch] [commit]
# 新建一个分支，与指定的远程分支建立追踪关系
git branch --track [branch] [remote-branch]
# 切换到指定分支，并更新工作区
git checkout [branch-name]
# 切换到上一个分支
git checkout -
# 建立追踪关系，在现有分支与指定的远程分支之间
git branch --set-upstream [branch] [remote-branch]
# 合并指定分支到当前分支
git merge [branch]
# 选择一个commit，合并进当前分支
git cherry-pick [commit]
# 删除分支
git branch -d [branch-name]
# 删除远程分支
git push origin --delete [branch-name]
git branch -dr [remote/branch]
# 检出版本v2.0
git checkout v2.0
# 从远程分支develop创建新本地分支devel并检出
git checkout -b devel origin/develop
# 检出head版本的README文件（可用于修改错误回退）
git checkout -- README 
```

### 六、标签

```crmsh
# 列出所有tag
git tag
# 新建一个tag在当前commit
git tag [tag]
# 新建一个tag在指定commit
git tag [tag] [commit]
# 删除本地tag
git tag -d [tag]
# 删除远程tag
git push origin :refs/tags/[tagName]
# 查看tag信息
git show [tag]
# 提交指定tag
git push [remote] [tag]
# 提交所有tag
git push [remote] --tags
# 新建一个分支，指向某个tag
git checkout -b [branch] [tag]
```

### 七、查看信息

```shell
# 显示有变更的文件
git status
# 显示当前分支的版本历史
git log
# 显示commit历史，以及每次commit发生变更的文件
git log --stat
# 搜索提交历史，根据关键词
git log -S [keyword]
# 显示某个commit之后的所有变动，每个commit占据一行
git log [tag] HEAD --pretty=format:%s
# 显示某个commit之后的所有变动，其"提交说明"必须符合搜索条件
git log [tag] HEAD --grep feature
# 显示某个文件的版本历史，包括文件改名
git log --follow [file]
git whatchanged [file]
# 显示指定文件相关的每一次diff
git log -p [file]
# 显示过去5次提交
git log -5 --pretty --oneline
# 显示所有提交过的用户，按提交次数排序
git shortlog -sn
# 显示指定文件是什么人在什么时间修改过
git blame [file]
# 显示暂存区和工作区的差异
git diff
# 显示暂存区和上一个commit的差异
git diff --cached [file]
# 显示工作区与当前分支最新commit之间的差异
git diff HEAD
# 显示两次提交之间的差异
git diff [first-branch]...[second-branch]
# 显示今天你写了多少行代码
git diff --shortstat "@{0 day ago}"
# 显示某次提交的元数据和内容变化
git show [commit]
# 显示某次提交发生变化的文件
git show --name-only [commit]
# 显示某次提交时，某个文件的内容
git show [commit]:[filename]
# 显示当前分支的最近几次提交
git reflog
```

### **八、远程同步**

```crystal
# 下载远程仓库的所有变动
git fetch [remote]
# 显示所有远程仓库
git remote -v
# 显示某个远程仓库的信息
git remote show [remote]
# 增加一个新的远程仓库，并命名
git remote add [shortname] [url]
git remote add origin git@github.com:MuyanGit/MuyanGit.github.io.git
#本地分支合并远程分支
git branch –set-upstream backup origin/backup
git branch --set-upstream-to=origin/backup 
git remote add origin git@github.com:MuyanGit/muyangit.github.io.backup.git
# 要删除遥控器：
git remote remove origin
# 取回远程仓库的变化，并与本地分支合并	
git pull [remote] [branch]
git pull git@github.com:MuyanGit/MuyanGit.github.io.git master

# 上传本地指定分支到远程仓库
git push [remote] [branch]
# 强行推送当前分支到远程仓库，即使有冲突
git push [remote] --force

#git强制提交本地分支覆盖远程分支
git push origin 分支名 --force
强行推送当前master分支到origin远程仓库，即使有冲突-覆盖
git push origin master --force

# 推送所有分支到远程仓库
git push [remote] --all




```

### **九、撤销**

```crystal
# 恢复暂存区的指定文件到工作区
git checkout [file]
# 恢复某个commit的指定文件到暂存区和工作区
git checkout [commit] [file]
# 恢复暂存区的所有文件到工作区
git checkout .
# 重置暂存区的指定文件，与上一次commit保持一致，但工作区不变
git reset [file]
# 重置暂存区与工作区，与上一次commit保持一致
git reset --hard
# 重置当前分支的指针为指定commit，同时重置暂存区，但工作区不变
git reset [commit]
# 重置当前分支的HEAD为指定commit，同时重置暂存区和工作区，与指定commit一致
git reset --hard [commit]
# 重置当前HEAD为指定commit，但保持暂存区和工作区不变
git reset --keep [commit]
# 新建一个commit，用来撤销指定commit
# 后者的所有变化都将被前者抵消，并且应用到当前分支
git revert [commit]
# 暂时将未提交的变化移除，稍后再移入
git stash
git stash pop
```

### 十、其他

```
git init                                                  # 初始化本地git仓库（创建新仓库）
git config --global user.name "xxx"                       # 配置用户名
git config --global user.email "xxx@xxx.com"              # 配置邮件
git config --global color.ui true                         # git status等命令自动着色
git config --global color.status auto
git config --global color.diff auto
git config --global color.branch auto
git config --global color.interactive auto
git config --global --unset http.proxy                    # remove  proxy configuration on git
git clone git+ssh://git@192.168.53.168/VT.git             # clone远程仓库
git status                                                # 查看当前版本状态（是否修改）
git add xyz                                               # 添加xyz文件至index
git add .                                                 # 增加当前子目录下所有更改过的文件至index
git commit -m 'xxx'                                       # 提交
git commit --amend -m 'xxx'                               # 合并上一次提交（用于反复修改）
git commit -am 'xxx'                                      # 将add和commit合为一步
git rm xxx                                                # 删除index中的文件
git rm -r *                                               # 递归删除
git log                                                   # 显示提交日志
git log -1                                                # 显示1行日志 -n为n行
git log -5
git log --stat                                            # 显示提交日志及相关变动文件
git log -p -m
git show dfb02e6e4f2f7b573337763e5c0013802e392818         # 显示某个提交的详细内容
git show dfb02                                            # 可只用commitid的前几位
git show HEAD                                             # 显示HEAD提交日志
git show HEAD^                                            # 显示HEAD的父（上一个版本）的提交日志 ^^为上两个版本 ^5为上5个版本
git tag                                                   # 显示已存在的tag
git tag -a v2.0 -m 'xxx'                                  # 增加v2.0的tag
git show v2.0                                             # 显示v2.0的日志及详细内容
git log v2.0                                              # 显示v2.0的日志
git diff                                                  # 显示所有未添加至index的变更
git diff --cached                                         # 显示所有已添加index但还未commit的变更
git diff HEAD^                                            # 比较与上一个版本的差异
git diff HEAD -- ./lib                                    # 比较与HEAD版本lib目录的差异
git diff origin/master..master                            # 比较远程分支master上有本地分支master上没有的
git diff origin/master..master --stat                     # 只显示差异的文件，不显示具体内容
git remote add origin git+ssh://git@192.168.53.168/VT.git # 增加远程定义（用于push/pull/fetch）
git branch                                                # 显示本地分支
git branch --contains 50089                               # 显示包含提交50089的分支
git branch -a                                             # 显示所有分支
git branch -r                                             # 显示所有原创分支
git branch --merged                                       # 显示所有已合并到当前分支的分支
git branch --no-merged                                    # 显示所有未合并到当前分支的分支
git branch -m master master_copy                          # 本地分支改名
git checkout -b master_copy                               # 从当前分支创建新分支master_copy并检出
git checkout -b master master_copy                        # 上面的完整版
git checkout features/performance                         # 检出已存在的features/performance分支
git checkout --track hotfixes/BJVEP933                    # 检出远程分支hotfixes/BJVEP933并创建本地跟踪分支
git checkout v2.0                                         # 检出版本v2.0
git checkout -b devel origin/develop                      # 从远程分支develop创建新本地分支devel并检出
git checkout -- README                                    # 检出head版本的README文件（可用于修改错误回退）
git merge origin/master                                   # 合并远程master分支至当前分支
git cherry-pick ff44785404a8e                             # 合并提交ff44785404a8e的修改
git push origin master                                    # 将当前分支push到远程master分支
git push origin :hotfixes/BJVEP933                        # 删除远程仓库的hotfixes/BJVEP933分支
git push --tags                                           # 把所有tag推送到远程仓库
git fetch                                                 # 获取所有远程分支（不更新本地分支，另需merge）
git fetch --prune                                         # 获取所有原创分支并清除服务器上已删掉的分支
git pull origin master                                    # 获取远程分支master并merge到当前分支
git mv README README2                                     # 重命名文件README为README2
git reset --hard HEAD                                     # 将当前版本重置为HEAD（通常用于merge失败回退）
git rebase
git branch -d hotfixes/BJVEP933                           # 删除分支hotfixes/BJVEP933（本分支修改已合并到其他分支）
git branch -D hotfixes/BJVEP933                           # 强制删除分支hotfixes/BJVEP933
git ls-files                                              # 列出git index包含的文件
git show-branch                                           # 图示当前分支历史
git show-branch --all                                     # 图示所有分支历史
git whatchanged                                           # 显示提交历史对应的文件修改
git revert dfb02e6e4f2f7b573337763e5c0013802e392818       # 撤销提交dfb02e6e4f2f7b573337763e5c0013802e392818
git ls-tree HEAD                                          # 内部命令：显示某个git对象
git rev-parse v2.0                                        # 内部命令：显示某个ref对于的SHA1 HASH
git reflog                                                # 显示所有提交，包括孤立节点
git show HEAD@{5}
git show master@{yesterday}                               # 显示master分支昨天的状态
git log --pretty=format:'%h %s' --graph                   # 图示提交日志
git show HEAD~3
git show -s --pretty=raw 2be7fcb476
git stash                                                 # 暂存当前修改，将所有至为HEAD状态
git stash list                                            # 查看所有暂存
git stash show -p stash@{0}                               # 参考第一次暂存
git stash apply stash@{0}                                 # 应用第一次暂存
git grep "delete from"                                    # 文件中搜索文本“delete from”
git grep -e '#define' --and -e SORT_DIRENT
git gc
git fsck
# 生成一个可供发布的压缩包
git archive
```



### 十一、回滚

```cmd
1. 代码回退
git log #查看回到的版本，然后用以下命令，将本地代码回退到某个版本：

git reset --hard HEAD^        #回退到上个版本
git reset --hard commit_id    #退到/进到 指定 commit_id

git push origin HEAD --force #如果需要将回退的某个版本提交远程，可执行以下命令：


回滚之后，想恢复到新的版本怎么办？
git reflog #打印你记录你的每一次操作记录
git reflog 可以查看所有分支的所有操作记录（包括 commit 和 reset 的操作），包括已经被删除的 commit 记录， git log 则不能察看已经删除了的 commit 记录，而且跟进结果可以回退道某一个修改。
2. 返回主分支
git checkout master
```





# 常用

初始化操作：

```
git config --global user.name <name>
// 设置提交者的名字

git config --global user.email <email>
// 设置提交者的邮箱

git config --global core.editor <editor>
// 设置默认文本编辑器

git config --global merge.tool <tool>
// 设置解决合并冲突时差异分析工具

git config --list
// 检查已有的配置信息1234567891011121314
```

------

创建新版本库：

```
git clone <url> #克隆远程版本库
git init #初始化本地版本库12
```

修改和提交：

```
git add . #添加所有改动过的文件到暂存区
git add <file> #添加指定的文件到暂存区

git mv <old> <new> #文件重命名
git rm <file> #删除文件
git rm --cached <file> #停止跟踪文件但不从工作区删除。123456
```

提交文件：

```
git commit -m <file> 'msg' # 提交指定的文件
git commit -m 'msg' # 提交所有暂存区中的文件
git commit -amend # 修改最后一次提交
git commit -C HEAD -a -amend #增补提交（不会产生新的提交记录)1234
```

查看提交历史：

```
git log #查看提交历史
git log -p <file> #查看指定文件的提交历史
git blame <file> #以列表方式查看指定文件的提交历史

gitk #查看当前分支历史记录，gitk貌似是个工具
gitk --all #查看所有分支历史记录

git branch -v #查看所有分支及其最后一次提交记录

git status #查看当前状态

git diff #查看变更内容（工作区与暂存区）
git diff --cached #查看改动（暂存区与版本库，即下次提交的内容）
git diff --staged #同上
git diff master #工作区与版本库对比123456789101112131415
```

------

**git checkout 用法：**

```
git checkout 
git checkout --
# 以缩写字母方式查看文件状态，M、A等等。

git checkout <file>
git checkout -- <file>
# 这两个命令都可以撤销工作区的修改，回到暂存区或者版本区的状态。(不会影响暂存区中的内容）

git checkout HEAD <file1> <file2>
git checkout HEAD .
# 撤销工作区和暂存区的修改（工作区和暂存区都会回到最后一次提交的状态）

git checkout HEAD^^ 
# 创建新分支，指向倒数第二次提交的状态1234567891011121314
```

------

撤销操作：

```
git reset --hard HEAD #撤销工作目录中所有未提交的修改，（工作区和版本库都会回退到最后一次提交的状态）
git reset --hard HEAD^^ #回退到倒数第二次提交的状态。
git reset --hard <hash> #回退到对应的版本
git revert <hash> 撤销指定的提交12345
```

分支与标签：

```
git branch #显示所有本地分支
git checkout <branch/tagname> #切换到指定分支或标签
git checkout -b loaclName origin/remoteName #创建本地分支并追踪到远端分支
git branch <name> #创建新分支
git branch -d <name> #删除本地分支

git tag #列出所有本地标签
git tag <tagname> #基于最新提交创建标签
git tag -d <tagname> #删除标签

git push origin --delete <branchname> # 删除一个远程分支1234567891011
```

合并与衍合

```
git merge <branch> #合并指定分支到当前分支
git rebase <branch> #衍合指定分支到当前分支12
```

远程操作：

```
git remote -v #查看远程版本库信息
git remote show <remote> <url> #查看指定远程版本库信息
git remote add <remote> <url> #添加远程版本库
要添加遥控器：
git remote add origin yourRemoteUrl
最后
git push -u origin master

git fetch <remote> #从远程库获取代码
git pull <remote> <branch> #下载代码及快速合并

git push <remote>:<branch>/<tagname> #删除远程分支或标签
git push -tags #上传所有标签123456789
```

### 备忘：

```
git push origin local-branch:remote-branch
git push origin master:master

// 同步本地分支到远端

git fetch origin master
// 拉取远端master数据

git log -p master origin/master
// 比较本地master和远端master的差别

git merge origin/master
// 合并远端master

git push origin localName:remoteName
git push origin master:master
// 推送本地分支到远端分支

git checkout -b localName origin/remoteName
// 创建本地分支并与远端分支相关联1234567891011121314151617
git branch -m old-name new-name
// 重命名分支名

git branch --set-upstream-to=origin/branch
// 将本地分支与远端分支相关联
```



## 常见问题

##### 1.Git 警告 LF will be replaced by CRLF



![image-20200329225258074](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240028564.png)

原创[DreamLee0625](https://me.csdn.net/vitaminc4) 最后发布于2017-09-18 11:22:43 阅读数 5558 收藏

展开

在使用git add . 命令时，出现如下提示：

```
warning: LF will be replaced by CRLF in .idea/vcs.xml. 1
```

ps：这里只是以这个文件名（vcs.xml）举个例子。
意思是在.idea/vcs.xml文件中，LF（换行，Line Feed）将会被CRLF（回车换行，CarriageReturn）替代。这是因为在windows中换行符为CRLF，而在linux下的换行符为LF。

```
The file will have its original line endings in your working directory.1
```

当报这个警告时是由于文件夹远程不存在，我是直接选择无视他继续提交。目前没有发现什么不妥。

在网上查询后发现，是因为git有自动转换功能，如果想要禁止自动转换功能，则执行如下步骤：

```
rm -rf .git  // 删除.git  
git config --global core.autocrlf false  //禁用自动转换    
git init    
git add .  
```





##### 2.[使用git push时出现error: src refspec master does not match any. 是什么原因](https://segmentfault.com/q/1010000004615080)

[github](https://segmentfault.com/t/github)[git](https://segmentfault.com/t/git)



###### 方案1：git commit -m "first commit"

![image-20200329225427690](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240028099.png)

使用git push是，采用以下步骤：

```
git init
git add README.md
git commit -m "first commit"
git remote add origin https://github.com/focusor/focusor.github.io.git
git push -u origin master
```

产生如下错误：

```
error: src refspec master does not match any. error: failed to push some refs to "xxxxxxx"
```

然后用如下方法解决了：

```
git add .git commit -m "write your meaaage"
```

之后push就成功了，具体原因是什么呢？

https://segmentfault.com/q/1010000004615080?sort=created#comment-area)

[![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240028132.png)**FullStackDeveloper**](https://segmentfault.com/u/reeco)

-  **8.8k**

这种错误一般是因为push的时候暂存区没有文件，确认下add的README.md存不存在

 赞 6

[评论](javascript:;) [赞赏](javascript:;) 2016-03-16

- [**bolelee**](https://segmentfault.com/u/bolelee)： 

  已经执行过git add 和git commit，暂存区是有内容的，为什么还是push失败？并没有修改到README.md，为什么要加这个？试了加这个还是没有解决问题怎么解决？

  

也可能是你分支不正确

![clipboard.png](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110240028155.png)

- 

git add . 会监控工作区的状态树，使用它会把工作时的所有变化提交到暂存区，包括文件内容修改(modified)以及新文件(new)，但不包括被删除的文件.

###### 方案2：touch README  

Git常见错误与操作：error: src refspec master does not match any解决办法

转载[su1573](https://me.csdn.net/su1573) 最后发布于2017-10-19 11:31:09 阅读数 4089 收藏

展开

Git常见错误与操作：error: src refspec master does not match any解决办法

一、 出现错误 error:src refspec master does not match any

原因分析：

引起该错误的原因是目录中没有文件，空目录是不能提交上去的

解决办法：

[html] view plain copy

```
touch README  git add README  git commit –m’first commit’  git push origin master  1234
```

(来自：http://www.open-open.com/lib/view/open1366080269265.html)
实际上

[html] view plain copy

```
git init  1
```

这一步之后创建了一个名为.git的文件夹，不过它在默认状态下是隐藏的，系统将隐藏文件夹显示出来，可以看到有这样一个文件夹。
github上传项目方法：
http://www.oschina.net/question/159132_86728
在你的电脑上装好git

大致流程是：

[html] view plain copy

```
1、 在github上创建项目  2、 使用git clone https://github/xx账号/xx项目.git克隆到本地  3、 编辑项目  4、 git add .(将改动添加到暂存区)  5、 git commit –m”提交说明”  6、 git push origin 将本地更改推送到远程master分支  123456
```

这样你就完成了向远程仓库的推送

如果在github的remote上已经有了文件，会出现错误。此时应当先pull一下，即：

[html] view plain copy

```
git pull origin master  1
```

然后再进行：

[html] view plain copy

```
git push origin master  1
```

二、如果输入git remoteadd origin git@github.com:djqiang（github帐号名）/gitdemo（项目名）.git

```
提示出错信息：fatal: remoteorigin already exists.解决办法如下：123
```

[html] view plain copy

```
1、先输入git remote rmorigin      2、再输入git remote addorigin git@github.com:djqiang/gitdemo.git 就不会报错了！      3、如果输入git remote rmorigin 还是报错的话，error: Could not remove config section'remote.origin'. 我们需要修改gitconfig文件的内容  4、找到你的github的安装路径5、找到一个名为gitconfig的文件，打开它把里面的[remote "origin"]那一行删掉就好了！12345678
```

三、如果输入ssh -T git@github.com
出现错误提示：Permissiondenied (publickey).因为新生成的key不能加入ssh就会导致连接不上github。

```
解决办法如下：1、先输入ssh-agent，再输入ssh-add ~/.ssh/id_key，这样就可以了。2、如果还是不行的话，输入ssh-add~/.ssh/id_key 命令后出现报错Could not open a connection toyour authentication agent.解决方法是key用Git Gui的ssh工具生成，这样生成的时候key就直接保存在ssh中了，不需要再ssh-add命令加入了，其它的user，token等配置都用命令行来做。3、最好检查一下在你复制id_rsa.pub文件的内容时有没有产生多余的空格或空行，有些编辑器会帮你添加这些的。1234567
```

四、如果输入git push origin master

```
提示出错信息：error:failedto push som refs to .......解决办法如下：123
```

[html] view plain copy

```
1、先输入git pullorigin master //先把远程服务器github上面的文件拉下来  2、再输入git pushorigin master  3、如果出现报错 fatal:Couldn't find remote ref master或者fatal: 'origin' doesnot appear to be a git repository以及fatal: Could notread from remote repository.  4、则需要重新输入git remoteadd origingit@github.com:djqiang/gitdemo.git  1234
```

五、Git常见操作

使用git在本地创建一个项目的过程

[html] view plain copy

```
makdir ~/hello-world    //创建一个项目hello-world  cd~/hello-world       //打开这个项目  git init             //初始化   touch README  git add README        //更新README文件  git commit-m 'first commit'     //提交更新，并注释信息“first commit”   git remote add origin git@github.com:defnngj/hello-world.git     //连接远程github项目    git push -u origin master     //将本地项目更新到github项目上去  12345678
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
git config --global user.name "John Doe"  git config --global user.email johndoe@example.com    2   你的编辑器(Your Editor)123456
```

　　现在，你的标识已经设置，你可以配置你的缺省文本编辑器，Git在需要你输入一些消息时会使用该文本编辑器。缺省情况下，Git使用你的系统的缺省编辑器，这通常可能是vi 或者 vim。如果你想使用一个不同的文本编辑器，例如Emacs，你可以做如下操作：

[html] view plain copy

```
git config --global core.editor emacs  1
```

3 检查你的设置(Checking YourSettings)

　　如果你想检查你的设置，你可以使用 git config –list 命令来列出Git可以在该处找到的所有的设置:

[html] view plain copy

```
git config --list    你也可以查看Git认为的一个特定的关键字目前的值，使用如下命令 git config {key}:12345
```

[html] view plain copy

```
git config user.name   4 获取帮助(Getting help)12345
```

　　如果当你在使用Git时需要帮助，有三种方法可以获得任何git命令的手册页(manpage)帮助信息:

[html] view plain copy

```
git help <verb>  git <verb> --help  man git-<verb>  123
```

　　例如，你可以运行如下命令获取对config命令的手册页帮助:

[html] view plain copy

```
git help config  1
```

转载来源：http://blog.csdn.net/s164828378/article/details/52425208

![image-20211116162738240](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211116162738240.png)





