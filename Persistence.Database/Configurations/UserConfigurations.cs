using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);
            builder.ToTable("Users");
            builder.Property(e => e.UserId)
                .HasColumnType("int")
                .HasColumnName("UserId");

            builder.Property(e => e.Name)
              .HasColumnName("Name");

            builder.Property(e => e.LastName)
              .HasColumnName("LastName");

            builder.Property(e => e.UserName)
              .HasColumnName("UserName");

            builder.Property(e => e.UserIdFirebase)
              .HasColumnName("UserIdFirebase");

            builder.Property(e => e.Email)
              .HasColumnName("Email");

            builder.Property(e => e.Age)
              .HasColumnName("Age");

            builder.Property(e => e.Celphone)
              .HasColumnName("Celphone");

            builder.Property(e => e.AvatarImage)
              .HasColumnName("AvatarImage");

            builder.Property(e => e.Description)
              .HasColumnName("Description");

            builder.Property(e => e.UserState)
                .HasColumnName("UserState");

            builder.Property(e => e.Height)
                .HasColumnName("Height");

            builder.HasMany(e => e.Address)
                .WithOne()
                .HasForeignKey(e => e.UserId);


            builder.HasMany(e => e.Images)
                .WithOne()
                .HasForeignKey(e => e.UserId);


            builder.HasMany(e => e.UserPermissions)
                .WithOne(u => u.User)
                .HasForeignKey(e => e.UserId);


            builder.HasMany(e => e.TypeEventsUsers)
                .WithOne(user => user.User)
                .HasForeignKey(e => e.UserId);


            //builder.HasMany(w => w.WaitLists)
            //    .WithOne(e => e.User)
            //    .HasForeignKey(w => w.UserId_FK);

            builder.HasMany(e => e.EventsCreated)
                .WithOne(userCreator => userCreator.UserCreator)
                .HasForeignKey(e => e.UserIdCreator);

            builder.HasMany(p => p.ProfileDancer)
                .WithOne(user => user.User)
                .HasForeignKey(p => p.UserId);


            builder.HasMany(e => e.CouplesEventsUserInivted)
             .WithOne(e => e.InvitedUser)
             .HasForeignKey(e => e.InvitedUserId);

            builder.HasMany(e => e.CouplesEventsUserHost)
          .WithOne(e => e.HostUser)
          .HasForeignKey(e => e.HostUserId);

            builder.HasMany(e => e.Userlanguages)
         .WithOne(e => e.User)
         .HasForeignKey(e => e.UserId);

        }
    }
}
