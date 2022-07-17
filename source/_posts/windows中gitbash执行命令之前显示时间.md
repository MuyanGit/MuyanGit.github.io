---
title: '  windows Git 中Git bash执行命令之前显示时间  '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-10-21 04:09:36
authorLink:
tags:
keywords:
description:
photos: https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110210422966.png
---

# windows Git 中Git bash执行命令之前显示时间

[PS1 prompt to show elapsed 显示经过的提示符time 时间](https://unix.stackexchange.com/questions/252229/ps1-prompt-to-show-elapsed-time)

![image-20211021042212796](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110210422966.png)

D:\MySoftware\DEV\VersionCtrl\Git\etc\profile.d\git-prompt.sh

```
if test -f /etc/profile.d/git-sdk.sh
then
	TITLEPREFIX=SDK-${MSYSTEM#MINGW}
else
	TITLEPREFIX=$MSYSTEM
fi

if test -f ~/.config/git/git-prompt.sh
then
	. ~/.config/git/git-prompt.sh
else
	PS1='\[\033]0;$TITLEPREFIX:$PWD\007\]' # set window title
	PS1="$PS1"'\n'                 # new line
	PS1="$PS1"'\[\033[32m\]'       # change to green
	PS1="$PS1"'\u@\h '             # user@host<space>
	PS1="$PS1"'\[\033[35m\]'       # change to purple
	PS1="$PS1"'$MSYSTEM '          # show MSYSTEM
	PS1="$PS1"'\[\033[33m\]'       # change to brownish yellow
	PS1="$PS1"'\w'                 # current working directory
	PS1="$PS1"' \t'                # time
	if test -z "$WINELOADERNOEXEC"
	then
		GIT_EXEC_PATH="$(git --exec-path 2>/dev/null)"
		COMPLETION_PATH="${GIT_EXEC_PATH%/libexec/git-core}"
		COMPLETION_PATH="${COMPLETION_PATH%/lib/git-core}"
		COMPLETION_PATH="$COMPLETION_PATH/share/git/completion"
		if test -f "$COMPLETION_PATH/git-prompt.sh"
		then
			. "$COMPLETION_PATH/git-completion.bash"
			. "$COMPLETION_PATH/git-prompt.sh"
			PS1="$PS1"'\[\033[36m\]'  # change color to cyan
			PS1="$PS1"'`__git_ps1`'   # bash function
		fi
	fi
	PS1="$PS1"'\[\033[0m\]'        # change color
	PS1="$PS1"'\n'                 # new line
	PS1="$PS1"'$ '                 # prompt: always $
fi

MSYS2_PS1="$PS1"               # for detection by MSYS2 SDK's bash.basrc

# Evaluate all user-specific Bash completion scripts (if any)
if test -z "$WINELOADERNOEXEC"
then
	for c in "$HOME"/bash_completion.d/*.bash
	do
		# Handle absence of any scripts (or the folder) gracefully
		test ! -f "$c" ||
		. "$c"
	done
fi

```



# [How to Shorten Git Bash 如何缩短 Git BashPrompt 提示 (Windows) (视窗)](https://stackoverflow.com/questions/54887987/how-to-shorten-git-bash-prompt-windows)

[Ask Question 问问题](https://stackoverflow.com/questions/ask)

Asked 问道 2 years, 7 months ago 2年7个月前

Active 活跃 [1 year, 6 months ago 一年零六个月前](https://stackoverflow.com/questions/54887987/how-to-shorten-git-bash-prompt-windows?lastactivity)

Viewed 观看 8k times 8k 次



17

3

How do I shorten my git bash prompt from something like this

我如何缩短我的 git bash 提示从这样的东西

```
Malik@LAPTOP-7R9912OI MINGW64 ~/Desktop/test
$
```

to something like this

这样的事情

```
Malik@test$
```

I am using git bash on windows with git version 2.21.0 (26-02-2019)

我在 windows 上使用 git bash 和 git 版本2.21.0(26-02-2019)

[windows 窗户](https://stackoverflow.com/questions/tagged/windows)[git-bash](https://stackoverflow.com/questions/tagged/git-bash)

[Share 分享](https://stackoverflow.com/q/54887987)

Follow 跟着

[edited 编辑Feb 26 '19 at 15:01 2月26’1915:01](https://stackoverflow.com/posts/54887987/revisions)

[![img](https://i.stack.imgur.com/9HhFs.png?s=64&g=1)](https://stackoverflow.com/users/1773434/govind-parmar)

[Govind Parmar](https://stackoverflow.com/users/1773434/govind-parmar)

**18.7k 18.7 k**66 gold badges 6枚金徽章4949 silver badges 49枚银徽章7979 bronze badges 79枚铜徽章

asked 问Feb 26 '19 at 14:41 2月26’1914:41

[![img](https://lh6.googleusercontent.com/-n0kBNdk4Mq8/AAAAAAAAAAI/AAAAAAAAAGc/uHVRvGWeA1U/photo.jpg?sz=64)](https://stackoverflow.com/users/10177043/malik-bagwala)

[malik bagwala](https://stackoverflow.com/users/10177043/malik-bagwala)

**1,594**22 gold badges 两枚金徽章1414 silver badges 14枚银质徽章2828 bronze badges 28枚铜徽章

[Add a comment 添加评论](https://stackoverflow.com/questions/54887987/how-to-shorten-git-bash-prompt-windows#)



## 3 Answers 3个答案

[Active 活跃](https://stackoverflow.com/questions/54887987/how-to-shorten-git-bash-prompt-windows?answertab=active#tab-top)[Oldest 最老的](https://stackoverflow.com/questions/54887987/how-to-shorten-git-bash-prompt-windows?answertab=oldest#tab-top)[Votes 投票](https://stackoverflow.com/questions/54887987/how-to-shorten-git-bash-prompt-windows?answertab=votes#tab-top)





22



An alternative answer is to go to `C:\Program Files\Git\etc\profile.d` and open the `git-prompt.sh` file. It contains the default configuration/prompt for Git Bash.

另一种方法是进入 c: Program Files Git etc profile.d 并打开 Git-prompt。Sh 文件。它包含 Git Bash 的默认配置/提示。

```
if test -f /etc/profile.d/git-sdk.sh
then
    TITLEPREFIX=SDK-${MSYSTEM#MINGW}
else
    TITLEPREFIX=$MSYSTEM
fi

if test -f ~/.config/git/git-prompt.sh
then
    . ~/.config/git/git-prompt.sh
else
    PS1='\[\033]0;$TITLEPREFIX:$PWD\007\]' # set window title
    PS1="$PS1"'\n'                 # new line
    PS1="$PS1"'\[\033[32m\]'       # change to green
    # PS1="$PS1"'\u@\h '             # user@host<space>
    # PS1="$PS1"'\[\033[35m\]'       # change to purple
    # PS1="$PS1"'$MSYSTEM '          # show MSYSTEM
    # PS1="$PS1"'\[\033[33m\]'       # change to brownish yellow
    PS1="$PS1"'\W'                 # current working directory
    if test -z "$WINELOADERNOEXEC"
    then
        GIT_EXEC_PATH="$(git --exec-path 2>/dev/null)"
        COMPLETION_PATH="${GIT_EXEC_PATH%/libexec/git-core}"
        COMPLETION_PATH="${COMPLETION_PATH%/lib/git-core}"
        COMPLETION_PATH="$COMPLETION_PATH/share/git/completion"
        if test -f "$COMPLETION_PATH/git-prompt.sh"
        then
            . "$COMPLETION_PATH/git-completion.bash"
            . "$COMPLETION_PATH/git-prompt.sh"
            PS1="$PS1"'\[\033[36m\]'  # change color to cyan
            PS1="$PS1"'`__git_ps1`'   # bash function
        fi
    fi
    PS1="$PS1"'\[\033[0m\]'        # change color
    # PS1="$PS1"'\n'                 # new line
    PS1="$PS1"' $ '                 # prompt: always $
fi

MSYS2_PS1="$PS1"               # for detection by MSYS2 SDK's bash.basrc

# Evaluate all user-specific Bash completion scripts (if any)
if test -z "$WINELOADERNOEXEC"
then
    for c in "$HOME"/bash_completion.d/*.bash
    do
        # Handle absence of any scripts (or the folder) gracefully
        test ! -f "$c" ||
        . "$c"
    done
fi
```

In my configuration, I commented out the `user@host<space>`, the `MINGW64` and changed the working directory to its basename by changing `\w` to `\W`.

在我的配置中，我注释掉了 user@host < space > ，MINGW64，并通过将 w 更改为 w 将工作目录更改为 basename。



[Share 分享](https://stackoverflow.com/a/61379148)

Follow 跟着

answered 回答Apr 23 '20 at 4:00 4月23日20时4分

[![img](https://i.stack.imgur.com/L0Vgo.jpg?s=64&g=1)](https://stackoverflow.com/users/7321307/krizza)

[Krizza 女名女子名](https://stackoverflow.com/users/7321307/krizza)

**348**33 silver badges 3枚银质徽章77 bronze badges 7枚铜徽章

- 7

  This works, but be careful: git updates overwrite this file. This file checks for the existence of 这是可行的，但是要小心: git 更新会覆盖这个文件`~/.config/git/git-prompt.sh` which if exists takes precedence, so you're better of making your changes there, or directly in 如果存在优先，所以你最好在那里修改，或者直接在`~/.bashrc`. 

  – [Willem 男名男子名](https://stackoverflow.com/users/928483/willem)

   [Jul 10 '20 at 6:56 2010年7月10日6:56](https://stackoverflow.com/questions/54887987/how-to-shorten-git-bash-prompt-windows#comment111105146_61379148) 

- I'm unable to change git- 我不能改变 git-prompt 提示.sh file as the system is complaining that's readonly file. chmod also isn't working (permission denied). What I might be missing? .Sh 文件，因为系统正在抱怨这是只读文件。Chmod 也不工作(许可被拒绝)。我可能错过了什么？ 

  – [Amit128 阿米特128](https://stackoverflow.com/users/1402720/amit128)

   [May 5 at 15:26 5月5日15:26](https://stackoverflow.com/questions/54887987/how-to-shorten-git-bash-prompt-windows#comment119140042_61379148)

[Add a comment 添加评论](https://stackoverflow.com/questions/54887987/how-to-shorten-git-bash-prompt-windows#)





17







In Git Bash:

在 Git Bash 中:

```
cd ~
notepad .bashrc
```

In notepad, add the line `PS1="foobar>"` (replace `foobar>` with whatever text you want)

在 notepad 中，添加行 PS1 = “ foobar >”(将 foobar > 替换为您想要的任何文本)

After saving `~/.bashrc`, in Git Bash, run the command:

在 Git Bash 中保存 ~/. bashrc 之后，运行以下命令:

```
source ~/.bashrc
```

You may find this [online `.bashrc` generator](http://bashrcgenerator.com/) useful to experiment with to find a prompt you like.

你可能会发现这个在线.bashrc 生成器有用的实验，找到一个提示您喜欢。



[Share 分享](https://stackoverflow.com/a/54888369)

Follow 跟着

answered 回答Feb 26 '19 at 14:59 2月26’1914:59

[![img](https://i.stack.imgur.com/9HhFs.png?s=64&g=1)](https://stackoverflow.com/users/1773434/govind-parmar)

[Govind Parmar](https://stackoverflow.com/users/1773434/govind-parmar)

**18.7k 18.7 k**66 gold badges 6枚金徽章4949 silver badges 49枚银徽章7979 bronze badges 79枚铜徽章

- after the command notepad .bashrc i get a message 'would you like to create a .bashrc file' and it opens a blank file 在命令记事本后面。我收到一条消息，你想创建一个。然后打开一个空白文件 

  – [malik bagwala](https://stackoverflow.com/users/10177043/malik-bagwala)

   [Feb 26 '19 at 16:15 2月26’1916:15](https://stackoverflow.com/questions/54887987/how-to-shorten-git-bash-prompt-windows#comment96548634_54888369)

- 1

  @malikbagwala Then say "Yes" to that @ malikbagwala 那就答应吧 

  – [Govind Parmar](https://stackoverflow.com/users/1773434/govind-parmar)

   [Feb 26 '19 at 16:15 2月26’1916:15](https://stackoverflow.com/questions/54887987/how-to-shorten-git-bash-prompt-windows#comment96548639_54888369)

[Add a comment 添加评论](https://stackoverflow.com/questions/54887987/how-to-shorten-git-bash-prompt-windows#)





-5



The:

返回文章页面

> LAPTOP-7R9912OI MINGW6

is the name of your PC.

是你电脑的名称。

Search in setting

在设置中搜索

> 'about your PC'
>
> 关于你的电脑

and look for

然后寻找

> rename
>
> 重新命名

There you can rename your pc and it should change the username in git-bash

在那里你可以重命名你的电脑，它应该改变在 git-bash 的用户名



[Share 分享](https://stackoverflow.com/a/54888266)

Follow 跟着
