USE SportsStore
GO

IF EXISTS (
       SELECT TABLE_NAME
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'OrderLines'
   )
    DROP TABLE OrderLines
GO

IF EXISTS (
       SELECT TABLE_NAME
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'Orders'
)
    DROP TABLE Orders
GO

IF EXISTS (
       SELECT TABLE_NAME
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'Products'
   )
    DROP TABLE Products
GO

CREATE TABLE Products
(
	ProductId         INT IDENTITY(1, 1) NOT NULL,
	[Name]            NVARCHAR(100) NOT NULL,
	[Description]     NVARCHAR(500) NOT NULL,
	Category          NVARCHAR(50) NOT NULL,
	Price             DECIMAL(16, 2) NOT NULL,
	CONSTRAINT [Products_ProductId_PK] PRIMARY KEY CLUSTERED(ProductId ASC)
)
GO

CREATE TABLE Orders
(
	OrderId        INT IDENTITY(1, 1) NOT NULL,
	[Name]         NVARCHAR(MAX) NULL,
	Line1          NVARCHAR(MAX) NULL,
	Line2          NVARCHAR(MAX) NULL,
	Line3          NVARCHAR(MAX) NULL,
	City           NVARCHAR(MAX) NULL,
	[State]        NVARCHAR(MAX) NULL,
	GiftWrap       BIT NOT NULL,
	Dispatched     BIT NOT NULL,
	CONSTRAINT Orders_OrderId_PK PRIMARY KEY CLUSTERED(OrderId ASC)
)
GO

CREATE TABLE OrderLines
(
	OrderLineId           INT IDENTITY(1, 1) NOT NULL,
	Quantity              INT NOT NULL,
	Product_ProductId     INT NULL,
	Order_OrderId         INT NULL,
	CONSTRAINT OrderLines_OrderLineId_PK PRIMARY KEY CLUSTERED(OrderLineId ASC),
	CONSTRAINT OrderLines_Products_Product_ProductId_FK FOREIGN KEY(Product_ProductId) 
	REFERENCES Products(ProductId),
	CONSTRAINT OrderLines_Orders_Order_OrderId_FK FOREIGN KEY(Order_OrderId) 
	REFERENCES Orders(OrderId)
)
GO