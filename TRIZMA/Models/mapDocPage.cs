namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public partial class mapDocPageDb
    {
       
        public int    ID { get; set; }
	    public string IDNK   { get; set; }
        public string Desc { get; set; }
        public bool chck { get; set; }
    }
}
