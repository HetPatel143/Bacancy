using CorporateTrainingManagementSystem.Data;
using CorporateTrainingManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTrainingManagementSystem.Repository
{
    public class EnrollmentRepository
    {
        public void EnrollEmployee(AppDbContext context)
        {
            Enrollment enrollment = new Enrollment();

            Console.WriteLine("Select EmployeeId you want to enroll");
            var employee = context.Employees.ToList();

            foreach (var result in employee)
            {
                Console.WriteLine($"{result.EmployeeId}: \t {result.EmployeeName}");
            }

            Console.WriteLine("enter employee id");
            int EmpId = Convert.ToInt32(Console.ReadLine());

            var exists = context.Employees.FirstOrDefault(e => e.EmployeeId == EmpId);
            if (exists == null)
            {
                Console.WriteLine("employee id didnot exists");
                return;
            }

            Console.WriteLine("Select program you want");
            var program = context.TrainingPrograms.ToList();

            foreach (var result in program)
            {
                Console.WriteLine($"{result.TrProgramId}: \t {result.Title}");
            }

            Console.WriteLine("enter program id");
            int ProgramId = Convert.ToInt32(Console.ReadLine());

            var exist = context.TrainingPrograms.FirstOrDefault(e => e.TrProgramId == ProgramId);
            if (exist == null)
            {
                Console.WriteLine("Programid didnot exists");
                return;
            }

            var check = context.Enrollments.FirstOrDefault(e => e.EnrollmentId == EmpId && e.TrProgramId == ProgramId);
            if (check != null)
            {
                Console.WriteLine("employee is already enrolled");
                return;
            }

            enrollment.EmployeeId = EmpId;
            enrollment.TrProgramId = ProgramId;
            enrollment.EnrollmentDate = DateOnly.FromDateTime(DateTime.Now);
            enrollment.PerformanceScore = 0;

            context.Enrollments.Add(enrollment);
            context.SaveChanges();

            Console.WriteLine("Enrolled Successfully");
        }
    }
}
