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
            builder.Property(e => e.UserIdCreator)
             .HasColumnName("UserIdCreator");

            builder.Property(e => e.Description)
            .HasColumnName("Description");

            builder.Property(e => e.AddressId)
            .HasColumnName("AddressId");

            builder.Property(e => e.Image)
            .HasColumnName("Image");
            builder.Property(e => e.DateInit)
            .HasColumnName("DateInit");
            builder.Property(e => e.DateFinish)
            .HasColumnName("DateFinish");

            builder.Property(e => e.EventStateId)
            .HasColumnName("EventStateId");

            builder.Property(e => e.TypeEventId)
           .HasColumnName("TypeEventId");

            builder.Property(e => e.Couple)
           .HasColumnName("Couple");

            builder.Property(e => e.Cupo)
           .HasColumnName("cupo");

            builder.Property(e => e.LevelId)
           .HasColumnName("LevelId");

            builder.Property(e => e.RolId)
           .HasColumnName("RolId");

            builder.Property(e => e.CycleId)
          .HasColumnName("CycleId");


            builder.HasOne(w => w.Address)
                    .WithMany(e => e.Events)
                    .HasForeignKey(e=> e.AddressId);

            builder.HasOne(w => w.UserCreator)
                    .WithMany(e => e.EventsCreated)
                    .HasForeignKey(w => w.UserIdCreator);

            builder.HasOne(e => e.TypeEvent)
               .WithMany(Events => Events.events)
               .HasForeignKey(Event => Event.TypeEventId);

            builder.HasOne(e => e.EventState)
              .WithMany(e => e.Events)
              .HasForeignKey(e => e.EventStateId);

            builder.HasMany(e => e.CouplesEvents)
             .WithOne(e => e.Evento)
             .HasForeignKey(e => e.EventId);

            builder.HasOne(ce => ce.Cycle)
             .WithMany(c => c.Events)
             .HasForeignKey(c => c.CycleId);

            builder.HasOne(ce => ce.Level)
          .WithMany(c => c.Events)
          .HasForeignKey(c => c.LevelId);

            builder.HasOne(ce => ce.Rol)
          .WithMany(c => c.Events)
          .HasForeignKey(c => c.RolId);

        }
    }
}
