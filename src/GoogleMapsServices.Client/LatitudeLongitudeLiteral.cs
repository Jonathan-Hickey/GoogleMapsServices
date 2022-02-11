namespace GoogleMapsServices.Client;

/// <summary>An object describing a specific location with Latitude and Longitude in decimal degrees.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class LatitudeLongitudeLiteral
{
    /// <summary>Latitude in decimal degrees</summary>
    [Newtonsoft.Json.JsonProperty("latitude", Required = Newtonsoft.Json.Required.Always)]
    public double Latitude { get; set; }

    /// <summary>Longitude in decimal degrees</summary>
    [Newtonsoft.Json.JsonProperty("longitude", Required = Newtonsoft.Json.Required.Always)]
    public double Longitude { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}