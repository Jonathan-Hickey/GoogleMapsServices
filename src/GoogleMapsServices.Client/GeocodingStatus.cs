namespace GoogleMapsServices.Client;

/// <summary>The `status` field within the Geocoding response object contains the status of the request, and may contain debugging information to help you track down why geocoding is not working. The "status" field may contain the following values:
/// 
/// - `OK` indicates that no errors occurred; the address was successfully parsed and at least one geocode was returned.
/// - `ZERO_RESULTS` indicates that the geocode was successful but returned no results. This may occur if the geocoder was passed a non-existent address or a `latlng` in a remote location.
/// - `OVER_DAILY_LIMIT` indicates any of the following:
///   - The API key is missing or invalid.
///   - Billing has not been enabled on your account.
///   - A self-imposed usage cap has been exceeded.
///   - The provided method of payment is no longer valid (for example, a credit card has expired).
/// - `OVER_QUERY_LIMIT` indicates that you are over your quota.
/// - `REQUEST_DENIED` indicates that your request was denied.
/// - `INVALID_REQUEST` generally indicates that the query (address, components, or latlng) is missing.
/// - `UNKNOWN_ERROR` indicates that the request could not be processed due to a server error. The request may succeed if you try again.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public enum GeocodingStatus
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