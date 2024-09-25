namespace KnowBe4.Types;

public record PhishingSecurityTestBase(
    int PstId,
    string Status,
    DateTime StartDate,
    int UsersCount,
    double PhishPronePercentage
);