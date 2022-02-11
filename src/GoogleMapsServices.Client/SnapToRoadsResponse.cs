namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class SnapToRoadsResponse
{
    /// <summary>An array of snapped points.</summary>
    [Newtonsoft.Json.JsonProperty("snappedPoints", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ICollection<SnappedPoint> SnappedPoints { get; set; }

    /// <summary>A string containing a user-visible warning.</summary>
    [Newtonsoft.Json.JsonProperty("warningMessage", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string WarningMessage { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}