namespace RwzReader.Forms;
partial class MainForm
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
        this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
        this.openButton = new System.Windows.Forms.Button();
        this.rowCountLabel = new System.Windows.Forms.Label();
        this.saveButton = new System.Windows.Forms.Button();
        this.saveDialog = new System.Windows.Forms.SaveFileDialog();
        this.rulesDataGrid = new System.Windows.Forms.DataGridView();
        this.ruleNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.ruleTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.moveUpButton = new System.Windows.Forms.Button();
        this.moveDownButton = new System.Windows.Forms.Button();
        this.sortButton = new System.Windows.Forms.Button();
        this.readFromOutlookButton = new System.Windows.Forms.Button();
        this.saveToOutlookButton = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.rulesDataGrid)).BeginInit();
        this.SuspendLayout();
        // 
        // dlgOpenFile
        // 
        this.openFileDialog.Filter = "RWZ Files|*.rwz|All Files|*.*";
        // 
        // OpenButton
        // 
        this.openButton.Location = new System.Drawing.Point(12, 12);
        this.openButton.Name = "OpenButton";
        this.openButton.Size = new System.Drawing.Size(75, 23);
        this.openButton.TabIndex = 0;
        this.openButton.Text = "Open File";
        this.openButton.UseVisualStyleBackColor = true;
        this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
        // 
        // RowCountLabel
        // 
        this.rowCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.rowCountLabel.Location = new System.Drawing.Point(373, 486);
        this.rowCountLabel.Name = "RowCountLabel";
        this.rowCountLabel.Size = new System.Drawing.Size(84, 15);
        this.rowCountLabel.TabIndex = 8;
        this.rowCountLabel.Text = "0 Items";
        this.rowCountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
        // 
        // SaveButton
        // 
        this.saveButton.Location = new System.Drawing.Point(93, 12);
        this.saveButton.Name = "SaveButton";
        this.saveButton.Size = new System.Drawing.Size(75, 23);
        this.saveButton.TabIndex = 1;
        this.saveButton.Tag = "";
        this.saveButton.Text = "Save File";
        this.saveButton.UseVisualStyleBackColor = true;
        this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
        // 
        // dlgSave
        // 
        this.saveDialog.DefaultExt = "rwz";
        this.saveDialog.Filter = "RWZ Files|*.rwz|All Files|*.*";
        // 
        // rulesDataGrid
        // 
        this.rulesDataGrid.AllowDrop = true;
        this.rulesDataGrid.AllowUserToAddRows = false;
        this.rulesDataGrid.AllowUserToDeleteRows = false;
        this.rulesDataGrid.AllowUserToResizeColumns = false;
        this.rulesDataGrid.AllowUserToResizeRows = false;
        this.rulesDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.rulesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.rulesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ruleNameColumn,
            this.ruleTypeColumn});
        this.rulesDataGrid.Location = new System.Drawing.Point(12, 41);
        this.rulesDataGrid.Name = "RulesDataGrid";
        this.rulesDataGrid.ReadOnly = true;
        this.rulesDataGrid.RowHeadersVisible = false;
        this.rulesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.rulesDataGrid.Size = new System.Drawing.Size(445, 442);
        this.rulesDataGrid.TabIndex = 4;
        // 
        // RuleNameColumn
        // 
        this.ruleNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        this.ruleNameColumn.DataPropertyName = "Name";
        this.ruleNameColumn.HeaderText = "Rule Name";
        this.ruleNameColumn.Name = "RuleNameColumn";
        this.ruleNameColumn.ReadOnly = true;
        // 
        // RuleTypeColumn
        // 
        this.ruleTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
        this.ruleTypeColumn.DataPropertyName = "Data.Criteria";
        this.ruleTypeColumn.HeaderText = "Rule Type";
        this.ruleTypeColumn.Name = "RuleTypeColumn";
        this.ruleTypeColumn.ReadOnly = true;
        this.ruleTypeColumn.Width = 81;
        // 
        // MoveUpButton
        // 
        this.moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.moveUpButton.Location = new System.Drawing.Point(463, 41);
        this.moveUpButton.Name = "MoveUpButton";
        this.moveUpButton.Size = new System.Drawing.Size(75, 23);
        this.moveUpButton.TabIndex = 5;
        this.moveUpButton.Text = "Move Up";
        this.moveUpButton.UseVisualStyleBackColor = true;
        this.moveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
        // 
        // MoveDownButton
        // 
        this.moveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.moveDownButton.Location = new System.Drawing.Point(463, 70);
        this.moveDownButton.Name = "MoveDownButton";
        this.moveDownButton.Size = new System.Drawing.Size(75, 23);
        this.moveDownButton.TabIndex = 6;
        this.moveDownButton.Text = "Move Down";
        this.moveDownButton.UseVisualStyleBackColor = true;
        this.moveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
        // 
        // SortButton
        // 
        this.sortButton.Location = new System.Drawing.Point(463, 115);
        this.sortButton.Name = "SortButton";
        this.sortButton.Size = new System.Drawing.Size(75, 37);
        this.sortButton.TabIndex = 7;
        this.sortButton.Text = "Sort Selected";
        this.sortButton.UseVisualStyleBackColor = true;
        this.sortButton.Click += new System.EventHandler(this.SortButton_Click);
        // 
        // ReadFromOutlookButton
        // 
        this.readFromOutlookButton.Location = new System.Drawing.Point(227, 12);
        this.readFromOutlookButton.Name = "ReadFromOutlookButton";
        this.readFromOutlookButton.Size = new System.Drawing.Size(112, 23);
        this.readFromOutlookButton.TabIndex = 2;
        this.readFromOutlookButton.Text = "Read From Outlook";
        this.readFromOutlookButton.UseVisualStyleBackColor = true;
        this.readFromOutlookButton.Click += new System.EventHandler(this.ReadFromOutlookButton_Click);
        // 
        // SaveToOutlookButton
        // 
        this.saveToOutlookButton.Location = new System.Drawing.Point(345, 13);
        this.saveToOutlookButton.Name = "SaveToOutlookButton";
        this.saveToOutlookButton.Size = new System.Drawing.Size(112, 23);
        this.saveToOutlookButton.TabIndex = 3;
        this.saveToOutlookButton.Text = "Save To Outlook";
        this.saveToOutlookButton.UseVisualStyleBackColor = true;
        this.saveToOutlookButton.Click += new System.EventHandler(this.SaveToOutlookButton_Click);
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(550, 520);
        this.Controls.Add(this.saveToOutlookButton);
        this.Controls.Add(this.readFromOutlookButton);
        this.Controls.Add(this.sortButton);
        this.Controls.Add(this.moveDownButton);
        this.Controls.Add(this.moveUpButton);
        this.Controls.Add(this.rulesDataGrid);
        this.Controls.Add(this.saveButton);
        this.Controls.Add(this.rowCountLabel);
        this.Controls.Add(this.openButton);
        this.MinimumSize = new System.Drawing.Size(394, 272);
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "RWZ Reader";
        this.Load += new System.EventHandler(this.MainForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.rulesDataGrid)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.Button openButton;
    private System.Windows.Forms.Label rowCountLabel;
    private System.Windows.Forms.Button saveButton;
    private System.Windows.Forms.SaveFileDialog saveDialog;
    private System.Windows.Forms.DataGridView rulesDataGrid;
    private System.Windows.Forms.Button moveUpButton;
    private System.Windows.Forms.Button moveDownButton;
    private System.Windows.Forms.DataGridViewTextBoxColumn ruleNameColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn ruleTypeColumn;
    private System.Windows.Forms.Button sortButton;
    private System.Windows.Forms.Button readFromOutlookButton;
    private System.Windows.Forms.Button saveToOutlookButton;
}