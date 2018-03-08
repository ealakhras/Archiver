using System.Windows.Forms;
using bal;

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
            /*
            FoldersCollection rootsFolders = new FoldersCollection(null);
            rootsFolders.Populate();

            BeginUpdate();
            Nodes.Clear();
            foreach (Folder rootFolder in rootsFolders)
            {
                FolderTreeNode root = new FolderTreeNode(rootFolder);
                Populate(root);
                Nodes.Add(root);
            }
            EndUpdate();
            */
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


    public class DatabaseTreeNode : TreeNode
    {
        public DatabaseTreeNode(Daa)
        {

        }
    }

    public class FolderTreeNode : TreeNode
    {
        #region constructors
        public FolderTreeNode(Folder folder)
        {
            mFolder = folder;
            Text = folder.Name;
            ToolTipText = folder.Description;
        }
        #endregion

        #region members
        private Folder mFolder;
        #endregion

        #region properties
        public Folder Folder
        {
            get
            {
                return mFolder;
            }
        }
        #endregion
    }
}
