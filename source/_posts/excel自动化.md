---
title: excel自动化
author: MuyanGit
categories: 技术
date: 2022-10-17 14:49:31
tags:
photos:
---

# excel字符串截取

### 1· excel从右边查找字符并截取全部

=TRIM(RIGHT(SUBSTITUTE(A3,"/",REPT(" ",LEN(A3))),LEN(A3)))

 excel从左边边查找字符并截取全部

=TRIM(left(SUBSTITUTE(A3,"/",REPT(" ",LEN(A3))),LEN(A3)))









# excel问题

## 1·方向键盘不能使用

按键盘的Fn+C键

