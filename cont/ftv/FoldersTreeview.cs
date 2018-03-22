using System;
using System.Windows.Forms;
using System.ComponentModel;
using ARCengine;
using set;

namespace cont
{
    public partial class FoldersTreeview : TreeView
    {
        #region constructors
        public FoldersTreeview()
        {
            InitializeComponent();
            HideSelection = false;
            ShowNodeToolTips = true;
            mTimer = new Timer();
            mTimer.Interval = RegistryDome.FoldersTreeViewInterval;
            mTimer.Tick += new System.EventHandler(timer_Tick);
        }
        #endregion

        #region members
        Timer mTimer;

        [Category("Action")]
        [Description("Fires after Interval passes from last Folder Change")]
        public event TreeViewEventHandler FolderChanged;
        #endregion

        #region methods
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            base.OnAfterSelect(e);

            // reset timer:
            mTimer.Stop();
            mTimer.Start();
        }

        protected virtual void OnFolderChanged(TreeViewEventArgs e)
        {
            // invoke event handler:
            FolderChanged?.Invoke(this, e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // stop timer:
            mTimer.Stop();

            // trigger event:
            OnFolderChanged(new TreeViewEventArgs(SelectedNode));
        }

        public void Populate()
        {
            try
            {
                BeginUpdate();
                Nodes.Clear();
                foreach (Database database in Dome.Databases)
                {
                    DatabaseTreeNode dbTreeNode = new DatabaseTreeNode(database);
                    Nodes.Add(dbTreeNode);
                }
            }
            finally
            {
                EndUpdate();
            }
        }

        public void Populate(Folder rootFolder)
        {
            BeginUpdate();
            Nodes.Clear();
            FolderTreeNode rootNode = new FolderTreeNode(rootFolder);
            Populate(rootNode);
            Nodes.Add(rootNode);
            SelectedNode = rootNode;
            rootNode.EnsureVisible();
            EndUpdate();
        }

        private void Populate(FolderTreeNode parentNode)
        {
            foreach (Folder folder in parentNode.Folder.SubFolders)
            {
                FolderTreeNode node = new FolderTreeNode(folder);
                Populate(node);
                parentNode.Nodes.Add(node);
            }
            parentNode.Expand();
        }
        #endregion
    }
}
