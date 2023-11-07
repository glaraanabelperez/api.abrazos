using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class ProfileDancerConfiguration : IEntityTypeConfiguration<ProfileDancer>
    {
        public void Configure(EntityTypeBuilder<ProfileDancer> builder)
        {
            builder.HasKey(e => e.ProfileDanceId);
            builder.ToTable("ProfileDancer");
            builder.Property(e => e.ProfileDanceId)
                .HasColumnType("int")
                .HasColumnName("ProfileDanceId");

            builder.Property(e => e.DanceLevel_FK)
              .HasColumnName("DanceLevel_FK");
            builder.Property(e => e.DanceRol_FK)
             .HasColumnName("DanceRol_FK");
            builder.Property(e => e.Height)
             .HasColumnName("Height");

            builder.HasOne(e => e.DanceLevel)
                .WithMany()
                .HasForeignKey(e => e.DanceLevel_FK);
            builder.HasOne(e => e.DanceRol)
               .WithMany()
               .HasForeignKey(e => e.DanceRol_FK);

        }
    }
}
