namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSDISTRICTStmp")]
    public partial class UHSDISTRICTStmpDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int ID { get; set; }
        public string district { get; set; }
        public int divID { get; set; }
        public string divisionName { get; set; }
        public int regID { get; set; }
        public string region { get; set; }
        public int DISTID { get; set; }
        public string DGRID { get; set; }
        public string DGRNM { get; set; }
        public string DISTA { get; set; }
        public string DICIT { get; set; }
        public string DIZIP { get; set; }
        public string DICOU { get; set; }
        public string DIADD { get; set; }
        public string DITMZ { get; set; }
        public double LAT { get; set; }
        public double LNG { get; set; }
        public string DIPHN { get; set; }
        public string DIFAX { get; set; }
        public int ACCID { get; set; }
        public string CUSNM { get; set; }
        public int OMDID { get; set; }
        public string OMD { get; set; }
        public string OMDEM { get; set; }
        public int DODID { get; set; }
        public string DOD { get; set; }
        public string DODEM { get; set; }
        public string emailTo { get; set; }
        public int wchk { get; set; }
        public int compid { get; set; }
        public int utco { get; set; }
    }
}
