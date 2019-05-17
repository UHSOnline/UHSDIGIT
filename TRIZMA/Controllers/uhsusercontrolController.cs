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
    public class uhsusercontrolController : Controller
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
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        public ActionResult _selectbuttons(int id1)
        {
            ViewBag.btnSel = id1;
            return PartialView("_selectbuttons");
        }
        public ActionResult _selectbuttonsb(int id1)
        {
            ViewBag.btnSelb = id1;
            return PartialView("_selectbuttonsb");
        }
        public ActionResult userstruct1(int projectID, int taskOrderID, int Int1)
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

            if (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13) && returnTaskOrdersIDlist.Contains(60))
            {
                var list = opb.UHSWEBUSRCONDbs.Where(s => s.A360CSTNM != null && s.distid != 0).Select(s => new { regid = s.regid, region = s.region}).Distinct();
                List<UHSWEBUSRCONDb> dataA360 = new List<UHSWEBUSRCONDb>();
                foreach (var item in list)
                {
                    UHSWEBUSRCONDb set1 = new UHSWEBUSRCONDb();
                    set1.regid = item.regid;
                    set1.region = item.region;
                    dataA360.Add(set1);
                }
                ViewBag.dataA360 = dataA360;

                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult _getdivA360(int ID)
        {
            var list = opb.UHSWEBUSRCONDbs.Where(s => s.A360CSTNM != null && s.regid == ID && s.distid != 0).Select(s => new { divid = s.divid, division = s.division }).Distinct();
            List<UHSWEBUSRCONDb> dataA360 = new List<UHSWEBUSRCONDb>();
            foreach (var item in list)
            {
                UHSWEBUSRCONDb set1 = new UHSWEBUSRCONDb();
                set1.divid = item.divid;
                set1.division = item.division;
                dataA360.Add(set1);
            }
            ViewBag.divA360 = dataA360;
            return PartialView("_getdivA360", dataA360.ToList());
        }
        public ActionResult _getdistA360(int ID)
        {
            var list = opb.UHSWEBUSRCONDbs.Where(s => s.A360CSTNM != null && s.divid == ID && s.distid != 0).Select(s => new { distid = s.distid, district = s.district }).Distinct();
            List<UHSWEBUSRCONDb> distA360 = new List<UHSWEBUSRCONDb>();
            foreach (var item in list)
            {
                UHSWEBUSRCONDb set1 = new UHSWEBUSRCONDb();
                set1.divid = item.distid;
                set1.division = item.district;
                distA360.Add(set1);
            }
            return PartialView("_getdistA360", distA360.ToList());
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
