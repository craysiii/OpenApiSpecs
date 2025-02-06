var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

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

// Build out app and OpenAPI config
var app = builder.Build();

app.MapOpenApi();

app.MapScalarApiReference(options =>
{
    options.Title = "DarkWebID Open API";
    options.Servers = new List<ScalarServer> { new ("https://secure.darkwebid.com") };
});

app.MapGet("/", () => Results.Redirect("/scalar/v1"))
    .ExcludeFromDescription();

app.MapGet("/services/organization.json",
    (
        [Description("Property by which to sort the results")]
        [FromQuery(Name = "sort")] OrganizationSort? sort,
        [Description("Page of search results to return. Default is 0 (first page)")]
        [FromQuery(Name = "page")] int? page = 0,
        [Description("Size of each results page (Max: 200)")]
        [FromQuery(Name = "limit")] int? limit = 200,
        [Description("Direction of the sort. Has no effect unless a sort is specified")]
        [FromQuery(Name = "direction")] SortDirection direction = SortDirection.ASC
    ) => Results.Ok())
    .Produces<ListResponse<Organization>>()
    .WithName("GetOrganizations")
    .WithTags("Organization")
    .WithSummary("Get Organizations")
    .WithDescription("List of organizations for the current user");

app.MapGet("/services/organization/{uuid:guid}.json",
    (
        [Description("UUID property for the organization to fetch")]
        [FromRoute(Name = "uuid")] Guid uuid
    ) => Results.Ok())
    .Produces<Organization>()
    .Produces(404)
    .WithName("GetOrganization")
    .WithTags("Organization")
    .WithSummary("Get Organization")
    .WithDescription("Get a specific organization");

app.MapGet("/services/supplychain.json",
    (
        [Description("Property by which to sort the results")]
        [FromQuery(Name = "sort")] SupplyChainSort? sort,
        [Description("Page of search results to return. Default is 0 (first page)")]
        [FromQuery(Name = "page")] int? page = 0,
        [Description("Size of each results page (Max: 200)")]
        [FromQuery(Name = "limit")] int? limit = 200,
        [Description("Direction of the sort. Has no effect unless a sort is specified")]
        [FromQuery(Name = "direction")] SortDirection direction = SortDirection.ASC
    ) => Results.Ok())
    .Produces<ListResponse<SupplyChain>>()
    .WithName("GetSupplyChains")
    .WithTags("SupplyChain")
    .WithSummary("Get Supply Chains")
    .WithDescription("List of supply chain comapnies for the current user");

app.MapGet("/services/supplychain/{uuid:guid}.json",
    (
        [Description("UUID property for the supply chain organization to fetch")]
        [FromRoute(Name = "uuid")] Guid uuid
    ) => Results.Ok())
    .Produces<SupplyChain>()
    .Produces(404)
    .WithName("GetSupplyChain")
    .WithTags("SupplyChain")
    .WithSummary("Get Supply Chain")
    .WithDescription("Get a specific supply chain");

app.MapGet("/services/compromise.json",
    (
        [Description("UUIDs of search feeds by which to filter the compromises")]
        [FromQuery(Name = "search_record[]")] Guid[] searchRecords,
        [Description("UUIDs of organizations by which to filter the compromises")]
        [FromQuery(Name = "organization[]")] Guid[] organizations,
        [Description("Begin date filter for imported date. Format: YYYY-MM-DD HH:MM:SS")]
        [FromQuery(Name = "beginDate")] string? beginDate,
        [Description("End date filter for imported date. Format: YYYY-MM-DD HH:MM:SS")]
        [FromQuery(Name = "endDate")] string? endDate,
        [Description("Property by which to sort the results")]
        [FromQuery(Name = "sort")] CompromiseSort? sort,
        [Description("Page of search results to return. Default is 0 (first page)")]
        [FromQuery(Name = "page")] int? page = 0,
        [Description("Size of each results page (Max: 200)")]
        [FromQuery(Name = "limit")] int? limit = 200,
        [Description("Direction of the sort. Has no effect unless a sort is specified")]
        [FromQuery(Name = "direction")] SortDirection direction = SortDirection.ASC
    ) => Results.Ok())
    .Produces<ListResponse<CompromiseRecord>>()
    .WithName("GetCompromiseRecords")
    .WithTags("Compromise")
    .WithSummary("Get Compromise Records")
    .WithDescription("List of compromises for the current user");

app.MapGet("/services/compromise/{uuid:guid}.json",
    (
        [Description("UUID property for the compromise to fetch")]
        [FromRoute(Name = "uuid")] Guid uuid
    ) => Results.Ok())
    .Produces<CompromiseRecord>()
    .Produces(404)
    .WithName("GetCompromiseRecord")
    .WithTags("Compromise")
    .WithSummary("Get Compromise Record")
    .WithDescription("Get a specific compromise");

app.MapGet("/services/user.json",
    (
        [Description("Property by which to sort the results")]
        [FromQuery(Name = "sort")] UserSort? sort,
        [Description("Page of search results to return. Default is 0 (first page)")]
        [FromQuery(Name = "page")] int? page = 0,
        [Description("Size of each results page (Max: 200)")]
        [FromQuery(Name = "limit")] int? limit = 200,
        [Description("Direction of the sort. Has no effect unless a sort is specified")]
        [FromQuery(Name = "direction")] SortDirection direction = SortDirection.ASC
    ) => Results.Ok())
    .Produces<ListResponse<User>>()
    .WithName("GetUsers")
    .WithTags("User")
    .WithSummary("Get Users")
    .WithDescription("List of users");

app.MapGet("/services/user/{uuid:guid}.json",
    (
        [Description("UUID property for the user to fetch")]
        [FromRoute(Name = "uuid")] Guid uuid
    ) => Results.Ok())
    .Produces<User>()
    .Produces(404)
    .WithName("GetUser")
    .WithTags("User")
    .WithSummary("Get User")
    .WithDescription("Get a user");

app.MapGet("/services/reseller.json",
    (
        [Description("Property by which to sort the results")]
        [FromQuery(Name = "sort")] ResellerSort? sort,
        [Description("Page of search results to return. Default is 0 (first page)")]
        [FromQuery(Name = "page")] int? page = 0,
        [Description("Size of each results page (Max: 200)")]
        [FromQuery(Name = "limit")] int? limit = 200,
        [Description("Direction of the sort. Has no effect unless a sort is specified")]
        [FromQuery(Name = "direction")] SortDirection direction = SortDirection.ASC
    ) => Results.Ok())
    .Produces<ListResponse<Reseller>>()
    .WithName("GetResellers")
    .WithTags("Reseller")
    .WithSummary("Get Resellers")
    .WithDescription("List of resellers");

app.MapGet("/services/reseller/{uuid:guid}.json",
    (
        [Description("UUID property for the reseller to fetch")]
        [FromRoute(Name = "uuid")] Guid uuid
    ) => Results.Ok())
    .Produces<Reseller>()
    .Produces(404)
    .WithName("GetReseller")
    .WithTags("Reseller")
    .WithSummary("Get Reseller")
    .WithDescription("Get a reseller");

app.MapGet("/services/livesearch.json",
    (
        [Description("Email or domain for livesearch")]
        [FromQuery(Name = "search")] string search
    ) => Results.Ok())
    .Produces<ListResponse<LiveSearch>>()
    .WithName("GetLivesearch")
    .WithTags("Livesearch")
    .WithSummary("Get Livesearch")
    .WithDescription("List of compromises by request for the search value");

app.Run();
