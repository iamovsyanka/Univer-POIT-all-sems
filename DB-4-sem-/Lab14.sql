use RO_UNIVER;
go

--1
CREATE FUNCTION COUNT_STUDENTS(@faculty varchar(20)) RETURNS int
AS BEGIN
	DECLARE @rc int;
	SET @rc = (SELECT COUNT(IDSTUDENT) FROM STUDENT 
						JOIN GROUPS ON STUDENT.IDGROUP = GROUPS.IDGROUP
						JOIN FACULTY ON FACULTY.FACULTY = GROUPS.FACULTY
						WHERE FACULTY.FACULTY = @faculty);
	RETURN @rc;
END;
go

DECLARE @f int = dbo.COUNT_STUDENTS('ТОВ');
PRINT 'Количество студентов на факультете: ' + cast(@f as varchar(4));
go

ALTER FUNCTION COUNT_STUDENTS(@faculty varchar(20), @prof varchar(20) = NULL) RETURNS int
AS BEGIN
	DECLARE @rc int;
	SET @rc = (SELECT COUNT(IDSTUDENT) FROM FACULTY 
				JOIN GROUPS ON FACULTY.FACULTY = GROUPS.FACULTY
				JOIN STUDENT ON GROUPS.IDGROUP = STUDENT.IDGROUP
				WHERE FACULTY.FACULTY = @faculty AND GROUPS.PROFESSION = @prof);
	RETURN @rc;
END;
go

DECLARE @p int = dbo.COUNT_STUDENTS('ТОВ', '1-48 01 02');
PRINT 'Количество студентов: ' + cast(@p as varchar(4));
go

--2
CREATE FUNCTION FSUBJECTS(@p varchar(20)) RETURNS varchar(300)
AS BEGIN
	DECLARE @sb varchar(10),	
			@s varchar(100) = '';
	DECLARE sbj CURSOR LOCAL STATIC
						FOR SELECT DISTINCT SUBJECT FROM SUBJECT 
						WHERE PULPIT = @p;
	OPEN sbj;
	FETCH sbj INTO @sb;
	WHILE @@FETCH_STATUS = 0
	begin
		SET @s = @s + RTRIM(@sb) + ', ';
		FETCH sbj into @sb;
	end;
RETURN @s
END;
go 

SELECT DISTINCT PULPIT, dbo.FSUBJECTS(PULPIT)[Дисциплины] FROM SUBJECT;
go

--3
CREATE FUNCTION FFACPUL(@f varchar(20), @p varchar(20)) 
													RETURNS TABLE
AS RETURN
SELECT FACULTY.FACULTY, PULPIT.PULPIT FROM FACULTY 
		LEFT OUTER JOIN PULPIT ON FACULTY.FACULTY = PULPIT.FACULTY
		WHERE FACULTY.FACULTY = ISNULL(@f, FACULTY.FACULTY) 
		AND
			PULPIT.PULPIT = ISNULL(@p, PULPIT.PULPIT);
go

SELECT * FROM dbo.FFACPUL(null, null);
SELECT * FROM dbo.FFACPUL('ИТ', null);
SELECT * FROM dbo.FFACPUL(null, 'ТДП');
SELECT * FROM dbo.FFACPUL('ИДиП', 'ПП');
go

--4
CREATE FUNCTION FCTEACHER(@p varchar(20)) RETURNS int
AS BEGIN
	DECLARE @rc int = (SELECT COUNT(TEACHER) FROM TEACHER WHERE PULPIT = ISNULL(@p, PULPIT));
	RETURN @rc;
END;
go 

SELECT PULPIT, dbo.FCTEACHER(PULPIT)[Количество преподавателей] FROM TEACHER;
SELECT dbo.FCTEACHER(null)[Общее количество преподавателей];
go


--5
use Concert;
go

CREATE FUNCTION COUNT_CONSERTS(@tickets int) RETURNS int
AS BEGIN
	DECLARE @rc int;
	SET @rc = (SELECT COUNT(Concerts.ConcertId) FROM Concerts WHERE Concerts.[Count] > @tickets);
	RETURN @rc;
END;
go

DECLARE @c int = dbo.COUNT_CONSERTS(15);
PRINT 'Количество концертов: ' + cast(@c as varchar(4));
go

--6 

CREATE FUNCTION FACULTY_REPORT(@c int) 
			returns @fr table([Факультет] varchar(50), [Количество кафедр] int, [Количество групп]  int, [Количество студентов] int, [Количество специальностей] int)
AS BEGIN
	DECLARE cc cursor static for select FACULTY from FACULTY where dbo.COUNT_STUDENTS(FACULTY,default)> @c; 
	DECLARE @f varchar(30);
	open cc;  
	fetch cc into @f;
	while @@fetch_status = 0
	begin
		insert @fr values(@f, dbo.COUNT_PULPIT(@f), dbo.COUNT_GROUP(@f), dbo.COUNT_STUDENTS(@f,default), dbo.COUNT_PROFESSION(@f)); 
		fetch cc into @f;  
	end;   
	return; 
END;
go

CREATE FUNCTION COUNT_PULPIT(@f varchar(20)) returns int
AS BEGIN
	DECLARE @rc int = 0;
	set @rc = (select count(PULPIT) from PULPIT where FACULTY = @f);
	return @rc;
END;
go

CREATE FUNCTION COUNT_GROUP(@f varchar(20)) returns int
AS BEGIN
	DECLARE @rc int = 0;
	set @rc = (select count(IDGROUP) from GROUPS where FACULTY like @f);
	return @rc;
END;
go

create function COUNT_PROFESSION(@f varchar(20)) returns int
AS BEGIN
	declare @rc int = 0;
	set @rc = (select count(PROFESSION) from PROFESSION where FACULTY like @f);
	return @rc;
END;
go