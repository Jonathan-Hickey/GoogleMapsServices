namespace GoogleMapsServices.Client;

/// <summary>
/// A review of the place submitted by a user.
/// </summary>
public sealed class PlaceReview
{
    /// <summary>The name of the user who submitted the review. Anonymous reviews are attributed to "A Google user".</summary>
    public string AuthorName { get; set; }

    /// <summary>The URL to the user's Google Maps Local Guides profile, if available.</summary>
    public string AuthorUrl { get; set; }

    /// <summary>The URL to the user's profile photo, if available.</summary>
    public string ProfilePhotoUrl { get; set; }

    /// <summary>An IETF language code indicating the language used in the user's review. This field contains the main language tag only, and not the secondary tag indicating country or region. For example, all the English reviews are tagged as 'en', and not 'en-AU' or 'en-UK' and so on.</summary>
    public string Language { get; set; }

    /// <summary>The user's overall rating for this place. This is a whole number, ranging from 1 to 5.</summary>
    public double Rating { get; set; }

    /// <summary>The time that the review was submitted in text, relative to the current time.</summary>
    public string RelativeTimeDescription { get; set; }

    /// <summary>
    /// The user's review. When reviewing a location with Google Places, text reviews are considered optional. Therefore, this field may be empty. Note that this field may include simple HTML markup. For example, the entity reference `&amp;amp;` may represent an ampersand character.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// The time that the review was submitted, measured in the number of seconds since since midnight, January 1, 1970 UTC.
    /// </summary>
    public double Time { get; set; }
}