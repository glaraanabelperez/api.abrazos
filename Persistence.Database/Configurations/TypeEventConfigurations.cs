using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class TypeEventConfiguration : IEntityTypeConfiguration<TypeEvent>
    {
        public void Configure(EntityTypeBuilder<TypeEvent> builder)
        {
            builder.HasKey(e => e.TypeEventId);
            builder.ToTable("TypeEvent");
            builder.Property(e => e.TypeEventId)
                .HasColumnType("int")
                .HasColumnName("TypeEventId");

            builder.Property(e => e.UserId_FK)
              .HasColumnName("UserId_FK");

            builder.HasMany(e => e.TypeEventsUsers)
                .WithOne(TyEvent => TyEvent.TypeEvent)
                .HasForeignKey(e => e.TypeEventId_FK);


        }
    }
}
