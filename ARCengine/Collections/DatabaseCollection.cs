using System.Collections;
using ARCettings;


namespace ARCengine.Collections
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
            // add if not already there:
            if (List.IndexOf(item) == -1)
            {
                List.Add(item);
            }
            Dome.CurrentDatabase = item;
        }

        public void Remove(Database item)
        {
            List.Remove(item);
            if(Count != 0)
            {
                Dome.CurrentDatabase = (Database)List[Count];
            }
        }

        public new void Clear()
        {
            base.Clear();
            Dome.CurrentDatabase = null;
        }

        public void Init()
        {
            string[] connectionStrings = RegistryDome.DBs;

            Clear();
            foreach (string conStr in connectionStrings)
            {
                Add(new Database(conStr));
            }
        }
        #endregion
    }
}