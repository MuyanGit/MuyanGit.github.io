---
title: ' 5行Python代码实现批量打水印技巧，值得收藏    '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-10-20 02:53:45
authorLink:
tags:
keywords:
description:
photos: https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/1880991-20200512175821075-1753638122.jpg
---

# [5行Python代码实现批量打水印技巧，值得收藏](https://www.cnblogs.com/chengxuyuanaa/p/12877728.html)

工作的时候，尤其是自媒体，我们必备水印添加[工具](https://pythondict.com/tag/tools/)以保护我们的知识产权，网上有许多的在线 / 下载的水印添加工具，但他们或多或少都存在以下问题：

1. 在线[工具](https://pythondict.com/tag/tools/)需要上传到对方服务器，信息不安全。
2. 很多[工具](https://pythondict.com/tag/tools/)不具备批量处理功能。
3. 很多[工具](https://pythondict.com/tag/tools/)自定义的功能太少，如水印透明度，字体等。
4. 操作繁琐。
   ![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/1880991-20200512175821075-1753638122.jpg)
   **这里还要注意：**光理论是不够的。这里顺便总大家一套2020最新python入门到高级项目实战视频教程，可以去小编的Python交流.裙 ：七衣衣九七七巴而五（数字的谐音)转换下可以找到了，还可以跟老司机交流讨教！

现在只要你会使用命令，我们就能教大家怎么使用 [Python 超级简单地为图片添加水印](https://pythondict.com/life-intelligent/tools/python-easy-batch-add-watermark/)，而且具备以下特点：

1. 支持自定义水印字体。
2. 支持自定义文本内容、颜色。
3. 支持批量处理。
4. 支持设定水印与水印之间的空间。
5. 支持设定水印字体大小。
6. 支持设定透明度。
7. 自己的代码，安全。

是不是超棒，已经具备你所需要的所有功能了 ？ 下面进入正题。

我们需要使用的是 2Dou 的开源项目：
[github.com/2Dou/watermarker](https://github.com/2Dou/watermarker)
非常有用的开源项目，感谢原作者。

有三种方法可以下载这个项目：

1. 如果你那边的网络可以上 github，你可以进入该页面，点击 clone or download 然后点击 Download Zip.

2. 如果你有下载

    

   git

   ，可以用 cmd/terminal 进入你想放置的文件夹，输入命令:

   ```python
   git clone https://github.com/2Dou/watermarker.git.
       
   ```

   terminal位置如下：

   <img src="D:/MyBackup/%25E7%25BB%25BC%25E5%2590%2588%25E5%25A4%2587%25E4%25BB%25BD/%25E5%25AD%25A6%25E4%25B9%25A0/%25E7%25AC%2594%25E8%25AE%25B0%25E6%259C%25AC/vscode/python%25E5%258E%25BB%25E9%2599%25A4%25E6%25B0%25B4%25E5%258D%25B0-%25E7%25A8%258B%25E5%25BA%258F%25E5%2591%2598%25E7%259A%2584%25E4%25BA%25BA%25E7%2594%259FA.assets/image-20210610110728525.png" alt="image-20210610110728525" style="zoom:33%;" />

3. 如果你都没有，则下载本站为你提供的源代码，而且修复了一个 windows 下的字体文件为中文的问题（后面会为大家详细介绍），[点击下载](https://pythondict.com/wp-content/uploads/2019/08/2019082413105661.zip)

下载解压到你想要放置的任意一个文件夹下。路径中最好不要带中文名，如果你是用前两种方法下载的，而且是 windows 系统用户，注意要把该项目的字体文件名改为英文，而且 marker.py 里也有一个地方需要改动，如下:

 

[![img](https://cdn.learnku.com/uploads/images/202005/07/50651/k66MgBqcTI.png!large)](https://cdn.learnku.com/uploads/images/202005/07/50651/k66MgBqcTI.png!large)

 

 

将 font 文件夹里的 青鸟华光简琥珀.ttf 改为 bird.ttf， 什么名字不重要，重点是不要用中文名，否则 [pillow](https://pythondict.com/tag/pillow/) 会无法使用改文件。注意 marker.py 文件里的第十行要改成相应的名字，与 font 文件夹下的字体文件名相对应。

刚刚我们提到了 [pillow](https://pythondict.com/tag/pillow/) 这个[库](https://pythondict.com/tag/库/)，这个包的运行需要使用到这个第三方[库](https://pythondict.com/tag/库/)，它是专门用来处理[图像](https://pythondict.com/tag/images/)的，打开 CMD/Terminal, 输入以下命令即可安装：

```python
pip install [pillow](https://pythondict.com/tag/pillow/ "pillow")
```

安装完毕后，我们就可以试一下了！最普通的例子如下，将你所需要加水印的图片放在该项目的 input 文件夹下，然后在 cmd/Terminal 中进入你存放该项目的文件夹输入以下命令：

```python
python marker.py -f ./input/baby.jpg -m python实用宝典
```

各个参数的含义如下：

-f 文件路径：是你的图片的路径
-m 文本内容：是你想要打的水印的内容

其他参数不设置则为默认值，运行完毕后会在 output 文件夹下出现相应的加了水印的图片，效果如下：

 

[![img](https://cdn.learnku.com/uploads/images/202005/07/50651/a7OrVczfvg.jpeg!large)](https://cdn.learnku.com/uploads/images/202005/07/50651/a7OrVczfvg.jpeg!large)

 

 

添加水印

默认水印的颜色是… 屎黄色的？但是没关系，我们可以修改它的颜色，添加 - c 参数即可！（参数默认格式为 #号后加 6 位 16 进制），利用图像工具，我们可以找到你喜欢的颜色的值：

 

[![img](https://cdn.learnku.com/uploads/images/202005/07/50651/AhTK3RDSBQ.jpeg!large)](https://cdn.learnku.com/uploads/images/202005/07/50651/AhTK3RDSBQ.jpeg!large)

 

 

找出颜色

然后我们输入命令：

```python
python marker.py -f ./input/baby.jpg -m python实用宝典 -c #232862
```

看看效果：

 

[![img](https://cdn.learnku.com/uploads/images/202005/07/50651/6TbpwGhpbI.jpeg!large)](https://cdn.learnku.com/uploads/images/202005/07/50651/6TbpwGhpbI.jpeg!large)

 

 

修改颜色

恩！变好看了，但是好像水印的颜色有点深，我们可以修改一下透明度让它变浅一点，默认的透明度为 0.15，可以让这个值变得更小，设定 opacity 参数：

```python
python marker.py -f ./input/baby.jpg -m python实用宝典 -c #232862 --opacity 0.08
```

结果如下：

 

[![img](https://cdn.learnku.com/uploads/images/202005/07/50651/Vd1LFNmqFY.jpeg!large)](https://cdn.learnku.com/uploads/images/202005/07/50651/Vd1LFNmqFY.jpeg!large)

 

 

变更透明

其实还有其他参数可以，我们就不一一展示了，一共有这些参数：

1. -f 参数，指定打水印的文件，如果你想打印整个文件夹，则输入该文件夹路径即可。
2. -m 参数，指定水印内容。
3. -o 参数，指定输出水印文件的位置，默认为 output 文件夹。
4. -c 参数，指定水印的颜色，默认值为 shi.. 啊不，黄色，#8B8B1B.
5. -s 参数，指定水印与水印之间的空隙，默认值为 75.
6. -a 参数，指定水印的旋转角度，我们的例子中都是默认值 30 度。
7. –size 参数，指定水印文本字体大小，默认值为 50。
8. –opacity 参数，指定透明度，默认为 0.15，数值越小越透明。

接下来给大家试试批量处理功能，首先把所有图片放置到项目的 input 文件夹下：

 

[![img](https://cdn.learnku.com/uploads/images/202005/07/50651/tI7opcJmye.jpeg!large)](https://cdn.learnku.com/uploads/images/202005/07/50651/tI7opcJmye.jpeg!large)

 

 

放到 input 下

然后输入命令里，指定文件夹即可！

```python
python marker.py -f ./input -m python实用宝典 -c #232862 --opacity 0.05
```

你会看到 input 文件夹名后没有 /baby.jpg 了，这表明将 input 文件夹下所有的图片打水印。

 

[![img](https://cdn.learnku.com/uploads/images/202005/07/50651/iJJFyTNGWm.jpeg!large)](https://cdn.learnku.com/uploads/images/202005/07/50651/iJJFyTNGWm.jpeg!large)

 

 

看到文件名 succes 则说明批处理成功！

还有一个隐藏功能！如果你想要修改字体也可以哦！还记得我们前面怎么修复 windows 的中文名问题吗？如图，你只要将新的字体文件放到 font 文件夹下，然后修改 TTF_FONT 变量里的字体名字，与 font 文件夹下的新字体名字相对应即可改成你想要的字体了！

 

[![img](https://cdn.learnku.com/uploads/images/202005/07/50651/k66MgBqcTI.png!large)](https://cdn.learnku.com/uploads/images/202005/07/50651/k66MgBqcTI.png!large)

 都会了吧？**最后注意：**光理论是不够的。这里顺便总大家一套2020最新python入门到高级项目实战视频教程，可以去小编的Python交流.裙 ：七衣衣九七七巴而五（数字的谐音）转换下可以找到了，还可以跟老司机交流讨教！

