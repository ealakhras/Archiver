using System;
using System.Windows.Forms;
using dal;
using bal;

namespace main
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            treeView1.ExpandAll();
            treeView1.SelectedNode = treeView1.Nodes[0];
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
            Folder folder = new Folder(9);

            folder.ParentID = 7;
            folder.Name = "Jojo";
            folder.Save();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Folder f = new Folder(1);


        }
    }
}
