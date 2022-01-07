using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace GoogleMapsServices.Client.Tests.Infrastructure
{
    class GoogleApiSimulator : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
           
            });
            
            return base.CreateHost(builder);
        }
    }
}
