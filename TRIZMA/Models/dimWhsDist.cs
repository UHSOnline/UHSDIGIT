namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dimWhsDist")]
    public partial class dimWhsDistDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string TechWhse { get; set; }
        public int WhseDistrictAssignment { get; set; }
        public string TechName { get; set; }
        public string whsDesc { get; set; }
        public string Type { get; set; }
        public string parentWhsDesc { get; set; }
        public string comboDrop { get; set; }
    }
}
