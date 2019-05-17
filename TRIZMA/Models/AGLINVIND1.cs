namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AGLINVIND1")]
    public partial class AGLINVIND1Db
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string ID { get; set; }
        public int acctid { get; set; }
        public string acctName { get; set; }
        public string acctAddress { get; set; }
        public string acctHours { get; set; }
        public string acctPhone { get; set; }
        public string acctImage { get; set; }
        public string docDate { get; set; }
        public string crtDate { get; set; }
        public int manTot { get; set; }
        public int manSng { get; set; }
        public double manSngP { get; set; }
        public string manSngH { get; set; }
        public int manMlt { get; set; }
        public double manMltP { get; set; }
        public string manMltH { get; set; }
        public int manNew { get; set; }
        public double manNewP { get; set; }
        public string manNewH { get; set; }
        public int manMacConf { get; set; }
        public int modTot { get; set; }
        public int modSng { get; set; }
        public double modSngP { get; set; }
        public string modSngH { get; set; }
        public int modMlt { get; set; }
        public double modMltP { get; set; }
        public string modMltH { get; set; }
        public int modNew { get; set; }
        public double modNewP { get; set; }
        public string modNewH { get; set; }
        public int modMacConf { get; set; }
    }
}
