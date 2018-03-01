using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dal;

namespace bal
{
    public abstract class BaseObject
    {
        #region constructors
        public BaseObject()
        {
            mIsDirty = true;
        }
        #endregion

        #region members
        protected bool mIsDirty;
        #endregion

        #region properties
        public bool IsDirty
        {
            get
            {
                return mIsDirty;
            }
        }
        #endregion

        #region methods
        protected abstract void InitFromDataReader(SqlDataReader dr);

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

        public virtual void Save()
        {
            mIsDirty = false;
        }

        public virtual void Delete()
        {
            mIsDirty = true;
        }

        public virtual void Refresh()
        {
            mIsDirty = false;
        }
        #endregion
    }
}
