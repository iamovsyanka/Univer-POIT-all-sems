--1
create tablespace TS_KAO
  datafile 'C:\app\Tablespaces\TS_KAO.dbf'
  size 7M
  autoextend on next 5M
  maxsize 20M
 extent management local;
 
drop tablespace TS_KAO;

--2
 create temporary tablespace TS_KAO_TEMP
  tempfile 'C:\app\Tablespaces\TS_KAO_TEMP.dbf'
  size 5M
  autoextend on next 3M
  maxsize 30M
 extent management local;
 
drop tablespace TS_KAO_TEMP;

--3
select * from SYS.dba_tablespaces;

--4
alter session set "_ORACLE_SCRIPT" = true;

create role RL_KAOCORE;
commit;

grant create session,
      create table,
      create view,
      create procedure,
      drop any table,
      drop any view,
      drop any procedure 
to RL_KAOCORE;

--5
select * from dba_roles;
select * from dba_roles where role = 'RL_KAOCORE';
select * from dba_sys_privs where grantee = 'RL_KAOCORE';

--6
create profile PF_KAOCORE limit
  password_life_time 180
  sessions_per_user 3
  failed_login_attempts 7
  password_lock_time 1
  password_reuse_time 10
  password_grace_time default
  connect_time 180
  idle_time 30;
  
--7
select * from dba_profiles;
select * from dba_profiles where profile = 'PF_KAOCORE';
select * from dba_profiles where profile = 'DEFAULT';     

--8
create user KAOCORE identified by 12345
default tablespace TS_KAO quota unlimited on TS_KAO
temporary tablespace TS_KAO_TEMP
profile PF_KAOCORE
account unlock
password expire;

grant RL_KAOCORE to KAOCORE;
commit;

--9
--sqlplus -> KAOCORE -> change password

--10
create table Points(x number(2), y number(2));

create view Points_view as select * from Points;

--11
grant create tablespace,
      alter tablespace
to KAOCORE;

create tablespace KAO_QDATA
datafile 'C:\app\Tablespaces\KAO_QDATA.dbf'
size 10M
extent management local
offline;

alter tablespace KAO_QDATA online;
alter user KAOCORE quota 2M on KAO_QDATA;

insert into Points(x, y) values (1, 1);
insert into Points(x, y) values (1, 2);
insert into Points(x, y) values (1, 3);

select * from Points;
