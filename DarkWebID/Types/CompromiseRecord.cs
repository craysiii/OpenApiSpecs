namespace DarkWebID.Types;

public record CompromiseRecord(
    [property: Description("Unique identifier for the compromise")]
    Guid Uuid,
    [property: Description("The date that the compromise occurred (unix timestamp)")]
    int Occurred,
    [property: Description("The date that the compromise was detected (unix timestamp)")]
    int Detected,
    [property: Description("Was this compromise created from the API")]
    bool Api,
    [property: Description("Identifying property displayed in Dark Web ID portal")]
    string? RecordNumber,
    [property: Description("The type of compromise. One of 'domain', 'ip', or 'email'")]
    RecordType RecordType,
    [property: Description("Source category for this compromise. Describes where the compromise was detected")]
    string? Source,
    [property: Description("The origin of the compromised credentials")]
    string Origin,
    [property: Description("Status of the compromise. '0' indicates 'New'. '1' indicates 'In Progress', '2' indicates 'Resolved' and '3' indicates '3rd Party Tracking'")]
    int RecordStatus,
    [property: Description("Type category for the compromise. May contain additional data describing the compromise")]
    string? Compromise,
    [property: Description("Whether this compromise matches the password criteria for its organization. '1' indicates a low priority, '2' indicates a high priority (match found), '3' indicates that the organization does not have password criteria setup")]
    int PasswordCriteria,
    [property: Description("The username of the compromised credentials")]
    string? SearchValue,
    [property: Description("The password of the compromised credentials")]
    string? Password,
    [property: Description("The unique identifier for the search record that relates to this compromise")]
    string SearchRecord,
    [property: Description("The unique identifier for the organization that relates to this compromise")]
    Guid Organization,
    [property: Description("The format the password is in. For example 'cleartext' or 'encrypted'")]
    string? PasswordStatusName,
    [property: Description("The type of hashing algorithm used, if any at all")]
    string? HashType,
    [property: Description("The name of the attacker group the compromise is from")]
    string? KnownAttackers,
    [property: Description("The name of the target industries for the compromise")]
    string? TargetIndustries,
    [property: Description("How reliable this compromise record is from 0 to 100")]
    int? ReliabilityScore,
    [property: Description("URL of the page where the compromise was found")]
    string? SourceLocations,
    [property: Description("The title of the breach or leak event")]
    string? ActivityTitle,
    [property: Description("Description of the breach or leak event")]
    string? Description,
    [property: Description("Metadata contained in the Compromise")]
    PersonallyIndentifiableInformation? PiiHit,
    [property: Description("Attribution of the compromise")]
    CompromiseAttribution? Attribution,
    [property: Description("This is a legacy (deprecated) field, left for the backward compatibility of the API protocol today. It will always have the value of an empty string")]
    string? SynopsisId
);