﻿namespace main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
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
            this.spcHorizontalLeft = new System.Windows.Forms.SplitContainer();
            this.spcHorizontalRight = new System.Windows.Forms.SplitContainer();
            this.spcVertical = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.tslSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslGeneral = new System.Windows.Forms.ToolStripStatusLabel();
            this.ftvFolders = new cont.FoldersTreeview();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tslDBEngine = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslDBName = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnsMain.SuspendLayout();
            this.stsMain.SuspendLayout();
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
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslGeneral,
            this.tslSpring,
            this.tslDBEngine,
            this.tslDBName});
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
            this.toolStripButton3});
            this.tstMain.Location = new System.Drawing.Point(0, 24);
            this.tstMain.Name = "tstMain";
            this.tstMain.Size = new System.Drawing.Size(549, 25);
            this.tstMain.TabIndex = 4;
            this.tstMain.Text = "toolStrip1";
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
            this.spcHorizontalLeft.Panel1.Controls.Add(this.ftvFolders);
            // 
            // spcHorizontalLeft.Panel2
            // 
            this.spcHorizontalLeft.Panel2.Controls.Add(this.spcHorizontalRight);
            this.spcHorizontalLeft.Size = new System.Drawing.Size(549, 313);
            this.spcHorizontalLeft.SplitterDistance = 135;
            this.spcHorizontalLeft.TabIndex = 5;
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
            // tslSpring
            // 
            this.tslSpring.Name = "tslSpring";
            this.tslSpring.Size = new System.Drawing.Size(288, 17);
            this.tslSpring.Spring = true;
            // 
            // tslGeneral
            // 
            this.tslGeneral.Name = "tslGeneral";
            this.tslGeneral.Size = new System.Drawing.Size(39, 17);
            this.tslGeneral.Text = "Ready";
            // 
            // ftvFolders
            // 
            this.ftvFolders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ftvFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ftvFolders.HideSelection = false;
            this.ftvFolders.Location = new System.Drawing.Point(0, 0);
            this.ftvFolders.Name = "ftvFolders";
            this.ftvFolders.ShowNodeToolTips = true;
            this.ftvFolders.Size = new System.Drawing.Size(135, 313);
            this.ftvFolders.TabIndex = 0;
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "SQLServer.png");
            this.ilMain.Images.SetKeyName(1, "Database.png");
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
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem mniViewFolders;
        private System.Windows.Forms.SplitContainer spcHorizontalRight;
        private System.Windows.Forms.SplitContainer spcVertical;
        private System.Windows.Forms.ToolStripMenuItem mniViewPreview;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column2;
        private System.Windows.Forms.ColumnHeader column3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private cont.FoldersTreeview ftvFolders;
        private System.Windows.Forms.ToolStripStatusLabel tslGeneral;
        private System.Windows.Forms.ToolStripStatusLabel tslSpring;
        private System.Windows.Forms.ToolStripStatusLabel tslDBEngine;
        private System.Windows.Forms.ToolStripStatusLabel tslDBName;
        private System.Windows.Forms.ImageList ilMain;
    }
}

