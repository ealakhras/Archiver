using System.Data.SqlClient;

namespace ARCdataTier
{
    public class LOVs: BaseTableWithID
    {
        public LOVs(Database database):base(database, "lovs")
        {

        }

        public SqlDataReader Save(int id, string name, string vals, string description = "")
        {
            return DoSave(
                        $"@id={id}, " +
                        $"@name='{name}', " +
                        $"@vals='{vals}', " +
                        $"@description='{description}'");
        }
    }
}