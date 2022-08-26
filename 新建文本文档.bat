@echo off
REM 声明采用UTF-8编码
chcp 65001
%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit
:begin
set input=
set /p input=要删除的目录或文件路径:

:loop
set /p a=确定要删除 %input% 吗？（1删除，0退出）
if /i '%a%'=='1' goto continue
if /i '%a%'=='0' goto end
echo 输入有误，请重新输入：&&goto loop
 
:continue
echo 正在删除 %input% ...
rmdir %input% /S /Q
echo %input% 删除成功!
 
:end
pause