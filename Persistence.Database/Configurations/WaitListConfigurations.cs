using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class WaitListConfiguration : IEntityTypeConfiguration<WaitList>
    {
        public void Configure(EntityTypeBuilder<WaitList> builder)
        {
            builder.HasKey(e => e.WaitListId);
            builder.ToTable("WaitList");
            builder.Property(e => e.WaitListId)
                .HasColumnType("int")
                .HasColumnName("WaitListId");

            builder.Property(e => e.UserId_FK)
              .HasColumnName("UserId_FK");
            builder.Property(e => e.EventId_FK)
                .HasColumnName("EventId_FK");
            builder.Property(e => e.State)
                .HasColumnName("State");

            //builder.HasOne(e => e.Event)
            //    .WithMany(w => w.WaitLists)
            //    .HasForeignKey(e => e.EventId_FK);

            //builder.HasOne(e => e.User)
            //    .WithMany(w => w.WaitLists)
            //    .HasForeignKey(e => e.UserId_FK);
        }
    }
}
