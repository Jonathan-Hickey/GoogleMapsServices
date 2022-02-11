namespace GoogleMapsServices.Client;

/// <summary>
/// A rectangle in geographical coordinates from points at the southwest and northeast corners.
/// </summary>
public sealed class Bounds
{
    public LatLngLiteral Northeast { get; set; } = new LatLngLiteral();

    public LatLngLiteral Southwest { get; set; } = new LatLngLiteral();

}