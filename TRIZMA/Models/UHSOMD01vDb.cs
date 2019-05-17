namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSOMD01v")]
    public partial class UHSOMD01vDb
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
        public string distnm { get; set; }
        public int acctid { get; set; }
        public int userid { get; set; }
        public string usernm { get; set; }
        public int dimgid { get; set; }
        public string dimgnm { get; set; }
        public int smid111 { get; set; }
        public string cmdt111 { get; set; }
        public bool verf111 { get; set; }
        public int smid112 { get; set; }
        public string cmdt112 { get; set; }
        public bool verf112 { get; set; }
        public int smid113 { get; set; }
        public string cmdt113 { get; set; }
        public bool verf113 { get; set; }
        public int smid114 { get; set; }
        public string cmdt114 { get; set; }
        public bool verf114 { get; set; }
        public int smid115 { get; set; }
        public string cmdt115 { get; set; }
        public bool verf115 { get; set; }
        public int smid116 { get; set; }
        public string cmdt116 { get; set; }
        public bool verf116 { get; set; }
        public int smid117 { get; set; }
        public string cmdt117 { get; set; }
        public bool verf117 { get; set; }
        public int smid118 { get; set; }
        public string cmdt118 { get; set; }
        public bool verf118 { get; set; }
        public int smid119 { get; set; }
        public string cmdt119 { get; set; }
        public bool verf119 { get; set; }
        public int smid120 { get; set; }
        public string cmdt120 { get; set; }
        public bool verf120 { get; set; }
        public int smid121 { get; set; }
        public string cmdt121 { get; set; }
        public bool verf121 { get; set; }
        public int smid122 { get; set; }
        public string cmdt122 { get; set; }
        public bool verf122 { get; set; }
        public int smid123 { get; set; }
        public string cmdt123 { get; set; }
        public bool verf123 { get; set; }
        public int smid124 { get; set; }
        public string cmdt124 { get; set; }
        public bool verf124 { get; set; }
        public int smid125 { get; set; }
        public string cmdt125 { get; set; }
        public bool verf125 { get; set; }
        public string comm01 { get; set; }
        public string comm02 { get; set; }
        public string comm03 { get; set; }
        public string comm04 { get; set; }
        public string comm05 { get; set; }
        public string comm06 { get; set; }
        public int allchc { get; set; }
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
        public string crdt { get; set; }
        public string eddt { get; set; }
        public int crusid { get; set; }
        public int edusid { get; set; }
        public string crusnm { get; set; }
        public string edusnm { get; set; }
        public string crdate { get; set; }
    }
}
