using DFToys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace DFToys.PvfCache
{
    public sealed class QuestCache : IPvfDictCacheObject
    {
        private const string LABEL_QUEST_GIVE_ITEM = "[depend give item]";
        private const string LABEL_QUEST_TYPE = "[type]";
        private const string LABEL_QUEST_DATA = "[int data]";
        private const string LABEL_QUEST_NAME = "[name]";

        private const string FLAG_QUEST_SEEK_ITEM = "[seeking]";

        [JsonInclude]
        public string Name { get; private set; }

        [JsonInclude]
        public GameItem[] Items { get; private set; }

        public void Initialize(PvfObjectReader reader)
        {
            int state = 0;
            var questItem = new Dictionary<uint, uint>();
            var seekItem = new Dictionary<uint, uint>();
            bool needItem = false;
            while (reader.Read())
            {
                switch (state)
                {
                    case 0:
                        state = UpdateState_0(reader);
                        break;
                    case 1: //depend give item Id
                        state = UpdateState_1(reader);
                        break;
                    case 2: //depend give item Count
                        state = UpdateState_2(reader, questItem);
                        break;
                    case 3: // quest type
                        state = UpdateState_3(reader, ref needItem);
                        break;
                    case 4: // quest data Id
                        state = UpdateState_4(reader);
                        break;
                    case 5: // quest data Count
                        state = UpdateState_5(reader, seekItem);
                        break;
                    case 6: // quest Name before
                        state = UpdateState_6(reader);
                        break;
                    case 7: // quest Name after
                        state = UpdateState_7(reader);
                        break;
                    default: // -1
                        break;
                }
            }
            if (!needItem)
                return;
            ProcessItem(questItem, seekItem);
        }

        private void ProcessItem(Dictionary<uint, uint> quest, Dictionary<uint, uint> seek)
        {

            if (quest.Count == 0)
            {
                Items = seek.Count == 0 ?
                    Array.Empty<GameItem>() :
                    seek
                     .Select(i => new GameItem(i.Key, i.Value))
                     .ToArray();
            }
            else
            {

                Items = seek
                     .Except(quest, KVEqualityComparer.Shared)
                     .Where(i => !quest.ContainsKey(i.Key) || quest[i.Key] <= i.Value)
                     .Select(i => new GameItem(i.Key, i.Value))
                 .ToArray();
            }
        }


        private static int UpdateState_0(PvfObjectReader reader)
        {
            if (reader.Token == 5)
            {
                switch (reader.TryGetString())
                {
                    case LABEL_QUEST_GIVE_ITEM:
                        return 1;
                    case LABEL_QUEST_TYPE:
                        return 3;
                    case LABEL_QUEST_DATA:
                        return 4;
                    case LABEL_QUEST_NAME:
                        return 6;
                    default:
                        break;
                }

            }
            return 0;
        }

        private static int UpdateState_1(PvfObjectReader reader)
        {
            if (reader.Token == 2)
            {
                return 2;
            }
            else if (reader.Token == 5)
            {
                return UpdateState_0(reader);
            }
            return 1;
        }

        private static int UpdateState_2(PvfObjectReader reader, Dictionary<uint, uint> questItem)
        {
            if (reader.Token == 2)
            {
                questItem.Add(reader.GetLastValue<uint>(), reader.GetValue<uint>());
                return 1;
            }
            else if (reader.Token == 5)
            {
                return UpdateState_0(reader);
            }
            return 2;
        }

        private static int UpdateState_3(PvfObjectReader reader, ref bool needItem)
        {
            if (reader.Token == 7)
            {
                needItem = reader.TryGetString() == FLAG_QUEST_SEEK_ITEM;
                return 0;
            }
            else if (reader.Token == 5)
            {
                return UpdateState_0(reader);
            }
            return 3;
        }


        private static int UpdateState_4(PvfObjectReader reader)
        {
            if (reader.Token == 2)
            {
                return 5;
            }
            else if (reader.Token == 5)
            {
                return UpdateState_0(reader);
            }
            return 4;
        }

        private static int UpdateState_5(PvfObjectReader reader, Dictionary<uint, uint> seekItem)
        {
            if (reader.Token == 2)
            {
                var key = reader.GetLastValue<uint>();
                if (!seekItem.ContainsKey(key))
                {
                    seekItem.Add(key, reader.GetValue<uint>());
                }
                return 4;
            }
            else if (reader.Token == 5)
            {
                return UpdateState_0(reader);
            }
            return 5;
        }

        private int UpdateState_6(PvfObjectReader reader)
        {
            if (reader.Token == 9)
            {
                return 7;
            }
            else if (reader.Token == 7)
            {
                Name = reader.TryGetString();
                return 0;
            }
            else if (reader.Token == 5)
            {
                return UpdateState_0(reader);
            }
            return 6;
        }

        private int UpdateState_7(PvfObjectReader reader)
        {
            if (reader.Token == 10)
            {
                Name = reader.TryGetString();

                return 0;
            }
            else if (reader.Token == 5)
            {
                return UpdateState_0(reader);
            }
            return 7;
        }


        private sealed class KVEqualityComparer : IEqualityComparer<KeyValuePair<uint, uint>>
        {
            public static readonly KVEqualityComparer Shared = new KVEqualityComparer();

            public bool Equals(KeyValuePair<uint, uint> x, KeyValuePair<uint, uint> y)
            {
                return x.Value == y.Value && x.Key == y.Key;
            }

            public int GetHashCode(KeyValuePair<uint, uint> obj)
            {
                return HashCode.Combine(obj.Key, obj.Value);
            }
        }


    }
}
