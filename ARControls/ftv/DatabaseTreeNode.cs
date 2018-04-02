using System.Data;
using ARCengine;

namespace ARControls
{
    public class DatabaseTreeNode : DatabaseObjectTreeNode
    {
        #region constructors
        public DatabaseTreeNode(Database database)
            : base(database)
        {
            Init();
        }
        #endregion

        #region methods
        private void Init()
        {
            Text = mDatabase.FriendlyName;
            ToolTipText = mDatabase.ToString();
            ImageIndex = mDatabase.State == ConnectionState.Open ? 0 : 1;
            SelectedImageIndex = ImageIndex;
            Nodes.Clear();
            foreach (Folder folder in mDatabase.Folders)
            {
                Nodes.Add(new FolderTreeNode(folder));
            }
        }

        public void Refresh()
        {
            mDatabase.Refresh();
            Init();
        }
        #endregion
    }
}