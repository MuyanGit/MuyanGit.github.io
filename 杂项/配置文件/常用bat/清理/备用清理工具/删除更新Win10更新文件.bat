@echo off
REM 声明采用UTF-8编码
chcp 65001
echo 请直接按【“回车”】键，可以删除Win10更新文件
%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit
cd /d "%~dp0"
cd /d C:\Windows\SoftwareDistribution\Download
for /d %%i in (*) do (
rd /s /q "%%i"
del /a /f /q *.*
)
REM echo 删除完成！

REM pause


