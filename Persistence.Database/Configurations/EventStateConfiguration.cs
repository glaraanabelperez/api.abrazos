using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class EventStateConfiguration : IEntityTypeConfiguration<EventState>
    {
        public void Configure(EntityTypeBuilder<EventState> builder)
        {
            builder.HasKey(e => e.EventStateId);
            builder.ToTable("EventState");
            builder.Property(e => e.EventStateId)
                .HasColumnType("int")
                .HasColumnName("EventStateId");

            builder.Property(e => e.Name)
              .HasColumnName("Name");
          
           
        }
    }
}
