@echo ON
if "%1"=="h" goto begin
start mshta vbscript:createobject("wscript.shell").run("""%~nx0"" h",0)(window.close)&&exit
:begin
::start D:\MyBackup\综合备份\便携版·软件\文本编辑\Notepad\Notepad++7.8.1_x64_Good\Notepad++7.8.1\notepad++.exe G:\MuyanGitBlog\MuyanGit\杂项\配置文件\常用bat\清理\临时终结.bat

::  注意 开发--playwright--
taskkill /f /t /im  firefox.exe
taskkill /f /t /im  chromedriver.exe
::  node.exe
::  ssh.exe

::  注意 文档--wpsoffice--
taskkill /f /t /im  wpsoffice.exe

::  注意 浏览器--谷歌--
::taskkill /f /t /im  chrome.exe

::  注意 浏览器--EDG--
taskkill /f /t /im  msedge.exe


::  注意 交流--远程--
::taskkill /f /t /im  RustDesk.exe

::  注意 下载--IDM--
taskkill /f /t /im  IEMonitor.exe

::  注意 阅读--EDG--PDF
taskkill /f /t /im  msedge.exe





::  Win10系统进程占用内存和网速过高的解决方法
taskkill /f /t /im  mshta.exe
taskkill /f /t /im  RuntimeBroker.exe


::  文本输入
taskkill /f /t /im  WindowsInternal.ComposableShell.Experiences.TextInput.InputApp.exe
::  win开始
taskkill /f /t /im  StartMenuExperienceHost.exe
::  win照片
taskkill /f /t /im  Microsoft.Photos.exe
::  win商店
taskkill /f /t /im  WinStore.App.exe
::  win设置
taskkill /f /t /im  SystemSettings.exe
::	终结微软小娜
taskkill /f /t /im  SearchUI.exe
::  
taskkill /f /t /im  ActionUriServer.exe
::  
taskkill /f /t /im  PlacesServer.exe
::  
taskkill /f /t /im  RemindersShareTargetApp.exe
taskkill /F /im  CSSReadCardNoServices.exe
taskkill /F /im  OfficeClickToRun.exe
taskkill /F /im  NVDisplay.Container.exe
taskkill /F /im  isa.exe
pause