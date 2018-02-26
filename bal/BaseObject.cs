using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal;

namespace bal
{
    public class BaseObject
    {
        protected bool mIsDirty;
        protected BaseTable mBaseTable;

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

        public virtual void Save()
        {
            mIsDirty = false;
        }
    }
}
