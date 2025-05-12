using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Database.Configurations
{
    public class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
    {
        public void Configure(EntityTypeBuilder<Workload> builder)
        {
            builder.ToTable("Workloads");
            builder.HasKey(w => w.Id);
            builder.HasOne(w => w.Teacher).WithMany(t => t.Workloads).HasForeignKey(w => w.TeacherId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(w => w.Subject).WithMany(s => s.Workloads).HasForeignKey(w => w.SubjectId).OnDelete(DeleteBehavior.SetNull);
            builder.Property(w => w.Hours).IsRequired().HasDefaultValue(0);
            builder.HasIndex(w => new { w.TeacherId, w.SubjectId }).IsUnique().HasFilter("[TeacherId] IS NOT NULL AND [SubjectId] IS NOT NULL");

            builder.HasData(
            new Workload { Id = 1, TeacherId = 1, SubjectId = 1, Hours = 40 },
            new Workload { Id = 2, TeacherId = 2, SubjectId = 2, Hours = 30 },
            new Workload { Id = 3, TeacherId = 3, SubjectId = 3, Hours = 20 }
        );
        }
    }
}