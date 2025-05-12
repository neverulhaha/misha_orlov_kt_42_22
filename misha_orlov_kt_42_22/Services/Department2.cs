using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using misha_orlov_kt_42_22.Database;

namespace misha_orlov_kt_42_22.Services
{
    public interface IDepartment2Service
    {
        Task<List<string>> GetDepartmentsByPositionAsync(string positionName);
    }

    public class Department2Service : IDepartment2Service
    {
        private readonly TeachersDbContext _context;

        public Department2Service(TeachersDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> GetDepartmentsByPositionAsync(string positionName)
        {
            if (string.IsNullOrWhiteSpace(positionName))
            {
                throw new ArgumentException("Название должности обязательно", nameof(positionName));
            }

            return await (from department in _context.Departments
                          join teacher in _context.Teachers on department.Id equals teacher.DepartmentId
                          join position in _context.Positions on teacher.PositionId equals position.Id
                          where position.PositionName.Contains(positionName)
                          select department.Name)
                         .Distinct()
                         .ToListAsync();
        }
    }
}
