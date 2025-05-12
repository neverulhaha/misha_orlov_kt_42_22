using Microsoft.EntityFrameworkCore;
using misha_orlov_kt_42_22.Models;
using misha_orlov_kt_42_22.Database.Configurations;

namespace misha_orlov_kt_42_22.Database
{
    public class TeachersDbContext : DbContext
    {
        public DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Workload> Workloads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());

        }
        public TeachersDbContext(DbContextOptions<TeachersDbContext> options) : base(options)
        {

        }
    }
}