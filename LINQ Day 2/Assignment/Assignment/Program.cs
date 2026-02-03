using Assignment;
using static Assignment.Data;
using static Assignment.DataBase;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("METHOD SYNTAX USED HERE");
        Tasks.Task1();
        Tasks.Task2();
        Tasks.Task3();
        Tasks.Task4();
        Tasks.Task5();
    }
}

public static class Tasks
{
    #region Task1
    public static void Task1()
    {
        Console.WriteLine("--------------------------TASK 1--------------------------");
        Console.WriteLine();

        int MaxSalary = employee.Max(e => e.Salary);
        Console.WriteLine($"The maximum salary of employee is {MaxSalary}");
        Console.WriteLine();

        int MinSalary = employee.Min(e => e.Salary);
        Console.WriteLine($"The minimum salary of employee is {MinSalary}");
        Console.WriteLine();

        int TotalSalary = employee.Sum(e => e.Salary);
        Console.WriteLine($"The total salary of employee is {TotalSalary}");
        Console.WriteLine();

        double AvgSalary = employee.Average(e => e.Salary);
        Console.WriteLine($"The average salary of employee is {AvgSalary}");
        Console.WriteLine();

        var result = employee.Join(department,emp => emp.DepartmentId,
                                            dep => dep.DepartmentId,
                                            (emp, dep) => new { emp, dep })
                                            .GroupBy(x => x.dep.DepartmentName)
                                            .Select(g => new
                                            {
                                                DepartmentName = g.Key,
                                                empcount = g.Count()
                                            });


        foreach (var item in result)
        {
            Console.WriteLine($"no of Employee in {item.DepartmentName} in {item.empcount} ");
        }

        Console.WriteLine();

        //MAX IS USED FOR FINDING THE MAXIMUM VALUE
        //MIN IS USED FOR FINDING THE MINIMUM VALUE
        //AVERAGE IS USED FOR FINDING THE AVERAGE VALUE
        //COUNT IS USED FOR FINDING THE NUMBER OF ITEMS 
        //JOIN USE TO COMBINE EMPLOYEE AND DEPARTMENT
        //GROUPBY GROUPS EMPLOYEE BY DEPARTMENTNAME
    }
    #endregion


    #region Task2
    public static void Task2()
    {
        Console.WriteLine("--------------------------TASK 2--------------------------");
        Console.WriteLine();

        Console.WriteLine("-----------Employee with their department name-----------");
        Console.WriteLine();
        var result = employee.GroupJoin(department,
                    emp => emp.DepartmentId,
                    dep => dep.DepartmentId,
                    (emp, dep) => new { emp, dep }).SelectMany(s => s.dep.DefaultIfEmpty(),
                    (s, dep) => new
                    {
                        s.emp.Name,
                        s.emp.Salary,
                        DepartmentName = dep != null ? dep.DepartmentName : "department not assigned"
                    });

        Console.WriteLine();
        foreach (var item in result)
        {
            
                Console.WriteLine($"Employee name {item.Name} in {item.DepartmentName} ");
        }

        Console.WriteLine();
        Console.WriteLine("-----------Department with their employee name-----------");
        Console.WriteLine();

        var result1 = department.GroupJoin(employee,
        dep => dep.DepartmentId,
        emp => emp.DepartmentId,
        (dep, emps) => new
        {
            dep.DepartmentName,
            Employees = emps
        }
    );
        foreach (var dep in result1)
        {
            Console.WriteLine($"Department {dep.DepartmentName}");
            foreach (var emp in dep.Employees)
                {
                    Console.WriteLine($"\t{emp.Name}");
                }   
        }
        Console.WriteLine();

        //GROUPJOIN USED TO PERFORM LEFT JOIN BETWEEN EMPLOYEE AND DEPARTMENT
        //DEFAULTIFEMPTY CHECKS EMPLOYEE WITHOUT DEPARTMENT DOESNOT EXCLUDED
        //TERNARY INSERTS NULL VALUE WHEN DEPARTMENT VALUE DOESNOT EXIST
        //SELECTMANY FLATTENS GROUPJOIN RESULT
        //ANONYMOUS TYPE NEW{} USED TO STORE TEMPORARY DATA
    }
    #endregion


