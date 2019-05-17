namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dimWarehouseDP")]
    public partial class dimWarehouseDPDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string ID { get; set; }
        public string Warehouse { get; set; }
        public int distid { get; set; }
        
    }
}
