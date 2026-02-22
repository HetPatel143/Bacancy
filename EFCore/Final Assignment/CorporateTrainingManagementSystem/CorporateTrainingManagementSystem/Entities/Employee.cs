using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CorporateTrainingManagementSystem.Model
{
    public class Employee
    {
       
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}