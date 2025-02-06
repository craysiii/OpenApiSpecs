namespace DarkWebID.Types;

public record SupplyChain(
    [property: Description("Industry category for this organization")]
    string FieldIndustry,
    [property: Description("Industry category for this organization")]
    string? FieldSupplyOrgType,
    [property: Description("List of Search Feeds representing the IP feeds for this organization")]
    List<SearchFeed> FieldIpAddresses,
    [property: Description("List of Search Feeds representing the domain feeds for this organization")]
    List<SearchFeed> FieldDomains,
    [property: Description("Number of compromses found for this organization. May be empty if none have been found")]
    int FieldCompromiseCount,
    [property: Description("Name of the organization")]
    string Title,
    [property: Description("Unique identifier for this organization")]
    Guid Uuid
);