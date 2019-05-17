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
    public class k2017orgStrL1Controller : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();


        public ActionResult Index()
        {
            return RedirectToAction("Index","k2017orgAdmStructure", new { projectID = 10, taskOrderID = 41, Int1 = 1 });
        }

        // GET: k2017orgStrL1Dbs/Create
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
                                                                                            && returnTaskOrdersIDlist.Contains(41)))
            {

                string CS = ConfigurationManager.ConnectionStrings["CRUDdataConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("prock2017orgStrL1IDres", con);
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

                ViewBag.task200 = new SelectList(db.taskOrdersDbs.Where(s => s.ID == 1 || s.ID == 41)
                                                                 .OrderBy(s => s.ID), "ID", "taskOrder");

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

        // POST: k2017orgStrL1Dbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, projectID, taskOrderID, orgStrL1, createdDT, editedDT, createdByUserID")] k2017orgStrL1Db k2017orgStrL1Db)
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
                                                                                            && returnTaskOrdersIDlist.Contains(41)))
            {

                if (ModelState.IsValid)
                {
                    db.k2017orgStrL1Dbs.Add(k2017orgStrL1Db);
                    db.SaveChanges();
                    return RedirectToAction("Index", "k2017orgAdmStructure", new { projectID = 10, taskOrderID = 41, Int1 = 1 });
                }

                return View(k2017orgStrL1Db);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: k2017orgStrL1Dbs/Edit/5
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

            k2017orgStrL1Db k2017orgStrL1Db = db.k2017orgStrL1Dbs.Find(id);

            if (k2017orgStrL1Db == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(10)
                                                                                            && returnTaskOrdersIDlist.Contains(41)))
            {

                ViewBag.currUL310 = User.Identity.GetUserId().ToString();
                ViewBag.currDT310 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                ViewBag.proj300 = new SelectList(db.clientsProjectsDbs.Where(s => s.ID == 1 || s.ID == 10)
                                                                      .OrderBy(s => s.ID), "ID", "projectName");

                ViewBag.task300 = new SelectList(db.taskOrdersDbs.Where(s => s.ID == 1 || s.ID == 41)
                                                                 .OrderBy(s => s.ID), "ID", "taskOrder");

                
                var Item32 = from m in db.k2017orgStrL1Dbs where m.ID == id select m.createdByUserID;
                string Item322 = Item32.Single();

                var Item2110 = from m in db.agentsDbs where m.userID == Item322 select m.agentName;
                string ItemID200 = Item2110.Single();
                ViewBag.agnm301 = ItemID200;
                

                return View(k2017orgStrL1Db);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: k2017orgStrL1Dbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, projectID, taskOrderID, orgStrL1, createdDT, editedDT, createdByUserID")] k2017orgStrL1Db k2017orgStrL1Db)
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
                                                                                            && returnTaskOrdersIDlist.Contains(41)))
            {

                if (ModelState.IsValid)
                {
                    db.Entry(k2017orgStrL1Db).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "k2017orgAdmStructure", new { projectID = 10, taskOrderID = 41, Int1 = 1 });
                }
                return View(k2017orgStrL1Db);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: k2017orgStrL1Dbs/Delete/5
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
                                                                                            && returnTaskOrdersIDlist.Contains(41)))
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                k2017orgStrL1Db k2017orgStrL1Db = db.k2017orgStrL1Dbs.Find(id);
                if (k2017orgStrL1Db == null)
                {
                    return HttpNotFound();
                }
                return View(k2017orgStrL1Db);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: k2017orgStrL1Dbs/Delete/5
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
                                                                                            && returnTaskOrdersIDlist.Contains(41)))
            {
                k2017orgStrL1Db k2017orgStrL1Db = db.k2017orgStrL1Dbs.Find(id);
                db.k2017orgStrL1Dbs.Remove(k2017orgStrL1Db);
                db.SaveChanges();
                return RedirectToAction("Index", "k2017orgAdmStructure", new { projectID = 10, taskOrderID = 41, Int1 = 1 });
            }
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
            var ExportList = from p in dbv.k2017orgStrL1ViewDbs
                             where p.createdByUserID == CurrentLoginID || usID102 == 2
                             select p;

            grid.DataSource = ExportList.ToList();

            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Export_TRIZMA_ORGADM_OrgStructure_Leve1.xls");
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

            return RedirectToAction("Index", "k2017orgAdmStructure", new { projectID = 10, taskOrderID = 41, Int1 = 1 });
        }
    }
}
