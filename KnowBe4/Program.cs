var builder = WebApplication.CreateBuilder(args);

// Configure serialization
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});
builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});

var servers = new List<OpenApiServer>
{
    new()
    {
        Url = "https://us.api.knowbe4.com/v1",
        Description = "US Server"
    },
    new()
    {
        Url = "https://eu.api.knowbe4.com/v1",
        Description = "EU Server"
    },
    new()
    {
        Url = "https://ca.api.knowbe4.com/v1",
        Description = "CA Server"
    },
    new()
    {
        Url = "https://uk.api.knowbe4.com/v1",
        Description = "UK Server"
    },
    new()
    {
        Url = "https://de.api.knowbe4.com/v1",
        Description = "DE Server"
    }
};

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "KnowBe4 Reporting",
        Description = "KnowBe4’s Reporting APIs are REST APIs that allow you to pull phishing, training, user, and group data from the KnowBe4 console.",
        
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.RoutePrefix = string.Empty;
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "KnowBe4 v1");
});

// Account
app.MapGet("/account", () => Results.Ok())
    .Produces<Account>()
    .WithName("GetAccountAndSubscriptionData")
    .WithTags("Account")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get Account And Subscription Data",
        Description = "This endpoint retrieves account data from you KnowBe4 account, including your subscription level, number of seats, risk score history, and more.",
        Servers = servers
    });

app.MapGet("/account/risk_score_history",
        (
            [FromQuery(Name = "full")] bool? full,
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "per_page")] int? perPage
        ) => Results.Ok())
    .Produces<List<HistoricalRiskScore>>()
    .WithName("GetAccountRiskScoreHistory")
    .WithTags("Account")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get Account Risk Score History",
        Description = "This endpoint retrieves your KnowBe4 account risk score history."
    });

// Users
app.MapGet("/users",
        (
            [FromQuery(Name = "status")] Status? status,
            [FromQuery(Name = "group_id")]int? groupId,
            [FromQuery(Name = "expand")]Expand? expand,
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "per_page")] int? perPage
        ) => Results.Ok())
    .Produces<List<User>>()
    .WithName("GetAListOfUsers")
    .WithTags("Users")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a List of All Users",
        Description = "This endpoint retrieves a list of all users in your KnowBe4 account."
    });

app.MapGet("/users/{user_id}",
    (
        [FromRoute(Name = "user_id")] int userId
    ) => Results.Ok())
    .Produces<User>()
    .WithName("GetASpecificUser")
    .WithTags("Users")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a Specific User",
        Description = "This endpoint retrieves a specific user based on the provided user identifier (user_id)."
    });

app.MapGet("/groups/{group_id}/members",
        (
            [FromRoute(Name = "group_id")] int groupId,
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "per_page")] int? perPage
        ) => Results.Ok())
    .Produces<List<User>>()
    .WithName("GetAListOfUsersInASpecificGroup")
    .WithTags("Users")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a List of Users in a Specific Group",
        Description = "This endpoint retrieves a list of all users who are members of a specific group."
    });

app.MapGet("/users/{user_id}/risk_score_history",
        (
            [FromRoute(Name = "user_id")] int userId
        ) => Results.Ok())
    .Produces<List<HistoricalRiskScore>>()
    .WithName("GetASpecificUsersRiskScoreHistory")
    .WithTags("Users")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a Specific User's Risk Score History",
        Description = "This endpoint retrieves risk score history for a specific user based on the provided user identifier (user_id)."
    });

// Groups
app.MapGet("/groups",
        (
            [FromQuery(Name = "status")] Status? status,
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "per_page")] int? perPage
        ) => Results.Ok())
    .Produces<List<Group>>()
    .WithName("GetAListOfAllGroups")
    .WithTags("Groups")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a List of All Groups",
        Description = "This endpoint retrieves a list of all groups in your KnowBe4 account."
    });

app.MapGet("/groups/{group_id}",
        (
            [FromRoute(Name = "group_id")] int groupId
        ) => Results.Ok())
    .Produces<Group>()
    .WithName("GetASpecificGroup")
    .WithTags("Groups")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a Specific Group",
        Description = "This endpoint retrieves a specific group in your KnowBe4 account, based on the provided group identifier (group_id)."
    });

