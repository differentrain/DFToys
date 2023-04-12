using DFToys.Abstract;
using System.Data;

namespace DFToys.DbConnection.Internals
{
    internal sealed class SimpleRecord<T> : SingletonRecordCreator<T, SimpleRecord<T>>
    {
        public SimpleRecord() { }

        public override T Create(IDataRecord record)
        {
            return (T)record.GetValue(0);
        }

    }
}
