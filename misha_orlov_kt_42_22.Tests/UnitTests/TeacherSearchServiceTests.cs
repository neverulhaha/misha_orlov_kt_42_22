using Xunit;
using misha_orlov_kt_42_22.Database;
using misha_orlov_kt_42_22.Services;
using misha_orlov_kt_42_22.Services.Filters;
using System.Threading.Tasks;

namespace misha_orlov_kt_42_22.Tests.IntegrationTests
{
    [Collection("DbCollection")]
    public class TeacherSearchServiceTests
    {
        private readonly TeachersDbContext _ctx;

        public TeacherSearchServiceTests(TestDbFixture fixture)
        {
            _ctx = fixture.Context;
        }

        [Fact]
        public async Task SearchTeachersAsync_PositionId2_ОжидаетсяОдинПреподаватель()
        {
            var service = new TeacherSearchService(_ctx);
            var filter = new TeacherSearchFilter { DepartmentId = 2 };
            var result = await service.SearchTeachersAsync(filter);

            Assert.Equal(2, result.Count);
        }
    }
}
