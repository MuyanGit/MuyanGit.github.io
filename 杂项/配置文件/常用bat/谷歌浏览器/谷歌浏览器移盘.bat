@echo OFF
%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit

rd/s/q "C:\Program Files\Google\Chrome"
rd/s/q "C:\Program Files (x86)\Google" 
rd/s/q "C:\Users\HI\AppData\Local\Google"
mklink /d "C:\Program Files\Google\Chrome" "D:\MySoftware\Browsers\Google\Chrome"
mklink /d "C:\Program Files (x86)\Google" "D:\MySoftware\Browsers\Google"
mklink /d "C:\Users\HI\AppData\Local\Google" "D:\MySoftware\Browsers\Google\PersonData"
pause