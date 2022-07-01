--1
select * from teacher;

create or replace procedure GET_TEACHERS_BY_PULPIT (PCODE TEACHER.PULPIT%TYPE) 
is
  cursor pteachers is select * from teacher where pulpit = pcode;
  pteacher pteachers%rowtype;
begin
  open pteachers;
  loop
    fetch pteachers into pteacher;
    exit when pteachers%notfound;
    dbms_output.put_line(pteacher.teacher_name||' '||pteacher.pulpit);
  end loop;
  
  close pteachers;
end;

begin
  get_teachers_by_pulpit('ISiT');
end;

--2
create or replace function GET_NUM_TEACHERS_BY_PULPIT (PCODE TEACHER.PULPIT%TYPE) RETURN NUMBER
is
  count_teachers number;
begin
  select count(*) into count_teachers from teacher where pulpit = pcode;
  return count_teachers;
end;

begin
  dbms_output.put_line('count of teachers '||get_num_teachers_by_pulpit('ISiT'));
end; 

--3
create or replace procedure GET_TEACHERS_BY_FACULTY (FCODE FACULTY.FACULTY%TYPE)
is
  cursor fteachers is select teacher.teacher_name, teacher.pulpit from teacher
  inner join pulpit on pulpit.pulpit = teacher.pulpit 
  where pulpit.faculty = fcode;
  
  fteacher fteachers%rowtype;
begin
  open fteachers;
  loop
    fetch fteachers into fteacher;
    exit when fteachers%notfound;
    dbms_output.put_line(fteacher.teacher_name||' '||fteacher.pulpit);
  end loop;
  
  close fteachers;
end;

begin
  get_teachers_by_faculty('IDiP');
end;  

create or replace procedure GET_SUBJECTS (PCODE SUBJECT.PULPIT%TYPE)
is
  cursor sub is select * from subject where pulpit = pcode;
  psubject sub%rowtype;
begin 
  open sub;
  loop
    fetch sub into psubject;
    exit when sub%notfound;
    dbms_output.put_line(psubject.subject_name||' '||psubject.pulpit);
  end loop;
  
  close sub;
end;

begin
  get_subjects('ISiT');
end;

--4
create or replace function GET_NUM_TEACHERS_BY_FACULTY (FCODE FACULTY.FACULTY%TYPE) RETURN NUMBER
is
  count_teachers number;
begin
  select count(*) into count_teachers from teacher
  inner join pulpit on teacher.pulpit = pulpit.pulpit 
  where pulpit.faculty = fcode;
  return count_teachers;
end;

begin
  dbms_output.put_line('count of teachers '||get_num_teachers_by_faculty('IDiP'));
end; 

create or replace function GET_NUM_SUBJECTS (PCODE SUBJECT.PULPIT%TYPE) RETURN NUMBER 
is
  count_subjects number;
begin
  select count(*) into count_subjects from subject where subject.pulpit = pcode;
  return count_subjects;
end;

begin
  dbms_output.put_line('count of subjects '||get_num_subjects('ISiT'));
end;

--5
create or replace package TEACHERS
as
  PROCEDURE GET_TEACHERS_BY_PULPIT (PCODE TEACHER.PULPIT%TYPE);  
  FUNCTION GET_NUM_TEACHERS_BY_PULPIT (PCODE TEACHER.PULPIT%TYPE) RETURN NUMBER;
  PROCEDURE GET_TEACHERS_BY_FACULTY (FCODE FACULTY.FACULTY%TYPE);
  PROCEDURE GET_SUBJECTS (PCODE SUBJECT.PULPIT%TYPE);
  FUNCTION GET_NUM_TEACHERS_BY_FACULTY (FCODE FACULTY.FACULTY%TYPE) RETURN NUMBER;
  FUNCTION GET_NUM_SUBJECTS (PCODE SUBJECT.PULPIT%TYPE) RETURN NUMBER;
end TEACHERS;  

CREATE OR REPLACE PACKAGE BODY TEACHERS IS
  PROCEDURE GET_TEACHERS_BY_PULPIT (PCODE TEACHER.PULPIT%TYPE) is
        cursor pteachers is select * from teacher where pulpit = pcode;
      pteacher pteachers%rowtype;
    begin
      open pteachers;
      loop
        fetch pteachers into pteacher;
        exit when pteachers%notfound;
        dbms_output.put_line(pteacher.teacher_name||' '||pteacher.pulpit);
      end loop;
      
      close pteachers;
    end;
    
    FUNCTION GET_NUM_TEACHERS_BY_PULPIT (PCODE TEACHER.PULPIT%TYPE) RETURN NUMBER is
          count_teachers number;
    begin
      select count(*) into count_teachers from teacher where pulpit = pcode;
      return count_teachers;
    end;
    
    PROCEDURE GET_TEACHERS_BY_FACULTY (FCODE FACULTY.FACULTY%TYPE) is
        cursor fteachers is select teacher.teacher_name, teacher.pulpit from teacher
      inner join pulpit on pulpit.pulpit = teacher.pulpit 
      where pulpit.faculty = fcode;
      
      fteacher fteachers%rowtype;
    begin
      open fteachers;
      loop
        fetch fteachers into fteacher;
        exit when fteachers%notfound;
        dbms_output.put_line(fteacher.teacher_name||' '||fteacher.pulpit);
      end loop;
      
      close fteachers;
    end;  
    
    PROCEDURE GET_SUBJECTS (PCODE SUBJECT.PULPIT%TYPE) is
        cursor sub is select * from subject where pulpit = pcode;
      psubject sub%rowtype;
    begin 
      open sub;
      loop
        fetch sub into psubject;
        exit when sub%notfound;
        dbms_output.put_line(psubject.subject_name||' '||psubject.pulpit);
      end loop;
      
      close sub;
    end;
    
   FUNCTION GET_NUM_TEACHERS_BY_FACULTY (FCODE FACULTY.FACULTY%TYPE) RETURN NUMBER is
      count_teachers number;
    begin
      select count(*) into count_teachers from teacher
      inner join pulpit on teacher.pulpit = pulpit.pulpit 
      where pulpit.faculty = fcode;
      return count_teachers;
    end;   
   
  FUNCTION GET_NUM_SUBJECTS (PCODE SUBJECT.PULPIT%TYPE) RETURN NUMBER is
    count_subjects number;
  begin
    select count(*) into count_subjects from subject where subject.pulpit = pcode;
    return count_subjects;
  end;  
  
END TEACHERS;

--6
begin
  teachers.get_teachers_by_pulpit('ISiT');
end;