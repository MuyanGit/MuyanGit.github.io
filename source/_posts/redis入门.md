title: redis入门
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2021-11-13 16:10:13
authorAbout:
series:
tags:
keywords:
description:
photos:
---







```cmd
方法二：给Redis服务端设置密码
第二种是给Redis Server设置密码，并且客户端配置正确的密码。
可以通过命令行修改密码：

进入安装目录
D:\MySoftware\DEV\Dev_env\Redis-x64-3.2.100>redis-cli.exe
修改密码为1
127.0.0.1:6379> config set requirepass 1
OK
127.0.0.1:6379> Ctrl + c
D:\MySoftware\DEV\Dev_env\Redis-x64-3.2.100>redis-cli.exe
127.0.0.1:6379> auth 123456#测试错误密码
(error) ERR invalid password
127.0.0.1:6379> auth 1
OK
也可以通过修改配置文件来修改密码，redis.windows.conf配置文件，搜索requirepass，找到注释密码行，去掉注释，设置密码：

requirepass tenny     //注意，行前不能有空格

```



修改密码

![image-20211113161411214](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211113161411214.png)



# Redis下载和安装（Windows系统）



![Redis安装](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/131Ga535-0.gif)
图1：Redis 安装


下载完成后，打开相应的文件夹，您会看到如下图所示的文件目录：



