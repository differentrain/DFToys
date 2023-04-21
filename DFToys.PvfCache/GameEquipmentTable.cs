using System;
using System.Collections.Generic;
using System.Text;

namespace DFToys.PvfCache
{
    public class GameEquipmentTable
    {

        public virtual string WeaponFriendlyName => "武器";

        public virtual string ArmorFriendlyName => "防具";

        public virtual string JewelryFriendlyName => "饰品";

        public virtual string PetCreatureFriendlyName => "宠物";

        public virtual string PetEggFriendlyName => "宠物蛋";

        public virtual string AvatarFriendlyName => "装扮";

        public virtual bool IsForPets(string friendlyName)
        {
            return friendlyName.StartsWith("宠物装备");
        }



        public virtual string GetMainTypeByEquimentType(string rawString, out string subType)
        {
            switch (rawString)
            {
                case "[weapon]":
                    subType = null;
                    return WeaponFriendlyName;

                case "[coat]":
                    subType = "上衣";
                    return ArmorFriendlyName;
                case "[shoulder]":
                    subType = "护肩";
                    return ArmorFriendlyName;
                case "[pants]":
                    subType = "下衣";
                    return ArmorFriendlyName;
                case "[waist]":
                    subType = "腰带";
                    return ArmorFriendlyName;
                case "[shoes]":
                    subType = "鞋";
                    return ArmorFriendlyName;

                case "[amulet]":
                    subType = "项链";
                    return JewelryFriendlyName;
                case "[wrist]":
                    subType = "手镯";
                    return JewelryFriendlyName;
                case "[ring]":
                    subType = "戒指";
                    return JewelryFriendlyName;
                case "[title name]":
                    subType = "称号";
                    return JewelryFriendlyName;
                case "[support]":
                    subType = "附加装备";
                    return JewelryFriendlyName;
                case "[magic stone]":
                    subType = "魔法石";
                    return JewelryFriendlyName;

                case "[hair avatar]":
                    subType = "头部";
                    return AvatarFriendlyName;
                case "[hat avatar]":
                    subType = "帽子";
                    return AvatarFriendlyName;
                case "[coat avatar]":
                    subType = "上装";
                    return AvatarFriendlyName;
                case "[face avatar]":
                    subType = "面部";
                    return AvatarFriendlyName;
                case "[breast avatar]":
                    subType = "胸部";
                    return AvatarFriendlyName;
                case "[waist avatar]":
                    subType = "腰部";
                    return AvatarFriendlyName;
                case "[pants avatar]":
                    subType = "下装";
                    return AvatarFriendlyName;
                case "[skin avatar]":
                    subType = "皮肤";
                    return AvatarFriendlyName;
                case "[shoes avatar]":
                    subType = "鞋";
                    return AvatarFriendlyName;
                case "[aurora avatar]":
                    subType = "光环";
                    return AvatarFriendlyName;

                case "[creature]":
                    subType = PetCreatureFriendlyName;
                    return "宠物";
                case "[artifact blue]":
                    subType = "宠物装备-蓝";
                    return "宠物";
                case "[artifact green]":
                    subType = "宠物装备-绿";
                    return "宠物";
                case "[artifact red]":
                    subType = "宠物装备-红";
                    return "宠物";

                default:
                    subType = null;
                    return "其他";
            }
        }

