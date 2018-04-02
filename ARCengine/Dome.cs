using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARCengine.Collections;

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
        private static Database mCurrentDatabase;
        
        public static DatabaseCollection Databases
        {
            get
            {
                return mDatabases;
            }
        }
        
        public static Database CurrentDatabase
        {
            get
            {
                return mCurrentDatabase;
            }
            set
            {
                mCurrentDatabase = value;
            }
        }
    }
}
