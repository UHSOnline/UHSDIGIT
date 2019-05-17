namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("taskOrdersView")]
    public partial class taskOrdersViewDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int    ID                { get; set; }
	    public string clientName        { get; set; }
        public string projectName       { get; set; }
        public string taskOrder         { get; set; }
        public string createdDT         { get; set; }
        public string editedDT          { get; set; }
        public string createdByUserID   { get; set; }
        public string taskOrderMenu     { get; set; }

    }
}
