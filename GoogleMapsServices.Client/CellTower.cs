namespace GoogleMapsServices.Client;

/// <summary>Attributes used to describe a cell tower. The following optional fields are not currently used, but may be included if values are available: `age`, `signalStrength`, `timingAdvance`.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class CellTower
{
    /// <summary>Unique identifier of the cell. On GSM, this is the Cell ID (CID); CDMA networks use the Base Station ID (BID). WCDMA networks use the UTRAN/GERAN Cell Identity (UC-Id), which is a 32-bit value concatenating the Radio Network Controller (RNC) and Cell ID. Specifying only the 16-bit Cell ID value in WCDMA networks may return inaccurate results.</summary>
    [Newtonsoft.Json.JsonProperty("cellId", Required = Newtonsoft.Json.Required.Always)]
    public int CellId { get; set; }

    /// <summary>The Location Area Code (LAC) for GSM and WCDMA networks. The Network ID (NID) for CDMA networks.</summary>
    [Newtonsoft.Json.JsonProperty("locationAreaCode", Required = Newtonsoft.Json.Required.Always)]
    public int LocationAreaCode { get; set; }

    /// <summary>The cell tower's Mobile Country Code (MCC).</summary>
    [Newtonsoft.Json.JsonProperty("mobileCountryCode", Required = Newtonsoft.Json.Required.Always)]
    public int MobileCountryCode { get; set; }

    /// <summary>The cell tower's Mobile Network Code. This is the MNC for GSM and WCDMA; CDMA uses the System ID (SID).</summary>
    [Newtonsoft.Json.JsonProperty("mobileNetworkCode", Required = Newtonsoft.Json.Required.Always)]
    public int MobileNetworkCode { get; set; }

    /// <summary>The number of milliseconds since this cell was primary. If age is 0, the cellId represents a current measurement.</summary>
    [Newtonsoft.Json.JsonProperty("age", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int Age { get; set; }

    /// <summary>Radio signal strength measured in dBm.</summary>
    [Newtonsoft.Json.JsonProperty("signalStrength", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double SignalStrength { get; set; }

    /// <summary>The timing advance value.</summary>
    [Newtonsoft.Json.JsonProperty("timingAdvance", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double TimingAdvance { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}