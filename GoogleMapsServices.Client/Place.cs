namespace GoogleMapsServices.Client;

/// <summary>Attributes describing a place. Not all attributes will be available for all place types.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class Place
{
    /// <summary>An array containing the separate components applicable to this address.</summary>
    [Newtonsoft.Json.JsonProperty("address_components", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<AddressComponent> Address_components { get; set; }

    /// <summary>A representation of the place's address in the [adr microformat](http://microformats.org/wiki/adr).</summary>
    [Newtonsoft.Json.JsonProperty("adr_address", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Adr_address { get; set; }

    /// <summary>Indicates the operational status of the place, if it is a business. If no data exists, `business_status` is not returned.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("business_status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public PlaceBusiness_status Business_status { get; set; }

    /// <summary>A string containing the human-readable address of this place.
    /// 
    /// Often this address is equivalent to the postal address. Note that some countries, such as the United Kingdom, do not allow distribution of true postal addresses due to licensing restrictions.
    /// 
    /// The formatted address is logically composed of one or more address components. For example, the address "111 8th Avenue, New York, NY" consists of the following components: "111" (the street number), "8th Avenue" (the route), "New York" (the city) and "NY" (the US state).
    /// 
    /// Do not parse the formatted address programmatically. Instead you should use the individual address components, which the API response includes in addition to the formatted address field.      
    /// </summary>
    [Newtonsoft.Json.JsonProperty("formatted_address", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Formatted_address { get; set; }

    /// <summary>Contains the place's phone number in its [local format](http://en.wikipedia.org/wiki/Local_conventions_for_writing_telephone_numbers).</summary>
    [Newtonsoft.Json.JsonProperty("formatted_phone_number", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Formatted_phone_number { get; set; }

    /// <summary>Contains the location and viewport for the location.</summary>
    [Newtonsoft.Json.JsonProperty("geometry", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Geometry Geometry { get; set; }

    /// <summary>Contains the URL of a suggested icon which may be displayed to the user when indicating this result on a map.</summary>
    [Newtonsoft.Json.JsonProperty("icon", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Icon { get; set; }

    /// <summary>Contains the default HEX color code for the place's category.</summary>
    [Newtonsoft.Json.JsonProperty("icon_background_color", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Icon_background_color { get; set; }

    /// <summary>Contains the URL of a recommended icon, minus the `.svg` or `.png` file type extension.</summary>
    [Newtonsoft.Json.JsonProperty("icon_mask_base_uri", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Icon_mask_base_uri { get; set; }

    /// <summary>Contains the place's phone number in international format. International format includes the country code, and is prefixed with the plus, +, sign. For example, the international_phone_number for Google's Sydney, Australia office is `+61 2 9374 4000`.</summary>
    [Newtonsoft.Json.JsonProperty("international_phone_number", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string International_phone_number { get; set; }

    /// <summary>Contains the human-readable name for the returned result. For `establishment` results, this is usually the canonicalized business name.</summary>
    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Name { get; set; }

    /// <summary>Contains hours of operation.</summary>
    [Newtonsoft.Json.JsonProperty("opening_hours", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public PlaceOpeningHours Opening_hours { get; set; }

    /// <summary>Deprecated. The field `permanently_closed` is deprecated, and should not be used. Instead, use `business_status` to get the operational status of businesses.</summary>
    [Newtonsoft.Json.JsonProperty("permanently_closed", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool Permanently_closed { get; set; }

    /// <summary>An array of photo objects, each containing a reference to an image. A request may return up to ten photos. More information about place photos and how you can use the images in your application can be found in the [Place Photos](https://developers.google.com/maps/documentation/places/web-service/photos) documentation.</summary>
    [Newtonsoft.Json.JsonProperty("photos", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<PlacePhoto> Photos { get; set; }

    /// <summary>A textual identifier that uniquely identifies a place. To retrieve information about the place, pass this identifier in the `place_id` field of a Places API request. For more information about place IDs, see the [place ID overview](https://developers.google.com/maps/documentation/places/web-service/place-id).</summary>
    [Newtonsoft.Json.JsonProperty("place_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Place_id { get; set; }

    /// <summary>An encoded location reference, derived from latitude and longitude coordinates, that represents an area: 1/8000th of a degree by 1/8000th of a degree (about 14m x 14m at the equator) or smaller. Plus codes can be used as a replacement for street addresses in places where they do not exist (where buildings are not numbered or streets are not named). See [Open Location Code](https://en.wikipedia.org/wiki/Open_Location_Code) and [plus codes](https://plus.codes/).
    /// </summary>
    [Newtonsoft.Json.JsonProperty("plus_code", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public PlusCode Plus_code { get; set; }

    /// <summary>The price level of the place, on a scale of 0 to 4. The exact amount indicated by a specific value will vary from region to region. Price levels are interpreted as follows:
    /// - 0 Free
    /// - 1 Inexpensive
    /// - 2 Moderate
    /// - 3 Expensive
    /// - 4 Very Expensive
    /// </summary>
    [Newtonsoft.Json.JsonProperty("price_level", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double Price_level { get; set; }

    /// <summary>Contains the place's rating, from 1.0 to 5.0, based on aggregated user reviews.</summary>
    [Newtonsoft.Json.JsonProperty("rating", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double Rating { get; set; }

    /// <summary>Deprecated</summary>
    [Newtonsoft.Json.JsonProperty("reference", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Reference { get; set; }

    /// <summary>A JSON array of up to five reviews. If a language parameter was specified in the request, the service will bias the results to prefer reviews written in that language.</summary>
    [Newtonsoft.Json.JsonProperty("reviews", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<PlaceReview> Reviews { get; set; }

    /// <summary>Deprecated.</summary>
    [Newtonsoft.Json.JsonProperty("scope", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Scope { get; set; }

    /// <summary>Contains an array of feature types describing the given result. See the list of [supported types](https://developers.google.com/maps/documentation/places/web-service/supported_types#table2).</summary>
    [Newtonsoft.Json.JsonProperty("types", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public System.Collections.Generic.ICollection<string> Types { get; set; }

    /// <summary>Contains the URL of the official Google page for this place. This will be the Google-owned page that contains the best available information about the place. Applications must link to or embed this page on any screen that shows detailed results about the place to the user.</summary>
    [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Url { get; set; }

    /// <summary>The total number of reviews, with or without text, for this place.</summary>
    [Newtonsoft.Json.JsonProperty("user_ratings_total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double User_ratings_total { get; set; }

    /// <summary>Contains the number of minutes this place’s current timezone is offset from UTC. For example, for places in Sydney, Australia during daylight saving time this would be 660 (+11 hours from UTC), and for places in California outside of daylight saving time this would be -480 (-8 hours from UTC).</summary>
    [Newtonsoft.Json.JsonProperty("utc_offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double Utc_offset { get; set; }

    /// <summary>For establishment (`types:["establishment", ...])` results only, the `vicinity` field contains a simplified address for the place, including the street name, street number, and locality, but not the province/state, postal code, or country.
    /// 
    /// For all other results, the `vicinity` field contains the name of the narrowest political (`types:["political", ...]`) feature that is present in the address of the result.
    /// 
    /// This content is meant to be read as-is. Do not programmatically parse the formatted address.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("vicinity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Vicinity { get; set; }

    /// <summary>The authoritative website for this place, such as a business' homepage.</summary>
    [Newtonsoft.Json.JsonProperty("website", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Website { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}