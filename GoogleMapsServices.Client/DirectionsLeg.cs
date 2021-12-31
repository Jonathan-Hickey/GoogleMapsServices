namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class DirectionsLeg
{
    /// <summary>Contains the estimated time of arrival for this leg. This property is only returned for transit directions.</summary>
    [Newtonsoft.Json.JsonProperty("arrival_time", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TimeZoneTextValueObject Arrival_time { get; set; }

    /// <summary>Contains the estimated time of departure for this leg, specified as a Time object. The `departure_time` is only available for transit directions.</summary>
    [Newtonsoft.Json.JsonProperty("departure_time", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TimeZoneTextValueObject Departure_time { get; set; }

    /// <summary>The total distance covered by this leg.</summary>
    [Newtonsoft.Json.JsonProperty("distance", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TextValueObject Distance { get; set; }

    /// <summary>The total duration of this leg.</summary>
    [Newtonsoft.Json.JsonProperty("duration", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TextValueObject Duration { get; set; }

    /// <summary>Indicates the total duration of this leg. This value is an estimate of the time in traffic based on current and historical traffic conditions. See the `traffic_model` request parameter for the options you can use to request that the returned value is optimistic, pessimistic, or a best-guess estimate. The duration in traffic is returned only if all of the following are true:
    /// 
    /// * The request does not include stopover waypoints. If the request includes waypoints, they must be prefixed with `via:` to avoid stopovers.
    /// * The request is specifically for driving directions—the mode parameter is set to `driving`.
    /// * The request includes a `departure_time` parameter.
    /// * Traffic conditions are available for the requested route.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("duration_in_traffic", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TextValueObject Duration_in_traffic { get; set; }

    /// <summary>Contains the human-readable address (typically a street address) from reverse geocoding the `end_location` of this leg. This content is meant to be read as-is. Do not programmatically parse the formatted address.</summary>
    [Newtonsoft.Json.JsonProperty("end_address", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string End_address { get; set; }

    /// <summary>The latitude/longitude coordinates of the given destination of this leg. Because the Directions API calculates directions between locations by using the nearest transportation option (usually a road) at the start and end points, `end_location` may be different than the provided destination of this leg if, for example, a road is not near the destination.</summary>
    [Newtonsoft.Json.JsonProperty("end_location", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public LatLngLiteral End_location { get; set; } = new LatLngLiteral();

    /// <summary>Contains the human-readable address (typically a street address) resulting from reverse geocoding the `start_location` of this leg. This content is meant to be read as-is. Do not programmatically parse the formatted address.</summary>
    [Newtonsoft.Json.JsonProperty("start_address", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Start_address { get; set; }

    /// <summary>The latitude/longitude coordinates of the origin of this leg. Because the Directions API calculates directions between locations by using the nearest transportation option (usually a road) at the start and end points, `start_location` may be different than the provided origin of this leg if, for example, a road is not near the origin.</summary>
    [Newtonsoft.Json.JsonProperty("start_location", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public LatLngLiteral Start_location { get; set; } = new LatLngLiteral();

    /// <summary>An array of steps denoting information about each separate step of the leg of the journey.</summary>
    [Newtonsoft.Json.JsonProperty("steps", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<DirectionsStep> Steps { get; set; } = new System.Collections.ObjectModel.Collection<DirectionsStep>();

    /// <summary>Information about traffic speed along the leg.</summary>
    [Newtonsoft.Json.JsonProperty("traffic_speed_entry", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<DirectionsTrafficSpeedEntry> Traffic_speed_entry { get; set; } = new System.Collections.ObjectModel.Collection<DirectionsTrafficSpeedEntry>();

    /// <summary>The locations of via waypoints along this leg.</summary>
    [Newtonsoft.Json.JsonProperty("via_waypoint", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<DirectionsViaWaypoint> Via_waypoint { get; set; } = new System.Collections.ObjectModel.Collection<DirectionsViaWaypoint>();

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}