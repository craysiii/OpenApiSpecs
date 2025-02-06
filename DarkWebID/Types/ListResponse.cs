namespace DarkWebID.Types;

public record ListResponse<T>(
    [property: Description("Url of the current request")]
    string Self,
    [property: Description("Url of the first page of data")]
    string First,
    [property: Description("Url of the final page of data")]
    string Last,
    [property: Description("Url of the next page of data")]
    string? Prev,
    [property: Description("Url of the previous page of data")]
    string? Next,
    [property: Description($"List of request objects")]
    List<T> List
);