@ECHO OFF
echo 检查并停止相关服务....
echo ------------------------------

    echo %date:~0,4%-%date:~5,2%-%date:~8,2% %time:~0,8%开始： >>"%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%环境变量.txt"

	set ENV_PATH=%PATH%
	@echo ====current environment：
	@echo %ENV_PATH% >>"%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%环境变量.txt"
	
	:: 添加环境变量,即在原来的环境变量后加上英文状态下的分号和路径###后面无需添加
	set MY_PATH1=D:\Java\Python\Anaconda3\bin\
	set MY_PATH2=D:\Java\Python\Anaconda3\Scripts\
	set MY_PATH3=D:\Java\Python\Anaconda3\
	set ENV_PATH=%PATH%;%MY_PATH1%;%MY_PATH2%;%MY_PATH3%
	
	
	@echo ====new environment: >>"%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%环境变量.txt
	@echo %ENV_PATH% >>"%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%环境变量.txt
    echo %date:~0,4%-%date:~5,2%-%date:~8,2% %time:~0,8%结束： >>"%date:~0,4%-%date:~5,2%-%date:~8,2%_%time:~0,2%环境变量.txt"

echo 执行完成

pause>nul