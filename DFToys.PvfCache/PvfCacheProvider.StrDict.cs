using DFToys.PvfCache.Internals;
using System.Collections.Generic;

namespace DFToys.PvfCache
{
    partial class PvfCacheProvider
    {

        private unsafe ref struct DictParseContent
        {
            public readonly Dictionary<string, string> strDict;
            public readonly string str;
            public int i;
            public int state;
            public int begin;
            public char ch;
            public string key;

            public DictParseContent(string strValue)
            {
                strDict = new Dictionary<string, string>();
                str = strValue;
                key = string.Empty;
                i = 0;
                state = 0;
                begin = 0;
                ch = '\0';
            }
        }


        private Dictionary<string, string> CreateStrDict(PvfFile strFile)
        {
            BytesBuffer strBuf = BytesBuffer.CreateAndDecodeFromStream(_stream, strFile, strFile.SeekPos);
            string str = strBuf.GetString(strFile.FileLength, _strEncoding);
            strBuf.Dispose();
            var mcontent = new DictParseContent(str);
            unsafe
            {
                fixed (char* ptr = str)
                {

                    while (mcontent.i < str.Length)
                    {
                        mcontent.ch = ptr[mcontent.i];
                        switch (mcontent.state)
                        {
                            case 0: // start
                                Process_0(ref mcontent);
                                break;
                            case 1: // //
                                Process_1(ref mcontent);
                                break;
                            case 2: // key
                                Process_2(ref mcontent);
                                break;
                            case 3: // value
                                Process_3(ref mcontent);
                                break;
                            case 4: // // 
                                Process_4(ref mcontent);
                                break;
                            default: // 5 skip 
                                Process_5(ref mcontent);
                                break;
                        }
                        ++mcontent.i;
                    }

                }
            }
            return mcontent.strDict;

        }


        private static unsafe void Process_0(ref DictParseContent content)
        {
            if (content.ch == '/')
            {
                content.state = 1;
            }
            else if (char.IsWhiteSpace(content.ch))
            {
                return;
            }
            else
            {
                content.begin = content.i;
                content.state = 2;
            }
        }

        private static unsafe void Process_1(ref DictParseContent content)
        {
            if (content.ch == '/')
            {
                content.state = 5;
            }
            else
            {
                content.begin = content.i - 1;
                content.state = 2;
            }
        }

        private static unsafe void Process_2(ref DictParseContent content)
        {
            if (content.ch == '>')
            {
                content.state = 3;

                content.key = content.str.Substring(content.begin, content.i - content.begin);
                content.begin = content.i + 1;
            }

        }

        private static unsafe void Process_3(ref DictParseContent content)
        {
            if (content.ch == '\r' || content.ch == '\n')
            {
                content.state = 0;
                content.strDict.Add(content.key, content.str.Substring(content.begin, content.i - content.begin));
            }
            else if (content.ch == '/')
            {
                content.state = 4;
            }
        }

        private static unsafe void Process_4(ref DictParseContent content)
        {
            if (content.ch == '/')
            {
                content.state = 5;
                content.strDict.Add(content.key, content.str.Substring(content.begin, content.i - content.begin - 1));
            }
            else if (content.ch == '\r' || content.ch == '\n')
            {
                content.state = 0;
                content.strDict.Add(content.key, content.str.Substring(content.begin, content.i - content.begin));
            }
            else
            {
                content.state = 3;
            }
        }

        private static unsafe void Process_5(ref DictParseContent content)
        {
            if (content.ch == '\r' || content.ch == '\n')
            {
                content.state = 0;
            }

        }

    }
}
