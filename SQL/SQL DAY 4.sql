use EmpData

create table Departments(
       DepartmentId int Primary Key,
       DepartmentName varchar(50)  not null unique);

create table Employees(
       EmployeeId int Primary Key ,
       EmployeeName varchar(50) not null,
       Salary int check (Salary>15000),
       HireDate Date,
       DepartmentId int,
       Foreign Key(DepartmentId) references Departments(DepartmentId)
);


-------------------query 1---------------------

--Add column Email (Unique).
alter table Employees add Email varchar(50) unique;


--Add column IsActive (Default 1).
alter table Employees add IsActive varchar(50) default 1;


--Modify Salary column to allow decimal values.
alter table Employees 
alter column Salary decimal(10,2);


-- Add constraint so HireDate cannot be a future date.
alter table Employees
add constraint chk_HireDate check(HireDate<getdate());




-------------------query 2---------------------
insert into Departments values
(101,'HR'),
(102,'IT'),
(103,'Finance'),
(104,'Admin'),
(105,'Sales');

--Insert at least 8 employees across different departments.

insert into Employees values(1,'Het',500000,'2020-01-01',101,'het@gmail.com',1),
(2,'niken',470000,'2022-01-01',101,'niken@gmail.com',1),
(3,'mann',430000,'2021-01-01',102,'mann@gmail.com',1),
(4,'ayush',200000,'2023-01-01',102,'ayush@gmail.com',1),
(5,'krunal',450000,'2020-01-01',103,'krunal@gmail.com',1),
(6,'devam',350000,'2022-01-01',103,'devam@gmail.com',1),
(7,'raj',400000,'2021-01-01',104,'raj@gmail.com',1),
(8,'aashish',40000,'2023-01-01',104,'aashish@gmail.com',1);


--Increase the salary of employees in one department by 5%.

update Employees
set Salary=Salary+(Salary*0.05)
where DepartmentId=101


--Deactivate employees hired before a specific date.
update Employees
set IsActive=0
where HireDate<'2022-01-01'


--Delete employees who are marked inactive.

delete Employees
where IsActive=0


--Transfer 2 employees from one department to another.

update Employees
set DepartmentId=105
where EmployeeId= 4 or EmployeeId=6;
select * from Employees

-------------------query 3---------------------


--Show employees with department names.

select e.EmployeeName ,d.DepartmentName
from Employees e
join Departments d
on e.DepartmentId=d.DepartmentId
group by e.EmployeeName, d.DepartmentName


--Show departments with no employees.

select e.EmployeeName ,d.DepartmentName
from Employees e
right join Departments d
on e.DepartmentId=d.DepartmentId
group by e.EmployeeName, d.DepartmentName


--Show highest salary in each department.


/*
select e.EmployeeName ,d.DepartmentName,e.Salary
from Employees e
join Departments d
on e.DepartmentId=d.DepartmentId
where e.Salary=(
select max(Salary)
from Employees
where DepartmentId=e.DepartmentId)
*/

select d.DepartmentName ,max(e.Salary) 
from Employees e
join Departments d
on e.DepartmentId=d.DepartmentId
group by d.DepartmentName
