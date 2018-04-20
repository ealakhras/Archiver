namespace ARControls.bo
{
    partial class frmProperties
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
            this.spcCategories = new System.Windows.Forms.SplitContainer();
            this.plvPages = new ARControls.bo.PagesListView();
            this.tbcPages = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spcCategories)).BeginInit();
            this.spcCategories.Panel1.SuspendLayout();
            this.spcCategories.Panel2.SuspendLayout();
            this.spcCategories.SuspendLayout();
            this.tbcPages.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcCategories
            // 
            this.spcCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcCategories.Location = new System.Drawing.Point(0, 0);
            this.spcCategories.Name = "spcCategories";
            // 
            // spcCategories.Panel1
            // 
            this.spcCategories.Panel1.Controls.Add(this.plvPages);
            // 
            // spcCategories.Panel2
            // 
            this.spcCategories.Panel2.Controls.Add(this.pnlTop);
            this.spcCategories.Panel2.Controls.Add(this.pnlBottom);
            this.spcCategories.Size = new System.Drawing.Size(574, 303);
            this.spcCategories.SplitterDistance = 126;
            this.spcCategories.TabIndex = 4;
            // 
            // plvPages
            // 
            this.plvPages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.plvPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plvPages.HideSelection = false;
            this.plvPages.Location = new System.Drawing.Point(0, 0);
            this.plvPages.MultiSelect = false;
            this.plvPages.Name = "plvPages";
            this.plvPages.OwnerDraw = true;
            this.plvPages.PagesTabControl = this.tbcPages;
            this.plvPages.Scrollable = false;
            this.plvPages.Size = new System.Drawing.Size(126, 303);
            this.plvPages.TabIndex = 0;
            this.plvPages.UseCompatibleStateImageBehavior = false;
            this.plvPages.View = System.Windows.Forms.View.Details;
            // 
            // tbcPages
            // 
            this.tbcPages.Controls.Add(this.tabPage1);
            this.tbcPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcPages.Location = new System.Drawing.Point(0, 0);
            this.tbcPages.Name = "tbcPages";
            this.tbcPages.SelectedIndex = 0;
            this.tbcPages.Size = new System.Drawing.Size(444, 263);
            this.tbcPages.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(436, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.tbcPages);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(444, 263);
            this.pnlTop.TabIndex = 5;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 263);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(444, 40);
            this.pnlBottom.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(281, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(362, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmProperties
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(574, 303);
            this.Controls.Add(this.spcCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Properties";
            this.spcCategories.Panel1.ResumeLayout(false);
            this.spcCategories.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcCategories)).EndInit();
            this.spcCategories.ResumeLayout(false);
            this.tbcPages.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.SplitContainer spcCategories;
        protected PagesListView plvPages;
        protected System.Windows.Forms.TabControl tbcPages;
        protected System.Windows.Forms.TabPage tabPage1;
        protected System.Windows.Forms.Panel pnlTop;
        protected System.Windows.Forms.Panel pnlBottom;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnOK;
    }
}