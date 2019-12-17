--Create Database if does not Exists
IF  NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'MyDatabase')
    BEGIN
        CREATE DATABASE [MyDatabase]
    END
GO

--Use/Select Database for performing operations
USE MyDatabase
GO

--Create a Table called Contact
CREATE TABLE Contact
(
  ContactId int Primary Key Identity(1,1),
  FirstName nvarchar(50),
  LastName nvarchar(50),
  Email nvarchar(50),
  Phone char(10),
  [Status] nvarchar(10) CHECK ([status] in ('Active','Inactive'))
)
GO

--Insert some values into Contact Table
INSERT INTO Contact values('Deepesh','Chopda','deepeshc@gmail.com', '8983290191','Active')
INSERT INTO Contact values('James','Smith','jamess@gmail.com', '1597534890','Active')
INSERT INTO Contact values('Eric','Brown','ericb@gmail.com', '8668639423','Active')
INSERT INTO Contact values('John','Cena','jhonC@gmail.com', '7418529630','Active')
INSERT INTO Contact values('Jacob','wood','jacobw@gmail.com', '1472583690','Active')
INSERT INTO Contact values('Charlie','son','charlies@gmail.com', '7894561230','Active')
INSERT INTO Contact values('Tiger','Shroff','tigers@gmail.com', '1234567890','Active')
INSERT INTO Contact values('Kartik','Aryan','kartika@gmail.com', '8527419630','Active')
INSERT INTO Contact values('Yash','Chopra','yashc@gmail.com', '7418963250','Inactive')
INSERT INTO Contact values('Sanket','Jain','sanketj@gmail.com', '9631465281','Inactive')
INSERT INTO Contact values('Khirtik','Roshan','khirtikr@gmail.com', '7115151851','Active')
INSERT INTO Contact values('John','Abraham','johnaC@gmail.com', '8113546555','Active')
INSERT INTO Contact values('ShahRukh','Khan','shahrukhk@gmail.com', '1658451161','Active')
INSERT INTO Contact values('Arjun','Kapoor','arjunk@gmail.com', '6183468151','Active')
