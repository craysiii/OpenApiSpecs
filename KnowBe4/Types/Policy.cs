namespace KnowBe4.Types;

public record Policy(
    int PolicyId,
    string ContentType,
    string Name,
    int MinimumTime,
    string DefaultLanguage,
    int Status
);