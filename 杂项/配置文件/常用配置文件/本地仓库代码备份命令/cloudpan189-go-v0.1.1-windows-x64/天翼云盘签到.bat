@echo off
if "%1"=="h" goto begin
start mshta vbscript:createobject("wscript.shell").run("""%~nx0"" h",0)(window.close)&&exit
:begin
::以下为正常批处理命令，不可含有pause set/p等交互命令
echo %date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%_%time:~3,2% >>天翼云盘签到log.txt
cloudpan189-go sign >>天翼云盘签到log.txt