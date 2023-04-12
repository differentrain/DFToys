using DFToys.Patch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFToys
{
    public partial class FormPatch : Form
    {
        public FormPatch()
        {
            InitializeComponent();
        }

        private void FormPatch_Shown(object sender, EventArgs e)
        {
            TopMost = Owner.TopMost;
        }

        private void CheckBoxSetGm_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxGmOn.Enabled = CheckBoxSetGm.Checked;
            EnsureButton();
        }

        private void CheckBoxSetLevel_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxLevel.Enabled = CheckBoxSetLevel.Checked;
            EnsureButton();
        }

        private void EnsureButton()
        {
            if (TextBoxLevel.Enabled)
            {
                ButtonPatch.Enabled = byte.TryParse(TextBoxLevel.Text, out _);
            }
            else if (CheckBoxGmOn.Enabled)
            {
                ButtonPatch.Enabled = true;
            }
            else
            {
                TextBoxLevel.Enabled = false;
            }
        }

        private void TextBoxLevel_TextChanged(object sender, EventArgs e)
        {
            EnsureButton();
        }

        private void ButtonPatch_Click(object sender, EventArgs e)
        {
            OpenFileDialogMain.FileName = "df_game_r";

            if (OpenFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                bool? isGm = CheckBoxSetGm.Checked ? (bool?)CheckBoxGmOn.Checked : null;
                byte? level = CheckBoxSetLevel.Checked ? (byte?)byte.Parse(TextBoxLevel.Text) : null;
                try
                {
                    DfServerPatch.Patch(OpenFileDialogMain.FileName, isGm, level);
                    MessageBox.Show("应用补丁完成。", "完成");
                }
                catch (Exception ecx)
                {
                    MessageBox.Show(ecx.Message, "失败");
                }
            }
        }
    }
}
