using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Surname)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(t => t.Patronymic)
                .HasMaxLength(50);

            builder.HasData(
                new Teacher { Id = 1, Surname = "Иванов", Name = "Иван", Patronymic = "Иванович", DepartmentId = 1, DegreeId = 1, PositionId = 1 },
                new Teacher { Id = 2, Surname = "Петров", Name = "Пётр", Patronymic = "Петрович", DepartmentId = null, DegreeId = null, PositionId = null },
                new Teacher { Id = 3, Surname = "Сидоров", Name = "Сидор", Patronymic = "Сидорович", DepartmentId = null, DegreeId = null, PositionId = null }
            );
        }
    }
}