using System.ComponentModel;
using System.Linq;

using RwzReader.Common.Helpers;

namespace RwzReader.Common;

/// <summary>
/// Represents a RWZ file exported by Outlook
/// </summary>
public class RulesExportFile : BindingList<RuleItem>
{
    public required byte[] Header { get; set; }
    public required byte[] Footer { get; set; }
    public required short ItemCount { get; set; }

    public static RulesExportFile Parse(string filename)
    {
        byte[] bytes = File.ReadAllBytes(filename);
        return Parse(bytes);
    }

    public static RulesExportFile Parse(byte[] bytes)
    {
        using BinaryReader ruleBinaryReader = new(new MemoryStream(bytes));

        byte[] fileHeader = ruleBinaryReader.ReadBytes(0x2C); // Header
        short fileItemCount = ruleBinaryReader.ReadInt16();
        List<RuleItem> ruleItems = [];

        do
        {
            int len = default;
            RuleItem? currentItem = RuleItem.Parse(ruleBinaryReader, ref len);

            if (currentItem == null)
            {
                continue;
            }

            ruleItems.Add(currentItem);
            ruleBinaryReader.ReadBytes(2); // Delimiter between rules

        } while (ruleBinaryReader.BaseStream.Length - ruleBinaryReader.BaseStream.Position > 24);

        byte[] fileFooter = ruleBinaryReader.ReadBytes((int)(ruleBinaryReader.BaseStream.Length - ruleBinaryReader.BaseStream.Position));

        ruleBinaryReader.Close();
        ruleBinaryReader.Dispose();

        RulesExportFile file = new()
        {
            Header = fileHeader,
            ItemCount = fileItemCount,
            Footer = fileFooter,
        };

        ruleItems.ForEach(file.Add);

        return file;
    }

    public byte[] GetBytes()
    {
        using MemoryStream s = new();
        using BinaryWriter sw = new(s);
        byte[] bytes;

        sw.Write(Header);
        sw.Write(ItemCount);

        for (int i = 0; i < Count; i++)
        {
            sw.Write(this[i].ToBytes(i == 0));
        }

        sw.Write(Footer);

        s.Seek(0, SeekOrigin.Begin);

        using BinaryReader sr = new(s);
        bytes = sr.ReadBytes((int)s.Length);

        sr.Close();
        sw.Close();
        s.Close();

        sw.Dispose();
        sr.Dispose();
        s.Dispose();

        return bytes;
    }

    /// <summary>
    /// Saves the export file to disk
    /// </summary>
    /// <param name="filename">Path to save the file</param>
    public void Save(string filename)
    {
        File.WriteAllBytes(filename, GetBytes());
    }

    /// <summary>
    /// Support function for moving items within the list
    /// </summary>
    /// <param name="itemIndexes">An array of indexes to move</param>
    /// <param name="delta">The positive or negative number of spaces to move</param>
    public void ChangeItemIndexes(int[] itemIndexes, int delta)
    {
        RuleItem item;

        Array.Sort(itemIndexes);
        if (delta > 0)
        {
            Array.Reverse(itemIndexes);
        }

        // Item can be moved without exceeding bounds
        // Each index in array
        foreach (int i in itemIndexes.Where(i => i + delta >= 0 && i + delta <= Count - 1))
        {
            item = this[i];
            RemoveAt(i);
            Insert(i + delta, item);
        }

        // Raise event for databound controls to refresh
        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
    }

    /// <summary>
    /// Sorts the contents of the <see cref="RulesExportFile"/> in alphabetical order, by name.
    /// </summary>
    /// <param name="itemIndexes">An array of indices of the items to be sorted.</param>
    /// <remarks>
    /// This method extracts the items at the specified indexes, sorts them alphabetically by name in descending order,
    /// and then reinserts them into the collection starting at the minimum provided index.
    /// After sorting, it raises a <see cref="BindingList{T}.OnListChanged"/> event with <see cref="ListChangedType.Reset"/> type to notify any bound UI controls to refresh.
    /// </remarks>
    public void SortAlpha(int[] itemIndexes)
    {
        int startIndex = itemIndexes.Min();
        Array.Sort(itemIndexes);
        Array.Reverse(itemIndexes);

        List<RuleItem> items = [];

        itemIndexes.ForEach(i =>
        {
            items.Add(this[i]);
            RemoveAt(i);
        });

        items.OrderByDescending(x => x.Name).ForEach(sortedItem => Insert(startIndex, sortedItem));

        // Raise event for databound controls to refresh
        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, 0));
    }
}