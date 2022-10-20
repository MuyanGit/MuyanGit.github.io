---
title: Centos8初始化配置
author: MuyanGit
categories: 技术
date: 2022-10-20 10:08:41
tags:
photos:
---





# 1·	用户配置





## 新增用户muyan

```bat
1. 首先使用ec2-user这个用户登录到服务器
$ ssh ec2-user@123.4.5.6

2. 切换到root用户
sudo su

3. 创建新用户 work
adduser work

4. 修改新用户 work 密码
passwd work

5. 添加新的组 SSHD_USER
groupadd SSHD_USER

6. 将新用户 work 添加到 SSHD_USER 组
usermod -G SSHD_USER work

查看用户
id work

当前用户-查看是否有sudo权限
sudo -l
输入命令cat /etc/passwd|grep+用户名，再按回车运行。
cat /etc/passwd|grep muyan
查看文件权限


```



## ssh开启

```bat

7. 修改 SSHD 配置文件
# vim /etc/ssh/sshd_config
在 sshd_config 文件末尾增加以下配置

# 允许登录的组: SSHD_USER ec2-user
AllowGroups SSHD_USER root 
 
# 仅允许 SSHD_USER 组使用密码登录
Match Group SSHD_USER
    PasswordAuthentication yes
8. 重启 SSHD 服务
```



# 2·  	 ip 配置

## 识别	a		地址识别NAT网络



![image-20221020100936482](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20221020100936482.png)



```bat
systemctl start libvirtd 启动daemon。
systemctl enable libvirtd 激活开机启动。
libvirtd是一服务的名字,跟虚拟化有关的daemon意思是守护 进程

这个时候，ip addr 显示4个: lo, ens33, virbr0, virbr0-nic 。
virbr0 就是NAT网络。vm客户机可以访问外网，有dnsmasq。

virsh net-list 只看到一个名称 default。
virsh net-info default 显示这个 default 使用的是 virbr0。

如果要修改 default网络(virbr0) 的 IP 和 网段。
virsh net-edit default, 其实就是修改 /etc/libvirt/qemu/networks/default.xml。
重启这个default网络。virsh net-destroy default; virsh net-start default 生效。
创建网络，见下文。
nmcli device 见到 virbr0是bridge, vribr0-nic 是tun设备。
```

```
nmcli 

nmcli device 见到 virbr0是bridge, vribr0-nic 是tun设备。
```

![image-20221020105540837](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20221020105540837.png)



```bat
问题
virsh net-list 只看到一个名称 default。
virsh net-info default 显示这个 default 使用的是 virbr0。
```

![image-20221020105436175](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20221020105436175.png)

## [VMware设置CentOS8静态IP（桥接模式）](https://www.cnblogs.com/ymang/p/vmware_centos8_static_ip.html)



## 设置虚拟机网络

1. 选择VMware的编辑-虚拟网络编辑器

   

2. 点击更改设置

3. ![image-20200805231155900](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/1996576-20200806004217384-1631175983.png)

   

4. **选择一个网卡**

   

   此处选择的网卡为物理网卡，不能为自动

   ![image-20200805231452101](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/1996576-20200806004317919-863418361.png)

5. 配置完成点击确定

## 配置CentOS8为静态地址

1. 先备份网卡设置

   ```shell
   su - 
   # 切换到root操作
   cd /etc/sysconfig/network-scripts/
   cp ifcfg-eth0 ifcfg-eth0.bak
   ```

   ![image-20200708104444990](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/1996576-20200806004424713-1490464701.png)

2. 编辑网卡设置

   ```shell
   vi ifcfg-ens33
   ```

   ![image-20200805234817028](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/1996576-20200806004458712-826392710.png)

   需要修改的位置

   ```shell
   ...
   BOOTPROTO="static"  # 修改为静态
   ...
   ONBOOT="yes"  # 修改为开机启动
   IPADDR=10.10.0.183  # 静态IP
   NETMASK=255.255.254.0  # 子网掩码
   GATEWAY=10.10.0.1  # 网关地址
   DNS1=114.114.114.114  # DNS地址
   ```

3. 重启网卡

   ```shell
   # 在CentOS7上可以用
   # service network restrat 重启网卡
   # 不过在CentOS8上，得使用
   nmcli c reload
   # 如果不生效则
   nmcli c up ens33  # ens33为网卡名字
   ```

