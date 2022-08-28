---
title: >-
  Pyinstaller打包Python代码为.exe，多个.py文件和多模块打包_Ethan的博客-程序员宅基地_pyinstaller打包多个py文件     
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-10-23 05:15:26
authorLink:
tags:
keywords:
description:
photos:
---

## Pyinstaller打包Python代码为.exe，多个.py文件和多模块打包_Ethan的博客-程序员宅基地_pyinstaller打包多个py文件

技术标签： [Pyinstaller打包教程](https://www.cxyzjd.com/searchArticle?qc=Pyinstaller打包教程&page=1) 

**文件结构**test[entrance.py](http://entrance.py/)[clip.py](http://clip.py/)[data.py](http://data.py/)unet.dbaccd.xmlreason.csv**多个.py文件和多个打包命令格式如下：**

`pyinstaller [主文件] -p [其他文件1] -p [其他文件2] --hidden-import [自建模块1] --hidden-import [自建模块2] 

**根据上面的文件结构打包命令如下**

`pyinstaller -F entrance.py -p clip.py -p data.py --hidden-import clip --hidden-import data `

**注意：**其中entrance.py是主程序入口文件，其他.py文件是自建模块，需要在主文件中使用，仅打包.py文件其余依赖项只需在打包完成后，将它们放在打包后生成的.exe文件的同一个目录下即可

![image-20211023051700876](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110230517724.png)

![image-20211023051633817](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110230517148.png)





