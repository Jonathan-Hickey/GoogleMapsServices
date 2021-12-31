namespace GoogleMapsServices.Client;

/// <summary>A rectangle in geographical coordinates from points at the southwest and northeast corners.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class Bounds
{
    [Newtonsoft.Json.JsonProperty("northeast", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public LatLngLiteral Northeast { get; set; } = new LatLngLiteral();

    [Newtonsoft.Json.JsonProperty("southwest", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public LatLngLiteral Southwest { get; set; } = new LatLngLiteral();

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}