using Xunit;

namespace GoogleMapsServices.Client.Tests.Infrastructure;

[CollectionDefinition("Google Api Fixture Collection")]
public class GoogleApiFixtureCollection : ICollectionFixture<GoogleApiFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}