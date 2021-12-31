namespace GoogleMapsServices.Client;

/// <summary>The `status` field within the Time Zone response object contains the status of the request. The `status` field may contain the following values:
/// 
/// - `OK` indicates that the request was successful.
/// - `INVALID_REQUEST` indicates that the request was malformed.
/// - `OVER_DAILY_LIMIT` indicates any of the following:
///   - The API key is missing or invalid.
///   - Billing has not been enabled on your account.
///   - A self-imposed usage cap has been exceeded.
///   - The provided method of payment is no longer valid (for example, a credit card has expired).
/// 
/// - `OVER_QUERY_LIMIT` indicates the requestor has exceeded quota.
/// - `REQUEST_DENIED` indicates that the API did not complete the request. Confirm that the request was sent over HTTPS instead of HTTP.
/// - `UNKNOWN_ERROR` indicates an unknown error.
/// - `ZERO_RESULTS` indicates that no time zone data could be found for the specified position or time. Confirm that the request is for a location on land, and not over water.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public enum TimeZoneStatus
{
    [System.Runtime.Serialization.EnumMember(Value = @"OK")]
    OK = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"INVALID_REQUEST")]
    INVALID_REQUEST = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"OVER_DAILY_LIMIT")]
    OVER_DAILY_LIMIT = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"OVER_QUERY_LIMIT")]
    OVER_QUERY_LIMIT = 3,

    [System.Runtime.Serialization.EnumMember(Value = @"REQUEST_DENIED")]
    REQUEST_DENIED = 4,

    [System.Runtime.Serialization.EnumMember(Value = @"UNKNOWN_ERROR")]
    UNKNOWN_ERROR = 5,

    [System.Runtime.Serialization.EnumMember(Value = @"ZERO_RESULTS")]
    ZERO_RESULTS = 6,

}