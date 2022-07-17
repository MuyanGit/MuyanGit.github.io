:: 启动代码.bat  （在bat中双冒号代表注释）
 
@ECHO OFF
PUSHD %~DP0 & cd /d "%~dp0"
%1 %2
mshta vbscript:createobject("shell.application").shellexecute("%~s0","goto :runas","","runas",1)(window.close)&goto :eof
:runas
 
net start CSSReadCardNoServices
 
exit
 