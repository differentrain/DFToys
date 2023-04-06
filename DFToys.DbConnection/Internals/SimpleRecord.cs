using DFToys.Abstract;
using DFToys.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DFToys.DbConnection.Internals
{
    internal sealed class SimpleRecord<T> : SingletonRecordCreator<T,SimpleRecord<T>>
    {
        public SimpleRecord() { }

        public override T Create(IDataRecord record)
        {
            return (T)record.GetValue(0); 
        }

    }
}
