@ECHO OFF
echo ��鲢ֹͣ��ط���....
echo ------------------------------

    echo %date:~0,4%-%date:~5,2%-%date:~8,2% %time:~0,8%��ʼ�� >>"%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%��������.txt"

	set ENV_PATH=%PATH%
	@echo ====current environment��
	@echo %ENV_PATH% >>"%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%��������.txt"
	
	:: ��ӻ�������,����ԭ���Ļ������������Ӣ��״̬�µķֺź�·��###�����������
	set MY_PATH1=D:\Java\Python\Anaconda3\bin\
	set MY_PATH2=D:\Java\Python\Anaconda3\Scripts\
	set MY_PATH3=D:\Java\Python\Anaconda3\
	set ENV_PATH=%PATH%;%MY_PATH1%;%MY_PATH2%;%MY_PATH3%
	
	
	@echo ====new environment: >>"%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%��������.txt
	@echo %ENV_PATH% >>"%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%��������.txt
    echo %date:~0,4%-%date:~5,2%-%date:~8,2% %time:~0,8%������ >>"%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%��������.txt"

echo ִ�����

pause>nul