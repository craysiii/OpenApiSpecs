namespace DarkWebID.Types;

public record LiveSearch(
    [property: Description("Unique identifier for the compromise")]
    [property: JsonPropertyName("id")]
    int Id,
    [property: Description("Compromise created date. Format 'Y-m-dTH:i:s.uZ. Example 2021-12-13T09:45:33.402Z")]
    [property: JsonPropertyName("sort_date")]
    string SortDate,
    [property: Description("Email of compromise")]
    [property: JsonPropertyName("email")]
    string Email,
    [property: Description("Password of compromise")]
    [property: JsonPropertyName("password")]
    string Password,
    [property: Description("Domain of compromise")]
    [property: JsonPropertyName("domain")]
    string Domain,
    [property: Description("Source of compromise")]
    [property: JsonPropertyName("source")]
    string Source,
    [property: Description("Compromise type")]
    [property: JsonPropertyName("compromiseType")]
    string CompromiseType,
    [property: Description("Breach of compromise")]
    [property: JsonPropertyName("breach")]
    string Breach,
    [property: Description("Hash type of compromise")]
    [property: JsonPropertyName("hashType")]
    string HashType,
    [property: Description("Dates of compromise")]
    [property: JsonPropertyName("timeline")]
    Timeline Timeline,
    [property: Description("Does the compromise contain PII")]
    [property: JsonPropertyName("hasPii")]
    bool HasPersonallyIdentifiableInformation,
    [property: Description("Key array of PII for compromise")]
    [property: JsonPropertyName("pii")]
    List<string> PersonallyIdentifiableInformation,
    [property: Description("Values of PII for compromise")]
    [property: JsonPropertyName("package")]
    PersonallyIndentifiableInformation? Package
);