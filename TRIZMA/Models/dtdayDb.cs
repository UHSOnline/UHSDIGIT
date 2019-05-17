namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("adtday")]
    public partial class dtdayDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int    ID    { get; set; }
	    public string day  { get; set; }
    }
}
