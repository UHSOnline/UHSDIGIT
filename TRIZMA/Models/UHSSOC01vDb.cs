namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSSOC01v")]
    public partial class UHSSOC01vDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string ID { get; set; }
        public string IDT { get; set; }
        public string IDK { get; set; }
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
        public int docmid { get; set; }
        public string L1DS { get; set; }
        public string acctnm { get; set; }
        public bool ispubl { get; set; }
        public bool isrepl { get; set; }
        public bool isrere { get; set; }
        public bool isread { get; set; }
        public bool islike { get; set; }
        public bool isrepo { get; set; }
        public bool isdlms { get; set; }
        public string isrddt { get; set; }
        public string isrodt { get; set; }
        public string msgtxt { get; set; }
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
        public string viewdt { get; set; }
        public string usernm { get; set; }
        public int divsid { get; set; }
    }
}
