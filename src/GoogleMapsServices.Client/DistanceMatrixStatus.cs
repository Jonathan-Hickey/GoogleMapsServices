namespace GoogleMapsServices.Client;

/// <summary>Status codes returned by service.
/// - `OK` indicates the response contains a valid result.
/// - `INVALID_REQUEST` indicates that the provided request was invalid.
/// - `MAX_ELEMENTS_EXCEEDED` indicates that the product of origins and destinations exceeds the per-query limit.
/// - `MAX_DIMENSIONS_EXCEEDED` indicates that the number of origins or destinations exceeds the per-query limit.
/// - `OVER_DAILY_LIMIT` indicates any of the following:
///   - The API key is missing or invalid.
///   - Billing has not been enabled on your account.
///   - A self-imposed usage cap has been exceeded.
///   - The provided method of payment is no longer valid (for example, a credit card has expired).
/// - `OVER_QUERY_LIMIT` indicates the service has received too many requests from your application within the allowed time period.
/// - `REQUEST_DENIED` indicates that the service denied use of the Distance Matrix service by your application.
/// - `UNKNOWN_ERROR` indicates a Distance Matrix request could not be processed due to a server error. The request may succeed if you try again.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public enum DistanceMatrixStatus
{
    [System.Runtime.Serialization.EnumMember(Value = @"OK")]
    OK = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"INVALID_REQUEST")]
    INVALID_REQUEST = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"MAX_ELEMENTS_EXCEEDED")]
    MAX_ELEMENTS_EXCEEDED = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"MAX_DIMENSIONS_EXCEEDED")]
    MAX_DIMENSIONS_EXCEEDED = 3,

    [System.Runtime.Serialization.EnumMember(Value = @"OVER_DAILY_LIMIT")]
    OVER_DAILY_LIMIT = 4,

    [System.Runtime.Serialization.EnumMember(Value = @"OVER_QUERY_LIMIT")]
    OVER_QUERY_LIMIT = 5,

    [System.Runtime.Serialization.EnumMember(Value = @"REQUEST_DENIED")]
    REQUEST_DENIED = 6,

    [System.Runtime.Serialization.EnumMember(Value = @"UNKNOWN_ERROR")]
    UNKNOWN_ERROR = 7,

}