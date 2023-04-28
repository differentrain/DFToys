using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DFToys.GameCheat.Internals
{
    [SuppressUnmanagedCodeSecurity]
    internal class NativeMethods
    {

        public const int ERROR_NOACCESS = 0x3E6;
        public const int MEMORY_PROTECT_EXECUTE_READ_WRITE = 0x40;
  

        [DllImport("Kernel32.dll", SetLastError = false, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool ReadProcessMemory([In] IntPtr hProcess, [In] IntPtr lpBaseAddress, [In, Out] void* lpBuffer, [In] int nSize, [Out, Optional] out int lpNumberOfBytesRead);

        [DllImport("Kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern unsafe bool WriteProcessMemory([In] IntPtr hProcess, [In] IntPtr lpBaseAddress, [In, Out] void* lpBuffer, [In] int nSize, [Out, Optional] out int lpNumberOfBytesWritten);


        [DllImport("user32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi, SetLastError = false)]
        public static extern IntPtr FindWindowEx([In] IntPtr hWndParent, [In] IntPtr hWndChildAfter, [In] string lpszClass, [In] string lpszWindow);

        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = false)]
        public static extern int GetWindowThreadProcessId([In] IntPtr hWnd, [Out] out int lpdwProcessId);

        [DllImport("kernel32.dll", SetLastError = false, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool VirtualProtectEx([In] IntPtr hProcess, [In] IntPtr lpAddress, [In] int dwSize, int flNewProtect, [Out] out int lpflOldProtect);

    }
}
