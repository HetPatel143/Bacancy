using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class data
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
        public class Student
        {
            public int RollNo { get; set; }
            public string Name { get; set; }
            public int Marks { get; set; }
        }
        public class Order
        {
            public int OrderId { get; set; }
            public string CustomerName { get; set; }
            public List<OrderItem> OrderItems { get; set; }
        }
        public class OrderItem
        {
            public string ProductName { get; set; }
            public int Price { get; set; }
        }

    }
}
