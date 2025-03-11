using System.Text;

namespace RwzReader.Common.Actions;

public class AssignCategory
{
    private byte[] _header = [];

    public string Name { get; private set; } = string.Empty;

    private AssignCategory()
    {
    }

    public static AssignCategory Parse(byte[] bytes)
    {
        using BinaryReader binaryReader = new(new MemoryStream(bytes));
        
        int len = binaryReader.ReadByte();
        string name = Encoding.Unicode.GetString(binaryReader.ReadBytes(len * 2));
        byte[] header = binaryReader.ReadBytes(0x8);

        return new AssignCategory()
        {
            Name = name,
            _header = header,
        };
    }

    public byte[] ToBytes()
    {
        return [
            (byte)RuleAction.AssignCategory,
            .. _header, // Length 0x0b
            (byte)Name.Length,
            .. Encoding.Unicode.GetBytes(Name),
        ];
    }
}