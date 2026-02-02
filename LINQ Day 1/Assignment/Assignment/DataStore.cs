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
            new Employee{EmpId=1, Name="rahul", Salary=10000,Department="HR",City="Ahmedabad" },
            new Employee{EmpId=2, Name="rohan", Salary=20000,Department="IT",City="Ahmedabad"  },
            new Employee{EmpId=3, Name="neil", Salary=30000, Department = "IT", City = "Surat"},
            new Employee{EmpId=4, Name="nitin", Salary=40000, Department = "Marketing", City = "Rajkot"},
            new Employee{EmpId=5, Name="mukesh", Salary=50000, Department = "Networking", City = "Mehsana"},
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
            new OrderItem { ProductName = "eyeliner", Price = 500 }
            }
        },
        new Order{OrderId=444,CustomerName="narendra",OrderItems = new List<OrderItem>{
            new OrderItem{ProductName="shoes",Price=5000},
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
