namespace GoogleMapsServices.Client;

public interface IPlacesApiClient
{

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
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
    /// <param name="input">Text input that identifies the search target, such as a name, address, or phone number. The input must be a string. Non-string input such as a lat/lng coordinate or plus code generates an error.</param>
    /// <param name="inputtype">The type of input. This can be one of either `textquery` or `phonenumber`. Phone numbers must be in international format (prefixed by a plus sign ("+"), followed by the country code, then the phone number itself). See [E.164 ITU recommendation](https://en.wikipedia.org/wiki/E.164) for more information.</param>
    /// <param name="locationbias">Prefer results in a specified area, by specifying either a radius plus lat/lng, or two lat/lng pairs representing the points of a rectangle. If this parameter is not specified, the API uses IP address biasing by default.
    /// - IP bias: Instructs the API to use IP address biasing. Pass the string `ipbias` (this option has no additional parameters).
    /// - Point: A single lat/lng coordinate. Use the following format: `point:lat,lng`.
    /// - Circular: A string specifying radius in meters, plus lat/lng in decimal degrees. Use the following format: `circle:radius@lat,lng`.
    /// - Rectangular: A string specifying two lat/lng pairs in decimal degrees, representing the south/west and north/east points of a rectangle. Use the following format:`rectangle:south,west|north,east`. Note that east/west values are wrapped to the range -180, 180, and north/south values are clamped to the range -90, 90.</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<PlacesFindPlaceFromTextResponse> FindPlaceFromTextAsync(IEnumerable<Field> fields, string input,
        Inputtype inputType, string locationBias, Language? language, CancellationToken cancellationToken);

    /// <param name="keyword">A term to be matched against all content that Google has indexed for this place, including but not limited to name and type, as well as customer reviews and other third-party content. Note that explicitly including location information using this parameter may conflict with the location, radius, and rankby parameters, causing unexpected results.</param>
    /// <param name="location">The point around which to retrieve place information. This must be specified as `latitude,longitude`.</param>
    /// <param name="maxprice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
    /// <param name="minprice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
    /// <param name="name">*Not Recommended* A term to be matched against all content that Google has indexed for this place. Equivalent to `keyword`. The `name` field is no longer restricted to place names. Values in this field are combined with values in the keyword field and passed as part of the same search string. We recommend using only the `keyword` parameter for all search terms.</param>
    /// <param name="opennow">Returns only those places that are open for business at the time the query is sent. Places that do not specify opening hours in the Google Places database will not be returned if you include this parameter in your query.</param>
    /// <param name="pagetoken">Returns up to 20 results from a previously run search. Setting a `pageToken` parameter will execute a search with the same parameters used previously — all parameters other than pageToken will be ignored.</param>
    /// <param name="rankby">Specifies the order in which results are listed. Possible values are:
    /// - `prominence` (default). This option sorts results based on their importance. Ranking will favor prominent places within the set radius over nearby places that match but that are less prominent. Prominence can be affected by a place's ranking in Google's index, global popularity, and other factors. When prominence is specified, the `radius` parameter is required.
    /// - `distance`. This option biases search results in ascending order by their distance from the specified location. When `distance` is specified, one or more of `keyword`, `name`, or `type` is required and `radius` is disallowed.</param>
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
    /// <param name="type">Restricts the results to places matching the specified type. Only one type may be specified. If more than one type is provided, all types following the first entry are ignored.
    /// 
    /// * `type=hospital|pharmacy|doctor` becomes `type=hospital`
    /// * `type=hospital,pharmacy,doctor` is ignored entirely
    /// 
    /// See the list of [supported types](https://developers.google.com/maps/documentation/places/web-service/supported_types).
    /// &lt;div class="note"&gt;Note: Adding both `keyword` and `type` with the same value (`keyword=cafe&amp;type=cafe` or `keyword=parking&amp;type=parking`) can yield `ZERO_RESULTS`.&lt;/div&gt;</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<PlacesNearbySearchResponse> NearbySearchAsync(string keyword, string location, Maxprice? maxPrice,
        Minprice? minPrice, string name, bool? openNow, string pageToken, Rankby? rankBy, double? radius, string type,
        Language? language);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="keyword">A term to be matched against all content that Google has indexed for this place, including but not limited to name and type, as well as customer reviews and other third-party content. Note that explicitly including location information using this parameter may conflict with the location, radius, and rankby parameters, causing unexpected results.</param>
    /// <param name="location">The point around which to retrieve place information. This must be specified as `latitude,longitude`.</param>
    /// <param name="maxprice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
    /// <param name="minprice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
    /// <param name="name">*Not Recommended* A term to be matched against all content that Google has indexed for this place. Equivalent to `keyword`. The `name` field is no longer restricted to place names. Values in this field are combined with values in the keyword field and passed as part of the same search string. We recommend using only the `keyword` parameter for all search terms.</param>
    /// <param name="opennow">Returns only those places that are open for business at the time the query is sent. Places that do not specify opening hours in the Google Places database will not be returned if you include this parameter in your query.</param>
    /// <param name="pagetoken">Returns up to 20 results from a previously run search. Setting a `pageToken` parameter will execute a search with the same parameters used previously — all parameters other than pageToken will be ignored.</param>
    /// <param name="rankby">Specifies the order in which results are listed. Possible values are:
    /// - `prominence` (default). This option sorts results based on their importance. Ranking will favor prominent places within the set radius over nearby places that match but that are less prominent. Prominence can be affected by a place's ranking in Google's index, global popularity, and other factors. When prominence is specified, the `radius` parameter is required.
    /// - `distance`. This option biases search results in ascending order by their distance from the specified location. When `distance` is specified, one or more of `keyword`, `name`, or `type` is required and `radius` is disallowed.</param>
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
    /// <param name="type">Restricts the results to places matching the specified type. Only one type may be specified. If more than one type is provided, all types following the first entry are ignored.
    /// 
    /// * `type=hospital|pharmacy|doctor` becomes `type=hospital`
    /// * `type=hospital,pharmacy,doctor` is ignored entirely
    /// 
    /// See the list of [supported types](https://developers.google.com/maps/documentation/places/web-service/supported_types).
    /// &lt;div class="note"&gt;Note: Adding both `keyword` and `type` with the same value (`keyword=cafe&amp;type=cafe` or `keyword=parking&amp;type=parking`) can yield `ZERO_RESULTS`.&lt;/div&gt;</param>
    /// <param name="language">The language in which to return results.
    /// 
    /// * See the [list of supported languages](https://developers.google.com/maps/faq#languagesupport). Google often updates the supported languages, so this list may not be exhaustive.
    /// * If `language` is not supplied, the API attempts to use the preferred language as specified in the `Accept-Language` header.
    /// * The API does its best to provide a street address that is readable for both the user and locals. To achieve that goal, it returns street addresses in the local language, transliterated to a script readable by the user if necessary, observing the preferred language. All other addresses are returned in the preferred language. Address components are all returned in the same language, which is chosen from the first component.
    /// * If a name is not available in the preferred language, the API uses the closest match.
    /// * The preferred language has a small influence on the set of results that the API chooses to return, and the order in which they are returned. The geocoder interprets abbreviations differently depending on language, such as the abbreviations for street types, or synonyms that may be valid in one language but not in another. For example, _utca_ and _tér_ are synonyms for street in Hungarian.</param>
    /// <returns>200 OK</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    Task<PlacesNearbySearchResponse> NearbySearchAsync(string keyword, string location, Maxprice? maxPrice,
        Minprice? minPrice, string name, bool? openNow, string pageToken, Rankby? rankBy, double? radius, string type,
        Language? language, CancellationToken cancellationToken);

    /// <param name="location">The point around which to retrieve place information. This must be specified as `latitude,longitude`. 
    /// 
    /// &lt;div class="note"&gt;The &lt;code&gt;location&lt;/code&gt; parameter may be overriden if the &lt;code&gt;query&lt;/code&gt; contains an explicit location such as &lt;code&gt;Market in Barcelona&lt;/code&gt;. Using quotes around the query may also influence the weight given to the &lt;code&gt;location&lt;/code&gt; and &lt;code&gt;radius&lt;/code&gt;.&lt;/div&gt;</param>
    /// <param name="maxPrice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
    /// <param name="minprice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
    /// <param name="opennow">Returns only those places that are open for business at the time the query is sent. Places that do not specify opening hours in the Google Places database will not be returned if you include this parameter in your query.</param>
    /// <param name="pagetoken">Returns up to 20 results from a previously run search. Setting a `pageToken` parameter will execute a search with the same parameters used previously — all parameters other than pageToken will be ignored.</param>
    /// <param name="query">The text string on which to search, for example: "restaurant" or "123 Main Street". The Google Places service will return candidate matches based on this string and order the results based on their perceived relevance.</param>
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
    /// <param name="type">Restricts the results to places matching the specified type. Only one type may be specified. If more than one type is provided, all types following the first entry are ignored.
    /// 
    /// * `type=hospital|pharmacy|doctor` becomes `type=hospital`
    /// * `type=hospital,pharmacy,doctor` is ignored entirely
    /// 
    /// See the list of [supported types](https://developers.google.com/maps/documentation/places/web-service/supported_types).
    /// &lt;div class="note"&gt;Note: Adding both `keyword` and `type` with the same value (`keyword=cafe&amp;type=cafe` or `keyword=parking&amp;type=parking`) can yield `ZERO_RESULTS`.&lt;/div&gt;</param>
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
    Task<PlacesTextSearchResponse> TextSearchAsync(string location, Maxprice? maxPrice, Minprice? minPrice,
        bool? openNow, string pageToken, string query, double? radius, string type, Language? language, Region? region);


    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <param name="location">The point around which to retrieve place information. This must be specified as `latitude,longitude`. 
    /// 
    /// &lt;div class="note"&gt;The &lt;code&gt;location&lt;/code&gt; parameter may be overriden if the &lt;code&gt;query&lt;/code&gt; contains an explicit location such as &lt;code&gt;Market in Barcelona&lt;/code&gt;. Using quotes around the query may also influence the weight given to the &lt;code&gt;location&lt;/code&gt; and &lt;code&gt;radius&lt;/code&gt;.&lt;/div&gt;</param>
    /// <param name="maxPrice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
    /// <param name="minPrice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
    /// <param name="openNow">Returns only those places that are open for business at the time the query is sent. Places that do not specify opening hours in the Google Places database will not be returned if you include this parameter in your query.</param>
    /// <param name="pageToken">Returns up to 20 results from a previously run search. Setting a `pageToken` parameter will execute a search with the same parameters used previously — all parameters other than pageToken will be ignored.</param>
    /// <param name="query">The text string on which to search, for example: "restaurant" or "123 Main Street". The Google Places service will return candidate matches based on this string and order the results based on their perceived relevance.</param>
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
    /// <param name="type">Restricts the results to places matching the specified type. Only one type may be specified. If more than one type is provided, all types following the first entry are ignored.
    /// 
    /// * `type=hospital|pharmacy|doctor` becomes `type=hospital`
    /// * `type=hospital,pharmacy,doctor` is ignored entirely
    /// 
    /// See the list of [supported types](https://developers.google.com/maps/documentation/places/web-service/supported_types).
    /// &lt;div class="note"&gt;Note: Adding both `keyword` and `type` with the same value (`keyword=cafe&amp;type=cafe` or `keyword=parking&amp;type=parking`) can yield `ZERO_RESULTS`.&lt;/div&gt;</param>
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
    Task<PlacesTextSearchResponse> TextSearchAsync(string location, Maxprice? maxPrice, Minprice? minPrice,
        bool? openNow, string pageToken, string query, double? radius, string type, Language? language, Region? region,
        CancellationToken cancellationToken);
}