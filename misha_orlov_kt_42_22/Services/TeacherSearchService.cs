using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using misha_orlov_kt_42_22.Database;
using misha_orlov_kt_42_22.Models;
using misha_orlov_kt_42_22.Services.Filters;

namespace misha_orlov_kt_42_22.Services
{
    public class TeacherSearchService : ITeacherSearchService
    {
        private readonly TeachersDbContext _context;

        public TeacherSearchService(TeachersDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> SearchTeachersAsync(TeacherSearchFilter filter)
        {
            var query = _context.Teachers
                .Include(t => t.Department)
                .Include(t => t.Position)
                .Include(t => t.Degree)
                .Include(t => t.Workloads)
                .AsQueryable();

            if (filter.DepartmentId.HasValue)
            {
                query = query.Where(t => t.DepartmentId == filter.DepartmentId.Value);
            }

            if (filter.PositionId.HasValue)
            {
                query = query.Where(t => t.PositionId == filter.PositionId.Value);
            }

            if (filter.DegreeId.HasValue)
            {
                query = query.Where(t => t.DegreeId == filter.DegreeId.Value);
            }

            if (filter.SubjectId.HasValue)
            {
                query = query.Where(t => t.Workloads.Any(w => w.SubjectId == filter.SubjectId.Value));
            }

            if (filter.MinWorkloadHours.HasValue)
            {
                query = query.Where(t => t.Workloads.Sum(w => w.Hours) >= filter.MinWorkloadHours.Value);
            }

            if (filter.MaxWorkloadHours.HasValue)
            {
                query = query.Where(t => t.Workloads.Sum(w => w.Hours) <= filter.MaxWorkloadHours.Value);
            }

            return await query.ToListAsync();
        }
    }
}
