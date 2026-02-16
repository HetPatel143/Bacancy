using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Data
    {
        public class Employee
        {
            public int EmpId { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }
            public int DepartmentId { get; set; }
            
        }
        public class Department
        {
            public int DepartmentId { get; set; }
            public string DepartmentName { get; set; }
        }
        

    }
}
