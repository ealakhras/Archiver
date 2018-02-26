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

        public SqlDataReader Insert(int parentID, string name, string description = null)
        {
            return base.Insert(parentID, name, description);
        }

        public int Delete(int id)
        {
            return base.Delete(id);
        }

        public SqlDataReader Update(int id, int parentID, string name, string description = null)
        {
            return base.Update(id, parentID, name, description);
        }

        public SqlDataReader Select(int id = 0, int parentID = 0)
        {
            return base.Select(id, parentID);
        }
    }
}
