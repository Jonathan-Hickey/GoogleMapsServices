namespace GoogleMapsServices.Client;

/// <summary>A successful geolocation request will return a JSON-formatted response defining a location and radius.</summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.0.22.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class GeolocationResponse
{
    /// <summary>The user’s estimated latitude and longitude, in degrees.</summary>
    [Newtonsoft.Json.JsonProperty("location", Required = Newtonsoft.Json.Required.Always)]
    [System.ComponentModel.DataAnnotations.Required]
    public LatLngLiteral Location { get; set; } = new LatLngLiteral();

    /// <summary>The accuracy of the estimated location, in meters. This represents the radius of a circle around the given `location`. If your Geolocation response shows a very high value in the `accuracy` field, the service may be geolocating based on the  request IP, instead of WiFi points or cell towers. This can happen if no cell towers or access points are valid or recognized. To confirm that this is the issue, set `considerIp` to `false` in your request. If the response is a `404`, you've confirmed that your `wifiAccessPoints` and `cellTowers` objects could not be geolocated.</summary>
    [Newtonsoft.Json.JsonProperty("accuracy", Required = Newtonsoft.Json.Required.Always)]
    public double Accuracy { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [Newtonsoft.Json.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }


}