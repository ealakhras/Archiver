using System.Data.SqlClient;

namespace ARCdataTier
{
    public class Fields : BaseTableWithID
    {
        public Fields(Database database) : base(database, "fields")
        {

        }

        public SqlDataReader Read(int id = 0, int folderID = 0)
        {
            return DoRead(new object[] { id, folderID });
        }

        public SqlDataReader Save(int id, int folderID, string name, string description, char type, string defVal, int width, char alignment, int lovID, int ord)
        {
            // type should be in ('L' 'Y' 'D' 'N' 'T')
            // alignment in ('R', 'L', 'C')
            return DoSave(
                        $"@id={id}, " +
                        $"@folderID={folderID}, " +
                        $"@name='{name}', " +
                        $"@description='{description}', " +
                        $"@type='{type}', " +
                        $"@defVal='{defVal}', " +
                        $"@width={width}, " +
                        $"@alignment='{alignment}', " +
                        $"@lovID={lovID}, " +
                        $"@ord={ord}");
        }
    }
}
