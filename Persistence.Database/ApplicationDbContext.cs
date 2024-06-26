﻿using Abrazos.Persistence.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Abrazos.Persistence.Database
{
    public  class ApplicationDbContext : AbrazosDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Address> Address { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country> Conuntry { get; set; } = null!;
        public virtual DbSet<CouplesEventDate> CouplesEvent_Date { get; set; } = null!;
        public virtual DbSet<DanceLevel> DanceLevel { get; set; } = null!;
        public virtual DbSet<DanceRol> DanceRol { get; set; } = null!;
        public virtual DbSet<Cycle> Cycle { get; set; } = null!;
        public virtual DbSet<Event> Event { get; set; } = null!;
        public virtual DbSet<Image> Image { get; set; } = null!;
        public virtual DbSet<Permission> Permission_ { get; set; } = null!;
        public virtual DbSet<ProfileDancer> ProfileDancer { get; set; } = null!;
        public virtual DbSet<TypeEventUser> TypeEventUser { get; set; } = null!;
        public virtual DbSet<TypeEvent> TypeEvent { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;
        public virtual DbSet<UserPermission> UserPermission { get; set; } = null!;
        //public virtual DbSet<WaitList> WaitList { get; set; } = null!;
        public virtual DbSet<EventState> EventStates { get; set; } = null!;
        public virtual DbSet<Dance> Dances { get; set; } = null!;
        public virtual DbSet<Language> Language { get; set; } = null!;
        public virtual DbSet<UserLanguage> UserLanguages { get; set; } = null!;


        protected override void ModelConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AS");
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfigurations());

            modelBuilder.ApplyConfiguration(new CouplesEventDateConfiguration());
            modelBuilder.ApplyConfiguration(new DanceLevelConfiguration());
            modelBuilder.ApplyConfiguration(new CycleConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileDancerConfiguration());
            modelBuilder.ApplyConfiguration(new TypeEventConfiguration());
            modelBuilder.ApplyConfiguration(new TypeEventConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserPermissionConfiguration());
            //modelBuilder.ApplyConfiguration(new WaitListConfiguration());
            modelBuilder.ApplyConfiguration(new EventStateConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new UserLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new DanceConfiguration());




        }
    }
}

