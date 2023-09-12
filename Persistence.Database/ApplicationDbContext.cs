using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using Persistence.Database;
using Persistence.Database.Configurations;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace Persistence.Database
{
    public  class ApplicationDbContext : AbrazosDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; } = null!;
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

