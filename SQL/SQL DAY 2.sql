use Employee_Data

select * from Employee

create table DepartmentInfo(

    DepartmentId Int,
 	Department VARCHAR(50)
)

INSERT INTO DepartmentInfo(DepartmentId,Department)
VALUES(1,'hr'),(2,'sales'),(3,'finance'),(4,'it'),(5,'sql'),(6,'networking');

select * from DepartmentInfo



--task 1
--implemented  view that display employee name , employee id and department id

create view vw_EmployeeBasicInfo as
select 
    e.EmployeeID,
    e.FirstName,
    d.DepartmentId,
    d.Department
from Employee e
join DepartmentInfo d
on e.Department=d.Department;

SELECT * FROM vw_EmployeeBasicInfo;


--task 2
--implemented Common table expression(CTE) to fetch finance data only

with cte_finance(EmployeeId,FirstName,LastName,Email,Department,Salary,DateOfJoining) as(
select * from Employee
where Department='finance'
)
select * from cte_finance


--task 3
--created temporary table to store hr employee data

select *
into #temphr
from Employee
where Department='hr'

select * from #temphr


--task 4
--employee with more than one skills

create table skills(
EmployeeID INT,
EmployeeSkill VARCHAR(50)
foreign key (EmployeeID) references employee(EmployeeID)
)

INSERT INTO Skills(EmployeeID, EmployeeSkill) VALUES
(101,'SQL'),
(101,'C#'),
(101,'Azure'),
(102,'Excel'),
(103,'Accounting'),
(103,'Taxation'),
(104,'SQL'),
(105,'C#'),
(105,'Azure'),
(106,'Excel'),
(107,'Accounting'),
(108,'Taxation'),
(108,'SQL'),
(109,'C#'),
(110,'Azure'),
(110,'Excel'),
(110,'Accounting'),
(102,'Taxation');


SELECT e.EmployeeID, e.FirstName, COUNT(s.EmployeeSkill) AS SkillCount
FROM Employee e
JOIN Skills s
ON e.EmployeeID = s.EmployeeID
GROUP BY e.EmployeeID, e.FirstName
HAVING COUNT(s.EmployeeSkill) > 1;

select * from Employee where EmployeeID in
(select EmployeeID from skills s group by s.EmployeeID having count(s.EmployeeID)>1)


--task 5

alter table DepartmentInfo
alter column DepartmentId int not null;

alter table DepartmentInfo
add constraint pk_DepartmentInfo
primary key(DepartmentId);

alter table Employee
alter column EmployeeID int not null;

alter table Employee
add DepartmentId int;

update e
set DepartmentId = d.DepartmentId
from Employee e
join DepartmentInfo d
on e.Department = d.Department;

alter table Employee
add constraint pk_employee
primary key(EmployeeID);

alter table Employee
add constraint uq_employee_email
unique(Email);

alter table Employee
add constraint fk_employee_department
foreign key(DepartmentId)
references DepartmentInfo(DepartmentId);




/*
primary key is a column that uniquely identifies each row in a table and cannot contain null value and must be unique, only one primary key in a table
foreign key creates relation between two tables. ensures the value exist in parent table
unique key ensures duplicate values are not allowed in a column, table can have more than one unique keys
*/


--task 4 another approach
create table Skill(
    SkillId int identity primary key,
    SkillName varchar(50) unique
);
insert into Skill(SkillName)
values ('SQL'),('C#'),('Azure'),('Excel'),('Accounting'),('Taxation');

create table EmployeeSkill(
    EmployeeID int,
    SkillId int,
    primary key(EmployeeID, SkillId),
    foreign key (EmployeeID) references Employee(EmployeeID),
    foreign key (SkillId) references Skill(SkillId)
);
insert into EmployeeSkill(EmployeeID, SkillId) values
(101,1),(101,2),(101,3),
(102,4),(102,6),
(103,5),(103,6),
(104,1),
(105,2),(105,3),
(106,4),
(107,5),
(108,6),(108,1),
(109,2),
(110,3),(110,4),(110,5),
(111,1),(111,4);

select e.EmployeeID, e.FirstName, count(es.SkillId) as skillcount
from Employee e
join EmployeeSkill as es
on e.EmployeeID=es.EmployeeID
group by e.EmployeeID,e.FirstName
having count(es.SkillId)>1