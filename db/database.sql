
create database InvoiceManagementDB

use InvoiceManagementDB

go

create table Rol(
RolId int primary key identity(1,1),
NameRol varchar(50),
RegistrationDate datetime default getdate()
)

create table Menu(
MenuId int primary key identity(1,1),
NameMenu varchar(50),
IconMenu varchar(50),
UrlMenu varchar(50)
)

create table MenuRol(
MenuRolId int primary key identity(1,1),
MenuId int references Menu(MenuId),
RolId int references Rol(RolId)
)

create table InvoiceState (
StateId int primary key identity(1,1),
StateName varchar(50),
RegistrationDate datetime default getdate()
);


create table UserInfo(
UserId int primary key identity(1,1),
IdentificationCard varchar(50),
FullName varchar(50),
Age int,
PhoneNumber varchar(50),
Email varchar(100),
UserPassword varchar(100),
RolId int references Rol(RolId),
JobTitle varchar(50),
IsActive bit default 1,
RegistrationDate datetime default getdate()
)

create table InvoiceInfo (
InvoiceId int primary key identity(1,1),
UserId int references UserInfo(UserId),
IssueDate datetime default getdate(),
BusinessName varchar(100),
RNC varchar(50),
NFC varchar(50),
AmountWithoutITBIS decimal(18, 2),
ITBIS decimal(18, 2),
ServicePercentage decimal(5, 2),
TotalAmount decimal(18, 2),
ImageUrl varchar(500),
StateId int references InvoiceState(StateId),
)
