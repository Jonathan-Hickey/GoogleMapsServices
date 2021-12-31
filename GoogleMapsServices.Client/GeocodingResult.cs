namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class GeocodingResult
{
    /// <summary>An array containing the separate components applicable to this address.</summary>
    [Newtonsoft.Json.JsonProperty("address_components", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<AddressComponent> Address_components { get; set; } = new System.Collections.ObjectModel.Collection<AddressComponent>();

    /// <summary>The human-readable address of this location.</summary>
    [Newtonsoft.Json.JsonProperty("formatted_address", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Formatted_address { get; set; }

    [Newtonsoft.Json.JsonProperty("geometry", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public GeocodingGeometry Geometry { get; set; } = new GeocodingGeometry();

    /// <summary>A unique identifier that can be used with other Google APIs. For example, you can use the `place_id` in a Places API request to get details of a local business, such as phone number, opening hours, user reviews, and more. See the [place ID overview](https://developers.google.com/places/place-id).</summary>
    [Newtonsoft.Json.JsonProperty("place_id", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Place_id { get; set; }

    [Newtonsoft.Json.JsonProperty("plus_code", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public PlusCode Plus_code { get; set; }

    /// <summary>The `types[]` array indicates the type of the returned result. This array contains a set of zero or more tags identifying the type of feature returned in the result. For example, a geocode of "Chicago" returns "locality" which indicates that "Chicago" is a city, and also returns "political" which indicates it is a political entity.</summary>
    [Newtonsoft.Json.JsonProperty("types", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<string> Types { get; set; } = new System.Collections.ObjectModel.Collection<string>();

    /// <summary>An array denoting all the localities contained in a postal code. This is only present when the result is a postal code that contains multiple localities.</summary>
    [Newtonsoft.Json.JsonProperty("postcode_localities", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<string> Postcode_localities { get; set; }

    /// <summary>Indicates that the geocoder did not return an exact match for the original request, though it was able to match part of the requested address. You may wish to examine the original request for misspellings and/or an incomplete address.
    /// 
    /// Partial matches most often occur for street addresses that do not exist within the locality you pass in the request. Partial matches may also be returned when a request matches two or more locations in the same locality.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("partial_match", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool Partial_match { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}