namespace KnowBe4.Types;

public record RecipientResult(
    int RecipientId,
    int PstId,
    UserBase User,
    Template Template,
    DateTime ScheduledAt,
    DateTime DeliveredAt,
    DateTime OpenedAt,
    DateTime ClickedAt,
    DateTime RepliedAt,
    DateTime AttachmentOpenedAt,
    DateTime MacroEnabledAt,
    DateTime DataEnteredAt,
    DateTime QrCodeScanned,
    DateTime Called,
    DateTime CallbackDataEntered,
    DateTime ReportedAt,
    DateTime BouncedAt,
    string Ip,
    string IpLocation,
    string Browser,
    string BrowserVersion,
    string Os
);