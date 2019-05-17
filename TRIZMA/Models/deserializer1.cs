namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class deserializer1
    {
        public List<serializer1> data { get; set; }
    }
    public class serializer1
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
