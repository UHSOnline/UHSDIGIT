
declare @int1 int, @int2 int, @int3 int, @int4 int, @int5 int, @int11 int, @int12 int, @int13 int, @dt1 nvarchar(50), @dt2 nvarchar(50), @dt3 nvarchar(50), @currDate1 nvarchar(50), @currDate2 nvarchar(50), @date1 nvarchar(50), @idch nvarchar(128), @per1 int, @per2 int, @per3 int, @per4 int, @week1 int, @day1 int, @ids nvarchar(128), @dt31 nvarchar(50), @dt41 nvarchar(50), @dt5 nvarchar(50), @yer1 int, @qtr1 int
declare @wktype int, @item1 int, @item2 int, @acctid int, @dctpid int, @period int
declare @str1 nvarchar(max), @pr01 nvarchar(50), @pr02 nvarchar(50), @pr03 nvarchar(50), @pr04 nvarchar(50), @pr05 nvarchar(50), @pr06 nvarchar(50), @pr07 nvarchar(50), @pr08 nvarchar(50), @pr09 nvarchar(50), @pr10 nvarchar(50), @pr11 nvarchar(50), @pr12 nvarchar(50)
set @currDate2 = left(convert(varchar,GETDATE(), 121),10)
set @date1 = (select wks1 from DATAOPA.dbo.TIME_FRAME where dateID = @currDate2)
set @yer1 = (select yyyy from DATAOPA.dbo.TIME_FRAME where dateID = @currDate2)
set @per1 = (select distinct wstymd from DATAOPA.dbo.TIME_FRAME where wks1 = @date1)
set @week1 = (select WNumber from DATAOPA.dbo.TIME_FRAME where dateID = @currDate2)
set @day1 = (select daywnm from DATAOPA.dbo.TIME_FRAME where dateID = @currDate2)
set @qtr1 = (select [Quarter] from DATAOPA.dbo.TIME_FRAME where dateID = @currDate2)
set @int11 = (select MAX(dateYMD) from DATAOPA.dbo.TIME_FRAME where yyyymm = @per2 and daywnm = 5)
set @int12 = (select MAX(dateYMD) from DATAOPA.dbo.TIME_FRAME where YYYY = @yer1 and [Quarter] = @qtr1 and daywnm = 5)
set @int13 = (select MAX(dateYMD) from DATAOPA.dbo.TIME_FRAME where YYYY = @yer1 and daywnm = 5)
set @per3 = left(convert(varchar,dateadd(MONTH,-11,getdate()),112),6)
set @per4 = left(convert(varchar,dateadd(MONTH,-1,getdate()),112),6)
-- set @acctid = 168604 set @dctpid = 1010006 set @period = 201805




--create table DATAOPB.dbo.UHSWEBHL01
--(
--	ID int not null
--  , ID2 int not null
--  , crdate nvarchar(50)
--)
-- select * from DATAOPB.dbo.UHSWEBHL01

-- truncate table DATAOPB.dbo.UHSWEBHL01

-- ************ wchk = 1 *************--
insert into DATAOPB.dbo.UHSWEBHL01
select 1
	 , 1
	 , MAX(dateID)
from DATAOPA.dbo.TIME_FRAME 
where MonthNbr in (12) 
  and YYYYMM >= @per3 
  and dateID <= @currDate2 
  and daywnm != 6
  and daywnm != 7 
group by yyyy

insert into DATAOPB.dbo.UHSWEBHL01
select 1
	 , 2
	 , MAX(dateID)
from DATAOPA.dbo.TIME_FRAME 
where YYYYMM >= @per3 
  and dateID <= @currDate2 
  and MonthNbr in (3,6,9) 
  and daywnm != 6 
  and daywnm != 7 
group by yyyy
      , [Quarter]

insert into DATAOPB.dbo.UHSWEBHL01
select 1
	 , 3
	 , MAX(dateID)
from DATAOPA.dbo.TIME_FRAME 
where YYYYMM >= @per3 
  and dateID <= @currDate2 
  and MonthNbr not in (3,6,9,12,substring(@currDate2,6,2)) 
  and daywnm != 6 
  and daywnm != 7 
group by yyyy, YYYYMM 

insert into DATAOPB.dbo.UHSWEBHL01
select 1
	 , 4
	 , MAX(dateID)
from DATAOPA.dbo.TIME_FRAME 
where YYYYMM >= @per3 
  and dateID <= @currDate2 
  and daywnm = 5 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 1 and ID2 = 1) 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 1 and ID2 = 2) 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 1 and ID2 = 3)
