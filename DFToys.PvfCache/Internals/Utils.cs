using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DFToys.PvfCache.Internals
{
    internal static class Utils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Align4(this int value) => (value + 3) & unchecked((int)0xFFFFFFFC);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Get<T>(this byte[] bytes, int offset = 0) where T : unmanaged
        {
            unsafe
            {
                fixed (byte* ptr = bytes)
                {
                    return Unsafe.Read<T>(ptr + offset);
                }
            }
        }

        public static string GetString(this byte[] bytes, int byteCount, Encoding encoding, int offset = 0)
        {
            unsafe
            {
                fixed (byte* p = bytes)
                    return encoding.GetString(p + offset, byteCount).ToLower();
            }
        }
    }
}
