using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFToys
{
    internal sealed class ListViewSorter : IComparer
    {
        public int ColumnToSort = -1;
        public int Compare(object x, object y)
        {
            var a = (x as ListViewItem).SubItems[ColumnToSort].Text;
            var b = (y as ListViewItem).SubItems[ColumnToSort].Text;
            return int.TryParse(a, out var i) && int.TryParse(b, out var j) ? i.CompareTo(j) : a.CompareTo(b);
        }
    }


}
