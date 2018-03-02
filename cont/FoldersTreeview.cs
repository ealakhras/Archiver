using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bal;

namespace cont
{
    public partial class FoldersTreeview : TreeView
    {
        public FoldersTreeview()
        {
            InitializeComponent();
            HideSelection = false;
            ShowNodeToolTips = true;
        }

        public void Populate()
        {
            //FoldersCollection fc = new FoldersCollection();
            //fc.
        }

        public void Populate(Folder rootFolder)
        {
            BeginUpdate();
            Nodes.Clear();
            FolderTreeNode root = new FolderTreeNode(rootFolder);
            Populate(root);
            Nodes.Add(root);
            SelectedNode = root;
            root.EnsureVisible();
            EndUpdate();
        }

        private void Populate(FolderTreeNode parentNode)
        {
            foreach (Folder folder in parentNode.Folder.SubFolders)
            {
                FolderTreeNode tn = new FolderTreeNode(folder);
                Populate(tn);
                parentNode.Nodes.Add(tn);
            }
            parentNode.Expand();
        }
    }

    public class FolderTreeNode : TreeNode
    {
        public FolderTreeNode(Folder folder)
        {
            mFolder = folder;
            Text = folder.Name;
            ToolTipText = folder.Description;
        }

        private Folder mFolder;

        public Folder Folder
        {
            get
            {
                return mFolder;
            }
        }
    }
}
