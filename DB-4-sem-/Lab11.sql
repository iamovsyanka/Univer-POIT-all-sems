--1
use RO_UNIVER

DECLARE Cursor1 CURSOR 
				FOR SELECT sub.[SUBJECT] FROM [SUBJECT] sub 
										 WHERE sub.PULPIT = N'ИСиТ'; 
DECLARE	@s nvarchar(10), 
		@str nvarchar(300) = ' '; 
		
OPEN Cursor1; 
FETCH Cursor1 into @s;

PRINT 'Cписок дисциплин на кафедре ИСиТ:';
WHILE @@FETCH_STATUS = 0
	BEGIN  
		SET @str = RTRIM(@s) + ', ' + @str; 
		FETCH Cursor1 into @s;
	END; 

CLOSE Cursor1; 
PRINT @str; 
DEALLOCATE Cursor1; 
GO 

--2
use Shop;

--local
DECLARE LocCursor CURSOR LOCAL                            
					FOR SELECT [Name], IdProducer FROM Products;
DECLARE @pr char(20), 
		@id int;  
		
OPEN LocCursor;	  
FETCH LocCursor into @pr, @id; 	
      PRINT '1. ' + @pr + cast(@id as varchar(6));   
      GO

DECLARE @pr char(20), 
		@id int;
FETCH LocCursor into @pr, @id; 	
      PRINT '2. ' + @pr + cast(@id as varchar(6));   
      GO 

--global
DECLARE GloCursor CURSOR GLOBAL                            
					FOR SELECT [Name], IdProducer FROM Products;
DECLARE @pr char(20), 
		@id int;  
		
OPEN GloCursor;	  
FETCH GloCursor into @pr, @id; 	
      PRINT '1. ' + @pr + cast(@id as varchar(6));   
      GO

DECLARE @pr char(20), 
		@id int;
FETCH GloCursor into @pr, @id; 	
      PRINT '2. ' + @pr + cast(@id as varchar(6));   
      GO	  

--3
use Shop;

--static
DECLARE StaCursor CURSOR LOCAL STATIC                            
					FOR SELECT [Name], IdProducer FROM Products;
DECLARE @pr char(20), 
		@id int;  
		
OPEN StaCursor;	
PRINT 'Количество строк: ' + cast(@@CURSOR_ROWS as varchar(5)); 

UPDATE Products SET [Name] = 'Baton3' WHERE Id = 1078;
DELETE Products WHERE IdProducer = 15;
INSERT Products ([Name], IdProducer) 
		  values('Bylka', 13);

FETCH StaCursor into @pr, @id; 	
WHILE @@FETCH_STATUS = 0
	BEGIN  
		PRINT @pr + ' ' + cast(@id as varchar(6)); 
		FETCH StaCursor into @pr, @id;
	END; 
CLOSE StaCursor;
GO

--dynamic
DECLARE DunCursor CURSOR LOCAL DYNAMIC                            
					FOR SELECT [Name], IdProducer FROM Products;
DECLARE @pr char(20), 
		@id int;  	

OPEN DunCursor;	
PRINT 'Количество строк: ' + cast(@@CURSOR_ROWS as varchar(5)); 

UPDATE Products SET [Name] = 'Baton' WHERE Id = 1078;
DELETE Products WHERE IdProducer = 15;
INSERT Products ([Name], IdProducer) 
		  values('Bylka', 13);

FETCH DunCursor into @pr, @id; 	
WHILE @@FETCH_STATUS = 0
	BEGIN  
		PRINT @pr + ' ' + cast(@id as varchar(6)); 
		FETCH DunCursor into @pr, @id;
	END; 
CLOSE DunCursor;
GO

--4 
use Shop;

DECLARE DunCursor CURSOR LOCAL STATIC SCROLL                           
					FOR SELECT [Name], IdProducer FROM Products;
DECLARE @pr char(20), 
		@id int;  	

OPEN DunCursor;	
PRINT 'Количество строк: ' + cast(@@CURSOR_ROWS as varchar(5)); 

FETCH FIRST FROM DunCursor into @pr, @id; 	
PRINT '1. Первая строка ' + @pr + ' ' + cast(@id as varchar(6)); 

FETCH NEXT FROM DunCursor into @pr, @id; 	
PRINT '2. Следующая строка ' + @pr + ' ' + cast(@id as varchar(6)); 

FETCH PRIOR FROM DunCursor into @pr, @id; 	
PRINT '3. Предыдущая строка ' + @pr + ' ' + cast(@id as varchar(6)); 

FETCH ABSOLUTE 3 FROM DunCursor into @pr, @id; 	
PRINT '4. Tретья строка от конца ' + @pr + ' ' + cast(@id as varchar(6));

FETCH LAST FROM DunCursor into @pr, @id; 	
PRINT '5. Последняя строка ' + @pr + ' ' + cast(@id as varchar(6));

CLOSE DunCursor;
GO

--5 
use Java;

DECLARE Cursor5 CURSOR LOCAL DYNAMIC	
						FOR SELECT [Name], [Description], Price FROM Product
						FOR UPDATE;
DECLARE @n varchar(20),
		@d varchar(20),
		@p int;

OPEN Cursor5;
	
--FETCH Cursor5 into @n, @d, @p;
--DELETE Product WHERE CURRENT OF Cursor5;

FETCH Cursor5 into @n, @d, @p; 	
WHILE @@FETCH_STATUS = 0
	BEGIN  
		UPDATE Product SET Price = Price + 5 WHERE CURRENT OF Cursor5;
		PRINT @n + ' ' + @d + ' ' + cast(@p as varchar(6)); 
		FETCH Cursor5 into @n, @d, @p; 
	END; 

CLOSE Cursor5;
GO 

--6 
use Java;

DECLARE Cursor6 CURSOR LOCAL DYNAMIC	
						FOR SELECT OrderId, ProductId, [Count], [Name] FROM ProductsInOrders 
						INNER JOIN Product ON ProductsInOrders.ProductId = Product.Id
						FOR UPDATE;
DECLARE @o int,
		@i int,
		@c int,
		@n varchar(20);

OPEN Cursor6;
FETCH Cursor6 into @o, @i, @c, @n; 	
WHILE @@FETCH_STATUS = 0
	BEGIN  
		IF(@o % 2 = 0)
			UPDATE ProductsInOrders SET [Count] = [Count]*2 WHERE CURRENT OF Cursor6;
		ELSE
			UPDATE ProductsInOrders SET [Count] = [Count] + 5 WHERE CURRENT OF Cursor6;

		FETCH Cursor6 into @o, @i, @c, @n; 
	END; 	 	
CLOSE Cursor6;
GO
