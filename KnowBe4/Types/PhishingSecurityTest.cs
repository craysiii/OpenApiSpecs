namespace KnowBe4.Types;

public record PhishingSecurityTest(
    int CampaignId,
    int PstId,
    string Status,
    string Name,
    List<GroupBase> Groups,
    double PhishPronePercentage,
    DateTime StartedAt,
    int Duration,
    List<CategoryBase> Categories,
    Template Template,
    LandingPage LandingPage,
    int ScheduledCount,
    int DeliveredCount,
    int OpenedCount,
    int ClickedCount,
    int RepliedCount,
    int AttachmentOpenCount,
    int MacroEnabledCount,
    int DataEnteredCount,
    int QrCodeScannedCount,
    int ReportedCount,
    int BouncedCount,
    int CalledCount,
    int CallbackDataEnteredCount
);