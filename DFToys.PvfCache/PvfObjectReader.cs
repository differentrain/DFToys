using DFToys.Common;
using DFToys.PvfCache.Internals;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DFToys.PvfCache
{
    public sealed class PvfObjectReader
    {
        private readonly byte[] _buf;
        private readonly int _tokenCount;
        private readonly string[] _strTab;
        private readonly Dictionary<int, Dictionary<string, string>> _strDict;

        private int _index = -1;

        internal PvfObjectReader(byte[] buf, int tokenCount, string[] strTab, Dictionary<int, Dictionary<string, string>> strDict)
        {
            _buf = buf;
            _tokenCount = tokenCount;
            _strTab = strTab;
            _strDict = strDict;
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
            int i = _index - 1;
            if (i < 0)
                throw new InvalidOperationException();
            return _buf.Get<T>(i * 5 + 3);
        }


        public string TryGetString()
        {
            if (_index < 0)
                throw new InvalidOperationException();
            var idx = _buf.Get<int>(_index * 5 + 3);

            if (idx >= _strTab.Length || idx < 0)
                return null;

            string str = _strTab[idx];

            string chs;

            if (Token != 10)
                return str.TryGetChsString(out chs) ? chs : str;

            int i = _index - 1;

            if (i < 0)
                throw new InvalidOperationException();

            return _strDict.TryGetValue(_buf.Get<int>(i * 5 + 3), out Dictionary<string, string> dict) &&
                   dict.TryGetValue(str, out str) ?
                    str.TryGetChsString(out chs) ? chs : str :
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
