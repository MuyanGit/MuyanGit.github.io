@echo OFF
%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit

mkdir "D:\MySoftware\Browsers\Google\Local_Google"
rem 安装Chrome之后重命名"C:\Users\HI\AppData\Local\Google"为"C:\Users\HI\AppData\Local\Google2"，然后执行如下命令
mklink /d "C:\Users\HI\AppData\Local\Google" "D:\MySoftware\Browsers\Google\Local_Google"
pause