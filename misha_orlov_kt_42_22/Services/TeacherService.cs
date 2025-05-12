using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using misha_orlov_kt_42_22.Database;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly TeachersDbContext _context;

        public TeacherService(TeachersDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetTeachersAsync(TeacherFilter filter)
        {
            var query = _context.Teachers
                .Include(t => t.Department)
                .Include(t => t.Degree)
                .Include(t => t.Position)
                .AsQueryable();

            if (filter.DepartmentId.HasValue)
            {
                query = query.Where(t => t.DepartmentId == filter.DepartmentId.Value);
            }
            if (filter.DegreeId.HasValue)
            {
                query = query.Where(t => t.DegreeId == filter.DegreeId.Value);
            }
            if (filter.PositionId.HasValue)
            {
                query = query.Where(t => t.PositionId == filter.PositionId.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<Teacher?> GetTeacherByIdAsync(int id)
        {
            return await _context.Teachers
                .Include(t => t.Department)
                .Include(t => t.Degree)
                .Include(t => t.Position)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Teacher> AddTeacherAsync(Teacher teacher)
        {
            teacher.Id = 0; // reset id for new entity
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> UpdateTeacherAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                return false;

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
