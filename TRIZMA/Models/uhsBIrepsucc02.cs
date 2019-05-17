namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("uhsBIrepsucc02")]
    public partial class uhsBIrepsucc02Db
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int dctpid { get; set; }
        public int acctid { get; set; }
        public int distid { get; set; }
        public string crdate { get; set; }
        public int wchk { get; set; }
        public int crPeriod { get; set; }
        public int c1 { get; set; }
        public int c2 { get; set; }
        public int c3 { get; set; }
        public int c4 { get; set; }
        public int c5 { get; set; }
        public int c6 { get; set; }
        public int c7 { get; set; }
        public string comboDistrict { get; set; }
        public int divID { get; set; }
        public string divisionName { get; set; }
        public int regID { get; set; }
        public string region { get; set; }
        public string customerName { get; set; }
        public string comboName { get; set; }
        public string TB01 { get; set; }
        public string TB02 { get; set; }
        public string TB03 { get; set; }
    }
}
