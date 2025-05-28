using Xunit;
using misha_orlov_kt_42_22.Database;
using misha_orlov_kt_42_22.Services;
using System.Threading.Tasks;

namespace misha_orlov_kt_42_22.Tests.IntegrationTests
{
    [Collection("DbCollection")]
    public class Department2ServiceTests
    {
        private readonly TeachersDbContext _ctx;

        public Department2ServiceTests(TestDbFixture fixture)
        {
            _ctx = fixture.Context;
        }

        [Fact]
        public async Task GetDepartmentsByPositionAsync_Доцент_ОжидаетсяОднаКафедра()
        {
            var service = new Department2Service(_ctx);
            var result = await service.GetDepartmentsByPositionAsync("Доцент");
            Assert.Equal(1, result.Count);
        }
    }
}
