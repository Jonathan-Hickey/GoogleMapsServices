using System;
using System.IO;
using System.Net.Http;
using GoogleMapsServices.Client.DependencyInjection;
using GoogleMapsServices.Client.Serialization;
using GoogleMapsServices.Client.Serialization.SystemTextJson;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace GoogleMapsServices.Client.Tests.Infrastructure
{
    public class GoogleApiFixture : IDisposable
    {
        private readonly GoogleApiSimulator _googleApiSimulator;
        private readonly ServiceProvider _serviceProvider;

        public GoogleApiFixture()
        {
            _googleApiSimulator = new GoogleApiSimulator();

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json", optional: false)
                .Build();

            var mockHttpClientFactory = new Mock<IHttpClientFactory>();

            var placesApiHttpClient = _googleApiSimulator.CreateClient();

            mockHttpClientFactory.Setup(x => x.CreateClient("PlacesApi"))
                .Returns(placesApiHttpClient);


            _serviceProvider = new ServiceCollection()
                .AddGoogleMapsServices(configuration)
                .RemoveAll<IHttpClientFactory>()
                .AddSingleton<IJsonSerialization, JsonSerialization>()
                .AddSingleton<IHttpClientFactory>(c => mockHttpClientFactory.Object )
                .BuildServiceProvider();
        }

        public IPlacesApiClient GetPlacesApiClient()
        {
            return _serviceProvider.GetRequiredService<IPlacesApiClient>();
        }

        public void Dispose()
        {
            _googleApiSimulator.Dispose();
        }
    }
}