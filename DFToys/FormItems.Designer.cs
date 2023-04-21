namespace DFToys
{
    partial class FormItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormItems));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxMinLv = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxMaxLv = new System.Windows.Forms.TextBox();
            this.ComboBoxJob = new System.Windows.Forms.ComboBox();
            this.ComboBoxType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ComboBoxRarity = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.CheckBoxRaw = new System.Windows.Forms.CheckBox();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.NumericUpDownCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.ListViewItems = new System.Windows.Forms.ListView();
            this.ColumnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderRarity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderMinLv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderMaxLv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TextBoxRaw = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownCount)).BeginInit();
            this.SuspendLayout();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "等级";
            // 
            // TextBoxMinLv
            // 
            this.TextBoxMinLv.Location = new System.Drawing.Point(49, 153);
            this.TextBoxMinLv.MaxLength = 3;
            this.TextBoxMinLv.Name = "TextBoxMinLv";
            this.TextBoxMinLv.Size = new System.Drawing.Size(29, 21);
            this.TextBoxMinLv.TabIndex = 5;
            this.TextBoxMinLv.TextChanged += new System.EventHandler(this.TextBoxMinLv_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "-";
            // 
            // TextBoxMaxLv
            // 
            this.TextBoxMaxLv.Location = new System.Drawing.Point(101, 153);
            this.TextBoxMaxLv.MaxLength = 3;
            this.TextBoxMaxLv.Name = "TextBoxMaxLv";
            this.TextBoxMaxLv.Size = new System.Drawing.Size(29, 21);
            this.TextBoxMaxLv.TabIndex = 7;
            this.TextBoxMaxLv.TextChanged += new System.EventHandler(this.TextBoxMaxLv_TextChanged);
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
            // ComboBoxType
            // 
            this.ComboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxType.FormattingEnabled = true;
            this.ComboBoxType.Location = new System.Drawing.Point(49, 100);
            this.ComboBoxType.Name = "ComboBoxType";
            this.ComboBoxType.Size = new System.Drawing.Size(100, 20);
            this.ComboBoxType.TabIndex = 9;
            // 
            // groupBox1
            // 
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
            this.groupBox1.Controls.Add(this.TextBoxMaxLv);
            this.groupBox1.Controls.Add(this.TextBoxMinLv);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(2, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 217);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "筛选器";
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
            this.ComboBoxRarity.Location = new System.Drawing.Point(49, 127);
            this.ComboBoxRarity.Name = "ComboBoxRarity";
            this.ComboBoxRarity.Size = new System.Drawing.Size(100, 20);
            this.ComboBoxRarity.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "稀有";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(49, 184);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
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
            this.TextBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxName_KeyPress);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ButtonSend);
            this.groupBox2.Controls.Add(this.NumericUpDownCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(2, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 77);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "邮件";
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(45, 47);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(75, 23);
            this.ButtonSend.TabIndex = 14;
            this.ButtonSend.Text = "发送";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // NumericUpDownCount
            // 
            this.NumericUpDownCount.Location = new System.Drawing.Point(45, 20);
            this.NumericUpDownCount.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.NumericUpDownCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownCount.Name = "NumericUpDownCount";
            this.NumericUpDownCount.Size = new System.Drawing.Size(104, 21);
            this.NumericUpDownCount.TabIndex = 4;
            this.NumericUpDownCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "数量";
            // 
            // ListViewItems
            // 
            this.ListViewItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeaderId,
            this.ColumnHeaderRarity,
            this.ColumnHeaderMinLv,
            this.ColumnHeaderMaxLv,
            this.ColumnHeaderType,
            this.ColumnHeaderName});
            this.ListViewItems.FullRowSelect = true;
            this.ListViewItems.HideSelection = false;
            this.ListViewItems.Location = new System.Drawing.Point(2, 309);
            this.ListViewItems.MultiSelect = false;
            this.ListViewItems.Name = "ListViewItems";
            this.ListViewItems.Size = new System.Drawing.Size(579, 197);
            this.ListViewItems.TabIndex = 12;
            this.ListViewItems.UseCompatibleStateImageBehavior = false;
            this.ListViewItems.View = System.Windows.Forms.View.Details;
            this.ListViewItems.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewItems_ColumnClick);
            this.ListViewItems.SelectedIndexChanged += new System.EventHandler(this.ListViewItems_SelectedIndexChanged);
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
            this.ColumnHeaderMinLv.Text = "lvn";
            this.ColumnHeaderMinLv.Width = 30;
            // 
            // ColumnHeaderMaxLv
            // 
            this.ColumnHeaderMaxLv.Text = "lvx";
            this.ColumnHeaderMaxLv.Width = 40;
            // 
            // ColumnHeaderType
            // 
            this.ColumnHeaderType.Text = "类型";
            this.ColumnHeaderType.Width = 98;
            // 
            // ColumnHeaderName
            // 
            this.ColumnHeaderName.Text = "名称";
            this.ColumnHeaderName.Width = 252;
            // 
            // TextBoxRaw
            // 
            this.TextBoxRaw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxRaw.Location = new System.Drawing.Point(166, 3);
            this.TextBoxRaw.Multiline = true;
            this.TextBoxRaw.Name = "TextBoxRaw";
            this.TextBoxRaw.ReadOnly = true;
            this.TextBoxRaw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxRaw.Size = new System.Drawing.Size(415, 300);
            this.TextBoxRaw.TabIndex = 13;
            // 
            // FormItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 508);
            this.Controls.Add(this.TextBoxRaw);
            this.Controls.Add(this.ListViewItems);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(460, 410);
            this.Name = "FormItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "物品邮件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormItemMain_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBoxMinLv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxMaxLv;
        private System.Windows.Forms.ComboBox ComboBoxJob;
        private System.Windows.Forms.ComboBox ComboBoxType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.CheckBox CheckBoxRaw;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown NumericUpDownCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.ListView ListViewItems;
        private System.Windows.Forms.ColumnHeader ColumnHeaderId;
        private System.Windows.Forms.ColumnHeader ColumnHeaderMinLv;
        private System.Windows.Forms.ColumnHeader ColumnHeaderType;
        private System.Windows.Forms.ColumnHeader ColumnHeaderName;
        private System.Windows.Forms.TextBox TextBoxRaw;
        private System.Windows.Forms.ColumnHeader ColumnHeaderMaxLv;
        private System.Windows.Forms.ComboBox ComboBoxRarity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader ColumnHeaderRarity;
    }
}