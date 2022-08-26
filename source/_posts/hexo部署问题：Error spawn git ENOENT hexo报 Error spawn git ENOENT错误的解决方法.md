---

title: 'hexo部署问题：Error spawn git ENOENT hexo报 Error spawn git ENOENT错误的解决方法'
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-10-21 00:22:03
authorLink:
tags:
keywords:
description: hexo部署问题：Error spawn git ENOENT hexo报 Error spawn git ENOENT错误的解决方法
---

# hexo报 Error: spawn git ENOENT错误的解决方法

在windows的cmd，执行hexo d突然就报Error: spawn git ENOENT错误。如下图

![img](https:////upload-images.jianshu.io/upload_images/5469770-f865f1e0bd1d0e24.png?imageMogr2/auto-orient/strip|imageView2/2/w/1200/format/webp)

看到报错里的乱码，想起正好当天改了_config.yml中的language为language: zh_cn，以为是这个问题，但改回去后问题仍然存在。

在网上搜了一圈，有效的解决方法是。。。。。。

在gitbash中执行该命令。



作者：木头场主
链接：https://www.jianshu.com/p/7f88e94993a2
来源：简书
著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。



## bat脚本启动git bash窗口，并执行命令-

一键清理生成发布备份+

bash在gitbash执行日志不乱码+

```cmd
@echo OFF
::重装系统后注意两处盘符的修改
G:
cd G:\MuyanGitBlog\MuyanGit\杂项\博客备份\
start D:\MySoftware\DEV\VersionCtrl\Git\git-bash.exe -c "bash bolg_backup.sh"
```

```cmd
start "" "D:\MySoftware\DEV\VersionCtrl\Git\bin\sh.exe" --login -i -l -c 'bash bolg_backup.sh'                                                                                                            
```



```bash
#!/bin/bash
#重装系统后注意两处盘符的修改
##exec 1>>G:\MuyanGitBlog\MuyanGit\杂项\博客备份\log.txt 2>&1
##cd G:/MuyanGitBlog/MuyanGit 
exec 3>&1 4>&2
trap 'exec 2>&4 1>&3' 0 1 2 3
exec 1>>log.txt 2>&1
# Everything below will go to the file 'log.txt':

# 执行的命令主体
echo 开始运行备份命令—————————————— && echo `date`······备份进行中 && hexo clean && hexo g && hexo d && hexo b && echo MuyanGit博客备份 && echo 结束运行备份命令—————————————— && echo `date`······备份结束中
```

```

```



## ![image-20211111032136879](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211111032136879.png)

## 2.2 参数说明

- start git-bash.ext： 在cmd脚本中启动gitbash窗口
- -c: 设置启动参数， 各个启动参数用&&分隔
- git config --global gui.encoding utf-8 : 设置编码utf-8

## 2.3 效果 

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110210030823.png)

这样随你怎么玩都不会乱码~ 







# [hexo部署到github的时候可以动态添加commit的message吗

发布于 2016-10-12

hexo部署到github的时候commit信息是直接写在配置文件里的，如果需要更新message，就需要每次部署前改一下配置文件
能不能直接在部署命令后面传入需要的更新的message呢？

可以：如下图配置

```
# Deployment
## Docs: https://hexo.io/docs/deployment.html
deploy:
  type: git #部署方式尝试修改引起变化
  repo: 
    github: git@git.zhlh6.cn:MuyanGit/MuyanGit.github.io.git
    #github: https://github.com/MuyanGit/MuyanGit.github.io.git
    #coding: 
  branch: master #main #master是旧的 #部署分支
  message: MuyanGit 的网站”更新“中······{{ now("YYYY-MM-DD HH:mm:ss") }}【https://MuyanGit.github.io/ 】
# backup
backup:
  type: git 
  message: MuyanGit 的网站”备份“中······{{ now("YYYY-MM-DD HH:mm:ss") }}【https://MuyanGit.github.io/ 】
  #(备份时候可以在这里加入备注2021年9月05日·星期0·23·48·58)备份之前分别执行 hexo c hexo g hexo d  hexo b 
  repo:
    #github: https://hub.fastgit.org/MuyanGit/MuyanGit.github.io.git,backup
    github: https://github.com/MuyanGit/MuyanGit.github.io.git,backup
    #coding:
```

