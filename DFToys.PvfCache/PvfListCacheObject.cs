using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DFToys.PvfCache
{
    public abstract class PvfListCacheObject
    {
        [JsonInclude]
        public int Id { get; private set; }

        public virtual void Initialize(int id, PvfObjectReader reader)
        {
            Id = id;
            InitializeCore(reader);
        }

        protected abstract void InitializeCore(PvfObjectReader reader);
    }
}
