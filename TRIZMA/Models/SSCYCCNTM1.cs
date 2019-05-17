namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SSCYCCNTM1")]
    public partial class SSCYCCNTM1Db
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public int linnr { get; set; }
        public string IDc { get; set; }
        public int projid { get; set; }
        public int tskoid { get; set; }
        public int dcgrid { get; set; }
        public int dctpid { get; set; }
        public int tspdid { get; set; }
        public int DistID { get; set; }
        public int acctid { get; set; }
        public int userid { get; set; }
        public int dimgid { get; set; }
        public string wareHouse { get; set; }
        public int ITSTNO { get; set; }
        public int PrimQty { get; set; }
        public int SecQty { get; set; }
        public double cost { get; set; }
        public int packingFactor { get; set; }
        public double AvgPrice { get; set; }
        public int actQtyPUM { get; set; }
        public int actQtySUM { get; set; }
        public DateTime crdt { get; set; }
        public DateTime eddt { get; set; }
        public int crusid { get; set; }
        public int edusid { get; set; }
        public int newArt { get; set; }
        public int upCnt { get; set; }
        public bool lckdc { get; set; }
        
    }
}
