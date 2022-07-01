--1
declare 
  faculty_rec faculty%rowtype;
begin 
  select * into faculty_rec from faculty where faculty = 'FIT';
  dbms_output.put_line(faculty_rec.faculty ||' '||faculty_rec.faculty_name);
  exception
  when others
    then dbms_output.put_line(sqlcode||' '||sqlerrm);
end;

--2
declare 
  faculty_rec faculty%rowtype;
begin 
  select * into faculty_rec from faculty;
  dbms_output.put_line(faculty_rec.faculty ||' '||faculty_rec.faculty_name);
  exception
  when others
    then dbms_output.put_line(sqlcode||' '||sqlerrm);
end;

--3
declare 
  faculty_rec faculty%rowtype;
begin 
  select * into faculty_rec from faculty;
  dbms_output.put_line(faculty_rec.faculty ||' '||faculty_rec.faculty_name);
  exception
  when too_many_rows
    then dbms_output.put_line(sqlcode||' '||sqlerrm);
end;

--4
declare 
  faculty_rec faculty%rowtype;
begin
  select * into faculty_rec from faculty where faculty = 'XXX';
  dbms_output.put_line(faculty_rec.faculty||' '||faculty_rec.faculty_name);
  exception
  when no_data_found
    then  dbms_output.put_line(sqlcode||' '||sqlerrm);
  when too_many_rows
    then dbms_output.put_line(sqlcode||' '||sqlerrm);
  when others
    then dbms_output.put_line(sqlcode||' '||sqlerrm);
end;

--5
declare 
  b1 boolean;
  b2 boolean;
  b3 boolean;
  n pls_integer;
  auditorium_cur auditorium%rowtype;
begin 
  update auditorium set auditorium='314-1',
                        auditorium_name = '314-1',
                        auditorium_capacity = 90,
                        auditorium_type = 'LB'
                  where auditorium='301-1';
  rollback;
  b1 := sql%found;
  b2 := sql%isopen;
  b3 := sql%notfound;
  n := sql%rowcount;
  dbms_output.put_line(auditorium_cur.auditorium_name || ' ' ||
                        auditorium_cur.auditorium_capacity|| ' '||
                        auditorium_cur.auditorium_type);
  if b1 then dbms_output.put_line('found');
      else dbms_output.put_line('notfound');
  end if;
  if b2 then dbms_output.put_line('isopen');
      else dbms_output.put_line('not open');
  end if;
  if b3 then dbms_output.put_line('notfound');
      else dbms_output.put_line('found');
  end if;
  
 dbms_output.put_line('n = '||n);
 exception
  when others
    then dbms_output.put_line(sqlerrm);
end;

--6
declare 
  auditorium_cur auditorium%rowtype;
begin 
  update auditorium set auditorium_capacity = 'string'
                  where auditorium='301-1';             
  dbms_output.put_line(auditorium_cur.auditorium_name || ' ' ||
                        auditorium_cur.auditorium_capacity|| ' '||
                        auditorium_cur.auditorium_type);

 exception
  when others
    then dbms_output.put_line(sqlerrm);
end;

--7
declare 
  b1 boolean;
  b2 boolean;
  b3 boolean;
  n pls_integer;
  auditorium_cur auditorium%rowtype;
begin 
  insert into auditorium(auditorium,auditorium_name,auditorium_capacity,auditorium_type) 
  values('304-1','304-1',80,'LB');
  b1 := sql%found;
  b2 := sql%isopen;
  b3 := sql%notfound;
  n := sql%rowcount;
  dbms_output.put_line(auditorium_cur.auditorium_name || ' ' ||
                        auditorium_cur.auditorium_capacity|| ' '||
                        auditorium_cur.auditorium_type);
  if b1 then dbms_output.put_line('found');
        else dbms_output.put_line('notfound');
    end if;
  if b2 then dbms_output.put_line('isopen');
        else dbms_output.put_line('not open');
    end if;
   if b3 then dbms_output.put_line('notfound');
        else dbms_output.put_line('found');
    end if;
   dbms_output.put_line('n = '||n);
  rollback;
   exception
    when others
      then dbms_output.put_line(sqlerrm);
end;

--8
declare 
  auditorium_cur auditorium%rowtype;
