using DFToys.PvfCache;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DFToys
{
    public sealed class MyCache
    {
        public static readonly MyCache Shared;

        static MyCache()
        {
            if (File.Exists("MyCache.json"))
            {
                FileStream fs;
                try
                {
                    fs = new FileStream("MyCache.json", FileMode.Open);
                    MyCache cache = JsonSerializer.Deserialize<MyCache>(fs);
                    Shared = cache ?? new MyCache();
                    Shared._needSavd = false;
                }
                catch
                {
                    Shared = new MyCache();
                }
            }
            else
            {
                Shared = new MyCache();
            }
        }

        private bool _needSavd = false;

        private Dictionary<int, QuestCache> _quest;

        public Dictionary<int, QuestCache> QuestCache
        {
            get => _quest;
            set
            {
                _needSavd = true;
                _quest = value;
            }
        }

        public List<EquipmentCache<GameJobTable, GameEquipmentTable>> EquipmentCache { get; set; }

        public List<StackableItemCache<GameJobTable, GameItemTable>> ItemCache { get; set; }

        public KeyValuePair<string, KeyValuePair<string, KeyValuePair<string, string[]>[]>[]>[] EquipmentIndexCache { get; set; }

        public KeyValuePair<string, string[]>[] ItemIndexCache { get; set; }

        public void Save()
        {
            if (!_needSavd || QuestCache == null || EquipmentCache == null || ItemCache == null)
                return;


            FileStream fs;
            try
            {
                fs = new FileStream("MyCache.json", FileMode.Create);
                JsonSerializer.Serialize(fs, this);
            }
            catch { }
        }

    }
}
