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
            mDatabases = new DatabaseCollection();
            mDatabases.Init();
        }

        private static DatabaseCollection mDatabases;
        private static Database mDefaultDatabase;
        
        public static DatabaseCollection Databases
        {
            get
            {
                return mDatabases;
            }
        }
        
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
    }
}
