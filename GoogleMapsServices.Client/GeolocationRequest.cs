namespace GoogleMapsServices.Client;

/// <summary>The request body must be formatted as JSON. The following fields are supported, and all fields are optional.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class GeolocationRequest
{
    /// <summary>The cell tower's Mobile Country Code (MCC).</summary>
    [Newtonsoft.Json.JsonProperty("homeMobileCountryCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int HomeMobileCountryCode { get; set; }

    /// <summary>The cell tower's Mobile Network Code. This is the MNC for GSM and WCDMA; CDMA uses the System ID (SID).</summary>
    [Newtonsoft.Json.JsonProperty("homeMobileNetworkCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int HomeMobileNetworkCode { get; set; }

    /// <summary>The mobile radio type. Supported values are lte, gsm, cdma, and wcdma. While this field is optional, it should be included if a value is available, for more accurate results.</summary>
    [Newtonsoft.Json.JsonProperty("radioType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string RadioType { get; set; }

    /// <summary>The carrier name.</summary>
    [Newtonsoft.Json.JsonProperty("carrier", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Carrier { get; set; }

    /// <summary>Specifies whether to fall back to IP geolocation if wifi and cell tower signals are not available. Defaults to true. Set considerIp to false to disable fall back.</summary>
    [Newtonsoft.Json.JsonProperty("considerIp", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string ConsiderIp { get; set; }

    /// <summary>The request body's cellTowers array contains zero or more cell tower objects.</summary>
    [Newtonsoft.Json.JsonProperty("cellTowers", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<CellTower> CellTowers { get; set; }

    /// <summary>An array of two or more WiFi access point objects.</summary>
    [Newtonsoft.Json.JsonProperty("wifiAccessPoints", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<WiFiAccessPoint> WifiAccessPoints { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}