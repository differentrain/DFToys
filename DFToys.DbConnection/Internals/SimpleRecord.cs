using DFToys.Common;
using System.Data;

namespace DFToys.DbConnection.Internals
{
    internal sealed class SimpleRecord<T> : RecordCreator<T, SimpleRecord<T>>
    {
        public SimpleRecord() { }

        public override T Create<TStringConvert>(IDataRecord record)
        {
            if (record.GetFieldType(0) == typeof(string))
            {
                return (T)(object)DbStringConvert<TStringConvert>.Instance.FromDbString(record.GetString(0));
            }
            else
            {
                return (T)record.GetValue(0);
            }
        }
    }
}
