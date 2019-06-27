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
    public class uhsReportingController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();
        // GET: clientsDbs
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13) && returnTaskOrdersIDlist.Contains(62))
            {

                ViewBag.svctr = 0;
                ViewBag.data1 = dbv.k2017orgStrL3ViewDbs.Where(s => s.ID > 0).OrderBy(s => s.ID).ToList();


                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult reportActivityDistrict(int projectID, int taskOrderID, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13) && returnTaskOrdersIDlist.Contains(62))
            {
                var data1 = opb.UHSWEBAABvDbs.OrderBy(s => s.ID).ToList();
                var list1 = opa.DISTRICTSDbs.Where(s => s.compid == 1).Select(s => s.divID).Distinct().ToList();
                ViewBag.division = new SelectList(opb.dimDivisionDbs.Where(s => s.ID == 0 || list1.Contains(s.ID)).OrderBy(s => s.DivisionName), "ID", "DivisionName").ToList();
                var list2 = opb.UHSWEBAABvDbs.OrderBy(s => s.ID).Select(s => new { divID = s.divID, TB01 = s.TB01 }).ToList();
                ViewBag.seldiv = list2;
                return View(data1);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult reportPeriodicalActivityDistrict(int projectID, int taskOrderID, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13) && returnTaskOrdersIDlist.Contains(62))
            {
                ViewBag.identif = Int1;
                if (Int1 == 1)
                {
                    var list4 = opb.dimStructureDbs.Where(s => s.ID == 0 || s.compid == 1).ToList();
                    var list5 = opb.dimStructureDbs.Where(s => s.ID == 0 || s.compid == 1).Select(s => new { regid = s.regid, divid = s.divid, division = s.division }).Distinct().ToList();
                    ViewBag.structure = list4;
                    ViewBag.structureb = list5;
                    ViewBag.region = new SelectList(opb.dimRegionDbs.OrderBy(s => s.ID), "ID", "region").ToList();
                    return View();
                }
                else
                if (Int1 == 2)
                {
                    var list4 = opb.dimStructureDbs.Where(s => s.ID == 0 || s.compid == 1).ToList();
                    var list5 = opb.dimStructureDbs.Where(s => s.ID == 0 || s.compid == 1).Select(s => new { regid = s.regid, divid = s.divid, division = s.division }).Distinct().ToList();
                    var list6 = opa.UHSACCTSDbs.Where(s => s.IDc == 0 || s.typeid == 1).Select(s => new { distid = s.DISTID, IDc = s.IDc, cstnm = s.CSTNM }).Distinct().ToList();
                    ViewBag.structure = list4;
                    ViewBag.structureb = list5;
                    ViewBag.accA360 = list6;
                    ViewBag.region = new SelectList(opb.dimRegionDbs.OrderBy(s => s.ID), "ID", "region").ToList();
                    return View();
                }
                else
                if (Int1 == 3)
                {
                    var list4 = opb.dimStructureDbs.Where(s => s.ID == 0 || s.compid == 1).ToList();
                    var list5 = opb.dimStructureDbs.Where(s => s.ID == 0 || s.compid == 1).Select(s => new { regid = s.regid, divid = s.divid, division = s.division }).Distinct().ToList();
                    var list6 = opa.UHSACCTSDbs.Where(s => s.IDc == 0 || s.typeid == 2).Select(s => new { distid = s.DISTID, IDc = s.IDc, cstnm = s.CSTNM }).Distinct().ToList();
                    ViewBag.structure = list4;
                    ViewBag.structureb = list5;
                    ViewBag.accA360 = list6;
                    ViewBag.region = new SelectList(opb.dimRegionDbs.OrderBy(s => s.ID), "ID", "region").ToList();
                    return View();
                }
                else
                if(Int1 == 4)
                {
                    var list4 = opb.dimStructureDbs.Where(s => s.ID == 0 || s.compid == 2).ToList();
                    var list5 = opb.dimStructureDbs.Where(s => s.ID == 0 || s.compid == 2).Select(s => new { regid = s.regid, divid = s.divid, division = s.division }).Distinct().ToList();
                    ViewBag.structure = list4;
                    ViewBag.structureb = list5;
                    ViewBag.region = new SelectList(opb.dimRegionDbs.OrderBy(s => s.ID), "ID", "region").ToList();
                    return View();
                }
                else
                if (Int1 == 5)
                {
                    var list4 = opb.dimStructureDbs.Where(s => s.ID == 0 || s.compid == 3).ToList();
                    var list5 = opb.dimStructureDbs.Where(s => s.ID == 0 || s.compid == 3).Select(s => new { regid = s.regid, divid = s.divid, division = s.division }).Distinct().ToList();
                    ViewBag.structure = list4;
                    ViewBag.structureb = list5;
                    ViewBag.region = new SelectList(opb.dimRegionDbs.Where(s => s.ID == 0 || s.ID == 1).OrderBy(s => s.ID), "ID", "region").ToList();
                    return View();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult _reportTablePADist(int ID, int tpid, int mid)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13) && returnTaskOrdersIDlist.Contains(62))
            {
                ViewBag.identif = mid;
                if (mid == 1)
                {
                    if (tpid == 1)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010008 && s.regID == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    if (tpid == 2)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010008 && s.divID == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    if (tpid == 3)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010008 && s.distid == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
                else
                if (mid == 2)
                {
                    if (tpid == 1)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010006 && s.regID == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    if (tpid == 2)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010006 && s.divID == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    if (tpid == 3)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010006 && s.distid == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    if (tpid == 4)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010006 && s.acctid == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
                else
                if (mid == 3)
                {
                    if (tpid == 1)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010007 && s.regID == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    if (tpid == 2)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010007 && s.divID == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    if (tpid == 3)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010007 && s.distid == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    if (tpid == 4)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010007 && s.acctid == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
                else
                if (mid == 4)
                {
                    if (tpid == 1)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010009 && s.regID == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    if (tpid == 2)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010009 && s.divID == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    if (tpid == 3)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010009 && s.distid == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
                else
                if (mid == 5)
                {
                    if (tpid == 1)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010010 && s.regID == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    if (tpid == 2)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010010 && s.divID == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
                    }
                    else
                    if (tpid == 3)
                    {
                        var data1 = opb.uhsBIrepsucc02Dbs.Where(s => s.dctpid == 1010010 && s.distid == ID).OrderBy(s => s.ID).ToList();
                        return PartialView("_reportTablePADist", data1);
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
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult reportActivityA360(int projectID, int taskOrderID, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13) && returnTaskOrdersIDlist.Contains(62))
            {
                var data1 = opb.UHSWEBOMD11vDbs.OrderBy(s => s.IDc).ToList();
                var list1 = opa.UHSACCTSDbs.Where(s => s.typeid == 1).Select(s => s.DIV).Distinct().ToList();
                ViewBag.division = new SelectList(opb.dimDivisionDbs.Where(s => s.ID == 0 || list1.Contains(s.DivisionName)).OrderBy(s => s.DivisionName), "ID", "DivisionName").ToList();
                var list2 = opb.UHSWEBOMD11vDbs.OrderBy(s => s.IDc).Select(s => new { DIV = s.DIV, IDc = s.IDc }).ToList();
                ViewBag.seldiv = list2;
                return View(data1);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult reportActivityB360(int projectID, int taskOrderID, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13) && returnTaskOrdersIDlist.Contains(62))
            {
                var data1 = opb.UHSWEBOMD21vDbs.OrderBy(s => s.IDc).ToList();
                var list1 = opa.UHSACCTSDbs.Where(s => s.typeid == 2).Select(s => s.DIV).Distinct().ToList();
                ViewBag.division = new SelectList(opb.dimDivisionDbs.Where(s => s.ID == 0 || list1.Contains(s.DivisionName)).OrderBy(s => s.DivisionName), "ID", "DivisionName").ToList();
                var list2 = opb.UHSWEBOMD21vDbs.OrderBy(s => s.IDc).Select(s => new { DIV = s.DIV, IDc = s.IDc }).ToList();
                ViewBag.seldiv = list2;
                return View(data1);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult reportActivitySS(int projectID, int taskOrderID, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13) && returnTaskOrdersIDlist.Contains(62))
            {
                var data1 = opb.UHSWEBAACvDbs.OrderBy(s => s.ID).ToList();
                var list1 = opa.DISTRICTSDbs.Where(s => s.compid == 2).Select(s => s.divID).Distinct().ToList();
                ViewBag.division = new SelectList(opb.dimDivisionDbs.Where(s => s.ID == 0 || list1.Contains(s.ID)).OrderBy(s => s.DivisionName), "ID", "DivisionName").ToList();
                var list2 = opb.UHSWEBAACvDbs.OrderBy(s => s.ID).Select(s => new { divID = s.divID, ID = s.ID }).ToList();
                ViewBag.seldiv = list2;
                return View(data1);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult reportActivityCOE(int projectID, int taskOrderID, int Int1)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13) && returnTaskOrdersIDlist.Contains(62))
            {
                var data1 = opb.UHSWEBAADvDbs.OrderBy(s => s.ID).ToList();
                var list1 = opa.DISTCOEDbs.Where(s => s.compid == 1).Select(s => s.divID).Distinct().ToList();
                ViewBag.division = new SelectList(opb.dimDivisionDbs.Where(s => s.ID == 0 || list1.Contains(s.ID)).OrderBy(s => s.DivisionName), "ID", "DivisionName").ToList();
                var list2 = opb.UHSWEBAADvDbs.OrderBy(s => s.ID).Select(s => new { divID = s.divID, ID = s.ID }).ToList();
                ViewBag.seldiv = list2;
                return View(data1);
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
