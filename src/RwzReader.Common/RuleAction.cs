namespace RwzReader.Common;

/// <summary>
/// Provides support for different actions that a rule invokes
/// </summary>
public enum RuleAction : byte
{
    MoveToFolder = 0x2C,
    Delete = 0x2D,
    ForwardToEmail = 0x2E,
    ReplyUsingTemplate = 0x2F,
    DisplayMessage = 0x30,
    ClearMessageFlag = 0x32,
    AssignCategory = 0x33,
    PlayASound = 0x36, // Requires On This Computer Only
    MarkAsImportance = 0x37,
    CopyToFolder = 0x39,
    StopProcessingRules = 0x42,
    ForwardAsAttachment = 0x47,
    PrintIt = 0x48,
    StartAnApplication = 0x49, // Requires On This Computer Only
    PermanentlyDelete = 0x4A, // Requires Stop Processing Rules
    MarkAsRead = 0x4C,
    DisplayDesktopAlert = 0x4F,
    FlagForFollowup = 0x51,
    ClearCategories = 0x52,
    OnThisComputerOnly = 0xEF // Length 0x1e?
}