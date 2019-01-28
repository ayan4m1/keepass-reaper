namespace KeeReaper
{
    partial class StaleEntries
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
            this.EntriesList = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChanged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DismissButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EntriesList
            // 
            this.EntriesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colUrl,
            this.colChanged,
            this.colAge});
            this.EntriesList.FullRowSelect = true;
            this.EntriesList.Location = new System.Drawing.Point(12, 12);
            this.EntriesList.MultiSelect = false;
            this.EntriesList.Name = "EntriesList";
            this.EntriesList.Size = new System.Drawing.Size(776, 380);
            this.EntriesList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.EntriesList.TabIndex = 0;
            this.EntriesList.UseCompatibleStateImageBehavior = false;
            this.EntriesList.View = System.Windows.Forms.View.Details;
            this.EntriesList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.EntriesList_ColumnClick);
            this.EntriesList.DoubleClick += new System.EventHandler(this.EntriesList_DoubleClick);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 200;
            // 
            // colUrl
            // 
            this.colUrl.Text = "URL";
            this.colUrl.Width = 200;
            // 
            // colChanged
            // 
            this.colChanged.Text = "Changed";
            this.colChanged.Width = 150;
            // 
            // colAge
            // 
            this.colAge.Text = "Age (Days)";
            this.colAge.Width = 150;
            // 
            // DismissButton
            // 
            this.DismissButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DismissButton.Location = new System.Drawing.Point(660, 398);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(128, 40);
            this.DismissButton.TabIndex = 1;
            this.DismissButton.Text = "Dismiss";
            this.DismissButton.UseVisualStyleBackColor = true;
            // 
            // StaleEntries
            // 
            this.AcceptButton = this.DismissButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.DismissButton;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DismissButton);
            this.Controls.Add(this.EntriesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StaleEntries";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stale Entries";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView EntriesList;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colUrl;
        private System.Windows.Forms.ColumnHeader colChanged;
        private System.Windows.Forms.ColumnHeader colAge;
        private System.Windows.Forms.Button DismissButton;
    }
}