using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment.data;

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
        public static List<Student> student = new List<Student>
    {
        new Student{RollNo=101, Name="amar", Marks=90},
        new Student{RollNo=102, Name="akbar", Marks=80},
        new Student{RollNo=103, Name="anthony", Marks=95},
        new Student{RollNo=104, Name="karan", Marks=35},
        new Student{RollNo=105, Name="arjun", Marks=25}

    };
        public static List<Order> order = new List<Order>
    {
        new Order{OrderId=111,CustomerName="ganga",OrderItems = new List<OrderItem>{
            new OrderItem{ProductName="laptop",Price=80000},
            new OrderItem { ProductName = "bag", Price = 1500 }
            }
        },
        new Order{OrderId=222,CustomerName="jamna",OrderItems = new List<OrderItem>{
            new OrderItem{ProductName="purse",Price=8000},
            new OrderItem { ProductName = "lipstick", Price = 1700 }
            }
        },
        new Order{OrderId=333,CustomerName="sarasvati",OrderItems = new List<OrderItem>{
            new OrderItem{ProductName="saree",Price=7000},
            new OrderItem { ProductName = "purse", Price = 500 }
            }
        },
        new Order{OrderId=444,CustomerName="narendra",OrderItems = new List<OrderItem>{
            new OrderItem{ProductName="laptop",Price=5000},
            new OrderItem { ProductName = "watch", Price = 3500 }
            }
        },
        new Order{OrderId=555,CustomerName="amit",OrderItems = new List<OrderItem>{
            new OrderItem{ProductName="mobile",Price=70000},
            new OrderItem { ProductName = "cover", Price = 1000 }
            }
        }
    };
    }
}
