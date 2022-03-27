using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using GoogleMapsServices.Client.Serialization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace GoogleMapsServices.Client
{
    internal class PlacesApiClient : IPlacesApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptionsMonitor<GoogleClientOptions> _googleClientOptions;
        
        private string _baseUrl;
        private readonly IJsonSerialization _jsonSerialization;

        public PlacesApiClient(IHttpClientFactory httpClientFactory, IOptionsMonitor<GoogleClientOptions> googleClientOptions, IJsonSerialization jsonSerialization)
        {
            _jsonSerialization = jsonSerialization;
            _httpClientFactory = httpClientFactory;
            _googleClientOptions = googleClientOptions;
            _baseUrl = _googleClientOptions.CurrentValue.BaseUrl;

            _googleClientOptions.OnChange(g =>
            {
                _baseUrl = g.BaseUrl;
            });
        }

        public async Task<PlacesFindPlaceFromTextResponse> FindPlaceFromTextAsync(IEnumerable<Field> fields, string input, Inputtype inputType, string locationBias, Language? language, CancellationToken cancellationToken)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            if (inputType == null)
                throw new ArgumentNullException("inputtype");

            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append(_baseUrl != null ? _baseUrl.TrimEnd('/') : "").Append("/maps/api/place/findplacefromtext/json?");
            
            if (fields != null)
            {
                foreach (var field in fields)
                {
                    urlBuilder_.Append("fields=").Append(field.GetUriEscapedValue()).Append("&");
                }
            }

            urlBuilder_.Append(Uri.EscapeDataString("input") + "=").Append(Uri.EscapeDataString(ConvertToString(input, CultureInfo.InvariantCulture))).Append("&");
            urlBuilder_.Append(Uri.EscapeDataString("inputtype") + "=").Append(Uri.EscapeDataString(ConvertToString(inputType, CultureInfo.InvariantCulture))).Append("&");
            if (locationBias != null)
            {
                urlBuilder_.Append("locationbias=").Append(Uri.EscapeDataString(ConvertToString(locationBias, CultureInfo.InvariantCulture))).Append("&");
            }
            if (language != null)
            {
                urlBuilder_.Append("language=").Append(language.LanguageCodeEscapeDataString()).Append("&");
            }
            urlBuilder_.Length--;

            var client_ = _httpClientFactory.CreateClient(HttpClientName.PlacesApi);
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

        public Task<PlacesNearbySearchResponse> NearbySearchAsync(string keyword, string location, Maxprice? maxprice, Minprice? minprice, string name, bool? opennow, string pagetoken, Rankby? rankby, double? radius, string type, Language? language)
        {
            return NearbySearchAsync(keyword, location, maxprice, minprice, name, opennow, pagetoken, rankby, radius, type, language, CancellationToken.None);
        }

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
                urlBuilder_.Append(Uri.EscapeDataString("minPrice") + "=").Append(Uri.EscapeDataString(ConvertToString(minprice, CultureInfo.InvariantCulture))).Append("&");
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
                urlBuilder_.Append(Uri.EscapeDataString("pageToken") + "=").Append(Uri.EscapeDataString(ConvertToString(pagetoken, CultureInfo.InvariantCulture))).Append("&");
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

            var client_ = _httpClientFactory.CreateClient(HttpClientName.PlacesApi);
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

        public Task<PlacesTextSearchResponse> TextSearchAsync(string location, Maxprice? maxPrice, Minprice? minPrice, bool? openNow, string pageToken, string query, double? radius, string type, Language? language, Region? region)
        {
            return TextSearchAsync(location, maxPrice, minPrice, openNow, pageToken, query, radius, type, language, region, CancellationToken.None);
        }

        public async Task<PlacesTextSearchResponse> TextSearchAsync(string location, Maxprice? maxPrice, Minprice? minPrice, bool? openNow, string pageToken, string query, double? radius, string type, Language? language, Region? region, CancellationToken cancellationToken)
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
            if (minPrice != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("minprice") + "=").Append(Uri.EscapeDataString(ConvertToString(minPrice, CultureInfo.InvariantCulture))).Append("&");
            }
            if (openNow != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("opennow") + "=").Append(Uri.EscapeDataString(ConvertToString(openNow, CultureInfo.InvariantCulture))).Append("&");
            }
            if (pageToken != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("pagetoken") + "=").Append(Uri.EscapeDataString(ConvertToString(pageToken, CultureInfo.InvariantCulture))).Append("&");
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

            var client_ = _httpClientFactory.CreateClient(HttpClientName.PlacesApi);
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
                    var typedBody = _jsonSerialization.DeserializeFromSnakeCase<T>(responseText);
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
                    {
                        var typedBody = await _jsonSerialization.DeserializeFromSnakeCase<T>(responseStream);
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
            public ObjectResponseResult(T? responseObject, string responseText)
            {
                Object = responseObject;
                Text = responseText;
            }

            public T? Object { get; }

            public string Text { get; }
        }
    }
}
