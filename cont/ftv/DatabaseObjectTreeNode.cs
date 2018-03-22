using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARCengine;

namespace cont
{
    public class DatabaseObjectTreeNode: TreeNode
    {
        public DatabaseObjectTreeNode(Database database)
        {
            mDatabase = database;
        }

        protected Database mDatabase;

        public Database Database
        {
            get
            {
                return mDatabase;
            }
        }
    }


}
