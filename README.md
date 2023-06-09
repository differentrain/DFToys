# DFToys

DFToys 需要 .NET Frameworks 4.8。

0725版辅助需要管理员权限。

## 路径设置

在默认情况下，将解压后的程序连同其父文件夹放入游戏目录下即可。

**(不推荐)** 如果将程序放在其他地方，需要手动修改其配置文件，指定游戏目录：
- 配置文件 `MyConfig.json` 位于程序目录下，程序首次启动并退出后，会自动生成此文件。
- 用支持 `Utf8` 编码的文本编辑器 修改 `DfPath` 字段 和 `PvfPath` 字段的值，它们分别表示游戏程序路径和脚本文件路径。 

## 密钥配置

登录密钥内置于程序中。如要使用自己的密钥，请自行修改 `DFToys.DFStartup` 项目。

导出公钥后，将 `publickey.pem` 文件放到服务器中即可。


## Pvf读取

Pvf读取用于获取游戏中的任务和物品信息。

首次加载 `Script.pvf` 文件会占用大量的内存，之后程序会直接加载缓存，所以建议加载一次pvf后，退出程序再次运行。

## 服务端补丁

详情参照 `DFToys.Patch` 项目。

理论上，标准的方式是解析 `Elf` 文件结构，获取函数位置进行修改，但鉴于服务端的程序都一样，所以这里采用偷懒的做法，直接修改相关的位置。

**但是，并不排除有其他服务端提供者对于 `df_game_r` 进行了修补，所以使用补丁前请务必备份原文件。**
 
## 数据库编码

在1.0.3之前的版本中，存在数据库乱码的问题。这是因为MySQL的默认编码是latin1，对应Windows代码页1252。

此问题在后续版本中已经解决，如依然有乱码问题，应当检查服务器中的MySQL编码配置，它通常位于 `/etc/my.cnt` 文件中，并实现 [DFToys.Common.DbStringConvert](https://github.com/differentrain/DFToys/blob/master/DFToys.Common/DbStringConvert.cs),或直接修改[DFToys.Common.DefaultDbStringConvert](https://github.com/differentrain/DFToys/blob/master/DFToys.Common/DefaultDbStringConvert.cs)。

另外，根据规范，cp1252中，以下字符属于未定义：`0x81`, `0x8D`, `0x8F`, `0x90`, `0x9D`. 而MySQL所实现的latin1，会将这五个字符映射为Unicode16编码。但在实际测试中，.NET Frameworks的Encoding可以自动完成此映射操作，无需特殊处理。
