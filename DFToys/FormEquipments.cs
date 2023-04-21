using DFToys.Common;
using DFToys.Models;
using DFToys.PvfCache;
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
    public partial class FormEquipments : Form
    {
        private readonly ListViewSorter _sorter = new ListViewSorter();

        public FormEquipments()
        {
            InitializeComponent();
        }


        public void UpdateByCache()
        {
            ListViewEquipments.Items.Clear();
            ComboBoxSubType2.Items.Clear();
            ComboBoxSubType1.Items.Clear();
            ComboBoxType.Items.Clear();
            ComboBoxJob.Items.Clear();
            TextBoxRaw.Text = string.Empty;
            ButtonSend.Enabled = ButtonSearch.Enabled = false;
            ComboBoxJob.Items.AddRange(MyCache.Shared.EquipmentIndexCache.Select(x => x.Key).ToArray());
            ComboBoxJob.SelectedIndex = -1;
        }



        private void FormEquipments_FormClosing(object sender, FormClosingEventArgs e)
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
                ComboBoxSubType1.Items.Clear();
                ComboBoxSubType2.Items.Clear();
                ComboBoxType.Items.Add("所有");
                ComboBoxType.Items.AddRange(MyCache.Shared.EquipmentIndexCache[ComboBoxJob.SelectedIndex].Value.Select(c => c.Key).ToArray());
            }
            CheckButtonSearch();
        }

        private void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxType.SelectedIndex >= 0)
            {
                ComboBoxSubType1.Items.Clear();
                ComboBoxSubType2.Items.Clear();
                ComboBoxSubType1.Items.Add("全部");
                if (ComboBoxType.SelectedIndex != 0)
                {
                    ComboBoxSubType1.Items.AddRange(
                        MyCache.Shared.EquipmentIndexCache[ComboBoxJob.SelectedIndex].Value[ComboBoxType.SelectedIndex - 1].Value.Select(c => c.Key).ToArray());
                }
            }
        }

        private void ComboBoxSubType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxType.SelectedIndex >= 0)
            {
                ComboBoxSubType2.Items.Clear();
                ComboBoxSubType2.Items.Add("全部");

                if (ComboBoxSubType1.SelectedIndex != 0)
                {
                    ComboBoxSubType2.Items.AddRange(
                        MyCache.Shared.EquipmentIndexCache[ComboBoxJob.SelectedIndex].Value[ComboBoxType.SelectedIndex - 1].Value[ComboBoxSubType1.SelectedIndex - 1].Value);
                }
            }
        }

        private void TextBoxMinLv_TextChanged(object sender, EventArgs e)
        {
            CheckButtonSearch();
        }


        private void CheckButtonSearch()
        {
            ButtonSearch.Enabled = ComboBoxJob.SelectedIndex >= 0 &&
                (string.IsNullOrWhiteSpace(TextBoxMinLv.Text) || byte.TryParse(TextBoxMinLv.Text, out _)) &&
                 (string.IsNullOrWhiteSpace(TextBoxMaxLv.Text) || byte.TryParse(TextBoxMaxLv.Text, out _)) &&
                 (string.IsNullOrEmpty(TextBoxAntiE.Text) || byte.TryParse(TextBoxAntiE.Text, out _));
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string keyWord = TextBoxName.Text;
            string typeFilter = MyCache.Shared.EquipmentIndexCache[ComboBoxJob.SelectedIndex].Key;


            var t =
                 MyCache.Shared.EquipmentCache.Where(
                     c => c.UsableJob.Count == 0 ||
                     c.UsableJob.Contains(EquipmentCache<GameJobTable, GameEquipmentTable>.JobTable.AllowAllJobFriendlyName) ||
                     c.UsableJob.Contains(typeFilter));

            if (!string.IsNullOrWhiteSpace(keyWord))
            {
                t = CheckBoxRaw.Checked ?
                    t.Where(c => c.RawData.Contains(keyWord)) :
                    t.Where(c => c.Name != null && c.Name.Contains(keyWord));
            }


            if (ComboBoxType.SelectedIndex > 0)
            {
                string typeFilter1 = MyCache.Shared.EquipmentIndexCache[ComboBoxJob.SelectedIndex].Value[ComboBoxType.SelectedIndex - 1].Key;
                t = t.Where(c => c.MainType == typeFilter1);

                if (ComboBoxSubType1.SelectedIndex > 0)
                {
                    string typeFilter2 = MyCache.Shared.EquipmentIndexCache[ComboBoxJob.SelectedIndex].Value[ComboBoxType.SelectedIndex - 1].Value[ComboBoxSubType1.SelectedIndex - 1].Key;
                    t = t.ToArray().Where(c => c.SubType1 == typeFilter2);

                    if (ComboBoxSubType2.SelectedIndex > 0)
                    {
                        string typeFilter3 = MyCache.Shared.EquipmentIndexCache[ComboBoxJob.SelectedIndex].Value[ComboBoxType.SelectedIndex - 1].Value[ComboBoxSubType1.SelectedIndex - 1].Value[ComboBoxSubType2.SelectedIndex - 1];
                        t = t.ToArray().Where(c => c.SubType2 == typeFilter3);
                    }
                }
            }



            if (ComboBoxRarity.SelectedIndex > 0)
            {
                int realRarity = ComboBoxRarity.SelectedIndex - 1;
                if (realRarity > 7)
                {
                    t = t.Where(c => c.Rarity == null || c.Rarity > 7);
                }
                else
                {
                    t = t.Where(c => c.Rarity != null && c.Rarity == realRarity);
                }

            }

            if (!string.IsNullOrEmpty(TextBoxAntiE.Text) && byte.TryParse(TextBoxAntiE.Text, out byte antiE) && antiE > 0)
            {
                t = t.Where(c => c.AntiEvil.HasValue && c.AntiEvil.Value >= antiE);
            }

            if (!string.IsNullOrWhiteSpace(TextBoxMinLv.Text) && byte.TryParse(TextBoxMinLv.Text, out byte min) && min > 1)
            {
                t = t.Where(c => (c.MinLevel.HasValue && c.MinLevel.Value >= min) && (!c.MaxLevel.HasValue || c.MaxLevel >= min));
            }

            if (!string.IsNullOrWhiteSpace(TextBoxMaxLv.Text) && byte.TryParse(TextBoxMaxLv.Text, out byte max))
            {
                t = t.Where(c => (!c.MaxLevel.HasValue || c.MaxLevel.Value <= max) && (!c.MinLevel.HasValue || c.MinLevel <= max));
            }

            if (CheckBoxSuit.CheckState == CheckState.Checked)
            {
                t = t.Where(c => c.IsSuit);
            }
            else if (CheckBoxSuit.CheckState == CheckState.Unchecked)
            {
                t = t.Where(c => !c.IsSuit);
            }


            ListViewEquipments.SelectedItems.Clear();
            ButtonSend.Enabled = false;
            ListViewEquipments.Items.Clear();
            ListViewEquipments.Items.AddRange(
                t.Select(
                    c => new ListViewItem(
                             new string[] {
                            c.Id.ToString(),
                            c.RarityString,
                            c.MinLevel.ToString(),
                            c.MaxLevel.ToString(),
                            c.AntiEvil?.ToString(),
                            c.FullType,
                            c.IsSuit.ToString(),
                            c.Name
                             })
                    {
                        Tag = c
                    })
                .ToArray()
                );
        }

        private void ListViewEquipments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewEquipments.SelectedItems.Count > 0)
            {
                ListViewItem sel = ListViewEquipments.SelectedItems[0];

                var item = sel.Tag as EquipmentCache<GameJobTable, GameEquipmentTable>;
                TextBoxRaw.Text = item.RawData;
                ButtonSend.Enabled = true;
                //  ButtonSend.Enabled = !EquipmentCache<GameJobTable, GameEquipmentTable>.EquipmentTable.IsForPets(item.SubType1);
                NumericUpDownS.Enabled = NumericUpDownSS.Enabled = NumericUpDownA.Enabled = ComboBoxAO.Enabled =
                    item.MainType == EquipmentCache<GameJobTable, GameEquipmentTable>.EquipmentTable.WeaponFriendlyName ||
                    item.MainType == EquipmentCache<GameJobTable, GameEquipmentTable>.EquipmentTable.ArmorFriendlyName ||
                    item.MainType == EquipmentCache<GameJobTable, GameEquipmentTable>.EquipmentTable.JewelryFriendlyName;
            }
            else
            {
                NumericUpDownS.Enabled = NumericUpDownSS.Enabled = NumericUpDownA.Enabled = ComboBoxAO.Enabled = false;
                ButtonSend.Enabled = false;
            }
        }

        private void ListViewEquipments_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (_sorter.ColumnToSort != e.Column)
            {
                _sorter.ColumnToSort = e.Column;
                ListViewEquipments.ListViewItemSorter = _sorter;
                ListViewEquipments.Sort();
            }
            ListViewEquipments.ListViewItemSorter = null;
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            var item = ListViewEquipments.SelectedItems[0].Tag as EquipmentCache<GameJobTable, GameEquipmentTable>;
            try
            {
                int t = ComboBoxAO.SelectedIndex < 0 ? 0 : ComboBoxAO.SelectedIndex;
                FormMain.GameDb.SendLetter<DefaultDbStringConvert, GameJobTable, GameEquipmentTable>(FormMain.GameCharac.Id, "DfToys", "Item", item, t, (int)NumericUpDownA.Value, (int)NumericUpDownSS.Value, (int)NumericUpDownS.Value);
                ButtonSend.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "发送失败");
            }

        }

        private void TextBoxMaxLv_TextChanged(object sender, EventArgs e)
        {
            CheckButtonSearch();
        }

        private void TextBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return && ButtonSearch.Enabled)
            {
                ButtonSearch.PerformClick();
            }
        }
    }
}
