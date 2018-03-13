using System.Windows.Forms;
using ARCengine;


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
        }
        #endregion

        #region methods
        public void Populate()
        {
            BeginUpdate();
            Nodes.Clear();

            foreach (Database database in Dome.Databases)
            {
                DatabaseTreeNode dbTreeNode = new DatabaseTreeNode(database);
                Nodes.Add(dbTreeNode);
            }
            EndUpdate();
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
