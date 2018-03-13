using System.Windows.Forms;
using System.Data;
using ARCengine;

namespace cont
{
    public class DatabaseTreeNode : TreeNode
    {
        public DatabaseTreeNode(Database database)
        {
            mDatabase = database;
            Init();
        }

        private Database mDatabase;

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

        public Database Database
        {
            get
            {
                return mDatabase;
            }
        }

        public void Refresh()
        {
            mDatabase.Refresh();
            Init();
        }
    }
}