---
title: playwright 使用
author: MuyanGit
categories: 技术
date: 2022-09-01 15:19:49
tags:
photos:
---

![img](https://assistest.cn/medias/logo.png)

木木

感谢你曾经来过，就算你是个过客！

- [主页](https://assistest.cn/)
- [标签](https://assistest.cn/tags)
- [分类](https://assistest.cn/categories)
- [归档](https://assistest.cn/archives)
- [关于](https://assistest.cn/about)
- [友链](https://assistest.cn/friends)
- [留言板](https://assistest.cn/contact)

# playwright

[Python ](https://assistest.cn/tags/Python/)[自动化](https://assistest.cn/tags/自动化/)

 [自动化](https://assistest.cn/categories/自动化/)

发布日期:  2021-11-07

更新日期:  2022-08-17

文章字数:  3.7k

阅读时长:  16 分

------

![img](G:/CloudBackup/TianYi/demo/%E7%AC%94%E8%AE%B0/%E5%9B%BE%E5%BA%8A%E5%A4%87%E4%BB%BD/logo.png)

木木

感谢你曾经来过，就算你是个过客！

- [主页](https://assistest.cn/)
- [标签](https://assistest.cn/tags)
- [分类](https://assistest.cn/categories)
- [归档](https://assistest.cn/archives)
- [关于](https://assistest.cn/about)
- [友链](https://assistest.cn/friends)
- [留言板](https://assistest.cn/contact)

# playwright

[Python ](https://assistest.cn/tags/Python/)[自动化](https://assistest.cn/tags/自动化/)

 [自动化](https://assistest.cn/categories/自动化/)

发布日期:  2021-11-07

更新日期:  2022-08-17

文章字数:  3.7k

阅读时长:  16 分

------

# 安装：

关闭谷歌浏览器自动更新：127.0.0.1 update.googleapis.com

win7 的 node 无法安装可以输入：`set NODE_SKIP_PLATFORM_CHECK=1` 之后再进行安装

安装：`pip install playwright`

```
pip install playwright --pro
```



安装浏览器：`python -m playwright install`

上面会安装多个浏览器，执行一下代码单独安装一个浏览器

python -m playwright install chromium

python -m playwright install firefox

录制：`python -m playwright codegen https://www.baidu.com`

启动规则：`python -m playwright codegen --target python -o 'my.py' -b chromium https://www.baidu.com`

- 打开[www.baidu.com，用Chromium驱动，将结果保存为my.py的python文件](http://www.baidu.xn--com%2Cchromium%2Cmy-1483an5ulrqvv2cjodu29g3uzdxtsc3u0j.xn--pypython-hu1mq77pwbzb/)
- target：规定生成脚本的语言，有 JS 和 Python 两种，默认为 Python
- b：指定浏览器驱动
- o：将录制的脚本保存到一个文件

以本地谷歌浏览器进行启动：`browser = await p.chromium.launch(headless=False, channel="chrome")`

但是官方是推荐以自带浏览器进行启动的。

------

- 浏览器启动配置项：https://peter.sh/experiments/chromium-command-line-switches/

## 全屏启动浏览器：





python

```python
async with async_playwright() as p:
    # p.chromium.launch 创建一个新的浏览器页面 headless 是否设置无头浏览器
    browser = await p.chromium.launch(headless=False, args=["--disable-infobars", "--enable-automation=False",
                                                            "--disable-blink-features=AutomationControlled", "--start-maximized"])
    # 创建一个新的页面,并且返回页面句柄
    page = await browser.new_page(no_viewport=True)
    # 进入指定页面，在登录完毕之后输入任意内容继续
    await page.goto("https://mms.pinduoduo.com/goods/goods_list")
```

------





python

```python
import asyncio

from playwright.async_api import async_playwright


async def main():
    playwright = await async_playwright().start()
    browser = await playwright.chromium.launch(headless=False)
    context = await browser.new_context()
    page = await context.new_page()
    await page.goto("https://www.baidu.com")

    await context.close()
    await browser.close()
    await playwright.stop()


if __name__ == '__main__':
    asyncio.run(main())
```

------





python

```python
# 以下代码可以启动本地已启动的浏览器
browser = await p.chromium.connect_over_cdp("http://localhost:9222")

# 启动浏览器
#  ./chrome.exe  --remote-debugging-port=9222 --user-data-dir="D:\google_cache"

# subprocess.Popen('./chrome.exe --remote-debugging-port=9222 --user-data-dir="D:\google_cache"')

# subprocess.Popen('taskkill /F /IM chrome.exe')
```

# 基本操作

## 自动等待

像操作**page.click**和**page.fill**自动等待该元素是可见的和**可操作的**时候进行。例如，单击将：

- 等待具有给定选择器的元素出现在 DOM 中
- 等待它变得可见：有非空的边界框并且没有 `visibility:hidden`
- 等待它停止移动：例如，等待 css 过渡完成
- 将元素滚动到视图中
- 等待它在动作点接收指针事件：例如，等待元素不被其他元素遮挡
- 如果在上述任何检查期间元素被分离，则重试

## 基本创建代码





python

```python
import asyncio
from playwright.async_api import async_playwright


async def main():
    async with async_playwright() as p:
        # p.chromium.launch 创建一个新的浏览器页面 headless 是否设置无头浏览器
        browser = await p.chromium.launch(headless=False)
        # 创建一个新的页面,并且返回页面句柄
        page = await browser.new_page()
        # 通过句柄操作浏览器
        await page.goto("http://www.baidu.com")
        # 输出页面标题
        print(await page.title())
        # 关闭浏览器
        await browser.close()


asyncio.run(main())
```

## 异步不使用 `with` 创建

- 并且通过本地启动的浏览器连接





python

```python
async def main():
    p = await async_playwright().start()
    browser = await p.chromium.connect_over_cdp("http://localhost:9222")
    context = await browser.new_context(no_viewport=True)
    page = await context.new_page()

if __name__ == '__main__':
    asyncio.run(main())
```





ini

```ini
# C:\Users\user\AppData\Local\ms-playwright\chromium-** 首先进入这个目录

# ./chrome.exe  --remote-debugging-port=9222 通过这个指令启动
```

## 创建无痕浏览器





python

```python
import asyncio
from playwright.async_api import async_playwright

if __name__ == '__main__':
    async def main():
        async with async_playwright() as p:
            # p.chromium.launch 创建一个新的浏览器页面 headless 是否设置无头浏览器
            browser = await p.chromium.launch(headless=False,args=["--disable-infobars", "--enable-automation=False",
                                                                "--disable-blink-features=AutomationControlled", "--start-maximized"])
            # 创建无痕浏览器上下文
            context = await browser.new_context(no_viewport=True)
            # 创建新页面进行访问
            page = await context.new_page()
            await page.goto("https://example.com")

    asyncio.run(main())
```

# API

## 浏览器操作

- **启动浏览器：**`p.chromium.launch(headless=False)`：这个浏览器是没有页面的
- **创建浏览器页面：**`browser.new_page()`：创建一个新页面，返回新页面句柄。
- **访问指定页面：**`page.goto("https://example.com")`
- **关闭浏览器：**`browser.close()`
- **返回浏览器上下文数组**：`browser.contexts`：也就是标签页的数组

## 页面操作

------

- **等待查找：**`wait_for_selector("rule",state='visible')`：等待查找指定元素，这里显示的指定，其实上面也会等待。
  - `visible`：
  - `attached` 等待元素出现在 DOM 中。
  - `detached` - 等待元素不在 DOM 中。
  - `visible`默认值,等待元素具有非空边界框并且没有`visibility:hidden
    - 请注意，没有任何内容或有的元素`display:none`有一个空的边界框，不被认为是可见的。
  - `hidden` 等待元素与 DOM 分离，或者有一个空的边界框或`visibility:hidden`. 这与`'visible'`选项相反。
  - `strict` 当为 true 时，调用需要选择器解析为单个元素。如果给定的选择器解析为多个元素，则调用会引发异常。
  - `timeout` 最大时间以毫秒为单位，默认为 30 秒，传递`0`给禁用超时。可以使用
  - **path**：保存路径
  - **quality**：图片质量，1~100
- **等待元素状态：**`element_handle.wait_for_element_state(state, **kwargs)`
- **保存截图，页面，或者元素：**`page.screenshot(path='./back.jpeg',quality=100)`

------

- **定位元素：**`page.query_selector("rule")`：定位规则可以是 css，可以是 xpath。

- **定位多个元素：**`page.query_selector_all("rule")`：定位规则可以是 css，可以是 xpath。

- **点击元素：**`await page.click('text=Login')`：

- **元素内容：**`page.text_content("nav:first-child")`：这个是获取了指定标签内部,所有内容（属性，文本，不包含标签）

- **内部文本：**`el.inner_text()`：这个是获取一个标签内的所有文本。

- **返回 input：**`element_handle.input_value(**kwargs)`：返回`<input>`或`<textarea>`或`<select>`的`value`否则抛出非输入元素。

- **内部 HTML：**`*await* page.inner_html("div.result")`：获取标签内所有内容，包括 HTML

- **获取指定元素属性：**`await page.get_attribute("div.head_wrapper", "id")`

- **获取指定复选框状态：**`await page.is_checked("input")`：返回真假，表示是否被选中。

- 执行 JS 表达式：

  ```
  await page.eval_on_selector("div.head_wrapper", "e => e.id")
  ```

  - **前面定位到的元素，会被传到后面的 JS 代码中进行操作。**

- **元素是否可见：**`*await* page.is_visible("input")`：返回真假。

- **元素是否启用：**`*await* page.is_enabled("input")`：返回真假。

- **元素是否被禁用：**`element_handle.is_disabled()`

- **元素是否可编辑：**`element_handle.is_editable()`

- **元素是否隐藏：**`element_handle.is_hidden()`

### 元素句柄操作

- 详细参数见：https://playwright.dev/python/docs/api/class-elementhandle

- ```
  element_handle.bounding_box()
  ```

  ：返回元素 xy 坐标和宽高。

  - 如果要点击元素的中心位置请使用：
  - `box["x"] + box["width"] / 2, box["y"] + box["height"] / 2`

- `element_handle.click(**kwargs)`：点击元素,参数很多。

- `element_handle.dblclick(**kwargs)`：双击元素。

- `element_handle.content_frame()`：返回 iframe 的内容框架

- `await element_handle.dispatch_event("click")`：触发元素 click 事件。无论元素的可见性状态如何。

- `element_handle.fill(value, **kwargs)`：为指定元素设置值

- `element_handle.focus()`：让元素获得焦点。

- `element_handle.get_attribute(name) `：获取元素的指定属性值。

- `element_handle.hover(**kwargs)`：将鼠标移动到指定元素上

- `element_handle.scroll_into_view_if_needed(**kwargs)`：等待元素可以被操作后将元素移动到视图中。

- `element_handle.select_option(**kwargs)`：选择下拉框的选项，可以通过 index，value 进行选择。不是下拉框则报错。

- `element_handle.select_text(**kwargs)`：选择一个元素上所有文本，相当于鼠标拖动选择。

- `element_handle.set_checked(checked, **kwargs)`：勾选,或取消勾选复选框元素。

- `element_handle.set_input_files(files, **kwargs)`：设置 input 上传文件。

- `element_handle.text_content()`：返回 node.textContent

### 键盘操作

- 参数链接：https://playwright.dev/python/docs/api/class-keyboard
- `element_handle.press(key, **kwargs)`：模拟键盘按键，支持组合键
- `element_handle.press("a")`：直接输入字母`a`
- `element_handle.press("Control+v")`：Ctrl+v
- `page.keyboard.press('Tab')`：Tab
- `element_handle.press("Control+Shift+T")`：Ctrl+Shift+T
- 可以在这找到所有按键：https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent/key/Key_Values

------

- 每一个输入的键都会触发按下和弹起事件，就像他们真的被按下。

- `await page.keyboard.down()`：按下某个键

- `await page.keyboard.up(key)`：弹起某个键

- `await page.keyboard.insert_text("嗨")`：键入文本

- `page.fill('rule', 'password')`：在指定元素中输入内容

- ```
  await page.keyboard.type("Hello")
  ```

  ：输入要输入到聚焦元素中的文本

  - 并且每一个按键都会触发按下，和弹起事件。

### 鼠标操作

- 鼠标对于左上角开始的坐标进行移动
- `await page.mouse.move(0, 0)`：鼠标移动到指定位置
- `await page.mouse.down()`：鼠标按下
- `await page.mouse.up()`：鼠标弹起
- `mouse.click(x, y, **kwargs)`：鼠标单击
- `mouse.dblclick(x, y, **kwargs)`：鼠标双击
- `mouse.wheel(delta_x, delta_y)`：鼠标滚轮，x，y 像素。
- 如果要点击元素的中心位置请使用：
  - `box["x"] + box["width"] / 2, box["y"] + box["height"] / 2`

------

## 自定义操作（执行 JS）

- 在各种情况下，将元素传入 JS 进行操作。

  #### 1. evaluate：如果传入的是函数，那么将解析为函数，否则以表达式运算。

  #### 2. 如果结果是一个 Promise 或者函数是异步的，evaluate 将自动等待直到它被解决：

  - `*await* page.evaluate("([x, y]) => Promise.resolve(x * y)", [7, 8])`
  - `*print*(*await* page.evaluate("1 + 2"))`

  #### 2. eval_on_selector：将定位到的元素传入 JS 中操作。

  - `await page.eval_on_selector('div', 'el => window.getComputedStyle(el).fontSize')`

  #### 3. eval_on_selector_all：将定位到的多个元素传入 JS 中操作

  - `await page.eval_on_selector_all('li.selected', '(items) => items.length')`

  #### 4. 具体内容可以见官网：https://playwright.dev/python/docs/core-concepts

## 重用认证状态

- 浏览器在登录后，保存状态，下次启动之后读取，无须重新登录。
- **保存状态到本地：**`await context.storage_state(path="state.json")`
- **读取本地状态：**`context = await browser.new_context(storage_state="state.json")`：读取本地状态，并创建一个新的上下文。
- **这里的两步操作都需要创建一个无痕浏览器进行操作**





python

```python
browser = await p.chromium.launch(headless=False)
context = await browser.new_context()
# 将本地数据用于创建无痕浏览器
# context = await browser.new_context(storage_state="state.json")
# 创建新页面进行访问
page = await context.new_page()
await page.goto("https://www.baidu.com")
# 保存状态到本地
await context.storage_state(path="state.json")
```

## 会话存储

- 也就是 session 的存储。





python

```python
import os
# Get session storage and store as env variable
session_storage = await page.evaluate("() => JSON.stringify(sessionStorage)")
os.environ["SESSION_STORAGE"] = session_storage

# Set session storage in a new context
session_storage = os.environ["SESSION_STORAGE"]
await context.add_init_script("""storage => {
  if (window.location.hostname == 'example.com') {
    entries = JSON.parse(storage)
    Object.keys(entries).forEach(key => {
      window.sessionStorage.setItem(key, entries[key])
    })
  }
}""", session_storage)
```

## 模拟移动设备





python

```python
import asyncio
from playwright.async_api import async_playwright

async def main():
    async with async_playwright() as p:
        iphone_11 = p.devices['iPhone 11 Pro']
        browser = await p.chromium.launch()
        context = await browser.new_context(
            **iphone_11,
            locale='de-DE',
            geolocation={ 'longitude': 12.492507, 'latitude': 41.889938 },
            permissions=['geolocation'],
            color_scheme='dark',
        )
        page = await browser.new_page()
        await browser.close()

asyncio.run(main())
```

## 操作 frame

- 具体查看：https://playwright.dev/python/docs/api/class-frame#frame-add-script-tag
- 当你定位到 frame 之后,可以像正常页面一样操作。
- `frame.add_script_tag(**kwargs)`：添加 js 代码到 frame
- `frame.child_frames`：返回当前页 frame 列表





python

```python
# 定位到网页的iframe
frame_element_handle = await page.query_selector('.frame-class')
# 返回内容进行操作
frame = await frame_element_handle.content_frame()
# 之后这个frame就可以操作内部元素。
await frame.fill('#username-input', 'John')
```

## 操作浏览器弹出的对话框





python

```python
# 如果没有对话框监听器,那么对话框都会被自动关闭。
# 但如果有对话框监听器，浏览器却没有弹出对话框，那么会一直等待
# 等待弹出窗口，输出窗口的信息
page.on("dialog", lambda dialog: print(dialog.message))
# 等待弹出框，并点击确定。
page.on("dialog", lambda dialog: dialog.accept())
# 等待窗口弹出,并且在窗口中输入指定内容后点击确定。
page.on("dialog", lambda dialog: dialog.accept('66666'))
# 等待弹出框，并点击取消。
page.on("dialog", lambda dialog: dialog.dismiss())
# 输入指定内容后点击取消（我想没有人会这么做）
page.on("dialog", lambda dialog: dialog.dismiss())
# 返回浏览器默认提示内容,没有返回空
page.on("dialog", lambda dialog: dialog.default_value)
# 返回浏览器对话框类型 可以是一个alert，beforeunload，confirm或prompt
page.on("dialog", lambda dialog: dialog.type)
```

## 下载文件

- 这里文件选择器记得修改弹出的页面，如果是新窗口要修改监听的 page。





python

```python
# 进入下载文件页面
await page.goto("https://xiazai.zol.com.cn/detail/13/126805.shtml")
# 等待下载开始
async with page.expect_download() as download_info:
    # 点击下载按钮
    await page.click("//a[@class='tanceng' and text()='官网下载1']")
    # 获取下载信息
    download = await download_info.value
    # 等待文件下载完成,返回下载文件保存位置
    path = await download.path()
    # 获取下载文件保存的名字
    name = download.suggested_filename
    # 获取下载文件的页面
    download_page = download.page
    # 将下载的文件复制到指定位置
    await download.save_as(r'C:\Users\Administrator\Desktop\1.exe')
    # 删除下载的文件（这里不会删除上面复制的文件）
    # 并且下载的文件是存在于temp临时目录,不进行删除也可以。
    await download.delete()
    # 返回下载地址
    print(download.url)
    # 输出路径
    print(path)
    # 输出名字
    print(name)
    # 获取下载页
    print(download_page)
    # ----------------------------------------------------------------
    # 取消下载,成功取消后download.failure()将解析为canceled。
    await download.cancel()
    # 下载是否失败 download error
    await download.failure()
```

## 文件选择器

- 这里文件选择器记得修改弹出的页面，如果是新窗口要修改监听的 page。
- 这里注意，如果网页限制了，不让上传的文件是没有办法上传的。
- 比如限制 3M，但文件超过了 3M 可能就会报错。





python

```python
# 进入上传文件界面
await page.goto('https://www.wenshushu.cn/')
# 定位按钮
but = await page.query_selector('//*[@id="page_content"]')
# 开始监听文件选择窗口
async with page.expect_file_chooser() as fc_info:
    # 点击按钮,弹出上传窗口
    await but.click()
    # 获取上传窗口信息
    file_chooser = await fc_info.value
    # 选择需要上传的路径
    await file_chooser.set_files(["back.jpeg", 'driver.py'])
    # --------------------------------------------------------
    # 返回与此文件选择器相关联的元素
    but2 = file_chooser.element
    # 返回次文件选择器是否接受选择多个文件
    file_chooser.is_multiple()
    # 返回此文件选择器所属页面
    url = file_chooser.page
    # 上传文件
    await file_chooser.set_files(files, **kwargs)
```

# 处理弹出新窗口





python

```python
# 等待新窗口的弹出
async with page.expect_popup() as popup_info:
    # 获取页面操作句柄
    new_page = await popup_info.value
    # 等待加载,但只是等待页面的加载,动态加载内容无法处理。
    await new_page.wait_for_load_state()
    await new_page.click('...')
```

# 鼠标滑动轨迹





python

```python
async def get_tracks(distance):
    """
    匀变速公式：
    v = v0 + at
    x = v0t + 1/2 * a*t**2
    """

    # 定义初速度
    v = 0
    # 定义单位时间
    t = 0.6
    # 定义加速运动和减速运动的分界线
    mid = distance * 4 / 5
    # 定义当前位移
    current = 0
    # 定义运动轨迹列表
    tracks = []
    # 为了一直移动
    while current < distance:
        if mid > current:
            # 定义加速运动的加速度
            a = 2
        else:
            # 定义减速运动的加速度
            a = -3
        v0 = v
        # 计算位移
        x = v0 * t + 1 / 2 * a * t ** 2
        # 计算当前位移
        current += x
        # 计算每一次移动的末速度
        v = v0 + a * t
        tracks.append(round(x))
    return tracks
```

# 下面 url 还没看

https://playwright.dev/python/docs/api/class-page：页面事件，触发的时候可以进行一写操作，感觉没什么用。

https://playwright.dev/python/docs/api/class-request：请求拦截，好像可以将浏览器发出的请求拦截住。

https://playwright.dev/python/docs/api/class-response：请求响应，也是拦截响应

https://playwright.dev/python/docs/api/class-route：路由，不知道有什么用

https://playwright.dev/python/docs/api/class-websocket：websocket网络套接字操作

https://playwright.dev/python/docs/api/class-video/：这个好像是视频录制，但网页的文档太简单了，都不知道怎么用。

------

 ***文章作者:\*** [林木木](https://assistest.cn/about)

 ***文章链接:\*** https://www.assistest.cn/2021/11/07/playwright/

 ***版权声明:\*** 本博客所有文章除特別声明外，均采用 [CC BY 4.0](https://creativecommons.org/licenses/by/4.0/deed.zh) 许可协议。转载请注明来源 [林木木](https://assistest.cn/about) !

