using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class DanceRolConfiguration : IEntityTypeConfiguration<DanceRol>
    {
        public void Configure(EntityTypeBuilder<DanceRol> builder)
        {
            builder.HasKey(e => e.DanceRolId);
            builder.ToTable("DanceRol");
            builder.Property(e => e.DanceRolId)
                .HasColumnType("int")
                .HasColumnName("DanceRolId");

            builder.Property(e => e.Name)
              .HasColumnName("Name");

        }
    }
}
