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
using Antlr.Runtime.Misc;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Web.Script.Serialization;

namespace TRIZMA.Controllers
{
    public class formsCRUDController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();

        // GET: Web Structure - Side Bar Menu - Drop down class

        public ActionResult _sidebarDropDownMenu()
        {
            return PartialView("_sidebarDropDownMenu");
        }

        public ActionResult SBagPr()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            var userIDSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;           
            int userIDInt = userIDSelect.First();

            var agentP = db.agentsProjDistDbs.OrderBy(c => c.projectName).Where(c => c.userID == CurrentLoginID && c.projectID != 7).ToList();
            return PartialView("_SBagPr", agentP);
        }

        public ActionResult SBagTo(int id)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            var preAgentT = db.agentsTODistDbs.Where(c => c.userID == CurrentLoginID);
            var agentT = preAgentT.OrderBy(s => s.taskOrder).Where(c => c.projectID == id).ToList();

            ViewBag.projectID = id;
            return PartialView("_SBagTo", agentT);
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

        public ActionResult _upperLeftHeader()
        {
            return PartialView("_upperLeftHeader");
        }


        public ActionResult _sidebarFooter()
        {          
            return PartialView("_sidebarFooter");
        }

        public ActionResult _upperRightMenu()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var Item10 = from m in db.agentsDbs where m.userID == CurrentLoginID select m.agentName;
            string ItemID200 = Item10.Single();
            ViewBag.ItemUN = ItemID200;
            return PartialView("_upperRightMenu");
        }

        public ActionResult _upperMessages()
        {
            return PartialView("_upperMessages");
        }

        public ActionResult _upperProfile()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var Item10 = from m in db.agentsDbs where m.userID == CurrentLoginID select m.agentName;
            string ItemID200 = Item10.Single();
            ViewBag.ItemUN2 = ItemID200;
            ViewBag.photoID = CurrentLoginID + ".jpg";
            return PartialView("_upperProfile");
        }

        public ActionResult _upperBaseMenu()
        {
            return PartialView("_upperBaseMenu");
        }

        // GET: formsCRUD
        // Index section - return projectID , taskOrderID, and other IDs for Index page selection
        public ActionResult Index(int projectID, int taskOrderID, int Int1)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.First();

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.projectID)
                             .ToList();

            List<int> returnTaskOrdersIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.taskOrderID)
                             .ToList();

            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            // Index Main
            if (projectID == 1 && taskOrderID == 1 && CurrentLoginID == User.Identity.GetUserId().ToString() && userTypeInt == 2)
            {
                return RedirectToAction("IndexMain", "formsCRUD", new { projectID = projectID, taskOrderID = taskOrderID, Int1 = Int1 });
            }

            // Index k2017bsh1
            if (projectID == 5 && taskOrderID == 13
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(5)
                                                 && returnTaskOrdersIDlist.Contains(13))
            {
                return RedirectToAction("Index", "k2017bsh1", new { projectID = 5, taskOrderID = 13, Int1 = Int1 });
            }

            // Index Clients
            if (projectID == 6 && taskOrderID == 20
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(20))
            {
                return RedirectToAction("Index", "clients", new { projectID = 6, taskOrderID = 20, Int1 = Int1 });
            }           

            // Index Projects
            if (projectID == 6 && taskOrderID == 21
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(21))
            {
                return RedirectToAction("Index", "clientsProjects", new { projectID = 6, taskOrderID = 21, Int1 = Int1 });
            }

            // Index Task Orders
            if (projectID == 6 && taskOrderID == 22
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(22))
            {
                return RedirectToAction("Index", "taskOrders", new { projectID = 6, taskOrderID = 22, Int1 = Int1 });
            }

            // Index Task Orders Countries
            if (projectID == 6 && taskOrderID == 23
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(23))
            {
                return RedirectToAction("Index", "taskOrdersCountry", new { projectID = 6, taskOrderID = 23, Int1 = Int1 });
            }

            // Index Task Orders Inquries
            if (projectID == 6 && taskOrderID == 24
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(24))
            {
                return RedirectToAction("Index", "toInquries", new { projectID = 6, taskOrderID = 24, Int1 = Int1 });
            }

            // Index Task Orders Languages
            if (projectID == 6 && taskOrderID == 25
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(25))
            {
                return RedirectToAction("Index", "toInquriesLang", new { projectID = 6, taskOrderID = 25, Int1 = Int1 });
            }

            if (projectID == 6 && taskOrderID == 26
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(26))
            {
                return RedirectToAction("Index", "toInquriesChanel", new { projectID = 6, taskOrderID = 26, Int1 = Int1 });
            }

            if (projectID == 6 && taskOrderID == 27
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(27))
            {
                return RedirectToAction("Index", "toInquriesForward", new { projectID = 6, taskOrderID = 27, Int1 = Int1 });
            }

            if (projectID == 6 && taskOrderID == 28
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(28))
            {
                return RedirectToAction("Index", "toInquriesProducts", new { projectID = 6, taskOrderID = 28, Int1 = Int1 });
            }

            // Index FTP Folders
            if (projectID == 6 && taskOrderID == 29
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(29))
            {
                return RedirectToAction("Index", "ftpPrefixDate", new { projectID = 6, taskOrderID = 29, Int1 = Int1 });
            }

            // Index Call Class Type
            if (projectID == 6 && taskOrderID == 30
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(30))
            {
                return RedirectToAction("Index", "callClassType", new { projectID = 6, taskOrderID = 30, Int1 = Int1 });
            }

            // Index Call Status
            if (projectID == 6 && taskOrderID == 31
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(31))
            {
                return RedirectToAction("Index", "callStatus", new { projectID = 6, taskOrderID = 31, Int1 = Int1 });
            }

            // Index Connection Type
            if (projectID == 6 && taskOrderID == 32
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(32))
            {
                return RedirectToAction("Index", "connType", new { projectID = 6, taskOrderID = 32, Int1 = Int1 });
            }

            // Index C.E.R.
            if (projectID == 6 && taskOrderID == 33
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(33))
            {
                return RedirectToAction("Index", "agents", new { projectID = 6, taskOrderID = 33, Int1 = Int1 });
            }

            // Index C.E.R. Task Orders
            if (projectID == 6 && taskOrderID == 34
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(34))
            {
                return RedirectToAction("Index", "agentsTaskOrders", new { projectID = 6, taskOrderID = 34, Int1 = Int1 });
            }

            // 
            if (projectID == 6 && taskOrderID == 61
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(61))
            {
                return RedirectToAction("Index", "uhsuserA360", new { projectID = 6, taskOrderID = 61, Int1 = Int1 });
            }
            if (projectID == 6 && taskOrderID == 63
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(6)
                                                 && returnTaskOrdersIDlist.Contains(63))
            {
                return RedirectToAction("IndexA360", "uhslocations", new { projectID = 6, taskOrderID = 63, Int1 = Int1 });
            }
            // Index Coca Cola 2
            if (projectID == 5 && taskOrderID == 35
                                                 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                                 && returnProjectIDlist.Contains(5)
                                                 && returnTaskOrdersIDlist.Contains(35))
            {
                return RedirectToAction("Index", "k2017smpCocaCola3", new { projectID = 5, taskOrderID = 35, Int1 = Int1 });
            }

            // Index k2017cscemb1 USA embasy
            if (projectID == 2 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(2))
            {
                return RedirectToAction("Index", "k2017cscemb1", new { projectID = 2, taskOrderID = 1, Int1 = Int1 });
            }


            // Index k2017cscemb2 AUS embasy
            if (projectID == 4 && taskOrderID == 12
                               && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(4) 
                               && returnTaskOrdersIDlist.Contains(12))
            {
                return RedirectToAction("Index", "k2017cscemb2", new { projectID = 4, taskOrderID = 12, Int1 = Int1 });
            }

            // Index k2017smpMetro1 
            if (projectID == 5 && taskOrderID == 14
                               && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(5)
                               && returnTaskOrdersIDlist.Contains(14))
            {
                return RedirectToAction("Index", "k2017smpMetro1", new { projectID = 5, taskOrderID = 14, Int1 = Int1 });
            }

            // Index k2017smpLukoil1 
            if (projectID == 5 && taskOrderID == 15
                               && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(5)
                               && returnTaskOrdersIDlist.Contains(15))
            {
                return RedirectToAction("Index", "k2017smpLukoil1", new { projectID = 5, taskOrderID = 15, Int1 = Int1 });
            }

            // Index k2017smpDhl1 
            if (projectID == 5 && taskOrderID == 17
                               && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(5)
                               && returnTaskOrdersIDlist.Contains(17))
            {
                return RedirectToAction("Index", "k2017smpDhl1", new { projectID = 5, taskOrderID = 17, Int1 = Int1 });
            }

            // Index k2017smpOmv1 
            if (projectID == 5 && taskOrderID == 18
                               && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(5)
                               && returnTaskOrdersIDlist.Contains(18))
            {
                return RedirectToAction("Index", "k2017smpOmv1", new { projectID = 5, taskOrderID = 18, Int1 = Int1 });
            }

            // Index k2017smpImlek1 
            if (projectID == 5 && taskOrderID == 19
                               && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(5)
                               && returnTaskOrdersIDlist.Contains(19))
            {
                return RedirectToAction("Index", "k2017smpImlek1", new { projectID = 5, taskOrderID = 19, Int1 = Int1 });
            }

            // Index REPORTING Centar by Task Orders 
            if (projectID == 7 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(7)
                               && returnTaskOrdersIDlist.Contains(36)
                               && taskOrderID == 36)
            {
                return RedirectToAction("reportingcercc", "formsCRUD", new { projectID = 7, taskOrderID = 36, Int1 = Int1 });
            }


            // Index EVALUATION of CER 
            if (projectID == 8 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(8)
                               && returnTaskOrdersIDlist.Contains(37)
                               && taskOrderID == 37)
            {
                return RedirectToAction("Index", "k2017evalcercc", new { projectID = 8, taskOrderID = 37, Int1 = Int1 });
            }

            // Index Organization Administration - Structure 
            if (projectID == 10 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(10)
                               && returnTaskOrdersIDlist.Contains(41)
                               && taskOrderID == 41)
            {
                return RedirectToAction("Index", "k2017orgAdmStructure", new { projectID = 10, taskOrderID = 41, Int1 = Int1 });
            }

            // Index Organization Administration - Sub Groups 
            if (projectID == 10 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(10)
                               && returnTaskOrdersIDlist.Contains(48)
                               && taskOrderID == 48)
            {
                return RedirectToAction("Index", "k2017orgStrSubGr", new { projectID = 10, taskOrderID = 48, Int1 = Int1 });
            }

            // Employee - My Dashboard 
            if (projectID == 9 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(9)
                               && returnTaskOrdersIDlist.Contains(47)
                               && taskOrderID == 47)
            {
                var ItemR1 = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();
                int ItemT1 = ItemR1;
                return RedirectToAction("Index", "k2017evalcerOverView", new { projectID = 9, taskOrderID = 47, Int1 = Int1, Int2 = ItemT1, Int3 = 2 });
            }

            // Index Work Schedule 
            if (projectID == 9 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(9)
                               && returnTaskOrdersIDlist.Contains(49)
                               && taskOrderID == 49)
            {
                return RedirectToAction("Index", "k2017HrsSchedule", new { projectID = 9, taskOrderID = 49, Int1 = Int1 });
            }

            // Index Work Schedule 
            if (projectID == 13 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(13)
                               && (returnTaskOrdersIDlist.Contains(50) || returnTaskOrdersIDlist.Contains(51) || returnTaskOrdersIDlist.Contains(52))
                               && (taskOrderID == 50 || taskOrderID == 51 || taskOrderID == 52))
            {
                return RedirectToAction("Home", "uhsCH", new { projectID = 13, taskOrderID = 50, Int1 = Int1 });
            }
            
            if (projectID == 13 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(13)
                               && returnTaskOrdersIDlist.Contains(53)
                               && taskOrderID == 53)
            {
                return RedirectToAction("District", "uhsdistrict", new { projectID = 13, taskOrderID = 53, Int1 = Int1 });
            }
            if (projectID == 13 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(13)
                               && returnTaskOrdersIDlist.Contains(55)
                               && taskOrderID == 55)
            {
                return RedirectToAction("a360", "uhsa360", new { projectID = 13, taskOrderID = 55, Int1 = Int1 });
            }
            if (projectID == 13 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(13)
                               && returnTaskOrdersIDlist.Contains(56)
                               && taskOrderID == 56)
            {
                return RedirectToAction("b360", "uhsb360", new { projectID = 13, taskOrderID = 56, Int1 = Int1 });
            }
            if (projectID == 13 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(13)
                               && returnTaskOrdersIDlist.Contains(57)
                               && taskOrderID == 57)
            {
                return RedirectToAction("sscadence", "uhssurserv", new { projectID = 13, taskOrderID = 57, Int1 = Int1 });
            }
            if (projectID == 13 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(13)
                               && returnTaskOrdersIDlist.Contains(58)
                               && taskOrderID == 58)
            {
                return RedirectToAction("coecadence", "uhscoeops", new { projectID = 13, taskOrderID = 58, Int1 = Int1 });
            }
            if (projectID == 13 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                && returnProjectIDlist.Contains(13)
                                && returnTaskOrdersIDlist.Contains(60)
                                && taskOrderID == 60)
            {
                return RedirectToAction("userstruct1", "uhsusercontrol", new { projectID = 13, taskOrderID = 60, Int1 = Int1 });
            }
            if (projectID == 13 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                && returnProjectIDlist.Contains(13)
                                && returnTaskOrdersIDlist.Contains(62)
                                && taskOrderID == 62)
            {
                return RedirectToAction("Index", "uhsreporting", new { projectID = 13, taskOrderID = 62, Int1 = Int1 });
            }
            if (projectID == 14 && CurrentLoginID == User.Identity.GetUserId().ToString()
                               && returnProjectIDlist.Contains(14)
                               && returnTaskOrdersIDlist.Contains(64)
                               && taskOrderID == 64)
            {
                return RedirectToAction("Index", "uhssscyccntm", new { projectID = 14, taskOrderID = 64, Int1 = Int1 });
            }
            if (projectID == 13 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                && returnProjectIDlist.Contains(13)
                                && returnTaskOrdersIDlist.Contains(65)
                                && taskOrderID == 65)
            {
                return RedirectToAction("Index", "uhsworktask", new { projectID = 13, taskOrderID = 65, Int1 = Int1 });
            }
            if (projectID == 15 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                && returnProjectIDlist.Contains(15)
                                && returnTaskOrdersIDlist.Contains(66)
                                && taskOrderID == 66)
            {
                return RedirectToAction("Index", "aglinvMap", new { projectID = 15, taskOrderID = 66, Int1 = Int1 });
            }
            else
            if (projectID == 17 && CurrentLoginID == User.Identity.GetUserId().ToString()
                                && returnProjectIDlist.Contains(17)
                                && returnTaskOrdersIDlist.Contains(68)
                                && taskOrderID == 68)
            {
                return RedirectToAction("Index", "emplactv", new { projectID = 17, taskOrderID = 68, Int1 = Int1 });
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult IndexMain(int projectID, int taskOrderID, int Int1)
        {
            ViewBag.projectID = projectID;
            ViewBag.taskOrderID = taskOrderID;
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var Item10 = from m in db.agentsDbs where m.userID == CurrentLoginID select m.agentName;
            string ItemID200 = Item10.Single();
            ViewBag.ItemUN = ItemID200;
            ViewBag.Int1 = Int1;


            //try
            //{
            //    string CS = ConfigurationManager.ConnectionStrings["CRUDdataConnection"].ConnectionString;
            //    using (SqlConnection con = new SqlConnection(CS))
            //    {
            //        SqlCommand cmd = new SqlCommand("procempCntToTot", con);
            //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //        cmd.Parameters.AddWithValue("@LoginID", User.Identity.GetUserId());
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //    }
            //}
            //catch (Exception e)
            //{
            //    throw (e);
            //}

            return View();
        }


        public ActionResult IndexSysAdmClients(int projectID, int taskOrderID, int Int1)
        {
            ViewBag.projectID = projectID;
            ViewBag.taskOrderID = taskOrderID;
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var Item10 = from m in db.agentsDbs where m.userID == CurrentLoginID select m.agentName;
            string ItemID200 = Item10.Single();
            ViewBag.ItemUN = ItemID200;
            ViewBag.Int1 = Int1;

            ViewBag.currDT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            

            ViewBag.coun200 = new SelectList(db.countriesDbs.Select(m => new { ID = m.ID, Value = m.country }), "ID", "Value");

            return View();
        }

        // disposing
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
