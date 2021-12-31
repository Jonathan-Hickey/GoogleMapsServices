namespace GoogleMapsServices.Client;

/// <summary>An object describing a specific location with Latitude and Longitude in decimal degrees.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class LatLngLiteral
{
    /// <summary>Latitude in decimal degrees</summary>
    [Newtonsoft.Json.JsonProperty("lat", Required = Newtonsoft.Json.Required.Always)]
    public double Lat { get; set; }

    /// <summary>Longitude in decimal degrees</summary>
    [Newtonsoft.Json.JsonProperty("lng", Required = Newtonsoft.Json.Required.Always)]
    public double Lng { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}