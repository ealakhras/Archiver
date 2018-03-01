using System.Data.SqlClient;

namespace dal
{
    public class Folders : BaseTable
    {
        #region constructors
        public Folders()
            : base("Folders")
        {
        }
        #endregion

        #region methods
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

        public SqlDataReader Children(object id = null)
        {
            return base.ExecuteDataReader("exec prcFolders_children {0}", id);
        }
        #endregion
    }
}
