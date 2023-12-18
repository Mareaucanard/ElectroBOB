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
        public DbSet<ActionTrigger> Actions { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<ReactionTrigger> Reactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionTrigger>().ToTable("ActionTrigger");
            modelBuilder.Entity<Area>().ToTable("Area");
            modelBuilder.Entity<Preference>().ToTable("Preference");
            modelBuilder.Entity<Users>().ToTable("User");
            modelBuilder.Entity<ReactionTrigger>().ToTable("ReactionTrigger");
        }
    }
}
