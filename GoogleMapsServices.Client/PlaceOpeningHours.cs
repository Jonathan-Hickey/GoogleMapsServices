namespace GoogleMapsServices.Client;

/// <summary>An object describing the opening hours of a place.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class PlaceOpeningHours
{
    /// <summary>A boolean value indicating if the place is open at the current time.</summary>
    [Newtonsoft.Json.JsonProperty("open_now", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool Open_now { get; set; }

    /// <summary>An array of opening periods covering seven days, starting from Sunday, in chronological order.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("periods", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<PlaceOpeningHoursPeriod> Periods { get; set; }

    /// <summary>An array of strings describing in human-readable text the hours of the place.</summary>
    [Newtonsoft.Json.JsonProperty("weekday_text", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<string> Weekday_text { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}