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
            
            var fields = new List<Field>()
            {
                Field.Basic.FormattedAddress,
                Field.Basic.Name,
                Field.Atmosphere.Rating,
                Field.Contact.OpeningHours,
                Field.Basic.Geometry,
            };

            var input = "Museum of Contemporary Art Australia";

            var result = await placesApiClient.FindPlaceFromTextAsync(fields, input, Inputtype.Textquery, null, Language.EnglishGreatBritain, CancellationToken.None);

            result.Status.Should().Be(PlacesSearchStatus.OK);
        }
    }
}