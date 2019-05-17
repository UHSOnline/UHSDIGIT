namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dimDistrict")]
    public partial class dimDistrictDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public Int16 DistrictID { get; set; }
	    //public string company  { get; set; }        
        public string comboDistrict { get; set; }
    }
}
