using System.ComponentModel;
using System.Windows.Forms;

namespace KeeReaper
{
    partial class StaleEntries
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CutoffDays = new System.Windows.Forms.NumericUpDown();
            this.CutoffLabel1 = new System.Windows.Forms.Label();
            this.CutoffLabel2 = new System.Windows.Forms.Label();
            this.DismissButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CutoffDays)).BeginInit();
            this.SuspendLayout();
            // 
            // EntriesList
            // 
            this.EntriesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EntriesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPath,
            this.colUser,
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
            // colPath
            // 
            this.colPath.Text = "Path";
            this.colPath.Width = 350;
            // 
            // colUser
            // 
            this.colUser.Text = "Username";
            this.colUser.Width = 250;
            // 
            // colAge
            // 
            this.colAge.Text = "Age";
            this.colAge.Width = 150;
            // 
            // CutoffDays
            // 
            this.CutoffDays.Location = new System.Drawing.Point(289, 404);
            this.CutoffDays.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CutoffDays.Name = "CutoffDays";
            this.CutoffDays.Size = new System.Drawing.Size(120, 31);
            this.CutoffDays.TabIndex = 2;
            this.CutoffDays.ValueChanged += new System.EventHandler(this.CutoffDays_ValueChanged);
            // 
            // CutoffLabel1
            // 
            this.CutoffLabel1.AutoSize = true;
            this.CutoffLabel1.Location = new System.Drawing.Point(12, 406);
            this.CutoffLabel1.Name = "CutoffLabel1";
            this.CutoffLabel1.Size = new System.Drawing.Size(271, 25);
            this.CutoffLabel1.TabIndex = 1;
            this.CutoffLabel1.Text = "Consider entries older than";
            // 
            // CutoffLabel2
            // 
            this.CutoffLabel2.AutoSize = true;
            this.CutoffLabel2.Location = new System.Drawing.Point(415, 406);
            this.CutoffLabel2.Name = "CutoffLabel2";
            this.CutoffLabel2.Size = new System.Drawing.Size(164, 25);
            this.CutoffLabel2.TabIndex = 3;
            this.CutoffLabel2.Text = "days to be stale";
            // 
            // DismissButton
            // 
            this.DismissButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DismissButton.Location = new System.Drawing.Point(660, 398);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(128, 40);
            this.DismissButton.TabIndex = 4;
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
            this.Controls.Add(this.CutoffLabel2);
            this.Controls.Add(this.CutoffLabel1);
            this.Controls.Add(this.CutoffDays);
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
            ((System.ComponentModel.ISupportInitialize)(this.CutoffDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView EntriesList;
        private ColumnHeader colPath;
        private ColumnHeader colAge;
        private ColumnHeader colUser;
        private NumericUpDown CutoffDays;
        private Label CutoffLabel1;
        private Label CutoffLabel2;
        private Button DismissButton;
    }
}