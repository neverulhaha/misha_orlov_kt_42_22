using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using misha_orlov_kt_42_22.Models;

namespace misha_orlov_kt_42_22.Database.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PositionName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new Position { Id = 1, PositionName = "Профессор" },
                new Position { Id = 2, PositionName = "Доцент" },
                new Position { Id = 3, PositionName = "Ассистент" }
            );
        }
    }
}