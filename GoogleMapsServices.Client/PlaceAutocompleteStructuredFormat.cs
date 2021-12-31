namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class PlaceAutocompleteStructuredFormat
{
    /// <summary>Contains the main text of a prediction, usually the name of the place.</summary>
    [Newtonsoft.Json.JsonProperty("main_text", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Main_text { get; set; }

    /// <summary>Contains an array with `offset` value and `length`. These describe the location of the entered term in the prediction result text, so that the term can be highlighted if desired.</summary>
    [Newtonsoft.Json.JsonProperty("main_text_matched_substrings", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<PlaceAutocompleteMatchedSubstring> Main_text_matched_substrings { get; set; } = new System.Collections.ObjectModel.Collection<PlaceAutocompleteMatchedSubstring>();

    /// <summary>Contains the secondary text of a prediction, usually the location of the place.</summary>
    [Newtonsoft.Json.JsonProperty("secondary_text", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Secondary_text { get; set; }

    /// <summary>Contains an array with `offset` value and `length`. These describe the location of the entered term in the prediction result text, so that the term can be highlighted if desired.</summary>
    [Newtonsoft.Json.JsonProperty("secondary_text_matched_substrings", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<PlaceAutocompleteMatchedSubstring> Secondary_text_matched_substrings { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}