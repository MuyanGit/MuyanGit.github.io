@echo off
if "%1"=="h" goto begin
start mshta vbscript:createobject("wscript.shell").run("""%~nx0"" h",0)(window.close)&&exit
:begin
::����Ϊ����������������ɺ���pause set/p�Ƚ�������
echo %date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%_%time:~3,2% >>��������ǩ��log.txt
cloudpan189-go sign >>��������ǩ��log.txt