# 1·CentOS8_debian11_远程ssh连接_

````
[CentOS8_debian11_远程ssh连接_在线安装KVM_openwrt](https://www.cnblogs.com/osnosn/p/16417701.html)

## [CentOS8_debian11_远程ssh连接_在线安装KVM_openwrt](https://www.cnblogs.com/osnosn/p/16417701.html)

**转载注明来源: [本文链接](https://www.cnblogs.com/osnosn/p/16417701.html) 来自[osnosn的博客](https://www.cnblogs.com/osnosn/)**，写于 2022-06-27.

### 参考

- 【[Linux中KVM的部署安装,管理及VNC的使用](https://blog.csdn.net/qq_42747175/article/details/83312418)】
- 【[在centos7.5上安装kvm,通过VNC远程连接并创建多台ubuntu虚拟机](https://www.cnblogs.com/dengyungao/p/9572347.html)】
- 【[在CentOS 8上安装 KVM / QEMU 进行虚拟化](https://blog.51cto.com/u_7895411/3670804)】
- 【[Centos8搭建KVM](https://www.cnblogs.com/chneki/p/13829568.html)】
- 【[如何在CentOS 8服务器上安装KVM](https://www.onitroad.com/jc/kvm/how-to-install-kvm-on-centos-8-headless-server.html)】
- 【[如何在CentOS 8上安装KVM以及如何在物理服务器上安装和管理虚拟机](https://www.iplayio.cn/post/40393)】
- 【[CentOS 8.1 安装部署KVM虚拟机](https://www.liuwg.com/archives/kvm)】
  【[CentOS 8.1 KVM网桥的配置](https://www.liuwg.com/archives/kvm-bridge)】
  【[CentOS 8.1下VNC安装与配置](https://www.liuwg.com/archives/vncserver)】
- 【[Linux 桌面玩家指南：07. Linux 中的 Qemu、KVM、VirtualBox、Xen 虚拟机体验](https://www.cnblogs.com/youxia/p/LinuxDesktop007.html)】

### Centos8 最简安装 KVM

- 使用 Centos8，(2022-8月测试)。

- 环境是: 不使用本地 console。使用 ssh 远程连接服务器，在线安装 kvm。
  先 ssh 登录服务器，然后运行 tmux 防止意外掉线。

- `lscpu | egrep 'vmx|svm'` 检查cpu支持虚拟化。
  vmx 是 Intel的，svm 是 AMD的。

- `lsmod | grep kvm` 内核是否加载 kvm 模块。
  如无，则 `modprobe kvm` 加载。

- `yum install virt-install` **vm客户机的命令行安装工具**。
  download size: 12MB, 装完占55MB (32 packages)

- `virt-host-validate` 环境检查。输出一堆 PASS。

- 这个时候，`ip addr` 显示2个设备: lo, ens33。没有 bridge。

- ```
  yum module install virt
  ```

   

  安装 KVM 服务端环境

  。

  download size: 91MB, 装完占330MB (154 packages)

  - 如要,更简的安装，就只装 `yum install libvirt`，就有 libvirt-daemon 包了。
    download size: 26MB (70 packages) 我没有使用这种极简的方式安装。

- `systemctl start libvirtd` **启动daemon**。

- `systemctl enable libvirtd` **激活开机启动**。

- 这个时候，`ip addr` 显示4个: lo, ens33, virbr0, virbr0-nic 。
  virbr0 就是NAT网络。vm客户机可以访问外网，有dnsmasq。

- `virsh net-list` 只看到一个名称 default。

- `virsh net-info default` 显示这个 default 使用的是 virbr0。

- 如果要修改 default网络(

  virbr0

  ) 的 IP 和 网段。

  - `virsh net-edit default`, 其实就是修改 `/etc/libvirt/qemu/networks/default.xml`。
  - 重启这个default网络。`virsh net-destroy default; virsh net-start default` 生效。

- 创建网络，见下文。

- `nmcli device` 见到 virbr0是bridge, vribr0-nic 是tun设备。

```vhdl
DEVICE      TYPE      STATE                   CONNECTION
ens33       ethernet  connected               ens33
virbr0      bridge    connected (externally)  virbr0
lo          loopback  unmanaged               --
virbr0-nic  tun       unmanaged               --
```

- `nmtui` 中看到一个物理网卡，一个 bridge。不要在 nmtui 中修改 virbr0 的配置。
- 到此，kvm安装完成。创建vm客户机，不能使用"桥接模式"。
  因为没有为本机的物理网口创建网桥。后面用到"桥接"再说。
  网桥设置参考: 【[CentOS 8.1 KVM网桥的配置](https://www.liuwg.com/archives/kvm-bridge)】
- 其他的包:
  - `yum install virt-manager` 管理vm客户机的 GUI工具。
  - `yum install virt-viewer` 用于连接vm客户机的桌面, GUI 工具
    (download size: 44MB, 113 packages)
  - `dnf install cockpit cockpit-machines` Cockpit Web控制台

### Debian11 最简安装 KVM

- 使用 debian11(bullseye)，(2022-8月测试)。

- 环境是: 不使用本地 console。使用 ssh 远程连接服务器，在线安装 kvm。
  先 ssh 登录服务器，然后运行 tmux 防止意外掉线。

- `lscpu | egrep 'vmx|svm'` 检查cpu支持虚拟化。
  vmx 是 Intel的，svm 是 AMD的。

- `lsmod | grep kvm` 内核是否加载 kvm 模块。
  如无，则 `modprobe kvm` 加载。

- `apt update`

- ```
  apt install libvirt-daemon-system
  ```

   

  安装libvirtd服务

  。

  会自动装上 libvirt-daemon, libvirt-client, qemu-k

  vm

  , qemu-utils,

  download 207MB, 694MB disk space will be used. 304 packages.

  - qemu-system 是其他架构cpu(arm,ppc,...)的支持。我没装。

- `apt install virtinst` **安装virt-install工具**。
  download 4MB, 20MB disk space will be used. 26 packages.

- 这时候，`ip addr` 没有新增 bridge。
  libvirtd 服务已经启动。
  `virsh net-list` 是空的。
  `virsh net-list --all` 显示default 是inactive。

- `virsh net-start default` **启动default网络**。
  `virsh net-autostart default` **自动启动default网络**。

- 这时候，`ip addr` 多出一个 virbr0 的 bridge。

- `virsh net-info default` 显示这个 default 网络的信息。

- `virsh net-edit default`, 修改 default网络(virbr0) 的 IP 和 网段。
  `virsh net-destroy default; virsh net-start default` 重启这个default网络,生效。

- 创建网络，见下文。

- 到此，kvm安装完成。创建vm客户机，不能使用"桥接模式"。
  因为没有为本机的物理网口创建网桥。后面用到"桥接"再说。
  网桥设置参考: 【[如何在 Debian 11 Bullseye Linux 上安装和配置 KVM](https://blog.csdn.net/allway2/article/details/122160151)】

## 创建网络

- virsh net-create name.xml 创建一个临时网络并启用，重启系统后丢失。
  - 能 start，destroy。但不能设置 autostart。
- virsh define name.xml 创建一个永久网络。
  - 能 start，destroy。也能设置 autostart。
- nat网络,带dhcp的例子

```xml
<!--
 文件名: my-wan.xml
-->
<network>
  <name>my-wan</name>
  <forward mode='nat'/>
  <bridge name='virbr1' stp='on' delay='0'/>
  <ip address='192.168.22.22' netmask='255.255.255.0'>
    <dhcp>
      <range start='192.168.22.100' end='192.168.22.200'/>
    </dhcp>
  </ip>
</network>
```

- 隔离网络,无dhcp的例子

```xml
<!--
 文件名: my-lan.xml
-->
<network>
  <name>my-lan</name>
  <bridge name='virbr1' stp='on' delay='0'/>
  <ip address='192.168.22.22' netmask='255.255.255.0'>
  </ip>
</network>
```

## KVM 虚拟化嵌套

- vm客户机的cpu是否支持vmx。

- Centos8

  默认未打开。

  - `cat /sys/module/kvm_intel/parameters/nested` 0:关闭，1:打开。
  - 修改 `/etc/modprobe.d/kvm.conf` 中 `options kvm_intel nested=1`
    `rmmod kvm-intel` 或者 `modprobe -r kvm-intel` 卸载。
    `modprobe kvm-intel nested=1` 重新加载。
    或者，重启整个系统。

- Debian11默认是打开的。

## 安装 VM 客户机

### qcow2 的镜像 测试

- 镜像来源
  `https://openwrt.cc/snapshots/targets/x86/64/immortalwrt-x86-64-generic-ext4-combined-efi.qcow2.gz`
- 用 gunzip 解压。
- `mv immortalwrt-.....efi.qcow2 /var/lib/libvirt/images/`
- `qemu-img info immortalwrt-.....efi.qcow2` 看到这个镜像的虚拟大小是814MB.

#### Centos8 , Debian11

- 创建 VM 客户机

```diff
virt-install \
--virt-type kvm \
--name opwrt2 \
--memory 512 \
--vcpus 1 \
--cpu host-passthrough \
--os-variant archlinux \
--network bridge=virbr0,model=virtio \
--graphics vnc \
--import \
--noautoconsole \
--autostart \
--disk path=/var/lib/libvirt/images/immortalwrt-x86-64-generic-ext4-combined-efi.qcow2,bus=virtio,format=qcow2
```

- virsh 部分命令列表:
  `virsh start opwrt2` 启动
  `virsh list --all` 列出所有vm客户机
  `virsh suspend opwrt2` 暂停
  `virsh resume opwrt2` 恢复
  `virsh dhutdown opwrt2` 正常关机
  `virsh destroy opwrt2` 强制关机
  `virsh undefine opwrt2` 删除vm客户机

- 修改 opwrt2 的 LAN口IP。
  `virsh console opwrt2` 连接终端。按 `^]` 退出终端。
  改 `/etc/config/network` 中，IP 为 192.168.122.10。
  `/etc/init.d/network reload` 重启生效。

- 用 putty 通过 ssh 登录宿主机。

  在 putty 的

   

  ```
  主菜单
  ```

   

  ->

   

  ```
  Change Settings...
  ```

   

  ->

   

  ```
  Connection
  ```

   

  ->

   

  ```
  SSH
  ```

   

  ->

   

  ```
  Tunnels
  ```

   

  中。

  ```
  Source port
  ```

  :

   

  ```
  9988
  ```

  ,

   

  ```
  Destination
  ```

  :

   

  ```
  192.168.122.10:80
  ```

  , 点击

   

  ```
  Add
  ```

  , 点击

   

  ```
  Apply
  ```

  。

  - 打开浏览器，访问 localhost:9988。配置 opwrt2。
    设置 LAN 的 网关，dns。关掉 LAN 的 dhcp。
  - 配置完成后。直接在 putty 中退出登录宿主机(要等2min才会完全退出)，即可。

### img 的镜像 测试

- 镜像来源
  `https://downloads.openwrt.org/releases/21.02.3/targets/x86/64/openwrt-21.02.3-x86-64-generic-ext4-combined-efi.img.gz`
- 用 gunzip 解压。
- `mv openwrt-21.02.3-.....efi.img /var/lib/libvirt/images/`
- `qemu-img info openwrt-21.02.3-.....efi.img` 看到这个镜像的虚拟大小是121MB.
- **如需扩容**,参考:【[openwrt_21.02_img_空间扩容_改分区表大小](https://www.cnblogs.com/osnosn/p/15524655.html)】

#### Centos8 , Debian11

- 创建 VM 客户机

```diff
virt-install \
--virt-type kvm \
--name opwrt21 \
--memory 256 \
--vcpus 1 \
--cpu host-passthrough \
--os-variant archlinux \
--network bridge=virbr0,model=virtio \
--graphics vnc \
--import \
--noautoconsole \
--autostart \
--disk path=/var/lib/libvirt/images/openwrt-21.02.3-x86-64-generic-ext4-combined-efi.img,bus=virtio,format=raw
```

- 修改 LAN口IP。配置 openwrt。同 qcow2 的镜像测试。

## NAT 端口映射

- 参考: 【

  kvm虚拟机端口映射（端口转发）到宿主机

  】

  - 以下是针对,带有nat的网络，进行端口转发。因为已经有从 内->外 的 MASQUERADE 的伪装规则，从 内->外 的转发规则。
  - 检查"包转发"已经打开。`sysctl net.ipv4.ip_forward` 应该显示=1。
  - 允许从 外->内 的转发。
    `iptables -I FORWARD -m state -o virbr0 -d 192.168.122.0/24 --state NEW,RELATED,ESTABLISHED -j ACCEPT`
    这个命令只需设置一次。注意 virbr0 和 ip 段，要改成你自己的。
    这个规则也可以限制严格一点，比如,加上 `--dport`，限制tcp `-p tcp`。
  - 用 `iptables -t nat -I PREROUTING -p tcp --dport 1234 -j DNAT --to-destination 192.168.122.10:5678` 实现。
    不同端口，使用不同的规则。
    从外部连接这个端口，vm客户机中的应用，获取的是真实的"来源IP"。
  - Centos8 用 `firewall-cmd --permanent --add-forward-port=port=1234:proto=tcp:toport=5678:toaddr=192.168.122.10` 命令实现。
    或者用 `firewall-cmd --zone=my_zone --add-rich-rule="..."`
  - nft 的办法类似，需要自己写规则。

- 为了宿主机重启之后，保留端口映射

  。把上述两条规则，写入到

   

  ```
  /etc/rc.local
  ```

   

  中。

  - 如果有`/etc/rc.local`这个文件，就保留里面的内容。如果没有这个文件，则自己创建。
    `echo -e '#!/bin/sh\n\nexit 0' >> /etc/rc.local; chmod +x /etc/rc.local`
  - 然后把规则写在 `/etc/rc.local` 中, `exit 0` 这行的前面。

- 不带nat的网络，如果要映射。应该也可以。(没测试)

  - 首先，允许双向转发。
  - 然后，应该是用 SNAT + DNAT 的一对规则实现吧。

## 映像文件转换格式

- 用 qemu-img 。
  - debain 装 `apt install qemu-utils` 。
  - centos8 装 `yum install qemu-img` 。
- `qemu-img -h` 查看帮助。resize 是改映像大小，convert 是改格式。
  `qemu-img info 映像文件名` 查看文件的格式类型。
  支持 img(raw), vhdx, vmdk, vdi, qcow, qcow2, dmg, ... 等很多格式，互相转换。
- 例子，
  `qemu-img resize -f raw 映像文件名.img +200M`
  `qemu-img convert -f raw -O vhdx 输入的映像名.img 输出的映像名.vhdx`

----end----

------

**转载注明来源: 本文链接 https://www.cnblogs.com/osnosn/p/16417701.html**
**来自 osnosn的博客 https://www.cnblogs.com/osnosn/** .


````





# 2`Linux系统下如何查看及修改文件读写权限

```
掌握Linux文件权限，看这篇就够了
老油条IT记
老油条IT记
3 人赞同了该文章
​作者：老油条IT记
公众号：老油条IT记
#前言
我们知道，无论什么东西，涉及到安全性的，比如文件、文件夹、磁盘(就如window系统的磁盘，我们就可以通过bitlocker技术将磁盘给加密锁起来)、服务器，等都需要设置权限管理，以保证安全性，接下来让我们来探讨以下Linux的文件权限。

1.权限概述
权限是操作系统用来限制对资源访问的机制，权限一般分为读、写、执行。系统中的每个文件都拥有特定的权限、所属用户及所属组，通过这样的机制来限制哪些用户、哪些组可以对特定文件进行什么样操作。

#Linux中权限基于UGO模型进行控制
u:代表user(用户)
g:代表group(组)
o:代表other(其他)

#查看权限
[root@ctos3 ~]# ls -ld test
drwxr-xr-- 2 root root 6 Mar 9 01:37 test
#讲解：第一个d是文件类型，后面9位3个为一组





#文件权限说明
文件或目录的权限位是由9个权限位来控制的，每三位一组，分别是文件属主(Owner)、用户组(Group)、其他(Other)用户的读、写、执行

其中
r(read)读权限， 可以读取文件内容，可以列出目录内容 用数字表示为4
w(write)写权限， 可以修改文件内容，可以在目录中创建删除文件 用数字表示为2
x(excute)执行权限，可以作为命令执行，可以访问目录内容 用数字表示为1
- 没有权限， 用数字表示为0

2.修改文件所属用户、所属组
#2.1.使用chown命令改变文件/目录的所属用户
修改格式：
chown 用户 文件名/目录名

#例子
将test.txt的所属用户从root更改为demo用户
[root@ctos3 ~]# ls -l test.txt
-rw-r--r-- 1 root root 0 Mar 9 01:36 test.txt
[root@ctos3 ~]# chown demo test.txt #更改
[root@ctos3 ~]# ls -l test.txt
-rw-r--r-- 1 demo root 0 Mar 9 01:36 test.txt

#参数介绍
-R 参数递归的修改目录下的所有文件的所属用户
#例子
将/test目录下的所有文件和用户所属用户修改成demo
[root@ctos3 ~]# chown -R demo /test/
[root@ctos3 ~]# ls -l /test/
drwxr-xr-x 3 demo root 16 Mar 9 01:55 aa

#2.2.使用chgrp改变文件/目录的所属组
命令格式
chgrp 用户 文件/目录名

#例子：
[root@ctos3 ~]# chgrp demo /test/
[root@ctos3 ~]# ls -ld /test/
drwxr-xr-x 3 demo demo 16 Mar 9 01:55 /test/
#注意点：一般都是用chown修改用户和组的了 格式chown -R 用户.组 + 文件

#2.3.使用chmod命令修改文件/目录的权限
命令格式
chmod +模式 +文件

模式为如下格式：
1.u、g、o、分别代表用户、组和其他
2.a可以代指ugo
3.+、-代表加入或删除对应权限
4.r、w、x代表三种权限

#示例
chmod u+rw test.txt #给所属用户权限位添加读写权限
chmod g+rw test.txt #给所属组权限位添加读写权限
chmod o+rw test.txt #给其他用户权限位添加读写权限
chmod u=rw test.txt #设置所属用户权限位的权限位读写
chmod a-x test.txt #所有权限为去掉执行权限

#修改权限2
命令chmod也支持以数字方式修改权限，三个权限分别由三个数字表示：
r=4
w=2
x=1

使用数字表示权限时，每组权限分别对应数字之和：
rw=4+2＝6
rwx＝4+2+1＝7
r-x＝4+1＝5

语法:
chmod 755 文件或文件夹名字

例：
[root@centos7 ~]# touch test.txt
[root@centos7 ~]# chmod 755 test.txt

3.默认权限
每一个终端都拥有一个umask属性，来确定新建文件、文件夹的默认权限

/etc/profile文件可以看到设置的umask值
if [ $UID -gt 199 ] && [ "/usr/bin/id -gn" = "/usr/bin/id -un" ]; then
umask 002
else
umask 022
fi
#注释：如果UID大于199并且用户的组名和用户名一样，umask值为002，否则就为022
#注释：gt在shell脚本中是大于，id -gn:显示组名，id -un:显示用户名

#UID小于199并且用户的组名和用户名一样
目录创建的默认权限为777-umask 就是755
文件创建的默认权限为777-umask 就是644

#例子：
#root用户创建文件，权限为644，uid为0
[root@centos7 ~]# touch test.txt
[root@centos7 ~]# ls -l test.txt
-rw-r--r--. 1 root root 0 Jul 13 00:30 test.txt

#切换到普通用户创建文件，权限为664，uid大于199
[root@centos7 ~]# su - test
Last login: Mon Jul 13 00:07:25 EDT 2020 on pts/0
[test@centos7 ~]$ touch test1.txt
[test@centos7 ~] ls -l test1.txt
-rw-rw-r--. 1 test test 0 Jul 13 00:31 test1.txt

#可以使用umask查看设置的umask值
[root@ctos3 ~]# umask
0022

#如果想要创建的文件权限多少，可以自己定义
[root@ctos3 ~]# umask 035 #设置默认umask为035，创建出来的文件默认权限为642
[root@ctos3 ~]# touch fil035
[root@ctos3 ~]# ls -l fil035
-rw-r---w- 1 root root 0 Mar 9 02:25 fil035
#注意为什么是642，而不是631呢，因为是奇数的话就会加1，从之前默认权限6就会加到7，用7-3就是4，7-5就是2，0为偶数所以还是6，所以为642

[root@ctos3 ~]# umask 022 #设置022，创建文件的权限为644
[root@ctos3 ~]# touch fil022
[root@ctos3 ~]# ls -l fil022
-rw-r--r-- 1 root root 0 Mar 9 02:25 fil022

4.特殊权限
Linux系统中的基本权限位为9位权限，加上3位特殊权限位，共12位权限 文件的特殊权限：suid,sgid,sticky

suid:是针对二进制可执行程序上的，对目录设置无效
suid作用：让普通用户可以以root(或其他)的用户角色运行只有root才能运行的程序或命令
suid数字表示为4，在文件所有者权限的第三位为小写的s，就代表拥有suid属性

sgid:既可以针对文件也可以针对目录设置
sgid作用：在设置了sgid权限的目录下建立文件时，新创建的文件的所属组会继承上级目录的所属组
sgid数字表示为2，在文件所属组权限的第三位为小写的s，就代表拥有sgid属性

sticky:设置sticky可以将自己的文件保护起来
sticky数字表示为1,在其他用户权限位的第三位为小写t
#示例
[root@centos7 ~]# chmod o+t /data/
[root@centos7 ~]# ls -ld /data/
drwxr-xr-t. 2 root root 6 Jul 13 03:20 /data/

#查找系统中的有特殊权限位文件

[root@centos7 ~]# find /usr/bin -type f -perm 4755 -exec ls -l {} ;
-rwsr-xr-x. 1 root root 32096 Oct 30 2018 /usr/bin/fusermount
-rwsr-xr-x. 1 root root 73888 Aug 8 2019 /usr/bin/chage
-rwsr-xr-x. 1 root root 78408 Aug 8 2019 /usr/bin/gpasswd
-rwsr-xr-x. 1 root root 41936 Aug 8 2019 /usr/bin/newgrp
-rwsr-xr-x. 1 root root 44264 Apr 1 00:51 /usr/bin/mount
-rwsr-xr-x. 1 root root 32128 Apr 1 00:51 /usr/bin/su
-rwsr-xr-x. 1 root root 31984 Apr 1 00:51 /usr/bin/umount
-rwsr-xr-x. 1 root root 57656 Aug 8 2019 /usr/bin/crontab
-rwsr-xr-x. 1 root root 23576 Apr 1 00:07 /usr/bin/pkexec
-rwsr-xr-x. 1 root root 27856 Mar 31 23:57 /usr/bin/passwd

[root@centos7 ~]# find /usr/bin -type f -perm 2755 -exec ls -l {} ;
-rwxr-sr-x. 1 root tty 19544 Apr 1 00:51 /usr/bin/write

[root@centos7 ~]# ls -ld /tmp/
drwxrwxrwt. 12 root root 4096 Jul 13 08:14 /tmp/

#设置特殊权限
#1.设置suid针对用户的
命令格式：chmod 4755 file 或者 chmod u+s file

#例子：
[root@centos7 ~]# useradd user1
[root@centos7 ~]# su - user1
[user1@centos7 ~]$ less /etc/shadow
/etc/shadow: Permission denied

[user1@centos7 ~]$ su - root
[root@centos7 ~]# chmod u+s /usr/bin/less #添加suid权限

[root@centos7 ~]# su - user1
Last login: Mon Jul 13 08:19:26 EDT 2020 on pts/0
[user1@centos7 ~]$ less /etc/shadow #可以查看
[root@centos7 ~]# ll /usr/bin/less
-rwsr-xr-x. 1 root root 158240 Jul 30 2015 /usr/bin/less
[root@centos7 ~]# chmod 4755 /usr/bin/less #相当于u+s

#2.设置sgid(针对组的)
命令格式：chmod 2755 file 或者 chmod g+s file

#例子：
[root@centos7 ~]# mkdir test
[root@centos7 ~]# ls -ld test
drwxr-xr-x. 2 root root 6 Jul 13 08:28 test

[root@centos7 ~]# chmod g+s test #设置sgid权限
[root@centos7 ~]# ls -ld test
drwxr-sr-x. 2 root root 6 Jul 13 08:28 test

[root@centos7 ~]# chgrp test1 test/
[root@centos7 ~]# ls -ld test/
drwxr-sr-x. 2 root test1 20 Jul 13 08:29 test/

[root@centos7 ~]# touch test/aa.txt #创建新文件的所属组会继承上级目录的
[root@centos7 ~]# ls -l test/aa.txt
-rw-r--r--. 1 root test1 0 Jul 13 08:29 test/aa.txt

#3.设置sticky(可以将自己文件保护起来)
命令格式：chmod o+t file

#例子：
[root@ctos3 ~]# touch 3.txt
[root@ctos3 ~]# chmod o+t 3.txt
[root@ctos3 ~]# ls -ld 3.txt
-rw-r--r-T 1 root root 0 Mar 9 02:38 3.txt

#有关suid和sgid总结
1.suid是针对命令和二进制程序的
2.suid作用是让普通用户以root（或其他）的用户角色运行只有root（或其他）账号才能运行的程序或命令，或程序命令对应本来没有权限操作的文件等
3.sgid与suid不同的是，sgid既可以针对文件也可以针对目录设置
4.sgid是针对用户组权限位的

5.查看和修改文件属性命令lsattr,chattr
lsattr：显示文件属性
chattr：修改文件属性

参数：
-a：只能追加内容,
-i：不能被修改
+a :(append)只能追加内容，如echo “111” >> test.txt
+i :(Immutable:不可改变) 系统不允许对这个文件进行任何的修改
-a：移除a参数
-i：移除i参数

#例子：
root@ctos3 ~]# mkdir attribute
[root@ctos3 ~]# cd attribute/
[root@ctos3 attribute]# echo "file attribution" > attribution.txt
[root@ctos3 attribute]# lsattr
---------------- ./attribution.txt
#根据上面操作。使用lsattr查看没有赋予任何属性，下面就使用chattr来为文件添加属性

[root@ctos3 attribute]# chattr +i attribution.txt
[root@ctos3 attribute]# lsattr
----i----------- ./attribution.txt
#提示：添加i属性到文件之后，即使是root用户也不能修改、删除文件，可以加a权限，但是添加了也不能删除文件，知道将这两个权限删除，才能删除修改文件

[root@ctos3 attribute]# chmod 655 attribution.txt
chmod: changing permissions of ‘attribution.txt’: Operation not permitted
[root@ctos3 attribute]# rm attribution.txt
rm: remove regular file ‘attribution.txt’? y
rm: cannot remove ‘attribution.txt’: Operation not permitted
```



# CentOS 8下载及版本说明

仲浩的博客

于 2021-09-03 17:17:18 发布

3595
 收藏 9
分类专栏： Linux 文章标签： centos linux
版权

Linux
专栏收录该内容
10 篇文章0 订阅
订阅专栏
下载地址
centOS官网
linux.org
Linux与Stream版本说明

版本	详情
CentOS Linux	支持64位的32位扩展版(一般安装这个)
CentOS Stream	最新特性的前沿实验版
ISO 版本说明

版本	描述
X86_X64	带64位的32位扩展版(一般安装这个)
ARM64 (aarch64)	嵌入式,适用于微端(树莓派,机械臂,机械中控)
IBM Power (ppc64le)	专用于IBM POWER服务器
下载列表下载版本
版本说明

版本	描述
CentOS-8.4.2105-x86_64-boot.iso	只包含最基本的boot引导程序
CentOS-8.4.2105-x86_64-boot.iso.manifest	boot依赖列表文件(指定依赖库)
CentOS-8.4.2105-x86_64-boot.torrent	boot的 BT 文件
CentOS-8.4.2105-x86_64-dvd1.iso	包含系统和必要软件的完整版(推荐安装)
CentOS-8.4.2105-x86_64-dvd1.iso.manifest	系统与所含软件的依赖列表文件(指定依赖库)
CentOS-8.4.2105-x86_64-dvd1.torrent	完整版 BT 文件
文章知识点与官方知识档案匹配，可进一步学习相关知识



CentOS8使用命令ifconfig没有ens33解决方法

杉叔

于 2022-01-04 16:07:35 发布

878
 收藏 2
分类专栏： CentOS8 文章标签： 网络 linux 服务器
版权

CentOS8
专栏收录该内容
5 篇文章0 订阅
订阅专栏

# CentOS8使用命令ifconfig没有ens33解决方法

1、使用ifconfig查看网络
# 输入命令
ifconfig
1
2


# 查看托管状态
nmcli n
1
2


2、解决方法
# 启动命令
systemctl start NetworkManager
1
2


# 查看
ifconfig
1
2
1)]

# 查看
ifconfig
1
2

