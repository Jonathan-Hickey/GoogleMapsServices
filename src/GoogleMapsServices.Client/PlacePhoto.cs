using System.Collections.ObjectModel;

namespace GoogleMapsServices.Client;

/// <summary>A photo of a Place. The photo can be accesed via the [Place Photo](https://developers.google.com/places/web-service/photos) API using an url in the following pattern:
/// 
/// ```
/// https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&amp;photo_reference=photo_reference&amp;key=YOUR_API_KEY
/// ```
/// 
/// See [Place Photos](https://developers.google.com/places/web-service/photos) for more information.
/// </summary>
public sealed class PlacePhoto
{
    /// <summary>
    /// The height of the photo.
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// The width of the photo.
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// The HTML attributions for the photo.
    /// </summary>
    public ICollection<string> HtmlAttributions { get; set; } = new Collection<string>();

    /// <summary>
    /// A string used to identify the photo when you perform a Photo request.
    /// </summary>
    public string PhotoReference { get; set; }
}