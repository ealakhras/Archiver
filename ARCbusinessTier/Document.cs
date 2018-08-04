using ARCdataTier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARCbusinessTier
{
    public class Document : BaseObjectWithID
    {
        #region constructors
        public Document() : base()
        {

        }

        public Document(Database database) : base(database)
        {

        }

        public Document(Database database, int id) : base(database, id)
        {

        }

        public Document(int id, int folderID, string name, string description = "")
        {
            Init(id, name, description);
            Init(folderID);
        }
        #endregion

        #region members
        private int mFolderID;
        #endregion

        #region methods
        protected override void InitDatabase(Database database)
        {
            base.InitDatabase(database);
            mTable = mDatabase.Documents;
        }

        private void Init(int folderID)
        {
            mFolderID = folderID;
        }

        protected override void Init(SqlDataReader dr)
        {
            base.Init(dr);
            Init(GetIntFromDataReader(dr["folderID"]));
        }

        protected override void DoSave()
        {
            using (SqlDataReader dr = ((ARCdataTier.Documents)mTable).Save(mID, mFolderID, mName, mDescription))
            {
                if (dr.Read())
                {
                    Init(dr);
                }
                dr.Close();
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nFolderID: {mFolderID}";
        }
        #endregion
    }
}
