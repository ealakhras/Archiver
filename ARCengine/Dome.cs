using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using set;

namespace ARCengine
{
    public static class Dome
    {
        static Dome()
        {
            //mDatabases = new Databases();
        }

        //private static Databases mDatabases;
        private static Database mDefaultDatabase;
        /*
        public static Databases Databases
        {
            get
            {
                return mDatabases;
            }
        }
        */
        public static Database DefaultDatabase
        {
            get
            {
                return mDefaultDatabase;
            }
            set
            {
                mDefaultDatabase = value;
            }
        }

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
