namespace GoogleMapsServices.Client;

/// <summary>Status codes returned by service.
/// - `OK` indicating the API request was successful.
/// - `ZERO_RESULTS` indicating that the search was successful but returned no results. This may occur if the search was passed a bounds in a remote location.
/// - `INVALID_REQUEST` indicating the API request was malformed, generally due to the missing `input` parameter.
/// - `OVER_QUERY_LIMIT` indicating any of the following:
///   - You have exceeded the QPS limits.
///   - Billing has not been enabled on your account.
///   - The monthly $200 credit, or a self-imposed usage cap, has been exceeded.
///   - The provided method of payment is no longer valid (for example, a credit card has expired).
///   See the [Maps FAQ](https://developers.google.com/maps/faq#over-limit-key-error) for more information about how to resolve this error.
/// - `REQUEST_DENIED` indicating that your request was denied, generally because:
///   - The request is missing an API key.
///   - The `key` parameter is invalid.
/// - `UNKNOWN_ERROR` indicating an unknown error.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public enum PlacesAutocompleteStatus
{
    [System.Runtime.Serialization.EnumMember(Value = @"OK")]
    OK = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"ZERO_RESULTS")]
    ZERO_RESULTS = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"INVALID_REQUEST")]
    INVALID_REQUEST = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"OVER_QUERY_LIMIT")]
    OVER_QUERY_LIMIT = 3,

    [System.Runtime.Serialization.EnumMember(Value = @"REQUEST_DENIED")]
    REQUEST_DENIED = 4,

    [System.Runtime.Serialization.EnumMember(Value = @"UNKNOWN_ERROR")]
    UNKNOWN_ERROR = 5,

}