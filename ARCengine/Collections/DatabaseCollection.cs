using System.Collections;
using ARCettings;


namespace ARCengine.Collections
{
    public class DatabaseCollection : CollectionBase
    {
        #region constructors
        public DatabaseCollection(): base()
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
        public void Add(Database database)
        {
            // add if not already there:
            if (List.IndexOf(database) == -1)
            {
                List.Add(database);
            }
            Dome.CurrentDatabase = database;
        }

        public void Remove(Database database)
        {
            List.Remove(database);
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