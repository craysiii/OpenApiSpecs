namespace DarkWebID.Types;

public record User(
    [property: Description("Unique identifier for the user")]
    Guid Uuid,
    [property: Description("First name of the user")]
    string FirstName,
    [property: Description("Last name of the user")]
    string LastName,
    [property: Description("Phone number of the user")]
    string? PhoneNumber,
    [property: Description("Country code for the phone number of the user")]
    int? CountryCode,
    [property: Description("Notification preferences of the user")]
    string NotificationPreferences,
    [property: Description("Email address of the user")]
    string Mail,
    [property: Description("Is the user active")]
    string? Active,
    [property: Description("Roles of the user")]
    List<string>? Roles,
    [property: Description("The client type of the user")]
    string? ClientType
);