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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node5");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node2", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node9");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node10");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node11");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node8", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node3", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4,
            treeNode11});
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
            this.mniClose = new System.Windows.Forms.ToolStripMenuItem();
            this.mniView = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewStatusbar = new System.Windows.Forms.ToolStripMenuItem();
            this.mniHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.tstMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.spcHorizontalLeft = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.spcHorizontalRight = new System.Windows.Forms.SplitContainer();
            this.spcVertical = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mnsMain.SuspendLayout();
            this.tstMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcHorizontalLeft)).BeginInit();
            this.spcHorizontalLeft.Panel1.SuspendLayout();
            this.spcHorizontalLeft.Panel2.SuspendLayout();
            this.spcHorizontalLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcHorizontalRight)).BeginInit();
            this.spcHorizontalRight.Panel1.SuspendLayout();
            this.spcHorizontalRight.Panel2.SuspendLayout();
            this.spcHorizontalRight.SuspendLayout();
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
            this.mnsMain.Size = new System.Drawing.Size(549, 24);
            this.mnsMain.TabIndex = 2;
            this.mnsMain.Text = "menuStrip1";
            // 
            // mniFile
            // 
            this.mniFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniClose});
            this.mniFile.Name = "mniFile";
            this.mniFile.Size = new System.Drawing.Size(37, 20);
            this.mniFile.Text = "&File";
            // 
            // mniClose
            // 
            this.mniClose.Name = "mniClose";
            this.mniClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mniClose.Size = new System.Drawing.Size(145, 22);
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
            this.stsMain.Location = new System.Drawing.Point(0, 362);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(549, 22);
            this.stsMain.TabIndex = 1;
            this.stsMain.Text = "statusStrip1";
            // 
            // tstMain
            // 
            this.tstMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripButton3});
            this.tstMain.Location = new System.Drawing.Point(0, 24);
            this.tstMain.Name = "tstMain";
            this.tstMain.Size = new System.Drawing.Size(549, 25);
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
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // spcHorizontalLeft
            // 
            this.spcHorizontalLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcHorizontalLeft.Location = new System.Drawing.Point(0, 49);
            this.spcHorizontalLeft.Name = "spcHorizontalLeft";
            // 
            // spcHorizontalLeft.Panel1
            // 
            this.spcHorizontalLeft.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.spcHorizontalLeft.Panel1.Controls.Add(this.treeView1);
            // 
            // spcHorizontalLeft.Panel2
            // 
            this.spcHorizontalLeft.Panel2.Controls.Add(this.spcHorizontalRight);
            this.spcHorizontalLeft.Size = new System.Drawing.Size(549, 313);
            this.spcHorizontalLeft.SplitterDistance = 135;
            this.spcHorizontalLeft.TabIndex = 5;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.Indent = 15;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Node1";
            treeNode2.Name = "Node4";
            treeNode2.Text = "Node4";
            treeNode3.Name = "Node5";
            treeNode3.Text = "Node5";
            treeNode4.Name = "Node2";
            treeNode4.Text = "Node2";
            treeNode5.Name = "Node6";
            treeNode5.Text = "Node6";
            treeNode6.Name = "Node7";
            treeNode6.Text = "Node7";
            treeNode7.Name = "Node9";
            treeNode7.Text = "Node9";
            treeNode8.Name = "Node10";
            treeNode8.Text = "Node10";
            treeNode9.Name = "Node11";
            treeNode9.Text = "Node11";
            treeNode10.Name = "Node8";
            treeNode10.Text = "Node8";
            treeNode11.Name = "Node3";
            treeNode11.Text = "Node3";
            treeNode12.Name = "Node0";
            treeNode12.Text = "Node0";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12});
            this.treeView1.Size = new System.Drawing.Size(135, 313);
            this.treeView1.TabIndex = 0;
            // 
            // spcHorizontalRight
            // 
            this.spcHorizontalRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcHorizontalRight.Location = new System.Drawing.Point(0, 0);
            this.spcHorizontalRight.Name = "spcHorizontalRight";
            // 
            // spcHorizontalRight.Panel1
            // 
            this.spcHorizontalRight.Panel1.Controls.Add(this.spcVertical);
            // 
            // spcHorizontalRight.Panel2
            // 
            this.spcHorizontalRight.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.spcHorizontalRight.Panel2.Controls.Add(this.pictureBox1);
            this.spcHorizontalRight.Size = new System.Drawing.Size(410, 313);
            this.spcHorizontalRight.SplitterDistance = 275;
            this.spcHorizontalRight.TabIndex = 0;
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
            this.spcVertical.Size = new System.Drawing.Size(275, 313);
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
            this.listView1.Size = new System.Drawing.Size(275, 207);
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
            this.listView2.Size = new System.Drawing.Size(275, 102);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 313);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 384);
            this.Controls.Add(this.spcHorizontalLeft);
            this.Controls.Add(this.tstMain);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.mnsMain);
            this.MainMenuStrip = this.mnsMain;
            this.Name = "frmMain";
            this.Text = "Archiver";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.tstMain.ResumeLayout(false);
            this.tstMain.PerformLayout();
            this.spcHorizontalLeft.Panel1.ResumeLayout(false);
            this.spcHorizontalLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcHorizontalLeft)).EndInit();
            this.spcHorizontalLeft.ResumeLayout(false);
            this.spcHorizontalRight.Panel1.ResumeLayout(false);
            this.spcHorizontalRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcHorizontalRight)).EndInit();
            this.spcHorizontalRight.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer spcHorizontalLeft;
        private System.Windows.Forms.ToolStripMenuItem mniView;
        private System.Windows.Forms.ToolStripMenuItem mniViewToolbar;
        private System.Windows.Forms.ToolStripMenuItem mniViewStatusbar;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem mniViewFolders;
        private System.Windows.Forms.SplitContainer spcHorizontalRight;
        private System.Windows.Forms.SplitContainer spcVertical;
        private System.Windows.Forms.ToolStripMenuItem mniViewPreview;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column2;
        private System.Windows.Forms.ColumnHeader column3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

