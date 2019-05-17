namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AGLINVMDL2")]
    public partial class AGLINVMDL2Db
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string ID { get; set; }
        public string extDocID { get; set; }
        public int extdcgrid { get; set; }
        public int extdctpid { get; set; }
        public int impID { get; set; }
        public int ordNo { get; set; }
        public string modelNK { get; set; }
        public string ModelDescription { get; set; }
        public string modelID1 { get; set; }
        public string equipmentTypeNK { get; set; }
        public string equipmentTypeDescr { get; set; }
        public string manufacturerNK { get; set; }
        public string ManufacturerName { get; set; }
        public int Cnt { get; set; }
        public string dpDesc { get; set; }
    }
}
