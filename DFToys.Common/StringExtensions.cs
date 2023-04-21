using DFToys.Common.Internals;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace DFToys.Common
{
    public static class StringExtensions
    {
        public static bool ContainsCnString(this string cnStr1, string cnStr2)
        {
            return cnStr1.Contains(cnStr2) || (cnStr2.TryGetChtString(out string chtStr) && cnStr1.Contains(chtStr));
        }

        public static bool TryGetChtString(this string chsStr, out string chtStr)
        {
            return MapStringCore(chsStr, NativeMethods.LCMAP_TRADITIONAL_CHINESE, out chtStr);
        }

        public static bool TryGetChsString(this string chtStr, out string chsStr)
        {
            return MapStringCore(chtStr, NativeMethods.LCMAP_SIMPLIFIED_CHINESE, out chsStr);
        }

 
        private static bool MapStringCore(string str, int mapType, out string mappedStr)
        {
            mappedStr = null;

            int size = NativeMethods.LCMapStringEx(
                  "zh-CN",
                  mapType,
                  str,
                  str.Length,
                  null,
                  0,
                  IntPtr.Zero,
                  IntPtr.Zero,
                  IntPtr.Zero);

            if (size == 0)
                return false;

            size <<= 2;

            byte[] buffer = ArrayPool<byte>.Shared.Rent(size);

            size = NativeMethods.LCMapStringEx(
                  "zh-CN",
                  mapType,
                  str,
                  str.Length,
                  buffer,
                  size,
                  IntPtr.Zero,
                  IntPtr.Zero,
                  IntPtr.Zero);

            if (size == 0)
                return false;
       
            try
            {
                unsafe
                {
                    // unicode16 编码的字符并不一定只占用2个字节
                    fixed (byte* p = buffer)
                        size = Encoding.Unicode.GetByteCount((char*)p, size);
                }
                mappedStr = Encoding.Unicode.GetString(buffer, 0, size);
                return true;
            }
            catch
            {
                return false;
            }
            finally { ArrayPool<byte>.Shared.Return(buffer); }

        }
    }
}
