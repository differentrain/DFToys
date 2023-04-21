using DFToys.Common;
using DFToys.Models;
using DFToys.PvfCache;
using System;
using System.Collections;
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
    public partial class FormItems : Form
    {
        private readonly ListViewSorter _sorter = new ListViewSorter();

        public FormItems()
        {
            InitializeComponent();
        }


        public void UpdateByCache()
        {
            ListViewItems.Items.Clear();
            ComboBoxType.Items.Clear();
            ComboBoxJob.Items.Clear();
            TextBoxRaw.Text = string.Empty;
            ButtonSend.Enabled = ButtonSearch.Enabled = false;
            ComboBoxJob.Items.AddRange(MyCache.Shared.ItemIndexCache.Select(x => x.Key).ToArray());
            ComboBoxJob.SelectedIndex = -1;
        }



        private void FormItemMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void ComboBoxJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxJob.SelectedIndex >= 0)
            {
                ComboBoxType.Items.Clear();
                ComboBoxType.Items.Add("所有");
                ComboBoxType.Items.AddRange(MyCache.Shared.ItemIndexCache[ComboBoxJob.SelectedIndex].Value);
            }
            CheckButtonSearch();
        }

        private void TextBoxMinLv_TextChanged(object sender, EventArgs e)
        {
            CheckButtonSearch();
        }

        private void TextBoxMaxLv_TextChanged(object sender, EventArgs e)
        {
            CheckButtonSearch();
        }

        private void CheckButtonSearch()
        {
            ButtonSearch.Enabled = ComboBoxJob.SelectedIndex >= 0 &&
                (string.IsNullOrWhiteSpace(TextBoxMinLv.Text) || byte.TryParse(TextBoxMinLv.Text, out _)) &&
                (string.IsNullOrWhiteSpace(TextBoxMaxLv.Text) || byte.TryParse(TextBoxMaxLv.Text, out _));
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string keyWord = TextBoxName.Text;
            string typeFilter = MyCache.Shared.ItemIndexCache[ComboBoxJob.SelectedIndex].Key;
            IEnumerable<StackableItemCache<GameJobTable, GameItemTable>> t =
                 MyCache.Shared.ItemCache.Where(
                     c => c.UsableJob.Count == 0 ||
                     c.UsableJob.Contains(StackableItemCache<GameJobTable, GameItemTable>.JobTable.AllowAllJobFriendlyName) ||
                     c.UsableJob.Contains(typeFilter));

            if (!string.IsNullOrWhiteSpace(keyWord))
            {
                t = CheckBoxRaw.Checked ?
                    t.Where(c => c.RawData.Contains(keyWord)) :
                    t.Where(c => c.Name != null && c.Name.Contains(keyWord));
            }


            if (ComboBoxType.SelectedIndex > 0)
            {
                var typeFilter1 = MyCache.Shared.ItemIndexCache[ComboBoxJob.SelectedIndex].Value[ComboBoxType.SelectedIndex - 1];
                t = t.Where(c => c.ItemType == typeFilter1);
            }

            if (ComboBoxRarity.SelectedIndex > 0)
            {
                var realRarity = ComboBoxRarity.SelectedIndex - 1;
                if (realRarity > 7)
                {
                    t = t.Where(c => c.Rarity != null && c.Rarity > 7);
                }
                else
                {
                    t = t.Where(c => c.Rarity != null && c.Rarity == realRarity);
                }

            }

            if (!string.IsNullOrWhiteSpace(TextBoxMinLv.Text) && byte.TryParse(TextBoxMinLv.Text, out byte min) && min > 0)
            {
                t = t.Where(c => c.MinLevel.HasValue && c.MinLevel.Value >= min);
            }

            if (!string.IsNullOrWhiteSpace(TextBoxMaxLv.Text) && byte.TryParse(TextBoxMaxLv.Text, out byte max))
            {
                t = t.Where(c => c.MaxLevel.HasValue && c.MaxLevel.Value <= max);
            }
            ListViewItems.SelectedItems.Clear();
            ButtonSend.Enabled = false;
            ListViewItems.Items.Clear();
            ListViewItems.Items.AddRange(
                t.Select(
                    c => new ListViewItem(
                             new string[] {
                            c.Id.ToString(),
                            c.RarityString,
                            c.MinLevel.ToString(),
                            c.MaxLevel.ToString(),
                            c.ItemType,
                            c.Name
                             })
                    {
                        Tag = c
                    })
                .ToArray()
                );
        }

        private void ListViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewItems.SelectedItems.Count > 0)
            {
                var sel = ListViewItems.SelectedItems[0];
                ButtonSend.Enabled = true;
                var item = sel.Tag as StackableItemCache<GameJobTable, GameItemTable>;
                TextBoxRaw.Text = item.RawData;
                if (item.StackLimit != null)
                {
                    if (item.StackLimit.Value < NumericUpDownCount.Value)
                    {
                        NumericUpDownCount.Value = item.StackLimit.Value;
                    }
                    NumericUpDownCount.Maximum = item.StackLimit.Value;
                }
                else
                {
                    NumericUpDownCount.Maximum = 99999;
                }
            }
            else
            {
                ButtonSend.Enabled = false;
            }
        }

        private void ListViewItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (_sorter.ColumnToSort != e.Column)
            {
                _sorter.ColumnToSort = e.Column;
                ListViewItems.ListViewItemSorter = _sorter;
                ListViewItems.Sort();
            }
            ListViewItems.ListViewItemSorter = null;
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            var item = ListViewItems.SelectedItems[0].Tag as StackableItemCache<GameJobTable, GameItemTable>;
            try
            {
                FormMain.GameDb.SendLetter<DefaultDbStringConvert>(FormMain.GameCharac.Id, "DfToys", "Item", new GameItem((uint)item.Id, (uint)NumericUpDownCount.Value));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"发送失败");
            }

        }
    }
}
