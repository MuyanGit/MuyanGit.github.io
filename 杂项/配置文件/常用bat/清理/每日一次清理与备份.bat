@echo off
if "%1"=="h" goto begin
start mshta vbscript:createobject("wscript.shell").run("""%~nx0"" h",0)(window.close)&&exit
:begin

rem ���ݴ���-����
rem start D:\MyBackup\�ۺϱ���\��Я�桤���\_����������Ŀ¼����ݷ�ʽ\bf1.lnk
rem ���ݴ���-����
rem start D:\MyBackup\�ۺϱ���\��Я�桤���\_����������Ŀ¼����ݷ�ʽ\bf2.lnk

rem ǩ��-��������
ping 127.0.0.1 -n 3 >nul
start D:\MyBackup\�ۺϱ���\��Я�桤���\_����������Ŀ¼����ݷ�ʽ\��������ǩ��.lnk

rem win10-����
ping 127.0.0.1 -n 3 >nul
start D:\MyBackup\�ۺϱ���\��Я�桤���\_����������Ŀ¼����ݷ�ʽ\Win10������.lnk
