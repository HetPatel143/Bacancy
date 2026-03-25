using EventManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EventManagementSystem.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>().HasOne(r => r.User).WithMany(r => r.Registrations)
                .HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Registration>().HasOne(r => r.Event).WithMany(r => r.Registrations)
                .HasForeignKey(r => r.EventId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Registration>().HasIndex(r => new { r.UserId, r.EventId }).IsUnique();
        }
    }
}
