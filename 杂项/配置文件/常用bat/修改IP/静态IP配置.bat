@echo on

%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit

cd /d "%~dp0"   

rem pushd C:\WINDOWS\system32
@rem设置环境变量目录，如bat保存于桌面，无此命令可能无法调用环境变量
 
@rem 设置静态IP，更改网络连接名称为"WLAN"，ip设置为192.168.0.170，子网为255.255.255.0，网关为192.168.0.1
netsh interface ipv4 set address "WLAN" static 192.168.0.170 255.255.255.0 192.168.0.1

netsh interface ipv4 set dns "WLAN" static 192.168.0.1
@rem netsh interface ipv4 add dns "WLAN" static 192.168.1.1


pause
@rem批处理最后加上pause，防止bat运行后自动闪退关闭，可以查看是否有运行错误信息