app.MapGet("/group/{group_id}/risk_score_history",
        (
            [FromRoute(Name = "group_id")] int groupId
        ) => Results.Ok())
    .Produces<List<HistoricalRiskScore>>()
    .WithName("GetASpecificGroupsRiskScoreHistory")
    .WithTags("Groups")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a Specific Group's Risk Score History",
        Description = "This endpoint retrieves risk score history for a specific group in your KnowBe4 account, based on the provided group identifier (group_id)."
    });

// Phishing
app.MapGet("/phishing/campaigns",
        (
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "per_page")] int? perPage    
        ) => Results.Ok())
    .Produces<List<PhishingCampaign>>()
    .WithName("GetAListOfAllPhishingCampaigns")
    .WithTags("Phishing")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get All Phishing Campaigns",
        Description = "This (undocumented) endpoint retrieves a list of all phishing campaigns in your account."
    });

app.MapGet("/phishing/campaigns/{campaign_id}",
        (
            [FromRoute(Name = "campaign_id")] int campaignId,
            [FromQuery(Name = "campaign_type")] CampaignType? campaignType
        ) => Results.Ok())
    .Produces<PhishingCampaign>()
    .WithName("GetASpecificPhishingCampaign")
    .WithTags("Phishing")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a Specific Phishing Campaign",
        Description = "This endpoint retrieves data from a specific phishing campaign, based on the provided campaign identifier (campaign_id)."
    });

app.MapGet("/phishing/security_tests",
        (
            [FromQuery(Name = "campaign_type")] CampaignType? campaignType,
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "per_page")] int? perPage
        ) => Results.Ok())
    .Produces<List<PhishingSecurityTest>>()
    .WithName("GetAllPhishingSecurityTests")
    .WithTags("Phishing")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get All Phishing Security Tests (PSTs)",
        Description = "This endpoint retrieves a list of all phishing security tests in your account."
    });

app.MapGet("/phishing/campaigns/{campaign_id}/security_tests",
        (
            [FromRoute(Name = "campaign_id")] int campaignId,
            [FromQuery(Name = "campaign_type")] CampaignType? campaignType
        ) => Results.Ok())
    .Produces<List<PhishingSecurityTest>>()
    .WithName("GetAllPSTsFromASpecificCampaign")
    .WithTags("Phishing")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get All PSTs From a Specific Campaign",
        Description = "This endpoint retrieves a list of all phishing security tests from a specific phishing campaign, based on the provided phishing campaign identifier (campaign_id)."
    });

app.MapGet("/phishing/security_tests/{pst_id}",
        (
            [FromRoute(Name = "pst_id")] int pstId,
            [FromQuery(Name = "campaign_type")] CampaignType? campaignType
        ) => Results.Ok())
    .Produces<PhishingSecurityTest>()
    .WithName("GetASpecificPST")
    .WithTags("Phishing")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a Specific PST",
        Description = "This endpoint retrieves data from a specific phishing security test, based on the provided phishing security test identifier (pst_id)."
    });

app.MapGet("/phishing/security_tests/{pst_id}/recipients",
        (
            [FromRoute(Name = "pst_id")] int pstId,
            [FromQuery(Name = "campaign_type")] CampaignType? campaignType,
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "per_page")] int? perPage
        ) => Results.Ok())
    .Produces<List<RecipientResult>>()
    .WithName("GetAllRecipientResults")
    .WithTags("Phishing")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get All Recipient Results",
        Description = "This endpoint retrieves a list of all the recipients (users) that were part of a specific phishing security test, based on the provided phishing security test identifier (pst_id)."
    });

app.MapGet("/phishing/security_tests/{pst_id}/recipients/{recipient_id}",
        (
            [FromRoute(Name = "pst_id")] int pstId,
            [FromRoute(Name = "recipient_id")] int recipientId,
            [FromQuery(Name = "campaign_type")] CampaignType? campaignType
        ) => Results.Ok())
    .Produces<RecipientResult>()
    .WithName("GetASpecificRecipientsResults")
    .WithTags("Phishing")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a Specific Recipient's Results",
        Description = "This endpoint retrieves details about a specific user's phishing security test results, based on the provided phishing security test identifier (pst_id) and recipient identifier (recipient_id)."
    });

