using DFToys.OpenSslRas.Internals;
using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;

namespace DFToys.OpenSslRas
{
    public sealed class SimpleRsa : SafeHandleZeroOrMinusOneIsInvalid
    {
        private readonly IntPtr _rsaKey;

        private SimpleRsa(IntPtr rsa, IntPtr rsaKey, bool isPublic) : base(true)
        {
            handle = rsa;
            _rsaKey = rsaKey;
            IsPublicKey = isPublic;
        }

        public bool IsPublicKey { get; }

        public int Encrypt(in ReadOnlySpan<byte> data, in Span<byte> output, RsaPadding padding)
        {
            return IsPublicKey ? PublicEncrypt(data, output, padding) : PrivateEncrypt(data, output, padding);
        }

        public int Decrypt(in ReadOnlySpan<byte> data, in Span<byte> output, RsaPadding padding)
        {
            return IsPublicKey ? PublicDecrypt(data, output, padding) : PrivateDecrypt(data, output, padding);
        }


        public static SimpleRsa CreateFromPublicKey(in ReadOnlySpan<byte> key)
        {
            using (var b = new Bio(in key))
            {
                IntPtr pkey = IntPtr.Size == 4 ?
                      NativeMethods.d2i_PUBKEY_bio(b, IntPtr.Zero) :
                      NativeMethodsX64.d2i_PUBKEY_bio(b, IntPtr.Zero);
                IntPtr pRsa = GetRsaCore(pkey);
                return new SimpleRsa(pRsa, pkey, true);
            }
        }

        public static SimpleRsa CreateFromPrivateKey(in ReadOnlySpan<byte> key)
        {
            using (var b = new Bio(in key))
            {
                IntPtr pkey = IntPtr.Size == 4 ?
                      NativeMethods.d2i_PrivateKey_bio(b, IntPtr.Zero) :
                      NativeMethodsX64.d2i_PrivateKey_bio(b, IntPtr.Zero);
                IntPtr pRsa = GetRsaCore(pkey);
                return new SimpleRsa(pRsa, pkey, false);
            }
        }


        protected override bool ReleaseHandle()
        {
            if (IntPtr.Size == 4)
            {
                NativeMethods.EVP_PKEY_free(handle);
                NativeMethods.EVP_PKEY_free(_rsaKey);
            }
            else
            {
                NativeMethodsX64.EVP_PKEY_free(handle);
                NativeMethodsX64.EVP_PKEY_free(_rsaKey);
            }
            return true;
        }


        private int PublicEncrypt(in ReadOnlySpan<byte> data, in Span<byte> output, RsaPadding padding)
        {
            unsafe
            {
                fixed (byte* pf = data, pt = output)
                    return IntPtr.Size == 4 ?
                           NativeMethods.RSA_public_encrypt(data.Length, pf, pt, handle, padding) :
                           NativeMethodsX64.RSA_public_encrypt(data.Length, pf, pt, handle, padding);
            }
        }
        private int PrivateEncrypt(in ReadOnlySpan<byte> data, in Span<byte> output, RsaPadding padding)
        {
            unsafe
            {
                fixed (byte* pf = data, pt = output)
                    return IntPtr.Size == 4 ?
                           NativeMethods.RSA_private_encrypt(data.Length, pf, pt, handle, padding) :
                           NativeMethodsX64.RSA_private_encrypt(data.Length, pf, pt, handle, padding);
            }
        }
        private int PublicDecrypt(in ReadOnlySpan<byte> data, in Span<byte> output, RsaPadding padding)
        {
            unsafe
            {
                fixed (byte* pf = data, pt = output)
                    return IntPtr.Size == 4 ?
                           NativeMethods.RSA_public_decrypt(data.Length, pf, pt, handle, padding) :
                           NativeMethodsX64.RSA_public_decrypt(data.Length, pf, pt, handle, padding);
            }
        }
        private int PrivateDecrypt(in ReadOnlySpan<byte> data, in Span<byte> output, RsaPadding padding)
        {
            unsafe
            {
                fixed (byte* pf = data, pt = output)
                    return IntPtr.Size == 4 ?
                           NativeMethods.RSA_private_decrypt(data.Length, pf, pt, handle, padding) :
                           NativeMethodsX64.RSA_private_decrypt(data.Length, pf, pt, handle, padding);
            }
        }

        private static IntPtr GetRsaCore(IntPtr key)
        {
            IntPtr pRsa;
            if (IntPtr.Size == 4)
            {
                if (key == IntPtr.Zero ||
                    (pRsa = NativeMethods.EVP_PKEY_get1_RSA(key)) == IntPtr.Zero)
                    throw new Win32Exception();
            }
            else
            {
                if (key == IntPtr.Zero ||
                    (pRsa = NativeMethodsX64.EVP_PKEY_get1_RSA(key)) == IntPtr.Zero)
                    throw new Win32Exception();
            }
            return pRsa;
        }
    }
}
