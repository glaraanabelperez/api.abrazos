using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Abrazos.Persistence.Database.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(e => e.LanguageId);
            builder.ToTable("Language");
            builder.Property(e => e.LanguageId)
                .HasColumnType("int")
                .HasColumnName("LanguageId");
        
            builder.Property(e => e.Name)
              .HasColumnName("Name");
  
          
        }
    }
}
