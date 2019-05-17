namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("toInquriesChanelView")]
    public partial class toInquriesChanelViewDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int    ID                { get; set; }
	    public string clientID          { get; set; }
        public string projectID         { get; set; }
        public string taskOrderID       { get; set; }
        public string inquryChanel      { get; set; }
        public string createdDT         { get; set; }
        public string editedDT          { get; set; }
        public string createdByUserID   { get; set; }

    }
}
