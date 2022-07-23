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



# 001-SSL报错解决

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

002-引入外部文件

```python
#加载本地from 表单
from time import sleep
from selenium import webdriver
import os

class TestCase(object):
    def __init__(self):
        self.driver = webdriver.Chrome()
        #当前文件所在的路径
        recent_path=os.path.abspath(__file__)
        #当前文件-上级文件夹所在的路径
        path_resource = os.path.dirname(recent_path)
        #selenium引入外部网页的方法
        file_path = 'file:///'+path_resource+'/forms.html'
        print(recent_path+'\n',path_resource+'\n',file_path) 
        self.driver.get(file_path)
    def test_login(self):
        username=self.driver.find_element_by_id('username')
        username.send_keys('admin')
        pwd=self.driver.find_element_by_id('pwd')
        pwd.send_keys('123123')
        
        print(username.get_attribute('value'))
        print(pwd.get_attribute('value'))
        sleep(2)
        self.driver.find_element_by_id('submit').click()
        sleep(2)
        # self.driver.find_element_by_id('submit').click()

if __name__ == '__main__':
    case=TestCase()
    case.test_login()


```





```html
<!-- 本地本地from 表单	-->
<!DOCTYPE html>
<html lang="en" >
<head>
	<meta charset="UTF-8">
	<title>自定义Title</title>
</head>
<body>
<!-- <form> 标签的拼写需要注意-->
<form action="javascript:alert('Hello')">
	<!-- <input> 需要注意id之前不能加上逗号-->
	username:<input type="text" name="username" id="username" placeholder="john"><br>
	password:<input type="password" name="pwd" id="pwd" ><br>
	<input type="submit" name="submit" id="submit">
</form>

</body>

</html>


```

# 002-导入文件与导入类

![image-20220719150845012](C:/Users/HI/AppData/Roaming/Typora/typora-user-images/image-20220719150845012.png)



# 010-#请求头是一个字典格式的

![image-20220714175320373](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20220714175320373.png)





# 知识梳理

## 1·webelement-常用属性.



![image-20220717171740294](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20220717171740294.png)

## 2·  常用方法

### 001-WebElement

![image-20220717171849644](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20220717171849644.png) 



### 002-显式等待方法

![image-20220720160330893](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20220720160330893.png)



![image-20220720160346045](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20220720160346045.png)



### 003-鼠标与键盘事件

![image-20220720173841603](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20220720173841603.png)





# 003-mysql安装

## 001-安装



一、官网下载安装包
 

·    

https://dev.mysql.com/downloads/mysql/

![图片](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/clip_image002.png)

![图片](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/clip_image004.png)

二、解压安装包
 

![图片](C:/Users/HI/AppData/Local/Temp/msohtmlclip1/01/clip_image006.png)

三、打开cmd窗口进入到bin目录



![图片](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/clip_image008.png)

四、初始化数据库
 

·    

mysqld --initialize --console

![图片](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/clip_image010.png)

五、将mysql安装为windows的服务

·    

mysqld -install

![图片](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/clip_image012.png)

![图片](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/clip_image014.png)

六、启动mysql服务
 

·    

net start mysql

![图片](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/clip_image016.jpg)

七、登录数据库，使用之前记录的密码

001-mysql密码明文登陆与修改密码



```bash
#登陆
mysql [-h 主机名] -u用户名 -p密码 [-P端口号] [-D数据库名]

mysql -u root -p5tzpKJePM9:P

#修改密码
alter user 'root'@'localhost' identified by 'Id213123bsdf';
alter user 'root'@'localhost' identified by '想要设置的密码';

```



![image-20220721221430327](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20220721221430327.png)

·    

mysql -u root -p

![图片](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/clip_image018.png)

八、登录成功后修改密码

·    

alter user 'root'@'localhost' identified by '想要设置的密码';





九、连接测试

![图片](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/clip_image020.png)

说明：用Navicat工具连接时，遇到以上报错信息，可根据以下代码解决

·    

·    

·    

·    

select host,user,plugin,authentication_string from mysql.user;ALTER USER 'root'@'localhost' IDENTIFIED BY 'password' PASSWORD EXPIRE NEVER;ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY 'password';FLUSH PRIVILEGES;

![图片](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/clip_image022.jpg)

![图片](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/clip_image024.jpg)

![图片](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/clip_image026.png)







## 002-web搭建-jpres

创建数据库

```bash
mysql> create database  if not exists  se_db ;
Query OK, 1 row affected, 1 warning (0.05 sec)

mysql> create database se_db ;
ERROR 1007 (HY000): Can't create database 'se_db'; database exists
mysql> show databases;
+--------------------+
| Database           |
+--------------------+
| information_schema |
| mysql              |
| performance_schema |
| se_db              |
| sys                |
+--------------------+
5 rows in set (0.00 sec)

mysql>
```



## 003-项目分析

```
需求分析极客本项目将要测试的是一个开源的Java项目,
测试的功能包括:
1. 用户注册: httg://localhost:8080/ jpress/user/register
2. 用P登录: http://localhost:8080/jpress/user/login
3.后台管理员登录: http://localhost:8080/jpress/admin/login
4. 文章分类: http://localhost:8080/jpress/admin/article/category
5. 添加文章: http://localhost:8080/jpress/admin/article/write
本项目通过自动化测试的方法来验证,用户注册、用户登录、管理员登录、添加文章分类、添加文章、信息的完整性、正确性等。例如:必填项、电子邮件的格式、密码是否一致、识别验证码。其中验证码识别是本项目的难点。
```



### 001-测试用例设计



#### 概况

##### 非空、超短、超长、特殊符号、符合审查规则

![image-20220722231101445](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202207222311780.png)

### 002-分层设计

```
项目架构如下
testcases测试用例
data测试数据
logs log日志
config 配置文件
reports测试报告
screenshots截屏
.lib第三方库
```









元素定位

无法被点击的元素-“同意”复选框

![image-20220723090806625](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202207230908692.png)

![image-20220723090754342](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202207230907912.png)













