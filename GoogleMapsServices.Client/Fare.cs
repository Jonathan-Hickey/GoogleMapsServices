namespace GoogleMapsServices.Client;

/// <summary>The total fare for the route.
/// 
/// ```
/// {
///   "currency" : "USD",
///   "value" : 6,
///   "text" : "$6.00"
/// }
/// ```
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class Fare
{
    /// <summary>An [ISO 4217 currency code](https://en.wikipedia.org/wiki/ISO_4217) indicating the currency that the amount is expressed in.</summary>
    [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Currency { get; set; }

    /// <summary>The total fare amount, in the currency specified.</summary>
    [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Always)]
    public double Value { get; set; }

    /// <summary>The total fare amount, formatted in the requested language.</summary>
    [Newtonsoft.Json.JsonProperty("text", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Text { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}