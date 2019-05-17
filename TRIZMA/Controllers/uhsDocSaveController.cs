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
    public class uhsDocSaveController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();


        // POST: Edit Doc:1010005
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult uhsomdrec01(UHSOMDREC01Db model)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && (returnTaskOrdersIDlist.Contains(53)
                                                                                                 || returnTaskOrdersIDlist.Contains(55)
                                                                                                 || returnTaskOrdersIDlist.Contains(56)
                                                                                                 || returnTaskOrdersIDlist.Contains(57)
                                                                                                 || returnTaskOrdersIDlist.Contains(58))))
            {
                if (ModelState.IsValid)
                {
                    
                    try
                    {
                        opa.UHSOMDREC01Dbs.Add(model);
                        opa.SaveChanges();

                        int respond = 1;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        int respond = 2;
                        return Json(respond, JsonRequestBehavior.AllowGet);
                        throw (e);
                    }
                }
                else
                {
                    int respond = 3;
                    return Json(respond, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                int respond = 4;
                return Json(respond, JsonRequestBehavior.AllowGet);
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

        


    }
}
