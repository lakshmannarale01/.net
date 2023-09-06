create table ITEM(itemname varchar(25) primary key,itemtype varchar(5),itemcolor varchar(15));
create table DEPARTMENT(deptname varchar(20) primary key,deptphone varchar(15) , deptfloor int, DeptMgrId int)
create table EMP(empno int  GENERATED ALWAYS AS IDENTITY primary key,empname varchar(30),empsalary varchar(8),bossno int,deptname varchar(30) references DEPARTMENT(deptname) not null)
create table SALES(salesno int primary  key,saleqty int,itemname varchar(30) references ITEM(itemname) not null,deptname varchar(30) references DEPARTMENT(deptname) not null)
create table EMP(empno int  GENERATED ALWAYS AS IDENTITY ,empname varchar(30),empsalary varchar(8),bossno int,deptname varchar(30) references DEPARTMENT(deptname) not null)
alter table EMP add constraint pk_empempno primary key(empno);
insert into item(itemname,itemtype, itemcolor) values('pocket knife-Nile','E','Brown');
select * from item;
insert into department(deptname,deptphone, deptfloor,DeptMgrId) values('Management','34','5','1');
select * from department;


create table EMP(empno int  primary key ,empname varchar(30),empsalary varchar(8),bossno int,deptname varchar(30) references DEPARTMENT(deptname) not null,constraint fk_emp_deptname Foreign key(deptname) references DEPARTMENT(deptname))
alter table EMP add constraint pk_empempno primary key(empno);
insert into EMP(empno,empname, empsalary,bossno,deptname) values('1','Alice','75000','0','Management');
select * from emp;
insert into department(deptname,deptphone, deptfloor,DeptMgrId) values('Books','81','1','4');

insert into sales(salesno,saleqty,itemname,deptname)values('101','2','Boots-snake proof','Clothes');

create table SALES(salesno int primary  key,saleqty int,itemname varchar(30) references ITEM(itemname) not null,deptname varchar(30) 
				   references DEPARTMENT(deptname) not null,constraint fk_item_itemname Foreign key(itemname) references ITEM(itemname))
 insert into sales(salesno,saleqty,itemname,deptname)values('101','2','Boots-snake proof','Clothes');
 
  insert into sales(salesno,saleqty,itemname,deptname)values('114','1','pocket knife-Nile','Navigation');
 insert into sales(salesno,saleqty,itemname,deptname)values('115','1','pocket knife-Nile','Equipment');
 insert into sales(salesno,saleqty,itemname,deptname)values('116','1','Sextant','Clothes');
  select * from sales;
  insert into EMP(empno,empname, empsalary,bossno,deptname) values('1','Alice','75000','0','management');
  select * from emp
   insert into EMP(empno,empname, empsalary,bossno,deptname) values('2','Ned','45000','1','Marketing');
    insert into EMP(empno,empname, empsalary,bossno,deptname) values('3','Andrew','25000','2','Marketing');
	 insert into EMP(empno,empname, empsalary,bossno,deptname) values('4','Clare','22000','2','Marketing');
	  insert into EMP(empno,empname, empsalary,bossno,deptname) values('5','Todd','38000','1','Accounting');
	   insert into EMP(empno,empname, empsalary,bossno,deptname) values('6','Nancy','22000','5','Accounting');
	    insert into EMP(empno,empname, empsalary,bossno,deptname) values('7','Brier','43000','1','Purchesing');
		 insert into EMP(empno,empname, empsalary,bossno,deptname) values('8','Sarah','56000','7','Purchesing');
		  insert into EMP(empno,empname, empsalary,bossno,deptname) values('9','Sophile','35000','1','Personnel');
		   insert into EMP(empno,empname, empsalary,bossno,deptname) values('10','Sanjay','15000','3','Navigation');
		    insert into EMP(empno,empname, empsalary,bossno,deptname) values('11','Rita','15000','4','Books');
			 insert into EMP(empno,empname, empsalary,bossno,deptname) values('12','Gigi','16000','4','Clothes');
			  insert into EMP(empno,empname, empsalary,bossno,deptname) values('13','Maggie','11000','4','Clothes');
			   insert into EMP(empno,empname, empsalary,bossno,deptname) values('14','Paul','15000','3','Equipment');
			    insert into EMP(empno,empname, empsalary,bossno,deptname) values('15','James','15000','3','Equipment');
				 insert into EMP(empno,empname, empsalary,bossno,deptname) values('16','Pat','15000','3','Furniture');
				  insert into EMP(empno,empname, empsalary,bossno,deptname) values('17','Mark','15000','3','Recreation');
				  