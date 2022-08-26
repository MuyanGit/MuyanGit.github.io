@echo off
if "%1"=="h" goto begin
start mshta vbscript:createobject("wscript.shell").run("""%~nx0"" h",0)(window.close)&&exit
:begin
rem 终结天翼云盘
taskkill /f /t /im  eCloud.exe
::设置7z的命令行程序路径
set zip7=D:\MySoftware\文件管理\压缩工具\7-Zip\7z.exe
::设置压缩包保存路径，即你的onedrive本地路径
set Save=F:\本地仓库\GitbakCloud189
::当天日期，备份文件名
::%date:~0,4%-%date:~5,2%-%date:~8,2%
::set curdate=%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%%time:~3,2%%time:~6,2%
set curdate=%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%%time:~3,2%
echo %curdate%备份代码中111 >>本地代码备份log.txt
::设置要打包压缩的文件夹
set zipfile=F:\本地仓库\demo
 
::备份命令 -xr!.svn过滤\data\image\文件夹 mx0是存储模式压缩
::"%zip7%" a -tzip "%Save%\本地仓库%curdate%.zip" "%zipfile%" -mx0 -xr"!*\data\image\"
"%zip7%" a -tzip "%Save%\本地仓库备份%curdate%.zip" "%zipfile%" -mx0 

::删除超过10天的备份--start--
forfiles /p "%Save%" /m *.zip -d -10 /c "cmd /c del /f @path"

rem 天翼云盘
ping 127.0.0.1 -n 3 >nul
start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\ty.lnk
