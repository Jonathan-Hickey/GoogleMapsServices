using System;
using GoogleMapsServices.Client.Serialization.SystemTextJson;
using Microsoft.Extensions.Options;

namespace GoogleMapsServices.Client.Tests.Infrastructure
{
    public class GoogleApiFixture : IDisposable
    {
        private readonly GoogleApiSimulator _googleApiSimulator;
        private readonly PlacesApiClient _placesApiClient;

        public GoogleApiFixture()
        {
            _googleApiSimulator = new GoogleApiSimulator();
            //_googleApiSimulator.Server.BaseAddress = new Uri("https://localhost/");
            var placesApiHttpClient = _googleApiSimulator.CreateClient();

            _placesApiClient = new PlacesApiClient(placesApiHttpClient, new GoogleClientOptions
            {
                BaseUrl = placesApiHttpClient.BaseAddress.AbsoluteUri,
            }, new JsonSerialization());
        }

        public PlacesApiClient GetPlacesApiClient()
        {
            return _placesApiClient;
        }

        public void Dispose()
        {
            _googleApiSimulator.Dispose();
        }
    }
}