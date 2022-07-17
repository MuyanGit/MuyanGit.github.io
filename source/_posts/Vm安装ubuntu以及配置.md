title: Vm安装ubuntu以及配置
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2022-07-15 17:28:06
authorAbout:
series:
tags:
keywords:
description:

photos:  https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wps30.jpg

------





*![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/favicon.ico)*

#### 知乎

[![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-d69e2d1e919828e50afa2b10327dc05a.png)下载  APP](https://www.zhihu.com/app/?auto_download=true&utm_source=sogou&utm_campaign=guest_feed&utm_content=guide&app_from=&itc_ct=)

VMware虚拟机安装Ubuntu详解

![长信](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-abed1a8c04700ba7d72b45195223e0ff_l.jpg)

长信

人生到处知何似，应似飞鸿踏雪泥。

**写在前面：** **如果你已经了解了VMware安装Ubuntu的原理但是想省却繁杂的安装过程，或者你没用过虚拟机但现在急需使用Linux虚拟机，请直接跳到第8点”快速使用Ununtu“。我已经封装好了ubuntu16.04-64，并且配置了嵌入式开发环境，你可以直接用来进行嵌入式开发练习。你可以直接打开使用，使用过程详见第8点。** **已经安装好虚拟机但无法全屏显示，请参考第7点后半部分的解决方案。** **已经安装好虚拟机但想实现和实体机的资源共享，请参考第9点。** **已经安装好虚拟机但无法联网，请参考第10点。** **如有其他问题，欢迎留言。** **1、虚拟机简介** 虚拟机（Virtual  Machine）指通过软件模拟的具有完整硬件系统功能的、运行在一个完全隔离环境中的完整计算机系统。在实体计算机中能够完成的工作在虚拟机中都能够实现。 虚拟机本质上是一种软件，它的功能是模拟一台裸机的所有硬件，我们可以在虚拟机模拟出的裸机基础上安装我们想要的任何操作系统。 根据字面意思理解，虚拟机即虚拟化的计算机，而它实现虚拟化的手段是软件模拟。在本电脑中创建虚拟机时，需要将本电脑的部分硬盘和内存容量作为虚拟机的硬盘和内存容量。 **2、VMware** VMware是虚拟机的一种，也是目前主流使用的，它的功能相较VirtualBox  更全面，安装和使用倒是相差不大。 **3、VMware下载与安装** 搜索VMware workstation找到官网下载最新版VMware，目前最新版是VMware  Workstation 16 pro。[Download VMware Workstation  Pro](https://www.vmware.com/products/workstation-pro/workstation-pro-evaluation.html) 双击下载下载好的安装包VMware-workstation-full-16.2.2-19200509  ，得到下列界面，点击下一步![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-da2800d491fac4a4642b12fcfb37c6e0_r.jpg) 勾上同意协议，点击下一步![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-66842acfd0dfde52b2af8ab87f7cc0df_r.jpg) **记住安装位置**，最好自己手动修改到常用位置，然后点下一步。![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-9b81dd7d42204efc8faa1381e9fb92c2_r.jpg) 然后一直下一步，直到安装界面![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-94360bb0fbe0eca2a9dee16f8a47cd84_r.jpg)![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-5dd400af6c1dd2c160dc52dbc41936db_r.jpg)安装界面 点击完成后，会出现如下界面，实际上我们可以通过百度搜索得到这个密钥，注意版本即可。 以下密钥亲测可用，也可自行在网络上搜索。
*ZF3R0-FHED2-M80TY-8QYGC-NPKYF*
*YF390-0HF8P-M81RQ-2DXQE-M2UT6*
*ZF71R-DMX85-08DQY-8YMNC-PPHV8*
*FA1M0-89YE3-081TQ-AFNX9-NKUC0*![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-9d177c400254ab97fc8e11eb54c05c59_r.jpg) 输入密钥后，出现如下界面，点击完成。![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-ea9dac850cab25e7eba4387aef37e559_r.jpg) VMware的安装就完成了，软件界面如下![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-abd8d774d1408ae50162b1cf547199c3_r.jpg) **4、创建虚拟机系统** 打开刚安装好的VMware，里面是没有任何可供使用的虚拟机的，需要我们自己根据需要创建。即首先我们创建一个裸机，然后再在这模拟的裸机上安装操作系统，这篇文章我们安装的操作系统是Linux系统的一种——ubuntu。 选择创建新的虚拟机，新手我们直接默认下一步。![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-ef2d77e445ea19736990f8505d169828_r.jpg) 此时我们还没有镜像文件（会在稍后介绍），选择"稍后安装操作系统"，然后点击下一步![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-1f9c3655da7e7a485be8a99e9b71600f_r.jpg) 由于我们要创建的是Linux的虚拟机，所以这里选择”Linux“，然后点击下一步![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-c449646326e2ffbde4ba5e54bd8c9708_r.jpg) 给虚拟机命名（一般默认为Ubuntu）,同时选择存放虚拟机的位置，C盘、D盘均可，有SSD可以选择放在SSD上，但需要注意的是要保证该盘至少有20GB的空间。然后点击下一步![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-29f629ea2ff740675be01544c7d5c310_r.jpg) 然后默认点击下一步。![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-0124b82b49bb458b82a635966f30473a_r.jpg) 点击完成，我们就已经创建好了一个还没有安装操作系统的裸机。![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-d13423745b45c0c273e96cbdaec0a2c1_r.jpg) 然后我们需要给这个裸机安装ubuntu操作系统，在此之前需要下载ubuntu的镜像文件。详见以下内容。 **5、ubuntu简介** Ubuntu是一个以桌面应用为主的Linux操作系统，其名称来自非洲南部祖鲁语或豪萨语的“ubuntu"一词，意思是“人性”“我的存在是因为大家的存在"，是非洲传统的一种价值观。Ubuntu基于Debian发行版和Gnome桌面环境，而从11.04版起，Ubuntu发行版放弃了Gnome桌面环境，改为Unity。从前人们认为Linux难以安装、难以使用，在Ubuntu出现后这些都成为了历史。Ubuntu也拥有庞大的社区力量，用户可以方便地从社区获得帮助。[1]自Ubuntu  18.04 LTS起，Ubuntu发行版又重新开始使用GNOME3桌面环境。 现在我们提到Linux系统，个人一般使用的都是ubuntu。它是全球最流行且最有影响力的Linux开源系统之一。 **6、ubuntu镜像下载（安装ubuntu虚拟机前必要的一步）** 安装虚拟机跟我们给电脑重装系统是一样的，都需要去官网上下载对应系统的镜像文件（文件后缀名为.iso）。镜像文件其实是一个具有光盘属性的压缩包之类的文件，其中有一些文件使得计算机裸机能识别它并能启动其中的操作系统文件，从而可以把这个镜像文件保存到硬盘或者U盘中，从而可以使用这个文件来安装系统。 搜索ubuntu进入官网，下载最新版本，目前最新版本为Ubuntu 20.04.4 LTS。[Download Ubuntu Desktop | Download | Ubuntu](https://ubuntu.com/download/desktop) 进入以下界面，点击下载即可![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-48ead69fcc1d8cc9ca409a8dac5a29f2_r.jpg) **7、给”裸机“安装ubuntu** 打开VMvare，在”我的计算机“里点击”Ubuntu“![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-9069653d82273c37f35394573cde8c35_r.jpg) 然后点击”编辑虚拟机设置“![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-fbd30d1eb0da45f754af136f9f2f2dc2_r.jpg) 然后点击”CD/DVD(SATA)“，选择”使用ISO映像文件“![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-372450e1c0c3db3e917b23c37f0be289_r.jpg) 这里有个关键点，你首先得把ISO文件放到之前创建虚拟机的同一路径下，这样方便你以后移动虚拟机，甚至你可以直接把这个虚拟机拿到其他电脑上使用，而省去繁琐的安装过程。如我的虚拟机路径为：![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-87888548163e5db808801588d0128d2f_r.jpg) 把镜像文件剪切到这个路径里，![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-f12fd36b9ee63f913d025c892c5bab08_r.jpg) 然后点击”浏览“，会直接搜索到你电脑里符合条件的文件，选择ubuntu-20.04.4-desktop-amd64，然后点击确定。![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-af1fd0a009ae1159116950f362912239_r.jpg) 然后选择”开启此虚拟机“![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-71c96d4565aae743f9201792f610ed2b_r.jpg) 等待加载完成。然后会让你选择语言，对英语自信的可选择English，英语一般就选简体中文，在下拉框的最低部。然后点击”安装Ubuntu“![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-401b5c97a8a962f75a69a91daed3fa57_r.jpg) 选择键盘布局，选择chinese和”Chinese-Hanyu Pinyin“![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-40b80164f869317428f31135a4fb96a2_r.jpg) 点击”继续“（这里有时会出现看不到下方按钮的情况，叉掉，等进入系统后再安装就可以了）![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-1b58d9d80bcd8eff08327825d321e4be_r.jpg) 选择”正常安装即可“，不要勾选安装时下载软件，有些软件涉及到版权，需要翻墙才能下载，不翻墙就会下载极慢。点击继续![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-c128f1718bbfd32cd24fb920a96de80c_r.jpg) 选择”清除整个磁盘并安装Ubuntu“，点击”现在安装“![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-7951ed75add2eadc9fe4809bb16c7981_r.jpg) 这里随便填一下。（用户名不要用汉字，记住密码）。点击”继续“![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-f527f1f73704dd82205df8667047bfe4_r.jpg) 等待安装完成。![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-6993292434e9a598d87d577aeed9ada4_r.jpg) 安装完成后重启虚拟机，登录就可以使用啦。 此时我们发现虚拟机未能全屏显示。原因是没有安装vmware tools。![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-b811a1c6d00fe1bebb00edd0159a54d6_r.jpg) 找到装载VMware Tools的虚拟光驱。找不到光驱时参照下方链接解决。[VMware 虚拟机 Ubuntu 不能全屏问题](https://www.cnblogs.com/clc2008/archive/2017/05/03/6801465.html)![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-d0553de91e556cf8113ce9e70602ed61_r.jpg) 打开这个光驱，复制下面这个文件夹到桌面，然后右键解压缩，无法复制到桌面时先在桌面新建一个文件夹再复制到这个文件夹里。![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-a9844f6fb1608b8bc60b54c0f86275eb_r.jpg) 解压缩后打开这个文件夹，右键选择在终端打开。![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-03d795a59943a6793291b35bb8843d73_r.jpg) 输入“sudo ./vmware-install.pl”，输入用户密码，输入yes开始安装![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-beddbdeaef63d909a1f79812993f6a32_r.jpg) 在安装过程中，出现下图红框中显示的符号提示时即为默认配置，在安装时笔者推荐使用默认配置，即但凡遇到提示，请再次手动输入默认配置。![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-fb6b0d45edbac847c1eaa85f2d35c4e1_r.jpg) 接下来N多enter，N多yes，凡yes/no选择都输入yes，不用输入的情况都按enter。![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-7dab2245da5634ee3cc144f844bdb95e_r.jpg) 安装完成，重启即可。此时虚拟机已经全屏显示了。![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-f039b79d9c849a3928e2c8121344cbed_r.jpg) 一个完整的Ubuntu虚拟机就这样安装好了，不要着急划走，下面介绍快速使用方法。 **8、快速使用“Ubuntu”** *8.1  VMware-workstation-full-16.2.2-19200509安装包链接：* *百度网盘* https://pan.baidu.com/s/1hC0-phDRsdVu5qwwbEA1xA 提取码：1234  首先安装虚拟机，直接下一步下一步，密钥如下选一个即可，亲测有效 **ZF3R0-FHED2-M80TY-8QYGC-NPKYF**  **YF390-0HF8P-M81RQ-2DXQE-M2UT6** **ZF71R-DMX85-08DQY-8YMNC-PPHV8**  **FA1M0-89YE3-081TQ-AFNX9-NKUC0** *8.2 Linux系统镜像**（作用：安装Linux系统）*** ubuntu16.04-64.rar（系统镜像文件较大，百度网盘无VIP下载较慢，急需的话可以留言，我通过其他途径发送给你） 百度网盘链接 链接：https://pan.baidu.com/s/1tGRiTXXvJEU-yzOORayQiQ  提取码：5678  *8.3 使用方法* a. 解压压缩包（最好放在固态硬盘分区中，运行速度较快） b. 打开VMware，点击“打开虚拟机”，找到解压路径，打开Ubuntu16.04-64.vmx c. 选择 gec 用户，密码为123456，进入系统 这个虚拟机可以直接使用，可满足嵌入式开发的入门需求。 **9、跨系统资源共享** 我们使用 VMware 软件的文件夹共享功能。 *使用步骤：* a. 在Windows中新建一个共享文件夹 share（名称最好为英文） b. VMware设置文件夹共享![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-be4c5e3dfa10a14050cb02af393b6ce6_b.jpg)![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-61ab3eecf50f2734ca3494092f1e4c73_r.jpg) c. 在Ubuntu中找到该共享文件![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-8ef0bc5b6b8a02c327a299966ba82562_r.jpg) **这样这个文件夹里的内容，你在实体机和虚拟机中都可以访问、复制、粘贴。** **10、配置Ubuntu联网** 配置ubuntu自动获取ip 点击网络配置，![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-c1d0d8db074d3559bc1885dc6ae55561_r.jpg)![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/v2-f18721883de78b75f101db707d87380d_r.jpg) 补充： ubuntu下载软件工具的命令 更新软件源 sudo apt-get update 下载软件 sudo apt-get install 软件的名字

编辑于 2022-05-23 · 著作权归作者所有

赞同  16

评论



收起

<iframe id="sgh-iframe-2" src="cid:frame-3A8578274C4E35B3477F369DA3642257@mhtml.blink" frameborder="none" width="100%"></iframe>

工作模式  预读模式 自动翻页模式 

预读设置 使用iframe方式  查看预读的内容 

翻页设置 使用iframe方式 新iframe  等待iframe完全载入  ms延时取出  手动模式  剩余倍页面高度触发  最多翻页  显示翻页导航  强制拼接  启用 立即翻页  开始 

启用 设置  保存 

![Google 翻译](https://www.gstatic.com/images/branding/product/1x/translate_24dp.png)

# 原文

提供更好的翻译建议

------

Number  of prefetched pictures: **1**
Prefetch  URL:**https://www.zhihu.com/tardis/sogou/art/477725832/page/2**

------

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/logo_black_trans.png)



<iframe title="语言翻译微件" class="goog-te-menu-frame skiptranslate" style="DISPLAY: none; VISIBILITY: visible" frameborder="0"></iframe>

[AC-重定向设置  25.05](https://www.ntaow.com/aboutscript.html)

-  主功能-重定向功能  En-Language 保存 重置 

-  附加1-去广告功能  自动翻页 

-  附加2-自主拦截域名 DIY   隐藏结果  隐藏'block'按钮 

-  附加3-自定义样式 

-  展开百度设置>>  百度-原始模式  百度-护眼模式  百度Lite样式 
   单列  单列居中  双列  三列  四列 

  

  展开谷歌设置>>  谷歌-原始模式  谷歌-护眼模式  谷歌-伪装百度  
   单列  单列居中  双列  三列  四列 

  

  展开必应设置>>  必应-原始模式  必应-护眼模式 
   单列  单列居中  双列  三列  四列 

  

  展开鸭鸭搜设置>>  鸭鸭-原始模式  鸭鸭-护眼模式  鸭鸭-常见配置 
   单列  单列居中  双列  三列  四列 

  

  展开多吉设置>>  多吉-原始模式  多吉-护眼模式  多吉-常见配置 
   单列  单列居中  双列  三列  四列 

- 附加4-护眼颜色配置-自定义3中需对应开启 

- 默认护眼颜色：           更多颜色选择 

- 附加5-Favicon功能 

- Favicon默认图标：  

- 附加6-移除百度搜索预测(文字自动搜索) 

- 附加7-显示右侧栏  附加8-编号功能  附加9-文字下划线 

- 附加10-自定义样式 支持Less.js 重置CSS 

- 

- [联系作者,提建议,寻求帮助,自定义样式,脚本定制点我](https://github.com/langren1353/GM_script)

- <-返回 拦截列表  想要生效的话需要手动保存} 

- 编辑列表 

- - baijiahao.baidu.comx 

- baijiahao.baidu.com 

- 全匹配拦截： 添加

- 返回

  使用说明：

  \-

  \1.  本脚本不包含任何广告内容，也无意于破坏网站现有功能的完整性，仅希望通过一些显示效果的变更能更好的留存对应网站现有的用户，一定程度上更好地保证了目标网站的日活。

  \2.  同时本脚本中所有功能均为学习和研究web前端技术的发展而开发，希望为学习前端技术的研究人员提供一个更好的参考代码，促进web前端技术的发展，便于技术的学习和交流，仅用于学习研究使用，无意于损害任何网站利益，不使用任何盈利方案或参与任何盈利组织。 

  \3.  因使用本脚本引起的或与本脚本有关的任何争议，各方应友好协商解决，本脚本对使用本脚本所提供的软件时可能对用户自己或他人造成的任何形式的损失和伤害不承担任何责任。如用户下载、安装和使用本产品中所提供的软件，即表明用户信任本作者及其相关协议和免责声明。 

取消保存



![img](https://www.google.com/images/cleardot.gif)![img](https://www.google.com/images/cleardot.gif)![img](https://www.google.com/images/cleardot.gif)▼

<iframe style="DISPLAY: none" src="cid:frame-05228298CF32297D3677836BA1BDA747@mhtml.blink" sandbox="allow-scripts"></iframe>



## ***\*VMware虚拟机 NAT模式 配置静态ip\****

![img](C:/Users/HI/AppData/Local/Temp/ksohtml4348/wps22.jpg) 

[hellocsz](https://me.csdn.net/hellocsz) 2018-09-10 11:17:57 ![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wps23.jpg) 4002 ![img](C:/Users/HI/AppData/Local/Temp/ksohtml4348/wps24.jpg) 收藏 1

前言：[Ubuntu](http://www.linuxidc.com/topicnews.aspx?tid=2) 16.04 VMware虚拟机 NAT模式 配置静态ip,这个问题困扰我好长时间，桥接的静态ip我会了，然而用NAT 的方式配置集群会更好。（NAT 方式客户机之间的通讯不经过路由器），所以想着换成NAT方式会更好。

要使用NAT方式设置静态ip ，需要相当多的[计算机网络](http://lib.csdn.net/base/computernetworks)知识了。

第一先查看你的主机的网卡是否把网络共享给虚拟网卡vmnet8 了吗？ 打开网络共享中心———>更改适配器设置 看下图  然后右击 你用的那个网卡。我用的无线。所以右击 无线网络连接———>属性——>共享——在选择框里选上 vmnet8网卡。 这个作用就是 无线网卡和 虚拟机的网卡对接上 主机 和 虚拟机就是通过vmnet8 这个虚拟网卡进行通讯的。这个 知识很重要。





本地局域网IP配置

![image-20220625191733087](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20220625191733087.png)



## 以太网 共享VMnet8-

### VMnet8-会生成默认的IP[例如192.168.138.1]-自动获取的IP可以上网（自动获取的IP）魔法

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wps25.jpg) 

。  

1 首先要知道，主机给 vmnet8 网卡分配的ip  看下图。**自动获取的IP可以上网**

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wps26.jpg) 

这个ip 就是虚拟机 配置静态ip时的网关，记住！！！！！！！这点很重要。

2 打开vm软件——》编辑——》虚拟网络编辑器

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wps27.jpg) 

 

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wps28.jpg) 

 

 

 

 

最终的效果类似如下(这里面有刚才主机分配的IP)

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wps29.jpg) 

3 进行虚拟机配置文件设置

我的系统是ubuntu 16.04 lts  ，[CentOS](http://www.linuxidc.com/topicnews.aspx?tid=14)的系统找相应的网卡配置文件就可以。

kong@root：sudo /etc/network/interfaces  

 

进行以下修改

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/wps30.jpg) 

4 进行dns 设置  

kong@root：sudo  vim /etc/resolvconf/resolvconf.d/head

 将 nameserver 8.8.8.8 写进去 保存退出  网卡重启。或者虚拟机重启

然后ping [www.linuxidc.com](http://www.linuxidc.com/) 看看能不能ping通

 



