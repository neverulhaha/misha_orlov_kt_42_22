using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Database.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new Subject { Id = 1, Name = "Программирование" },
                new Subject { Id = 2, Name = "Алгебра" },
                new Subject { Id = 3, Name = "Физика" }
            );
        }
    }
}