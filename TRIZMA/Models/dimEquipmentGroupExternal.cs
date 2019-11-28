namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dimEquipmentGroupExternal")]
    public partial class dimEquipmentGroupExternalDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int ID { get; set; }
        public int IDK { get; set; }
        public int IDT { get; set; }
        //public string company  { get; set; }        
        public string grpdesc { get; set; }
    }
}
