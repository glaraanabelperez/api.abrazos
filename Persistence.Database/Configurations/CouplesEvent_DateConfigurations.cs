using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class CouplesEventDateConfiguration : IEntityTypeConfiguration<CouplesEvent_Date>
    {
        public void Configure(EntityTypeBuilder<CouplesEvent_Date> builder)
        {
            builder.HasKey(e => e.CouplesEventId);
            builder.ToTable("CouplesEvent_Date>");
            builder.Property(e => e.CouplesEventId)
                .HasColumnType("int")
                .HasColumnName("CouplesEventId");

            builder.Property(e => e.EventId_FK)
              .HasColumnName("EventId_FK");
            builder.Property(e => e.HostUserId_FK)
              .HasColumnName("HostUserId_FK");
            builder.Property(e => e.InvitedUserId_FK)
              .HasColumnName("InvitedUserId_FK");
            builder.Property(e => e.CouplesEventApproved)
              .HasColumnName("CouplesEventApproved");
            builder.Property(e => e.RequestAccepted)
              .HasColumnName("RequestAccepted");

            builder.HasOne(e => e.Evento)
                .WithMany(e => e.CouplesEvents)
                .HasForeignKey(e => e.EventId_FK);

            builder.HasOne(e => e.HostUser)
                .WithMany(e => e.CouplesEventsHost)
                .HasForeignKey(e => e.HostUserId_FK);

            builder.HasOne(e => e.InvitedUser)
                .WithMany(e => e.CouplesEventsInvited)
                .HasForeignKey(e => e.InvitedUserId_FK);
        }
    }
}
