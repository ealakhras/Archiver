using System.Collections;
using set;

namespace ARCengine
{
    public class DatabaseCollection : CollectionBase
    {
        #region constructors
        public DatabaseCollection()
            : base()
        {
        }
        #endregion

        #region properties
        public Database this[int index]
        {
            get
            {
                return (Database)List[index];
            }
        }
        #endregion

        #region methods
        public void Add(Database item)
        {
            List.Add(item);
        }

        public void Init()
        {
            string[] connectionStrings = RegistryDome.DBCS;

            Clear();
            foreach (string conStr in connectionStrings)
            {
                this.Add(new Database(conStr));
            }
        }

        public void Remove(Database item)
        {
            List.Remove(item);
        }

        #endregion
    }
}