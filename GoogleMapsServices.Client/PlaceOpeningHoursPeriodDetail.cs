namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class PlaceOpeningHoursPeriodDetail
{
    /// <summary>A number from 0–6, corresponding to the days of the week, starting on Sunday. For example, 2 means Tuesday.</summary>
    [Newtonsoft.Json.JsonProperty("day", Required = Newtonsoft.Json.Required.Always)]
    public double Day { get; set; }

    /// <summary>May contain a time of day in 24-hour hhmm format. Values are in the range 0000–2359. The time will be reported in the place’s time zone.</summary>
    [Newtonsoft.Json.JsonProperty("time", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Time { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}