begin 
  insert into auditorium(auditorium,auditorium_name,auditorium_capacity,auditorium_type) 
  values('304-1','304-1','STRING','LB');
  dbms_output.put_line(auditorium_cur.auditorium_name || ' ' ||
                        auditorium_cur.auditorium_capacity|| ' '||
                        auditorium_cur.auditorium_type);
  rollback;
   exception
    when others
      then dbms_output.put_line(sqlerrm);
end;

--9
declare 
  b1 boolean;
  b2 boolean;
  b3 boolean;
  n pls_integer;
  begin 
  delete auditorium where auditorium = '301-4';
  commit;
  b1 := sql%found;
  b2 := sql%isopen;
  b3 := sql%notfound;
  n := sql%rowcount;
  if b1 then dbms_output.put_line('found');
        else dbms_output.put_line('notfound');
    end if;
  if b2 then dbms_output.put_line('isopen');
        else dbms_output.put_line('not open');
    end if;
   if b3 then dbms_output.put_line('notfound');
        else dbms_output.put_line('found');
    end if;
   dbms_output.put_line('n = '||n);
  rollback;
   exception
    when others
      then dbms_output.put_line(sqlerrm);
end;

--10
declare
 sub auditorium%rowtype;
begin
    delete from auditorium where auditorium_capacity='FNYM';
    select * into sub from auditorium where auditorium_name='301-1';
    exception
        when others then dbms_output.put_line(sqlerrm);
end;

--11
declare
  cursor cur is select teacher_name, pulpit from TEACHER;
  m_name      teacher.teacher_name%type;
  m_pulpit    teacher.pulpit%type;
begin
  open cur;
  dbms_output.put_line('rowcount = '||cur%rowcount);
    loop
       fetch cur into m_name, m_pulpit;
       exit when cur%notfound;
       dbms_output.put_line(cur%rowcount||' '||m_name||' '||m_pulpit);
    end loop;
  dbms_output.put_line('rowcount = '||cur%rowcount);
  close cur;
  exception
     when others then dbms_output.put_line(sqlerrm);
end;
    
--12
declare
   cursor cur is select subject, subject_name, pulpit from SUBJECT;
   rec subject%rowtype;
begin
   open cur;
   dbms_output.put_line('rowcount = '||cur%rowcount);
   fetch cur into rec;
   while cur%found
     loop
       dbms_output.put_line(cur%rowcount||' '||rec.subject||' '||
                                 rec.subject_name||' '||rec.pulpit);
       fetch cur into rec;
     end loop;
   dbms_output.put_line('rowcount = '||cur%rowcount);
   close cur;
end;
    
--13
declare
  cursor cur is select pulpit.pulpit, teacher.teacher_name
  from pulpit inner join teacher on pulpit.pulpit=teacher.pulpit;
  rec cur%rowtype;
begin
    for rec in cur
    loop
        dbms_output.put_line(cur%rowcount||' '||rec.teacher_name||' '||rec.pulpit);
    end loop;
end;

--14
declare 
  cursor cur(cap1 auditorium.auditorium%type,cap2 auditorium.auditorium%type)
  is select auditorium, auditorium_capacity from auditorium
  where auditorium_capacity >=cap1 and AUDITORIUM_CAPACITY <= cap2;
begin
      dbms_output.put_line('CAPACITY < 20 :');
      for aum in cur(0,20)
      loop dbms_output.put(aum.auditorium||' '); end loop;   
      dbms_output.put_line(chr(10)||'CAPACITY 20-30 :');
      for aum in cur(21,30)
      loop dbms_output.put(aum.auditorium||' '); end loop;    
       dbms_output.put_line(chr(10)||'CAPACITY 30-60 :');
      for aum in cur(31,60)
      loop dbms_output.put(aum.auditorium||' '); end loop;   
       dbms_output.put_line(chr(10)||'CAPACITY 60-80 :');
      for aum in cur(61,80)
      loop dbms_output.put(aum.auditorium||' '); end loop;  
       dbms_output.put_line(chr(10)||'CAPACITY > 80 :');
      for aum in cur(81,1000)
      loop dbms_output.put(aum.auditorium||' '); end loop;  
end;

--15
variable x refcursor;
declare 
  type teacher_name is ref cursor return teacher%rowtype;
  xcurs teacher_name;
begin
  open xcurs for select * from teacher;
  :x :=xcurs;
end;
    
print x;
  
