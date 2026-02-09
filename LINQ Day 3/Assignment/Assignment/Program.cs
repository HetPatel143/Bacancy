using Assignment;
using System;
using System.Threading.Tasks.Dataflow;
using static Assignment.data;
using static Assignment.DataBase;
class Program
{
    public static void Main(string[] args)
    {
        Tasks.Task1();
        //Tasks.Task2();
        //Tasks.Task3();
        //Tasks.Task4();
        //Tasks.Task5();
        //Tasks.Task6();
        //Tasks.Task7();
        //Tasks.Task8();
        //Tasks.Task9();
        //Tasks.Task10();
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
        Console.WriteLine("employee with salary >30000");
        Console.WriteLine();
        var HigherSalary = employee.Where(s => s.Salary > 30000);
        
        employee.Add(new Employee { EmpId = 6, Name = "zenisha", Salary = 50000, DepartmentId = 3 });
        foreach (var i in HigherSalary)
        {
            Console.WriteLine($" {i.DepartmentId}-{i.Name}-{i.EmpId}-{i.Salary}");
        }
        Console.WriteLine();
        Console.WriteLine("TASK 1 END");
        Console.WriteLine();

        //THEORY: HERE WE WRITE QUERY TO GET EMPLOYEE WITH SALARY ABOVE 30000 BUT DONT EXECUTE IT
        //AFTER THAT WE ADD A NEW EMPLOYEE ZENISHA WITH SALARY 50000 AND PRINT THE RESULT
        //SO THE ZENISHA WILL ALSO BE IN THE PRINT BECAUSE IT IS DEFERRED EXECUTION IT IS EXECUTED ONLY WHEN IT IS ACCESSED
        //SO IT WILL TAKE THE CHANGES MADE AFTER THE QUERY BUT BEFORE EXECUTION

    }
    #endregion

    #region Task2
    public static void Task2()
    {
        var Result = student.Where(s => s.Marks >= 40).ToList();
        var update = student.FirstOrDefault(s => s.Marks == 35);
        if (update != null)
        {
            update.Marks = 80;
        }

        var Result1 = student.Where(s => s.Marks >= 40).ToList();

        Console.WriteLine("----------------------------TASK 2----------------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------student result >40 update result from 35 to 80-----------------------");
        Console.WriteLine();

        Console.WriteLine("result before update");
        foreach (var i in Result)
        {
            Console.WriteLine($"{i.Name} with marks {i.Marks}");
        }
        Console.WriteLine();
        Console.WriteLine($"marks after update");
        foreach (var i in Result1)
        {
            Console.WriteLine($"{i.Name} with marks {i.Marks}");
        }
        Console.WriteLine();
        Console.WriteLine("TASK 2 END");
        Console.WriteLine();

        //DEFERRED EXECUTION:LINQ QUERY IS NOT EXECUTED WHEN IT IS WRITTEN. IT IS EXECUTED ONLY WHEN ACCESSED OR USED
        //IMMEDIATE EXECUTION: LINQ QUERY RUNS IMMEDIATELY AND THE RESULT STORED IN MEMORY
    }
    #endregion

    #region Task3
    public static void Task3()
    {
        Console.WriteLine("-----------------------TASK 3 START-----------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------Product list and number of items sold-----------------------");
        Console.WriteLine();
        var products = order.SelectMany(o => o.OrderItems).Select(s => s.ProductName);
        int soldItem = order.SelectMany(o => o.OrderItems).Count();

        Console.WriteLine("Product names are");
        foreach (var product in products)
        {
            Console.WriteLine($"\t{product}");
        }

        Console.WriteLine($"number of products sold are {soldItem}");

        //SELECTMANY IS NEEDED HERE BECAUSE EVERY ORDER CONTAINS LIST OF ORDERITEMS AND SELECTMANY FLATTENS THIS NESTED COLLECTIONS
        //INTO A SINGLE DIMENSION  SO WE CAN ACCESS THE INNER ITEM PROPERTIES

    }
    #endregion

