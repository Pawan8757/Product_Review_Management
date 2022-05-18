create procedure spUpdateEmlpyeeSalary001

@id int,
@month varchar(20),
@salary int,
@Emplyeeid int
as
begin
update Salary
set Salary=@salary
where SalaryId=@id and SalaryMonth=@month and Employeeid=@Emplyeeid;
Select e.Emplyeeid,e.EmployeeName,s.Salary,s.SalaryMonth,s.SalaryId
from employee_payroll7 e inner join Salary s
on e.EmplyeeId=s.Employeeid where s.SalaryId=@id;
end

