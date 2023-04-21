using DFToys.Common;
using System;

namespace DFToys.Models
{
    public sealed class GameCharacter : RecordCreator<GameCharacter, GameCharacter>, IEquatable<GameCharacter>
    {
        public GameCharacter() { }

        public GameCharacter(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public override bool Equals(object obj) => obj is GameCharacter charac && Equals(charac);

        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => Name;

        public bool Equals(GameCharacter other) => other.Id == Id;


    }
}
