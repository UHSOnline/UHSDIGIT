namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AGLINVMFC2")]
    public partial class AGLINVMFC2Db
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string ID { get; set; }
        public string extDocID { get; set; }
        public int extdcgrid { get; set; }
        public int extdctpid { get; set; }
        public int impID { get; set; }
        public int ordNo { get; set; }
        public string ManufacturerNK { get; set; }
        public string ManufacturerName { get; set; }
        public int sourceCD { get; set; }
        public string source { get; set; }
        public string Status { get; set; }
        public string ApprovedBy { get; set; }
        public string DisapprovedBy { get; set; }
    }
}
