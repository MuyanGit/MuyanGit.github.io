title: 英文文本分词之工具NLTK
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/MuyanGit/ImageHosting/images/favicon.ico'
authorLink: /about/MuyanGit.html
authorDesc: 尽小者大，慎微者著
categories: 技术
comments: true
date: 2021-11-18 15:36:54
authorAbout:
series:
tags:
keywords:
description:
photos:
---









### 文文本分词之工具NLTK

- [安装NLTK](https://blog.csdn.net/weixin_43543177/article/details/117756242#NLTK_1)
- [停用词和标点符号包放置](https://blog.csdn.net/weixin_43543177/article/details/117756242#_18)
- [验证](https://blog.csdn.net/weixin_43543177/article/details/117756242#_21)



# 安装NLTK

```
pip install nltk
1
```

分词需要用到两个包：`stopwords`和`punkt`,需要下载：

```
import nltk

nltk.download('stopwords')
nltk.download('punkt')
1234
```

如果你能运行成功，那么恭喜，但多半要和我一样，被墙，然后下载失败。于是乎，需要手动下载，这里我已经打包好了，百度提取即可。

```
链接：https://pan.baidu.com/s/1ddVRG86W-dyk2O6TsIMXAw 
提取码：nltk 
12
```

此处也是要感激广大网友的无私分享和帮助！！！

# 停用词和标点符号包放置

言归正传，下载解压后要注意，stopwords里面还有个stopwords文件，punkt文件里面还有个punkt文件，我们需要的是里面的这两个文件，而不是最外围的同名文件，虽然包含的内容一样，但是[python](https://so.csdn.net/so/search?from=pc_blog_highlight&q=python)读取的时候路径会出错。将`里面`的`stopwords`和`punkt`文件夹分别移动到python安装目录下的两个子路径中，比如我的路径是`F:\python38\Lib\nltk_data\corpora`和`F:\python38\Lib\nltk_data\tokenizers`。需要说明的是，我的`F:\python38\Lib`路径下并没有`nltk_data`这个文件，没有？没有就让他有！新建文件夹，重命名即可。
然后在`nltk_data`中再新建两个文件夹：`corpora`和`tokenizers`。然后把停用词和标点分别移动到这两个文件里即可，亦即：`corpora\stopwords`和`tokenizers\punkt`。

# 验证

此处提供一段验证代码，明日开始nltk分词之旅！

```
from nltk.tokenize import word_tokenize
from nltk.corpus import stopwords

punctuations = [',', '.', ':', ';', '?', '(', ')', '[', ']', '&', '!', '*', '@', '#', '$', '%']
data = "All work and no play makes jack dull boy. All work and no play makes jack a dull boy."
words = word_tokenize(data)
words = [word for word in words if word not in punctuations]   # 去除标点符号
stopWords = set(stopwords.words('english'))
wordsFiltered = []

for w in words:
    if w not in stopWords:
        wordsFiltered.append(w)

print(wordsFiltered)
123456789101112131415
```

完结，可以愉快地听歌了。



![image-20211118153808248](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211118153808248.png)



![image-20211118153759640](https://cdn.jsdelivr.net/gh/MuyanGit/pic_url@master/img/image-20211118153759640.png)



