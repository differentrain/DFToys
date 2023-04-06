using DFToys.DbConnection;
using DFToys.GameStartup;
using DFToys.Models;
using DFToys.PvfCache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFToys
{
    public partial class FormMain : Form
    {
        private readonly FormPvf _pvfLoadDialog = new FormPvf();

        private readonly GameLauncher _launcher = new GameLauncher();

        private DefaultGameDbVisitor _db = null;



        public FormMain()
        {
            InitializeComponent();
            _pvfLoadDialog.Owner = this;
            TextBoxIp.Text = MyConfig.Shared.Ip;
            TextBoxPort.Text = MyConfig.Shared.Port.ToString();
            TextBoxDbId.Text = MyConfig.Shared.DbId;
            TextBoxPwd.Text = MyConfig.Shared.Pwd;
            CheckBoxTopMost.Checked = this.TopMost = MyConfig.Shared.TopMost;
            TextBoxQuestCount.Text = MyConfig.Shared.QuestCache == null ?
                string.Empty : $"共 {MyConfig.Shared.QuestCache.Count} 项任务";
            TextBoxUserId.Text = MyConfig.Shared.Uid;

        }

        private void ButtonSaveRsaKey_Click(object sender, EventArgs e)
        {
            if (SaveFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GameLauncher.ExportDefaultPublicKey(SaveFileDialogMain.FileName);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "ecx");
                }
            }
        }

        private void CheckBoxTopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = MyConfig.Shared.TopMost = CheckBoxTopMost.Checked;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _db?.Dispose();
            MyConfig.Shared.Save();
        }

        private void ButtonPvf_Click(object sender, EventArgs e)
        {
            if (_pvfLoadDialog.ShowDialog() == DialogResult.OK)
            {
                MyConfig.Shared.QuestCache = _pvfLoadDialog.QuestCache;
                TextBoxQuestCount.Text = $"共 {MyConfig.Shared.QuestCache.Count} 项任务";
            }
        }

        private void TextBoxOfDbChanged(object sender, EventArgs e)
        {
            ButtonDB.Enabled =
                IPAddress.TryParse(TextBoxIp.Text, out _) &&
                ushort.TryParse(TextBoxPort.Text, out _) &&
                !string.IsNullOrWhiteSpace(TextBoxDbId.Text) &&
                !string.IsNullOrWhiteSpace(TextBoxPwd.Text);

        }

        private void ButtonDB_Click(object sender, EventArgs e)
        {
            if (_db == null)
            {
                try
                {
                    _db = new DefaultGameDbVisitor(
                      TextBoxIp.Text,
                      ushort.Parse(TextBoxPort.Text),
                      TextBoxDbId.Text,
                      TextBoxPwd.Text);
                    TextBoxIp.Enabled = TextBoxPort.Enabled = TextBoxDbId.Enabled = TextBoxPwd.Enabled = false;
                    GroupBoxID.Enabled = true;
                    ButtonDB.Text = "断开";
                    MyConfig.Shared.Ip = TextBoxIp.Text;
                    MyConfig.Shared.Port = ushort.Parse(TextBoxPort.Text);
                    MyConfig.Shared.DbId = TextBoxDbId.Text;
                    MyConfig.Shared.Pwd = TextBoxPwd.Text;
                }
                catch (Exception ecx)
                {
                    MessageBox.Show(ecx.Message, "连接失败");
                    _db?.Dispose();
                    _db = null;
                }
            }
            else
            {
                _db.Dispose();
                _db = null;
                TextBoxIp.Enabled = TextBoxPort.Enabled = TextBoxDbId.Enabled = TextBoxPwd.Enabled = true;
                GroupBoxID.Enabled = false;
                ButtonDB.Text = "连接";
                ListBoxCharac.SelectedIndex = -1;
                ListBoxCharac.Items.Clear();
                ListBoxQuest.SelectedItems.Clear();
                ListBoxQuest.Items.Clear();

            }
        }

        private void TextBoxUserId_TextChanged(object sender, EventArgs e)
        {
            ButtonRun.Enabled = ButtonReg.Enabled = ButtonGetCharac.Enabled = !string.IsNullOrWhiteSpace(TextBoxUserId.Text);
        }

        private void ButtonGetCharac_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _db.GetUserInfo(TextBoxUserId.Text);
                if (user == null) {
                    MessageBox.Show("帐号尚未注册。", "错误");
                    return;
                }
                ListBoxCharac.SelectedIndex = -1;
                ListBoxCharac.Items.Clear();
                ListBoxCharac.Items.AddRange(user.Characters);
                ListBoxQuest.SelectedItems.Clear();
                ListBoxQuest.Items.Clear();
                MyConfig.Shared.Uid = TextBoxUserId.Text;
            }
            catch (Exception ecx)
            {
                MessageBox.Show(ecx.Message, "错误");
            }

        }

        private void ButtonReg_Click(object sender, EventArgs e)
        {
            try
            {
                _db.Register(TextBoxUserId.Text);
                MyConfig.Shared.Uid = TextBoxUserId.Text;
                MessageBox.Show( "帐号注册成功。");
            }
            catch (Exception ecx)
            {
                MessageBox.Show(ecx.Message, "注册失败");
            }
        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            try
            {
                var user = _db.GetUserInfo(TextBoxUserId.Text);
                if (user == null)
                {
                    MessageBox.Show("帐号尚未注册。", "错误");
                    return;
                }
                _launcher.Run(MyConfig.Shared.DfPath, user.Id);
                MyConfig.Shared.Uid = TextBoxUserId.Text;
            }
            catch (Exception ecx)
            {
                MessageBox.Show(ecx.Message, "运行失败");
            }
        }

        private void ListBoxCharac_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelQuest.Enabled = ListBoxCharac.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(TextBoxQuestCount.Text);
            ListBoxQuest.SelectedItems.Clear();
            ListBoxQuest.Items.Clear();

        }

        private void TextBoxQuestCount_TextChanged(object sender, EventArgs e)
        {
            PanelQuest.Enabled = ListBoxCharac.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(TextBoxQuestCount.Text);
        }


        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            ListBoxQuest.SelectedItems.Clear();
            ListBoxQuest.Items.Clear();

            var gameCharacter = ListBoxCharac.SelectedItem as GameCharacter;
            try
            {
                var quests = _db.GetQuest(gameCharacter.Id, MyConfig.Shared.QuestCache);
                ListBoxQuest.Items.AddRange(quests);
                ButtonClearAll.Enabled = ListBoxQuest.Items.Count > 0;
            }
            catch (Exception ecx)
            {
                MessageBox.Show(ecx.Message, "查询失败");
            }


        }

        private void ListBoxQuest_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonClearQuest.Enabled = ListBoxQuest.SelectedItems.Count > 0;
        }

        private void ButtonClearQuest_Click(object sender, EventArgs e)
        {
            var x = ListBoxQuest.SelectedItems.Cast<CurrentQuest>().ToArray();
            var gameCharacter = ListBoxCharac.SelectedItem as GameCharacter;

            try
            {
                _db.ClearQuest(gameCharacter.Id, x.ToArray());
                for (int i = 0; i < x.Length; i++)
                {
                    ListBoxQuest.SelectedItems.Remove(x[i]);
                    ListBoxQuest.Items.Remove(x[i]);
                }
            }
            catch (Exception ecx)
            {
                MessageBox.Show(ecx.Message, "失败。");

            }
        }

        private void ButtonClearAll_Click(object sender, EventArgs e)
        {
            var x = ListBoxQuest.Items.Cast<CurrentQuest>().ToArray();
            var gameCharacter = ListBoxCharac.SelectedItem as GameCharacter;
            try
            {
                _db.ClearQuest(gameCharacter.Id, x.ToArray());
                ListBoxQuest.SelectedItems.Clear();
                ListBoxQuest.Items.Clear();

            }
            catch (Exception ecx)
            {
                MessageBox.Show(ecx.Message, "失败。");

            }
        }

        private void ButtonForceQuest_Click(object sender, EventArgs e)
        {
            ListBoxQuest.SelectedItems.Clear();
            ListBoxQuest.Items.Clear();

            var gameCharacter = ListBoxCharac.SelectedItem as GameCharacter;

            try
            {
                var quests = _db.GetQuest(gameCharacter.Id, MyConfig.Shared.QuestCache);
                _db.ClearQuest(gameCharacter.Id, quests);
            }
            catch (Exception ecx)
            {
                MessageBox.Show(ecx.Message, "操作失败");
            }
        }
    }
}
