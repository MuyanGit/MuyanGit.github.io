@echo OFF
%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit

rem �ս���̣�
::taskkill /f /t /im  conhost.exe


rem ���ݲ���MuyanGit
ping 127.0.0.1 -n 3 >nul
start D:\MyBackup\�ۺϱ���\��Я�桤���\_����������Ŀ¼����ݷ�ʽ\bk.lnk