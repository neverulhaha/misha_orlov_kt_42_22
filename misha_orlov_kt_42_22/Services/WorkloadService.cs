using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using misha_orlov_kt_42_22.Database;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Services
{
    public class WorkloadService : IWorkloadService
    {
        private readonly TeachersDbContext _context;

        public WorkloadService(TeachersDbContext context)
        {
            _context = context;
        }

        public async Task<List<Workload>> GetWorkloadsAsync(WorkloadFilter filter)
        {
            var query = _context.Workloads
                .Include(w => w.Teacher)
                .ThenInclude(t => t.Department)
                .Include(w => w.Subject)
                .AsQueryable();

            if (filter.TeacherId.HasValue)
            {
                query = query.Where(w => w.TeacherId == filter.TeacherId.Value);
            }

            if (filter.SubjectId.HasValue)
            {
                query = query.Where(w => w.SubjectId == filter.SubjectId.Value);
            }

            if (filter.DepartmentId.HasValue)
            {
                query = query.Where(w => w.Teacher != null && w.Teacher.DepartmentId == filter.DepartmentId.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<Workload?> GetWorkloadByIdAsync(int id)
        {
            return await _context.Workloads
                .Include(w => w.Teacher)
                .Include(w => w.Subject)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<Workload> AddWorkloadAsync(Workload workload)
        {
            _context.Workloads.Add(workload);
            await _context.SaveChangesAsync();
            return workload;
        }

        public async Task<Workload> UpdateWorkloadAsync(Workload workload)
        {
            _context.Workloads.Update(workload);
            await _context.SaveChangesAsync();
            return workload;
        }
    }
}
