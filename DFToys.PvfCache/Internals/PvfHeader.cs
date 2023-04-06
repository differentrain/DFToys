using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFToys.PvfCache.Internals
{
    internal sealed class PvfHeader : DecodeInfo
    {
        public PvfHeader(int fileLength, uint fileCrc, int chunkStart, int fileCount) : base(fileLength, fileCrc)
        {
            ChunkStart = chunkStart;
            FileCount = fileCount;
        }

        public readonly int ChunkStart;

        public readonly int FileCount;
    }
}
