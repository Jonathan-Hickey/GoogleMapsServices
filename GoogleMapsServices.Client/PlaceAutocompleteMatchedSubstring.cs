namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class PlaceAutocompleteMatchedSubstring
{
    /// <summary>Length of the matched substring in the prediction result text.</summary>
    [Newtonsoft.Json.JsonProperty("length", Required = Newtonsoft.Json.Required.Always)]
    public double Length { get; set; }

    /// <summary>Start location of the matched substring in the prediction result text.</summary>
    [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.Always)]
    public double Offset { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}