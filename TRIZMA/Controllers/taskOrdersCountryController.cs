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
    public class taskOrdersCountryController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();

        // GET: taskOrdersCountryDbs
        public ActionResult Index(int projectID, int taskOrderID, int Int1)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult _tableIndexSysAdmTaskOrdersCountry()
        {
            var customerDat = from s in dbv.taskOrdersCountryViewDbs where s.ID > 1 select s;
            return PartialView(customerDat.ToList());
        }


        // GET: taskOrdersCountryDbs/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    taskOrdersCountryDb taskOrdersCountryDb = db.taskOrdersCountryDbs.Find(id);  
        //    if (taskOrdersCountryDb == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(taskOrdersCountryDb);
        //}

        // GET: taskOrdersDbs/Create
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
                    SqlCommand cmd = new SqlCommand("proctaskOrdersCountryIDres", con);
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

                ViewBag.clientsDb = new SelectList(db.clientsDbs, "ID", "clientName");
                ViewBag.countriesDb = new SelectList(db.countriesDbs, "ID", "country");
                ViewBag.currentUserLoginID = User.Identity.GetUserId().ToString();
                ViewBag.currentTimeDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: taskOrdersCountryDbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, clientID, projectID, taskOrderID, countryID, createdDT, editedDT, createdByUserID")] taskOrdersCountryDb taskOrdersCountryDb)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {

                if (ModelState.IsValid)
                {
                    db.taskOrdersCountryDbs.Add(taskOrdersCountryDb);
                    db.SaveChanges();
                    return RedirectToAction("Index","taskOrdersCountry", new { projectID = 6, taskOrderID = 23, Int1 = 1 });
                }

                return View(taskOrdersCountryDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: taskOrdersCountryDbs/Edit/5
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
                taskOrdersCountryDb taskOrdersCountryDb = db.taskOrdersCountryDbs.Find(id);
                if (taskOrdersCountryDb == null)
                {
                    return HttpNotFound();
                }

                var Item41 = from s in db.taskOrdersCountryDbs where s.ID == id select s.clientID;
                int Item411 = Item41.Single();

                var Item42 = from s in db.taskOrdersCountryDbs where s.ID == id select s.projectID;
                int Item421 = Item42.Single();

                ViewBag.clientsDb = new SelectList(db.clientsDbs, "ID", "clientName");

                ViewBag.clientsProjectsDb = new SelectList(db.clientsProjectsDbs.Where(s => s.ID == 1 || s.clientID == Item411), "ID", "projectName");

                ViewBag.taskOrdersDb = new SelectList(db.taskOrdersDbs.Where(s => s.ID == 1 || (s.clientID == Item411 && s.projectID == Item421)), "ID", "taskOrder");
                ViewBag.countriesDb = new SelectList(db.countriesDbs, "ID", "country");

                ViewBag.currentUserLoginID = User.Identity.GetUserId().ToString();
                ViewBag.currentTimeDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                return View(taskOrdersCountryDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: taskOrdersCountryDbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, clientID, projectID, taskOrderID, countryID, createdDT, editedDT, createdByUserID")] taskOrdersCountryDb taskOrdersCountryDb)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {

                if (ModelState.IsValid)
                {
                    db.Entry(taskOrdersCountryDb).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "taskOrdersCountry", new { projectID = 6, taskOrderID = 23, Int1 = 1 });
                }
                return View(taskOrdersCountryDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: taskOrdersCountryDbs/Delete/5
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
                taskOrdersCountryDb taskOrdersCountryDb = db.taskOrdersCountryDbs.Find(id);
                if (taskOrdersCountryDb == null)
                {
                    return HttpNotFound();
                }
                return View(taskOrdersCountryDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: taskOrdersCountryDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {
                taskOrdersCountryDb taskOrdersCountryDb = db.taskOrdersCountryDbs.Find(id);
                db.taskOrdersCountryDbs.Remove(taskOrdersCountryDb);
                db.SaveChanges();
                return RedirectToAction("Index", "taskOrdersCountry", new { projectID = 6, taskOrderID = 23, Int1 = 1 });
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
            int usID102 = usID101.First();

            var grid = new GridView();
            var ExportList = from p in dbv.taskOrdersCountryViewDbs
                             where p.createdByUserID == CurrentLoginID || usID102 == 2
                             select p;

            grid.DataSource = ExportList.ToList();

            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=AdmExport_Task_Orders_Countries_List.xls");
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

            return RedirectToAction("Index", "taskOrdersCountry", new { projectID = 6, taskOrderID = 23, Int1 = 1 });
        }
    }
}
