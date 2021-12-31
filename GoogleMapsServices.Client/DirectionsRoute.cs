namespace GoogleMapsServices.Client;

/// <summary>Routes consist of nested `legs` and `steps`.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class DirectionsRoute
{
    /// <summary>An array which contains information about a leg of the route, between two locations within the given route. A separate leg will be present for each waypoint or destination specified. (A route with no waypoints will contain exactly one leg within the legs array.) Each leg consists of a series of steps.</summary>
    [Newtonsoft.Json.JsonProperty("legs", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ICollection<DirectionsLeg> Legs { get; set; } = new System.Collections.ObjectModel.Collection<DirectionsLeg>();

    /// <summary>Contains the viewport bounding box of the `overview_polyline`.</summary>
    [Newtonsoft.Json.JsonProperty("bounds", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public Bounds Bounds { get; set; } = new Bounds();

    /// <summary>Contains an array of warnings to be displayed when showing these directions. You must handle and display these warnings yourself.</summary>
    [Newtonsoft.Json.JsonProperty("copyrights", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Copyrights { get; set; }

    /// <summary>Contains a short textual description for the route, suitable for naming and disambiguating the route from alternatives.</summary>
    [Newtonsoft.Json.JsonProperty("summary", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Summary { get; set; }

    /// <summary>An array indicating the order of any waypoints in the calculated route. This waypoints may be reordered if the request was passed optimize:true within its waypoints parameter.</summary>
    [Newtonsoft.Json.JsonProperty("waypoint_order", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ICollection<int> Waypoint_order { get; set; } = new System.Collections.ObjectModel.Collection<int>();

    /// <summary>Contains an array of warnings to be displayed when showing these directions. You must handle and display these warnings yourself.</summary>
    [Newtonsoft.Json.JsonProperty("warnings", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public ICollection<string> Warnings { get; set; } = new System.Collections.ObjectModel.Collection<string>();

    /// <summary>Contains an object that holds an encoded polyline representation of the route. This polyline is an approximate (smoothed) path of the resulting directions.</summary>
    [Newtonsoft.Json.JsonProperty("overview_polyline", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public DirectionsPolyline Overview_polyline { get; set; } = new DirectionsPolyline();

    /// <summary>If present, contains the total fare (that is, the total ticket costs) on this route. This property is only returned for transit requests and only for routes where fare information is available for all transit legs.</summary>
    [Newtonsoft.Json.JsonProperty("fare", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public Fare Fare { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}