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
    public class uhsuserSSController : Controller
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
                ViewBag.dist1 = opb.UHSUSAC1SURSERVDbs.OrderBy(s => s.agentName).Select(s => new { DISTID = s.DISTID, MGRID = s.MGRID, agentName = s.agentName }).ToList();
                ViewBag.btnSel = 4;
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult FillDdl(int ID)
        {
                var list1 = opb.UHSUSAC1SURSERVDbs.Where(s => s.MGRID == ID).Select(s => s.DISTID).Distinct().ToList();
                var datatable = opa.DISTRICTSDbs.Where(c => c.compid == 2 && !list1.Contains(c.ID))
                                               .OrderBy(c => c.ID)
                                               .Select(c => new { ID = c.ID, Value = c.district });
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
        public ActionResult CreateNew(UHSUSAT1SURSERVDb UHSUSAT1SURSERVDb)
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
                if (UHSUSAT1SURSERVDb.MGRID == 0 || UHSUSAT1SURSERVDb.DISTID == 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                        if (ModelState.IsValid)
                        try
                        {
                            opa.UHSUSAT1SURSERVDbs.Add(UHSUSAT1SURSERVDb);
                            opa.SaveChanges();
                            var conf = 1;
                            return Json(conf, JsonRequestBehavior.AllowGet);
                        }
                        catch (Exception e)
                        {
                            return View(UHSUSAT1SURSERVDb);
                            throw (e);
                        }

                    return View(UHSUSAT1SURSERVDb);
                }        
            }
            return View(UHSUSAT1SURSERVDb);
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
                var IDD = opa.UHSUSAT1SURSERVDbs.Where(s => s.ID == id).Select(s => s.MGRID).First();
                var acc1 = opa.UHSUSAT1SURSERVDbs.Where(s => s.ID == id).Select(s => s.DISTID).First();
                var list1 = opb.UHSUSAC1SURSERVDbs.Where(s => s.MGRID == IDD).Select(s => s.DISTID).Distinct().ToList();
                var datatable = opa.DISTRICTSDbs.Where(c => c.compid == 2 && (c.ID == acc1 || !list1.Contains(c.ID)))
                                               .OrderBy(c => c.ID)
                                               .Select(c => new { ID = c.ID, Value = c.district });
                

                ViewBag.users1 = new SelectList(dbv.agentsViewDbs.OrderBy(s => s.agentName), "ID", "agentNameID2");
                ViewBag.dist1 = new SelectList(opa.DISTRICTSDbs.Where(c => c.compid == 2 && (c.ID == acc1 || !list1.Contains(c.ID))).OrderBy(c => c.ID).Select(c => new { ID = c.ID, district = c.district }), "ID", "district");
                ViewBag.userid = userIDselectInt;
                ViewBag.data1 = opa.UHSUSAT1SURSERVDbs.Where(s => s.ID == id);

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
        public ActionResult EditEx(UHSUSAT1SURSERVDb model)
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
                UHSUSAT1SURSERVDb UHSUSAT1SURSERVDb = opa.UHSUSAT1SURSERVDbs.Find(id);
                if (UHSUSAT1SURSERVDb == null)
                {
                    return HttpNotFound();
                }
                return View(UHSUSAT1SURSERVDb);
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

            if (userTypeInt == 2 && CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(6)
                                                                                            && returnTaskOrdersIDlist.Contains(61))
            {
                UHSUSAT1SURSERVDb UHSUSAT1SURSERVDb = opa.UHSUSAT1SURSERVDbs.Find(id);
                opa.UHSUSAT1SURSERVDbs.Remove(UHSUSAT1SURSERVDb);
                opa.SaveChanges();
                return RedirectToAction("Index", "uhsuserSS", new { projectID = 6, taskOrderID = 61, Int1 = 1 });
            }
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult getDistrictmap(int ID)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            // get user logged ID int
            int userid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();

            // get userTypeid integer
            int userTypeid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.userType).First();
            ViewBag.userTypeID = userTypeid;

            int distid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.distid).First();
            int usertitle = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.titlid).First();

            if (userTypeid == 2)
            {
                var datatable = opb.UHSWEBAACvDbs.ToList();
                return Json(datatable, JsonRequestBehavior.AllowGet);
            }
            else 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           

        }

        public ActionResult _tableIndexDistrict()
        {
            var data = from s in opb.UHSUSAC1SURSERVDbs select s;
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
