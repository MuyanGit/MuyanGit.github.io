:: 关闭代码.bat 
 
@ECHO OFF
PUSHD %~DP0 & cd /d "%~dp0"
%1 %2
mshta vbscript:createobject("shell.application").shellexecute("%~s0","goto :runas","","runas",1)(window.close)&goto :eof
:runas

::设置服务为自动
::sc config MEmuSVC start= auto
::设置服务为禁用
::sc config MEmuSVC start= disabled


::设置服务为手动·Distributed Link Tracking Client·维护某个计算机内或某个网络中的计算机的 NTFS 文件之间的链接。
sc config TrkWks start= demand
sc stop TrkWks

::设置服务为手动·利用计算机或网络上的可用传真资源发送和接收传真。
sc config Fax start= demand
sc stop Fax

::设置服务为手动```Hyper-V 主机计算服务
sc config vmcompute start= demand
sc stop vmcompute

::设置服务为逍遥模拟器
sc config MEmuSVC start= demand
sc stop MEmuSVC 




exit