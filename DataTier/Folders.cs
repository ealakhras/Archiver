using System;
using System.Data.SqlClient;

namespace ARCdataTier
{
    public class Folders: BaseTableWithParentID
    {
        public Folders(Database database) : 
            base(database, "Folders")
        {

        }

        public SqlDataReader Save(int id, int parentID, string name, string description, int imageIndex, bool inheritsFields)
        {
            return DoSave(
                        $"@id={id}, " +
                        $"@parentID={parentID}, " +
                        $"@name='{name}', " +
                        $"@description='{description}', " +
                        $"@imageIndex={imageIndex}, " +
                        $"@inheritsFields={(inheritsFields ? 1 : 0)}");
        }
    }
}
