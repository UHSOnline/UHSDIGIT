namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SSCYCCNTM1v")]
    public partial class SSCYCCNTM1vDb
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
        public string DistrictName { get; set; }
        public string comboDistrict { get; set; }
        public string wareHouse { get; set; }
        public int ITSTNO { get; set; }
        public string productCode { get; set; }
        public string prodDesc { get; set; }
        public string primUM { get; set; }
        public int PrimQty { get; set; }
        public string secUM { get; set; }
        public int SecQty { get; set; }
        public double cost { get; set; }
        public int packingFactor { get; set; }
        public double AvgPrice { get; set; }
        public int actQtyPUM { get; set; }
        public int actQtySUM { get; set; }
        public string tb01 { get; set; }
        public string tb02 { get; set; }
        public string crdate { get; set; }
        public int crymd { get; set; }
        public int cryymm { get; set; }
        public DateTime crdt { get; set; }
        public DateTime eddt { get; set; }
        public int crusid { get; set; }
        public int edusid { get; set; }
        public string comboName { get; set; }
        public int totLowQty { get; set; }
        public string tb03 { get; set; }
        public string tb04 { get; set; }
        public string tb05 { get; set; }
        public string tb06 { get; set; }
        public string tb07 { get; set; }
        public string tb08 { get; set; }
        public string tb09 { get; set; }
        public string tb10 { get; set; }
        public int newArt { get; set; }
        public int upCnt { get; set; }
        public bool lckdc { get; set; }
        
    }
}
