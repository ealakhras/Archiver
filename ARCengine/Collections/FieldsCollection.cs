using System.Collections;
using System.Data.SqlClient;

namespace ARCengine.Collections
{
    public class FieldsCollection : CollectionBase
    {
        public FieldsCollection(Folder folder)
        {
            mFolder = folder;
            mFolderID = folder.ID;
            mNeedsRefreshing = true;
        }

        #region members
        private int mFolderID;
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
        public bool NeedsRefreshing
        {
            get
            {
                return mNeedsRefreshing;
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
        private void Read()
        {
            Clear();
            if (mFolder.InheritsFields)
            {
                foreach (Field field in ((Folder)mFolder.Parent).Fields)
                {
                    Add(field);
                }
            }
            else
            {
                SqlDataReader dr = Database.ExecuteDataReader($"exec prcFields_read @folderID = {mFolderID}, @showInherited = 1");
                Read(dr);
                dr.Close();
            }
        }

        private void Read(SqlDataReader dr)
        {
            while (dr.Read())
            {
                Add(new Field(mFolder, dr));
            }
        }

        public void Save()
        {
            foreach (Field field in List)
            {
                if(field.IsDirty)
                {
                    field.Save();
                }
            }
        }

        protected override void OnClear()
        {
            base.OnClear();
            mNeedsRefreshing = false;
        }

        public void Refresh()
        {
            Read();
        }
        #endregion
    }
}
