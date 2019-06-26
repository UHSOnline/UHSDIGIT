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
    public class uhsvwpstandardController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();

        // GET: clientsDbs
        public ActionResult Index()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            return View();
        }
        public ActionResult Standards()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            // get user logged ID int
            int userid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();

            // get userTypeid integer
            int userTypeid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.userType).First();
            ViewBag.userTypeID = userTypeid;

            string userName = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();

            ViewBag.ItemSelect = 4;

            ViewBag.daNeOption200 = new SelectList(new[] {
                                                            new { Id = "1", Name = "-" },
                                                            new { Id = "2", Name = "DA" },
                                                            new { Id = "3", Name = "NE" }
                                                          }, "Id", "Name");

            ViewBag.svctr = 0;
            return View();
        }

        //-////////////////////////////////////////////////////////
        // Part - CleaningStation
        public ActionResult vwpCleaningStation()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return View();
        }
        public ActionResult _vwpCleaningStation()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return PartialView("_vwpCleaningStation");
        }
        //-////////////////////////////////////////////////////////

        //-////////////////////////////////////////////////////////
        // Part - InspectionTestingStation
        public ActionResult vwpInspectionTestingStation()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return View();
        }
        public ActionResult _vwpInspectionTestingStation()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return PartialView("_vwpInspectionTestingStation");
        }
        //-////////////////////////////////////////////////////////

        //-////////////////////////////////////////////////////////
        // Part - BERD
        public ActionResult vwpBERD()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return View();
        }
        public ActionResult _vwpBERD()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return PartialView("_vwpBERD");
        }
        //-////////////////////////////////////////////////////////


        //-////////////////////////////////////////////////////////
        // Part - PatientReadyEquipment
        public ActionResult vwpPatientReadyEquipment()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return View();
        }
        public ActionResult _vwpPatientReadyEquipment()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return PartialView("_vwpPatientReadyEquipment");
        }
        //-////////////////////////////////////////////////////////

        //-////////////////////////////////////////////////////////
        // Part - SurgicalServices
        public ActionResult vwpSurgicalServices()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return View();
        }
        public ActionResult _vwpSurgicalServices()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return PartialView("_vwpSurgicalServices");
        }
        //-////////////////////////////////////////////////////////

        //-////////////////////////////////////////////////////////
        // Part - ShippingReceiving
        public ActionResult vwpShippingReceiving()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return View();
        }
        public ActionResult _vwpShippingReceiving()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return PartialView("_vwpShippingReceiving");
        }
        //-////////////////////////////////////////////////////////

        //-////////////////////////////////////////////////////////
        // Part - OverallBuilding
        public ActionResult vwpOverallBuilding()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return View();
        }
        public ActionResult _vwpOverallBuilding()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return PartialView("_vwpOverallBuilding");
        }
        //-////////////////////////////////////////////////////////

        //-////////////////////////////////////////////////////////
        // Part - OverallBuilding
        public ActionResult vwpOtherStandards()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return View();
        }
        public ActionResult _vwpOtherStandards()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            return PartialView("_vwpOtherStandards");
        }
        //-////////////////////////////////////////////////////////



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
