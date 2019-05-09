using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StiffFormsLibrary
{
    public partial class HideableTabControl : TabControl
    {
        public HideableTabControl()
        {
            InitializeComponent();
            HiddenPages = new List<TabPage>();
            lastIndex = new List<int>();
        }

        public List<TabPage> HiddenPages;
        public List<int> lastIndex;

        public void ShowPage(TabPage tabPage)
        {
            if (HiddenPages.Contains(tabPage))
            {
                int i = HiddenPages.FindIndex(x => x == tabPage);
                TabPages.Insert(i, tabPage);
                HiddenPages.RemoveAt(lastIndex[i]);
                lastIndex.RemoveAt(i);
            }
        }

        public void HidePage(TabPage tabPage)
        {
            if(TabPages.Contains(tabPage)){
                int v = TabPages.IndexOf(tabPage);
                HiddenPages.Add(tabPage);
                lastIndex.Add(v);
                TabPages.RemoveAt(v);
            }
        }
    }
}
