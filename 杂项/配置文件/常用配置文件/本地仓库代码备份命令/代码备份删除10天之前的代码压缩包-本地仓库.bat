@echo off
if "%1"=="h" goto begin
start mshta vbscript:createobject("wscript.shell").run("""%~nx0"" h",0)(window.close)&&exit
:begin
rem �ս���������
taskkill /f /t /im  eCloud.exe
::����7z�������г���·��
set zip7=D:\MySoftware\�ļ�����\ѹ������\7-Zip\7z.exe
::����ѹ��������·���������onedrive����·��
set Save=F:\���زֿ�\GitbakCloud189
::�������ڣ������ļ���
::%date:~0,4%-%date:~5,2%-%date:~8,2%
::set curdate=%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%%time:~3,2%%time:~6,2%
set curdate=%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%%time:~3,2%
echo %curdate%���ݴ�����111 >>���ش��뱸��log.txt
::����Ҫ���ѹ�����ļ���
set zipfile=F:\���زֿ�\demo
 
::�������� -xr!.svn����\data\image\�ļ��� mx0�Ǵ洢ģʽѹ��
::"%zip7%" a -tzip "%Save%\���زֿ�%curdate%.zip" "%zipfile%" -mx0 -xr"!*\data\image\"
"%zip7%" a -tzip "%Save%\���زֿⱸ��%curdate%.zip" "%zipfile%" -mx0 

::ɾ������10��ı���--start--
forfiles /p "%Save%" /m *.zip -d -10 /c "cmd /c del /f @path"

rem ��������
ping 127.0.0.1 -n 3 >nul
start D:\MyBackup\�ۺϱ���\��Я�桤���\_����������Ŀ¼����ݷ�ʽ\ty.lnk
