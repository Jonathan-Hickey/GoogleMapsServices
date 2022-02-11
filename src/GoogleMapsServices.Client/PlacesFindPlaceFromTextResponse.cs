using System.Collections.ObjectModel;

namespace GoogleMapsServices.Client
{
    public sealed class PlacesFindPlaceFromTextResponse
    {
        /// <summary>Contains an array of Place candidates.
        /// Place Search requests return a subset of the fields that are returned by Place Details requests. If the field you want is not returned by Place Search, you can use Place Search to get a place_id, then use that Place ID to make a Place Details request.
        /// </summary>
        public ICollection<Place> Candidates { get; set; } = new Collection<Place>();

        /// <summary>
        /// Contains the status of the request, and may contain debugging information to help you track down why the request failed.
        /// </summary>
        public PlacesSearchStatus Status { get; set; }

        /// <summary>
        /// When the service returns a status code other than `OK&lt;`, there may be an additional `error_message` field within the response object. This field contains more detailed information about thereasons behind the given status code. This field is not always returned, and its content is subject to change.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// When the service returns additional information about the request specification, there may be an additional `info_messages` field within the response object. This field is only returned for successful requests. It may not always be returned, and its content is subject to change.
        /// </summary>
        public ICollection<string> InfoMessages { get; set; }
    }
}