![image-20211021011004485](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110210110426.png)





# hexo n " 如何完整记录所有bash脚本操作+当做日志+日志记录+windows如何运行bash    "



## gitbash中可以 power也可以

```
#!/bin/bash
exec 3>&1 4>&2
trap 'exec 2>&4 1>&3' 0 1 2 3
exec 1>H:/MuyanGitBlog/MuyanGit/log.txt 2>&1
# Everything below will go to the file 'log.out':

# 执行的命令主体
cd H:/MuyanGitBlog/MuyanGit&&echo `date`备份进行中&hexo clean&hexo g&hexo d&hexo b&echo MuyanGit博客备份&echo 结束运行备份命令&&echo `date`备份结束中
```



## 日志记录

```
#!/bin/bash
(
echo " `date` : part 1 - start "
ssh -f admin@server.com 'bash /www/htdocs/server.com/scripts/part1.sh logout exit'
echo " `date` : sleep 120"
sleep 120
echo " `date` : part 2 - start"
ssh admin@server.com 'bash /www/htdocs/server.com/scripts/part2.sh logout exit'
echo " `date` : part 3 - start"
ssh admin@server.com 'bash /www/htdocs/server.com/scripts/part3.sh logout exit'
echo " `date` : END"
) | tee -a /home/scripts/cron/logs
```



我通常在每个脚本的开头放置类似于以下内容的内容（特别是如果它将作为守护程序运行）：

```sh
#!/bin/bash
exec 3>&1 4>&2
trap 'exec 2>&4 1>&3' 0 1 2 3
exec 1>log.out 2>&1
# Everything below will go to the file 'log.out':
```

```
说明：

exec 3>&1 4>&2

保存文件描述符，以便可以将它们恢复到重定向之前的状态，也可以将自身用于输出到以下重定向之前的状态。

trap 'exec 2>&4 1>&3' 0 1 2 3

恢复特定信号的文件描述符。通常不需要，因为应该在子外壳退出时将其还原。

exec 1>log.out 2>&1

重定向stdout到文件，log.out然后重定向stderr到stdout。请注意，当您希望它们转到同一文件时，顺序很重要。stdout 必须先重定向，然后才能stderr重定向到stdout。

从那时起，要查看控制台上的输出（也许），您只需将其重定向到即可&3。例如，

echo "$(date) : part 1 - start" >&3
stdout在执行上面的第3行之前，它将转到所指示的任何地方（大概是控制台）。

— 机器人
 source
<< niceroot，谢谢！我在脚本的开头添加了三行（exec，trap，exec），并且能够同时获取stdout和stderr。但是一个问题：我已经看到“文件描述符3（pipe：XXX）在some_command上泄漏” ...请让我知道如何避免出现这些错误。我在自定义面板中使用基于busybox的sh。
— kumar
3
伟大的功夫在这里！-更好的是使用trap 'exec 2>&4 1>&3' 0 1 2 3 RETURN。每次使用.shell执行shell函数或脚本时，RETURN伪sigspec恢复文件描述符。或源内置命令执行完毕。由于这个原因（以及其他原因），我在最后两行中添加：return＆exit 0-仅需2美分，@ nicerobot恭喜您！
— DavAlPi'3
通过shell的全局变量记录shell脚本的细节很多。我们可以在外壳程序脚本中模拟类似的日志记录：cubicrace.com/2016/03/efficiency-logging-mechnism-in-shell.html 文章详细介绍了日志级别，如INFO，DEBUG，ERROR。跟踪详细信息，例如脚本入口，脚本出口，函数入口，函数出口。
— Piyush Chordia'3
trap信号的枚举看起来有些奇怪。通常，您也希望包括在内15。
— 三胞胎
1
@PiyushChordia链接修复：cubicrace.com/2016/03/ficient-logging-mechnism-in-shell.html
— 警惕者
```





