namespace KnowBe4.Types;

public record Group(
    int Id,
    string Name,
    string GroupType,
    string ProvisioningGuid,
    int MemberCount,
    double CurrentRiskScore,
    string Status
);