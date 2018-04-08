using System.Collections;
using System.Data.SqlClient;


namespace ARCengine.Collections
{
    public class DocumentsCollection : CollectionBase
    {
        public DocumentsCollection(Folder folder)
        {
            mFolder = folder;
            mNeedsRefreshing = false;
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

        public Document this[int index]
        {
            get
            {
                if (mNeedsRefreshing)
                {
                    Read();
                }
                return (Document)List[index];
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
        public void Add(Document document)
        {
            List.Add(document);
        }

        /// <summary>
        /// populates fields from Database.
        /// </summary>
        private void Read()
        {
            Clear();
            SqlDataReader dr = Database.ExecuteDataReader("exec prcDocuments_read @folderID = {0}", mFolder.ID);
            Read(dr);
            dr.Close();
        }

        private void Read(SqlDataReader dr)
        {
            while (dr.Read())
            {
                Add(new Document(mFolder, dr));
            }
            mNeedsRefreshing = false;
        }

        public void Save()
        {
            foreach (Document document in List)
            {
                if(document.NeedsSaving)
                {
                    document.Save();
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