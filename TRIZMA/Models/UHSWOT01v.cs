namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSWOT01v")]
    public partial class UHSWOT01vDb
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
        public string distnm { get; set; }
        public string docmid { get; set; }
        public int eXprojid { get; set; }
        public int eXtskoid { get; set; }
        public int eXdcgrid { get; set; }
        public int eXdctpid { get; set; }
        public int eXtspdid { get; set; }
        public int L3ID { get; set; }
        public string L1DS { get; set; }
        public string L2DS { get; set; }
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
        public string datsen { get; set; }
        public int dsyyyy { get; set; }
        public int dsyymm { get; set; }
        public int dsyymd { get; set; }
        public int dshhms { get; set; }
        public int dswknr { get; set; }
        public string dswkds { get; set; }

        public string dateex { get; set; }
        public string datsxn { get; set; }
        public int dxyyyy { get; set; }
        public int dxyymm { get; set; }
        public int dxyymd { get; set; }
        public int dxhhms { get; set; }
        public int dxwknr { get; set; }
        public string dxwkds { get; set; }

        public string dateed { get; set; }
        public string dateen { get; set; }
        public int deyyyy { get; set; }
        public int deyymm { get; set; }
        public int deyymd { get; set; }
        public int dehhms { get; set; }
        public int dewknr { get; set; }
        public string dewkds { get; set; }
        public int tskcnt { get; set; }

        public int difdstex { get; set; }
        public int difhstex { get; set; }
        public int difdexed { get; set; }
        public int difhexed { get; set; }
        public int difdsted { get; set; }
        public int difhsted { get; set; }
        public double avgsucce { get; set; }
        public string avgsucsa { get; set; }
        public string avgsucsb { get; set; }
        public double prgsucce { get; set; }
        public string prgsucsa { get; set; }
        public string prgsucsb { get; set; }

        public int latedays { get; set; }
        public int latehour { get; set; }

        public int wekday { get; set; }
        public string wekdnm { get; set; }
        public bool chck { get; set; }
        public int chckid { get; set; }
        public string chcknm { get; set; }
        public string chckdt { get; set; }
        public int yyyy { get; set; }
        public int yyyymm { get; set; }
        public int weeknr { get; set; }
        public string weekds { get; set; }
        public int yyyymmdd { get; set; }
        public int hhmmss { get; set; }
        public string crdate { get; set; }
        public string crdt { get; set; }
        public string eddt { get; set; }
        public int crusid { get; set; }
        public int edusid { get; set; }
        public string crusnm { get; set; }
        public string edusnm { get; set; }
        public string CSTNM { get; set; }

    }
}
