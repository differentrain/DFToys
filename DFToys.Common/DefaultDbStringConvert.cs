using System;
using System.Collections.Generic;
using System.Text;

namespace DFToys.Common
{
    public sealed class DefaultDbStringConvert : DbStringConvert<DefaultDbStringConvert>
    {
        public override Encoding DbEncoding { get; } = Encoding.GetEncoding(1252);

        public override Encoding DbStringEncoding { get; } = Encoding.UTF8;
    }
}
