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
using System.Web.WebPages;

namespace TRIZMA.Controllers
{
    public class uhsworktaskController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();

        public ActionResult Index(int projectID, int taskOrderID, int Int1)
        {
            //System.Diagnostics.Debug.WriteLine("test over date");
            
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
            int dis = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.distid).First();
            int week = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.WNumber).First();
            int daynbr = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.daywnm).First();
            List<int> agentP = new List<int>(db.agentsProjDistDbs.OrderBy(c => c.ID).Where(c => c.userID == CurrentLoginID && c.projectID != 6 && c.projectID != 7).Select(c => c.projectID).ToList());

            var ch01 = opb.UHSUSAC1A360Dbs.Where(s => s.MGRID == userIDselectInt).Count();
            var ch02 = opb.UHSUSAC1B360Dbs.Where(s => s.MGRID == userIDselectInt).Count();
            var ch03 = opb.UHSUSAC1DISTRICTDbs.Where(s => s.MGRID == userIDselectInt).Count();
            var ch04 = opb.UHSUSAC1SURSERVDbs.Where(s => s.MGRID == userIDselectInt).Count();
            var ch05 = opb.UHSUSAC1COEDbs.Where(s => s.MGRID == userIDselectInt).Count();

            ViewBag.preAgentT = db.agentsTODistDbs.Where(c => c.userID == CurrentLoginID && (((c.taskOrderID == 52 || c.taskOrderID == 53) && ch03 >= 1)
                                                                                          || (c.taskOrderID == 55 && ch01 >= 1)
                                                                                          || (c.taskOrderID == 56 && ch02 >= 1)
                                                                                          || (c.taskOrderID == 57 && ch04 >= 1)
                                                                                          || (c.taskOrderID == 58 && ch05 >= 1))).Select(c => new { ID = c.taskOrderID }).ToList();
            ViewBag.daynbr = daynbr;
            
            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13) && returnTaskOrdersIDlist.Contains(65)))
            {
                
                List<uhspageitemsDb> pageModel = new List<uhspageitemsDb>();

                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procUHSWOT01refresh", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    

                    cmd.Parameters.AddWithValue("@IDT", userIDselectInt);
                    cmd.Parameters.AddWithValue("@IDC", 1);
                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string resp = outputParameter.Value.ToString();
                    int res = Int32.Parse(resp);

                    uhspageitemsDb List1 = new uhspageitemsDb();
                    List1.modInt01 = res;
                    pageModel.Add(List1);

                    con.Close();
                }

                int respint = pageModel.Select(s => s.modInt01).First();
                
                if (respint == 1)
                {
                    ViewBag.userID = userIDselectInt;
                    ViewBag.dat = 0;
                    ViewBag.wek = 0;
                    ViewBag.per = 0;
                    ViewBag.dis = dis;
                    ViewBag.act = 0;
                    ViewBag.dcg = 0;
                    ViewBag.dct = 0;

                    var data1 = opb.UHSWOT01vDbs.Where(s => userTypeInt == 2 || s.crusid == userIDselectInt).ToList();
                    ViewBag.pageData = data1;
                    
                    ViewBag.btnSel = 1;
                    return View();
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }              
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult proba(int tskoid, int L3IDc, string docmid)
        {
            var dts = docmid;
            return Json(dts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult insertDoc(int tskoid, int L3IDc, int dat, int wek, int per, int dis, int act, int dcg, int dct, string IDR)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13) && returnTaskOrdersIDlist.Contains(65)))
            {
                var dts = DateTime.Now.ToString("yyyyMMddHHMMss");
                var newIDb = dts + "DC3010001TO" + tskoid + "DS" + dis + "AC" + act + "US" + userIDselectInt;
                var newID = newIDb + "," + IDR;

                

                List<uhspageitemsDb> pageModel = new List<uhspageitemsDb>();
               
                ViewBag.dat = dat;
                ViewBag.wek = wek;
                ViewBag.per = per;
                ViewBag.dis = dis;
                ViewBag.act = act;
                ViewBag.dcg = dcg;
                ViewBag.dct = dct;

                //System.Diagnostics.Trace.WriteLine(newID);

                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {   
                    SqlCommand cmd = new SqlCommand("procUHSWOT01insert", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDa", newID);
                    cmd.Parameters.AddWithValue("@userid", userIDselectInt);
                    cmd.Parameters.AddWithValue("@L3ID", L3IDc);
                    cmd.Parameters.AddWithValue("@dat", dat);
                    cmd.Parameters.AddWithValue("@wek", wek);
                    cmd.Parameters.AddWithValue("@per", per);
                    cmd.Parameters.AddWithValue("@dis", dis);
                    cmd.Parameters.AddWithValue("@act", act);
                    cmd.Parameters.AddWithValue("@dcg", dcg);
                    cmd.Parameters.AddWithValue("@dct", dct);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string resp = outputParameter.Value.ToString();
                    int res = Int32.Parse(resp);
                   
                    uhspageitemsDb List1 = new uhspageitemsDb();
                    List1.modInt01 = res;
                    pageModel.Add(List1);

                    con.Close();
                }

                int respint = pageModel.Select(s => s.modInt01).First();

               

                if (respint == 1)
                {
                    var response = newIDb;
                    return Json(response, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    var response = 3;
                    return Json(response, JsonRequestBehavior.AllowGet);
                }   
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult WorkTask(string ID, int IDK, int IDF)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13) && returnTaskOrdersIDlist.Contains(65)))
            {

                List<uhspageitemsDb> pageModel = new List<uhspageitemsDb>();
                //System.Diagnostics.Trace.WriteLine("whatever ho ho ho");
                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procUHSWOT01refresh", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDT", ID);
                    cmd.Parameters.AddWithValue("@IDC", 2);
                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string resp = outputParameter.Value.ToString();
                    int res = Int32.Parse(resp);

                    uhspageitemsDb List1 = new uhspageitemsDb();
                    List1.modInt01 = res;
                    pageModel.Add(List1);

                    con.Close();
                }

                int respint = pageModel.Select(s => s.modInt01).First();
                
                if (respint == 1)
                {
                    var tskoid = opb.UHSWOT01vDbs.Where(s => s.ID == ID).Select(s => s.eXtskoid).First();
                    var distid = opb.UHSWOT01vDbs.Where(s => s.ID == ID).Select(s => s.distid).First();
                    var acctid = opb.UHSWOT01vDbs.Where(s => s.ID == ID).Select(s => s.acctid).First();
                    
                    if (tskoid == 0)
                    {
                        ViewBag.tskoid = IDK;

                        if(IDK == 52)
                        {
                            ViewBag.mode = opb.UHSinquriesDbs.Where(s => s.tskoid == IDK).Select(s => new { tskoid = s.tskoid, taskOrder = s.taskOrder }).Distinct();
                            ViewBag.task = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS }).Distinct();
                            ViewBag.tasg = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).OrderBy(s => s.ID).Select(s => new { L1ID = s.L1ID, L2ID = s.L2ID, L2DS = s.L2DS }).Distinct();
                            ViewBag.inquries = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).Select(s => new { ID = s.ID, tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS, L2ID = s.L2ID, L2DS = s.L2DS, L3DS = s.L3DS, taskOrder = s.taskOrder }).OrderBy(s => s.ID);
                            List<int> dis1 = opb.UHSUSAC1DISTRICTDbs.Where(s => s.MGRID == userIDselectInt)
                                                                        .Select(s => s.DISTID)
                                                                        .ToList();
                            ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == 0 || dis1.Contains(s.ID)).OrderBy(s => s.ID);

                        }
                        else if (IDK == 53 || IDK == 57 || IDK == 58)
                        {
                            ViewBag.mode = opb.UHSinquriesDbs.Where(s => s.tskoid == IDK).Select(s => new { tskoid = s.tskoid, taskOrder = s.taskOrder }).Distinct();
                            ViewBag.task = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS }).Distinct();
                            ViewBag.inquries = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).Select(s => new { ID = s.ID, tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS, L2ID = s.L2ID, L2DS = s.L2DS, L3DS = s.L3DS, taskOrder = s.taskOrder }).OrderBy(s => s.ID);

                            if(IDK == 53)
                            {
                                List<int> dis1 = opb.UHSUSAC1DISTRICTDbs.Where(s => s.MGRID == userIDselectInt)
                                                                        .Select(s => s.DISTID)
                                                                        .ToList();
                                ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == 0 || dis1.Contains(s.ID)).OrderBy(s => s.ID);
                            }
                            else if(IDK == 57)
                            {
                                List<int> dis1 = opb.UHSUSAC1SURSERVDbs.Where(s => s.MGRID == userIDselectInt)
                                                                           .Select(s => s.DISTID)
                                                                           .ToList();
                                ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == 0 || dis1.Contains(s.ID)).OrderBy(s => s.ID);

                            }
                            else if (IDK == 58)
                            {
                                List<int> dis1 = opb.UHSUSAC1COEDbs.Where(s => s.MGRID == userIDselectInt)
                                                                           .Select(s => s.DISTID)
                                                                           .ToList();
                                ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == 0 || dis1.Contains(s.ID)).OrderBy(s => s.ID);
                            }
                        }
                        else if (IDK == 55 || IDK == 56)
                        {
                            ViewBag.mode = opb.UHSinquriesDbs.Where(s => s.tskoid == IDK).Select(s => new { tskoid = s.tskoid, taskOrder = s.taskOrder }).Distinct();
                            ViewBag.task = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS }).Distinct();
                            ViewBag.inquries = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).Select(s => new { ID = s.ID, tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS, L2ID = s.L2ID, L2DS = s.L2DS, L3DS = s.L3DS, taskOrder = s.taskOrder }).OrderBy(s => s.ID);

                            if(IDK == 55)
                            {
                                List<int> acc1 = opb.UHSUSAC1A360Dbs.Where(s => s.MGRID == userIDselectInt)
                                                                           .Select(s => s.IDc)
                                                                           .ToList();
                                List<int> dis2 = opa.UHSACCTSDbs.Where(s => s.typeid == 1 && acc1.Contains(s.IDc))
                                                                           .Select(s => s.DISTID)
                                                                           .Distinct()
                                                                           .ToList();
                                ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == 0 || dis2.Contains(s.ID)).OrderBy(s => s.ID);
                                ViewBag.accts = opa.UHSACCTSDbs.Where(s => acc1.Contains(s.IDc)).OrderBy(s => s.IDc).Select(s => new { DISTID = s.DISTID, IDc = s.IDc, CSTNM = s.CSTNM }).Distinct();
                            }
                            else if (IDK == 56)
                            {
                                List<int> acc1 = opb.UHSUSAC1B360Dbs.Where(s => s.MGRID == userIDselectInt)
                                                                           .Select(s => s.IDc)
                                                                           .ToList();
                                List<int> dis2 = opa.UHSACCTSDbs.Where(s => s.typeid == 2 && acc1.Contains(s.IDc))
                                                                           .Select(s => s.DISTID)
                                                                           .Distinct()
                                                                           .ToList();
                                ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == 0 || dis2.Contains(s.ID)).OrderBy(s => s.ID);
                                ViewBag.accts = opa.UHSACCTSDbs.Where(s => acc1.Contains(s.IDc)).OrderBy(s => s.IDc).Select(s => new { DISTID = s.DISTID, IDc = s.IDc, CSTNM = s.CSTNM }).Distinct();
                            }
                        }
                    }
                    else if(tskoid == 52)
                    {
                        ViewBag.tskoid = tskoid;
                        ViewBag.mode = new SelectList(opb.UHSinquriesDbs.Where(s => s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, taskOrder = s.taskOrder }).Distinct(), "tskoid", "taskOrder");
                        ViewBag.task = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS }).Distinct();
                        ViewBag.tasg = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { L1ID = s.L1ID, L2ID = s.L2ID, L2DS = s.L2DS }).Distinct();
                        ViewBag.inquries = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == tskoid).Select(s => new { ID = s.ID, tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS, L2ID = s.L2ID, L2DS = s.L2DS, L3DS = s.L3DS, taskOrder = s.taskOrder }).OrderBy(s => s.ID);
                        ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == distid).OrderBy(s => s.ID);
                    }
                    else if (tskoid == 53 || tskoid == 57 || tskoid == 58)
                    {
                        ViewBag.tskoid = tskoid;
                        ViewBag.mode = opb.UHSinquriesDbs.Where(s => s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, taskOrder = s.taskOrder }).Distinct();
                        ViewBag.task = opb.UHSinquriesDbs.Where(s => s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { L1ID = s.L1ID, L1DS = s.L1DS }).Distinct();
                        ViewBag.inquries = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == tskoid).Select(s => new { ID = s.ID, tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS, L2ID = s.L2ID, L2DS = s.L2DS, L3DS = s.L3DS, taskOrder = s.taskOrder }).OrderBy(s => s.ID);
                        ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == distid).OrderBy(s => s.ID);
                    }
                    else if (tskoid == 55 || tskoid == 56)
                    {
                        ViewBag.tskoid = tskoid;
                        ViewBag.mode = opb.UHSinquriesDbs.Where(s => s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, taskOrder = s.taskOrder }).Distinct();
                        ViewBag.task = opb.UHSinquriesDbs.Where(s => s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { L1ID = s.L1ID, L1DS = s.L1DS }).Distinct();
                        ViewBag.inquries = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == tskoid).Select(s => new { ID = s.ID, tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS, L2ID = s.L2ID, L2DS = s.L2DS, L3DS = s.L3DS, taskOrder = s.taskOrder }).OrderBy(s => s.ID);
                        ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == distid).OrderBy(s => s.ID);
                        ViewBag.accts = opb.UHSdimCustomerDropDownDbs.Where(s => s.ID == acctid).OrderBy(s => s.ID);
                    }

                    var data1 = opb.UHSWOT01vDbs.Where(s => s.ID == ID).ToList();
                    ViewBag.pageData = data1;

                    ViewBag.mnth = data1.Select(s => s.yyyymm).First();
                    ViewBag.crdate = data1.Select(s => s.crdate).First();
                    ViewBag.datest = data1.Select(s => s.datest).First();
                    ViewBag.dateex = data1.Select(s => s.dateex).First();
                    ViewBag.comboDistrict = data1.Select(s => s.distnm).First();
                    ViewBag.IDK = IDK;
                    ViewBag.distid = data1.Select(s => s.distid).First();
                    ViewBag.docmid = null;
                    ViewBag.dimgid = 0;
                    ViewBag.userID = userIDselectInt;
                    ViewBag.docID = ID;
                    ViewBag.stepTable = opb.UHSWOP01vDbs.Where(c => c.IDT == ID);
                    ViewBag.cntSteps = data1.Select(s => s.tskcnt).First();
                    ViewBag.IDF = IDF;
                    return View();
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult mainTest()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            string userName = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();
            ViewBag.userName = userName;

            return View();
        }

        public ActionResult athreeform(string ID, int IDK)
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



            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13) && returnTaskOrdersIDlist.Contains(65)))
            {

                List<uhspageitemsDb> pageModel = new List<uhspageitemsDb>();

                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procUHSWOT01refresh", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDT", ID);
                    cmd.Parameters.AddWithValue("@IDC", 2);
                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string resp = outputParameter.Value.ToString();
                    int res = Int32.Parse(resp);

                    uhspageitemsDb List1 = new uhspageitemsDb();
                    List1.modInt01 = res;
                    pageModel.Add(List1);

                    con.Close();
                }

                int respint = pageModel.Select(s => s.modInt01).First();

                if (respint == 1)
                {
                    var tskoid = opb.UHSWOT01vDbs.Where(s => s.ID == ID).Select(s => s.eXtskoid).First();
                    var distid = opb.UHSWOT01vDbs.Where(s => s.ID == ID).Select(s => s.distid).First();
                    var acctid = opb.UHSWOT01vDbs.Where(s => s.ID == ID).Select(s => s.acctid).First();

                    if (tskoid == 0)
                    {
                        ViewBag.tskoid = IDK;

                        if (IDK == 52)
                        {
                            ViewBag.mode = opb.UHSinquriesDbs.Where(s => s.tskoid == IDK).Select(s => new { tskoid = s.tskoid, taskOrder = s.taskOrder }).Distinct();
                            ViewBag.task = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS }).Distinct();
                            ViewBag.tasg = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).OrderBy(s => s.ID).Select(s => new { L1ID = s.L1ID, L2ID = s.L2ID, L2DS = s.L2DS }).Distinct();
                            ViewBag.inquries = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).Select(s => new { ID = s.ID, tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS, L2ID = s.L2ID, L2DS = s.L2DS, L3DS = s.L3DS, taskOrder = s.taskOrder }).OrderBy(s => s.ID);
                            List<int> dis1 = opb.UHSUSAC1DISTRICTDbs.Where(s => s.MGRID == userIDselectInt)
                                                                        .Select(s => s.DISTID)
                                                                        .ToList();
                            ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == 0 || dis1.Contains(s.ID)).OrderBy(s => s.ID);

                        }
                        else if (IDK == 53 || IDK == 57 || IDK == 58)
                        {
                            ViewBag.mode = opb.UHSinquriesDbs.Where(s => s.tskoid == IDK).Select(s => new { tskoid = s.tskoid, taskOrder = s.taskOrder }).Distinct();
                            ViewBag.task = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS }).Distinct();
                            ViewBag.inquries = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).Select(s => new { ID = s.ID, tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS, L2ID = s.L2ID, L2DS = s.L2DS, L3DS = s.L3DS, taskOrder = s.taskOrder }).OrderBy(s => s.ID);

                            if (IDK == 53)
                            {
                                List<int> dis1 = opb.UHSUSAC1DISTRICTDbs.Where(s => s.MGRID == userIDselectInt)
                                                                        .Select(s => s.DISTID)
                                                                        .ToList();
                                ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == 0 || dis1.Contains(s.ID)).OrderBy(s => s.ID);
                            }
                            else if (IDK == 57)
                            {
                                List<int> dis1 = opb.UHSUSAC1SURSERVDbs.Where(s => s.MGRID == userIDselectInt)
                                                                           .Select(s => s.DISTID)
                                                                           .ToList();
                                ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == 0 || dis1.Contains(s.ID)).OrderBy(s => s.ID);

                            }
                            else if (IDK == 58)
                            {
                                List<int> dis1 = opb.UHSUSAC1COEDbs.Where(s => s.MGRID == userIDselectInt)
                                                                           .Select(s => s.DISTID)
                                                                           .ToList();
                                ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == 0 || dis1.Contains(s.ID)).OrderBy(s => s.ID);
                            }
                        }
                        else if (IDK == 55 || IDK == 56)
                        {
                            ViewBag.mode = opb.UHSinquriesDbs.Where(s => s.tskoid == IDK).Select(s => new { tskoid = s.tskoid, taskOrder = s.taskOrder }).Distinct();
                            ViewBag.task = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS }).Distinct();
                            ViewBag.inquries = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == IDK).Select(s => new { ID = s.ID, tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS, L2ID = s.L2ID, L2DS = s.L2DS, L3DS = s.L3DS, taskOrder = s.taskOrder }).OrderBy(s => s.ID);

                            if (IDK == 55)
                            {
                                List<int> acc1 = opb.UHSUSAC1A360Dbs.Where(s => s.MGRID == userIDselectInt)
                                                                           .Select(s => s.IDc)
                                                                           .ToList();
                                List<int> dis2 = opa.UHSACCTSDbs.Where(s => s.typeid == 1 && acc1.Contains(s.IDc))
                                                                           .Select(s => s.DISTID)
                                                                           .Distinct()
                                                                           .ToList();
                                ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == 0 || dis2.Contains(s.ID)).OrderBy(s => s.ID);
                                ViewBag.accts = opa.UHSACCTSDbs.Where(s => acc1.Contains(s.IDc)).OrderBy(s => s.IDc).Select(s => new { DISTID = s.DISTID, IDc = s.IDc, CSTNM = s.CSTNM }).Distinct();
                            }
                            else if (IDK == 56)
                            {
                                List<int> acc1 = opb.UHSUSAC1B360Dbs.Where(s => s.MGRID == userIDselectInt)
                                                                           .Select(s => s.IDc)
                                                                           .ToList();
                                List<int> dis2 = opa.UHSACCTSDbs.Where(s => s.typeid == 2 && acc1.Contains(s.IDc))
                                                                           .Select(s => s.DISTID)
                                                                           .Distinct()
                                                                           .ToList();
                                ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == 0 || dis2.Contains(s.ID)).OrderBy(s => s.ID);
                                ViewBag.accts = opa.UHSACCTSDbs.Where(s => acc1.Contains(s.IDc)).OrderBy(s => s.IDc).Select(s => new { DISTID = s.DISTID, IDc = s.IDc, CSTNM = s.CSTNM }).Distinct();
                            }
                        }
                    }
                    else if (tskoid == 52)
                    {
                        ViewBag.tskoid = tskoid;
                        ViewBag.mode = new SelectList(opb.UHSinquriesDbs.Where(s => s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, taskOrder = s.taskOrder }).Distinct(), "tskoid", "taskOrder");
                        ViewBag.task = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS }).Distinct();
                        ViewBag.tasg = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { L1ID = s.L1ID, L2ID = s.L2ID, L2DS = s.L2DS }).Distinct();
                        ViewBag.inquries = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == tskoid).Select(s => new { ID = s.ID, tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS, L2ID = s.L2ID, L2DS = s.L2DS, L3DS = s.L3DS, taskOrder = s.taskOrder }).OrderBy(s => s.ID);
                        ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == distid).OrderBy(s => s.ID);
                    }
                    else if (tskoid == 53 || tskoid == 57 || tskoid == 58)
                    {
                        ViewBag.tskoid = tskoid;
                        ViewBag.mode = opb.UHSinquriesDbs.Where(s => s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, taskOrder = s.taskOrder }).Distinct();
                        ViewBag.task = opb.UHSinquriesDbs.Where(s => s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { L1ID = s.L1ID, L1DS = s.L1DS }).Distinct();
                        ViewBag.inquries = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == tskoid).Select(s => new { ID = s.ID, tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS, L2ID = s.L2ID, L2DS = s.L2DS, L3DS = s.L3DS, taskOrder = s.taskOrder }).OrderBy(s => s.ID);
                        ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == distid).OrderBy(s => s.ID);
                    }
                    else if (tskoid == 55 || tskoid == 56)
                    {
                        ViewBag.tskoid = tskoid;
                        ViewBag.mode = opb.UHSinquriesDbs.Where(s => s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { tskoid = s.tskoid, taskOrder = s.taskOrder }).Distinct();
                        ViewBag.task = opb.UHSinquriesDbs.Where(s => s.tskoid == tskoid).OrderBy(s => s.ID).Select(s => new { L1ID = s.L1ID, L1DS = s.L1DS }).Distinct();
                        ViewBag.inquries = opb.UHSinquriesDbs.Where(s => s.ID == 0 || s.tskoid == tskoid).Select(s => new { ID = s.ID, tskoid = s.tskoid, L1ID = s.L1ID, L1DS = s.L1DS, L2ID = s.L2ID, L2DS = s.L2DS, L3DS = s.L3DS, taskOrder = s.taskOrder }).OrderBy(s => s.ID);
                        ViewBag.districts = opb.UHSDISTDP1Dbs.Where(s => s.ID == distid).OrderBy(s => s.ID);
                        ViewBag.accts = opb.UHSdimCustomerDropDownDbs.Where(s => s.ID == acctid).OrderBy(s => s.ID);
                    }

                    var data1 = opb.UHSWOT01vDbs.Where(s => s.ID == ID).ToList();
                    ViewBag.pageData = data1;

                    ViewBag.mnth = data1.Select(s => s.yyyymm).First();
                    ViewBag.crdate = data1.Select(s => s.crdate).First();
                    ViewBag.comboDistrict = data1.Select(s => s.distnm).First();
                    ViewBag.IDK = IDK;
                    ViewBag.distid = opb.UHSWOT01vDbs.Where(s => s.ID == ID).Select(s => s.distid).First();
                    ViewBag.docmid = null;
                    ViewBag.dimgid = 0;
                    ViewBag.userID = userIDselectInt;
                    ViewBag.userTypeID = userTypeInt;
                    ViewBag.docID = ID;
                    ViewBag.svctr = 1;
                    ViewBag.stepTable = opb.UHSWOP01vDbs.Where(c => c.IDT == ID);
                    ViewBag.cntSteps = opb.UHSWOT01vDbs.Where(s => s.ID == ID).Select(s => s.tskcnt).First();
                    return View();
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
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
