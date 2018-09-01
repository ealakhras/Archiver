using System;
using System.Windows.Forms;
using ARCbusinessTier;

namespace main
{
    public partial class frmDatabasePicker : Form
    {
        public frmDatabasePicker()
        {
            InitializeComponent();
            //foreach (string dbcs in RegistryDome.DBCS)
            foreach(Database database in Dome.Databases)
            {
                ListViewItem lvi = new ListViewItem(new string[] { database.FriendlyName, database.Engine, database.Name });
                lvi.ImageIndex = 0;
                lsvDatabases.Items.Add(lvi);
            }

            lsvDatabases.Items.Add("<new>", 0);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
