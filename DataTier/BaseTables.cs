using System.Data.SqlClient;

namespace ARCdataTier
{
    public class BaseTable
    {
        public BaseTable(Database database, string tableName)
        {
            mDatabase = database;
            mTableName = tableName;
        }

        protected readonly Database mDatabase;
        protected readonly string mTableName;

        /// <summary>
        /// Formats DataTier procedures parameters into a compatible common string.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected string PrepareParameters(params object[] parameters)
        {
            string result = "";
            foreach (object parameter in parameters)
            {
                if (parameter == null)
                    result += " null,";
                else if (parameter is string)
                {
                    result += " '" + parameter + "',";
                }
                else
                {
                    result += " " + parameter.ToString() + ",";
                }
            }

            // remove last comma, if any:
            return result == "" ? "" : result.Substring(0, result.Length - 1).Trim();
        }

        protected virtual SqlDataReader DoRead(params object[] parameters)
        {
            return DoRead(PrepareParameters(parameters));
        }

        protected virtual SqlDataReader DoRead(string parameters)
        {
            return mDatabase.ExecuteDataReader($"exec prc{mTableName}_read {parameters}");
        }

        /// <summary>
        /// DAL Save.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected virtual SqlDataReader DoSave(params object[] parameters)
        {
            return DoSave(PrepareParameters(parameters));
        }

        protected virtual SqlDataReader DoSave(string parameters)
        {
            return mDatabase.ExecuteDataReader($"exec prc{mTableName}_save {parameters}");
        }

        protected virtual void DoDelete(params object[] parameters)
        {
            DoDelete(PrepareParameters(parameters));
        }

        protected virtual void DoDelete(string parameters)
        {
            mDatabase.ExecuteDataReader($"exec prc{mTableName}_delete {parameters}");
        }
    }

    public class BaseTableWithID : BaseTable
    {
        public BaseTableWithID(Database database, string tableName) : base(database, tableName)
        {

        }

        /// <summary>
        /// DataTier Read.
        /// </summary>
        public virtual SqlDataReader Read(int id = 0)
        {
            return DoRead($"@id={id}");
        }

        public virtual void Delete(int id)
        {
            DoDelete($"@id={id}");
        }
    }

    public class BaseTableWithParentID: BaseTableWithID
    {
        public BaseTableWithParentID(Database database, string tableName) : base(database, tableName)
        {

        }

        public virtual SqlDataReader Read(int id = 0, int parentID = 0)
        {
            return DoRead($"@id={id}, @parentID={parentID}");
        }
    }
}