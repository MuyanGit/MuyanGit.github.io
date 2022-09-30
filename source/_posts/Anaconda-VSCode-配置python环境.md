---





title: '  Anaconda + VSCode 配置python环境   '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-10-20 08:01:39
authorLink:
tags: Anaconda
keywords:
description: Anaconda+vscode配置Python环境,AnacondaVSCode,python
photos:
---



# Anaconda + VSCode 配置python环境

Anacond下载

**下载地址： https://www.anaconda.com/download/
选择适合的系统环境和版本。本人是Windows10系统64位机器，故下载python3.7 64-Bit。**
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200604172832565.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MjEzMzIxNg==,size_16,color_FFFFFF,t_70)
**下载完成**
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200802643.png)
**打开安装包，进行安装（其实接下来除了选择安装路径，其他的直接默认点击下一步就可以了）**
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200802187.png) ![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200802232.png) ![在这里插入图片描述](https://img-blog.csdnimg.cn/20200604173416368.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MjEzMzIxNg==,size_16,color_FFFFFF,t_70)
**Install for: Just me || All Users，如若电脑有多个 Users ，需要考虑这个问题。我们电脑一般只会有一个 User，只自己使用。如果电脑有多个用户，选择All Users，笔者此处直接 All User，继续点击 Next 。**
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200802326.png)

```
选择路径，继续安装，
不勾选第一项--> 方便安装官网的python
```



![image-20211110201434027](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110201434027.png)



https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/	image-20211110201434027.png

https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/	20220523225729.png



![在这里插入图片描述](https://img-blog.csdnimg.cn/20200604173942895.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MjEzMzIxNg==,size_16,color_FFFFFF,t_70)

此处勾选设置环境变量，否则需要自己设置（也很简单）
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200802496.png) ![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200802975.png)

https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200802975.png







**验证是否安装成功：
win+r输入cmd，打开命令管理器，输入conda --version**
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200604174331167.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MjEzMzIxNg==,size_16,color_FFFFFF,t_70)
**输出Anaconda版本，则表示安装成功！**

Anaconda更换国内源

**Anaconda使用的源在国外，下载各种包的速度比较慢，所以我们更改Anaconda的源
Anaconda更换国内源方法的文章地址在此处，请点击查看：
https://blog.csdn.net/weixin_42133216/article/details/106476875**

Anaconda新建环境

**Anaconda可以看作是一个虚拟机，我们的python环境使用的不是本机，而是Anaconda中的环境。
比如笔者的Windows的电脑上并没有安装python解释器，但是在写python程序的时候选择Anaconda环境，一样可以随心所欲的使用python。**

**打开安装好的Anaconda Navigator**
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200604180536404.png)
点击Environments
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200802914.png)
**最初只会有base(root)这一个环境，我们可以自己创建新环境，此处的machine就是笔者自己创建的**
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200802480.png)

**创建方法也很简单：
1.点击Create
2.输入环境名称和Python版本点击创建即可**
![在这里插入图片描述](https://img-blog.csdnimg.cn/2020060418100621.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MjEzMzIxNg==,size_16,color_FFFFFF,t_70)
**这样在后面使用VSCode的时候，只要将环境设置为Anaconda中自己创建的环境就可以了。**



### [Win10 vscode配置环境系列：Anaconda](https://segmentfault.com/a/1190000037545828)

### 

如果使用此方法，则电脑可以不用安装python，直接使用anaconda自带的python，在cmd即可直接进入anaconda的python环境，而不用每次都启动anaconda。

### 2.配置环境变量

这5个路径都要全部添加到环境变量里面，否则conda和python命令可能会无法使用。具体的路径根据自己电脑的安装路径修改。

- ```
  D:\MySoftware\DEV\Dev_env\Anaconda3;
  D:\MySoftware\DEV\Dev_env\Anaconda3\Scripts
  D:\MySoftware\DEV\Dev_env\Anaconda3\Library\bin;
  D:\MySoftware\DEV\Dev_env\Anaconda3\Library\mingw-w64\bin;
  
  ```

- 

**添加完环境变量后要重启vscode**

3.在vscode选择python环境-这里需要双击，然后点击工作区，然后选择Anaconda

![image](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200804886.png)

- 选择路径为annaconda的那个，大功告成
- 在每次打开包含python配置的文件夹后，终端会自动打开anaconda

安装VSCode

**Anaconda在安装时，会自带VSCode，若已安装，则无需再次安装VSCode**
**下载地址： https://code.visualstudio.com/Download**
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200604174902276.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MjEzMzIxNg==,size_16,color_FFFFFF,t_70)
**下载完成，点击安装包进行安装**
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200604174750956.png)
**安装步骤图示不再给出，直接勾选下一步，下一步即可**

配置VSCode

