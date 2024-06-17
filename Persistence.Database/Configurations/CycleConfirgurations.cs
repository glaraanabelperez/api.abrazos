using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class CycleConfiguration : IEntityTypeConfiguration<Cycle>
    {
        public void Configure(EntityTypeBuilder<Cycle> builder)
        {
            builder.HasKey(e => e.CycleId);
            builder.ToTable("Cycle");
            builder.Property(e => e.CycleId)
                .HasColumnType("int")
                .HasColumnName("CycleId");

            builder.Property(e => e.CycleTitle)
              .HasColumnName("CycleTitle");

            builder.Property(e => e.Description)
             .HasColumnName("CycleDescription");


        }
    }
}