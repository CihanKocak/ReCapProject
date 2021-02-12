CREATE TABLE Users(
	Id int PRIMARY KEY IDENTITY(1,1),
	FirstName varchar(50),
	LastName varchar(50),
	Email varchar(50),
	Password varchar(50)
)

CREATE TABLE Customers(
	Id int PRIMARY KEY IDENTITY(1,1),
	UserId int,
	CompanyName varchar(50),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
)


CREATE TABLE Rentals(
	Id int PRIMARY KEY IDENTITY(1,1),
	CarId int,
	CustomerId int,
	RentDate datetime,
	ReturnDate datetime,
	FOREIGN KEY (CarId) REFERENCES Cars(CarId),
	FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
)