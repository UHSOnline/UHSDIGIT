namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSACCTStmp")]
    public partial class UHSACCTStmpDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public int IDc { get; set; }
        public string REG { get; set; }
        public string DIV { get; set; }
        public string DIST { get; set; }
        public int DISTID { get; set; }
        public string CUST { get; set; }
        public double MFO { get; set; }
        public double LAT { get; set; }
        public double LNG { get; set; }
        public int MGRID { get; set; }
        public string MGR { get; set; }
        public string MGREM { get; set; }
        public int ARID { get; set; }
        public string ARNM { get; set; }
        public string AREM { get; set; }
        public string ADDR { get; set; }
        public string CITY { get; set; }
        public string STAT { get; set; }
        public string PHON { get; set; }
        public string ACTP { get; set; }
        public int typeid { get; set; }
        public string typedesc { get; set; }
        public string CSTNM { get; set; }
        public int DODID { get; set; }
        public string DOD { get; set; }
        public string DODEM { get; set; }
        public int OMDID { get; set; }
        public string OMD { get; set; }
        public string OMDEM { get; set; }
        public int wchk { get; set; }
        public DateTime crdt { get; set; }
        public int utco { get; set; }
    }
}
