using System;
using System.Collections;
using System.Data.SqlClient;

namespace ARCengine
{
    public class FieldsCollection : CollectionBase
    {
        public FieldsCollection(Folder owner)
        {
            mOwner = owner;
            mIsDirty = true;
        }

        #region members
        private Folder mOwner;
        private bool mIsDirty;
        #endregion

        #region properties
        public Folder Owner
        {
            get
            {
                return mOwner;
            }
        }

        public Database Database
        {
            get
            {
                return mOwner.Database;
            }
        }

        public Field this[int index]
        {
            get
            {
                if (mIsDirty)
                {
                    Populate();
                }
                return (Field)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
        #endregion

        #region methods
        public void Add(Field field)
        {
            List.Add(field);
        }

        /// <summary>
        /// populates fields.
        /// </summary>
        public void Populate()
        {
            Clear();
            SqlDataReader dr = Database.ExecuteDataReader("exec prcFields_read @folderID = {0}", mOwner.ID);
            Populate(dr);
            dr.Close();
            mIsDirty = false;
        }

        protected virtual void Populate(SqlDataReader dr)
        {
            while (dr.Read())
            {
                Add(new Field(mOwner, dr));
            }
        }

        protected virtual void Save()
        {
            foreach (Field field in List)
            {
                if(field.IsDirty)
                {
                    field.Save();
                }
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
