using System.Data.SqlClient;

namespace ARCengine
{
    public class LOV: CoreTableWithID
    {
        #region constructors
        public LOV(): base("LOV")
        {

        }

        public LOV(Database database):this()
        {
            Database = database;
        }

        public LOV(Database database, int id):this(database)
        {
            mID = id;
            Read();
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
        protected override SqlParameterCollection GetSaveParameters()
        {
            SqlParameterCollection result = base.GetSaveParameters();
            AddParam(result, "@vals", SqlParamTypes.String, mVals);
            return result;
        }

        protected override void Init(SqlDataReader dr)
        {
            base.Init(dr);
            mVals = GetStringFromDataReader(dr["vals"]);
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                    $"Vals: '{mVals}'";
        }
        #endregion
    }
}