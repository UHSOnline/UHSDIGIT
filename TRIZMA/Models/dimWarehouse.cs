namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dimWarehouse")]
    public partial class dimWarehouseDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string Warehouse { get; set; }
        public string TechnicianDescription { get; set; }
        public int EmpHomeDist { get; set; }
        public string EmployeeHomeDistDescription { get; set; }
        public int WhseDistrictAssignment { get; set; }
        public string Type { get; set; }
        public string AcctorEmpID { get; set; }
        public string ParentWhse { get; set; }
        public string ParentWhsNameDescription { get; set; }
        public int HomeDstNEWhseDst { get; set; }
        public string EmpSts { get; set; }
    }
}
