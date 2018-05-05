using System.Windows.Forms;
using ARCengine;
using System.Threading;
using System.ComponentModel;

namespace ARControls
{
    public partial class DocumentsListView : ListView
    {
        #region constructors
        public DocumentsListView()
        {
            InitializeComponent();
            View = View.Details;
            mIsPopulating = false;
            mBGW = new BackgroundWorker();
            mBGW.DoWork += new DoWorkEventHandler(bgwDoWork);
        }
        #endregion

        #region members
        private Folder mFolder;
        private bool mIsPopulating;
        //private Thread mThread;
        private BackgroundWorker mBGW;
        #endregion

        #region properties
        public Folder Folder
        {
            get
            {
                return mFolder;
            }
            set
            {
                if(mFolder == value)
                {
                    return;
                }
                mFolder = value;
                mBGW.RunWorkerAsync();
                //Populate();
            }
        }
        #endregion

        delegate void dodo();

        #region methods
        private void bgwDoWork(object sender, DoWorkEventArgs e)
        {
            Populate();
        }

        private void PopulateSafely()
        {
            PopulateDodo();
        }

        private void PopulateDodo()
        {
            if (InvokeRequired)
            {
                dodo d = new dodo(Populate);
                Invoke(d);
            }
            else
            {
                Populate();
            }
        }

        private void Populate()
        {
            try
            {
                mIsPopulating = true;
                //BeginUpdate();
                Columns.Clear();
                foreach (Field field in mFolder.Fields)
                {
                    Columns.Add(new FieldColumnHeader(field));
                }
                Items.Clear();
                foreach(Document document in mFolder.Documents)
                {
                    Items.Add(new DocumentListViewItem(document));
                }
            }
            finally
            {
                mIsPopulating = false;
                //EndUpdate();
            }
        }

        protected override void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
        {
            base.OnColumnWidthChanged(e);
            if(mIsPopulating)
            {
                return;
            }
            FieldColumnHeader fch = (FieldColumnHeader) Columns[e.ColumnIndex];
            fch.Field.Width = fch.Width;
            fch.Field.Save();
        }
        #endregion
    }
}
