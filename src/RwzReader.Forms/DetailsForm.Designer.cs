namespace RWZReader
{
    partial class DetailsForm
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
            this.detailsGridView = new System.Windows.Forms.DataGridView();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.detailsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDetails
            // 
            this.detailsGridView.AllowUserToAddRows = false;
            this.detailsGridView.AllowUserToDeleteRows = false;
            this.detailsGridView.AllowUserToResizeRows = false;
            this.detailsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionColumn,
            this.positionColumn,
            this.dataColumn});
            this.detailsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsGridView.Location = new System.Drawing.Point(0, 0);
            this.detailsGridView.Name = "dgDetails";
            this.detailsGridView.ReadOnly = true;
            this.detailsGridView.RowHeadersVisible = false;
            this.detailsGridView.Size = new System.Drawing.Size(284, 262);
            this.detailsGridView.TabIndex = 0;
            // 
            // DescriptionColumn
            // 
            this.descriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descriptionColumn.HeaderText = "Description";
            this.descriptionColumn.Name = "DescriptionColumn";
            this.descriptionColumn.ReadOnly = true;
            this.descriptionColumn.Width = 85;
            // 
            // PositionColumn
            // 
            this.positionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.positionColumn.HeaderText = "Position";
            this.positionColumn.Name = "PositionColumn";
            this.positionColumn.ReadOnly = true;
            this.positionColumn.Width = 69;
            // 
            // DataColumn
            // 
            this.dataColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataColumn.HeaderText = "Data";
            this.dataColumn.Name = "DataColumn";
            this.dataColumn.ReadOnly = true;
            this.dataColumn.Width = 55;
            // 
            // DetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.detailsGridView);
            this.Name = "DetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rule Details";
            this.Load += new System.EventHandler(this.DetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detailsGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView detailsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataColumn;
    }
}