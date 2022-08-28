title: Windows Terminal 完美配置 PowerShell 7.1 - 知乎
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2021-11-10 20:24:13
authorAbout:
series:
tags: Terminal 
keywords:
description:

photos:
---


首发于[修辞与编程](https://www.zhihu.com/column/c_1099361984826499072)

# Windows Terminal 完美配置 PowerShell 7.1

[![littleNewton](https://pic2.zhimg.com/v2-6f2475da64a7302f15a5c2bea51d2ee8_xs.jpg?source=172ae18b)](https://www.zhihu.com/people/littleNewton)

[littleNewton](https://www.zhihu.com/people/littleNewton)

700 人赞同了该文章

> **坑边闲话**：忆往昔岁月，不堪回首，伟大的 Windows 竟然拿不出一个像样的终端模拟器。mintty.exe 和 封装后的 cmder 之流，总是有各种问题，而且不兼容 emoji 字符。后来，全网 Windows 用户随着一个华丽的广告沸腾了，微软宣布了终端软件 Windows Terminal 的开发进程，而且开源！如今，Windows Terminal 正式版已经陪伴我们走过了很长一段时间，其稳定性和易用性已经非常不错，关键是颜值相当高。**如果你是一个追求完美与和谐的 User，那么请跟上我的步伐，我们重新起航！**

**重要提醒**：本文的所有配置经过无数网友的多重考验，**请勿在配置过程中突发奇想**而走弯路，一定要认真阅读每一个段落、每一个句子！



![img](https://pic2.zhimg.com/80/v2-59db8c16ee82335a0f6229b1f01f5481_720w.jpg)图 1：常规展示





![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-f25122805f8f8ab76ffc979238fc2444_720w.jpg)

图 2：在 git 目录下的效果。

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url/img202208262338870.jpeg)

## 1. 安装 Windows Terminal

相信这一步对大多数人不构成任何困难，去 **Microsoft Store** 搜索下载就是了。

```cmd
代理打开后，可能无法安装

```

配置

![image-20211110204016221](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110204016221.png)

```cmd
NICE! 安装成功，问题主要集中在两点：
1。字体选择时，字体Fira Code NF中间加了空格，导致程序配置识别不了，改FiraCode NF正常了；
2。最后的配置时，按下面的评论一切ok
# 设置 PowerShell 主题
Set-Theme Paradox
由于oh-my-push已经更新，这个语句不识别了。需要换成

Set-PoshPrompt -Theme Paradox
```



修改后的配置文件：

```cmd
/* 
 * Author: 刘鹏
 * Email: littleNewton6@gmail.com
 * Date: 2020, Nov. 30
 * <Alt> + Settings，打开默认设置
 * 参考文档：https://aka.ms/terminal-documentation
 * DESCRIPTION: 配置 Windows Terminal 的选项文件
 * TAB_SIZE = 8
 *字体空格，已经修改
 *显示cmd，方便cmd的管理员操作--> 该p7终端会多线程并发执行 命令&命令
 */

 {
	"$schema": "https://aka.ms/terminal-profiles-schema",
	"defaultProfile": "{574e775e-4f2a-5b96-ac1e-a2962a402336}",

	// 全局主题
	"theme": "system",
	"alwaysShowTabs": true,
	"tabWidthMode": "equal",
	"confirmCloseAllTabs": false,

	// 位置
	// (1) 1920x1080 - (320, 65)
	// (2) 5120x2880 - (1275,692)
	"initialPosition": "135,140",
	"initialCols": 135,
	"initialRows": 45,

	// 禁止自动生成
	"disabledProfileSources": [
		"Windows.Terminal.Azure"
	],





	// ======================== PROFILES 配置 BEGIN ========================
	"profiles": [


		// ======================== PWSH7 配置 BEGIN ========================
		{
			// 键标记
			"guid":			"{574e775e-4f2a-5b96-ac1e-a2962a402336}",
			"name":			"PowerShell Core 7.1.0",
			"source":		"Windows.Terminal.PowershellCore",
			// 行为
			"closeOnExit":		true,
			"commandline":		"C:/Program Files/PowerShell/7/pwsh.exe -nologo",
			"hidden":		false,
			"historySize":		9001,
			"snapOnInput":		true,
			"startingDirectory": ".",
			// 外观
			"icon":			"D:/Users/newton/Software/develop/shell/pwsh-7.1.ico",
			"acrylicOpacity":	0.5,
			"cursorColor":		"#FFFFFF",
			"cursorShape":		"bar",
			"fontFace":		"FiraCode NF",
			"fontSize":		11,
			"padding":		"5, 5, 20, 25",
			"useAcrylic":		false,
			// 颜色主题
			"colorScheme":		"Homebrew"
		},
		// ======================== PWSH7 配置 END   ========================


		// ======================== WSL 配置 BEGIN ========================
		{
			// 键标记
			"guid":			"{07b52e3e-de2c-5db4-bd2d-ba144ed6c273}",
			"name":			"Ubuntu-20.04",
			"source":		"Windows.Terminal.Wsl",
			// 行为
			"closeOnExit":		true,
			"commandline":		"wsl.exe -d Ubuntu-20.04",
			"hidden":		false,
			"historySize":		9001,
			"snapOnInput":		true,
			"startingDirectory":	".",
			// 外观
			"acrylicOpacity":	0.5,
			"cursorColor":		"#FFFFFF",
			"cursorShape":		"bar",
			"fontFace":		"FiraCode NF",
			"fontSize":		11,
			"padding":		"5, 5, 20, 25",
			"useAcrylic":		false,
			// 颜色主题
			"colorScheme":		"Homebrew"
		},
		// ======================== WSL 配置 END   ========================


		// ======================== PWSH5 配置 BEGIN ========================
		{
			// 键标记
			"guid":			"{61c54bbd-c2c6-5271-96e7-009a87ff44bf}",
			"name":			"Windows PowerShell",
			// 行为
			"closeOnExit":		true,
			"commandline":		"powershell.exe",
			"hidden": true,
			"historySize":		9001,
			"snapOnInput":		true,
			"startingDirectory":	".",
			// 外观
			"acrylicOpacity":	0.5,
			"cursorColor":		"#FFFFFF",
			"cursorShape":		"bar",
			"fontFace":		"FiraCode NF",
			"fontSize":		11,
			"padding":		"5, 5, 20, 25",
			"useAcrylic":		false,
			// 颜色主题
			"colorScheme":		"Homebrew"
		},
		// ======================== PWSH5 配置 END   ========================


		// ======================== CMD 配置 BEGIN ========================
		{
			// 键标记
			"guid":		"{0caa0dad-35be-5f56-a8ff-afceeeaa6101}",
			"name":		"cmd",
			// 行为
			"commandline":	"cmd.exe",
			//不隐藏CMD
			"hidden":	false,
			// 字体
			"fontFace":	"FiraCode NF",
			"fontSize":	11
		},
		// ======================== CMD 配置 END   ========================


		// ======================== AZURE 配置 BEGIN ========================
		{
			"guid":		"{b453ae62-4e3d-5e58-b989-0a998ec441b8}",
			"name":		"Azure Cloud Shell",
			"hidden":	true,
			"source":	"Windows.Terminal.Azure"
		}
		// ======================== AZURE 配置 END   ========================


	],
	// ======================== PROFILES 配置 END   ========================





	// ======================== COLOR SCHEME 配置 BEGIN ========================
	"schemes": [
		{
			"name":		"Homebrew",
			"black":	"#000000",
			"red":		"#FC5275",
			"green":	"#00a600",
			"yellow":	"#ffff00",
			"blue":		"#6666e9",
			"purple":	"#ff00ff",
			"cyan":		"#00a6b2",
			"white":	"#bfbfbf",
			"brightBlack":	"#666666",
			"brightRed":	"#ff6060",
			"brightGreen":	"#00d900",
			"brightYellow":	"#fdff73",
			"brightBlue":	"#00a2ff",
			"brightPurple":	"#ff08ff",
			"brightCyan":	"#53ffff",
			"brightWhite":	"#e5e5e5",
			"background":	"#283033",
			"foreground":	"#00ff00"
		}
	],
	// ======================== COLOR SCHEME 配置 END   ========================





	// ======================== HOTKEY 配置 BEGIN ========================
	"keybindings": [


		// ======================== 1. 界面视图 配置 BEGIN ========================
		// 1.1 调节字体大小
		{ "command": { "action": "adjustFontSize", "delta":  1 }, "keys": "ctrl+=" },
		{ "command": { "action": "adjustFontSize", "delta": -1 }, "keys": "ctrl+-" },
		{ "command":             "resetFontSize",                 "keys": "ctrl+0" },
		// ======================== 1. 界面视图 配置 END   ========================


		// ======================== 2. PANE 分割 配置 BEGIN ========================
		// 2.1 水平、竖直分割
		{ "command": { "action": "splitPane", "split": "horizontal" }, "keys": "alt+shift+-"    },
		{ "command": { "action": "splitPane", "split": "vertical"   }, "keys": "alt+shift+plus" },
		{ "command": { "action": "splitPane", "split": "auto"       }, "keys": "alt+shift+|"    },
		{ "command": { "action": "splitPane", "split": "auto", "splitMode": "duplicate" }, "keys": "alt+shift+d" },
		{ "command": { "action": "splitPane", "split": "horizontal", "profile": "Ubuntu-20.04" }, "keys": "alt+shift+u" },
		// 2.2 按下 Alt 键，同时按下方向键，在多个 pane 之间切换
		{ "command": { "action": "moveFocus",  "direction": "down"  }, "keys": "alt+down"  },
		{ "command": { "action": "moveFocus",  "direction": "left"  }, "keys": "alt+left"  },
		{ "command": { "action": "moveFocus",  "direction": "right" }, "keys": "alt+right" },
		{ "command": { "action": "moveFocus",  "direction": "up"    }, "keys": "alt+up"    },
		// 2.3 按下 Alt + Shift，同时按下方向键，调整当前 pane 的大小
		{ "command": { "action": "resizePane", "direction": "down"  }, "keys": "alt+shift+down"  },
		{ "command": { "action": "resizePane", "direction": "left"  }, "keys": "alt+shift+left"  },
		{ "command": { "action": "resizePane", "direction": "right" }, "keys": "alt+shift+right" },
		{ "command": { "action": "resizePane", "direction": "up"    }, "keys": "alt+shift+up"    },
		// 2.4 关闭 pane
		{ "command": "closePane", "keys": "alt+shift+w" },
		// ======================== 2. PANE 分割 配置 BEGIN ========================


		// ======================== 3. 关于标签 配置 BEGIN ========================
		// 3.1 新建默认标签页
		{ "command": "newTab", "keys": ["ctrl+n"]},
		// 3.2 新建 N 号 profile 的标签
		{ "command": { "action": "newTab", "index": 0 }, "keys": "ctrl+shift+1" },
		{ "command": { "action": "newTab", "index": 1 }, "keys": "ctrl+shift+2" },
		{ "command": { "action": "newTab", "index": 2 }, "keys": "ctrl+shift+3" },
		{ "command": { "action": "newTab", "index": 3 }, "keys": "ctrl+shift+4" },
		{ "command": { "action": "newTab", "index": 4 }, "keys": "ctrl+shift+5" },
		{ "command": { "action": "newTab", "index": 5 }, "keys": "ctrl+shift+6" },
		{ "command": { "action": "newTab", "index": 6 }, "keys": "ctrl+shift+7" },
		{ "command": { "action": "newTab", "index": 7 }, "keys": "ctrl+shift+8" },
		{ "command": { "action": "newTab", "index": 8 }, "keys": "ctrl+shift+9" },
		// 3.3 切换到第 N 个标签页
		{ "command": { "action": "switchToTab", "index": 0 }, "keys": "ctrl+alt+1" },
		{ "command": { "action": "switchToTab", "index": 1 }, "keys": "ctrl+alt+2" },
		{ "command": { "action": "switchToTab", "index": 2 }, "keys": "ctrl+alt+3" },
		{ "command": { "action": "switchToTab", "index": 3 }, "keys": "ctrl+alt+4" },
		{ "command": { "action": "switchToTab", "index": 4 }, "keys": "ctrl+alt+5" },
		{ "command": { "action": "switchToTab", "index": 5 }, "keys": "ctrl+alt+6" },
		{ "command": { "action": "switchToTab", "index": 6 }, "keys": "ctrl+alt+7" },
		{ "command": { "action": "switchToTab", "index": 7 }, "keys": "ctrl+alt+8" },
		{ "command": { "action": "switchToTab", "index": 8 }, "keys": "ctrl+alt+9" },
		// 3.4 -> <- 标签页间切换
		{ "command": "nextTab",      "keys": "ctrl+tab"       },
		{ "command": "prevTab",      "keys": "ctrl+shift+tab" },
		{ "command": "duplicateTab", "keys": "ctrl+shift+d"   },
		// 3.5 关闭标签页
		{ "command": "closeTab", "keys": "ctrl+w"},
		// ======================== 3. 关于标签 配置 END   ========================


		// ======================== 4. 杂项热键 配置 BEGIN ========================
		// 4.1 搜索
		{ "command": "find", "keys": "ctrl+f" },
		// 4.2 打开 settings.json 
		{ "command": "openSettings", "keys": "ctrl+;" },
		// 4.3 复制、粘贴
		{ "command": { "action": "copy", "singleLine": false }, "keys": "ctrl+shift+c" },
		{ "command": { "action": "copy", "singleLine": false }, "keys": "ctrl+insert"  },
		{ "command": "paste", "keys": "ctrl+shift+v" },
		{ "command": "paste", "keys": "shift+insert" },
		// 4.4 上下滚动、上下整页滚动
		{ "command": "scrollDown",     "keys": "ctrl+shift+down" },
		{ "command": "scrollUp"  ,     "keys": "ctrl+shift+up"   },
		{ "command": "scrollDownPage", "keys": "ctrl+shift+pgdn" },
		{ "command": "scrollUpPage",   "keys": "ctrl+shift+pgup" }
		// ======================== 4. 杂项热键 配置 END   ========================


	]
	// ======================== HOTKEY 配置 END   ========================
}

```



> 该项难度系数：0

## 2. 安装字体

这里仅推荐一款字体：**Fira Code Nerd Font**。该字体支持 ligature 连字功能，而且是一款专门为代码显示准备的字体，该字体也支持很多有趣的特殊字符，非常适合在终端里使用。该字体开源，广受海内外程序员好评！

[单击此处从 GitHub 下载。](https://github.com/ryanoasis/nerd-fonts/releases/download/v2.1.0/FiraCode.zip)

装上该字体，即可进入下一步。

需要的字体如图：

![image-20211110212454724](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110212454724.png)



```cmd
如上图若不行：
解压下图全部放置文件夹-->  C:\Windows\Fonts\
```



![image-20211110212317050](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110212317050.png)

```cmd
如上图若不行：
解压后全部放置文件夹-->  C:\Windows\Fonts\
```



![image-20211110203703368](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110203703368.png)

> 该项难度系数：1

（或许有人登 Github 有网络问题，请自行解决。）

## 3. 1安装新款 Powershell Core

首先声明，我们这儿用的 Powershell 与 Windows 自带的 Powershell 是完全不同的两个东西，除了功能相似和名字相同，两者内在已经天差地别。

现阶段 Windows 10 自带的 Powershell **错误提示冗长**，**颜值低**，**速度慢**，总之就是不太值得去用了。

那么 Powershell Core 是什么呢？这是伟大的 **.Net Core 跨平台战略**的一个重要组成部分，微软设想，要让强大的 .Net 在所有平台上通用，让这么强大的 Powershell 在所有平台上都能用，古老的 bash 可以退休了！

基于以上愿景，微软开始了漫长而辉煌的征程。

在 https://github.com/PowerShell/PowerShell/releases 这个GitHub 链接里，有目前 Powershell 的最新版，我建议你从 release 里选个最新的 preview 版本。**经过测试，这些预览版都相当稳定。**

[直接单击此处下载 x86-64 Windows 64 位 .msi 安装包。](https://github.com/PowerShell/PowerShell/releases/download/v7.1.4/PowerShell-7.1.4-win-x64.msi)

> 该项难度系数：1

难度同样来自于访问 Github。



## 3.2. 添加 Powershell 启动参数

在 powershell 中输入

```powershell
notepad.exe $Profile
```

紧接着在弹出的页面中输入下面这一长串代码，保存并关闭。这个 Profile 配置文件与 .zshrc / .bashrc 文件一样，都是控制启动前参数的。

```cmd
打开PowerShell 7 （X64）
打开配置文件--> ：
notepad.exe $Profile
或者
code $Profile   
```



![image-20211110210521539](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110210521539.png)

![image-20211110210450637](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110210450637.png)



![image-20211110210741797](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110210741797.png)

## 

```powershell
<#
 * FileName: Microsoft.PowerShell_profile.ps1
 * Author: 刘 鹏
 * Email: littleNewton6@outlook.com
 * Date: 2021, Aug. 21
 * Copyright: No copyright. You can use this code for anything with no warranty.
#>


#------------------------------- Import Modules BEGIN -------------------------------
# 引入 posh-git
Import-Module posh-git

# 引入 oh-my-posh
Import-Module oh-my-posh

# 引入 ps-read-line
Import-Module PSReadLine

# 设置 PowerShell 主题
# Set-PoshPrompt ys
Set-PoshPrompt paradox
#------------------------------- Import Modules END   -------------------------------





#-------------------------------  Set Hot-keys BEGIN  -------------------------------
# 设置预测文本来源为历史记录
Set-PSReadLineOption -PredictionSource History

# 每次回溯输入历史，光标定位于输入内容末尾
Set-PSReadLineOption -HistorySearchCursorMovesToEnd

# 设置 Tab 为菜单补全和 Intellisense
Set-PSReadLineKeyHandler -Key "Tab" -Function MenuComplete

# 设置 Ctrl+d 为退出 PowerShell
Set-PSReadlineKeyHandler -Key "Ctrl+d" -Function ViExit

# 设置 Ctrl+z 为撤销
Set-PSReadLineKeyHandler -Key "Ctrl+z" -Function Undo

# 设置向上键为后向搜索历史记录
Set-PSReadLineKeyHandler -Key UpArrow -Function HistorySearchBackward

# 设置向下键为前向搜索历史纪录
Set-PSReadLineKeyHandler -Key DownArrow -Function HistorySearchForward
#-------------------------------  Set Hot-keys END    -------------------------------





#-------------------------------    Functions BEGIN   -------------------------------
# Python 直接执行
$env:PATHEXT += ";.py"

# 更新系统组件
function Update-Packages {
	# update pip
	Write-Host "Step 1: 更新 pip" -ForegroundColor Magenta -BackgroundColor Cyan
	$a = pip list --outdated
	$num_package = $a.Length - 2
	for ($i = 0; $i -lt $num_package; $i++) {
		$tmp = ($a[2 + $i].Split(" "))[0]
		pip install -U $tmp
	}

	# update TeX Live
	$CurrentYear = Get-Date -Format yyyy
	Write-Host "Step 2: 更新 TeX Live" $CurrentYear -ForegroundColor Magenta -BackgroundColor Cyan
	tlmgr update --self
	tlmgr update --all

	# update Chocolotey
	Write-Host "Step 3: 更新 Chocolatey" -ForegroundColor Magenta -BackgroundColor Cyan
	choco outdated
}
#-------------------------------    Functions END     -------------------------------





#-------------------------------   Set Alias BEGIN    -------------------------------
# 1. 编译函数 make
function MakeThings {
	nmake.exe $args -nologo
}
Set-Alias -Name make -Value MakeThings

# 2. 更新系统 os-update
Set-Alias -Name os-update -Value Update-Packages

# 3. 查看目录 ls & ll
function ListDirectory {
	(Get-ChildItem).Name
	Write-Host("")
}
Set-Alias -Name ls -Value ListDirectory
Set-Alias -Name ll -Value Get-ChildItem

# 4. 打开当前工作目录
function OpenCurrentFolder {
	param
	(
		# 输入要打开的路径
		# 用法示例：open C:\
		# 默认路径：当前工作文件夹
		$Path = '.'
	)
	Invoke-Item $Path
}
Set-Alias -Name open -Value OpenCurrentFolder
#-------------------------------    Set Alias END     -------------------------------





#-------------------------------   Set Network BEGIN    -------------------------------
# 1. 获取所有 Network Interface
function Get-AllNic {
	Get-NetAdapter | Sort-Object -Property MacAddress
}
Set-Alias -Name getnic -Value Get-AllNic

# 2. 获取 IPv4 关键路由
function Get-IPv4Routes {
	Get-NetRoute -AddressFamily IPv4 | Where-Object -FilterScript {$_.NextHop -ne '0.0.0.0'}
}
Set-Alias -Name getip -Value Get-IPv4Routes

# 3. 获取 IPv6 关键路由
function Get-IPv6Routes {
	Get-NetRoute -AddressFamily IPv6 | Where-Object -FilterScript {$_.NextHop -ne '::'}
}
Set-Alias -Name getip6 -Value Get-IPv6Routes
#-------------------------------    Set Network END     -------------------------------
```

另外，如果你喜欢我的主题，可以用 Everything.exe 搜索 paradox.omp.json 这个文件，把它替换为这个[链接](https://gist.github.com/LittleNewton/e60df543481d495af65ede37734c69e4)里的文件。



## 4. 安装 Powershell 插件

这一步是灵魂。

直接上代码：管理员打开刚装好的新版 powershell，逐行输入命令。



```powershell
# 1. 安装 PSReadline 包，该插件可以让命令行很好用，类似 zsh
Install-Module -Name PSReadLine  -Scope CurrentUser
安装失败的方法：强制安装-->如下：
Install-Module -Name PSReadLine  -Scope CurrentUser -Force

# 2. 安装 posh-git 包，让你的 git 更好用
Install-Module posh-git  -Scope CurrentUser

# 3. 安装 oh-my-posh 包，让你的命令行更酷炫、优雅
Install-Module oh-my-posh -Scope CurrentUser



#oh-my-posh 包安装失败的方法
···oh-my-posh is not recognized as a name of a cmdlet, function, script file, or executable program 

https://ohmyposh.dev/docs/installation/windows
打开 PowerShell 提示符并运行以下命令:
Set-ExecutionPolicy Bypass -Scope Process -Force; Invoke-Expression ((New-Object System.Net.WebClient).DownloadString('https://ohmyposh.dev/install.ps1'))
安装完毕为了重新加载 PATH，建议重新启动终端。

Update 更新
Set-ExecutionPolicy Bypass -Scope Process -Force; Invoke-Expression ((New-Object System.Net.WebClient).DownloadString('https://ohmyposh.dev/install.ps1'))

Default themes 默认主题

You can find the themes in the folder indicated by the environment variable POSH_THEMES_PATH. For example, you can use oh-my-posh init pwsh --config "$env:POSH_THEMES_PATH\jandedobbeleer.omp.json" for the prompt initialization in PowerShell.

你可以在文件夹中找到主题，这个文件夹的环境变量是 POSH _ THE MES _ PATH。例如，您可以使用 oh-my-POSH init pwsh —— config“ $env: POSH _ THMES _ PATH jandedobbeleer.omp.json”在 PowerShell 中进行提示初始化。




```

安装过程可能有点慢，**好像卡住了一样**，但是请耐心等待几分钟。等不及的同学自行搜索科学方法访问 GitHub.

**win键盘 --> pwsh--> 如图**

![image-20211110211552201](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110211552201.png)

安装时系统会提问是否继续，不用管它直接输入 `A` 并回车即可。

![image-20211110211431062](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110211431062.png)

> 该项难度系数：0



## 5. 配置 Windows Terminal

这一项是灵魂。

只有新款 Powershell 而没有 Windows Terminal，好比吃肉不放盐。

简单点，直接上配置代码，遇到不懂的地方，自己读注释。记得将此设置默认配置（代码已经给出）。

```json
// 默认的配置就是我们的新 powershell（重要！！！）
"defaultProfile": "{574e775e-4f2a-5b96-ac1e-a2962a402336}",

{
    // 键标记
    "guid": "{574e775e-4f2a-5b96-ac1e-a2962a402336}",
    "name": "PowerShell Core 7.1.0.5",
    "source": "Windows.Terminal.PowershellCore",
    // 行为
    "closeOnExit": true,
    "commandline": "C:/Program Files/PowerShell/7-preview/pwsh.exe -nologo",
    "hidden": false,
    "historySize": 9001,
    "snapOnInput": true,
    "startingDirectory": ".",
    // 外观
    "icon": "D:/Users/newton/Documents/Softwares/software_windows/develop/shell/pwsh.ico",
    "acrylicOpacity": 0.5,
    "cursorColor": "#FFFFFF",
    "cursorShape": "bar",
    "fontFace": "Fira Code",
    "fontSize": 11,
    "padding": "5, 5, 20, 25",
    "useAcrylic": false,
    // 颜色主题
    "colorScheme": "Homebrew"
},
```

同时附上 Homebrew 配色，该配色经过我改良。

```json
{
    "name": "Homebrew",
    "black": "#000000",
    "red": "#FC5275",
    "green": "#00a600",
    "yellow": "#999900",
    "blue": "#6666e9",
    "purple": "#b200b2",
    "cyan": "#00a6b2",
    "white": "#bfbfbf",
    "brightBlack": "#666666",
    "brightRed": "#e50000",
    "brightGreen": "#00d900",
    "brightYellow": "#e5e500",
    "brightBlue": "#0000ff",
    "brightPurple": "#e500e5",
    "brightCyan": "#00e5e5",
    "brightWhite": "#e5e5e5",
    "background": "#283033",
    "foreground": "#00ff00"
},
```

特别注意，用其他配色可能**降低颜值**。

> Note: 由于 Windows Terminal 的配置**非常复杂，整个文件很长**，可直接参考这个[链接](https://gist.github.com/LittleNewton/b37d5182292c314df55decde56711075)。
>
> 该项难度系数：0

需要懂点 json，还**需要会配置 Windows Terminal**。





```
/* 
 * Author: 刘鹏
 * Email: littleNewton6@gmail.com
 * Date: 2020, Nov. 30
 * <Alt> + Settings，打开默认设置
 * 参考文档：https://aka.ms/terminal-documentation
 * DESCRIPTION: 配置 Windows Terminal 的选项文件
 * TAB_SIZE = 8
 *字体空格，已经修改
 *显示cmd，方便cmd的管理员操作--> 该p7终端会多线程并发执行 命令&命令
 */

 {
	"$schema": "https://aka.ms/terminal-profiles-schema",
	"defaultProfile": "{574e775e-4f2a-5b96-ac1e-a2962a402336}",

	// 全局主题
	"theme": "system",
	"alwaysShowTabs": true,
	"tabWidthMode": "equal",
	"confirmCloseAllTabs": false,

	// 位置
	// (1) 1920x1080 - (320, 65)
	// (2) 5120x2880 - (1275,692)
	"initialPosition": "135,140",
	"initialCols": 135,
	"initialRows": 45,

	// 禁止自动生成
	"disabledProfileSources": [
		"Windows.Terminal.Azure"
	],





	// ======================== PROFILES 配置 BEGIN ========================
	"profiles": [


		// ======================== PWSH7 配置 BEGIN ========================
		{
			// 键标记
			"guid":			"{574e775e-4f2a-5b96-ac1e-a2962a402336}",
			"name":			"PowerShell Core 7.1.0",
			"source":		"Windows.Terminal.PowershellCore",
			// 行为
			"closeOnExit":		true,
			"commandline":		"C:/Program Files/PowerShell/7/pwsh.exe -nologo",
			"hidden":		false,
			"historySize":		9001,
			"snapOnInput":		true,
			"startingDirectory": ".",
			// 外观
			"icon":			"D:/Users/newton/Software/develop/shell/pwsh-7.1.ico",
			"acrylicOpacity":	0.5,
			"cursorColor":		"#FFFFFF",
			"cursorShape":		"bar",
			"fontFace":		"FiraCode NF",
			"fontSize":		11,
			"padding":		"5, 5, 20, 25",
			"useAcrylic":		false,
			// 颜色主题
			"colorScheme":		"Homebrew"
		},
		// ======================== PWSH7 配置 END   ========================


		// ======================== WSL 配置 BEGIN ========================
		{
			// 键标记
			"guid":			"{07b52e3e-de2c-5db4-bd2d-ba144ed6c273}",
			"name":			"Ubuntu-20.04",
			"source":		"Windows.Terminal.Wsl",
			// 行为
			"closeOnExit":		true,
			"commandline":		"wsl.exe -d Ubuntu-20.04",
			"hidden":		false,
			"historySize":		9001,
			"snapOnInput":		true,
			"startingDirectory":	".",
			// 外观
			"acrylicOpacity":	0.5,
			"cursorColor":		"#FFFFFF",
			"cursorShape":		"bar",
			"fontFace":		"FiraCode NF",
			"fontSize":		11,
			"padding":		"5, 5, 20, 25",
			"useAcrylic":		false,
			// 颜色主题
			"colorScheme":		"Homebrew"
		},
		// ======================== WSL 配置 END   ========================


		// ======================== PWSH5 配置 BEGIN ========================
		{
			// 键标记
			"guid":			"{61c54bbd-c2c6-5271-96e7-009a87ff44bf}",
			"name":			"Windows PowerShell",
			// 行为
			"closeOnExit":		true,
			"commandline":		"powershell.exe",
			"hidden": true,
			"historySize":		9001,
			"snapOnInput":		true,
			"startingDirectory":	".",
			// 外观
			"acrylicOpacity":	0.5,
			"cursorColor":		"#FFFFFF",
			"cursorShape":		"bar",
			"fontFace":		"FiraCode NF",
			"fontSize":		11,
			"padding":		"5, 5, 20, 25",
			"useAcrylic":		false,
			// 颜色主题
			"colorScheme":		"Homebrew"
		},
		// ======================== PWSH5 配置 END   ========================


		// ======================== CMD 配置 BEGIN ========================
		{
			// 键标记
			"guid":		"{0caa0dad-35be-5f56-a8ff-afceeeaa6101}",
			"name":		"cmd",
			// 行为
			"commandline":	"cmd.exe",
			//不隐藏CMD
			"hidden":	false,
			// 字体
			"fontFace":	"FiraCode NF",
			"fontSize":	11
		},
		// ======================== CMD 配置 END   ========================


		// ======================== AZURE 配置 BEGIN ========================
		{
			"guid":		"{b453ae62-4e3d-5e58-b989-0a998ec441b8}",
			"name":		"Azure Cloud Shell",
			"hidden":	true,
			"source":	"Windows.Terminal.Azure"
		}
		// ======================== AZURE 配置 END   ========================


	],
	// ======================== PROFILES 配置 END   ========================





	// ======================== COLOR SCHEME 配置 BEGIN ========================
	"schemes": [
		{
			"name":		"Homebrew",
			"black":	"#000000",
			"red":		"#FC5275",
			"green":	"#00a600",
			"yellow":	"#ffff00",
			"blue":		"#6666e9",
			"purple":	"#ff00ff",
			"cyan":		"#00a6b2",
			"white":	"#bfbfbf",
			"brightBlack":	"#666666",
			"brightRed":	"#ff6060",
			"brightGreen":	"#00d900",
			"brightYellow":	"#fdff73",
			"brightBlue":	"#00a2ff",
			"brightPurple":	"#ff08ff",
			"brightCyan":	"#53ffff",
			"brightWhite":	"#e5e5e5",
			"background":	"#283033",
			"foreground":	"#00ff00"
		}
	],
	// ======================== COLOR SCHEME 配置 END   ========================





	// ======================== HOTKEY 配置 BEGIN ========================
	"keybindings": [


		// ======================== 1. 界面视图 配置 BEGIN ========================
		// 1.1 调节字体大小
		{ "command": { "action": "adjustFontSize", "delta":  1 }, "keys": "ctrl+=" },
		{ "command": { "action": "adjustFontSize", "delta": -1 }, "keys": "ctrl+-" },
		{ "command":             "resetFontSize",                 "keys": "ctrl+0" },
		// ======================== 1. 界面视图 配置 END   ========================


		// ======================== 2. PANE 分割 配置 BEGIN ========================
		// 2.1 水平、竖直分割
		{ "command": { "action": "splitPane", "split": "horizontal" }, "keys": "alt+shift+-"    },
		{ "command": { "action": "splitPane", "split": "vertical"   }, "keys": "alt+shift+plus" },
		{ "command": { "action": "splitPane", "split": "auto"       }, "keys": "alt+shift+|"    },
		{ "command": { "action": "splitPane", "split": "auto", "splitMode": "duplicate" }, "keys": "alt+shift+d" },
		{ "command": { "action": "splitPane", "split": "horizontal", "profile": "Ubuntu-20.04" }, "keys": "alt+shift+u" },
		// 2.2 按下 Alt 键，同时按下方向键，在多个 pane 之间切换
		{ "command": { "action": "moveFocus",  "direction": "down"  }, "keys": "alt+down"  },
		{ "command": { "action": "moveFocus",  "direction": "left"  }, "keys": "alt+left"  },
		{ "command": { "action": "moveFocus",  "direction": "right" }, "keys": "alt+right" },
		{ "command": { "action": "moveFocus",  "direction": "up"    }, "keys": "alt+up"    },
		// 2.3 按下 Alt + Shift，同时按下方向键，调整当前 pane 的大小
		{ "command": { "action": "resizePane", "direction": "down"  }, "keys": "alt+shift+down"  },
		{ "command": { "action": "resizePane", "direction": "left"  }, "keys": "alt+shift+left"  },
		{ "command": { "action": "resizePane", "direction": "right" }, "keys": "alt+shift+right" },
		{ "command": { "action": "resizePane", "direction": "up"    }, "keys": "alt+shift+up"    },
		// 2.4 关闭 pane
		{ "command": "closePane", "keys": "alt+shift+w" },
		// ======================== 2. PANE 分割 配置 BEGIN ========================


		// ======================== 3. 关于标签 配置 BEGIN ========================
		// 3.1 新建默认标签页
		{ "command": "newTab", "keys": ["ctrl+n"]},
		// 3.2 新建 N 号 profile 的标签
		{ "command": { "action": "newTab", "index": 0 }, "keys": "ctrl+shift+1" },
		{ "command": { "action": "newTab", "index": 1 }, "keys": "ctrl+shift+2" },
		{ "command": { "action": "newTab", "index": 2 }, "keys": "ctrl+shift+3" },
		{ "command": { "action": "newTab", "index": 3 }, "keys": "ctrl+shift+4" },
		{ "command": { "action": "newTab", "index": 4 }, "keys": "ctrl+shift+5" },
		{ "command": { "action": "newTab", "index": 5 }, "keys": "ctrl+shift+6" },
		{ "command": { "action": "newTab", "index": 6 }, "keys": "ctrl+shift+7" },
		{ "command": { "action": "newTab", "index": 7 }, "keys": "ctrl+shift+8" },
		{ "command": { "action": "newTab", "index": 8 }, "keys": "ctrl+shift+9" },
		// 3.3 切换到第 N 个标签页
		{ "command": { "action": "switchToTab", "index": 0 }, "keys": "ctrl+alt+1" },
		{ "command": { "action": "switchToTab", "index": 1 }, "keys": "ctrl+alt+2" },
		{ "command": { "action": "switchToTab", "index": 2 }, "keys": "ctrl+alt+3" },
		{ "command": { "action": "switchToTab", "index": 3 }, "keys": "ctrl+alt+4" },
		{ "command": { "action": "switchToTab", "index": 4 }, "keys": "ctrl+alt+5" },
		{ "command": { "action": "switchToTab", "index": 5 }, "keys": "ctrl+alt+6" },
		{ "command": { "action": "switchToTab", "index": 6 }, "keys": "ctrl+alt+7" },
		{ "command": { "action": "switchToTab", "index": 7 }, "keys": "ctrl+alt+8" },
		{ "command": { "action": "switchToTab", "index": 8 }, "keys": "ctrl+alt+9" },
		// 3.4 -> <- 标签页间切换
		{ "command": "nextTab",      "keys": "ctrl+tab"       },
		{ "command": "prevTab",      "keys": "ctrl+shift+tab" },
		{ "command": "duplicateTab", "keys": "ctrl+shift+d"   },
		// 3.5 关闭标签页
		{ "command": "closeTab", "keys": "ctrl+w"},
		// ======================== 3. 关于标签 配置 END   ========================


		// ======================== 4. 杂项热键 配置 BEGIN ========================
		// 4.1 搜索
		{ "command": "find", "keys": "ctrl+f" },
		// 4.2 打开 settings.json 
		{ "command": "openSettings", "keys": "ctrl+;" },
		// 4.3 复制、粘贴
		{ "command": { "action": "copy", "singleLine": false }, "keys": "ctrl+shift+c" },
		{ "command": { "action": "copy", "singleLine": false }, "keys": "ctrl+insert"  },
		{ "command": "paste", "keys": "ctrl+shift+v" },
		{ "command": "paste", "keys": "shift+insert" },
		// 4.4 上下滚动、上下整页滚动
		{ "command": "scrollDown",     "keys": "ctrl+shift+down" },
		{ "command": "scrollUp"  ,     "keys": "ctrl+shift+up"   },
		{ "command": "scrollDownPage", "keys": "ctrl+shift+pgdn" },
		{ "command": "scrollUpPage",   "keys": "ctrl+shift+pgup" }
		// ======================== 4. 杂项热键 配置 END   ========================


	]
	// ======================== HOTKEY 配置 END   ========================
}

```



## 6. 添加右键菜单

这一步是**灵魂中的灵魂**。

> **这里涉及修改注册表，小白请勿手残改坏注册表，强烈建议事前建立系统还原点！**

Github 上面已经有 powershell 脚本了，可以用管理员身份运行该脚本 + 某些参数以实现配置右键菜单。

[原版 Github 仓库](https://github.com/lextm/windowsterminal-shell/)

[我修改后的脚本仓库](https://github.com/LittleNewton/windows_terminal_here) （建议用这个）

建议下载我这个，然后在管理员模式的 powershell 7 里运行：

```text
.\install.ps1 mini
```

记住一定要以**管理员身份**在 powershell 7 里面运行该脚本。



![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='0' height='0'></svg>)图 3： 用我修改后的脚本安装之后的效果如图



**目前发现问题**：该脚本会读取 Windows Terminal 的 profile，然后把其中的非隐藏项目添加到右键菜单（默认视图），这之后如果你修改了 profile，那么需要用 `uninstall.ps1` 脚本先清除右键菜单，然后重新 install 一遍。



------

# 后续字体需要修改哦

字体修改如下



![image-20220826233814773](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url/img202208262338028.png)

![PowerShell、CMD 和 Windows Terminal 的美化配置方法](https://pic1.zhimg.com/v2-693e52e1f96b18c645a8bd5019b75413_1440w.jpg?source=172ae18b)

### PowerShell、CMD 和 Windows Terminal 的美化配置方法

[![孤单魂随风荡](https://pic2.zhimg.com/v2-dace501ea3554d1b188350e00eda0bdf_xs.jpg?source=172ae18b)

## 1. 安装字体

（附件中有所需要的字体文件）

推荐使用 FiraCode NF 和更纱黑体。

FiraCode NF 下载地址：

[Github - FiraCode NFgithub.com/ryanoasis/nerd-fonts/releases](https://github.com/ryanoasis/nerd-fonts/releases)

![img](https://pic4.zhimg.com/80/v2-f2ddf8bcc5de57ea20dfdaa161a9737f_720w.jpg)下载 FiraCode NF Retina 字体

将.zip 文件下载到本地，然后打开该压缩文件，将“Fira Code Regular Nerd Font Complete Mono Windows Compatible.otf”文件解压到本地并重命名为“FiraCode NF.OTF”，右击后选择“为所有用户安装”。

更纱黑体下载地址：

[Github - 更纱黑体github.com/be5invis/Sarasa-Gothic/releases![img](https://pic1.zhimg.com/v2-931b0bcdb51a4508229f7717b8b804d4_ipico.jpg)](https://github.com/be5invis/Sarasa-Gothic/releases)

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-336c5a7cff7b6cd5a202b32133c27c6f_720w.jpg)下载更纱黑体

将 .7z 文件下载到本地，然后打开该压缩文件，将“sarasa-mono-sc-regular.ttf”文件解压到本地并重命名为“Sarasa Mono SC.TTF”，右击后选择“为所有用户安装”。

## 2. 设置默认字体

设置默认字体是设置的 PowerShell 和 CMD 的默认字体。

### 2.1 设置 CMD 的默认字体

（附件中有注册表.reg 文件，可以直接导入）

按快捷键 Win+R 打开“运行”窗口，输入“regedit”后回车打开“注册表编辑器”，然后进入目录[HKEY_CURRENT_USER\Console\%SystemRoot%_system32_cmd.exe]，在右侧空白处鼠标右击-->新建-->字符串值，并重命名为“FaceName”，双击打开后输入“Sarasa Mono SC”并“确定”。

![img](https://pic2.zhimg.com/80/v2-15ef8c2d90ead64031354233e13686a5_720w.jpg)设置 CMD 的默认字体

### 2.2 设置 PowerShell 的默认字体（System32）

进入目录[HKEY_CURRENT_USER\Console\%SystemRoot%_System32_WindowsPowerShell_v1.0_powershell.exe]，在右侧空白处鼠标右击-->新建-->字符串值，并重命名为“FaceName”，双击打开后输入“Sarasa Mono SC”并“确定”。

![img](https://pic1.zhimg.com/80/v2-63dd66b39ccf8b1106be10d942387db8_720w.jpg)设置 PowerShell 的默认字体

### 2.3 设置 PowerShell 的默认字体（SysWOW64）

进入目录[HKEY_CURRENT_USER\Console\%SystemRoot%_SysWOW64_WindowsPowerShell_v1.0_powershell.exe]，在右侧空白处鼠标右击-->新建-->字符串值，并重命名为“FaceName”，双击打开后输入“Sarasa Mono SC”并“确定”。

![img](https://pic3.zhimg.com/80/v2-b33cdd7bcb90a8da534927b201c2ede2_720w.jpg)设置 PowerShell 的默认字体

## 3. 注册字体

注册字体的作用当 PowerShell 设置 Sarasa Mono SC 字体后支持显示 Emoji。

进入目录[HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\FontLink\SystemLink]，在右侧空白处鼠标右击-->新建-->字符串值，并重命名为“Sarasa Mono SC”，双击打开后输入如下值（最后一行需要留一个空段落）：

BSSYM7.ttf,Bookshelf Symbol 7

HOLOMDL2.ttf,HoloLens MDL2 Assets

MARLETT.ttf,Marlett

REFSPCL.ttf,MS Reference Specialty

MTEXTRA.ttf,MT Extra

SEGMDL2.ttf,Segoe MDL2 Assets

SEGUIEMJ.ttf,Segoe UI Emoji

SEGUIHIS.ttf,Segoe UI Historic

SEGUISYM.ttf,Segoe UI Symbol

SYMBOL.ttf,Symbol

WEBDINGS.ttf,Webdings

WINGDING.ttf,Wingdings

WINGDNG2.ttf,Wingdings 2

WINGDNG3.ttf,Wingdings 3

[请删掉此行文字保留空段落]

并“确定”。

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='720' height='536'></svg>)注册字体

重启电脑。

## 4. 设置 PowerShell

按快捷键 Win+R 打开“运行”窗口，输入“PowerShell”后回车打开“Windows PowerShell”，在标题栏右击，选择“属性”。

### 4.1 字体

切换到“字体”，找到“等距更纱黑体 SC”并选中，然后“大小”设置成“20”。

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='720' height='562'></svg>)设置 PowerShell 字体

### 4.2 颜色

（附件中有完整的设置截图，可以对照截图来挨个设置各个颜色块的颜色值）

切换到“颜色”。

**4.2.1 屏幕文字**

选中“屏幕文字”，然后点击下方选中的颜色块，再在“选定的颜色值”的“红(R) 蓝(H) 绿(L)”中依次输入“147，161，161”，“不透明度”选择“90”。

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='579' height='737'></svg>)设置 PowerShell 颜色-屏幕文字

**4.2.2 屏幕背景**

选中“屏幕背景”，然后点击下方选中的颜色块，再在“选定的颜色值”的“红(R) 蓝(H) 绿(L)”中依次输入“253，246，227”。

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='579' height='737'></svg>)设置 PowerShell 颜色-屏幕背景

注：为了能在后面的操作中看清 PowerShell 命令，请单独设置一下这个颜色块的颜色值，设置后“屏幕背景”仍然选择第一个颜色块。

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='579' height='737'></svg>)单独设置此颜色块

### 4.3 终端

切换到“终端”，“光标形状”选中“竖条”。

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='579' height='737'></svg>)设置 PowerShell 终端

点击“确定”，然后关闭 PowerShell 再重新打开，设置生效。

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='996' height='667'></svg>)PowerShell 设置生效

## 5. 设置 CMD

方法跟上方大致相同，不再赘述。

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='1007' height='789'></svg>)CMD 设置生效

## 6. 安装 Windows Terminal

看到这里您可能会感觉到，怎么美化了 PowerShell 还是达不到心理的预期值（还是丑），这里向大家推荐使用微软官方出品的 Windows 终端工具——Windows Terminal。

下载地址：[Windows Terminal](https://www.microsoft.com/zh-cn/p/windows-terminal/9n0dx20hk701)（会调用本地的 Windows 10 应用商店进行安装）

喜欢尝鲜可以安装预览版（已支持图形化设置界面），下载地址：

### 6.1 配置 Windows Terminal

**6.1.1 安装 Git**

（附件中有 Git 的安装包）

下载地址：

安装步骤没有什么特殊的，基本默认然后点下一步就可以了，实在不放心可以看这个教程：

**6.1.2 配置 Git 环境变量**

依次进入开始菜单-->控制面板-->系统-->高级系统设置-->高级-->环境变量，在“系统变量”中找到“Path”并双击打开，点击“新建”，输入你的 Git 安装目录，比如我的是“C:\Program Files\Git”，回车，一直点击“确定”。

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='677' height='664'></svg>)配置 Git 环境变量

**6.1.3 配置 Git 的用户名和邮箱**

打开 Git Bash，依次执行以下命令进行用户名和邮箱的配置（注意有无引号）：

```powershell
git config --global user.name "你的用户名"
git config --global user.email 你的邮箱
```

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='825' height='545'></svg>)配置 Git 的用户名和邮箱

配置完成后可以执行以下命令进行查看：

```powershell
git config --list
```

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='825' height='545'></svg>)查看 Git 配置的用户名和邮箱

如果你不嫌烦的话呢，也可以对 Git Bash 的界面进行美化设置，而且可以设置成中文，右击标题栏，选择“Options”，切换到“Window”，在“UI Language”里选择“zn_CH”，这里不再赘述。

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='450' height='435'></svg>)设置 Git Bash 界面语言

**6.1.4 修改执行策略权限**

按快捷键 Win+X+A，以管理员身份运行“Windows PowerShell”，先查看执行策略权限状态，执行以下命令：

```text
Get-ExecutionPolicy -List
```

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='1473' height='789'></svg>)查看执行策略权限状态

可以看到“CurrentUser”和“LocalMachine”的执行策略权限无法运行未签名的脚本。

① 修改 CurrentUser 的执行策略权限，执行以下命令：

```text
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
```

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='1473' height='789'></svg>)修改 CurrentUser 的执行策略权限

输入“A”，回车。

② 修改 LocalMachine 的执行策略权限，执行以下命令：

```text
Set-ExecutionPolicy RemoteSigned
```

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='1473' height='789'></svg>)修改 LocalMachine 的执行策略权限

输入“A”，回车。

再次查看执行策略权限状态，执行以下命令：

```text
Get-ExecutionPolicy -List
```

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='1473' height='789'></svg>)查看执行策略权限状态

现在 PowerShell 可以运行未签名的脚本了。

**6.1.5 安装 oh-my-posh**

① 安装 posh-git，执行以下命令：

```powershell
Install-Module posh-git
```

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='1473' height='789'></svg>)安装 oh-my-posh

输入“Y”，回车。

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='1473' height='789'></svg>)安装 oh-my-posh

输入“A”，回车。

② 安装 oh-my-posh，执行以下命令：

```powershell
Install-Module oh-my-posh
```

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='1473' height='789'></svg>)

输入“A”，回车。

**6.1.6 导入 oh-my-posh**

依次执行以下命令：

```powershell
Import-Module posh-git
Import-Module oh-my-posh
Set-PoshPrompt -Theme PowerLine
```

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='1473' height='789'></svg>)

