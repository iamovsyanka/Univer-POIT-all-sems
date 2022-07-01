--1      
SET NOCOUNT ON
IF exists (SELECT * FROM  SYS.OBJECTS
	            WHERE OBJECT_ID = object_id(N'DBO.X') )	            
DROP TABLE X; 

DECLARE @c int, 
		@flag char = 'c';

SET IMPLICIT_TRANSACTIONS ON   

CREATE TABLE X(K int );                         
INSERT X VALUES (1), (2), (3);
SET @c = (SELECT count(*) FROM X);
PRINT 'количество строк в таблице X: ' + cast( @c as varchar(2));

IF @flag = 'c'  commit;                   
ELSE		    rollback;   

SET IMPLICIT_TRANSACTIONS OFF
	
IF exists (SELECT * FROM  SYS.OBJECTS
	            WHERE OBJECT_ID = object_id(N'DBO.X') )	  
PRINT 'таблица X есть';  
ELSE PRINT 'таблицы X нет'
GO

--2
use Concert;

BEGIN TRY        
	BEGIN TRAN
		INSERT Concerts values ('Ashe', 20, 'A', '2020-05-05 21:00:00');
	    INSERT Concerts values ('AJR', 15, 'B');
	COMMIT TRAN;
END TRY
BEGIN CATCH
	PRINT 'ошибка: ' + 
	CASE 
		WHEN error_number() = 2627 and patindex('%Conserts_PK%', error_message()) > 0 then 'дублирование '
		ELSE 'неизвестная ошибка: '+ cast(error_number() as  varchar(5)) + error_message()  
	END;
	IF @@trancount > 0 rollback TRAN;   
END CATCH;

SELECT * FROM Concerts;
GO

--3
use Java;

DECLARE @point varchar(32);
BEGIN TRY     
	BEGIN TRAN
		SET @point = 'p1' save tran @point
		INSERT Product values (7, 'Avokado', 'Eat', 50);
		SET @point = 'p2'; SAVE TRAN @point;
	    DELETE Product WHERE [Name] = 'Banan'
		SET @point = 'p3'; SAVE TRAN @point;
	COMMIT TRAN;
END TRY
BEGIN CATCH
	PRINT 'error: ' + 
	CASE
		WHEN error_number() = 2627 and patindex('%PK_Product%', error_message()) > 0 then N'дублирование ' 
        ELSE N'неизвестная ошибка: ' + cast(@@Trancount as  varchar(5)) + '==' + cast(error_number() as  varchar(5)) + error_message()  
	END; 
    IF @@trancount > 0
		BEGIN
		   PRINT 'контрольная точка: '+ @point;
		   ROLLBACK TRAN @point;
		   COMMIT TRAN;
		END; 
END CATCH;

SELECT * FROM Product;
GO

--4
use Java;
	-- A ---
set transaction isolation level READ UNCOMMITTED 
begin transaction 
	-------------------------- t1 ------------------
	SELECT @@SPID, 'INSERT Product' 'результат', * FROM Product WHERE [Name] = 'Apple';
	SELECT @@SPID, 'update Product'  'результат',  * FROM Product WHERE [Name] = 'Ovsyanka';
commit; 
	-------------------------- t2 -----------------
	--- B --	
begin transaction 
	SELECT @@SPID
	INSERT Product VALUES (11, 'Apple', 'Eat', 10); 
	UPDATE Product SET [Name] = 'Ovsyanka' WHERE [Name] = 'Apple' 
	-------------------------- t1 --------------------
	-------------------------- t2 --------------------
rollback;
GO

--5
use Java;
	-- A ---
set transaction isolation level READ COMMITTED 
begin transaction 
	SELECT count(*) FROM Product WHERE [Name] = 'Milk';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	SELECT  'update Заказы'  'результат', count(*) FROM Product WHERE [Name] = 'Milk';
commit; 
	--- B ---	
begin transaction 	  
	-------------------------- t1 --------------------
	UPDATE Product SET [Name] = 'Milk1' WHERE [Name] = 'Milk';
commit; 
	-------------------------- t2 --------------------
GO

--6
use Java;
-- A ---
set transaction isolation level  REPEATABLE READ 
begin transaction 
	SELECT [Name] FROM Product WHERE Price = 11;
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	SELECT 
		CASE
          WHEN [Name] = 'Rice' then 'insert Product'  
		  ELSE ' ' 
		END 'результат', [Name] FROM Product WHERE [Name] = 'Rice';
commit; 
	--- B ---	
begin transaction 	  
	-------------------------- t1 --------------------
    INSERT Product VALUES (18, 'Rice', 'Eat', 11); 
commit; 
	-------------------------- t2 --------------------
GO

--7
use Java;
	--- A ---
set transaction isolation level SERIALIZABLE 
begin transaction 
	DELETE FROM Product WHERE [Name] = 'Rice'; 
    INSERT Product VALUES (14, 'Rice', 'Eat', 11); 
    UPDATE Product SET Price = 11 WHERE [Name] = 'Rice';
    SELECT Price FROM Product WHERE [Name] = 'Rice';
	-------------------------- t1 -----------------
	SELECT Price FROM Product WHERE [Name] = 'Rice';
	-------------------------- t2 ------------------ 
commit; 	

	--- B ---	
begin transaction 	  
	DELETE FROM Product WHERE [Name] = 'Rice'; 
    INSERT Product VALUES (14, 'Rice', 'Eat', 11); 
    UPDATE Product SET Price = 11 WHERE [Name] = 'Rice';
    SELECT Price FROM Product WHERE [Name] = 'Rice';
	-------------------------- t1 -----------------
	SELECT Price FROM Product WHERE [Name] = 'Rice';
GO

--8
use Java;

BEGIN TRAN
	INSERT Product values (15, 'Chiken', 'Eat', 110);
	BEGIN TRAN
			INSERT Product values (16, 'Chiken', 'Eat', 110);
		COMMIT;
	IF @@trancount > 0 ROLLBACK TRAN;
SELECT * FROM Product;
GO

--9
use Shop;

BEGIN TRAN
	INSERT Products VALUES('Milk', NULL, 13);
	IF CAST(RAND()* 10 AS int) % 2 = 0   COMMIT TRAN;
	IF CAST(RAND()* 10 AS int) % 2 != 0  ROLLBACK TRAN;
SELECT * FROM Products;
GO