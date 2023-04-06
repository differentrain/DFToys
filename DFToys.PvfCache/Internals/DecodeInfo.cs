 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DFToys.PvfCache.Internals
{
    internal abstract class DecodeInfo
    {
        private const uint DECODE_MAGIC = 0x81A79011;

        public readonly int FileLength;
        public readonly uint Crc;
        public readonly int ChunkLength;


        protected DecodeInfo(int fileLength, uint fileCrc)
        {
            FileLength = fileLength;
            Crc = fileCrc;
            ChunkLength = fileLength.Align4();
        }


        public void Decode(byte[] buffer, int offset)
        {
            unsafe
            {
                fixed (byte* ptr = buffer)
                    Decode(ptr, ChunkLength, DECODE_MAGIC ^ Crc);
            }
            if (ChunkLength > FileLength)
                Array.Clear(buffer, FileLength, ChunkLength - FileLength);
        }

        private unsafe static void Decode(byte* p, int byteCount, uint key)
        {
            var puint = (uint*)p;
            int intLen = byteCount >> 2;
            int i = 0;

            if (Vector<uint>.Count >= 8)
                i = Decode256(puint, intLen, key, i);
            else if (Vector<uint>.Count >= 4)
                i = Decode128(puint, intLen, key, i);

            uint v32;
            while (i < intLen)
            {
                v32 = puint[i] ^ key;
                puint[i] = (v32 << 26) | (v32 >> 6);
                ++i;
            }

        }

        private unsafe static int Decode256(uint* puint, int intLen, uint key, int i)
        {
            if (intLen >= 8)
            {
                uint* v = stackalloc uint[8];

                while (i < intLen - 7)
                {
                    v[0] = puint[i + 0] ^ key;
                    v[1] = puint[i + 1] ^ key;
                    v[2] = puint[i + 2] ^ key;
                    v[3] = puint[i + 3] ^ key;
                    v[4] = puint[i + 4] ^ key;
                    v[5] = puint[i + 5] ^ key;
                    v[6] = puint[i + 6] ^ key;
                    v[7] = puint[i + 7] ^ key;
                    puint[i + 0] = (v[0] << 26) | (v[0] >> 6);
                    puint[i + 1] = (v[1] << 26) | (v[1] >> 6);
                    puint[i + 2] = (v[2] << 26) | (v[2] >> 6);
                    puint[i + 3] = (v[3] << 26) | (v[3] >> 6);
                    puint[i + 4] = (v[4] << 26) | (v[4] >> 6);
                    puint[i + 5] = (v[5] << 26) | (v[5] >> 6);
                    puint[i + 6] = (v[6] << 26) | (v[6] >> 6);
                    puint[i + 7] = (v[7] << 26) | (v[7] >> 6);

                    i += 8;
                }
            }
            return i;
        }

        private unsafe static int Decode128(uint* puint, int intLen, uint key, int i)
        {
            if (intLen >= 4)
            {
                uint* v = stackalloc uint[4];
                while (i < intLen - 3)
                {
                    v[0] = puint[i + 0] ^ key;
                    v[1] = puint[i + 1] ^ key;
                    v[2] = puint[i + 2] ^ key;
                    v[3] = puint[i + 3] ^ key;
                    puint[i + 0] = (v[0] << 26) | (v[0] >> 6);
                    puint[i + 1] = (v[1] << 26) | (v[1] >> 6);
                    puint[i + 2] = (v[2] << 26) | (v[2] >> 6);
                    puint[i + 3] = (v[3] << 26) | (v[3] >> 6);
                    i += 4;
                }
            }
            return i;
        }

    }
}
