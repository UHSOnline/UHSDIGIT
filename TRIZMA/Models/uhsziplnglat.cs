namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSzipLongLat")]
    public partial class UHSzipLongLatDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        
        public string ZIP   { get; set; }
        public string LAT { get; set; }
        public string LNG { get; set; }
        
    }
}
