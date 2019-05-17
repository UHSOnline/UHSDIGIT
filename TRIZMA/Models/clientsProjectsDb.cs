namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("clientsProjects")]
    public partial class clientsProjectsDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int    ID                { get; set; }
	    public string projectName       { get; set; }
        public int    clientID          { get; set; }
        public string createdDT         { get; set; }
        public string editedDT          { get; set; }
        public string createdByUserID   { get; set; }

    }
}
