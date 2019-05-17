namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dimCustomerDropDown")]
    public partial class UHSdimCustomerDropDownDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int ID { get; set; }
        public string CSTNM { get; set; }

    }
}
