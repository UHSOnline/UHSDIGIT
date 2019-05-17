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
    public class uhsuserB360Controller : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();

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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6) && returnTaskOrdersIDlist.Contains(61))
            {
                ViewBag.accts1 = opb.UHSUSAC1B360Dbs.OrderBy(s => s.agentName).Select(s => new { IDc = s.IDc, MGRID = s.MGRID, agentName = s.agentName }).ToList();
                ViewBag.btnSel = 2;
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult FillDdl(int ID)
        {
                var list1 = opb.UHSUSAC1B360Dbs.Where(s => s.MGRID == ID).Select(s => s.IDc).Distinct().ToList();
                var datatable = opa.UHSACCTSDbs.Where(c => c.typeid == 2 && !list1.Contains(c.IDc))
                                               .OrderBy(c => c.IDc)
                                               .Select(c => new { ID = c.IDc, Value = c.CSTNM });
                return Json(datatable, JsonRequestBehavior.AllowGet);
        }

        // GET: agentsDbs/Create
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6)
                                                                                            && returnTaskOrdersIDlist.Contains(61))
            {
                ViewBag.users1 = new SelectList(dbv.agentsViewDbs.OrderBy(s => s.agentName), "ID", "agentNameID2");
                ViewBag.userid = userIDselectInt;
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        // POST: agentsDbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateNew(UHSUSAT1B360Db UHSUSAT1B360Db)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6)
                                                                                            && returnTaskOrdersIDlist.Contains(61))
            {
                if (UHSUSAT1B360Db.MGRID == 0 || UHSUSAT1B360Db.IDc == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                        if (ModelState.IsValid)
                        try
                        {
                            opa.UHSUSAT1B360Dbs.Add(UHSUSAT1B360Db);
                            opa.SaveChanges();
                            var conf = 1;
                            return Json(conf, JsonRequestBehavior.AllowGet);
                        }
                        catch (Exception e)
                        {
                            return View(UHSUSAT1B360Db);
                            throw (e);
                        }

                    return View(UHSUSAT1B360Db);
                }        
            }
            return View(UHSUSAT1B360Db);
        }
        // GET: agentsDbs/Edit
        public ActionResult EditDoc(string id)
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

           

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6)
                                                                                            && returnTaskOrdersIDlist.Contains(61))
            {
                var IDD = opa.UHSUSAT1B360Dbs.Where(s => s.ID == id).Select(s => s.MGRID).First();
                var acc1 = opa.UHSUSAT1B360Dbs.Where(s => s.ID == id).Select(s => s.IDc).First();
                var list1 = opb.UHSUSAC1B360Dbs.Where(s => s.MGRID == IDD).Select(s => s.IDc).Distinct().ToList();
                var datatable = opa.UHSACCTSDbs.Where(c => c.typeid == 2 && (c.IDc == acc1 || !list1.Contains(c.IDc)))
                                               .OrderBy(c => c.IDc)
                                               .Select(c => new { ID = c.IDc, Value = c.CSTNM });
                

                ViewBag.users1 = new SelectList(dbv.agentsViewDbs.OrderBy(s => s.agentName), "ID", "agentNameID2");
                ViewBag.accts1 = new SelectList(opa.UHSACCTSDbs.Where(c => c.typeid == 2 && (c.IDc == acc1 || !list1.Contains(c.IDc))).OrderBy(c => c.IDc).Select(c => new { ID = c.IDc, CSTNM = c.CSTNM }), "ID", "CSTNM");
                ViewBag.userid = userIDselectInt;
                ViewBag.data1 = opa.UHSUSAT1B360Dbs.Where(s => s.ID == id);
                //System.Diagnostics.Debug.WriteLine(id);

                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // POST: Edit Doc:1010003
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditEx(UHSUSAT1B360Db model)
        {
            //System.Diagnostics.Debug.WriteLine(model.ID);
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6)
                                                                                            && returnTaskOrdersIDlist.Contains(61)))
            {

                if (ModelState.IsValid)
                {
                    try
                    {
                        opa.Entry(model).State = EntityState.Modified;
                        opa.SaveChanges();
                        int resp = 1;
                        return Json(resp, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        int resp = 2;
                        return Json(resp, JsonRequestBehavior.AllowGet);
                        throw (e);
                    }
                }
                else
                {
                    int resp = 3;
                    return Json(resp, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int resp = 4;
                return Json(resp, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: UHSUSAT1A360Db/Delete/5
        public ActionResult Delete(string id)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6)
                                                                                            && returnTaskOrdersIDlist.Contains(61))
            {

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                UHSUSAT1B360Db UHSUSAT1B360Db = opa.UHSUSAT1B360Dbs.Find(id);
                if (UHSUSAT1B360Db == null)
                {
                    return HttpNotFound();
                }
                return View(UHSUSAT1B360Db);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        // POST: UHSUSAT1A360Db/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6)
                                                                                            && returnTaskOrdersIDlist.Contains(61)))
            {
                UHSUSAT1B360Db UHSUSAT1B360Db = opa.UHSUSAT1B360Dbs.Find(id);
                opa.UHSUSAT1B360Dbs.Remove(UHSUSAT1B360Db);
                opa.SaveChanges();
                return RedirectToAction("Index", "uhsuserB360", new { projectID = 6, taskOrderID = 61, Int1 = 1 });
            }
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult getB360map(int ID)
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6)
                                                                                            && returnTaskOrdersIDlist.Contains(61))
            {
                var datatable = opb.UHSWEBOMD21vDbs.ToList();
                return Json(datatable, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult _tableIndexB360()
        {
            var data = from s in opb.UHSUSAC1B360Dbs select s;
            return PartialView(data.ToList());
        }
        
        public ActionResult sendmailmessage(string email, string passwordb)
        {
            string emailToDist = email;

            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;
            string m_userName = "uhsvwpcontrolsystem@gmail.com";
            string m_UserpassWord = "Trizma123+";

            string emailID = emailToDist;

            string emailFrom = m_userName;
            string password = m_UserpassWord;
            string emailTo = emailID;

            // Here you can put subject of the mail
            string subject = "UHS VWPS Control System: Login Credentials Info";
            // Body of the mail
            string body = "<div><span style='color:#367EAD'>To: </span><b> " + email + " </b></div>";
            body += "<hr />";
            body += "<div><br /><br /><span>Access VWP Application at: </span><a target='_blank' href='http://uhsdigit.trizma.com:8083/uhsCH/Index'> http://uhsdigit.trizma.com:8083/uhsCH/Index </div></span>";
            body += "<div><br /><span>Go to Login and enter credentials as follows:</span></div>";
            body += "<div><br /><table><thead style='text-align:left'><tr><th>Login</th><th>Password</th></tr></thead><tbody style='text-align:left'><tr><td style='padding-right:20px'>" + email + "</td><td>" + passwordb + "</td></tr></tbody></table></div>";

            // this is done using  using System.Net.Mail; & using System.Net; 
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                // Can set to false, if you are sending pure text.

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }

            string data = "The message was successfully sent to: " + emailID;
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    
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
