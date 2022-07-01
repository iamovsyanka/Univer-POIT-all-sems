use RO_UNIVER;
go

--1
drop table TR_AUDIT
go

CREATE TABLE TR_AUDIT (
						ID int identity,
						STMT varchar(20)
							check (STMT in ('INS', 'DEL', 'UPD')),
						TRNAME varchar(50),
						CC varchar(300)
					  )
go

DROP TRIGGER TR_TEACHER_INS;
go

CREATE TRIGGER TR_TEACHER_INS ON TEACHER after INSERT
as
DECLARE @a1 varchar(50),
		@a2 varchar(50), 
		@in varchar(300);
PRINT 'Операция: INSERT';
SET @a1 = (SELECT TEACHER FROM inserted);
SET @a2= (SELECT TEACHER_NAME FROM inserted);
SET @in = @a1 + ' ' + @a2;
INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES('INS', 'TR_TEACHER_INS', @in);	
RETURN;  
go

BEGIN TRY        
	BEGIN TRAN
		INSERT INTO TEACHER values(1, 'Василий Василь', 'м', 'ИСиТ');
	COMMIT TRAN;
END TRY
BEGIN CATCH
	PRINT 'ошибка: ' + 
	CASE 
		WHEN error_number() = 2627 and patindex('%TEACHER_PK%', error_message()) > 0 then 'дублирование '
		ELSE 'неизвестная ошибка: '+ cast(error_number() as  varchar(5)) + error_message()  
	END;
		IF @@trancount > 0 rollback TRAN; 
END CATCH;

SELECT * FROM TR_AUDIT;
SELECT * FROM TEACHER;
go

--2
DROP TRIGGER TR_TEACHER_DEL;
go

CREATE TRIGGER TR_TEACHER_DEL ON TEACHER after DELETE
as
DECLARE @a1 varchar(50), 
		@a2 varchar(50), 
		@in varchar(300);
PRINT 'Операция: DELETE';
SET @a1 = (SELECT TEACHER FROM deleted);
SET @a2= (SELECT TEACHER_NAME FROM deleted);
SET @in = @a1 + ' ' + @a2;
INSERT INTO TR_AUDIT(STMT, TRNAME, CC) VALUES('DEL', 'TR_TEACHER_DEL', @in);	         
RETURN;  
go

DELETE TEACHER WHERE TEACHER = '1';
SELECT * FROM TR_AUDIT;
SELECT * FROM TEACHER; 
go

--3
DROP TRIGGER TRIG_TEACHER_UP;
go

CREATE TRIGGER TRIG_TEACHER_UP ON TEACHER after UPDATE
as
DECLARE @a1 varchar(50), 
		@a2 varchar(50), 
		@a11 varchar(50), 
		@a22 varchar(50), 
		@in varchar(300);
SET @a11 = (SELECT TEACHER FROM INSERTED);
SET @a22= (SELECT TEACHER_NAME FROM INSERTED);
SET @a1 = (SELECT TEACHER FROM deleted);
SET @a2 = (SELECT TEACHER_NAME FROM deleted);	 
SET @in = @a1 + ' ' + @a2 + ' - ' + @a11 + ' ' + @a22;
INSERT INTO TR_AUDIT(STMT, TRNAME, CC)  values('UPD', 'TRIG_TEACHER_UP', @in);
RETURN;  
go

UPDATE TEACHER SET TEACHER_NAME = 'Вася' where TEACHER = '1';                  
SELECT * FROM TR_AUDIT; 
SELECT * FROM TEACHER; 
go

--4
CREATE TRIGGER TRIG_TEACHER ON TEACHER after INSERT, DELETE, UPDATE  
as
DECLARE @a1 varchar(50), 
		@a2 varchar(50), 
		@in varchar(300);
DECLARE @ins int = (select count(*) from inserted),
		@del int = (select count(*) from deleted); 
IF @ins > 0 AND  @del = 0  
	begin
		PRINT 'Событие: INSERT';
		SET @a1 = (SELECT TEACHER FROM inserted);
		SET @a2 = (SELECT TEACHER_NAME FROM inserted);	 
		SET @in = @a1 + ' ' + @a2;
		INSERT INTO TR_AUDIT(STMT, TRNAME, CC) values('INS', 'TRIG_TEACHER', @in);
	end;
ELSE IF @ins = 0 and  @del > 0  
	begin 
		PRINT 'Событие: DELETE';
		SET @a1 = (SELECT TEACHER FROM deleted);
		SET @a2 = (SELECT TEACHER_NAME FROM deleted);		 
		SET @in = @a1 + ' ' + @a2;
		INSERT INTO TR_AUDIT(STMT, TRNAME, CC) values('DEL', 'TRIG_TEACHER', @in);
	end;
