using RwzReader.Common;

namespace RWZReader;

public partial class DetailsForm : Form
{
    private readonly RuleItem _rule;

    public DetailsForm(RuleItem item)
    {
        InitializeComponent();
        _rule = item;
    }

    private void DetailsForm_Load(object sender, EventArgs e)
    {
        Parse();
    }

    private void Parse()
    {
        // Implementation would go here
        // Loop through rule data bytes and add rows to dgDetails
        // Example pseudo-implementation:
        /*
        byte[] bytes = rule.Data.GetBytes();
        for (int i = 0; i < bytes.Length; i++)
        {
            string description = GetDescription(i, bytes[i]);
            dgDetails.Rows.Add(description, $"0x{i:X2}", $"0x{bytes[i]:X2}");
        }
        */
    }
}