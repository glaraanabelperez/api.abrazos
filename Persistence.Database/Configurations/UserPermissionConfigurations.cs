using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.HasKey(e => e.UserPermissionId);
            builder.ToTable("UserPermissions");
            builder.Property(e => e.UserPermissionId)
                .HasColumnType("int")
                .HasColumnName("UserPermissionId");

            builder.Property(e => e.PermissionId)
              .HasColumnName("PermissionId");

            builder.Property(e => e.UserId)
                .HasColumnName("UserId");

            builder.HasOne(u => u.User)
                .WithMany(up => up.UserPermissions)
                .HasForeignKey(u => u.UserId);

            builder.HasOne(u => u.Permission)
                .WithMany(up => up.UserPermissions)
                .HasForeignKey(u => u.PermissionId);


        }
    }
}
