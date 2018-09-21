using ARCengine.CoreObjects;
using System.Data.SqlClient;

namespace ARCengine
{
    public class FieldsCollection : CoreCollection
    {
        public FieldsCollection(Folder folder) : base(typeof(Field))
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
        public Field this[int index]
        {
            get
            {
                Refresh(true);
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
        protected override void Read()
        {
            Clear();
            using (SqlDataReader dr = Database.ExecuteDataReader($"exec prcFields_read @folderID = {mFolder.ID}"))
            {
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
        #endregion
    }
}
