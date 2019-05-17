namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vChartCMScount1")]
    public partial class vChartCMScount1Db
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int ID { get; set; }
        public string dateDT { get; set; }
        public string starttime { get; set; }
        public int split { get; set; }
        public string splitName { get; set; }
        public string logid { get; set; }
        public int agentsID { get; set; }
        public double acdcallsNum { get; set; }
        public double outboundcallsNum { get; set; }
        public double acdtimeAvg { get; set; }
        public double outboundtimeAvg { get; set; }
        public int YYYYMM { get; set; }
        public int YYYY { get; set; }
        public int MonthNbr { get; set; }
        public string WeekNbr { get; set; }
        public int auxoutSec { get; set; }
        public string skillNameCMS { get; set; }
        public string TaskOrder { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public int nameID { get; set; }
        public int skillNameID { get; set; }
        public int taskOrderID { get; set; }
        public int countryID { get; set; }
        public int languageID { get; set; }

    }
}
