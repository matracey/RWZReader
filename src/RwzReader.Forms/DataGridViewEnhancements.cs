using RwzReader.Common;

namespace RwzReader.Forms;

public static class DataGridViewEnhancements
{
    /// <summary>
    /// Handler for <see cref="DataGridView.CellFormatting" /> event that formats <see cref="RuleCriteria"/> values.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A <see cref="DataGridViewCellFormattingEventArgs"/> containing event data.</param>
    /// <remarks>
    /// When a cell value is of type <see cref="RuleCriteria"/>, this method replaces underscores with 
    /// spaces in the string representation and marks the formatting as applied.
    /// </remarks>
    public static void DataGridView_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value != null && e.Value is RuleCriteria)
        {
            e.Value = e.Value.ToString()?.Replace("_", " ");
            e.FormattingApplied = true;
        }
    }
}