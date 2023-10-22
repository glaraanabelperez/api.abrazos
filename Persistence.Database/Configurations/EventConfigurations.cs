using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.EventId);
            builder.ToTable("Event");
            builder.Property(e => e.EventId)
                .HasColumnType("int")
                .HasColumnName("EventId");

            builder.Property(e => e.Name)
              .HasColumnName("Name");
            builder.Property(e => e.UserIdCreator_FK)
             .HasColumnName("UserIdCreator_FK");

            builder.Property(e => e.Description)
            .HasColumnName("Description");

            builder.Property(e => e.AddressId_fk)
            .HasColumnName("AddressId_fk");

            builder.Property(e => e.Image)
            .HasColumnName("Image");
            builder.Property(e => e.DateInit)
            .HasColumnName("DateInit");
            builder.Property(e => e.DateFinish)
            .HasColumnName("DateFinish");

            builder.Property(e => e.EventStateId_fk)
            .HasColumnName("EventStateId_fk");

            builder.Property(e => e.TypeEventId_fk)
           .HasColumnName("TypeEventId_fk");

            builder.HasOne(e => e.TypeEvent)
                .WithMany(Events => Events.Events)
                .HasForeignKey(e => e.TypeEvent.TypeEventId);

            builder.HasOne(e => e.UserCreator)
                .WithMany(Events => Events.Events)
                .HasForeignKey(e => e.UserIdCreator_FK);

            builder.HasMany(w => w.WaitLists)
                .WithOne(e => e.Event)
                .HasForeignKey(w => w.EventId_FK);

            builder.HasOne(e => e.Address)
               .WithMany(Events => Events.Events)
               .HasForeignKey(Event => Event.AddressId_fk);

        }
    }
}
