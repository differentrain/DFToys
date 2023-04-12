namespace DFToys
{
    partial class FormPatch
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
            this.CheckBoxSetGm = new System.Windows.Forms.CheckBox();
            this.CheckBoxGmOn = new System.Windows.Forms.CheckBox();
            this.CheckBoxSetLevel = new System.Windows.Forms.CheckBox();
            this.TextBoxLevel = new System.Windows.Forms.TextBox();
            this.ButtonPatch = new System.Windows.Forms.Button();
            this.OpenFileDialogMain = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // CheckBoxSetGm
            // 
            this.CheckBoxSetGm.AutoSize = true;
            this.CheckBoxSetGm.Location = new System.Drawing.Point(12, 12);
            this.CheckBoxSetGm.Name = "CheckBoxSetGm";
            this.CheckBoxSetGm.Size = new System.Drawing.Size(60, 16);
            this.CheckBoxSetGm.TabIndex = 0;
            this.CheckBoxSetGm.Text = "GM补丁";
            this.CheckBoxSetGm.UseVisualStyleBackColor = true;
            this.CheckBoxSetGm.CheckedChanged += new System.EventHandler(this.CheckBoxSetGm_CheckedChanged);
            // 
            // CheckBoxGmOn
            // 
            this.CheckBoxGmOn.AutoSize = true;
            this.CheckBoxGmOn.Enabled = false;
            this.CheckBoxGmOn.Location = new System.Drawing.Point(88, 12);
            this.CheckBoxGmOn.Name = "CheckBoxGmOn";
            this.CheckBoxGmOn.Size = new System.Drawing.Size(48, 16);
            this.CheckBoxGmOn.TabIndex = 1;
            this.CheckBoxGmOn.Text = "启用";
            this.CheckBoxGmOn.UseVisualStyleBackColor = true;
            // 
            // CheckBoxSetLevel
            // 
            this.CheckBoxSetLevel.AutoSize = true;
            this.CheckBoxSetLevel.Location = new System.Drawing.Point(10, 36);
            this.CheckBoxSetLevel.Name = "CheckBoxSetLevel";
            this.CheckBoxSetLevel.Size = new System.Drawing.Size(72, 16);
            this.CheckBoxSetLevel.TabIndex = 2;
            this.CheckBoxSetLevel.Text = "等级补丁";
            this.CheckBoxSetLevel.UseVisualStyleBackColor = true;
            this.CheckBoxSetLevel.CheckedChanged += new System.EventHandler(this.CheckBoxSetLevel_CheckedChanged);
            // 
            // TextBoxLevel
            // 
            this.TextBoxLevel.Enabled = false;
            this.TextBoxLevel.Location = new System.Drawing.Point(88, 34);
            this.TextBoxLevel.MaxLength = 3;
            this.TextBoxLevel.Name = "TextBoxLevel";
            this.TextBoxLevel.Size = new System.Drawing.Size(48, 21);
            this.TextBoxLevel.TabIndex = 3;
            this.TextBoxLevel.TabStop = false;
            this.TextBoxLevel.TextChanged += new System.EventHandler(this.TextBoxLevel_TextChanged);
            // 
            // ButtonPatch
            // 
            this.ButtonPatch.Enabled = false;
            this.ButtonPatch.Location = new System.Drawing.Point(152, 12);
            this.ButtonPatch.Name = "ButtonPatch";
            this.ButtonPatch.Size = new System.Drawing.Size(63, 35);
            this.ButtonPatch.TabIndex = 4;
            this.ButtonPatch.Text = "修补";
            this.ButtonPatch.UseVisualStyleBackColor = true;
            this.ButtonPatch.Click += new System.EventHandler(this.ButtonPatch_Click);
            // 
            // OpenFileDialogMain
            // 
            this.OpenFileDialogMain.FileName = "df_game_r";
            // 
            // FormPatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 61);
            this.Controls.Add(this.ButtonPatch);
            this.Controls.Add(this.TextBoxLevel);
            this.Controls.Add(this.CheckBoxSetLevel);
            this.Controls.Add(this.CheckBoxGmOn);
            this.Controls.Add(this.CheckBoxSetGm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPatch";
            this.Text = "服务端补丁";
            this.Shown += new System.EventHandler(this.FormPatch_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBoxSetGm;
        private System.Windows.Forms.CheckBox CheckBoxGmOn;
        private System.Windows.Forms.CheckBox CheckBoxSetLevel;
        private System.Windows.Forms.TextBox TextBoxLevel;
        private System.Windows.Forms.Button ButtonPatch;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogMain;
    }
}