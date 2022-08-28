@echo OFF
%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit

taskkill /f /t /im  firefox.exe
taskkill /f /t /im  mshta.exe
taskkill /f /t /im  RustDesk.exe




taskkill /f /t /im  cmd.exe