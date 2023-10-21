IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases
			WHERE name = 'SportDress')
BEGIN
	DROP DATABASE SportDress
	print '' print '*** database of SportDress dropped'
END

GO
CREATE DATABASE SportDress
GO
print '' print '*** database of SportDress created'

GO
USE [SportDress]
GO
print '' print '*** database of SportDress is in use'

GO
CREATE TABLE [dbo].[Employees]
(
	[EmployeeID]		[int]	IDENTITY(100000,1)	NOT NULL,
	[GivenName]	[nvarchar](50)	NOT NULL,
	[FamilyName]	[nvarchar](50)	NOT NULL,
	[PhoneNumber]	[nvarchar](11)	NOT NULL,
	[Email]		[nvarchar](250)	NOT NULL,
	[PasswordHash]	[nvarchar](100)	NOT NULL,
	[Active]	[bit] default 1	NOT NULL,
	CONSTRAINT [pk_EmployeeID] PRIMARY KEY ([EmployeeID])
)
GO
print '' print '*** Employees table  created'

GO
print '' print '*** inserting samples data in employees table ***'
GO
INSERT INTO [dbo].[Employees]
	([GivenName], [FamilyName],[PhoneNumber],[Email],[PasswordHash],[Active])
	VALUES
	('first', 'employee', '3190000001','firstEmployee@company.com','9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08',1),
	('second','employee','3190000002','secondEmployee@company.com', '9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08',1),
		('third','employee','3190000003','third@company.com', '9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08',0)
GO
SELECT [EmployeeID],[GivenName], [FamilyName] FROM [dbo].[employees]
GO

CREATE TABLE [dbo].[Roles]
(
	[RoleID]	[nvarchar](50)	NOT NULL,
	[Description]	[nvarchar](255)	NOT NULL
	CONSTRAINT [pk_RoleID] PRIMARY KEY ([RoleID])
)
GO
print '' print '*** Roles table  created'

GO
print '' print '*** inserting samples data in Roles table ***'
GO
INSERT INTO [dbo].[Roles]
	([RoleID], [Description])
	VALUES
	('employee', 'view and all views'),
	('manager','view and edit all views'),
	('admin','creat and update permissions')
GO
SELECT [RoleID], [Description] FROM [dbo].[Roles]

