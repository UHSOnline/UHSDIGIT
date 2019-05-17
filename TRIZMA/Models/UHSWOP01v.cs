namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSWOP01v")]
    public partial class UHSWOP01vDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public string IDT { get; set; }
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
        public int L3ID { get; set; }
        public string stepnm { get; set; }
        public string stepds { get; set; }
        public string datest { get; set; }
        public int dsyyyy { get; set; }
        public int dsyymm { get; set; }
        public int dsyymd { get; set; }
        public int dshhms { get; set; }
        public int dswknr { get; set; }
        public string dswkds { get; set; }
        public string dateex { get; set; }
        public int dxyyyy { get; set; }
        public int dxyymm { get; set; }
        public int dxyymd { get; set; }
        public int dxhhms { get; set; }
        public int dxwknr { get; set; }
        public string dxwkds { get; set; }
        public string assgto { get; set; }
        public int wrkhrs { get; set; }
        public int wrkmin { get; set; }
        public int expdol { get; set; }
        public int expcnt { get; set; }
        public bool priohg { get; set; }
        public bool compld { get; set; }
        public int compid { get; set; }
        public string dateed { get; set; }
        public int deyyyy { get; set; }
        public int deyymm { get; set; }
        public int deyymd { get; set; }
        public int dehhms { get; set; }
        public int dewknr { get; set; }
        public string dewkds { get; set; }

        public int difdstex { get; set; }
        public int difhstex { get; set; }
        public int difdexed { get; set; }
        public int difhexed { get; set; }
        public int difdsted { get; set; }
        public int difhsted { get; set; }
        public int succes { get; set; }


        public double timsucce { get; set; }
        public string timsucsa { get; set; }
        public string timsucsb { get; set; }

        public int latedays { get; set; }
        public int latehour { get; set; }

        public bool incUnit { get; set; }
        public bool incPart { get; set; }
        public bool incModule { get; set; }
        public bool incTool { get; set; }
        public bool incMaterial { get; set; }
        public bool incAccess { get; set; }
        public bool incData { get; set; }
        public bool incDocument { get; set; }
        public bool incReport { get; set; }
        public bool incSME { get; set; }
        public bool incStuff { get; set; }
        public bool incTime { get; set; }
        public bool incMoney { get; set; }
        public bool incSetup { get; set; }
        public bool incMisusage { get; set; }
        public bool incVehicle { get; set; }
        public bool incOther { get; set; }
        public string incOthDs { get; set; }
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
        //public string dbdt { get; set; }
        
    }
}
