CREATE TABLE Categories 
(
	Id int not null primary key,
	CategoryName nvarchar(MAX) not null,
)

CREATE TABLE Roles 
(
	Id int not null primary key,
	RoleName nvarchar(MAX) not null,
)

CREATE TABLE Addresses 
(
	Id int not null primary key,
	StreetName  nvarchar(MAX) not null,
	PostalCode nvarchar(MAX) not null,
	City nvarchar(MAX) not null,
)

CREATE TABLE Products 
(
	Id int not null primary key,
	Title nvarchar(MAX) not null,
	Price money not null,
	CategoryId int not null references Categories(Id),
)

CREATE TABLE Customers 
(
	Id int not null primary key,
	FirstName nvarchar(MAX) not null,
	LastName nvarchar(MAX) not null,
	Email nvarchar(MAX) not null,
	RoleId int not null references Roles(Id),
	AddressId int not null references Addresses(Id),
)