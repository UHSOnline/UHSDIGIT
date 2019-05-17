






if object_ID('tempdb.dbo.#Zoki1','U') is not null
drop table #Zoki1
select *
into #Zoki1
from TRIZMAB.dbo.CMSagentsNumAvgDaily
where acdcallsNum != 0
   or outboundcallsNum != 0
-- select * from #Zoki1


if object_ID('tempdb.dbo.#country1','U') is not null
drop table #country1
select row_number() over(order by uni.country) as ID
	 , uni.country
into #country1
from (
		select distinct 
			   country
		from TRIZMAB.dbo.CMSsplitSkill
	 ) as uni
-- select * from #country1


if object_ID('tempdb.dbo.#taskorder1','U') is not null
drop table #taskorder1
select row_number() over(order by uni.TaskOrder) as ID
	 , uni.TaskOrder
into #taskorder1
from (
		select distinct 
			   TaskOrder
		from TRIZMAB.dbo.CMSsplitSkill
	 ) as uni
-- select * from #taskorder1

if object_ID('tempdb.dbo.#name1','U') is not null
drop table #name1
select row_number() over(order by uni.Name) as ID
	 , uni.Name
into #name1
from (
		select distinct 
			   Name
		from TRIZMAB.dbo.CMSsplitSkill
	 ) as uni
-- select * from #name1

if object_ID('tempdb.dbo.#skillname1','U') is not null
drop table #skillname1
select row_number() over(order by uni.SkillNameCMS) as ID
	 , uni.SkillNameCMS
into #skillname1
from (
		select distinct 
			   SkillNameCMS
		from TRIZMAB.dbo.CMSsplitSkill
	 ) as uni
-- select * from #skillname1

if object_ID('tempdb.dbo.#language1','U') is not null
drop table #language1
select row_number() over(order by uni.[Language]) as ID
	 , uni.[Language]
into #language1
from (
		select distinct 
			   [Language]
		from TRIZMAB.dbo.CMSsplitSkill
	 ) as uni
-- select * from #language1

if object_ID('tempdb.dbo.#desc1','U') is not null
drop table #desc1
select a1.*
	 , a2.ID as nameID
	 , a3.ID as skillNameID
	 , a4.ID as taskOrderID
	 , a5.ID as countryID
	 , a6.ID as languageID
into #desc1
from TRIZMAB.dbo.CMSsplitSkill as a1
	left join (select * from #name1) as a2 on a1.Name = a2.Name
	left join (select * from #skillname1) as a3 on a1.SkillNameCMS = a3.SkillNameCMS
	left join (select * from #taskorder1) as a4 on a1.TaskOrder = a4.TaskOrder
	left join (select * from #country1) as a5 on a1.Country = a5.Country
	left join (select * from #language1) as a6 on a1.Language = a6.Language
-- select * from #desc1

truncate table TRIZMAB.dbo.vChartCMScount1
insert into TRIZMAB.dbo.vChartCMScount1
select a1.*
	 , a2.skillNameCMS
	 , a2.TaskOrder
	 , a2.Country
	 , a2.Language
	 , a2.nameID
	 , a2.skillNameID
	 , a2.taskOrderID
	 , a2.countryID
	 , a2.languageID
from #Zoki1 as a1
   left join (select * from #desc1) as a2 on a1.split = a2.[value]
where a1.splitName is not null
-- select * from TRIZMAB.dbo.vChartCMScount1
