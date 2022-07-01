use RO_UNIVER;
go

--1
--DROP PROCEDURE PSUBJECT
CREATE PROCEDURE PSUBJECT
as
begin
	DECLARE @n int = (SELECT count(*) from SUBJECT);
	SELECT [SUBJECT] [���], SUBJECT_NAME [����������], PULPIT [�������] FROM SUBJECT;
	return @n;
end;

DECLARE @k int;
EXEC @k = PSUBJECT;
print '���������� ���������: ' + cast(@k as varchar(3));
go

--2
ALTER PROCEDURE PSUBJECT @p varchar(20), @c nvarchar(2) output
as 
begin
	SELECT [SUBJECT] [���], SUBJECT_NAME [����������], PULPIT [�������] FROM SUBJECT WHERE [SUBJECT] = @p;
	SET @c = cast(@@rowcount as nvarchar(2));
end;

DECLARE @k int, 
		@k1 nvarchar(2);
EXEC @k = PSUBJECT @p = '��', @c = @k1 output;
PRINT '���������� ���������: ' + @k1;
go

--3
CREATE TABLE #SUBJECT  (��� varchar(10),
						���������� varchar(50),
						������� varchar(5)
						);

ALTER PROCEDURE PSUBJECT @p varchar(20)
as 
begin
	SELECT [SUBJECT] [���], SUBJECT_NAME [����������], PULPIT [�������] FROM SUBJECT WHERE [SUBJECT] = @p;
end;

INSERT #SUBJECT EXEC PSUBJECT @p = '��';
INSERT #SUBJECT EXEC PSUBJECT @p = '��';

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
		print '����� ������: ' + cast(error_number() as varchar(6));
		print '���������: ' + error_message();
		print '�������: ' + cast(error_severity() as varchar(6));
		print '�����: ' + cast(error_state() as varchar(8));
		print '����� ������: ' + cast(error_line() as varchar(8));
		if error_procedure() is not null   
			print '��� ���������: ' + error_procedure();
		return -1;
	end catch;
end;

DECLARE @rc int;  
EXEC @rc = PAUDITORIUM_INSERT @a = '423-3', @n = '��', @c = 100, @t = '423-3'; 
print '��� ������: ' + cast(@rc as varchar(3));
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
		raiserror('������', 11, 1);
      else 
      open sbj;	  
	  fetch sbj into @sb;
      print '��������: ';
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
        print '������ � ����������' 
        if error_procedure() is not null   
			print '��� ��������� : ' + error_procedure();
        return @rc;
   end catch; 

DECLARE	@return_value int
EXEC	@return_value = SUBJECT_REPORT
		@p = N'����'
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
		print '����� ������: ' + cast(error_number() as varchar(6));
		print '���������: ' + error_message();
		print '�������: ' + cast(error_severity() as varchar(6));
		print '�����: ' + cast(error_state() as varchar(8));
		print '����� ������: ' + cast(error_line() as varchar(8));
		if error_procedure() is not null   
			print '��� ���������: ' + error_procedure(); 
		if @@trancount > 0 rollback tran ; 
		return -1;
	end catch;
end;

DECLARE @k int;  
EXEC @k = PAUDITORIUM_INSERTX '622-3', @n = '��', @c = 85, @t = '622-3', @tn = '����. �����'; 
print '��� ������: ' + cast(@k as varchar(3));

delete AUDITORIUM where [AUDITORIUM]='622-3';  
go