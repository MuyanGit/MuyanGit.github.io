---
title: Ubuntu18.04修改IP地址的方法
author: MuyanGit
categories: 技术
date: 2022-09-02 15:31:02
tags:
photos:
---

[![CSDN首页](G:/Demo_Git/pic_url/img/20201124032511.png)](https://www.csdn.net/)

- [博客](https://blog.csdn.net/)
- [社区](https://bbs.csdn.net/)
- [GitCode](https://gitcode.net/?utm_source=csdn_toolbar)
- [猿如意 ![img](G:/Demo_Git/pic_url/img/20220830073411.png)](https://devbit.csdn.net/?source=csdn_toolbar)



 搜索



登录/注册

[会员中心 ![img](G:/Demo_Git/pic_url/img/20210918025138.gif)](https://mall.csdn.net/vip)

[足迹](https://i.csdn.net/#/user-center/collection-list?type=1)

[动态](https://blink.csdn.net/)

[创作中心 ![img](G:/Demo_Git/pic_url/img/20220627041202.png)](https://mp.csdn.net/)

[发布](https://mp.csdn.net/edit)

# Ubuntu18.04修改IP地址的方法

![img](G:/Demo_Git/pic_url/img/original.png)

[root888888](https://blog.csdn.net/weixin_42342456)![img](G:/Demo_Git/pic_url/img/newCurrentTime2.png)于 2019-01-12 22:41:18 发布![img](G:/Demo_Git/pic_url/img/articleReadEyes2.png)29235![img](G:/Demo_Git/pic_url/img/tobarCollect2.png) 收藏 41

分类专栏： [Ubuntu](https://blog.csdn.net/weixin_42342456/category_8607370.html) [Linux操作系统](https://blog.csdn.net/weixin_42342456/category_7736777.html) [实用技巧](https://blog.csdn.net/weixin_42342456/category_7804310.html)

版权

[![img](G:/Demo_Git/pic_url/img/resize,m_fixed,h_64,w_64.png)Ubuntu同时被 3 个专栏收录![img](G:/Demo_Git/pic_url/img/newArrowDown1White.png)](https://blog.csdn.net/weixin_42342456/category_8607370.html)

1 篇文章0 订阅

订阅专栏

[![img](G:/Demo_Git/pic_url/img/resize,m_fixed,h_64,w_64-16621043085171.png)Linux操作系统](https://blog.csdn.net/weixin_42342456/category_7736777.html)

42 篇文章1 订阅

订阅专栏

[![img](G:/Demo_Git/pic_url/img/resize,m_fixed,h_64,w_64.png)实用技巧](https://blog.csdn.net/weixin_42342456/category_7804310.html)

21 篇文章0 订阅

订阅专栏

今天刚装了个Ubuntu18.04的服务器，按照之前16.04版本的方式修改了网卡IP地址，但在重启网卡的时候起不来，具体过程如下：
**修改/etc/network/interfaces配置文件**
![在这里插入图片描述](G:/Demo_Git/pic_url/img/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MjM0MjQ1Ng==,size_16,color_FFFFFF,t_70.png)
**保存后重启网卡报错**
![在这里插入图片描述](G:/Demo_Git/pic_url/img/20190112222155727.png)
**检查报错**
![在这里插入图片描述](G:/Demo_Git/pic_url/img/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MjM0MjQ1Ng==,size_16,color_FFFFFF,t_70-16621043085182.png)
说明：按照报错，然后在网上找有关次报错的解决办法，搞了半天没用，还是无法启动，这我就有点郁闷了，我在想是不是版本的问题，然后上网一查发现原来Ubuntu18.04网卡配置文件发生了变化，之前Ubuntu16.04的/etc/network/interfaces配置文件已经不生效了，在Ubuntu18.04中需要修改 **/etc/netplan/50-cloud-init.yaml** 配置文件，下面是具体修改如下：
![在这里插入图片描述](G:/Demo_Git/pic_url/img/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MjM0MjQ1Ng==,size_16,color_FFFFFF,t_70-16621043085183.png)
**重启网卡**
![在这里插入图片描述](G:/Demo_Git/pic_url/img/20190112223551674.png)
**查看网卡信息**
![在这里插入图片描述](G:/Demo_Git/pic_url/img/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MjM0MjQ1Ng==,size_16,color_FFFFFF,t_70-16621043085184.png)



博客当中的‘在Ubuntu18.04中需要修改 /etc/netplan/50-cloud-init.[yaml](https://so.csdn.net/so/search?q=yaml&spm=1001.2101.3001.7020) 配置文件’这一句需要根据自己的实际情况修改，可以通过ls命令和cd命令一直找
![在这里插入图片描述](G:/Demo_Git/pic_url/img/20190827200819366)
这里我的名字是01-netcfg.yaml
然后使用vi编辑就好了
![在这里插入图片描述](G:/Demo_Git/pic_url/img/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L20wXzM3MDUyMzIw,size_16,color_FFFFFF,t_70.png)
这里是我的结果，注意那个/24不能少（根据不同子网掩码推算的结果[查看网址](https://doc.m0n0.ch/quickstartpc/intro-CIDR.html)），
![在这里插入图片描述](G:/Demo_Git/pic_url/img/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L20wXzM3MDUyMzIw,size_16,color_FFFFFF,t_70-166210438402156.png)不然就会报错
![在这里插入图片描述](G:/Demo_Git/pic_url/img/20190827201008594)
error in network definition …is missing /prefixlength

最后运行完netplan apply之后稍微等一会就可以了

```cmd
muyan@VMmuyan:/etc/netplan$ cat /etc/netplan/01-network-manager-all.yaml 
# Let NetworkManager manage all devices on this system
network:
  version: 2
  renderer: NetworkManager
  ethernets:
    ens33:                      #网卡名，以ubuntu操作系统的网卡名称为准
      dhcp4: no                 #ipv4关闭dhcp，用static模式
      dhcp6: no                 #ip6关闭dhcp
      #还可以这样写 
      #addresses: [192.168.137.137/24] #ubuntu本机IP地址
      addresses:
        - 192.168.137.100/24     #ubuntu本机IP地址
      gateway4: 192.168.137.2    #vmware网关的的IP地址
      nameservers:               #DNS服务器
        addresses: [114.114.114.114, 8.8.8.8, 1.1.1.1]
        
muyan@VMmuyan:/etc/netplan$ sudo netplan apply #重启网卡
muyan@VMmuyan:/etc/netplan$ sudo init 6 #重启电脑


```





 
