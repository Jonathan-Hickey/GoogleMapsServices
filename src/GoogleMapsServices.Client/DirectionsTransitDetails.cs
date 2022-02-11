namespace GoogleMapsServices.Client;

/// <summary>Additional information that is not relevant for other modes of transportation.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class DirectionsTransitDetails
{
    /// <summary>The arrival transit stop.</summary>
    [Newtonsoft.Json.JsonProperty("arrival_stop", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public DirectionsTransitStop Arrival_stop { get; set; }

    [Newtonsoft.Json.JsonProperty("arrival_time", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TimeZoneTextValueObject Arrival_time { get; set; }

    /// <summary>The departure transit stop.</summary>
    [Newtonsoft.Json.JsonProperty("departure_stop", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public DirectionsTransitStop Departure_stop { get; set; }

    [Newtonsoft.Json.JsonProperty("departure_time", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public TimeZoneTextValueObject Departure_time { get; set; }

    /// <summary>Specifies the direction in which to travel on this line, as it is marked on the vehicle or at the departure stop. This will often be the terminus station.</summary>
    [Newtonsoft.Json.JsonProperty("headsign", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Headsign { get; set; }

    /// <summary>Specifies the expected number of seconds between departures from the same stop at this time. For example, with a `headway` value of 600, you would expect a ten minute wait if you should miss your bus.</summary>
    [Newtonsoft.Json.JsonProperty("headway", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int Headway { get; set; }

    /// <summary>Contains information about the transit line used in this step.</summary>
    [Newtonsoft.Json.JsonProperty("line", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public DirectionsTransitLine Line { get; set; }

    /// <summary>The number of stops from the departure to the arrival stop. This includes the arrival stop, but not the departure stop. For example, if your directions involve leaving from Stop A, passing through stops B and C, and arriving at stop D, `num_stops` will return 3.</summary>
    [Newtonsoft.Json.JsonProperty("num_stops", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int Num_stops { get; set; }

    /// <summary>The text that appears in schedules and sign boards to identify a transit trip to passengers. The text should uniquely identify a trip within a service day. For example, "538" is the `trip_short_name` of the Amtrak train that leaves San Jose, CA at 15:10 on weekdays to Sacramento, CA.</summary>
    [Newtonsoft.Json.JsonProperty("trip_short_name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Trip_short_name { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}