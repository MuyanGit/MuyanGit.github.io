title: Python中内置的日志模块logging用法详解
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2022-01-22 03:05:57
authorAbout:
series:
tags:
keywords:
description:

photos:
---





# Python中内置的日志模块logging用法详解

2021-11-30阅读 1.8K0

*交流、咨询，有疑问欢迎添加QQ 2125364717，一起交流、一起发现问题、一起进步啊，哈哈哈哈哈*







**logging模块简介**

Python的logging模块提供了通用的日志系统，可以方便第三方模块或者是应用使用。这个模块提供不同的日志级别，并可以采用不同的方式记录日志，比如文件，HTTP GET/POST，SMTP，Socket等，甚至可以自己实现具体的日志记录方式。logging模块与log4j的机制是一样的，只是具体的实现细节不同。模块提供logger，handler，filter，formatter。

- logger：提供日志接口，供应用代码使用。logger最长用的操作有两类：配置和发送日志消息。可以通过logging.getLogger(name)获取logger对象，如果不指定name则返回root对象，多次使用相同的name调用getLogger方法返回同一个logger对象。
- handler：将日志记录（log record）发送到合适的目的地（destination），比如文件，socket等。一个logger对象可以通过addHandler方法添加0到多个handler，每个handler又可以定义不同日志级别，以实现日志分级过滤显示。
-  filter：提供一种优雅的方式决定一个日志记录是否发送到handler。
-  formatter：指定日志记录输出的具体格式。formatter的构造方法需要两个参数：消息的格式字符串和日期字符串，这两个参数都是可选的。

与log4j类似，logger，handler和日志消息的调用可以有具体的日志级别（Level），只有在日志消息的级别大于logger和handler的级别。

**logging用法解析**

\1. 初始化 logger = logging.getLogger("endlesscode")，getLogger()方法后面最好加上所要日志记录的模块名字，后面的日志格式中的%(name)s 对应的是这里的模块名字 2. 设置级别 logger.setLevel(logging.DEBUG),Logging中有NOTSET < DEBUG < INFO < WARNING < ERROR < CRITICAL这几种级别，日志会记录设置级别以上的日志 3. Handler，常用的是StreamHandler和FileHandler，windows下你可以简单理解为一个是console和文件日志，一个打印在CMD窗口上，一个记录在一个文件上

\4. formatter，定义了最终log信息的顺序,结构和内容，我喜欢用这样的格式 '[%(asctime)s] [%(levelname)s] %(message)s', '%Y-%m-%d %H:%M:%S'，

- %(name)s Logger的名字
- %(levelname)s 文本形式的日志级别
- %(message)s 用户输出的消息
- %(asctime)s 字符串形式的当前时间。默认格式是 “2003-07-08 16:49:45,896”。逗号后面的是毫秒
- %(levelno)s 数字形式的日志级别
- %(pathname)s 调用日志输出函数的模块的完整路径名，可能没有
- %(filename)s 调用日志输出函数的模块的文件名
- %(module)s  调用日志输出函数的模块名
- %(funcName)s 调用日志输出函数的函数名
- %(lineno)d 调用日志输出函数的语句所在的代码行
- %(created)f 当前时间，用UNIX标准的表示时间的浮 点数表示
- %(relativeCreated)d 输出日志信息时的，自Logger创建以 来的毫秒数
- %(thread)d 线程ID。可能没有
- %(threadName)s 线程名。可能没有
- %(process)d 进程ID。可能没有

\5. 记录 使用object.debug(message)来记录日志 下面来写一个实例，在CMD窗口上只打出error以上级别的日志，但是在日志中打出debug以上的信息

```javascript
import logging
logger = logging.getLogger("simple_example")
logger.setLevel(logging.DEBUG)
# 建立一个filehandler来把日志记录在文件里，级别为debug以上
fh = logging.FileHandler("spam.log")
fh.setLevel(logging.DEBUG)
# 建立一个streamhandler来把日志打在CMD窗口上，级别为error以上
ch = logging.StreamHandler()
ch.setLevel(logging.ERROR)
# 设置日志格式
formatter = logging.Formatter("%(asctime)s - %(name)s - %(levelname)s - %(message)s")
ch.setFormatter(formatter)
fh.setFormatter(formatter)
#将相应的handler添加在logger对象中
logger.addHandler(ch)
logger.addHandler(fh)
# 开始打日志
logger.debug("debug message")
logger.info("info message")
logger.warn("warn message")
logger.error("error message")
logger.critical("critical message")
```

运行一下将会看到CMD窗口只记录两条，spam.log中记录了五条日志

