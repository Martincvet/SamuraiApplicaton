using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Data
{
    public class SamuraiDbContext : DbContext
    {
        public SamuraiDbContext(DbContextOptions<SamuraiDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quotes> Quotes { get; set; }
        public DbSet<SamuraiBattle> SamuraiBattles { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }

        //public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information).AddConsole(); });

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuiloptionsBuilder)
        //{
        //    optionsBuiloptionsBuilder
        //        .UseLoggerFactory(MyLoggerFactory)
        //        .EnableSensitiveDataLogging()
        //        .UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = SamuraiApp; Trusted_Connection = True; Integrated Security = True ");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(e => new { e.BattleId, e.SamuraiId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
