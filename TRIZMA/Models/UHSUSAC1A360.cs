namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSUSAC1A360")]
    public partial class UHSUSAC1A360Db
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public int MGRID { get; set; }
        public int IDc { get; set; }
        public string crdt { get; set; }
        public string eddt { get; set; }
        public int crusid { get; set; }
        public int edusid { get; set; }
        public string userType { get; set; }
        public string agentName { get; set; }
        public string orgStrL3 { get; set; }
        public string usreg { get; set; }
        public string usdiv { get; set; }
        public string usdist { get; set; }
        public string acreg { get; set; }
        public string acdiv { get; set; }
        public string acdist { get; set; }
        public string CUST { get; set; }
    }
}
