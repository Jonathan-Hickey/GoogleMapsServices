namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class PlaceAutocompletePrediction
{
    /// <summary>Contains the human-readable name for the returned result. For `establishment` results, this is usually the business name. This content is meant to be read as-is. Do not programmatically parse the formatted address.</summary>
    [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Description { get; set; }

    /// <summary>A list of substrings that describe the location of the entered term in the prediction result text, so that the term can be highlighted if desired.</summary>
    [Newtonsoft.Json.JsonProperty("matched_substrings", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ICollection<PlaceAutocompleteMatchedSubstring> Matched_substrings { get; set; } = new System.Collections.ObjectModel.Collection<PlaceAutocompleteMatchedSubstring>();

    /// <summary>A textual identifier that uniquely identifies a place. To retrieve information about the place, pass this identifier in the placeId field of a Places API request. For more information about place IDs, see the [Place IDs](https://developers.google.com/maps/documentation/places/web-service/place-id) overview.</summary>
    [Newtonsoft.Json.JsonProperty("place_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Place_id { get; set; }

    /// <summary>(Deprecated) See place_id.</summary>
    [Newtonsoft.Json.JsonProperty("reference", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Reference { get; set; }

    /// <summary>Provides pre-formatted text that can be shown in your autocomplete results. This content is meant to be read as-is. Do not programmatically parse the formatted address.</summary>
    [Newtonsoft.Json.JsonProperty("structured_formatting", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public PlaceAutocompleteStructuredFormat Structured_formatting { get; set; } = new PlaceAutocompleteStructuredFormat();

    /// <summary>Contains an array of terms identifying each section of the returned description (a section of the description is generally terminated with a comma). Each entry in the array has a `value` field, containing the text of the term, and an `offset` field, defining the start position of this term in the description, measured in Unicode characters.</summary>
    [Newtonsoft.Json.JsonProperty("terms", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ICollection<PlaceAutocompleteTerm> Terms { get; set; } = new System.Collections.ObjectModel.Collection<PlaceAutocompleteTerm>();

    /// <summary>Contains an array of types that apply to this place. For example: `[ "political", "locality" ]` or `[ "establishment", "geocode", "beauty_salon" ]`. The array can contain multiple values. Learn more about [Place types](https://developers.google.com/maps/documentation/places/web-service/supported_types).
    /// </summary>
    [Newtonsoft.Json.JsonProperty("types", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ICollection<string> Types { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}