namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("k2017orgStrL2")]
    public partial class k2017orgStrL2Db
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int    ID                { get; set; }
	    public int    projectID         { get; set; }
        public int    taskOrderID       { get; set; }
        public int    orgStrL1ID         { get; set; }
        public string orgStrL2           { get; set; }
        public string createdDT         { get; set; }
        public string editedDT          { get; set; }
        public string createdByUserID   { get; set; }

    }
}
