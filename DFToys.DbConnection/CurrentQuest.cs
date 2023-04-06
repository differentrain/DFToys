using DFToys.Models;
using DFToys.PvfCache;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DFToys.DbConnection
{
    public sealed class CurrentQuest
    {
        private readonly int _id;

        public CurrentQuest(int index, int id, Dictionary<int, QuestCache> questCache)
        {
            Index = index;
            _id = id;
            questCache.TryGetValue(id, out QuestCache info);
            Info=info;
        }

        public int Index { get; }

        public QuestCache Info { get; }

        public override string ToString()
        {
            return Info == null || string.IsNullOrWhiteSpace(Info.Name) ?
                $"未知任务{_id}" :
                Info.Name;
        }

    }
}
