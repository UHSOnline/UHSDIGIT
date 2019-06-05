namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AGLINVMDLDATApg
    {
        public string ID { get; set; }
        public string DA { get; set; }
        public string MA { get; set; }
        public string TA { get; set; }
        public string FA { get; set; }
        public string DB { get; set; }
        public string MB { get; set; }
        public string TB { get; set; }
        public string FB { get; set; }
        public bool CH { get; set; }
        public string RA { get; set; }
        public string RB { get; set; }
        public string RC { get; set; }
        public string RD { get; set; }
        public string RE { get; set; }
        public string RF { get; set; }
        public string RG { get; set; }
        public string RH { get; set; }

    }
}
