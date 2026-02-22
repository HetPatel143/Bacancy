using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CorporateTrainingManagementSystem.Model
{
    public class Department
    {
        
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentLocation { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}
