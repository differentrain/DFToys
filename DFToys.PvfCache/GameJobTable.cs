using System;
using System.Collections.Generic;
using System.Text;

namespace DFToys.PvfCache
{
    public class GameJobTable
    {
        public virtual string[] Jobs { get; }=new string[] {
            "鬼剑士","黑暗武士","格斗家(女)","格斗家(男)","神枪手(男)","神枪手(女)","魔法师(女)","魔法师(男)","圣职者","暗夜使者","缔造者"
        };

        public virtual string AllowAllJobFriendlyName => "通用";
        public virtual string SwordmanFriendlyName => "鬼剑士";
        public virtual string DemonicSwordmanFriendlyName => "黑暗武士";
        public virtual string FighterFriendlyName => "格斗家(女)";
        public virtual string AtFighterFriendlyName => "格斗家(男)";
        public virtual string GunnerFriendlyName => "神枪手(男)";
        public virtual string AtGunnerFriendlyName => "神枪手(女)";
        public virtual string MageFriendlyName => "魔法师(女)";
        public virtual string AtMageManFriendlyName => "魔法师(男)";
        public virtual string PriestFriendlyName => "圣职者";
        public virtual string ThiefFriendlyName => "暗夜使者";
        public virtual string CreatorMageFriendlyName => "缔造者";

        public virtual string GetFriendlyName(string rawJobString)
        {
            switch (rawJobString)
            {
                case "[all]":
                    return AllowAllJobFriendlyName;
                case "[swordman]":
                    return SwordmanFriendlyName;
                case "[demonic swordman]":
                    return DemonicSwordmanFriendlyName;
                case "[fighter]":
                    return FighterFriendlyName;
                case "[at fighter]":
                    return AtFighterFriendlyName;
                case "[gunner]":
                    return GunnerFriendlyName;
                case "[at gunner]":
                    return AtGunnerFriendlyName;
                case "[mage]":
                    return MageFriendlyName;
                case "[at mage]":
                    return AtMageManFriendlyName;
                case "[priest]":
                    return PriestFriendlyName;
                case "[thief]":
                    return ThiefFriendlyName;
                case "[creator mage]":
                    return CreatorMageFriendlyName;
                default:
                    return rawJobString;
            }
        }

        //public virtual string GetSubTypeName(string rawJobString, int subType)
        //{
        //    switch (rawJobString)
        //    {
        //        case "[swordman]":
        //        case "[demonic swordman]":
        //            return GetSwordmanWeapon(subType);
        //        case "[fighter]":
        //        case "[at fighter]":
        //            return GetFighterWeapon(subType);
        //        case "[gunner]":
        //        case "[at gunner]":
        //            return GetGunnerWeapon(subType);
        //        case "[mage]":
        //        case "[at mage]":
        //        case "[creator mage]":
        //            return GetMegaWeapon(subType);
        //        case "[priest]":
        //            return GetPriestWeapon(subType);
        //        case "[thief]":
        //            return GetThiefWeapon(subType);
        //        default:
        //            return null;
        //    }
        //}


      
    }
}
