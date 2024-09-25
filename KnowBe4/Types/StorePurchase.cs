namespace KnowBe4.Types;

public record StorePurchase(
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
    string PolicyUrl
);