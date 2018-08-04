using System.Data.SqlClient;

namespace ARCdataTier
{
    public class Documents : BaseTableWithID
    {
        public Documents(Database database) : base(database, "documents")
        {

        }

        public SqlDataReader Read(int id = 0, int folderID = 0)
        {
            return DoRead(new object[] { id, folderID });
        }

        public virtual SqlDataReader Save(int id, int folderID, string name, string description)
        {
            return DoSave(
                        $"@id={id}, " +
                        $"@folderID={folderID}, " +
                        $"@name='{name}', " +
                        $"@description='{description}'");
        }
    }
}