group by yyyy
       , WeekNbr

insert into DATAOPB.dbo.UHSWEBHL01
select 1
	 , 5
	 , dateID
from DATAOPA.dbo.TIME_FRAME 
where YYYYMM >= @per3 
  and dateID <= @currDate2 
  and daywnm != 6
  and daywnm != 7 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 1 and ID2 = 1) 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 1 and ID2 = 2) 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 1 and ID2 = 3)
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 1 and ID2 = 4)


-- ************ wchk = 2 *************--
insert into DATAOPB.dbo.UHSWEBHL01
select 2
	 , 1
	 , MAX(dateID)
from DATAOPA.dbo.TIME_FRAME 
where MonthNbr in (12) 
  and YYYYMM >= @per3 
  and dateID <= @currDate2 
  and daywnm != 7 
group by yyyy 

insert into DATAOPB.dbo.UHSWEBHL01
select 2
	 , 2
	 , MAX(dateID)
from DATAOPA.dbo.TIME_FRAME 
where YYYYMM >= @per3 
  and dateID <= @currDate2 
  and MonthNbr in (3,6,9) 
  and daywnm != 7 
group by yyyy
       , [Quarter]

insert into DATAOPB.dbo.UHSWEBHL01
select 2
	 , 3
	 , MAX(dateID)
from DATAOPA.dbo.TIME_FRAME 
where YYYYMM >= @per3 
  and dateID <= @currDate2 
  and MonthNbr not in (3,6,9,12,substring(@currDate2,6,2)) 
  and daywnm != 7
group by yyyy
	   , YYYYMM

insert into DATAOPB.dbo.UHSWEBHL01
select 2
	 , 4
	 , MAX(dateID)
from DATAOPA.dbo.TIME_FRAME 
where YYYYMM >= @per3 
  and dateID <= @currDate2 
  and MonthNbr not in (substring(@currDate2,6,2)) 
  and daywnm = 6 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 2 and ID2 = 1) 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 2 and ID2 = 2) 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 2 and ID2 = 3)
group by yyyy
       , WeekNbr 

insert into DATAOPB.dbo.UHSWEBHL01
select 2
	 , 5
	 , dateID
from DATAOPA.dbo.TIME_FRAME 
where YYYYMM >= @per3 
  and dateID <= @currDate2 
  and daywnm != 6 
  and daywnm != 7 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 2 and ID2 = 1) 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 2 and ID2 = 2) 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 2 and ID2 = 3)
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 2 and ID2 = 4)


-- ************ wchk = 3 *************--
insert into DATAOPB.dbo.UHSWEBHL01
select 3
	 , 1
	 , MAX(dateID)
from DATAOPA.dbo.TIME_FRAME 
where MonthNbr in (12) 
  and YYYYMM >= @per3 
  and dateID <= @currDate2  
group by yyyy 

insert into DATAOPB.dbo.UHSWEBHL01
select 3
	 , 2
	 , MAX(dateID)
from DATAOPA.dbo.TIME_FRAME 
where YYYYMM >= @per3 
  and dateID <= @currDate2 
  and MonthNbr in (3,6,9)
group by yyyy
       , [Quarter]

insert into DATAOPB.dbo.UHSWEBHL01
select 3
	 , 3
	 , MAX(dateID)
from DATAOPA.dbo.TIME_FRAME 
where YYYYMM >= @per3 
  and dateID <= @currDate2 
  and MonthNbr not in (3,6,9,12,substring(@currDate2,6,2)) 
group by yyyy
	   , YYYYMM

insert into DATAOPB.dbo.UHSWEBHL01
select 3
	 , 4
	 , MAX(dateID)
from DATAOPA.dbo.TIME_FRAME 
where YYYYMM >= @per3 
  and dateID <= @currDate2 
  and MonthNbr not in (substring(@currDate2,6,2)) 
  and daywnm = 7 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 3 and ID2 = 1) 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 3 and ID2 = 2) 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 3 and ID2 = 3)
group by yyyy
       , WeekNbr 

insert into DATAOPB.dbo.UHSWEBHL01
select 3
	 , 5
	 , dateID
from DATAOPA.dbo.TIME_FRAME 
where YYYYMM >= @per3 
  and dateID <= @currDate2 
  and daywnm != 7 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 3 and ID2 = 1) 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 3 and ID2 = 2) 
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 3 and ID2 = 3)
  and dateID not in (select crdate from DATAOPB.dbo.UHSWEBHL01 where ID = 3 and ID2 = 4)