using DFToys.DbConnection.Internals;
using DFToys.Models;
using DFToys.PvfCache;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DFToys.DbConnection
{
    public sealed class DefaultGameDbVisitor : GameDbVisitor<DefaultGameDbVisitor>
    {

        public DefaultGameDbVisitor(string ip, int port, string user, string password) : base(ip, port, user, password)
        {
        }

        public void Register(string userName)
        {
            var count = Queue<long, SimpleRecord<long>>(
                "d_taiwan",
                 $"SELECT COUNT(UID) FROM accounts WHERE accountname = \"{userName}\";")
                .FirstOrDefault();
            if (count != 0)
                throw new InvalidOperationException("此用户名已被注册。");
            var trans = "USE d_taiwan;START TRANSACTION;INSERT INTO accounts (accountname,password,VIP) VALUES('" +
                       userName +
                       "','123456','1');INSERT INTO member_info (user_id) VALUES (LAST_INSERT_ID());SET @mid=LAST_INSERT_ID();INSERT INTO member_white_account (m_id) VALUES (@mid);USE taiwan_login;INSERT INTO member_login (m_id) VALUES (@mid);COMMIT;";
            NoneQueue(null, trans);
        }

        public GameUserInfo GetUserInfo(string userName)
        {
            int uid = Queue<int, SimpleRecord<int>>(
                "d_taiwan",
                $"SELECT UID FROM accounts WHERE accountname = \"{userName}\";")
                .FirstOrDefault();

            if (uid == 0)
                return null;

            IEnumerable<GameCharacter> characters = GetCharactersByUID(uid);
            return new GameUserInfo(uid, userName, characters.ToArray());
        }

        public GameUserInfo GetUserInfo(int userId)
        {
            string userName = Queue<string, SimpleRecord<string>>(
                "d_taiwan",
                $"SELECT accountname FROM accounts WHERE UID = \"{userId}\";")
                .FirstOrDefault();

            if (userName == null)
                return null;

            IEnumerable<GameCharacter> characters = GetCharactersByUID(userId);
            return new GameUserInfo(userId, userName, characters.ToArray());
        }

        public GameUserInfo GetUserInfoByCharacter(string characterName)
        {
            int uid = Queue<int, SimpleRecord<int>>(
               "taiwan_cain",
                $"SELECT m_id FROM charac_info WHERE charac_name = \"{characterName}\" AND delete_flag = 0;"
                )
                .FirstOrDefault();

            if (uid == 0)
                return null;

            return GetUserInfo(uid);
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

        public void ClearQuest(int characterId, params CurrentQuest[] quest)
        {
            IEnumerable<CurrentQuest> itemQuest = quest.Where(q => q.Info != null && q.Info.Items != null);
            ClearQuestCore(characterId, quest);
            if (itemQuest == null)
                return;
            GameItem[] items = itemQuest
                .SelectMany(i => i.Info.Items)
                .GroupBy(i => i.Id)
                .Select(g => new GameItem(g.Key, (uint)g.Sum(i => i.Count))).ToArray();
            SendLetter(characterId, items);
        }

        public void SendLetter(int characterId, params GameItem[] items)
        {
            if (items == null || items.Length == 0)
                return;

            int len = items.Length;
            var sb = new StringBuilder(2048);
            sb.Append("START TRANSACTION;SET @mtime=NOW();");
            GameItem itm;
            for (int i = 0; i < len; i++)
            {
                if (i % 10 == 0)
                {
                    sb[sb.Length - 1] = ';';
                    sb.Append("INSERT INTO letter (charac_no,send_charac_name,letter_text,reg_date,stat) VALUES(")
                     .Append(characterId)
                     .Append(",\"DfQ\",\"Quest Items\",@mtime,1);SET @letterID = LAST_INSERT_ID();INSERT INTO postal (occ_time,send_charac_name,receive_charac_no,item_id,add_info,letter_id) VALUES ");
                }
                itm = items[i];
                sb.Append("(@mtime,\"DfQ\",")
                  .Append(characterId)
                  .Append(',')
                  .Append(itm.Id)
                  .Append(',')
                  .Append(itm.Count)
                  .Append(",@letterID),");
            }
            sb[sb.Length - 1] = ';';
            sb.Append("COMMIT;");

            NoneQueue("taiwan_cain_2nd", sb.ToString());
        }

        private void ClearQuestCore(int characterId, params CurrentQuest[] quests)
        {
            if (quests == null || quests.Length == 0)
                return;
            var sb = new StringBuilder(2048);
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
            NoneQueue("taiwan_cain", sb.ToString());
        }


        private IEnumerable<GameCharacter> GetCharactersByUID(int userId)
        {
            return Queue<GameCharacter, GameCharacter>(
                "taiwan_cain",
                $"SELECT charac_no, charac_name FROM charac_info WHERE m_id = {userId} AND delete_flag = 0;"
                );
        }



    }
}
