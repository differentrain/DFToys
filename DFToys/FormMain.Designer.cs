namespace DFToys
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ButtonPatch = new System.Windows.Forms.Button();
            this.ButtonSaveRsaKey = new System.Windows.Forms.Button();
            this.GroupBoxID = new System.Windows.Forms.GroupBox();
            this.ButtonReg = new System.Windows.Forms.Button();
            this.ButtonGetCharac = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ListBoxCharac = new System.Windows.Forms.ListBox();
            this.ButtonRun = new System.Windows.Forms.Button();
            this.TextBoxUserName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TextBoxQuestCount = new System.Windows.Forms.TextBox();
            this.ButtonPvf = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonDB = new System.Windows.Forms.Button();
            this.TextBoxPwd = new System.Windows.Forms.TextBox();
            this.TextBoxIp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxDbId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxPort = new System.Windows.Forms.TextBox();
            this.CheckBoxTopMost = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PanelQuest = new System.Windows.Forms.Panel();
            this.ButtonForceQuest = new System.Windows.Forms.Button();
            this.ButtonClearAll = new System.Windows.Forms.Button();
            this.ButtonClearQuest = new System.Windows.Forms.Button();
            this.ListBoxQuest = new System.Windows.Forms.ListBox();
            this.ButtonRefresh = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.GroupBoxMail = new System.Windows.Forms.GroupBox();
            this.ButtonClearMail = new System.Windows.Forms.Button();
            this.ButtonItemMain = new System.Windows.Forms.Button();
            this.ButtonEquipments = new System.Windows.Forms.Button();
            this.SaveFileDialogMain = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.GroupBoxID.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.PanelQuest.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.GroupBoxMail.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(255, 375);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ButtonPatch);
            this.tabPage1.Controls.Add(this.ButtonSaveRsaKey);
            this.tabPage1.Controls.Add(this.GroupBoxID);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.CheckBoxTopMost);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(247, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ButtonPatch
            // 
            this.ButtonPatch.Location = new System.Drawing.Point(82, 317);
            this.ButtonPatch.Name = "ButtonPatch";
            this.ButtonPatch.Size = new System.Drawing.Size(57, 26);
            this.ButtonPatch.TabIndex = 12;
            this.ButtonPatch.Text = "补丁";
            this.ButtonPatch.UseVisualStyleBackColor = true;
            this.ButtonPatch.Click += new System.EventHandler(this.ButtonPatch_Click);
            // 
            // ButtonSaveRsaKey
            // 
            this.ButtonSaveRsaKey.Location = new System.Drawing.Point(6, 317);
            this.ButtonSaveRsaKey.Name = "ButtonSaveRsaKey";
            this.ButtonSaveRsaKey.Size = new System.Drawing.Size(69, 26);
            this.ButtonSaveRsaKey.TabIndex = 11;
            this.ButtonSaveRsaKey.Text = "保存公钥";
            this.ButtonSaveRsaKey.UseVisualStyleBackColor = true;
            this.ButtonSaveRsaKey.Click += new System.EventHandler(this.ButtonSaveRsaKey_Click);
            // 
            // GroupBoxID
            // 
            this.GroupBoxID.Controls.Add(this.ButtonReg);
            this.GroupBoxID.Controls.Add(this.ButtonGetCharac);
            this.GroupBoxID.Controls.Add(this.label6);
            this.GroupBoxID.Controls.Add(this.label5);
            this.GroupBoxID.Controls.Add(this.ListBoxCharac);
            this.GroupBoxID.Controls.Add(this.ButtonRun);
            this.GroupBoxID.Controls.Add(this.TextBoxUserName);
            this.GroupBoxID.Enabled = false;
            this.GroupBoxID.Location = new System.Drawing.Point(6, 174);
            this.GroupBoxID.Name = "GroupBoxID";
            this.GroupBoxID.Size = new System.Drawing.Size(231, 137);
            this.GroupBoxID.TabIndex = 10;
            this.GroupBoxID.TabStop = false;
            this.GroupBoxID.Text = "账号相关";
            // 
            // ButtonReg
            // 
            this.ButtonReg.Enabled = false;
            this.ButtonReg.Location = new System.Drawing.Point(165, 57);
            this.ButtonReg.Name = "ButtonReg";
            this.ButtonReg.Size = new System.Drawing.Size(61, 26);
            this.ButtonReg.TabIndex = 12;
            this.ButtonReg.Text = "注册账号";
            this.ButtonReg.UseVisualStyleBackColor = true;
            this.ButtonReg.Click += new System.EventHandler(this.ButtonReg_Click);
            // 
            // ButtonGetCharac
            // 
            this.ButtonGetCharac.Enabled = false;
            this.ButtonGetCharac.Location = new System.Drawing.Point(165, 98);
            this.ButtonGetCharac.Name = "ButtonGetCharac";
            this.ButtonGetCharac.Size = new System.Drawing.Size(61, 25);
            this.ButtonGetCharac.TabIndex = 13;
            this.ButtonGetCharac.Text = "加载角色";
            this.ButtonGetCharac.UseVisualStyleBackColor = true;
            this.ButtonGetCharac.Click += new System.EventHandler(this.ButtonGetCharac_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "角色";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "账号";
            // 
            // ListBoxCharac
            // 
            this.ListBoxCharac.FormattingEnabled = true;
            this.ListBoxCharac.ItemHeight = 12;
            this.ListBoxCharac.Location = new System.Drawing.Point(40, 47);
            this.ListBoxCharac.Name = "ListBoxCharac";
            this.ListBoxCharac.Size = new System.Drawing.Size(118, 76);
            this.ListBoxCharac.TabIndex = 10;
            this.ListBoxCharac.SelectedIndexChanged += new System.EventHandler(this.ListBoxCharac_SelectedIndexChanged);
            // 
            // ButtonRun
            // 
            this.ButtonRun.Enabled = false;
            this.ButtonRun.Location = new System.Drawing.Point(165, 17);
            this.ButtonRun.Name = "ButtonRun";
            this.ButtonRun.Size = new System.Drawing.Size(61, 25);
            this.ButtonRun.TabIndex = 9;
            this.ButtonRun.Text = "运行游戏";
            this.ButtonRun.UseVisualStyleBackColor = true;
            this.ButtonRun.Click += new System.EventHandler(this.ButtonRun_Click);
            // 
            // TextBoxUserName
            // 
            this.TextBoxUserName.Location = new System.Drawing.Point(41, 20);
            this.TextBoxUserName.Name = "TextBoxUserName";
            this.TextBoxUserName.Size = new System.Drawing.Size(117, 21);
            this.TextBoxUserName.TabIndex = 7;
            this.TextBoxUserName.TextChanged += new System.EventHandler(this.TextBoxUserId_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TextBoxQuestCount);
            this.groupBox2.Controls.Add(this.ButtonPvf);
            this.groupBox2.Location = new System.Drawing.Point(8, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 53);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pvf数据";
            // 
            // TextBoxQuestCount
            // 
            this.TextBoxQuestCount.Location = new System.Drawing.Point(10, 18);
            this.TextBoxQuestCount.Name = "TextBoxQuestCount";
            this.TextBoxQuestCount.ReadOnly = true;
            this.TextBoxQuestCount.Size = new System.Drawing.Size(159, 21);
            this.TextBoxQuestCount.TabIndex = 2;
            this.TextBoxQuestCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxQuestCount.TextChanged += new System.EventHandler(this.TextBoxQuestCount_TextChanged);
            // 
            // ButtonPvf
            // 
            this.ButtonPvf.Location = new System.Drawing.Point(175, 14);
            this.ButtonPvf.Name = "ButtonPvf";
            this.ButtonPvf.Size = new System.Drawing.Size(49, 27);
            this.ButtonPvf.TabIndex = 1;
            this.ButtonPvf.Text = "加载";
            this.ButtonPvf.UseVisualStyleBackColor = true;
            this.ButtonPvf.Click += new System.EventHandler(this.ButtonPvf_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButtonDB);
            this.groupBox1.Controls.Add(this.TextBoxPwd);
            this.groupBox1.Controls.Add(this.TextBoxIp);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TextBoxDbId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TextBoxPort);
            this.groupBox1.Location = new System.Drawing.Point(10, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 106);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库";
            // 
            // ButtonDB
            // 
            this.ButtonDB.Location = new System.Drawing.Point(162, 74);
            this.ButtonDB.Name = "ButtonDB";
            this.ButtonDB.Size = new System.Drawing.Size(63, 26);
            this.ButtonDB.TabIndex = 9;
            this.ButtonDB.Text = "连接";
            this.ButtonDB.UseVisualStyleBackColor = true;
            this.ButtonDB.Click += new System.EventHandler(this.ButtonDB_Click);
            // 
            // TextBoxPwd
            // 
            this.TextBoxPwd.Location = new System.Drawing.Point(163, 47);
            this.TextBoxPwd.Name = "TextBoxPwd";
            this.TextBoxPwd.Size = new System.Drawing.Size(62, 21);
            this.TextBoxPwd.TabIndex = 8;
            this.TextBoxPwd.TextChanged += new System.EventHandler(this.TextBoxOfDbChanged);
            // 
            // TextBoxIp
            // 
            this.TextBoxIp.Location = new System.Drawing.Point(41, 20);
            this.TextBoxIp.Name = "TextBoxIp";
            this.TextBoxIp.Size = new System.Drawing.Size(102, 21);
            this.TextBoxIp.TabIndex = 1;
            this.TextBoxIp.TextChanged += new System.EventHandler(this.TextBoxOfDbChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "账号";
            // 
            // TextBoxDbId
            // 
            this.TextBoxDbId.Location = new System.Drawing.Point(41, 47);
            this.TextBoxDbId.Name = "TextBoxDbId";
            this.TextBoxDbId.Size = new System.Drawing.Size(81, 21);
            this.TextBoxDbId.TabIndex = 6;
            this.TextBoxDbId.TextChanged += new System.EventHandler(this.TextBoxOfDbChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口";
            // 
            // TextBoxPort
            // 
            this.TextBoxPort.Location = new System.Drawing.Point(184, 20);
            this.TextBoxPort.Name = "TextBoxPort";
            this.TextBoxPort.Size = new System.Drawing.Size(41, 21);
            this.TextBoxPort.TabIndex = 3;
            this.TextBoxPort.TextChanged += new System.EventHandler(this.TextBoxOfDbChanged);
            // 
            // CheckBoxTopMost
            // 
            this.CheckBoxTopMost.AutoSize = true;
            this.CheckBoxTopMost.Location = new System.Drawing.Point(163, 323);
            this.CheckBoxTopMost.Name = "CheckBoxTopMost";
            this.CheckBoxTopMost.Size = new System.Drawing.Size(72, 16);
            this.CheckBoxTopMost.TabIndex = 4;
            this.CheckBoxTopMost.Text = "窗口最前";
            this.CheckBoxTopMost.UseVisualStyleBackColor = true;
            this.CheckBoxTopMost.CheckedChanged += new System.EventHandler(this.CheckBoxTopMost_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PanelQuest);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(247, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "任务";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PanelQuest
            // 
            this.PanelQuest.Controls.Add(this.ButtonForceQuest);
            this.PanelQuest.Controls.Add(this.ButtonClearAll);
            this.PanelQuest.Controls.Add(this.ButtonClearQuest);
            this.PanelQuest.Controls.Add(this.ListBoxQuest);
            this.PanelQuest.Controls.Add(this.ButtonRefresh);
            this.PanelQuest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelQuest.Enabled = false;
            this.PanelQuest.Location = new System.Drawing.Point(3, 3);
            this.PanelQuest.Name = "PanelQuest";
            this.PanelQuest.Size = new System.Drawing.Size(241, 343);
            this.PanelQuest.TabIndex = 0;
            // 
            // ButtonForceQuest
            // 
            this.ButtonForceQuest.Location = new System.Drawing.Point(132, 7);
            this.ButtonForceQuest.Name = "ButtonForceQuest";
            this.ButtonForceQuest.Size = new System.Drawing.Size(102, 26);
            this.ButtonForceQuest.TabIndex = 8;
            this.ButtonForceQuest.Text = "刷新+完成任务";
            this.ButtonForceQuest.UseVisualStyleBackColor = true;
            this.ButtonForceQuest.Click += new System.EventHandler(this.ButtonForceQuest_Click);
            // 
            // ButtonClearAll
            // 
            this.ButtonClearAll.Enabled = false;
            this.ButtonClearAll.Location = new System.Drawing.Point(148, 304);
            this.ButtonClearAll.Name = "ButtonClearAll";
            this.ButtonClearAll.Size = new System.Drawing.Size(88, 31);
            this.ButtonClearAll.TabIndex = 7;
            this.ButtonClearAll.Text = "完成全部任务";
            this.ButtonClearAll.UseVisualStyleBackColor = true;
            this.ButtonClearAll.Click += new System.EventHandler(this.ButtonClearAll_Click);
            // 
            // ButtonClearQuest
            // 
            this.ButtonClearQuest.Enabled = false;
            this.ButtonClearQuest.Location = new System.Drawing.Point(5, 304);
            this.ButtonClearQuest.Name = "ButtonClearQuest";
            this.ButtonClearQuest.Size = new System.Drawing.Size(88, 31);
            this.ButtonClearQuest.TabIndex = 6;
            this.ButtonClearQuest.Text = "完成所选任务";
            this.ButtonClearQuest.UseVisualStyleBackColor = true;
            this.ButtonClearQuest.Click += new System.EventHandler(this.ButtonClearQuest_Click);
            // 
            // ListBoxQuest
            // 
            this.ListBoxQuest.FormattingEnabled = true;
            this.ListBoxQuest.ItemHeight = 12;
            this.ListBoxQuest.Location = new System.Drawing.Point(5, 39);
            this.ListBoxQuest.Name = "ListBoxQuest";
            this.ListBoxQuest.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ListBoxQuest.Size = new System.Drawing.Size(229, 256);
            this.ListBoxQuest.TabIndex = 5;
            this.ListBoxQuest.SelectedIndexChanged += new System.EventHandler(this.ListBoxQuest_SelectedIndexChanged);
            // 
            // ButtonRefresh
            // 
            this.ButtonRefresh.Location = new System.Drawing.Point(5, 5);
            this.ButtonRefresh.Name = "ButtonRefresh";
            this.ButtonRefresh.Size = new System.Drawing.Size(76, 28);
            this.ButtonRefresh.TabIndex = 4;
            this.ButtonRefresh.Text = "刷新";
            this.ButtonRefresh.UseVisualStyleBackColor = true;
            this.ButtonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.GroupBoxMail);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(247, 349);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "其他";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // GroupBoxMail
            // 
            this.GroupBoxMail.Controls.Add(this.ButtonClearMail);
            this.GroupBoxMail.Controls.Add(this.ButtonItemMain);
            this.GroupBoxMail.Controls.Add(this.ButtonEquipments);
            this.GroupBoxMail.Location = new System.Drawing.Point(8, 12);
            this.GroupBoxMail.Name = "GroupBoxMail";
            this.GroupBoxMail.Size = new System.Drawing.Size(231, 58);
            this.GroupBoxMail.TabIndex = 4;
            this.GroupBoxMail.TabStop = false;
            this.GroupBoxMail.Text = "邮件";
            // 
            // ButtonClearMail
            // 
            this.ButtonClearMail.Location = new System.Drawing.Point(162, 20);
            this.ButtonClearMail.Name = "ButtonClearMail";
            this.ButtonClearMail.Size = new System.Drawing.Size(63, 27);
            this.ButtonClearMail.TabIndex = 2;
            this.ButtonClearMail.Text = "清除附件";
            this.ButtonClearMail.UseVisualStyleBackColor = true;
            this.ButtonClearMail.Click += new System.EventHandler(this.ButtonClearMail_Click);
            // 
            // ButtonItemMain
            // 
            this.ButtonItemMain.Location = new System.Drawing.Point(6, 20);
            this.ButtonItemMain.Name = "ButtonItemMain";
            this.ButtonItemMain.Size = new System.Drawing.Size(66, 27);
            this.ButtonItemMain.TabIndex = 0;
            this.ButtonItemMain.Text = "物品邮件";
            this.ButtonItemMain.UseVisualStyleBackColor = true;
            this.ButtonItemMain.Click += new System.EventHandler(this.ButtonItemMain_Click);
            // 
            // ButtonEquipments
            // 
            this.ButtonEquipments.Location = new System.Drawing.Point(78, 20);
            this.ButtonEquipments.Name = "ButtonEquipments";
            this.ButtonEquipments.Size = new System.Drawing.Size(70, 27);
            this.ButtonEquipments.TabIndex = 1;
            this.ButtonEquipments.Text = "装备邮件";
            this.ButtonEquipments.UseVisualStyleBackColor = true;
            this.ButtonEquipments.Click += new System.EventHandler(this.ButtonEquipments_Click);
            // 
            // SaveFileDialogMain
            // 
            this.SaveFileDialogMain.FileName = "publickey.pem";
            this.SaveFileDialogMain.Filter = "密钥文件|*.pem";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 375);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DFToys";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.GroupBoxID.ResumeLayout(false);
            this.GroupBoxID.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.PanelQuest.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.GroupBoxMail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox TextBoxPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckBoxTopMost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonDB;
        private System.Windows.Forms.TextBox TextBoxPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxDbId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ButtonPvf;
        private System.Windows.Forms.GroupBox GroupBoxID;
        private System.Windows.Forms.TextBox TextBoxUserName;
        private System.Windows.Forms.Button ButtonRun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox ListBoxCharac;
        private System.Windows.Forms.Button ButtonReg;
        private System.Windows.Forms.Button ButtonGetCharac;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ButtonSaveRsaKey;
        private System.Windows.Forms.TextBox TextBoxQuestCount;
        private System.Windows.Forms.SaveFileDialog SaveFileDialogMain;
        private System.Windows.Forms.Panel PanelQuest;
        private System.Windows.Forms.Button ButtonClearAll;
        private System.Windows.Forms.Button ButtonClearQuest;
        private System.Windows.Forms.ListBox ListBoxQuest;
        private System.Windows.Forms.Button ButtonRefresh;
        private System.Windows.Forms.Button ButtonForceQuest;
        private System.Windows.Forms.Button ButtonPatch;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox GroupBoxMail;
        private System.Windows.Forms.Button ButtonClearMail;
        private System.Windows.Forms.Button ButtonItemMain;
        private System.Windows.Forms.Button ButtonEquipments;
    }
}

