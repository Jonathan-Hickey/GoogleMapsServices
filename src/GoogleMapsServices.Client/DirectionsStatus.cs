namespace GoogleMapsServices.Client;

/// <summary>The status field within the Directions response object contains the status of the request, and may contain debugging information to help you track down why the Directions service failed. The status field may contain the following values:
/// 
/// - `OK` indicates the response contains a valid result.
/// - `NOT_FOUND` indicates at least one of the locations specified in the request's origin, destination, or waypoints could not be geocoded.
/// - `ZERO_RESULTS` indicates no route could be found between the origin and destination.
/// - `MAX_WAYPOINTS_EXCEEDED` indicates that too many waypoints were provided in the request. For applications using the Directions API as a web service, or the directions service in the Maps JavaScript API, the maximum allowed number of waypoints is 25, plus the origin and destination.
/// - `MAX_ROUTE_LENGTH_EXCEEDED` indicates the requested route is too long and cannot be processed. This error occurs when more complex directions are returned. Try reducing the number of waypoints, turns, or instructions.
/// - `INVALID_REQUEST` indicates that the provided request was invalid. Common causes of this status include an invalid parameter or parameter value.
/// - `OVER_DAILY_LIMIT` indicates any of the following:
///     - The API key is missing or invalid.
///     - Billing has not been enabled on your account.
///     - A self-imposed usage cap has been exceeded.
///     - The provided method of payment is no longer valid (for example, a credit card has expired).
///     See the [Maps FAQ](https://developers.google.com/maps/faq#over-limit-key-error) to learn how to fix this.
/// - `OVER_QUERY_LIMIT` indicates the service has received too many requests from your application within the allowed time period.
/// - `REQUEST_DENIED` indicates that the service denied use of the directions service by your application.
/// - `UNKNOWN_ERROR` indicates a directions request could not be processed due to a server error. The request may succeed if you try again.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public enum DirectionsStatus
{
    [System.Runtime.Serialization.EnumMember(Value = @"OK")]
    OK = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"NOT_FOUND")]
    NOT_FOUND = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"ZERO_RESULTS")]
    ZERO_RESULTS = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"MAX_WAYPOINTS_EXCEEDED")]
    MAX_WAYPOINTS_EXCEEDED = 3,

    [System.Runtime.Serialization.EnumMember(Value = @"MAX_ROUTE_LENGTH_EXCEEDED")]
    MAX_ROUTE_LENGTH_EXCEEDED = 4,

    [System.Runtime.Serialization.EnumMember(Value = @"INVALID_REQUEST")]
    INVALID_REQUEST = 5,

    [System.Runtime.Serialization.EnumMember(Value = @"OVER_DAILY_LIMIT")]
    OVER_DAILY_LIMIT = 6,

    [System.Runtime.Serialization.EnumMember(Value = @"OVER_QUERY_LIMIT")]
    OVER_QUERY_LIMIT = 7,

    [System.Runtime.Serialization.EnumMember(Value = @"REQUEST_DENIED")]
    REQUEST_DENIED = 8,

    [System.Runtime.Serialization.EnumMember(Value = @"UNKNOWN_ERROR")]
    UNKNOWN_ERROR = 9,

}