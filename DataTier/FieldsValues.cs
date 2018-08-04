using System.Data.SqlClient;

namespace ARCdataTier
{
    public class FieldsValues:BaseTable
    {
        public FieldsValues(Database database):base(database, "fieldsValues")
        {

        }

        public SqlDataReader Read(int documentID = 0, int fieldID = 0)
        {
            return DoRead(new object[] { documentID, fieldID });
        }

        public SqlDataReader Save(int documentID, int fieldID, string value)
        {
            return DoSave(
                        $"@documentID={documentID}, " +
                        $"@fieldID={fieldID}, " +
                        $"@value='{value}'");
        }

        public void Delete(int documentID, int fieldID)
        {
            DoDelete(
                    $"@documentID={documentID}, " +
                    $"@fieldID={fieldID}");
        }
    }
}
