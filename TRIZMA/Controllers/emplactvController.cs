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

namespace TRIZMA.Controllers
{
    public class emplactvController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();

        // GET: toInquriesDbs
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(17) && returnTaskOrdersIDlist.Contains(68))
            {
                ViewBag.userID = userIDselectInt;
                ViewBag.userTypeID = userTypeInt;
                ViewBag.userTitleID = db.agentsDbs.Where(s => s.ID == userIDselectInt).Select(s => s.titlid).First();
                ViewBag.btnSel = 1;
                ViewBag.chkInt = Int1;
                ViewBag.svctr = 0;
                ViewBag.userinfo = dbv.agentsViewDbs.Where(s => s.ID == userIDselectInt).ToList();
                ViewBag.districts = opa.DISTRICTSDbs.Where(s => s.compid == 1).ToList();
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult _tableIndexSysAdmToInquries()
        {
            var customerDat = from s in dbv.toInquriesViewDbs where s.ID > 1 select s;
            return PartialView(customerDat.ToList());
        }


        public ActionResult MapData(int a, int b, int c, string d, string e)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            if (CurrentLoginID == User.Identity.GetUserId().ToString())
            {
                if(a == 1)
                {
                    var data = dbv.agentsViewDbs.Where(s => s.ID == b).OrderBy(s => s.agentName).Select(s => new { ID = s.ID, agentName = s.agentName, distid = s.distid }).ToList();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var data = from s in dbv.toInquriesViewDbs where s.ID > 1 select s;
                    return Json(data, JsonRequestBehavior.AllowGet);
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
