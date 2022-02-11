namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class NearestRoadsErrorResponse
{
    [Newtonsoft.Json.JsonProperty("error", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public NearestRoadsError Error { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}