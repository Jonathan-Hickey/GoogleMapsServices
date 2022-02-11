namespace GoogleMapsServices.Client;

/// <summary>An object describing the opening hours of a place.</summary>
public sealed class PlaceOpeningHours
{
    /// <summary>
    /// A boolean value indicating if the place is open at the current time.
    /// </summary>
    public bool OpenNow { get; set; }

    /// <summary>
    /// An array of opening periods covering seven days, starting from Sunday, in chronological order.
    /// </summary>
    public ICollection<PlaceOpeningHoursPeriod> Periods { get; set; }

    /// <summary>
    /// An array of strings describing in human-readable text the hours of the place.
    /// </summary>
    public ICollection<string> WeekdayText { get; set; }

}