namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class ElevationResult
{
    /// <summary>The elevation of the location in meters.</summary>
    [Newtonsoft.Json.JsonProperty("elevation", Required = Newtonsoft.Json.Required.Always)]
    public double Elevation { get; set; }

    /// <summary>The value indicating the maximum distance between data points from which the elevation was interpolated, in meters. This property will be missing if the resolution is not known. Note that elevation data becomes more coarse (larger resolution values) when multiple points are passed. To obtain the most accurate elevation value for a point, it should be queried independently.</summary>
    [Newtonsoft.Json.JsonProperty("resolution", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double Resolution { get; set; }

    /// <summary>A location element of the position for which elevation data is being computed. Note that for path requests, the set of location elements will contain the sampled points along the path.</summary>
    [Newtonsoft.Json.JsonProperty("location", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public LatLngLiteral Location { get; set; } = new LatLngLiteral();

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}