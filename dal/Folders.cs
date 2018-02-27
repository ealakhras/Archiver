using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dal
{
    public class Folders : BaseTable
    {
        public Folders()
            : base("Folders")
        {
        }

        public SqlDataReader Save(int id, int parentID, string name, string description = null)
        {
            return base.Save(id, parentID, name, description);
        }

        public void Delete(int id)
        {
            base.Delete(id);
        }

        public SqlDataReader Read(int id = 0, int parentID = 0)
        {
            return base.Read(id, parentID);
        }

        public SqlDataReader Tree()
        {
            return base.ExecuteDataReader("exec prcFolders_tree");
        }
    }
}
