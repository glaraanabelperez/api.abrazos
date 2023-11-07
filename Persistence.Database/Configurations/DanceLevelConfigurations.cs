using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class DanceLevelConfiguration : IEntityTypeConfiguration<DanceLevel>
    {
        public void Configure(EntityTypeBuilder<DanceLevel> builder)
        {
            builder.HasKey(e => e.DanceLevelId);
            builder.ToTable("DanceLevel");
            builder.Property(e => e.DanceLevelId)
                .HasColumnType("int")
                .HasColumnName("DanceLevelId");

            builder.Property(e => e.Name)
              .HasColumnName("Name");


        }
    }
}
