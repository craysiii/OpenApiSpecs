

namespace DarkWebID.Types;

public record Organization(
    [property: Description("Industry category for this organization")]
    string? Industry,
    [property: Description("List of Search Feeds representing the IP feeds for this organization")]
    List<SearchFeed> IpAddresses,
    [property: Description("List of Search Feeds representing the domain feeds for this organization")]
    List<SearchFeed> EmailDomains,
    [property: Description("List of Search Feeds representing the personal email feeds for this organization")]
    List<SearchFeed> EmailAddresses,
    [property: Description("Number of compromises found for this organization. May be empty if none have been found")]
    int CompromiseCount,
    [property: Description("Name of the organization")]
    string Title,
    [property: Description("Unique identifier for this organization")]
    Guid Uuid,
    [property: Description("Unique identifier of the Reseller for this organization")]
    Guid? Reseller,
    [property: Description("The number of employees in the organization")]
    string? EmployeeCount,
    [property: Description("Should clean bill of health emails be sent")]
    bool? CleanBillOfHealthEmailEnabled,
    [property: Description("Clean Bill of Health Destination emails")]
    List<string>? CleanBillOfHealthEmailDestinations,
    [property: Description("Clean Bill of Health reply to email")]
    string? CleanBillOfHealthEmailReplyTo,
    [property: Description("Notification preferences of the User")]
    string? NotificationPreferences,
    [property: Description("Notification email addresses")]
    List<string>? NotificationEmailAddresses
);