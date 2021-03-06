USE [TRIZMA]
GO
/****** Object:  StoredProcedure [dbo].[dbUpdateCMS1b]    Script Date: 2/5/2018 10:53:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[dbUpdateCMS1b]

AS
BEGIN

declare @date1 date
set @date1 = dateadd(month,-2,getdate())
--print @date1

if OBJECT_ID('tempdb.dbo.#Temp02','U') is not null
drop table #Temp02
select row_date
	 , left(row_date,7) as mnth
	 , starttime
	 , split
	 , logid
	 , sum(acdcalls)	as acdcalls
	 , sum(acwoutcalls) as acwoutcalls
	 , sum(auxoutcalls) as auxoutcalls
	 , sum(acdtime)		as acdtime
	 , sum(acwouttime)	as acwouttime
	 , sum(auxouttime)	as auxouttime
	 , sum(ti_auxtime)	as ti_auxtime
into #Temp02
from TRIZMAB.dbo.CMSraw1
where row_date > @date1
group by row_date
	   , starttime
	   , split
	   , logid
-- select * from #Temp02

if OBJECT_ID('tempdb.dbo.#help51','U') is not null
drop table #help51
select top 2 uni.mnth
into #help51
from ( select distinct
			  mnth 
	   from #Temp02
	 ) as uni
order by uni.mnth desc
-- select * from #help51

if OBJECT_ID('tempdb.dbo.#helpD1','U') is not null
drop table #helpD1
select distinct
	   YYYYMM
	 , left(dateID,7) as perd
	 , MStartDate
	 , left(convert(varchar,dateadd(day,-1,MEndDT),121),10) as dat
into #helpD1
from TRIZMA.dbo.timeFrame
where left(dateID,7) in (select * from #help51)
order by YYYYMM
	   , MStartDate
-- select * from #helpD1

if OBJECT_ID('tempdb.dbo.#helpD2','U') is not null
drop table #helpD2
select dateID
     , left(convert(varchar,dateadd(day,-1,dimDateNK),121),10) as dayprev
into #helpD2
from TRIZMA.dbo.timeFrame
where yyyymm in (select YYYYMM from #helpD1)
-- select * from #helpD2

if OBJECT_ID('tempdb.dbo.#help52','U') is not null
drop table #help52
select min(row_date) as mindt
	 , mnth
	 , logid
into #help52
from #Temp02 as a1
	left join (select * from #helpD1) as a2 on a1.mnth = a2.perd
where a1.mnth in (select perd from #helpD1)
  and a1.row_date >= a2.MStartDate
  and a1.starttime > 400
  and acdcalls > 0
group by mnth
	   , logid
-- select * from #help52



declare @drt1 nvarchar(50)
declare @drt2 nvarchar(50)
set @drt1 = (select min(MStartDate) from #helpD1)
set @drt2 = (select max(MStartDate) from #helpD1)

if OBJECT_ID('tempdb.dbo.#Temp022','U') is not null
drop table #Temp022
select a1.mnth
	 , a1.row_date as row_date_old
	 , (case when (a1.row_date = @drt1 or a1.row_date = @drt2) and a1.starttime >= 0 and a1.starttime < 400
			 then a2.mindt
			 when (a1.row_date <> @drt1 or a1.row_date <> @drt2) and a1.starttime >= 0 and a1.starttime < 400
			 then a3.dayprev
			 else a1.row_date end) as row_date
	 , a1.starttime
	 , a1.split
	 , a1.logid
	 , a1.acdcalls
	 , a1.acwoutcalls
	 , a1.auxoutcalls
	 , a1.acdtime
	 , a1.acwouttime
	 , a1.auxouttime
	 , a1.ti_auxtime
into #Temp022
from #Temp02 as a1
	left join (select * from #help52) as a2 on a1.mnth = a2.mnth
										   and a1.logid = a2.logid
	left join (select * from #helpD2) as a3 on a1.row_date = a3.dateID
where a1.mnth in (select * from #help51)
  and a1.acdcalls <> 0 or acwoutcalls <> 0 or auxoutcalls <> 0
-- select * from #Temp022


if OBJECT_ID('tempdb.dbo.#Temp03','U') is not null
drop table #Temp03
select convert(nvarchar,row_date) as dateDT
     , right(concat('00',starttime),4) as starttime
     , convert(int,split) as split
     , logid
     , acdcalls as acdcallsNum
     , outboundcallsNum = auxoutcalls + acwoutcalls
     , (case when acdcalls = 0 then 0 else acdtime / acdcalls end) as acdtimeAvg
	 , (case when acwoutcalls + auxoutcalls = 0 then 0 else (acwouttime + auxouttime)/(acwoutcalls + auxoutcalls) end) as outboundtimeAvg
	 , ti_auxtime
into #Temp03
from #Temp022

if OBJECT_ID('tempdb.dbo.#Temp033','U') is not null
drop table #Temp033
select ROW_NUMBER() over(order by a1.dateDT) as ID
	 , a1.dateDT
     , a1.starttime
     , a1.split	 
	 , a2.Name as splitName
     , a1.logid
	 , a3.ID as agentsID
     , a1.acdcallsNum
     , a1.outboundcallsNum
     , a1.acdtimeAvg
	 , a1.outboundtimeAvg
	 , t1.YYYYMM
	 , t1.YYYY
	 , t1.MonthNbr
	 , t1.WeekNbr
	 , a1.ti_auxtime
into #Temp033
from #Temp03 as a1
	left join (select * from Reporting.dbo.SplitSkill) as a2 on a1.split = convert(int,a2.Value)
	left join (select ID, agentID from TRIZMA.dbo.agents) as a3 on a1.logid = a3.agentID
	left join (select dateid, YYYYMM, YYYY, MonthNbr, WeekNbr from TRIZMA.dbo.timeFrame) as t1 on a1.dateDT = t1.dateID
where a3.ID is not null
-- select * from #Temp033 where ID like '%2018-02-013038000237W0500%'

truncate table TRIZMAB.dbo.CMSagentsNumAvgDaily
insert into TRIZMAB.dbo.CMSagentsNumAvgDaily
select *
from #Temp033
-- select * from TRIZMAB.dbo.CMSagentsNumAvgDaily

truncate table TRIZMAB.dbo.CMSagentsNumTotDaily
insert into TRIZMAB.dbo.CMSagentsNumTotDaily
select ROW_NUMBER() over(order by uni.agentsID, uni.dateDT) as ID
	 , uni.dateDT
	 , uni.logid
	 , uni.agentsID
	 , uni.acdcallsNum
	 , (case when uni.acdcallsNum / 0.55 > 100.00 then 100.00 else uni.acdcallsNum / 0.55 end)
	 , (case when uni.acdcallsNum / 0.55 > 100.00 then '100.00' else convert(nvarchar,convert(decimal(16,2),uni.acdcallsNum / 0.55)) end)
	 , (case when uni.acdcallsNum - 55 <= 0 then null else uni.acdcallsNum - 55 end)
	 , left(uni.dateDT,7)
	 , uni.avgAcdTime
	 , uni.skillCnt
	 , uni.auxouttime
from (
		select unb.dateDT
			 , unb.logid
		     , unb.agentsID
			 , (case when unb.acdcallsNum = 0 then unb.outboundcallsNum else unb.acdcallsNum end) as acdcallsNum
			 , (case when unb.acdcallsNum = 0 then unb.outboundtimeAvg else unb.avgAcdTime end) as avgAcdTime
			 , unb.skillCnt
			 , unb.auxouttime
		from (  select dateDT
				     , logid
					 , agentsID
				     , sum(acdcallsNum) as acdcallsNum
					 , concat(convert(int,avg(acdtimeAvg) / 60),'m ',convert(int,avg(acdtimeAvg))-convert(int,avg(acdtimeAvg) / 60)*60,'s') as avgAcdTime
					 , sum(outboundcallsNum) as outboundcallsNum
					 , concat(convert(int,avg(outboundtimeAvg) / 60),'m ',convert(int,avg(outboundtimeAvg))-convert(int,avg(outboundtimeAvg) / 60)*60,'s') as outboundtimeAvg
					 --, avg(outboundtimeAvg) / 60 as outboundtimeAvg
					 , count(distinct split) as skillCnt
					 , concat(convert(int,sum(auxoutSec) / 60),'m ',convert(int,sum(auxoutSec))-convert(int,sum(auxoutSec) / 60)*60,'s') as auxouttime
				from TRIZMAB.dbo.CMSagentsNumAvgDaily
				where acdcallsNum <> 0 or outboundcallsNum <> 0
				group by dateDT
				       , logid
					   , agentsID
		      ) as unb
	 ) as uni

if OBJECT_ID('tempdb.dbo.#Temp82','U') is not null
drop table #Temp82
select [Name]
      ,[Value]
into #Temp82
FROM [Reporting].[dbo].[SplitSkill]
where value not in (select value from cms.dbo.split_skill)

truncate table TRIZMAB.dbo.CMSsplitSkill
insert into TRIZMAB.dbo.CMSsplitSkill
select uni.*
from (  select * 
		from cms.dbo.split_skill
		union all
		select Value
			 , Name
			 , Name
			 , Name
			 , 'Serbia'
			 , 'Serbian'
		from #Temp82
	) as uni

declare @dateDT2 nvarchar(50)
set @dateDT2 = (
select max(uni.dateDT) as dateDT
from ( 
		select distinct top 2 dateDT 
		from TRIZMAB.dbo.CMSagentsNumAvgDaily
		order by dateDT desc
	 ) as uni
)

if OBJECT_ID('tempdb.dbo.#Temp72','U') is not null
drop table #Temp72
select uni.row_date
     , uni.logid
	 , uni.split
	 , (case when uni.SumCalls = 0 then uni.outCalls else uni.SumCalls end) as SumCalls
	 , (case when uni.SumCalls = 0 then uni.outTime else uni.SumTime end) as SumTime
into #Temp72
from (
		select convert(nvarchar,row_date) as row_date
			 , logid
			 , split
			 , sum(acdcalls) as SumCalls
			 , sum(acdtime) as SumTime
			 , sum(acwoutcalls + auxoutcalls) as outCalls
			 , sum(acwouttime + auxouttime) as outTime
		from #Temp022
		where row_date = @dateDT2
		group by row_date
			   , logid
			   , split
) as uni
order by uni.logid
       , uni.split

truncate table TRIZMAB.dbo.CMSagentsSplitSkillDaily
insert into TRIZMAB.dbo.CMSagentsSplitSkillDaily
select ROW_NUMBER() over(order by logid, row_date) as ID
	 , uni.*
from (
		select *
			 , isnull(convert(decimal(16,2),(convert(float,SumTime) / nullif(SumCalls,0))/60),0.00) as AvgAcdTime
		from #Temp72 as a1
			left join (select * from TRIZMAB.dbo.CMSsplitSkill) as b1 on a1.split = b1.value
			left join (select ID as agentsID, agentID from TRIZMA.dbo.agents) as a3 on a1.logid = a3.agentID
		where b1.Value is not null
	 ) as uni

END