        public virtual string TryGetMainTypeByItemGroup(string rawItemGroup, out string subType1, out string subType2)
        {
            subType2 = null;

            switch (rawItemGroup)
            {
                case "wrist":
                    subType1 = "手镯";
                    return JewelryFriendlyName;
                case "ring":
                    subType1 = "戒指";
                    return JewelryFriendlyName;
                case "amulet":
                    subType1 = "项链";
                    return JewelryFriendlyName;

                case "support":
                    subType1 = "辅助装备";
                    return JewelryFriendlyName;
                case "magic stone":
                    subType1 = "魔法石";
                    return JewelryFriendlyName;

                case "knuckle":
                    subType1 = "手套";
                    return WeaponFriendlyName;
                case "gauntlet":
                    subType1 = "臂铠";
                    return WeaponFriendlyName;
                case "claw":
                    subType1 = "格斗爪";
                    return WeaponFriendlyName;
                case "bglove":
                    subType1 = "拳套";
                    return WeaponFriendlyName;
                case "tonfa":
                    subType1 = "东方棍";
                    return WeaponFriendlyName;

                case "revolver":
                    subType1 = "左轮";
                    return WeaponFriendlyName;
                case "automatic":
                    subType1 = "自动手枪";
                    return WeaponFriendlyName;
                case "musket":
                    subType1 = "步枪";
                    return WeaponFriendlyName;
                case "hcannon":
                    subType1 = "手炮";
                    return WeaponFriendlyName;
                case "bowgun":
                    subType1 = "手弩";
                    return WeaponFriendlyName;

                case "ssword":
                    subType1 = "短剑";
                    return WeaponFriendlyName;
                case "katana":
                    subType1 = "武士刀";
                    return WeaponFriendlyName;
                case "club":
                    subType1 = "钝器";
                    return WeaponFriendlyName;
                case "lswd":
                    subType1 = "巨剑";
                    return WeaponFriendlyName;
                case "beamswd":
                    subType1 = "光剑";
                    return WeaponFriendlyName;

                case "spear":
                    subType1 = "战矛";
                    return WeaponFriendlyName;
                case "pole":
                    subType1 = "长棍";
                    return WeaponFriendlyName;
                case "rod":
                    subType1 = "魔杖";
                    return WeaponFriendlyName;
                case "staff":
                    subType1 = "法杖";
                    return WeaponFriendlyName;
                case "broom":
                    subType1 = "扫把";
                    return WeaponFriendlyName;

                case "cross":
                    subType1 = "十字架";
                    return WeaponFriendlyName;
                case "rosary":
                    subType1 = "念珠";
                    return WeaponFriendlyName;
                case "totem":
                    subType1 = "图腾";
                    return WeaponFriendlyName;
                case "scythe":
                    subType1 = "镰刀";
                    return WeaponFriendlyName;
                case "axe":
                    subType1 = "战斧";
                    return WeaponFriendlyName;

                case "dagger":
                    subType1 = "匕首";
                    return WeaponFriendlyName;
                case "twinswd":
                    subType1 = "双剑";
                    return WeaponFriendlyName;
                case "wand":
                    subType1 = "手杖";
                    return WeaponFriendlyName;

                case "cl coat":
                    subType1 = "布甲";
                    subType2 = "上衣";
                    return ArmorFriendlyName;
                case "cl pants":
                    subType1 = "布甲";
                    subType2 = "下衣";
                    return ArmorFriendlyName;
                case "cl shoulder":
                    subType1 = "布甲";
                    subType2 = "护肩";
                    return ArmorFriendlyName;
                case "cl waist":
                    subType1 = "布甲";
                    subType2 = "腰带";
                    return ArmorFriendlyName;
                case "cl shoes":
                    subType1 = "布甲";
                    subType2 = "鞋";
                    return ArmorFriendlyName;

                case "lt coat":
                    subType1 = "皮甲";
                    subType2 = "上衣";
                    return ArmorFriendlyName;
                case "lt pants":
                    subType1 = "皮甲";
                    subType2 = "下衣";
                    return ArmorFriendlyName;
                case "lt shoulder":
                    subType1 = "皮甲";
                    subType2 = "护肩";
                    return ArmorFriendlyName;
                case "lt waist":
                    subType1 = "皮甲";
                    subType2 = "腰带";
                    return ArmorFriendlyName;
                case "lt shoes":
                    subType1 = "皮甲";
                    subType2 = "鞋";
                    return ArmorFriendlyName;

                case "la coat":
                    subType1 = "轻甲";
                    subType2 = "上衣";
                    return ArmorFriendlyName;
                case "la pants":
                    subType1 = "轻甲";
                    subType2 = "下衣";
                    return ArmorFriendlyName;
                case "la shoulder":
                    subType1 = "轻甲";
                    subType2 = "护肩";
                    return ArmorFriendlyName;
                case "la waist":
                    subType1 = "轻甲";
                    subType2 = "腰带";
                    return ArmorFriendlyName;
                case "la shoes":
                    subType1 = "轻甲";
                    subType2 = "鞋";
                    return ArmorFriendlyName;

                case "ha coat":
                    subType1 = "重甲";
                    subType2 = "上衣";
                    return ArmorFriendlyName;
                case "ha pants":
                    subType1 = "重甲";
                    subType2 = "下衣";
                    return ArmorFriendlyName;
                case "ha shoulder":
                    subType1 = "重甲";
                    subType2 = "护肩";
                    return ArmorFriendlyName;
                case "ha waist":
                    subType1 = "重甲";
                    subType2 = "腰带";
                    return ArmorFriendlyName;
                case "ha shoes":
                    subType1 = "重甲";
                    subType2 = "鞋";
                    return ArmorFriendlyName;

                case "mt coat":
                    subType1 = "板甲";
                    subType2 = "上衣";
                    return ArmorFriendlyName;
                case "mt pants":
                    subType1 = "板甲";
                    subType2 = "下衣";
                    return ArmorFriendlyName;
                case "mt shoulder":
                    subType1 = "板甲";
                    subType2 = "护肩";
                    return ArmorFriendlyName;
                case "mt waist":
                    subType1 = "板甲";
                    subType2 = "腰带";
                    return ArmorFriendlyName;
                case "mt shoes":
                    subType1 = "板甲";
                    subType2 = "鞋";
                    return ArmorFriendlyName;

                default:
                    subType1 = null;
                    return null;
            }
        }

