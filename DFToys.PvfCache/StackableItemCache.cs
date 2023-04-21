using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DFToys.PvfCache
{
    public class StackableItemCache<TJobTable, TItemType> : ItemCache<TJobTable>
       where TJobTable : GameJobTable, new()
       where TItemType : GameItemTable, new()
    {
        public static readonly TItemType ItemTable = new TItemType();

        private int _state = 0;
 

        [JsonInclude]
        public int? StackLimit { get; private set; }

        [JsonInclude]
        public string ItemType { get; private set; }

        protected override void Final()
        {

        }

        protected override bool IsUsefullyLable(string lable)
        {
            switch (lable)
            {
                case "[stackable type]":
                    _state = 1;
                    return true;
                case "[stack limit]":
                    _state = 2;
                    return true;
                default:
                    _state = 0;
                    return false;
            }
        }

        protected override bool SetFloatValue(float value) => true;

        protected override bool SetIntValue(int value)
        {
           if (_state == 2)
                StackLimit = value;
            _state = 0;
            return true;
        }

        protected override bool SetStringValue(string value)
        {
            if (_state == 1)
            {
                ItemType = ItemTable.GetItemTypeFriendlyName(value);
            }
            _state = 0;
            return true;
        }


    }
}
