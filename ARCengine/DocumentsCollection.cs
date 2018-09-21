using ARCengine.CoreObjects;
using System.Data.SqlClient;


namespace ARCengine
{
    public class DocumentsCollection : CoreCollection
    {
        public DocumentsCollection(Folder folder) : base(typeof(Document))
        {
            mFolder = folder;
        }

        #region members
        private Folder mFolder;
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
                Refresh(true);
                return (Document)List[index];
            }
            set
            {
                List[index] = value;
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
        protected override void Read()
        {
            Clear();
            using (SqlDataReader dr = Database.ExecuteDataReader($"prcDocuments_read @folderID = {mFolder.ID}"))
            {
                Read(dr);
                dr.Close();
            }
        }

        private void Read(SqlDataReader dr)
        {
            while (dr.Read())
            {
                Add(new Document(mFolder, dr));
            }

            if (dr.NextResult() && dr.Read())
            {
                foreach (Document document in List)
                {
                    document.ReadFieldsValues(dr);
                }
            }
        }

        public void Save()
        {
            foreach (Document document in List)
            {
                if(document.IsDirty)
                {
                    document.Save();
                }
            }
        }
        #endregion
    }
}