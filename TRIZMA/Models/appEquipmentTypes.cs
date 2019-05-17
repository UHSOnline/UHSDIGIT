namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("appEquipmentTypes")]
    public partial class appEquipmentTypesDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
       
        public string equipmentTypeNK { get; set; }      
        public string equipmentTypeDescr { get; set; }
        public string equipmentFunctionName { get; set; }       
        public string clinicalRiskDescr { get; set; }      
        public string maintenanceRequirementsDescr { get; set; }
        public int riskIndicatorTotal { get; set; }
        public int calculatedClass { get; set; }
        public int actualClass { get; set; }
        public int sourceCD { get; set; }
        public int Rnm { get; set; }
        
        

    }
}
