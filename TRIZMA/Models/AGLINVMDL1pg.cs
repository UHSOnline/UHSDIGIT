namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AGLINVMDL1pgDb
    {
        
        public string Device_Category { get; set; }      
        public int impTypeID { get; set; }
        public int cnta { get; set; }
        public int cntb { get; set; }
        public int cntc { get; set; }
    }
}
