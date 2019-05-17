namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dimStructure")]
    public partial class dimStructureDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int compid { get; set; }
        public string company { get; set; }
        public int regid { get; set; }
        public string region { get; set; }
        public int divid { get; set; }
        public string division { get; set; }
        public int distid { get; set; }
        public string district { get; set; }
    }
}
