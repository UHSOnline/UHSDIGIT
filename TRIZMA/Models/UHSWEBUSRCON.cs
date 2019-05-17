namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSWEBUSRCON")]
    public partial class UHSWEBUSRCONDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public int regid { get; set; }
        public string region { get; set; }
        public int divid { get; set; }
        public string division { get; set; }
        public int distid { get; set; }
        public string district { get; set; }
        public int agentID { get; set; }
        public string agentName { get; set; }
        public string userID { get; set; }
        public string UserName { get; set; }
        public string passwordstring { get; set; }
        public string userType { get; set; }
        public string agentNameID { get; set; }
        public int titlid { get; set; }
        public string titule { get; set; }
        public string Email { get; set; }
        public int taskOrderID { get; set; }
        public string taskOrder { get; set; }
        public int DISTDIVID { get; set; }
        public string DISTDIV { get; set; }
        public int DISTDISTID { get; set; }
        public string DISTDIST { get; set; }
        public int A360DIVID { get; set; }
        public string A360DIV { get; set; }
        public int A360DISTID { get; set; }
        public string A360DIST { get; set; }
        public string A360CSTNM { get; set; }
        public int B360DIVID { get; set; }
        public string B360DIV { get; set; }
        public int B360DISTID { get; set; }
        public string B360DIST { get; set; }
        public string B360CSTNM { get; set; }
        public int SSDIVID { get; set; }
        public string SSDIV { get; set; }
        public int SSDISTID { get; set; }
        public string SSDIST { get; set; }

    }
}
