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
using System.IO;
using System.Web.UI;

namespace TRIZMA.Controllers
{
    public class ddlPopulateController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();

        // //////////////////////////////////////////////////////////////////////////////////////////////////
        //populate dropdown list Task Orders by Project selected and User assigned Task Orders inside project
        // //////////////////////////////////////////////////////////////////////////////////////////////////
        public ActionResult FillDdl1(int ID)
        {

            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.First();

            var Item331 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int Int331 = Item331.Single();


            var returntoIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                          .Select(s => s.taskOrderID)
                          .ToList();

                var datatable = db.taskOrdersDbs.Where(c => c.ID == 1 || c.projectID == ID)
                                                .Select(c => new { ID = c.ID, Value = c.taskOrder });

                return Json(datatable, JsonRequestBehavior.AllowGet);
                    
        }

        public ActionResult FillDdlATOs(int ID, int IDb)
        {

            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var userIDselectVar = from s in db.agentsDbs where s.userID == CurrentLoginID select s.ID;
            int userIDselectInt = userIDselectVar.First();

            var Item331 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int Int331 = Item331.Single();


            var returntoIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userIDselectInt)
                          .Select(s => s.taskOrderID)
                          .ToList();

            var datatable = db.taskOrdersDbs.Where(c => c.ID == 1 || c.projectID == ID)
                                            .Select(c => new { ID = c.ID, Value = c.taskOrder });

            return Json(datatable, JsonRequestBehavior.AllowGet);

        }

        // /////////////////////////////////////////////////////
        // populate dropdown list Country by Task Order selected
        // /////////////////////////////////////////////////////
        public ActionResult FillDdl2(int ID)
        {

            List<int> returnCountryIDlist = db.taskOrdersCountryDbs.Where(s => s.taskOrderID == ID)
                             .Select(s => s.countryID)
                             .ToList();

            var datatable = db.countriesDbs.Where(c => returnCountryIDlist.Contains(c.ID) || c.ID == 1)
                                           .OrderBy(c => c.country)
                                           .Select(c => new { ID = c.ID, Value = c.country });

            return Json(datatable, JsonRequestBehavior.AllowGet);
        }

        // /////////////////////////////////////////////////////////////
        //populate dropdown list Inqury Languages by Task Order selected
        // /////////////////////////////////////////////////////////////
        public ActionResult FillDdl3(int ID)
        {

            var datatable = db.toInquriesLangDbs.Where(c => c.ID == 1 || c.taskOrderID == ID)
                                            .Select(c => new { ID = c.ID, Value = c.inqLanguage });

            return Json(datatable, JsonRequestBehavior.AllowGet);
        }

        // /////////////////////////////////////////////////////////////////
        //populate dropdown list Task Orders Inquries by Task Order selected
        // /////////////////////////////////////////////////////////////////
        public ActionResult FillDdl4(int ID)
        {

            var datatable = db.toInquriesDbs.Where(c => c.ID == 1 || c.taskOrderID == ID)
                                            .Select(c => new { ID = c.ID, Value = c.inqury });

            return Json(datatable, JsonRequestBehavior.AllowGet);
        }

        // /////////////////////////////////////////////////////////////////
        //populate dropdown list Projects by Client selected
        // /////////////////////////////////////////////////////////////////
        public ActionResult FillDdl5(int ID)
        {

            var datatable = db.clientsProjectsDbs.Where(c => c.ID == 1 || c.clientID == ID)
                                            .Select(c => new { ID = c.ID, Value = c.projectName });

            return Json(datatable, JsonRequestBehavior.AllowGet);
        }

        // /////////////////////////////////////////////////////////////////
        //populate Task Order list by ProjectID selected, Administration
        // /////////////////////////////////////////////////////////////////
        public ActionResult FillDdl6(int ID)
        {

            var datatable = db.taskOrdersDbs.Where(c => c.ID == 1 || c.projectID == ID)
                                            .OrderBy(c => c.taskOrder)
                                            .Select(c => new { ID = c.ID, Value = c.taskOrder });

            return Json(datatable, JsonRequestBehavior.AllowGet);
        }

        // /////////////////////////////////////////////////////////////////
        //populate Call Class Type list by ProjectID selected, Administration
        // /////////////////////////////////////////////////////////////////
        public ActionResult FillDdl7(int ID)
        {

            var datatable = db.callClassTypeDbs.Where(c => c.ID == 1 || c.taskOrderID == ID)
                                            .Select(c => new { ID = c.ID, Value = c.taskOrderID });

            return Json(datatable, JsonRequestBehavior.AllowGet);
        }

        // /////////////////////////////////////////////////////////////////
        //populate Call Class Type list by ProjectID selected, Administration
        // /////////////////////////////////////////////////////////////////
        public ActionResult FillDdl8(int ID)
        {

            var datatable = db.cityDbs.Where(c => c.ID == 1 || c.countryID == ID)
                                      .OrderBy(c => c.appDef)
                                      .Select(c => new { ID = c.ID, Value = c.appDef });

            return Json(datatable, JsonRequestBehavior.AllowGet);
        }
        

        public JsonResult autoComplete(string ID)
        {
            var data = db.agentsDbs.Where(s => s.agentName.ToLower().Contains(ID.ToLower()))
                                             .Select(c => new { ID = c.ID, Value = c.agentName })
                                             .OrderBy(c => new { c.Value })
                                             .ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getCountryValues(int ID)
        {

            var list = dbv.vChartCMScount1Dbs.GroupBy(ac => new
                                                                {
                                                                    ac.countryID,
                                                                    ac.Country
                                                                })
                                             .Select(ac => new 
                                                               {
                                                                   countryID = ac.Key.countryID,
                                                                   country = ac.Key.Country,
                                                                   Total = ac.Sum(acs => acs.acdcallsNum)
                                                               });
            return Json(list, JsonRequestBehavior.AllowGet);
        }



        public ActionResult agentsProjects()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();
            var agentP = db.agentsProjDistDbs.Where(c => c.userID == CurrentLoginID).ToList();
            return PartialView("_agentsProjects", agentP);
        }

        public ActionResult agentsTOs(int id)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            var preAgentT = db.agentsTODistDbs.Where(c => c.userID == CurrentLoginID);
            var agentT = preAgentT.Where(c => c.projectID == id).ToList();
            return PartialView("_agentsTOs", agentT);
        }


    }
}
