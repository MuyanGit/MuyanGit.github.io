@echo off
if "%1"=="h" goto begin
start mshta vbscript:createobject("wscript.shell").run("""%~nx0"" h",0)(window.close)&&exit
:begin

rem 备份代码-本地
rem start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\bf1.lnk
rem 备份代码-本地
rem start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\bf2.lnk

rem 签到-天翼云盘
ping 127.0.0.1 -n 3 >nul
start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\天翼云盘签到.lnk

rem win10-清理
ping 127.0.0.1 -n 3 >nul
start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\Win10清理工具.lnk
