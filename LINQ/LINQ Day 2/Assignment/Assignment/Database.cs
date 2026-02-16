using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment.Data;

namespace Assignment
{
    public class DataBase
    {
        public static List<Employee> employee = new List<Employee>
        {
            new Employee{EmpId=101, Name="rahul", Salary=10000, DepartmentId=1 },
            new Employee{EmpId=102, Name="rohan", Salary=20000, DepartmentId=1 },
            new Employee{EmpId=103, Name="neil", Salary=30000, DepartmentId =2 },
            new Employee{EmpId=104, Name="nitin", Salary=40000, DepartmentId=2 },
            new Employee{EmpId=105, Name="mukesh", Salary=50000, DepartmentId =3 },
            new Employee{EmpId=106, Name="amar", Salary=85000, DepartmentId =2 },
            new Employee{EmpId=107, Name="akbar", Salary=35000, DepartmentId =3},
            new Employee{EmpId=108, Name="anthony", Salary=70000, DepartmentId =3 },
            new Employee{EmpId=109, Name="karan", Salary=80000, DepartmentId =2 },
            new Employee{EmpId=110, Name="arjun", Salary=50000, DepartmentId =1 },
        };
        public static List<Department> department = new List<Department>
        {
            new Department{DepartmentId=1,DepartmentName="HR" },
            new Department{DepartmentId=2,DepartmentName="IT" },
            new Department{DepartmentId=3,DepartmentName="DevOps" }
        };
    }
}
