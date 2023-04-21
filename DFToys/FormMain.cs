using DFToys.Common;
using DFToys.DbConnection;
using DFToys.GameStartup;
using DFToys.Models;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace DFToys
{
    public partial class FormMain : Form
    {
        private readonly FormPvf _pvfLoadDialog = new FormPvf();
        private readonly FormPatch _gamePatchDialog = new FormPatch();
        private readonly FormItems _itemMainWindow = new FormItems();
        private readonly FormEquipments _equipmentsMainWindow = new FormEquipments();

        private readonly GameLauncher _launcher = new GameLauncher();

        public static DefaultGameDbVisitor GameDb = null;

        public static int UId;

        public static GameCharacter GameCharac;


        public FormMain()
        {
            InitializeComponent();
            _pvfLoadDialog.Owner = this;
            TextBoxIp.Text = MyConfig.Shared.Ip;
            TextBoxPort.Text = MyConfig.Shared.Port.ToString();
            TextBoxDbId.Text = MyConfig.Shared.DbId;
            TextBoxPwd.Text = MyConfig.Shared.Pwd;
            CheckBoxTopMost.Checked = this.TopMost = MyConfig.Shared.TopMost;
            if (MyCache.Shared.QuestCache == null)
            {
                TextBoxQuestCount.Text = string.Empty;
            }
            else
            {
                TextBoxQuestCount.Text = $"任务:{MyCache.Shared.QuestCache.Count};物品:{MyCache.Shared.ItemCache.Count};装备:{MyCache.Shared.EquipmentCache.Count}";
                _itemMainWindow.UpdateByCache();
                _equipmentsMainWindow.UpdateByCache();  
            }

 
            TextBoxUserName.Text = MyConfig.Shared.UName;

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
            GameDb?.Dispose();
            MyConfig.Shared.Save();
            MyCache.Shared.Save();
        }

        private void ButtonPvf_Click(object sender, EventArgs e)
        {
            if (_itemMainWindow.Visible)
                _itemMainWindow.Hide();
            if (_equipmentsMainWindow.Visible)
                _equipmentsMainWindow.Hide();
            if (_pvfLoadDialog.ShowDialog() == DialogResult.OK)
            {
                MyCache.Shared.QuestCache = _pvfLoadDialog.QuestCache;
                MyCache.Shared.ItemCache = _pvfLoadDialog.ItemCache;
                MyCache.Shared.EquipmentCache = _pvfLoadDialog.EquipmentCache;
                MyCache.Shared.EquipmentIndexCache = _pvfLoadDialog.EquipmentIndexCache;
                MyCache.Shared.ItemIndexCache = _pvfLoadDialog.ItemIndexCache;
                TextBoxQuestCount.Text = $"任务:{MyCache.Shared.QuestCache.Count};物品:{MyCache.Shared.ItemCache.Count};装备:{MyCache.Shared.EquipmentCache.Count}";
                _itemMainWindow.UpdateByCache();
                _equipmentsMainWindow.UpdateByCache();
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
            if (GameDb == null)
            {
                try
                {
                    GameDb = new DefaultGameDbVisitor(
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
                    GameDb?.Dispose();
                    GameDb = null;
                }
            }
            else
            {
                GameDb.Dispose();
                GameDb = null;
                TextBoxIp.Enabled = TextBoxPort.Enabled = TextBoxDbId.Enabled = TextBoxPwd.Enabled = true;
                GroupBoxID.Enabled = false;
                ButtonDB.Text = "连接";
                ListBoxCharac.SelectedIndex = -1;
                ListBoxCharac.Items.Clear();
                ListBoxQuest.SelectedItems.Clear();
                ListBoxQuest.Items.Clear();
                if (_itemMainWindow.Visible)
                    _itemMainWindow.Hide();
                if (_equipmentsMainWindow.Visible)
                    _equipmentsMainWindow.Hide();



            }
        }

        private void TextBoxUserId_TextChanged(object sender, EventArgs e)
        {
            ButtonRun.Enabled = ButtonReg.Enabled = ButtonGetCharac.Enabled = !string.IsNullOrWhiteSpace(TextBoxUserName.Text);
        }



        private void ButtonGetCharac_Click(object sender, EventArgs e)
        {
            try
            {
                if (_itemMainWindow.Visible)
                    _itemMainWindow.Hide();
                if (_equipmentsMainWindow.Visible)
                    _equipmentsMainWindow.Hide();
                var user = GameDb.GetUserInfo<DefaultDbStringConvert>(TextBoxUserName.Text);
                if (user == null)
                {
                    MessageBox.Show("帐号尚未注册。", "错误");
                    return;
                }
                ListBoxCharac.SelectedIndex = -1;
                ListBoxCharac.Items.Clear();
                ListBoxCharac.Items.AddRange(user.Characters);
                ListBoxQuest.SelectedItems.Clear();
                ListBoxQuest.Items.Clear();
                MyConfig.Shared.UName = TextBoxUserName.Text;
                UId = user.Id;
            }
            catch (Exception ecx)
            {
                MessageBox.Show(ecx.Message, "错误");
                UId = -1;
            }

        }

        private void ButtonReg_Click(object sender, EventArgs e)
        {
            try
            {
                GameDb.Register<DefaultDbStringConvert>(TextBoxUserName.Text);
                MyConfig.Shared.UName = TextBoxUserName.Text;
                MessageBox.Show("帐号注册成功。");
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
                var user = GameDb.GetUserInfo<DefaultDbStringConvert>(TextBoxUserName.Text);
                if (user == null)
                {
                    MessageBox.Show("帐号尚未注册。", "错误");
                    return;
                }
                _launcher.Run(MyConfig.Shared.DfPath, user.Id);
                MyConfig.Shared.UName = TextBoxUserName.Text;
            }
            catch (Exception ecx)
            {
                MessageBox.Show(ecx.Message, "运行失败");
            }
        }

        private void ListBoxCharac_SelectedIndexChanged(object sender, EventArgs e)
        {
             GroupBoxMail.Enabled = PanelQuest.Enabled = ListBoxCharac.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(TextBoxQuestCount.Text);
            GameCharac = ListBoxCharac.SelectedItem as GameCharacter;
            ListBoxQuest.SelectedItems.Clear();
            ListBoxQuest.Items.Clear();

        }

        private void TextBoxQuestCount_TextChanged(object sender, EventArgs e)
        {
            GroupBoxMail.Enabled = PanelQuest.Enabled = ListBoxCharac.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(TextBoxQuestCount.Text);
        }


        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            ListBoxQuest.SelectedItems.Clear();
            ListBoxQuest.Items.Clear();
 
            try
            {
                var quests = GameDb.GetQuest(GameCharac.Id, MyCache.Shared.QuestCache);
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
 

            try
            {
                GameDb.ClearQuest<DefaultDbStringConvert>(GameCharac.Id, x.ToArray());
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
 
            try
            {
                GameDb.ClearQuest<DefaultDbStringConvert>(GameCharac.Id, x.ToArray());
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
 
            try
            {
                var quests = GameDb.GetQuest(GameCharac.Id, MyCache.Shared.QuestCache);
                GameDb.ClearQuest<DefaultDbStringConvert>(GameCharac.Id, quests);
            }
            catch (Exception ecx)
            {
                MessageBox.Show(ecx.Message, "操作失败");
            }
        }

        private void ButtonPatch_Click(object sender, EventArgs e)
        {
            _gamePatchDialog.ShowDialog(this);
        }

        private void ButtonItemMain_Click(object sender, EventArgs e)
        {
            if (!_itemMainWindow.Visible)
            {
                _itemMainWindow.Show(this);
            }
        }

        private void ButtonEquipments_Click(object sender, EventArgs e)
        {
            if (!_equipmentsMainWindow.Visible)
            {
                _equipmentsMainWindow.Show(this);
            }
        }

        private void ButtonClearMail_Click(object sender, EventArgs e)
        {
            try
            {
                GameDb.ClearMail(GameCharac.Id);
            }
            catch (Exception ecx)
            {
                MessageBox.Show(ecx.Message, "操作失败");
            }
        }
    }
}
