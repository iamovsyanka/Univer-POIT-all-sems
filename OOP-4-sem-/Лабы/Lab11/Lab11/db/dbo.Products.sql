CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Image] IMAGE NULL, 
    [Price] INT NOT NULL, 
    [IdProducer] INT NOT NULL 
)
