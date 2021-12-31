namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class DirectionsTransitVehicle
{
    /// <summary>Contains the URL for an icon associated with this vehicle type.</summary>
    [Newtonsoft.Json.JsonProperty("icon", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Icon { get; set; }

    /// <summary>Contains the URL for the icon associated with this vehicle type, based on the local transport signage.</summary>
    [Newtonsoft.Json.JsonProperty("local_icon", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string Local_icon { get; set; }

    /// <summary>The name of this vehicle, capitalized.</summary>
    [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public string Name { get; set; }

    /// <summary>The type of vehicle used.
    /// 
    /// * `BUS` -	Bus.
    /// * `CABLE_CAR` -	A vehicle that operates on a cable, usually on the ground. Aerial cable cars may be of the type GONDOLA_LIFT.
    /// * `COMMUTER_TRAIN` -	Commuter rail.
    /// * `FERRY` -	Ferry.
    /// * `FUNICULAR` -	A vehicle that is pulled up a steep incline by a cable. A Funicular typically consists of two cars, with each car acting as a counterweight for the other.
    /// * `GONDOLA_LIFT` -	An aerial cable car.
    /// * `HEAVY_RAIL` -	Heavy rail.
    /// * `HIGH_SPEED_TRAIN` -	High speed train.
    /// * `INTERCITY_BUS` -	Intercity bus.
    /// * `LONG_DISTANCE_TRAIN` -	Long distance train.
    /// * `METRO_RAIL` -	Light rail transit.
    /// * `MONORAIL` -	Monorail.
    /// * `OTHER` -	All other vehicles will return this type.
    /// * `RAIL` -	Rail.
    /// * `SHARE_TAXI` -	Share taxi is a kind of bus with the ability to drop off and pick up passengers anywhere on its route.
    /// * `SUBWAY` -	Underground light rail.
    /// * `TRAM` -	Above ground light rail.
    /// * `TROLLEYBUS` -	Trolleybus.
    /// </summary>
    [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public DirectionsTransitVehicleType Type { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}