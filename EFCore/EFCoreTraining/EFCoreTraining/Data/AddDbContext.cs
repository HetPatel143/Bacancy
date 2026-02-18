using EFCoreTraining.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.Data
{
    public class AddDbContext: DbContext
    {
        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }

        public DbSet<Batch> batches { get; set; }
        public DbSet<Trainer> trainers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=EFCoreDb;Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasMany(c => c.Courses)
                .WithMany(s => s.Students)
                .UsingEntity(d => d.ToTable("Student Courses"));

            modelBuilder.Entity<Batch>().HasOne(c => c.Course)
                .WithMany(s => s.Batch).HasForeignKey(f => f.CourseId);

            modelBuilder.Entity<Batch>().HasOne(c => c.trainer)
                .WithMany(s => s.Batch).HasForeignKey(f => f.TrainerId);

            modelBuilder.Entity<Trainer>().HasData(
                new Trainer { TrainerId = 1, Name = "Jaydip Mer", ExperienceYears=5},
                new Trainer { TrainerId = 2, Name = "Vivek Vaghasiya", ExperienceYears = 5 }
                );
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 101, Title = ".NET", Fees = 5000, DurationInMonths = 4 },
                new Course { CourseId = 102, Title = "C#", Fees = 3000, DurationInMonths = 2 }
                );

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, Name = "Het", Email = "het@gmail.com" , CreatedDate = DateOnly.FromDateTime(DateTime.Now) },
                new Student { StudentId = 2, Name = "Niken", Email = "niken@gmail.com", CreatedDate = DateOnly.FromDateTime(DateTime.Now) },
                new Student { StudentId = 3, Name = "Megh", Email = "megh@gmail.com", CreatedDate = DateOnly.FromDateTime(DateTime.Now) }
                );

        }
    }
}
