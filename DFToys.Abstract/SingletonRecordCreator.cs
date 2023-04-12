using System;
using System.Data;
using System.Text;

namespace DFToys.Abstract
{
    public abstract class SingletonRecordCreator<TRecord, TSelf> : IRecordCreator<TRecord>
        where TSelf : SingletonRecordCreator<TRecord, TSelf>, new()
    {
        public static TSelf Instance { get; } = new TSelf();

        public virtual TRecord Create(IDataRecord record)
        {
            int fieldCount = record.FieldCount;
            object[] args = new object[fieldCount];
            for (int i = 0; i < fieldCount; i++)
            {
                if (record.GetFieldType(i) == typeof(string))
                    args[i] = GetStringFromSqlString(record.GetString(i));
                else
                    args[i] = record[i];
            }
            return (TRecord)Activator.CreateInstance(typeof(TRecord), args);
        }

        protected virtual string GetStringFromSqlString(string sqlString)
        {
            Encoding latin1 = Encoding.GetEncoding(1252);
            unsafe
            {
                byte* ptrBuffer = stackalloc byte[255];
                int count;
                fixed (char* ptrChar = sqlString)
                    count = latin1.GetBytes(ptrChar, sqlString.Length, ptrBuffer, 255);
                return Encoding.UTF8.GetString(ptrBuffer, count);
            }
        }
    }
}
