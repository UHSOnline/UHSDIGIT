namespace TRIZMA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TRIZMA.Models;

    public partial class DATAOPBdataModel : DbContext
    {
        public DATAOPBdataModel()
            : base("name=DATAOPBConnection")
        {
        }

        public virtual DbSet<UHSACCTStmpDb> UHSACCTStmpDbs { get; set; }
        public virtual DbSet<UHSGWL01vDb> UHSGWL01vDbs { get; set; }
        public virtual DbSet<UHSVAS01vDb> UHSVAS01vDbs { get; set; }
        public virtual DbSet<UHSOMD01vDb> UHSOMD01vDbs { get; set; }
        public virtual DbSet<UHSWEBAABvDb> UHSWEBAABvDbs { get; set; }
        public virtual DbSet<UHSWEBAACvDb> UHSWEBAACvDbs { get; set; }
        public virtual DbSet<UHSWEBAADvDb> UHSWEBAADvDbs { get; set; }        
        public virtual DbSet<UHSPREFIXDb> UHSPREFIXDbs { get; set; }
        public virtual DbSet<UHSRATEBASEDb> UHSRATEBASEDbs { get; set; }
        public virtual DbSet<UHSOMD11vDb> UHSOMD11vDbs { get; set; }
        public virtual DbSet<UHSWEBOMD11vDb> UHSWEBOMD11vDbs { get; set; }
        public virtual DbSet<UHSWEBOMD21vDb> UHSWEBOMD21vDbs { get; set; }
        public virtual DbSet<dimDivisionDb> dimDivisionDbs { get; set; }
        public virtual DbSet<dimRegionDb> dimRegionDbs { get; set; }
        public virtual DbSet<UHSWEBAVG01vDb> UHSWEBAVG01vDbs { get; set; }
        public virtual DbSet<UHSbwDates1Db> UHSbwDates1Dbs { get; set; }
        public virtual DbSet<UHSUSAC1A360Db> UHSUSAC1A360Dbs { get; set; }
        public virtual DbSet<UHSUSAC1B360Db> UHSUSAC1B360Dbs { get; set; }
        public virtual DbSet<UHSUSAC1COEDb> UHSUSAC1COEDbs { get; set; }
        public virtual DbSet<UHSUSAC1DISTRICTDb> UHSUSAC1DISTRICTDbs { get; set; }
        public virtual DbSet<UHSUSAC1SURSERVDb> UHSUSAC1SURSERVDbs { get; set; }
        public virtual DbSet<UHSWEBUSRCONDb> UHSWEBUSRCONDbs { get; set; }
        public virtual DbSet<UHSUSDP01Db> UHSUSDP01Dbs { get; set; }
        public virtual DbSet<UHSdimCustomerDropDownDb> UHSdimCustomerDropDownDbs { get; set; }
        public virtual DbSet<dimWarehouseDb> dimWarehouseDbs { get; set; }
        public virtual DbSet<dimDistrictDPDb> dimDistrictDPDbs { get; set; }
        public virtual DbSet<dimWarehouseDPDb> dimWarehouseDPDbs { get; set; }
        public virtual DbSet<SSCYCCNTM1vDb> SSCYCCNTM1vDbs { get; set; }
        public virtual DbSet<SSCYCCNTM1ssitstnoDb> SSCYCCNTM1ssitstnoDbs { get; set; }
        public virtual DbSet<UHSDISTDP1Db> UHSDISTDP1Dbs { get; set; }
        public virtual DbSet<UHSDISTRICTStmpDb> UHSDISTRICTStmpDbs { get; set; }
        public virtual DbSet<uhsBIrepsucc02Db> uhsBIrepsucc02Dbs { get; set; }
        public virtual DbSet<dimStructureDb> dimStructureDbs { get; set; }
        public virtual DbSet<UHSinquriesDb> UHSinquriesDbs { get; set; }
        public virtual DbSet<UHSWOP01vDb> UHSWOP01vDbs { get; set; }
        public virtual DbSet<UHSWOT01vDb> UHSWOT01vDbs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}