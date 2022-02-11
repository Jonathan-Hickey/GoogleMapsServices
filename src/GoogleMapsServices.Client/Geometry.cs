namespace GoogleMapsServices.Client;

/// <summary>
/// An object describing the location.
/// </summary>
public partial class Geometry
{
    public LatLngLiteral Location { get; set; } = new LatLngLiteral();

    public Bounds Viewport { get; set; } = new Bounds();


}