using DFToys.PvfCache.Internals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        private Dictionary<int, string> _stringFileDict;

        public PvfCacheProvider(string pvfPath, Encoding fileEncoding, Encoding strEncoding)
        {
            _fileEncoding = fileEncoding;
            _strEncoding = strEncoding;
            _stream = new FileStream(pvfPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.RandomAccess);
            PvfHeader headerInfo = GetHeaderInfo();
            _fileDict = GetFileInfoDict(headerInfo);
            _stringTable = CreateStringTable(_fileDict[NAME_STRING_TABLE]);
            _stringFileDict = CreateList(_fileDict[NAME_STRING_DICT_LIST]);
        }

        public static Dictionary<int, TPvfObject> FromJson<TPvfObject>(string json)
        {
            return JsonSerializer.Deserialize<Dictionary<int, TPvfObject>>(json);
        }

        public static string ToJson<TPvfObject>(Dictionary<int, TPvfObject> cache)
        {
            return JsonSerializer.Serialize(cache);
        }

        public Dictionary<int, QuestCache> TryCreateQuestCache()
        {
            return TryCreateCache<QuestCache>("n_quest", "n_quest/quest.lst", "n_quest/quest.");
        }

        public Dictionary<int, TPvfObject> TryCreateCache<TPvfObject>(string folder, string listPath, string strDictFlag)
          where TPvfObject : IPvfCacheObject<TPvfObject>, new()
        {
            KeyValuePair<int, string> dictPath = _stringFileDict
                .FirstOrDefault(
                    d => d.Value.StartsWith(strDictFlag));

            if (dictPath.Value == null)
                throw new ArgumentException("未找到目标列表。");
            Dictionary<string, string> strDict = CreateStrDict(_fileDict[dictPath.Value]);
            return CreateCacheCore<TPvfObject>(folder, _fileDict[listPath], dictPath.Key, strDict);
        }

        private Dictionary<int, TPvfObject> CreateCacheCore<TPvfObject>(string folder, PvfFile fInfo, int dictIndex, Dictionary<string, string> strDict)
            where TPvfObject : IPvfCacheObject<TPvfObject>, new()
        {
            BytesBuffer buffer = BytesBuffer.CreateAndDecodeFromStream(_stream, fInfo, fInfo.SeekPos);
            int dictLen = (fInfo.FileLength - 2) / 10;
            var dict = new Dictionary<int, TPvfObject>(dictLen);
            byte[] tbuf = buffer.Buffer;
            try
            {
                Parallel.For(0, dictLen, i =>
                {
                    KeyValuePair<int, string> dictPathInfo = GetListItem(tbuf, i, _stringTable);
                    dict.Add(
                        dictPathInfo.Key,
                        GetPvfObject<TPvfObject>(
                            _fileDict[$"{folder}/{dictPathInfo.Value}"],
                            dictIndex,
                            strDict
                        ));
                });
                return dict;
            }
            finally
            {
                buffer.Dispose();
            }
        }

        private TPvfObject GetPvfObject<TPvfObject>(PvfFile fInfo, int strDictIndex, Dictionary<string, string> strDict)
            where TPvfObject : IPvfCacheObject<TPvfObject>, new()
        {
            BytesBuffer buffer = BytesBuffer.CreateAndDecodeFromStream(_stream, fInfo, fInfo.SeekPos, true);
            int tokenCount = (fInfo.FileLength - 2) / 5;
            var reader = new PvfObjectReader(buffer.Buffer, tokenCount, _stringTable, strDict, strDictIndex);
            var obj = new TPvfObject();
            obj.Initialize(reader);
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
                _stringFileDict = null;
                _stream = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
