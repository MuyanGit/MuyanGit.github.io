title: NodeJs 的安装及配置环境变量
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2021-11-10 22:40:08
authorAbout:
series:
tags: NodeJs 
keywords:
description:

photos: https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110225515117.png
---





set 限制解除 

# NodeJs 的安装及配置环境变量



[Alisone_li](https://blog.csdn.net/zimeng303) 2021-01-04 10:56:24 



### NodeJs 的安装及配置环境变量

- [一、Node.js 下载与安装](https://blog.csdn.net/zimeng303/article/details/112167688#Nodejs__1)
- [二、Node.js环境变量配置](https://blog.csdn.net/zimeng303/article/details/112167688#Nodejs_31)
- [三、国内镜像网站配置](https://blog.csdn.net/zimeng303/article/details/112167688#_79)



# 一、Node.js 下载与安装

**下载**

1. 在 [Node官网](https://nodejs.org/zh-cn/) 上，下载对应的安装包
   ![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/20210104083349537.png)
   这里下载的是 64位window系统 的安装文件 `node-v14.15.3-x64`

**安装**

1. 点击安装文件，开始安装 `node.js`
   ![在这里插入图片描述](https://img-blog.csdnimg.cn/20210104083632728.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3ppbWVuZzMwMw==,size_16,color_FFFFFF,t_70)

2. 点击 Next (下一步)

   **初次安装**
   ![在这里插入图片描述](https://img-blog.csdnimg.cn/20210104084514501.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3ppbWVuZzMwMw==,size_16,color_FFFFFF,t_70)
   **已安装NodeJs，再次安装**
   ![在这里插入图片描述](https://img-blog.csdnimg.cn/20210104083942430.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3ppbWVuZzMwMw==,size_16,color_FFFFFF,t_70)

3. 勾选同意选项(I accept the terms …)，并点击 Next (下一步)
   ![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/20210104085506611.png)

4. 选择node.js的安装目录，这里选择安装在E盘
   ![在这里插入图片描述](https://img-blog.csdnimg.cn/2021010408571977.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3ppbWVuZzMwMw==,size_16,color_FFFFFF,t_70)

5. 接着一直点击 Next (下一步) 到下面的界面
   ![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/20210104090119293.png)

6. 点击 Install (安装)
   ![在这里插入图片描述](https://img-blog.csdnimg.cn/20210104090307991.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3ppbWVuZzMwMw==,size_16,color_FFFFFF,t_70)

7. 点击 Finish，完成安装
   ![在这里插入图片描述](https://img-blog.csdnimg.cn/20210104090426794.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3ppbWVuZzMwMw==,size_16,color_FFFFFF,t_70)

8. 使用 window + R 快捷键，启动 `cmd命令行` 验证 `node.js` 是否安装成功
   ![在这里插入图片描述](https://img-blog.csdnimg.cn/20210104092934341.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3ppbWVuZzMwMw==,size_16,color_FFFFFF,t_70)
   出现以上情况，即表示安装成功

# 二、Node.js环境变量配置

> - 在上面已经完成了 `node.js` 的安装，即使不进行此步骤的环境变量配置也不影响node.js的使用
> - 但是，若不进行环境变量配置，那么在使用命令安装 `node.js全局模块` （如：npm install -g vue）时，会默认安装到C盘的路径 (`C:\Users\hua\AppData\Roaming\npm`) 中
> - 因此，需要配置 **全局安装模块 `node_global`** 以及 **缓存目录 `node_cache`** 的环境变量；

1. 在**node.js的安装目录**中，新建两个文件夹 `node_global` 和 `node_cache`，分别用来存放安装的全局模块和全局缓存信息
   ![在这里插入图片描述](https://img-blog.csdnimg.cn/20210104094550475.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3ppbWVuZzMwMw==,size_16,color_FFFFFF,t_70)

2. 创建完两个文件夹后，在cmd窗口中输入以下命令（两个路径即是两个文件夹的路径）：

   ```powershell
     # 设置全局模块安装路径
     npm config set prefix "E:\leading\NodeJs\info\node_global"
     # 设置全局缓存存放路径
     npm config set cache "E:\leading\NodeJs\info\node_cache"
   
   ```

   命令执行，效果如图： ![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/20210104095317507.png)

3. 设置电脑环境变量，环境变量界面打开顺序：`右键 “我的电脑”=》属性=》高级系统设置=》环境变量` ，具体实行过程，请看下图：
   ![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/20210104100243947.png)

4. 进入环境变量对话框，在【系统变量】中新建环境变量 `NODE_PATH`，值为 `E:\leading\NodeJs\info\node_global\node_modules`，其中 `E:\leading\NodeJs\info\node_global` 是新创建的全局模块安装路径

   eg:

![image-20211110225626509](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110225626509.png)

![image-20211110225515117](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110225515117.png)

1. ![在这里插入图片描述](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/20210104100859831.png)

2. 修改【用户变量】中的 `path` 变量，将 `C:\Users\86135\AppData\Roaming\npm` 修改为`E:\leading\NodeJs\info\node_global`

   ![image-20211110225742011](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211110225742011.png)

   eg:

   **修改前**
   ![在这里插入图片描述](https://img-blog.csdnimg.cn/20210104101707544.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3ppbWVuZzMwMw==,size_16,color_FFFFFF,t_70)
   **修改后**
   ![在这里插入图片描述](https://img-blog.csdnimg.cn/2021010410150955.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3ppbWVuZzMwMw==,size_16,color_FFFFFF,t_70)

3. 点击确定后，配置完成。

4. 测试是否配置成功，在cmd窗口中输入以下指令 全局安装Vue模块

   ```powershell
    npm install -g vue # -g 表示全局安装
   
   ```

   执行效果，如图所示：![在这里插入图片描述](https://img-blog.csdnimg.cn/20210104102133308.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3ppbWVuZzMwMw==,size_16,color_FFFFFF,t_70)
   vue 模块安装目录，如图所示：
   ![在这里插入图片描述](https://img-blog.csdnimg.cn/2021010410231073.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3ppbWVuZzMwMw==,size_16,color_FFFFFF,t_70)
   可以看出，node.js环境变量配置成功。

5. 至此，node.js安装和环境变量配置全部完成。

**注意**

> 配置完，一定要重启，否则不生效
>
> 配置完，一定要重启，否则不生效
>
> 配置完，一定要重启，否则不生效

# 三、国内镜像网站配置

配置国内镜像，解决模块安装缓慢或者失败的问题。

一般配置 `淘宝npm镜像`

**直接切换**

1. 在 cmd 命令行中，通过命令配置淘宝镜像

   ```powershell
     npm install -g cnpm --registry=https://registry.npm.taobao.org
   1
   ```

2. 使用淘宝镜像下载模块，即，将 `npm` 替换成 `cnpm` 即可

   ```powershell
     cnpm install # module_name
   1
   ```

**切换工具**

上述切换镜像的方式比较麻烦。这里推荐一款切换镜像的工具：`nrm`

1. 使用

    

   ```
   npm
   ```

    

   全局安装

    

   ```
   nrm
   ```

   ```powershell
     npm install nrm -g
   
   ```

   执行命令，效果如下：

   

2. 通过

    

   ```
   nrm ls
   ```

    

   命令，查看npm的仓库列表，带

    

   ```
   *
   ```

    

   的就是当前选中的镜像仓库：

   ```powershell
     nrm ls
   
   ```

   执行命令，效果如下：

   

3. 通过

    

   ```
   nrm use taobao
   ```

    

   来指定要使用的镜像源：

   ```powershell
     nrm use taobao
   
   ```

   执行命令，效果如下：

   

4. 最后，通过

    

   ```
   nrm test npm
   ```

    

   来测试速度：

   ```powershell
     nrm test npm
   
   ```

   执行命令，效果如下：

   

