using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFToys.PvfCache
{
    public interface IPvfCacheObject<TSelf>
        where TSelf : IPvfCacheObject<TSelf>, new()
    {

        void Initialize(PvfObjectReader reader);
    }
}
