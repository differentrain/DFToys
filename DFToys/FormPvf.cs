using DFToys.PvfCache;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFToys
{
    public partial class FormPvf : Form
    {
        private readonly int _defaultFileEncodingIndex;
        private readonly int _defaultStringEncodingIndex;

        public FormPvf()
        {
            InitializeComponent();

            var en = Encoding
                   .GetEncodings()
                   .Where(e => e.GetEncoding().IsReadOnly && (!e.GetEncoding().IsSingleByte || e.GetEncoding().CodePage == Encoding.UTF8.CodePage))
                   .Select(e => (EncodingWapper)e.GetEncoding());
            int i = 0;
            foreach (EncodingWapper e in en)
            {
                ComboBoxFile.Items.Add(e);
                ComboBoxStr.Items.Add(e);
                if (e.Encoding.CodePage == 949)
                {
                    _defaultFileEncodingIndex = i;
                }
                else if (e.Encoding.CodePage == 950)
                {
                    _defaultStringEncodingIndex = i;
                }
                ++i;
            }


        }

        public Dictionary<int, QuestCache> QuestCache { get; private set; }


        private void FormPvf_Shown(object sender, EventArgs e)
        {
            ComboBoxFile.SelectedIndex = _defaultFileEncodingIndex;
            ComboBoxStr.SelectedIndex = _defaultStringEncodingIndex;
            TopMost = Owner.TopMost;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void ButtonPvf_Click(object sender, EventArgs e)
        {

            PvfCacheProvider cp = null;
            try
            {
                cp = new PvfCacheProvider(
                    MyConfig.Shared.PvfPath,
                    ComboBoxFile.SelectedItem as EncodingWapper,
                    ComboBoxStr.SelectedItem as EncodingWapper);
                QuestCache = cp.TryCreateQuestCache();

                if (MessageBox.Show(this, $"共加载 {QuestCache.Count} 条任务信息。", "加载成功", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DialogResult = DialogResult.OK;
                    Hide();
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                    Hide();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "加载失败");

            }
            finally
            {
                cp?.Dispose();
            }



        }

        private sealed class EncodingWapper
        {
            public EncodingWapper(Encoding encoding)
            {
                @Encoding = encoding;
            }

            public Encoding @Encoding { get; }

            public override string ToString()
            {
                return @Encoding.WebName;
            }

            public static implicit operator Encoding(EncodingWapper ew) => ew.Encoding;

            public static implicit operator EncodingWapper(Encoding en) => new EncodingWapper(en);
        }
    }

}
