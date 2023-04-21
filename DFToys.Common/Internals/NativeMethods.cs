using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace DFToys.Common.Internals
{
    [SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
    {

        public const int LCMAP_SIMPLIFIED_CHINESE = 0x02000000;
        public const int LCMAP_TRADITIONAL_CHINESE = 0x04000000;

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode, SetLastError = false, CallingConvention = CallingConvention.Winapi)]
        public static extern int LCMapStringEx(
          [In] string lpLocaleName,
          [In] int dwMapFlags,
          [In] string lpSrcStr,
          [In] int cchSrc,
          [In, Out] byte[] dest,
          [In] int cchDest,
          [In, Optional] IntPtr lpVersionInformation,
          [In, Optional] IntPtr lpReserved,
          [In, Optional] IntPtr sortHandle);
    }
}
