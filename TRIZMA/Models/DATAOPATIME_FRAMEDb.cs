namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TIME_FRAME")]
    public partial class DATAOPATIME_FRAMEDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int      ID { get; set; }
        public string   dimDateNK { get; set; }
        public string   dateID { get; set; }
        public string   date2 { get; set; }
        public int      dateYMD { get; set; }
        public int      YYYYMM { get; set; }
        public int      YYYY { get; set; }
        public int   Quarter { get; set; }
        public string   QuarterExc { get; set; }
        public string   YearQuarter { get; set; }
        public int      MonthNbr { get; set; }
        public int      MonthNbrExc { get; set; }
        public string   MonthNbrName { get; set; }
        public string   MonthName { get; set; }
        public string   YearMonth { get; set; }
        public int      DaysInMonth { get; set; }
        public string   MStartDT { get; set; }
        public string   MEndDT { get; set; }
        public string   MStartDate { get; set; }
        public string   MEndDate { get; set; }
        public int      MStartYYYYMM { get; set; }
        public int      MEndYYYYMM { get; set; }
        public string   WeekNbr { get; set; }
        public int      WNumber { get; set; }
        public string   WStartDT { get; set; }
        public string   WEndDT { get; set; }
        public string   wks1 { get; set; }
        public string   wks2 { get; set; }
        public string   wks3 { get; set; }
        public string   wke1 { get; set; }
        public string   wke2 { get; set; }
        public string   wke3 { get; set; }
        public string   weekDesc { get; set; }
        public string   DayName { get; set; }
        public string   DNmShort { get; set; }
        public string   DayType { get; set; }
        public string   isHoliday { get; set; }
        public string   DayTypeExc { get; set; }
        public string   Dan { get; set; }
        public string   DanShort { get; set; }
        public int daywnm { get; set; }
        public int wstymd { get; set; }
        public string dateus { get; set; }
    }
}
