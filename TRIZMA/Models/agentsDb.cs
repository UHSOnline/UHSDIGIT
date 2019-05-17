namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("agents")]
    public partial class agentsDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int    ID                { get; set; }
	    public int agentID           { get; set; }
        public string agentDescription  { get; set; }
        public string userID            { get; set; }
        public string UserName          { get; set; }
        public int    taskOrderID       { get; set; }
        public string createdDT         { get; set; }
        public string editedDT          { get; set; }
        public string createdByUserID   { get; set; }
        public int    userType          { get; set; }
        public string agentName         { get; set; }
        public int    orgStrL3ID        { get; set; }
        public int    orgStrSubGrID     { get; set; }
        public int regid { get; set; }
        public int divid { get; set; }
        public int distid { get; set; }
        public int acctid { get; set; }
        public int titlid { get; set; }
        public string workPhone { get; set; }
        public string mobilePhone { get; set; }
        public int DODID { get; set; }
        public bool a360 { get; set; }
        public bool b360 { get; set; }
        public int orgStrL1ID { get; set; }
        public int orgStrL2ID { get; set; }
        public string passwordstring { get; set; }
        
    }
}
