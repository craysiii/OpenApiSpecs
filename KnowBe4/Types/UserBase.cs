namespace KnowBe4.Types;

public record UserBase(
    int Id,
    string ProvisioningGuid,
    string FirstName,
    string LastName,
    string Email
);