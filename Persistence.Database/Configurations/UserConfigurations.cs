using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Persistence.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(e => e.UserId);

            builder.ToTable("Users");

            builder.Property(e => e.Name)
                .HasColumnName("Name");

            builder.Property(e => e.Pass)
                .HasColumnName("Pass");
         

        }
    }
}
