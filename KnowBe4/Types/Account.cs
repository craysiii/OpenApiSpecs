namespace KnowBe4.Types;

public record Account(
    string Name,
    string Type,
    List<string> Domains,
    List<Admin> Admins,
    string SubscriptionLevel,
    string SubscriptionEndDate,
    int NumberOfSeats,
    double CurrentRiskScore
);