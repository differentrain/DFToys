using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFToys.PvfCache.Internals
{
    internal sealed class PvfFile : DecodeInfo
    {
        public PvfFile(int fileLength, uint fileCrc, string path, int seek) : base(fileLength, fileCrc)
        {
            FilePath = path;
            SeekPos = seek;
        }

        public readonly string FilePath;

        public readonly int SeekPos;
    }
}
