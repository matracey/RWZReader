using Microsoft.Office.Interop.Outlook;

using RwzReader.Common;
using RwzReader.Forms.Interop;

using Exception = System.Exception;

namespace RwzReader.Forms;

public partial class MainForm : Form
{
    private const string PropertySchemaName = "http://schemas.microsoft.com/mapi/proptag/0x68020102";
    private RulesExportFile? _file;
    private readonly BindingSource _rules = [];

    private int _dragSourceIndex;
    private DataGridViewSelectedRowCollection? _dragRows;
    private Rectangle _dragSourceRectangle;
    private int _dragDestinationIndex;

    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        // set up DataGrid for display
        rulesDataGrid.AutoGenerateColumns = false;
        rulesDataGrid.CellFormatting += DataGridViewEnhancements.DataGridView_CellFormatting;
    }

    private void OpenButton_Click(object sender, EventArgs e)
    {
        // open file
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            _file = RulesExportFile.Parse(openFileDialog.FileName);

            // bind to grid
            rulesDataGrid.DataSource = _file;
            rowCountLabel.Text = $"{rulesDataGrid.Rows.Count} Items";
        }
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        // Save organized file
        if (_file is not null && saveDialog.ShowDialog() == DialogResult.OK)
        {
            _file.Save(saveDialog.FileName);
            MessageBox.Show("Saved.");
        }
    }

    private static PropertyAccessor? GetOutlookPropertyAccessor(out StorageItem? storageItem)
    {
        object? instance = Marshal.GetActiveObject("Outlook.Application");
        storageItem = null;

        if (instance == null)
        {
            MessageBox.Show("Outlook is not running.");
            return null;
        }

        ApplicationClass outlookApp = (ApplicationClass)instance;

        MAPIFolder folder = outlookApp.Session.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
        storageItem = folder.GetStorage("IPM.RuleOrganizer", OlStorageIdentifierType.olIdentifyByMessageClass);
        return storageItem.PropertyAccessor;
    }

    private void ReadFromOutlookButton_Click(object sender, EventArgs e)
    {
        try
        {
            PropertyAccessor? property = GetOutlookPropertyAccessor(out _);
            byte[] bytes = (property?.GetProperty(PropertySchemaName) as byte[]) ?? [];
            _file = RulesExportFile.Parse(bytes);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error connecting to Outlook: {ex.Message}");
        }

        // bind to grid
        rulesDataGrid.DataSource = _file;
        rowCountLabel.Text = $"{rulesDataGrid.Rows.Count} Items";
    }

    private void SaveToOutlookButton_Click(object sender, EventArgs e)
    {
        try
        {
            PropertyAccessor? propertyAccessor = GetOutlookPropertyAccessor(out StorageItem? storageItem);

            if (propertyAccessor == null || _file is null)
            {
                return;
            }

            propertyAccessor.SetProperty(PropertySchemaName, _file.GetBytes());
            storageItem?.Save();

            MessageBox.Show("Saved.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving to Outlook: {ex.Message}");
        }
    }

    private void MoveUpButton_Click(object sender, EventArgs e)
    {
        List<int> indexes = [];

        // Collect the indexes that need moved
        foreach (DataGridViewRow row in rulesDataGrid.SelectedRows)
        {
            indexes.Add(row.Index);
        }

        // If nothing selected, nothing to do
        if (indexes.Count == 0 || _file is null)
        {
            return;
        }

        // Process the item indexes
        _file.ChangeItemIndexes([.. indexes], -1);

        // highlight the rows using their new indexes
        rulesDataGrid.ClearSelection();
        foreach (int i in indexes)
        {
            if (i > 0)
            {
                rulesDataGrid.Rows[i - 1].Selected = true;
            }
        }

        // set the scroll position if items moved off the visible area
        int minIndex = int.MaxValue;
        foreach (var i in indexes.Where(i => i < minIndex))
        {
            minIndex = i;
        }

        if (minIndex < rulesDataGrid.FirstDisplayedScrollingRowIndex)
        {
            rulesDataGrid.FirstDisplayedScrollingRowIndex = minIndex;
        }
    }

    private void MoveDownButton_Click(object sender, EventArgs e)
    {
        List<int> indexes = [];

        // Collect indexes
        foreach (DataGridViewRow row in rulesDataGrid.SelectedRows)
        {
            indexes.Add(row.Index);
        }

        // exit if nothing selected
        if (indexes.Count == 0 || _file is null)
        {
            return;
        }

        // process the indexes
        _file.ChangeItemIndexes([.. indexes], 1);

        // highlight the rows with new indexes
        rulesDataGrid.ClearSelection();
        foreach (int i in indexes.Where(i => i < rulesDataGrid.Rows.Count - 1))
        {
            rulesDataGrid.Rows[i + 1].Selected = true;
        }

        // scroll display to keep last item visible
        int maxIndex = int.MinValue;
        foreach (int i in indexes.Where(i => i > maxIndex))
        {
            maxIndex = i;
        }

        if (maxIndex + indexes.Count > rulesDataGrid.FirstDisplayedScrollingRowIndex + rulesDataGrid.DisplayedRowCount(false))
        {
            rulesDataGrid.FirstDisplayedScrollingRowIndex = maxIndex + indexes.Count - rulesDataGrid.DisplayedRowCount(false);
        }
    }

    private void SortButton_Click(object sender, EventArgs e)
    {
        List<int> indexes = [];

        // Collect the indexes that need moved
        foreach (DataGridViewRow row in rulesDataGrid.SelectedRows)
        {
            indexes.Add(row.Index);
        }

        // If nothing selected, nothing to do
        if (indexes.Count == 0 || _file is null)
        {
            return;
        }

        _file.SortAlpha([.. indexes]);

        // highlight the rows using their new indexes
        rulesDataGrid.ClearSelection();

        int minIndex = int.MaxValue;
        foreach (int i in indexes)
        {
            if (i < minIndex)
            {
                minIndex = i;
            }
        }

        for (int i = minIndex; i < minIndex + indexes.Count; i++)
        {
            rulesDataGrid.Rows[i].Selected = true;
        }

        // set the scroll position if items moved off the visible area
        if (minIndex < rulesDataGrid.FirstDisplayedScrollingRowIndex)
        {
            rulesDataGrid.FirstDisplayedScrollingRowIndex = minIndex;
        }
    }

    private void RulesDataGrid_DragDrop(object sender, DragEventArgs e)
    {
        Point pt;

        // Determine the place to drop the selected items
        pt = rulesDataGrid.PointToClient(new Point(e.X, e.Y));
        _dragDestinationIndex = rulesDataGrid.HitTest(pt.X, pt.Y).RowIndex;

        // drop in order depending on if dropping higher or lower
        if (_dragDestinationIndex <= _dragSourceIndex)
        {
            DropItemsHigher();
        }
        else
        {
            DropItemsLower();
        }
    }

    private void RulesDataGrid_DragOver(object sender, DragEventArgs e)
    {
        // Check to be sure items being dropped are DataGrid rows
        if (e.Data?.GetDataPresent("System.Windows.Forms.DataGridViewSelectedRowCollection", true) ?? false)
        {
            e.Effect = DragDropEffects.Move;
        }
    }

    private void RulesDataGrid_MouseDown(object sender, MouseEventArgs e)
    {
        Size s;

        // store the selected rows and the size of the drag area
        if ((e.Button & MouseButtons.Left) != 0)
        {
            _dragSourceIndex = rulesDataGrid.HitTest(e.X, e.Y).RowIndex;
            _dragRows = rulesDataGrid.SelectedRows;

            if (_dragSourceIndex >= 0)
            {
                s = SystemInformation.DragSize;
                _dragSourceRectangle = new Rectangle(
                    new Point(e.X - s.Width / 2, e.Y - s.Height / 2), s);
            }
            else
            {
                _dragSourceRectangle = Rectangle.Empty;
            }
        }
    }

    private void RulesDataGrid_MouseMove(object sender, MouseEventArgs e)
    {
        if ((e.Button & MouseButtons.Left) != 0)
        {
            if (_dragSourceRectangle != Rectangle.Empty && !_dragSourceRectangle.Contains(e.X, e.Y) && _dragRows is not null)
            {
                // Moved out of the drag rectangle
                rulesDataGrid.DoDragDrop(_dragRows, DragDropEffects.Move);
            }
        }
    }

    private void DropItemsHigher()
    {
        RuleItem item;

        if (_dragDestinationIndex < 0 || _dragRows is null || _file is null)
        {
            return;
        }

        // reassign the items in order
        for (int i = 0; i < _dragRows.Count; i++)
        {
            item = (RuleItem)_dragRows[i].DataBoundItem;
            _file.Remove(item);
            _file.Insert(_dragDestinationIndex, item);
        }

        // Highlight items, which are now contiguous
        rulesDataGrid.ClearSelection();
        for (int i = _dragDestinationIndex; i < _dragDestinationIndex + _dragRows.Count; i++)
        {
            rulesDataGrid.Rows[i].Selected = true;
        }
    }

    private void DropItemsLower()
    {
        if (_dragRows is null || _file is null)
        {
            return;
        }

        // reassign place in order
        for (int i = _dragRows.Count - 1; i >= 0; i--)
        {
            RuleItem item = (RuleItem)_dragRows[i].DataBoundItem;
            _file.Remove(item);
            _file.Insert(_dragDestinationIndex, item);
        }

        // highlight new locations
        rulesDataGrid.ClearSelection();
        for (int i = _dragDestinationIndex - _dragRows.Count + 1; i <= _dragDestinationIndex; i++)
        {
            rulesDataGrid.Rows[i].Selected = true;
        }
    }
}