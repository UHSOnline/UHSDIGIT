namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("city")]
    public partial class cityDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int    ID         { get; set; }
        public string country   { get; set; }
        public string countryCD { get; set; }
        public string countryUNICODElower { get; set; }
        public string countryUNICODEupper { get; set; }
        public string countryANSIlower { get; set; }
        public string countryANSIupper { get; set; }
        public string state { get; set; }
        public string stateCD { get; set; }
        public string ZIP { get; set; }
        public string postalCode { get; set; }
        public string postalCD { get; set; }
        public string cityUNICODElower { get; set; }
        public string cityUNICODEupper { get; set; }
        public string cityANSIlower { get; set; }
        public string cityANSIupper { get; set; }
        public string postalCodeRe { get; set; }
        public string cityRegionLowerUN { get; set; }
        public string cityRegionUpperUN { get; set; }
        public string cityRegionLowerAN { get; set; }
        public string cityRegionUpperAN { get; set; }
        public string appDef            { get; set; }
        public int countryID { get; set; }







    }
}
