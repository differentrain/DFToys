using DFToys.Common;
using DFToys.PvfCache.Internals;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace DFToys.PvfCache
{
    public abstract class ItemCache<TJobTable> : PvfListCacheObject
        where TJobTable : GameJobTable, new()
    {
        public static readonly TJobTable JobTable = new TJobTable();


        [JsonInclude]
        public string Name { get; private set; }

        [JsonInclude]
        public int? Rarity { get; private set; }

        [JsonInclude]
        public int? MinLevel { get; private set; }

        [JsonInclude]
        public int? MaxLevel { get; private set; }

        [JsonInclude]
        public List<string> UsableJob { get; private set; } = new List<string>();

        [JsonInclude]
        public string RawData { get; private set; }

        [JsonIgnore]
        public virtual string RarityString
        {
            get
            {
                if (Rarity == null)
                    return "其他";
                switch (Rarity.Value)
                {
                    case 0:
                        return "普通";
                    case 1:
                        return "高级";
                    case 2:
                        return "稀有";
                    case 3:
                        return "神器";
                    case 4:
                        return "史诗";
                    case 5:
                        return "勇者";
                    case 6:
                        return "传说";
                    case 7:
                        return "神话";
                    default:
                        return "其他";
                }
            }
        }


        protected abstract bool IsUsefullyLable(string lable);

        protected abstract bool SetIntValue(int value);

        protected abstract bool SetFloatValue(float value);

        protected abstract bool SetStringValue(string value);

        protected abstract void Final();


        public override string ToString() => string.IsNullOrEmpty(Name) ? $"未命名{Id}" : Name;


        protected override void InitializeCore(PvfObjectReader reader)
        {
            int state = 0;
            StringBuilder sb = StringBuilderPool.Shared.Get();
            int intValue;
            float floatValue;
            string strValue;
            try
            {
                while (reader.Read())
                {
                    switch (reader.Token)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            intValue = reader.GetValue<int>();
                            sb.Append(' ')
                              .Append(intValue);
                            state = ProcessIntValue(state, intValue);
                            break;
                        case 4:
                            floatValue = reader.GetValue<float>();
                            sb.Append(' ')
                              .Append(floatValue);
                            state = ProcessFloatValue(state, floatValue);
                            break;
                        case 5:
                            strValue = reader.TryGetString();
                            sb.AppendLine()
                              .AppendLine(strValue);
                            state = GetLabel(strValue);
                            break;
                        case 6:
                        case 7:
                        case 8:
                        case 10:
                            strValue = reader.TryGetString();
                            sb.Append(' ')
                              .Append(strValue);
                            state = ProcessStrValue(state, strValue);
                            break;
                        case 9:
                            break;
                        default:
                            state = 0;
                            break;
                    }
                }
                RawData = sb.ToString();
                Final();
            }
            catch
            {
                throw;
            }
            finally
            {
                StringBuilderPool.Shared.Return(sb);
            }

        }

        private int GetLabel(string label)
        {
            switch (label)
            {
                case "[name]":
                    return 1;
                case "[rarity]":
                    return 2;
                case "[minimum level]":
                    return 3;
                case "[usable job]":
                    return 4;
                case "[maximum level]":
                    return 5;
                default:
                    if (string.IsNullOrWhiteSpace(label))
                        return 0;
                    return IsUsefullyLable(label) ? 6 : 0;
            }
        }

        private int ProcessIntValue(int state, int value)
        {
            switch (state)
            {
                case 2:
                    Rarity = value;
                    return 0;
                case 3:
                    MinLevel = value;
                    return 0;
                case 5:
                    MaxLevel = value;
                    return 0;
                case 0:
                case 1:
                case 4:
                    return 0;
                default: //6
                    return SetIntValue(value) ? 0 : 6;
            }
        }

        private int ProcessFloatValue(int state, float value)
        {
            if (state == 6)
            {
                return SetFloatValue(value) ? 0 : 6;
            }
            else
            {
                return 0;
            }
        }

        private int ProcessStrValue(int state, string value)
        {
            switch (state)
            {
                case 1:
                    Name = value;
                    return 0;
                case 4:
                    UsableJob.Add(JobTable.GetFriendlyName(value));
                    return 4;
                case 0:
                case 2:
                case 3:
                case 5:
                    return 0;
                default: //6
                    return SetStringValue(value) ? 0 : 6;
            }
        }

 

    }
}
