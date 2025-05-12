using System.Collections.Generic;
using System.Threading.Tasks;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Services
{
    public class SubjectFilter
    {
        public int? TeacherId { get; set; }
        public int? MinHours { get; set; }
        public int? MaxHours { get; set; }
    }

    public interface ISubjectService
    {
        Task<List<Subject>> GetSubjectsAsync(SubjectFilter filter);
        Task<Subject?> GetSubjectByIdAsync(int id);
        Task<Subject> AddSubjectAsync(Subject subject);
        Task<Subject> UpdateSubjectAsync(Subject subject);
        Task<bool> DeleteSubjectAsync(int id);
    }
}
