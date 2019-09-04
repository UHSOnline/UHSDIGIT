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
using System.Net.Sockets;

namespace TRIZMA.Controllers
{
    public class uhsCHController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();
        // GET: clientsDbs

       
        public ActionResult UserLogin(string a, int b)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var stra = b + "<|>" + CurrentLoginID + "<|>" + a;

            string CS = ConfigurationManager.ConnectionStrings["VIEWdataConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("procUserLoginRec", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@stra", stra);

                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@ID";
                outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                outputParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);

                con.Open();
                cmd.ExecuteNonQuery();

                string conID = outputParameter.Value.ToString();
                int data = Int32.Parse(conID);

                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Index()
        {
            string check1 = null;
            //var check1 = User.Identity.GetUserId().ToString();
            if (check1 == null)
            {
                ViewBag.ItemSelect = 989;
                return View();
            }
            else
            {
                return RedirectToAction("District", "uhsCH");
            }
        }
        public ActionResult Home()
        {
            // get user logged ID string
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            // get user logged ID int
            int userid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();
            // get userTypeid integer
            int userTypeid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.userType).First();
            ViewBag.userID = userid;
            ViewBag.userTypeID = userTypeid;
            string userName = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();
            ViewBag.ItemSelect = 1;
            var dtt = DateTime.Now.ToString("yyyyMM");
            int dtt1 = int.Parse(dtt);
            var dts = DateTime.Now.ToString("yyyyMMdd");
            int dt1 = int.Parse(dts);
            int week = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.WNumber).First();
            int daynbr = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.daywnm).First();
            List<int> agentP = new List<int>(db.agentsProjDistDbs.OrderBy(c => c.ID).Where(c => c.userID == CurrentLoginID && c.projectID != 6 && c.projectID != 7).Select(c => c.projectID).ToList());
            ViewBag.preAgentT = db.agentsTODistDbs.Where(c => c.userID == CurrentLoginID && (c.taskOrderID == 53 
                                                                                          || c.taskOrderID == 55
                                                                                          || c.taskOrderID == 56
                                                                                          || c.taskOrderID == 57
                                                                                          || c.taskOrderID == 58
                                                                                          || c.taskOrderID == 64
                                                                                          || c.taskOrderID == 65
                                                                                          || c.taskOrderID == 66)).Select(c => new { ID = c.taskOrderID }).ToList();
            ViewBag.daynbr = daynbr;
            ViewBag.modules = opb.UHSinquriesDbs.Select(c => new { dctpid = c.dctpid, taskOrder = c.taskOrder }).Distinct().ToList();
            var list = opb.UHSSOC01vDbs.Where(c => (c.crusid == userid || c.userid == userid || c.ispubl == true) && c.isdlms == false).Select(c => c.ID).ToList();
            ViewBag.msgs = opb.UHSSOC01vDbs.Where(c => list.Contains(c.ID) || list.Contains(c.IDT)).OrderBy(c => c.crdt).Select(c => new { ID = c.ID
                                                            , IDT = c.IDT
                                                            , IDK = c.IDK
                                                            , distid = c.distid
                                                            , acctid = c.acctid
                                                            , userid = c.userid
                                                            , distnm = c.distnm
                                                            , docmid = c.docmid
                                                            , L1DS = c.L1DS
                                                            , acctnm = c.acctnm
                                                            , ispubl = c.ispubl
                                                            , isrepl = c.isrepl
                                                            , isrere = c.isrere
                                                            , isread = c.isread
                                                            , islike = c.islike
                                                            , isrepo = c.isrepo
                                                            , isdlms = c.isdlms
                                                            , msgtxt = c.msgtxt
                                                            , chckid = c.chckid
                                                            , crusid = c.crusid
                                                            , crusnm = c.crusnm
                                                            , viewdt = c.viewdt
                                                            , usernm = c.usernm }).ToList();


            ViewBag.svctr = 0;
            return View();
        }
        public ActionResult getDiv(int ID)
        {
            if (ID == 1010003 || ID == 1010008)
            {
                var locs = opa.UHSUSAT1DISTRICTDbs.Select(s => s.DISTID).Distinct().ToList();
                var data = opa.DISTRICTSDbs.Where(s => s.compid == 1 && locs.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.divID, Name = s.divisionName }).Distinct().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            if (ID == 1010006)
            {
                var locs = opa.UHSUSAT1A360Dbs.Select(s => s.IDc).Distinct().ToList();
                var data = opa.UHSACCTSDbs.Where(s => s.typeid == 1 && locs.Contains(s.IDc)).OrderBy(s => s.ID).Select(s => new { ID = s.divID, Name = s.DIV }).Distinct().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            if (ID == 1010007)
            {
                var locs = opa.UHSUSAT1B360Dbs.Select(s => s.IDc).Distinct().ToList();
                var data = opa.UHSACCTSDbs.Where(s => s.typeid == 2 && locs.Contains(s.IDc)).OrderBy(s => s.ID).Select(s => new { ID = s.divID, Name = s.DIV }).Distinct().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            if (ID == 1010009)
            {
                var locs = opa.UHSUSAT1SURSERVDbs.Select(s => s.DISTID).Distinct().ToList();
                var data = opa.DISTRICTSDbs.Where(s => s.compid == 2 && locs.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.divID, Name = s.divisionName }).Distinct().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            if (ID == 1010010)
            {
                var locs = opa.UHSUSAT1COEDbs.Select(s => s.DISTID).Distinct().ToList();
                var data = opa.DISTCOEDbs.Where(s => s.compid == 1 && locs.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.divID, Name = s.divisionName }).Distinct().ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = "";
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult getLoc(int ID, int IDc)
        {
            if (ID == 1010003 || ID == 1010008)
            {
                var locs = opa.UHSUSAT1DISTRICTDbs.Select(s => s.DISTID).Distinct().ToList();
                var data = opa.DISTRICTSDbs.Where(s => s.compid == 1 && s.divID == IDc && locs.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Name = s.district }).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            if(ID == 1010006)
            {
                var locs = opa.UHSUSAT1A360Dbs.Select(s => s.IDc).Distinct().ToList();
                var data = opa.UHSACCTSDbs.Where(s => s.typeid == 1 && s.divID == IDc && locs.Contains(s.IDc)).OrderBy(s => s.ID).Select(s => new { ID = s.IDc, Name = s.CSTNM }).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            if (ID == 1010007)
            {
                var locs = opa.UHSUSAT1B360Dbs.Select(s => s.IDc).Distinct().ToList();
                var data = opa.UHSACCTSDbs.Where(s => s.typeid == 2 && s.divID == IDc && locs.Contains(s.IDc)).OrderBy(s => s.ID).Select(s => new { ID = s.IDc, Name = s.CSTNM }).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            if (ID == 1010009)
            {
                var locs = opa.UHSUSAT1SURSERVDbs.Select(s => s.DISTID).Distinct().ToList();
                var data = opa.DISTRICTSDbs.Where(s => s.compid == 2 && s.divID == IDc && locs.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Name = s.district }).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            if (ID == 1010010)
            {
                var locs = opa.UHSUSAT1COEDbs.Select(s => s.DISTID).Distinct().ToList();
                var data = opa.DISTCOEDbs.Where(s => s.compid == 1 && s.divID == IDc && locs.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Name = s.district }).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = "";
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult getUsr(int ID, int IDb)
        {
            if (ID == 1010003 || ID == 1010008)
            {
                var data = opb.UHSUSAC1DISTRICTDbs.Where(s => s.DISTID == IDb).Select(s => new { ID = s.MGRID, Name = s.agentName }).Distinct().OrderBy(s => s.Name).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            if (ID == 1010006)
            {
                var data = opb.UHSUSAC1A360Dbs.Where(s => s.IDc == IDb).Select(s => new { ID = s.MGRID, Name = s.agentName }).Distinct().OrderBy(s => s.Name).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            if (ID == 1010007)
            {
                var data = opb.UHSUSAC1B360Dbs.Where(s => s.IDc == IDb).Select(s => new { ID = s.MGRID, Name = s.agentName }).Distinct().OrderBy(s => s.Name).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            if (ID == 1010009)
            {
                var data = opb.UHSUSAC1SURSERVDbs.Where(s => s.DISTID == IDb).Select(s => new { ID = s.MGRID, Name = s.agentName }).Distinct().OrderBy(s => s.Name).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            if (ID == 1010010)
            {
                var data = opb.UHSUSAC1COEDbs.Where(s => s.DISTID == IDb).Select(s => new { ID = s.MGRID, Name = s.agentName }).Distinct().OrderBy(s => s.Name).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = "";
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult messEdit(string b)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            if(CurrentLoginID == User.Identity.GetUserId().ToString())
            {
                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procAGLMESEDIT", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@stra", b);

                    cmd.Parameters.Add("@ID", SqlDbType.VarChar, 30);
                    cmd.Parameters["@ID"].Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    string conID = cmd.Parameters["@ID"].Value.ToString();
                    
                    if (conID == "1" || conID == "2" || conID == "4")
                    {
                        var msgs = conID;                        
                        return Json(msgs, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        
                        var msgs = opb.UHSSOC01vDbs.Where(c => c.ID == conID).ToList();
                        return Json(msgs, JsonRequestBehavior.AllowGet);
                    }
                    
                }
               
            }
            else
            {
                var data = "";
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            
        }
        public ActionResult messDel(string a)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            if (CurrentLoginID == User.Identity.GetUserId().ToString())
            {
                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procAGLMESDELT", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@stra", a);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int msgs = Int32.Parse(conID);

                    return Json(msgs, JsonRequestBehavior.AllowGet);

                }

            }
            else
            {
                int msgs = 2;
                return Json(msgs, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult SBagPr()
        {
            //string CurrentLoginID = User.Identity.GetUserId().ToString();
            //var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            //int userTypeInt = userTypeSelect.First();

            //var userIDSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            //int userIDInt = userIDSelect.First();

            //var agentP = db.agentsProjDistDbs.OrderBy(c => c.projectName).Where(c => c.userID == CurrentLoginID && c.projectID != 6 && c.projectID != 7).ToList();
            //return PartialView("_SBagPr", agentP);

            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            var userIDSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDInt = userIDSelect.First();

            List<int> agentP = new List<int>(db.agentsProjDistDbs.OrderBy(c => c.ID).Where(c => c.userID == CurrentLoginID && c.projectID != 6 && c.projectID != 7).Select(c => c.projectID).ToList());

            var preAgentT = db.agentsTODistDbs.Where(c => c.userID == CurrentLoginID);
            var agentT = preAgentT.OrderBy(s => s.taskOrder).Where(c => agentP.Contains(c.projectID)).ToList();
            //System.Diagnostics.Debug.WriteLine(agentT);
            //ViewBag.projectID = id;
            return PartialView("_SBagTo", agentT);
        }
        
        public ActionResult SBagTo()
        {           
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            var userIDSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDInt = userIDSelect.First();

            List<int> agentP = new List<int>(db.agentsProjDistDbs.OrderBy(c => c.ID).Where(c => c.userID == CurrentLoginID && c.projectID != 6 && c.projectID != 7).Select(c => c.projectID).ToList());

            var preAgentT = db.agentsTODistDbs.Where(c => c.userID == CurrentLoginID);
            var agentT = preAgentT.OrderBy(s => s.taskOrder).Where(c => agentP.Contains(c.projectID)).ToList();

            //System.Diagnostics.Debug.WriteLine(agentT);
            //ViewBag.projectID = id;
            return PartialView("_SBagTo", agentT);
        }
        public ActionResult SBagTox()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            var userIDSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDInt = userIDSelect.First();

            List<int> agentP = new List<int>(db.agentsProjDistDbs.OrderBy(c => c.ID).Where(c => c.userID == CurrentLoginID && c.projectID != 6 && c.projectID != 7).Select(c => c.projectID).ToList());

            var preAgentT = db.agentsTODistDbs.Where(c => c.userID == CurrentLoginID);
            var agentT = preAgentT.OrderBy(s => s.taskOrder).Where(c => agentP.Contains(c.projectID)).ToList();

            //System.Diagnostics.Debug.WriteLine(agentT);
            //ViewBag.projectID = id;
            return PartialView("_SBagTox", agentT);
        }
        public ActionResult SBagPra()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            var userIDSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDInt = userIDSelect.First();

            var agentP = db.agentsProjDistDbs.Where(c => c.userID == CurrentLoginID && c.projectID == 7).ToList();
            return PartialView("_SBagPr", agentP);
        }
        public ActionResult _left_sidebar_pro()
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
            var dtt = DateTime.Now.ToString("yyyyMM");
            int dtt1 = int.Parse(dtt);
            var dts = DateTime.Now.ToString("yyyyMMdd");
            int dt1 = int.Parse(dts);
            ViewBag.usrnm = dbv.agentsViewDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();

            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeID = userTypeInt;

            return PartialView("_left_sidebar_pro");
        }
        public ActionResult _header_advance_area()
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
            ViewBag.usrnm = dbv.agentsViewDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();

            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeID = userTypeInt;

            return PartialView("_left_sidebar_pro");
        }
        public ActionResult _header_top_wraper(int tid)
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
            ViewBag.usrnm = dbv.agentsViewDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();

            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeID = userTypeInt;
            ViewBag.svctr = tid;
            return PartialView("_header_top_wraper");
        }
        public ActionResult _mobile_menu_nav()
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
            ViewBag.usrnm = dbv.agentsViewDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();

            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeID = userTypeInt;
            return PartialView("_mobile_menu_nav");
        }

        public ActionResult SBagToa(int id)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            var preAgentT = db.agentsTODistDbs.Where(c => c.userID == CurrentLoginID);
            var agentT = preAgentT.OrderBy(s => s.taskOrder).Where(c => c.projectID == id).ToList();

            ViewBag.projectID = id;
            return PartialView("_SBagTo", agentT);
        }
        public ActionResult _navbartop()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            string userName = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();
            ViewBag.userName = userName;
            return PartialView("_navbartop");
        }
        public ActionResult _navbartopb()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            string userName = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();
            ViewBag.userName = userName;
            return PartialView("_navbartopb");
        }
        public ActionResult _navbarleft()
        {
            return PartialView("_navbarleft");
        }
        public ActionResult Data()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            // get user logged ID int
            int userid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();
            // get userTypeid integer
            int userTypeid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.userType).First();
            ViewBag.userTypeID = userTypeid;
            string userName = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();
            ViewBag.ItemSelect = 3;
            return View();
        }
        public ActionResult Quality()
        {
            // get user logged ID string
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            // get user logged ID int
            int userid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();
            // get userTypeid integer
            int userTypeid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.userType).First();
            ViewBag.userTypeID = userTypeid;
            string userName = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();
            ViewBag.ItemSelect = 5;
            return View();
        }
        public ActionResult perdrop1(int ID)
        {
            var list = opb.UHSGWL01vDbs.Where(s => s.dctpid == 1010001)
                                        .OrderByDescending(c => c.yyyymm)
                                        .Select(c => new { ID = c.yyyymm, Value = c.yyyymm })
                                        .Distinct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult perd6op1(int ID)
        {
            var list = opb.UHSGWL01vDbs.Where(s => s.dctpid == 1010002)
                                        .OrderByDescending(c => c.yyyymm)
                                        .Select(c => new { ID = c.yyyymm, Value = c.yyyymm })
                                        .Distinct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult wekdrop1(int ID)
        {
            var list = opb.UHSGWL01vDbs.Where(c => c.yyyymm == ID && c.dctpid == 1010001)
                                       .OrderByDescending(c => c.weeknr)
                                       .Select(c => new { ID = c.weeknr, Value = c.weekds })
                                       .Distinct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult wekd6op1(int ID)
        {
            var list = opb.UHSGWL01vDbs.Where(c => c.yyyymm == ID && c.dctpid == 1010002)
                                       .OrderByDescending(c => c.weeknr)
                                       .Select(c => new { ID = c.weeknr, Value = c.weekds })
                                       .Distinct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult disdrop1(int ID1, int ID2)
        {
            var help1 = opb.UHSGWL01vDbs.Where(c => c.yyyymm == ID1 && c.weeknr == ID2 && c.dctpid == 1010001)
                                        .OrderBy(c => c.distid)
                                        .Select(c => c.distid)
                                        .Distinct()
                                        .ToList();
            var list = opa.DISTRICTSDbs.Where(c => c.ID == 0 || (help1.Contains(c.ID) && c.compid == 1))
                                        .OrderBy(c => c.ID)
                                        .Select(c => new { ID = c.ID, Value = c.district })
                                        .ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult disd6op1(int ID1, int ID2)
        {
            var help1 = opb.UHSGWL01vDbs.Where(c => c.yyyymm == ID1 && c.weeknr == ID2 && c.dctpid == 1010002)
                                        .OrderBy(c => c.distid)
                                        .Select(c => c.distid)
                                        .Distinct()
                                        .ToList();
            var list = opa.DISTRICTSDbs.Where(c => c.ID == 1 || (help1.Contains(c.ID) && c.compid == 1))
                                        .OrderBy(c => c.ID)
                                        .Select(c => new { ID = c.ID, Value = c.district })
                                        .ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult viewdocs1(int ID1, int ID2)
        {
            var data = 2;

            return Json(data, JsonRequestBehavior.AllowGet);
        }  
        public ActionResult _retUplDocList(string id1, string id2)
        {
            string vPath = @"~/upload/uplCadence/";
            string cPath = Server.MapPath(vPath);
            string[] fileArray = Directory.GetFiles(cPath);

            List<uhspageitemsDb> dataSet1 = new List<uhspageitemsDb>();
            foreach (var i in fileArray)
            {
                uhspageitemsDb List1 = new uhspageitemsDb();
                var itt1 = i.ToString();
                int st1 = itt1.IndexOf("_");
                int st2 = st1 + 9;
                int st3 = itt1.Length;
                int st4 = st3 - st2;

                //**********************************
                // IMPORTANT !!! //
                // change these walues on Publish - folder path is different on server
                // when working on local commment out 35, uncomment 81 - and wiseversa :)
                //**********************************
                //int na1 = 81;
                int na1 = 35;
                //**********************************
                //**********************************

                int na2 = itt1.Length;
                int na3 = na2 - na1;
                string deo1 = itt1.Substring(st2, st4);
                string deo2 = itt1.Substring(na1, na3);
                List1.modStr1 = deo2;
                List1.modStr2 = deo1;
                dataSet1.Add(List1);
            }
            //uhspageitemsDb List1 = new uhspageitemsDb();
            //List1.modStr1 = "test";
            //List1.modStr2 = "test";
            //dataSet1.Add(List1);

            //var data = dataSet1.ToList();
            var data = dataSet1.Where(s => s.modStr1.Contains(id1) && s.modStr1.Contains(id2)).ToList();
            return PartialView("_retUplDocList", data);
        }
        public ActionResult returnDocList(string id1)
        {
            string vPath = @"~/upload/uplCadence/";
            string cPath = Server.MapPath(vPath);
            string[] fileArray = Directory.GetFiles(cPath);

            List<uhspageitemsDb> dataSet1 = new List<uhspageitemsDb>();
            foreach (var i in fileArray)
            {
                uhspageitemsDb List1 = new uhspageitemsDb();
                var itt1 = i.ToString();
                int st1 = itt1.IndexOf("_");
                int st2 = st1 + 9;
                int st3 = itt1.Length;
                int st4 = st3 - st2;

                //**********************************
                // IMPORTANT !!! //
                // change these walues on Publish - folder path is different on server
                // when working on local commment out 35, uncomment 81 - and wiseversa :)
                //**********************************
                //int na1 = 81;
                int na1 = 35;
                //**********************************
                //**********************************

                int na2 = itt1.Length;
                int na3 = na2 - na1;
                string deo1 = itt1.Substring(st2, st4);
                string deo2 = itt1.Substring(na1, na3);
                List1.modStr1 = deo2;
                List1.modStr2 = deo1;
                dataSet1.Add(List1);
            }
            //uhspageitemsDb List1 = new uhspageitemsDb();
            //List1.modStr1 = "test";
            //List1.modStr2 = "test";
            //dataSet1.Add(List1);

            //var data = dataSet1.ToList();
            var data = dataSet1.Where(s => s.modStr1.Contains(id1)).ToList();
            return Json(data.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult retDelDocList(string id1)
        {
            string vPath = "~/upload/uplCadence/";
            string cPath = Server.MapPath(vPath);
            string completePath = cPath+id1;
            if (System.IO.File.Exists(completePath))
            {
                System.IO.File.Delete(completePath);
                var data = 1;
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = 2;
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        } 
        public string dnlDoc(string file, string str2)
        {
            string vPath = "~/upload/uplCadence/";
            string cPath = Server.MapPath(vPath);
            string actualFilePath = cPath + file;
            
            //System.Diagnostics.Debug.WriteLine(actualFilePath);
            HttpContext.Response.ContentType = "APPLICATION/OCTET-STREAM";
            string filename = str2;
            String Header = "Attachment; Filename=" + filename;
            HttpContext.Response.AppendHeader("Content-Disposition", Header);
            HttpContext.Response.WriteFile(actualFilePath);
            HttpContext.Response.End();
            return "";
        }
        public ActionResult procUHSUSAG01(int ID)
        {
            string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("procUHSUSAG01", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@res";
                outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                outputParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);
                con.Open();
                cmd.ExecuteNonQuery();
                var respond = outputParameter.Value;
                int res = Convert.ToInt32(respond);

                if (res == 1)
                {
                    return Json(res, JsonRequestBehavior.AllowGet);
                }
                return Json(res, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult updtwebavg01(int acctid, int dctpid)
        {
            string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("procUHSWEBAVG01vNewUpdate", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@acctid", acctid);
                cmd.Parameters.AddWithValue("@dctpid", dctpid);
                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@ID";
                outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                outputParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);
                con.Open();
                cmd.ExecuteNonQuery();
                var respond = outputParameter.Value;
                return Json(respond, JsonRequestBehavior.AllowGet);              
            }
        }
        public ActionResult updtwebavg02(int distid, int dctpid)
        {
            string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("procUHSWEBAVG01vUpdate01", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@distid", distid);
                cmd.Parameters.AddWithValue("@dctpid", dctpid);
                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@ID";
                outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                outputParameter.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(outputParameter);
                con.Open();
                cmd.ExecuteNonQuery();
                var respond = outputParameter.Value;
                return Json(respond, JsonRequestBehavior.AllowGet);
            }
        }
        // POST: Edit Doc:1010001 & Doc:1010002
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult edit1010001(UHSGWL01Db model)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && returnTaskOrdersIDlist.Contains(53)))
            {
                if (ModelState.IsValid)
                {
                    try
                    {          
                        opa.Entry(model).State = EntityState.Modified;
                        opa.SaveChanges();
                        int resp1010001 = 1;
                        return Json(resp1010001, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        int resp1010001 = 2;
                        return Json(resp1010001, JsonRequestBehavior.AllowGet);
                        throw (e);
                    }
                }
                else
                {
                    int resp1010001 = 3;
                    return Json(resp1010001, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int resp1010001 = 4;
                return Json(resp1010001, JsonRequestBehavior.AllowGet);
            }
        }


        // POST: Edit Doc:1010003
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult edit1010003(UHSVAS01Db model)
        {
            //System.Diagnostics.Debug.WriteLine(model.ID);
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && returnTaskOrdersIDlist.Contains(53)))
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        opa.Entry(model).State = EntityState.Modified;
                        opa.SaveChanges();
                        int resp1010003 = 1;
                        return Json(resp1010003, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        int resp1010003 = 2;
                        return Json(resp1010003, JsonRequestBehavior.AllowGet);
                        throw (e);
                    }
                }
                else
                {
                    int resp1010003 = 3;
                    return Json(resp1010003, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int resp1010003 = 4;
                return Json(resp1010003, JsonRequestBehavior.AllowGet);
            }
        }
        // POST: Edit Doc:1010005
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult edit1010005(UHSOMD01Db model)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && returnTaskOrdersIDlist.Contains(53)))
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        opa.Entry(model).State = EntityState.Modified;
                        opa.SaveChanges();

                        int resp1010005 = 1;
                        return Json(resp1010005, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        int resp1010005 = 2;
                        return Json(resp1010005, JsonRequestBehavior.AllowGet);
                        throw (e);
                    }
                }
                else
                {
                    int resp1010005 = 3;
                    return Json(resp1010005, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int resp1010005 = 4;
                return Json(resp1010005, JsonRequestBehavior.AllowGet);
            }
        }
        // POST: Edit Doc:1010005
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult edit10100061(UHSOMD11Db model)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && (returnTaskOrdersIDlist.Contains(53)
                                                                                                 || returnTaskOrdersIDlist.Contains(55)
                                                                                                 || returnTaskOrdersIDlist.Contains(56)
                                                                                                 || returnTaskOrdersIDlist.Contains(57) 
                                                                                                 || returnTaskOrdersIDlist.Contains(58))))
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        opa.Entry(model).State = EntityState.Modified;
                        opa.SaveChanges();

                        int respond = 1;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        int respond = 2;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                        throw (e);
                    }
                }
                else
                {
                    int respond = 3;
                    return Json(respond, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int respond = 4;
                return Json(respond, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult edit10100062(UHSOMD12Db model)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && (returnTaskOrdersIDlist.Contains(53)
                                                                                                 || returnTaskOrdersIDlist.Contains(55)
                                                                                                 || returnTaskOrdersIDlist.Contains(56)
                                                                                                 || returnTaskOrdersIDlist.Contains(57)
                                                                                                 || returnTaskOrdersIDlist.Contains(58))))
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        opa.Entry(model).State = EntityState.Modified;
                        opa.SaveChanges();

                        int respond = 1;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        int respond = 2;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                        throw (e);
                    }
                }
                else
                {
                    int respond = 3;
                    return Json(respond, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int respond = 4;
                return Json(respond, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult edit10100063(UHSOMD13Db model)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && (returnTaskOrdersIDlist.Contains(53)
                                                                                                 || returnTaskOrdersIDlist.Contains(55)
                                                                                                 || returnTaskOrdersIDlist.Contains(56)
                                                                                                 || returnTaskOrdersIDlist.Contains(57)
                                                                                                 || returnTaskOrdersIDlist.Contains(58))))
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        opa.Entry(model).State = EntityState.Modified;
                        opa.SaveChanges();

                        int respond = 1;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        int respond = 2;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                        throw (e);
                    }
                }
                else
                {
                    int respond = 3;
                    return Json(respond, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int respond = 4;
                return Json(respond, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult edit10100064(UHSOMD14Db model)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && (returnTaskOrdersIDlist.Contains(53)
                                                                                                 || returnTaskOrdersIDlist.Contains(55)
                                                                                                 || returnTaskOrdersIDlist.Contains(56)
                                                                                                 || returnTaskOrdersIDlist.Contains(57)
                                                                                                 || returnTaskOrdersIDlist.Contains(58))))
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        opa.Entry(model).State = EntityState.Modified;
                        opa.SaveChanges();
                        //System.Diagnostics.Debug.WriteLine("test 4 1");
                        int respond = 1;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        int respond = 2;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                        throw (e);
                    }
                }
                else
                {
                    int respond = 3;
                    return Json(respond, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int respond = 4;
                return Json(respond, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult edit10100065(UHSOMD15Db model)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && (returnTaskOrdersIDlist.Contains(53)
                                                                                                 || returnTaskOrdersIDlist.Contains(55)
                                                                                                 || returnTaskOrdersIDlist.Contains(56)
                                                                                                 || returnTaskOrdersIDlist.Contains(57)
                                                                                                 || returnTaskOrdersIDlist.Contains(58))))
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        //System.Diagnostics.Debug.WriteLine("test 1");
                        opa.Entry(model).State = EntityState.Modified;
                        //System.Diagnostics.Debug.WriteLine("test 2");
                        opa.SaveChanges();
                        //System.Diagnostics.Debug.WriteLine("test 3");
                        int respond = 1;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        int respond = 2;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                        throw (e);
                    }
                }
                else
                {
                    int respond = 3;
                    return Json(respond, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int respond = 4;
                return Json(respond, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult edit3010001(UHSWOT01Db model)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && returnTaskOrdersIDlist.Contains(65)))
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        //System.Diagnostics.Debug.WriteLine("test 1");
                        opa.Entry(model).State = EntityState.Modified;
                        //System.Diagnostics.Debug.WriteLine("test 2");
                        opa.SaveChanges();
                        //System.Diagnostics.Debug.WriteLine("test 3");
                        int respond = 1;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        int respond = 2;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                        throw (e);
                    }
                }
                else
                {
                    int respond = 3;
                    return Json(respond, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int respond = 4;
                return Json(respond, JsonRequestBehavior.AllowGet);
            }
        }
        // POST: k2017orgStrL1Dbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult save3010002(UHSWOP01Db UHSWOP01Db)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && returnTaskOrdersIDlist.Contains(65)))
            {

                if (ModelState.IsValid)
                {
                    opa.UHSWOP01Dbs.Add(UHSWOP01Db);
                    opa.SaveChanges();

                    var respond = 1;
                    return Json(respond, JsonRequestBehavior.AllowGet);
                }

                return View(UHSWOP01Db);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult edit3010002(UHSWOP01Db model)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && returnTaskOrdersIDlist.Contains(65)))
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        //System.Diagnostics.Debug.WriteLine("test 1");
                        opa.Entry(model).State = EntityState.Modified;
                        //System.Diagnostics.Debug.WriteLine("test 2");
                        opa.SaveChanges();
                        //System.Diagnostics.Debug.WriteLine("test 3");
                        int respond = 1;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        int respond = 2;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                        throw (e);
                    }
                }
                else
                {
                    int respond = 3;
                    return Json(respond, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int respond = 4;
                return Json(respond, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: k2017orgStrL1Dbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult save9010001(UHSSOC01Db UHSSOC01Db)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.Single();

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.projectID)
                             .ToList();

            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && (returnProjectIDlist.Contains(13)
                                                                                             || returnProjectIDlist.Contains(15)
                                                                                             || returnProjectIDlist.Contains(16))))
            {
                var IDd = UHSSOC01Db.ID;

                if (ModelState.IsValid)
                {
                    opa.UHSSOC01Dbs.Add(UHSSOC01Db);
                    opa.SaveChanges();

                    var msgs = opb.UHSSOC01vDbs.Where(c => c.ID == IDd).Select(c => new { ID = c.ID
                                                            , IDT = c.IDT
                                                            , IDK = c.IDK
                                                            , distid = c.distid
                                                            , acctid = c.acctid
                                                            , userid = c.userid
                                                            , distnm = c.distnm
                                                            , docmid = c.docmid
                                                            , L1DS = c.L1DS
                                                            , acctnm = c.acctnm
                                                            , ispubl = c.ispubl
                                                            , isrepl = c.isrepl
                                                            , isrere = c.isrere
                                                            , isread = c.isread
                                                            , islike = c.islike
                                                            , isrepo = c.isrepo
                                                            , isdlms = c.isdlms
                                                            , msgtxt = c.msgtxt 
                                                            , crusid = c.crusid
                                                            , crusnm = c.crusnm
                                                            , viewdt = c.viewdt
                                                            , usernm = c.usernm }).ToList();
                    return Json(msgs, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return View(UHSSOC01Db);
                }
                
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }









        // POST: 

        //[ValidateAntiForgeryToken]
        public ActionResult delDoc3010001(string id)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && returnTaskOrdersIDlist.Contains(65)))
            {
                UHSWOT01Db UHSWOT01Db = opa.UHSWOT01Dbs.Find(id);
                opa.UHSWOT01Dbs.Remove(UHSWOT01Db);
                opa.SaveChanges();
                var response = 1;
                return Json(response, JsonRequestBehavior.AllowGet);
            } else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        // POST: 

        //[ValidateAntiForgeryToken]
        public ActionResult delStep3010002(string id)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && returnTaskOrdersIDlist.Contains(65)))
            {
                UHSWOP01Db UHSWOP01Db = opa.UHSWOP01Dbs.Find(id);
                opa.UHSWOP01Dbs.Remove(UHSWOP01Db);
                opa.SaveChanges();
                var response = 1;
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult delc1010003(string docid)
        {

            string district = opb.UHSVAS01vDbs.Where(s => s.ID == docid).Select(s => s.distnm).First();
            int dater = opb.UHSVAS01vDbs.Where(s => s.ID == docid).Select(s => s.yyyymmdd).First();
            string dated = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dater).Select(s => s.dateID).First();
            int dctpid = opa.UHSVAS01Dbs.Where(s => s.ID == docid).Select(s => s.dctpid).First();

            var data = new
            {
                docid = docid
              , distnm = district
              , crdate = dated
              , dctpid = dctpid
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult del1010005d(string docid)
        {
            string district = opb.UHSOMD01vDbs.Where(s => s.ID == docid).Select(s => s.distnm).First();
            string dater = opb.UHSOMD01vDbs.Where(s => s.ID == docid).Select(s => s.crdate).First();
            int dctpid = opa.UHSOMD01Dbs.Where(s => s.ID == docid).Select(s => s.dctpid).First();
            int tspdid = opa.UHSOMD01Dbs.Where(s => s.ID == docid).Select(s => s.tspdid).First();

            if(dctpid == 1010005 && tspdid == 1)
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "OM-D District Daily Checklist"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }
            else 
                if(dctpid == 1010005 && tspdid == 2)
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "OM-D District Weekly Checklist"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }
            else 
                if(dctpid == 1010005 && tspdid == 3)
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "OM-D District Monthly Checklist"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }
            else 
                if(dctpid == 1010006 && tspdid == 1)
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "OM-D B360 Daily Checklist"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }
            else 
                if(dctpid == 1010006 && tspdid == 2)
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "OM-D B360 Weekly Checklist"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }
            else 
                if(dctpid == 1010006 && tspdid == 3)
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "OM-D B360 Monthly Checklist"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }
            else 
                if(dctpid == 1010006 && tspdid == 4)
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "OM-D B360 Quarterly Checklist"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }
            else 
                if(dctpid == 1010006 && tspdid == 5)
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "OM-D B360 Annual Checklist"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }
            else 
                if(dctpid == 1010007 && tspdid == 1)
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "OM-D A360 Daily Checklist"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }
            else 
                if(dctpid == 1010007 && tspdid == 2)
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "OM-D A360 Weekly Checklist"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }
            else 
                if(dctpid == 1010007 && tspdid == 3)
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "OM-D A360 Monthly Checklist"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }
            else 
                if(dctpid == 1010007 && tspdid == 4)
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "OM-D A360 Quarterly Checklist"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }
            else 
                if(dctpid == 1010007 && tspdid == 5)
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "OM-D A360 Annual Checklist"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }
            else 
            {
                        var data = new
                    {
                        docid = docid
                      , distnm = district
                      , crdate = dater
                      , dctpid = dctpid
                      , dcdesc = "None"
                    };

                    return Json(data, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Equipment()
        {
            ViewBag.ItemSelect = 6;
            return View();
        }
        public ActionResult Reporting()
        {
            ViewBag.ItemSelect = 7;
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult _tableIndexSysAdmClients()
        {           
            var customerDat = from s in dbv.clientsViewDbs where s.ID > 1 select s;
            return PartialView(customerDat.ToList());           
        } 
        public ActionResult getdddiv(int ID)
        {           
            List<int> list1 = new List<int>(opa.DISTRICTSDbs.Where(s => s.compid == 1).Select(s => s.divID ).Distinct());
            var datatable = opb.dimDivisionDbs.Where(s => s.ID == 0 || list1.Contains(s.ID)).ToList();
            return Json(datatable, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getgw6id(int diid)
        {
            string data = opb.UHSWEBAABvDbs.Where(s => s.ID == diid).Select(s => s.GWLID).First();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getgw7id(int diid)
        {
            string data = opb.UHSWEBAABvDbs.Where(s => s.ID == diid).Select(s => s.S6LID).First();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getassid(int diid)
        {
            string data = opb.UHSWEBAABvDbs.Where(s => s.ID == diid).Select(s => s.AASID).First();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult omdusr(int docid)
        {
            // get user logged ID string
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            // get user logged ID int
            int userid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();
            string usernm = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();

            var data = new {
                id = userid
              , nm = usernm

            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult latlngcalc(double lat, double lng)
        {
            System.Diagnostics.Debug.WriteLine(lat);
            System.Diagnostics.Debug.WriteLine(lng);

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

            if (userTypeInt == 2)
            {
                string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procLatLngCalcUtc", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@lat", lat);
                    cmd.Parameters.AddWithValue("@lng", lng);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string docID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(docID);

                    var utc = ddID;
                    return Json(utc, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult sendmailnotif(int diid, string mnt, int tpch)
        {

            var dts = DateTime.Now.ToString("yyyyMMdd");
            int dt1 = int.Parse(dts);
            string date1 = DateTime.Now.ToString("MM/dd/yyyy");

            string disids = opb.UHSWEBAABvDbs.Where(s => s.ID == diid).Select(s => s.dist).First();
            string gwwdudt = opb.UHSWEBAABvDbs.Where(s => s.ID == diid).Select(s => s.dtby1).First();
            string s6wdudt = opb.UHSWEBAABvDbs.Where(s => s.ID == diid).Select(s => s.dtby2).First();

            int gwdl = opb.UHSWEBAABvDbs.Where(s => s.ID == diid).Select(s => s.GWDAY).First();
            int gwwk = opb.UHSWEBAABvDbs.Where(s => s.ID == diid).Select(s => s.GWWEE).First();
            int s6dl = opb.UHSWEBAABvDbs.Where(s => s.ID == diid).Select(s => s.S6DAY).First();
            int s6wk = opb.UHSWEBAABvDbs.Where(s => s.ID == diid).Select(s => s.S6WEE).First();

            string emailToDist = opa.DISTRICTSDbs.Where(s => s.compid == 1 && s.ID == diid).Select(s => s.emailTo).First();

            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;
            string m_userName = "rumunko@gmail.com";
            string m_UserpassWord = "Dowling2000";

            string emailID = emailToDist;
            
            string emailFrom = m_userName;
            string password = m_UserpassWord;
            string emailTo = emailID;

            string usrcomm = "<a style='font-size:12px'>" + mnt + "</a>";

            string incgwd0 = "<tr><td style='color:#367EAD'>Gemba Walk</td><td style='text-align:right'>D:</td><td style='padding-left:4px; color:red'>Due: Today</td></tr>";
            string incgwd1 = "<tr><td style='color:#367EAD'>Gemba Walk</td><td style='text-align:right'>D:</td><td style='padding-left:4px; color:lightseagreen'>Completed</td></tr>";
            string incgww0 = "<tr><td style='color:#367EAD'>Gemba Walk</td><td style='text-align:right'>W:</td><td style='padding-left:4px; color:red'>Due: " + gwwdudt + "</td></tr>";
            string incgww1 = "<tr><td style='color:#367EAD'>Gemba Walk</td><td style='text-align:right'>W:</td><td style='padding-left:4px; color:lightseagreen'>Completed</td></tr>";
            string inc6sd0 = "<tr><td style='color:#367EAD'>6S List</td><td style='text-align:right'>D:</td><td style='padding-left:4px; color:red'>Due: Today</td></tr>";
            string inc6sd1 = "<tr><td style='color:#367EAD'>6S List</td><td style='text-align:right'>D:</td><td style='padding-left:4px; color:lightseagreen'>Completed</td></tr>";
            string inc6sw0 = "<tr><td style='color:#367EAD'>6S List</td><td style='text-align:right'>W:</td><td style='padding-left:4px; color:red'>Due: " + s6wdudt + "</td></tr>";
            string inc6sw1 = "<tr><td style='color:#367EAD'>6S List</td><td style='text-align:right'>W:</td><td style='padding-left:4px; color:lightseagreen'>Completed</td></tr>";

            List<uhspageitemsDb> uhspageitemsDb = new List<uhspageitemsDb>();
            
            if (gwdl == 0 && gwwk == 0 && s6dl == 0 && s6wk == 0)
            {
                string taskslist = incgwd0 + incgww0 + inc6sd0 + inc6sw0;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
            if (gwdl == 1 && gwwk == 0 && s6dl == 0 && s6wk == 0)
            {
                string taskslist = incgwd1 + incgww0 + inc6sd0 + inc6sw0;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
            if (gwdl == 0 && gwwk == 1 && s6dl == 0 && s6wk == 0)
            {
                string taskslist = incgwd0 + incgww1 + inc6sd0 + inc6sw0;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
                if (gwdl == 0 && gwwk == 0 && s6dl == 1 && s6wk == 0)
            {
                string taskslist = incgwd0 + incgww0 + inc6sd1 + inc6sw0;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
                if (gwdl == 0 && gwwk == 0 && s6dl == 0 && s6wk == 1)
            {
                string taskslist = incgwd0 + incgww0 + inc6sd0 + inc6sw1;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
                if (gwdl == 1 && gwwk == 1 && s6dl == 0 && s6wk == 0)
            {
                string taskslist = incgwd1 + incgww1 + inc6sd0 + inc6sw0;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
                if (gwdl == 1 && gwwk == 0 && s6dl == 1 && s6wk == 0)
            {
                string taskslist = incgwd1 + incgww0 + inc6sd1 + inc6sw0;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
                if (gwdl == 1 && gwwk == 0 && s6dl == 0 && s6wk == 1)
            {
                string taskslist = incgwd1 + incgww0 + inc6sd0 + inc6sw1;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
                if (gwdl == 0&& gwwk == 1 && s6dl == 1 && s6wk == 0)
            {
                string taskslist = incgwd0 + incgww1 + inc6sd1 + inc6sw0;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
                if (gwdl == 0 && gwwk == 1 && s6dl == 0 && s6wk == 1)
            {
                string taskslist = incgwd0 + incgww1 + inc6sd0 + inc6sw1;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
                if (gwdl == 0 && gwwk == 0 && s6dl == 1 && s6wk == 1)
            {
                string taskslist = incgwd0 + incgww0 + inc6sd1 + inc6sw1;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
                if (gwdl == 1 && gwwk == 1 && s6dl == 1 && s6wk == 0)
            {
                string taskslist = incgwd1 + incgww1 + inc6sd1 + inc6sw0;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
                if (gwdl == 1 && gwwk == 1 && s6dl == 0 && s6wk == 1)
            {
                string taskslist = incgwd1 + incgww1 + inc6sd0 + inc6sw1;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
                if (gwdl == 1 && gwwk == 0 && s6dl == 1 && s6wk == 1)
            {
                string taskslist = incgwd1 + incgww0 + inc6sd1 + inc6sw1;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
                if (gwdl == 0 && gwwk == 1 && s6dl == 1 && s6wk == 1)
            {
                string taskslist = incgwd0 + incgww1 + inc6sd1 + inc6sw1;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            } else
                if (gwdl == 1 && gwwk == 1 && s6dl == 1 && s6wk == 1)
            {
                string taskslist = incgwd1 + incgww1 + inc6sd1 + inc6sw1;
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = taskslist; uhspageitemsDb.Add(listData);
            }

            var list01 = from s in uhspageitemsDb select s.modStr1;
            string tasklist = list01.First();
            string autcomm = "<div><span style='font-size:12px'><b>Tasks: </b></span></div><table><tbody>" + tasklist + "</tbody></table>";

            List<uhspageitemsDb> listItem1 = new List<uhspageitemsDb>();
            if (mnt == null || mnt == "")
            {
                string usrmsg1 = "";
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = usrmsg1; listItem1.Add(listData);
            } else
                if(mnt != null && mnt != "")
            {
                string usrmsg1 = "<h4><span style='color:darkorange'>Message </span><span style='color:#367EAD'> From User:</span></h4><a style='font-size:14px'>" + mnt + "</a>";
                uhspageitemsDb listData = new uhspageitemsDb(); listData.modStr1 = usrmsg1; listItem1.Add(listData);
            }
            var data01 = from s in listItem1 select s.modStr1;
            string usrcmm = data01.First();


            // Here you can put subject of the mail
            string subject = "UHS VWPS Control System: Notification Message";
            // Body of the mail
            string body = "<div>";
            body += "<h4><span style='color:#367EAD'> UHS </span><span style='color:darkorange'> VWP </span> Standards Control System</h4>";
            body += "<hr />";
            body += "<h4 style='color:#367EAD'>VWP Control System Server:</h4>";
            body += "<h4 style='color:gray'>This is an Automated <span style='color: darkorange'> Notification </span> Message. Do not reply!</h4>";
            body += "<br />";
            body += "<div><span style='color:#367EAD'>To: </span><b> " + disids + " </b></div>";
            body += "<div><span style='color:#367EAD'>Date: </span><b> " + date1 + " </b></div>";
            body += "<h4><span style='color:darkorange'>Message </span><span style='color:#367EAD'> Content:</span></h4>";
            body += autcomm;
            body += usrcmm;
            body += "<br><br /><br />";
            body += "Thank You.";
            body += "<hr />";
            body += "<div><span style='font-size:smaller; color:lightgray'>Disclaimer: </span><span style='font-size:smaller; color:lightblue'> This automated e-mail message is confidential and may also be legally privileged. If you are not the intended recipient please delete the e-mail and do not disclose its contents to any person. Any unauthorized review, use, disclosure, copying or distribution is strictly prohibited.</span></div>";
            body += "</div>";
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

        public ActionResult testexec()
        {
            string data = "Success";
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getIP()
        {
            string clientIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1].ToString();
            return Json(clientIp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult sendNotif()
        {
            const int PORT_NO = 5000;
            const string SERVER_IP = "172.16.154.6";

            //---data to send to the server---
            string textToSend = DateTime.Now.ToString();

            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            //---send the text---
            Console.WriteLine("Sending : " + textToSend);
            nwStream.Write(bytesToSend, 0, bytesToSend.Length);

            //---read back the text---
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = nwStream.Read(bytesToRead, 0, client.ReceiveBufferSize);
            Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, bytesRead));
            Console.ReadLine();
            client.Close();

            return View();
        }

        public ActionResult UploadFile1(HttpPostedFileBase file)
        {
            //string path = Server.MapPath("~/upload/uplCadence/" + file.FileName);
            //file.SaveAs(path);
           
            return Json(1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ExportToExcel()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.Single();

            var grid = new GridView();
            var ExportList = from p in dbv.k2017orgStrSubGrViewDbs
                             where p.createdByUserID == CurrentLoginID || usID102 == 2
                             select p;

            grid.DataSource = ExportList.ToList();

            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Export_TRIZMA_ORGADM_OrgStructure_SubGroup.xls");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index", "k2017orgStrSubGr", new { projectID = 10, taskOrderID = 48, Int1 = 1 });
        }


    }
}
