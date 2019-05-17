namespace TRIZMA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TRIZMA.Models;

    public partial class UHSDMSQLSERV1dataModel : DbContext
    {
        public UHSDMSQLSERV1dataModel()
            : base("name=UHSDMSQLSERV1Connection")
        {
        }

        public virtual DbSet<UHSdimCustomerDb> UHSdimCustomerDbs { get; set; }
        public virtual DbSet<dimDistrictDb> dimDistrictDbs { get; set; }
        public virtual DbSet<fctEquipmentManufacturersDb> fctEquipmentManufacturersDbs { get; set; }
        public virtual DbSet<fctEquipmentModelsDb> fctEquipmentModelsDbs { get; set; }
        public virtual DbSet<fctEquipmentTypesDb> fctEquipmentTypesDbs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}