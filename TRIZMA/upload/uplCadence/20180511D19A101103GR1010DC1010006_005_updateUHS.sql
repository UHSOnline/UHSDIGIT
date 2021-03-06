




declare @currDate1 nvarchar(50)
declare @currDate2 nvarchar(50)
declare @date1 int
declare @date2 int
declare @per1 int
declare @week1 int
declare @week2 nvarchar(8)
declare @day1 int
declare @ids nvarchar(128)
declare @qtr1 int
declare @year1 int
set @currDate1 = concat(left(convert(varchar,GETDATE(), 121),10),'T',right(convert(varchar,GETDATE(), 121),12),'Z')
set @currDate2 = left(convert(varchar,GETDATE(), 121),10)
set @date1 = (select wks1 from DATAOPA.dbo.TIME_FRAME where dateID = @currDate2)
set @date2 = (select dateYMD from DATAOPA.dbo.TIME_FRAME where dateID = @currDate2)
set @per1 = (select min(YYYYMM) from DATAOPA.dbo.TIME_FRAME where wks1 = @date1)
set @week1 = (select WNumber from DATAOPA.dbo.TIME_FRAME where dateID = @currDate2)
set @week2 = (select WeekNbr from DATAOPA.dbo.TIME_FRAME where dateID = @currDate2)
set @day1 = (select daywnm from DATAOPA.dbo.TIME_FRAME where dateID = @currDate2)
set @year1 = (select YYYY from DATAOPA.dbo.TIME_FRAME where dateID = @currDate2)
declare @int1 int
declare @int2 int
declare @int3 int
declare @int4 int
declare @int5 int
declare @int6 int


--************************************************************************************************************************************************
--************************************************************************************************************************************************
--* 1010001 *--* Gemba Walk / 6S List - Document *--
--************************************************************************************************************************************************

if OBJECT_ID('tempdb.dbo.#ids2','U') is not null
drop table #ids2
select distinct
	   distid
into #ids2
from [DATAOPB].[dbo].[UHSGWL01v]
where [dctpid] = 1010001
  and yyyymm = @per1
  and weeknr = @week1
-- select * from #ids2

if OBJECT_ID('tempdb.dbo.#idsf2','U') is not null
drop table #idsf2
select distinct
	   distid
into #idsf2
from [DATAOPB].[dbo].[UHSGWL01v]
where [dctpid] = 1010002
  and yyyymm = @per1
  and weeknr = @week1
-- select * from #idsf2

