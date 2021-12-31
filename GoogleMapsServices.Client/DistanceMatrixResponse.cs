namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class DistanceMatrixResponse
{
    /// <summary>An array of addresses as returned by the API from your original request. These are formatted by the geocoder and localized according to the language parameter passed with the request. This content is meant to be read as-is. Do not programatically parse the formatted addresses.</summary>
    [Newtonsoft.Json.JsonProperty("origin_addresses", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ICollection<string> Origin_addresses { get; set; } = new System.Collections.ObjectModel.Collection<string>();

    /// <summary>An array of addresses as returned by the API from your original request. As with `origin_addresses`, these are localized if appropriate. This content is meant to be read as-is. Do not programatically parse the formatted addresses.</summary>
    [Newtonsoft.Json.JsonProperty("destination_addresses", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ICollection<string> Destination_addresses { get; set; } = new System.Collections.ObjectModel.Collection<string>();

    /// <summary>An array of elements, which in turn each contain a `status`, `duration`, and `distance` element.</summary>
    [Newtonsoft.Json.JsonProperty("rows", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ICollection<DistanceMatrixRow> Rows { get; set; } = new System.Collections.ObjectModel.Collection<DistanceMatrixRow>();

    /// <summary>Contains the status of the request, and may contain debugging information to help you track down why the request failed.</summary>
    [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public DistanceMatrixStatus Status { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}