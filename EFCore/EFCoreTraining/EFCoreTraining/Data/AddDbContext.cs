using EFCoreTraining.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.Data
{
    internal class AddDbContext: DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=EFCoreDb;Trusted_Connection=True; TrustServerCertificate=True");
        }
    }
}
