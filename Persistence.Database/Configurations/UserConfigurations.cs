using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Persistence.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);

            builder.ToTable("User");

            builder.Property(e => e.Name)
                .HasColumnName("Name");
            //builder.Property(e => e.ConsumerEmail)
            //    .HasColumnName("ConsumerEmail");

            //builder.Property(e => e.ConsumerName)
            //    .HasColumnName("ConsumerName");

            //builder.Property(e => e.ConsumerLastName)
            //    .HasColumnName("ConsumerLastName");

            //builder.Property(e => e.ConsumerTel)
            //    .HasColumnName("ConsumerTel");

            //builder.Property(e => e.ConsumerBirthDate)
            //    .HasColumnName("ConsumerBirthDate");

            //builder.Property(e => e.DocumentTypeId)
            //    .HasColumnName("DocumentTypeId");

            //builder.Property(e => e.ConsumerDocumentNumber)
            //    .HasColumnName("ConsumerDocumentNumber");

            //builder.Property(e => e.ConsumerGender)
            //    .HasColumnName("ConsumerGender");


        }
    }
}