ELSE IF @ins > 0 and  @del > 0  
	begin 
		PRINT 'Событие: UPDATE'; 
		SET @a1 = (SELECT TEACHER FROM inserted);
		SET @a2 = (SELECT TEACHER_NAME FROM inserted);	 
		SET @in = @a1 + ' ' + @a2;
		SET @a1 = (SELECT TEACHER FROM deleted);
		SET @a2 = (SELECT TEACHER_NAME FROM deleted);		 
		SET @in = @a1 + ' ' + @a2;
		INSERT INTO TR_AUDIT(STMT, TRNAME, CC)  values('UPD', 'TRIG_TEACHER', @in); 
	end;
RETURN;  
go

INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT) values(2, 'Василий Василь', 'м', 'ИСиТ');                   
DELETE TEACHER where TEACHER = '54';        
UPDATE TEACHER set TEACHER_NAME = 'Арсентьев Виталий Арсентьевич' where TEACHER = 'АРС';                
SELECT * FROM TR_AUDIT; 
SELECT * FROM TEACHER;
go

--5
UPDATE TEACHER SET GENDER = 'w' WHERE TEACHER='АРС'
SELECT * FROM TR_AUDIT;
go

--6
CREATE TRIGGER TR_TEACHER_DEL1 ON TEACHER after DELETE  
as 
PRINT 'TR_TEACHER_DEL1';
RETURN;  
go 

CREATE TRIGGER TR_TEACHER_DEL2 ON TEACHER after DELETE  
as 
PRINT 'TR_TEACHER_DEL2';
RETURN;  
go  

CREATE TRIGGER TR_TEACHER_DEL3 ON TEACHER after DELETE 
as 
PRINT 'TR_TEACHER_DEL3';
RETURN;  
go    

SELECT t.name, e.type_desc
		FROM sys.triggers  t join  sys.trigger_events e  
				ON t.object_id = e.object_id  
                      WHERE OBJECT_NAME(t.parent_id) = 'TEACHER' and e.type_desc = 'DELETE' ;  

EXEC SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL3', 
	                        @order = 'First', @stmttype = 'DELETE';

EXEC SP_SETTRIGGERORDER @triggername = 'TR_TEACHER_DEL2', 
	                        @order = 'Last', @stmttype = 'DELETE';

DELETE TEACHER WHERE TEACHER = '2';

SELECT t.name, e.type_desc
		FROM sys.triggers  t join  sys.trigger_events e  
				ON t.object_id = e.object_id  
                      WHERE OBJECT_NAME(t.parent_id) = 'TEACHER' and e.type_desc = 'DELETE' ;  
go

--7
SELECT COUNT(*) FROM TEACHER WHERE GENDER = 'ж'
go

CREATE TRIGGER TR_TEACHER_INS_W	ON TEACHER after INSERT, DELETE, UPDATE  
as
DECLARE @c int = (SELECT COUNT(*) FROM TEACHER WHERE GENDER = 'ж'); 	 
IF (@c > 5) 
	 begin
       raiserror('Количество женщин-преподавателей не должно быть больше 5', 10, 1);
		rollback; 
	 end; 
RETURN;
go

INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT) values(54, 'Демидко Марина Николаевна', 'ж', 'ИСиТ');
INSERT INTO TEACHER(TEACHER, TEACHER_NAME, GENDER, PULPIT) values(34, 'Демидко Марина Николаевна', 'ж', 'ИСиТ');
SELECT * FROM TR_AUDIT;
go

--8
CREATE TRIGGER TR_FACULTY_DEL ON FACULTY instead of DELETE 
as
	raiserror(N'Удаление запрещено', 10, 1);
RETURN;
go

DELETE FACULTY WHERE FACULTY = 'ИДиП';
go

DROP TRIGGER TRIG_TEACHER;
DROP TRIGGER TR_TEACHER_DEL1;
DROP TRIGGER TR_TEACHER_DEL2;
DROP TRIGGER TR_TEACHER_DEL3;
DROP TRIGGER TR_TEACHER_INS_W;
DROP TRIGGER TR_FACULTY_DEL;
go

--9
DROP TRIGGER DDL_TMPF_UNIVER;
go	

CREATE TRIGGER DDL_TMPF_UNIVER on database for DDL_DATABASE_LEVEL_EVENTS  
as   
DECLARE @t varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(50)'),
		@t1 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(50)'),
		@t2 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(50)'); 
begin
   PRINT 'Тип события: ' + @t;
   PRINT 'Имя объекта: ' + @t1;
   PRINT 'Тип объекта: ' + @t2;
   raiserror( N'операции с таблицей запрещены', 16, 1);  
   rollback;    
end;
go

ALTER TABLE TEACHER DROP COLUMN TEACHER_NAME;
go