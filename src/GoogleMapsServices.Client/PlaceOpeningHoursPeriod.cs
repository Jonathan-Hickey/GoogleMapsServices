namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class PlaceOpeningHoursPeriod
{
    /// <summary>Contains a pair of day and time objects describing when the place opens.</summary>
    [Newtonsoft.Json.JsonProperty("open", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public PlaceOpeningHoursPeriodDetail Open { get; set; } = new PlaceOpeningHoursPeriodDetail();

    /// <summary>May contain a pair of day and time objects describing when the place closes. If a place is always open, the close section will be missing from the response. Clients can rely on always-open being represented as an open period containing day with value `0` and time with value `0000`, and no `close`.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("close", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public PlaceOpeningHoursPeriodDetail Close { get; set; } = new PlaceOpeningHoursPeriodDetail();

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}