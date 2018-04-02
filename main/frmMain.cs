using System;
using System.ComponentModel;
using System.Windows.Forms;
using ARCengine;
using ARControls;
using ARCettings;

namespace main
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            Dome.Databases.Init();
            ftvFolders.Populate();
        }

        public frmMain(string[] args)
            : this()
        {
            ParseStartupArgs(args);
            try
            {
            }
            catch
            {
                throw;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadUI();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            SaveUI();
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
                    //RegistryDome.DBConnectionString = arg.Substring(4);
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
            spcLeft.Panel1Collapsed = !mniViewFolders.Checked;
        }

        private void mniViewActions_Click(object sender, EventArgs e)
        {
            spcRight.Panel2Collapsed = !mniViewPreview.Checked;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            /*
            Folder f = new Folder(1);
            f.SubFolders.Populate();
            ftvFolders.Populate(f);
            */
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            /*
            Folder f = new Folder(14);
            f.SubFolders.Populate();
            ftvFolders.Populate(f);
            */
        }

        private void LoadUI()
        {
            WindowState = RegistryDome.WindowsState;
            if (WindowState == FormWindowState.Normal)
            {
                Size = RegistryDome.WindowSize;
            }
            spcLeft.SplitterDistance = RegistryDome.SplitLeftDist;
            spcRight.SplitterDistance = RegistryDome.SplitRightDist;
            spcVertical.SplitterDistance = RegistryDome.SplitVertDist;
            mniViewToolbar.Checked = RegistryDome.ViewToolbar;
            mniViewFolders.Checked = RegistryDome.ViewFolders;
            mniViewPreview.Checked = RegistryDome.ViewPreview;
            mniViewStatusbar.Checked = RegistryDome.ViewStatusBar;
            spcLeft.SplitterWidth = RegistryDome.SplitterWidth;
            spcRight.SplitterWidth = spcLeft.SplitterWidth;
            spcVertical.SplitterWidth = spcLeft.SplitterWidth;
        }

        private void SaveUI()
        {
            RegistryDome.WindowsState = WindowState;
            if (WindowState == FormWindowState.Normal)
            {
                RegistryDome.WindowSize = Size;
            }
            RegistryDome.SplitLeftDist = spcLeft.SplitterDistance;
            RegistryDome.SplitRightDist = spcRight.SplitterDistance;
            RegistryDome.SplitVertDist = spcVertical.SplitterDistance;
            RegistryDome.ViewToolbar = mniViewToolbar.Checked;
            RegistryDome.ViewFolders = mniViewFolders.Checked;
            RegistryDome.ViewPreview = mniViewPreview.Checked;
            RegistryDome.ViewStatusBar = mniViewStatusbar.Checked;
        }

        private void mniOpenDatabase_Click(object sender, EventArgs e)
        {
            frmDatabasePicker f = new frmDatabasePicker();
            f.ShowDialog();
        }

        private void ftvFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tslDBEngine.Text = ((DatabaseObjectTreeNode)e.Node).Database.Engine;
            tslDBName.Text = ((DatabaseObjectTreeNode)e.Node).Database.Name;
        }

        private void ftvFolders_FolderChanged(object sender, TreeViewEventArgs e)
        {
            MessageBox.Show(e.Node.Text);
        }
    }
}
