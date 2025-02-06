namespace DarkWebID.Types;

public record Timeline(
    [property: Description("Found date of compromise. Format 'Y-m-dTH:i:s.uZ. Example 2021-12-13T09:45:33.402Z")]
    string Found,
    [property: Description("Updated date of compromise. Format 'Y-m-dTH:i:s.uZ. Example 2021-12-13T09:45:33.402Z")]
    string Updated,
    [property: Description("Created date of compromise. Format 'Y-m-dTH:i:s.uZ. Example 2021-12-13T09:45:33.402Z")]
    string Created
);