:: �رմ���.bat 
 
@ECHO OFF
PUSHD %~DP0 & cd /d "%~dp0"
%1 %2
mshta vbscript:createobject("shell.application").shellexecute("%~s0","goto :runas","","runas",1)(window.close)&goto :eof
:runas

::���÷���Ϊ�Զ�
::sc config MEmuSVC start= auto
::���÷���Ϊ����
::sc config MEmuSVC start= disabled


::���÷���Ϊ�ֶ���Distributed Link Tracking Client��ά��ĳ��������ڻ�ĳ�������еļ������ NTFS �ļ�֮������ӡ�
sc config TrkWks start= demand
sc stop TrkWks

::���÷���Ϊ�ֶ������ü�����������ϵĿ��ô�����Դ���ͺͽ��մ��档
sc config Fax start= demand
sc stop Fax

::���÷���Ϊ�ֶ�```Hyper-V �����������
sc config vmcompute start= demand
sc stop vmcompute

::���÷���Ϊ��ңģ����
sc config MEmuSVC start= demand
sc stop MEmuSVC 




exit