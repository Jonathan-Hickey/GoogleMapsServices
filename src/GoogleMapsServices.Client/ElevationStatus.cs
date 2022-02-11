namespace GoogleMapsServices.Client;

/// <summary>Status codes returned by service.
/// - `OK` indicating the API request was successful.
/// - `DATA_NOT_AVAILABLE` indicating that there's no available data for the input locations. 
/// - `INVALID_REQUEST` indicating the API request was malformed.
/// - `OVER_DAILY_LIMIT` indicating any of the following:
///   - The API key is missing or invalid.
///   - Billing has not been enabled on your account.
///   - A self-imposed usage cap has been exceeded.
///   - The provided method of payment is no longer valid (for example, a credit card has expired).
/// - `OVER_QUERY_LIMIT` indicating the requestor has exceeded quota.
/// - `REQUEST_DENIED` indicating the API did not complete the request.
/// - `UNKNOWN_ERROR` indicating an unknown error.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public enum ElevationStatus
{
    [System.Runtime.Serialization.EnumMember(Value = @"OK")]
    OK = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"DATA_NOT_AVAILABLE")]
    DATA_NOT_AVAILABLE = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"INVALID_REQUEST")]
    INVALID_REQUEST = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"OVER_DAILY_LIMIT")]
    OVER_DAILY_LIMIT = 3,

    [System.Runtime.Serialization.EnumMember(Value = @"OVER_QUERY_LIMIT")]
    OVER_QUERY_LIMIT = 4,

    [System.Runtime.Serialization.EnumMember(Value = @"REQUEST_DENIED")]
    REQUEST_DENIED = 5,

    [System.Runtime.Serialization.EnumMember(Value = @"UNKNOWN_ERROR")]
    UNKNOWN_ERROR = 6,

}