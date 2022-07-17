#红帽
##•	使用CTRL-ALT-F[1-6]键可切换不同虚拟控制台
•	按CTRL-ALT-F7键可进入图形控制台
##•	命令有着如下的语法
–	command options arguments
•	项与项之间以空格分隔开
•	options修饰一个命令的行为
–	单字母选项前一般都带有-,例如-a,-b,-c或者-abc
–	全字选项前通常带有--,例如:--help

•	date – 显示当前日期和时间
•	cal – 显示日历

##•	多种层次的帮助
–	whatis
–	command --help
–	man和info
–	/usr/share/doc/ Red Hat文档
###查看命令帮助文档
•	当查看man页面时:
–	使用PgUp,PgDn箭头来浏览
–	使用/text来查询text
–	n或者N定位到下一个或者上一个匹配的位置
–	q退出
•	查找手册
–	man –k keyword列出所有匹配的页
###•	当查看一个info页面时:
–	通过箭头PgUp,PgDn
–	Tab键移动到下一个链接
–	Enter符进入到选择的链接
–	n/p,/u/l 定位到下一个/前一个,上一个/最近一个节点
–	s text搜索文本(缺省为上一次搜索的)
–	q命令退出info

##命令组合
–	x|y|z表示”x 或者y或者z”
–	-abc表示”任意-a,-b或者-c的任意组合

##已经保存的包
•	在/usr/share/doc目录中
•	子目录保存大部分已经安装的包
•	以下这些文档的位置不适合放在它处
–	示例配置文件
–	HTML/PDF/PS文档
–	License详细信息

##一些重要的目录

•	主目录:/root,/home/username
•	用户可执行的目录:/bin,/usr/bin,/usr/local/bin
•	系统可执行目录:/sbin,/usr/sbin,/usr/local/sbin
•	其它加载点:/media, /mnt
•	配置目录:/etc
•	临时文件目录:/tmp
•	内核和引导启动目录:/boot
•	服务目录:/var,/srv
•	系统信息目录:/proc,/sys
•	共享库目录:/lib,usr/lib,/usr/local/lib

##命名
•	任何shell和系统进程都有当前工作目录(cwd)
•	pwd命令
–	显示shell的cwd的绝对路径

#路径
•	绝对路径
–	以斜线开头
–	文件位置的全路径
–	采用绝对路径可以到处使用
•	相对路径
–	不以斜线开头
–	当前工作目录的相对位置
–	可以通过相对路径方式来指定一个文件名
# cd
•	cd命令改变目录
•	改变到一个绝对或者相对路径
–	cd /home/joshua/work
–	cd project/docs
•	改变到上层目录
–	cd ..
•	改变到当前用户的主目录
–	cd
•	改变目录到上一个工作目录
–	cd -







[root@localhost ~]# chmod 777 /home/user 注：仅把/home/user目录的权限设置为rwxrwxrwx

[root@localhost ~]# chmod -R 777 /home/user 注：表示将整个/home/user目录与其中的文件和子目录的权限都设置为rwxrwxrwx


想一次修改某个目录下所有文件的权限，包括子目录中的文件权限也要修改，要使用参数－R表示启动递归处理。

 

例如：

 

[root@localhost ~]# chmod 777 /home/user 注：仅把/home/user目录的权限设置为rwxrwxrwx

[root@localhost ~]# chmod -R 777 /home/user 注：表示将整个/home/user目录与其中的文件和子目录的权限都设置为rwxrwxrwx
















