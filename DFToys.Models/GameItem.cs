using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DFToys.Models
{
    public sealed class GameItem : IEquatable<GameItem>
    {

        public GameItem() { }

        public GameItem(uint id, uint count)
        {
            Id = id;
            Count = count;
        }

        [JsonInclude]
        public uint Id { get; private set; }
        [JsonInclude]
        public uint Count { get; private set; }

        public override bool Equals(object obj) => obj is GameItem item && Equals(item);

        public override int GetHashCode() => HashCode.Combine(Id, Count);

        public bool Equals(GameItem other) => other.Id == Id && other.Count == Count;

    }
}
