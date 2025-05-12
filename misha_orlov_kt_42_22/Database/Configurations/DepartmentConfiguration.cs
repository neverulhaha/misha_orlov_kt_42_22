using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name).IsRequired().HasMaxLength(150);
            builder.Property(d => d.FoundationDate).HasColumnType("date");
            builder.HasOne(d => d.Head).WithOne().HasForeignKey<Department>(d => d.HeadId).OnDelete(DeleteBehavior.SetNull);
            builder.HasIndex(d => d.Name).IsUnique();

            builder.HasData(
            new Department
            {
                Id = 1,
                Name = "Кафедра информатики",
                FoundationDate = new DateTime(2000, 1, 1),
                HeadId = null
            },
            new Department
            {
                Id = 2,
                Name = "Кафедра математики",
                FoundationDate = new DateTime(2005, 5, 15),
                HeadId = null
            },
            new Department
            {
                Id = 3,
                Name = "Кафедра физики",
                FoundationDate = new DateTime(2010, 9, 1),
                HeadId = null
            }
        );
        }
    }
}