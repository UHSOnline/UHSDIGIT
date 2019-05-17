namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSWEBOMD11v")]
    public partial class UHSWEBOMD11vDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDc { get; set; }
        public string REG { get; set; }
        public string DIV { get; set; }
        public string DIST { get; set; }
        public int DISTID { get; set; }
        public string CUST { get; set; }
        public string MFO { get; set; }
        public double LAT { get; set; }
        public double LNG { get; set; }
        public int MGRID { get; set; }
        public string MGR { get; set; }
        public int DODID { get; set; }
        public string DOD { get; set; }
        public int ARID { get; set; }
        public string ARNM { get; set; }
        public string ADDR { get; set; }
        public string CITY { get; set; }
        public string STAT { get; set; }
        public string PHON { get; set; }
        public string ACTP { get; set; }
        public int typeid { get; set; }
        public string typedesc { get; set; }
        public int a360dyc { get; set; }
        public string a360dyd { get; set; }
        public int a360wkc { get; set; }
        public string a360wkd { get; set; }
        public int a360prc { get; set; }
        public string a360prd { get; set; }
        public int a360qtc { get; set; }
        public string a360qtd { get; set; }
        public int a360yrc { get; set; }
        public string a360yrd { get; set; }
        public int wchk { get; set; }
        public int utco { get; set; }
    }
}