## 要将ssh输出输出到您的日志文件，您必须重定向`stderr`到`stdout`。您可以通过`2>&1`在bash脚本之后追加来做到这一点。

它应该看起来像这样：

```sh
#!/bin/bash
(
...
) 2>&1 | tee ...
```

当这不能按正确的顺序显示消息时，请尝试添加另一个子shell：

```sh
#!/bin/bash
((
...
) 2>&1) | tee ...
```







# windows - 打开 git bash shell 窗口，执行命令并在 term 信号后保留

[原文](https://stackoverflow.com/questions/37774951/) 标签 [windows](https://www.coder.work/blog?tag=windows) [git](https://www.coder.work/blog?tag=git) [bash](https://www.coder.work/blog?tag=bash) [shell](https://www.coder.work/blog?tag=shell) [maven](https://www.coder.work/blog?tag=maven)

我有一个批处理文件，它通过打开许多“git bash”shell 窗口来设置我的环境。除了一个烦人的功能之外，这完全有效，如果您按 Ctrl C(或发送任何其他 Term 信号)整个 bash 窗口将关闭。

我希望窗口的行为就像它已正常打开一样，因此当它收到术语信号时，它会返回到 bash 提示符。

这是我的 setup.bat 文件的当前内容:

```
C:
cd \project\
start "" "%SYSTEMDRIVE%\Program Files (x86)\Git\bin\sh.exe" --login -i -l -c "source ali.sh && mvn spring-boot:run"
cd \project2\
start "" "%SYSTEMDRIVE%\Program Files (x86)\Git\bin\sh.exe" --login
```


请注意，第一个启动命令运行 maven，当我想重新启动命令(按 Ctrl+C)时，它会关闭整个窗口。
第二个启动命令在该目录中创建一个新的 bash 窗口，即使使用 Ctrl+C，它也像普通的 bash 窗口一样工作，但我希望它在开始时运行一个命令。

这可能吗？
非常感谢您的帮助



**最佳答案**

像这样的事情可能对你有用:

```
C:
cd \project\
start "" "%SYSTEMDRIVE%\Program Files (x86)\Git\bin\sh.exe" --login -i -l -c "sh -c 'source ali.sh && mvn spring-boot:run; exec sh'"
```


诀窍是将命令包装在:

```
sh -c '...; exec sh'
```

```
"D:\MySoftware\DEV\VersionCtrl\Git\bin\sh.exe"
start "" "D:\MySoftware\DEV\VersionCtrl\Git\bin\sh.exe" --login -i -l -c "sh -c 'bash bolg_backup.sh;exec sh'"
```

```
start "" "D:\MySoftware\DEV\VersionCtrl\Git\bin\sh.exe" --login -i -l -c 'bash bolg_backup.sh'                                                                                                                          
```



哪里`sh`是你的 shell ，可能是 `bash` .

您实际上可能只需为每个命令添加后缀:`exec sh` ，例如:

```
start "" "%SYSTEMDRIVE%\Program Files (x86)\Git\bin\sh.exe" --login -i -l -c "source ali.sh && mvn spring-boot:run; exec sh"
```

start ""  "D:\MySoftware\DEV\VersionCtrl\Git\bin\sh.exe" -c "G:\MuyanGitBlog\MuyanGit\杂项\博客备份\bolg_backup.sh"

关于windows - 打开 git bash shell 窗口，执行命令并在 term 信号后保留，我们在Stack Overflow上找到一个类似的问题： https://stackoverflow.com/questions/37774951/



