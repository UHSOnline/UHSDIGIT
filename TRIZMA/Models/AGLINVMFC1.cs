namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AGLINVMFC1")]
    public partial class AGLINVMFC1Db
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
        public string extDocID { get; set; }
        public int extdcgrid { get; set; }
        public int extdctpid { get; set; }
        public int impID { get; set; }
        public string imName { get; set; }
        public bool matchSingle { get; set; }
        public bool matchMultip { get; set; }
        public bool matchConfrm { get; set; }
        public bool manualInput { get; set; }
        public int Cnt { get; set; }
        public int sourceCD { get; set; }
        public string ManufacturerNK { get; set; }
        public string Q2000NK { get; set; }
        public string OASYSNK { get; set; }
        public string S2NK { get; set; }
        public string source { get; set; }
        public string systemCD { get; set; }
        public string isDup { get; set; }
        public string ManufacturerName { get; set; }
        public string Type { get; set; }
        public string HoursOfOperation { get; set; }
        public string Status { get; set; }
        public string Alias { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip9 { get; set; }
        public string Country { get; set; }
        public string URL { get; set; }
        public string AddressComments { get; set; }
        public string ApprovedDT { get; set; }
        public string ApprovedStatus { get; set; }
        public string ApprovedBy { get; set; }
        public string DisapprovedDT { get; set; }
        public string DisapprovedReason { get; set; }
        public string DisapprovedBy { get; set; }
        public string CreatedDT { get; set; }
        public string CreatedBy { get; set; }
        public string Comments { get; set; }
        public bool chck { get; set; }
        public int chckid { get; set; }
        public string chckdt { get; set; }
        public string crdate { get; set; }
        public string crdt { get; set; }
        public string eddt { get; set; }
        public int crusid { get; set; }
        public int edusid { get; set; }
    }
}
