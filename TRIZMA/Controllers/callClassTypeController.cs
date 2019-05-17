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
    public class callClassTypeController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();

        // GET: callClassTypeDbs
        
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

        public ActionResult _tableIndexSysAdmCallClassType()
        {
            var customerDat = from s in dbv.callClassTypeViewDbs where s.ID > 1 select s;
            return PartialView(customerDat.ToList());
        }


        // GET: callClassTypeDbs/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    callClassTypeDb callClassTypeDb = db.callClassTypeDbs.Find(id);  
        //    if (callClassTypeDb == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(callClassTypeDb);
        //}

        // GET: callClassTypeDbs/Create
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
                    SqlCommand cmd = new SqlCommand("proccallClassTypeIDres", con);
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
                
                ViewBag.currentUserLoginID = User.Identity.GetUserId().ToString();
                ViewBag.currentTimeDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: callClassTypeDbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, clientID, projectID, taskOrderID, callClassDesc, createdDT, editedDT, createdByUserID")] callClassTypeDb callClassTypeDb)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {

                if (ModelState.IsValid)
                {
                    db.callClassTypeDbs.Add(callClassTypeDb);
                    db.SaveChanges();
                    return RedirectToAction("Index", "callClassType", new { projectID = 6, taskOrderID = 30, Int1 = 1 });
                }

                return View(callClassTypeDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: callClassTypeDbs/Edit/5
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
                callClassTypeDb callClassTypeDb = db.callClassTypeDbs.Find(id);
                if (callClassTypeDb == null)
                {
                    return HttpNotFound();
                }

                ViewBag.clientsDb = new SelectList(db.clientsDbs, "ID", "clientName");

                var Item410 = from s in db.callClassTypeDbs where s.ID == id select s.clientID;
                int Int410 = Item410.First();
                ViewBag.clientsProjectsDb = new SelectList(db.clientsProjectsDbs.Where(s => s.ID == 1 || s.clientID == Int410), "ID", "projectName");

                var Item420 = from s in db.callClassTypeDbs where s.ID == id select s.projectID;
                int Int420 = Item420.First();
                ViewBag.taskOrdersDb = new SelectList(db.taskOrdersDbs.Where(s => s.ID == 1 || (s.clientID == Int410 && s.projectID == Int420)), "ID", "taskOrder");

                ViewBag.currentUserLoginID = User.Identity.GetUserId().ToString();
                ViewBag.currentTimeDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                return View(callClassTypeDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: callClassTypeDbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, clientID, projectID, taskOrderID, callClassDesc, createdDT, editedDT, createdByUserID")] callClassTypeDb callClassTypeDb)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {

                if (ModelState.IsValid)
                {
                    db.Entry(callClassTypeDb).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "callClassType", new { projectID = 6, taskOrderID = 30, Int1 = 1 });
                }
                return View(callClassTypeDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: callClassTypeDbs/Delete/5
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
                callClassTypeDb callClassTypeDb = db.callClassTypeDbs.Find(id);
                if (callClassTypeDb == null)
                {
                    return HttpNotFound();
                }
                return View(callClassTypeDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: callClassTypeDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {

                callClassTypeDb callClassTypeDb = db.callClassTypeDbs.Find(id);
                db.callClassTypeDbs.Remove(callClassTypeDb);
                db.SaveChanges();
                return RedirectToAction("Index", "callClassType", new { projectID = 6, taskOrderID = 30, Int1 = 1 });
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
            var ExportList = from p in dbv.callClassTypeViewDbs
                             where p.createdByUserID == CurrentLoginID || usID102 == 2
                             select p;

            grid.DataSource = ExportList.ToList();

            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=AdmExport_Call_Class_Type_List.xls");
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

            return RedirectToAction("Index", "callClassType", new { projectID = 6, taskOrderID = 30, Int1 = 1 });
        }
    }
}
