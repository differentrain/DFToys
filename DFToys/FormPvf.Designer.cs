namespace DFToys
{
    partial class FormPvf
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxFile = new System.Windows.Forms.ComboBox();
            this.ComboBoxStr = new System.Windows.Forms.ComboBox();
            this.ButtonPvf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件编码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "文本编码";
            // 
            // ComboBoxFile
            // 
            this.ComboBoxFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxFile.FormattingEnabled = true;
            this.ComboBoxFile.Location = new System.Drawing.Point(71, 15);
            this.ComboBoxFile.Name = "ComboBoxFile";
            this.ComboBoxFile.Size = new System.Drawing.Size(135, 20);
            this.ComboBoxFile.TabIndex = 3;
            this.ComboBoxFile.TabStop = false;
            // 
            // ComboBoxStr
            // 
            this.ComboBoxStr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxStr.FormattingEnabled = true;
            this.ComboBoxStr.Location = new System.Drawing.Point(71, 49);
            this.ComboBoxStr.Name = "ComboBoxStr";
            this.ComboBoxStr.Size = new System.Drawing.Size(135, 20);
            this.ComboBoxStr.TabIndex = 6;
            this.ComboBoxStr.TabStop = false;
            // 
            // ButtonPvf
            // 
            this.ButtonPvf.Location = new System.Drawing.Point(47, 85);
            this.ButtonPvf.Name = "ButtonPvf";
            this.ButtonPvf.Size = new System.Drawing.Size(126, 24);
            this.ButtonPvf.TabIndex = 7;
            this.ButtonPvf.Text = "加载PVF";
            this.ButtonPvf.UseVisualStyleBackColor = true;
            this.ButtonPvf.Click += new System.EventHandler(this.ButtonPvf_Click);
            // 
            // FormPvf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 117);
            this.Controls.Add(this.ButtonPvf);
            this.Controls.Add(this.ComboBoxStr);
            this.Controls.Add(this.ComboBoxFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormPvf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pvf缓存处理";
            this.Shown += new System.EventHandler(this.FormPvf_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBoxFile;
        private System.Windows.Forms.ComboBox ComboBoxStr;
        private System.Windows.Forms.Button ButtonPvf;
    }
}