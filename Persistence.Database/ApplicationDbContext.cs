using Abrazos.Persistence.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Abrazos.Persistence.Database
{
    public  class ApplicationDbContext : AbrazosDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Users> Users { get; set; } = null!;
        //public virtual DbSet<Address> Addresses { get; set; } = null!;
        //public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;

        protected override void ModelConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new AddressConfiguration());
            //modelBuilder.ApplyConfiguration(new DocumentTypeConfiguration());

        }
    }
}

