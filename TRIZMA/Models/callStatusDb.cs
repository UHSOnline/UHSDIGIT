namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("callStatus")]
    public partial class callStatusDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int      ID                  { get; set; }
        public int      clientID            { get; set; }
        public int      projectID           { get; set; }
        public int      taskOrderID         { get; set; }
        public string   callStatus          { get; set; }
        public string   createdDT           { get; set; }
        public string   editedDT            { get; set; }
        public string   createdByUserID     { get; set; }

    }
}
