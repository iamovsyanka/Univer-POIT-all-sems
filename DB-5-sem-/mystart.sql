Create table KD_t(x number(3) primary key,s varchar2(50));

Insert into KD_t(x,s) values(1, '1');
Insert into KD_t(x,s) values(2, '2');
Insert into KD_t(x,s) values(3, '3');
COMMIT;

Update KD_t set x = 4 where x <3;
COMMIT;

Select sum(x) from KD_t where s='2';

Delete from KD_t where s='1';
COMMIT;

Create table KD_t1(
    x1 number(3),
    t1 varchar2(50),
    constraint cxx1 foreign key (x1) references KD_t(x)
    );

Insert into KD_t1(x1,t1) values(1, 'q');
Insert into KD_t1(x1,t1) values(2, 'w');
Insert into KD_t1(x1,t1) values(3, 'e');

Select * from KD_t inner join KD_t1 on x = x1 ;
Select * from KD_t cross join KD_t1 where x = '2';
Select * from KD_t left join KD_t1 on x = x1;
Select * from KD_t right join KD_t1 on x = x1;

Drop table KD_t;
Drop table KD_t1;