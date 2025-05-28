using Xunit;

namespace misha_orlov_kt_42_22.Tests.IntegrationTests
{
    [CollectionDefinition("DbCollection")]
    public class DbCollection : ICollectionFixture<TestDbFixture>
    {
    }
}
