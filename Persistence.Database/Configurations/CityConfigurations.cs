using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(e => e.CityId);
            builder.ToTable("City");
            builder.Property(e => e.CityId)
                .HasColumnType("int")
                .HasColumnName("CityId");
        
            builder.Property(e => e.CityName)
              .HasColumnName("CityName");
            builder.Property(e => e.StateName)
              .HasColumnName("StateName");

            builder.HasOne(e => e.Country)
          .WithMany(e => e.Cities)
          .HasForeignKey(e => e.CountryId);

            builder.HasMany(e => e.Address)
         .WithOne(e => e.City)
         .HasForeignKey(e => e.CityId);

        }
    }
}