![img](https://ask.qcloudimg.com/http-save/yehe-4464657/1f459fwtz7.png?imageView2/2/w/1620)

当一个项目比较大的时候，不同的文件中都要用到Log,可以考虑将其封装为一个类来使用

```javascript
#! /usr/bin/env python
#coding=gbk
import logging,os
 
class Logger:
 def __init__(self, path,clevel = logging.DEBUG,Flevel = logging.DEBUG):
  self.logger = logging.getLogger(path)
  self.logger.setLevel(logging.DEBUG)
  fmt = logging.Formatter('[%(asctime)s] [%(levelname)s] %(message)s', '%Y-%m-%d %H:%M:%S')
  #设置CMD日志
  sh = logging.StreamHandler()
  sh.setFormatter(fmt)
  sh.setLevel(clevel)
  #设置文件日志
  fh = logging.FileHandler(path)
  fh.setFormatter(fmt)
  fh.setLevel(Flevel)
  self.logger.addHandler(sh)
  self.logger.addHandler(fh)
 
 def debug(self,message):
  self.logger.debug(message)
 
 def info(self,message):
  self.logger.info(message)
 
 def war(self,message):
  self.logger.warn(message)
 
 def error(self,message):
  self.logger.error(message)
 
 def cri(self,message):
  self.logger.critical(message)
 
if __name__ =='__main__':
 logyyx = Logger('yyx.log',logging.ERROR,logging.DEBUG)
 logyyx.debug('一个debug信息')
 logyyx.info('一个info信息')
 logyyx.war('一个warning信息')
 logyyx.error('一个error信息')
 logyyx.cri('一个致命critical信息')
```

这样每次使用的时候只要实例化一个对象就可以了

```javascript
logobj = Logger(‘filename',clevel,Flevel)
```

如果想在CMD窗口中对于error的日志标红，warning的日志标黄，那么可以使用ctypes模块

![img](https://ask.qcloudimg.com/http-save/yehe-4464657/tduv3lj9wi.png?imageView2/2/w/1620)

```javascript
#! /usr/bin/env python
#coding=gbk
import logging,os
import ctypes
 
FOREGROUND_WHITE = 0x0007
FOREGROUND_BLUE = 0x01 # text color contains blue.
FOREGROUND_GREEN= 0x02 # text color contains green.
FOREGROUND_RED = 0x04 # text color contains red.
FOREGROUND_YELLOW = FOREGROUND_RED | FOREGROUND_GREEN
 
STD_OUTPUT_HANDLE= -11
std_out_handle = ctypes.windll.kernel32.GetStdHandle(STD_OUTPUT_HANDLE)
def set_color(color, handle=std_out_handle):
 bool = ctypes.windll.kernel32.SetConsoleTextAttribute(handle, color)
 return bool
 
class Logger:
 def __init__(self, path,clevel = logging.DEBUG,Fself.logger.critical(message)level = logging.DEBUG):
  self.logger = logging.getLogger(path)
  self.logger.setLevel(logging.DEBUG)
  fmt = logging.Formatter('[%(asctime)s] [%(levelname)s] %(message)s', '%Y-%m-%d %H:%M:%S')
  #设置CMD日志
  sh = logging.StreamHandler()
  sh.setFormatter(fmt)
  sh.setLevel(clevel)
  #设置文件日志
  fh = logging.FileHandler(path)
  fh.setFormatter(fmt)
  fh.setLevel(Flevel)
  self.logger.addHandler(sh)
  self.logger.addHandler(fh)
 
 def debug(self,message):
  self.logger.debug(message)
 
 def info(self,message):
  self.logger.info(message)
 
 def war(self,message,color=FOREGROUND_YELLOW):
  set_color(color)
  self.logger.warn(message)
  set_color(FOREGROUND_WHITE)
 
 def error(self,message,color=FOREGROUND_RED):
  set_color(color)
  self.logger.error(message)
  set_color(FOREGROUND_WHITE)
 
 def cri(self,message):
  self.logger.critical(message)
 
if __name__ =='__main__':
 logyyx = Logger('yyx.log',logging.WARNING,logging.DEBUG)
 logyyx.debug('一个debug信息')
 logyyx.info('一个info信息')
 logyyx.war('一个warning信息')
 logyyx.error('一个error信息')
 logyyx.cri('一个致命critical信息')
```

**多模块使用logging** logging模块保证在同一个python解释器内，多次调用logging.getLogger('log_name')都会返回同一个logger实例，即使是在多个模块的情况下。所以典型的多模块场景下使用logging的方式是在main模块中配置logging，这个配置会作用于多个的子模块，然后在其他模块中直接通过getLogger获取Logger对象即可。

配置文件： 

```javascript
[loggers] 
keys=root,main 
  
[handlers] 
keys=consoleHandler,fileHandler 
  
[formatters] 
keys=fmt 
  
[logger_root] 
level=DEBUG 
handlers=consoleHandler 
  
[logger_main] 
level=DEBUG 
qualname=main 
handlers=fileHandler 
  
[handler_consoleHandler] 
class=StreamHandler 
level=DEBUG 
formatter=fmt 
args=(sys.stdout,) 
  
[handler_fileHandler] 
class=logging.handlers.RotatingFileHandler 
level=DEBUG 
formatter=fmt 
args=('tst.log','a',20000,5,) 
  
[formatter_fmt] 
format=%(asctime)s - %(name)s - %(levelname)s - %(message)s 
datefmt= 
```

主模块main.py：

```javascript
import logging 
import logging.config 
  
logging.config.fileConfig('logging.conf') 
root_logger = logging.getLogger('root') 
root_logger.debug('test root logger...') 
  
logger = logging.getLogger('main') 
logger.info('test main logger') 
logger.info('start import module \'mod\'...') 
import mod 
  
logger.debug('let\'s test mod.testLogger()') 
mod.testLogger() 
  
root_logger.info('finish test...') 
```

子模块mod.py：

```javascript
import logging 
import submod 
  
logger = logging.getLogger('main.mod') 
logger.info('logger of mod say something...') 
  
def testLogger(): 
  logger.debug('this is mod.testLogger...') 
  submod.tst() 
```

子子模块submod.py：

```javascript
import logging 
  
logger = logging.getLogger('main.mod.submod') 
logger.info('logger of submod say something...') 
  
def tst(): 
  logger.info('this is submod.tst()...') 
```

然后运行python main.py，控制台输出：

```javascript
2012-03-09 18:22:22,793 - root - DEBUG - test root logger... 
2012-03-09 18:22:22,793 - main - INFO - test main logger 
2012-03-09 18:22:22,809 - main - INFO - start import module 'mod'... 
2012-03-09 18:22:22,809 - main.mod.submod - INFO - logger of submod say something... 
2012-03-09 18:22:22,809 - main.mod - INFO - logger say something... 
2012-03-09 18:22:22,809 - main - DEBUG - let's test mod.testLogger() 
2012-03-09 18:22:22,825 - main.mod - DEBUG - this is mod.testLogger... 
2012-03-09 18:22:22,825 - main.mod.submod - INFO - this is submod.tst()... 
2012-03-09 18:22:22,841 - root - INFO - finish test... 
```

可以看出，和预想的一样，然后在看一下tst.log，logger配置中的输出的目的地：

```javascript
2012-03-09 18:22:22,793 - main - INFO - test main logger 
2012-03-09 18:22:22,809 - main - INFO - start import module 'mod'... 
2012-03-09 18:22:22,809 - main.mod.submod - INFO - logger of submod say something... 
2012-03-09 18:22:22,809 - main.mod - INFO - logger say something... 
2012-03-09 18:22:22,809 - main - DEBUG - let's test mod.testLogger() 
2012-03-09 18:22:22,825 - main.mod - DEBUG - this is mod.testLogger... 
2012-03-09 18:22:22,825 - main.mod.submod - INFO - this is submod.tst()... 
```

tst.log中没有root logger输出的信息，因为logging.conf中配置了只有main logger及其子logger使用RotatingFileHandler，而root logger是输出到标准输出。

本文参与[腾讯云自媒体分享计划](https://cloud.tencent.com/developer/support-plan)，欢迎正在阅读的你也加入，一起分享。

[Android](https://cloud.tencent.com/developer/tag/10216?entry=article)[Python](https://cloud.tencent.com/developer/tag/10169?entry=article)[命令行工具](https://cloud.tencent.com/developer/tag/10387?entry=article)[日志服务](https://cloud.tencent.com/developer/tag/10370?entry=article)

[举报](javascript:;)

点赞 2分享

### 我来说





# python 日志 logging 模块详解

 原创

[wx60dc8ce39e154](https://blog.51cto.com/u_15290941)2021-07-12 14:13:42©著作权

*文章标签*[python](https://blog.51cto.com/topic/python-2.html)*文章分类*[Python](https://blog.51cto.com/nav/python)[编程语言](https://blog.51cto.com/nav/program)*阅读数*133



### 文章目录

- [ 1 日志相关概念](https://blog.51cto.com/u_15290941/3047223#1__1)
- - [ 1.1 日志的作用](https://blog.51cto.com/u_15290941/3047223#11__2)
  - [ 1.2 日志的等级](https://blog.51cto.com/u_15290941/3047223#12__8)
  - [ 1.3 logging 模块两种使用方式](https://blog.51cto.com/u_15290941/3047223#13_logging__18)
- [ 2 使用 logging 提供的模块级别的函数](https://blog.51cto.com/u_15290941/3047223#2__logging__22)
- - [ 2.1 logging 模块定义常用函数](https://blog.51cto.com/u_15290941/3047223#21_logging__23)
  - [ 2.2 使用方式1：简单配置](https://blog.51cto.com/u_15290941/3047223#22_1_36)
  - [ 2.3 使用方式2：使用 logging.basicConfig() 函数](https://blog.51cto.com/u_15290941/3047223#23_2_loggingbasicConfig__58)
- [ 3 使用 Logging 日志系统的四大组件](https://blog.51cto.com/u_15290941/3047223#3__Logging__131)
- - [ 3.1 Logger 类](https://blog.51cto.com/u_15290941/3047223#31_Logger__159)
  - [ 3.2 Handler 类](https://blog.51cto.com/u_15290941/3047223#32_Handler__193)
  - [ 3.3 Formater 类](https://blog.51cto.com/u_15290941/3047223#33_Formater__212)
  - [ 3.4 Filter类（了解即可）](https://blog.51cto.com/u_15290941/3047223#34_Filter_227)
  - [ 3.5 日志流处理简要流程](https://blog.51cto.com/u_15290941/3047223#35__238)



1 日志相关概念

## 1.1 日志的作用

- 程序调试
- 了解程序运行是否正常
- 故障分析与问题定位
- 用户行为分析

## 1.2 日志的等级

| 等级     | 含义                                                         |
| -------- | ------------------------------------------------------------ |
| DEBUG    | 最详细的日志信息，典型应用场景是问题诊断                     |
| INFO     | 信息详细程度仅次于 DEBUG，通常只记录关键节点信息，用于确认一切都是按照我们预期的那样进行工作 |
| WARNING  | 当某些不期望的事情发生时记录的信息（如，磁盘可用空间较低），但是此时应用程序还是正常运行的 |
| ERROR    | 由于一个更严重的问题导致某些功能不能正常运行时记录的信       |
| CRITICAL | 当发生严重错误，导致应用程序不能继续运行时记录的信息         |

默认情况下，logging 模块将等级为 WARNING 及其以上的日志信息打印到控制台

## 1.3 logging 模块两种使用方式

logging 模块有两种使用方式

- 第一种方式是使用 logging 提供的模块级别的函数
- 第二种方式是使用 Logging 日志系统的四大组件

2 使用 logging 提供的模块级别的函数

## 2.1 logging 模块定义常用函数

| 函数                                 | 说明                                   |
| ------------------------------------ | -------------------------------------- |
| logging.debug(msg,*args,**kwargs)    | 创建一条严重级别为 DEBUG 的日志记录    |
| logging.info(msg,*args,*kwargs)      | 创建一条严重级别为 INFO 的日志记录     |
| logging.warning(msg,*args,*kwargs)   | 创建一条严重级别为 WARNING 的日志记录  |
| logging.error(msg,*args,*kwargs)     | 创建一条严重级别为 ERROR 的日志记录    |
| logging.critical(msg,*args,**kwargs) | 创建一条严重级别为 CRITICAL 的日志记录 |
| logging.log(level,*args,*kwargs)     | 创建一条严重级别为 level 的日志记录    |
| logging.basicConfig(**kwargs)        | 对 root logger 进行一次性配置          |

下面进行使用演示：

## 2.2 使用方式1：简单配置

```python
import logging

logging.debug("debug message")
logging.info("info message")
logging.warning("warning message")
logging.error("error message")
logging.critical("critical message")
logging.log(level=logging.ERROR, msg = "error in logging.log function")
1.2.3.4.5.6.7.8.
```

输出结果：

```python
WARNING:root:warning message
ERROR:root:error message
CRITICAL:root:critical message
ERROR:root:error in logging.log function
1.2.3.4.
```

默认情况下 logging 模块将日志打印到了标准输出中，且只显示大于等于 WARNING 级别的日志，这说明默认的日志级别设置为 WARNING（日志级别等级 CRITICAL > ERROR > WARNING > INFO > DEBUG）

## 2.3 使用方式2：使用 logging.basicConfig() 函数

使用 logging.basicConfig() 函数可以调整日志级别、输出格式等

logging.basicConfig() 函数说明

| 参数名   | 描述                                                         |
| -------- | ------------------------------------------------------------ |
| filename | 指定日志输出目标文件的文件名，指定该设置项后日志信息就不会被输出到控制台了 |
| format   | 指定日志格式字符串，即指定日志输出时所包含的字段信息以及它们的顺序。logging 模块定义的格式字段下面会列出。 |
| datefmt  | 指定日期/时间格式。需要注意的是，该选项要在 format 中包含时间字段 %(asctime)s 时才有效 |
| level    | 指定日志器的日志级别                                         |
| stream   | 指定日志输出目标 stream，如 sys.stdout、sys.stderr 以及网络 stream。需要说明的是，stream 和 filename 不能同时提供，否则会引发 ValueError 异常 |
| style    | Python3.2 中新添加的配置项。指定 format 格式字符串的风格，可取值为 ‘%’、’{’ 和 ‘$’，默认为 ‘%’ |
| handlers | Python 3.3 中新添加的配置项。该选项如果被指定，它应该是一个创建了多个 Handler 的可迭代对象，这些 handler 将会被添加到 rootlogger。需要说明的是：filename、stream 和 handlers 这三个配置项只能有一个存在，不能同时出现 2 个或 3 个，否则会引发 ValueError 异常。 |

logging 模块的格式字符串

| 字段/属性名称   | 使用格式            | 描述                                                         |
| --------------- | ------------------- | ------------------------------------------------------------ |
| asctime         | %(asctime)s         | 日志事件发生的时间–人类可读时间，如：2003-07-08 16:49:45,896 |
| created         | %(created)f         | 日志事件发生的时间–时间戳，就是当时调用 time.time() 函数返回的值 |
| relativeCreated | %(relativeCreated)d | 日志事件发生的时间相对于 logging 模块加载时间的相对毫秒数（目前还不知道干嘛用的） |
| msecs           | %(msecs)d           | 日志事件发生事件的毫秒部分                                   |
| levelname       | %(levelname)s       | 该日志记录的文字形式的日志级别（‘DEBUG’, ‘INFO’, ‘WARNING’, ‘ERROR’, ‘CRITICAL’） |
| levelno         | %(levelno)s         | 该日志记录的数字形式的日志级别（10, 20, 30, 40, 50）         |
| name            | %(name)s            | 所使用的日志器名称，默认是 ‘root’，因为默认使用的是 rootLogger |
| message         | %(message)s         | 日志记录的文本内容，通过 msg % args 计算得到的               |
| pathname        | %(pathname)s        | 调用日志记录函数的源码文件的全路径                           |
| filename        | %(filename)s        | pathname 的文件名部分，包含文件后缀                          |
| module          | %(module)s          | filename 的名称部分，不包含后缀                              |
| lineno          | %(lineno)d          | 调用日志记录函数的源代码所在的行号                           |
| funcName        | %(funcName)s        | 调用日志记录函数的函数名                                     |
| process         | %(process)d         | 进程 ID                                                      |
| processName     | %(processName)s     | 进程名称，Python 3.1 新增                                    |
| thread          | %(thread)d          | 线程 ID                                                      |
| threadName      | %(thread)s          | 线程名称                                                     |

```python
# coding=utf-8
import logging

MY_FORMAT = "%(asctime)s %(name)s %(levelname)s %(pathname)s %(lineno)d %(message)s"  # 配置输出日志格式
DATE_FORMAT = '%Y-%m-%d  %H:%M:%S %a '  #配置输出时间的格式

logging.basicConfig(
    filename="my.log",  # 指定日志写入到文件
    level=logging.INFO,
    datefmt=DATE_FORMAT,
    format=MY_FORMAT,
)

logging.debug("debug")
logging.info("info")
logging.warning("warning")
logging.error("error")
logging.critical("critical")
1.2.3.4.5.6.7.8.9.10.11.12.13.14.15.16.17.18.
```

打开文件 my.log，内容如下：

```html
2020-11-22  19:18:58 Sun  root INFO E:/prapy/python_project/testcase/test1.py 15 info
2020-11-22  19:18:58 Sun  root WARNING E:/prapy/python_project/testcase/test1.py 16 warning
2020-11-22  19:18:58 Sun  root ERROR E:/prapy/python_project/testcase/test1.py 17 error
2020-11-22  19:18:58 Sun  root CRITICAL E:/prapy/python_project/testcase/test1.py 18 critical
1.2.3.4.
```

说明：

- logging.basicConfig() 函数是一个一次性的简单配置工具使，也就是说只有在第一次调用该函数时会起作用，后续再次调用该函数时完全不会产生任何操作的，多次调用的设置并不是累加操作。
- 日志器（Logger）是有层级关系的，上面调用的 logging 模块级别的函数所使用的日志器是 RootLogger 类的实例，其名称为 ‘root’，它是处于日志器层级关系最顶层的日志器，且该实例是以单例模式存在的。
- 如果要记录的日志中包含变量数据，可使用一个格式字符串作为这个事件的描述消息（logging.debug、logging.info 等函数的第一个参数），然后将变量数据作为第二个参数 *args 的值进行传递，

```python
>>> import logging
>>> logging.warning('%s is %d years old.', 'Tom', 10)
WARNING:root:Tom is 10 years old.
1.2.3.
```

3 使用 Logging 日志系统的四大组件

上面我们了解到了 logging.debug()、logging.info()、logging.warning()、logging.error()、logging.critical()（分别用以记录不同级别的日志信息），logging.basicConfig()（用默认日志格式（Formatter）为日志系统建立一个默认的流处理器（StreamHandler），设置基础配置（如日志级别等）并加到 root logger（根 Logger）中）这几个 logging 模块级别的函数。

下面介绍第二种打印日志的方法，日志流处理，使用函数 logging.getLogger([name])（返回一个 logger 对象，如果没有指定名字将返回 root logger）。

在介绍 logging 模块的日志流处理流程之前，我们先来介绍下 logging 模块的四大组件：

| 组件名称 | 对应类名  | 功能描述                                                     |
| -------- | --------- | ------------------------------------------------------------ |
| 日志器   | Logger    | 提供了应用程序可一直使用的接口                               |
| 处理器   | Handler   | 将 logger 创建的日志记录发送到合适的目的输出                 |
| 过滤器   | Filter    | 提供了更细粒度的控制工具来决定输出哪条日志记录，丢弃哪条日志记录 |
| 格式器   | Formatter | 决定日志记录的最终输出格式                                   |

**这些组件之间的关系描述：**

- 日志器（logger）需要通过处理器（handler）将日志信息输出到目标位置，如：文件、sys.stdout、网络等；
- 不同的处理器（handler）可以将日志输出到不同的位置；
- 日志器（logger）可以设置多个处理器（handler）将同一条日志记录输出到不同的位置；
- 每个处理器（handler）都可以设置自己的过滤器（filter）实现日志过滤，从而只保留感兴趣的日志；
- 每个处理器（handler）都可以设置自己的格式器（formatter）实现同一条日志以不同的格式输出到不同的地方。

简单点说就是：日志器（logger）是入口，真正干活儿的是处理器（handler），处理器（handler）还可以通过过滤器（filter）和格式器（formatter）对要输出的日志内容做过滤和格式化等处理操作。

**logging 日志模块相关类及其常用方法介绍**

与 logging 四大组件相关的类：Logger, Handler, Filter, Formatter。

## 3.1 Logger 类

Logger 对象有 3 个任务要做：

1. 向应用程序代码暴露几个方法，使应用程序可以在运行时记录日志消息；
2. 基于日志严重等级（默认的过滤设施）或 filter 对象来决定要对哪些日志进行后续处理；
3. 将日志消息传送给所有感兴趣的日志 handlers。

Logger 对象最常用的方法分为两类：配置方法和消息发送方法

**Logger 类相关方法**

| 方法                                          | 描述                                       |
| --------------------------------------------- | ------------------------------------------ |
| Logger.setLevel()                             | 设置日志器将会处理的日志消息的最低严重级别 |
| Logger.addHandler() 和 Logger.removeHandler() | 为该logger对象添加 和 移除一个handler对象  |
| Logger.addFilter() 和 Logger.removeFilter()   | 为该logger对象添加 和 移除一个filter对象   |

logger对象配置完成后，可以使用下面的方法来创建日志记录：

| 方法                                                         | 描述                                                |
| ------------------------------------------------------------ | --------------------------------------------------- |
| Logger.debug(), Logger.info(), Logger.warning(), Logger.error(), Logger.critical() | 创建一个与它们的方法名对应等级的日志记录            |
| Logger.exception()                                           | 创建一个类似于 Logger.error() 的日志消息            |
| Logger.log()                                                 | 需要获取一个明确的日志 level 参数来创建一个日志记录 |

一个 Logger 对象呢？一种方式是通过 Logger 类的实例化方法创建一个 Logger 类的实例，但是我们通常都是用第二种方式–logging.getLogger() 方法。

logging.getLogger() 方法有一个可选参数 name，该参数表示将要返回的日志器的名称标识，如果不提供该参数，则其值为 ‘root’。若以相同的 name 参数值多次调用 getLogger() 方法，将会返回指向同一个 logger 对象的引用。

多次使用注意不能创建多个logger,否则会出现重复输出日志现象。

**关于logger的层级结构与有效等级的说明：**

- logger的名称是一个以 ‘.’ 分割的层级结构，每个 ‘.’ 后面的 logger 都是 ‘.’ 前面的 logger 的 children，例如，有一个名称为 foo 的 logger，其它名称分别为 foo.bar, foo.bar.baz 和 foo.bam 都是 foo 的后代。
- logger 有一个"有效等级（effective level）"的概念。如果一个 logger 上没有被明确设置一个 level，那么该 logger 就是使用它 parent 的 level；如果它的 parent 也没有明确设置 level 则继续向上查找 parent 的 parent 的有效 level，依次类推，直到找到个一个明确设置了 level 的祖先为止。需要说明的是，root logger 总是会有一个明确的 level 设置（默认为 WARNING）。当决定是否去处理一个已发生的事件时，logger 的有效等级将会被用来决定是否将该事件传递给该 logger 的 handlers 进行处理。
- child loggers 在完成对日志消息的处理后，默认会将日志消息传递给与它们的祖先 loggers 相关的 handlers。因此，我们不必为一个应用程序中所使用的所有 loggers 定义和配置 handlers，只需要为一个顶层的 logger 配置 handlers，然后按照需要创建 child loggers 就可足够了。我们也可以通过将一个 logger 的 propagate 属性设置为 False 来关闭这种传递机制。

## 3.2 Handler 类

Handler 对象的作用是（基于日志消息的 level）将消息分发到 handler 指定的位置（文件、网络、邮件等）。Logger 对象可以通过 addHandler() 方法为自己添加 0 个或者更多个 handler 对象。比如，一个应用程序可能想要实现以下几个日志需求：

| 方法                                                | 描述                                              |
| --------------------------------------------------- | ------------------------------------------------- |
| Handler.setLevel(lel)                               | 指定被处理的信息级别，低于 lel 级别的信息将被忽略 |
| Handler.setFormatter()                              | 给这个 handler 选择一个格式                       |
| Handler.addFilter(filt)、Handler.removeFilter(filt) | 新增或删除一个 filter 对象                        |

需要说明的是，应用程序代码不应该直接实例化和使用 Handler 实例。因为 Handler 是一个基类，它只定义了所有 handlers 都应该有的接口，同时提供了一些子类可以直接使用或覆盖的默认行为。下面是一些常用的 Handler：

| Handler                                   | 描述                                                         |
| ----------------------------------------- | ------------------------------------------------------------ |
| logging.StreamHandler                     | 将日志消息发送到输出到 Stream，如 std.out, std.err 或任何 file-like 对象。 |
| logging.FileHandler                       | 将日志消息发送到磁盘文件，默认情况下文件大小会无限增长       |
| logging.handlers.RotatingFileHandler      | 将日志消息发送到磁盘文件，并支持日志文件按大小切割           |
| logging.hanlders.TimedRotatingFileHandler | 将日志消息发送到磁盘文件，并支持日志文件按时间切割           |
| logging.handlers.HTTPHandler              | 将日志消息以 GET 或 POST 的方式发送给一个 HTTP 服务器        |
| logging.handlers.SMTPHandler              | 将日志消息发送给一个指定的 email 地址                        |
| logging.NullHandler                       | 该 Handler 实例会忽略 error messages，通常被想使用 logging 的 library 开发者使用来避免 ‘No handlers could be found for logger XXX’ 信息的出现。 |

## 3.3 Formater 类

Formater 对象用于配置日志信息的最终顺序、结构和内容。与 logging.Handler基类不同的是，应用代码可以直接实例化 Formatter 类。另外，如果你的应用程序需要一些特殊的处理行为，也可以实现一个 Formatter 的子类来完成。

Formatter 类的构造方法定义如下：

```python
logging.Formatter.__init__(fmt=None, datefmt=None, style='%')
1.
```

可见，该构造方法接收 3 个可选参数：

- fmt：指定消息格式化字符串，如果不指定该参数则默认使用 message 的原始值
- datefmt：指定日期格式字符串，如果不指定该参数则默认使用 “%Y-%m-%d %H:%M:%S”
- style：Python 3.2 新增的参数，可取值为 ‘%’，’{’ 和 ‘$’，如果不指定该参数则默认使用 ‘%’

一般直接用 logging.Formatter(fmt, datefmt)

## 3.4 Filter类（了解即可）

Filter 可以被 Handler 和 Logger 用来做比 level 更细粒度的、更复杂的过滤功能。Filter 是一个过滤器基类，它只允许某个 logger 层级下的日志事件通过过滤。该类定义如下：

```python
class logging.Filter(name='')
    filter(record)
1.2.
```

比如，一个 filter 实例化时传递的 name 参数值为 ‘A.B’，那么该 filter 实例将只允许名称为类似如下规则的 loggers 产生的日志记录通过滤：‘A.B’，‘A.B,C’，‘A.B.C.D’，‘A.B.D’，而名称为 ‘A.BB’，‘B.A.B’ 的 loggers 产生的日志则会被过滤掉。如果 name 的值为空字符串，则允许所有的日志事件通过过滤。

filter 方法用于具体控制传递的 record 记录是否能通过过滤，如果该方法返回值为0表示不能通过过滤，返回值为非 0 表示可以通过过滤。

## 3.5 日志流处理简要流程

1、创建一个 logger
2、设置下 logger 的日志的等级
3、创建合适的 Handler(FileHandler 要有路径)
4、设置下每个 Handler 的日志等级
5、创建下日志的格式
6、向 Handler 中添加上面创建的格式
7、将上面创建的 Handler 添加到 logger 中
8、打印输出 logger.debug\logger.info\logger.warning\logger.error\logger.critical

```python
# coding=utf-8
import logging

# 创建logger，如果参数为空则返回 root logger
logger = logging.getLogger("mylogger")
logger.setLevel(logging.DEBUG)  # 设置logger日志等级

# 创建handler
fh = logging.FileHandler("test.log", encoding="utf-8")
ch = logging.StreamHandler()

# 设置输出日志格式, 注意 logging.Formatter的大小写
formatter = logging.Formatter(
    fmt="%(asctime)s %(name)s %(filename)s %(message)s",
    datefmt="%Y/%m/%d %X"
)

# 为handler指定输出格式，注意大小写
fh.setFormatter(formatter)
ch.setFormatter(formatter)

# 为logger添加的日志处理器
logger.addHandler(fh)
logger.addHandler(ch)

# 输出不同级别的log
logger.warning("warning message")
logger.info("info message")
logger.error("error message")
1.2.3.4.5.6.7.8.9.10.11.12.13.14.15.16.17.18.19.20.21.22.23.24.25.26.27.28.29.
```

运行结果

```html
2020/11/22 21:00:24 mylogger test3.py warning message
2020/11/22 21:00:24 mylogger test3.py info message
2020/11/22 21:00:24 mylogger test3.py error message
1.2.3.
```

**python logging 重复写日志问题**

用 Python 的 logging 模块记录日志时，可能会遇到重复记录日志的问题，第一条记录写一次，第二条记录写两次，第三条记录写三次

**原因：没有移除 handler 解决：在日志记录完之后 removeHandler**

```python
# coding=utf-8
import logging

def log(msg):
    #创建logger，如果参数为空则返回root logger
    logger = logging.getLogger("mylogger")
    logger.setLevel(logging.DEBUG)  #设置logger日志等级

    #创建handler
    fh = logging.FileHandler("test.log",encoding="utf-8")
    ch = logging.StreamHandler()

    #设置输出日志格式
    formatter = logging.Formatter(
        fmt="%(asctime)s %(name)s %(filename)s %(message)s",
        datefmt="%Y/%m/%d %X"
        )

    #为handler指定输出格式
    fh.setFormatter(formatter)
    ch.setFormatter(formatter)

    #为logger添加的日志处理器
    logger.addHandler(fh)
    logger.addHandler(ch)

    # 输出不同级别的log
    logger.info(msg)

# 输出不同级别的log
log("message1")
log("message2")
log("message3")
1.2.3.4.5.6.7.8.9.10.11.12.13.14.15.16.17.18.19.20.21.22.23.24.25.26.27.28.29.30.31.32.33.
```

运行结果

```html
2020/11/22 21:08:04 mylogger test3.py message1
2020/11/22 21:08:04 mylogger test3.py message2
2020/11/22 21:08:04 mylogger test3.py message2
2020/11/22 21:08:04 mylogger test3.py message3
2020/11/22 21:08:04 mylogger test3.py message3
2020/11/22 21:08:04 mylogger test3.py message3
1.2.3.4.5.6.
```

**分析**：可以看到输出结果有重复打印

原因：第二次调用 log 的时候，根据 getLogger(name) 里的 name 获取同一个logger，而这个 logger 里已经有了第一次你添加的 handler，第二次调用又添加了一个 handler，所以，这个 logger 里有了两个同样的 handler，以此类推，调用几次就会有几个 handler。

**解决方案 1：添加 removeHandler 语句**

```python
# coding=utf-8
import logging


def log(msg):
    # 创建logger，如果参数为空则返回root logger
    logger = logging.getLogger("mylogger")
    logger.setLevel(logging.DEBUG)  # 设置logger日志等级

    # 创建handler
    fh = logging.FileHandler("test.log", encoding="utf-8")
    ch = logging.StreamHandler()

    # 设置输出日志格式
    formatter = logging.Formatter(
        fmt="%(asctime)s %(name)s %(filename)s %(message)s",
        datefmt="%Y/%m/%d %X"
    )

    # 为handler指定输出格式
    fh.setFormatter(formatter)
    ch.setFormatter(formatter)

    # 为logger添加的日志处理器
    logger.addHandler(fh)
    logger.addHandler(ch)

    # 输出不同级别的log
    logger.info(msg)

    # 解决方案1，添加removeHandler语句，每次用完之后移除Handler
    logger.removeHandler(fh)
    logger.removeHandler(ch)


# 输出不同级别的log
log("message1")
log("message2")
log("message3")
1.2.3.4.5.6.7.8.9.10.11.12.13.14.15.16.17.18.19.20.21.22.23.24.25.26.27.28.29.30.31.32.33.34.35.36.37.38.39.
```

**解决方案 2：在 log 方法里做判断，如果这个 logger 已有 handler，则不再添加 handler。**

```python
# coding=utf-8
import logging


def log(msg):
    # 创建logger，如果参数为空则返回root logger
    logger = logging.getLogger("mylogger")
    logger.setLevel(logging.DEBUG)  # 设置logger日志等级

    if not logger.handlers:
        # 创建handler
        fh = logging.FileHandler("test.log", encoding="utf-8")
        ch = logging.StreamHandler()

        # 设置输出日志格式
        formatter = logging.Formatter(
            fmt="%(asctime)s %(name)s %(filename)s %(message)s",
            datefmt="%Y/%m/%d %X"
        )

        # 为handler指定输出格式
        fh.setFormatter(formatter)
        ch.setFormatter(formatter)

        # 为logger添加的日志处理器
        logger.addHandler(fh)
        logger.addHandler(ch)

    # 输出不同级别的log
    logger.info(msg)


# 输出不同级别的log
log("message1")
log("message2")
log("message3")
1.2.3.4.5.6.7.8.9.10.11.12.13.14.15.16.17.18.19.20.21.22.23.24.25.26.27.28.29.30.31.32.33.34.35.36.
```

**logger 调用方法的例子**

```python
# coding=utf-8
import logging.handlers
import datetime


def get_logger():
    logger = logging.getLogger('mylogger')  # mylogger为日志器的名称标识，如果不提供该参数，默认为'root'
    logger.setLevel(logging.DEBUG)  # 设置logger处理等级

    # 这里进行判断，如果logger.handlers列表为空，则添加，否则，直接去写日志
    if not logger.handlers:
        # rf_handler将所有的日志信息写到 all.log 中
        # when:字符串，定义了日志切分的间隔时间单位
        # interval:间隔时间单位的个数，指等待多少个when的时间后Logger会自动重建新闻继续进行日志记录
        # backupCount 是保留日志的文件个数，日志文件最多backupCount个，多余的删除，默认为0，表示不会自动删除
        rf_handler = logging.handlers.TimedRotatingFileHandler('all.log', when='midnight', interval=1, backupCount=7,
                                                               atTime=datetime.time(0, 0, 0, 0))

        # 设置输出日志格式
        rf_formatter = logging.Formatter("%(asctime)s - %(levelname)s - %(message)s")
        # 为handler指定输出格式
        rf_handler.setFormatter(rf_formatter)

        # f_handler 将等级大于等于 error的信息写到error.log文件中
        f_handler = logging.FileHandler('error.log')
        f_handler.setLevel(logging.ERROR)

        # 设置输出日志格式
        f_formatter = logging.Formatter("%(asctime)s - %(levelname)s - %(filename)s[:%(lineno)d] - %(message)s")
        # 为handler指定输出格式
        f_handler.setFormatter(f_formatter)

        # 为logger添加的日志处理器
        logger.addHandler(rf_handler)
        logger.addHandler(f_handler)

    return logger


logger = get_logger()
logger.debug('debug message')
logger.info('info message')
logger.warning('warning message')
logger.error('error message')
logger.critical('critical message')
logger.log(level=logging.ERROR, msg="logger.log message")
1.2.3.4.5.6.7.8.9.10.11.12.13.14.15.16.17.18.19.20.21.22.23.24.25.26.27.28.29.30.31.32.33.34.35.36.37.38.39.40.41.42.43.44.45.46.
```

参考：https://www.cnblogs.com/Nicholas0707/p/9021672.html#_label1_1





# 引入类

```python
from myfolder import myfile

class1 = myfile.myclass()
```

### [示例代码 2：](https://www.delftstack.com/zh/howto/python/python-import-class-from-another-file/#示例代码-2)

```python
from myfolder.myfile import myclass
```
