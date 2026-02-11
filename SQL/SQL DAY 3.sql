use Employee_Data

select * from Employee

--TASK 1

create function TotalExperience(@DateOfJoining date)
returns decimal(10,1)
as 
begin
	return datediff(year,@DateOfJoining,getdate()) 
	end

select EmployeeID,FirstName,DateOfJoining ,dbo.TotalExperience(DateOfJoining) as Experience
from Employee;


--task 2
create function senior(@DepartmentId int)
returns table as
return(
	select e.* ,case
					when dbo.TotalExperience(e.DateOfJoining)>5
					then 'Yes'
					else 'no'
				end as IsSeniorEmp
				from Employee e
				where DepartmentId=@DepartmentId)
select * from dbo.senior(2)
	

--task 3

create procedure AddEmployee
	@EmployeeId int,
	@FirstName varchar(50),
	@LastName varchar(50),
	@email varchar (50),
	@Department varchar(50),
	@salary int,
	@DateOfJoining date
as
begin
	insert into Employee(EmployeeID,FirstName,LastName,Email,Department,Salary,DateOfJoining)
	values(@EmployeeID,@FirstName,@LastName,@Email,@Department,@Salary,@DateOfJoining);
end;

exec AddEmployee 12,'om','kotawala','kotawala@gmail.com','java',500,'2022-02-22'
exec AddEmployee 13,'smit','savaliya','smit@gmail.com','java',100,'2024-12-01'
select * from Employee

--task 4
/*
create procedure TotalSalary(
@StartDate date,
@EndDate date)
as 
begin

select Department,sum(Salary)*DATEDIFF(MONTH,@StartDate,@EndDate)
	as TotalSalaryDepartment
	from Employee
	group by Department;
end
exec TotalSalary '2019-01-01','2025-12-01';
*/
create procedure TotalSalary
@StartDate date,
@EndDate date
as 
begin
	select Department,
	sum(Salary*
		DATEDIFF(
		MONTH,
			case 
				when DateOfJoining> @StartDate
				then DateOfJoining
				else @StartDate
				end,
				@EndDate))
	as TotalSalaryDepartment
	from Employee
	where DateOfJoining <= @EndDate
	group by Department
end;
go
exec TotalSalary '2024-12-01','2025-12-01';
select * from Employee

--task 5


create table Orders(
	OrderId int primary key,
	OrderItem varchar(50),
	CreatedBy varchar(50)
	)
create table OrdersAudit(
	OrderId int ,
	InsertedDate date,
	InsertedBy varchar(50)
	);

go
create trigger AfterInsert
on Orders
after insert
as
begin
	insert into OrdersAudit(OrderId,InsertedDate,InsertedBy)
	select OrderId,getdate(),CreatedBy
	from inserted;
end;

insert into Orders values(1,'vadapav','niken')
select * from OrdersAudit



--task 6

create table ProductDetails(
    ProductId int,
    ProductName varchar(50),
    ProductPrice int,
    ProductStatus varchar(50)
)
insert into ProductDetails(ProductId,ProductName,ProductPrice,ProductStatus)
values
(101,'shoes',5000,'inactive'),
(102,'purse',10000,'inactive'),
(103,'watch',2000,'active'),
(104,'headphone',50000,'inactive'),
(105,'bottle',100,'inactive'),
(106,'iphone',200000,'active')

go
create trigger trg_ProductDelationPrevent
on ProductDetails
instead of delete
AS
begin
    if exists ( select * from deleted where ProductStatus = 'active')
    begin
       print 'can not delete product which active with order'
       return;
    end

    delete from ProductDetails where ProductId IN (
        select ProductID from deleted
    );

end
go
delete from ProductDetails where ProductID = 101
select * from ProductDetails
