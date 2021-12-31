namespace GoogleMapsServices.Client;

/// <summary>Attributes used to describe a WiFi access point.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class WiFiAccessPoint
{
    /// <summary>The MAC address of the WiFi node. It's typically called a BSS, BSSID or MAC address. Separators must be `:` (colon).</summary>
    [Newtonsoft.Json.JsonProperty("macAddress", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string MacAddress { get; set; }

    /// <summary>The current signal strength measured in dBm.</summary>
    [Newtonsoft.Json.JsonProperty("signalStrength", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int SignalStrength { get; set; }

    /// <summary>The current signal to noise ratio measured in dB.</summary>
    [Newtonsoft.Json.JsonProperty("signalToNoiseRatio", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int SignalToNoiseRatio { get; set; }

    /// <summary>The number of milliseconds since this access point was detected.</summary>
    [Newtonsoft.Json.JsonProperty("age", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int Age { get; set; }

    /// <summary>The channel over which the client is communication with the access point.</summary>
    [Newtonsoft.Json.JsonProperty("channel", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int Channel { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}