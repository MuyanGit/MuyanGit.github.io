---
title: ' Python3读取写入json的中文乱码问题_SeniorZ的点滴记录-程序员信息网    '
author: MuyanGit
avatar: 'https://cdn.jsdelivr.net/gh/muyangit/cdn@1.4/img/custom/avatar.jpg'
authorAbout: 尽小者大，甚微者著
authorDesc: 日就月将，学有缉熙于光明
categories: 技术
comments: true
date: 2021-10-23 04:42:52
authorLink:
tags:
keywords:
description:
photos:
---

## Python3读取写入json的中文乱码问题_SeniorZ的点滴记录-程序员信息网

技术标签： [Python](https://www.i4k.xyz/searchArticle?qc=Python&page=1) https://www.i4k.xyz/copyright)



问题1.中文写入json，但json文件中显示"\u6731\u5fb7\u57f9",不是中文。

```
#中文写入json，但文件中显示"\u6731\u5fb7\u57f9",不是中文。
# encoding='utf-8'，用于确保写入中文不乱码
with open(filename,'w',encoding='utf-8') as f_obj:
    json.dump(username,f_obj)
```

解决方法：加入ensure_ascii=False

```
# encoding='utf-8'，用于确保写入中文不乱码
with open(filename,'w',encoding='utf-8') as f_obj:
    # ensure_ascii=False，用于确保写入json的中文不发生乱码
    json.dump(username,f_obj,ensure_ascii=False)
```

问题2.当目标json文件内容为空时，出现

```python
json.decoder.JSONDecodeError: Expecting value: line 1 column 1 (char 0)
```

解决方法：新增一个异常

```python
# 当username.json为空，这里如果不加入 json.decoder.JSONDecodeError: 异常
# 会导致json.decoder.JSONDecodeError: Expecting value: line 1 column 1 (char 0)
except json.decoder.JSONDecodeError:
    print("文件内容是空的。")
```

