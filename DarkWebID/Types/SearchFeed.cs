namespace DarkWebID.Types;

public record SearchFeed(
    [property: Description("The type of feed. (either 'ip', 'domain', or 'email')")]
    RecordType Type,
    [property: Description("Unique identifier for this feed")]
    Guid Uuid,
    [property: Description("The IP, domain, or email address whose compromises will be returned")]
    string SearchValue
);