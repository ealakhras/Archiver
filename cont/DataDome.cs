using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using set;

namespace con
{
    public static class DataDome
    {
        public static void Init()
        {
            string[] connectionStrings = RegistryDome.DBCS;

            //mDatabases.Clear();
            foreach (string conStr in connectionStrings)
            {
                //mDatabases.Add(conStr);
            }
        }
    }
}
