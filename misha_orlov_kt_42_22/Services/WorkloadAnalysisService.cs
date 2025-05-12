using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using misha_orlov_kt_42_22.Database;
using misha_orlov_kt_42_22.Models;
using misha_orlov_kt_42_22.Services.Filters;

namespace misha_orlov_kt_42_22.Services
{
    public class WorkloadAnalysisService : IWorkloadAnalysisService
    {
        private readonly TeachersDbContext _context;

        public WorkloadAnalysisService(TeachersDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentWorkloadSummary>> GetDepartmentWorkloadSummaryAsync(WorkloadAnalysisFilter filter)
        {
            var query = _context.Departments
                .Include(d => d.Teachers)
                .ThenInclude(t => t.Workloads)
                .AsQueryable();

            if (filter.DepartmentFoundedAfter.HasValue)
            {
                query = query.Where(d => d.FoundationDate >= filter.DepartmentFoundedAfter.Value);
            }

            if (filter.DepartmentFoundedBefore.HasValue)
            {
                query = query.Where(d => d.FoundationDate <= filter.DepartmentFoundedBefore.Value);
            }

            if (filter.MinTeachersCount.HasValue)
            {
                query = query.Where(d => d.Teachers.Count >= filter.MinTeachersCount.Value);
            }

            if (filter.MaxTeachersCount.HasValue)
            {
                query = query.Where(d => d.Teachers.Count <= filter.MaxTeachersCount.Value);
            }

            var departments = await query.ToListAsync();

            var result = departments.Select(d =>
            {
                var totalHours = d.Teachers.SelectMany(t => t.Workloads).Sum(w => w.Hours);
                var subjectsCount = d.Teachers.SelectMany(t => t.Workloads).Select(w => w.SubjectId).Distinct().Count();

                return new DepartmentWorkloadSummary
                {
                    DepartmentId = d.Id,
                    DepartmentName = d.Name,
                    TotalHours = totalHours,
                    SubjectsCount = subjectsCount
                };
            }).ToList();

            if (filter.MinHours.HasValue)
            {
                result = result.Where(r => r.TotalHours >= filter.MinHours.Value).ToList();
            }

            if (filter.MaxHours.HasValue)
            {
                result = result.Where(r => r.TotalHours <= filter.MaxHours.Value).ToList();
            }

            return result;
        }
    }
}
