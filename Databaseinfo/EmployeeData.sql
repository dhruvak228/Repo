DROP DATABASE IF EXISTS Employeedata;
create databse Employeedata;
use Employeedata;
create table employee(empid integer primary key auto_increment,empname varchar(75),job varchar(75),joiningdate date);

insert into employee values(26,"Dhruva","C Sharp","16-01-2023");
insert into employee(empname,job,joiningdate) values("Pranav","Full Stack Developer","01-06-2023");