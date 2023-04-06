using System;
using System.Data;

namespace DFToys.Abstract
{
    public abstract class SingletonRecordCreator<TRecord, TSelf> : IRecordCreator<TRecord>
        where TSelf : SingletonRecordCreator<TRecord, TSelf>, new()
    {
        public static TSelf Instance { get; } = new TSelf();

        public virtual TRecord Create(IDataRecord record)
        {
            object[] args = new object[record.FieldCount];
            record.GetValues(args);
            return (TRecord)Activator.CreateInstance(typeof(TRecord), args);
        }
    }
}
