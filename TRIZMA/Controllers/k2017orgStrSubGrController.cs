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
    public class k2017orgStrSubGrController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();


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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(10)))
            {
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult _tableIndexk2017orgStrSubGr()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var userTypeSelect = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int userTypeInt = userTypeSelect.First();

            var customerDat = from s in dbv.k2017orgStrSubGrViewDbs where (userTypeInt == 2 || s.createdByUserID == CurrentLoginID) && s.ID > 1 orderby s.createdDT descending select s;
            return PartialView(customerDat.ToList());
        }


        // GET: k2017orgStrSubGrDbs/Create
        public ActionResult Create()
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(10)
                                                                                            && returnTaskOrdersIDlist.Contains(48)))
            {

                string CS = ConfigurationManager.ConnectionStrings["CRUDdataConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("prock2017orgStrSubGrIDres", con);
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
                    ViewBag.docID = docID;
                }

                ViewBag.currUL210 = User.Identity.GetUserId().ToString();
                ViewBag.currDT210 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
   
                ViewBag.proj200 = new SelectList(db.clientsProjectsDbs.Where(s => s.ID == 1 || s.ID == 10)
                                                                                       .OrderBy(s => s.ID), "ID", "projectName");

                ViewBag.task200 = new SelectList(db.taskOrdersDbs.Where(s => s.ID == 1 || s.ID == 48)
                                                                 .OrderBy(s => s.ID), "ID", "taskOrder");

                ViewBag.stL1200 = new SelectList(db.k2017orgStrL1Dbs.OrderBy(s => s.ID), "ID", "orgStrL1");


                var Item2110 = from m in db.agentsDbs where m.userID == CurrentLoginID select m.agentName;
                string ItemID200 = Item2110.Single();
                ViewBag.agnm201 = ItemID200;
                ViewBag.agid201 = userIDselectInt;


                return View();
            }

            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        // POST: k2017orgStrSubGrDbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, projectID, taskOrderID, orgStrL1ID, orgStrL2ID, orgStrSubGr, createdDT, editedDT, createdByUserID")] k2017orgStrSubGrDb k2017orgStrSubGrDb)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(10)
                                                                                            && returnTaskOrdersIDlist.Contains(48)))
            {

                if (ModelState.IsValid)
                {
                    db.k2017orgStrSubGrDbs.Add(k2017orgStrSubGrDb);
                    db.SaveChanges();
                    return RedirectToAction("Index", "k2017orgStrSubGr", new { projectID = 10, taskOrderID = 48, Int1 = 1 });
                }

                return View(k2017orgStrSubGrDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: k2017orgStrSubGrDbs/Edit/5
        public ActionResult Edit(int? id)
        {
            System.Diagnostics.Debug.WriteLine(id);

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

                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            k2017orgStrSubGrDb k2017orgStrSubGrDb = db.k2017orgStrSubGrDbs.Find(id);

            if (k2017orgStrSubGrDb == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(10)
                                                                                            && returnTaskOrdersIDlist.Contains(48)))
            {

                ViewBag.currUL310 = User.Identity.GetUserId().ToString();
                ViewBag.currDT310 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                ViewBag.proj300 = new SelectList(db.clientsProjectsDbs.Where(s => s.ID == 1 || s.ID == 10)
                                                                      .OrderBy(s => s.ID), "ID", "projectName");

                ViewBag.task300 = new SelectList(db.taskOrdersDbs.Where(s => s.ID == 1 || s.ID == 48)
                                                                 .OrderBy(s => s.ID), "ID", "taskOrder");

                ViewBag.stL1300 = new SelectList(db.k2017orgStrL1Dbs.OrderBy(s => s.ID), "ID", "orgStrL1");


                var It02 = db.k2017orgStrSubGrDbs.Where(s => s.ID == id)
                                              .Select(s => s.orgStrL1ID)
                                              .First();

                ViewBag.stL2300 = new SelectList(db.k2017orgStrL2Dbs.Where(s => s.ID == 1 || s.orgStrL1ID == It02)
                                                                    .OrderBy(s => s.ID), "ID", "orgStrL2");

                var Item32 = from m in db.k2017orgStrSubGrDbs where m.ID == id select m.createdByUserID;
                string Item322 = Item32.Single();

                var Item2110 = from m in db.agentsDbs where m.userID == Item322 select m.agentName;
                string ItemID200 = Item2110.Single();
                ViewBag.agnm301 = ItemID200;
                

                return View(k2017orgStrSubGrDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: k2017orgStrSubGrDbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, projectID, taskOrderID, orgStrL1ID, orgStrL2ID, orgStrSubGr, createdDT, editedDT, createdByUserID")] k2017orgStrSubGrDb k2017orgStrSubGrDb)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(10)
                                                                                            && returnTaskOrdersIDlist.Contains(48)))
            {

                if (ModelState.IsValid)
                {
                    db.Entry(k2017orgStrSubGrDb).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "k2017orgStrSubGr", new { projectID = 10, taskOrderID = 48, Int1 = 1 });
                }
                return View(k2017orgStrSubGrDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: k2017orgStrSubGrDbs/Delete/5
        public ActionResult Delete(int? id)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(10)
                                                                                            && returnTaskOrdersIDlist.Contains(48)))
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                k2017orgStrSubGrDb k2017orgStrSubGrDb = db.k2017orgStrSubGrDbs.Find(id);
                if (k2017orgStrSubGrDb == null)
                {
                    return HttpNotFound();
                }
                return View(k2017orgStrSubGrDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: k2017orgStrSubGrDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(10)
                                                                                            && returnTaskOrdersIDlist.Contains(48)))
            {
                k2017orgStrSubGrDb k2017orgStrSubGrDb = db.k2017orgStrSubGrDbs.Find(id);
                db.k2017orgStrSubGrDbs.Remove(k2017orgStrSubGrDb);
                db.SaveChanges();
                return RedirectToAction("Index", "k2017orgStrSubGr", new { projectID = 10, taskOrderID = 48, Int1 = 1 });
            }
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult FillDdl(int ID)
        {
            var datatable = db.k2017orgStrL2Dbs.Where(c => c.ID == 1 || c.orgStrL1ID == ID)
                                               .Select(c => new { ID = c.ID, Value = c.orgStrL2 });

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
