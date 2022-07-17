@echo off
if "%1"=="h" goto begin
start mshta vbscript:createobject("wscript.shell").run("""%~nx0"" h",0)(window.close)&&exit
:begin

taskkill -f -im explorer.exe
ping -n 5 127.0.0.1>nul
explorer.exe