using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using misha_orlov_kt_42_22.Database;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly TeachersDbContext _context;

        public SubjectService(TeachersDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetSubjectsAsync(SubjectFilter filter)
        {
            var query = _context.Subjects.AsQueryable();

            if (filter.TeacherId.HasValue)
            {
                query = query.Where(s => s.Workloads.Any(w => w.TeacherId == filter.TeacherId.Value));
            }

            if (filter.MinHours.HasValue)
            {
                query = query.Where(s => s.Workloads.Any(w => w.Hours >= filter.MinHours.Value));
            }

            if (filter.MaxHours.HasValue)
            {
                query = query.Where(s => s.Workloads.Any(w => w.Hours <= filter.MaxHours.Value));
            }

            return await query.ToListAsync();
        }

        public async Task<Subject?> GetSubjectByIdAsync(int id)
        {
            return await _context.Subjects.FindAsync(id);
        }

        public async Task<Subject> AddSubjectAsync(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> UpdateSubjectAsync(Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
                return false;

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
