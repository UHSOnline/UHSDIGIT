namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SSCYCCNTM1ssitstno")]
    public partial class SSCYCCNTM1ssitstnoDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int ID { get; set; }
        public int ITSTNO { get; set; }
        public string productCode { get; set; }
        public string prodDesc { get; set; }
        public string comboName { get; set; }
        public string primUM { get; set; }
        public string secUM { get; set; }
        public int packingFactor { get; set; }
        public double AvgPrice { get; set; }
    }
}
