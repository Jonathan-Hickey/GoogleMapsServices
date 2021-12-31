namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class DirectionsTrafficSpeedEntry
{
    /// <summary>The current traffic/speed conditions on this portion of a path.</summary>
    [Newtonsoft.Json.JsonProperty("speed_category", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Speed_category { get; set; }

    /// <summary>The offset along the path (in meters) up to which this speed category is valid.</summary>
    [Newtonsoft.Json.JsonProperty("offset_meters", Required = Newtonsoft.Json.Required.Always)]
    public double Offset_meters { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}