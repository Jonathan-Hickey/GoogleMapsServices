using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using GoogleMapsServices.Client.Tests.Infrastructure;
using Xunit;

namespace GoogleMapsServices.Client.Tests
{
    [Collection("Google Api Fixture Collection")]
    public class PlacesApiFindPlaceTests
    {
        GoogleApiFixture _googleApiFixture;

        public PlacesApiFindPlaceTests(GoogleApiFixture googleApiFixture)
        {
            _googleApiFixture = googleApiFixture;
        }

        [Fact]
        public async Task Given_When_Then()
        {
            var placesApiClient =_googleApiFixture.GetPlacesApiClient();
            
            var fields = new List<string>()
            {
                "formatted_address",
                "name",
                "rating",
                "opening_hours",
                "geometry"
            };

            var input = "Museum of Contemporary Art Australia";

            var result = await placesApiClient.FindPlaceFromTextAsync(fields, input,Inputtype.Textquery, null, Language.EnGB, CancellationToken.None);

            result.Status.Should().Be(PlacesSearchStatus.OK);
        }
    }
}