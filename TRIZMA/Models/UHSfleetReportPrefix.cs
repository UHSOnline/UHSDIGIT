namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fleetReportPrefixes")]
    public partial class fleetReportPrefixesDb
    {
        public int modItm1 { get; set; }
        public int modItm2 { get; set; }
        public int modItm3 { get; set; }
        


    }
}