**6.1.7 新建配置文件**

（附件中有已经编辑好了的 Microsoft.PowerShell_profile.ps1 文件）

打开文件资源管理器，进入文件夹 C:\Users\[你的用户名]\Documents\WindowsPowerShell，没有“WindowsPowerShell”文件夹就新建一个，然后在此文件夹内新建文本文档，编辑以下内容：

```powershell
Import-Module posh-git
Import-Module oh-my-posh
Set-PoshPrompt -Theme PowerLine
```

另存为“Microsoft.PowerShell_profile.ps1”文件。

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='977' height='384'></svg>)主题加载配置文件

**6.1.8 美化配置**

（附件中有已经配置好了的 settings.json 文件，直接覆盖源文件即可。背景图片和图标也在其内，配置时请注意文件所在路径）

打开文件资源管理器，进入文件夹 C:\Users\[你的用户名]\AppData\Local\Packages\Microsoft.WindowsTerminal_8wekyb3d8bbwe\LocalState（预览版的配置文件所在目录 C:\Users\[你的用户名]\AppData\Local\Packages\Microsoft.WindowsTerminalPreview_8wekyb3d8bbwe\LocalState），然后右击“settings.json”文件，“打开方式”选择“记事本”，以下摘选的是会影响外观的配置项（请根据自己需要进行增删改）。

