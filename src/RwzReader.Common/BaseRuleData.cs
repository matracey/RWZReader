using System.Text;

namespace RwzReader.Common;

/// <summary>
/// The block of data that comprises a rule, including criteria, actions, and exceptions
/// </summary>
public class BaseRuleData
{
    private const string CRuleElement = "CRuleElement";
    private byte[] _dataBytes;

    public RuleCriteria Criteria { get; private set; }

    public BaseRuleData(byte[] bytes)
    {
        _dataBytes = bytes;
        Parse();
    }

    private void Parse()
    {
        List<byte> tempBytes;

        // The first rule has an extra 16-byte section in the middle of it.  This is accounted for in the length of the rule.
        if (_dataBytes[0x4] == 0xFF && _dataBytes[0x5] == 0xFF) // Means extra 0x10 bytes are included
        {
            // Remove First rule data
            tempBytes = [.. _dataBytes];
            tempBytes[0x4] = 0x0;
            tempBytes[0x5] = 0x0;
            tempBytes.RemoveRange(0x6, 0x10);

            _dataBytes = [.. tempBytes];
        }

        Criteria = (RuleCriteria)_dataBytes[0x2A];
    }

    /// <summary>
    /// Serializes the rule data back into bytes, including the size information
    /// </summary>
    public byte[] ToBytes(bool isFirstRule = false)
    {
        List<byte> bytes = [.. _dataBytes];
        if (isFirstRule)
        {
            bytes[0x4] = 0xFF;
            bytes[0x5] = 0xFF;
            bytes.InsertRange(0x6, FirstRuleData);
        }

        bytes.InsertRange(0, [(byte)(bytes.Count & 0xFF), (byte)(bytes.Count >> 8)]);

        return [.. bytes];
    }

    private byte[] FirstRuleData
    {
        get
        {
            List<byte> bytes =
            [
                0x00,
                0x00,
                0x0C,
                0x00,
                .. Encoding.Default.GetBytes(CRuleElement),
            ];

            return [.. bytes];
        }
    }
}