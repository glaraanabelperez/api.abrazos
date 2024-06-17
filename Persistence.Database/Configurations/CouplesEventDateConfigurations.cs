using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class CouplesEventDateConfiguration : IEntityTypeConfiguration<CouplesEventDate>
    {
        public void Configure(EntityTypeBuilder<CouplesEventDate> builder)
        {
            builder.HasKey(e => e.CouplesEventId);
            builder.ToTable("CouplesEvent_Date>");
            builder.Property(e => e.CouplesEventId)
                .HasColumnType("int")
                .HasColumnName("CouplesEventId");

            builder.Property(e => e.EventId)
              .HasColumnName("EventId");
            builder.Property(e => e.HostUserId)
              .HasColumnName("HostUserId");
            builder.Property(e => e.InvitedUserId)
              .HasColumnName("InvitedUserId");
            builder.Property(e => e.CouplesEventApproved)
              .HasColumnName("CouplesEventApproved");
            builder.Property(e => e.RequestAccepted)
              .HasColumnName("RequestAccepted");

            builder.HasOne(e => e.Evento)
                .WithMany(e => e.CouplesEvents)
                .HasForeignKey(e => e.EventId);

            builder.HasOne(e => e.HostUser)
                .WithMany(e => e.CouplesEventsUserHost)
                .HasForeignKey(e => e.HostUserId);

            builder.HasOne(e => e.InvitedUser)
                .WithMany(e => e.CouplesEventsUserInivted)
                .HasForeignKey(e => e.InvitedUserId);
        }
    }
}
