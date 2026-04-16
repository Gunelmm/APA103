CREATE DATABASE Company;
use Company;

CREATE TABLE Countries(
Id int PRIMARY KEY IDENTITY,
Name nvarchar(30)
)

CREATE TABLE Cities(
Id int PRIMARY KEY IDENTITY,
Name nvarchar(30),
CountryId int,
Foreign key (CountryId) References Countries(Id)
);

CREATE TABLE Employees(
Id int PRIMARY KEY IDENTITY,
Name nvarchar(30),
Surname nvarchar(30),
Age int,
Salary decimal(6,2),
Position nvarchar(30),
IsDeleted BIT,
CityId int,
Foreign key (CityId) References Cities(Id)
);

INSERT INTO Countries (Name)
VALUES ('Azerbaijan'), ('Turkey');

INSERT INTO Cities (Name, CountryId)
VALUES ('Baku', 1), ('Ganja', 1), ('Istanbul', 2);

INSERT INTO Employees (Name, Surname, Age, Salary, Position, IsDeleted, CityId)
VALUES 
('Ali', 'Aliyev', 25, 2500, 'Developer', 0, 1),
('Aysel', 'Mammadova', 30, 1800, 'Reseption', 0, 2),
('Murad', 'Huseynov', 28, 3000, 'Manager', 1, 3);
 
SELECT Employees.Name as EmployeeName, Cities.Name as City, Countries.Name as Country From Employees
join Cities on Employees.CityId = Cities.Id
join Countries on Cities.CountryId = Countries.Id;

Select Employees.Name, Countries.Name as Country From Employees
join Cities on Employees.CityId = Cities.Id
join Countries on Cities.CountryId = Countries.Id
Where Employees.Salary > 2000;

SELECT Cities.Name, Countries.Name
FROM Cities
JOIN Countries ON Cities.CountryId = Countries.Id;

SELECT Name, Surname, Age, Salary, Position, IsDeleted, CityId
FROM Employees
WHERE Position = 'Reseption';

SELECT Employees.Name, Employees.Surname, Cities.Name, Countries.Name
FROM Employees
JOIN Cities ON Employees.CityId = Cities.Id
JOIN Countries ON Cities.CountryId = Countries.Id
WHERE Employees.IsDeleted = 1;

