using System.Data;

namespace DFToys.Abstract
{
    public interface IRecordCreator<T>
    {
        T Create(IDataRecord record);
    }
}
