namespace GoogleMapsServices.Client;

/// <summary>Each element in the steps array defines a single step of the calculated directions. A step is the most atomic unit of a direction's route, containing a single step describing a specific, single instruction on the journey. E.g. "Turn left at W. 4th St." The step not only describes the instruction but also contains distance and duration information relating to how this step relates to the following step. For example, a step denoted as "Merge onto I-80 West" may contain a duration of "37 miles" and "40 minutes," indicating that the next step is 37 miles/40 minutes from this step.
/// 
/// When using the Directions API to search for transit directions, the steps array will include additional transit details in the form of a transit_details array. If the directions include multiple modes of transportation, detailed directions will be provided for walking or driving steps in an inner steps array. For example, a walking step will include directions from the start and end locations: "Walk to Innes Ave &amp; Fitch St". That step will include detailed walking directions for that route in the inner steps array, such as: "Head north-west", "Turn left onto Arelious Walker", and "Turn left onto Innes Ave".
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class DirectionsStep
{
    /// <summary>Contains the distance covered by this step until the next step. This field may be undefined if the distance is unknown.</summary>
    [Newtonsoft.Json.JsonProperty("distance", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TextValueObject Distance { get; set; }

    /// <summary>Contains the typical time required to perform the step, until the next step. This field may be undefined if the duration is unknown.</summary>
    [Newtonsoft.Json.JsonProperty("duration", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public TextValueObject Duration { get; set; } = new TextValueObject();

    /// <summary>Contains the location of the last point of this step.</summary>
    [Newtonsoft.Json.JsonProperty("end_location", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public LatLngLiteral End_location { get; set; } = new LatLngLiteral();

    /// <summary>Contains formatted instructions for this step, presented as an HTML text string. This content is meant to be read as-is. Do not programmatically parse this display-only content.</summary>
    [Newtonsoft.Json.JsonProperty("html_instructions", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Html_instructions { get; set; }

    /// <summary>Contains the action to take for the current step (turn left, merge, straight, etc.). Values are subject to change, and new values may be introduced without prior notice.</summary>
    [Newtonsoft.Json.JsonProperty("maneuver", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public DirectionsStepManeuver Maneuver { get; set; }

    /// <summary>Contains a single points object that holds an [encoded polyline](https://developers.devsite.corp.google.com/maps/documentation/utilities/polylinealgorithm) representation of the step. This polyline is an approximate (smoothed) path of the step.</summary>
    [Newtonsoft.Json.JsonProperty("polyline", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public DirectionsPolyline Polyline { get; set; } = new DirectionsPolyline();

    /// <summary>Contains the location of the starting point of this step.</summary>
    [Newtonsoft.Json.JsonProperty("start_location", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public LatLngLiteral Start_location { get; set; } = new LatLngLiteral();

    /// <summary>Details pertaining to this step if the travel mode is `TRANSIT`.</summary>
    [Newtonsoft.Json.JsonProperty("transit_details", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public DirectionsTransitDetails Transit_details { get; set; }

    /// <summary>Contains the type of travel mode used.</summary>
    [Newtonsoft.Json.JsonProperty("travel_mode", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public TravelMode Travel_mode { get; set; }

    /// <summary>Contains detailed directions for walking or driving steps in transit directions. Substeps are only available when travel_mode is set to "transit". The inner steps array is of the same type as steps.</summary>
    [Newtonsoft.Json.JsonProperty("steps", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public object Steps { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}