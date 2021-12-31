namespace GoogleMapsServices.Client;

/// <summary>The `status` field within the Streetview Metadata response object contains the status of the request. The `status` field may contain the following values:
/// 
/// - `OK` indicates that no errors occurred; a panorama is found and metadata is returned.
/// - `INVALID_REQUEST` indicates that the request was malformed.
/// - `NOT_FOUND` indicates that the address string provided in the `location` parameter could not be found. This may occur if a non-existent address is given.
/// - `ZERO_RESULTS` indicates that no panorama could be found near the provided location. This may occur if a non-existent or invalid `pano` id is given.
/// - `OVER_QUERY_LIMIT` indicates the requestor has exceeded quota.
/// - `REQUEST_DENIED` indicates that your request was denied. This may occur if you did not [authorize](https://developers.google.com/maps/documentation/streetview/get-api-key) your request, or if the Street View Static API is not activated in the Google Cloud Console project containing your API key.
/// - `UNKNOWN_ERROR` indicates that the request could not be processed due to a server error. This is often a temporary status. The request may succeed if you try again
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public enum StreetViewStatus
{
    [System.Runtime.Serialization.EnumMember(Value = @"OK")]
    OK = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"INVALID_REQUEST")]
    INVALID_REQUEST = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"NOT_FOUND")]
    NOT_FOUND = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"ZERO_RESULTS")]
    ZERO_RESULTS = 3,

    [System.Runtime.Serialization.EnumMember(Value = @"OVER_QUERY_LIMIT")]
    OVER_QUERY_LIMIT = 4,

    [System.Runtime.Serialization.EnumMember(Value = @"REQUEST_DENIED")]
    REQUEST_DENIED = 5,

    [System.Runtime.Serialization.EnumMember(Value = @"UNKNOWN_ERROR")]
    UNKNOWN_ERROR = 6,

}