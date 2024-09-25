namespace KnowBe4.Types;

public record TrainingCampaign(
    int CampaignId,
    string Name,
    List<GroupBase> Groups,
    string Status,
    List<Content> Content,
    string DurationType,
    DateTime StartDate,
    DateTime EndDate,
    string RelativeDuration,
    bool AutoEnroll,
    bool AllowMultipleEnrollments,
    double CompletionPercentage
);