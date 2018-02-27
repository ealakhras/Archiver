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
        protected bool mIsDirty;

        public bool IsDirty
        {
            get
            {
                return mIsDirty;
            }
        }

        public BaseObject()
        {
            mIsDirty = true;
        }

        protected abstract void InitFromDataReader(SqlDataReader dr);

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
    }
}
