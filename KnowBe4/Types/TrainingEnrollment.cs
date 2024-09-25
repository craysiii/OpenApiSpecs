namespace KnowBe4.Types;

public record TrainingEnrollment(
    int EnrollmentId,
    string ContentType,
    string ModuleName,
    EnrollmentUser User,
    string CampaignName,
    DateTime EnrollmentDate,
    DateTime StartDate,
    DateTime CompletionDate,
    string Status,
    int TimeSpent,
    bool PolicyAcknowledged
);