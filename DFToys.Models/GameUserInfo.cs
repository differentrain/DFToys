using System;
using System.Collections.Generic;
using System.Text;

namespace DFToys.Models
{
    public sealed class GameUserInfo
    {
        public GameUserInfo(int id, string name, GameCharacter[] characters )
        {
            Id = id;
            Name = name;
            Characters = characters;
        }

        public int Id { get; }

        public string Name { get; }

        public GameCharacter[] Characters { get; }

    }
}
