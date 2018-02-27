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

        private string FormatParameters(params object[] parameters)
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

        protected SqlDataReader Read(params object[] parameters)
        {
            return DataDome.ExecuteDataReader("exec prc{0}_read {1}", mTableName, FormatParameters(parameters));
        }

        protected SqlDataReader Save(params object[] parameters)
        {
            return DataDome.ExecuteDataReader("exec prc{0}_save {1}", mTableName, FormatParameters(parameters));
        }

        protected void Delete(params object[] parameters)
        {
            DataDome.ExecuteNonQuery("exec prc{0}_delete {1}", mTableName, FormatParameters(parameters));
        }

        protected SqlDataReader ExecuteDataReader(string sql, params object[] parameters)
        {
            return DataDome.ExecuteDataReader(sql, parameters);
        }

        protected int ExecuteNonQuery(string sql, params object[] parameters)
        {
            return DataDome.ExecuteNonQuery(sql, parameters);
        }
    }
}
