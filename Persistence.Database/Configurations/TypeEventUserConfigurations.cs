using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class TypeEventUserConfiguration : IEntityTypeConfiguration<TypeEventUser>
    {
        public void Configure(EntityTypeBuilder<TypeEventUser> builder)
        {
            builder.HasKey(e => e.TypeEventUserId);
            builder.ToTable("TypeEventUser");
            builder.Property(e => e.TypeEventUserId)
                .HasColumnType("int")
                .HasColumnName("TypeEventUserId");

            builder.Property(e => e.TypeEventId)
              .HasColumnName("TypeEventId");
            builder.Property(e => e.UserId)
             .HasColumnName("UserId");

            builder.HasOne(e => e.User)
                .WithMany(typeEventUser => typeEventUser.TypeEventsUsers)
                .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.TypeEvent)
                .WithMany(typeEventUser => typeEventUser.TypeEventsUsers)
                .HasForeignKey(e => e.TypeEventId);
        }
    }
}
