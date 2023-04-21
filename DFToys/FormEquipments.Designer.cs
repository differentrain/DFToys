namespace DFToys
{
    partial class FormEquipments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEquipments));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComboBoxSubType2 = new System.Windows.Forms.ComboBox();
            this.ComboBoxSubType1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboBoxRarity = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.CheckBoxRaw = new System.Windows.Forms.CheckBox();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBoxType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxJob = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxMinLv = new System.Windows.Forms.TextBox();
            this.TextBoxRaw = new System.Windows.Forms.TextBox();
            this.ListViewEquipments = new System.Windows.Forms.ListView();
            this.ColumnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderRarity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderMinLv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderAntiE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ComboBoxAO = new System.Windows.Forms.ComboBox();
            this.NumericUpDownA = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.NumericUpDownS = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.NumericUpDownSS = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TextBoxAntiE = new System.Windows.Forms.TextBox();
            this.CheckBoxSuit = new System.Windows.Forms.CheckBox();
            this.ColumnHeaderSuit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownSS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CheckBoxSuit);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.TextBoxAntiE);
            this.groupBox1.Controls.Add(this.ComboBoxSubType2);
            this.groupBox1.Controls.Add(this.ComboBoxSubType1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ComboBoxRarity);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ButtonSearch);
            this.groupBox1.Controls.Add(this.CheckBoxRaw);
            this.groupBox1.Controls.Add(this.TextBoxName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ComboBoxType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ComboBoxJob);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TextBoxMinLv);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 265);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "筛选器";
            // 
            // ComboBoxSubType2
            // 
            this.ComboBoxSubType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSubType2.FormattingEnabled = true;
            this.ComboBoxSubType2.Location = new System.Drawing.Point(49, 154);
            this.ComboBoxSubType2.Name = "ComboBoxSubType2";
            this.ComboBoxSubType2.Size = new System.Drawing.Size(100, 20);
            this.ComboBoxSubType2.TabIndex = 18;
            // 
            // ComboBoxSubType1
            // 
            this.ComboBoxSubType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSubType1.FormattingEnabled = true;
            this.ComboBoxSubType1.Location = new System.Drawing.Point(49, 128);
            this.ComboBoxSubType1.Name = "ComboBoxSubType1";
            this.ComboBoxSubType1.Size = new System.Drawing.Size(100, 20);
            this.ComboBoxSubType1.TabIndex = 17;
            this.ComboBoxSubType1.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSubType1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "子类型";
            // 
            // ComboBoxRarity
            // 
            this.ComboBoxRarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxRarity.FormattingEnabled = true;
            this.ComboBoxRarity.Items.AddRange(new object[] {
            "全部",
            "普通",
            "高级",
            "稀有",
            "神器",
            "史诗",
            "勇者",
            "传说",
            "神话",
            "其他"});
            this.ComboBoxRarity.Location = new System.Drawing.Point(49, 180);
            this.ComboBoxRarity.Name = "ComboBoxRarity";
            this.ComboBoxRarity.Size = new System.Drawing.Size(100, 20);
            this.ComboBoxRarity.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "稀有";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(84, 236);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(65, 23);
            this.ButtonSearch.TabIndex = 13;
            this.ButtonSearch.Text = "搜索";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // CheckBoxRaw
            // 
            this.CheckBoxRaw.AutoSize = true;
            this.CheckBoxRaw.Location = new System.Drawing.Point(49, 50);
            this.CheckBoxRaw.Name = "CheckBoxRaw";
            this.CheckBoxRaw.Size = new System.Drawing.Size(60, 16);
            this.CheckBoxRaw.TabIndex = 12;
            this.CheckBoxRaw.Text = "原文本";
            this.CheckBoxRaw.UseVisualStyleBackColor = true;
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(49, 23);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(100, 21);
            this.TextBoxName.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "关键字";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "职业";
            // 
            // ComboBoxType
            // 
            this.ComboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxType.FormattingEnabled = true;
            this.ComboBoxType.Location = new System.Drawing.Point(49, 100);
            this.ComboBoxType.Name = "ComboBoxType";
            this.ComboBoxType.Size = new System.Drawing.Size(100, 20);
            this.ComboBoxType.TabIndex = 9;
            this.ComboBoxType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "主类型";
            // 
            // ComboBoxJob
            // 
            this.ComboBoxJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxJob.FormattingEnabled = true;
            this.ComboBoxJob.Location = new System.Drawing.Point(49, 74);
            this.ComboBoxJob.Name = "ComboBoxJob";
            this.ComboBoxJob.Size = new System.Drawing.Size(100, 20);
            this.ComboBoxJob.TabIndex = 8;
            this.ComboBoxJob.SelectedIndexChanged += new System.EventHandler(this.ComboBoxJob_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "等级";
            // 
            // TextBoxMinLv
            // 
            this.TextBoxMinLv.Location = new System.Drawing.Point(49, 206);
            this.TextBoxMinLv.MaxLength = 3;
            this.TextBoxMinLv.Name = "TextBoxMinLv";
            this.TextBoxMinLv.Size = new System.Drawing.Size(29, 21);
            this.TextBoxMinLv.TabIndex = 5;
            this.TextBoxMinLv.TextChanged += new System.EventHandler(this.TextBoxMinLv_TextChanged);
            // 
            // TextBoxRaw
            // 
            this.TextBoxRaw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxRaw.Location = new System.Drawing.Point(165, 2);
            this.TextBoxRaw.Multiline = true;
            this.TextBoxRaw.Name = "TextBoxRaw";
            this.TextBoxRaw.ReadOnly = true;
            this.TextBoxRaw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxRaw.Size = new System.Drawing.Size(301, 373);
            this.TextBoxRaw.TabIndex = 14;
            // 
            // ListViewEquipments
            // 
            this.ListViewEquipments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewEquipments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderId,
            this.ColumnHeaderRarity,
            this.ColumnHeaderMinLv,
            this.ColumnHeaderAntiE,
            this.ColumnHeaderType,
            this.ColumnHeaderSuit,
            this.ColumnHeaderName});
            this.ListViewEquipments.FullRowSelect = true;
            this.ListViewEquipments.HideSelection = false;
            this.ListViewEquipments.Location = new System.Drawing.Point(1, 381);
            this.ListViewEquipments.MultiSelect = false;
            this.ListViewEquipments.Name = "ListViewEquipments";
            this.ListViewEquipments.Size = new System.Drawing.Size(465, 137);
            this.ListViewEquipments.TabIndex = 15;
            this.ListViewEquipments.UseCompatibleStateImageBehavior = false;
            this.ListViewEquipments.View = System.Windows.Forms.View.Details;
            this.ListViewEquipments.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewEquipments_ColumnClick);
            this.ListViewEquipments.SelectedIndexChanged += new System.EventHandler(this.ListViewEquipments_SelectedIndexChanged);
            // 
            // ColumnHeaderId
            // 
            this.ColumnHeaderId.Text = "id";
            this.ColumnHeaderId.Width = 93;
            // 
            // ColumnHeaderRarity
            // 
            this.ColumnHeaderRarity.Text = "稀有";
            this.ColumnHeaderRarity.Width = 46;
            // 
            // ColumnHeaderMinLv
            // 
            this.ColumnHeaderMinLv.Text = "等级";
            this.ColumnHeaderMinLv.Width = 40;
            // 
            // ColumnHeaderAntiE
            // 
            this.ColumnHeaderAntiE.Text = "抗魔";
            this.ColumnHeaderAntiE.Width = 66;
            // 
            // ColumnHeaderType
            // 
            this.ColumnHeaderType.Text = "类型";
            this.ColumnHeaderType.Width = 87;
            // 
            // ColumnHeaderName
            // 
            this.ColumnHeaderName.Text = "名称";
            this.ColumnHeaderName.Width = 252;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ComboBoxAO);
            this.groupBox2.Controls.Add(this.NumericUpDownA);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.NumericUpDownS);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.ButtonSend);
            this.groupBox2.Controls.Add(this.NumericUpDownSS);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(1, 273);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 102);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "邮件";
            // 
            // ComboBoxAO
            // 
            this.ComboBoxAO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxAO.FormattingEnabled = true;
            this.ComboBoxAO.Items.AddRange(new object[] {
            "无",
            "体",
            "精",
            "力",
            "智"});
            this.ComboBoxAO.Location = new System.Drawing.Point(45, 47);
            this.ComboBoxAO.Name = "ComboBoxAO";
            this.ComboBoxAO.Size = new System.Drawing.Size(45, 20);
            this.ComboBoxAO.TabIndex = 19;
            // 
            // NumericUpDownA
            // 
            this.NumericUpDownA.Location = new System.Drawing.Point(96, 46);
            this.NumericUpDownA.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericUpDownA.Name = "NumericUpDownA";
            this.NumericUpDownA.Size = new System.Drawing.Size(53, 21);
            this.NumericUpDownA.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "异界";
            // 
            // NumericUpDownS
            // 
            this.NumericUpDownS.Location = new System.Drawing.Point(43, 19);
            this.NumericUpDownS.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.NumericUpDownS.Name = "NumericUpDownS";
            this.NumericUpDownS.Size = new System.Drawing.Size(33, 21);
            this.NumericUpDownS.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "锻造";
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(45, 73);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(107, 23);
            this.ButtonSend.TabIndex = 14;
            this.ButtonSend.Text = "发送";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // NumericUpDownSS
            // 
            this.NumericUpDownSS.Location = new System.Drawing.Point(116, 19);
            this.NumericUpDownSS.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.NumericUpDownSS.Name = "NumericUpDownSS";
            this.NumericUpDownSS.Size = new System.Drawing.Size(33, 21);
            this.NumericUpDownSS.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "强化";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(85, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "抗魔";
            // 
            // TextBoxAntiE
            // 
            this.TextBoxAntiE.Location = new System.Drawing.Point(120, 206);
            this.TextBoxAntiE.MaxLength = 3;
            this.TextBoxAntiE.Name = "TextBoxAntiE";
            this.TextBoxAntiE.Size = new System.Drawing.Size(29, 21);
            this.TextBoxAntiE.TabIndex = 20;
            // 
            // CheckBoxSuit
            // 
            this.CheckBoxSuit.AutoSize = true;
            this.CheckBoxSuit.Checked = true;
            this.CheckBoxSuit.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.CheckBoxSuit.Location = new System.Drawing.Point(12, 240);
            this.CheckBoxSuit.Name = "CheckBoxSuit";
            this.CheckBoxSuit.Size = new System.Drawing.Size(48, 16);
            this.CheckBoxSuit.TabIndex = 21;
            this.CheckBoxSuit.Text = "套装";
            this.CheckBoxSuit.ThreeState = true;
            this.CheckBoxSuit.UseVisualStyleBackColor = true;
            // 
            // ColumnHeaderSuit
            // 
            this.ColumnHeaderSuit.Text = "套装";
            // 
            // FormEquipments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 521);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ListViewEquipments);
            this.Controls.Add(this.TextBoxRaw);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(410, 560);
            this.Name = "FormEquipments";
            this.Text = "装备邮件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEquipments_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownSS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ComboBoxRarity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.CheckBox CheckBoxRaw;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComboBoxType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBoxJob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxMinLv;
        private System.Windows.Forms.ComboBox ComboBoxSubType2;
        private System.Windows.Forms.ComboBox ComboBoxSubType1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxRaw;
        private System.Windows.Forms.ListView ListViewEquipments;
        private System.Windows.Forms.ColumnHeader ColumnHeaderId;
        private System.Windows.Forms.ColumnHeader ColumnHeaderRarity;
        private System.Windows.Forms.ColumnHeader ColumnHeaderMinLv;
        private System.Windows.Forms.ColumnHeader ColumnHeaderAntiE;
        private System.Windows.Forms.ColumnHeader ColumnHeaderType;
        private System.Windows.Forms.ColumnHeader ColumnHeaderName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox ComboBoxAO;
        private System.Windows.Forms.NumericUpDown NumericUpDownA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown NumericUpDownS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.NumericUpDown NumericUpDownSS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox CheckBoxSuit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TextBoxAntiE;
        private System.Windows.Forms.ColumnHeader ColumnHeaderSuit;
    }
}