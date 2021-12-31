namespace GoogleMapsServices.Client;

/// <summary>A photo of a Place. The photo can be accesed via the [Place Photo](https://developers.google.com/places/web-service/photos) API using an url in the following pattern:
/// 
/// ```
/// https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&amp;photo_reference=photo_reference&amp;key=YOUR_API_KEY
/// ```
/// 
/// See [Place Photos](https://developers.google.com/places/web-service/photos) for more information.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class PlacePhoto
{
    /// <summary>The height of the photo.</summary>
    [Newtonsoft.Json.JsonProperty("height", Required = Newtonsoft.Json.Required.Always)]
    public double Height { get; set; }

    /// <summary>The width of the photo.</summary>
    [Newtonsoft.Json.JsonProperty("width", Required = Newtonsoft.Json.Required.Always)]
    public double Width { get; set; }

    /// <summary>The HTML attributions for the photo.</summary>
    [Newtonsoft.Json.JsonProperty("html_attributions", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<string> Html_attributions { get; set; } = new System.Collections.ObjectModel.Collection<string>();

    /// <summary>A string used to identify the photo when you perform a Photo request.</summary>
    [Newtonsoft.Json.JsonProperty("photo_reference", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Photo_reference { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}