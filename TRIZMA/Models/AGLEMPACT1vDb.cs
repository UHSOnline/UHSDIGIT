namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("AGLEMPACT1v")]
    public partial class AGLEMPACT1vDb
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
        public string docmid { get; set; }
        public string usnmnm { get; set; }
        public int uscmid { get; set; }
        public string uscmnm { get; set; }
        public int usrgid { get; set; }
        public string usrgnm { get; set; }
        public int usdvid { get; set; }
        public string usdvnm { get; set; }
        public int usdsid { get; set; }
        public string usdsnm { get; set; }
        public int usdpid { get; set; }
        public string usdpnm { get; set; }
        public int usjcid { get; set; }
        public string usjcnm { get; set; }
        public int actpid { get; set; }
        public string actpnm { get; set; }
        public int sourcd { get; set; }
        public int trtpid { get; set; }
        public string trtpnm { get; set; }
        public int eqgrid { get; set; }
        public string eqgrnk { get; set; }
        public string eqgrnm { get; set; }
        public int eqmnid { get; set; }
        public string eqmnnk { get; set; }
        public string eqmnnm { get; set; }
        public int eqtpid { get; set; }
        public string eqtpnk { get; set; }
        public string eqtpnm { get; set; }
        public int eqclid { get; set; }
        public string eqclnk { get; set; }
        public string eqclnm { get; set; }
        public int eqmdid { get; set; }
        public string eqmdnk { get; set; }
        public string eqmdnm { get; set; }
        public bool eqprfl { get; set; }
        public int eqprid { get; set; }
        public string eqpref { get; set; }
        public string eqprnm { get; set; }
        public int svprid { get; set; }
        public string svprnk { get; set; }
        public string svprnm { get; set; }
        public string svprmn { get; set; }
        public DateTime tnstdt { get; set; }
        public DateTime tnendt { get; set; }
        public float tnsten { get; set; }
        public int tnhrsa { get; set; }
        public int tnhrsb { get; set; }
        public int trstat { get; set; }
        public DateTime trstdt { get; set; }
        public float trstst { get; set; }
        public float trenst { get; set; }
        public string mstxta { get; set; }
        public string mstxtb { get; set; }
        public string mstxtc { get; set; }
        public string mstxtd { get; set; }
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

    }
}
