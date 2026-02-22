using CorporateTrainingManagementSystem.Data;
using CorporateTrainingManagementSystem.Model;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTrainingManagementSystem.Repository
{
    public class EmployeeRepository
    {
        public void RegisterEmployee(AppDbContext context)
        {
            Employee employee = new Employee();
            
            Console.WriteLine("Enter Employee Name ");
            employee.EmployeeName = Console.ReadLine();

            Console.WriteLine("Enter Employee Email ");
            employee.EmployeeEmail = Console.ReadLine();

            Console.WriteLine("Enter DepartmentId in which you want the employee to be in \n 1:IT \n 2:HR \n 3:Marketing \n 4:Networking \n 5:QA");
            int DepId = Convert.ToInt32(Console.ReadLine());
            var exists = context.Departments.FirstOrDefault(x => x.DepartmentId == DepId);
            if (exists == null)
            {
                Console.WriteLine("DepartmentId did not exists");
                return;
            }
            employee.DepartmentId = DepId;

            context.Employees.Add(employee);
            context.SaveChanges();
            Console.WriteLine("Employee registered");
        }
        
        public void EmployeePerformance(AppDbContext context)
        {
            Console.WriteLine("Select EmployeeId whom score you want to update");
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
            var check = context.Enrollments.FirstOrDefault(e => e.EmployeeId == EmpId && e.TrProgramId == ProgramId);
            if (check == null)
            {
                Console.WriteLine("employee is not enrolled in this training");
                return;
            }

            Console.WriteLine("enter new performance score (0-100)");
            int score = Convert.ToInt32(Console.ReadLine());

            if (score > 100 || score < 0)
            {
                Console.WriteLine("Invalid score. Must be between 0 and 100.");
                return;
            }

            check.PerformanceScore = score;
            context.SaveChanges();

            Console.WriteLine("Performance updated");

        }
    }
}
