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
using TRIZMA.Controllers;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace TRIZMA.Controllers
{
    public class agentsController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();

        // GET: agentsDbs

        public ActionResult Index(int projectID, int taskOrderID, int Int1)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            var expo1 = db.agentsDbs.Select(s => s.ID).ToList();
            ViewBag.userTypeDb101 = new SelectList(opb.UHSUSDP01Dbs.Where(s => s.ID == 0 || !expo1.Contains(s.ID)).OrderBy(s => s.appdef), "ID", "appdef").ToList();

            //var customerDat = from s in dbv.agentsViewDbs where s.ID > 1 select s;
            return View();
           
        }

        public ActionResult _tableIndexSysAdmAgents()
        {
            var customerDat = from s in dbv.agentsViewDbs where s.ID > 1 select s;
            return PartialView(customerDat.ToList());
        }

        // GET: agentsDbs/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    agentsDb agentsDb = db.agentsDbs.Find(id);  
        //    if (agentsDb == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(agentsDb);
        //}

        // GET: agentsDbs/Create
        public ActionResult Create()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {
                string CS = ConfigurationManager.ConnectionStrings["CRUDdataConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procagentsIDres", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@LoginID", User.Identity.GetUserId());

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string docID = outputParameter.Value.ToString();
                    ViewBag.docID101 = docID;
                }

                ViewBag.taskOrdersDb101 = new SelectList(db.taskOrdersDbs, "ID", "taskOrder");
                ViewBag.userTypeDb101 = new SelectList(db.userTypeDbs, "ID", "userType");

                ViewBag.stL1200 = new SelectList(db.k2017orgStrL1Dbs.OrderBy(s => s.ID), "ID", "orgStrL1").ToList();
                ViewBag.stL2200 = new SelectList(dbv.k2017orgStrL2ViewDbs.OrderBy(s => s.ID), "ID", "appDef").ToList();
                ViewBag.stL3200 = new SelectList(dbv.k2017orgStrL3ViewDbs.OrderBy(s => s.ID), "ID", "appDef").ToList();

                ViewBag.currentUserLoginID101 = User.Identity.GetUserId().ToString();
                ViewBag.currentTimeDate101 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                ViewBag.titule1 = new SelectList(new[] {
                                                            new { Id = "0", Name = "-" },
                                                            new { Id = "1", Name = "DOD" },
                                                            new { Id = "2", Name = "OMD" },
                                                            new { Id = "3", Name = "OMH" }
                                                          }, "Id", "Name");

                ViewBag.region1 = new SelectList(opb.dimRegionDbs.OrderBy(s => s.ID), "ID", "region").ToList();
                ViewBag.division1 = new SelectList(opa.DISTRICTSDbs.Where(s => s.ID == 0), "ID", "district").ToList();
                ViewBag.district1 = new SelectList(opa.DISTRICTSDbs.Where(s => s.ID == 0), "ID", "district").ToList();
                ViewBag.account1 = new SelectList(opa.DISTRICTSDbs.Where(s => s.ID == 0), "ID", "district").ToList();
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult getdddiv(int ID)
        {
            List<int> list1 = opa.DISTRICTSDbs.Where(s => s.regID == ID).Select(s => s.divID).Distinct().ToList();
            var datatable = opb.dimDivisionDbs.Where(s => s.ID == 0 || list1.Contains(s.ID)).OrderBy(s => s.ID).ToList();
            return Json(datatable, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getdddist(int ID)
        {
            var datatable = opa.DISTRICTSDbs.Where(s => s.ID == 0 || s.divID == ID).Select(s => new { ID = s.ID, district = s.district }).ToList();
            return Json(datatable, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getddacct(int ID)
        {           
            List<UHSACCTSDb> set1 = new List<UHSACCTSDb>();
            UHSACCTSDb List1 = new UHSACCTSDb();
            List1.IDc = 0;
            List1.CSTNM = "-";
            set1.Add(List1);

            var item2 = opa.UHSACCTSDbs.Where(s => s.DISTID == ID).OrderBy(s => s.ID).Select(s => new { IDc = s.IDc, CSTNM = s.CSTNM }).Distinct().ToList();
            foreach(var item in item2)
            {
                UHSACCTSDb List2 = new UHSACCTSDb();
                List2.IDc = item.IDc;
                List2.CSTNM = item.CSTNM;
                set1.Add(List2);
            }
            var datatable = set1.Select(s => new { IDc = s.IDc, CSTNM = s.CSTNM }).ToList();
            
            return Json(datatable, JsonRequestBehavior.AllowGet);
        }

        // POST: agentsDbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, agentID, agentDescription, userID, UserName, taskOrderID, createdDT, editedDT, createdByUserID, userType, agentName, orgStrL3ID, orgStrSubGrID, regid, divid, distid, acctid, titlid, workPhone, mobilePhone, DODID, a360, b360, orgStrL1ID, orgStrL2ID, passwordstring")] agentsDb agentsDb)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {
                if (ModelState.IsValid)
                {
                    db.agentsDbs.Add(agentsDb);
                    db.SaveChanges();
                    return RedirectToAction("Index","agents", new { projectID = 6, taskOrderID = 33, Int1 = 1  });
                }

                return View(agentsDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: agentsDbs/Edit/5
        public ActionResult Edit(int? id)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                agentsDb agentsDb = db.agentsDbs.Find(id);
                if (agentsDb == null)
                {
                    return HttpNotFound();
                }

                ViewBag.taskOrdersDb102 = new SelectList(db.taskOrdersDbs, "ID", "taskOrder");
                ViewBag.userTypeDb102 = new SelectList(db.userTypeDbs, "ID", "userType");
                ViewBag.currentUserLoginID102 = User.Identity.GetUserId().ToString();
                ViewBag.currentTimeDate102 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                int ItR1 = dbv.agentsViewDbs.Where(s => s.ID == id).Select(s => s.orgStrL1ID).First();
                ViewBag.ItR1 = ItR1;

                var It02 = dbv.agentsViewDbs.Where(s => s.ID == id).Select(s => s.orgStrL3ID).First();

                int It03 = db.k2017orgStrL3Dbs.Where(s => s.ID == It02).Select(s => s.orgStrL2ID).First();
                ViewBag.ItR2 = It03;

                int It04 = db.k2017orgStrL2Dbs.Where(s => s.ID == It03).Select(s => s.orgStrL1ID).First();


                ViewBag.subg300 = new SelectList(db.k2017orgStrSubGrDbs.Where(s => s.ID == 1 || s.orgStrL2ID == It03)
                                                                    .OrderBy(s => s.ID), "ID", "orgStrSubGr");

                ViewBag.titule2 = new SelectList(new[] {
                                                            new { Id = "0", Name = "-" },
                                                            new { Id = "1", Name = "DOD" },
                                                            new { Id = "2", Name = "OMD" },
                                                            new { Id = "3", Name = "OMH" }
                                                          }, "Id", "Name");

                ViewBag.region2 = new SelectList(opb.dimRegionDbs.OrderBy(s => s.ID), "ID", "region").ToList();

                var regid = db.agentsDbs.Where(s => s.ID == id).Select(s => s.regid).First();
                List <int> list1 = opa.DISTRICTSDbs.Where(s => s.regID == regid).Select(s => s.divID).Distinct().ToList();
                ViewBag.division2 = new SelectList(opb.dimDivisionDbs.Where(s => s.ID == 0 || list1.Contains(s.ID)).OrderBy(s => s.ID), "ID", "DivisionName").ToList();

                var divid = db.agentsDbs.Where(s => s.ID == id).Select(s => s.divid).First();
                ViewBag.district2 = new SelectList(opa.DISTRICTSDbs.Where(s => s.ID == 0 || s.divID == divid).Select(s => new { ID = s.ID, district = s.district }).OrderBy(s => s.ID), "ID", "district").ToList();

                ViewBag.stL1300 = new SelectList(db.k2017orgStrL1Dbs.OrderBy(s => s.ID), "ID", "orgStrL1").ToList();
                ViewBag.stL2300 = new SelectList(dbv.k2017orgStrL2ViewDbs.OrderBy(s => s.ID), "ID", "appDef").ToList();
                ViewBag.stL3300 = new SelectList(dbv.k2017orgStrL3ViewDbs.OrderBy(s => s.ID), "ID", "appDef").ToList();

                var distid = db.agentsDbs.Where(s => s.ID == id).Select(s => s.distid).First();
                List<UHSACCTSDb> set1 = new List<UHSACCTSDb>();
                UHSACCTSDb List1 = new UHSACCTSDb();
                List1.IDc = 0;
                List1.CSTNM = "-";
                set1.Add(List1);

                var item2 = opa.UHSACCTSDbs.Where(s => s.DISTID == distid).OrderBy(s => s.ID).Select(s => new { IDc = s.IDc, CSTNM = s.CSTNM }).Distinct().ToList();
                foreach (var item in item2)
                {
                    UHSACCTSDb List2 = new UHSACCTSDb();
                    List2.IDc = item.IDc;
                    List2.CSTNM = item.CSTNM;
                    set1.Add(List2);
                }
                ViewBag.account2 = new SelectList(set1.Select(s => new { ID = s.IDc, CSTNM = s.CSTNM }), "ID", "CSTNM").ToList();

                return View(agentsDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: agentsDbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, agentID, agentDescription, userID, UserName, taskOrderID, createdDT, editedDT, createdByUserID, userType, agentName, orgStrL3ID, orgStrSubGrID, regid, divid, distid, acctid, titlid, workPhone, mobilePhone, DODID, a360, b360, orgStrL1ID, orgStrL2ID, passwordstring")] agentsDb agentsDb)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(agentsDb).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "agents", new { projectID = 6, taskOrderID = 33, Int1 = 1 });
                }
                return View(agentsDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: agentsDbs/Delete/5
        public ActionResult Delete(int? id)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                agentsDb agentsDb = db.agentsDbs.Find(id);
                if (agentsDb == null)
                {
                    return HttpNotFound();
                }
                return View(agentsDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: agentsDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {
                agentsDb agentsDb = db.agentsDbs.Find(id);
                db.agentsDbs.Remove(agentsDb);
                db.SaveChanges();
                return RedirectToAction("Index","agents", new { projectID = 6, taskOrderID = 33, Int1 = 1 });
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }


        public ActionResult FillDdl2(int ID)
        {
            var datatable = db.k2017orgStrL2Dbs.Where(c => c.ID == 1 || c.orgStrL1ID == ID)
                                               .Select(c => new { ID = c.ID, Value = c.orgStrL2 });

            return Json(datatable, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FillDdl3(int ID)
        {
            var datatable = db.k2017orgStrL3Dbs.Where(c => c.ID == 1 || c.orgStrL2ID == ID)
                                               .Select(c => new { ID = c.ID, Value = c.orgStrL3 });

            return Json(datatable, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FillDdl4(int ID)
        {
            var datatable = db.k2017orgStrSubGrDbs.Where(c => c.ID == 1 || c.orgStrL2ID == ID)
                                               .Select(c => new { ID = c.ID, Value = c.orgStrSubGr });

            return Json(datatable, JsonRequestBehavior.AllowGet);
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
            int usID102 = usID101.First();

            var grid = new GridView();
            var ExportList = from p in dbv.agentsViewDbs
                                 where p.createdByUserID == CurrentLoginID || usID102 == 2
                                 select p;

            grid.DataSource = ExportList.ToList();

            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=AdmExport_Agents_List.xls");
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

            return RedirectToAction("Index", "agents", new { projectID = 6, taskOrderID = 33, Int1 = 1 });
        }

    }
}
