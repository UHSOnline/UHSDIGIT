namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("callClassType")]
    public partial class callClassTypeDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int      ID                  { get; set; }
        public int      clientID            { get; set; }
        public int      projectID           { get; set; }
        public int      taskOrderID         { get; set; }
        public string   callClassDesc       { get; set; }
        public string   createdDT           { get; set; }
        public string   editedDT            { get; set; }
        public string   createdByUserID     { get; set; }

    }
}