GO
CREATE TABLE [dbo].[EmployeesRoles]
(
	[EmployeeID]	[int]	NOT NULL,
	[RoleID]	[nvarchar](50)	NOT NULL,
	CONSTRAINT [fk_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [Employees]([EmployeeID]),
	CONSTRAINT [fk_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles]([RoleId]),
	CONSTRAINT [pk_RoleID_EmployeeID] PRIMARY KEY ([RoleID],[EmployeeID])
)
GO
print '' print '*** EmployeesRoles table  created'
GO
print '' print '*** inserting samples data in EmployeesRoles table ***'
GO
INSERT INTO [dbo].[EmployeesRoles]
	([EmployeeID], [RoleID])
	VALUES
	(100000, 'admin'),
	(100001,'manager'),
	(100002,'employee')
GO
SELECT [EmployeeID], [RoleID] FROM [dbo].[EmployeesRoles]

GO
CREATE TABLE [dbo].[Zipcodes]
(
	[zipcode]	[nvarchar](10)	NOT NULL,
	[city]		[nvarchar](50)	NOT NULL,
	[state]		[nvarchar](50)	NOT NULL
	CONSTRAINT [pk_zipcode] PRIMARY KEY ([zipcode])
)
GO
print '' print '*** Zipcodes table  created'
GO
print '' print '*** inserting samples data in Zipcodes table ***'
GO
INSERT INTO [dbo].[Zipcodes]
	([zipcode], [city],[state])
	VALUES
	('52404', 'cedar rapids','iowa')
GO
SELECT [zipcode], [city] FROM [dbo].[Zipcodes]


GO
CREATE TABLE [dbo].[Customers]
(
	[CustomerID]	[int]	IDENTITY(100000,1)	NOT NULL,
	[GivenName]	[nvarchar](50)	NOT NULL,
	[FamilyName]	[nvarchar](50)	NOT NULL,
	[PhoneNumber]	[nvarchar](11)	NOT NULL,
	[Email]		[nvarchar](250)	NOT NULL,
	[line1]		[nvarchar](250)	NOT NULL,
	[line2]		[nvarchar](250)	,
	[zipcode]	[nvarchar](10)	NOT NULL,
	CONSTRAINT [pk_CustomerID] PRIMARY KEY ([CustomerID]),
	CONSTRAINT [fk_zipcode] FOREIGN KEY ([zipcode]) REFERENCES [Zipcodes]([zipcode]),
)
GO
print '' print '*** Customers table  created'
Go
print '' print '*** inserting samples data in Customers table ***'
GO
INSERT INTO [dbo].[Customers]
	([GivenName], [FamilyName],[PhoneNumber],[Email],[line1],[line2],[zipcode])
	VALUES
	('first', 'customer','3180000001','firstCustomer@email.com','line1','line2','52404')
GO
SELECT [CustomerID], [GivenName],[zipcode] FROM [dbo].[Customers]


GO
CREATE TABLE [dbo].[CustomersCreditCards]
(
	[CustomerID]	[int]	NOT NULL,
	[CreditCardNumber]	[nvarchar](50)	NOT NULL,
	[zipcode]	[nvarchar](10)	NOT NULL,
	[cvv]	[nvarchar](11)	NOT NULL,
	[dateOfExpiration]	[nvarchar](250)	NOT NULL,
	[nameOnTheCard]		[nvarchar](250)	NOT NULL,
	CONSTRAINT [pk_CustomerCreditCard] PRIMARY KEY ([CustomerID],[CreditCardNumber]),
	CONSTRAINT [fk_CustomerID_CustomersCreditCards] FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([CustomerID]),
	CONSTRAINT [fk_zipcode_CustomersCreditCards] FOREIGN KEY ([zipcode]) REFERENCES [zipcodes]([zipcode])
)
Go
print '' print '*** CustomersCreditCards table created ***'
Go
print '' print '*** inserting samples data in CustomersCreditCards table ***'
GO
INSERT INTO [dbo].[CustomersCreditCards]
	([CustomerID], [CreditCardNumber],[zipcode],[cvv],[dateOfExpiration],[nameOnTheCard])
	VALUES
	(100000, '1234567891011','52404','980','10/10/2040','first customer')
Go
SELECT [CustomerID], [CreditCardNumber], [zipcode] FROM CustomersCreditCards

GO
CREATE TABLE [dbo].[productstypes]
(
	[productTypeName]	[nvarchar](50)	NOT NULL,
	[discription]	[nvarchar](255)	NOT NULL,
	CONSTRAINT [pk_productTypeName] PRIMARY KEY ([productTypeName])
)
Go
print '' print '*** productstypes table created ***'
Go
print '' print '*** inserting samples data in productstypes table ***'
GO
INSERT INTO [dbo].[productstypes]
	([productTypeName], [discription])
	VALUES
	('T-shirt', 'all t-shirts'),
	('shoes','all foot covers')
Go
SELECT [productTypeName], [discription] FROM productstypes

GO
CREATE TABLE [dbo].[productsSizes]
(
	[productsSizeName]	[nvarchar](4)	NOT NULL,
	[discription]	[nvarchar](255)	,
	CONSTRAINT [pk_productsSizeName] PRIMARY KEY ([productsSizeName])
)
Go
print '' print '*** inserting samples data in productsSizes table ***'
GO
INSERT INTO [dbo].[productsSizes]
	([productsSizeName], [discription])
	VALUES
	('xs', ''),
	('s',''),
	('m',''),
	('l',''),
	('xl',''),
	('xxl','')
Go
SELECT [productsSizeName], [discription] FROM productsSizes

GO
CREATE TABLE [dbo].[products]
(
	[productID]	[int]	IDENTITY(100000,1)	NOT NULL,
	[productName]	[nvarchar](50)	NOT NULL,
	[type]	[nvarchar](50)	NOT NULL,
	[size]	[nvarchar](4)	NOT NULL,
	CONSTRAINT [pk_productID] PRIMARY KEY ([productID]),
	CONSTRAINT [fk_type] FOREIGN KEY ([type]) REFERENCES [productstypes]([productTypeName]),
	CONSTRAINT [fk_size] FOREIGN KEY ([size]) REFERENCES [productsSizes]([productsSizeName])
)
GO
print '' print '*** products table  created'
Go
print '' print '*** inserting samples data in products table ***'
GO
INSERT INTO [dbo].[products]
	([productName], [type],[size])
	VALUES
	('product1', 'T-shirt','l')
Go
SELECT [productName], [type], [size] FROM products

GO
CREATE TABLE [dbo].[productsImages]
(
	[imageID]	[int]	IDENTITY(100000,1)	NOT NULL,
	[productID]	[int]	NOT NULL,
	[imageUrl]	[nvarchar](255)	NOT NULL,
	CONSTRAINT [pk_imageID] PRIMARY KEY ([imageID]),
	CONSTRAINT [fk_productID] FOREIGN KEY ([productID]) REFERENCES [products]([productID])
)
GO
print '' print '*** productsImages table  created'
Go
print '' print '*** inserting samples data in productsImages table ***'
GO
INSERT INTO [dbo].[productsImages]
	([productID], [imageUrl])
	VALUES
	('100000', 'http://images.image1')
Go
SELECT [imageID], [productID], [imageUrl] FROM productsImages
GO
print '' print '*** creating sp_verify_user'
GO
CREATE PROCEDURE [dbo].[sp_verify_user]
(
	@Email		[nvarchar](250),
	@PasswordHash	[nvarchar](100)
)
AS
	BEGIN
		SELECT Email,PasswordHash
		FROM [dbo].[Employees]
		WHERE Email = @Email
		AND PasswordHash = @PasswordHash
	END
GO