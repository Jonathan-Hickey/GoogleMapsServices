namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class ElevationResponse
{
    /// <summary>When the service returns a status code other than `OK`, there may be an additional `error_message` field within the response object. This field contains more detailed information about thereasons behind the given status code. This field is not always returned, and its content is subject to change.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("error_message", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Error_message { get; set; }

    [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ElevationStatus Status { get; set; }

    [Newtonsoft.Json.JsonProperty("results", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ICollection<ElevationResult> Results { get; set; } = new System.Collections.ObjectModel.Collection<ElevationResult>();

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}