using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(e => e.AddressId);
            builder.ToTable("Address");
            builder.Property(e => e.AddressId)
                .HasColumnType("int")
                .HasColumnName("AddressId");
            builder.Property(e => e.UserId)
              .HasColumnName("UserId");
            builder.Property(e => e.CityId)
              .HasColumnName("CityId");
            builder.Property(e => e.StateAddress)
              .HasColumnName("StateAddress");
            builder.Property(e => e.Number)
              .HasColumnName("Number");
            builder.Property(e => e.Street)
              .HasColumnName("Street");
            builder.Property(e => e.VenueName)
             .HasColumnName("VenueName");
            builder.Property(e => e.DetailAddress)
               .HasColumnName("DetailAddress");

            builder.HasOne(e => e.City)
            .WithMany(e => e.Address)
            .HasForeignKey(e => e.CityId);

            //builder.HasMany(e => e.Events)
            //.WithOne(e => e.Address)
            //.HasForeignKey(e => e.AddressId);
        }
    }
}
