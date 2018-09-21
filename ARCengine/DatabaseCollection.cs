using ARCengine.CoreObjects;
using ARCettings;


namespace ARCengine
{
    public class DatabaseCollection : CoreCollection
    {
        #region constructors
        public DatabaseCollection(): base(typeof(Database))
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

        protected override void OnClear()
        {
            base.OnClear();
            Dome.CurrentDatabase = null;
        }

        protected override void Read()
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