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
                .HasColumnName("ProfileDancerId");

            builder.Property(e => e.DanceLevelId)
              .HasColumnName("DanceLevelId");

            builder.Property(e => e.DanceRolId)
             .HasColumnName("DanceRolId");

            builder.Property(e => e.DanceId)
              .HasColumnName("DanceId");

            builder.Property(e => e.UserId)
              .HasColumnName("UserId");


            builder.HasOne(e => e.DanceLevel)
                .WithMany()
                .HasForeignKey(e => e.DanceLevelId);

            builder.HasOne(e => e.DanceRol)
               .WithMany()
               .HasForeignKey(e => e.DanceRolId);

            builder.HasOne(e => e.User)
               .WithMany(prof => prof.ProfileDancer)
               .HasForeignKey(e => e.UserId);

            builder.HasOne(x => x.Dance)
                .WithMany(e => e.ProfileDancers)
                .HasForeignKey(x => x.DanceId);

        }
    }
}
