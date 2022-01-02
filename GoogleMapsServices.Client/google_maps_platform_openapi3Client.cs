namespace GoogleMapsServices.Client;

[System.CodeDom.Compiler.GeneratedCode("NSwag", "13.0.5.0 (NJsonSchema v10.0.22.0 (Newtonsoft.Json v11.0.0.0))")]
public partial class google_maps_platform_openapi3Client
{
    private string _baseUrl = "https://www.googleapis.com";
    private HttpClient _httpClient;
    private Lazy<Newtonsoft.Json.JsonSerializerSettings> _settings;

    public google_maps_platform_openapi3Client(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _settings = new Lazy<Newtonsoft.Json.JsonSerializerSettings>(() =>
        {
            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            UpdateJsonSerializerSettings(settings);
            return settings;
        });
    }

    public string BaseUrl
    {
        get { return _baseUrl; }
        set { _baseUrl = value; }
    }

    protected Newtonsoft.Json.JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }

    partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings);
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url);
    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, System.Text.StringBuilder urlBuilder);
    partial void ProcessResponse(HttpClient client, HttpResponseMessage response);

    /// <param name="body">The request body must be formatted as JSON.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<GeolocationResponse> GeolocateAsync(GeolocationRequest body)
    {
        return GeolocateAsync(body, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="body">The request body must be formatted as JSON.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<GeolocationResponse> GeolocateAsync(GeolocationRequest body, CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/geolocation/v1/geolocate");

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                var content_ = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
                request_.Content = content_;
                request_.Method = new HttpMethod("POST");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GeolocationResponse>(response_, headers_).ConfigureAwait(false);
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == "400")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_).ConfigureAwait(false);
                        throw new ApiException<ErrorResponse>("400 BAD REQUEST", (int)response_.StatusCode, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ == "404")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<ErrorResponse>(response_, headers_).ConfigureAwait(false);
                        throw new ApiException<ErrorResponse>("404 NOT FOUND", (int)response_.StatusCode, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(GeolocationResponse);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    /// <param name="arrival_time">Specifies the desired time of arrival for transit directions, in seconds since midnight, January 1, 1970 UTC. You can specify either `departure_time` or `arrival_time`, but not both. Note that `arrival_time` must be specified as an integer.</param>
    /// <param name="departure_time">Specifies the desired time of departure. You can specify the time as an integer in seconds since midnight, January 1, 1970 UTC. If a `departure_time` later than 9999-12-31T23:59:59.999999999Z is specified, the API will fall back the `departure_time` to 9999-12-31T23:59:59.999999999Z. Alternatively, you can specify a value of now, which sets the departure time to the current time (correct to the nearest second). The departure time may be specified in two cases:
    /// * For requests where the travel mode is transit: You can optionally specify one of `departure_time` or `arrival_time`. If neither time is specified, the `departure_time` defaults to now (that is, the departure time defaults to the current time).
    /// * For requests where the travel mode is driving: You can specify the `departure_time` to receive a route and trip duration (response field: duration_in_traffic) that take traffic conditions into account. The `departure_time` must be set to the current time or some time in the future. It cannot be in the past.
    /// 
    /// &lt;div class="note"&gt;Note: If departure time is not specified, choice of route and duration are based on road network and average time-independent traffic conditions. Results for a given request may vary over time due to changes in the road network, updated average traffic conditions, and the distributed nature of the service. Results may also vary between nearly-equivalent routes at any time or frequency.&lt;/div&gt;
    /// &lt;div class="note"&gt;Note: Distance Matrix requests specifying `departure_time` when `mode=driving` are limited to a maximum of 100 elements per request. The number of origins times the number of destinations defines the number of elements.&lt;/div&gt;</param>
    /// <param name="alternatives">If set to `true`, specifies that the Directions service may provide more than one route alternative in the response. Note that providing route alternatives may increase the response time from the server. This is only available for requests without intermediate waypoints. For more information, see the [guide to waypoints](https://developers.google.com/maps/documentation/directions/get-directions#Waypoints).</param>
    /// <param name="avoid">Indicates that the calculated route(s) should avoid the indicated features. This parameter supports the following arguments:
    /// * `tolls` indicates that the calculated route should avoid toll roads/bridges.
    /// * `highways` indicates that the calculated route should avoid highways.
    /// * `ferries` indicates that the calculated route should avoid ferries.
    /// * `indoor` indicates that the calculated route should avoid indoor steps for walking and transit directions.
    /// 
    /// It's possible to request a route that avoids any combination of tolls, highways and ferries by passing multiple restrictions to the avoid parameter. For example: 
    /// 
    /// ```
    /// avoid=tolls|highways|ferries.
    /// ```</param>
    /// <param name="destination">The place ID, address, or textual latitude/longitude value to which you wish to calculate directions. The options for the destination parameter are the same as for the origin parameter.</param>
    /// <param name="origin">The place ID, address, or textual latitude/longitude value from which you wish to calculate directions.
    /// * Place IDs must be prefixed with `place_id:`. You can retrieve place IDs from the Geocoding API and the Places API (including Place Autocomplete). For an example using place IDs from Place Autocomplete, see [Place Autocomplete and Directions](https://developers.google.com/maps/documentation/javascript/examples/places-autocomplete-directions). For more about place IDs, see the [Place ID overview](https://developers.google.com/maps/documentation/places/web-service/place-id).
    ///   
    ///   ```
    ///   origin=place_id:ChIJ3S-JXmauEmsRUcIaWtf4MzE
    ///   ```
    ///   
    /// * If you pass an address, the Directions service geocodes the string and converts it to a latitude/longitude coordinate to calculate directions. This coordinate may be different from that returned by the Geocoding API, for example a building entrance rather than its center.
    ///   
    ///   ```
    ///   origin=24+Sussex+Drive+Ottawa+ON
    ///   ```
    ///   
    ///   Using place IDs is preferred over using addresses or latitude/longitude coordinates. Using coordinates will always result in the point being snapped to the road nearest to those coordinates - which may not be an access point to the property, or even a road that will quickly or safely lead to the destination.
    /// * If you pass coordinates, the point will snap to the nearest road. Passing a place ID is preferred. If you do pass coordinates, ensure that no space exists between the latitude and longitude values.
    ///   
    ///   ```
    ///   origin=41.43206,-81.38992
    ///   ```
    /// 
    /// * Plus codes must be formatted as a global code or a compound code. Format plus codes as shown here (plus signs are url-escaped to `%2B` and spaces are url-escaped to `%20`). 
    ///   
    ///   * **Global code** is a 4 character area code and 6 character or longer local code (849VCWC8+R9 is `849VCWC8%2BR9`). 
    ///   * **Compound code** is a 6 character or longer local code with an explicit location (CWC8+R9 Mountain View, CA, USA is `CWC8%2BR9%20Mountain%20View%20CA%20USA`).
    /// 
    /// &lt;div class="note"&gt;Note: For efficiency and accuracy, use place ID's when possible. These ID's are uniquely explicit like a lat/lng value pair and provide geocoding benefits for routing such as access points and traffic variables. Unlike an address, ID's do not require the service to perform a search or an intermediate request for place details; therefore, performance is better.&lt;/div&gt;</param>
    /// <param name="units">Specifies the unit system to use when displaying results.
    /// 
    /// Directions results contain text within distance fields that may be displayed to the user to indicate the distance of a particular "step" of the route. By default, this text uses the unit system of the origin's country or region.
    /// 
    /// For example, a route from "Chicago, IL" to "Toronto, ONT" will display results in miles, while the reverse route will display results in kilometers. You may override this unit system by setting one explicitly within the request's units parameter, passing one of the following values:
    /// 
    /// * `metric` specifies usage of the metric system. Textual distances are returned using kilometers and meters.
    /// * `imperial` specifies usage of the Imperial (English) system. Textual distances are returned using miles and feet.
    /// 
    /// &lt;div class="note"&gt;Note: this unit system setting only affects the text displayed within distance fields. The distance fields also contain values which are always expressed in meters.&lt;/div&gt;</param>
    /// <param name="waypoints">&lt;div class="caution"&gt;Caution: Requests using more than 10 waypoints (between 11 and 25), or waypoint optimization, are billed at a higher rate. &lt;a href="https://developers.google.com/maps/billing/gmp-billing#directions-advanced"&gt;Learn more about billing&lt;/a&gt; for Google Maps Platform products.&lt;/div&gt;
    /// 
    /// Specifies an array of intermediate locations to include along the route between the origin and destination points as pass through or stopover locations. Waypoints alter a route by directing it through the specified location(s). The API supports waypoints for these travel modes: driving, walking and bicycling; not transit.   You can supply one or more locations separated by the pipe character (`|` or `%7C`), in the form of a place ID, an address, or latitude/longitude coordinates. By default, the Directions service calculates a route using the waypoints in the order they are given. The precedence for parsing the value of the waypoint is place ID, latitude/longitude coordinates, then address.
    /// * If you pass a place ID, you must prefix it with `place_id:`. You can retrieve place IDs from the Geocoding API and the Places API (including Place Autocomplete). For an example using place IDs from Place Autocomplete, see [Place Autocomplete and Directions](/maps/documentation/javascript/examples/places-autocomplete-directions). For more about place IDs, see the [Place ID overview](/maps/documentation/places/web-service/place-id).
    ///   &lt;div class="note"&gt;For efficiency and accuracy, use place ID's when possible. These ID's are uniquely explicit like a lat/lng value pair and provide geocoding benefits for routing such as access points and traffic variables. Unlike an address, ID's do not require the service to perform a search or an intermediate request for place details; therefore, performance is better.&lt;/div&gt;
    /// * If you pass latitude/longitude coordinates, the values go directly to the front-end server to calculate directions without geocoding. The points are snapped to roads and might not provide the accuracy your app needs. Use coordinates when you are confident the values truly specify the points your app needs for routing without regard to possible access points or additional geocoding details. Ensure that a comma (`%2C`) and not a space (`%20`) separates the latitude and longitude values.
    /// * If you pass an address, the Directions service will geocode the string and convert it into latitude/longitude coordinates to calculate directions. If the address value is ambiguous, the value might evoke a search to disambiguate from similar addresses. For example, "1st Street" could be a complete value or a partial value for "1st street NE" or "1st St SE". This result may be different from that returned by the Geocoding API. You can avoid possible misinterpretations using place IDs.
    /// * Alternatively, you can supply an encoded set of points using the [Encoded Polyline Algorithm](https://developers.google.com/maps/documentation/utilities/polylinealgorithm). You will find an encoded set is useful for a large number of waypoints, because the URL is significantly shorter. All web services have a URL limit of 8192 characters.
    ///   * Encoded polylines must be prefixed with `enc:` and followed by a colon (`:`). For example: `waypoints=enc:gfo}EtohhU:`.
    ///   * You can also include multiple encoded polylines, separated by the pipe character (`|`). For example, `waypoints=via:enc:wc~oAwquwMdlTxiKtqLyiK:|enc:c~vnAamswMvlTor@tjGi}L:| via:enc:udymA{~bxM:`
    /// 
    /// ##### Influence routes with stopover and pass through points
    /// 
    /// For each waypoint in the request, the directions response appends an entry to the `legs` array to provide the details for stopovers on that leg of the journey.
    /// 
    /// If you'd like to influence the route using waypoints without adding a stopover, add the prefix `via:` to the waypoint. Waypoints prefixed with `via:` will not add an entry to the `legs` array, but will route the journey through the waypoint.
    /// 
    /// The following URL modifies the previous request such that the journey is routed through Lexington without stopping:
    /// 
    /// ```
    /// https://maps.googleapis.com/maps/api/directions/json?
    /// origin=Boston,MA&amp;destination=Concord,MA
    /// &amp;waypoints=Charlestown,MA|via:Lexington,MA  
    /// ```
    /// 
    /// The `via:` prefix is most effective when creating routes in response to the user dragging the waypoints on the map. Doing so allows the user to see how the final route may look in real-time and helps ensure that waypoints are placed in locations that are accessible to the Directions API.
    /// 
    /// &lt;div class="caution"&gt;Caution: Using the `via:` prefix to avoid stopovers results in directions that are strict in their interpretation of the waypoint. This interpretation may result in severe detours on the route or `ZERO_RESULTS` in the response status code if the Directions API is unable to create directions through that point.&lt;/div&gt;
    /// 
    /// 
    /// ##### Optimize your waypoints
    /// 
    /// By default, the Directions service calculates a route through the provided waypoints in their given order. Optionally, you may pass `optimize:true` as the first argument within the waypoints parameter to allow the Directions service to optimize the provided route by rearranging the waypoints in a more efficient order. (This optimization is an application of the traveling salesperson problem.) Travel time is the primary factor which is optimized, but other factors such as distance, number of turns and many more may be taken into account when deciding which route is the most efficient. All waypoints must be stopovers for the Directions service to optimize their route.
    /// 
    /// If you instruct the Directions service to optimize the order of its waypoints, their order will be returned in the `waypoint_order` field within the routes object. The `waypoint_order` field returns values which are zero-based.
    /// 
    /// The following example calculates a road journey from Adelaide, South Australia to each of South Australia's main wine regions using route optimization.
    /// 
    /// ```
    /// https://maps.googleapis.com/maps/api/directions/json?
    /// origin=Adelaide,SA&amp;destination=Adelaide,SA
    /// &amp;waypoints=optimize:true|Barossa+Valley,SA|Clare,SA|Connawarra,SA|McLaren+Vale,SA
    /// ```
    /// 
    /// Inspection of the calculated route will indicate that calculation uses waypoints in the following waypoint order:
    /// 
    /// ```
    /// "waypoint_order": [ 3, 2, 0, 1 ]
    /// ```
    /// 
    /// &lt;div class="caution"&gt;Caution: Requests using waypoint optimization are billed at a higher rate. &lt;a href="https://developers.devsite.corp.google.com/maps/billing/gmp-billing#directions-advanced"&gt;Learn more about how Google Maps Platform products are billed.&lt;/a&gt;&lt;/div&gt;</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <param name="mode">For the calculation of distances and directions, you may specify the transportation mode to use. By default, `DRIVING` mode is used. By default, directions are calculated as driving directions. The following travel modes are supported:
    /// 
    /// * `driving` (default) indicates standard driving directions or distance using the road network.
    /// * `walking` requests walking directions or distance via pedestrian paths &amp; sidewalks (where available).
    /// * `bicycling` requests bicycling directions or distance via bicycle paths &amp; preferred streets (where available).
    /// * `transit` requests directions or distance via public transit routes (where available). If you set the mode to transit, you can optionally specify either a `departure_time` or an `arrival_time`. If neither time is specified, the `departure_time` defaults to now (that is, the departure time defaults to the current time). You can also optionally include a `transit_mode` and/or a `transit_routing_preference`.
    /// 
    /// &lt;div class="note"&gt;Note: Both walking and bicycling directions may sometimes not include clear pedestrian or bicycling paths, so these directions will return warnings in the returned result which you must display to the user.&lt;/div&gt;</param>
    /// <param name="region">The region code, specified as a [ccTLD ("top-level domain")](https://en.wikipedia.org/wiki/List_of_Internet_top-level_domains#Country_code_top-level_domains) two-character value. Most ccTLD codes are identical to ISO 3166-1 codes, with some notable exceptions. For example, the United Kingdom's ccTLD is "uk" (.co.uk) while its ISO 3166-1 code is "gb" (technically for the entity of "The United Kingdom of Great Britain and Northern Ireland").</param>
    /// <param name="traffic_model">Specifies the assumptions to use when calculating time in traffic. This setting affects the value returned in the duration_in_traffic field in the response, which contains the predicted time in traffic based on historical averages. The `traffic_model` parameter may only be specified for driving directions where the request includes a `departure_time`. The available values for this parameter are:
    /// * `best_guess` (default) indicates that the returned duration_in_traffic should be the best estimate of travel time given what is known about both historical traffic conditions and live traffic. Live traffic becomes more important the closer the `departure_time` is to now.
    /// * `pessimistic` indicates that the returned duration_in_traffic should be longer than the actual travel time on most days, though occasional days with particularly bad traffic conditions may exceed this value.
    /// * `optimistic` indicates that the returned duration_in_traffic should be shorter than the actual travel time on most days, though occasional days with particularly good traffic conditions may be faster than this value.
    /// The default value of `best_guess` will give the most useful predictions for the vast majority of use cases. It is possible the `best_guess` travel time prediction may be shorter than `optimistic`, or alternatively, longer than `pessimistic`, due to the way the `best_guess` prediction model integrates live traffic information.</param>
    /// <param name="transit_mode">Specifies one or more preferred modes of transit. This parameter may only be specified for transit directions. The parameter supports the following arguments:
    /// * `bus` indicates that the calculated route should prefer travel by bus.
    /// * `subway` indicates that the calculated route should prefer travel by subway.
    /// * `train` indicates that the calculated route should prefer travel by train.
    /// * `tram` indicates that the calculated route should prefer travel by tram and light rail.
    /// * `rail` indicates that the calculated route should prefer travel by train, tram, light rail, and subway. This is equivalent to `transit_mode=train|tram|subway`.</param>
    /// <param name="transit_routing_preference">Specifies preferences for transit routes. Using this parameter, you can bias the options returned, rather than accepting the default best route chosen by the API. This parameter may only be specified for transit directions. The parameter supports the following arguments:
    /// * `less_walking` indicates that the calculated route should prefer limited amounts of walking.
    /// * `fewer_transfers` indicates that the calculated route should prefer a limited number of transfers.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<DirectionsResponse> DirectionsAsync(double? arrival_time, double? departure_time, bool? alternatives, string avoid, string destination, string origin, Units? units, string waypoints, Language? language, Mode? mode, Region? region, Traffic_model? traffic_model, string transit_mode, Transit_routing_preference? transit_routing_preference)
    {
        return DirectionsAsync(arrival_time, departure_time, alternatives, avoid, destination, origin, units, waypoints, language, mode, region, traffic_model, transit_mode, transit_routing_preference, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="arrival_time">Specifies the desired time of arrival for transit directions, in seconds since midnight, January 1, 1970 UTC. You can specify either `departure_time` or `arrival_time`, but not both. Note that `arrival_time` must be specified as an integer.</param>
    /// <param name="departure_time">Specifies the desired time of departure. You can specify the time as an integer in seconds since midnight, January 1, 1970 UTC. If a `departure_time` later than 9999-12-31T23:59:59.999999999Z is specified, the API will fall back the `departure_time` to 9999-12-31T23:59:59.999999999Z. Alternatively, you can specify a value of now, which sets the departure time to the current time (correct to the nearest second). The departure time may be specified in two cases:
    /// * For requests where the travel mode is transit: You can optionally specify one of `departure_time` or `arrival_time`. If neither time is specified, the `departure_time` defaults to now (that is, the departure time defaults to the current time).
    /// * For requests where the travel mode is driving: You can specify the `departure_time` to receive a route and trip duration (response field: duration_in_traffic) that take traffic conditions into account. The `departure_time` must be set to the current time or some time in the future. It cannot be in the past.
    /// 
    /// &lt;div class="note"&gt;Note: If departure time is not specified, choice of route and duration are based on road network and average time-independent traffic conditions. Results for a given request may vary over time due to changes in the road network, updated average traffic conditions, and the distributed nature of the service. Results may also vary between nearly-equivalent routes at any time or frequency.&lt;/div&gt;
    /// &lt;div class="note"&gt;Note: Distance Matrix requests specifying `departure_time` when `mode=driving` are limited to a maximum of 100 elements per request. The number of origins times the number of destinations defines the number of elements.&lt;/div&gt;</param>
    /// <param name="alternatives">If set to `true`, specifies that the Directions service may provide more than one route alternative in the response. Note that providing route alternatives may increase the response time from the server. This is only available for requests without intermediate waypoints. For more information, see the [guide to waypoints](https://developers.google.com/maps/documentation/directions/get-directions#Waypoints).</param>
    /// <param name="avoid">Indicates that the calculated route(s) should avoid the indicated features. This parameter supports the following arguments:
    /// * `tolls` indicates that the calculated route should avoid toll roads/bridges.
    /// * `highways` indicates that the calculated route should avoid highways.
    /// * `ferries` indicates that the calculated route should avoid ferries.
    /// * `indoor` indicates that the calculated route should avoid indoor steps for walking and transit directions.
    /// 
    /// It's possible to request a route that avoids any combination of tolls, highways and ferries by passing multiple restrictions to the avoid parameter. For example: 
    /// 
    /// ```
    /// avoid=tolls|highways|ferries.
    /// ```</param>
    /// <param name="destination">The place ID, address, or textual latitude/longitude value to which you wish to calculate directions. The options for the destination parameter are the same as for the origin parameter.</param>
    /// <param name="origin">The place ID, address, or textual latitude/longitude value from which you wish to calculate directions.
    /// * Place IDs must be prefixed with `place_id:`. You can retrieve place IDs from the Geocoding API and the Places API (including Place Autocomplete). For an example using place IDs from Place Autocomplete, see [Place Autocomplete and Directions](https://developers.google.com/maps/documentation/javascript/examples/places-autocomplete-directions). For more about place IDs, see the [Place ID overview](https://developers.google.com/maps/documentation/places/web-service/place-id).
    ///   
    ///   ```
    ///   origin=place_id:ChIJ3S-JXmauEmsRUcIaWtf4MzE
    ///   ```
    ///   
    /// * If you pass an address, the Directions service geocodes the string and converts it to a latitude/longitude coordinate to calculate directions. This coordinate may be different from that returned by the Geocoding API, for example a building entrance rather than its center.
    ///   
    ///   ```
    ///   origin=24+Sussex+Drive+Ottawa+ON
    ///   ```
    ///   
    ///   Using place IDs is preferred over using addresses or latitude/longitude coordinates. Using coordinates will always result in the point being snapped to the road nearest to those coordinates - which may not be an access point to the property, or even a road that will quickly or safely lead to the destination.
    /// * If you pass coordinates, the point will snap to the nearest road. Passing a place ID is preferred. If you do pass coordinates, ensure that no space exists between the latitude and longitude values.
    ///   
    ///   ```
    ///   origin=41.43206,-81.38992
    ///   ```
    /// 
    /// * Plus codes must be formatted as a global code or a compound code. Format plus codes as shown here (plus signs are url-escaped to `%2B` and spaces are url-escaped to `%20`). 
    ///   
    ///   * **Global code** is a 4 character area code and 6 character or longer local code (849VCWC8+R9 is `849VCWC8%2BR9`). 
    ///   * **Compound code** is a 6 character or longer local code with an explicit location (CWC8+R9 Mountain View, CA, USA is `CWC8%2BR9%20Mountain%20View%20CA%20USA`).
    /// 
    /// &lt;div class="note"&gt;Note: For efficiency and accuracy, use place ID's when possible. These ID's are uniquely explicit like a lat/lng value pair and provide geocoding benefits for routing such as access points and traffic variables. Unlike an address, ID's do not require the service to perform a search or an intermediate request for place details; therefore, performance is better.&lt;/div&gt;</param>
    /// <param name="units">Specifies the unit system to use when displaying results.
    /// 
    /// Directions results contain text within distance fields that may be displayed to the user to indicate the distance of a particular "step" of the route. By default, this text uses the unit system of the origin's country or region.
    /// 
    /// For example, a route from "Chicago, IL" to "Toronto, ONT" will display results in miles, while the reverse route will display results in kilometers. You may override this unit system by setting one explicitly within the request's units parameter, passing one of the following values:
    /// 
    /// * `metric` specifies usage of the metric system. Textual distances are returned using kilometers and meters.
    /// * `imperial` specifies usage of the Imperial (English) system. Textual distances are returned using miles and feet.
    /// 
    /// &lt;div class="note"&gt;Note: this unit system setting only affects the text displayed within distance fields. The distance fields also contain values which are always expressed in meters.&lt;/div&gt;</param>
    /// <param name="waypoints">&lt;div class="caution"&gt;Caution: Requests using more than 10 waypoints (between 11 and 25), or waypoint optimization, are billed at a higher rate. &lt;a href="https://developers.google.com/maps/billing/gmp-billing#directions-advanced"&gt;Learn more about billing&lt;/a&gt; for Google Maps Platform products.&lt;/div&gt;
    /// 
    /// Specifies an array of intermediate locations to include along the route between the origin and destination points as pass through or stopover locations. Waypoints alter a route by directing it through the specified location(s). The API supports waypoints for these travel modes: driving, walking and bicycling; not transit.   You can supply one or more locations separated by the pipe character (`|` or `%7C`), in the form of a place ID, an address, or latitude/longitude coordinates. By default, the Directions service calculates a route using the waypoints in the order they are given. The precedence for parsing the value of the waypoint is place ID, latitude/longitude coordinates, then address.
    /// * If you pass a place ID, you must prefix it with `place_id:`. You can retrieve place IDs from the Geocoding API and the Places API (including Place Autocomplete). For an example using place IDs from Place Autocomplete, see [Place Autocomplete and Directions](/maps/documentation/javascript/examples/places-autocomplete-directions). For more about place IDs, see the [Place ID overview](/maps/documentation/places/web-service/place-id).
    ///   &lt;div class="note"&gt;For efficiency and accuracy, use place ID's when possible. These ID's are uniquely explicit like a lat/lng value pair and provide geocoding benefits for routing such as access points and traffic variables. Unlike an address, ID's do not require the service to perform a search or an intermediate request for place details; therefore, performance is better.&lt;/div&gt;
    /// * If you pass latitude/longitude coordinates, the values go directly to the front-end server to calculate directions without geocoding. The points are snapped to roads and might not provide the accuracy your app needs. Use coordinates when you are confident the values truly specify the points your app needs for routing without regard to possible access points or additional geocoding details. Ensure that a comma (`%2C`) and not a space (`%20`) separates the latitude and longitude values.
    /// * If you pass an address, the Directions service will geocode the string and convert it into latitude/longitude coordinates to calculate directions. If the address value is ambiguous, the value might evoke a search to disambiguate from similar addresses. For example, "1st Street" could be a complete value or a partial value for "1st street NE" or "1st St SE". This result may be different from that returned by the Geocoding API. You can avoid possible misinterpretations using place IDs.
    /// * Alternatively, you can supply an encoded set of points using the [Encoded Polyline Algorithm](https://developers.google.com/maps/documentation/utilities/polylinealgorithm). You will find an encoded set is useful for a large number of waypoints, because the URL is significantly shorter. All web services have a URL limit of 8192 characters.
    ///   * Encoded polylines must be prefixed with `enc:` and followed by a colon (`:`). For example: `waypoints=enc:gfo}EtohhU:`.
    ///   * You can also include multiple encoded polylines, separated by the pipe character (`|`). For example, `waypoints=via:enc:wc~oAwquwMdlTxiKtqLyiK:|enc:c~vnAamswMvlTor@tjGi}L:| via:enc:udymA{~bxM:`
    /// 
    /// ##### Influence routes with stopover and pass through points
    /// 
    /// For each waypoint in the request, the directions response appends an entry to the `legs` array to provide the details for stopovers on that leg of the journey.
    /// 
    /// If you'd like to influence the route using waypoints without adding a stopover, add the prefix `via:` to the waypoint. Waypoints prefixed with `via:` will not add an entry to the `legs` array, but will route the journey through the waypoint.
    /// 
    /// The following URL modifies the previous request such that the journey is routed through Lexington without stopping:
    /// 
    /// ```
    /// https://maps.googleapis.com/maps/api/directions/json?
    /// origin=Boston,MA&amp;destination=Concord,MA
    /// &amp;waypoints=Charlestown,MA|via:Lexington,MA  
    /// ```
    /// 
    /// The `via:` prefix is most effective when creating routes in response to the user dragging the waypoints on the map. Doing so allows the user to see how the final route may look in real-time and helps ensure that waypoints are placed in locations that are accessible to the Directions API.
    /// 
    /// &lt;div class="caution"&gt;Caution: Using the `via:` prefix to avoid stopovers results in directions that are strict in their interpretation of the waypoint. This interpretation may result in severe detours on the route or `ZERO_RESULTS` in the response status code if the Directions API is unable to create directions through that point.&lt;/div&gt;
    /// 
    /// 
    /// ##### Optimize your waypoints
    /// 
    /// By default, the Directions service calculates a route through the provided waypoints in their given order. Optionally, you may pass `optimize:true` as the first argument within the waypoints parameter to allow the Directions service to optimize the provided route by rearranging the waypoints in a more efficient order. (This optimization is an application of the traveling salesperson problem.) Travel time is the primary factor which is optimized, but other factors such as distance, number of turns and many more may be taken into account when deciding which route is the most efficient. All waypoints must be stopovers for the Directions service to optimize their route.
    /// 
    /// If you instruct the Directions service to optimize the order of its waypoints, their order will be returned in the `waypoint_order` field within the routes object. The `waypoint_order` field returns values which are zero-based.
    /// 
    /// The following example calculates a road journey from Adelaide, South Australia to each of South Australia's main wine regions using route optimization.
    /// 
    /// ```
    /// https://maps.googleapis.com/maps/api/directions/json?
    /// origin=Adelaide,SA&amp;destination=Adelaide,SA
    /// &amp;waypoints=optimize:true|Barossa+Valley,SA|Clare,SA|Connawarra,SA|McLaren+Vale,SA
    /// ```
    /// 
    /// Inspection of the calculated route will indicate that calculation uses waypoints in the following waypoint order:
    /// 
    /// ```
    /// "waypoint_order": [ 3, 2, 0, 1 ]
    /// ```
    /// 
    /// &lt;div class="caution"&gt;Caution: Requests using waypoint optimization are billed at a higher rate. &lt;a href="https://developers.devsite.corp.google.com/maps/billing/gmp-billing#directions-advanced"&gt;Learn more about how Google Maps Platform products are billed.&lt;/a&gt;&lt;/div&gt;</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <param name="mode">For the calculation of distances and directions, you may specify the transportation mode to use. By default, `DRIVING` mode is used. By default, directions are calculated as driving directions. The following travel modes are supported:
    /// 
    /// * `driving` (default) indicates standard driving directions or distance using the road network.
    /// * `walking` requests walking directions or distance via pedestrian paths &amp; sidewalks (where available).
    /// * `bicycling` requests bicycling directions or distance via bicycle paths &amp; preferred streets (where available).
    /// * `transit` requests directions or distance via public transit routes (where available). If you set the mode to transit, you can optionally specify either a `departure_time` or an `arrival_time`. If neither time is specified, the `departure_time` defaults to now (that is, the departure time defaults to the current time). You can also optionally include a `transit_mode` and/or a `transit_routing_preference`.
    /// 
    /// &lt;div class="note"&gt;Note: Both walking and bicycling directions may sometimes not include clear pedestrian or bicycling paths, so these directions will return warnings in the returned result which you must display to the user.&lt;/div&gt;</param>
    /// <param name="region">The region code, specified as a [ccTLD ("top-level domain")](https://en.wikipedia.org/wiki/List_of_Internet_top-level_domains#Country_code_top-level_domains) two-character value. Most ccTLD codes are identical to ISO 3166-1 codes, with some notable exceptions. For example, the United Kingdom's ccTLD is "uk" (.co.uk) while its ISO 3166-1 code is "gb" (technically for the entity of "The United Kingdom of Great Britain and Northern Ireland").</param>
    /// <param name="traffic_model">Specifies the assumptions to use when calculating time in traffic. This setting affects the value returned in the duration_in_traffic field in the response, which contains the predicted time in traffic based on historical averages. The `traffic_model` parameter may only be specified for driving directions where the request includes a `departure_time`. The available values for this parameter are:
    /// * `best_guess` (default) indicates that the returned duration_in_traffic should be the best estimate of travel time given what is known about both historical traffic conditions and live traffic. Live traffic becomes more important the closer the `departure_time` is to now.
    /// * `pessimistic` indicates that the returned duration_in_traffic should be longer than the actual travel time on most days, though occasional days with particularly bad traffic conditions may exceed this value.
    /// * `optimistic` indicates that the returned duration_in_traffic should be shorter than the actual travel time on most days, though occasional days with particularly good traffic conditions may be faster than this value.
    /// The default value of `best_guess` will give the most useful predictions for the vast majority of use cases. It is possible the `best_guess` travel time prediction may be shorter than `optimistic`, or alternatively, longer than `pessimistic`, due to the way the `best_guess` prediction model integrates live traffic information.</param>
    /// <param name="transit_mode">Specifies one or more preferred modes of transit. This parameter may only be specified for transit directions. The parameter supports the following arguments:
    /// * `bus` indicates that the calculated route should prefer travel by bus.
    /// * `subway` indicates that the calculated route should prefer travel by subway.
    /// * `train` indicates that the calculated route should prefer travel by train.
    /// * `tram` indicates that the calculated route should prefer travel by tram and light rail.
    /// * `rail` indicates that the calculated route should prefer travel by train, tram, light rail, and subway. This is equivalent to `transit_mode=train|tram|subway`.</param>
    /// <param name="transit_routing_preference">Specifies preferences for transit routes. Using this parameter, you can bias the options returned, rather than accepting the default best route chosen by the API. This parameter may only be specified for transit directions. The parameter supports the following arguments:
    /// * `less_walking` indicates that the calculated route should prefer limited amounts of walking.
    /// * `fewer_transfers` indicates that the calculated route should prefer a limited number of transfers.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<DirectionsResponse> DirectionsAsync(double? arrival_time, double? departure_time, bool? alternatives, string avoid, string destination, string origin, Units? units, string waypoints, Language? language, Mode? mode, Region? region, Traffic_model? traffic_model, string transit_mode, Transit_routing_preference? transit_routing_preference, CancellationToken cancellationToken)
    {
        if (destination == null)
            throw new ArgumentNullException("destination");

        if (origin == null)
            throw new ArgumentNullException("origin");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/maps/api/directions/json?");
        if (arrival_time != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("arrival_time") + "=").Append(Uri.EscapeDataString(ConvertToString(arrival_time, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (departure_time != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("departure_time") + "=").Append(Uri.EscapeDataString(ConvertToString(departure_time, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (alternatives != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("alternatives") + "=").Append(Uri.EscapeDataString(ConvertToString(alternatives, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (avoid != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("avoid") + "=").Append(Uri.EscapeDataString(ConvertToString(avoid, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Append(Uri.EscapeDataString("destination") + "=").Append(Uri.EscapeDataString(ConvertToString(destination, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        urlBuilder_.Append(Uri.EscapeDataString("origin") + "=").Append(Uri.EscapeDataString(ConvertToString(origin, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        if (units != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("units") + "=").Append(Uri.EscapeDataString(ConvertToString(units, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (waypoints != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("waypoints") + "=").Append(Uri.EscapeDataString(ConvertToString(waypoints, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (language != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("language") + "=").Append(Uri.EscapeDataString(ConvertToString(language, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (mode != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("mode") + "=").Append(Uri.EscapeDataString(ConvertToString(mode, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (region != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("region") + "=").Append(Uri.EscapeDataString(ConvertToString(region, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (traffic_model != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("traffic_model") + "=").Append(Uri.EscapeDataString(ConvertToString(traffic_model, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (transit_mode != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("transit_mode") + "=").Append(Uri.EscapeDataString(ConvertToString(transit_mode, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (transit_routing_preference != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("transit_routing_preference") + "=").Append(Uri.EscapeDataString(ConvertToString(transit_routing_preference, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Length--;

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<DirectionsResponse>(response_, headers_).ConfigureAwait(false);
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(DirectionsResponse);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    /// <param name="locations">Positional requests are indicated through use of the locations parameter, indicating elevation requests for the specific locations passed as latitude/longitude values.
    /// 
    /// The locations parameter may take the following arguments:
    /// 
    /// - A single coordinate: `locations=40.714728,-73.998672`
    /// - An array of coordinates separated using the pipe ('|') character: 
    ///   ```
    ///   locations=40.714728,-73.998672|-34.397,150.644
    ///   ```
    /// - A set of encoded coordinates using the [Encoded Polyline Algorithm](https://developers.google.com/maps/documentation/utilities/polylinealgorithm): 
    ///   ```
    ///   locations=enc:gfo}EtohhU
    ///   ```
    /// 
    /// Latitude and longitude coordinate strings are defined using numerals within a comma-separated text string. For example, "40.714728,-73.998672" is a valid locations value. Latitude and longitude values must correspond to a valid location on the face of the earth. Latitudes can take any value between -90 and 90 while longitude values can take any value between -180 and 180. If you specify an invalid latitude or longitude value, your request will be rejected as a bad request.
    /// 
    /// You may pass any number of multiple coordinates within an array or encoded polyline, while still constructing a valid URL. Note that when passing multiple coordinates, the accuracy of any returned data may be of lower resolution than when requesting data for a single coordinate.</param>
    /// <param name="path">An array of comma separated `latitude,longitude` strings.</param>
    /// <param name="samples">Required if path parameter is set.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<Response> ElevationAsync(IEnumerable<string> locations, IEnumerable<string> path, double? samples)
    {
        return ElevationAsync(locations, path, samples, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="locations">Positional requests are indicated through use of the locations parameter, indicating elevation requests for the specific locations passed as latitude/longitude values.
    /// 
    /// The locations parameter may take the following arguments:
    /// 
    /// - A single coordinate: `locations=40.714728,-73.998672`
    /// - An array of coordinates separated using the pipe ('|') character: 
    ///   ```
    ///   locations=40.714728,-73.998672|-34.397,150.644
    ///   ```
    /// - A set of encoded coordinates using the [Encoded Polyline Algorithm](https://developers.google.com/maps/documentation/utilities/polylinealgorithm): 
    ///   ```
    ///   locations=enc:gfo}EtohhU
    ///   ```
    /// 
    /// Latitude and longitude coordinate strings are defined using numerals within a comma-separated text string. For example, "40.714728,-73.998672" is a valid locations value. Latitude and longitude values must correspond to a valid location on the face of the earth. Latitudes can take any value between -90 and 90 while longitude values can take any value between -180 and 180. If you specify an invalid latitude or longitude value, your request will be rejected as a bad request.
    /// 
    /// You may pass any number of multiple coordinates within an array or encoded polyline, while still constructing a valid URL. Note that when passing multiple coordinates, the accuracy of any returned data may be of lower resolution than when requesting data for a single coordinate.</param>
    /// <param name="path">An array of comma separated `latitude,longitude` strings.</param>
    /// <param name="samples">Required if path parameter is set.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<Response> ElevationAsync(IEnumerable<string> locations, IEnumerable<string> path, double? samples, CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/maps/api/elevation/json?");
        if (locations != null)
        {
            foreach (var item_ in locations) { urlBuilder_.Append(Uri.EscapeDataString("locations") + "=").Append(Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append("&"); }
        }
        if (path != null)
        {
            foreach (var item_ in path) { urlBuilder_.Append(Uri.EscapeDataString("path") + "=").Append(Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append("&"); }
        }
        if (samples != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("samples") + "=").Append(Uri.EscapeDataString(ConvertToString(samples, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Length--;

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<Response>(response_, headers_).ConfigureAwait(false);
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(Response);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    /// <param name="address">The street address or plus code that you want to geocode. Specify addresses in accordance with the format used by the national postal service of the country concerned. Additional address elements such as business names and unit, suite or floor numbers should be avoided. Street address elements should be delimited by spaces (shown here as url-escaped to `%20`):
    /// 
    /// ```
    /// address=24%20Sussex%20Drive%20Ottawa%20ON
    /// ```
    /// 
    /// Format plus codes as shown here (plus signs are url-escaped to `%2B` and spaces are url-escaped to `%20`):
    /// - global code is a 4 character area code and 6 character or longer local code (`849VCWC8+R9` is `849VCWC8%2BR9`).
    /// - compound code is a 6 character or longer local code with an explicit location (`CWC8+R9 Mountain View, CA, USA` is `CWC8%2BR9%20Mountain%20View%20CA%20USA`).
    /// 
    /// &lt;div class="note"&gt;Note: At least one of `address` or `components` is required.&lt;/div&gt;</param>
    /// <param name="bounds">The bounding box of the viewport within which to bias geocode results more prominently. This parameter will only influence, not fully restrict, results from the geocoder.</param>
    /// <param name="components">A components filter with elements separated by a pipe (|). The components filter is also accepted as an optional parameter if an address is provided. Each element in the components filter consists of a `component:value` pair, and fully restricts the results from the geocoder.
    /// 
    /// The components that can be filtered include:
    /// 
    /// * `postal_code` matches `postal_code` and `postal_code_prefix`.
    /// * `country` matches a country name or a two letter ISO 3166-1 country code. The API follows the ISO standard for defining countries, and the filtering works best when using the corresponding ISO code of the country.
    ///   &lt;aside class="note"&gt;&lt;strong&gt;Note&lt;/strong&gt;: If you receive unexpected results with a country code, verify that you are using a code which includes the countries, dependent territories, and special areas of geographical interest you intend. You can find code information at Wikipedia: List of ISO 3166 country codes or the ISO Online Browsing Platform.&lt;/aside&gt;
    ///   
    /// The following components may be used to influence results, but will not be enforced:
    /// 
    /// * `route` matches the long or short name of a route.
    /// * `locality` matches against `locality` and `sublocality` types.
    /// * `administrative_area` matches all the `administrative_area` levels.
    ///   
    /// Notes about component filtering:
    /// 
    /// * Do not repeat these component filters in requests, or the API will return `INVALID_REQUEST`: 
    ///   * `country`
    ///   * `postal_code`
    ///   * `route`
    /// * If the request contains repeated component filters, the API evaluates those filters as an AND, not an OR.
    /// * Results are consistent with Google Maps, which occasionally yields unexpected `ZERO_RESULTS` responses. Using Place Autocomplete may provide better results in some use cases. To learn more, see [this FAQ](https://developers.devsite.corp.google.com/maps/documentation/geocoding/faq#trbl_component_filtering).
    /// * For each address component, either specify it in the address parameter or in a components filter, but not both. Specifying the same values in both may result in `ZERO_RESULTS`.
    /// 
    /// &lt;div class="note"&gt;Note: At least one of `address` or `components` is required.&lt;/div&gt;</param>
    /// <param name="latlng">The street address that you want to geocode, in the format used by the national postal service of the country concerned. Additional address elements such as business names and unit, suite or floor numbers should be avoided.</param>
    /// <param name="location_type">A filter of one or more location types, separated by a pipe (`|`). If the parameter contains multiple location types, the API returns all addresses that match any of the types. A note about processing: The `location_type` parameter does not restrict the search to the specified location type(s). Rather, the `location_type` acts as a post-search filter: the API fetches all results for the specified latlng, then discards those results that do not match the specified location type(s). The following values are supported:
    /// * `APPROXIMATE` returns only the addresses that are characterized as approximate.
    /// * `GEOMETRIC_CENTER` returns only geometric centers of a location such as a polyline (for example, a street) or polygon (region).
    /// * `RANGE_INTERPOLATED` returns only the addresses that reflect an approximation (usually on a road) interpolated between two precise points (such as intersections). An interpolated range generally indicates that rooftop geocodes are unavailable for a street address.
    /// * `ROOFTOP` returns only the addresses for which Google has location information accurate down to street address precision.</param>
    /// <param name="place_id">A textual identifier that uniquely identifies a place, returned from a [Place Search](https://developers.google.com/maps/documentation/places/web-service/search).
    /// For more information about place IDs, see the [place ID overview](https://developers.google.com/maps/documentation/places/web-service/place-id).</param>
    /// <param name="result_type">A filter of one or more address types, separated by a pipe (|). If the parameter contains multiple address types, the API returns all addresses that match any of the types. A note about processing: The `result_type` parameter does not restrict the search to the specified address type(s). Rather, the `result_type` acts as a post-search filter: the API fetches all results for the specified `latlng`, then discards those results that do not match the specified address type(s).The following values are supported:
    /// * `administrative_area_level_1` indicates a first-order civil entity below the country level. Within the United States, these administrative levels are states. Not all nations exhibit these administrative levels. In most cases, administrative_area_level_1   * `short` names will closely match ISO 3166-2 subdivisions and other widely circulated lists; however this is not guaranteed as our geocoding results are based on a variety of signals and location data.
    /// * `administrative_area_level_2` indicates a second-order civil entity below the country level. Within the United States, these administrative levels are counties. Not all nations exhibit these administrative levels.
    /// * `administrative_area_level_3` indicates a third-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
    /// * `administrative_area_level_4` indicates a fourth-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
    /// * `administrative_area_level_5` indicates a fifth-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
    /// * `airport` indicates an airport.
    /// * `colloquial_area` indicates a commonly-used alternative name for the entity.
    /// * `country` indicates the national political entity, and is typically the highest order type returned by the Geocoder.
    /// * `intersection` indicates a major intersection, usually of two major roads.
    /// * `locality` indicates an incorporated city or town political entity.
    /// * `natural_feature` indicates a prominent natural feature.
    /// * `neighborhood` indicates a named neighborhood
    /// * `park` indicates a named park.
    /// * `plus_code` indicates an encoded location reference, derived from latitude and longitude. Plus codes can be used as a replacement for street addresses in places where they do not exist (where buildings are not numbered or streets are not named). See [https://plus.codes/](https://plus.codes/) for details.
    /// * `point_of_interest` indicates a named point of interest. Typically, these "POI"s are prominent local entities that don't easily fit in another category, such as "Empire State Building" or "Eiffel Tower".
    /// * `political` indicates a political entity. Usually, this type indicates a polygon of some civil administration.
    /// * `postal_code` indicates a postal code as used to address postal mail within the country.
    /// * `premise` indicates a named location, usually a building or collection of buildings with a common name
    /// * `route` indicates a named route (such as "US 101").
    /// * `street_address` indicates a precise street address.
    /// * `sublocality` indicates a first-order civil entity below a locality. For some locations may receive one of the additional types: `sublocality_level_1` to `sublocality_level_5`. Each sublocality level is a civil entity. Larger numbers indicate a smaller geographic area.
    /// * `subpremise` indicates a first-order entity below a named location, usually a singular building within a collection of buildings with a common name</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <param name="region">The region code, specified as a [ccTLD ("top-level domain")](https://en.wikipedia.org/wiki/List_of_Internet_top-level_domains#Country_code_top-level_domains) two-character value. Most ccTLD codes are identical to ISO 3166-1 codes, with some notable exceptions. For example, the United Kingdom's ccTLD is "uk" (.co.uk) while its ISO 3166-1 code is "gb" (technically for the entity of "The United Kingdom of Great Britain and Northern Ireland").</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<GeocodingResponse> GeocodeAsync(string address, IEnumerable<string> bounds, IEnumerable<string> components, string latlng, IEnumerable<Anonymous> location_type, string place_id, IEnumerable<Anonymous2> result_type, Language? language, Region? region)
    {
        return GeocodeAsync(address, bounds, components, latlng, location_type, place_id, result_type, language, region, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="address">The street address or plus code that you want to geocode. Specify addresses in accordance with the format used by the national postal service of the country concerned. Additional address elements such as business names and unit, suite or floor numbers should be avoided. Street address elements should be delimited by spaces (shown here as url-escaped to `%20`):
    /// 
    /// ```
    /// address=24%20Sussex%20Drive%20Ottawa%20ON
    /// ```
    /// 
    /// Format plus codes as shown here (plus signs are url-escaped to `%2B` and spaces are url-escaped to `%20`):
    /// - global code is a 4 character area code and 6 character or longer local code (`849VCWC8+R9` is `849VCWC8%2BR9`).
    /// - compound code is a 6 character or longer local code with an explicit location (`CWC8+R9 Mountain View, CA, USA` is `CWC8%2BR9%20Mountain%20View%20CA%20USA`).
    /// 
    /// &lt;div class="note"&gt;Note: At least one of `address` or `components` is required.&lt;/div&gt;</param>
    /// <param name="bounds">The bounding box of the viewport within which to bias geocode results more prominently. This parameter will only influence, not fully restrict, results from the geocoder.</param>
    /// <param name="components">A components filter with elements separated by a pipe (|). The components filter is also accepted as an optional parameter if an address is provided. Each element in the components filter consists of a `component:value` pair, and fully restricts the results from the geocoder.
    /// 
    /// The components that can be filtered include:
    /// 
    /// * `postal_code` matches `postal_code` and `postal_code_prefix`.
    /// * `country` matches a country name or a two letter ISO 3166-1 country code. The API follows the ISO standard for defining countries, and the filtering works best when using the corresponding ISO code of the country.
    ///   &lt;aside class="note"&gt;&lt;strong&gt;Note&lt;/strong&gt;: If you receive unexpected results with a country code, verify that you are using a code which includes the countries, dependent territories, and special areas of geographical interest you intend. You can find code information at Wikipedia: List of ISO 3166 country codes or the ISO Online Browsing Platform.&lt;/aside&gt;
    ///   
    /// The following components may be used to influence results, but will not be enforced:
    /// 
    /// * `route` matches the long or short name of a route.
    /// * `locality` matches against `locality` and `sublocality` types.
    /// * `administrative_area` matches all the `administrative_area` levels.
    ///   
    /// Notes about component filtering:
    /// 
    /// * Do not repeat these component filters in requests, or the API will return `INVALID_REQUEST`: 
    ///   * `country`
    ///   * `postal_code`
    ///   * `route`
    /// * If the request contains repeated component filters, the API evaluates those filters as an AND, not an OR.
    /// * Results are consistent with Google Maps, which occasionally yields unexpected `ZERO_RESULTS` responses. Using Place Autocomplete may provide better results in some use cases. To learn more, see [this FAQ](https://developers.devsite.corp.google.com/maps/documentation/geocoding/faq#trbl_component_filtering).
    /// * For each address component, either specify it in the address parameter or in a components filter, but not both. Specifying the same values in both may result in `ZERO_RESULTS`.
    /// 
    /// &lt;div class="note"&gt;Note: At least one of `address` or `components` is required.&lt;/div&gt;</param>
    /// <param name="latlng">The street address that you want to geocode, in the format used by the national postal service of the country concerned. Additional address elements such as business names and unit, suite or floor numbers should be avoided.</param>
    /// <param name="location_type">A filter of one or more location types, separated by a pipe (`|`). If the parameter contains multiple location types, the API returns all addresses that match any of the types. A note about processing: The `location_type` parameter does not restrict the search to the specified location type(s). Rather, the `location_type` acts as a post-search filter: the API fetches all results for the specified latlng, then discards those results that do not match the specified location type(s). The following values are supported:
    /// * `APPROXIMATE` returns only the addresses that are characterized as approximate.
    /// * `GEOMETRIC_CENTER` returns only geometric centers of a location such as a polyline (for example, a street) or polygon (region).
    /// * `RANGE_INTERPOLATED` returns only the addresses that reflect an approximation (usually on a road) interpolated between two precise points (such as intersections). An interpolated range generally indicates that rooftop geocodes are unavailable for a street address.
    /// * `ROOFTOP` returns only the addresses for which Google has location information accurate down to street address precision.</param>
    /// <param name="place_id">A textual identifier that uniquely identifies a place, returned from a [Place Search](https://developers.google.com/maps/documentation/places/web-service/search).
    /// For more information about place IDs, see the [place ID overview](https://developers.google.com/maps/documentation/places/web-service/place-id).</param>
    /// <param name="result_type">A filter of one or more address types, separated by a pipe (|). If the parameter contains multiple address types, the API returns all addresses that match any of the types. A note about processing: The `result_type` parameter does not restrict the search to the specified address type(s). Rather, the `result_type` acts as a post-search filter: the API fetches all results for the specified `latlng`, then discards those results that do not match the specified address type(s).The following values are supported:
    /// * `administrative_area_level_1` indicates a first-order civil entity below the country level. Within the United States, these administrative levels are states. Not all nations exhibit these administrative levels. In most cases, administrative_area_level_1   * `short` names will closely match ISO 3166-2 subdivisions and other widely circulated lists; however this is not guaranteed as our geocoding results are based on a variety of signals and location data.
    /// * `administrative_area_level_2` indicates a second-order civil entity below the country level. Within the United States, these administrative levels are counties. Not all nations exhibit these administrative levels.
    /// * `administrative_area_level_3` indicates a third-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
    /// * `administrative_area_level_4` indicates a fourth-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
    /// * `administrative_area_level_5` indicates a fifth-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
    /// * `airport` indicates an airport.
    /// * `colloquial_area` indicates a commonly-used alternative name for the entity.
    /// * `country` indicates the national political entity, and is typically the highest order type returned by the Geocoder.
    /// * `intersection` indicates a major intersection, usually of two major roads.
    /// * `locality` indicates an incorporated city or town political entity.
    /// * `natural_feature` indicates a prominent natural feature.
    /// * `neighborhood` indicates a named neighborhood
    /// * `park` indicates a named park.
    /// * `plus_code` indicates an encoded location reference, derived from latitude and longitude. Plus codes can be used as a replacement for street addresses in places where they do not exist (where buildings are not numbered or streets are not named). See [https://plus.codes/](https://plus.codes/) for details.
    /// * `point_of_interest` indicates a named point of interest. Typically, these "POI"s are prominent local entities that don't easily fit in another category, such as "Empire State Building" or "Eiffel Tower".
    /// * `political` indicates a political entity. Usually, this type indicates a polygon of some civil administration.
    /// * `postal_code` indicates a postal code as used to address postal mail within the country.
    /// * `premise` indicates a named location, usually a building or collection of buildings with a common name
    /// * `route` indicates a named route (such as "US 101").
    /// * `street_address` indicates a precise street address.
    /// * `sublocality` indicates a first-order civil entity below a locality. For some locations may receive one of the additional types: `sublocality_level_1` to `sublocality_level_5`. Each sublocality level is a civil entity. Larger numbers indicate a smaller geographic area.
    /// * `subpremise` indicates a first-order entity below a named location, usually a singular building within a collection of buildings with a common name</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <param name="region">The region code, specified as a [ccTLD ("top-level domain")](https://en.wikipedia.org/wiki/List_of_Internet_top-level_domains#Country_code_top-level_domains) two-character value. Most ccTLD codes are identical to ISO 3166-1 codes, with some notable exceptions. For example, the United Kingdom's ccTLD is "uk" (.co.uk) while its ISO 3166-1 code is "gb" (technically for the entity of "The United Kingdom of Great Britain and Northern Ireland").</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<GeocodingResponse> GeocodeAsync(string address, IEnumerable<string> bounds, IEnumerable<string> components, string latlng, IEnumerable<Anonymous> location_type, string place_id, IEnumerable<Anonymous2> result_type, Language? language, Region? region, CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/maps/api/geocode/json?");
        if (address != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("address") + "=").Append(Uri.EscapeDataString(ConvertToString(address, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (bounds != null)
        {
            foreach (var item_ in bounds) { urlBuilder_.Append(Uri.EscapeDataString("bounds") + "=").Append(Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append("&"); }
        }
        if (components != null)
        {
            foreach (var item_ in components) { urlBuilder_.Append(Uri.EscapeDataString("components") + "=").Append(Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append("&"); }
        }
        if (latlng != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("latlng") + "=").Append(Uri.EscapeDataString(ConvertToString(latlng, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (location_type != null)
        {
            foreach (var item_ in location_type) { urlBuilder_.Append(Uri.EscapeDataString("location_type") + "=").Append(Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append("&"); }
        }
        if (place_id != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("place_id") + "=").Append(Uri.EscapeDataString(ConvertToString(place_id, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (result_type != null)
        {
            foreach (var item_ in result_type) { urlBuilder_.Append(Uri.EscapeDataString("result_type") + "=").Append(Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append("&"); }
        }
        if (language != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("language") + "=").Append(Uri.EscapeDataString(ConvertToString(language, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (region != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("region") + "=").Append(Uri.EscapeDataString(ConvertToString(region, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Length--;

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<GeocodingResponse>(response_, headers_).ConfigureAwait(false);
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(GeocodingResponse);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <param name="location">A comma-separated latitude,longitude tuple, `location=39.6034810,-119.6822510`, representing the location to look up.</param>
    /// <param name="timestamp">The desired time as seconds since midnight, January 1, 1970 UTC. The Time Zone API uses the `timestamp` to determine whether or not Daylight Savings should be applied, based on the time zone of the `location`. 
    /// 
    /// Note that the API does not take historical time zones into account. That is, if you specify a past timestamp, the API does not take into account the possibility that the location was previously in a different time zone.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<TimeZoneResponse> TimezoneAsync(Language? language, string location, double timestamp)
    {
        return TimezoneAsync(language, location, timestamp, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <param name="location">A comma-separated latitude,longitude tuple, `location=39.6034810,-119.6822510`, representing the location to look up.</param>
    /// <param name="timestamp">The desired time as seconds since midnight, January 1, 1970 UTC. The Time Zone API uses the `timestamp` to determine whether or not Daylight Savings should be applied, based on the time zone of the `location`. 
    /// 
    /// Note that the API does not take historical time zones into account. That is, if you specify a past timestamp, the API does not take into account the possibility that the location was previously in a different time zone.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<TimeZoneResponse> TimezoneAsync(Language? language, string location, double timestamp, CancellationToken cancellationToken)
    {
        if (location == null)
            throw new ArgumentNullException("location");

        if (timestamp == null)
            throw new ArgumentNullException("timestamp");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/maps/api/timezone/json?");
        if (language != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("language") + "=").Append(Uri.EscapeDataString(ConvertToString(language, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Append(Uri.EscapeDataString("location") + "=").Append(Uri.EscapeDataString(ConvertToString(location, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        urlBuilder_.Append(Uri.EscapeDataString("timestamp") + "=").Append(Uri.EscapeDataString(ConvertToString(timestamp, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        urlBuilder_.Length--;

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<TimeZoneResponse>(response_, headers_).ConfigureAwait(false);
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(TimeZoneResponse);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    /// <param name="path">The path to be snapped. The path parameter accepts a list of latitude/longitude pairs. Latitude and longitude values should be separated by commas. Coordinates should be separated by the pipe character: "|". For example: `path=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796`.
    /// &lt;div class="note"&gt;Note: The snapping algorithm works best for points that are not too far apart. If you observe odd snapping behavior, try creating paths that have points closer together. To ensure the best snap-to-road quality, you should aim to provide paths on which consecutive pairs of points are within 300m of each other. This will also help in handling any isolated, long jumps between consecutive points caused by GPS signal loss, or noise.&lt;/div&gt;</param>
    /// <param name="interpolate">Whether to interpolate a path to include all points forming the full road-geometry. When true, additional interpolated points will also be returned, resulting in a path that smoothly follows the geometry of the road, even around corners and through tunnels. Interpolated paths will most likely contain more points than the original path. Defaults to `false`.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<SnapToRoadsResponse> SnapToRoadsAsync(IEnumerable<string> path, bool? interpolate)
    {
        return SnapToRoadsAsync(path, interpolate, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="path">The path to be snapped. The path parameter accepts a list of latitude/longitude pairs. Latitude and longitude values should be separated by commas. Coordinates should be separated by the pipe character: "|". For example: `path=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796`.
    /// &lt;div class="note"&gt;Note: The snapping algorithm works best for points that are not too far apart. If you observe odd snapping behavior, try creating paths that have points closer together. To ensure the best snap-to-road quality, you should aim to provide paths on which consecutive pairs of points are within 300m of each other. This will also help in handling any isolated, long jumps between consecutive points caused by GPS signal loss, or noise.&lt;/div&gt;</param>
    /// <param name="interpolate">Whether to interpolate a path to include all points forming the full road-geometry. When true, additional interpolated points will also be returned, resulting in a path that smoothly follows the geometry of the road, even around corners and through tunnels. Interpolated paths will most likely contain more points than the original path. Defaults to `false`.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<SnapToRoadsResponse> SnapToRoadsAsync(IEnumerable<string> path, bool? interpolate, CancellationToken cancellationToken)
    {
        if (path == null)
            throw new ArgumentNullException("path");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1/snapToRoads?");
        foreach (var item_ in path) { urlBuilder_.Append(Uri.EscapeDataString("path") + "=").Append(Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append("&"); }
        if (interpolate != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("interpolate") + "=").Append(Uri.EscapeDataString(ConvertToString(interpolate, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Length--;

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<SnapToRoadsResponse>(response_, headers_).ConfigureAwait(false);
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(SnapToRoadsResponse);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    /// <param name="points">The path to be snapped. The path parameter accepts a list of latitude/longitude pairs. Latitude and longitude values should be separated by commas. Coordinates should be separated by the pipe character: "|". For example: `path=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796`.
    /// &lt;div class="note"&gt;Note: The snapping algorithm works best for points that are not too far apart. If you observe odd snapping behavior, try creating paths that have points closer together. To ensure the best snap-to-road quality, you should aim to provide paths on which consecutive pairs of points are within 300m of each other. This will also help in handling any isolated, long jumps between consecutive points caused by GPS signal loss, or noise.&lt;/div&gt;</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<NearestRoadsResponse> NearestRoadsAsync(IEnumerable<string> points)
    {
        return NearestRoadsAsync(points, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="points">The path to be snapped. The path parameter accepts a list of latitude/longitude pairs. Latitude and longitude values should be separated by commas. Coordinates should be separated by the pipe character: "|". For example: `path=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796`.
    /// &lt;div class="note"&gt;Note: The snapping algorithm works best for points that are not too far apart. If you observe odd snapping behavior, try creating paths that have points closer together. To ensure the best snap-to-road quality, you should aim to provide paths on which consecutive pairs of points are within 300m of each other. This will also help in handling any isolated, long jumps between consecutive points caused by GPS signal loss, or noise.&lt;/div&gt;</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<NearestRoadsResponse> NearestRoadsAsync(IEnumerable<string> points, CancellationToken cancellationToken)
    {
        if (points == null)
            throw new ArgumentNullException("points");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/v1/nearestRoads?");
        foreach (var item_ in points) { urlBuilder_.Append(Uri.EscapeDataString("points") + "=").Append(Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append("&"); }
        urlBuilder_.Length--;

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<NearestRoadsResponse>(response_, headers_).ConfigureAwait(false);
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ == "400")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<NearestRoadsErrorResponse>(response_, headers_).ConfigureAwait(false);
                        throw new ApiException<NearestRoadsErrorResponse>("400 BAD REQUEST", (int)response_.StatusCode, objectResponse_.Text, headers_, objectResponse_.Object, null);
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(NearestRoadsResponse);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    /// <param name="arrival_time">Specifies the desired time of arrival for transit directions, in seconds since midnight, January 1, 1970 UTC. You can specify either `departure_time` or `arrival_time`, but not both. Note that `arrival_time` must be specified as an integer.</param>
    /// <param name="departure_time">Specifies the desired time of departure. You can specify the time as an integer in seconds since midnight, January 1, 1970 UTC. If a `departure_time` later than 9999-12-31T23:59:59.999999999Z is specified, the API will fall back the `departure_time` to 9999-12-31T23:59:59.999999999Z. Alternatively, you can specify a value of now, which sets the departure time to the current time (correct to the nearest second). The departure time may be specified in two cases:
    /// * For requests where the travel mode is transit: You can optionally specify one of `departure_time` or `arrival_time`. If neither time is specified, the `departure_time` defaults to now (that is, the departure time defaults to the current time).
    /// * For requests where the travel mode is driving: You can specify the `departure_time` to receive a route and trip duration (response field: duration_in_traffic) that take traffic conditions into account. The `departure_time` must be set to the current time or some time in the future. It cannot be in the past.
    /// 
    /// &lt;div class="note"&gt;Note: If departure time is not specified, choice of route and duration are based on road network and average time-independent traffic conditions. Results for a given request may vary over time due to changes in the road network, updated average traffic conditions, and the distributed nature of the service. Results may also vary between nearly-equivalent routes at any time or frequency.&lt;/div&gt;
    /// &lt;div class="note"&gt;Note: Distance Matrix requests specifying `departure_time` when `mode=driving` are limited to a maximum of 100 elements per request. The number of origins times the number of destinations defines the number of elements.&lt;/div&gt;</param>
    /// <param name="avoid">Distances may be calculated that adhere to certain restrictions. Restrictions are indicated by use of the avoid parameter, and an argument to that parameter indicating the restriction to avoid. The following restrictions are supported:
    /// 
    /// * `tolls` indicates that the calculated route should avoid toll roads/bridges.
    /// * `highways` indicates that the calculated route should avoid highways.
    /// * `ferries` indicates that the calculated route should avoid ferries.
    /// * `indoor` indicates that the calculated route should avoid indoor steps for walking and transit directions.
    /// 
    /// &lt;div class="note"&gt;Note: The addition of restrictions does not preclude routes that include the restricted feature; it biases the result to more favorable routes.&lt;/div&gt;</param>
    /// <param name="destinations">One or more locations to use as the finishing point for calculating travel distance and time. The options for the destinations parameter are the same as for the origins parameter.</param>
    /// <param name="origins">The starting point for calculating travel distance and time. You can supply one or more locations separated by the pipe character (|), in the form of a place ID, an address, or latitude/longitude coordinates:
    /// - **Place ID**: If you supply a place ID, you must prefix it with `place_id:`.
    /// - **Address**: If you pass an address, the service geocodes the string and converts it to a latitude/longitude coordinate to calculate distance. This coordinate may be different from that returned by the Geocoding API, for example a building entrance rather than its center.
    ///   &lt;div class="note"&gt;Note: using place IDs is preferred over using addresses or latitude/longitude coordinates. Using coordinates will always result in the point being snapped to the road nearest to those coordinates - which may not be an access point to the property, or even a road that will quickly or safely lead to the destination.&lt;/div&gt;
    /// - **Coordinates**: If you pass latitude/longitude coordinates, they they will snap to the nearest road. Passing a place ID is preferred. If you do pass coordinates, ensure that no space exists between the latitude and longitude values.
    /// - **Plus codes** must be formatted as a global code or a compound code. Format plus codes as shown here (plus signs are url-escaped to %2B and spaces are url-escaped to %20):
    ///   - **global code** is a 4 character area code and 6 character or longer local code (`849VCWC8+R9` is encoded to `849VCWC8%2BR9`).
    ///   - **compound code** is a 6 character or longer local code with an explicit location (`CWC8+R9 Mountain View, CA, USA` is encoded to `CWC8%2BR9%20Mountain%20View%20CA%20USA`).
    /// - **Encoded Polyline** Alternatively, you can supply an encoded set of coordinates using the [Encoded Polyline Algorithm](https://developers.google.com/maps/documentation/utilities/polylinealgorithm). This is particularly useful if you have a large number of origin points, because the URL is significantly shorter when using an encoded polyline.
    ///   - Encoded polylines must be prefixed with `enc:` and followed by a colon `:`. For example: `origins=enc:gfo}EtohhU:`
    ///   - You can also include multiple encoded polylines, separated by the pipe character `|`. For example: 
    ///     ```
    ///     origins=enc:wc~oAwquwMdlTxiKtqLyiK:|enc:c~vnAamswMvlTor@tjGi}L:|enc:udymA{~bxM:
    ///     ```</param>
    /// <param name="units">Specifies the unit system to use when displaying results.
    /// 
    /// &lt;div class="note"&gt;Note: this unit system setting only affects the text displayed within distance fields. The distance fields also contain values which are always expressed in meters.&lt;/div&gt;</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <param name="mode">For the calculation of distances and directions, you may specify the transportation mode to use. By default, `DRIVING` mode is used. By default, directions are calculated as driving directions. The following travel modes are supported:
    /// 
    /// * `driving` (default) indicates standard driving directions or distance using the road network.
    /// * `walking` requests walking directions or distance via pedestrian paths &amp; sidewalks (where available).
    /// * `bicycling` requests bicycling directions or distance via bicycle paths &amp; preferred streets (where available).
    /// * `transit` requests directions or distance via public transit routes (where available). If you set the mode to transit, you can optionally specify either a `departure_time` or an `arrival_time`. If neither time is specified, the `departure_time` defaults to now (that is, the departure time defaults to the current time). You can also optionally include a `transit_mode` and/or a `transit_routing_preference`.
    /// 
    /// &lt;div class="note"&gt;Note: Both walking and bicycling directions may sometimes not include clear pedestrian or bicycling paths, so these directions will return warnings in the returned result which you must display to the user.&lt;/div&gt;</param>
    /// <param name="region">The region code, specified as a [ccTLD ("top-level domain")](https://en.wikipedia.org/wiki/List_of_Internet_top-level_domains#Country_code_top-level_domains) two-character value. Most ccTLD codes are identical to ISO 3166-1 codes, with some notable exceptions. For example, the United Kingdom's ccTLD is "uk" (.co.uk) while its ISO 3166-1 code is "gb" (technically for the entity of "The United Kingdom of Great Britain and Northern Ireland").</param>
    /// <param name="traffic_model">Specifies the assumptions to use when calculating time in traffic. This setting affects the value returned in the duration_in_traffic field in the response, which contains the predicted time in traffic based on historical averages. The `traffic_model` parameter may only be specified for driving directions where the request includes a `departure_time`. The available values for this parameter are:
    /// * `best_guess` (default) indicates that the returned duration_in_traffic should be the best estimate of travel time given what is known about both historical traffic conditions and live traffic. Live traffic becomes more important the closer the `departure_time` is to now.
    /// * `pessimistic` indicates that the returned duration_in_traffic should be longer than the actual travel time on most days, though occasional days with particularly bad traffic conditions may exceed this value.
    /// * `optimistic` indicates that the returned duration_in_traffic should be shorter than the actual travel time on most days, though occasional days with particularly good traffic conditions may be faster than this value.
    /// The default value of `best_guess` will give the most useful predictions for the vast majority of use cases. It is possible the `best_guess` travel time prediction may be shorter than `optimistic`, or alternatively, longer than `pessimistic`, due to the way the `best_guess` prediction model integrates live traffic information.</param>
    /// <param name="transit_mode">Specifies one or more preferred modes of transit. This parameter may only be specified for transit directions. The parameter supports the following arguments:
    /// * `bus` indicates that the calculated route should prefer travel by bus.
    /// * `subway` indicates that the calculated route should prefer travel by subway.
    /// * `train` indicates that the calculated route should prefer travel by train.
    /// * `tram` indicates that the calculated route should prefer travel by tram and light rail.
    /// * `rail` indicates that the calculated route should prefer travel by train, tram, light rail, and subway. This is equivalent to `transit_mode=train|tram|subway`.</param>
    /// <param name="transit_routing_preference">Specifies preferences for transit routes. Using this parameter, you can bias the options returned, rather than accepting the default best route chosen by the API. This parameter may only be specified for transit directions. The parameter supports the following arguments:
    /// * `less_walking` indicates that the calculated route should prefer limited amounts of walking.
    /// * `fewer_transfers` indicates that the calculated route should prefer a limited number of transfers.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<DistanceMatrixResponse> DistanceMatrixAsync(double? arrival_time, double? departure_time, string avoid, IEnumerable<string> destinations, IEnumerable<string> origins, Units2? units, Language? language, Mode? mode, Region? region, Traffic_model? traffic_model, string transit_mode, Transit_routing_preference? transit_routing_preference)
    {
        return DistanceMatrixAsync(arrival_time, departure_time, avoid, destinations, origins, units, language, mode, region, traffic_model, transit_mode, transit_routing_preference, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="arrival_time">Specifies the desired time of arrival for transit directions, in seconds since midnight, January 1, 1970 UTC. You can specify either `departure_time` or `arrival_time`, but not both. Note that `arrival_time` must be specified as an integer.</param>
    /// <param name="departure_time">Specifies the desired time of departure. You can specify the time as an integer in seconds since midnight, January 1, 1970 UTC. If a `departure_time` later than 9999-12-31T23:59:59.999999999Z is specified, the API will fall back the `departure_time` to 9999-12-31T23:59:59.999999999Z. Alternatively, you can specify a value of now, which sets the departure time to the current time (correct to the nearest second). The departure time may be specified in two cases:
    /// * For requests where the travel mode is transit: You can optionally specify one of `departure_time` or `arrival_time`. If neither time is specified, the `departure_time` defaults to now (that is, the departure time defaults to the current time).
    /// * For requests where the travel mode is driving: You can specify the `departure_time` to receive a route and trip duration (response field: duration_in_traffic) that take traffic conditions into account. The `departure_time` must be set to the current time or some time in the future. It cannot be in the past.
    /// 
    /// &lt;div class="note"&gt;Note: If departure time is not specified, choice of route and duration are based on road network and average time-independent traffic conditions. Results for a given request may vary over time due to changes in the road network, updated average traffic conditions, and the distributed nature of the service. Results may also vary between nearly-equivalent routes at any time or frequency.&lt;/div&gt;
    /// &lt;div class="note"&gt;Note: Distance Matrix requests specifying `departure_time` when `mode=driving` are limited to a maximum of 100 elements per request. The number of origins times the number of destinations defines the number of elements.&lt;/div&gt;</param>
    /// <param name="avoid">Distances may be calculated that adhere to certain restrictions. Restrictions are indicated by use of the avoid parameter, and an argument to that parameter indicating the restriction to avoid. The following restrictions are supported:
    /// 
    /// * `tolls` indicates that the calculated route should avoid toll roads/bridges.
    /// * `highways` indicates that the calculated route should avoid highways.
    /// * `ferries` indicates that the calculated route should avoid ferries.
    /// * `indoor` indicates that the calculated route should avoid indoor steps for walking and transit directions.
    /// 
    /// &lt;div class="note"&gt;Note: The addition of restrictions does not preclude routes that include the restricted feature; it biases the result to more favorable routes.&lt;/div&gt;</param>
    /// <param name="destinations">One or more locations to use as the finishing point for calculating travel distance and time. The options for the destinations parameter are the same as for the origins parameter.</param>
    /// <param name="origins">The starting point for calculating travel distance and time. You can supply one or more locations separated by the pipe character (|), in the form of a place ID, an address, or latitude/longitude coordinates:
    /// - **Place ID**: If you supply a place ID, you must prefix it with `place_id:`.
    /// - **Address**: If you pass an address, the service geocodes the string and converts it to a latitude/longitude coordinate to calculate distance. This coordinate may be different from that returned by the Geocoding API, for example a building entrance rather than its center.
    ///   &lt;div class="note"&gt;Note: using place IDs is preferred over using addresses or latitude/longitude coordinates. Using coordinates will always result in the point being snapped to the road nearest to those coordinates - which may not be an access point to the property, or even a road that will quickly or safely lead to the destination.&lt;/div&gt;
    /// - **Coordinates**: If you pass latitude/longitude coordinates, they they will snap to the nearest road. Passing a place ID is preferred. If you do pass coordinates, ensure that no space exists between the latitude and longitude values.
    /// - **Plus codes** must be formatted as a global code or a compound code. Format plus codes as shown here (plus signs are url-escaped to %2B and spaces are url-escaped to %20):
    ///   - **global code** is a 4 character area code and 6 character or longer local code (`849VCWC8+R9` is encoded to `849VCWC8%2BR9`).
    ///   - **compound code** is a 6 character or longer local code with an explicit location (`CWC8+R9 Mountain View, CA, USA` is encoded to `CWC8%2BR9%20Mountain%20View%20CA%20USA`).
    /// - **Encoded Polyline** Alternatively, you can supply an encoded set of coordinates using the [Encoded Polyline Algorithm](https://developers.google.com/maps/documentation/utilities/polylinealgorithm). This is particularly useful if you have a large number of origin points, because the URL is significantly shorter when using an encoded polyline.
    ///   - Encoded polylines must be prefixed with `enc:` and followed by a colon `:`. For example: `origins=enc:gfo}EtohhU:`
    ///   - You can also include multiple encoded polylines, separated by the pipe character `|`. For example: 
    ///     ```
    ///     origins=enc:wc~oAwquwMdlTxiKtqLyiK:|enc:c~vnAamswMvlTor@tjGi}L:|enc:udymA{~bxM:
    ///     ```</param>
    /// <param name="units">Specifies the unit system to use when displaying results.
    /// 
    /// &lt;div class="note"&gt;Note: this unit system setting only affects the text displayed within distance fields. The distance fields also contain values which are always expressed in meters.&lt;/div&gt;</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <param name="mode">For the calculation of distances and directions, you may specify the transportation mode to use. By default, `DRIVING` mode is used. By default, directions are calculated as driving directions. The following travel modes are supported:
    /// 
    /// * `driving` (default) indicates standard driving directions or distance using the road network.
    /// * `walking` requests walking directions or distance via pedestrian paths &amp; sidewalks (where available).
    /// * `bicycling` requests bicycling directions or distance via bicycle paths &amp; preferred streets (where available).
    /// * `transit` requests directions or distance via public transit routes (where available). If you set the mode to transit, you can optionally specify either a `departure_time` or an `arrival_time`. If neither time is specified, the `departure_time` defaults to now (that is, the departure time defaults to the current time). You can also optionally include a `transit_mode` and/or a `transit_routing_preference`.
    /// 
    /// &lt;div class="note"&gt;Note: Both walking and bicycling directions may sometimes not include clear pedestrian or bicycling paths, so these directions will return warnings in the returned result which you must display to the user.&lt;/div&gt;</param>
    /// <param name="region">The region code, specified as a [ccTLD ("top-level domain")](https://en.wikipedia.org/wiki/List_of_Internet_top-level_domains#Country_code_top-level_domains) two-character value. Most ccTLD codes are identical to ISO 3166-1 codes, with some notable exceptions. For example, the United Kingdom's ccTLD is "uk" (.co.uk) while its ISO 3166-1 code is "gb" (technically for the entity of "The United Kingdom of Great Britain and Northern Ireland").</param>
    /// <param name="traffic_model">Specifies the assumptions to use when calculating time in traffic. This setting affects the value returned in the duration_in_traffic field in the response, which contains the predicted time in traffic based on historical averages. The `traffic_model` parameter may only be specified for driving directions where the request includes a `departure_time`. The available values for this parameter are:
    /// * `best_guess` (default) indicates that the returned duration_in_traffic should be the best estimate of travel time given what is known about both historical traffic conditions and live traffic. Live traffic becomes more important the closer the `departure_time` is to now.
    /// * `pessimistic` indicates that the returned duration_in_traffic should be longer than the actual travel time on most days, though occasional days with particularly bad traffic conditions may exceed this value.
    /// * `optimistic` indicates that the returned duration_in_traffic should be shorter than the actual travel time on most days, though occasional days with particularly good traffic conditions may be faster than this value.
    /// The default value of `best_guess` will give the most useful predictions for the vast majority of use cases. It is possible the `best_guess` travel time prediction may be shorter than `optimistic`, or alternatively, longer than `pessimistic`, due to the way the `best_guess` prediction model integrates live traffic information.</param>
    /// <param name="transit_mode">Specifies one or more preferred modes of transit. This parameter may only be specified for transit directions. The parameter supports the following arguments:
    /// * `bus` indicates that the calculated route should prefer travel by bus.
    /// * `subway` indicates that the calculated route should prefer travel by subway.
    /// * `train` indicates that the calculated route should prefer travel by train.
    /// * `tram` indicates that the calculated route should prefer travel by tram and light rail.
    /// * `rail` indicates that the calculated route should prefer travel by train, tram, light rail, and subway. This is equivalent to `transit_mode=train|tram|subway`.</param>
    /// <param name="transit_routing_preference">Specifies preferences for transit routes. Using this parameter, you can bias the options returned, rather than accepting the default best route chosen by the API. This parameter may only be specified for transit directions. The parameter supports the following arguments:
    /// * `less_walking` indicates that the calculated route should prefer limited amounts of walking.
    /// * `fewer_transfers` indicates that the calculated route should prefer a limited number of transfers.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<DistanceMatrixResponse> DistanceMatrixAsync(double? arrival_time, double? departure_time, string avoid, IEnumerable<string> destinations, IEnumerable<string> origins, Units2? units, Language? language, Mode? mode, Region? region, Traffic_model? traffic_model, string transit_mode, Transit_routing_preference? transit_routing_preference, CancellationToken cancellationToken)
    {
        if (destinations == null)
            throw new ArgumentNullException("destinations");

        if (origins == null)
            throw new ArgumentNullException("origins");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/maps/api/distanceMatrix/json?");
        if (arrival_time != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("arrival_time") + "=").Append(Uri.EscapeDataString(ConvertToString(arrival_time, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (departure_time != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("departure_time") + "=").Append(Uri.EscapeDataString(ConvertToString(departure_time, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (avoid != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("avoid") + "=").Append(Uri.EscapeDataString(ConvertToString(avoid, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        foreach (var item_ in destinations) { urlBuilder_.Append(Uri.EscapeDataString("destinations") + "=").Append(Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append("&"); }
        foreach (var item_ in origins) { urlBuilder_.Append(Uri.EscapeDataString("origins") + "=").Append(Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append("&"); }
        if (units != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("units") + "=").Append(Uri.EscapeDataString(ConvertToString(units, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (language != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("language") + "=").Append(Uri.EscapeDataString(ConvertToString(language, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (mode != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("mode") + "=").Append(Uri.EscapeDataString(ConvertToString(mode, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (region != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("region") + "=").Append(Uri.EscapeDataString(ConvertToString(region, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (traffic_model != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("traffic_model") + "=").Append(Uri.EscapeDataString(ConvertToString(traffic_model, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (transit_mode != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("transit_mode") + "=").Append(Uri.EscapeDataString(ConvertToString(transit_mode, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (transit_routing_preference != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("transit_routing_preference") + "=").Append(Uri.EscapeDataString(ConvertToString(transit_routing_preference, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Length--;

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<DistanceMatrixResponse>(response_, headers_).ConfigureAwait(false);
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(DistanceMatrixResponse);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    /// <param name="place_id">A textual identifier that uniquely identifies a place, returned from a [Place Search](https://developers.google.com/maps/documentation/places/web-service/search).
    /// For more information about place IDs, see the [place ID overview](https://developers.google.com/maps/documentation/places/web-service/place-id).</param>
    /// <param name="fields">&lt;div class="caution"&gt; Caution: Place Search requests and Place Details requests do not return the same fields. Place Search requests return a subset of the fields that are returned by Place Details requests. If the field you want is not returned by Place Search, you can use Place Search to get a &lt;code&gt;place_id&lt;/code&gt;, then use that Place ID to make a Place Details request. For more information on the fields that are unavailable in a Place Search request, see &lt;a href="https://developers.google.com/maps/documentation/places/web-service/place-data-fields#places-api-fields-support"&gt;Places API fields support&lt;/a&gt;.&lt;/div&gt;
    /// 
    /// Use the fields parameter to specify a comma-separated list of place data types to return. For example: `fields=formatted_address,name,geometry`. Use a forward slash when specifying compound values. For example: `opening_hours/open_now`.
    /// 
    /// Fields are divided into three billing categories: Basic, Contact, and Atmosphere. Basic fields are billed at base rate, and incur no additional charges. Contact and Atmosphere fields are billed at a higher rate. See the [pricing sheet](https://cloud.google.com/maps-platform/pricing/sheet/) for more information. Attributions, `html_attributions`, are always returned with every call, regardless of whether the field has been requested.
    /// 
    /// **Basic**
    /// 
    /// The Basic category includes the following fields: `address_component`, `adr_address`, `business_status`, `formatted_address`, `geometry`, `icon`, `icon_mask_base_uri`, `icon_background_color`, `name`, `permanently_closed` ([deprecated](https://developers.google.com/maps/deprecations)), `photo`, `place_id`, `plus_code`, `type`, `url`, `utc_offset`, `vicinity`.
    /// 
    /// **Contact**
    /// 
    /// The Contact category includes the following fields: `formatted_phone_number`, `international_phone_number`, `opening_hours`, `website`
    /// 
    /// **Atmosphere**
    /// 
    /// The Atmosphere category includes the following fields: `price_level`, `rating`, `review`, `user_ratings_total`.</param>
    /// <param name="sessiontoken">A random string which identifies an autocomplete [session](https://developers.google.com/maps/documentation/places/web-service/details#session_tokens) for billing purposes.
    /// 
    /// The session begins when the user starts typing a query, and concludes when they select a place and a call to Place Details is made. Each session can have multiple queries, followed by one place selection. The API key(s) used for each request within a session must belong to the same Google Cloud Console project. Once a session has concluded, the token is no longer valid; your app must generate a fresh token for each session. If the `sessiontoken` parameter is omitted, or if you reuse a session token, the session is charged as if no session token was provided (each request is billed separately).
    /// 
    /// We recommend the following guidelines:
    /// 
    /// - Use session tokens for all autocomplete sessions.
    /// - Generate a fresh token for each session. Using a version 4 UUID is recommended.
    /// - Ensure that the API key(s) used for all Place Autocomplete and Place Details requests within a session belong to the same Cloud Console project.
    /// - Be sure to pass a unique session token for each new session. Using the same token for more than one session will result in each request being billed individually.</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <param name="region">The region code, specified as a [ccTLD ("top-level domain")](https://en.wikipedia.org/wiki/List_of_Internet_top-level_domains#Country_code_top-level_domains) two-character value. Most ccTLD codes are identical to ISO 3166-1 codes, with some notable exceptions. For example, the United Kingdom's ccTLD is "uk" (.co.uk) while its ISO 3166-1 code is "gb" (technically for the entity of "The United Kingdom of Great Britain and Northern Ireland").</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<PlacesDetailsResponse> PlaceDetailsAsync(string place_id, IEnumerable<string> fields, string sessiontoken, Language? language, Region? region)
    {
        return PlaceDetailsAsync(place_id, fields, sessiontoken, language, region, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="place_id">A textual identifier that uniquely identifies a place, returned from a [Place Search](https://developers.google.com/maps/documentation/places/web-service/search).
    /// For more information about place IDs, see the [place ID overview](https://developers.google.com/maps/documentation/places/web-service/place-id).</param>
    /// <param name="fields">&lt;div class="caution"&gt; Caution: Place Search requests and Place Details requests do not return the same fields. Place Search requests return a subset of the fields that are returned by Place Details requests. If the field you want is not returned by Place Search, you can use Place Search to get a &lt;code&gt;place_id&lt;/code&gt;, then use that Place ID to make a Place Details request. For more information on the fields that are unavailable in a Place Search request, see &lt;a href="https://developers.google.com/maps/documentation/places/web-service/place-data-fields#places-api-fields-support"&gt;Places API fields support&lt;/a&gt;.&lt;/div&gt;
    /// 
    /// Use the fields parameter to specify a comma-separated list of place data types to return. For example: `fields=formatted_address,name,geometry`. Use a forward slash when specifying compound values. For example: `opening_hours/open_now`.
    /// 
    /// Fields are divided into three billing categories: Basic, Contact, and Atmosphere. Basic fields are billed at base rate, and incur no additional charges. Contact and Atmosphere fields are billed at a higher rate. See the [pricing sheet](https://cloud.google.com/maps-platform/pricing/sheet/) for more information. Attributions, `html_attributions`, are always returned with every call, regardless of whether the field has been requested.
    /// 
    /// **Basic**
    /// 
    /// The Basic category includes the following fields: `address_component`, `adr_address`, `business_status`, `formatted_address`, `geometry`, `icon`, `icon_mask_base_uri`, `icon_background_color`, `name`, `permanently_closed` ([deprecated](https://developers.google.com/maps/deprecations)), `photo`, `place_id`, `plus_code`, `type`, `url`, `utc_offset`, `vicinity`.
    /// 
    /// **Contact**
    /// 
    /// The Contact category includes the following fields: `formatted_phone_number`, `international_phone_number`, `opening_hours`, `website`
    /// 
    /// **Atmosphere**
    /// 
    /// The Atmosphere category includes the following fields: `price_level`, `rating`, `review`, `user_ratings_total`.</param>
    /// <param name="sessiontoken">A random string which identifies an autocomplete [session](https://developers.google.com/maps/documentation/places/web-service/details#session_tokens) for billing purposes.
    /// 
    /// The session begins when the user starts typing a query, and concludes when they select a place and a call to Place Details is made. Each session can have multiple queries, followed by one place selection. The API key(s) used for each request within a session must belong to the same Google Cloud Console project. Once a session has concluded, the token is no longer valid; your app must generate a fresh token for each session. If the `sessiontoken` parameter is omitted, or if you reuse a session token, the session is charged as if no session token was provided (each request is billed separately).
    /// 
    /// We recommend the following guidelines:
    /// 
    /// - Use session tokens for all autocomplete sessions.
    /// - Generate a fresh token for each session. Using a version 4 UUID is recommended.
    /// - Ensure that the API key(s) used for all Place Autocomplete and Place Details requests within a session belong to the same Cloud Console project.
    /// - Be sure to pass a unique session token for each new session. Using the same token for more than one session will result in each request being billed individually.</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <param name="region">The region code, specified as a [ccTLD ("top-level domain")](https://en.wikipedia.org/wiki/List_of_Internet_top-level_domains#Country_code_top-level_domains) two-character value. Most ccTLD codes are identical to ISO 3166-1 codes, with some notable exceptions. For example, the United Kingdom's ccTLD is "uk" (.co.uk) while its ISO 3166-1 code is "gb" (technically for the entity of "The United Kingdom of Great Britain and Northern Ireland").</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<PlacesDetailsResponse> PlaceDetailsAsync(string place_id, IEnumerable<string> fields, string sessiontoken, Language? language, Region? region, CancellationToken cancellationToken)
    {
        if (place_id == null)
            throw new ArgumentNullException("place_id");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/maps/api/place/details/json?");
        urlBuilder_.Append(Uri.EscapeDataString("place_id") + "=").Append(Uri.EscapeDataString(ConvertToString(place_id, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        if (fields != null)
        {
            foreach (var item_ in fields) { urlBuilder_.Append(Uri.EscapeDataString("fields") + "=").Append(Uri.EscapeDataString(ConvertToString(item_, System.Globalization.CultureInfo.InvariantCulture))).Append("&"); }
        }
        if (sessiontoken != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("sessiontoken") + "=").Append(Uri.EscapeDataString(ConvertToString(sessiontoken, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (language != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("language") + "=").Append(Uri.EscapeDataString(ConvertToString(language, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (region != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("region") + "=").Append(Uri.EscapeDataString(ConvertToString(region, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Length--;

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlacesDetailsResponse>(response_, headers_).ConfigureAwait(false);
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(PlacesDetailsResponse);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    /// <param name="photo_reference">A string identifier that uniquely identifies a photo. Photo references are returned from either a Place Search or Place Details request.</param>
    /// <param name="maxheight">Specifies the maximum desired height, in pixels, of the image. If the image is smaller than the values specified, the original image will be returned. If the image is larger in either dimension, it will be scaled to match the smaller of the two dimensions, restricted to its original aspect ratio. Both the `maxheight` and `maxwidth` properties accept an integer between `1` and `1600`.</param>
    /// <param name="maxwidth">Specifies the maximum desired width, in pixels, of the image. If the image is smaller than the values specified, the original image will be returned. If the image is larger in either dimension, it will be scaled to match the smaller of the two dimensions, restricted to its original aspect ratio. Both the `maxheight` and `maxwidth` properties accept an integer between `1` and `1600`.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<FileResponse> PlacePhotoAsync(string photo_reference, double? maxheight, double? maxwidth)
    {
        return PlacePhotoAsync(photo_reference, maxheight, maxwidth, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="photo_reference">A string identifier that uniquely identifies a photo. Photo references are returned from either a Place Search or Place Details request.</param>
    /// <param name="maxheight">Specifies the maximum desired height, in pixels, of the image. If the image is smaller than the values specified, the original image will be returned. If the image is larger in either dimension, it will be scaled to match the smaller of the two dimensions, restricted to its original aspect ratio. Both the `maxheight` and `maxwidth` properties accept an integer between `1` and `1600`.</param>
    /// <param name="maxwidth">Specifies the maximum desired width, in pixels, of the image. If the image is smaller than the values specified, the original image will be returned. If the image is larger in either dimension, it will be scaled to match the smaller of the two dimensions, restricted to its original aspect ratio. Both the `maxheight` and `maxwidth` properties accept an integer between `1` and `1600`.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<FileResponse> PlacePhotoAsync(string photo_reference, double? maxheight, double? maxwidth, CancellationToken cancellationToken)
    {
        if (photo_reference == null)
            throw new ArgumentNullException("photo_reference");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/maps/api/place/photo?");
        urlBuilder_.Append(Uri.EscapeDataString("photo_reference") + "=").Append(Uri.EscapeDataString(ConvertToString(photo_reference, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        if (maxheight != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("maxheight") + "=").Append(Uri.EscapeDataString(ConvertToString(maxheight, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (maxwidth != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("maxwidth") + "=").Append(Uri.EscapeDataString(ConvertToString(maxwidth, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Length--;

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("image/*"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200" || status_ == "206")
                    {
                        var responseStream_ = response_.Content == null ? Stream.Null : await response_.Content.ReadAsStreamAsync().ConfigureAwait(false);
                        var fileResponse_ = new FileResponse((int)response_.StatusCode, headers_, responseStream_, null, response_);
                        client_ = null; response_ = null; // response and client are disposed by FileResponse
                        return fileResponse_;
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(FileResponse);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    /// <param name="input">The text string on which to search. The Place Autocomplete service will return candidate matches based on this string and order results based on their perceived relevance.</param>
    /// <param name="offset">The position, in the input term, of the last character that the service uses to match predictions. For example, if the input is `Google` and the offset is 3, the service will match on `Goo`. The string determined by the offset is matched against the first word in the input term only. For example, if the input term is `Google abc` and the offset is 3, the service will attempt to match against `Goo abc`. If no offset is supplied, the service will use the whole term. The offset should generally be set to the position of the text caret.</param>
    /// <param name="location">The point around which to retrieve place information. This must be specified as `latitude,longitude`. 
    /// 
    /// &lt;div class="note"&gt;The &lt;code&gt;location&lt;/code&gt; parameter may be overriden if the &lt;code&gt;query&lt;/code&gt; contains an explicit location such as &lt;code&gt;Market in Barcelona&lt;/code&gt;. Using quotes around the query may also influence the weight given to the &lt;code&gt;location&lt;/code&gt; and &lt;code&gt;radius&lt;/code&gt;.&lt;/div&gt;</param>
    /// <param name="radius">Defines the distance (in meters) within which to return place results. You may bias results to a specified circle by passing a `location` and a `radius` parameter. Doing so instructs the Places service to _prefer_ showing results within that circle; results outside of the defined area may still be displayed.
    /// 
    /// The radius will automatically be clamped to a maximum value depending on the type of search and other parameters.
    /// 
    /// * Autocomplete: 50,000 meters
    /// * Nearby Search: 
    ///   * with `keyword` or `name`: 50,000 meters
    ///   * without `keyword` or `name`
    ///     * `rankby=prominence` (default): 50,000 meters
    ///     * `rankby=distance`: A few kilometers depending on density of area. `radius` will not be accepted, and will result in an INVALID_REQUEST.
    /// * Query Autocomplete: 50,000 meters
    /// * Text Search: 50,000 meters</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<PlacesQueryAutocompleteResponse> QueryAutocompleteAsync(string input, double? offset, string location, double? radius, Language? language)
    {
        return QueryAutocompleteAsync(input, offset, location, radius, language, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="input">The text string on which to search. The Place Autocomplete service will return candidate matches based on this string and order results based on their perceived relevance.</param>
    /// <param name="offset">The position, in the input term, of the last character that the service uses to match predictions. For example, if the input is `Google` and the offset is 3, the service will match on `Goo`. The string determined by the offset is matched against the first word in the input term only. For example, if the input term is `Google abc` and the offset is 3, the service will attempt to match against `Goo abc`. If no offset is supplied, the service will use the whole term. The offset should generally be set to the position of the text caret.</param>
    /// <param name="location">The point around which to retrieve place information. This must be specified as `latitude,longitude`. 
    /// 
    /// &lt;div class="note"&gt;The &lt;code&gt;location&lt;/code&gt; parameter may be overriden if the &lt;code&gt;query&lt;/code&gt; contains an explicit location such as &lt;code&gt;Market in Barcelona&lt;/code&gt;. Using quotes around the query may also influence the weight given to the &lt;code&gt;location&lt;/code&gt; and &lt;code&gt;radius&lt;/code&gt;.&lt;/div&gt;</param>
    /// <param name="radius">Defines the distance (in meters) within which to return place results. You may bias results to a specified circle by passing a `location` and a `radius` parameter. Doing so instructs the Places service to _prefer_ showing results within that circle; results outside of the defined area may still be displayed.
    /// 
    /// The radius will automatically be clamped to a maximum value depending on the type of search and other parameters.
    /// 
    /// * Autocomplete: 50,000 meters
    /// * Nearby Search: 
    ///   * with `keyword` or `name`: 50,000 meters
    ///   * without `keyword` or `name`
    ///     * `rankby=prominence` (default): 50,000 meters
    ///     * `rankby=distance`: A few kilometers depending on density of area. `radius` will not be accepted, and will result in an INVALID_REQUEST.
    /// * Query Autocomplete: 50,000 meters
    /// * Text Search: 50,000 meters</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<PlacesQueryAutocompleteResponse> QueryAutocompleteAsync(string input, double? offset, string location, double? radius, Language? language, CancellationToken cancellationToken)
    {
        if (input == null)
            throw new ArgumentNullException("input");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/maps/api/place/queryautocomplete/json?");
        urlBuilder_.Append(Uri.EscapeDataString("input") + "=").Append(Uri.EscapeDataString(ConvertToString(input, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        if (offset != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("offset") + "=").Append(Uri.EscapeDataString(ConvertToString(offset, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (location != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("location") + "=").Append(Uri.EscapeDataString(ConvertToString(location, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (radius != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("radius") + "=").Append(Uri.EscapeDataString(ConvertToString(radius, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (language != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("language") + "=").Append(Uri.EscapeDataString(ConvertToString(language, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Length--;

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlacesQueryAutocompleteResponse>(response_, headers_).ConfigureAwait(false);
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(PlacesQueryAutocompleteResponse);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    /// <param name="input">The text string on which to search. The Place Autocomplete service will return candidate matches based on this string and order results based on their perceived relevance.</param>
    /// <param name="sessiontoken">A random string which identifies an autocomplete [session](https://developers.google.com/maps/documentation/places/web-service/details#session_tokens) for billing purposes.
    /// 
    /// The session begins when the user starts typing a query, and concludes when they select a place and a call to Place Details is made. Each session can have multiple queries, followed by one place selection. The API key(s) used for each request within a session must belong to the same Google Cloud Console project. Once a session has concluded, the token is no longer valid; your app must generate a fresh token for each session. If the `sessiontoken` parameter is omitted, or if you reuse a session token, the session is charged as if no session token was provided (each request is billed separately).
    /// 
    /// We recommend the following guidelines:
    /// 
    /// - Use session tokens for all autocomplete sessions.
    /// - Generate a fresh token for each session. Using a version 4 UUID is recommended.
    /// - Ensure that the API key(s) used for all Place Autocomplete and Place Details requests within a session belong to the same Cloud Console project.
    /// - Be sure to pass a unique session token for each new session. Using the same token for more than one session will result in each request being billed individually.</param>
    /// <param name="components">A grouping of places to which you would like to restrict your results. Currently, you can use components to filter by up to 5 countries. Countries must be passed as a two character, ISO 3166-1 Alpha-2 compatible country code. For example: `components=country:fr` would restrict your results to places within France. Multiple countries must be passed as multiple `country:XX` filters, with the pipe character `|` as a separator. For example: `components=country:us|country:pr|country:vi|country:gu|country:mp` would restrict your results to places within the United States and its unincorporated organized territories.
    /// &lt;div class="note"&gt;&lt;strong&gt;Note:&lt;/strong&gt; If you receive unexpected results with a country code, verify that you are using a code which includes the countries, dependent territories, and special areas of geographical interest you intend.  You can find code information at &lt;a href="https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes" target="blank" class="external"&gt;Wikipedia: List of ISO 3166 country codes&lt;/a&gt; or the &lt;a href="https://www.iso.org/obp/ui/#search" target="blank" class="external"&gt;ISO Online Browsing Platform&lt;/a&gt;.&lt;/div&gt;</param>
    /// <param name="strictbounds">Returns only those places that are strictly within the region defined by `location` and `radius`. This is a restriction, rather than a bias, meaning that results outside this region will not be returned even if they match the user input.</param>
    /// <param name="offset">The position, in the input term, of the last character that the service uses to match predictions. For example, if the input is `Google` and the offset is 3, the service will match on `Goo`. The string determined by the offset is matched against the first word in the input term only. For example, if the input term is `Google abc` and the offset is 3, the service will attempt to match against `Goo abc`. If no offset is supplied, the service will use the whole term. The offset should generally be set to the position of the text caret.</param>
    /// <param name="origin">The origin point from which to calculate straight-line distance to the destination (returned as `distance_meters`). If this value is omitted, straight-line distance will not be returned. Must be specified as `latitude,longitude`.</param>
    /// <param name="location">The point around which to retrieve place information. This must be specified as `latitude,longitude`. 
    /// 
    /// &lt;div class="note"&gt;When using the Text Search API, the `location` parameter may be overriden if the `query` contains an explicit location such as `Market in Barcelona`.&lt;/div&gt;</param>
    /// <param name="radius">Defines the distance (in meters) within which to return place results. You may bias results to a specified circle by passing a `location` and a `radius` parameter. Doing so instructs the Places service to _prefer_ showing results within that circle; results outside of the defined area may still be displayed.
    /// 
    /// The radius will automatically be clamped to a maximum value depending on the type of search and other parameters.
    /// 
    /// * Autocomplete: 50,000 meters
    /// * Nearby Search: 
    ///   * with `keyword` or `name`: 50,000 meters
    ///   * without `keyword` or `name`
    ///     * `rankby=prominence` (default): 50,000 meters
    ///     * `rankby=distance`: A few kilometers depending on density of area. `radius` will not be accepted, and will result in an INVALID_REQUEST.
    /// * Query Autocomplete: 50,000 meters
    /// * Text Search: 50,000 meters</param>
    /// <param name="types">You may restrict results from a Place Autocomplete request to be of a certain type by passing a types parameter. The parameter specifies a type or a type collection, as listed in the supported types below. If nothing is specified, all types are returned. In general only a single type is allowed. The exception is that you can safely mix the geocode and establishment types, but note that this will have the same effect as specifying no types. The supported types are:
    /// - `geocode` instructs the Place Autocomplete service to return only geocoding results, rather than business results. Generally, you use this request to disambiguate results where the location specified may be indeterminate.
    /// - `address` instructs the Place Autocomplete service to return only geocoding results with a precise address. Generally, you use this request when you know the user will be looking for a fully specified address.
    /// - `establishment` instructs the Place Autocomplete service to return only business results.
    /// - `(regions)` type collection instructs the Places service to return any result matching the following types:
    ///   - `locality`
    ///   - `sublocality`
    ///   - `postal_code`
    ///   - `country`
    ///   - `administrative_area_level_1`
    ///   - `administrative_area_level_2`
    /// - `(cities)` type collection instructs the Places service to return results that match `locality` or `administrative_area_level_3`.</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<PlacesAutocompleteResponse> AutocompleteAsync(string input, string sessiontoken, string components, bool? strictbounds, double? offset, string origin, string location, double? radius, Types? types, Language? language)
    {
        return AutocompleteAsync(input, sessiontoken, components, strictbounds, offset, origin, location, radius, types, language, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="input">The text string on which to search. The Place Autocomplete service will return candidate matches based on this string and order results based on their perceived relevance.</param>
    /// <param name="sessiontoken">A random string which identifies an autocomplete [session](https://developers.google.com/maps/documentation/places/web-service/details#session_tokens) for billing purposes.
    /// 
    /// The session begins when the user starts typing a query, and concludes when they select a place and a call to Place Details is made. Each session can have multiple queries, followed by one place selection. The API key(s) used for each request within a session must belong to the same Google Cloud Console project. Once a session has concluded, the token is no longer valid; your app must generate a fresh token for each session. If the `sessiontoken` parameter is omitted, or if you reuse a session token, the session is charged as if no session token was provided (each request is billed separately).
    /// 
    /// We recommend the following guidelines:
    /// 
    /// - Use session tokens for all autocomplete sessions.
    /// - Generate a fresh token for each session. Using a version 4 UUID is recommended.
    /// - Ensure that the API key(s) used for all Place Autocomplete and Place Details requests within a session belong to the same Cloud Console project.
    /// - Be sure to pass a unique session token for each new session. Using the same token for more than one session will result in each request being billed individually.</param>
    /// <param name="components">A grouping of places to which you would like to restrict your results. Currently, you can use components to filter by up to 5 countries. Countries must be passed as a two character, ISO 3166-1 Alpha-2 compatible country code. For example: `components=country:fr` would restrict your results to places within France. Multiple countries must be passed as multiple `country:XX` filters, with the pipe character `|` as a separator. For example: `components=country:us|country:pr|country:vi|country:gu|country:mp` would restrict your results to places within the United States and its unincorporated organized territories.
    /// &lt;div class="note"&gt;&lt;strong&gt;Note:&lt;/strong&gt; If you receive unexpected results with a country code, verify that you are using a code which includes the countries, dependent territories, and special areas of geographical interest you intend.  You can find code information at &lt;a href="https://en.wikipedia.org/wiki/List_of_ISO_3166_country_codes" target="blank" class="external"&gt;Wikipedia: List of ISO 3166 country codes&lt;/a&gt; or the &lt;a href="https://www.iso.org/obp/ui/#search" target="blank" class="external"&gt;ISO Online Browsing Platform&lt;/a&gt;.&lt;/div&gt;</param>
    /// <param name="strictbounds">Returns only those places that are strictly within the region defined by `location` and `radius`. This is a restriction, rather than a bias, meaning that results outside this region will not be returned even if they match the user input.</param>
    /// <param name="offset">The position, in the input term, of the last character that the service uses to match predictions. For example, if the input is `Google` and the offset is 3, the service will match on `Goo`. The string determined by the offset is matched against the first word in the input term only. For example, if the input term is `Google abc` and the offset is 3, the service will attempt to match against `Goo abc`. If no offset is supplied, the service will use the whole term. The offset should generally be set to the position of the text caret.</param>
    /// <param name="origin">The origin point from which to calculate straight-line distance to the destination (returned as `distance_meters`). If this value is omitted, straight-line distance will not be returned. Must be specified as `latitude,longitude`.</param>
    /// <param name="location">The point around which to retrieve place information. This must be specified as `latitude,longitude`. 
    /// 
    /// &lt;div class="note"&gt;When using the Text Search API, the `location` parameter may be overriden if the `query` contains an explicit location such as `Market in Barcelona`.&lt;/div&gt;</param>
    /// <param name="radius">Defines the distance (in meters) within which to return place results. You may bias results to a specified circle by passing a `location` and a `radius` parameter. Doing so instructs the Places service to _prefer_ showing results within that circle; results outside of the defined area may still be displayed.
    /// 
    /// The radius will automatically be clamped to a maximum value depending on the type of search and other parameters.
    /// 
    /// * Autocomplete: 50,000 meters
    /// * Nearby Search: 
    ///   * with `keyword` or `name`: 50,000 meters
    ///   * without `keyword` or `name`
    ///     * `rankby=prominence` (default): 50,000 meters
    ///     * `rankby=distance`: A few kilometers depending on density of area. `radius` will not be accepted, and will result in an INVALID_REQUEST.
    /// * Query Autocomplete: 50,000 meters
    /// * Text Search: 50,000 meters</param>
    /// <param name="types">You may restrict results from a Place Autocomplete request to be of a certain type by passing a types parameter. The parameter specifies a type or a type collection, as listed in the supported types below. If nothing is specified, all types are returned. In general only a single type is allowed. The exception is that you can safely mix the geocode and establishment types, but note that this will have the same effect as specifying no types. The supported types are:
    /// - `geocode` instructs the Place Autocomplete service to return only geocoding results, rather than business results. Generally, you use this request to disambiguate results where the location specified may be indeterminate.
    /// - `address` instructs the Place Autocomplete service to return only geocoding results with a precise address. Generally, you use this request when you know the user will be looking for a fully specified address.
    /// - `establishment` instructs the Place Autocomplete service to return only business results.
    /// - `(regions)` type collection instructs the Places service to return any result matching the following types:
    ///   - `locality`
    ///   - `sublocality`
    ///   - `postal_code`
    ///   - `country`
    ///   - `administrative_area_level_1`
    ///   - `administrative_area_level_2`
    /// - `(cities)` type collection instructs the Places service to return results that match `locality` or `administrative_area_level_3`.</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<PlacesAutocompleteResponse> AutocompleteAsync(string input, string sessiontoken, string components, bool? strictbounds, double? offset, string origin, string location, double? radius, Types? types, Language? language, CancellationToken cancellationToken)
    {
        if (input == null)
            throw new ArgumentNullException("input");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/maps/api/place/autocomplete/json?");
        urlBuilder_.Append(Uri.EscapeDataString("input") + "=").Append(Uri.EscapeDataString(ConvertToString(input, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        if (sessiontoken != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("sessiontoken") + "=").Append(Uri.EscapeDataString(ConvertToString(sessiontoken, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (components != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("components") + "=").Append(Uri.EscapeDataString(ConvertToString(components, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (strictbounds != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("strictbounds") + "=").Append(Uri.EscapeDataString(ConvertToString(strictbounds, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (offset != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("offset") + "=").Append(Uri.EscapeDataString(ConvertToString(offset, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (origin != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("origin") + "=").Append(Uri.EscapeDataString(ConvertToString(origin, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (location != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("location") + "=").Append(Uri.EscapeDataString(ConvertToString(location, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (radius != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("radius") + "=").Append(Uri.EscapeDataString(ConvertToString(radius, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (types != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("types") + "=").Append(Uri.EscapeDataString(ConvertToString(types, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (language != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("language") + "=").Append(Uri.EscapeDataString(ConvertToString(language, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Length--;

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<PlacesAutocompleteResponse>(response_, headers_).ConfigureAwait(false);
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(PlacesAutocompleteResponse);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    /// <param name="fov">Determines the horizontal field of view of the image. The field of view is expressed in degrees, with a maximum allowed value of 120. When dealing with a fixed-size viewport, as with a Street View image of a set size, field of view in essence represents zoom, with smaller numbers indicating a higher level of zoom. Default is 90.</param>
    /// <param name="heading">Indicates the compass heading of the camera. Accepted values are from 0 to 360 (both values indicating North, with 90 indicating East, and 180 South). If no heading is specified, a value will be calculated that directs the camera towards the specified location, from the point at which the closest photograph was taken.</param>
    /// <param name="location">The point around which to retrieve place information. The Street View Static API will snap to the panorama photographed closest to this location. When an address text string is provided, the API may use a different camera location to better display the specified location. When a lat/lng is provided, the API searches a 50 meter radius for a photograph closest to this location. Because Street View imagery is periodically refreshed, and photographs may be taken from slightly different positions each time, it's possible that your `location` may snap to a different panorama when imagery is updated.</param>
    /// <param name="pano">A specific panorama ID. These are generally stable, though panoramas may change ID over time as imagery is refreshed.</param>
    /// <param name="pitch">Specifies the up or down angle of the camera relative to the Street View vehicle. This is often, but not always, flat horizontal. Positive values angle the camera up (with 90 degrees indicating straight up); negative values angle the camera down (with -90 indicating straight down). Default is 0.</param>
    /// <param name="radius">Sets a radius, specified in meters, in which to search for a panorama, centered on the given latitude and longitude. Valid values are non-negative integers. Default is 50 meters.</param>
    /// <param name="return_error_code">Indicates whether the API should return a non `200 Ok` HTTP status when no image is found (`404 NOT FOUND`), or in response to an invalid request (400 BAD REQUEST). Valid values are `true` and `false`. If set to `true`, an error message is returned in place of the generic gray image. This eliminates the need to make a separate call to check for image availability.</param>
    /// <param name="signature">A digital signature used to verify that any site generating requests using your API key is authorized to do so. Requests that do not include a digital signature might fail. For more information, see [Get a Key and Signature](https://developers.google.com/maps/documentation/streetview/get-api-key).</param>
    /// <param name="size">Specifies the output size of the image in pixels. Size is specified as `{width}x{height}` - for example, `size=600x400` returns an image 600 pixels wide, and 400 high.</param>
    /// <param name="source">Limits Street View searches to selected sources. Valid values are:
    /// * `default` uses the default sources for Street View; searches are not limited to specific sources.
    /// * `outdoor` limits searches to outdoor collections. Indoor collections are not included in search results. Note that outdoor panoramas may not exist for the specified location. Also note that the search only returns panoramas where it's possible to determine whether they're indoors or outdoors. For example, PhotoSpheres are not returned because it's unknown whether they are indoors or outdoors.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<FileResponse> StreetViewAsync(double? fov, double? heading, string location, string pano, double? pitch, double? radius, bool? return_error_code, string signature, string size, Source? source)
    {
        return StreetViewAsync(fov, heading, location, pano, pitch, radius, return_error_code, signature, size, source, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="fov">Determines the horizontal field of view of the image. The field of view is expressed in degrees, with a maximum allowed value of 120. When dealing with a fixed-size viewport, as with a Street View image of a set size, field of view in essence represents zoom, with smaller numbers indicating a higher level of zoom. Default is 90.</param>
    /// <param name="heading">Indicates the compass heading of the camera. Accepted values are from 0 to 360 (both values indicating North, with 90 indicating East, and 180 South). If no heading is specified, a value will be calculated that directs the camera towards the specified location, from the point at which the closest photograph was taken.</param>
    /// <param name="location">The point around which to retrieve place information. The Street View Static API will snap to the panorama photographed closest to this location. When an address text string is provided, the API may use a different camera location to better display the specified location. When a lat/lng is provided, the API searches a 50 meter radius for a photograph closest to this location. Because Street View imagery is periodically refreshed, and photographs may be taken from slightly different positions each time, it's possible that your `location` may snap to a different panorama when imagery is updated.</param>
    /// <param name="pano">A specific panorama ID. These are generally stable, though panoramas may change ID over time as imagery is refreshed.</param>
    /// <param name="pitch">Specifies the up or down angle of the camera relative to the Street View vehicle. This is often, but not always, flat horizontal. Positive values angle the camera up (with 90 degrees indicating straight up); negative values angle the camera down (with -90 indicating straight down). Default is 0.</param>
    /// <param name="radius">Sets a radius, specified in meters, in which to search for a panorama, centered on the given latitude and longitude. Valid values are non-negative integers. Default is 50 meters.</param>
    /// <param name="return_error_code">Indicates whether the API should return a non `200 Ok` HTTP status when no image is found (`404 NOT FOUND`), or in response to an invalid request (400 BAD REQUEST). Valid values are `true` and `false`. If set to `true`, an error message is returned in place of the generic gray image. This eliminates the need to make a separate call to check for image availability.</param>
    /// <param name="signature">A digital signature used to verify that any site generating requests using your API key is authorized to do so. Requests that do not include a digital signature might fail. For more information, see [Get a Key and Signature](https://developers.google.com/maps/documentation/streetview/get-api-key).</param>
    /// <param name="size">Specifies the output size of the image in pixels. Size is specified as `{width}x{height}` - for example, `size=600x400` returns an image 600 pixels wide, and 400 high.</param>
    /// <param name="source">Limits Street View searches to selected sources. Valid values are:
    /// * `default` uses the default sources for Street View; searches are not limited to specific sources.
    /// * `outdoor` limits searches to outdoor collections. Indoor collections are not included in search results. Note that outdoor panoramas may not exist for the specified location. Also note that the search only returns panoramas where it's possible to determine whether they're indoors or outdoors. For example, PhotoSpheres are not returned because it's unknown whether they are indoors or outdoors.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<FileResponse> StreetViewAsync(double? fov, double? heading, string location, string pano, double? pitch, double? radius, bool? return_error_code, string signature, string size, Source? source, CancellationToken cancellationToken)
    {
        if (size == null)
            throw new ArgumentNullException("size");

        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/maps/api/streetview?");
        if (fov != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("fov") + "=").Append(Uri.EscapeDataString(ConvertToString(fov, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (heading != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("heading") + "=").Append(Uri.EscapeDataString(ConvertToString(heading, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (location != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("location") + "=").Append(Uri.EscapeDataString(ConvertToString(location, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (pano != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("pano") + "=").Append(Uri.EscapeDataString(ConvertToString(pano, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (pitch != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("pitch") + "=").Append(Uri.EscapeDataString(ConvertToString(pitch, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (radius != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("radius") + "=").Append(Uri.EscapeDataString(ConvertToString(radius, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (return_error_code != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("return_error_code") + "=").Append(Uri.EscapeDataString(ConvertToString(return_error_code, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (signature != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("signature") + "=").Append(Uri.EscapeDataString(ConvertToString(signature, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Append(Uri.EscapeDataString("size") + "=").Append(Uri.EscapeDataString(ConvertToString(size, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        if (source != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("source") + "=").Append(Uri.EscapeDataString(ConvertToString(source, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Length--;

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("image/*"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200" || status_ == "206")
                    {
                        var responseStream_ = response_.Content == null ? Stream.Null : await response_.Content.ReadAsStreamAsync().ConfigureAwait(false);
                        var fileResponse_ = new FileResponse((int)response_.StatusCode, headers_, responseStream_, null, response_);
                        client_ = null; response_ = null; // response and client are disposed by FileResponse
                        return fileResponse_;
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(FileResponse);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    /// <param name="heading">Indicates the compass heading of the camera. Accepted values are from 0 to 360 (both values indicating North, with 90 indicating East, and 180 South). If no heading is specified, a value will be calculated that directs the camera towards the specified location, from the point at which the closest photograph was taken.</param>
    /// <param name="location">The point around which to retrieve place information. The Street View Static API will snap to the panorama photographed closest to this location. When an address text string is provided, the API may use a different camera location to better display the specified location. When a lat/lng is provided, the API searches a 50 meter radius for a photograph closest to this location. Because Street View imagery is periodically refreshed, and photographs may be taken from slightly different positions each time, it's possible that your `location` may snap to a different panorama when imagery is updated.</param>
    /// <param name="pano">A specific panorama ID. These are generally stable, though panoramas may change ID over time as imagery is refreshed.</param>
    /// <param name="pitch">Specifies the up or down angle of the camera relative to the Street View vehicle. This is often, but not always, flat horizontal. Positive values angle the camera up (with 90 degrees indicating straight up); negative values angle the camera down (with -90 indicating straight down). Default is 0.</param>
    /// <param name="radius">Sets a radius, specified in meters, in which to search for a panorama, centered on the given latitude and longitude. Valid values are non-negative integers. Default is 50 meters.</param>
    /// <param name="return_error_code">Indicates whether the API should return a non `200 Ok` HTTP status when no image is found (`404 NOT FOUND`), or in response to an invalid request (400 BAD REQUEST). Valid values are `true` and `false`. If set to `true`, an error message is returned in place of the generic gray image. This eliminates the need to make a separate call to check for image availability.</param>
    /// <param name="signature">A digital signature used to verify that any site generating requests using your API key is authorized to do so. Requests that do not include a digital signature might fail. For more information, see [Get a Key and Signature](https://developers.google.com/maps/documentation/streetview/get-api-key).</param>
    /// <param name="size">Specifies the output size of the image in pixels. Size is specified as `{width}x{height}` - for example, `size=600x400` returns an image 600 pixels wide, and 400 high.</param>
    /// <param name="source">Limits Street View searches to selected sources. Valid values are:
    /// * `default` uses the default sources for Street View; searches are not limited to specific sources.
    /// * `outdoor` limits searches to outdoor collections. Indoor collections are not included in search results. Note that outdoor panoramas may not exist for the specified location. Also note that the search only returns panoramas where it's possible to determine whether they're indoors or outdoors. For example, PhotoSpheres are not returned because it's unknown whether they are indoors or outdoors.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public Task<StreetViewResponse> StreetViewMetadataAsync(double? heading, string location, string pano, double? pitch, double? radius, bool? return_error_code, string signature, string size, Source? source)
    {
        return StreetViewMetadataAsync(heading, location, pano, pitch, radius, return_error_code, signature, size, source, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="heading">Indicates the compass heading of the camera. Accepted values are from 0 to 360 (both values indicating North, with 90 indicating East, and 180 South). If no heading is specified, a value will be calculated that directs the camera towards the specified location, from the point at which the closest photograph was taken.</param>
    /// <param name="location">The point around which to retrieve place information. The Street View Static API will snap to the panorama photographed closest to this location. When an address text string is provided, the API may use a different camera location to better display the specified location. When a lat/lng is provided, the API searches a 50 meter radius for a photograph closest to this location. Because Street View imagery is periodically refreshed, and photographs may be taken from slightly different positions each time, it's possible that your `location` may snap to a different panorama when imagery is updated.</param>
    /// <param name="pano">A specific panorama ID. These are generally stable, though panoramas may change ID over time as imagery is refreshed.</param>
    /// <param name="pitch">Specifies the up or down angle of the camera relative to the Street View vehicle. This is often, but not always, flat horizontal. Positive values angle the camera up (with 90 degrees indicating straight up); negative values angle the camera down (with -90 indicating straight down). Default is 0.</param>
    /// <param name="radius">Sets a radius, specified in meters, in which to search for a panorama, centered on the given latitude and longitude. Valid values are non-negative integers. Default is 50 meters.</param>
    /// <param name="return_error_code">Indicates whether the API should return a non `200 Ok` HTTP status when no image is found (`404 NOT FOUND`), or in response to an invalid request (400 BAD REQUEST). Valid values are `true` and `false`. If set to `true`, an error message is returned in place of the generic gray image. This eliminates the need to make a separate call to check for image availability.</param>
    /// <param name="signature">A digital signature used to verify that any site generating requests using your API key is authorized to do so. Requests that do not include a digital signature might fail. For more information, see [Get a Key and Signature](https://developers.google.com/maps/documentation/streetview/get-api-key).</param>
    /// <param name="size">Specifies the output size of the image in pixels. Size is specified as `{width}x{height}` - for example, `size=600x400` returns an image 600 pixels wide, and 400 high.</param>
    /// <param name="source">Limits Street View searches to selected sources. Valid values are:
    /// * `default` uses the default sources for Street View; searches are not limited to specific sources.
    /// * `outdoor` limits searches to outdoor collections. Indoor collections are not included in search results. Note that outdoor panoramas may not exist for the specified location. Also note that the search only returns panoramas where it's possible to determine whether they're indoors or outdoors. For example, PhotoSpheres are not returned because it's unknown whether they are indoors or outdoors.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public async Task<StreetViewResponse> StreetViewMetadataAsync(double? heading, string location, string pano, double? pitch, double? radius, bool? return_error_code, string signature, string size, Source? source, CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/maps/api/streetview/metadata?");
        if (heading != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("heading") + "=").Append(Uri.EscapeDataString(ConvertToString(heading, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (location != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("location") + "=").Append(Uri.EscapeDataString(ConvertToString(location, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (pano != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("pano") + "=").Append(Uri.EscapeDataString(ConvertToString(pano, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (pitch != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("pitch") + "=").Append(Uri.EscapeDataString(ConvertToString(pitch, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (radius != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("radius") + "=").Append(Uri.EscapeDataString(ConvertToString(radius, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (return_error_code != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("return_error_code") + "=").Append(Uri.EscapeDataString(ConvertToString(return_error_code, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (signature != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("signature") + "=").Append(Uri.EscapeDataString(ConvertToString(signature, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (size != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("size") + "=").Append(Uri.EscapeDataString(ConvertToString(size, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        if (source != null)
        {
            urlBuilder_.Append(Uri.EscapeDataString("source") + "=").Append(Uri.EscapeDataString(ConvertToString(source, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Length--;

        var client_ = _httpClient;
        try
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = new HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);
                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                try
                {
                    var headers_ = Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = ((int)response_.StatusCode).ToString();
                    if (status_ == "200")
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<StreetViewResponse>(response_, headers_).ConfigureAwait(false);
                        return objectResponse_.Object;
                    }
                    else
                    if (status_ != "200" && status_ != "204")
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                    }

                    return default(StreetViewResponse);
                }
                finally
                {
                    if (response_ != null)
                        response_.Dispose();
                }
            }
        }
        finally
        {
        }
    }

    protected struct ObjectResponseResult<T>
    {
        public ObjectResponseResult(T responseObject, string responseText)
        {
            Object = responseObject;
            Text = responseText;
        }

        public T Object { get; }

        public string Text { get; }
    }

    public bool ReadResponseAsString { get; set; }

    protected virtual async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(HttpResponseMessage response, IReadOnlyDictionary<string, IEnumerable<string>> headers)
    {
        if (response == null || response.Content == null)
        {
            return new ObjectResponseResult<T>(default(T), string.Empty);
        }

        if (ReadResponseAsString)
        {
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                var typedBody = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                return new ObjectResponseResult<T>(typedBody, responseText);
            }
            catch (Newtonsoft.Json.JsonException exception)
            {
                var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
            }
        }
        else
        {
            try
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (var streamReader = new StreamReader(responseStream))
                using (var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader))
                {
                    var serializer = Newtonsoft.Json.JsonSerializer.Create(JsonSerializerSettings);
                    var typedBody = serializer.Deserialize<T>(jsonTextReader);
                    return new ObjectResponseResult<T>(typedBody, string.Empty);
                }
            }
            catch (Newtonsoft.Json.JsonException exception)
            {
                var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
            }
        }
    }

    private string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
    {
        if (value is Enum)
        {
            string name = Enum.GetName(value.GetType(), value);
            if (name != null)
            {
                var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                if (field != null)
                {
                    var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                        as System.Runtime.Serialization.EnumMemberAttribute;
                    if (attribute != null)
                    {
                        return attribute.Value != null ? attribute.Value : name;
                    }
                }
            }
        }
        else if (value is bool)
        {
            return Convert.ToString(value, cultureInfo).ToLowerInvariant();
        }
        else if (value is byte[])
        {
            return Convert.ToBase64String((byte[])value);
        }
        else if (value != null && value.GetType().IsArray)
        {
            var array = Enumerable.OfType<object>((Array)value);
            return string.Join(",", Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
        }

        return Convert.ToString(value, cultureInfo);
    }
}