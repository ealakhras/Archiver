using System.Windows.Forms;
using ARCengine;


namespace ARControls
{
    public class FolderTreeNode: DatabaseObjectTreeNode
    {
        #region constructors
        public FolderTreeNode(Folder folder)
            : base(folder.Database)
        {
            mFolder = folder;
            Init();
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

        #region methods
        private void Init()
        {
            Text = mFolder.Name;
            ToolTipText = mFolder.Description;
            ImageIndex = mFolder.ImageIndex;
            SelectedImageIndex = ImageIndex;
            Nodes.Clear();
            foreach (Folder subFolder in mFolder.SubFolders)
            {
                Nodes.Add(new FolderTreeNode(subFolder));
            }
        }

        public void Refresh()
        

{
            mFolder.Refresh();
            Init();
        }

        public override string ToString()
        {
            return mFolder.ToString();
        }
        #endregion
    }
}
