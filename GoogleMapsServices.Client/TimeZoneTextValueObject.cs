namespace GoogleMapsServices.Client;

/// <summary>An object containing Unix time, a time zone, and its formatted text representation.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class TimeZoneTextValueObject
{
    /// <summary>The time specified as a string in the time zone.</summary>
    [Newtonsoft.Json.JsonProperty("text", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Text { get; set; }

    /// <summary>The time specified as Unix time, or seconds since midnight, January 1, 1970 UTC.</summary>
    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Always)]
    public double Value { get; set; }

    /// <summary>Contains the time zone. The value is the name of the time zone as defined in the [IANA Time Zone Database](http://www.iana.org/time-zones), e.g. "America/New_York".</summary>
    [Newtonsoft.Json.JsonProperty("time_zone", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Time_zone { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}