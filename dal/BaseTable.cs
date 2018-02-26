using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dal
{
    public class BaseTable
    {
        protected string mTableName;

        public BaseTable(string tableName)
        {
            mTableName = tableName;
        }

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

        protected SqlDataReader Insert(params object[] parameters)
        {
            string sql = string.Format("exec prc{0}_insert {1}", mTableName, PrepareParameters(parameters));
            return DataDome.ExecuteDataReader(sql);
        }

        protected int Delete(params object[] parameters)
        {
            string sql = string.Format("exec prc{0}_delete {1}", mTableName, PrepareParameters(parameters));
            return DataDome.ExecuteNonQuery(sql);
        }

        protected SqlDataReader Update(params object[] parameters)
        {
            string sql = string.Format("exec prc{0}_update {1}", mTableName, PrepareParameters(parameters));
            return DataDome.ExecuteDataReader(sql);
        }

        protected SqlDataReader Select(params object[] parameters)
        {
            string sql = string.Format("exec prc{0}_select {1}", mTableName, PrepareParameters(parameters));
            return DataDome.ExecuteDataReader(sql);
        }
    }
}