    #region Task3
    public static void Task3()
    {
        Console.WriteLine("--------------------------TASK 3--------------------------");
        Console.WriteLine();

        Console.WriteLine("-----------Groupby employee and calculate average salary and the total number of employee-----------");
        Console.WriteLine();

        var result = employee.GroupBy(e => e.DepartmentId).Select(g => new
        {
            DepartmentId = g.Key,
            EmployeeCount = g.Count(),
            AvgSalary = g.Average(e => e.Salary),
        });
        foreach (var item in result)
        {
            Console.WriteLine(
                $"Department: {item.DepartmentId} -No of employees: {item.EmployeeCount} - Average Salary of employee: {item.AvgSalary}"
            );
        }
        Console.WriteLine();

        //GROUPBY GROUP EMPLOYEE WITH DEPARTMENT
        //KEY IS THE GROUPING KEY HELPS TO KNOW WHICH DEPARTMENT ID BELONGS TO
        //COUNT IS USED TO COUNT NUMBER OF ELEMENTS AND AVERAGE IS USED TO FIND THE AVERAGE SALARY
        //ANONYMOUS TYPE NEW{} USED TO STORE TEMPORARY DATA
        //SELECT IS USED TO PROJECT DATA
    }
    #endregion


    #region Task4

    public static void Task4()
    {
        Console.WriteLine("--------------------------TASK 4--------------------------");
        Console.WriteLine();
        Console.WriteLine("-----------Employee with salary greater than average salary-----------");
        Console.WriteLine();

        double AvgSalary = employee.Average(e => e.Salary);
        var AboveAvg = employee.Where(s => s.Salary > AvgSalary);
        foreach(var item in AboveAvg)
        {
            Console.WriteLine($"{item.Name} has salary {item.Salary} which is above average {AvgSalary}");
        }

        Console.WriteLine("-----------Employee with high salary than highest salary of HR-----------");
        Console.WriteLine();

        int HrDepartment = employee.Join(department,e => e.DepartmentId,d => d.DepartmentId,
                                     (e, d) => new { e, d })
                                    .Where(x => x.d.DepartmentName == "HR")
                                    .Max(x => x.e.Salary);


        var employeeHigherThanHr =employee.Where(e => e.Salary > HrDepartment);

        foreach (var emp in employeeHigherThanHr)
        {
            Console.WriteLine($"{emp.Name} has higher salary than HR which is - {emp.Salary}");
        }
        Console.WriteLine();


        //AVERAGE CALCULATES THE AVERAGE SALARY
        //WHERE FINDS THE SALARY ABOVE THAN AVERAGE SALARY, WHERE(2ND) FILTERS ONLY HR DEPARTMENT
        //JOIN COMBINES EMPLOYEE AND DEPARTMENT DATA
        //MAX FINDS MAXIMUM SALARY IN HR
        //LAMBDA EXPRESSION IS USED FOR KEY SELECTION, FILTERING
    }
    #endregion



    #region Task5

    public static void Task5()
    {
        Console.WriteLine("--------------------------TASK 5--------------------------");
        Console.WriteLine();
        List<string> names = new List<string>() {"amar","akbar", "anthony","karan","arjun" };
        List<string> names1 = new List<string>() { "raju", "akbar", "shyam", "babu", "arjun" };
        
        Console.WriteLine("---------common names in both list---------");
        Console.WriteLine();
        var commonName = names.Intersect(names1);
        foreach (var name in commonName)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("---------names in list 1 which are not in list 2---------");
        Console.WriteLine();
        var first=names.Except(names1);
        foreach (var name in first)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("---------combined list with no repeats---------");
        Console.WriteLine();
        var combine = names.Union(names1);
        foreach (var name in combine)
        {
            Console.WriteLine(name);
        }
    }
    //INTERSECT USED TO FIND THE COMMON ELEMENTS OF BOTH LISTS
    //EXCEPT IS USED TO GET THE ELEMENTS THAT ARE PRESENT IN LIST 1 BUT NOT IN LIST 2
    //UNION IS USED TO GET ALL THE ELEMENTS FROM BOTH THE LIST WITHOUT REPEATING ELEMENTS

    #endregion
}