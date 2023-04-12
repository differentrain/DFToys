using DFToys.PvfCache.Internals;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DFToys.PvfCache
{
    public sealed class PvfObjectReader
    {
        private readonly byte[] _buf;
        private readonly int _tokenCount;
        private readonly string[] _strTab;
        private readonly Dictionary<string, string> _strDict;

        private int _index = -1;

        internal PvfObjectReader(byte[] buf, int tokenCount, string[] strTab, Dictionary<string, string> strDict, int dictIndex)
        {
            _buf = buf;
            _tokenCount = tokenCount;
            _strTab = strTab;
            _strDict = strDict;
            StrDictIndex = dictIndex;
        }

        public int StrDictIndex { get; }

        public byte Token { get; private set; }


        public T GetValue<T>() where T : unmanaged
        {
            if (Unsafe.SizeOf<T>() > 4)
                throw new ArgumentException();
            if (_index < 0)
                throw new InvalidOperationException();
            return _buf.Get<T>(_index * 5 + 3);
        }

        public T GetLastValue<T>() where T : unmanaged
        {
            if (Unsafe.SizeOf<T>() > 4)
                throw new ArgumentException();
            var i = _index - 1;
            if (i < 0)
                throw new InvalidOperationException();
            return _buf.Get<T>(i * 5 + 3);
        }


        public string TryGetString()
        {

            var str = TryGetStringFromTable(GetValue<int>());
            if (str == null)
                return str;
            return Token == 10 ? TryGetStringFromDict(str) : str;
        }


        public string TryGetStringFromTable(int index)
        {
            return index < _strTab.Length ? _strTab[index] : null;
        }


        public string TryGetStringFromDict(string key)
        {
            return _strDict.TryGetValue(key, out string ret) ?
                        ret :
                        null;
        }

        public bool Read()
        {
            ++_index;
            if (_index < _tokenCount)
            {
                Token = _buf.Get<byte>(_index * 5 + 2);
                return true;
            }
            return false;
        }






    }
}
