using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class TypeEvent_UserConfiguration : IEntityTypeConfiguration<TypeEvent_User>
    {
        public void Configure(EntityTypeBuilder<TypeEvent_User> builder)
        {
            builder.HasKey(e => e.TypeEventUserId);
            builder.ToTable("TypeEvent_User");
            builder.Property(e => e.TypeEventUserId)
                .HasColumnType("int")
                .HasColumnName("TypeEventUserId");

            builder.Property(e => e.TypeEventId_FK)
              .HasColumnName("TypeEventId_FK");
            builder.Property(e => e.UserId_FK)
             .HasColumnName("UserId_FK");

            builder.HasOne(e => e.User)
                .WithMany(typeEventUser => typeEventUser.TypeEventsUsers)
                .HasForeignKey(e => e.User.UserId);

            builder.HasOne(e => e.TypeEvent)
                .WithMany(typeEventUser => typeEventUser.TypeEventsUsers)
                .HasForeignKey(e => e.TypeEvent.TypeEventId);
        }
    }
}
