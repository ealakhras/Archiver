using ARCdataTier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARCbusinessTier
{
    public class Field : BaseObjectWithID
    {
        #region constructors
        public Field() : base()
        {

        }

        public Field(Database database) : base(database)
        {

        }

        public Field(Database database, int id) : base(database, id)
        {

        }

        public Field(int id, int folderID, string name, string description = "", char type = 'T', string defVal = "", int width = 60, char alignment = 'L', int lovID = 0, int ord = 0)
        {
            Init(id, name, description);
            Init(folderID, type, defVal, alignment, width, lovID, ord);
        }
        #endregion

        #region members
        private int mFolderID;
        private char mType;
        private string mDefVal;
        private int mWidth;
        private char mAlignemnt;
        private int mLOVID;
        private int mOrd;
        #endregion

        #region methods
        protected override void InitDatabase(Database database)
        {
            base.InitDatabase(database);
            mTable = mDatabase.Fields;
        }

        protected override void DoSave()
        {
            using (SqlDataReader dr = ((ARCdataTier.Fields)mTable).Save(mID, mFolderID, mName, mDescription, mType, mDefVal, mWidth, mAlignemnt, mLOVID, mLOVID))
            {
                if (dr.Read())
                {
                    Init(dr);
                }
                dr.Close();
            }
        }

        private void Init(int folderID, char type, string defVal, char alignment, int width, int lovID, int ord)
        {
            mFolderID = folderID;
            mType = type;
            mDefVal = defVal;
            mAlignemnt = alignment;
            mWidth = width;
            mLOVID = lovID;
            mOrd = ord;
        }

        protected override void Init(SqlDataReader dr)
        {
            base.Init(dr);
            Init(
                GetIntFromDataReader(dr["folderID"]),
                GetCharFromDataReader(dr["type"]),
                GetStringFromDataReader(dr["defVal"]),
                GetCharFromDataReader(dr["alignment"]),
                GetIntFromDataReader(dr["width"]),
                GetIntFromDataReader(dr["lovID"]),
                GetIntFromDataReader(dr["ord"]));
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                                $"FolderID: {mFolderID}\n" +
                                $"Type: '{mType}'\n" +
                                $"DefVal: '{mDefVal}\n" +
                                $"Aligment: '{mAlignemnt}'\n" +
                                $"Width: {mWidth}\n" +
                                $"lovID: {mLOVID}\n" +
                                $"Ord: {mOrd}";
        }
        #endregion
    }
}