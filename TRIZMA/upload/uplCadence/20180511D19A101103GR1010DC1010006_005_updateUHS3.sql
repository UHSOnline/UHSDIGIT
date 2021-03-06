/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [accountID] as ID
      ,[region] as REG
      ,[DivisionName] as DIV
      ,[District] as DIST
      ,[districtID] as DISTID
      ,[customerName] as CUST
      ,[milesFromOffice] as MFO
      ,[accountLatitude] as LAT
      ,[accountLongitude] as LNG
      ,[acctMgrID] as MGRID
      ,[arID] as ARID
      ,[arName] as ARNM
      ,[ShipToAddr1] as ADDR
      ,[ShipToCity] as CITY
      ,[ShipToState] AS STAT
      ,[shipToPhone] AS PHON
      ,[accountType] AS ACTP
  INTO DATAOPA.dbo.UHSACCTS
  FROM [DATAOPB].[dbo].[b360accounts]
  where [accountLatitude] is not null
    and [accountLatitude] != 0
-- select * from DATAOPA.dbo.UHSACCTS

--alter table DATAOPA.dbo.UHSACCTS
--alter column ID INT NOT NULL

--alter table DATAOPA.dbo.UHSACCTS
--add primary key(ID)