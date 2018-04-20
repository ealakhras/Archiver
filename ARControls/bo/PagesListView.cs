using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARControls.bo
{
    public partial class PagesListView : ListView
    {
        public PagesListView()
        {
            InitializeComponent();
            View = View.Details;
            Columns.Add("Select Page");
            BorderStyle = BorderStyle.None;
            HeaderStyle = ColumnHeaderStyle.Clickable;
            HideSelection = false;
            LabelEdit = false;
            MultiSelect = false;
            Scrollable = false;
            OwnerDraw = true;
        }

        private TabControl mPagesTabControl;

        [Category("Link")]
        [Description("Connected TabControl")]
        public TabControl PagesTabControl
        {
            get
            {
                return mPagesTabControl;
            }
            set
            {
                mPagesTabControl = value;
                if ((mPagesTabControl != null) && (mPagesTabControl.TabPages.Count > 0))
                {
                    mPagesTabControl.SelectTab(0);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (Columns.Count == 1)
            {
                Columns[0].Width = Width + 1;
            }
        }

        protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e)
        {
            base.OnItemSelectionChanged(e);
            if ((mPagesTabControl != null) && (mPagesTabControl.TabPages.Count > e.ItemIndex))
            {
                mPagesTabControl.SelectTab(e.ItemIndex);
            }
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            base.OnDrawColumnHeader(e);
            //e.DrawDefault = true;
            e.Graphics.FillRectangle(Brushes.LightSteelBlue, e.Bounds);
            e.DrawText(TextFormatFlags.VerticalCenter);
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawItem(e);
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawSubItem(e);
        }
    }
}
