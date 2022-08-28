@echo OFF
%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit

rem 终结进程：
::taskkill /f /t /im  conhost.exe


rem 备份博客MuyanGit
ping 127.0.0.1 -n 3 >nul
start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\bk.lnk