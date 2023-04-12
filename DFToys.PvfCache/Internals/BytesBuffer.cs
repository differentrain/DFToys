using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace DFToys.PvfCache.Internals
{
    internal readonly ref struct BytesBuffer
    {

        public BytesBuffer(int length)
        {
            Length = length.Align4();
            Buffer = ArrayPool<byte>.Shared.Rent(Length);
        }

        public readonly byte[] Buffer;
        public readonly int Length;


        public void Load(Stream stream, int length)
        {
            if (length != stream.Read(Buffer, 0, length))
                throw new EndOfStreamException("文件长度错误.");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Get<T>(int offset = 0) where T : unmanaged => Buffer.Get<T>(offset);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetString(int byteCount, Encoding encoding, int offset = 0) => Buffer.GetString(byteCount, encoding, offset);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose() => ArrayPool<byte>.Shared.Return(Buffer);

        public static BytesBuffer CreateFromStream(Stream stream, int byteCount, int seekPos = -1, bool isLock = false)
        {
            if (isLock)
            {
                lock (stream)
                {
                    return CreateFromStreamCore(stream, byteCount, seekPos);
                }
            }
            else
            {
                return CreateFromStreamCore(stream, byteCount, seekPos);
            }


            BytesBuffer CreateFromStreamCore(Stream mstream, int mbyteCount, int mseekPos)
            {
                if (mseekPos >= 0)
                    mstream.Seek(mseekPos, SeekOrigin.Begin);

                var ret = new BytesBuffer(mbyteCount);
                try
                {
                    ret.Load(mstream, mbyteCount);
                }
                catch
                {
                    ret.Dispose();
                    throw;
                }
                return ret;
            }

        }

        public static BytesBuffer CreateAndDecodeFromStream(Stream stream, DecodeInfo fInfo, int seekPos = -1, bool isLock = false)
        {
            var buf = CreateFromStream(stream, fInfo.ChunkLength, seekPos, isLock);
            fInfo.Decode(buf.Buffer, 0);
            return buf;
        }
    }
}
