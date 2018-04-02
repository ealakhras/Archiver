using System.Windows.Forms;
using ARCengine;

namespace ARControls
{
    public class DatabaseObjectTreeNode: TreeNode
    {
        #region constructors
        public DatabaseObjectTreeNode(Database database)
        {
            mDatabase = database;
        }
        #endregion

        #region members
        protected Database mDatabase;
        #endregion

        #region properties
        public Database Database
        {
            get
            {
                return mDatabase;
            }
        }
        #endregion
    }
}