![redis安装](http://c.biancheng.net/uploads/allimg/210913/131G91346-1.gif)
图2：Window 安装 Redis

 

## 创建Redis临时服务

#### 1) 启动服务端程序

如上图所示，双击 

Redis

 服务端启动程序 

redis

-server.exe，您会看到以下界面：



![Redis服务端启动](http://c.biancheng.net/uploads/allimg/210913/131G94961-2.png)
图3：启动 Redis 服务端程序


上图中显示一些 

Redis

 的相关信息，比如 

Redis

 的版本号以及默认端口号(6379)。注意，为了实现后续操作，请您保持服务端开启状态，否则客户端无法正常工作。 

#### 2) 启动客户端程序

启动服务端后，双击客户端启动程序 

redis

-cli.exe，得到如下界面：



![redis客户端启动](http://c.biancheng.net/uploads/allimg/210913/131G93507-3.gif)
图4：Redis客户端启动

得到如上界面，说明 

Redis

 本地客户端与服务端连接成功。

## 命令创建Redis服务

上述方式虽然简单快捷，但是显然不是程序员的操作，下面介绍，通过命令启动 

Redis

 服务端，并将 

Redis

 服务添加到 

Windows

 资源管理器，实现开机后自动启动。

#### 1) 注册Redis服务

通过 CMD 命令行工具进入 

Redis

 安装目录，将 

Redis

 服务注册到 

Windows

 服务中，执行以下命令：

```
redis-server.exe --service-install redis.windows.conf --loglevel verbose
```

执行完后，得到以下输出，说明注册成功。

```
[1868] 07 Jan 15:00:08.223 # Granting read/write access to 'NT AUTHORITY\NetworkService' on: "D:\Redis-x64-5.0.10" "D:\Redis-x64-5.0.10\"
[1868] 07 Jan 15:00:08.230 # Redis successfully installed as a service.
```

#### 2) 启动Redis服务

执行以下命令启动 

Redis

 服务，命令如下：

```
redis-server --service-start
```

如下图所示：

![redis命令起动](http://c.biancheng.net/uploads/allimg/210913/131G91059-4.gif)
图5：命令启动 Redis 服务


注意：此时 

Redis

 已经被添加到 

Windows

 服务中，因此不会再显示 

Redis

 服务端的相应的信息，如下图所示：



![Redis注册Window服务](http://c.biancheng.net/uploads/allimg/210913/131G922W-5.gif)
图6：Windows 服务管理界面

#### 3) 启动Redis客户端

在 CMD 命令行输出 

redis

-cli 命令启动客户端，如下所示：



![Redis客户端启动](http://c.biancheng.net/uploads/allimg/210913/131G92131-6.gif)
图7：启动 Redis 客户端

#### 4) 检查是否连接成功

测试客户端和服务端是否成功连接。输出`PING`命令，若返回`PONG`则证明成功连接。如下所示：



![检查Redis是否成功连接](http://c.biancheng.net/uploads/allimg/210913/131G940b-7.gif)
图8：测试客户端是否连接


通过上面的操作，我们完成了 

Redis

 的安装。当然，您也可以将 

Redis

 加入到环境变量中，如下所示：



![环境变量配置](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/131G95226-8.gif)
图9：环境变量配置

注意：根据自己的安装路径添加环境变量。

## 总结

下面对安装过程中涉及到的命令进行总结，主要包括以下命令：

```
安装服务：redis-server --service-install
卸载服务：redis-server --service-uninstall
开启服务：redis-server --service-start
停止服务：redis-server --service-stop
服务端启动时重命名：redis-server --service-start --service-name Redis1
```

![image-20211122210534669](C:/Users/HI/AppData/Roaming/Typora/typora-user-images/image-20211122210534669.png)





## 修改密码

今天在启动项目时，用到了Redis缓存数据库，但是却出现了报错信息：ERR Client sent AUTH, but no password is set。

```java
Caused by: io.lettuce.core.RedisCommandExecutionException: ERR Client sent AUTH, but no password is set
1
```

![在这里插入图片描述](https://img-blog.csdnimg.cn/20200426140629148.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3UwMTQwMjYwODQ=,size_16,color_FFFFFF,t_70)

## 原因

产生这个问题的原因异常信息里已经说明，就是Redis服务器没有设置密码，但客户端向其发送了AUTH（authentication，身份验证）请求携带着密码，导致报错。既然是没有设置密码导致的报错，那我们就把Redis服务器给设置上密码就好了。一共有2种方式设置密码：

## 一、命令行方式

1、先进入Redis服务器

```csharp
C:\Program Files (x86)\Redis-x64-3.2.100>redis-cli.exe
1
```

2、查看是否设置了密码

```csharp
127.0.0.1:6379> auth 123456
(error) ERR Client sent AUTH, but no password is set
12
```

3、报错，说明没有设置密码，然后再执行配置命令

```csharp
127.0.0.1:6379> config set requirepass root

OK
123
```

4、返回OK后即代表配置成功，这个时候再执行查看密码命令

```csharp
redis 127.0.0.1:6379> AUTH 123456
Ok
12
```

返回OK，就说明已经配置成功了。
**这种配置方式存在一个很严重的问题，就是当我们将Redis服务器关掉之后，这些配置就会失效，下次再启动服务器，需要重新设置！**

## 二、修改配置文件

还有一种方式就是一劳永逸的方式，就是直接修改配置文件里的参数。在redis.windows.conf（我的是这个配置文件）或者redis.conf（我看网上有说是这个配置文件的）的配置文件中找到requirepass这个参数，设置参数密码，然后保存配置文件，重启Redis。

```csharp
# requirepass foobared
requirepass 123456 //123456是设置的密码
12
```

本来这种方式非常简单，但是在实际过程中，却遇见了一些问题，那就是配置不生效，明明配置文件里都已经配置了密码，但是还会报错，后来在Redis启动时发现，Redis报错了：

```csharp
 Warning: no config file specified, using the default config. 
 In order to specify a config file use C:\Program Files (x86)\Redis-x64-3.2.100\redis-server.exe
 /path/to/redis.conf
123
```

![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/2020042614443476.png)
后来查阅之后才知道，**原来Redis启动时需要指定配置文件，否则还会使用默认配置**，而我在Windows里启动.exe应用程序时，还是习惯性的双击应用程序启动，导致Redis一直使用的是默认配置。
这样我们就需要在命令行窗口通过命令行的方式来启动并指定配置文件：

```csharp
C:\Program Files (x86)\Redis-x64-3.2.100>redis-server.exe redis.windows.conf
1
```

![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/20200426144822606.png)
这样，我们的Redis服务器的密码就正式配置完成了。



 
