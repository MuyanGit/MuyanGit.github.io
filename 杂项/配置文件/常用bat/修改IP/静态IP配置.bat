@echo on

%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit

cd /d "%~dp0"   

rem pushd C:\WINDOWS\system32
@rem���û�������Ŀ¼����bat���������棬�޴���������޷����û�������
 
@rem ���þ�̬IP������������������Ϊ"WLAN"��ip����Ϊ192.168.0.170������Ϊ255.255.255.0������Ϊ192.168.0.1
netsh interface ipv4 set address "WLAN" static 192.168.0.170 255.255.255.0 192.168.0.1

netsh interface ipv4 set dns "WLAN" static 192.168.0.1
@rem netsh interface ipv4 add dns "WLAN" static 192.168.1.1


pause
@rem������������pause����ֹbat���к��Զ����˹رգ����Բ鿴�Ƿ������д�����Ϣ