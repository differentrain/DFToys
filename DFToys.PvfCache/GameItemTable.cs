using System;
using System.Collections.Generic;
using System.Text;

namespace DFToys.PvfCache
{
    public class GameItemTable
    {
        public string GetItemTypeFriendlyName(string rawString)
        {
            switch (rawString)
            {
                case "[waste]":
                    return "消耗品";
                case "[recipe]":
                    return "设计图";
                case "[quest]":
                    return "任务物品";
                case "[material]":
                    return "材料";
                case "[material expert job]":
                    return "副职业材料";
                case "[enchant waste]":
                    return "副职业镶嵌";
                case "[unlimited waste]":
                    return "无限物品";
                case "[feed]":
                case "[creature]":
                case "[creature expitem]":
                    return "宠物相关";
                case "[usable cera package]":
                    return "时装包";
                case "[avatar emblem]":
                    return "时装徽章";
                case "[dye]":
                    return "染色剂";
                case "[booster selection]":
                    return "自选包";
                case "[cera package]":
                case "[booster]":
                case "[cera booster]":
                case "[upgrade limit cube]":
                    return "礼包类";
                case "[booster random]":
                case "[upgradable legacy]":
                case "[multi upgradable legacy]":
                case "[multi upgradable legacy bonus cera]":
                case "[legacy]":
                case "[random upgradable legacy]":
                case "[random reward item]":
                    return "抽奖类";
                case "[global effect]":
                    return "全局道具";
                case "[contract]":
                    return "契约";
                case "[expert town potion]":
                case "[teleport potion]":
                    return "秘药";
                case "[disguise]":
                    return "COS道具";
                case "[only effect]":
                    return "气氛类";
                case "[quest receive]":
                    return "任务通告";
                case "[throw]":
                    return "投掷道具";
                case "[set]":
                    return "陷阱";
                case "[town and dungeon]":
                case "[unlimited town and dungeon]":
                    return "便携道具";
                case "[etc]":
                case "[stackable legacy]":
                default:
                    return "其他";
            }
        }
    }
}
