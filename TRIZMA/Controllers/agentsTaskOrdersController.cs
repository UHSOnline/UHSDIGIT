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
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TRIZMA.Controllers
{
    public class agentsTaskOrdersController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();

        // GET: agentsTaskOrdersDbs
        
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

        public ActionResult _tableIndexSysAdmAgentsTaskOrders()
        {
            var customerDat = from s in dbv.agentsTaskOrdersViewDbs where s.ID > 1 select s;
            return PartialView(customerDat.ToList());
        }

        // GET: agentsTaskOrdersDbs/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    agentsTaskOrdersDb agentsTaskOrdersDb = db.agentsTaskOrdersDbs.Find(id);  
        //    if (agentsTaskOrdersDb == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(agentsTaskOrdersDb);
        //}

        // GET: agentsTaskOrdersDbs/Create
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
                    SqlCommand cmd = new SqlCommand("procagentsTaskOrdersIDres", con);
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

                ViewBag.agentsListDb = new SelectList(dbv.agentsViewDbs.OrderBy(s => s.ID), "ID", "agentNameID");
                ViewBag.clientsDb = new SelectList(db.clientsDbs.OrderBy(s => s.ID), "ID", "clientName");

                ViewBag.currentUserLoginID = User.Identity.GetUserId().ToString();
                ViewBag.currentTimeDate101 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: agentsTaskOrdersDbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, agentID, clientID, projectID, taskOrderID, createdDT, editedDT, createdByUserID")] agentsTaskOrdersDb agentsTaskOrdersDb)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {
                if (ModelState.IsValid)
                {
                    db.agentsTaskOrdersDbs.Add(agentsTaskOrdersDb);
                    db.SaveChanges();
                    return RedirectToAction("Index", "agentsTaskOrders", new { projectID = 6, taskOrderID = 34, Int1 = 1 });
                }

                return View(agentsTaskOrdersDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: agentsTaskOrdersDbs/Edit/5
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

                agentsTaskOrdersDb agentsTaskOrdersDb = db.agentsTaskOrdersDbs.Find(id);
                if (agentsTaskOrdersDb == null)
                {
                    return HttpNotFound();
                }

                ViewBag.agentsListDb = new SelectList(dbv.agentsViewDbs.OrderBy(s => s.ID), "ID", "agentNameID");

                var Item41 = from s in db.agentsTaskOrdersDbs where s.ID == id select s.clientID;
                int Item411 = Item41.First();

                var Item42 = from s in db.agentsTaskOrdersDbs where s.ID == id select s.projectID;
                int Item421 = Item42.First();

                ViewBag.clientsDb = new SelectList(db.clientsDbs, "ID", "clientName");

                ViewBag.clientsProjectsDb = new SelectList(db.clientsProjectsDbs.Where(s => s.ID == 1 || s.clientID == Item411)
                                                                                .OrderBy(s => s.ID), "ID", "projectName");

                ViewBag.taskOrdersDb = new SelectList(db.taskOrdersDbs.Where(s => s.ID == 1 || (s.clientID == Item411 && s.projectID == Item421))
                                                                      .OrderBy(s => s.ID), "ID", "taskOrder");

                ViewBag.currentUserLoginID = User.Identity.GetUserId().ToString();
                ViewBag.currentTimeDate101 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                return View(agentsTaskOrdersDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: agentsTaskOrdersDbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, agentID, clientID, projectID, taskOrderID, createdDT, editedDT, createdByUserID")] agentsTaskOrdersDb agentsTaskOrdersDb)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(agentsTaskOrdersDb).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "agentsTaskOrders", new { projectID = 6, taskOrderID = 34, Int1 = 1 });
                }
                return View(agentsTaskOrdersDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: agentsTaskOrdersDbs/Delete/5
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
                agentsTaskOrdersDb agentsTaskOrdersDb = db.agentsTaskOrdersDbs.Find(id);
                if (agentsTaskOrdersDb == null)
                {
                    return HttpNotFound();
                }
                return View(agentsTaskOrdersDb);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: agentsTaskOrdersDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            if (usID102 == 2)
            {
                agentsTaskOrdersDb agentsTaskOrdersDb = db.agentsTaskOrdersDbs.Find(id);
                db.agentsTaskOrdersDbs.Remove(agentsTaskOrdersDb);
                db.SaveChanges();
                return RedirectToAction("Index", "agentsTaskOrders", new { projectID = 6, taskOrderID = 34, Int1 = 1 });
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
            var ExportList = from p in dbv.agentsTaskOrdersViewDbs
                               where p.createdByUserID == CurrentLoginID || usID102 == 2
                               select p;

            grid.DataSource = ExportList.ToList();

            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=AdmExport_Agents_TaskOrders_List.xls");
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

            return RedirectToAction("Index", "agentsTaskOrders", new { projectID = 6, taskOrderID = 34, Int1 = 1 });
        }
    }
}
