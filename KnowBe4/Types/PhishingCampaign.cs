namespace KnowBe4.Types;

public record PhishingCampaign(
    int CampaignId,
    string Name,
    List<GroupBase> Groups,
    double LastPhishPronePercentage,
    DateTime LastRun,
    string Status,
    bool Hidden,
    string SendDuration,
    string TrackDuration,
    string Frequency,
    List<int> DifficultyFilter,
    DateTime CreateDate,
    int PstsCount,
    List<PhishingSecurityTestBase> Psts
);