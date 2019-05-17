namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("agentsTODist")]
    public partial class agentsTODistDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string    ID             { get; set; }
	    public string    userID         { get; set; }
        public int       agentID        { get; set; }
        public int       projectID      { get; set; }
        public int       taskOrderID    { get; set; }
        public string    taskOrder      { get; set; }
        

    }
}
