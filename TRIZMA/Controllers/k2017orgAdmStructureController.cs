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

namespace TRIZMA.Controllers
{
    public class k2017orgAdmStructureController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();

        // GET: k2017evalcerccDbs
        public ActionResult Index(int projectID, int taskOrderID, int Int1)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.First();

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                             .Select(s => s.projectID)
                             .ToList();

            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(8)))
            {
                var It01 = dbv.k2017orgStrL1ViewDbs.Where(s => s.ID > 0);
                ViewBag.It01 = It01.ToList();

                var It02 = dbv.k2017orgStrL2ViewDbs.Where(s => s.ID > 0);
                ViewBag.It02 = It02.ToList();

                var It03 = dbv.k2017orgStrL3ViewDbs.Where(s => s.ID > 0);
                ViewBag.It03 = It03.ToList();

                ViewBag.It21 = dbv.k2017orgStrL1ViewDbs.Where(s => s.ID > 0);

                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }


        public ActionResult _DiagLevel1(int ID)
        {
            ViewBag.It00 = ID;
            ViewBag.It41 = dbv.k2017orgStrL2ViewDbs.Where(s => s.orgStrL1ID == ID);
            return PartialView();
        }

        public ActionResult _DiagLevel2(int ID)
        {
            ViewBag.It51 = dbv.k2017orgStrL3ViewDbs.Where(s => s.orgStrL2ID == ID);
            return PartialView();
        }
        //public ActionResult _DiagLevel3(int ID)
        //{
        //    ViewBag.It03 = db.k2017orgStrL3Dbs.Where(s => s.orgStrL2ID == ID);
        //    return PartialView();
        //}

    }
}
