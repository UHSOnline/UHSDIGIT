namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSWEBAVG01v")]
    public partial class UHSWEBAVG01vDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int dctpid { get; set; }
        public int acctid { get; set; }
        public string pr01 { get; set; }
        public int pc01 { get; set; }
        public string pr02 { get; set; }
        public int pc02 { get; set; }
        public string pr03 { get; set; }
        public int pc03 { get; set; }
        public string pr04 { get; set; }
        public int pc04 { get; set; }
        public string pr05 { get; set; }
        public int pc05 { get; set; }
        public string pr06 { get; set; }
        public int pc06 { get; set; }
        public string pr07 { get; set; }
        public int pc07 { get; set; }
        public string pr08 { get; set; }
        public int pc08 { get; set; }
        public string pr09 { get; set; }
        public int pc09 { get; set; }
        public string pr10 { get; set; }
        public int pc10 { get; set; }
        public string pr11 { get; set; }
        public int pc11 { get; set; }
        public string pr12 { get; set; }
        public int pc12 { get; set; }
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
        public string AOV01 { get; set; }
        public string AOV02 { get; set; }
        public string AOV03 { get; set; }
        public string AOV04 { get; set; }
        public string AOV05 { get; set; }
        public string AOV06 { get; set; }
        public string AOV07 { get; set; }
        public string AOV08 { get; set; }
        public string AOVPC { get; set; }
        public string TB01 { get; set; }
    }
}
