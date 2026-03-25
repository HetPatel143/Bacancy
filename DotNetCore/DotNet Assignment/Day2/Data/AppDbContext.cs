using Day2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Day2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products => Set<Product>();
    }
}