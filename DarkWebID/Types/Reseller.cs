namespace DarkWebID.Types;

public record Reseller(
    [property: Description("Unique identifier for the reseller")]
    Guid Uuid,
    [property: Description("Name of the reseller")]
    string Name,
    [property: Description("Number of domains a reseller is currently searching on")]
    int DomainUsage,
    [property: Description("Number of domains for which reseller is currenly configured")]
    int DomainLimit,
    [property: Description("Number of live searched a reseller has used this month")]
    int SearchUsage,
    [property: Description("Number of live searches a reseller is permitted per month")]
    int SearchLimit,
    [property: Description("Number of email address feeds that a reseller is currently searching on")]
    int EmailUsage,
    [property: Description("Number of ip address feeds that a reseller is currently searching on")]
    int IpUsage,
    [property: Description("Is the reseller enabled")]
    bool? Enabled
);