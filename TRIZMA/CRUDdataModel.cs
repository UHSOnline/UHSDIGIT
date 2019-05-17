namespace TRIZMA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TRIZMA.Models;

    public partial class CRUDdataModel : DbContext
    {
        public CRUDdataModel()
            : base("name=CRUDdataConnection")
        {
        }

        public virtual DbSet<connTypeDb> connTypeDbs { get; set; }
        public virtual DbSet<callDirTypeDb> callDirTypeDbs { get; set; }
        public virtual DbSet<callClassTypeDb> callClassTypeDbs { get; set; }
        public virtual DbSet<callStatusDb> callStatusDbs { get; set; }
        public virtual DbSet<cityDb> cityDbs { get; set; }

        //public virtual DbSet<topicDescDb> topicDescDbs { get; set; }
        public virtual DbSet<clientsDb> clientsDbs { get; set; }
        public virtual DbSet<countriesDb> countriesDbs { get; set; }
        public virtual DbSet<clientsProjectsDb> clientsProjectsDbs { get; set; }
        public virtual DbSet<taskOrdersDb> taskOrdersDbs { get; set; }
        public virtual DbSet<taskOrdersCountryDb> taskOrdersCountryDbs { get; set; }
        public virtual DbSet<agentsDb> agentsDbs { get; set; }
        public virtual DbSet<agentsTaskOrdersDb> agentsTaskOrdersDbs { get; set; }        
        public virtual DbSet<userTypeDb> userTypeDbs { get; set; }
        public virtual DbSet<dtyearDb> dtyearDbs { get; set; }
        public virtual DbSet<dtyearbDb> dtyearbDbs { get; set; }
        public virtual DbSet<dtmonthDb> dtmonthDbs { get; set; }
        public virtual DbSet<dtdayDb> dtdayDbs { get; set; }
        public virtual DbSet<dthourDb> dthourDbs { get; set; }
        public virtual DbSet<dthourbDb> dthourbDbs { get; set; }
        public virtual DbSet<dtminDb> dtminDbs { get; set; }
        public virtual DbSet<toInquriesDb> toInquriesDbs { get; set; }
        public virtual DbSet<toInquriesLangDb> toInquriesLangDbs { get; set; }
        public virtual DbSet<toInquriesChanelDb> toInquriesChanelDbs { get; set; }
        public virtual DbSet<toInquriesForwardDb> toInquriesForwardDbs { get; set; }
        public virtual DbSet<toInquriesProductsDb> toInquriesProductsDbs { get; set; }

        //public virtual DbSet<ftpPrefixDateDb> ftpPrefixDateDbs { get; set; }
        public virtual DbSet<agentsTODistDb> agentsTODistDbs { get; set; }
        public virtual DbSet<agentsProjDistDb> agentsProjDistDbs { get; set; }

        public virtual DbSet<timeFrameDb> timeFrameDbs { get; set; }


        public virtual DbSet<k2017orgStrL1Db> k2017orgStrL1Dbs { get; set; }
        public virtual DbSet<k2017orgStrL2Db> k2017orgStrL2Dbs { get; set; }
        public virtual DbSet<k2017orgStrL3Db> k2017orgStrL3Dbs { get; set; }
        public virtual DbSet<k2017orgStrSubGrDb> k2017orgStrSubGrDbs { get; set; }
        //public virtual DbSet<testDataDb> testDataDbs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}