--16
declare 
  cursor curs_aut is select auditorium_type,
      cursor (select auditorium from auditorium aum
          where aut.auditorium_type = aum.auditorium_type)
      from auditorium_type aut;
  curs_aum sys_refcursor;
  aut auditorium_type.auditorium_type%type;
  txt varchar2(1000);
  aum auditorium.auditorium%type;
begin
  open curs_aut;
   fetch curs_aut into aut, curs_aum;
   while(curs_aut%found)
      loop
        txt:=rtrim(aut)||':';
        loop
          fetch curs_aum into aum;
          exit when curs_aum%notfound;
          txt := txt||','||rtrim(aum);
        end loop;
        dbms_output.put_line(txt);
        fetch curs_aut into aut, curs_aum;
      end loop;
  close curs_aut;
  exception
  when others
      then dbms_output.put_line(sqlerrm);
end;

select auditorium from auditorium aum inner join auditorium_type aut on
             aut.auditorium_type = aum.auditorium_type;
--17
declare 
  cursor curs_auditorium(capacity auditorium.auditorium%type, capac auditorium.auditorium%type)
    is select auditorium, auditorium_capacity
      from auditorium
      where auditorium_capacity >=capacity and AUDITORIUM_CAPACITY <= capac for update;
  aum auditorium.auditorium%type;
  cty auditorium.auditorium_capacity%type;
begin
  open curs_auditorium(40,80);
  fetch curs_auditorium into aum, cty;
  while(curs_auditorium%found)
    loop
      cty := cty * 0.9;
      update auditorium
      set auditorium_capacity = cty
      where current of curs_auditorium;
      dbms_output.put_line(' '||aum||' '||cty);
      fetch curs_auditorium into aum, cty;
    end loop;
  close curs_auditorium;
  rollback;
  exception
  when others
    then dbms_output.put_line(sqlerrm);
end;

select * from auditorium;
--18
declare 
  cursor cur(cap1 auditorium.auditorium%type,cap2 auditorium.auditorium%type)
  is select auditorium, auditorium_capacity from auditorium
  where auditorium_capacity between cap1 and cap2 for update;
  aum auditorium.auditorium%type;
  cap auditorium.auditorium_capacity%type;
begin
  open cur(0,20);
  fetch cur into aum, cap;
  while(cur%found)
      loop
          delete auditorium where current of cur;
          fetch cur into aum, cap;
      end loop;
  close cur;
      
  for pp in cur(0,120) loop
     dbms_output.put_line(pp.auditorium||' '||pp.auditorium_capacity);
  end loop; 
  rollback;
end;

--19
declare
  cursor cur(capacity auditorium.auditorium%type)
  is select auditorium, auditorium_capacity, rowid
  from auditorium where auditorium_capacity >=capacity for update;
  aum auditorium.auditorium%type;
  cap auditorium.auditorium_capacity%type;
begin
  for xxx in cur(80)
      loop
        if xxx.auditorium_capacity >=80
          then update auditorium
          set auditorium_capacity = auditorium_capacity+3
          where rowid = xxx.rowid;
        end if;
      end loop;
  for yyy in cur(80)
      loop
        dbms_output.put_line(yyy.auditorium||' '||yyy.auditorium_capacity);
      end loop; 
      rollback;
end;
    
--20
declare 
  cursor curs_teacher is select teacher, teacher_name, pulpit from teacher;
  m_teacher teacher.teacher%type;
  m_teacher_name teacher.teacher_name%type;
  m_pulpit teacher.pulpit%type;
  k integer :=1;
begin
    open curs_teacher;
    loop
      fetch curs_teacher into m_teacher, m_teacher_name, m_pulpit;
      exit when curs_teacher%notfound;
      DBMS_OUTPUT.PUT_LINE(' '||curs_teacher%rowcount||' '
                            ||m_teacher||' '
                            ||m_teacher_name||' '
                            ||m_pulpit);
      if (k mod 3 = 0) 
        then DBMS_OUTPUT.PUT_LINE('-------------------------------------------'); 
      end if;
      k:=k+1;
    end loop;
     DBMS_OUTPUT.PUT_LINE('rowcount = '|| curs_teacher%rowcount);
   close curs_teacher;
    exception
    when others
      then  DBMS_OUTPUT.PUT_LINE(sqlerrm);
end;
