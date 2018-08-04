using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARCdataTier;
using ARCbusinessTier;


namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mniFunc1_Click(object sender, EventArgs e)
        {
            Database db = new Database("Data Source = LENOVO; Initial Catalog=archiver; Integrated Security = False; User ID = sa; Password = 123; Auto Connect = 1");
            Folder f = new Folder(db, 1);
            MessageBox.Show(f.ToString());
        }

        private void func2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Database db = new Database("Data Source = LENOVO; Initial Catalog=archiver; Integrated Security = False; User ID = sa; Password = 123; Auto Connect = 1");
            Folder f = new Folder();
            f.Name = "koko";
            MessageBox.Show(f.ToString());
            f.Save(db);
            MessageBox.Show(f.ToString());
        }
    }
}
