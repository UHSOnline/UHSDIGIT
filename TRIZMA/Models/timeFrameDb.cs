namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("timeFrame")]
    public partial class timeFrameDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string dimDateSKID    { get; set; }
        public string dimDateNK      { get; set; }
        public string dateID         { get; set; }
        public int    dateYMD        { get; set; }
        public int    YYYYMM         { get; set; }
        public int    YYYY           { get; set; }
        public string    Quarter        { get; set; }
        public string QuarterExc     { get; set; }
        public string MonthNbr       { get; set; }
        public string MonthNbrName   { get; set; }
        public string MonthName      { get; set; }
        public string DayName        { get; set; }
        public string DayType        { get; set; }
        public string Dan            { get; set; }
        public string DanShort       { get; set; }
        public string WStartDate    { get; set; }
    }
}
