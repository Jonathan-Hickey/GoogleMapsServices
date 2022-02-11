namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class PlacesDetailsResponse
{
    /// <summary>May contain a set of attributions about this listing which must be displayed to the user (some listings may not have attribution).</summary>
    [Newtonsoft.Json.JsonProperty("html_attributions", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ICollection<string> Html_attributions { get; set; } = new System.Collections.ObjectModel.Collection<string>();

    /// <summary>Contains the detailed information about the place requested.</summary>
    [Newtonsoft.Json.JsonProperty("result", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Place Result { get; set; } = new Place();

    /// <summary>Contains the status of the request, and may contain debugging information to help you track down why the request failed.</summary>
    [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public PlacesDetailsStatus Status { get; set; }

    /// <summary>When the service returns additional information about the request specification, there may be an additional `info_messages` field within the response object. This field is only returned for successful requests. It may not always be returned, and its content is subject to change.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("info_messages", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ICollection<string> Info_messages { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}