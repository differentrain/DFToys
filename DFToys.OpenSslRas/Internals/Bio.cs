using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;

namespace DFToys.OpenSslRas.Internals
{
    internal sealed class Bio : SafeHandleZeroOrMinusOneIsInvalid
    {

        public Bio(in ReadOnlySpan<byte> key) : base(true)
        {
            unsafe
            {
                fixed (byte* pb = key)
                {

                    if (IntPtr.Size == 4)
                    {
                        IntPtr p = NativeMethods.BIO_s_mem();
                        if (p == IntPtr.Zero || (handle = NativeMethods.BIO_new(p)) == IntPtr.Zero || NativeMethods.BIO_write(handle, pb, key.Length) != key.Length)
                            throw new Win32Exception();
                    }
                    else
                    {
                        IntPtr p = NativeMethodsX64.BIO_s_mem();
                        if (p == IntPtr.Zero || (handle = NativeMethodsX64.BIO_new(p)) == IntPtr.Zero || NativeMethodsX64.BIO_write(handle, pb, key.Length) != key.Length)
                            throw new Win32Exception();
                    }

                }
            }
        }
        protected override bool ReleaseHandle()
        {
            if (IntPtr.Size == 4)
            {
                NativeMethods.BIO_free(handle);
            }
            else
            {
                NativeMethodsX64.BIO_free(handle);
            }
            return true;
        }

    }
}
