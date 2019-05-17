namespace TRIZMA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TRIZMA.Models;

    public partial class UHSTRIZMAdataModel : DbContext
    {
        public UHSTRIZMAdataModel()
            : base("name=UHSTRIZMAConnection")
        {
        }

        public virtual DbSet<dimWhsDistDb> dimWhsDistDbs { get; set; }
        public virtual DbSet<appEquipmentManufacturersDb> appEquipmentManufacturersDbs { get; set; }
        public virtual DbSet<appEquipmentTypesDb> appEquipmentTypesDbs { get; set; }
        public virtual DbSet<appEquipmentModelsDb> appEquipmentModelsDbs { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}