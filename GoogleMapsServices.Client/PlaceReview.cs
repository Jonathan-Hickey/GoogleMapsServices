namespace GoogleMapsServices.Client;

/// <summary>A review of the place submitted by a user.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class PlaceReview
{
    /// <summary>The name of the user who submitted the review. Anonymous reviews are attributed to "A Google user".</summary>
    [Newtonsoft.Json.JsonProperty("author_name", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Author_name { get; set; }

    /// <summary>The URL to the user's Google Maps Local Guides profile, if available.</summary>
    [Newtonsoft.Json.JsonProperty("author_url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Author_url { get; set; }

    /// <summary>The URL to the user's profile photo, if available.</summary>
    [Newtonsoft.Json.JsonProperty("profile_photo_url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Profile_photo_url { get; set; }

    /// <summary>An IETF language code indicating the language used in the user's review. This field contains the main language tag only, and not the secondary tag indicating country or region. For example, all the English reviews are tagged as 'en', and not 'en-AU' or 'en-UK' and so on.</summary>
    [Newtonsoft.Json.JsonProperty("language", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Language { get; set; }

    /// <summary>The user's overall rating for this place. This is a whole number, ranging from 1 to 5.</summary>
    [Newtonsoft.Json.JsonProperty("rating", Required = Newtonsoft.Json.Required.Always)]
    public double Rating { get; set; }

    /// <summary>The time that the review was submitted in text, relative to the current time.</summary>
    [Newtonsoft.Json.JsonProperty("relative_time_description", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Relative_time_description { get; set; }

    /// <summary>The user's review. When reviewing a location with Google Places, text reviews are considered optional. Therefore, this field may be empty. Note that this field may include simple HTML markup. For example, the entity reference `&amp;amp;` may represent an ampersand character.</summary>
    [Newtonsoft.Json.JsonProperty("text", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Text { get; set; }

    /// <summary>The time that the review was submitted, measured in the number of seconds since since midnight, January 1, 1970 UTC.</summary>
    [Newtonsoft.Json.JsonProperty("time", Required = Newtonsoft.Json.Required.Always)]
    public double Time { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}