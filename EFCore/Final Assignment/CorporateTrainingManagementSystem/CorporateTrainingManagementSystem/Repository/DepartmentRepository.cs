using CorporateTrainingManagementSystem.Data;
using CorporateTrainingManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTrainingManagementSystem.Repository
{
    public class DepartmentRepository
    {
        public void ShowDepartment(AppDbContext context)
        {
            Console.WriteLine("Choose Department");

            var departments = context.Departments.ToList();
            foreach (var result in departments)
            {
                Console.WriteLine($"{result.DepartmentId}: \t {result.DepartmentName}");
            }

            Console.WriteLine("enter department id");
            var DepId = Convert.ToInt32(Console.ReadLine());

            var exist = context.Departments.FirstOrDefault(e => e.DepartmentId == DepId);
            if (exist == null)
            {
                Console.WriteLine("department id didnot exist");
                return;
            }

            int TotalEmployee = context.Employees.Count(e => e.DepartmentId == DepId);
            int EnrolledEmployee = context.Enrollments.Include(e => e.Employee).Count(e=>e.Employee.DepartmentId==DepId);

            Console.WriteLine($"Department: {exist.DepartmentName}");
            Console.WriteLine($"Total Employees: {TotalEmployee}");
            Console.WriteLine($"Employees Enrolled in Training: {EnrolledEmployee}");
        }
    }
}
