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

namespace TRIZMA.Controllers
{
    public class uhslocationsController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();

        public ActionResult IndexA360(int projectID, int taskOrderID, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {
                var lista1 = opa.UHSACCTSDbs.Where(s => s.typeid == 1 && s.IDc > 0).Select(s => s.IDc).Distinct().ToList();
                //ViewBag.accts1 = new SelectList(opb.UHSdimCustomerDropDownDbs.Where(s => !lista1.Contains(s.ID)), "ID", "CSTNM").ToList();

                ViewBag.btnSel = 1;
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult _tableIndexA360()
        {
            var data = from s in opa.UHSACCTSDbs where s.typeid == 1 select s;
            return PartialView(data.ToList());
        }
        public ActionResult IndexB360(int projectID, int taskOrderID, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {
                var lista1 = opa.UHSACCTSDbs.Where(s => s.typeid == 2 && s.IDc > 0).Select(s => s.IDc).Distinct().ToList();
                //ViewBag.accts1 = new SelectList(opb.UHSdimCustomerDropDownDbs.Where(s => !lista1.Contains(s.ID)), "ID", "CSTNM").ToList();

                ViewBag.btnSel = 2;
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult _tableIndexB360()
        {
            var data = from s in opa.UHSACCTSDbs where s.typeid == 2 select s;
            return PartialView(data.ToList());
        }
        public JsonResult customerSelectA360(string ID)
        {
            var lista1 = opa.UHSACCTSDbs.Where(s => s.typeid == 1 && s.IDc > 0).Select(s => s.IDc).Distinct().ToList();
            var data = opb.UHSdimCustomerDropDownDbs.Where(s => !lista1.Contains(s.ID) && s.CSTNM.ToLower().StartsWith(ID.ToLower()))
                                             .Select(c => new { ID = c.ID, Value = c.ID })
                                             .OrderBy(c => new { c.Value })
                                             .ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult customerSelectB360(string ID)
        {
            var lista1 = opa.UHSACCTSDbs.Where(s => s.typeid == 2 && s.IDc > 0).Select(s => s.IDc).Distinct().ToList();
            var data = opb.UHSdimCustomerDropDownDbs.Where(s => !lista1.Contains(s.ID) && s.CSTNM.ToLower().StartsWith(ID.ToLower()))
                                             .Select(c => new { ID = c.ID, Value = c.ID })
                                             .OrderBy(c => new { c.Value })
                                             .ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateAccountPre(int IDc, int dctp)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {
                List<uhspageitemsDb> cheka = new List<uhspageitemsDb>();

                string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procUHSACCTStmpInsert", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@acctid", IDc);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string docID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(docID);


                    uhspageitemsDb set1 = new uhspageitemsDb();
                    set1.modInt01 = ddID;
                    set1.modInt02 = IDc;
                    set1.modInt03 = dctp;
                    cheka.Add(set1);

                    return Json(cheka, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
              
        }

        public ActionResult CreateAccount(int IDc, int dctp)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {
            
                        
            
                        ViewBag.IDc = IDc;
                        ViewBag.wchk = new SelectList(new[] {
                                                                        new { Id = "0", Name = "-" },
                                                                        new { Id = "1", Name = "Monday-Friday" },
                                                                        new { Id = "2", Name = "Monday-Saturday" },
                                                                        new { Id = "3", Name = "Monday-Sunday" }
                                                                      }, "Id", "Name");

                //System.Diagnostics.Debug.WriteLine(IDc);
                ViewBag.data1 = from s in opb.UHSACCTStmpDbs where s.IDc == IDc select s;
                        ViewBag.dctp = dctp;
                        return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        public ActionResult clearResA360(int IDc)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {

                string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procUHSACCTStmpDelete", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@acctid", IDc);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    
                }
                int conf = 1;
                return Json(conf, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        public ActionResult SaveA360(int IDc, int actp, int wchk, double lat, double lng, int utco)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {
                List<uhspageitemsDb> cheka = new List<uhspageitemsDb>();
                string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procUHSACCTStmpSave", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@acctid", IDc);
                    cmd.Parameters.AddWithValue("@actp", actp);
                    cmd.Parameters.AddWithValue("@wchk", wchk);
                    cmd.Parameters.AddWithValue("@lat", lat);
                    cmd.Parameters.AddWithValue("@lng", lng);
                    cmd.Parameters.AddWithValue("@utco", utco);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string docID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(docID);

                    uhspageitemsDb set1 = new uhspageitemsDb();
                    set1.modInt01 = ddID;
                    cheka.Add(set1);
                }

                var conf = cheka.Select(s => s.modInt01).First();
                return Json(conf, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult DeleteAccount(string IDd, int typeid)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {
                List<uhspageitemsDb> cheka = new List<uhspageitemsDb>();
                string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procUHSACCTSDelete", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDd", IDd);
                    cmd.Parameters.AddWithValue("@typeid", typeid);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string docID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(docID);

                    uhspageitemsDb set1 = new uhspageitemsDb();
                    set1.modInt01 = ddID;
                    cheka.Add(set1);
                }

                var conf = cheka.Select(s => s.modInt01).First();
                return Json(conf, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }


        public ActionResult IndexDistrict(int projectID, int taskOrderID, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {               
                if(Int1 == 3)
                {
                    List<int> dists = opa.DISTRICTSDbs.Where(s => s.compid == 1)
                             .Select(s => s.ID)
                             .ToList();
                    ViewBag.districts = new SelectList(opb.UHSDISTDP1Dbs.Where(s => !dists.Contains(s.ID)).OrderBy(s => s.ID), "ID", "DistrictName");
                    ViewBag.btnSel = 3;
                }
                else
                if(Int1 == 4)
                {
                    List<int> dists = opa.DISTRICTSDbs.Where(s => s.compid == 2)
                             .Select(s => s.ID)
                             .ToList();
                    ViewBag.districts = new SelectList(opb.UHSDISTDP1Dbs.Where(s => !dists.Contains(s.ID)).OrderBy(s => s.ID), "ID", "DistrictName");
                    ViewBag.btnSel = 4;
                }
                else
                if(Int1 == 5)
                {
                    List<int> dists = opa.DISTCOEDbs.Where(s => s.compid == 1)
                             .Select(s => s.ID)
                             .ToList();
                    ViewBag.districts = new SelectList(opb.UHSDISTDP1Dbs.Where(s => !dists.Contains(s.ID)).OrderBy(s => s.ID), "ID", "DistrictName");
                    ViewBag.btnSel = 5;
                }

                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }


        public ActionResult _tableIndexDistrict(int Int1)
        {
            if (Int1 == 3)
            {
                var data = from s in opa.DISTRICTSDbs where s.compid == 1 select s;
                return PartialView(data.ToList());
            } else
            if (Int1 == 4)
            {
                var data = from s in opa.DISTRICTSDbs where s.compid == 2 select s;
                return PartialView(data.ToList());
            }
            else
            if (Int1 == 5)
            {
                List<DISTRICTSDb> data = new List<DISTRICTSDb>();
                var dt1 = opa.DISTCOEDbs.Where(s => s.compid == 1);
                
                foreach(var item in dt1)
                {
                    DISTRICTSDb don1 = new DISTRICTSDb();
                    don1.ID = item.ID; don1.district = item.district; don1.divID = item.divID; don1.divisionName = item.divisionName; don1.regID = item.regID; don1.region = item.region; don1.DISTID = item.DISTID; don1.DGRID = item.DGRID; don1.DGRNM = item.DGRNM; don1.DISTA = item.DISTA; don1.DICIT = item.DICIT; don1.DIZIP = item.DIZIP; don1.DICOU = item.DICOU; don1.DIADD = item.DIADD; don1.DITMZ = item.DITMZ; don1.LAT = item.LAT; don1.LNG = item.LNG; don1.DIPHN = item.DIPHN; don1.DIFAX = item.DIFAX; don1.ACCID = item.ACCID; don1.CUSNM = item.CUSNM; don1.OMDID = item.OMDID; don1.OMD = item.OMD; don1.OMDEM = item.OMDEM; don1.DODID = item.DODID; don1.DOD = item.DOD; don1.DODEM = item.DODEM; don1.emailTo = item.emailTo; don1.wchk = item.wchk; don1.compid = item.compid; don1.utco = item.utco;
                    data.Add(don1);
                }                
                return PartialView(data.ToList());
            }
            else
            {
                return PartialView();
            }
        }

        public ActionResult CreateDistrictPre(int IDD, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {
                List<uhspageitemsDb> cheka = new List<uhspageitemsDb>();

                string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procUHSDISTRICTSinsert", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@distid", IDD);
                    cmd.Parameters.AddWithValue("@compid", Int1);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string docID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(docID);

                    return Json(ddID, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        public ActionResult CreateDistrict(int IDD, int dctp, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {
                ViewBag.IDD = IDD;
                ViewBag.wchk = new SelectList(new[] {
                                                                        new { Id = "0", Name = "-" },
                                                                        new { Id = "1", Name = "Monday-Friday" },
                                                                        new { Id = "2", Name = "Monday-Saturday" },
                                                                        new { Id = "3", Name = "Monday-Sunday" }
                                                                      }, "Id", "Name");

                //System.Diagnostics.Debug.WriteLine(IDc);
                ViewBag.data1 = from s in opb.UHSDISTRICTStmpDbs where s.ID == IDD && s.compid == Int1 select s;
                ViewBag.IDD = IDD;
                ViewBag.Int1 = Int1;
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        public ActionResult SaveDistrict(int IDD, int Int1, int wchk, double lat, double lng, int utco)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {
                List<uhspageitemsDb> cheka = new List<uhspageitemsDb>();
                string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procUHSDISTRICTSsave", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@distid", IDD);
                    cmd.Parameters.AddWithValue("@compid", Int1);
                    cmd.Parameters.AddWithValue("@wchk", wchk);
                    cmd.Parameters.AddWithValue("@lat", lat);
                    cmd.Parameters.AddWithValue("@lng", lng);
                    cmd.Parameters.AddWithValue("@utco", utco);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string docID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(docID);
                    
                    var conf = ddID;
                    return Json(conf, JsonRequestBehavior.AllowGet);
                }               
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult clearResDistrict(int IDD, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {

                string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procUHSDISTRICTStmpDelete", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDD", IDD);
                    cmd.Parameters.AddWithValue("@compid", Int1);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string docID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(docID);
                    int conf = ddID;
                    return Json(conf, JsonRequestBehavior.AllowGet);
                }
                
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        public ActionResult DeleteDistrict(int IDD, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {
                List<uhspageitemsDb> cheka = new List<uhspageitemsDb>();
                string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procUHSDISTRICTSDelete", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDD", IDD);
                    cmd.Parameters.AddWithValue("@compid", Int1);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string docID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(docID);

                    var conf = ddID;
                    return Json(conf, JsonRequestBehavior.AllowGet);
                }

                
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }


        public ActionResult getDistrictmap(int Int1)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            // get user logged ID int
            int userid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();

            // get userTypeid integer
            int userTypeid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.userType).First();
            ViewBag.userTypeID = userTypeid;

            int distid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.distid).First();
            int usertitle = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.titlid).First();

            if (userTypeid == 2)
            {
                if(Int1 == 3)
                {
                    var datatable = opa.DISTRICTSDbs.Where(s => s.compid == 1).ToList();
                    return Json(datatable, JsonRequestBehavior.AllowGet);
                } else
                if(Int1 == 4)
                {
                    var datatable = opa.DISTRICTSDbs.Where(s => s.compid == 2).ToList();
                    return Json(datatable, JsonRequestBehavior.AllowGet);
                } else
                if(Int1 == 5)
                {
                    var datatable = opa.DISTCOEDbs.Where(s => s.compid == 1).ToList();
                    return Json(datatable, JsonRequestBehavior.AllowGet);
                } else
                {
                    var datatable = 1;
                    return Json(datatable, JsonRequestBehavior.AllowGet);
                }  
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult userstruct1(int projectID, int taskOrderID, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(63))
            {
                var list = opb.UHSWEBUSRCONDbs.Where(s => s.A360CSTNM != null && s.distid != 0).Select(s => new { regid = s.regid, region = s.region}).Distinct();
                List<UHSWEBUSRCONDb> dataA360 = new List<UHSWEBUSRCONDb>();
                foreach (var item in list)
                {
                    UHSWEBUSRCONDb set1 = new UHSWEBUSRCONDb();
                    set1.regid = item.regid;
                    set1.region = item.region;
                    dataA360.Add(set1);
                }
                ViewBag.dataA360 = dataA360;

                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult _getdivA360(int ID)
        {
            var list = opb.UHSWEBUSRCONDbs.Where(s => s.A360CSTNM != null && s.regid == ID && s.distid != 0).Select(s => new { divid = s.divid, division = s.division }).Distinct();
            List<UHSWEBUSRCONDb> dataA360 = new List<UHSWEBUSRCONDb>();
            foreach (var item in list)
            {
                UHSWEBUSRCONDb set1 = new UHSWEBUSRCONDb();
                set1.divid = item.divid;
                set1.division = item.division;
                dataA360.Add(set1);
            }
            ViewBag.divA360 = dataA360;
            return PartialView("_getdivA360", dataA360.ToList());
        }
        public ActionResult _getdistA360(int ID)
        {
            var list = opb.UHSWEBUSRCONDbs.Where(s => s.A360CSTNM != null && s.divid == ID && s.distid != 0).Select(s => new { distid = s.distid, district = s.district }).Distinct();
            List<UHSWEBUSRCONDb> distA360 = new List<UHSWEBUSRCONDb>();
            foreach (var item in list)
            {
                UHSWEBUSRCONDb set1 = new UHSWEBUSRCONDb();
                set1.divid = item.distid;
                set1.division = item.district;
                distA360.Add(set1);
            }
            return PartialView("_getdistA360", distA360.ToList());
        }
        public ActionResult sendmailmessage(string email, string passwordb)
        {
            string emailToDist = email;

            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;
            string m_userName = "uhsvwpcontrolsystem@gmail.com";
            string m_UserpassWord = "Trizma123+";

            string emailID = emailToDist;

            string emailFrom = m_userName;
            string password = m_UserpassWord;
            string emailTo = emailID;

            // Here you can put subject of the mail
            string subject = "UHS VWPS Control System: Login Credentials Info";
            // Body of the mail
            string body = "<div><span style='color:#367EAD'>To: </span><b> " + email + " </b></div>";
            body += "<hr />";
            body += "<div><br /><br /><span>Access VWP Application at: </span><a target='_blank' href='http://uhsdigit.trizma.com:8083/uhsCH/Index'> http://uhsdigit.trizma.com:8083/uhsCH/Index </div></span>";
            body += "<div><br /><span>Go to Login and enter credentials as follows:</span></div>";
            body += "<div><br /><table><thead style='text-align:left'><tr><th>Login</th><th>Password</th></tr></thead><tbody style='text-align:left'><tr><td style='padding-right:20px'>" + email + "</td><td>" + passwordb + "</td></tr></tbody></table></div>";

            // this is done using  using System.Net.Mail; & using System.Net; 
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                // Can set to false, if you are sending pure text.

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }

            string data = "The message was successfully sent to: " + emailID;
            return Json(data, JsonRequestBehavior.AllowGet);
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
