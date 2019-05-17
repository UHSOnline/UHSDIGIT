namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSOMD15")]
    public partial class UHSOMD15Db
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
        public int smid111 { get; set; }
        public string cmdt111 { get; set; }
        public int verf111 { get; set; }
        public int smid112 { get; set; }
        public string cmdt112 { get; set; }
        public int verf112 { get; set; }
        public int smid113 { get; set; }
        public string cmdt113 { get; set; }
        public int verf113 { get; set; }
        public int smid114 { get; set; }
        public string cmdt114 { get; set; }
        public int verf114 { get; set; }
        public int smid115 { get; set; }
        public string cmdt115 { get; set; }
        public int verf115 { get; set; }
        public int smid116 { get; set; }
        public string cmdt116 { get; set; }
        public int verf116 { get; set; }
        public int smid117 { get; set; }
        public string cmdt117 { get; set; }
        public int verf117 { get; set; }
        public int smid118 { get; set; }
        public string cmdt118 { get; set; }
        public int verf118 { get; set; }
        public int smid119 { get; set; }
        public string cmdt119 { get; set; }
        public int verf119 { get; set; }
        public int smid120 { get; set; }
        public string cmdt120 { get; set; }
        public int verf120 { get; set; }
        public int smid121 { get; set; }
        public string cmdt121 { get; set; }
        public int verf121 { get; set; }
        public int smid122 { get; set; }
        public string cmdt122 { get; set; }
        public int verf122 { get; set; }
        public int smid123 { get; set; }
        public string cmdt123 { get; set; }
        public int verf123 { get; set; }
        public int smid124 { get; set; }
        public string cmdt124 { get; set; }
        public int verf124 { get; set; }
        public int smid125 { get; set; }
        public string cmdt125 { get; set; }
        public int verf125 { get; set; }
        public string note01 { get; set; }
        public string note02 { get; set; }
        public string note03 { get; set; }
        public string note04 { get; set; }
        public string note05 { get; set; }
        public string note06 { get; set; }
        public string note07 { get; set; }
        public string note08 { get; set; }
        public string note09 { get; set; }
        public string note10 { get; set; }
        public string note11 { get; set; }
        public string note12 { get; set; }
        public string note13 { get; set; }
        public string note14 { get; set; }
        public string note15 { get; set; }
        public string task01 { get; set; }
        public string task02 { get; set; }
        public string task03 { get; set; }
        public string task04 { get; set; }
        public string task05 { get; set; }
        public string acit01 { get; set; }
        public string acit02 { get; set; }
        public string acit03 { get; set; }
        public string acit04 { get; set; }
        public string acit05 { get; set; }
        public string tool01 { get; set; }
        public string tool02 { get; set; }
        public string tool03 { get; set; }
        public string tool04 { get; set; }
        public string tool05 { get; set; }
        public string docn01 { get; set; }
        public string docn02 { get; set; }
        public string docn03 { get; set; }
        public string docn04 { get; set; }
        public string docn05 { get; set; }
        public int prfx01 { get; set; }
        public int prfx02 { get; set; }
        public int prfx03 { get; set; }
        public int prfx04 { get; set; }
        public int prfx05 { get; set; }
        public string rate01 { get; set; }
        public string rate02 { get; set; }
        public string rate03 { get; set; }
        public string rate04 { get; set; }
        public string rate05 { get; set; }
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
