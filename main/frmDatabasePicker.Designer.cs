namespace main
{
    partial class frmDatabasePicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabasePicker));
            this.lsvDatabases = new System.Windows.Forms.ListView();
            this.clhFriendlyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhEngine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.imlDatabases = new System.Windows.Forms.ImageList(this.components);
            this.clhDatabase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lsvDatabases
            // 
            this.lsvDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvDatabases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhFriendlyName,
            this.clhEngine,
            this.clhDatabase});
            this.lsvDatabases.FullRowSelect = true;
            this.lsvDatabases.HideSelection = false;
            this.lsvDatabases.LargeImageList = this.imlDatabases;
            this.lsvDatabases.Location = new System.Drawing.Point(12, 12);
            this.lsvDatabases.Name = "lsvDatabases";
            this.lsvDatabases.Size = new System.Drawing.Size(623, 178);
            this.lsvDatabases.SmallImageList = this.imlDatabases;
            this.lsvDatabases.TabIndex = 0;
            this.lsvDatabases.UseCompatibleStateImageBehavior = false;
            this.lsvDatabases.View = System.Windows.Forms.View.Details;
            // 
            // clhFriendlyName
            // 
            this.clhFriendlyName.Text = "Friendly Name";
            this.clhFriendlyName.Width = 119;
            // 
            // clhEngine
            // 
            this.clhEngine.Text = "Engine";
            this.clhEngine.Width = 131;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(560, 196);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "&Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(479, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // imlDatabases
            // 
            this.imlDatabases.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlDatabases.ImageStream")));
            this.imlDatabases.TransparentColor = System.Drawing.Color.Transparent;
            this.imlDatabases.Images.SetKeyName(0, "Database.png");
            // 
            // clhDatabase
            // 
            this.clhDatabase.Text = "Database";
            this.clhDatabase.Width = 122;
            // 
            // frmDatabasePicker
            // 
            this.AcceptButton = this.btnOpen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(647, 231);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lsvDatabases);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatabasePicker";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Database";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvDatabases;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader clhFriendlyName;
        private System.Windows.Forms.ColumnHeader clhEngine;
        private System.Windows.Forms.ImageList imlDatabases;
        private System.Windows.Forms.ColumnHeader clhDatabase;
    }
}