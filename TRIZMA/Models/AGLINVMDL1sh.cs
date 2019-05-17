namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AGLINVMDL1shDb
    {
        
        public string Device_Category { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int modelImpID { get; set; }
        public bool matchSingle { get; set; }
        public bool matchMultip { get; set; }
        public bool matchConfrm { get; set; }
        public bool manualInput { get; set; }
        public int Cnt { get; set; }
        public int impTypeID { get; set; }

    }
}
