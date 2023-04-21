using DFToys.PvfCache.Internals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DFToys.PvfCache
{
    public sealed partial class PvfCacheProvider : IDisposable
    {
        //FileVersion, DirTreeLength, DirTreeCrc32, HeaderFilesCount
        private const int FIXED_HEADER_SIZE = 16;

        private const string NAME_STRING_TABLE = "stringtable.bin";

        private const string NAME_STRING_DICT_LIST = "n_string.lst";


        private Stream _stream;
        private readonly Encoding _fileEncoding;
        private readonly Encoding _strEncoding;

        private Dictionary<string, PvfFile> _fileDict;
        private string[] _stringTable;
        private Dictionary<int, Dictionary<string, string>> _stringDict;

        public PvfCacheProvider(string pvfPath, Encoding fileEncoding, Encoding strEncoding)
        {
            _fileEncoding = fileEncoding;
            _strEncoding = strEncoding;
            _stream = new FileStream(pvfPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.RandomAccess);
            PvfHeader headerInfo = GetHeaderInfo();
            _fileDict = GetFileInfoDict(headerInfo);
            _stringTable = CreateStringTable(_fileDict[NAME_STRING_TABLE]);
            _stringDict = CreateStringDict(_fileDict[NAME_STRING_DICT_LIST], _fileDict);
        }



        public Dictionary<int, QuestCache> TryCreateQuestCache()
        {
            return TryCreateDictCache<QuestCache>("n_quest", "n_quest/quest.lst");
        }


        public List<StackableItemCache<GameJobTable, GameItemTable>> TryCreateItemCache(
            out KeyValuePair<string, string[]>[] indexDict)
        {
            List<StackableItemCache<GameJobTable, GameItemTable>> cacheList =
                TryCreateListCache<StackableItemCache<GameJobTable, GameItemTable>>("stackable", "stackable/stackable.lst");

            Dictionary<string, List<string>> t
                = CreateItemCacheIndexDict(cacheList);
           
            indexDict = t.Select(
                    d0 =>
                    new KeyValuePair<string, string[]>(
                        d0.Key,
                        d0.Value
                            .OrderBy(s => s, GameStringComparer.Instance).ToArray()
                   )
                ).OrderBy(x => x.Key, GameStringComparer.Instance).ToArray();

            return cacheList;
        }


        public List<EquipmentCache<GameJobTable, GameEquipmentTable>> TryCreateEquipmentCache(
            out KeyValuePair<string, KeyValuePair<string, KeyValuePair<string, string[]>[]>[]>[] indexDict)
        {
            List<EquipmentCache<GameJobTable, GameEquipmentTable>> cacheList =
                TryCreateListCache<EquipmentCache<GameJobTable, GameEquipmentTable>>("equipment", "equipment/equipment.lst");

            Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>> t
                = CreateEqCacheIndexDict(cacheList);


            indexDict = t.Select(
                    d0 =>
                    new KeyValuePair<string, KeyValuePair<string, KeyValuePair<string, string[]>[]>[]>(
                        d0.Key,
                        d0.Value.Select(
                                d1 =>
                                new KeyValuePair<string, KeyValuePair<string, string[]>[]>(
                                    d1.Key,
                                    d1.Value.Select(
                                        d2 =>
                                        new KeyValuePair<string, string[]>(
                                            d2.Key,
                                            d2.Value.OrderBy(
                                                l => l, GameStringComparer.Instance).ToArray()))
                                    .OrderBy(d3 => d3.Key, GameStringComparer.Instance).ToArray()))
                                    .OrderBy(d4 => d4.Key, GameStringComparer.Instance).ToArray())
                ).OrderBy(x => x.Key, GameStringComparer.Instance).ToArray();

            return cacheList;
        }

        private Dictionary<string, List<string>> CreateItemCacheIndexDict(List<StackableItemCache<GameJobTable, GameItemTable>> cacheList)
        {
            var dict = new Dictionary<string, List<string>>();
            StackableItemCache<GameJobTable, GameItemTable> cache;
            for (int i = 0; i < cacheList.Count; i++)
            {
                cache = cacheList[i];
                if (cache.UsableJob.Count == 0)
                {
                    UpdateItemCacheIndexDict(
                        EquipmentCache<GameJobTable, GameEquipmentTable>.JobTable.AllowAllJobFriendlyName,
                        dict,
                        cache);
                }
                else
                {
                    for (int j = 0; j < cache.UsableJob.Count; j++)
                    {
                        UpdateItemCacheIndexDict(
                          cache.UsableJob[j],
                          dict,
                          cache);
                    }
                }
            }
            return dict;
        }

        private Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>
                CreateEqCacheIndexDict(List<EquipmentCache<GameJobTable, GameEquipmentTable>> cacheList)
        {
            var dict = new Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>();
            EquipmentCache<GameJobTable, GameEquipmentTable> cache;
            for (int i = 0; i < cacheList.Count; i++)
            {
                cache = cacheList[i];
                if (cache.UsableJob.Count == 0)
                {
                    UpdateEqCacheIndexDict(
                        EquipmentCache<GameJobTable, GameEquipmentTable>.JobTable.AllowAllJobFriendlyName,
                        dict,
                        cache);
                }
                else
                {
                    for (int j = 0; j < cache.UsableJob.Count; j++)
                    {
                        UpdateEqCacheIndexDict(
                          cache.UsableJob[j],
                          dict,
                          cache);
                    }
                }
            }
            return dict;
        }


        private void UpdateItemCacheIndexDict(
                string jobName,
                Dictionary<string, List<string>> dict,
                StackableItemCache<GameJobTable, GameItemTable> cache)
        {
            if (jobName == EquipmentCache<GameJobTable, GameEquipmentTable>.JobTable.AllowAllJobFriendlyName)
            {
                foreach (var item in EquipmentCache<GameJobTable, GameEquipmentTable>.JobTable.Jobs)
                {
                    UpdateItemCacheIndexDict(item, dict, cache);
                }
                return;
            }

            if (!dict.TryGetValue(
                        jobName,
                        out List<string> value))
            {
                value = new List<string> { cache.ItemType };

                dict.Add(jobName, value);
            }
            else if (!value.Contains(cache.ItemType))
            {
                value.Add(cache.ItemType);
            }
        }


        private void UpdateEqCacheIndexDict(
            string jobName,
            Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>> dict,
            EquipmentCache<GameJobTable, GameEquipmentTable> cache)
        {
            if (jobName == EquipmentCache<GameJobTable, GameEquipmentTable>.JobTable.AllowAllJobFriendlyName)
            {
                foreach (var item in EquipmentCache<GameJobTable, GameEquipmentTable>.JobTable.Jobs)
                {
                    UpdateEqCacheIndexDict(item, dict, cache);
                }
                return;
            }

            if (!dict.TryGetValue(
                        jobName,
                        out Dictionary<string, Dictionary<string, List<string>>> value0))
            {
                value0 = new Dictionary<string, Dictionary<string, List<string>>>
                {
                    { cache.MainType, new Dictionary<string, List<string>>() }
                };
                dict.Add(jobName, value0);
            }

            if (cache.SubType1 != null)
            {
                if (!value0.TryGetValue(cache.MainType, out Dictionary<string, List<string>> value1))
                {
                    value1 = new Dictionary<string, List<string>>
                    {
                        { cache.SubType1, new List<string>() }
                    };
                    value0.Add(cache.MainType, value1);
                }

                if (!value1.TryGetValue(cache.SubType1, out List<string> value2))
                {
                    value2 = new List<string>();
                    value1.Add(cache.SubType1, value2);
                }

                if (cache.SubType2 != null && !value2.Contains(cache.SubType2))
                {
                    value2.Add(cache.SubType2);
                }

            }

        }


        public Dictionary<int, TPvfObject> TryCreateDictCache<TPvfObject>(string folder, string listPath)
            where TPvfObject : IPvfDictCacheObject, new()
        {
            var fInfo = _fileDict[listPath];

            BytesBuffer buffer = BytesBuffer.CreateAndDecodeFromStream(_stream, fInfo, fInfo.SeekPos);
            int dictLen = (fInfo.FileLength - 2) / 10;
            var dict = new Dictionary<int, TPvfObject>(dictLen);
            byte[] tbuf = buffer.Buffer;
            try
            {
                Parallel.For(0, dictLen, i =>
                {
                    KeyValuePair<int, string> dictPathInfo = GetListItem(tbuf, i, _stringTable);
                    if (_fileDict.TryGetValue($"{folder}/{dictPathInfo.Value}", out PvfFile pvfInfo))
                    {
                        dict.Add(
                           dictPathInfo.Key,
                           GetPvfObject<TPvfObject>(pvfInfo)
                           );
                    }
                });
                return dict;
            }
            finally
            {
                buffer.Dispose();
            }
        }

        public List<TPvfObject> TryCreateListCache<TPvfObject>(string folder, string listPath)
                where TPvfObject : PvfListCacheObject, new()
        {

            var fInfo = _fileDict[listPath];

            BytesBuffer buffer = BytesBuffer.CreateAndDecodeFromStream(_stream, fInfo, fInfo.SeekPos);
            int objectLen = (fInfo.FileLength - 2) / 10;
            var objects = new List<TPvfObject>(objectLen);
            byte[] tbuf = buffer.Buffer;
            try
            {
                Parallel.For(0, objectLen, i =>
                {
                    KeyValuePair<int, string> dictPathInfo = GetListItem(tbuf, i, _stringTable);
                    if (_fileDict.TryGetValue($"{folder}/{dictPathInfo.Value}", out PvfFile pvfInfo))
                    {
                        objects.Add(
                           GetPvfObject<TPvfObject>(
                               pvfInfo,
                               dictPathInfo.Key
                           ));
                    }
                });
                return objects;
            }
            finally
            {
                buffer.Dispose();
            }

        }

        private TPvfObject GetPvfObject<TPvfObject>(PvfFile fInfo)
            where TPvfObject : IPvfDictCacheObject, new()
        {
            BytesBuffer buffer = BytesBuffer.CreateAndDecodeFromStream(_stream, fInfo, fInfo.SeekPos, true);
            int tokenCount = (fInfo.FileLength - 2) / 5;
            var reader = new PvfObjectReader(buffer.Buffer, tokenCount, _stringTable, _stringDict);
            var obj = new TPvfObject();
            obj.Initialize(reader);
            return obj;
        }

        private TPvfObject GetPvfObject<TPvfObject>(PvfFile fInfo, int objectIndex)
            where TPvfObject : PvfListCacheObject, new()
        {
            BytesBuffer buffer = BytesBuffer.CreateAndDecodeFromStream(_stream, fInfo, fInfo.SeekPos, true);
            int tokenCount = (fInfo.FileLength - 2) / 5;
            var reader = new PvfObjectReader(buffer.Buffer, tokenCount, _stringTable, _stringDict);
            var obj = new TPvfObject();
            obj.Initialize(objectIndex, reader);
            return obj;
        }


        private PvfHeader GetHeaderInfo()
        {
            var buffer = new BytesBuffer(256);
            try
            {
                buffer.Load(_stream, 4);
                int guidLength = buffer.Get<int>();
                buffer.Load(_stream, guidLength + FIXED_HEADER_SIZE);
                var fileLength = buffer.Get<int>(guidLength + 4);
                return new PvfHeader(
                    fileLength: fileLength,
                    fileCrc: buffer.Get<uint>(guidLength + 8),
                    chunkStart: 20 + guidLength + fileLength,
                    fileCount: buffer.Get<int>(guidLength + 12)
                    );
            }
            finally { buffer.Dispose(); }
        }

        private Dictionary<string, PvfFile> GetFileInfoDict(PvfHeader headerInfo)
        {
            BytesBuffer buffer = BytesBuffer.CreateAndDecodeFromStream(_stream, headerInfo);

            int fileCount = headerInfo.FileCount;
            int chunkStart = headerInfo.ChunkStart;
            // Quest ID is 16bit signed integer.
            var dict = new Dictionary<string, PvfFile>(Math.Min(fileCount, short.MaxValue));
            PvfFile pvfFileInfo;
            for (int i = 0, j = 0; i < fileCount; i++)
            {
                pvfFileInfo = TryCreatePvfFileInfo(in buffer, chunkStart, ref j);
                if (pvfFileInfo != null)
                    dict.Add(pvfFileInfo.FilePath, pvfFileInfo);
            }
            buffer.Dispose();
            return dict;

            PvfFile TryCreatePvfFileInfo(in BytesBuffer buf, int chunkBegin, ref int idx)
            {

                idx += 4;
                int strLen = buf.Get<int>(idx);
                idx += 4;
                string filePath = buf.GetString(strLen, _fileEncoding, idx);
                idx += strLen;
                int fileLength = buf.Get<int>(idx);
                idx += 4;
                uint crc = buf.Get<uint>(idx);
                idx += 4;
                int offset = buf.Get<int>(idx);
                idx += 4;
                return new PvfFile(fileLength, crc, filePath, chunkBegin + offset);
            }
        }

        private string[] CreateStringTable(PvfFile fInfo)
        {
            BytesBuffer buffer = BytesBuffer.CreateAndDecodeFromStream(_stream, fInfo, fInfo.SeekPos);
            var strTab = new string[buffer.Get<int>()];
            byte[] tBuf = buffer.Buffer;
            Parallel.For(0, strTab.Length, i =>
            {
                var start = tBuf.Get<int>((i << 2) + 4);
                var end = tBuf.Get<int>((i << 2) + 8);

                strTab[i] = tBuf.GetString(end - start, _strEncoding, start + 4);
            });
            buffer.Dispose();
            return strTab;
        }

        private Dictionary<int, string> CreateList(PvfFile fInfo)
        {
            BytesBuffer buffer = BytesBuffer.CreateAndDecodeFromStream(_stream, fInfo, fInfo.SeekPos);
            int dictLen = (fInfo.FileLength - 2) / 10;
            var dict = new Dictionary<int, string>(dictLen);
            byte[] tbuf = buffer.Buffer;
            try
            {
                Parallel.For(0, dictLen, i =>
                {
                    KeyValuePair<int, string> dictPathInfo = GetListItem(tbuf, i, _stringTable);
                    dict.Add(dictPathInfo.Key, dictPathInfo.Value);
                });
                return dict;
            }
            finally
            {
                buffer.Dispose();
            }
        }


        private Dictionary<int, Dictionary<string, string>> CreateStringDict(PvfFile fInfo, Dictionary<string, PvfFile> fileDict)
        {
            BytesBuffer buffer = BytesBuffer.CreateAndDecodeFromStream(_stream, fInfo, fInfo.SeekPos);
            int dictLen = (fInfo.FileLength - 2) / 10;
            var dict = new Dictionary<int, Dictionary<string, string>>(dictLen);
            byte[] tbuf = buffer.Buffer;
            try
            {
                Parallel.For(0, dictLen, i =>
                {
                    KeyValuePair<int, string> dictPathInfo = GetListItem(tbuf, i, _stringTable);
                    dict.Add(dictPathInfo.Key, CreateStrDictCore(fileDict[dictPathInfo.Value]));
                });
                return dict;
            }
            finally
            {
                buffer.Dispose();
            }
        }

        private static KeyValuePair<int, string> GetListItem(byte[] buffer, int idx, string[] strTable)
        {
            if (buffer.Get<byte>(idx * 10 + 2) != 2 || buffer.Get<byte>(idx * 10 + 7) != 7)
                throw new FormatException("格式错误。");
            return new KeyValuePair<int, string>(
                buffer.Get<int>(idx * 10 + 3), // index
                strTable[buffer.Get<int>(idx * 10 + 8)]); // path
        }


        public void Dispose()
        {
            if (_stream != null)
            {
                _stream.Dispose();
                _fileDict = null;
                _stringTable = null;
                _stringDict = null;
                _stream = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
