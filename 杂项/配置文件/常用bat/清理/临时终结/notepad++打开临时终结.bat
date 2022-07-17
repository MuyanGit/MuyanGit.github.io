@echo off
if "%1"=="h" goto begin
start mshta vbscript:createobject("wscript.shell").run("""%~nx0"" h",0)(window.close)&&exit
:begin
start D:\MyBackup\综合备份\便携版·软件\文本编辑\Notepad\Notepad++7.8.1_x64_Good\Notepad++7.8.1\notepad++.exe G:\MuyanGitBlog\MuyanGit\杂项\配置文件\常用bat\清理\临时终结\临时终结.bat
