namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("adtyear")]
    public partial class dtyearDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int    ID    { get; set; }
	    public string year  { get; set; }
    }
}
