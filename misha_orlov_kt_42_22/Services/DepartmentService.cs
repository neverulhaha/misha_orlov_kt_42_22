using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using misha_orlov_kt_42_22.Database;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Services
{
    public class DepartmentFilter
    {
        public DateTime? FoundedAfter { get; set; } = new DateTime(1999, 4, 28, 9, 15, 5, 983, DateTimeKind.Utc);
        public DateTime? FoundedBefore { get; set; } = new DateTime(2025, 4, 28, 9, 15, 5, 983, DateTimeKind.Utc);
        public int? MinTeachersCount { get; set; }
        public int? MaxTeachersCount { get; set; }
    }

    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartmentsAsync(DepartmentFilter filter);
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<Department> AddDepartmentAsync(Department department);
        Task<Department> UpdateDepartmentAsync(Department department);
        Task<bool> DeleteDepartmentAsync(int id);
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly TeachersDbContext _context;

        public DepartmentService(TeachersDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetDepartmentsAsync(DepartmentFilter filter)
        {
            var query = _context.Departments
                .Include(d => d.Head) // заведующий кафедрой
                .Include(d => d.Teachers) // преподаватели кафедры
                .AsQueryable();

            if (filter.FoundedAfter.HasValue)
            {
                query = query.Where(d => d.FoundationDate >= filter.FoundedAfter.Value);
            }
            if (filter.FoundedBefore.HasValue)
            {
                query = query.Where(d => d.FoundationDate <= filter.FoundedBefore.Value);
            }
            if (filter.MinTeachersCount.HasValue)
            {
                query = query.Where(d => d.Teachers.Count >= filter.MinTeachersCount.Value);
            }
            if (filter.MaxTeachersCount.HasValue)
            {
                query = query.Where(d => d.Teachers.Count <= filter.MaxTeachersCount.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments
                .Include(d => d.Head)
                .Include(d => d.Teachers)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments
                .Include(d => d.Teachers)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (department == null)
                return false;

            // Удаляем связанных преподавателей
            _context.Teachers.RemoveRange(department.Teachers);

            // Удаляем кафедру
            _context.Departments.Remove(department);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
