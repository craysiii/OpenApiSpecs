namespace KnowBe4.Types;

public record Content(
    int StorePurchaseId,
    string ContentType,
    string Name,
    string Description,
    string Type,
    int Duration,
    bool Retired,
    DateTime RetirementDate,
    DateTime PublishDate,
    string Publisher,
    DateTime PurchaseDate,
    string PolicyUrl,
    int PolicyId,
    int MinimumTime,
    string DefaultLanguage,
    bool Published
);