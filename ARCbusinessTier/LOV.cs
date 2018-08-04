using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARCdataTier;

namespace ARCbusinessTier
{
    public class LOV: BaseObjectWithID
    {
        #region constructors
        public LOV() : base()
        {

        }

        public LOV(Database database) : base(database)
        {

        }

        public LOV(Database database, int id) : base(database, id)
        {

        }

        public LOV(int id, string name, string description = "", string vals = "")
        {
            Init(id, name, description);
            Init(vals);
        }
        #endregion

        #region members
        private string mVals;
        #endregion

        #region properties
        public string Vals
        {
            get
            {
                return mVals;
            }
            set
            {
                if(mVals == value)
                {
                    return;
                }
                mVals = value;
                mIsDirty = true;
            }
        }
        #endregion

        #region methods
        protected override void InitDatabase(Database database)
        {
            base.InitDatabase(database);
            mTable = mDatabase.LOVs;
        }

        private void Init(string vals)
        {
            mVals = vals;
        }

        protected override void Init(SqlDataReader dr)
        {
            base.Init(dr);
            Init(GetStringFromDataReader(dr["vals"]));
        }

        protected override void DoSave()
        {
            using (SqlDataReader dr = ((ARCdataTier.LOVs)mTable).Save(mID, mName, mVals, mDescription))
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
            return $"{base.ToString()}\n" +
                    $"Vals: '{mVals}'";
        }
        #endregion
    }
}
