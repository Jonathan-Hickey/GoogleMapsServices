namespace GoogleMapsServices.Client;

/// <summary>An object describing the location.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class GeocodingGeometry
{
    [Newtonsoft.Json.JsonProperty("location", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public LatLngLiteral Location { get; set; } = new LatLngLiteral();

    /// <summary>Stores additional data about the specified location. The following values are currently supported:
    /// 
    /// - "ROOFTOP" indicates that the returned result is a precise geocode for which we have location information accurate down to street address precision.
    /// - "RANGE_INTERPOLATED" indicates that the returned result reflects an approximation (usually on a road) interpolated between two precise points (such as intersections). Interpolated results are generally returned when rooftop geocodes are unavailable for a street address.
    /// - "GEOMETRIC_CENTER" indicates that the returned result is the geometric center of a result such as a polyline (for example, a street) or polygon (region).
    /// - "APPROXIMATE" indicates that the returned result is approximate.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("location_type", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public GeocodingGeometryLocation_type Location_type { get; set; }

    [Newtonsoft.Json.JsonProperty("bounds", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Bounds Bounds { get; set; }

    [Newtonsoft.Json.JsonProperty("viewport", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Bounds Viewport { get; set; } = new Bounds();

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}