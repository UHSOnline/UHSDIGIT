namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSOMD13")]
    public partial class UHSOMD13Db
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
        public int smid126 { get; set; }
        public string cmdt126 { get; set; }
        public int verf126 { get; set; }
        public int smid127 { get; set; }
        public string cmdt127 { get; set; }
        public int verf127 { get; set; }
        public int smid128 { get; set; }
        public string cmdt128 { get; set; }
        public int verf128 { get; set; }
        public int smid129 { get; set; }
        public string cmdt129 { get; set; }
        public int verf129 { get; set; }
        public int smid130 { get; set; }
        public string cmdt130 { get; set; }
        public int verf130 { get; set; }
        public int smid131 { get; set; }
        public string cmdt131 { get; set; }
        public int verf131 { get; set; }
        public int smid132 { get; set; }
        public string cmdt132 { get; set; }
        public int verf132 { get; set; }
        public int smid133 { get; set; }
        public string cmdt133 { get; set; }
        public int verf133 { get; set; }
        public int smid134 { get; set; }
        public string cmdt134 { get; set; }
        public int verf134 { get; set; }
        public int smid135 { get; set; }
        public string cmdt135 { get; set; }
        public int verf135 { get; set; }
        public string note26 { get; set; }
        public string note27 { get; set; }
        public string note28 { get; set; }
        public string note29 { get; set; }
        public string note30 { get; set; }
        public string note31 { get; set; }
        public string note32 { get; set; }
        public string note33 { get; set; }
        public string note34 { get; set; }
        public string note35 { get; set; }

    }
}