if OBJECT_ID('tempdb.dbo.#ids1','U') is not null
drop table #ids1
select ID
into #ids1
from DATAOPA.dbo.DISTRICTS
where ID not in (select * from #ids2)
-- select * from #ids1

if OBJECT_ID('tempdb.dbo.#idsf1','U') is not null
drop table #idsf1
select ID
into #idsf1
from DATAOPA.dbo.DISTRICTS
where ID not in (select * from #idsf2)
-- select * from #idsf1

if OBJECT_ID('tempdb.dbo.#ids3','U') is not null
drop table #ids3
select ROW_NUMBER() over(order by ID) as Rnm
	 , ID
into #ids3
from #ids1
-- select * from #ids3

if OBJECT_ID('tempdb.dbo.#ids4','U') is not null
drop table #ids4
select ROW_NUMBER() over(order by ID) as Rnm
	 , ID
into #ids4
from #idsf1
-- select * from #ids4

set @int1 = 1
set @int2 = (select max(Rnm) from #ids3)

while (@int1 <= @int2)
begin

	set @int3 = (select ID from #ids3 where Rnm = @int1)

	insert into [DATAOPA].[dbo].[UHSGWL01]
	select concat(@per1,@week2,'D',@int3,'A0GR1010DC1010001')
	      ,[projid] = 13
	      ,[tskoid] = 50
	      ,[dcgrid] = 1010
	      ,[dctpid] = 1010001
	      ,[tspdid] = 2
	      ,[distid] = @int3
	      ,[acctid] = 0
	      ,[userid] = 1
	      ,[tstp01] = 1
		  ,[tstp011] = 0,[tstp012] = 0,[tstp013] = 0,[tstp014] = 0,[tstp015] = 0,[tstp016] = 0,[tstp017] = 0,[tstp02] = 2,[tstp021] = 0,[tstp022] = 0,[tstp023] = 0,[tstp024] = 0,[tstp025] = 0,[tstp026] = 0,[tstp027] = 0,[tstp03] = 3,[tstp031] = 0,[tstp032] = 0,[tstp033] = 0,[tstp034] = 0,[tstp035] = 0,[tstp036] = 0,[tstp037] = 0,[tstp04] = 4,[tstp041] = 0,[tstp042] = 0,[tstp043] = 0,[tstp044] = 0,[tstp045] = 0,[tstp046] = 0,[tstp047] = 0,[tstp05] = 5,[tstp051] = 0,[tstp052] = 0,[tstp053] = 0,[tstp054] = 0,[tstp055] = 0,[tstp056] = 0,[tstp057] = 0,[tstp06] = 6,[tstp061] = 0,[tstp062] = 0,[tstp063] = 0,[tstp064] = 0,[tstp065] = 0,[tstp066] = 0,[tstp067] = 0,[tstp07] = 7,[tstp071] = 0,[tstp072] = 0,[tstp073] = 0,[tstp074] = 0,[tstp075] = 0,[tstp076] = 0,[tstp077] = 0,[tstp08] = 8,[tstp081] = 0,[tstp082] = 0,[tstp083] = 0,[tstp084] = 0,[tstp085] = 0,[tstp086] = 0,[tstp087] = 0,[tstp09] = 9,[tstp091] = 0,[tstp092] = 0,[tstp093] = 0,[tstp094] = 0,[tstp095] = 0,[tstp096] = 0,[tstp097] = 0,[tstp10] = 10,[tstp101] = 0,[tstp102] = 0,[tstp103] = 0,[tstp104] = 0,[tstp105] = 0,[tstp106] = 0,[tstp107] = 0,[tstp11] = 11,[tstp111] = 0,[tstp112] = 0,[tstp113] = 0,[tstp114] = 0,[tstp115] = 0,[tstp116] = 0,[tstp117] = 0,[tstp12] = 12,[tstp121] = 0,[tstp122] = 0,[tstp123] = 0,[tstp124] = 0,[tstp125] = 0,[tstp126] = 0,[tstp127] = 0,[tstp13] = 13,[tstp131] = 0,[tstp132] = 0,[tstp133] = 0,[tstp134] = 0,[tstp135] = 0,[tstp136] = 0,[tstp137] = 0,[tstp14] = 14,[tstp141] = 0,[tstp142] = 0,[tstp143] = 0,[tstp144] = 0,[tstp145] = 0,[tstp146] = 0,[tstp147] = 0,[tstp15] = 15,[tstp151] = 0,[tstp152] = 0,[tstp153] = 0,[tstp154] = 0,[tstp155] = 0,[tstp156] = 0,[tstp157] = 0,[tstp16] = 16,[tstp161] = 0,[tstp162] = 0,[tstp163] = 0,[tstp164] = 0,[tstp165] = 0,[tstp166] = 0,[tstp167] = 0,[tstp17] = 17,[tstp171] = 0,[tstp172] = 0,[tstp173] = 0,[tstp174] = 0,[tstp175] = 0,[tstp176] = 0,[tstp177] = 0,[tstp18] = 18,[tstp181] = 0,[tstp182] = 0,[tstp183] = 0,[tstp184] = 0,[tstp185] = 0,[tstp186] = 0,[tstp187] = 0
	      ,[chck] = 0
	      ,[chckid] = 0
	      ,[chckdt] = null
	      ,[crdt] = @currDate1
	      ,[eddt] = @currDate1
	      ,[crusid] = 1
	      ,[edusid] = 1
		  ,ts6s01 = 1,ts6s011 = 0,ts6s012 = 0,ts6s013 = 0,ts6s014 = 0,ts6s015 = 0,ts6s016 = 0,ts6s017 = 0,ts6s02 = 1,ts6s021 = 0,ts6s022 = 0,ts6s023 = 0,ts6s024 = 0,ts6s025 = 0,ts6s026 = 0,ts6s027 = 0,ts6s03 = 1,ts6s031 = 0,ts6s032 = 0,ts6s033 = 0,ts6s034 = 0,ts6s035 = 0,ts6s036 = 0,ts6s037 = 0,ts6s04 = 1,ts6s041 = 0,ts6s042 = 0,ts6s043 = 0,ts6s044 = 0,ts6s045 = 0,ts6s046 = 0,ts6s047 = 0,ts6s05 = 1,ts6s051 = 0,ts6s052 = 0,ts6s053 = 0,ts6s054 = 0,ts6s055 = 0,ts6s056 = 0,ts6s057 = 0,ts6s06 = 1,ts6s061 = 0,ts6s062 = 0,ts6s063 = 0,ts6s064 = 0,ts6s065 = 0,ts6s066 = 0,ts6s067 = 0,ts6s07 = 1,ts6s071 = 0,ts6s072 = 0,ts6s073 = 0,ts6s074 = 0,ts6s075 = 0,ts6s076 = 0,ts6s077 = 0,ts6s08 = 1,ts6s081 = 0,ts6s082 = 0,ts6s083 = 0,ts6s084 = 0,ts6s085 = 0,ts6s086 = 0,ts6s087 = 0,ts6s09 = 1,ts6s091 = 0,ts6s092 = 0,ts6s093 = 0,ts6s094 = 0,ts6s095 = 0,ts6s096 = 0,ts6s097 = 0,ts6s10 = 1,ts6s101 = 0,ts6s102 = 0,ts6s103 = 0,ts6s104 = 0,ts6s105 = 0,ts6s106 = 0,ts6s107 = 0,ts6s11 = 1,ts6s111 = 0,ts6s112 = 0,ts6s113 = 0,ts6s114 = 0,ts6s115 = 0,ts6s116 = 0,ts6s117 = 0
	
	set @int1 = @int1 + 1
end



-- select * from [DATAOPB].[dbo].[UHSGWL01v]
-- delete from [DATAOPA].[dbo].[UHSGWL01]
-- delete from [DATAOPB].[dbo].[UHSGWL01v]


--************************************************************************************************************************************************
--************************************************************************************************************************************************
--* 1010003 *--* Visual Work Place Assessment Document *--
--************************************************************************************************************************************************

if OBJECT_ID('tempdb.dbo.#ids21','U') is not null
drop table #ids21
select distinct
	   distid
into #ids21
from [DATAOPB].[dbo].[UHSVAS01v]
where [dctpid] = 1010003
-- select * from #ids21

if OBJECT_ID('tempdb.dbo.#ids11','U') is not null
drop table #ids11
select ID
into #ids11
from DATAOPA.dbo.DISTRICTS
where ID not in (select * from #ids21)
-- select * from #ids11

if OBJECT_ID('tempdb.dbo.#ids31','U') is not null
drop table #ids31
select ROW_NUMBER() over(order by ID) as Rnm
	 , ID
into #ids31
from #ids11
-- select * from #ids31

set @int1 = 1
set @int2 = (select max(Rnm) from #ids31)

while (@int1 <= @int2)
begin

	set @int3 = (select ID from #ids31 where Rnm = @int1)

	insert into [DATAOPA].[dbo].[UHSVAS01]
	SELECT concat(@date2,'D',@int3,'A0GR1010DC1010003')
      ,[projid] = 13
      ,[tskoid] = 52
      ,[dcgrid] = 1010
      ,[dctpid]	= 1010003
      ,[tspdid] = 2
      ,[distid] = @int3
      ,[acctid] = 0
      ,[userid] = 0
      ,[dimgid] = 0
      ,[GR001] = 0,[GR002] = 0,[GR003] = 0,[GR004] = 0,[GR005] = 0,[GR006] = 0,[GR007] = 0,[GR008] = 0,[GR009] = 0,[GR010] = 0,[GR011] = 0,[GR012] = 0,[GR013] = 0,[GR014] = 0,[GR015] = 0,[GR016] = 0,[GR017] = 0,[GR018] = 0,[GR019] = 0,[GR020] = 0,[GR021] = 0,[GR022] = 0,[GR023] = 0,[GR024] = 0,[GR025] = 0,[GR026] = 0,[GR027] = 0,[GR028] = 0,[GR029] = 0,[GR030] = 0,[GR031] = 0,[GR032] = 0,[GR033] = 0,[GR034] = 0,[GR035] = 0,[GR036] = 0,[GR037] = 0,[GR038] = 0,[GR039] = 0,[GR040] = 0,[GR041] = 0,[GR042] = 0,[GR043] = 0,[GR044] = 0,[GR045] = 0,[GR046] = 0,[GR047] = 0,[GR048] = 0,[GR049] = 0,[GR050] = 0,[GR051] = 0,[GR052] = 0,[GR053] = 0,[GR054] = 0,[GR055] = 0,[GR056] = 0,[GR057] = 0,[GR058] = 0,[GR059] = 0,[GR060] = 0,[GR061] = 0,[GR062] = 0,[GR063] = 0,[GR064] = 0,[GR065] = 0,[GR066] = 0,[GR067] = 0,[GR068] = 0,[GR069] = 0,[GR070] = 0,[GR071] = 0,[GR072] = 0,[GR073] = 0,[GR074] = 0,[GR075] = 0,[GR076] = 0,[GR077] = 0,[GR078] = 0,[GR079] = 0,[GR080] = 0,[GR081] = 0,[GR082] = 0,[GR083] = 0,[GR084] = 0,[GR085] = 0,[GR086] = 0,[GR087] = 0,[GR088] = 0,[GR089] = 0,[GR090] = 0,[GR091] = 0,[GR092] = 0,[GR093] = 0,[GR094] = 0,[GR095] = 0,[GR096] = 0,[GR097] = 0,[GR098] = 0,[GR099] = 0,[GR100] = 0,[GR101] = 0,[GR102] = 0,[GR103] = 0,[GR104] = 0,[GR105] = 0,[GR106] = 0,[GR107] = 0,[GR108] = 0,[GR109] = 0,[GR110] = 0,[GR111] = 0,[GR112] = 0,[GR113] = 0,[GR114] = 0,[GR115] = 0,[GR116] = 0,[GR117] = 0,[GR118] = 0,[GR119] = 0,[GR120] = 0,[GR121] = 0,[GR122] = 0,[GR123] = 0,[GR124] = 0,[GR125] = 0,[GR126] = 0,[GR127] = 0,[GR128] = 0,[GR129] = 0,[GR130] = 0,[GR131] = 0,[GR132] = 0,[GR133] = 0,[GR134] = 0,[GR135] = 0,[GR136] = 0,[TX001] = null,[TX002] = null,[TX003] = null,[TX004] = null,[TX005] = null,[TX006] = null,[TX007] = null,[TX008] = null,[TX009] = null,[TX010] = null,[TX011] = null,[TX012] = null,[TX013] = null,[TX014] = null,[TX015] = null,[TX016] = null,[TX017] = null,[TX018] = null,[TX019] = null,[TX020] = null,[TX021] = null,[TX022] = null,[TX023] = null,[TX024] = null,[TX025] = null,[TX026] = null,[TX027] = null,[TX028] = null,[TX029] = null,[TX030] = null,[TX031] = null,[TX032] = null,[TX033] = null,[TX034] = null,[TX035] = null,[TX036] = null,[TX037] = null,[TX038] = null,[TX039] = null,[TX040] = null,[TX041] = null,[TX042] = null,[TX043] = null,[TX044] = null,[TX045] = null,[TX046] = null,[TX047] = null,[TX048] = null,[TX049] = null,[TX050] = null,[TX051] = null,[TX052] = null,[TX053] = null,[TX054] = null,[TX055] = null,[TX056] = null,[TX057] = null,[TX058] = null,[TX059] = null,[TX060] = null,[TX061] = null,[TX062] = null,[TX063] = null,[TX064] = null,[TX065] = null,[TX066] = null,[TX067] = null,[TX068] = null,[TX069] = null,[TX070] = null,[TX071] = null,[TX072] = null,[TX073] = null,[TX074] = null,[TX075] = null,[TX076] = null,[TX077] = null,[TX078] = null,[TX079] = null,[TX080] = null,[TX081] = null,[TX082] = null,[TX083] = null,[TX084] = null,[TX085] = null,[TX086] = null,[TX087] = null,[TX088] = null,[TX089] = null,[TX090] = null,[TX091] = null,[TX092] = null,[TX093] = null,[TX094] = null,[TX095] = null,[TX096] = null,[TX097] = null,[TX098] = null,[TX099] = null,[TX100] = null,[TX101] = null,[TX102] = null,[TX103] = null,[TX104] = null,[TX105] = null,[TX106] = null,[TX107] = null,[TX108] = null,[TX109] = null,[TX110] = null,[TX111] = null,[TX112] = null,[TX113] = null,[TX114] = null,[TX115] = null,[TX116] = null,[TX117] = null,[TX118] = null,[TX119] = null,[TX120] = null,[TX121] = null,[TX122] = null,[TX123] = null,[TX124] = null,[TX125] = null,[TX126] = null,[TX127] = null,[TX128] = null,[TX129] = null,[TX130] = null,[TX131] = null,[TX132] = null,[TX133] = null,[TX134] = null,[TX135] = null,[TX136] = null
      ,[chck] = 0
      ,[chckid] = 0
      ,[chckdt] = null
      ,[crdt] = @currDate1
      ,[eddt] = @currDate1
      ,[crusid] = 1
      ,[edusid] = 1

	  set @int1 = @int1 + 1
end
-- select * from [DATAOPA].[dbo].[UHSVAS01]
-- select * from [DATAOPB].[dbo].[UHSVAS01v]
-- delete from [DATAOPA].[dbo].[UHSVAS01]


--************************************************************************************************************************************************
--************************************************************************************************************************************************
--* 1010006 *--* A360 OM-D Document *--
--************************************************************************************************************************************************

if OBJECT_ID('tempdb.dbo.#idg11','U') is not null
drop table #idg11
select distinct
	   acctid
into #idg11
from [DATAOPB].[dbo].[UHSOMD11v]
where [dctpid] = 1010006
  and [tspdid] = 1
  and [yyyymmdd] = @date2
-- select * from #idg11
-- select * from [DATAOPB].[dbo].[UHSOMD11v]

if OBJECT_ID('tempdb.dbo.#idg12','U') is not null
drop table #idg12
select IDc
into #idg12
from DATAOPA.dbo.UHSACCTS
where typeid = 1
  and IDc not in (select acctid from #idg11)
-- select * from #idg12
-- select * from DATAOPA.dbo.UHSACCTS

if OBJECT_ID('tempdb.dbo.#idg13','U') is not null
drop table #idg13
select ROW_NUMBER() over(order by IDc) as Rnm
	 , IDc
into #idg13
from #idg12
-- select * from #idg13

set @int1 = 1
set @int2 = (select max(Rnm) from #idg13)

while (@int1 <= @int2)
begin

	set @int3 = (select IDc from #idg13 where Rnm = @int1)
	set @int4 = isnull((select DISTID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)
	set @int5 = isnull((select MGRID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)
	set @int6 = isnull((select DODID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)
	
insert into [DATAOPA].[dbo].[UHSOMD11]
SELECT concat(@date2,'D',@int4,'A',@int3,'GR1010DC1010006')
      ,[projid] = 13
      ,[tskoid] = 55
      ,[dcgrid] = 1010
      ,[dctpid]	= 1010006
      ,[tspdid] = 1
      ,[distid] = @int4
      ,[acctid] = @int3
      ,[userid] = @int5 -- OM-H
      ,[dimgid] = @int6 -- DOD
	  ,[smid111] = 0
      ,[cmdt111] = null
      ,[verf111] = 0
      ,[smid112] = 0
      ,[cmdt112] = null
      ,[verf112] = 0
      ,[smid113] = 0
      ,[cmdt113] = null
      ,[verf113] = 0
      ,[smid114] = 0
      ,[cmdt114] = null
      ,[verf114] = 0
      ,[smid115] = 0
      ,[cmdt115] = null
      ,[verf115] = 0
      ,[smid116] = 0
      ,[cmdt116] = null
      ,[verf116] = 0
      ,[smid117] = 0
      ,[cmdt117] = null
      ,[verf117] = 0
      ,[smid118] = 0
      ,[cmdt118] = null
      ,[verf118] = 0
      ,[smid119] = 0
      ,[cmdt119] = null
      ,[verf119] = 0
      ,[smid120] = 0
      ,[cmdt120] = null
      ,[verf120] = 0
      ,[smid121] = 0
      ,[cmdt121] = null
      ,[verf121] = 0
      ,[smid122] = 0
      ,[cmdt122] = null
      ,[verf122] = 0
      ,[smid123] = 0
      ,[cmdt123] = null
      ,[verf123] = 0
      ,[smid124] = 0
      ,[cmdt124] = null
      ,[verf124] = 0
      ,[smid125] = 0
      ,[cmdt125] = null
      ,[verf125] = 0
      ,[note01] = null
      ,[note02] = null
      ,[note03] = null
      ,[note04] = null
      ,[note05] = null
      ,[note06] = null
      ,[note07] = null
      ,[note08] = null
      ,[note09] = null
      ,[note10] = null
      ,[note11] = null
      ,[note12] = null
      ,[note13] = null
      ,[note14] = null
      ,[note15] = null
      ,[task01] = null
      ,[task02] = null
      ,[task03] = null
      ,[task04] = null
      ,[task05] = null
      ,[acit01] = null
      ,[acit02] = null
      ,[acit03] = null
      ,[acit04] = null
      ,[acit05] = null
      ,[tool01] = null
      ,[tool02] = null
      ,[tool03] = null
      ,[tool04] = null
      ,[tool05] = null
      ,[docn01] = null
      ,[docn02] = null
      ,[docn03] = null
      ,[docn04] = null
      ,[docn05] = null
      ,[prfx01] = 0
      ,[prfx02] = 0
      ,[prfx03] = 0
      ,[prfx04] = 0
      ,[prfx05] = 0
	  ,[rate01] = 0
	  ,[rate02] = 0
	  ,[rate03] = 0
	  ,[rate04] = 0
	  ,[rate05] = 0
	  ,[chck] = 0
      ,[chckid] = 0
      ,[chckdt] = null
	  ,[crdate] = @currDate2
      ,[crdt] = @currDate1
      ,[eddt] = @currDate1
      ,[crusid] = 1
      ,[edusid] = 1

	  set @int1 = @int1 + 1
end


if OBJECT_ID('tempdb.dbo.#irs2','U') is not null
drop table #irs2
select distinct
	   acctid
into #irs2
from [DATAOPB].[dbo].[UHSOMD11v]
where [dctpid] = 1010006
  and [tspdid] = 2
  and yyyymm = @per1
  and weeknr = @week1
-- select * from #irs2

if OBJECT_ID('tempdb.dbo.#irs1','U') is not null
drop table #irs1
select IDc
into #irs1
from DATAOPA.dbo.UHSACCTS
where typeid = 1
  and IDc not in (select * from #irs2)
-- select * from #irs1

if OBJECT_ID('tempdb.dbo.#irs3','U') is not null
drop table #irs3
select ROW_NUMBER() over(order by IDc) as Rnm
	 , IDc
into #irs3
from #irs1
-- select * from #irs3


set @int1 = 1
set @int2 = (select max(Rnm) from #irs3)

while (@int1 <= @int2)
begin

	set @int3 = (select IDc from #irs3 where Rnm = @int1)
	set @int4 = isnull((select DISTID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)
	set @int5 = isnull((select MGRID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)
	set @int6 = isnull((select DODID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)

insert into [DATAOPA].[dbo].[UHSOMD12]
SELECT concat(@date2,@week2,'D',@int4,'A',@int3,'GR1010DC1010006')
      ,[projid] = 13
      ,[tskoid] = 55
      ,[dcgrid] = 1010
      ,[dctpid]	= 1010006
      ,[tspdid] = 2
      ,[distid] = @int4
      ,[acctid] = @int3
      ,[userid] = @int5 -- OM-H
      ,[dimgid] = @int6 -- DOD
	  ,[smid111] = 0
      ,[cmdt111] = null
      ,[verf111] = 0
      ,[smid112] = 0
      ,[cmdt112] = null
      ,[verf112] = 0
      ,[smid113] = 0
      ,[cmdt113] = null
      ,[verf113] = 0
      ,[smid114] = 0
      ,[cmdt114] = null
      ,[verf114] = 0
      ,[smid115] = 0
      ,[cmdt115] = null
      ,[verf115] = 0
      ,[smid116] = 0
      ,[cmdt116] = null
      ,[verf116] = 0
      ,[smid117] = 0
      ,[cmdt117] = null
      ,[verf117] = 0
      ,[smid118] = 0
      ,[cmdt118] = null
      ,[verf118] = 0
      ,[smid119] = 0
      ,[cmdt119] = null
      ,[verf119] = 0
      ,[smid120] = 0
      ,[cmdt120] = null
      ,[verf120] = 0
      ,[smid121] = 0
      ,[cmdt121] = null
      ,[verf121] = 0
      ,[smid122] = 0
      ,[cmdt122] = null
      ,[verf122] = 0
      ,[smid123] = 0
      ,[cmdt123] = null
      ,[verf123] = 0
      ,[smid124] = 0
      ,[cmdt124] = null
      ,[verf124] = 0
      ,[smid125] = 0
      ,[cmdt125] = null
      ,[verf125] = 0
      ,[note01] = null
      ,[note02] = null
      ,[note03] = null
      ,[note04] = null
      ,[note05] = null
      ,[note06] = null
      ,[note07] = null
      ,[note08] = null
      ,[note09] = null
      ,[note10] = null
      ,[note11] = null
      ,[note12] = null
      ,[note13] = null
      ,[note14] = null
      ,[note15] = null
      ,[task01] = null
      ,[task02] = null
      ,[task03] = null
      ,[task04] = null
      ,[task05] = null
      ,[acit01] = null
      ,[acit02] = null
      ,[acit03] = null
      ,[acit04] = null
      ,[acit05] = null
      ,[tool01] = null
      ,[tool02] = null
      ,[tool03] = null
      ,[tool04] = null
      ,[tool05] = null
      ,[docn01] = null
      ,[docn02] = null
      ,[docn03] = null
      ,[docn04] = null
      ,[docn05] = null
      ,[prfx01] = 0
      ,[prfx02] = 0
      ,[prfx03] = 0
      ,[prfx04] = 0
      ,[prfx05] = 0
	  ,[rate01] = 0
	  ,[rate02] = 0
	  ,[rate03] = 0
	  ,[rate04] = 0
	  ,[rate05] = 0
	  ,[chck] = 0
      ,[chckid] = 0
      ,[chckdt] = null
	  ,[crdate] = @currDate2
      ,[crdt] = @currDate1
      ,[eddt] = @currDate1
      ,[crusid] = 1
      ,[edusid] = 1

	  set @int1 = @int1 + 1
end



if OBJECT_ID('tempdb.dbo.#ies2','U') is not null
drop table #ies2
select distinct
	   acctid
into #ies2
from [DATAOPB].[dbo].[UHSOMD11v]
where [dctpid] = 1010006
  and [tspdid] = 3
  and yyyymm = @per1
-- select * from #ies2

if OBJECT_ID('tempdb.dbo.#ies1','U') is not null
drop table #ies1
select IDc
into #ies1
from DATAOPA.dbo.UHSACCTS
where typeid = 1
  and IDc not in (select * from #ies2)
-- select * from #ies1

if OBJECT_ID('tempdb.dbo.#ies3','U') is not null
drop table #ies3
select ROW_NUMBER() over(order by IDc) as Rnm
	 , IDc
into #ies3
from #ies1
-- select * from #ies3


set @int1 = 1
set @int2 = (select max(Rnm) from #ies3)

while (@int1 <= @int2)
begin

	set @int3 = (select IDc from #ies3 where Rnm = @int1)
	set @int4 = isnull((select DISTID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)
	set @int5 = isnull((select MGRID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)
	set @int6 = isnull((select DODID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)

insert into [DATAOPA].[dbo].[UHSOMD13]
SELECT concat(@date2,'P',@per1,'D',@int4,'A',@int3,'GR1010DC1010006')
      ,[projid] = 13
      ,[tskoid] = 55
      ,[dcgrid] = 1010
      ,[dctpid]	= 1010006
      ,[tspdid] = 3
      ,[distid] = @int4
      ,[acctid] = @int3
      ,[userid] = @int5 -- OM-H
      ,[dimgid] = @int6 -- DOD
	  ,[smid111] = 0
      ,[cmdt111] = null
      ,[verf111] = 0
      ,[smid112] = 0
      ,[cmdt112] = null
      ,[verf112] = 0
      ,[smid113] = 0
      ,[cmdt113] = null
      ,[verf113] = 0
      ,[smid114] = 0
      ,[cmdt114] = null
      ,[verf114] = 0
      ,[smid115] = 0
      ,[cmdt115] = null
      ,[verf115] = 0
      ,[smid116] = 0
      ,[cmdt116] = null
      ,[verf116] = 0
      ,[smid117] = 0
      ,[cmdt117] = null
      ,[verf117] = 0
      ,[smid118] = 0
      ,[cmdt118] = null
      ,[verf118] = 0
      ,[smid119] = 0
      ,[cmdt119] = null
      ,[verf119] = 0
      ,[smid120] = 0
      ,[cmdt120] = null
      ,[verf120] = 0
      ,[smid121] = 0
      ,[cmdt121] = null
      ,[verf121] = 0
      ,[smid122] = 0
      ,[cmdt122] = null
      ,[verf122] = 0
      ,[smid123] = 0
      ,[cmdt123] = null
      ,[verf123] = 0
      ,[smid124] = 0
      ,[cmdt124] = null
      ,[verf124] = 0
      ,[smid125] = 0
      ,[cmdt125] = null
      ,[verf125] = 0
      ,[note01] = null
      ,[note02] = null
      ,[note03] = null
      ,[note04] = null
      ,[note05] = null
      ,[note06] = null
      ,[note07] = null
      ,[note08] = null
      ,[note09] = null
      ,[note10] = null
      ,[note11] = null
      ,[note12] = null
      ,[note13] = null
      ,[note14] = null
      ,[note15] = null
      ,[task01] = null
      ,[task02] = null
      ,[task03] = null
      ,[task04] = null
      ,[task05] = null
      ,[acit01] = null
      ,[acit02] = null
      ,[acit03] = null
      ,[acit04] = null
      ,[acit05] = null
      ,[tool01] = null
      ,[tool02] = null
      ,[tool03] = null
      ,[tool04] = null
      ,[tool05] = null
      ,[docn01] = null
      ,[docn02] = null
      ,[docn03] = null
      ,[docn04] = null
      ,[docn05] = null
      ,[prfx01] = 0
      ,[prfx02] = 0
      ,[prfx03] = 0
      ,[prfx04] = 0
      ,[prfx05] = 0
	  ,[rate01] = 0
	  ,[rate02] = 0
	  ,[rate03] = 0
	  ,[rate04] = 0
	  ,[rate05] = 0
	  ,[chck] = 0
      ,[chckid] = 0
      ,[chckdt] = null
	  ,[crdate] = @currDate2
      ,[crdt] = @currDate1
      ,[eddt] = @currDate1
      ,[crusid] = 1
      ,[edusid] = 1

	  set @int1 = @int1 + 1
end

set @qtr1 = (select [Quarter] from DATAOPA.dbo.TIME_FRAME where dateID = @currDate2)

if OBJECT_ID('tempdb.dbo.#ikm1','U') is not null
drop table #ikm1
select dateID
into #ikm1
from DATAOPA.dbo.TIME_FRAME
where YYYY = @year1
  and [Quarter] = @qtr1
-- select * from #ikm1

if OBJECT_ID('tempdb.dbo.#ikm2','U') is not null
drop table #ikm2
select distinct
	   acctid
into #ikm2
from [DATAOPB].[dbo].[UHSOMD11v]
where [dctpid] = 1010006
  and [tspdid] = 4
  and [crdate] in (select * from #ikm1)
-- select * from #ikm2

if OBJECT_ID('tempdb.dbo.#ikm3','U') is not null
drop table #ikm3
select IDc
into #ikm3
from DATAOPA.dbo.UHSACCTS
where typeid = 1
  and IDc not in (select * from #ikm2)
-- select * from #ikm3

if OBJECT_ID('tempdb.dbo.#ikm4','U') is not null
drop table #ikm4
select ROW_NUMBER() over(order by IDc) as Rnm
	 , IDc
into #ikm4
from #ikm3
-- select * from #ikm4


set @int1 = 1
set @int2 = (select max(Rnm) from #ikm4)

while (@int1 <= @int2)
begin

	set @int3 = (select IDc from #ikm4 where Rnm = @int1)
	set @int4 = isnull((select DISTID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)
	set @int5 = isnull((select MGRID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)
	set @int6 = isnull((select DODID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)

insert into [DATAOPA].[dbo].[UHSOMD14]
SELECT concat(@date2,'Q',@qtr1,'D',@int4,'A',@int3,'GR1010DC1010006')
      ,[projid] = 13
      ,[tskoid] = 55
      ,[dcgrid] = 1010
      ,[dctpid]	= 1010006
      ,[tspdid] = 4
      ,[distid] = @int4
      ,[acctid] = @int3
      ,[userid] = @int5 -- OM-H
      ,[dimgid] = @int6 -- DOD
	  ,[smid111] = 0
      ,[cmdt111] = null
      ,[verf111] = 0
      ,[smid112] = 0
      ,[cmdt112] = null
      ,[verf112] = 0
      ,[smid113] = 0
      ,[cmdt113] = null
      ,[verf113] = 0
      ,[smid114] = 0
      ,[cmdt114] = null
      ,[verf114] = 0
      ,[smid115] = 0
      ,[cmdt115] = null
      ,[verf115] = 0
      ,[smid116] = 0
      ,[cmdt116] = null
      ,[verf116] = 0
      ,[smid117] = 0
      ,[cmdt117] = null
      ,[verf117] = 0
      ,[smid118] = 0
      ,[cmdt118] = null
      ,[verf118] = 0
      ,[smid119] = 0
      ,[cmdt119] = null
      ,[verf119] = 0
      ,[smid120] = 0
      ,[cmdt120] = null
      ,[verf120] = 0
      ,[smid121] = 0
      ,[cmdt121] = null
      ,[verf121] = 0
      ,[smid122] = 0
      ,[cmdt122] = null
      ,[verf122] = 0
      ,[smid123] = 0
      ,[cmdt123] = null
      ,[verf123] = 0
      ,[smid124] = 0
      ,[cmdt124] = null
      ,[verf124] = 0
      ,[smid125] = 0
      ,[cmdt125] = null
      ,[verf125] = 0
      ,[note01] = null
      ,[note02] = null
      ,[note03] = null
      ,[note04] = null
      ,[note05] = null
      ,[note06] = null
      ,[note07] = null
      ,[note08] = null
      ,[note09] = null
      ,[note10] = null
      ,[note11] = null
      ,[note12] = null
      ,[note13] = null
      ,[note14] = null
      ,[note15] = null
      ,[task01] = null
      ,[task02] = null
      ,[task03] = null
      ,[task04] = null
      ,[task05] = null
      ,[acit01] = null
      ,[acit02] = null
      ,[acit03] = null
      ,[acit04] = null
      ,[acit05] = null
      ,[tool01] = null
      ,[tool02] = null
      ,[tool03] = null
      ,[tool04] = null
      ,[tool05] = null
      ,[docn01] = null
      ,[docn02] = null
      ,[docn03] = null
      ,[docn04] = null
      ,[docn05] = null
      ,[prfx01] = 0
      ,[prfx02] = 0
      ,[prfx03] = 0
      ,[prfx04] = 0
      ,[prfx05] = 0
	  ,[rate01] = 0
	  ,[rate02] = 0
	  ,[rate03] = 0
	  ,[rate04] = 0
	  ,[rate05] = 0
	  ,[chck] = 0
      ,[chckid] = 0
      ,[chckdt] = null
	  ,[crdate] = @currDate2
      ,[crdt] = @currDate1
      ,[eddt] = @currDate1
      ,[crusid] = 1
      ,[edusid] = 1

	  set @int1 = @int1 + 1
end


if OBJECT_ID('tempdb.dbo.#izm2','U') is not null
drop table #izm2
select distinct
	   acctid
into #izm2
from [DATAOPB].[dbo].[UHSOMD11v]
where [dctpid] = 1010006
  and [tspdid] = 5
  and yyyy = @year1
-- select * from #izm2

if OBJECT_ID('tempdb.dbo.#izm3','U') is not null
drop table #izm3
select IDc
into #izm3
from DATAOPA.dbo.UHSACCTS
where typeid = 1
  and IDc not in (select * from #izm2)
-- select * from #ikm3

if OBJECT_ID('tempdb.dbo.#izm4','U') is not null
drop table #izm4
select ROW_NUMBER() over(order by IDc) as Rnm
	 , IDc
into #izm4
from #izm3
-- select * from #izm4


set @int1 = 1
set @int2 = (select max(Rnm) from #izm4)

while (@int1 <= @int2)
begin

	set @int3 = (select IDc from #izm4 where Rnm = @int1)
	set @int4 = isnull((select DISTID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)
	set @int5 = isnull((select MGRID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)
	set @int6 = isnull((select DODID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)

insert into [DATAOPA].[dbo].[UHSOMD15]
SELECT concat(@date2,'Y',@year1,'D',@int4,'A',@int3,'GR1010DC1010006')
      ,[projid] = 13
      ,[tskoid] = 55
      ,[dcgrid] = 1010
      ,[dctpid]	= 1010006
      ,[tspdid] = 5
      ,[distid] = @int4
      ,[acctid] = @int3
      ,[userid] = @int5 -- OM-H
      ,[dimgid] = @int6 -- DOD
	  ,[smid111] = 0
      ,[cmdt111] = null
      ,[verf111] = 0
      ,[smid112] = 0
      ,[cmdt112] = null
      ,[verf112] = 0
      ,[smid113] = 0
      ,[cmdt113] = null
      ,[verf113] = 0
      ,[smid114] = 0
      ,[cmdt114] = null
      ,[verf114] = 0
      ,[smid115] = 0
      ,[cmdt115] = null
      ,[verf115] = 0
      ,[smid116] = 0
      ,[cmdt116] = null
      ,[verf116] = 0
      ,[smid117] = 0
      ,[cmdt117] = null
      ,[verf117] = 0
      ,[smid118] = 0
      ,[cmdt118] = null
      ,[verf118] = 0
      ,[smid119] = 0
      ,[cmdt119] = null
      ,[verf119] = 0
      ,[smid120] = 0
      ,[cmdt120] = null
      ,[verf120] = 0
      ,[smid121] = 0
      ,[cmdt121] = null
      ,[verf121] = 0
      ,[smid122] = 0
      ,[cmdt122] = null
      ,[verf122] = 0
      ,[smid123] = 0
      ,[cmdt123] = null
      ,[verf123] = 0
      ,[smid124] = 0
      ,[cmdt124] = null
      ,[verf124] = 0
      ,[smid125] = 0
      ,[cmdt125] = null
      ,[verf125] = 0
      ,[note01] = null
      ,[note02] = null
      ,[note03] = null
      ,[note04] = null
      ,[note05] = null
      ,[note06] = null
      ,[note07] = null
      ,[note08] = null
      ,[note09] = null
      ,[note10] = null
      ,[note11] = null
      ,[note12] = null
      ,[note13] = null
      ,[note14] = null
      ,[note15] = null
      ,[task01] = null
      ,[task02] = null
      ,[task03] = null
      ,[task04] = null
      ,[task05] = null
      ,[acit01] = null
      ,[acit02] = null
      ,[acit03] = null
      ,[acit04] = null
      ,[acit05] = null
      ,[tool01] = null
      ,[tool02] = null
      ,[tool03] = null
      ,[tool04] = null
      ,[tool05] = null
      ,[docn01] = null
      ,[docn02] = null
      ,[docn03] = null
      ,[docn04] = null
      ,[docn05] = null
      ,[prfx01] = 0
      ,[prfx02] = 0
      ,[prfx03] = 0
      ,[prfx04] = 0
      ,[prfx05] = 0
	  ,[rate01] = 0
	  ,[rate02] = 0
	  ,[rate03] = 0
	  ,[rate04] = 0
	  ,[rate05] = 0
	  ,[chck] = 0
      ,[chckid] = 0
      ,[chckdt] = null
	  ,[crdate] = @currDate2
      ,[crdt] = @currDate1
      ,[eddt] = @currDate1
      ,[crusid] = 1
      ,[edusid] = 1

	  set @int1 = @int1 + 1
end

--************************************************************************************************************************************************
--************************************************************************************************************************************************
--* 1010007 *--* B360 OM-D Document *--
--************************************************************************************************************************************************

if OBJECT_ID('tempdb.dbo.#idb11','U') is not null
drop table #idb11
select distinct
	   acctid
into #idb11
from [DATAOPB].[dbo].[UHSOMD11v]
where [dctpid] = 1010007
  and [tspdid] = 1
  and [yyyymmdd] = @date2
-- select * from #idb11
-- select * from [DATAOPB].[dbo].[UHSOMD11v]

if OBJECT_ID('tempdb.dbo.#idb12','U') is not null
drop table #idb12
select IDc
into #idb12
from DATAOPA.dbo.UHSACCTS
where typeid = 2
  and IDc not in (select acctid from #idb11)
-- select * from #idb12
-- select * from DATAOPA.dbo.UHSACCTS

if OBJECT_ID('tempdb.dbo.#idb13','U') is not null
drop table #idb13
select ROW_NUMBER() over(order by IDc) as Rnm
	 , IDc
into #idb13
from #idb12
-- select * from #idb13

set @int1 = 1
set @int2 = (select max(Rnm) from #idb13)

while (@int1 <= @int2)
begin

	set @int3 = (select IDc from #idb13 where Rnm = @int1)
	set @int4 = isnull((select DISTID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 2),0)
	set @int5 = isnull((select MGRID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 2),0)
	set @int6 = isnull((select DODID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 2),0)
	
insert into [DATAOPA].[dbo].[UHSOMD11]
SELECT concat(@date2,'D',@int4,'A',@int3,'GR1010DC1010007')
      ,[projid] = 13
      ,[tskoid] = 56
      ,[dcgrid] = 1010
      ,[dctpid]	= 1010007
      ,[tspdid] = 1
      ,[distid] = @int4
      ,[acctid] = @int3
      ,[userid] = @int5 -- OM-D
      ,[dimgid] = @int6 -- DOD
	  ,[smid111] = 0
      ,[cmdt111] = null
      ,[verf111] = 0
      ,[smid112] = 0
      ,[cmdt112] = null
      ,[verf112] = 0
      ,[smid113] = 0
      ,[cmdt113] = null
      ,[verf113] = 0
      ,[smid114] = 0
      ,[cmdt114] = null
      ,[verf114] = 0
      ,[smid115] = 0
      ,[cmdt115] = null
      ,[verf115] = 0
      ,[smid116] = 0
      ,[cmdt116] = null
      ,[verf116] = 0
      ,[smid117] = 0
      ,[cmdt117] = null
      ,[verf117] = 0
      ,[smid118] = 0
      ,[cmdt118] = null
      ,[verf118] = 0
      ,[smid119] = 0
      ,[cmdt119] = null
      ,[verf119] = 0
      ,[smid120] = 0
      ,[cmdt120] = null
      ,[verf120] = 0
      ,[smid121] = 0
      ,[cmdt121] = null
      ,[verf121] = 0
      ,[smid122] = 0
      ,[cmdt122] = null
      ,[verf122] = 0
      ,[smid123] = 0
      ,[cmdt123] = null
      ,[verf123] = 0
      ,[smid124] = 0
      ,[cmdt124] = null
      ,[verf124] = 0
      ,[smid125] = 0
      ,[cmdt125] = null
      ,[verf125] = 0
      ,[note01] = null
      ,[note02] = null
      ,[note03] = null
      ,[note04] = null
      ,[note05] = null
      ,[note06] = null
      ,[note07] = null
      ,[note08] = null
      ,[note09] = null
      ,[note10] = null
      ,[note11] = null
      ,[note12] = null
      ,[note13] = null
      ,[note14] = null
      ,[note15] = null
      ,[task01] = null
      ,[task02] = null
      ,[task03] = null
      ,[task04] = null
      ,[task05] = null
      ,[acit01] = null
      ,[acit02] = null
      ,[acit03] = null
      ,[acit04] = null
      ,[acit05] = null
      ,[tool01] = null
      ,[tool02] = null
      ,[tool03] = null
      ,[tool04] = null
      ,[tool05] = null
      ,[docn01] = null
      ,[docn02] = null
      ,[docn03] = null
      ,[docn04] = null
      ,[docn05] = null
      ,[prfx01] = 0
      ,[prfx02] = 0
      ,[prfx03] = 0
      ,[prfx04] = 0
      ,[prfx05] = 0
	  ,[rate01] = 0
	  ,[rate02] = 0
	  ,[rate03] = 0
	  ,[rate04] = 0
	  ,[rate05] = 0
	  ,[chck] = 0
      ,[chckid] = 0
      ,[chckdt] = null
	  ,[crdate] = @currDate2
      ,[crdt] = @currDate1
      ,[eddt] = @currDate1
      ,[crusid] = 1
      ,[edusid] = 1

	  set @int1 = @int1 + 1
end


if OBJECT_ID('tempdb.dbo.#irb2','U') is not null
drop table #irb2
select distinct
	   acctid
into #irb2
from [DATAOPB].[dbo].[UHSOMD11v]
where [dctpid] = 1010007
  and [tspdid] = 2
  and yyyymm = @per1
  and weeknr = @week1
-- select * from #irb2

if OBJECT_ID('tempdb.dbo.#irb1','U') is not null
drop table #irb1
select IDc
into #irb1
from DATAOPA.dbo.UHSACCTS
where typeid = 2
  and IDc not in (select * from #irb2)
-- select * from #irs1

if OBJECT_ID('tempdb.dbo.#irb3','U') is not null
drop table #irb3
select ROW_NUMBER() over(order by IDc) as Rnm
	 , IDc
into #irb3
from #irb1
-- select * from #irb3


set @int1 = 1
set @int2 = (select max(Rnm) from #irb3)

while (@int1 <= @int2)
begin

	set @int3 = (select IDc from #irb3 where Rnm = @int1)
	set @int4 = isnull((select DISTID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 2),0)
	set @int5 = isnull((select MGRID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 2),0)
	set @int6 = isnull((select DODID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 2),0)

insert into [DATAOPA].[dbo].[UHSOMD12]
SELECT concat(@date2,@week2,'D',@int4,'A',@int3,'GR1010DC1010007')
      ,[projid] = 13
      ,[tskoid] = 56
      ,[dcgrid] = 1010
      ,[dctpid]	= 1010007
      ,[tspdid] = 2
      ,[distid] = @int4
      ,[acctid] = @int3
      ,[userid] = @int5 -- OM-H
      ,[dimgid] = @int6 -- DOD
	  ,[smid111] = 0
      ,[cmdt111] = null
      ,[verf111] = 0
      ,[smid112] = 0
      ,[cmdt112] = null
      ,[verf112] = 0
      ,[smid113] = 0
      ,[cmdt113] = null
      ,[verf113] = 0
      ,[smid114] = 0
      ,[cmdt114] = null
      ,[verf114] = 0
      ,[smid115] = 0
      ,[cmdt115] = null
      ,[verf115] = 0
      ,[smid116] = 0
      ,[cmdt116] = null
      ,[verf116] = 0
      ,[smid117] = 0
      ,[cmdt117] = null
      ,[verf117] = 0
      ,[smid118] = 0
      ,[cmdt118] = null
      ,[verf118] = 0
      ,[smid119] = 0
      ,[cmdt119] = null
      ,[verf119] = 0
      ,[smid120] = 0
      ,[cmdt120] = null
      ,[verf120] = 0
      ,[smid121] = 0
      ,[cmdt121] = null
      ,[verf121] = 0
      ,[smid122] = 0
      ,[cmdt122] = null
      ,[verf122] = 0
      ,[smid123] = 0
      ,[cmdt123] = null
      ,[verf123] = 0
      ,[smid124] = 0
      ,[cmdt124] = null
      ,[verf124] = 0
      ,[smid125] = 0
      ,[cmdt125] = null
      ,[verf125] = 0
      ,[note01] = null
      ,[note02] = null
      ,[note03] = null
      ,[note04] = null
      ,[note05] = null
      ,[note06] = null
      ,[note07] = null
      ,[note08] = null
      ,[note09] = null
      ,[note10] = null
      ,[note11] = null
      ,[note12] = null
      ,[note13] = null
      ,[note14] = null
      ,[note15] = null
      ,[task01] = null
      ,[task02] = null
      ,[task03] = null
      ,[task04] = null
      ,[task05] = null
      ,[acit01] = null
      ,[acit02] = null
      ,[acit03] = null
      ,[acit04] = null
      ,[acit05] = null
      ,[tool01] = null
      ,[tool02] = null
      ,[tool03] = null
      ,[tool04] = null
      ,[tool05] = null
      ,[docn01] = null
      ,[docn02] = null
      ,[docn03] = null
      ,[docn04] = null
      ,[docn05] = null
      ,[prfx01] = 0
      ,[prfx02] = 0
      ,[prfx03] = 0
      ,[prfx04] = 0
      ,[prfx05] = 0
	  ,[rate01] = 0
	  ,[rate02] = 0
	  ,[rate03] = 0
	  ,[rate04] = 0
	  ,[rate05] = 0
	  ,[chck] = 0
      ,[chckid] = 0
      ,[chckdt] = null
	  ,[crdate] = @currDate2
      ,[crdt] = @currDate1
      ,[eddt] = @currDate1
      ,[crusid] = 1
      ,[edusid] = 1

	  set @int1 = @int1 + 1
end



if OBJECT_ID('tempdb.dbo.#ieb2','U') is not null
drop table #ieb2
select distinct
	   acctid
into #ieb2
from [DATAOPB].[dbo].[UHSOMD11v]
where [dctpid] = 1010007
  and [tspdid] = 3
  and yyyymm = @per1
-- select * from #ieb2

if OBJECT_ID('tempdb.dbo.#ieb1','U') is not null
drop table #ieb1
select IDc
into #ieb1
from DATAOPA.dbo.UHSACCTS
where typeid = 2
  and IDc not in (select * from #ieb2)
-- select * from #ies1

if OBJECT_ID('tempdb.dbo.#ieb3','U') is not null
drop table #ieb3
select ROW_NUMBER() over(order by IDc) as Rnm
	 , IDc
into #ieb3
from #ieb1
-- select * from #ies3


set @int1 = 1
set @int2 = (select max(Rnm) from #ieb3)

while (@int1 <= @int2)
begin

	set @int3 = (select IDc from #ieb3 where Rnm = @int1)
	set @int4 = isnull((select DISTID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 2),0)
	set @int5 = isnull((select MGRID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 2),0)
	set @int6 = isnull((select DODID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 2),0)

insert into [DATAOPA].[dbo].[UHSOMD13]
SELECT concat(@date2,'P',@per1,'D',@int4,'A',@int3,'GR1010DC1010007')
      ,[projid] = 13
      ,[tskoid] = 56
      ,[dcgrid] = 1010
      ,[dctpid]	= 1010007
      ,[tspdid] = 3
      ,[distid] = @int4
      ,[acctid] = @int3
      ,[userid] = @int5 -- OM-H
      ,[dimgid] = @int6 -- DOD
	  ,[smid111] = 0
      ,[cmdt111] = null
      ,[verf111] = 0
      ,[smid112] = 0
      ,[cmdt112] = null
      ,[verf112] = 0
      ,[smid113] = 0
      ,[cmdt113] = null
      ,[verf113] = 0
      ,[smid114] = 0
      ,[cmdt114] = null
      ,[verf114] = 0
      ,[smid115] = 0
      ,[cmdt115] = null
      ,[verf115] = 0
      ,[smid116] = 0
      ,[cmdt116] = null
      ,[verf116] = 0
      ,[smid117] = 0
      ,[cmdt117] = null
      ,[verf117] = 0
      ,[smid118] = 0
      ,[cmdt118] = null
      ,[verf118] = 0
      ,[smid119] = 0
      ,[cmdt119] = null
      ,[verf119] = 0
      ,[smid120] = 0
      ,[cmdt120] = null
      ,[verf120] = 0
      ,[smid121] = 0
      ,[cmdt121] = null
      ,[verf121] = 0
      ,[smid122] = 0
      ,[cmdt122] = null
      ,[verf122] = 0
      ,[smid123] = 0
      ,[cmdt123] = null
      ,[verf123] = 0
      ,[smid124] = 0
      ,[cmdt124] = null
      ,[verf124] = 0
      ,[smid125] = 0
      ,[cmdt125] = null
      ,[verf125] = 0
      ,[note01] = null
      ,[note02] = null
      ,[note03] = null
      ,[note04] = null
      ,[note05] = null
      ,[note06] = null
      ,[note07] = null
      ,[note08] = null
      ,[note09] = null
      ,[note10] = null
      ,[note11] = null
      ,[note12] = null
      ,[note13] = null
      ,[note14] = null
      ,[note15] = null
      ,[task01] = null
      ,[task02] = null
      ,[task03] = null
      ,[task04] = null
      ,[task05] = null
      ,[acit01] = null
      ,[acit02] = null
      ,[acit03] = null
      ,[acit04] = null
      ,[acit05] = null
      ,[tool01] = null
      ,[tool02] = null
      ,[tool03] = null
      ,[tool04] = null
      ,[tool05] = null
      ,[docn01] = null
      ,[docn02] = null
      ,[docn03] = null
      ,[docn04] = null
      ,[docn05] = null
      ,[prfx01] = 0
      ,[prfx02] = 0
      ,[prfx03] = 0
      ,[prfx04] = 0
      ,[prfx05] = 0
	  ,[rate01] = 0
	  ,[rate02] = 0
	  ,[rate03] = 0
	  ,[rate04] = 0
	  ,[rate05] = 0
	  ,[chck] = 0
      ,[chckid] = 0
      ,[chckdt] = null
	  ,[crdate] = @currDate2
      ,[crdt] = @currDate1
      ,[eddt] = @currDate1
      ,[crusid] = 1
      ,[edusid] = 1

	  set @int1 = @int1 + 1
end

set @qtr1 = (select [Quarter] from DATAOPA.dbo.TIME_FRAME where dateID = @currDate2)

if OBJECT_ID('tempdb.dbo.#ikb1','U') is not null
drop table #ikb1
select dateID
into #ikb1
from DATAOPA.dbo.TIME_FRAME
where YYYY = @year1
  and [Quarter] = @qtr1
-- select * from #ikb1

if OBJECT_ID('tempdb.dbo.#ikb2','U') is not null
drop table #ikb2
select distinct
	   acctid
into #ikb2
from [DATAOPB].[dbo].[UHSOMD11v]
where [dctpid] = 1010007
  and [tspdid] = 4
  and [crdate] in (select * from #ikb1)
-- select * from #ikb2

if OBJECT_ID('tempdb.dbo.#ikb3','U') is not null
drop table #ikb3
select IDc
into #ikb3
from DATAOPA.dbo.UHSACCTS
where typeid = 2
  and IDc not in (select * from #ikb2)
-- select * from #ikb3

if OBJECT_ID('tempdb.dbo.#ikb4','U') is not null
drop table #ikb4
select ROW_NUMBER() over(order by IDc) as Rnm
	 , IDc
into #ikb4
from #ikb3
-- select * from #ikb4


set @int1 = 1
set @int2 = (select max(Rnm) from #ikb4)

while (@int1 <= @int2)
begin

	set @int3 = (select IDc from #ikb4 where Rnm = @int1)
	set @int4 = isnull((select DISTID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 2),0)
	set @int5 = isnull((select MGRID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 2),0)
	set @int6 = isnull((select DODID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 2),0)

insert into [DATAOPA].[dbo].[UHSOMD14]
SELECT concat(@date2,'Q',@qtr1,'D',@int4,'A',@int3,'GR1010DC1010007')
      ,[projid] = 13
      ,[tskoid] = 56
      ,[dcgrid] = 1010
      ,[dctpid]	= 1010007
      ,[tspdid] = 4
      ,[distid] = @int4
      ,[acctid] = @int3
      ,[userid] = @int5 -- OM-D
      ,[dimgid] = @int6 -- DOD
	  ,[smid111] = 0
      ,[cmdt111] = null
      ,[verf111] = 0
      ,[smid112] = 0
      ,[cmdt112] = null
      ,[verf112] = 0
      ,[smid113] = 0
      ,[cmdt113] = null
      ,[verf113] = 0
      ,[smid114] = 0
      ,[cmdt114] = null
      ,[verf114] = 0
      ,[smid115] = 0
      ,[cmdt115] = null
      ,[verf115] = 0
      ,[smid116] = 0
      ,[cmdt116] = null
      ,[verf116] = 0
      ,[smid117] = 0
      ,[cmdt117] = null
      ,[verf117] = 0
      ,[smid118] = 0
      ,[cmdt118] = null
      ,[verf118] = 0
      ,[smid119] = 0
      ,[cmdt119] = null
      ,[verf119] = 0
      ,[smid120] = 0
      ,[cmdt120] = null
      ,[verf120] = 0
      ,[smid121] = 0
      ,[cmdt121] = null
      ,[verf121] = 0
      ,[smid122] = 0
      ,[cmdt122] = null
      ,[verf122] = 0
      ,[smid123] = 0
      ,[cmdt123] = null
      ,[verf123] = 0
      ,[smid124] = 0
      ,[cmdt124] = null
      ,[verf124] = 0
      ,[smid125] = 0
      ,[cmdt125] = null
      ,[verf125] = 0
      ,[note01] = null
      ,[note02] = null
      ,[note03] = null
      ,[note04] = null
      ,[note05] = null
      ,[note06] = null
      ,[note07] = null
      ,[note08] = null
      ,[note09] = null
      ,[note10] = null
      ,[note11] = null
      ,[note12] = null
      ,[note13] = null
      ,[note14] = null
      ,[note15] = null
      ,[task01] = null
      ,[task02] = null
      ,[task03] = null
      ,[task04] = null
      ,[task05] = null
      ,[acit01] = null
      ,[acit02] = null
      ,[acit03] = null
      ,[acit04] = null
      ,[acit05] = null
      ,[tool01] = null
      ,[tool02] = null
      ,[tool03] = null
      ,[tool04] = null
      ,[tool05] = null
      ,[docn01] = null
      ,[docn02] = null
      ,[docn03] = null
      ,[docn04] = null
      ,[docn05] = null
      ,[prfx01] = 0
      ,[prfx02] = 0
      ,[prfx03] = 0
      ,[prfx04] = 0
      ,[prfx05] = 0
	  ,[rate01] = 0
	  ,[rate02] = 0
	  ,[rate03] = 0
	  ,[rate04] = 0
	  ,[rate05] = 0
	  ,[chck] = 0
      ,[chckid] = 0
      ,[chckdt] = null
	  ,[crdate] = @currDate2
      ,[crdt] = @currDate1
      ,[eddt] = @currDate1
      ,[crusid] = 1
      ,[edusid] = 1

	  set @int1 = @int1 + 1
end

--if OBJECT_ID('tempdb.dbo.#izm2','U') is not null
--drop table #izm2
--select distinct
--	   acctid
--into #izm2
--from [DATAOPB].[dbo].[UHSOMD11v]
--where [dctpid] = 1010006
--  and [tspdid] = 5
--  and yyyy = @year1
---- select * from #izm2

--if OBJECT_ID('tempdb.dbo.#izm3','U') is not null
--drop table #izm3
--select IDc
--into #izm3
--from DATAOPA.dbo.UHSACCTS
--where typeid = 1
--  and IDc not in (select * from #izm2)
---- select * from #ikm3

--if OBJECT_ID('tempdb.dbo.#izm4','U') is not null
--drop table #izm4
--select ROW_NUMBER() over(order by IDc) as Rnm
--	 , IDc
--into #izm4
--from #izm3
---- select * from #izm4


--set @int1 = 1
--set @int2 = (select max(Rnm) from #izm4)

--while (@int1 <= @int2)
--begin

--	set @int3 = (select IDc from #izm4 where Rnm = @int1)
--	set @int4 = isnull((select DISTID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)
--	set @int5 = isnull((select MGRID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)
--	set @int6 = isnull((select DODID from DATAOPA.dbo.UHSACCTS where IDc = @int3 and typeid = 1),0)

--insert into [DATAOPA].[dbo].[UHSOMD15]
--SELECT concat(@date2,'Y',@year1,'D',@int4,'A',@int3,'GR1010DC1010006')
--      ,[projid] = 13
--      ,[tskoid] = 55
--      ,[dcgrid] = 1010
--      ,[dctpid]	= 1010006
--      ,[tspdid] = 5
--      ,[distid] = @int4
--      ,[acctid] = @int3
--      ,[userid] = @int5 -- OM-H
--      ,[dimgid] = @int6 -- DOD
--	  ,[smid111] = 0
--      ,[cmdt111] = null
--      ,[verf111] = 0
--      ,[smid112] = 0
--      ,[cmdt112] = null
--      ,[verf112] = 0
--      ,[smid113] = 0
--      ,[cmdt113] = null
--      ,[verf113] = 0
--      ,[smid114] = 0
--      ,[cmdt114] = null
--      ,[verf114] = 0
--      ,[smid115] = 0
--      ,[cmdt115] = null
--      ,[verf115] = 0
--      ,[smid116] = 0
--      ,[cmdt116] = null
--      ,[verf116] = 0
--      ,[smid117] = 0
--      ,[cmdt117] = null
--      ,[verf117] = 0
--      ,[smid118] = 0
--      ,[cmdt118] = null
--      ,[verf118] = 0
--      ,[smid119] = 0
--      ,[cmdt119] = null
--      ,[verf119] = 0
--      ,[smid120] = 0
--      ,[cmdt120] = null
--      ,[verf120] = 0
--      ,[smid121] = 0
--      ,[cmdt121] = null
--      ,[verf121] = 0
--      ,[smid122] = 0
--      ,[cmdt122] = null
--      ,[verf122] = 0
--      ,[smid123] = 0
--      ,[cmdt123] = null
--      ,[verf123] = 0
--      ,[smid124] = 0
--      ,[cmdt124] = null
--      ,[verf124] = 0
--      ,[smid125] = 0
--      ,[cmdt125] = null
--      ,[verf125] = 0
--      ,[note01] = null
--      ,[note02] = null
--      ,[note03] = null
--      ,[note04] = null
--      ,[note05] = null
--      ,[note06] = null
--      ,[note07] = null
--      ,[note08] = null
--      ,[note09] = null
--      ,[note10] = null
--      ,[note11] = null
--      ,[note12] = null
--      ,[note13] = null
--      ,[note14] = null
--      ,[note15] = null
--      ,[task01] = null
--      ,[task02] = null
--      ,[task03] = null
--      ,[task04] = null
--      ,[task05] = null
--      ,[acit01] = null
--      ,[acit02] = null
--      ,[acit03] = null
--      ,[acit04] = null
--      ,[acit05] = null
--      ,[tool01] = null
--      ,[tool02] = null
--      ,[tool03] = null
--      ,[tool04] = null
--      ,[tool05] = null
--      ,[docn01] = null
--      ,[docn02] = null
--      ,[docn03] = null
--      ,[docn04] = null
--      ,[docn05] = null
--      ,[prfx01] = 0
--      ,[prfx02] = 0
--      ,[prfx03] = 0
--      ,[prfx04] = 0
--      ,[prfx05] = 0
--	  ,[rate01] = 0
--	  ,[rate02] = 0
--	  ,[rate03] = 0
--	  ,[rate04] = 0
--	  ,[rate05] = 0
--	  ,[chck] = 0
--      ,[chckid] = 0
--      ,[chckdt] = null
--	  ,[crdate] = @currDate2
--      ,[crdt] = @currDate1
--      ,[eddt] = @currDate1
--      ,[crusid] = 1
--      ,[edusid] = 1

--	  set @int1 = @int1 + 1
--end

--************************************************************************************************************************************************
--************************************************************************************************************************************************
--* 1010008 *--* District OM-D Document *--
--************************************************************************************************************************************************

if OBJECT_ID('tempdb.dbo.#kdg11','U') is not null
drop table #kdg11
select distinct
	   distid
into #kdg11
from [DATAOPB].[dbo].[UHSOMD11v]
where [dctpid] = 1010008
  and [tspdid] = 1
  and [yyyymmdd] = @date2
-- select * from #kdg11
-- select * from [DATAOPB].[dbo].[UHSOMD11v]

if OBJECT_ID('tempdb.dbo.#kds11','U') is not null
drop table #kds11
select ID
into #kds11
from DATAOPA.dbo.DISTRICTS
where ID not in (select * from #kdg11)
-- select * from #kds11

if OBJECT_ID('tempdb.dbo.#kds31','U') is not null
drop table #kds31
select ROW_NUMBER() over(order by ID) as Rnm
	 , ID
into #kds31
from #kds11
-- select * from #kds31

set @int1 = 1
set @int2 = (select max(Rnm) from #kds31)

while (@int1 <= @int2)
begin

set @int3 = (select ID from #kds31 where Rnm = @int1)
set @int5 = isnull((select OMDID from DATAOPA.dbo.DISTRICTS where ID = @int3),0)
set @int6 = isnull((select DODID from DATAOPA.dbo.DISTRICTS where ID = @int3),0)
--print 'test';
insert into [DATAOPA].[dbo].[UHSOMD11]
SELECT concat(@date2,'D',@int3,'A0GR1010DC1010008')
      ,[projid] = 13
      ,[tskoid] = 53
      ,[dcgrid] = 1010
      ,[dctpid]	= 1010008
      ,[tspdid] = 1
      ,[distid] = @int3
      ,[acctid] = 0
      ,[userid] = @int5 -- OM-D
      ,[dimgid] = @int6 -- DOD
	  ,[smid111] = 0
      ,[cmdt111] = null
      ,[verf111] = 0
      ,[smid112] = 0
      ,[cmdt112] = null
      ,[verf112] = 0
      ,[smid113] = 0
      ,[cmdt113] = null
      ,[verf113] = 0
      ,[smid114] = 0
      ,[cmdt114] = null
      ,[verf114] = 0
      ,[smid115] = 0
      ,[cmdt115] = null
      ,[verf115] = 0
      ,[smid116] = 0
      ,[cmdt116] = null
      ,[verf116] = 0
      ,[smid117] = 0
      ,[cmdt117] = null
      ,[verf117] = 0
      ,[smid118] = 0
      ,[cmdt118] = null
      ,[verf118] = 0
      ,[smid119] = 0
      ,[cmdt119] = null
      ,[verf119] = 0
      ,[smid120] = 0
      ,[cmdt120] = null
      ,[verf120] = 0
      ,[smid121] = 0
      ,[cmdt121] = null
      ,[verf121] = 0
      ,[smid122] = 0
      ,[cmdt122] = null
      ,[verf122] = 0
      ,[smid123] = 0
      ,[cmdt123] = null
      ,[verf123] = 0
      ,[smid124] = 0
      ,[cmdt124] = null
      ,[verf124] = 0
      ,[smid125] = 0
      ,[cmdt125] = null
      ,[verf125] = 0
      ,[note01] = null
      ,[note02] = null
      ,[note03] = null
      ,[note04] = null
      ,[note05] = null
      ,[note06] = null
      ,[note07] = null
      ,[note08] = null
      ,[note09] = null
      ,[note10] = null
      ,[note11] = null
      ,[note12] = null
      ,[note13] = null
      ,[note14] = null
      ,[note15] = null
      ,[task01] = null
      ,[task02] = null
      ,[task03] = null
      ,[task04] = null
      ,[task05] = null
      ,[acit01] = null
      ,[acit02] = null
      ,[acit03] = null
      ,[acit04] = null
      ,[acit05] = null
      ,[tool01] = null
      ,[tool02] = null
      ,[tool03] = null
      ,[tool04] = null
      ,[tool05] = null
      ,[docn01] = null
      ,[docn02] = null
      ,[docn03] = null
      ,[docn04] = null
      ,[docn05] = null
      ,[prfx01] = 0
      ,[prfx02] = 0
      ,[prfx03] = 0
      ,[prfx04] = 0
      ,[prfx05] = 0
	  ,[rate01] = 0
	  ,[rate02] = 0
	  ,[rate03] = 0
	  ,[rate04] = 0
	  ,[rate05] = 0
	  ,[chck] = 0
      ,[chckid] = 0
      ,[chckdt] = null
	  ,[crdate] = @currDate2
      ,[crdt] = @currDate1
      ,[eddt] = @currDate1
      ,[crusid] = 1
      ,[edusid] = 1

	  --print 'test';
	  set @int1 = @int1 + 1
end


if OBJECT_ID('tempdb.dbo.#krs2','U') is not null
drop table #krs2
select distinct
	   distid
into #krs2
from [DATAOPB].[dbo].[UHSOMD11v]
where [dctpid] = 1010008
  and [tspdid] = 2
  and yyyymm = @per1
  and weeknr = @week1
-- select * from #krs2



if OBJECT_ID('tempdb.dbo.#krs1','U') is not null
drop table #krs1
select ID
into #krs1
from DATAOPA.dbo.DISTRICTS
where ID not in (select * from #krs2)
-- select * from #krs1

if OBJECT_ID('tempdb.dbo.#krs3','U') is not null
drop table #krs3
select ROW_NUMBER() over(order by ID) as Rnm
	 , ID
into #krs3
from #krs1
-- select * from #krs3


set @int1 = 1
set @int2 = (select max(Rnm) from #krs3)

while (@int1 <= @int2)
begin

set @int3 = (select ID from #krs3 where Rnm = @int1)
set @int5 = isnull((select OMDID from DATAOPA.dbo.DISTRICTS where ID = @int3),0)
set @int6 = isnull((select DODID from DATAOPA.dbo.DISTRICTS where ID = @int3),0)

insert into [DATAOPA].[dbo].[UHSOMD12]
SELECT concat(@date2,@week2,'D',@int3,'A0GR1010DC1010008')
      ,[projid] = 13
      ,[tskoid] = 53
      ,[dcgrid] = 1010
      ,[dctpid]	= 1010008
      ,[tspdid] = 2
      ,[distid] = @int3
      ,[acctid] = 0
      ,[userid] = @int5 -- OM-D
      ,[dimgid] = @int6 -- DOD
	  ,[smid111] = 0
      ,[cmdt111] = null
      ,[verf111] = 0
      ,[smid112] = 0
      ,[cmdt112] = null
      ,[verf112] = 0
      ,[smid113] = 0
      ,[cmdt113] = null
      ,[verf113] = 0
      ,[smid114] = 0
      ,[cmdt114] = null
      ,[verf114] = 0
      ,[smid115] = 0
      ,[cmdt115] = null
      ,[verf115] = 0
      ,[smid116] = 0
      ,[cmdt116] = null
      ,[verf116] = 0
      ,[smid117] = 0
      ,[cmdt117] = null
      ,[verf117] = 0
      ,[smid118] = 0
      ,[cmdt118] = null
      ,[verf118] = 0
      ,[smid119] = 0
      ,[cmdt119] = null
      ,[verf119] = 0
      ,[smid120] = 0
      ,[cmdt120] = null
      ,[verf120] = 0
      ,[smid121] = 0
      ,[cmdt121] = null
      ,[verf121] = 0
      ,[smid122] = 0
      ,[cmdt122] = null
      ,[verf122] = 0
      ,[smid123] = 0
      ,[cmdt123] = null
      ,[verf123] = 0
      ,[smid124] = 0
      ,[cmdt124] = null
      ,[verf124] = 0
      ,[smid125] = 0
      ,[cmdt125] = null
      ,[verf125] = 0
      ,[note01] = null
      ,[note02] = null
      ,[note03] = null
      ,[note04] = null
      ,[note05] = null
      ,[note06] = null
      ,[note07] = null
      ,[note08] = null
      ,[note09] = null
      ,[note10] = null
      ,[note11] = null
      ,[note12] = null
      ,[note13] = null
      ,[note14] = null
      ,[note15] = null
      ,[task01] = null
      ,[task02] = null
      ,[task03] = null
      ,[task04] = null
      ,[task05] = null
      ,[acit01] = null
      ,[acit02] = null
      ,[acit03] = null
      ,[acit04] = null
      ,[acit05] = null
      ,[tool01] = null
      ,[tool02] = null
      ,[tool03] = null
      ,[tool04] = null
      ,[tool05] = null
      ,[docn01] = null
      ,[docn02] = null
      ,[docn03] = null
      ,[docn04] = null
      ,[docn05] = null
      ,[prfx01] = 0
      ,[prfx02] = 0
      ,[prfx03] = 0
      ,[prfx04] = 0
      ,[prfx05] = 0
	  ,[rate01] = 0
	  ,[rate02] = 0
	  ,[rate03] = 0
	  ,[rate04] = 0
	  ,[rate05] = 0
	  ,[chck] = 0
      ,[chckid] = 0
      ,[chckdt] = null
	  ,[crdate] = @currDate2
      ,[crdt] = @currDate1
      ,[eddt] = @currDate1
      ,[crusid] = 1
      ,[edusid] = 1

	  set @int1 = @int1 + 1
end

if OBJECT_ID('tempdb.dbo.#urs2','U') is not null
drop table #urs2
select distinct
	   distid
into #urs2
from [DATAOPB].[dbo].[UHSOMD11v]
where [dctpid] = 1010008
  and [tspdid] = 3
  and yyyymm = @per1
-- select * from #urs2

if OBJECT_ID('tempdb.dbo.#urs1','U') is not null
drop table #urs1
select ID
into #urs1
from DATAOPA.dbo.DISTRICTS
where ID not in (select * from #urs2)
-- select * from #urs1

if OBJECT_ID('tempdb.dbo.#urs3','U') is not null
drop table #urs3
select ROW_NUMBER() over(order by ID) as Rnm
	 , ID
into #urs3
from #urs1
-- select * from #urs3


set @int1 = 1
set @int2 = (select max(Rnm) from #urs3)


while (@int1 <= @int2)
begin

set @int3 = (select ID from #urs3 where Rnm = @int1)
set @int5 = isnull((select OMDID from DATAOPA.dbo.DISTRICTS where ID = @int3),0)
set @int6 = isnull((select DODID from DATAOPA.dbo.DISTRICTS where ID = @int3),0)

insert into [DATAOPA].[dbo].[UHSOMD13]
SELECT concat(@date2,'P',@per1,'D',@int3,'A0GR1010DC1010008')
      ,[projid] = 13
      ,[tskoid] = 53
      ,[dcgrid] = 1010
      ,[dctpid]	= 1010008
      ,[tspdid] = 3
      ,[distid] = @int3
      ,[acctid] = 0
      ,[userid] = @int5 -- OM-D
      ,[dimgid] = @int6 -- DOD
	  ,[smid111] = 0
      ,[cmdt111] = null
      ,[verf111] = 0
      ,[smid112] = 0
      ,[cmdt112] = null
      ,[verf112] = 0
      ,[smid113] = 0
      ,[cmdt113] = null
      ,[verf113] = 0
      ,[smid114] = 0
      ,[cmdt114] = null
      ,[verf114] = 0
      ,[smid115] = 0
      ,[cmdt115] = null
      ,[verf115] = 0
      ,[smid116] = 0
      ,[cmdt116] = null
      ,[verf116] = 0
      ,[smid117] = 0
      ,[cmdt117] = null
      ,[verf117] = 0
      ,[smid118] = 0
      ,[cmdt118] = null
      ,[verf118] = 0
      ,[smid119] = 0
      ,[cmdt119] = null
      ,[verf119] = 0
      ,[smid120] = 0
      ,[cmdt120] = null
      ,[verf120] = 0
      ,[smid121] = 0
      ,[cmdt121] = null
      ,[verf121] = 0
      ,[smid122] = 0
      ,[cmdt122] = null
      ,[verf122] = 0
      ,[smid123] = 0
      ,[cmdt123] = null
      ,[verf123] = 0
      ,[smid124] = 0
      ,[cmdt124] = null
      ,[verf124] = 0
      ,[smid125] = 0
      ,[cmdt125] = null
      ,[verf125] = 0
      ,[note01] = null
      ,[note02] = null
      ,[note03] = null
      ,[note04] = null
      ,[note05] = null
      ,[note06] = null
      ,[note07] = null
      ,[note08] = null
      ,[note09] = null
      ,[note10] = null
      ,[note11] = null
      ,[note12] = null
      ,[note13] = null
      ,[note14] = null
      ,[note15] = null
      ,[task01] = null
      ,[task02] = null
      ,[task03] = null
      ,[task04] = null
      ,[task05] = null
      ,[acit01] = null
      ,[acit02] = null
      ,[acit03] = null
      ,[acit04] = null
      ,[acit05] = null
      ,[tool01] = null
      ,[tool02] = null
      ,[tool03] = null
      ,[tool04] = null
      ,[tool05] = null
      ,[docn01] = null
      ,[docn02] = null
      ,[docn03] = null
      ,[docn04] = null
      ,[docn05] = null
      ,[prfx01] = 0
      ,[prfx02] = 0
      ,[prfx03] = 0
      ,[prfx04] = 0
      ,[prfx05] = 0
	  ,[rate01] = 0
	  ,[rate02] = 0
	  ,[rate03] = 0
	  ,[rate04] = 0
	  ,[rate05] = 0
	  ,[chck] = 0
      ,[chckid] = 0
      ,[chckdt] = null
	  ,[crdate] = @currDate2
      ,[crdt] = @currDate1
      ,[eddt] = @currDate1
      ,[crusid] = 1
      ,[edusid] = 1

	  set @int1 = @int1 + 1
end

-- delete from [DATAOPA].[dbo].[UHSGWL01]

-- delete from [DATAOPA].[dbo].[UHSOMD11]
-- delete from [DATAOPA].[dbo].[UHSOMD12]
-- delete from [DATAOPA].[dbo].[UHSOMD13]
-- delete from [DATAOPA].[dbo].[UHSOMD14]
-- delete from [DATAOPA].[dbo].[UHSOMD15]

-- delete from [DATAOPB].[dbo].[UHSOMD11v]