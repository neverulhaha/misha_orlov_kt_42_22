using System.Collections.Generic;
using System.Threading.Tasks;
using misha_orlov_kt_42_22.Models;
using misha_orlov_kt_42_22.Services.Filters;

namespace misha_orlov_kt_42_22.Services
{
    public interface ITeacherSearchService
    {
        Task<List<Teacher>> SearchTeachersAsync(TeacherSearchFilter filter);
    }
}
