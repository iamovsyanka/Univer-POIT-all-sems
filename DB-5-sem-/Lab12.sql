--1
alter table TEACHER add(BIRTHDAY DATE, SALARY INT);
delete teacher;
select * from teacher;
drop table teacher;
insert into  TEACHER    (TEACHER,   TEACHER_NAME, PULPIT, birthday, salary )
                       values  ('SMLV',    'Smelov Vladimir Vladislavovich',  'ISiT', to_date('19.01.2000', 'DD.MM.YYYY'), 10);
insert into  TEACHER    (TEACHER,  TEACHER_NAME, PULPIT, birthday, salary )
                       values  ('AKNVCH',    'Akunovich Stanislav Ivanovich',  'ISiT', to_date('17.02.2001', 'DD.MM.YYYY'), 20);
insert into  TEACHER    (TEACHER,  TEACHER_NAME, PULPIT, birthday, salary )
                       values  ('DDK',    'Detko Alexandr Apkadevich',  'ISiT', to_date('21.03.2002', 'DD.MM.YYYY'), 30);

commit;

--2
select teacher_name from TEACHER;

select regexp_substr(teacher_name,'(\S+)',1, 1)||' '||
      substr(regexp_substr(teacher_name,'(\S+)',1, 2),1, 1)||'. '||
      substr(regexp_substr(teacher_name,'(\S+)',1, 3),1, 1)||'. ' from teacher;

--3
select * from teacher where TO_CHAR((birthday), 'd') = 5; --Thursday
select * from teacher where TO_CHAR((birthday), 'd') = 4; --Wednesday
select * from teacher where TO_CHAR((birthday), 'd') = 7; --Saturday

--4. 
create or replace view NextMonth as select teacher_name, birthday from teacher where extract(month from birthday) = 1;

select * from NextMonth;

--5. 
create or replace view CountBirthday as
select extract(month from birthday) as month, count(birthday) as n_teacher from teacher group by extract(month from birthday);

select * from CountBirthday;

--6
cursor Ubilei(teacher%rowtype) return teacher%rowtype is
select * from teacher
where mod((TO_CHAR(sysdate,'yyyy') - TO_CHAR(birthday, 'yyyy')+1), 10)=0;

--7
cursor tAvgSalary(teacher.salary%type,teacher.pulpit%type) 
return teacher.salary%type,teacher.pulpit%type  is
select floor(avg(salary)), pulpit
from teacher group by pulpit;

select round(avg(T.salary),3),P.faculty
from teacher T inner join pulpit P
on T.pulpit = P.pulpit group by P.faculty
union
select floor(avg(salary)), teacher.pulpit
from teacher group by teacher.pulpit
order by faculty;

select round(avg(salary),3) from teacher;

--8
declare
  type LAB is record
   (
      lab varchar2(10):='DB',
      numberLab int:=12
   );
   p1 LAB;
begin
 dbms_output.put_line(p1.lab||' '||p1.numberLab);
 p1.lab:='Test';
 p1.numberLab:=13;
 dbms_output.put_line(p1.lab||' '||p1.numberLab);
end;