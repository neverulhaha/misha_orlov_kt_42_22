using System.Collections.Generic;
using System.Threading.Tasks;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Services
{
    public class TeacherFilter
    {
        public int? DepartmentId { get; set; }
        public int? DegreeId { get; set; }
        public int? PositionId { get; set; }
    }

    public interface ITeacherService
    {
        Task<List<Teacher>> GetTeachersAsync(TeacherFilter filter);
        Task<Teacher?> GetTeacherByIdAsync(int id);
        Task<Teacher> AddTeacherAsync(Teacher teacher);
        Task<Teacher> UpdateTeacherAsync(Teacher teacher);
        Task<bool> DeleteTeacherAsync(int id);
    }
}
