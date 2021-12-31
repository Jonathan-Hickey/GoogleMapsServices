namespace GoogleMapsServices.Client;

/// <summary>- `OK` indicates the response contains a valid result.
/// - `NOT_FOUND` indicates that the origin and/or destination of this pairing could not be geocoded.
/// - `ZERO_RESULTS` indicates no route could be found between the origin and destination.
/// - `MAX_ROUTE_LENGTH_EXCEEDED` indicates the requested route is too long and cannot be processed.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public enum DistanceMatrixElementStatus
{
    [System.Runtime.Serialization.EnumMember(Value = @"OK")]
    OK = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"NOT_FOUND")]
    NOT_FOUND = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"ZERO_RESULTS")]
    ZERO_RESULTS = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"MAX_ROUTE_LENGTH_EXCEEDED")]
    MAX_ROUTE_LENGTH_EXCEEDED = 3,

}