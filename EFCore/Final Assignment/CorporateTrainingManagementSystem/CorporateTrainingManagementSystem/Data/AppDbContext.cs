using CorporateTrainingManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTrainingManagementSystem.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainingProgram> TrainingPrograms { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=CTMSDb; Trusted_Connection=True; TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);
            modelBuilder.Entity<Department>().HasKey(e => e.DepartmentId);
            modelBuilder.Entity<Trainer>().HasKey(e => e.TrainerId);
            modelBuilder.Entity<TrainingProgram>().HasKey(e => e.TrProgramId);
            modelBuilder.Entity<Enrollment>().HasKey(e => e.EnrollmentId);


            modelBuilder.Entity<Employee>().HasOne(d => d.Department).WithMany(e => e.Employees)
                .HasForeignKey(d => d.DepartmentId);
            modelBuilder.Entity<TrainingProgram>().HasOne(d => d.Trainer).WithMany(e => e.TrainingPrograms)
                .HasForeignKey(d => d.TrainerId);
            modelBuilder.Entity<Enrollment>().HasOne(d => d.Employee).WithMany(e => e.Enrollments)
                .HasForeignKey(d => d.EmployeeId);
            modelBuilder.Entity<Enrollment>().HasOne(d => d.TrainingProgram).WithMany(e => e.Enrollments)
                .HasForeignKey(d => d.TrProgramId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>().Property(e => e.EmployeeName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Trainer>().Property(e => e.TrainerName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<TrainingProgram>().Property(e => e.Title).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Employee>().HasIndex(e => e.EmployeeEmail).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(e => e.DepartmentName).IsUnique();
            modelBuilder.Entity<TrainingProgram>().HasIndex(e => e.Title).IsUnique();
            modelBuilder.Entity<Enrollment>().HasIndex(e =>new { e.EmployeeId,e.TrProgramId }).IsUnique();

            modelBuilder.Entity<Enrollment>().Property(e => e.PerformanceScore).HasDefaultValue(0);
            modelBuilder.Entity<Enrollment>().ToTable(e => e.HasCheckConstraint(
                "CK_MAX_SCORE < 100", "[PerformanceScore]<100"));


            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId=1 ,DepartmentName="IT",DepartmentLocation="Ahmedabad" },
                new Department { DepartmentId = 2 , DepartmentName = "HR", DepartmentLocation = "mumbai" },
                new Department { DepartmentId = 3 , DepartmentName = "Marketing", DepartmentLocation = "bangaluru" },
                new Department { DepartmentId = 4, DepartmentName = "Networking", DepartmentLocation = "bangaluru" },
                new Department { DepartmentId = 5, DepartmentName = "QA", DepartmentLocation = "Ahmedabad" }
                );
            modelBuilder.Entity<Trainer>().HasData(
                new Trainer {TrainerId=1 ,TrainerName="rahul" , ExpertiseLevel=5},
                new Trainer { TrainerId = 2, TrainerName = "mehul", ExpertiseLevel =5}
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId=1, EmployeeName="het" ,EmployeeEmail="het@mail",DepartmentId=1},
                new Employee { EmployeeId = 2, EmployeeName = "niken", EmployeeEmail = "niken@mail", DepartmentId = 2 }
                );
            modelBuilder.Entity<TrainingProgram>().HasData(
                new TrainingProgram { TrProgramId=1, Title="Public Speaking",Duration=5, TrainerId=1}
                );

        }
    }
}
