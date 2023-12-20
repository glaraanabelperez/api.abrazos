using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(e => e.CountryId);
            builder.ToTable("Country");
            builder.Property(e => e.CountryId)
                .HasColumnType("int")
                .HasColumnName("CountryId");
            builder.Property(e => e.Name)
              .HasColumnName("Name");

            //builder.HasMany(e => e.Cities)
            // .WithOne(e => e.Country)
            // .HasForeignKey(e => e.CountryId_FK);
        }
    }
}
