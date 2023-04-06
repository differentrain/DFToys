using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DFToys.Abstract
{
    public interface IRecordCreator<T>
    {
        T Create(IDataRecord record);
    }
}
