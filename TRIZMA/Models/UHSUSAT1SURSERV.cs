namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSUSAT1SURSERV")]
    public partial class UHSUSAT1SURSERVDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public int MGRID { get; set; }
        public int DISTID { get; set; }
        public string crdt { get; set; }
        public string eddt { get; set; }
        public int crusid { get; set; }
        public int edusid { get; set; }

    }
}
