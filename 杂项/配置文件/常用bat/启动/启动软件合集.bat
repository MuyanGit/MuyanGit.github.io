@echo OFF
%1 mshta vbscript:CreateObject("Shell.Application").ShellExecute("cmd.exe","/c %~s0 ::","","runas",1)(window.close)&&exit

rem 识图
ping 127.0.0.1 -n 7 >nul
start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\fy1.lnk

rem 视频播放器
ping 127.0.0.1 -n 7 >nul
start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\pot.lnk

rem 搜索工具
ping 127.0.0.1 -n 7 >nul
start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\ss.lnk

rem 文件浏览器
ping 127.0.0.1 -n 7 >nul
start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\C.lnk

rem 截屏
ping 127.0.0.1 -n 7 >nul
start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\jp.lnk

rem 科学上网工具
ping 127.0.0.1 -n 7 >nul
start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\win.lnk

rem 云盘同步
ping 127.0.0.1 -n 7 >nul
start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\ty.lnk

rem 开发-WEB编辑器
ping 127.0.0.1 -n 7 >nul
start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\vs.lnk

rem PicGo图床
ping 127.0.0.1 -n 7 >nul
start D:\MyBackup\综合备份\便携版·软件\_环境变量·目录·快捷方式\pic.lnk
