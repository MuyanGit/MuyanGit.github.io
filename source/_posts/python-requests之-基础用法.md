---
title: ' python requests之 基础用法    '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-11-03 13:48:13
authorLink:
tags:
keywords:
description:
photos: https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202111031353656.png
---



# python requests之 基础用法

![img](https://csdnimg.cn/release/blogv2/dist/pc/img/original.png)

分类专栏： [python进阶](https://blog.csdn.net/weixin_39791387/category_7939836.html) 文章标签： [python](https://www.csdn.net/tags/MtjaQg4sNDk0LWJsb2cO0O0O.html) [requests](https://www.csdn.net/tags/MtTaEg0sMTEzMjItYmxvZwO0O0OO0O0O.html)

版权

[![img](https://img-blog.csdnimg.cn/20201014180756757.png?x-oss-process=image/resize,m_fixed,h_64,w_64)python进阶](https://blog.csdn.net/weixin_39791387/category_7939836.html)专栏收录该内容

56 篇文章2 订阅

订阅专栏

![image-20211103135239916](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202111031352021.png)

![image-20211103135336890](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202111031353987.png)

### 文章目录

- [一. 发送请求的类型](https://blog.csdn.net/weixin_39791387/article/details/100536884#__2)
- [二. GET 传递URL参数](https://blog.csdn.net/weixin_39791387/article/details/100536884#_GET_URL_15)
- [三. 响应内容:](https://blog.csdn.net/weixin_39791387/article/details/100536884#__40)
- - [3.1 文本响应内容及其编码](https://blog.csdn.net/weixin_39791387/article/details/100536884#31__41)
  - [3.2 二进制响应内容(常用)](https://blog.csdn.net/weixin_39791387/article/details/100536884#32__64)
  - [3.3 JSON 响应内容(常用)](https://blog.csdn.net/weixin_39791387/article/details/100536884#33_JSON__76)
  - [3.4 原始响应内容](https://blog.csdn.net/weixin_39791387/article/details/100536884#34__90)
  - [3.5 定制请求头](https://blog.csdn.net/weixin_39791387/article/details/100536884#35__117)
- [四. POST请求](https://blog.csdn.net/weixin_39791387/article/details/100536884#_POST_123)
- - [4.1 数据上传](https://blog.csdn.net/weixin_39791387/article/details/100536884#41__124)
  - [4.2 文件上传](https://blog.csdn.net/weixin_39791387/article/details/100536884#42__179)
  - - [4.2.1 最简单的上传方法](https://blog.csdn.net/weixin_39791387/article/details/100536884#421__182)
    - [4.2.2 显式设置文件名, 文件类型和请求头](https://blog.csdn.net/weixin_39791387/article/details/100536884#422___197)
- [五. 响应状态码](https://blog.csdn.net/weixin_39791387/article/details/100536884#__211)
- [六. 响应头](https://blog.csdn.net/weixin_39791387/article/details/100536884#__231)
- [七. Cookie](https://blog.csdn.net/weixin_39791387/article/details/100536884#_Cookie_243)
- - [7.1 快速访问cookies](https://blog.csdn.net/weixin_39791387/article/details/100536884#71_cookies_244)
  - [7.2 发送cookies到服务器, 使用cookies参数](https://blog.csdn.net/weixin_39791387/article/details/100536884#72_cookies_cookies_251)
  - [7.3 Cookies返回对象](https://blog.csdn.net/weixin_39791387/article/details/100536884#73_Cookies_264)
- [八. 请求超时处理(生产代码必须使用这一参数.)](https://blog.csdn.net/weixin_39791387/article/details/100536884#__275)



> 本文仅供学习参考,建议调试阶段使用, 生产阶段可以使用进阶用法

# 一. 发送请求的类型

- `(***)`表示经常会用到, `(**)` 表示会用到但不经常, `(*)`表示很少用到
- GET 查看 (***)
- POST 增加 (***)
- PUT 修改 (**)
- PATCH 修改(**)
- DELETE 删除 (**)
- HEAD 查看响应头 (*)
- OPTIONS 查看可用请求方法 (*)

```python
requests.[method](url)
1
```

# 二. GET 传递URL参数

```python
In [1]: import requests

In [2]: url = 'http://www.test.com'

In [3]: params = {"key1":"val1", "key2":"val2"}

In [4]: r = requests.get(url, params)

In [5]: r.url
Out[5]: 'https://www.test.com/?key1=val1&key2=val2'

In [6]: params2 = {"key1": "val1", "key2":["v2", "val2"]}
# 最近碰到个问题，极个别接口在get请求的参数params时，若数据类型为dict，则报500，json.dumps()后则200， 将参数名params改为data，也200， 改为json也200. 若采用get(url, params=json.dumps(dict), ) 方案，这样的话，其它接口可能就会400了，最后判断返回是否500，若500 则dumps. 

In [7]: r = requests.get(url,params2)
# 因网址问题,可能会报错

In [8]: r.url
Out[8]: 'https://www.test.com/?key1=val1&key2=v2&key2=val2'

1234567891011121314151617181920
```

> 1. requests.get(url, params={“key1”: “val1”, “key2”: “val2”}), 相当于在url后面拼接一些参数
> 2. `params`参数只在get中使用.

# 三. 响应内容:

## 3.1 文本响应内容及其编码

```python
In [3]: r = requests.get("https://www.baidu.com")

In [4]: r.url
Out[4]: 'https://www.baidu.com/'

In [5]: r.text
Out[5]: '<!DOCTYPE html>\r\n<!--STATUS OK--><html> <head><meta http-equiv=conten
t-type content=text/html;charset=utf-8><meta http-equiv=X-UA-Compatible content=
IE=Edge><meta content=always name=referrer><link rel=stylesheet type=text/css hr
ef=https://ss1.bdstatic.com/5eN1bjq8AAUYm2zgoY3K/r/www/cache/bdorz/baidu.min.css
><title>莽\x99戮氓潞娄盲赂\x80盲赂\x8b茂录\x8c盲陆\xa0氓掳卤莽\x9f楼茅\x81\x93</title></head> <bo
dy link=#0000cc> ... 此处省略几千字...</body> </html>\r\n'

In [6]: r.encoding
Out[6]: 'ISO-8859-1'

In [7]: r.encoding= 'utf-8'

In [9]: r.encoding
Out[9]: 'utf-8'
1234567891011121314151617181920
```

## 3.2 二进制响应内容(常用)

```python
In [23]: r.content
Out[23]: ...省略几千字... 如果r的链接地址是个图片, 可以非常好的作为示例.

In [24]: from PIL import Image

In [25]: from io import BytesIO

In [26]: i = Image.open(BytesIO(r.content))  # 可以作为下载图片或二进制文档的方法

123456789
```

## 3.3 JSON 响应内容(常用)

```python
In [1]: r = requests.get('https://api.github.com/events')

In [2]: r.json()
Out[2]:
[{'id': '13092490355',
  'type': 'PushEvent',
  'actor': {'id': 46406730,
   'login': 'NekoSilverFox
   ...
}]
12345678910
```

## 3.4 原始响应内容

```python
In [1]: r = requests.get('https://api.github.com/events', stream=True) # 可能会报错

In [2]: r.json()
Out[2]:
[{'id': '13092490355',
  'type': 'PushEvent',
  'actor': {'id': 46406730,
   'login': 'NekoSilverFox
   ...
}]

In [3]: r.raw
Out[3]: <urllib3.response.HTTPResponse at 0x1b4c491ddd8>

In [4]: r.raw.read(10)
Out[4]: b''

1234567891011121314151617
```

> 一般情况下使用如下代码替代文件流:

```python
with open(filename, 'wb') as fd:
   for chunk in r.iter_content(chunk_size):
       fd.write(chunk)
123
```

## 3.5 定制请求头

```python
>>> url = 'https://api.github.com/some/endpoint'
>>> headers = {'user-agent': 'my-app/0.0.1'}
>>> r = requests.get(url, headers=headers)
123
```

# 四. POST请求

## 4.1 数据上传

- 格式有以下几种:

1. `requests.post(url, data={"key1": "val1", "key2": "val2"})`
   是将`字典数据`传给`data`参数, 还可以传输`元组列表`, 也可以传`string`(此时需要用json.dumps()处理下).
2. `requests.post(url, json={"key1": "val1", "key2": "val2"})`
   是将`字典数据`传给`json`参数, 会自动编码

> 1. post请求可以 接受 `data`和`json` 两个参数,不接受params
> 2. 若 post请求传参要求是body中raw的格式josn(application/json), 则在post请求参数中添加headers参数, 参数值包含{“Content-Type”: “application/json; charset=UTF-8”}

```python
import requests
headers = {
   "Content-Type": "application/json; charset=UTF-8",
}
resp = requests.post(url, data=(), headers=headers)
12345
# 将字典数据传给data参数
>>> data = {'key1': 'value1', 'key2': 'value2'}
>>> r = requests.post("http://httpbin.org/post", data=data)
>>> print(r.text)
{
  ...
  "form": {
    "key2": "value2",
    "key1": "value1"
  },
  ...
}
# 将元组数据传给data参数
>>> payload = (('key1', 'value1'), ('key1', 'value2'))
>>> r = requests.post('http://httpbin.org/post', data=payload)
>>> print(r.text)
{
  ...
  "form": {
    "key1": [
      "value1",
      "value2"
    ]
  },
  ...
}
# 将json数据传给data参数
>>> import json
>>> url = 'https://api.github.com/some/endpoint'
>>> json_dict = {"some": "data"}
>>> r = requests.post(url, data=json.dumps(payload))

# 将字典数据传给json参数
>>> url = 'https://api.github.com/some/endpoint'
>>> json_dict = {"some": "data"}
>>> r = requests.post(url, json=json_dict)
123456789101112131415161718192021222324252627282930313233343536
```

## 4.2 文件上传

格式如下:
`r = requests.post(url, files={'file': open('report.xls', 'rb')})`

### 4.2.1 最简单的上传方法

```python
>>> url = 'http://httpbin.org/post'
>>> files = {'file': open('report.xls', 'rb')}
>>> r = requests.post(url, files=files)
>>> r.text
{
  ...
  "files": {
    "file": "<censored...binary...data>"
  },
  ...
}

123456789101112
```

### 4.2.2 显式设置文件名, 文件类型和请求头

```python
>>> url = 'http://httpbin.org/post'
>>> files = {'file': ('report.xls', open('report.xls', 'rb'), 'application/vnd.ms-excel', {'Expires': '0'})}
>>> r = requests.post(url, files=files)
>>> r.text
{
  ...
  "files": {
    "file": "<censored...binary...data>"
  },
  ...
}
1234567891011
```

# 五. 响应状态码

```python
>>> r = requests.get('https://www.baidu.com')
>>> r.status_code  # 获取请求状态码
200
>>> r.status_code == requests.codes.ok  # 可以用此来判断是否请求成功
True
>>> bad_r = requests.get("http://httpbin.org/status/404")
>>> bad_r.status_code
404
>>> bad_r.raise_for_status()   # 可以用此来查找 请求错误的原因
Traceback (most recent call last):
  File "<stdin>", line 1, in <module>
  File "D:\Anaconda3\lib\site-packages\requests\models.py", line 940, in raise_for_status
    raise HTTPError(http_error_msg, response=self)
requests.exceptions.HTTPError: 404 Client Error: NOT FOUND for url: http://httpbin.org/sta
tus/404
>>> r.raise_for_status()  # 如果请求成功, 那么没有错误原因的, 所以返回为None.
>>>
1234567891011121314151617
```

# 六. 响应头

```python
>>> r.headers
{'Cache-Control': 'private, no-cache, no-store, proxy-revalidate, no-transform', 'Connecti
on': 'keep-alive', 'Content-Encoding': 'gzip', 'Content-Type': 'text/html', 'Date': 'Mon,
03 Aug 2020 09:15:49 GMT', 'Last-Modified': 'Mon, 23 Jan 2017 13:23:51 GMT', 'Pragma': 'no
-cache', 'Server': 'bfe/1.0.8.18', 'Set-Cookie': 'BDORZ=27315; max-age=86400; domain=.baid
u.com; path=/', 'Transfer-Encoding': 'chunked'}
>>> r.headers.get('content-type')  # 此处get的key大小写不敏感
'text/html'
12345678
```

# 七. Cookie

## 7.1 快速访问cookies

```python
>>> url = 'http://example.com/some/cookie/setting/url'
>>> r = requests.get(url)
>>> r.cookies['example_cookie_name']
'example_cookie_value'
1234
```

## 7.2 发送cookies到服务器, 使用cookies参数

```python
>>> url = 'http://example.com/some/cookie/setting/url'
>>> r = requests.get(url)
>>> r.cookies
<RequestsCookieJar[]>
>>> r.cookies.get('example_cookie_name')
>>> test_cookies = dict(cookes_are='working')
>>> r = requests.get(url, cookies=test_cookies)
>>> r.text
'...省略几千字...'
>>>
12345678910
```

## 7.3 Cookies返回对象

对象为`RequestsCookiesJar`, 和字典非常相似, 也可以将jar传到cookies参数中

```python
>>> jar = requests.cookies.RequestsCookieJar()
>>> jar.set('tasty_cookie', 'yum', domain='httpbin.org', path='/cookies')
>>> jar.set('gross_cookie', 'blech', domain='httpbin.org', path='/elsewhere')
>>> url = 'http://httpbin.org/cookies'
>>> r = requests.get(url, cookies=jar)
>>> r.text
'{"cookies": {"tasty_cookie": "yum"}}'
1234567
```

# 八. 请求超时处理(生产代码必须使用这一参数.)

```python
# 配置超时处理(以下两种方法都可以), 生产代码必须使用这一参数.
requests.get(url, timeout=(3, 7))
requests.get(url, timeout=10)

1234
```



set 限制解除 

[![CSDN首页](https://img-home.csdnimg.cn/images/20201124032511.png)](https://www.csdn.net/)

- [博客](https://blog.csdn.net/)
- [下载](https://download.csdn.net/)
- [问答](https://ask.csdn.net/)
- [社区](https://bbs.csdn.net/)

70%

 搜索





[登入](https://passport.csdn.net/account/login)

# python requests 进阶用法

![img](https://csdnimg.cn/release/blogv2/dist/pc/img/original.png)

分类专栏： [python进阶](https://blog.csdn.net/weixin_39791387/category_7939836.html) 文章标签： [python](https://www.csdn.net/tags/MtjaQg4sNDk0LWJsb2cO0O0O.html) [requests](https://www.csdn.net/tags/MtTaEg0sMTEzMjItYmxvZwO0O0OO0O0O.html)

版权

[![img](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/202111031350603.png)python进阶](https://blog.csdn.net/weixin_39791387/category_7939836.html)专栏收录该内容

56 篇文章2 订阅

订阅专栏



### 文章目录

- [一. 会话对象](https://blog.csdn.net/weixin_39791387/article/details/107769951#__1)
- - [1.1会话对象可以跨请求保持某些参数,](https://blog.csdn.net/weixin_39791387/article/details/107769951#11_2)
  - [1.2 会话可以为请求方法提供缺省数据](https://blog.csdn.net/weixin_39791387/article/details/107769951#12__14)
  - [1.3 参数合并](https://blog.csdn.net/weixin_39791387/article/details/107769951#13__25)
  - [1.4 建议使用的代码方式:上下文管理器](https://blog.csdn.net/weixin_39791387/article/details/107769951#14__37)



# 一. 会话对象

## 1.1会话对象可以跨请求保持某些参数,

会话对象具有requests API的所有方法.

```python
>>> import requests
>>> s = requests.Session()
>>> s.get("http://httpbin.org/cookies/set/sessioncookie/123456789")
<Response [200]>
>>> r = s.get("http://httpbin.org/cookies")
>>> r.text
'{\n  "cookies": {\n    "sessioncookie": "123456789"\n  }\n}\n'
1234567
```

## 1.2 会话可以为请求方法提供缺省数据

```python
>>> s = requests.Session()
>>> s.auth("user", "pass")
	...因为没有真正验证登录, 所以会报错...
>>> s.headers.update({"x-test": "true"})
>>> s.get('http://httpbin.org/headers', headers={'x-test2': 'true'})
<Response [200]>
# 此时x-test 和x-test2 都会被放入请求头中
1234567
```

## 1.3 参数合并

传递给请求方法的字典都会与已设置的会话层数据合并. 方法层的参数覆盖会话的参数. 方法级别的参数不会被跨请求保持

```python
>>> s = requests.Session()
>>> r = s.get('http://httpbin.org/cookies', cookies={'from-my': 'browser'})
>>> r.text
'{\n  "cookies": {\n    "from-my": "browser"\n  }\n}\n'
>>> r = s.get('http://httpbin.org/cookies')
>>> r.text
'{\n  "cookies": {}\n}\n'
>>>
12345678
```

## 1.4 建议使用的代码方式:上下文管理器

```python
with requests.Session() as s:
    s.get('http://httpbin.org/cookies/set/sessioncookie/123456789')

# 若是在测试环境中, 不知道将来用get post,可以这么写
with requests.Session() as s:
	resp = s.request(method="get|post", url=url)

# 不知道返回值是什么的情况下，可以通过content_type来判断返回值类型
content_type = ["application/json", "application/stream", "text/explain"]

12345678910
```

未完待续…



 

# python常用

```cmd


1，多引用类库
2，数据结构位置
3，尽量减少使用for
4、避免使用全局变量
5、增加列表推导式（List Comprehension）list.apend
6、用xrange()替换range()
7、使用生成器（Generators）生成器以块计算数据。
8、用Join连接字符串串 i

```

set 限制解除 

# python笔记——split()函数详解



## **一、split()**

------

1. 语法

- str.split(str="", num=string.count(str))

1. 参数

- str 分隔符，默认为所有的空字符，包括空格、换行(\n)、制表符(\t)等。
- num – 分割次数。默认为 -1, 即分隔所有。
- 注意：当使用**空格作为分隔符时，对于中间为空的项会自动忽略**

1. 例子

```python
>>> str = "Line1-abcdef \nLine2-abc Line4-abcd"
>>> print(str.split())
['Line1-abcdef', 'Line2-abc', 'Line4-abcd']   ##不仅自动识别了换行符(\n)、还识别了空格（ ）
123
>>> str = "Line1-abcdef \nLine2-abc Line4-abcd"
>>> (a,b,c) = str.split()
>>> print(a)
>>> print(b)
>>> print(c)
Line1-abcdef
Line2-abc
Line4-abcd                    ### 如果在知道分割后的个数，可直接赋值
12345678
>>> str="hello boy<[www.baidu.com]>byebye"
>>> print(str.split("[")[1].split("]")[0])
www.baidu.com                  ###骚操作，用到的时候回来看下
123
```

## 二、os.path.split()

------

1. 语法

- os.path.split(‘PATH’)

1. 参数

- 如果PATH传入的是一个目录和文件名，则输出路径和文件名
- 如果给出的是一个目录名，则输出路径和为空文件名

1. 例子

```python
>>> import os
>>> file_path = "E:\\desktop\\cangjie.avi"
>>> print(os.path.split(file_path))
('E:\\desktop', 'cangjie.avi')
1234
```



 
