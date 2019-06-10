namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("appEquipmentModels")]
    public partial class appEquipmentModelsDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
       
        public string ModelNK { get; set; }      
        public string ModelDescription { get; set; }
        public string modelID1 { get; set; }       
        public string ModelID2 { get; set; }
        public string Status { get; set; }
        public string manufacturer { get; set; }
        public string equipmentType { get; set; }
        public int sourceCD { get; set; }
        public int Rnm { get; set; }
        public string ModelApp { get; set; }
        public string ManufacturerNK { get; set; }
        public string equipmentTypeNK { get; set; }
    }
}