        public virtual string GuessWeaponSubType(List<string> usableJob, int? rawSubType, GameJobTable jobTable)
        {
            if (usableJob.Count > 0 && rawSubType != null && !usableJob.Contains(jobTable.AllowAllJobFriendlyName))
            {
                return GetWeaponSubTypeName(usableJob[0], rawSubType.Value, jobTable);
            }
            else
            {
                return "其他";
            }
        }

        public virtual string GuessArmorSubType(int? rawSubType)
        {
            if (rawSubType != null)
            {
                switch (rawSubType.Value)
                {
                    case 0:
                        return "布甲";
                    case 1:
                        return "皮甲";
                    case 2:
                        return "轻甲";
                    case 3:
                        return "重甲";
                    case 4:
                        return "板甲";
                    default:
                        return "其他";
                }
            }
            else
            {
                return "其他";
            }
        }

        public virtual string GetPetSubType2(int? rawSubType)
        {
            return (!rawSubType.HasValue || rawSubType.Value == 0) ? "宠物" : PetEggFriendlyName;
        }


        protected virtual string GetWeaponSubTypeName(string jobFriendlyName, int rawSubType, GameJobTable jobTable)
        {
            if (jobFriendlyName == jobTable.SwordmanFriendlyName ||
                jobFriendlyName == jobTable.DemonicSwordmanFriendlyName)
            {
                return GetSwordmanWeaponName(rawSubType);
            }
            else if (jobFriendlyName == jobTable.FighterFriendlyName ||
                jobFriendlyName == jobTable.AtFighterFriendlyName)
            {
                return GetFighterWeaponName(rawSubType);
            }
            else if (jobFriendlyName == jobTable.GunnerFriendlyName ||
                jobFriendlyName == jobTable.AtGunnerFriendlyName)
            {
                return GetGunnerWeaponName(rawSubType);
            }
            else if (jobFriendlyName == jobTable.MageFriendlyName ||
                jobFriendlyName == jobTable.AtMageManFriendlyName ||
               jobFriendlyName == jobTable.CreatorMageFriendlyName)
            {
                return GetMegaWeaponName(rawSubType);
            }
            else if (jobFriendlyName == jobTable.PriestFriendlyName)
            {
                return GetPriestWeaponName(rawSubType);
            }
            else if (jobFriendlyName == jobTable.ThiefFriendlyName)
            {
                return GetThiefWeaponName(rawSubType);
            }
            else
            {
                return $"{jobFriendlyName}武器";
            }
        }


        protected virtual string GetSwordmanWeaponName(int subType)
        {
            switch (subType)
            {
                case 0:
                    return "短剑";
                case 1:
                    return "武士刀";
                case 2:
                    return "钝器";
                case 3:
                    return "巨剑";
                case 5:
                    return "光剑";
                default:
                    return "其他";
            }
        }

        protected virtual string GetFighterWeaponName(int subType)
        {
            switch (subType)
            {
                case 0:
                    return "手套";
                case 1:
                    return "臂铠";
                case 2:
                    return "格斗爪";
                case 3:
                    return "拳套";
                case 5:
                    return "东方棍";
                default:
                    return "其他";
            }
        }

        protected virtual string GetGunnerWeaponName(int subType)
        {
            switch (subType)
            {
                case 0:
                    return "左轮";
                case 1:
                    return "自动手枪";
                case 2:
                    return "步枪";
                case 3:
                    return "手炮";
                case 4:
                    return "手弩";
                default:
                    return "其他";
            }
        }

        protected virtual string GetMegaWeaponName(int subType)
        {
            switch (subType)
            {
                case 0:
                    return "战矛";
                case 1:
                    return "长棍";
                case 2:
                    return "魔杖";
                case 3:
                    return "法杖";
                case 4:
                    return "扫把";
                default:
                    return "其他";
            }
        }


        protected virtual string GetPriestWeaponName(int subType)
        {
            switch (subType)
            {
                case 0:
                    return "十字架";
                case 1:
                    return "念珠";
                case 2:
                    return "图腾";
                case 3:
                    return "镰刀";
                case 4:
                    return "战斧";
                default:
                    return "其他";
            }
        }


        protected virtual string GetThiefWeaponName(int subType)
        {
            switch (subType)
            {
                case 0:
                    return "匕首";
                case 1:
                    return "双剑";
                case 3:
                    return "手杖";
                default:
                    return "其他";
            }
        }


    }
}
