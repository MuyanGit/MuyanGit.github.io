title: Selenium自动化测试实战web高级测试
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2022-07-15 17:28:24
authorAbout:
series:
tags:
keywords:
description:
photos: https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20220621204230994.png
---



# SSL报错解决

## 1·忽略SSL与证书

## 2·http加上s--> https  或者  移除https中的s--> http

```
from selenium import webdriver
from time import sleep

#   http://sahitest.com/demo/
class  TestCase(object):
    def __init__(self):

        #方法1--> 忽略证书以及ssl问题
        # options = webdriver.ChromeOptions()
        # #这2个方法是通过设置浏览器忽略这些证书错误，使得IDE不报错 ……
        # #网上也没有找到其他的解决方法，因为是SSL问题导致的，
        # # 而Https = http +ssl,所以我尝试通过http协议访问网站，发现不会报错
        # options.add_argument('-ignore-certificate-errors')
        # options.add_argument('-ignore -ssl-errors')
        # driver = webdriver.Chrome(chrome_options = options)、

        # 方法2--> ssl出问题可以加上s变为--> https
        self.driver = webdriver.Chrome()
        # self.driver.get('http://sahitest.com/')
        self.driver.get('https://sahitest.com/demo/linkTest.htm')
    def test_webelement_prop(self):
        e=self.driver.find_element_by_id('t1')
        print(type(e))
        print(e.id)
        print(e.tag_name)
        print(e.size)
        print(e.rect)
        print(e.text)


#   http://sahitest.com/demo/
class  TestCase_ignore(object):
    def __init__(self):

        # # 方法1--> 忽略证书以及ssl问题
        options = webdriver.ChromeOptions()
        #这2个方法是通过设置浏览器忽略这些证书错误，使得IDE不报错 ……
        #网上也没有找到其他的解决方法，因为是SSL问题导致的，
        # 而Https = http +ssl,所以我尝试通过http协议访问网站，发现不会报错
        options.add_argument('-ignore-certificate-errors')
        options.add_argument('-ignore -ssl-errors')
        self.driver = webdriver.Chrome(chrome_options = options)

        # # 方法2--> ssl出问题可以加上s变为--> https
        # self.driver = webdriver.Chrome()
        # # self.driver.get('http://sahitest.com/')
        self.driver.get('https://sahitest.com/demo/linkTest.htm')
    def test_webelement_prop(self):
        e=self.driver.find_element_by_id('t1')
        print(type(e))
        print(e.id)
        print(e.tag_name)
        print(e.size)
        print(e.rect)
        print(e.text)

if __name__ == '__main__':
    case=TestCase()
    case.test_webelement_prop()

    case=TestCase_ignore()
    case.test_webelement_prop()
```

# 知识梳理

## 1·webelement-常用属性



![image-20220717171740294](C:/Users/HI/AppData/Roaming/Typora/typora-user-images/image-20220717171740294.png)

## 2·  常用方法

![image-20220717171849644](C:/Users/HI/AppData/Roaming/Typora/typora-user-images/image-20220717171849644.png) 





#请求头是一个字典格式的

![image-20220714175320373](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20220714175320373.png)

```


```



