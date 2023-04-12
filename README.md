# DFToys

DFToys 需要 .NET Frameworks 4.8。

## 路径设置

在默认情况下，将解压后的程序连同其父文件夹放入游戏目录下即可。

**(不推荐)** 如果将程序放在其他地方，需要手动修改其配置文件，指定游戏目录：
- 配置文件 `MyConfig.json` 位于程序目录下，程序首次启动并退出后，会自动生成此文件。
- 用支持 `Utf8` 编码的文本编辑器 修改 `DfPath` 字段 和 `PvfPath` 字段的值，它们分别表示游戏程序路径和脚本文件路径。 

## 密钥配置

登录密钥内置于程序中。如要使用自己的密钥，请自行修改 `DFToys.DFStartup` 项目。

导出公钥后，将 `publickey.pem` 文件放到服务器中即可。


## Pvf读取

Pvf读取用于获取游戏中的任务名称。

如未加载任务信息，或者读取失败，则无法显示任务名称，也不能指定要完成的任务，只能批量完成。

首次加载 `Script.pvf` 文件会占用大量的内存，之后程序会直接加载缓存，所以建议加载一次pvf后，退出程序再次运行。

当前仅实现了最基础的读取功能，如果想要对其进行扩展，可以实现 `DFToys.PvfCache` 项目的 `IPvfCacheObject<TSelf>` 接口，并将其作为 `PvfCacheProvider` 的 `Dictionary<int, TPvfObject> TryCreateCache<TPvfObject>(string folder, string listPath, string strDictFlag)` 方法的泛型参数进行调用。在此方法的参数定义如下：

- TPvfObject - 实现了 `IPvfCacheObject<TSelf>` 接口的类型
- folder - 目标目录，例如任务信息目录是 `n_quest`
- listPath - 目标索引文件，任务信息的索引文件为 `"n_quest/quest.lst`
- strDictFlag - 目标中文本的字典标志。文本字典索引位于 `n_string.lst` 中，此标志用于在文本字典索引中寻找其路径。对于任务来说，合适的标志是 `n_quest/quest.`

## 服务端补丁

详情参照 `DFToys.Patch` 项目。

理论上，标准的方式是解析 `Elf` 文件结构，获取函数位置进行修改，但鉴于服务端的程序都一样，所以这里采用偷懒的做法，直接修改相关的位置。

**但是，并不排除有其他服务端提供者对于 `df_game_r` 进行了修补，所以使用补丁前请务必备份原文件。**
 
