:: ¹Ø±Õ´úÂë.bat 
 
@ECHO OFF
PUSHD %~DP0 & cd /d "%~dp0"
%1 %2
mshta vbscript:createobject("shell.application").shellexecute("%~s0","goto :runas","","runas",1)(window.close)&goto :eof
:runas

::net start CSSReadCardNoServices 

taskkill /f /t /im  firefox.exe
taskkill /f /t /im  mshta.exe
taskkill /f /t /im  RustDesk.exe
taskkill /f /t /im  IEMonitor.exe
taskkill /f /t /im  notepad.exe

exit