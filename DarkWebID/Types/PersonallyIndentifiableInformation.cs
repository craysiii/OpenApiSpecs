namespace DarkWebID.Types;

public record PersonallyIndentifiableInformation(
    [property: Description("First Name")]
    [property: JsonPropertyName("namefirst")]
    string? FirstName,
    [property: Description("Last Name")]
    [property: JsonPropertyName("namelast")]
    string? LastName,
    [property: Description("Address Line 1")]
    [property: JsonPropertyName("addr1")]
    string? Address1,
    [property: Description("Address Line 2")]
    [property: JsonPropertyName("addr2")]
    string? Address2,
    [property: Description("Address City")]
    [property: JsonPropertyName("addrcity")]
    string? City,
    [property: Description("Address Zip Code")]
    [property: JsonPropertyName("addrzip")]
    string? ZipCode,
    [property: Description("Phone Number")]
    [property: JsonPropertyName("phone")]
    string? Phone,
    [property: Description("Social Security Number")]
    [property: JsonPropertyName("ssn")]
    string? SocialSecurityNumber,
    [property: Description("No idea tbh LMAO")]
    [property: JsonPropertyName("mmn")]
    string? Mmn,
    [property: Description("Date of Birth")]
    [property: JsonPropertyName("dob")]
    string? DateOfBirth,
    [property: Description("Drivers License Number")]
    [property: JsonPropertyName("dlnumber")]
    string? DriversLicenseNumber,
    [property: Description("User Id")]
    [property: JsonPropertyName("userid")]
    string? UserId,
    [property: Description("Card Type")]
    [property: JsonPropertyName("cardtype")]
    string? CardType,
    [property: Description("Card Name")]
    [property: JsonPropertyName("cardname")]
    string? CardName,
    [property: Description("Card Number")]
    [property: JsonPropertyName("cardnum")]
    string? CardNumber,
    [property: Description("Card Verification Number")]
    [property: JsonPropertyName("cardcvn")]
    string? CardVerificationNumber,
    [property: Description("Card PIN")]
    [property: JsonPropertyName("cardpin")]
    string? CardPin,
    [property: Description("Card Expiration Date")]
    [property: JsonPropertyName("cardexpdate")]
    string? CardExpirationDate,
    [property: Description("Card Expiration Year")]
    [property: JsonPropertyName("cardexpyear")]
    string? CardExpirationYear,
    [property: Description("Card Bank Id")]
    [property: JsonPropertyName("cardbin")]
    string? CardBankId,
    [property: Description("Paypal User Id")]
    [property: JsonPropertyName("paypaluid")]
    string? PaypalUserId,
    [property: Description("Ebay User Id")]
    [property: JsonPropertyName("ebayuid")]
    string? EbayUserId,
    [property: Description("Bank Name")]
    [property: JsonPropertyName("bankname")]
    string? BankName,
    [property: Description("Bank Routing Number")]
    [property: JsonPropertyName("bankroute")]
    string? BankRoutingNumber,
    [property: Description("Bank Account Number")]
    [property: JsonPropertyName("bankacct")]
    string? BankAccountNumber,
    [property: Description("Bank User Id")]
    [property: JsonPropertyName("bankuid")]
    string? BankUserId,
    [property: Description("Bank Password")]
    [property: JsonPropertyName("bankpwd")]
    string? BankPassword,
    [property: Description("Bank PIN")]
    [property: JsonPropertyName("bankpin")]
    string? BankPin,
    [property: Description("Medical Id")]
    [property: JsonPropertyName("medicalid")]
    string? MedicalId,
    [property: Description("Medical Provider")]
    [property: JsonPropertyName("medicalprovider")]
    string? MedicalProvider,
    [property: Description("Passport Number")]
    [property: JsonPropertyName("passportnum")]
    string? PassportNumber
    
);