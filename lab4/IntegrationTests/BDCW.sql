create database warehouse
go


--create schema warehouse2
--go


create table warehouse2.Products 
(
Id int primary key, 
[Name] varchar(30), 
[value] int,
 dateCome date,
 dateProduction date
)
go

create table warehouse2.InventoryProduct
(
inventory_number int primary key, 
product_Id int REFERENCES  warehouse2.Products (Id)
)
go

create table warehouse2.Place
(
Id int primary key, 
number_stay int,
number_layer int, 
size int
)
go

create table warehouse2.PlaceofObject
(
Id int primary key, 
PlaceId int REFERENCES  warehouse2.Place (Id),
InventoryId int REFERENCES  warehouse2.InventoryProduct (inventory_number)
)
go

create table dbo.Persons
(
[Login] varchar(50) primary key,
[Name] varchar(50), 
SecondName varchar(50),
Position varchar(50),
DateOfBirthday date,
[password] varchar(50) unique,
number_of_come int
)

create table warehouse2.Useful
(
InventoryId int REFERENCES  warehouse2.InventoryProduct (inventory_number) primary key,
PersonId varchar(50) REFERENCES  dbo.Persons ([Login]),
DateOfStart date
)
go



insert into warehouse2.Products values
(1, 'microscop', 2, null, null),
(2, 'LUPA', 2, null, null)


insert into warehouse2.InventoryProduct values
--( 1, 1),
( 3, 1),
( 23, 2)

insert into warehouse2.Place values
(1, 1, 1, 50),
(2, 2, 3, 50),
(3, 2, 4, 50),
(4, 2, 5, 50),
(5, 2, 6, 50)

insert into warehouse2.PlaceofObject values
(1,1,23),
--(2,2,1),
--(3,3,1),
(4,4,3),
(5,5,3)

select * from warehouse2.Place

insert into dbo.Persons values
( '123', 'b', 'm','admin', '1912-10-25' ,'va',0),
( 'aa', 'g', 'b','worker', '1962-10-25' ,'jt',0),
( 'as', 'g', 'b','hradmin', '1956-10-25' ,'ji',0)

insert into warehouse2.Useful values
( 1, 'f', null),

go


--drop table warehouse2.InventoryProduct
--drop table warehouse2.Products
--drop table warehouse2.Place
--drop table warehouse2.PlaceofObject
--drop table warehouse2.Useful
--drop table dbo.Persons