```json
"defaults": //默认配置
    {
        // Put settings here that you want to apply to all profiles.
        "colorScheme" : "Ubuntu", // 主题
        "useAcrylic" : true, // 毛玻璃特效
        "acrylicOpacity": 0.5, // 不透明度
        "cursorColor" : "#E6FF00", // 光标颜色
        "cursorShape" : "bar", // 光标类型
        "fontFace" : "FiraCode NF Retina", // 字体名称
        "fontSize" : 12, // 字体大小
        "icon" : "C:\\Users\\Pictures\\Java.png", // 图标
        "backgroundImage": "C:\\Users\\Pictures\\colorful.jpg", // 背景图片
        "backgroundImageOpacity": 0.25, // 背景图片的不透明度
        "tabTitle" : "开始学习啦", //标签名称
        "startingDirectory" : "C:\\Users\\JavaLearning", // 起始文件夹路径
        "closeOnExit" : true, // 输入exit退出命令窗口
        "padding" : "10, 10, 10, 10", // 内容距离界面的内部距离
        "snapOnInput" : true, // 嗅探输入
        "historySize" : 8001 // 历史大小
    },

"schemes": [ // 主题（此处设置的主题是“Ubuntu”）
    {
        "name": "Ubuntu",
        "black": "#2e3436",
        "red": "#cc0000",
        "green": "#4e9a06",
        "yellow": "#c4a000",
        "blue": "#3465a4",
        "purple": "#75507b",
        "cyan": "#06989a",
        "white": "#d3d7cf",
        "brightBlack": "#555753",
        "brightRed": "#ef2929",
        "brightGreen": "#8ae234",
        "brightYellow": "#fce94f",
        "brightBlue": "#729fcf",
        "brightPurple": "#ad7fa8",
        "brightCyan": "#34e2e2",
        "brightWhite": "#eeeeec",
        "background": "#300a24",
        "foreground": "#eeeeec"
    }
],
```

想预览其它主题，请访问：

想下载其它主题，请访问：[主题下载](https://github.com/mbadolato/iTerm2-Color-Schemes/tree/master/windowsterminal)（请不要直接覆盖 settings.json 文件，请编辑俩 .json 将内容复制到 settings.json 内的指定位置即可）

### 6.2 查看效果

附上效果图：

![img](data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='1483' height='787'></svg>)

## 7. 附件下载

链接：https://dustinwinvip.lanzoui.com/b01oqqcej

密码：mhzd

编辑于 10-29
