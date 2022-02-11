namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class DirectionsTransitLine
{
    /// <summary>The transit agency (or agencies) that operates this transit line.</summary>
    [Newtonsoft.Json.JsonProperty("agencies", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ICollection<DirectionsTransitAgency> Agencies { get; set; } = new System.Collections.ObjectModel.Collection<DirectionsTransitAgency>();

    /// <summary>The color commonly used in signage for this line.</summary>
    [Newtonsoft.Json.JsonProperty("color", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Color { get; set; }

    /// <summary>The full name of this transit line, e.g. "8 Avenue Local".</summary>
    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Name { get; set; }

    /// <summary>The short name of this transit line. This will normally be a line number, such as "M7" or "355".</summary>
    [Newtonsoft.Json.JsonProperty("short_name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Short_name { get; set; }

    /// <summary>The color commonly used in signage for this line.</summary>
    [Newtonsoft.Json.JsonProperty("text_color", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Text_color { get; set; }

    /// <summary>Contains the URL for this transit line as provided by the transit agency.</summary>
    [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Url { get; set; }

    /// <summary>Contains the URL for the icon associated with this line.</summary>
    [Newtonsoft.Json.JsonProperty("icon", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Icon { get; set; }

    /// <summary>The type of vehicle that operates on this transit line.</summary>
    [Newtonsoft.Json.JsonProperty("vehicle", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public DirectionsTransitVehicle Vehicle { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}