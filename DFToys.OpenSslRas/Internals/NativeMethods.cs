﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace DFToys.OpenSslRas.Internals
{
    [SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
    {

        [DllImport("dlls\\libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void BIO_free(IntPtr bio);
        [DllImport("dlls\\libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BIO_new(IntPtr type);
        [DllImport("dlls\\libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BIO_s_mem();
        [DllImport("dlls\\libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int BIO_write(IntPtr b, byte* buf, int len);

        [DllImport("dlls\\libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        public extern static void EVP_PKEY_free(IntPtr pkey);
        [DllImport("dlls\\libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr EVP_PKEY_get1_RSA(IntPtr pkey);

        [DllImport("libeay32", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RSA_free(IntPtr rsa);
        [DllImport("libeay32", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int RSA_private_decrypt(int flen, byte* from, byte* to, IntPtr rsa, RsaPadding padding);
        [DllImport("libeay32", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int RSA_private_encrypt(int flen, byte* from, byte* to, IntPtr rsa, RsaPadding padding);
        [DllImport("libeay32", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int RSA_public_decrypt(int flen, byte* from, byte* to, IntPtr rsa, RsaPadding padding);
        [DllImport("libeay32", CallingConvention = CallingConvention.Cdecl)]
        public static unsafe extern int RSA_public_encrypt(int flen, byte* from, byte* to, IntPtr rsa, RsaPadding padding);

        [DllImport("dlls\\libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr d2i_PrivateKey_bio(Bio bp, IntPtr u);
        [DllImport("dlls\\libeay32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr d2i_PUBKEY_bio(Bio bp, IntPtr u);







    }
}
