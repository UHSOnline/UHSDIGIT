namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSWOT01")]
    public partial class UHSWOT01Db
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public int projid { get; set; }
        public int tskoid { get; set; }
        public int dcgrid { get; set; }
        public int dctpid { get; set; }
        public int tspdid { get; set; }
        public int distid { get; set; }
        public int acctid { get; set; }
        public int userid { get; set; }
        public int dimgid { get; set; }
        public string docmid { get; set; }
        public int L3ID { get; set; }
        public string project { get; set; }
        public string problem { get; set; }
        public string oprmngr { get; set; }
        public string kznlead { get; set; }
        public string teammbr { get; set; }
        public string scpobjc { get; set; }
        public string objectv { get; set; }
        public string scopein { get; set; }
        public string scopeot { get; set; }
        public string statecr { get; set; }
        public string stateft { get; set; }
        public string commres { get; set; }
        public bool compld { get; set; }
        public int compid { get; set; }
        public string datest { get; set; }
        public string dateex { get; set; }
        public string dateed { get; set; }
        public double avgsucce { get; set; }
        public bool chck { get; set; }
        public int chckid { get; set; }
        public string chckdt { get; set; }
        public string crdt { get; set; }
        public string eddt { get; set; }
        public int crusid { get; set; }
        public int edusid { get; set; }

    }
}