**安装完VSCode后，开始是纯英文的，如果有喜欢中文的朋友，可以下载插件，设置成中文**

**点击左边图标，在搜索框里面搜索Chinese**
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200604183429692.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MjEzMzIxNg==,size_16,color_FFFFFF,t_70)
**选择中文简体，点击安装即可，安装后重启一遍VSCode**
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200802358.png)
**然后输入Python，搜索Python插件，点击安装**
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200802115.png)
然后就是选择Python环境，可以看到笔者的Python环境是Anaconda中的machine，也就是自己创建的环境** 

这里需要双击，然后点击工作区，然后选择Anaconda

![加粗样式](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200802172.png)
**点击左下角便可以更改Python环境**
![在这里插入图片描述](https://img-blog.csdnimg.cn/2020060418391331.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MjEzMzIxNg==,size_16,color_FFFFFF,t_70)
**然后就可以使用了VSCode写Python代码了**
![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200802319.png)





# Anaconda国内源配置

[![海上添翼](https://www.cpci.dev/content/images/2021/06/suse-2.png)](https://www.cpci.dev/author/hai/)



[清华源页面](https://mirrors.tuna.tsinghua.edu.cn/help/anaconda/)；也包含了`MiniConda`的源

安装完Anaconda之后，打开`Anaconda Prompt（anaconda3）`；输入

```cmd
conda config --set show_channel_urls yes
```

在安装完成后，`.condarc`文件还没生成，所以使用一条命令生成一下，其位置在`c:\Users\<用户名>\.condarc`，对于新版的win10可能显示的是`c:\用户\<用户名>\.condarc`

使用文本编辑器打开这个文件，覆盖原有的全部内容

![image-20211023221106980](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110232213017.png)

##### 问题-可以解决2·[Anaconda建立新的环境，出现CondaHTTPError: HTTP 000 CONNECTION FAILED for url ...... 解决过程](https://www.cnblogs.com/tianlang25/p/12433025.html)



```ini
show_channel_urls: true

ssl_verify: false
channels:
  - http://mirrors.tuna.tsinghua.edu.cn/anaconda/pkgs/main/
  - http://mirrors.tuna.tsinghua.edu.cn/anaconda/pkgs/free/
  - http://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud/conda-forge/
  - http://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud/Paddle/
  - http://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud/msys2/
  - http://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud/fastai/
  - http://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud/pytorch/
  - http://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud/bioconda/

```

也可以试一下：

```
channels:
  - defaults
show_channel_urls: true
ssl_verify: false
channel_alias: https://mirrors.tuna.tsinghua.edu.cn/anaconda
default_channels:
  - https://mirrors.tuna.tsinghua.edu.cn/anaconda/pkgs/main
  - https://mirrors.tuna.tsinghua.edu.cn/anaconda/pkgs/free
  - https://mirrors.tuna.tsinghua.edu.cn/anaconda/pkgs/r
  - https://mirrors.tuna.tsinghua.edu.cn/anaconda/pkgs/pro
  - https://mirrors.tuna.tsinghua.edu.cn/anaconda/pkgs/msys2
custom_channels:
  conda-forge: https://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud
  msys2: https://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud
  bioconda: https://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud
  menpo: https://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud
  pytorch: https://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud
  simpleitk: https://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud
```



```


channels:
  - https://mirrors.tuna.tsinghua.edu.cn/anaconda/pkgs/main/
  - defaults
show_channel_urls: true
```



- $\textcolor{Red}{	ssl_verify: true	--> 应该关闭	}$
- $\textcolor{Red}{	https:--> http	--> 应该关闭	}$
- $\textcolor{Red}{	default_channels--> 删除--> 应该关闭	}$

```
channels:
  - defaults
ssl_verify: true	--> 应该关闭
show_channel_urls: true
default_channels:
  - https://mirrors.tuna.tsinghua.edu.cn/anaconda/pkgs/main
  - https://mirrors.tuna.tsinghua.edu.cn/anaconda/pkgs/r
  - https://mirrors.tuna.tsinghua.edu.cn/anaconda/pkgs/msys2
custom_channels:
  conda-forge: https://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud
  msys2: https://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud
  bioconda: https://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud
  menpo: https://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud
  pytorch: https://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud
  simpleitk: https://mirrors.tuna.tsinghua.edu.cn/anaconda/cloud
123456789101112131415
```



保存后执行一条命令，清除一下缓存

```cmd
conda clean -i
```

**如果已经打开了Anaconda Navigator，别忘了重启生效**

测试生效

```cmd
:: 查看全部配置信息
conda config --show
:: 查看源的配置信息
conda config --show-sources
1234
```

- 

# 软件配置

### 如果选择Miniconda，则：

- 熟手可以完全自定义安装每个所用的包；
- 磁盘空间紧张；
- 追求效率，不想浪费在初始化上；或喜欢纯净的开发环境

### 配置PyCharm

如果环境变量配置正确了，那么在PyCharm里面选择Conda环境的时候，会自动识别；如果没有自动识别，可以手动添加一下；

现有环境

- 解释器：D:\anaconda\python3.exe
- Conda可执行文件：D:\anaconda3\Scripts\conda.exe
- 可用于所有项目：勾选

对于项目的根目录下的`.idea/venv`可以删除了

这个时候，对于当前的项目就出问题了，因为原先的解释器失效了；右下角配置环境的按钮挪到了右上角，点击下拉菜单中的“编辑”，（“运行”按钮旁边）；选择“Python解释器”的下拉菜单，选择带有Anaconda图标的那个，应用；一切恢复如常。

文件 -> 清除缓存/重启 -> 作废并重启

### PIP  源 --> Python

验证版本：Python 3.8.5

在当前用户目录下（不是文档目录下）`c:\用户\<用户名>\`下新建`pip`目录，然后创建一个`pip.ini`文件，输入一下内容即可使用阿里源

```ini
[global]
index-url = https://mirrors.aliyun.com/pypi/simple/

[install]
trusted-host=mirrors.aliyun.com
```

pip.ini路径如下C:\Users\HelloWorld\pip\pip.ini![image-20211020092806270](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200928376.png)

![image-20211020092850288](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200930058.png)



### MoviePy的安装-新建conda环境，然后安装-

下载与安装

Conda包管理

```cmd
:: 为指定环境安装某个包

conda install -n TestPythonHello moviepy

:: 激活某个环境
activate TestPythonHello
conda install -c conda-forge moviepy
```









MoviePy的安装-

新建conda环境，然后安装-

**首先，**安装moviepy基本包。与其他的库一样，直接采用 pip 的方式安装即可，pip方便快捷

```text
conda install moviepy
pip install moviepy



conda remove -n python38Video --all
删除python38Video文件夹
conda env list

#删除所有的下载的安装包及cache
conda clean -y --all 

conda create --name python38Video python=3.8
activate python38Video
conda install moviepy


```

安装完后，python38Video中有moviepy可以看见`moviepy/config_defaults.py`文件

![image-20211020171527437](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110201715540.png)



防止错误定期重建everything索引 

![image-20211020172744825](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110201727979.png)

**第二步**，安装依赖包ImageMagic

ImageMagic是用于在视频中填入文本信息的工具，我认为还是很有用处的，需要单独下载exe程序安装。

下载地址为：https://imagemagick.org/script/download.php，windows系统页面拖到最下面可以找到。下载完毕后双击安装即可

[ImageMagick](https://www.imagemagick.org/script/index.php) 只有在你想要添加文字时需要用到。它可作为一个后端用在GIF上，但如果不安装ImageMagick，你也可以用MoviePy处理GIF。

必须勾选才会有ImageMagick_VERSION\\convert.exe"文件



![image-20211020092307789](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200932752.png)



![image-20211020093705837](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110200937892.png)

一旦你安装了ImageMagick，它会被MoviePy自动检测到，**除了Windows环境！** Windows用户在手动安装MoviePy之前，应在`moviepy/config_defaults.py`文件中指定ImageMagick binary的路径，并叫做*convert*。看起来应该像是这样：

 ImageMagic路径:

```
IMAGEMAGICK_BINARY = "C:\\Program Files\\ImageMagick_VERSION\\convert.exe"
IMAGEMAGICK_BINARY = "D:\\MySoftware\\VideoCut\\ImageMagick-7.1.0-Q16-HDRI\\convert.exe"
```



**第三步**，给选定环境中的moviepy 设置 ImageMagic路径

在上一步中安装了ImageMagic，但此时仍无法使用，因为Python不知道ImageMagic安装在哪里，需要在Python的库文件中找到`moviepy/config_defaults.py`，

并在最后一行加入`IMAGEMAGICK_BINARY = "C:\\Program Files\\ImageMagick_VERSION\\convert.exe"` （此处修改为你的安装路径）

至此，moviepy安装完毕！

eg:

```
"""
Configuration of MoviePy


This file enables you to specify a configuration for MoviePy. In
particular you can enter the path to the FFMPEG and ImageMagick
binaries.

Defaults must be done BEFORE installing MoviePy: first make the changes,
then install MoviePy with

    [sudo] python setup.py install

Note that you can also change the path by setting environment variables.
e.g.

Linux/Mac:
   export FFMPEG_BINARY=path/to/ffmpeg

Windows:
   set FFMPEG_BINARY=path\to\ffmpeg

Instructions
--------------

FFMPEG_BINARY
    Normally you can leave this one to its default ('ffmpeg-imageio') at which
    case image-io will download the right ffmpeg binary (at first use) and then
    always use that binary.
    The second option is 'auto-detect', in this case ffmpeg will be whatever
    binary is found on the computer generally 'ffmpeg' (on linux) or 'ffmpeg.exe'
    (on windows).
    Third option: If you want to use a binary at a special location on you disk,
    enter it like that:

    FFMPEG_BINARY = r"path/to/ffmpeg" # on linux
    FFMPEG_BINARY = r"path\to\ffmpeg.exe" # on windows

    Warning: the 'r' before the path is important, especially on Windows.


IMAGEMAGICK_BINARY
    For linux users, 'convert' should be fine.
    For Windows users, you must specify the path to the ImageMagick
    'magick' binary. For instance:

    IMAGEMAGICK_BINARY = r"C:\Program Files\ImageMagick-6.8.8-Q16\magick.exe"

"""

import os

FFMPEG_BINARY = os.getenv('FFMPEG_BINARY', 'ffmpeg-imageio')
IMAGEMAGICK_BINARY = os.getenv('IMAGEMAGICK_BINARY', 'auto-detect')
IMAGEMAGICK_BINARY = "D:\\MySoftware\\VideoCut\\ImageMagick-7.1.0-Q16-HDRI\\convert.exe"
```



视频文件的读取

剪辑处理视频，首先需要读取到视频文件，主要有`VideoFileClip`、`clips_array`、`CompositeVideoClips`这三种方法









# Anaconda常用命令小结

[![菜鸡日志](https://pic3.zhimg.com/v2-e12f5d64d5fe50a52950bb9e7fc58f2a_xs.jpg?source=172ae18b)](https://www.zhihu.com/people/wo-shi-lao-qi)

[菜鸡日志](https://www.zhihu.com/people/wo-shi-lao-qi)

沉迷学习

29 人赞同了该文章



简介

入门机器学习、深度学习，有个神器不得不了解下，最好熟练有它。这就是Anaconda



Anaconda是一个开源的Python发行版本，其包含了conda、Python等180多个科学包及其依赖项. 用它来管理、开发等，及其方便，里面集成了相当多的有用的吧，比如：numpy、pandas等。



还有个神器也在里面，jupyter notebook，这个用来调试代码等非常方便。现在就简单介绍一些anaconda常用的命令，方便大家早些上手。



首先，官网文档地址贴上：

[https://conda.io/docs/user-guide/index.html](https://link.zhihu.com/?target=https%3A//conda.io/docs/user-guide/index.html)

更详细的教程可直接查询官网~



Anaconda安装配置

安装过程在这里就略掉不展开了，在TensorFlow环境配置那有详细讲过，可以翻阅。

再贴个其他博客的地址，供参考（Windows版）

[https://blog.csdn.net/wz947324/article/details/80205181](https://link.zhihu.com/?target=https%3A//blog.csdn.net/wz947324/article/details/80205181)

安装好记得检查下环境变量，配置好环境变量



conda管理相关命令

conda自身相关

查看当前conda工具版本号

```text
conda --version
```





![img](https://pic4.zhimg.com/80/v2-75ac44cc5d04b4c8dee0b5a7509e5523_720w.jpg)





查看包括版本的更多信息

```text
conda info
```



![img](https://pic1.zhimg.com/80/v2-af840a14126f8f918b100c8251fca5a4_720w.jpg)



更新conda至最新版本

```text
conda update conda
```



查看conda帮助信息

```text
conda -h
```



![img](https://pic2.zhimg.com/80/v2-49449f2a50551c100a35f76b1b62957d_720w.jpg)关注公众号“学习与成长资源库”获取更多最新资料



环境管理相关

查看conda环境管理命令帮助信息

```text
conda create --help
```



创建出来的虚拟环境所在的位置为conda路径下的env/文件下,,默认创建和当前python版本一致的环境.

```text
conda create --name envname
```



创建新环境时指定python版本为3.6，环境名称为python36

```text
conda create --name python36 python=3.6
```



切换到环境名为python36的环境（默认是base环境），切换后可通过python -V查看是否切换成功

```text
conda activate python36
```



返回前一个python环境

```text
conda deactivate
```

显示已创建的环境，会列出所有的环境名和对应路径

```text
conda info -e
```



删除虚拟环境

```text
conda remove --name envname --all
```



指定python版本,以及多个包

```text
conda create -n envname python=3.4 scipy=0.15.0 astroib numpy
```



查看当前环境安装的包

```text
conda list   ##获取当前环境中已安装的包
conda list -n python36   ##获取指定环境中已安装的包
```



克隆一个环境

```text
# clone_env 代指克隆得到的新环境的名称
# envname 代指被克隆的环境的名称
conda create --name clone_env --clone envname

#查看conda环境信息
conda info --envs
```



构建相同的conda环境(不通过克隆的方法)

```text
# 查看包信息
conda list --explicit

# 导出包信息到当前目录, spec-file.txt为导出文件名称,可以自行修改名称
conda list --explicit > spec-file.txt

# 使用包信息文件建立和之前相同的环境
conda create --name newenv --file spec-file.txt

# 使用包信息文件向一个已经存在的环境中安装指定包
conda install --name newenv --file spec-file.txt
```



查找包

```text
#模糊查找，即模糊匹配，只要含py字符串的包名就能匹配到
conda search py   

##查找包，--full-name表示精确查找，即完全匹配名为python的包
conda search --full-name python
```



安装更新删除包

```text
##在当前环境中安装包
conda install scrapy  

##在指定环境中安装包
conda install -n python36 scrapy

##在当前环境中更新包  
conda update scrapy   

##在指定环境中更新包
conda update -n python36 scrapy  

##更新当前环境所有包
conda update --all   

##在当前环境中删除包
conda remove scrapy   

##在指定环境中删除包
conda remove -n python2 scrapy
```





Python管理

查找可以安装的python

```text
# 查找所有名称包含python的包
conda search python

# 查找全名为python的包
conda search --full-name python
```



安装不同版本的Python

```text
#在不影响当前版本的情况下,新建环境并安装不同版本的python
#新建一个Python版本为3.6 名称为 py36 的环境

conda create -n py36 python=3.6 anaconda

#注:将py36替换为您要创建的环境的名称。 anaconda是元数据包，带这个会把base的基础包一起安装，不带的话新环境只包含python3.6相关的包。 python = 3.6是您要在此新环境中安装的软件包和版本。 这可以是任何包，例如numpy = 1.7，或多个包。
#然后激活想要使用的环境即可
conda activate py36
#更新Python
# 普通的更新python
conda update python

# 将python更新到另外一个版本/安装指定版本的python
conda install python=3.6
```



------

分享环境

如果你想把你当前的环境配置与别人分享，这样ta可以快速建立一个与你一模一样的环境（同一个版本的python及各种包）来共同开发/进行新的实验。一个分享环境的快速方法就是给ta一个你的环境的.yml文件。



首先通过activate target_env要分享的环境target_env，然后输入下面的命令会在当前工作目录下生成一个environment.yml文件

```text
conda env export > environment.yml
```



小伙伴拿到environment.yml文件后，将该文件放在工作目录下，可以通过以下命令从该文件创建环境

```text
conda env create -f environment.yml
```





参考文档

[https://conda.io/docs/user-guide/index.html](https://link.zhihu.com/?target=https%3A//conda.io/docs/user-guide/index.html)

[https://blog.csdn.net/wz947324/article/details/80229560](https://link.zhihu.com/?target=https%3A//blog.csdn.net/wz947324/article/details/80229560)

[https://blog.csdn.net/menc15/article/details/71477949](https://link.zhihu.com/?target=https%3A//blog.csdn.net/menc15/article/details/71477949)





### 常用命令

[Conda官方文档](https://docs.conda.io/projects/conda/en/latest/index.html)

```cmd
:: 获取版本号
conda --version
conda -V

:: 获取帮助
conda --help
conda -h

:: 查看某个子命令的帮助
conda config --help
conda update --help
conda remove --help
conda install --help

:: 查看环境管理的全部命令
conda env -h

:: 创建Python版本的环境
conda create --name your_env_name python=3.7
conda create --name python38Video python=3.8
conda create --name p28 python=2.8 -y
conda create --name p30 python=3.0 -y
conda create --name p35 python=3.5 -y
conda create --name p36 python=3.6 -y
conda create --name p37 python=3.7 -y
conda create --name p38 python=3.8 -y

:: 确定Python版本：
activate envname
python -V

:: 创建包含某些包的环境
conda create --name your_env_name numpy scipy

:: 创建指定Python版本下包含某些包的环境
conda create --name your_env_name python=3.8 numpy scipy
conda create -n your_env_name3.6 python=3.6 numpy scipy
conda create -n ksDjango3.8 python=3.8

:: 列出当前所有环境
conda info --envs
conda env list

:: 激活某个环境
activate your_env_name
activate python38Video

:: 关闭某个环境
conda deactivate 


```

#### :: 克隆某个环境

```cmd
# clone_env 代指克隆得到的新环境的名称
# envname 代指被克隆的环境的名称
conda create --name clone_env --clone envname

#查看conda环境信息
conda info --envs
conda create -n HelloPython38 --clone TestPythonHello
conda create -n base20211023Python38 --clone base
```

##### 构建相同的conda环境(不通过克隆的方法)

```bash
# 查看包信息
conda list --explicit

# 导出包信息到当前目录, spec-file.txt为导出文件名称,可以自行修改名称
conda list --explicit > 2021年11月16日·星期2·4·09·54·15conda-p38-file.txt

# 使用包信息文件建立和之前相同的环境
conda create --name newenv --file spec-file.txt
conda create -n p38Video -conda-base-env-spec-file.txt


conda list --explicit > 2021年10月23日·星期6·23·12·15conda-base-env-spec-file.txt

# 使用包信息文件向一个已经存在的环境中安装指定包
conda install --name newenv --file spec-file.txt
```

```cmd
:不可以如此
应该先创建环境，然后倒入
conda create --name p38Proxy python=3.8
conda install --name p35 --file spec-file.txt
```

![image-20211116052025305]()



#### 查找包

```bash
#模糊查找，即模糊匹配，只要含py字符串的包名就能匹配到
conda search py   

##查找包，--full-name表示精确查找，即完全匹配名为python的包
conda search --full-name pythona

:: 列出当前激活环境的所有包
conda list

:: 列出一个非激活环境的所有包
conda list --name your_env_name
conda list -n HelloPython38
```

#### 查找可以安装的python

```bash
# 查找所有名称包含python的包
conda search python

# 查找全名为python的包
conda search --full-name python



```

##### 安装不同版本的Python

```bash
#在不影响当前版本的情况下,新建环境并安装不同版本的python
#新建一个Python版本为3.6 名称为 py36 的环境

conda create -n py36 python=3.6 anaconda
conda create --name p38Proxy python=3.8 -y

#注:将py36替换为您要创建的环境的名称。 anaconda是元数据包，带这个会把base的基础包一起安装，不带的话新环境只包含python3.6相关的包。 python = 3.6是您要在此新环境中安装的软件包和版本。 这可以是任何包，例如numpy = 1.7，或多个包。
#然后激活想要使用的环境即可
conda activate py36
#更新Python
# 普通的更新python
conda update python

# 将python更新到另外一个版本/安装指定版本的python
conda install python=3.6
```

#### 安装包

```bash
##在当前环境中安装包
conda install scrapy  

##在指定环境中安装包
conda install -n python36 scrapy

:: 为指定环境安装某个包
conda install -n env_name package_name
conda install -n TestPythonHello moviepy
cmd中运行
activate p38 && pip install pyexecjs
记得关闭代理
activate p38Proxy && pip install -r requirements.txt
activate p38 && pip install -r  requirements.txt
activate p38 && pip install -r  G:\Demo_Git\哔哩哔哩\上传\biliup\requirements.txt

activate p38 && conda install --name p38 --file  requirements.txt  -y 
activate p38 && conda install --name p38 tensorflow  -y 

pip install -r requirements.txt 
## 
conda install --yes --file requirements.txt

conda install --name ksDjango3.8 autopep8 -y
conda install --name ksDjango3.8 --file requirements.txt  -y 


activate HelloPython38
conda deactivate
conda uninstall moviepy

通道
conda config --add channels conda-forge
conda install  django
conda install -c conda-forge moviepy
conda install -c conda-forge ruia
conda install pytorch torchvision torchaudio cudatoolkit=11.0 -c pytorch
```

#### naconda 安装在线/离线(.whl或者.tar.gz)包的一些方法



##### 在线包

对于命令行窗口安装，有两种终端窗口
1、“win”+R，输入”cmd“，如下
![在这里插入图片描述](https://pianshen.com/images/358/3064b99c7a8e0cf1c3804da99e200616.png)
2、右键开始菜单，选择“Windows Powershell(I)”
![在这里插入图片描述](https://pianshen.com/images/12/230a3c00800d10930bae5575315b289c.png)
个人建议可以用后面这个，命令更多。

将命令行的所在文件目录cd/d到有conda或者pip的文件夹下，进行
conda install “文件名”
pip install “文件名”--> conda 环境中也可以使用哦

![image-20211112185205415](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211112185205415.png)

##### 离线安装·**请关闭代理**--> 可以直接在cmd中进行

![image-20211113051536343](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211113051536343.png)

```cmd
1、安装.whl文件--> **请关闭代理**
在Anaconda文件目录下打开Anaconda Powershell Prompt
输入pip install “路径\文件名”
```



pip 指定某个路径安装包

场景：

有的时候我们安装了annconda环境，有很多的python环境，比如py36, py37, py27。此时，我们使用`pip`安装包的时候，经常可能安装在一个不知道的路径，或者不是我们期望安装的路径。

这就是本文要解决的问题了。

方法一

指定安装`numpy`包到固定文件夹下，比如这里“文件夹”是安装路径

```cmake
pip install -t 文件夹 numpy
```

方法二

设置 pip 默认安装路径

找到 `site.py` 文件。（windows：可以通过自带的查找，或者使用 `everything`软件；Linux直接使用find命令即可）

我的目录：D:programAnacondaenvspy36Libsite.py

修改 `USER_SITE` 和 `USER_BASE` 两个字段的值(之前是null).

```ini
#自定义依赖安装包的路径
USER_SITE = null
#自定义的启用Python脚本的路径
USER_BASE = null
```

我这里修改为

```ini
USER_SITE = "D:\program\Anaconda\envs\py36\Lib\site-packages"
USER_BASE = "D:\program\Anaconda\envs\py36\Scripts"
```

使用命令查看、验证

```ebnf
python -m site
```

结果

```taggerscript
sys.path = [
    'C:\\Users\\z2010',
    'D:\\program\\Anaconda\\envs\\py36\\python36.zip',
    'D:\\program\\Anaconda\\envs\\py36\\DLLs',
    'D:\\program\\Anaconda\\envs\\py36\\lib',
    'D:\\program\\Anaconda\\envs\\py36',
    'D:\\program\\Anaconda\\envs\\py36\\Lib\\site-packages',
    'D:\\program\\Anaconda\\envs\\py36\\Lib\\site-packages\\torchvision-0.2.1-py3.6.egg',
    'D:\\program\\Anaconda\\envs\\py36\\Lib\\site-packages\\tqdm-4.28.1-py3.6.egg',
    'D:\\program\\Anaconda\\envs\\py36\\Lib\\site-packages\\pyahocorasick-1.4.0-py3.6-win-amd64.egg',
    'D:\\program\\Anaconda\\envs\\py36\\Lib\\site-packages\\win32',
    'D:\\program\\Anaconda\\envs\\py36\\Lib\\site-packages\\win32\\lib',
    'D:\\program\\Anaconda\\envs\\py36\\Lib\\site-packages\\Pythonwin',
]
USER_BASE: 'D:\\program\\Anaconda\\envs\\py36\\Scripts' (exists)
USER_SITE: 'D:\\program\\Anaconda\\envs\\py36\\Lib\\site-packages' (exists)
ENABLE_USER_SITE: True
```



```cmd
2、安装.tar.gz文件

（1）将解压后的文件直接放在…/Anacoanda/Lib/site-packages目录下，删除版本号哦
注：需要将不带版本号的子文件放在目录下
（2）在Anaconda文件目录下打开Anaconda Powershell Prompt·
输入：
python setup.py install
```

![image-20211112183210140](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211112183210140.png)

```cmd
离线安装-方法2
下载安装包:复制网址https://pypi.tuna.tsinghua.edu.cn/packages/42/02/7b2fb0b81266aa3243dd8f392d48db1a206cc9a1856a14228e75c515616e/opencv-contrib-python-4.5.1.48.tar.gz到浏览器下载安装包
解压安装包:tar -zxvf opencv-contrib-python-4.5.1.48.tar.gz
cd opencv-contrib-python-4.5.1.48
python setup.py build
提示错误:ModuleNotFoundError: No module named ‘skbuild’
解决:pip install scikit-build
提示错误:
解决:编译OpenCV 以及 openc_contrib 提示缺少boostdesc_bgm.i文件出错的解决
python setup.py install
```



![在这里插入图片描述](https://pianshen.com/images/721/b9e6a58aa17d8801db9a1956f2f9e349.png)



配置环境变量了，cmd中也是可以操作

```cmd
1、安装.whl文件--> **请关闭代理**
```



![image-20211111222403911](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211111222403911.png)

![image-20211111221853167](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211111221853167.png)



#### 更新

```bash
##在当前环境中更新包  
conda update scrapy   

##在指定环境中更新包
conda update -n python36 scrapy  

##更新当前环境所有包
conda update --all  
```

#### 删除

```bash

:: 删除某个环境
conda remove -n your_env_name(虚拟环境名称) --all， 即可删除。
##在当前环境中删除包
conda remove scrapy   

##在指定环境中删除包
conda remove -n python2 scrapy
conda remove -n python38Video --all
conda clean -p      //删除没有用的包
conda clean -t      //tar打包
conda clean -y --all //删除所有的下载的安装包及cache
```



#### 分享环境

如果你想把你当前的环境分享给朋友，让对方也可以快速拥有一个和你相同的环境（相同的版本和包），那么就给TA一个当前环境的`.yml`文件。

首先通过`activate target_env`要分享的环境`target_env`，然后输入以下命令，生成一个`.yml`文件

```cmd
conda env export > share_env.yml
```

对方拿到后，放在指定目录下，然后通过命令创建该环境

```cmd
conda env create -f share_env.yml
```

如果你够厉害的话，这个文件完全可以手写，里面详细记录了每个包的名字和对应的版本号



### 问题1：新建环境可解决

```bash
发生异常: ImportError       (note: full exception trace is shown but execution is paused at: <module>)


IMPORTANT: PLEASE READ THIS FOR ADVICE ON HOW TO SOLVE THIS ISSUE!

Importing the numpy C-extensions failed. This error can happen for
many reasons, often due to issues with your setup or how NumPy was
installed.

We have compiled some common reasons and troubleshooting tips at:

    https://numpy.org/devdocs/user/troubleshooting-importerror.html

Please note and check the following:

  * The Python version is: Python3.8 from "D:\Java\Python\Anaconda3\envs\HelloPython38\python.exe"
  * The NumPy version is: "1.20.1"

and make sure that they are the versions you expect.
Please carefully study the documentation linked above for further help.

Original error was: DLL load failed while importing _multiarray_umath: 找不到指定的模块。

During handling of the above exception, another exception occurred:

  File "H:\douyinVideo\视频拼接.py", line 2, in <module> (Current frame)
    from moviepy.editor import VideoFileClip,concatenate_videoclips
```





### requirements.txt使用

许多Python项目中都包含了requirements.txt文件，该文件记录了当前程序的所有依赖包及其精确版本号。

1. **生成requirement.txt文件**

> pip freeze > requirements.txt

**安装requirement.txt文件依赖**

> pip install -r requirements.txt

1. 除了使用pip命令来生成及安装requirement.txt文件以外，也可以使用**conda命令来安装**。

> ```cmd
> ## conda install --yes --file requirements.txt
> 
> conda install --name ksDjango3.8 autopep8 -y
> conda install --name p38 --file requirements.txt  -y 
> 
> ```
>
> 

但是这里存在一个问题，如果requirements.txt中的包不可用，则会抛出“无包错误”。
使用下面这个命令可以解决这个问题

> $ while read requirement; do conda install --yes $requirement; done < requirements.txt

如果想要在conda命令无效时使用pip命令来代替，那么使用如下命令：

> $ while read requirement; do conda install --yes $requirement || pip install $requirement; done < requirements.txt

1. 也可以这样子操作

**导出到.yml文件**

> conda env export > freeze.yml

**直接创建conda环境**

> conda env create -f freeze.yml

Reference：
[Install only available packages using “conda install --yes --file requirements.txt” without error](https://stackoverflow.com/questions/35802939/install-only-available-packages-using-conda-install-yes-file-requirements-t)

![image-20211020161426340](C:/Users/HelloWorld/AppData/Roaming/Typora/typora-user-images/image-20211020161426340.png)

### 添加已安装的应用

如果已经安装Pycharm Community和Vscode（这个会自动识别）；可以把Pycharm社区版手动添加到Anaconda Navigator里面

File -> Preference -> PyCharm CE path:"D:\Program Files\JetBrains\PyCharm Community Edition 2020.3.2"

MiniConda

Miniconda一个Conda的免费最小安装程序，它是Anaconda的小型启动程序版本，仅包含Python、Conda；最小的依赖包和少量的其他软件，属于精简版Conda；

### [MiniConda下载地址/官方文档](https://docs.conda.io/en/latest/miniconda.html)

选择建议

如果选择Anaconda，则：

- 是Conda或Python新手；
- 完全集成的环境安装大量软件包
- 多余的磁盘空间（占用大约3G）和节省安装插件或配置的时间；
- 不想单独安装每个所用的包或解决包依赖关系。

## 自动导入

装一下这个插件，在 TS 和 TSX 模块中可用。
![请添加图片描述](https://img-blog.csdnimg.cn/3df240aad870487f9a8ac127a3df6b2f.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MzQ4Nzc4Mg==,size_16,color_FFFFFF,t_70)
例如在这边导出一个 `compose` 函数：
![请添加图片描述](https://img-blog.csdnimg.cn/2086cad42d144b8aa0ac13b34f3b23ef.png)
在另一个模块中输入 `compose` 然后按回车：
![请添加图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110251532711.png)
即可自动导入：
![请添加图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110251532102.png)







# [python pip 安装 requirements.txt 报错](https://segmentfault.com/a/1190000040128988)

[![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/2132139767-5c000091a1baa_huge128)**ponponon**](https://segmentfault.com/u/ponponon)发布于 6 月 6 日

[English](https://segmentfault.com/a/1190000040128988/en)

# 错误描述

```bash
pip install requirements.txt 
Defaulting to user installation because normal site-packages is not writeable
ERROR: Could not find a version that satisfies the requirement requirements.txt (from versions: none)
ERROR: No matching distribution found for requirements.txt
vagrant@vagrant:/vagrant$ sudo pip install requirements.txt 
```

# 解决办法

少了 `-r` 参数，换成如下命令

```bash
pip install -r requirements.txt 
```

[![img](https://avatar-static.segmentfault.com/252/177/2521771040-54cb53b372821_small)python](https://segmentfault.com/t/python)

阅读 1.3k发布于 6 月 6 日







