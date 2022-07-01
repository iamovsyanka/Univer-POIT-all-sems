use master  
go

CREATE DATABASE Java;
go

use Java;
go

CREATE TABLE [dbo].[Orders](
	[Id] [int] NOT NULL,
	[DateOfReceipt] [date] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go

CREATE TABLE [dbo].[Product](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
go

CREATE TABLE [dbo].[ProductsInOrders](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Count] [int] NOT NULL
) ON [PRIMARY]
go

ALTER TABLE [dbo].[ProductsInOrders]  WITH CHECK ADD  CONSTRAINT [FK_ProductsInOrders_Orders1] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
go

ALTER TABLE [dbo].[ProductsInOrders] CHECK CONSTRAINT [FK_ProductsInOrders_Orders1]
GO

ALTER TABLE [dbo].[ProductsInOrders]  WITH CHECK ADD  CONSTRAINT [FK_ProductsInOrders_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
go

ALTER TABLE [dbo].[ProductsInOrders] CHECK CONSTRAINT [FK_ProductsInOrders_Product]
go

INSERT INTO [dbo].[Orders]
           ([Id]
           ,[DateOfReceipt])
     VALUES
           (1, '2020-02-20'),
		   (2, '2020-03-03'),
		   (3, '2020-03-05'),
		   (4, '2020-04-04')
go

INSERT INTO [dbo].[Product]
           ([Id]
           ,[Name]
           ,[Description]
           ,[Price])
     VALUES
           (1, 'Banan', 'Eat', 45),
		   (2, 'Milk', 'Eat', 55),
		   (3, 'Kvas', 'Eat', 70),
		   (4, 'Water', 'Eat', 51),
		   (5, 'Ovsyanka', 'Eat', 10),
		   (6, 'Rice', 'Eat', 11)
go

INSERT INTO [dbo].[ProductsInOrders]
           ([OrderId]
           ,[ProductId]
           ,[Count])
     VALUES
           (1, 1, 25),
		   (2, 4, 160),
		   (3, 3, 55)
go