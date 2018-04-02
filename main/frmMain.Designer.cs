namespace main
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "c11",
            "c12",
            "c13"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "c21",
            "c22",
            "c23"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "c31",
            "c32",
            "c33"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("image1");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("image2");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("image3");
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.mniFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mniOpenDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mniView = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewStatusbar = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.tslGeneral = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslDBEngine = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslDBName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tstMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.spcLeft = new System.Windows.Forms.SplitContainer();
            this.ftvFolders = new ARControls.FoldersTreeview();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.spcRight = new System.Windows.Forms.SplitContainer();
            this.spcVertical = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mnsMain.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.tstMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcLeft)).BeginInit();
            this.spcLeft.Panel1.SuspendLayout();
            this.spcLeft.Panel2.SuspendLayout();
            this.spcLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcRight)).BeginInit();
            this.spcRight.Panel1.SuspendLayout();
            this.spcRight.Panel2.SuspendLayout();
            this.spcRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcVertical)).BeginInit();
            this.spcVertical.Panel1.SuspendLayout();
            this.spcVertical.Panel2.SuspendLayout();
            this.spcVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mnsMain
            // 
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniFile,
            this.mniView,
            this.mniHelp});
            this.mnsMain.Location = new System.Drawing.Point(0, 0);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(815, 24);
            this.mnsMain.TabIndex = 2;
            this.mnsMain.Text = "menuStrip1";
            // 
            // mniFile
            // 
            this.mniFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniOpenDatabase,
            this.toolStripMenuItem1,
            this.mniClose});
            this.mniFile.Name = "mniFile";
            this.mniFile.Size = new System.Drawing.Size(37, 20);
            this.mniFile.Text = "&File";
            // 
            // mniOpenDatabase
            // 
            this.mniOpenDatabase.Name = "mniOpenDatabase";
            this.mniOpenDatabase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mniOpenDatabase.Size = new System.Drawing.Size(206, 22);
            this.mniOpenDatabase.Text = "&Open Database...";
            this.mniOpenDatabase.Click += new System.EventHandler(this.mniOpenDatabase_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(203, 6);
            // 
            // mniClose
            // 
            this.mniClose.Name = "mniClose";
            this.mniClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mniClose.Size = new System.Drawing.Size(206, 22);
            this.mniClose.Text = "&Close";
            this.mniClose.Click += new System.EventHandler(this.mniClose_Click);
            // 
            // mniView
            // 
            this.mniView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniViewToolbar,
            this.mniViewFolders,
            this.mniViewPreview,
            this.mniViewStatusbar});
            this.mniView.Name = "mniView";
            this.mniView.Size = new System.Drawing.Size(44, 20);
            this.mniView.Text = "&View";
            // 
            // mniViewToolbar
            // 
            this.mniViewToolbar.Checked = true;
            this.mniViewToolbar.CheckOnClick = true;
            this.mniViewToolbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mniViewToolbar.Name = "mniViewToolbar";
            this.mniViewToolbar.Size = new System.Drawing.Size(123, 22);
            this.mniViewToolbar.Text = "&Toolbar";
            this.mniViewToolbar.Click += new System.EventHandler(this.mniViewToolbar_Click);
            // 
            // mniViewFolders
            // 
            this.mniViewFolders.Checked = true;
            this.mniViewFolders.CheckOnClick = true;
            this.mniViewFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mniViewFolders.Name = "mniViewFolders";
            this.mniViewFolders.Size = new System.Drawing.Size(123, 22);
            this.mniViewFolders.Text = "&Folders";
            this.mniViewFolders.Click += new System.EventHandler(this.mniViewFolders_Click);
            // 
            // mniViewPreview
            // 
            this.mniViewPreview.Checked = true;
            this.mniViewPreview.CheckOnClick = true;
            this.mniViewPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mniViewPreview.Name = "mniViewPreview";
            this.mniViewPreview.Size = new System.Drawing.Size(123, 22);
            this.mniViewPreview.Text = "&Preview";
            this.mniViewPreview.Click += new System.EventHandler(this.mniViewActions_Click);
            // 
            // mniViewStatusbar
            // 
            this.mniViewStatusbar.Checked = true;
            this.mniViewStatusbar.CheckOnClick = true;
            this.mniViewStatusbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mniViewStatusbar.Name = "mniViewStatusbar";
            this.mniViewStatusbar.Size = new System.Drawing.Size(123, 22);
            this.mniViewStatusbar.Text = "&Statusbar";
            this.mniViewStatusbar.Click += new System.EventHandler(this.statusBarToolStripMenuItem_Click);
            // 
            // mniHelp
            // 
            this.mniHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAbout});
            this.mniHelp.Name = "mniHelp";
            this.mniHelp.Size = new System.Drawing.Size(44, 20);
            this.mniHelp.Text = "&Help";
            // 
            // mniAbout
            // 
            this.mniAbout.Name = "mniAbout";
            this.mniAbout.Size = new System.Drawing.Size(154, 22);
            this.mniAbout.Text = "&About Archiver";
            this.mniAbout.Click += new System.EventHandler(this.mniAbout_Click);
            // 
            // stsMain
            // 
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslGeneral,
            this.tslSpring,
            this.tslDBEngine,
            this.tslDBName});
            this.stsMain.Location = new System.Drawing.Point(0, 362);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(815, 22);
            this.stsMain.TabIndex = 1;
            this.stsMain.Text = "statusStrip1";
            // 
            // tslGeneral
            // 
            this.tslGeneral.Name = "tslGeneral";
            this.tslGeneral.Size = new System.Drawing.Size(39, 17);
            this.tslGeneral.Text = "Ready";
            // 
            // tslSpring
            // 
            this.tslSpring.Name = "tslSpring";
            this.tslSpring.Size = new System.Drawing.Size(585, 17);
            this.tslSpring.Spring = true;
            // 
            // tslDBEngine
            // 
            this.tslDBEngine.Image = global::main.Properties.Resources.SQLServer;
            this.tslDBEngine.ImageTransparentColor = System.Drawing.Color.White;
            this.tslDBEngine.Name = "tslDBEngine";
            this.tslDBEngine.Size = new System.Drawing.Size(90, 17);
            this.tslDBEngine.Text = "<DBEngine>";
            // 
            // tslDBName
            // 
            this.tslDBName.Image = global::main.Properties.Resources.Database;
            this.tslDBName.ImageTransparentColor = System.Drawing.Color.White;
            this.tslDBName.Name = "tslDBName";
            this.tslDBName.Size = new System.Drawing.Size(86, 17);
            this.tslDBName.Text = "<DBName>";
            // 
            // tstMain
            // 
            this.tstMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton2});
            this.tstMain.Location = new System.Drawing.Point(0, 24);
            this.tstMain.Name = "tstMain";
            this.tstMain.Size = new System.Drawing.Size(815, 25);
            this.tstMain.TabIndex = 4;
            this.tstMain.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // spcLeft
            // 
            this.spcLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcLeft.Location = new System.Drawing.Point(0, 49);
            this.spcLeft.Name = "spcLeft";
            // 
            // spcLeft.Panel1
            // 
            this.spcLeft.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.spcLeft.Panel1.Controls.Add(this.ftvFolders);
            // 
            // spcLeft.Panel2
            // 
            this.spcLeft.Panel2.Controls.Add(this.spcRight);
            this.spcLeft.Size = new System.Drawing.Size(815, 313);
            this.spcLeft.SplitterDistance = 100;
            this.spcLeft.TabIndex = 5;
            // 
            // ftvFolders
            // 
            this.ftvFolders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ftvFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ftvFolders.HideSelection = false;
            this.ftvFolders.ImageIndex = 0;
            this.ftvFolders.ImageList = this.ilMain;
            this.ftvFolders.Location = new System.Drawing.Point(0, 0);
            this.ftvFolders.Name = "ftvFolders";
            this.ftvFolders.SelectedImageIndex = 0;
            this.ftvFolders.ShowNodeToolTips = true;
            this.ftvFolders.Size = new System.Drawing.Size(100, 313);
            this.ftvFolders.TabIndex = 0;
            this.ftvFolders.FolderChanged += new System.Windows.Forms.TreeViewEventHandler(this.ftvFolders_FolderChanged);
            this.ftvFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ftvFolders_AfterSelect);
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "Database Blue.png");
            this.ilMain.Images.SetKeyName(1, "Database Blue Plus.png");
            this.ilMain.Images.SetKeyName(2, "icons8-folder-16.png");
            this.ilMain.Images.SetKeyName(3, "icons8-folder-16 (1).png");
            this.ilMain.Images.SetKeyName(4, "icons8-archive-folder-16 (2).png");
            // 
            // spcRight
            // 
            this.spcRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcRight.Location = new System.Drawing.Point(0, 0);
            this.spcRight.Name = "spcRight";
            // 
            // spcRight.Panel1
            // 
            this.spcRight.Panel1.Controls.Add(this.spcVertical);
            // 
            // spcRight.Panel2
            // 
            this.spcRight.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.spcRight.Panel2.Controls.Add(this.pictureBox1);
            this.spcRight.Size = new System.Drawing.Size(711, 313);
            this.spcRight.SplitterDistance = 465;
            this.spcRight.TabIndex = 0;
            // 
            // spcVertical
            // 
            this.spcVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcVertical.Location = new System.Drawing.Point(0, 0);
            this.spcVertical.Name = "spcVertical";
            this.spcVertical.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcVertical.Panel1
            // 
            this.spcVertical.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.spcVertical.Panel1.Controls.Add(this.listView1);
            // 
            // spcVertical.Panel2
            // 
            this.spcVertical.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.spcVertical.Panel2.Controls.Add(this.listView2);
            this.spcVertical.Size = new System.Drawing.Size(465, 313);
            this.spcVertical.SplitterDistance = 207;
            this.spcVertical.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1,
            this.column2,
            this.column3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(465, 207);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // column1
            // 
            this.column1.Text = "column1";
            this.column1.Width = 93;
            // 
            // column2
            // 
            this.column2.Text = "column2";
            this.column2.Width = 91;
            // 
            // column3
            // 
            this.column3.Text = "column3";
            this.column3.Width = 87;
            // 
            // listView2
            // 
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.HideSelection = false;
            this.listView2.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(465, 102);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 313);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 384);
            this.Controls.Add(this.spcLeft);
            this.Controls.Add(this.tstMain);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.Name = "frmMain";
            this.Text = "Archiver";
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.tstMain.ResumeLayout(false);
            this.tstMain.PerformLayout();
            this.spcLeft.Panel1.ResumeLayout(false);
            this.spcLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcLeft)).EndInit();
            this.spcLeft.ResumeLayout(false);
            this.spcRight.Panel1.ResumeLayout(false);
            this.spcRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcRight)).EndInit();
            this.spcRight.ResumeLayout(false);
            this.spcVertical.Panel1.ResumeLayout(false);
            this.spcVertical.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcVertical)).EndInit();
            this.spcVertical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripMenuItem mniFile;
        private System.Windows.Forms.ToolStripMenuItem mniClose;
        private System.Windows.Forms.ToolStripMenuItem mniHelp;
        private System.Windows.Forms.ToolStripMenuItem mniAbout;
        private System.Windows.Forms.ToolStrip tstMain;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SplitContainer spcLeft;
        private System.Windows.Forms.ToolStripMenuItem mniView;
        private System.Windows.Forms.ToolStripMenuItem mniViewToolbar;
        private System.Windows.Forms.ToolStripMenuItem mniViewStatusbar;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem mniViewFolders;
        private System.Windows.Forms.SplitContainer spcRight;
        private System.Windows.Forms.SplitContainer spcVertical;
        private System.Windows.Forms.ToolStripMenuItem mniViewPreview;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column2;
        private System.Windows.Forms.ColumnHeader column3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ARControls.FoldersTreeview ftvFolders;
        private System.Windows.Forms.ToolStripStatusLabel tslGeneral;
        private System.Windows.Forms.ToolStripStatusLabel tslSpring;
        private System.Windows.Forms.ToolStripStatusLabel tslDBEngine;
        private System.Windows.Forms.ToolStripStatusLabel tslDBName;
        private System.Windows.Forms.ImageList ilMain;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem mniOpenDatabase;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}

