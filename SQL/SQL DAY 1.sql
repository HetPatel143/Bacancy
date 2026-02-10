CREATE DATABASE EmpData1;
SELECT NAME FROM sys.databases

CREATE TABLE Employee(
    EmployeeID INT,
 	FirstName VARCHAR(50),
 	LastName VARCHAR(50),
 	Email VARCHAR(100),
 	Department VARCHAR(50),
 	Salary DECIMAL(10,2),
 	DateOfJoining DATE
)

INSERT INTO Employee(EmployeeID,FirstName,LastName,Email,Department,Salary,DateOfJoining)
VALUES(101,'het','patel','het.patel@bacancy.us','hr',1000000, '2020-01-01'),
(102,'niken','patel','niken.patel@bacancy.us','hr',200000,'2021-06-12'),
(103,'mann','badresiya','mann.badresiya@bacancy.us','sales',10000,'2019-11-03'),
(104,'ayush','panchasara','ayush.panchasara@bacancy.us','sales',50000,'2024-02-18'),
(105,'krunal','khernar','kruna.khernar@bacancy.us','finance',250000,'2020-08-27'),
(106,'devam','satasiya','devam.satasiya@bacancy.us','finance',300000,'2022-01-09'),
(107,'raj','rana','raj.rana@bacancy.us','it',400000,'2018-07-14'),
(108,'aashish','pateliya','aashish.pateliya@bacancy.us','it',10000,'2023-05-30'),
(109,'megh','mewada','megh.mewada@bacancy.us','sql',1000,'2025-09-11'),
(111,'arjun','kumar','arjun.kumar@bacancy.us','sql',100000,'2025-11-11'),
(110,'meet','patel','patel.network@bacancy.us','networking',10000000, '2017-08-22');

--task 1

--SELECT * FROM Employee
--WHERE Salary>10000
--ORDER BY Salary DESC
--OFFSET 2 ROWS
--FETCH NEXT 7 ROWS ONLY;

SELECT TOP 5 * FROM Employee
ORDER BY Salary DESC


--task 2
SELECT DISTINCT Department
FROM Employee
WHERE Department LIKE 's%';


--task 3
SELECT *
FROM Employee
WHERE Department IN ('hr', 'finance', 'it') AND Salary>50000;

--TASK 4
SELECT *
FROM Employee
WHERE Department IN ('sales') OR Salary>75000;
--here we check the condition using 'WHERE' the department of employee is IN 'sales' (IN checks that employee's department name is sales)
--and then using OR we check that the salary is above 75000
--if any one condition is true then it will return the employee

--task 5
SELECT *
FROM Employee
WHERE Email LIKE '%'+FirstName+'%'

--task 6
SELECT *
FROM Employee
ORDER BY DateOfJoining DESC
OFFSET 5 ROWS
FETCH NEXT 5 ROWS ONLY;

--task 7
SELECT *
FROM Employee
WHERE (Department = 'it' AND Salary>60000) OR (Department='hr' AND DateOfJoining < '2020-01-01')
ORDER BY DateOfJoining ASC