namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class DirectionsViaWaypoint
{
    /// <summary>The location of the waypoint.</summary>
    [Newtonsoft.Json.JsonProperty("location", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public LatLngLiteral Location { get; set; }

    /// <summary>The index of the step containing the waypoint.</summary>
    [Newtonsoft.Json.JsonProperty("step_index", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int Step_index { get; set; }

    /// <summary>The position of the waypoint along the step's polyline, expressed as a ratio from 0 to 1.</summary>
    [Newtonsoft.Json.JsonProperty("step_interpolation", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double Step_interpolation { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}