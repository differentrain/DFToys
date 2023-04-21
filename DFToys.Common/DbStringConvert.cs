using System;
using System.Buffers;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Text;

namespace DFToys.Common
{
    public abstract class DbStringConvert<TSelf>
        where TSelf : DbStringConvert<TSelf>, new()
    {
        public static TSelf Instance { get; } = new TSelf();

        public abstract Encoding DbEncoding { get; }

        public abstract Encoding DbStringEncoding { get; }

        public virtual string FromDbString(string dbString)
        {
            return TryConvertStringCore(DbEncoding, DbStringEncoding, dbString, out string str) ? str : null;
        }

        public virtual string ToDbString(string dbString)
        {
            return TryConvertStringCore(DbStringEncoding, DbEncoding, dbString, out string str) ? str : null;
        }


        protected static bool TryConvertStringCore(Encoding encodingFrom, Encoding encodingTo, string str, out string result)
        {
            result = null;
            int length = encodingFrom.GetByteCount(str);
            byte[] buffer = ArrayPool<byte>.Shared.Rent(length);
            try
            {
                encodingFrom.GetBytes(str, 0, str.Length, buffer, 0);
                result = encodingTo.GetString(buffer, 0, length);
                return true;
            }
            catch { return false; }
            finally { ArrayPool<byte>.Shared.Return(buffer); }
        }
    }

}