// Training
app.MapGet("/training/store_purchases",
        (
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "per_page")] int? perPage    
        ) => Results.Ok())
    .Produces<List<StorePurchase>>()
    .WithName("GetAllStorePurchases")
    .WithTags("Training")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get all Store Purchases",
        Description = "This endpoint retrieves a list of all Store Purchases in your KnowBe4 account."
    });

app.MapGet("/training/store_purchases/{store_purchase_id}",
        (
            [FromRoute(Name = "store_purchase_id")] int storePurchaseId
        ) => Results.Ok())
    .Produces<StorePurchase>()
    .WithName("GetASpecificStorePurchase")
    .WithTags("Training")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a Specific Store Purchase",
        Description = "This endpoint retrieves a specific Store Purchase from your KnowBe4 account."
    });

app.MapGet("/training/policies",
        (
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "per_page")] int? perPage    
        ) => Results.Ok())
    .Produces<List<Policy>>()
    .WithName("GetAllPolicies")
    .WithTags("Training")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get all Policies",
        Description = "This endpoint retrieves a list of all uploaded policies in your KnowBe4 account."
    });

app.MapGet("/training/policies/{policies_id}",
        (
            [FromRoute(Name = "policies_id")] int policiesId
        ) => Results.Ok())
    .Produces<Policy>()
    .WithName("GetASpecificPolicy")
    .WithTags("Training")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a Specific Policy",
        Description = "This endpoint retrieves a specific uploaded policy from your KnowBe4 account."
    });

app.MapGet("/training/campaigns",
        (
            [FromQuery(Name = "exclude_percentages")] bool? excludePercentages,
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "per_page")] int? perPage
        ) => Results.Ok())
    .Produces<List<TrainingCampaign>>()
    .WithName("GetAllTrainingCampaigns")
    .WithTags("Training")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get all Training Campaigns",
        Description = "This endpoint retrieves a list of all Training Campaigns in your KnowBe4 account."
    });

app.MapGet("/training/campaigns/{campaign_id}",
        (
            [FromRoute(Name = "campaign_id")] int campaignId
        ) => Results.Ok())
    .Produces<TrainingCampaign>()
    .WithName("GetASpecificTrainingCampaign")
    .WithTags("Training")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a Specific Training Campaign",
        Description = "This endpoint retrieves a specific Training Campaign from your KnowBe4 account."
    });

app.MapGet("/training/enrollments",
        (
            [FromQuery(Name = "user_id")] int? userId,
            [FromQuery(Name = "exclude_archived_users")] bool? excludeArchivedUsers,
            [FromQuery(Name = "store_purchase_id")] int? storePurchaseId,
            [FromQuery(Name = "include_store_purchase_id")] bool? includeStorePurchaseId,
            [FromQuery(Name = "campaign_id")] int? campaignId,
            [FromQuery(Name = "include_campaign_id")] bool? includeCampaignId,
            [FromQuery(Name = "page")] int? page,
            [FromQuery(Name = "per_page")] int? perPage
        ) => Results.Ok())
    .Produces<List<TrainingEnrollment>>()
    .WithName("GetAllTrainingEnrollments")
    .WithTags("Training")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get all Training Enrollments",
        Description = "This endpoint retrieves a list of all Training Enrollments in your KnowBe4 account."
    });

app.MapGet("/training/enrollments/{enrollment_id}",
        (
            [FromRoute(Name = "enrollment_id")] int enrollmentId,
            [FromQuery(Name = "include_campaign_id")] bool? includeCampaignId
        ) => Results.Ok())
    .Produces<TrainingEnrollment>()
    .WithName("GetASpecificTrainingEnrollment")
    .WithTags("Training")
    .WithOpenApi(operation => new OpenApiOperation(operation)
    {
        Summary = "Get a Specific Training Enrollment",
        Description = "This endpoint retrieves a specific Training Enrollment from your KnowBe4 account."
    });

app.Run();
