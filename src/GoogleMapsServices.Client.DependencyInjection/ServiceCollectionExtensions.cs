using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoogleMapsServices.Client.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGoogleMapsServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddHttpClient(HttpClientName.PlacesApi);

            serviceCollection.AddOptions<GoogleClientOptions>()
                .Bind(configuration.GetSection("GoogleClient"));

            serviceCollection.AddSingleton<IPlacesApiClient, PlacesApiClient>();
            return serviceCollection;
        }
    }
}