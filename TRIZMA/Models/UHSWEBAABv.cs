namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSWEBAABv")]
    public partial class UHSWEBAABvDb
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
        public string GWLID { get; set; }
        public int GWALL { get; set; }
        public int GWDAY { get; set; }
        public int GWWEE { get; set; }
        public bool GWAPR { get; set; }
        public string S6LID { get; set; }
        public int S6ALL { get; set; }
        public int S6DAY { get; set; }
        public int S6WEE { get; set; }
        public bool S6APR { get; set; }
        public string AASID { get; set; }
        public int AAS01 { get; set; }
        public int AAS02 { get; set; }
        public int AAS03 { get; set; }
        public int AAS04 { get; set; }
        public int AAS05 { get; set; }
        public int AAS06 { get; set; }
        public int AAS07 { get; set; }
        public int AAS08 { get; set; }
        public int AASTO { get; set; }
        public string AASPC { get; set; }
        public string AAS91 { get; set; }
        public string AAS92 { get; set; }
        public string AAS93 { get; set; }
        public string AAS94 { get; set; }
        public string AAS95 { get; set; }
        public string AAS96 { get; set; }
        public string AAS97 { get; set; }
        public string AAS98 { get; set; }
        public string dtby1 { get; set; }
        public string dtby2 { get; set; }
        public string dtby3 { get; set; }
        public string dtby4 { get; set; }
        public string asdate { get; set; }
        public bool aschk { get; set; }
        public int omdch1 { get; set; }
        public int omdch2 { get; set; }
        public int omdch3 { get; set; }
        public int wchk { get; set; }
        public string TB01 { get; set; }
        public string TAB01 { get; set; }
        public string TAB02 { get; set; }
        public string TAB03 { get; set; }
        public string TAB04 { get; set; }
        public int utco { get; set; }
        public int omdch4 { get; set; }
        public string dtby5 { get; set; }
    }
}
