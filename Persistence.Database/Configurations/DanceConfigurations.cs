using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class DanceConfiguration : IEntityTypeConfiguration<Dance>
    {
        public void Configure(EntityTypeBuilder<Dance> builder)
        {
            builder.HasKey(e => e.DanceId);
            builder.ToTable("Dance");
            builder.Property(e => e.DanceId)
                .HasColumnType("int")
                .HasColumnName("DanceId");

            builder.Property(e => e.Name)
              .HasColumnName("Name");

            builder.HasMany(x=> x.ProfileDancers)
                 .WithOne(e => e.Dance)
                 .HasForeignKey(x => x.DanceId);



        }
    }
}
