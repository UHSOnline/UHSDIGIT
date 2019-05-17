namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSbwDates1")]
    public partial class UHSbwDates1Db
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int YYYY { get; set; }
        public string dateus { get; set; }
        public int dateYMDe { get; set; }
        public string dateID { get; set; }
        public int dateYMD { get; set; }
        public int dateYMD2 { get; set; }
        public string dateYMDwchk2 { get; set; }
        public int dateYMDwchk2b { get; set; }
        public string dateYMDwchk2c { get; set; }
        public string dateYMDwchk1 { get; set; }
        public int dateYMDwchk1b { get; set; }
        public string dateYMDwchk1c { get; set; }
        public int Rnm { get; set; }
        public string dateYMDwchk0 { get; set; }
        public int dateYMDwchk0b { get; set; }
        public string dateYMDwchk0c { get; set; }
    }
}
