using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(e => e.PermissionId);
            builder.ToTable("Permissions");
            builder.Property(e => e.PermissionId)
                .HasColumnType("int")
                .HasColumnName("PermissionId");

            builder.Property(e => e.Name)
              .HasColumnName("Name");
          
        }
    }
}
