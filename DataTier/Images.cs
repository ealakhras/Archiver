using System.Data.SqlClient;
using System.IO;

namespace ARCdataTier
{
    public class Images : BaseTableWithID
    {
        public Images(Database database) : base(database, "images")
        {

        }

        public SqlDataReader Read(int id = 0, int documentID = 0)
        {
            return DoRead(new object[] { id, documentID });
        }

        public SqlDataReader Save(int id, int documentID, string name, string description,  Stream data, Stream thumbnail, string fileName1, string fileName2, string notesDetails, int ord)
        {
            return DoSave(
                        $"@id={id}, " +
                        $"@documentID={documentID}, " +
                        $"@name='{name}', " +
                        $"@description='{description}', " +
                        $"@data={data}" +
                        $"@thumbnail={thumbnail}" +
                        $"@fileName1='{fileName1}'" +
                        $"@fileName2='{fileName2}'" +
                        $"@notesDetails='{notesDetails}'" +
                        $"@ord={ord}");
        }
    }
}