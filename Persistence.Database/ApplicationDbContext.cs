using Abrazos.Persistence.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Abrazos.Persistence.Database
{
    public  class ApplicationDbContext : AbrazosDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Address> Address { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country> Country { get; set; } = null!;
        public virtual DbSet<CouplesEvent_Date> CouplesEvent_Date { get; set; } = null!;
        public virtual DbSet<DanceLevel> DanceLevel { get; set; } = null!;
        public virtual DbSet<DanceRol> DanceRol { get; set; } = null!;
        public virtual DbSet<Event> Event { get; set; } = null!;
        public virtual DbSet<Image> Image { get; set; } = null!;
        public virtual DbSet<Permission> Permission { get; set; } = null!;
        public virtual DbSet<ProfileDancer> ProfileDancer { get; set; } = null!;
        public virtual DbSet<TypeEvent_User> TypeEvent_User { get; set; } = null!;
        public virtual DbSet<TypeEvent> TypeEvent { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;
        public virtual DbSet<UserPermission> UserPermission { get; set; } = null!;
        public virtual DbSet<WaitList> WaitList { get; set; } = null!;
        public virtual DbSet<EventState> EventStates { get; set; } = null!;


        protected override void ModelConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CouplesEventDateConfiguration());
            modelBuilder.ApplyConfiguration(new DanceLevelConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileDancerConfiguration());
            modelBuilder.ApplyConfiguration(new TypeEvent_UserConfiguration());
            modelBuilder.ApplyConfiguration(new TypeEventConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserPermissionConfiguration());
            modelBuilder.ApplyConfiguration(new WaitListConfiguration());
            modelBuilder.ApplyConfiguration(new EventStateConfiguration());


        }
    }
}

