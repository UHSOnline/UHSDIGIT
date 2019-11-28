namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AspNetUserLoginRec")]
    public partial class AspNetUserLoginRecDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string ID { get; set; }
        public string userID { get; set; }
        public bool inOut { get; set; }
        public string logDT { get; set; }
        public int logDate { get; set; }
        public int logTime { get; set; }
        public string dbdt { get; set; }
        public int dbdate { get; set; }
        public int dbtime { get; set; }
    }
}
