using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GoogleMapsServices.Client
{
    public class GoogleClientOptions
    {
        public string BaseUrl { get; set; }
    }

    public class PlacesApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly GoogleClientOptions _googleClientOptions;

        private Lazy<JsonSerializerSettings> _settings;
        private readonly string _baseUrl;
        protected JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }
        public PlacesApiClient(HttpClient httpClient, GoogleClientOptions googleClientOptions)
        {
            _httpClient = httpClient;
            _googleClientOptions = googleClientOptions;
            _baseUrl = _googleClientOptions.BaseUrl;

            _settings = new Lazy<JsonSerializerSettings>(() =>
            {
                var settings = new JsonSerializerSettings();
                UpdateJsonSerializerSettings(settings);
                return settings;
            });
        }


        private void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
        {

        }

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
        public async Task<PlacesFindPlaceFromTextResponse> FindPlaceFromTextAsync(IEnumerable<string> fields, string input, Inputtype inputType, string locationBias, Language? language, CancellationToken cancellationToken)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            if (inputType == null)
                throw new ArgumentNullException("inputtype");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(_baseUrl != null ? _baseUrl.TrimEnd('/') : "").Append("/maps/api/place/findplacefromtext/json?");
            if (fields != null)
            {
                foreach (var item_ in fields) { urlBuilder_.Append(Uri.EscapeDataString("fields") + "=").Append(Uri.EscapeDataString(ConvertToString(item_, CultureInfo.InvariantCulture))).Append("&"); }
            }
            urlBuilder_.Append(Uri.EscapeDataString("input") + "=").Append(Uri.EscapeDataString(ConvertToString(input, CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Append(Uri.EscapeDataString("inputtype") + "=").Append(Uri.EscapeDataString(ConvertToString(inputType, CultureInfo.InvariantCulture))).Append("&");
            if (locationBias != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("locationbias") + "=").Append(Uri.EscapeDataString(ConvertToString(locationBias, CultureInfo.InvariantCulture))).Append("&");
            }
            if (language != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("language") + "=").Append(Uri.EscapeDataString(ConvertToString(language, CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Length--;

            var client_ = _httpClient;
            try
            {
                using (var request_ = new HttpRequestMessage())
                {
                    request_.Method = HttpMethod.Get;
                    request_.Headers.Accept.Add( MediaTypeWithQualityHeaderValue.Parse("application/json"));

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

                        var status_ = response_.StatusCode;
                        if (status_ == HttpStatusCode.OK)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<PlacesFindPlaceFromTextResponse>(response_, headers_).ConfigureAwait(false);
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ != HttpStatusCode.OK && status_ != HttpStatusCode.NoContent)
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }

                        return default(PlacesFindPlaceFromTextResponse);
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

        /// <param name="keyword">A term to be matched against all content that Google has indexed for this place, including but not limited to name and type, as well as customer reviews and other third-party content. Note that explicitly including location information using this parameter may conflict with the location, radius, and rankby parameters, causing unexpected results.</param>
        /// <param name="location">The point around which to retrieve place information. This must be specified as `latitude,longitude`.</param>
        /// <param name="maxprice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
        /// <param name="minprice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
        /// <param name="name">*Not Recommended* A term to be matched against all content that Google has indexed for this place. Equivalent to `keyword`. The `name` field is no longer restricted to place names. Values in this field are combined with values in the keyword field and passed as part of the same search string. We recommend using only the `keyword` parameter for all search terms.</param>
        /// <param name="opennow">Returns only those places that are open for business at the time the query is sent. Places that do not specify opening hours in the Google Places database will not be returned if you include this parameter in your query.</param>
        /// <param name="pagetoken">Returns up to 20 results from a previously run search. Setting a `pagetoken` parameter will execute a search with the same parameters used previously — all parameters other than pagetoken will be ignored.</param>
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
        public Task<PlacesNearbySearchResponse> NearbySearchAsync(string keyword, string location, Maxprice? maxprice, Minprice? minprice, string name, bool? opennow, string pagetoken, Rankby? rankby, double? radius, string type, Language? language)
        {
            return NearbySearchAsync(keyword, location, maxprice, minprice, name, opennow, pagetoken, rankby, radius, type, language, CancellationToken.None);
        }


        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="keyword">A term to be matched against all content that Google has indexed for this place, including but not limited to name and type, as well as customer reviews and other third-party content. Note that explicitly including location information using this parameter may conflict with the location, radius, and rankby parameters, causing unexpected results.</param>
        /// <param name="location">The point around which to retrieve place information. This must be specified as `latitude,longitude`.</param>
        /// <param name="maxprice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
        /// <param name="minprice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
        /// <param name="name">*Not Recommended* A term to be matched against all content that Google has indexed for this place. Equivalent to `keyword`. The `name` field is no longer restricted to place names. Values in this field are combined with values in the keyword field and passed as part of the same search string. We recommend using only the `keyword` parameter for all search terms.</param>
        /// <param name="opennow">Returns only those places that are open for business at the time the query is sent. Places that do not specify opening hours in the Google Places database will not be returned if you include this parameter in your query.</param>
        /// <param name="pagetoken">Returns up to 20 results from a previously run search. Setting a `pagetoken` parameter will execute a search with the same parameters used previously — all parameters other than pagetoken will be ignored.</param>
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
        public async Task<PlacesNearbySearchResponse> NearbySearchAsync(string keyword, string location, Maxprice? maxprice, Minprice? minprice, string name, bool? opennow, string pagetoken, Rankby? rankby, double? radius, string type, Language? language, CancellationToken cancellationToken)
        {
            if (location == null)
                throw new ArgumentNullException("location");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(_baseUrl != null ? _baseUrl.TrimEnd('/') : "").Append("/maps/api/place/nearbysearch/json?");
            if (keyword != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("keyword") + "=").Append(Uri.EscapeDataString(ConvertToString(keyword, CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Append(Uri.EscapeDataString("location") + "=").Append(Uri.EscapeDataString(ConvertToString(location, CultureInfo.InvariantCulture))).Append("&");
            if (maxprice != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("maxPrice") + "=").Append(Uri.EscapeDataString(ConvertToString(maxprice, CultureInfo.InvariantCulture))).Append("&");
            }
            if (minprice != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("minprice") + "=").Append(Uri.EscapeDataString(ConvertToString(minprice, CultureInfo.InvariantCulture))).Append("&");
            }
            if (name != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("name") + "=").Append(Uri.EscapeDataString(ConvertToString(name, CultureInfo.InvariantCulture))).Append("&");
            }
            if (opennow != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("opennow") + "=").Append(Uri.EscapeDataString(ConvertToString(opennow, CultureInfo.InvariantCulture))).Append("&");
            }
            if (pagetoken != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("pagetoken") + "=").Append(Uri.EscapeDataString(ConvertToString(pagetoken, CultureInfo.InvariantCulture))).Append("&");
            }
            if (rankby != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("rankby") + "=").Append(Uri.EscapeDataString(ConvertToString(rankby, CultureInfo.InvariantCulture))).Append("&");
            }
            if (radius != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("radius") + "=").Append(Uri.EscapeDataString(ConvertToString(radius, CultureInfo.InvariantCulture))).Append("&");
            }
            if (type != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("type") + "=").Append(Uri.EscapeDataString(ConvertToString(type, CultureInfo.InvariantCulture))).Append("&");
            }
            if (language != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("language") + "=").Append(Uri.EscapeDataString(ConvertToString(language, CultureInfo.InvariantCulture))).Append("&");
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
                            var objectResponse_ = await ReadObjectResponseAsync<PlacesNearbySearchResponse>(response_, headers_).ConfigureAwait(false);
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }

                        return default(PlacesNearbySearchResponse);
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

        /// <param name="location">The point around which to retrieve place information. This must be specified as `latitude,longitude`. 
        /// 
        /// &lt;div class="note"&gt;The &lt;code&gt;location&lt;/code&gt; parameter may be overriden if the &lt;code&gt;query&lt;/code&gt; contains an explicit location such as &lt;code&gt;Market in Barcelona&lt;/code&gt;. Using quotes around the query may also influence the weight given to the &lt;code&gt;location&lt;/code&gt; and &lt;code&gt;radius&lt;/code&gt;.&lt;/div&gt;</param>
        /// <param name="maxPrice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
        /// <param name="minprice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
        /// <param name="opennow">Returns only those places that are open for business at the time the query is sent. Places that do not specify opening hours in the Google Places database will not be returned if you include this parameter in your query.</param>
        /// <param name="pagetoken">Returns up to 20 results from a previously run search. Setting a `pagetoken` parameter will execute a search with the same parameters used previously — all parameters other than pagetoken will be ignored.</param>
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
        public Task<PlacesTextSearchResponse> TextSearchAsync(string location, Maxprice? maxPrice, Minprice? minprice, bool? opennow, string pagetoken, string query, double? radius, string type, Language? language, Region? region)
        {
            return TextSearchAsync(location, maxPrice, minprice, opennow, pagetoken, query, radius, type, language, region, CancellationToken.None);
        }


        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="location">The point around which to retrieve place information. This must be specified as `latitude,longitude`. 
        /// 
        /// &lt;div class="note"&gt;The &lt;code&gt;location&lt;/code&gt; parameter may be overriden if the &lt;code&gt;query&lt;/code&gt; contains an explicit location such as &lt;code&gt;Market in Barcelona&lt;/code&gt;. Using quotes around the query may also influence the weight given to the &lt;code&gt;location&lt;/code&gt; and &lt;code&gt;radius&lt;/code&gt;.&lt;/div&gt;</param>
        /// <param name="maxPrice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
        /// <param name="minprice">Restricts results to only those places within the specified range. Valid values range between 0 (most affordable) to 4 (most expensive), inclusive. The exact amount indicated by a specific value will vary from region to region.</param>
        /// <param name="opennow">Returns only those places that are open for business at the time the query is sent. Places that do not specify opening hours in the Google Places database will not be returned if you include this parameter in your query.</param>
        /// <param name="pagetoken">Returns up to 20 results from a previously run search. Setting a `pagetoken` parameter will execute a search with the same parameters used previously — all parameters other than pagetoken will be ignored.</param>
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
        public async Task<PlacesTextSearchResponse> TextSearchAsync(string location, Maxprice? maxPrice, Minprice? minprice, bool? opennow, string pagetoken, string query, double? radius, string type, Language? language, Region? region, CancellationToken cancellationToken)
        {
            if (query == null)
                throw new ArgumentNullException("query");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(_baseUrl != null ? _baseUrl.TrimEnd('/') : "").Append("/maps/api/place/textsearch/json?");
            if (location != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("location") + "=").Append(Uri.EscapeDataString(ConvertToString(location, CultureInfo.InvariantCulture))).Append("&");
            }
            if (maxPrice != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("maxPrice") + "=").Append(Uri.EscapeDataString(ConvertToString(maxPrice, CultureInfo.InvariantCulture))).Append("&");
            }
            if (minprice != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("minprice") + "=").Append(Uri.EscapeDataString(ConvertToString(minprice, CultureInfo.InvariantCulture))).Append("&");
            }
            if (opennow != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("opennow") + "=").Append(Uri.EscapeDataString(ConvertToString(opennow, CultureInfo.InvariantCulture))).Append("&");
            }
            if (pagetoken != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("pagetoken") + "=").Append(Uri.EscapeDataString(ConvertToString(pagetoken, CultureInfo.InvariantCulture))).Append("&");
            }
            urlBuilder_.Append(Uri.EscapeDataString("query") + "=").Append(Uri.EscapeDataString(ConvertToString(query, CultureInfo.InvariantCulture))).Append("&");
            if (radius != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("radius") + "=").Append(Uri.EscapeDataString(ConvertToString(radius, CultureInfo.InvariantCulture))).Append("&");
            }
            if (type != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("type") + "=").Append(Uri.EscapeDataString(ConvertToString(type, CultureInfo.InvariantCulture))).Append("&");
            }
            if (language != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("language") + "=").Append(Uri.EscapeDataString(ConvertToString(language, CultureInfo.InvariantCulture))).Append("&");
            }
            if (region != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("region") + "=").Append(Uri.EscapeDataString(ConvertToString(region, CultureInfo.InvariantCulture))).Append("&");
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
                            var objectResponse_ = await ReadObjectResponseAsync<PlacesTextSearchResponse>(response_, headers_).ConfigureAwait(false);
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }

                        return default(PlacesTextSearchResponse);
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

        private void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {

        }

        private void PrepareRequest(HttpClient client, HttpRequestMessage request, System.Text.StringBuilder urlBuilder)
        {

        }

        private void ProcessResponse(HttpClient client, HttpResponseMessage response)
        {

        }

        private string ConvertToString(object value, CultureInfo cultureInfo)
        {
            if (value is Enum)
            {
                string name = Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        var attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(EnumMemberAttribute))
                            as EnumMemberAttribute;
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
                    var typedBody = JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (JsonException exception)
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
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        var serializer = JsonSerializer.Create(JsonSerializerSettings);
                        var typedBody = serializer.Deserialize<T>(jsonTextReader);
                        return new ObjectResponseResult<T>(typedBody, string.Empty);
                    }
                }
                catch (JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        private bool ReadResponseAsString { get; set; }

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
    }
}
