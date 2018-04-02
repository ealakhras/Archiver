using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;

namespace bal
{
    public class BaseCollection : CollectionBase
    {
        #region constructors
        public BaseCollection(object owner)
            : base()
        {
            mOwner = owner;
        }
        #endregion

        #region members
        protected object mOwner;
        #endregion

        #region properties
        public object this[int index]
        {
            get
            {
                return List[index];
            }
            set
            {
                List[index] = value;
            }
        }
        #endregion

        #region methods
        public virtual void Add(object item)
        {
            List.Add(item);
        }

        public virtual void AddRange(object[] items)
        {
            foreach (object i in items)
                Add(i);
        }

        public virtual void Remove(object item)
        {
            List.Remove(item);
        }

        public virtual int IndexOf(object item)
        {
            return List.IndexOf(item);
        }

        public virtual bool Contains(object item)
        {
            return List.Contains(item);
        }

        public virtual void Insert(int index, object item)
        {
            List.Insert(index, item);
        }

        public virtual void Populate()
        {
        }

        protected virtual void Populate(SqlDataReader dr = null)
        {
        }
        #endregion
    }
}
