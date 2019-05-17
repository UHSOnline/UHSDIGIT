namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dimCustomer")]
    public partial class UHSdimCustomerDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int sourceCD { get; set; }
        public string customerNK { get; set; }
        public string exceptionCD { get; set; }
        public string source { get; set; }
        public int accountID { get; set; }
        public int billToID { get; set; }
        public int projectID { get; set; }
        public int customerID { get; set; }
        public string Q2000NK { get; set; }
        public string OASYSNK { get; set; }
        public string S2NK { get; set; }
        public string SAPNK { get; set; }
        public string documentNK { get; set; }
        public string oRegion { get; set; }
        public int oDivisionID { get; set; }
        public string oDivisionName { get; set; }
        public int companyID { get; set; }
        public string companyNK { get; set; }
        public string profitID { get; set; }
        public int districtID { get; set; }
        public string districtName { get; set; }
        public string customerName { get; set; }
        public DateTime sinceDT { get; set; }
        public DateTime effectiveDT { get; set; }
        public DateTime expirationDT { get; set; }
        public string statusCD { get; set; }
        public string status { get; set; }
        public int primaryGPOID { get; set; }
        public string primaryGPO { get; set; }
        public int IDNID { get; set; }
        public string IDN { get; set; }
        public int groupID { get; set; }
        public string groupName { get; set; }
        public string customerGeocode { get; set; }
        public float milesFromOffice { get; set; }
        public float driveMilesFromOffice { get; set; }
        public float accountLatitude { get; set; }
        public float accountLongitude { get; set; }
        public int acctMgrID { get; set; }
        public int vendorMgmtID { get; set; }
        public int bpaID { get; set; }
        public int bpmID { get; set; }
        public int omhID { get; set; }
        public int arID { get; set; }
        public string arNK { get; set; }
        public string arName { get; set; }
        public string creditContactNK { get; set; }
        public string careType { get; set; }
        public string industrySegment { get; set; }
        public string isDup { get; set; }
        public string isAS400Account { get; set; }
        public string isRevenueAccount { get; set; }
        public string isAMPPAccount { get; set; }
        public string isCHAMPAccount { get; set; }
        public string isOASYSAccount { get; set; }
        public string isMYUHSAccount { get; set; }
        public string isMemberOfGPO { get; set; }
        public string isA360 { get; set; }
        public string isB360 { get; set; }
        public string kindOfAccount { get; set; }
        public string kindCD1 { get; set; }
        public string kindCD2 { get; set; }
        public string ShipToAddr1 { get; set; }
        public string ShipToAddr2 { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToState { get; set; }
        public string ShipToZip { get; set; }
        public string ShipToCounty { get; set; }
        public string ShipToPhoneNbr { get; set; }
        public string shipToPhone { get; set; }
        public string ShipToFaxNbr { get; set; }
        public string shipToFax { get; set; }
        public string ShipToCountry { get; set; }
        public string BillToAddr1 { get; set; }
        public string BillToAddr2 { get; set; }
        public string BillToCity { get; set; }
        public string BillToState { get; set; }
        public string BillToZip { get; set; }
        public string BillToCounty { get; set; }
        public string BillToPhoneNbr { get; set; }
        public string billToPhone { get; set; }
        public string BillToFaxNbr { get; set; }
        public string billToFax { get; set; }
        public string BillToCountry { get; set; }
        public string siteGroup { get; set; }
        public string accountType { get; set; }
        public int parentID { get; set; }
        public string serviceLocationID { get; set; }
        public string accountMgr { get; set; }
        public string customerHIN { get; set; }
        public string customerGLN { get; set; }
        public int taxExemptID { get; set; }
        public int mesID { get; set; }
        public int surgicalID { get; set; }
        public string definitiveID { get; set; }
        public string premierID { get; set; }
        public string GLN { get; set; }
        public string HIN { get; set; }
        public string isApproved { get; set; }
        public DateTime approvedDT { get; set; }
        public string approvedBy { get; set; }
        public DateTime disapprovedDT { get; set; }
        public string disapprovedBy { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public DateTime JCAHOInspectionDT { get; set; }
        public DateTime CAPInspectionDT { get; set; }
        public DateTime DPHInspectionDT { get; set; }
        public string MAXID { get; set; }
        public int bedCount { get; set; }
        public int bedCensus { get; set; }
        public int lastRevYYYYMM { get; set; }
        public DateTime createDT { get; set; }
        public string createBy { get; set; }
        public int facilityID { get; set; }
        public string mas90ID { get; set; }
        public string acquisition { get; set; }
        public int branchID { get; set; }
        public string branchName { get; set; }
        public int creditHold { get; set; }
        public string crHoldReason { get; set; }
        public float rentalRevYTD { get; set; }
        public float salesRevYTD { get; set; }
        public DateTime loadDT { get; set; }
        public int loadID { get; set; }


    }
}
