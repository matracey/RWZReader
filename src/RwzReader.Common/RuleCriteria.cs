namespace RwzReader.Common;

public enum RuleCriteria : byte
{
    OnThisComputerOnly = 0x4F,
    WhereMyNameIsInTo = 0xC2,
    SentOnlyToMe = 0xC9,
    WhereMyNameIsNotInTo = 0xCA,
    FromPeople = 0xCB,
    SentToPeople = 0xCC,
    WithWordsInSubject = 0xCD,
    WithWordsInBody = 0xCE,
    WithWordsInSubjectOrBody = 0xCF,
    WhichIsAnAutomaticReply = 0xDC,
    WhichHasAnAttachment = 0xDE,
    WithSelectedProperties = 0xDF,
    WhichHasASizeBetween = 0xE0,
    WHereMyNameIsInCC = 0xE2,
    WhereMyNameIsInToOrCC = 0xE3,
    WhichUsesTheForm = 0xE4,
    WithWordsInRecipientsAddress = 0xE5,
    WithWordsInSendersAddress = 0xE6,
    WithWordsInMessageHeader = 0xE8,
    WhichIsAMeetingInvoice = 0xF1,
    AssignedToAnyCategory = 0xF6,
    FromRSSFeed = 0xF7,
    AssignedToSpecificCategory = 0xD7,
    FlaggedForAction = 0xD0,
    FlaggedAsImportance = 0xD2,
    FlaggedAsSensitivity = 0xD3,
    ReceivedBetween = 0xE1,
    ThroughSpecificAccount = 0xEE,
    SenderInSpeciedAddressBook = 0xF0 // Requires On This Computer only
}