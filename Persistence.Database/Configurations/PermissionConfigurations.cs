using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(e => e.ImageId);
            builder.ToTable("Image");
            builder.Property(e => e.ImageId)
                .HasColumnType("int")
                .HasColumnName("ImageId");

            builder.Property(e => e.Name)
              .HasColumnName("Name");
          
        }
    }
}
