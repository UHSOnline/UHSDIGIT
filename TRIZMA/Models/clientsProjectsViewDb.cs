namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("clientsProjectsView")]
    public partial class clientsProjectsViewDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int      ID              { get; set; }
        public string   projectName     { get; set; }
        public string   clientName      { get; set; }
        public string   createdDT       { get; set; }
        public string   editedDT        { get; set; }
        public string   createdByUserID { get; set; }

    }
}
