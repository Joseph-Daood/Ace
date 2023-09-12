using Ace.Api.Entities;
using Ace.Shared;
using Microsoft.EntityFrameworkCore;

namespace Ace.Api.Database
{
    public class AceDbContext : DbContextBase
    {
        public AceDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Family> Families { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Community> Communities { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Build> Builds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Contribution>()
            //    .HasOne(ci => ci.Member)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
