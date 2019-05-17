namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSinquries")]
    public partial class UHSinquriesDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int ID { get; set; }
        public int projid { get; set; }
        public int tskoid { get; set; }
        public int dcgrid { get; set; }
        public int dctpid { get; set; }
        public int tspdid { get; set; }
        public int L1ID { get; set; }
        public string L1DS { get; set; }
        public int L2ID { get; set; }
        public string L2DS { get; set; }
        public string L3DS { get; set; }
        public string TID01 { get; set; }
        public string TID02 { get; set; }
        public string TID03 { get; set; }
        public string taskOrder { get; set; }
    }
}
