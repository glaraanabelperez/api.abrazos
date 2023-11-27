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

            builder.Property(e => e.Pass)
              .HasColumnName("Pass");

            builder.Property(e => e.Email)
              .HasColumnName("Email");

            builder.Property(e => e.Age)
              .HasColumnName("Age");

            builder.Property(e => e.Celphone)
              .HasColumnName("Celphone");

            builder.Property(e => e.AvatarImage)
              .HasColumnName("AvatarImage");

            builder.Property(e => e.ProfileDancerId_FK)
                .HasColumnName("ProfileDancerId_FK");

            builder.Property(e => e.UserState)
                .HasColumnName("UserState");


            builder.HasMany(e => e.Address)
                .WithOne()
                .HasForeignKey(e => e.UserId_FK);


            builder.HasMany(e => e.Images)
                .WithOne()
                .HasForeignKey(e => e.UserId_fk);


            builder.HasMany(e => e.UserPermissions)
                .WithOne(u => u.User)
                .HasForeignKey(e => e.UserId_FK);


            builder.HasMany(e => e.TypeEventsUsers)
                .WithOne(user => user.User)
                .HasForeignKey(e => e.UserId_FK);


            builder.HasMany(w => w.WaitLists)
                .WithOne(e => e.User)
                .HasForeignKey(w => w.UserId_FK);

            builder.HasMany(e => e.EventsCreated)
                .WithOne(userCreator => userCreator.UserCreator)
                .HasForeignKey(e => e.UserIdCreator_FK);

            builder.HasOne(e => e.ProfileDancer)
                .WithMany(user => user.Users)
                .HasForeignKey(u => u.ProfileDancerId_FK);

           
        }
    }
}
