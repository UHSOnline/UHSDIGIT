namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("agentsView")]
    public partial class agentsViewDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int    ID                { get; set; }
	    public int agentID           { get; set; }
        public string agentDescription  { get; set; }
        public string userID            { get; set; }
        public string UserName          { get; set; }
        public string taskOrderName     { get; set; }
        public string createdDT         { get; set; }
        public string editedDT          { get; set; }
        public string createdByUserID   { get; set; }
        public string userType          { get; set; }
        public string agentName         { get; set; }
        public string agentNameID       { get; set; }
        public int    orgStrL1ID        { get; set; }
        public string orgStrL1          { get; set; }
        public int    orgStrL2ID        { get; set; }
        public string orgStrL2          { get; set; }
        public int    orgStrL3ID        { get; set; }
        public string orgStrL3          { get; set; }
        public int    orgStrSubGrID     { get; set; }
        public string orgStrSubGr       { get; set; }

        public int regid { get; set; }
        public string region { get; set; }
        public int divid { get; set; }
        public string division { get; set; }
        public int distid { get; set; }
        public string district { get; set; }
        public int acctid { get; set; }
        public string account    { get; set; }
        public int titlid { get; set; }
        public string titule { get; set; }
        public string workPhone { get; set; }
        public string mobilePhone { get; set; }
        public int DODID { get; set; }
        public bool a360 { get; set; }
        public bool b360 { get; set; }
        public string passwordstring { get; set; }
        public string agentNameID2 { get; set; }

    }
}
