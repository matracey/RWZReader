using System.Text;

namespace RwzReader.Common;

/// <summary>
/// A distinct rule which is repeated with a rule export file
/// </summary>
public class RuleItem
{
    public required byte[] Header { get; set; }
    public required string Name { get; set; }
    public required byte[] Padding { get; set; }
    public required BaseRuleData Data { get; set; }

    /// <summary>
    /// Serializes the rule into a byte array for saving
    /// </summary>
    /// <returns>Byte array containing the serialized rule</returns>
    public byte[] ToBytes(bool isFirstRule)
    {
        List<byte> bytes =
        [
            .. Header,
            (byte)Name.Length,
            .. Encoding.Unicode.GetBytes(Name),
            .. Padding,
            .. Data.ToBytes(isFirstRule),
            0x00,
            0x00,
        ];

        return [.. bytes];
    }

    /// <summary>
    /// <para>Reads the <see cref="RuleItem" /> data from the <paramref name="binaryReader"/>.</para>
    /// <para>The <paramref name="binaryReader"/> is expected to be positioned at the beginning of the <see cref="RuleItem" /> to read.</para>
    /// </summary>
    /// <param name="binaryReader">The <see cref="BinaryReader" /> to read the <see cref="RuleItem" /> from.</param>
    /// <param name="length">The length of the <see cref="RuleItem" />.</param>
    /// <returns>A <see cref="RuleItem" /> object containing the data read from the <paramref name="binaryReader"/>, or <c>null</c> if the end of the stream is reached.</returns>
    internal static RuleItem? Parse(BinaryReader binaryReader, ref int length)
    {
        byte[] header = binaryReader.ReadBytes(0x4); // Record header
        length = binaryReader.ReadByte(); // Length of name
        string name = Encoding.Unicode.GetString(binaryReader.ReadBytes(length * 2)); // 2 bytes for each char
        byte[] padding = binaryReader.ReadBytes(0x14); // Padding
        if (binaryReader.BaseStream.Position == binaryReader.BaseStream.Length)
        {
            // incomplete final item. roll back to last item ending
            binaryReader.BaseStream.Position -= padding.Length;
            binaryReader.BaseStream.Position -= length * 2;
            binaryReader.BaseStream.Position -= header.Length;
            binaryReader.BaseStream.Position -= 1;
            return null;
        }
        length = binaryReader.ReadInt16(); // Get length of data block
        BaseRuleData ruleData = new(binaryReader.ReadBytes(length)); // read data block
        return new RuleItem
        {
            Header = header,
            Name = name,
            Padding = padding,
            Data = ruleData
        };
    }
}