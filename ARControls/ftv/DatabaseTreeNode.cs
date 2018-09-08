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
            ImageIndex = GetImageIndex(mDatabase.State);
            SelectedImageIndex = ImageIndex;
            Nodes.Clear();
            foreach (Folder folder in mDatabase.Folders)
            {
                Nodes.Add(new FolderTreeNode(folder));
            }
        }

        private int GetImageIndex(DatabaseStateEnum state)
        {
            switch (state)
            {
                case DatabaseStateEnum.Initializing:
                    return 0;

                case DatabaseStateEnum.Ready:
                    return 1;

                case DatabaseStateEnum.ErrorInConnectionString:
                    return 2;

                case DatabaseStateEnum.ErrorInDBStructure:
                    return 3;

                case DatabaseStateEnum.Opened:
                    return 4;

                case DatabaseStateEnum.Closed:
                    return 5;

                default:
                    return 0;
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