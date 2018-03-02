using System;
using System.Windows.Forms;
using bal;
using dal;
using set;

namespace main
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            listView1.Items[0].Selected = true;
            listView2.Items[0].Selected = true;
        }

        public frmMain(string[] args)
            : this()
        {
            ParseStartupArgs(args);
            try
            {
                DataDome.Connect();
                tslDBEngine.Text = DataDome.DBEngine;
                tslDBName.Text = DataDome.DBName;
                ftvFolders.Populate();
            }
            catch
            {

            }
        }

        private string GetStartupArgsHelp()
        {
            string result = "startup arguments:" + '\n' + '\n';
            result += @"/? or -help   " + '\t' + "shows this message box." + '\n';
            result += @"/cs:""<connStr>""" + '\t' + "passes db connStr and auto-connects." + '\n';
            result += @"/d or /debug" + '\t' + "set debug mode ON." + '\n';
            result += @"/-d or /-debug" + '\t' + "set debug mode OFF." + '\n';
            return result;
        }

        private void ParseStartupArgs(string[] args)
        {
            if (args.Length == 0)
                return;

            foreach (string arg in args)
            {
                if (arg == "/?" || arg == "/help")
                {
                    MessageBox.Show(GetStartupArgsHelp(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (arg.StartsWith("/cs:"))
                {
                    RegistryDome.DBConnectionString = arg.Substring(4);
                }
                else if (arg == "/d" || arg == "/debug")
                {
                    RegistryDome.Debug = true;
                }
                else if (arg == "/-d" || arg == "/-debug")
                {
                    RegistryDome.Debug = false;
                }
            }
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
