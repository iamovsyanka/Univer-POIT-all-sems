--1
select name, open_mode, open_time, total_size from v$pdbs;

--2
select * from v$instance;

--3
select * from product_component_version;

--4
--DCA -> KAO_PDB

--5
select name, open_mode, open_time, total_size from v$pdbs;

--6
create tablespace TS_KAO_PDB
  datafile 'C:\app\Tablespaces\TS_KAO_PDB.dbf'
  size 7M
  autoextend on next 5M
  maxsize 20M
 extent management local;

 create temporary tablespace TS_KAO_TEMP_PDB
  tempfile 'C:\app\Tablespaces\TS_KAO_TEMP_PDB.dbf'
  size 5M
  autoextend on next 3M
  maxsize 30M
 extent management local;
 
alter session set "_ORACLE_SCRIPT" = true;

create role RL_KAO_PDB;
commit;

grant create session,
      create table,
      create view,
      create procedure,
      drop any table,
      drop any view,
      drop any procedure 
to RL_KAO_PDB;

create profile PF_KAO_PDB limit
  password_life_time 180
  sessions_per_user 3
  failed_login_attempts 7
  password_lock_time 1
  password_reuse_time 10
  password_grace_time default
  connect_time 180
  idle_time 30;
  
create user U1_KAO_PDB identified by 12345
default tablespace TS_KAO_PDB quota unlimited on TS_KAO_PDB
temporary tablespace TS_KAO_TEMP_PDB
profile PF_KAO_PDB
account unlock
password expire;

grant RL_KAO_PDB to U1_KAO_PDB;
commit;

--7
create table KAO_table(x number(2) primary key disable, y varchar(50));

insert into KAO_table(x, y) values (1, 'a');
insert into KAO_table(x, y) values (2, 'b');
insert into KAO_table(x, y) values (3, 'c');
commit;

select * from KAO_table;

--8
select * from all_users;
select * from dba_tablespaces;
select * from dba_data_files;
select * from dba_temp_files;
select * from dba_roles;
select grantee, privilege from dba_sys_privs;
select * from dba_profiles;