using DFToys.GameCheat.Internals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DFToys.GameCheat
{
    public abstract class GameProcess<TSelf> : IDisposable
        where TSelf : GameProcess<TSelf>, new()
    {
        private Process _proc;


        public event EventHandler GameExited;


        public bool IsDisposed => _proc == null;

        public bool IsExited => _proc.HasExited;

        public abstract string GameProcessName { get; }
        public abstract string WindowClass { get; }
        public abstract string WindowName { get; }

        public abstract void Initialize();
        public abstract bool Verify();



        protected virtual void OnProc_Exited(object sender, EventArgs e)
        {
            GameExited?.Invoke(this, e);
        }


        public static TSelf TryCatch()
        {
            var ret = new TSelf();
            if (ret.WindowClass != null || ret.WindowName != null)
            {
                ret = CreateByProcWindow(ret);
                if (ret != null)
                {
                    return ret;
                }
                ret = new TSelf();
            }

            if (ret.GameProcessName == null)
            {
                ret.Dispose();
                return null;
            }
            else
            {
                return CreateByProcName(ret);
            }

        }



        private static TSelf CreateByProcWindow(TSelf ret)
        {
            IntPtr hWnd = NativeMethods.FindWindowEx(IntPtr.Zero, IntPtr.Zero, ret.WindowClass, ret.WindowName);
            if (hWnd == IntPtr.Zero ||
                NativeMethods.GetWindowThreadProcessId(hWnd, out int pid) == 0)
                return null;
            try
            {
                Process proc = Process.GetProcessById(pid);
                ret._proc = proc;
                ret.Initialize();
                if (ret.Verify())
                {
                    ret._proc.EnableRaisingEvents = true;
                    ret._proc.Exited += ret.OnProc_Exited;
                    return ret;
                }
                ret.Dispose();
                return null;
            }
            catch
            {
                ret.Dispose();
                return null;
            }
        }

        private static TSelf CreateByProcName(TSelf ret)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(ret.GameProcessName);
                bool found = false;
                for (int i = 0; i < processes.Length; i++)
                {
                    if (!found)
                    {
                        found = InitGameProc(processes[i], ret);
                    }
                    else
                    {
                        processes[i].Dispose();
                    }
                }
                return found ? ret : null;
            }
            catch
            {
                ret.Dispose();
                return null;
            }

            bool InitGameProc(Process p, TSelf gp)
            {
                gp._proc = p;
                try
                {
                    gp.Initialize();
                    if (gp.Verify())
                    {
                        gp._proc.EnableRaisingEvents = true;
                        gp._proc.Exited += gp.OnProc_Exited;
                        return true;
                    }
                    gp._proc = null;
                    p.Dispose();
                    return false;
                }
                catch
                {
                    gp._proc = null;
                    p.Dispose();
                    return false;
                }
            }
        }

        public T ReadMemory<T>(IntPtr address) where T : unmanaged
        {
            unsafe
            {
                int size = Marshal.SizeOf<T>();
                byte* buffer = stackalloc byte[size];
                int error = ReadMemoryCore(address, buffer, size);
                if (error == 0)
                {
                    return Unsafe.Read<T>(buffer);
                }
                throw new Win32Exception(error);
            }
        }

        public bool ReadMemory<T>(IntPtr address, in Span<T> buffer) where T : unmanaged
        {

            unsafe
            {
                int size = Marshal.SizeOf<T>() * buffer.Length;
                fixed (T* ptr = buffer)
                {
                    return ReadMemoryCore(address, ptr, size) == 0;
                }
            }
        }

        public bool WriteMemory<T>(IntPtr address, in T buffer) where T : unmanaged
        {
            unsafe
            {
                int size = Marshal.SizeOf<T>();
                fixed (T* ptr = &buffer)
                {
                    return WriteMemoryCore(address, ptr, size) == 0;
                }
            }
        }

        public bool WriteMemory<T>(IntPtr address, in ReadOnlySpan<T> buffer) where T : unmanaged
        {
            unsafe
            {
                int size = Marshal.SizeOf<T>() * buffer.Length;
                fixed (T* ptr = buffer)
                {
                    return WriteMemoryCore(address, ptr, size) == 0;
                }
            }
        }


        private unsafe int ReadMemoryCore(IntPtr address, void* pBuffer, int bufferSize)
        {
            if (_proc == null)
                throw new InvalidOperationException();
            IntPtr handle = _proc.Handle;

            if (!NativeMethods.ReadProcessMemory(handle, address, pBuffer, bufferSize, out _))
            {
                int error = Marshal.GetLastWin32Error();
                if (error != NativeMethods.ERROR_NOACCESS ||
                          !NativeMethods.VirtualProtectEx(handle, address, bufferSize, NativeMethods.MEMORY_PROTECT_EXECUTE_READ_WRITE, out _) ||
                          !NativeMethods.ReadProcessMemory(handle, address, pBuffer, bufferSize, out _))
                {
                    return error;
                }
            }
            return 0;
        }

        private unsafe int WriteMemoryCore(IntPtr address, void* pBuffer, int bufferSize)
        {
            if (_proc == null)
                throw new InvalidOperationException();
            IntPtr handle = _proc.Handle;
            if (!NativeMethods.WriteProcessMemory(handle, address, pBuffer, bufferSize, out _))
            {
                int error = Marshal.GetLastWin32Error();
                if (error != NativeMethods.ERROR_NOACCESS ||
                          !NativeMethods.VirtualProtectEx(handle, address, bufferSize, NativeMethods.MEMORY_PROTECT_EXECUTE_READ_WRITE, out _) ||
                          !NativeMethods.WriteProcessMemory(handle, address, pBuffer, bufferSize, out _))
                {
                    return error;
                }
            }
            return 0;
        }



        protected virtual void Dispose(bool disposing)
        {
            if (_proc != null)
            {
                if (disposing)
                {
                    _proc.Exited -= OnProc_Exited;
                    _proc.Dispose();
                }
                _proc = null;
            }
        }


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
