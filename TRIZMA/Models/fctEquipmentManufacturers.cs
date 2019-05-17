namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fctEquipmentManufacturers")]
    public partial class fctEquipmentManufacturersDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int sourceCD { get; set; }
        public string ManufacturerNK { get; set; }      
        public string ManufacturerName { get; set; }
        public string Type { get; set; }       
        public string Status { get; set; }      
        public string ApprovedBy { get; set; }
        
    }
}