    #region Task4
    public static void Task4()
    {
        Console.WriteLine("-----------------------TASK 4 START-----------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------employees groupby and number of employee in each department-----------------------");
        Console.WriteLine();
        var numEmp = employee.GroupBy(e => e.DepartmentId).Select(g => new
        {
            DepartmentId = g.Key,
            EmpCount = g.Count()
        });

        foreach (var item in numEmp)
        {
            Console.WriteLine(
                $"Department: {item.DepartmentId} -No of employees: {item.EmpCount}"
            );
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("TASK 4 END");
        Console.WriteLine();

       //HERE DEFERRED EXECUTION IS USED BECAUSE GROUPBY AND SELECT ARE DEFERRED LINQ OPERATORS
       //IT DIDNOT EXECUTES IMMEDIATELY IT IS EXECUTED WHEN FOREACH LOOP ACCESSES IT.


    }
    #endregion

    #region Task5
    public static void Task5()
    {
        IEnumerable<Employee> ienum = employee;
        var query = ienum.Where(s => s.Salary > 30000);

        IQueryable<Employee> ique = employee.AsQueryable();
        var query2 = ique.Where(s => s.Salary > 30000);


        Console.WriteLine("----------------------------TASK 5----------------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------student result pass or fail-----------------------");
        Console.WriteLine();
        Console.WriteLine("result from IEnumerable");
        foreach (var i in query)
        {
            Console.WriteLine($"{i.Name} - {i.Salary} ");
        }
        Console.WriteLine();
        Console.WriteLine("result from IQueryable");
        foreach (var i in query2)
        {
            Console.WriteLine($"{i.Name} - {i.Salary} ");
        }
        Console.WriteLine();
        Console.WriteLine("TASK 5 END");
        Console.WriteLine();

        //IENUMRABLE WORKS ON THE DATA THAT IS ALREADY IN MEMORY AND OPERATIONS ARE PERFORMED AFTER ALL DATA FETCHED
        //IQUERYABLE WORKS ON THE DATA IN DATABASE THE OPERATIONS PERFORMED AT DATABASE AND THEN RESULT IS FETCHED IN MEMORY

    }


    #endregion

    #region Task6
    public static void Task6()
    {
        Console.WriteLine("-----------------------TASK 6 START-----------------------");
        Console.WriteLine("-----------------------Single Query and N+1 Problem-----------------------");
        Console.WriteLine();
        Console.WriteLine("");

        foreach (var emp in employee)
        {
            var dep = department.FirstOrDefault(d => d.DepartmentId == emp.DepartmentId);

            Console.WriteLine($"{emp.Name} - {dep.DepartmentName}");
        }
        Console.WriteLine() ;
        Console.WriteLine("using single query");
        Console.WriteLine();
        var result = employee.Join(department,
                  e => e.DepartmentId,
                  d => d.DepartmentId,
                  (e, d) => new
                  {
                      e.Name,
                      d.DepartmentName
                  });

        foreach (var item in result)
        {
            Console.WriteLine($"{item.Name} - {item.DepartmentName}");
        }

        //N+1 PROBLEM: IN N+1 PROBLEM 1 QUERY IS EXECUTED TO GET A LIST 
        // AND N EXTRA QUERIES EXECUTED INSIDE A LOOP TO FETCH RELATED DATA
        //IT SLOWS THE PERFORMANCE
        //INCREASES DATABASE CALL AS EACH TIME IT CALLS DATABASE IN FOREACH LOOP
        //MEMORY AND RESOURCES ARE WASTED 
    }
    #endregion

    #region Task7
    public static void Task7()
    {
        var duplicate = order.SelectMany(o => o.OrderItems).Select(o => o.ProductName);
        Console.WriteLine("----------------------------TASK 7----------------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------list of object-----------------------");
        Console.WriteLine();


        Console.WriteLine("list of object before removing duplicate");
        Console.WriteLine();
        foreach (var i in duplicate)
        {
            Console.WriteLine($"\t{i}");
        }
        var unique = duplicate.Distinct();
        Console.WriteLine();

        Console.WriteLine("list of object before removing duplicate");
        Console.WriteLine();
        foreach (var i in unique)
        {
            Console.WriteLine($"\t{i}");
        }

        //HERE SELECTMANY IS FIRST USED TO FLATTEN THE NESTED ITEMS AND THEN SELECT IS USED TO GET DESIRED ITEM
        //.DISTINCT() IS USED TO REMOVE THE DUPLICATE VALUES FROM THE LIST
    }
    #endregion

    #region Task8
    public static void Task8()
    {
        Dictionary<int,string> dict1= employee.ToDictionary(s =>s.EmpId,s=>s.Name);
        

        Console.WriteLine("----------------------------TASK 8----------------------------");
        Console.WriteLine();
        Console.WriteLine("-----------------------Dictionary with key=employeeid value=employee name-----------------------");
        Console.WriteLine();
        foreach (var i in dict1)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
        Console.WriteLine("TASK 8 END");
        Console.WriteLine();

        //.TODICTIONARY IS IMMEDIATE EXECUTION AS IT CREATES DICTIONARY IN MEMORY AND PROCESS ELEMENTS TO GENERATE KEY VALUE PAIRS
    }
    #endregion

    #region Task9
    public static void Task9()
    {
        var filtered = employee.Where(s => s.DepartmentId == 2);

        Console.WriteLine("-----------------------TASK 9 START-----------------------");
        Console.WriteLine("-----------------------employees names in new collection-----------------------");
        Console.WriteLine();

        Console.WriteLine("first print");
        foreach (var i in filtered)
        {
            Console.WriteLine($"{i.EmpId} {i.Name} {i.DepartmentId}");
        }
        Console.WriteLine();
        Console.WriteLine("second print");
        foreach (var i in filtered)
        {
            Console.WriteLine($"{i.EmpId} {i.Name} {i.DepartmentId}");
        }
        Console.WriteLine();

        var empHr = employee.FirstOrDefault(e => e.EmpId == 103);
        if (empHr != null)
        {
            empHr.DepartmentId = 1;
        }

        Console.WriteLine("after update");
        foreach (var i in filtered)
        {
            Console.WriteLine($"{i.EmpId} {i.Name} {i.DepartmentId}");
        }
        Console.WriteLine();

        Console.WriteLine("TASK 9 END");
        Console.WriteLine();

        //FIRST FOREACH AND SECOND FOREACH LOOP PRINTS THE EMPLOYEE WITH DEPARTMENT ID=2(IT) 
        //AFTER THAT WE UPDATE THE VALUE OF EMPLOYEE WITH EMPLOYEEID=103 FROM DEPARTMENT ID=2(IT) TO DEPARTMENT ID=1(HR)
        //AFTER IN 3RD FOREACH LOOP WE PRINT THE UPDATED RESULT SO WE WILL NOT GET THE EMPLOYEE WHOSE VALUE WE CHANGED
    }
    #endregion

    #region Task10
    public static void Task10()
    {
        //LINQ BEST PRACTICES

        //.TOLIST() IS USED WHEN WE WANT A IMMEDIATE EXECUTION OR WANT TO USE THE RESULT MULTIPLE TIME
        
        //AVOID REPEATED ENUMERATOR: ENUMERATING SAME LINQ QUERY MULTIPLE TIMES CAN CAUSE REPEATED EXECUTION AND PERFORMANCE ISSUE.
        //THE RESULT SHOULD BE STORED IF WE WANT TO USE IT MULTIPLE TIME

        //USE ANY() INSTEAD OF COUNT()>0:ANY IS FAST AS IT STOPS AS SOON AS ANY ONE THE ELEMENT IS FOUND
        //WHEN COUNT CHECKS ALL THE ELEMENTS

        //AVOID LOOPS IF LINQ IS POSSIBLE: BY USING LINQ WE CAN GET A MORE CLEAR AND READABLE CODE COMPARED TO LOOPS
        //IT REDUCES BOILERPLATE AND ERROR

        //N+1 QUERY PROBLEM : FETCHING RELATED DATA MULTIPLE TIMES CAUSES THE N+1 PROBLEM
        //IT PROCESSES MANY UNNECESSARY QUERIES. WE SHOULD USE EAGERLOADING TO IMPROVE PERFORMANCE
    }
    #endregion
}
