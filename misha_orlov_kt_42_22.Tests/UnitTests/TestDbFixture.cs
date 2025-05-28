using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using misha_orlov_kt_42_22.Database;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Tests.IntegrationTests
{
    public class TestDbFixture : IDisposable
    {
        public TeachersDbContext Context { get; }

        public TestDbFixture()
        {
            var options = new DbContextOptionsBuilder<TeachersDbContext>()
                .UseInMemoryDatabase("Tests")
                .Options;

            Context = new TeachersDbContext(options);

            if (!Context.Teachers.Any())
            {
                var department = new Department { Id = 1, Name = "1" };
                var department2 = new Department { Id = 2, Name = "2" };
                var position = new Position { Id = 1, PositionName = "Профессор" };
                var position2 = new Position { Id = 2, PositionName = "Доцент" };

                var teacher = new Teacher
                {
                    Id = 1,
                    Surname = "Иванов",
                    Name = "Иван",
                    Patronymic = "Иванович",
                    PositionId = 2,
                    DepartmentId = 1
                };
                var teacher2 = new Teacher
                {
                    Id = 2,
                    Surname = "Петров",
                    Name = "Иван",
                    Patronymic = "Иванович",
                    PositionId = 1,
                    DepartmentId = 2
                };
                var teacher3 = new Teacher
                {
                    Id = 3,
                    Surname = "Сидоров",
                    Name = "Иван",
                    Patronymic = "Иванович",
                    PositionId = 1,
                    DepartmentId = 2
                };

                Context.Departments.AddRange(department, department2);
                Context.Positions.AddRange(position, position2);
                Context.Teachers.AddRange(teacher, teacher2, teacher3);
                Context.SaveChanges();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
