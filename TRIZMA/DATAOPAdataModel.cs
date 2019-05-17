namespace TRIZMA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TRIZMA.Models;

    public partial class DATAOPAdataModel : DbContext
    {
        public DATAOPAdataModel()
            : base("name=DATAOPAConnection")
        {
        }

        public virtual DbSet<DATAOPATIME_FRAMEDb> DATAOPATIME_FRAMEDbs { get; set; }
        public virtual DbSet<DISTRICTSDb> DISTRICTSDbs { get; set; }
        public virtual DbSet<DISTCOEDb> DISTCOEDbs { get; set; }
        public virtual DbSet<UHSGWL01Db> UHSGWL01Dbs { get; set; }
        public virtual DbSet<UHSVAS01Db> UHSVAS01Dbs { get; set; }
        public virtual DbSet<UHSOMD01Db> UHSOMD01Dbs { get; set; }
        public virtual DbSet<UHSACCTSDb> UHSACCTSDbs { get; set; }
        public virtual DbSet<UHSOMD11Db> UHSOMD11Dbs { get; set; }
        public virtual DbSet<UHSOMD12Db> UHSOMD12Dbs { get; set; }
        public virtual DbSet<UHSOMD13Db> UHSOMD13Dbs { get; set; }
        public virtual DbSet<UHSOMD14Db> UHSOMD14Dbs { get; set; }
        public virtual DbSet<UHSOMD15Db> UHSOMD15Dbs { get; set; }
        public virtual DbSet<UHSOMDREC01Db> UHSOMDREC01Dbs { get; set; }
        public virtual DbSet<UHSUSAT1A360Db> UHSUSAT1A360Dbs { get; set; }
        public virtual DbSet<UHSUSAT1B360Db> UHSUSAT1B360Dbs { get; set; }
        public virtual DbSet<UHSUSAT1DISTRICTDb> UHSUSAT1DISTRICTDbs { get; set; }
        public virtual DbSet<UHSUSAT1SURSERVDb> UHSUSAT1SURSERVDbs { get; set; }
        public virtual DbSet<UHSUSAT1COEDb> UHSUSAT1COEDbs { get; set; }
        public virtual DbSet<SSCYCCNTM1Db> SSCYCCNTM1Dbs { get; set; }
        public virtual DbSet<UHSWOP01Db> UHSWOP01Dbs { get; set; }
        public virtual DbSet<UHSWOT01Db> UHSWOT01Dbs { get; set; }
        public virtual DbSet<AGLINVMDL1Db> AGLINVMDL1Dbs { get; set; }
        public virtual DbSet<AGLINVMDL2Db> AGLINVMDL2Dbs { get; set; }
        public virtual DbSet<AGLINVMFC1Db> AGLINVMFC1Dbs { get; set; }
        public virtual DbSet<AGLINVMFC2Db> AGLINVMFC2Dbs { get; set; }
        public virtual DbSet<AGLINVIND1Db> AGLINVIND1Dbs { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}