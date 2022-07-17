@echo OFF
::重装系统后注意两处盘符的修改
F:
cd F:\本地仓库\本地博客\muyangit.github.io.backup.local\杂项\博客备份\
start D:\MySoftware\DEV\VersionCtrl\Git\git-bash.exe -c "bash bolg_backup.sh"
G:
cd G:\MuyanGitBlog\MuyanGit\杂项\博客备份\
start D:\MySoftware\DEV\VersionCtrl\Git\git-bash.exe -c "bash bolg_backup.sh"