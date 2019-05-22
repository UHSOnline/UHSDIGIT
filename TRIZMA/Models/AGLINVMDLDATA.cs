namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AGLINVMDLDATA")]
    public partial class AGLINVMDLDATADb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string ID { get; set; }
        public string extModID { get; set; }
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
        public string Device_Category { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int sourceCD { get; set; }
        public string modelNK { get; set; }
        public int modelImpID { get; set; }
        public string Q2000NK { get; set; }
        public string OASYSNK { get; set; }
        public string S2NK { get; set; }
        public string modelID1 { get; set; }
        public string modelID2 { get; set; }
        public string ModelDescription { get; set; }
        public string modelURL { get; set; }
        public string Status { get; set; }
        public string statusCD { get; set; }
        public float estimatedMinutesSM { get; set; }
        public string ManufacturerNK { get; set; }
        public int manufImpID { get; set; }
        public string manufacturerName { get; set; }
        public string equipmentTypeNK { get; set; }
        public string equipmentType { get; set; }
        public string Control_Number { get; set; }
        public string Owner_Department { get; set; }
        public string Scheduling_Department { get; set; }
        public string Serial_Number { get; set; }
        public string SN_Modified { get; set; }
        public string STATUS2 { get; set; }
        public string Column1 { get; set; }
        public string Risk_Group { get; set; }
        public string Asset_Center { get; set; }
        public bool matchSingle { get; set; }
        public bool matchMultip { get; set; }
        public bool matchConfrm { get; set; }
        public bool manualInput { get; set; }
        public int Cnt { get; set; }
        public bool chck { get; set; }
        public int chckid { get; set; }
        public string chckdt { get; set; }
        public string crdate { get; set; }
        public string crdt { get; set; }
        public string eddt { get; set; }
        public int crusid { get; set; }
        public int edusid { get; set; }
        public int impTypeID { get; set; }
        public string equipmentNK { get; set; }
        public bool checkUp { get; set; }
    }
}
