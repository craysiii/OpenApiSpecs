namespace DarkWebID.Types;

public record CompromiseAttribution(
    [property: Description("The country of the breached website")]
    [property: JsonPropertyName("breachedsitecountry")]
    string? BreachedSiteCountry,
    [property: Description("The sector of the breached website")]
    [property: JsonPropertyName("breachedsector")]
    string? BreachedSector,
    [property: Description("The hacker involved in the compromise")]
    [property: JsonPropertyName("hacker")]
    string? Hacker,
    [property: Description("The hacker group involved in the compromise")]
    [property: JsonPropertyName("hackergroup")]
    string? HackerGroup,
    [property: Description("The password status of the compromise")]
    [property: JsonPropertyName("passwordstatus")]
    string? PasswordStatus,
    [property: Description("The hacking operation of the compromise")]
    [property: JsonPropertyName("hackingoperation")]
    string? HackingOperation,
    [property: Description("The motivation behind the compromise")]
    [property: JsonPropertyName("motivation")]
    string? Motivation,
    [property: Description("The strain of the malware related to the compromise")]
    [property: JsonPropertyName("malwarestrainname")]
    string? MalwareStrainName
);