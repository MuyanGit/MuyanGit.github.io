---
title: '   16.如何在csv文件中跳过第一行的python代码  '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-10-25 23:11:51
authorLink:
tags:
keywords:
description:
photos:
---

# txt，xls，xlsx，csv操作



## 1·	xlwt 保存的xlsx无法直接office打开，但是wps可以打开，

```cmd
xlsx 修改格式为xls
```







## 2·如何在csv文件中跳过第一行的python代码

![img](https://csdnimg.cn/release/blogv2/dist/pc/img/original.png)

[今天加油鸭�](https://blog.csdn.net/weixin_44037569) 2021-06-10 18:16:07 ![img](https://csdnimg.cn/release/blogv2/dist/pc/img/articleReadEyes.png) 76 ![img](https://csdnimg.cn/release/blogv2/dist/pc/img/tobarCollect.png) 收藏

文章标签： [python](https://www.csdn.net/tags/MtjaQg4sNDk0LWJsb2cO0O0O.html) [大数据](https://www.csdn.net/tags/MtTaYg5sNzg2NS1ibG9n.html) [人工智能](https://www.csdn.net/tags/MtTaEg3sNzIxMjgtYmxvZwO0O0OO0O0O.html)

版权

我来了我来了，我带着问题回来了~

![img](https://img-blog.csdnimg.cn/20210610181155962.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80NDAzNzU2OQ==,size_16,color_FFFFFF,t_70)

宝们有没有在日常敲代码中发现索引值和数据对不上的问题，产生这个问题的原因是你加了header，它在计算机数据识别中占了一行位置，那么我们应该如何给它变回来呢？

我之前尝试过header=None,index=0，还有巴拉巴拉一大堆都不好使，这里我给大家看一行代码，你只需要在我框框的指定位置添加，名字什么自己对应上就可以完美解决~

![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110252312368.png)

就是这里next(reader)，别看它不起眼，但是真的很好用，前后你们那个名称自己对应一下，一定要改成自己的

![img](https://img-blog.csdnimg.cn/20210610181710208.png)

OK啦完美解决，已经跳过第一行啦嘿嘿嘿~

### 备选方案

```python

import csv
from itertools import islice
with open('表格/2019-04-01.csv', 'r') as read_file:
    reader = csv.reader(read_file)
    for row in islice(reader, 1, None):
        print(row)
```



前言

在做自动化测试时，需要将测试数据存放在excel表格中，读取数据的时候，我们只需要读取非表头的内容即可，那么如何跳过表头读取excel表格中的数据呢？

------

在此，先将excel工作簿以及sheet表格进行封装

```python
import xlrd
class ReadExcel:
    def __init__(self, filename):
        """
        打开文件
        :param filename: 文件路径
        """
        self.wb = xlrd.open_workbook(filename=filename)

    def open_sheet(self, sheet_name):
        """
        根据表格名称打开表格
        :param sheet_name:sheet表格名称
        :return:
        """
        return self.wb.sheet_by_name(sheet_name=sheet_name)
    def operate_sheet(self, sheet_name):
        """
        这里就是读取excel表格的函数，通过下面三种方法读取
        :return:
        """
123456789101112131415161718192021
```

**下面将通过三种方法实现excel跳过表头读取数据（operate_sheet函数）**

#### 一、方法一：普通方法

在读取表格时，条件判断：当行数对应索引为0（索引从0开始，0表示第一行）时，跳过
代码如下（示例）：

```python
    def operate_sheet(self, sheet_name):
        """
        操作表格
        :return:
        """
        sheet = self.open_sheet(sheet_name=sheet_name)
 		# 方法一：（此方法不推荐，效率太低）
        # 2.跳过第一行读取表格
        for i in range(row_num):
            if i==0:
                continue
            print(sheet.row_values(i))
12345678910111213
```

调用operate_sheet函数：

```python
if __name__ == '__main__':
    re = ReadExcel("ZHZX.xlsx") 	# 参数传入你的工作簿（excel文件）路径
    re.operate_sheet("Sheet_zhzx")	# 传入你的sheet表名字
123
```

后续两种方法的调用方法同上，不再展示

![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202110252316817.png)

#### 二、方法二：用range函数

range()函数用法参考菜鸟教程：[pyhton3 range()函数用法](https://www.runoob.com/python3/python3-func-range.html)

代码如下（示例）：

```python
def operate_sheet(self, sheet_name):
        """
        操作表格
        :return:
        """
        sheet = self.open_sheet(sheet_name=sheet_name)
        # 方法二：
        # 2.跳过第一行读取表格（推荐）
        for i in range(1,row_num):
           print(sheet.row_values(i))
12345678910
```

#### 三、方法三：用迭代器切片

需导入islice包

```python
from itertools import islice
1
```

代码如下（示例）：

```python
def operate_sheet(self, sheet_name):
        """
        操作表格
        :return:
        """
        sheet = self.open_sheet(sheet_name=sheet_name)
        # 方法三：
        # 构造迭代器（推荐）
        iter_row_num = iter(range(row_num))
        # 2.跳过第一行读取表格
        for i in islice(iter_row_num,1,None):
            print(sheet.row_values(i))
123456789101112
```

------

总结





#### pandas

https://pandas.pydata.org/pandas-docs/stable/user_guide/io.html

