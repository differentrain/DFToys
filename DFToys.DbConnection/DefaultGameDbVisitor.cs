using DFToys.Common;
using DFToys.DbConnection.Internals;
using DFToys.Models;
using DFToys.PvfCache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DFToys.DbConnection
{
    public class DefaultGameDbVisitor : GameDbVisitor<DefaultGameDbVisitor>
    {

        public DefaultGameDbVisitor(string ip, int port, string user, string password) : base(ip, port, user, password)
        {
        }

        public void Register<TStringConvert>(string userName)
             where TStringConvert : DbStringConvert<TStringConvert>, new()
        {
            long count = Queue<long, SimpleRecord<long>, TStringConvert>(
                "d_taiwan",
                 $"SELECT COUNT(UID) FROM accounts WHERE accountname = \"{DbStringConvert<TStringConvert>.Instance.ToDbString(userName)}\";")
                .FirstOrDefault();
            if (count != 0)
                throw new InvalidOperationException("此用户名已被注册。");
            string trans = "USE d_taiwan;START TRANSACTION;INSERT INTO accounts (accountname,password) VALUES('" +
                       userName +
                       "','123456');INSERT INTO member_info (user_id) VALUES (LAST_INSERT_ID());SET @mid=LAST_INSERT_ID();INSERT INTO member_white_account (m_id) VALUES (@mid);USE taiwan_login;INSERT INTO member_login (m_id) VALUES (@mid);COMMIT;";
            NoneQueue(null, trans);
        }

        public GameUserInfo GetUserInfo<TStringConvert>(string userName)
            where TStringConvert : DbStringConvert<TStringConvert>, new()
        {
            int uid = Queue<int, SimpleRecord<int>, TStringConvert>(
                "d_taiwan",
                $"SELECT UID FROM accounts WHERE accountname = \"{DbStringConvert<TStringConvert>.Instance.ToDbString(userName)}\";")
                .FirstOrDefault();

            if (uid == 0)
                return null;

            IEnumerable<GameCharacter> characters = GetCharactersByUID<TStringConvert>(uid);
            return new GameUserInfo(uid, userName, characters.ToArray());
        }

        public GameUserInfo GetUserInfo<TStringConvert>(int userId)
            where TStringConvert : DbStringConvert<TStringConvert>, new()
        {
            string userName = Queue<string, SimpleRecord<string>, TStringConvert>(
                "d_taiwan",
                $"SELECT accountname FROM accounts WHERE UID = \"{userId}\";")
                .FirstOrDefault();

            if (userName == null)
                return null;

            IEnumerable<GameCharacter> characters = GetCharactersByUID<TStringConvert>(userId);
            return new GameUserInfo(userId, userName, characters.ToArray());
        }



        public CurrentQuest[] GetQuest(int characterId, Dictionary<int, QuestCache> questCache)
        {
            IDataRecord quest = QueueCore(
                 "taiwan_cain",
                 $"SELECT play_1,play_1_trigger,play_2,play_2_trigger,play_3,play_3_trigger,play_4,play_4_trigger,play_5,play_5_trigger,play_6,play_6_trigger,play_7,play_7_trigger,play_8,play_8_trigger,play_9,play_9_trigger,play_10,play_10_trigger,play_11,play_11_trigger,play_12,play_12_trigger,play_13,play_13_trigger,play_14,play_14_trigger,play_15,play_15_trigger,play_16,play_16_trigger,play_17,play_17_trigger,play_18,play_18_trigger,play_19,play_19_trigger,play_20,play_20_trigger FROM new_charac_quest WHERE charac_no = {characterId};"
                 ).FirstOrDefault();
            if (quest == null)
                return null;
            var l = new List<CurrentQuest>(20);
            for (int i = 0; i < 20; i++)
            {
                int id = (ushort)quest.GetValue(i << 1);
                if (id != 0 && (uint)quest.GetValue((i << 1) + 1) != 0)
                {
                    l.Add(new CurrentQuest(i + 1, id, questCache));
                }
            }
            return l.ToArray();
        }

        public void ClearQuest<TStringConvert>(int characterId, params CurrentQuest[] quest)
            where TStringConvert : DbStringConvert<TStringConvert>, new()
        {
            IEnumerable<CurrentQuest> itemQuest = quest.Where(q => q.Info != null && q.Info.Items != null);
            ClearQuestCore(characterId, quest);
            if (itemQuest == null)
                return;
            GameItem[] items = itemQuest
                .SelectMany(i => i.Info.Items)
                .GroupBy(i => i.Id)
                .Select(g => new GameItem(g.Key, (uint)g.Sum(i => i.Count))).ToArray();
            SendLetter<TStringConvert>(characterId, "DFToys", "Quest Items", items);
        }

        public void SendLetter<TStringConvert, TJobTable, TEquipmentTable>(int characterId, string senderName, string mailMessage, EquipmentCache<TJobTable, TEquipmentTable> eq,
            int amplify_option, int amplify, int seperate, int upgrade)
            where TJobTable : GameJobTable, new()
            where TEquipmentTable : GameEquipmentTable, new()
        {
            StringBuilder sb0 = StringBuilderPool.Shared.Get();
            StringBuilder sb1 = StringBuilderPool.Shared.Get();
            StringBuilder sb2 = StringBuilderPool.Shared.Get();
            sb0.Append("START TRANSACTION;SET @mtime=NOW();");

            sb1.Append("INSERT INTO letter (charac_no,send_charac_name,letter_text,reg_date,stat) VALUES (")
                    .Append(characterId)
                    .Append(",\"")
                    .Append(senderName)
                    .Append("\",\"")
                    .Append(mailMessage)
                    .Append("\",@mtime,1);SET @letterID = LAST_INSERT_ID();INSERT INTO postal (occ_time,send_charac_name,receive_charac_no,item_id,letter_id");

            sb2.Append(") VALUES ")
                  .Append("(@mtime,\"DfToys\",")
                  .Append(characterId)
                  .Append(',')
                  .Append(eq.Id)
                  .Append(",@letterID");

            if (eq.IsSealing)
            {
                sb1.Append(",seal_flag");
                sb2.Append(",1");
            }

            string sql;

            if (eq.MainType == EquipmentCache<GameJobTable, GameEquipmentTable>.EquipmentTable.WeaponFriendlyName ||
                eq.MainType == EquipmentCache<GameJobTable, GameEquipmentTable>.EquipmentTable.ArmorFriendlyName ||
                eq.MainType == EquipmentCache<GameJobTable, GameEquipmentTable>.EquipmentTable.JewelryFriendlyName)
            {
                sb1.Append(",add_info");
                sb2.Append(",105");
                if (eq.Durability != null)
                {
                    sb1.Append(",endurance");
                    sb2.Append(',')
                       .Append(eq.Durability.Value);
                }
                if (amplify_option != 0 && amplify != 0)
                {
                    sb1.Append(",amplify_option,amplify_value");
                    sb2.Append(',')
                       .Append(amplify_option)
                       .Append(',')
                       .Append(amplify);
                }
                if (seperate != 0)
                {
                    sb1.Append(",seperate_upgrade");
                    sb2.Append(',')
                       .Append(seperate);
                }
                if (upgrade != 0)
                {
                    sb1.Append(",upgrade");
                    sb2.Append(',')
                       .Append(upgrade);
                }
                sb2.Append(");COMMIT;");
            }
            else if (eq.MainType == EquipmentCache<GameJobTable, GameEquipmentTable>.EquipmentTable.AvatarFriendlyName)
            {
                sb0.Append("INSERT INTO user_items (charac_no,it_id,expire_date,obtain_from,reg_date,stat) VALUES (")
                      .Append(characterId)
                      .Append(',')
                      .Append(eq.Id)
                      .Append(",'9999-12-31 23:59:59',1,@mtime,2);SET @lastAvatar = LAST_INSERT_ID();");

                sb1.Append(",add_info,avata_flag");
                sb2.Append(",@lastAvatar,1);COMMIT;");
            }
            else if (EquipmentCache<GameJobTable, GameEquipmentTable>.EquipmentTable.IsForPets(eq.SubType1))
            {
                // todo impl
                sb1.Append(",add_info,creature_flag");
                sb2.Append(",67452247,1);COMMIT;");
            }
            else if (eq.SubType1 == EquipmentCache<GameJobTable, GameEquipmentTable>.EquipmentTable.PetCreatureFriendlyName)
            {
                sb0
                    .Append("INSERT INTO creature_items (charac_no,it_id,expire_date,reg_date,stat,creature_type) VALUES (")
                    .Append(characterId)
                    .Append(',')
                    .Append(eq.Id)
                    .Append(',')
                    .Append("'9999-12-31 23:59:59'")
                    .Append(',')
                    .Append("@mtime,")
                    .Append(
                    eq.SubType2 == EquipmentCache<GameJobTable, GameEquipmentTable>.EquipmentTable.PetEggFriendlyName ?
                        "0,0);SET @lastPet=LAST_INSERT_ID();" :
                        "1,1);SET @lastPet=LAST_INSERT_ID();");
                sb1.Append(",add_info,creature_flag");
                sb2.Append(",@lastPet,1);COMMIT;");

            }
            else
            {
                sb2.Append(");COMMIT;");
            }
            sql = sb0.ToString() + sb1.ToString() + sb2.ToString();
            StringBuilderPool.Shared.Return(sb0);
            StringBuilderPool.Shared.Return(sb1);
            StringBuilderPool.Shared.Return(sb2);
            NoneQueue("taiwan_cain_2nd", sql);

        }

        public void ClearMail(int characterId)
        {
            NoneQueue("taiwan_cain_2nd", $"UPDATE postal SET delete_flag = 1 WHERE receive_charac_no = {characterId};");
        }

        public void SendLetter<TStringConvert>(int characterId, string senderName, string mailMessage, params GameItem[] items)
             where TStringConvert : DbStringConvert<TStringConvert>, new()
        {
            if (items == null || items.Length == 0)
                return;
            int len = items.Length;
            var sb = StringBuilderPool.Shared.Get();
            sb.Append("START TRANSACTION;SET @mtime=NOW();");
            GameItem itm;
            for (int i = 0; i < len; i++)
            {
                if (i % 10 == 0)
                {
                    sb[sb.Length - 1] = ';';
                    sb.Append("INSERT INTO letter (charac_no,send_charac_name,letter_text,reg_date,stat) VALUES(")
                     .Append(characterId)
                     .Append(",\"")
                     .Append(senderName)
                     .Append("\",\"")
                     .Append(mailMessage)
                     .Append("\",@mtime,1);SET @letterID = LAST_INSERT_ID();INSERT INTO postal (occ_time,send_charac_name,receive_charac_no,item_id,add_info,letter_id) VALUES ");
                }
                itm = items[i];
                sb.Append("(@mtime,\"DfToys\",")
                  .Append(characterId)
                  .Append(',')
                  .Append(itm.Id)
                  .Append(',')
                  .Append(itm.Count)
                  .Append(",@letterID),");
            }
            sb[sb.Length - 1] = ';';
            sb.Append("COMMIT;");
            NoneQueue("taiwan_cain_2nd", StringBuilderPool.Shared.ReturnAndGetString(sb));
        }

        private void ClearQuestCore(int characterId, params CurrentQuest[] quests)
        {
            if (quests == null || quests.Length == 0)
                return;
            var sb = StringBuilderPool.Shared.Get();
            sb.Append("UPDATE new_charac_quest SET ");
            for (int i = 0; i < quests.Length; i++)
            {
                sb.Append("play_")
                  .Append(quests[i].Index)
                  .Append("_trigger = 0,");
            }
            sb[sb.Length - 1] = ' ';
            sb.Append("WHERE charac_no = ")
              .Append(characterId)
              .Append(';');
            NoneQueue("taiwan_cain", StringBuilderPool.Shared.ReturnAndGetString(sb));
        }


        private IEnumerable<GameCharacter> GetCharactersByUID<TStringConvert>(int userId)
            where TStringConvert : DbStringConvert<TStringConvert>, new()
        {
            return Queue<GameCharacter, GameCharacter, TStringConvert>(
                "taiwan_cain",
                $"SELECT charac_no, charac_name FROM charac_info WHERE m_id = {userId} AND delete_flag = 0;"
                );
        }



    }
}
