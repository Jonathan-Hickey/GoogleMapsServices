namespace GoogleMapsServices.Client;

/// <summary>
/// An object describing a specific location with Latitude and Longitude in decimal degrees.
/// </summary>
public sealed class LatLngLiteral
{
    public decimal Lat { get; set; }

    public decimal Lng { get; set; }
}