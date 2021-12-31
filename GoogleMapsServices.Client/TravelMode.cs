namespace GoogleMapsServices.Client;

/// <summary>- `DRIVING` (default) indicates calculation using the road network.
/// - `BICYCLING` requests calculation for bicycling via bicycle paths &amp; preferred streets (where available).
/// - `TRANSIT` requests calculation via public transit routes (where available). 
/// - `WALKING` requests calculation for walking via pedestrian paths &amp; sidewalks (where available).
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public enum TravelMode
{
    [System.Runtime.Serialization.EnumMember(Value = @"DRIVING")]
    DRIVING = 0,

    [System.Runtime.Serialization.EnumMember(Value = @"BICYCLING")]
    BICYCLING = 1,

    [System.Runtime.Serialization.EnumMember(Value = @"TRANSIT")]
    TRANSIT = 2,

    [System.Runtime.Serialization.EnumMember(Value = @"WALKING")]
    WALKING = 3,

}