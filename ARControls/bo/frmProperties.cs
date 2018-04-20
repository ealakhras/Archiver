using System;
using System.Drawing;
using System.Windows.Forms;
using ARCengine.Interfaces;

namespace ARControls.bo
{
    public partial class frmProperties : Form
    {
        public frmProperties()
        {
            InitializeComponent();
            tbcPages.TabStop = false;

            if (DesignMode)
            {
                tbcPages.Appearance = TabAppearance.Normal;
                tbcPages.ItemSize = new Size(30, 19);
                tbcPages.SizeMode = TabSizeMode.Normal;
            }
            else
            {
                tbcPages.Appearance = TabAppearance.FlatButtons;
                tbcPages.ItemSize = new Size(0, 1);
                tbcPages.SizeMode = TabSizeMode.Fixed;
            }
        }
    
        public frmProperties(IUsesPropertiesForm owner)
        {
            Populate(owner);
        }

        public static void Show(IUsesPropertiesForm owner)
        {
            frmProperties f = new frmProperties(owner);
            f.ShowDialog();
        }

        private IUsesPropertiesForm mOwner;

        protected void Populate(IUsesPropertiesForm owner)
        {
            mOwner = owner;
            Text = string.Format("{0} Properties", owner.GetType().ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // save and close.
            try
            {
                if (mOwner != null)
                {
                    mOwner.Save();
                    btnCancel_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
