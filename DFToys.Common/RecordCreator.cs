using System;
using System.Data;
using System.Text;

namespace DFToys.Common
{
    public abstract class RecordCreator<TRecord, TSelf> 
        where TSelf : RecordCreator<TRecord, TSelf>, new()
    {
        public static TSelf Instance { get; } = new TSelf();

        public virtual TRecord Create<TStringConvert>(IDataRecord record)
            where TStringConvert : DbStringConvert<TStringConvert>, new()
        {
            int fieldCount = record.FieldCount;
            object[] args = new object[fieldCount];
            for (int i = 0; i < fieldCount; i++)
            {
                if (record.GetFieldType(i) == typeof(string))
                    args[i] = DbStringConvert<TStringConvert>.Instance.FromDbString(record.GetString(i));
                else
                    args[i] = record[i];
            }
            return (TRecord)Activator.CreateInstance(typeof(TRecord), args);
        }
    }
}
