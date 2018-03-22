using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARCengine
{
    public abstract class DatabaseObject
    {
        #region constructors
        public DatabaseObject()
        {
            mDatabase = Dome.CurrentDatabase;
        }
        #endregion

        #region members
        protected Database mDatabase;
        protected bool mIsDirty;
        protected string mName;
        #endregion

        #region properties
        public Database Database
        {
            get
            {
                return mDatabase;
            }
        }

        public bool IsDirty
        {
            get
            {
                return mIsDirty;
            }
        }
        #endregion

        #region methods
        protected int GetIntFromDataReader(object drField)
        {
            if ((drField != null) && (int.TryParse(drField.ToString(), out int result)))
                return result;

            return 0;
        }

        protected string GetStringFromDataReader(object drField)
        {
            if (drField != null)
                return drField.ToString();

            return string.Empty;
        }

        protected DateTime GetDateTimeFromDataReader(object drField)
        {
            if ((drField != null) && (DateTime.TryParse(drField.ToString(), out DateTime result)))
                return result;

            return DateTime.MinValue;
        }

        public abstract void Read();

        public virtual void Refresh()
        {
            Read();
            mIsDirty = false;
        }
        #endregion
    }
}
