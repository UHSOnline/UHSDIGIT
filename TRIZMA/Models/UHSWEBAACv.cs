namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSWEBAACv")]
    public partial class UHSWEBAACvDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string dist { get; set; }
        public int divID { get; set; }
        public string divNm { get; set; }
        public int regID { get; set; }
        public string region { get; set; }
        public string disPh { get; set; }
        public double aclng { get; set; }
        public double aclat { get; set; }
        public string OMD { get; set; }
        public string DOD { get; set; }
        public string dateDT { get; set; }
        public string dtby1 { get; set; }
        public string dtby2 { get; set; }
        public string dtby3 { get; set; }
        public string dtby4 { get; set; }
        public int omdch1 { get; set; }
        public int omdch2 { get; set; }
        public int omdch3 { get; set; }
        public int omdch4 { get; set; }
        public int wchk { get; set; }
        public int utco { get; set; }
    }
}
