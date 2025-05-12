using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Database.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            builder.ToTable("AcademicDegrees");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.DegreeName).IsRequired().HasMaxLength(100);
            builder.HasIndex(a => a.DegreeName).IsUnique();

            builder.HasData(
                new AcademicDegree { Id = 1, DegreeName = "Доктор наук" },
                new AcademicDegree { Id = 2, DegreeName = "Кандидат наук" }
            );
        }
    }
}