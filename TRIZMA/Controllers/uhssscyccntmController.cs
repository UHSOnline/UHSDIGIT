using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TRIZMA.Models;
using PagedList;
using System.Dynamic;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TRIZMA.Controllers
{
    public class uhssscyccntmController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();
        private UHSDMSQLSERV1dataModel opc = new UHSDMSQLSERV1dataModel();
        private UHSTRIZMAdataModel opd = new UHSTRIZMAdataModel();

        public ActionResult Index(int projectID, int taskOrderID, int Int1)
        {
            //System.Diagnostics.Debug.WriteLine(item2);
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.Single();

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.projectID)
                             .ToList();

            List<int> returnTaskOrdersIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.taskOrderID)
                             .ToList();

            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();
            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeb = userTypeInt;
            ViewBag.svctr = 0;
            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64))
            {
                ViewBag.districts = new SelectList(opd.dimWhsDistDbs.OrderBy(c => c.WhseDistrictAssignment).Select(c => new { ID = c.WhseDistrictAssignment, Value = c.parentWhsDesc }).Distinct(), "ID", "Value").ToList();

                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult _tableIndexUserCycCnt1()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.Single();

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.projectID)
                             .ToList();

            List<int> returnTaskOrdersIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.taskOrderID)
                             .ToList();

            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();
            ViewBag.userType = userTypeInt;

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64)))
            {
                //System.Diagnostics.Debug.WriteLine("Uslo u IF");
                List<SSCYCCNTM1vDb> data01 = new List<SSCYCCNTM1vDb>();
                if(userTypeInt == 2)
                {
                    var itemdt = opb.SSCYCCNTM1vDbs.Select(s => new { IDc = s.IDc, comboDistrict = s.comboDistrict, comboName = s.comboName, crdate = s.crdate, lckdc = s.lckdc }).Distinct().ToList();
                    foreach (var item in itemdt)
                    {
                        SSCYCCNTM1vDb List1 = new SSCYCCNTM1vDb();
                        List1.IDc = item.IDc; List1.comboDistrict = item.comboDistrict; List1.comboName = item.comboName; List1.crdate = item.crdate; List1.lckdc = item.lckdc;
                        data01.Add(List1);
                    }
                }
                else
                {
                    var itemdt = opb.SSCYCCNTM1vDbs.Where(s => s.crusid == userIDselectInt).Select(s => new { IDc = s.IDc, comboDistrict = s.comboDistrict, comboName = s.comboName, crdate = s.crdate, lckdc = s.lckdc }).Distinct().ToList();      
                    foreach (var item in itemdt)
                    {
                        SSCYCCNTM1vDb List1 = new SSCYCCNTM1vDb();
                        List1.IDc = item.IDc; List1.comboDistrict = item.comboDistrict; List1.comboName = item.comboName; List1.crdate = item.crdate; List1.lckdc = item.lckdc;
                        data01.Add(List1);
                    }
                }

                return PartialView(data01);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        public ActionResult Create(string whsid, string userID)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.Single();

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.projectID)
                             .ToList();

            List<int> returnTaskOrdersIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.taskOrderID)
                             .ToList();

            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();
            ViewBag.userTypeID = userTypeInt;
            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64)))
            {
                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procSSCYCCNTM1create", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@wrhsid", whsid);
                    cmd.Parameters.AddWithValue("@crusid", userID);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(conID);

                    return Json(ddID, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        public ActionResult Edit(string IDc)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.Single();

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.projectID)
                             .ToList();

            List<int> returnTaskOrdersIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.taskOrderID)
                             .ToList();

            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();
            ViewBag.userTypeID = userTypeInt;
            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64)))
            {
                //System.Diagnostics.Debug.WriteLine("Uslo u IF");
                var crdate = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.crdate).First();
                ViewBag.crdate = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.crdate).First();
                ViewBag.distid = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.DistID).First();

                ViewBag.comboDistrict = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.comboDistrict).First();
                ViewBag.whs = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.wareHouse).First();
                ViewBag.comboName = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.comboName).First();
                ViewBag.itstnos = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.ITSTNO).ToList();
                ViewBag.lckdc = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.lckdc).First();
                ViewBag.userID = userIDselectInt;
                ViewBag.docID = IDc;
                ViewBag.mnth = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateID == crdate).Select(s => s.MonthName).First();
                var mnthNm = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateID == crdate).Select(s => s.MonthNbr).First();
                ViewBag.districts = new SelectList(opd.dimWhsDistDbs.OrderBy(c => c.WhseDistrictAssignment).Select(c => new { ID = c.WhseDistrictAssignment, Value = c.parentWhsDesc }).Distinct(), "ID", "Value").ToList();
                var datatable = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).OrderBy(s => s.linnr).ToList();

                return View(datatable);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        public ActionResult Filldd1(int ID)
        {
            var dos = DateTime.Now.ToString("yyyyMM");
            int curdtymd = int.Parse(dos);
            List<string> whslist = opb.SSCYCCNTM1vDbs.Where(s => s.DistID == ID && s.cryymm == curdtymd)
                             .Select(s => s.wareHouse)
                             .ToList();

            var datatable = opd.dimWhsDistDbs.OrderBy(s => s.TechWhse).Where(s => (s.ID == 0 || s.WhseDistrictAssignment == ID) && !whslist.Contains(s.TechWhse)).Select(s => new { ID = s.TechWhse, Value = s.comboDrop });
            return Json(datatable, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Filldd2()
        {
            var datatable = opb.SSCYCCNTM1ssitstnoDbs.Select(s => new { ID = s.ITSTNO, comboName = s.comboName}).ToList();
            return Json(datatable, JsonRequestBehavior.AllowGet);
        }
        public ActionResult addNewIstno(int ID)
        {
            var datatable = opb.SSCYCCNTM1ssitstnoDbs.Where(s => s.ITSTNO == ID).ToList();
            return Json(datatable, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Save(string data)
        {
            //System.Diagnostics.Debug.WriteLine(item2);
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.Single();

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.projectID)
                             .ToList();

            List<int> returnTaskOrdersIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.taskOrderID)
                             .ToList();

            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64))
            {
                
                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procSSCYCCNTM1update", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@data", data);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(conID);

                    return Json(ddID, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
              
        }
        public ActionResult Delete(string IDc)
        {
            //System.Diagnostics.Debug.WriteLine(item2);
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.Single();

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.projectID)
                             .ToList();

            List<int> returnTaskOrdersIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.taskOrderID)
                             .ToList();

            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64))
            {

                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procSSCYCCNTM1delete", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDc", IDc);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(conID);

                    return Json(ddID, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        public ActionResult DeleteSingle(string IDc)
        {
            //System.Diagnostics.Debug.WriteLine(item2);
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.Single();

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.projectID)
                             .ToList();

            List<int> returnTaskOrdersIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.taskOrderID)
                             .ToList();

            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64))
            {

                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procSSCYCCNTM1deleteSingle", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDc", IDc);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int itstno = Int32.Parse(conID);

                    return Json(itstno, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }


        public ActionResult exportDoc(string IDc)
        {
            //System.Diagnostics.Debug.WriteLine(item2);
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.Single();

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.projectID)
                             .ToList();

            List<int> returnTaskOrdersIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.taskOrderID)
                             .ToList();

            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64))
            {

                string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procSSCYCCNTM1export", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDc", IDc);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(conID);

                    return Json(ddID, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        public ActionResult lockDoc(string IDc, int Int1)
        {
            //System.Diagnostics.Debug.WriteLine(item2);
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.Single();

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.projectID)
                             .ToList();

            List<int> returnTaskOrdersIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.taskOrderID)
                             .ToList();

            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64))
            {

                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procSSCYCCNTM1lockDoc", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDc", IDc);
                    cmd.Parameters.AddWithValue("@Int1", Int1);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(conID);

                    return Json(ddID, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        

    }
}
