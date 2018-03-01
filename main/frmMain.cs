using System;
using System.Windows.Forms;
using bal;
using dal;

namespace main
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            listView1.Items[0].Selected = true;
            listView2.Items[0].Selected = true;
            DataDome.ConnectTo("Integrated Security=SSPI;Persist Security Info=False;User ID='';Initial Catalog=archiver;Data Source=.;Initial File Name=''");
        }

        public frmMain(string[] args) : this()
        {
        }

        private void mniClose_Click(object sender, EventArgs e) => Close();

        private void mniAbout_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stsMain.Visible = mniViewStatusbar.Checked;
        }

        private void mniViewToolbar_Click(object sender, EventArgs e)
        {
            tstMain.Visible = mniViewToolbar.Checked;
        }

        private void mniViewFolders_Click(object sender, EventArgs e)
        {
            spcHorizontalLeft.Panel1Collapsed = !mniViewFolders.Checked;
        }

        private void mniViewActions_Click(object sender, EventArgs e)
        {
            spcHorizontalRight.Panel2Collapsed = !mniViewPreview.Checked;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Folder f = new Folder(1);
            f.SubFolders.Populate();
            ftvFolders.Populate(f);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Folder f = new Folder(14);
            f.SubFolders.Populate();
            ftvFolders.Populate(f);
        }
    }
}
