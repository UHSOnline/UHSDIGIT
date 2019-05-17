namespace TRIZMA
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using TRIZMA.Models;

    public partial class VIEWdataModel : DbContext
    {
        public VIEWdataModel()
            : base("name=VIEWdataConnection")
        {
        }

        public virtual DbSet<connTypeViewDb> connTypeViewDbs { get; set; }
        public virtual DbSet<callClassTypeViewDb> callClassTypeViewDbs { get; set; }
        public virtual DbSet<callStatusViewDb> callStatusViewDbs { get; set; }
        public virtual DbSet<clientsViewDb> clientsViewDbs { get; set; }
        public virtual DbSet<clientsProjectsViewDb> clientsProjectsViewDbs { get; set; }
        public virtual DbSet<taskOrdersViewDb> taskOrdersViewDbs { get; set; }
        public virtual DbSet<taskOrdersCountryViewDb> taskOrdersCountryViewDbs { get; set; }
        public virtual DbSet<agentsViewDb> agentsViewDbs { get; set; }
        public virtual DbSet<agentsTaskOrdersViewDb> agentsTaskOrdersViewDbs { get; set; }
        public virtual DbSet<toInquriesViewDb> toInquriesViewDbs { get; set; }
        public virtual DbSet<toInquriesLangViewDb> toInquriesLangViewDbs { get; set; }
        public virtual DbSet<toInquriesChanelViewDb> toInquriesChanelViewDbs { get; set; }
        public virtual DbSet<toInquriesForwardViewDb> toInquriesForwardViewDbs { get; set; }
        public virtual DbSet<toInquriesProductsViewDb> toInquriesProductsViewDbs { get; set; }

        public virtual DbSet<k2017orgStrL1ViewDb> k2017orgStrL1ViewDbs { get; set; }
        public virtual DbSet<k2017orgStrL2ViewDb> k2017orgStrL2ViewDbs { get; set; }
        public virtual DbSet<k2017orgStrL3ViewDb> k2017orgStrL3ViewDbs { get; set; }
        public virtual DbSet<k2017orgStrSubGrViewDb> k2017orgStrSubGrViewDbs { get; set; }
        public virtual DbSet<UHSzipLongLatDb> UHSzipLongLatDbs { get; set; }
        public virtual DbSet<vChartCMScount1Db> vChartCMScount1Dbs { get; set; }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}