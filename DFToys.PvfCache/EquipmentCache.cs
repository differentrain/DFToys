using DFToys.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.Json.Serialization;

namespace DFToys.PvfCache
{
    public class EquipmentCache<TJobTable, TEquipmentTable> : ItemCache<TJobTable>
       where TJobTable : GameJobTable, new()
        where TEquipmentTable : GameEquipmentTable, new()
    {
        public static readonly GameEquipmentTable EquipmentTable = new GameEquipmentTable();

        private string _rawEquipmentType;
        private int? _rawSubType;
        private string _rawItemGroup;

        private int _state = 0;

        [JsonInclude]
        public int? AntiEvil { get; private set; }

        [JsonInclude]
        public bool IsSuit { get; private set; }

        [JsonInclude]
        public bool IsSealing { get; private set; }

        [JsonInclude]
        public int? Durability { get; private set; }

        [JsonInclude]
        public string MainType { get; private set; }

        [JsonInclude]
        public string SubType1 { get; private set; }

        [JsonInclude]
        public string SubType2 { get; private set; }

        [JsonInclude]
        public string FullType { get; private set; }




        protected override void Final()
        {
            MainType = EquipmentTable.TryGetMainTypeByItemGroup(_rawItemGroup, out string subType1, out string subType2);

            if (MainType == null)
            {
                MainType = EquipmentTable.GetMainTypeByEquimentType(_rawEquipmentType, out string subType);

                if (MainType == EquipmentTable.WeaponFriendlyName)
                {
                    subType1 = EquipmentTable.GuessWeaponSubType(UsableJob, _rawSubType, JobTable);
                }
                else if (MainType == EquipmentTable.ArmorFriendlyName)
                {
                    subType1 = EquipmentTable.GuessArmorSubType(_rawSubType);
                    subType2 = subType;
                }
                else
                {
                    subType1 = subType;
                }
            }

            SubType1 = subType1;
            SubType2 = subType2;

            if (subType1 == EquipmentTable.PetCreatureFriendlyName)
            {
                SubType2 = EquipmentTable.GetPetSubType2(_rawSubType);
            }


            var sb = StringBuilderPool.Shared.Get().Append(MainType);

            if (SubType1 != null)
            {
                sb.Append('-')
                  .Append(SubType1);
                if (SubType2 != null)
                {
                    sb.Append('-')
                    .Append(SubType2);
                }
            }
            FullType = sb.ToString();
            StringBuilderPool.Shared.Return(sb);
        }

        protected override bool IsUsefullyLable(string lable)
        {
            switch (lable)
            {
                case "[equipment type]":
                    _state = 1;
                    return true;
                case "[anti evil]":
                    _state = 2;
                    return true;
                case "[sub type]":
                    _state = 3;
                    return true;
                case "[item group name]":
                    _state = 4;
                    return true;
                case "[durability]":
                    _state = 5;
                    return true;
                case "[attach type]":
                    _state = 6;
                    return true;
                case "[part set index]":
                case "[set item]":
                case "[set item master]":
                    IsSuit = true;
                    _state = 0;
                    return false;
                default:
                    _state = 0;
                    return false;
            }
        }

        protected override bool SetFloatValue(float value) => true;


        protected override bool SetIntValue(int value)
        {
            if (_state == 2)
                AntiEvil = value;
            else if (_state == 3)
                _rawSubType = value;
            else if (_state == 5)
                Durability = value;

            _state = 0;
            return true;
        }

        protected override bool SetStringValue(string value)
        {
            if (_state == 1)
                _rawEquipmentType = value;
            else if (_state == 4)
                _rawItemGroup = value;
            else if (_state == 6 && value.StartsWith("[sealing"))
                IsSealing = true;
            _state = 0;
            return true;
        }
    }
}
