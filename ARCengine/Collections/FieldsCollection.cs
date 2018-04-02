using System;
using System.Collections;
using System.Data.SqlClient;

namespace ARCengine.Collections
{
    public class FieldsCollection : CollectionBase
    {
        public FieldsCollection(Folder folder)
        {
            mFolder = folder;
            mNeedsRefreshing = true;
        }

        #region members
        private Folder mFolder;
        private bool mNeedsRefreshing;
        #endregion

        #region properties
        public Folder Folder
        {
            get
            {
                return mFolder;
            }
        }

        public Database Database
        {
            get
            {
                return mFolder.Database;
            }
        }

        public Field this[int index]
        {
            get
            {
                if (mNeedsRefreshing)
                {
                    Read();
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
        public override string ToString()
        {
            return base.ToString();
        }

        public void Add(Field field)
        {
            List.Add(field);
        }

        /// <summary>
        /// populates fields from Database.
        /// </summary>
        public void Read()
        {
            Clear();
            SqlDataReader dr = Database.ExecuteDataReader("exec prcFields_read @folderID = {0}", mFolder.ID);
            Read(dr);
            dr.Close();
        }

        private void Read(SqlDataReader dr)
        {
            while (dr.Read())
            {
                Add(new Field(mFolder, dr));
            }
            mNeedsRefreshing = false;
        }

        public void Save()
        {
            foreach (Field field in List)
            {
                if(field.NeedsSaving)
                {
                    field.Save();
                }
            }
        }

        public void Refresh()
        {
            Read();
        }
        #endregion
    }
}
