using Assignment;
using System;
using static Assignment.data;
using static Assignment.DataBase;
class Program
{
    public static void Main(string[] args)
    {
        Tasks.Task1();
        Tasks.Task2();
        Tasks.Task3();
        Tasks.Task4();
        Tasks.Task5();
        Tasks.Task6();
        Tasks.Task7();
        Tasks.Task8();
        Tasks.Task9();
        Tasks.Task10();
    }
}

public static class Tasks
{
    #region Task1
    public static void Task1()
    {

        Console.WriteLine("method syntax used");
        Console.WriteLine("-----------------------TASK 1 START-----------------------");
        Console.WriteLine();
        Console.WriteLine("employee with salary >25000");
        Console.WriteLine();
        var HigherSalary = employee.Where(s => s.Salary > 25000).Select(s => $"{s.EmpId}-{s.Name} {s.Salary}");
        //Console.WriteLine(string.Join(",",HighestSalary));
        foreach (var i in HigherSalary)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        Console.WriteLine("TASK 1 END");
        Console.WriteLine();

        //THEORY: HERE I USED WHERE TO FILTER THE EMPLOYEES WITH SALARY ABOVE 25000
        //SELECT IS USED HERE TO RETRIVE DATA IN STRING FORMAT

    }
    #endregion

    #region Task2
    public static void Task2()
    {

        Console.WriteLine("-----------------------TASK 2 START-----------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------employees in IT Department-----------------------");
        Console.WriteLine();

        var DepartmentIT = employee.Where(s => s.Department == "IT").Select(s => $"{s.Name} {s.Salary}");
        foreach (var i in DepartmentIT)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        Console.WriteLine("TASK 2 END");
        Console.WriteLine();
        Console.WriteLine();

        //THEORY: WHERE FILTERS EMPLOYEE BASED ON DEPARTMENT AND SELECT GIVES DATA OF EMPLOYEE

    }
    #endregion

    #region Task3
    public static void Task3()
    {
        Console.WriteLine("-----------------------TASK 3 START-----------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------employees in IT Department-----------------------");
        Console.WriteLine();
        var OrderSalary = employee.Where(s => s.Salary > 30000).OrderBy(s => s.Salary).Select(s => $"{s.EmpId}-{s.Name} {s.Salary}");
        foreach (var i in OrderSalary)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        Console.WriteLine("TASK 3 END");
        Console.WriteLine();

        //THEORY: WHERE FILTERS THE EMPLOYEE SALARY ABOVE 30000 
        //ORDERBY IS USED TO SORT BASED ON SALARY IN ASCENDING ORDER
        //SELECT IS USED HERE TO RETRIVE DATA IN STRING FORMAT

    }
    #endregion

    #region Task4
    public static void Task4()
    {
        Console.WriteLine("-----------------------TASK 4 START-----------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------employees sortedby department and then name-----------------------");
        Console.WriteLine();
        var SortName = employee.OrderBy(s => s.Department).ThenBy(s => s.Name).Select(s => $"{s.Department}-{s.Name}");
        foreach (var i in SortName)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        Console.WriteLine("TASK 4 END");
        Console.WriteLine();

        //HERE ORDERBY FIRST SORTS BASED ON DEPARTMENT AND THENBY THEN SORTS BASED ON THE NAME
        //SELECT IS USED HERE TO RETRIVE DATA IN STRING FORMAT


    }
    #endregion

    #region Task5
    public static void Task5()
    {


        var Result = student.Select(s => new { s.Name, s.Marks, Result = s.Marks >= 40 ? "Pass" : "Fail" });
        Console.WriteLine("----------------------------TASK 5----------------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------student result pass or fail-----------------------");
        Console.WriteLine();
        foreach (var i in Result)
        {
            Console.WriteLine($"{i.Name} - {i.Marks} - {i.Result}");
        }
        Console.WriteLine();
        Console.WriteLine("TASK 5 END");
        Console.WriteLine();

        //SELECT IS USED HERE TO RETRIVE STUDENT DATA WITH ANONYMOUS TYPE 
        //TERNARY OPERATOR USED TO COMPUTE PASS OR FAIL

    }
    #endregion

    #region Task6
    public static void Task6()
    {


        var AnonymousFun = student.Select(s => new { s.Name, s.Marks, s.RollNo });
        Console.WriteLine("----------------------------TASK 6----------------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------anonymous type-----------------------");
        Console.WriteLine();
        foreach (var i in AnonymousFun)
        {
            Console.WriteLine($"{i.Name} - {i.Marks} - {i.RollNo}");
        }
        Console.WriteLine();
        Console.WriteLine("TASK 6 END");
        Console.WriteLine();

        //SELECT IS USED HERE TO RETRIVE STUDENT DATA WITH ANONYMOUS TYPE 


    }
    #endregion

    #region Task7
    public static void Task7()
    {

        var NameProduct = order.SelectMany(o => o.OrderItems).Select(o => o.ProductName);

        Console.WriteLine("----------------------------TASK 7----------------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------products name from orders-----------------------");
        Console.WriteLine(); foreach (var i in NameProduct)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        Console.WriteLine("TASK 7 END");
        Console.WriteLine();

        //HERE SELECTMANY IS USED TO FLATTEN THE NESTED ORDERITEMS AND SELECT RETRIVES PRODUCT NAME

    }
    #endregion

    #region Task8
    public static void Task8()
    {
        var CustomerProduct = order.SelectMany(s => s.OrderItems, (o, item) => new { o.CustomerName, item.ProductName });


        Console.WriteLine("----------------------------TASK 8----------------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------customer name and product name-----------------------");
        Console.WriteLine();
        foreach (var i in CustomerProduct)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        Console.WriteLine("TASK 8 END");
        Console.WriteLine();

        //HERE SELECTMANY IS USED WITH ANONYMOUS TYPE AND RETRIVES CUSTOMER NAME AND PRODUCT NAME

    }
    #endregion

    #region Task9
    public static void Task9()
    {
        Console.WriteLine("-----------------------TASK 9 START-----------------------");
        Console.WriteLine("-----------------------employees names in new collection-----------------------");
        Console.WriteLine();
        List<string> EmployeeNames = employee.Select(s => $"{s.Name}").ToList();

        foreach (var i in EmployeeNames)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        Console.WriteLine("TASK 9 END");
        Console.WriteLine();

        //HERE I EXTRACTED EMPLOYEE NAMES AND USING .TOLIST() STORED IN A COLLECTION

    }
    #endregion

    #region Task10
    public static void Task10()
    {
        var QuerySyntax = from e in employee
                          where e.Salary > 25000
                          select e;
        var MethodSyntax = employee.Where(s => s.Salary > 25000).Select(s => $"{s.EmpId}-{s.Name} {s.Salary}");

        Console.WriteLine("----------------------------TASK 10----------------------------");

        Console.WriteLine("----------------------------Query syntax----------------------------");
        foreach (var i in QuerySyntax)
        {
            Console.WriteLine($"{i.EmpId} - {i.Name} - {i.Salary}");
        }
        Console.WriteLine("----------------------------Method syntax----------------------------");
        foreach (var i in MethodSyntax)
        {
            Console.WriteLine(i);
        }

        // QUERY SYNTAX IS LIKE SQL USES KEYWORDS LIKE FROM , WHERE, SELECT
        //QUERY SYNTAX IS INTERNALLY CONVERTED INTO METHOD SYNTAX
        // METHOD SYNTAX USES EXTENSION METHODS WHERE(),SELECT()

    }
    #endregion
}
