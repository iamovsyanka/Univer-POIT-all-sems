use RO_UNIVER;
go

--1
--DROP PROCEDURE PSUBJECT
CREATE PROCEDURE PSUBJECT
as
begin
	DECLARE @n int = (SELECT count(*) from SUBJECT);
	SELECT [SUBJECT] [Код], SUBJECT_NAME [Дисциплина], PULPIT [Кафедра] FROM SUBJECT;
	return @n;
end;

DECLARE @k int;
EXEC @k = PSUBJECT;
print 'Количество предметов: ' + cast(@k as varchar(3));
go

--2
ALTER PROCEDURE PSUBJECT @p varchar(20), @c nvarchar(2) output
as 
begin
	SELECT [SUBJECT] [Код], SUBJECT_NAME [Дисциплина], PULPIT [Кафедра] FROM SUBJECT WHERE [SUBJECT] = @p;
	SET @c = cast(@@rowcount as nvarchar(2));
end;

DECLARE @k int, 
		@k1 nvarchar(2);
EXEC @k = PSUBJECT @p = 'КГ', @c = @k1 output;
PRINT 'Количество предметов: ' + @k1;
go

--3
CREATE TABLE #SUBJECT  (Код varchar(10),
						Дисциплина varchar(50),
						Кафедра varchar(5)
						);

ALTER PROCEDURE PSUBJECT @p varchar(20)
as 
begin
	SELECT [SUBJECT] [Код], SUBJECT_NAME [Дисциплина], PULPIT [Кафедра] FROM SUBJECT WHERE [SUBJECT] = @p;
end;

INSERT #SUBJECT EXEC PSUBJECT @p = 'БД';
INSERT #SUBJECT EXEC PSUBJECT @p = 'КГ';

SELECT * FROM #SUBJECT;
go

--4
--drop PROCEDURE PAUDITORIUM_INSERT
CREATE PROCEDURE PAUDITORIUM_INSERT @a char(20), @n varchar(50), @c int = 0, @t char(10)
as
begin
	begin try
		INSERT into AUDITORIUM(AUDITORIUM, AUDITORIUM_TYPE, AUDITORIUM_CAPACITY, AUDITORIUM_NAME)
						values(@a, @n, @c, @t);
		return 1;
	end try
	begin catch
		print 'Номер ошибки: ' + cast(error_number() as varchar(6));
		print 'Сообщение: ' + error_message();
		print 'Уровень: ' + cast(error_severity() as varchar(6));
		print 'Метка: ' + cast(error_state() as varchar(8));
		print 'Номер строки: ' + cast(error_line() as varchar(8));
		if error_procedure() is not null   
			print 'Имя процедуры: ' + error_procedure();
		return -1;
	end catch;
end;

DECLARE @rc int;  
EXEC @rc = PAUDITORIUM_INSERT @a = '423-3', @n = 'ЛК', @c = 100, @t = '423-3'; 
print 'Код ошибки: ' + cast(@rc as varchar(3));
go

--5
--drop PROCEDURE SUBJECT_REPORT
CREATE PROCEDURE SUBJECT_REPORT @p CHAR(10)
as  
DECLARE @rc int = 0;                            
   begin try    
      DECLARE @sb char(10), 
			  @r varchar(100) = ''; 
      DECLARE sbj CURSOR for 
					SELECT [SUBJECT] from SUBJECT where PULPIT = @p;
	  if not exists(SELECT [SUBJECT] from SUBJECT where PULPIT = @p)
		raiserror('Ошибка', 11, 1);
      else 
      open sbj;	  
	  fetch sbj into @sb;
      print 'Предметы: ';
	  while @@fetch_status = 0
		begin
			set @r = rtrim(@sb) + ', ' + @r;  
			set @rc = @rc + 1;
			fetch sbj into @sb;
		end
	  print @r;
	  CLOSE sbj;
	return @rc;
   end try  
   begin catch              
        print 'ошибка в параметрах' 
        if error_procedure() is not null   
			print 'имя процедуры : ' + error_procedure();
        return @rc;
   end catch; 

DECLARE	@return_value int
EXEC	@return_value = SUBJECT_REPORT
		@p = N'ИСиТ'
SELECT	'Return Value' = @return_value
go

--6
--drop PROCEDURE PAUDITORIUM_INSERTX
CREATE PROCEDURE PAUDITORIUM_INSERTX @a char(20),	
									 @n varchar(50), 
									 @c int = 0, 
									 @t char(10), 
									 @tn varchar(50)
as 
begin
DECLARE @rc int = 1;
	begin try
		set transaction isolation level serializable;          
		begin tran
			INSERT into AUDITORIUM_TYPE(AUDITORIUM_TYPE, AUDITORIUM_TYPENAME)
				values(@n, @tn);
			EXEC @rc = PAUDITORIUM_INSERT @a, @n, @c, @t;
		commit tran;
		return @rc;
	end try
	begin catch
		print 'Номер ошибки: ' + cast(error_number() as varchar(6));
		print 'Сообщение: ' + error_message();
		print 'Уровень: ' + cast(error_severity() as varchar(6));
		print 'Метка: ' + cast(error_state() as varchar(8));
		print 'Номер строки: ' + cast(error_line() as varchar(8));
		if error_procedure() is not null   
			print 'Имя процедуры: ' + error_procedure(); 
		if @@trancount > 0 rollback tran ; 
		return -1;
	end catch;
end;

DECLARE @k int;  
EXEC @k = PAUDITORIUM_INSERTX '622-3', @n = 'КК', @c = 85, @t = '622-3', @tn = 'Комп. класс'; 
print 'Код ошибки: ' + cast(@k as varchar(3));

delete AUDITORIUM where [AUDITORIUM]='622-3';  
go