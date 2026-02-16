using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

#region Assignment 1

//class Employee
//{

//    public int PayHours = 1000;
//    public int EmpHours;
//    public int fixpay = 15000;
//    public int bonus = 5000;
//    public int salary;

//    public virtual void Salary(int EmpHours)
//    {
//        salary=fixpay;

//        Console.WriteLine($"salary is {salary}");
//    }
//}
//class FullTimeEmployee : Employee
//{
//    public override void Salary(int EmpHours)
//    {
//        salary=(PayHours*EmpHours)+bonus;
//        Console.WriteLine($"salary of fulltime employee is {salary}");
//    }
//}
//class ContractEmployee : Employee
//{
//    public override void Salary(int EmpHours)
//    {
//        salary = (PayHours * EmpHours);
//        Console.WriteLine($"salary of contract based employee is {salary}");
//    }
//}
//class Program
//{
//    public static void Main(string[] args)
//    {
//        Employee e1 = new Employee();
//        e1.Salary(10);
//        Employee e2 = new FullTimeEmployee();
//        e2.Salary(20);
//        FullTimeEmployee e3 = new FullTimeEmployee();
//        e3.Salary(30);
//        Employee e4 = new ContractEmployee();
//        e4.Salary(40);
//        ContractEmployee e5 = new ContractEmployee();
//        e5.Salary(50);
//    }
//}

#endregion

#region Assignment 2

//class Log
//{
//    protected void LogMessage(string message)
//    {
//           Console.WriteLine($"LOG - {DateTime.Now} {message}");
//    }
//    public Log()
//    {
//        LogMessage("Enter any valid name and password");
//        LogMessage("base constructor");
//        LogMessage("enter your name");
//        string name=Convert.ToString(Console.ReadLine());
//        if(Regex.IsMatch(name, @"^[A-Za-z ]+$")){
//            LogMessage("name matched");
//        }
//        else
//        {
//            LogMessage("name didnot match");
//        }
//    }
//}
//class ChildLog : Log
//{
//    public ChildLog() : base()
//    {
//        Console.WriteLine();
//        LogMessage("childlog constructor");
//        LogMessage("enter password");
//        string pass=Convert.ToString(Console.ReadLine());
//        if (Regex.IsMatch(pass, @"^\S+$"))
//        {
//            LogMessage($"password matched");
//        }
//        else
//        {
//            LogMessage("password did not matched");

//        }
//    }
//}

//class Program
//{
//    public static void Main(string[] args)
//    {
//        ChildLog log = new ChildLog();
//    }
//}

#endregion

#region Assignment 3

//class PaymentProcessor
//{
//    public virtual void Money()
//    {
//        Console.WriteLine("money method");
//    }
//    public void ProcessPayment(int a)
//    {
//        Console.WriteLine($"payment is done for int value {a}");
//    }
//    public void ProcessPayment(double a)
//    {
//        Console.WriteLine($"payment is done for double value {a}");
//    }
//}
//class Creditcard : PaymentProcessor
//{
//    public override void Money()
//    {
//        Console.WriteLine("Credit card payment is done");
//    }
//}
//class UPI : PaymentProcessor
//{
//    public override void Money()
//    {
//        Console.WriteLine("UPI payment is done");
//    }
//}

//class Program
//{
//    public static void Main(string[] args)
//    {
//        PaymentProcessor p1 = new PaymentProcessor();
//        p1.Money();
//        p1.ProcessPayment(1);
//        p1.ProcessPayment(2.1);
//        Creditcard c1 = new Creditcard();
//        c1.Money();
//        UPI c2 = new UPI();
//        c2.Money();
//    }
//}
#endregion

#region Assignment 4

//public abstract class ReportGenerator
//{
//    public abstract void GenerateReport();
//}
//public class PDFReport : ReportGenerator
//{
//    public override void GenerateReport()
//    {
//        Console.WriteLine("PDF Report is generated");
//    }
//}
//public class ExcelReport : ReportGenerator
//{
//    public override void GenerateReport()
//    {
//        Console.WriteLine("Excel Report is generated");
//    }
//}

//class Program
//{
//    public static void Main(string[] args)
//    {
//        ReportGenerator pdf = new PDFReport();
//        pdf.GenerateReport();
//        ReportGenerator excel = new ExcelReport();
//        excel.GenerateReport();
//    }
//}

#endregion

#region Assignment 5

//class Parent
//{
//    public virtual void speak()
//    {
//        Console.WriteLine("Parent is speaking");
//    }

//}
//class Child : Parent
//{
//    public override void speak()
//    {
//        Console.WriteLine("child is trying to speak");
//    }
//    public void walk()
//    {
//        Console.WriteLine("child walking");
//    }
//}
//class Baby : Child
//{
//    public new void walk()
//    {
//        Console.WriteLine("baby is walking");
//    }
//}
//class Program
//{
//    public static void Main(string[] args)
//    {
//        Baby bb=new Baby();
//        bb.walk();
//        Child cc = new Child();
//        cc.speak();
//        cc.walk();
//        Parent pp=new Parent();
//        pp.speak();
//        Parent pc = new Child();
//        pc.speak();
//        Child cb = new Baby();
//        cb.walk();
//        cb.speak();

//    }
//}

#endregion