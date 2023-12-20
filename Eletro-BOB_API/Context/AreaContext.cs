using Microsoft.EntityFrameworkCore;
using Eletro_BOB_API.Models;
using Eletro_BOB_API.Classes;

namespace Eletro_BOB_API.Context
{
    public class AreaContext : DbContext
    {
        public AreaContext()
        {
        }

        public AreaContext(DbContextOptions<AreaContext> options) : base(options)
        {
        }
        public DbSet<ActionTrigger> ActionTriggers { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<ActionCatalog> ActionCatalogs { get; set; }
        public DbSet<ReactionCatalog> ReactionCatalogs { get; set; }
        public DbSet<ReactionTrigger> ReactionTriggers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>().ToTable("Area");
            modelBuilder.Entity<Preference>().ToTable("Preference");
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<ReactionTrigger>().ToTable("ReactionTrigger");
            modelBuilder.Entity<ReactionCatalog>().ToTable("ReactionCatalog");
            modelBuilder.Entity<ActionTrigger>().ToTable("ActionTrigger");
            modelBuilder.Entity<ActionCatalog>().ToTable("ActionCatalog");
        }
    }
}
