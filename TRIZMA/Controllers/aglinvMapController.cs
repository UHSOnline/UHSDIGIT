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
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TRIZMA.Controllers
{
    public class aglinvMapController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();
        private UHSDMSQLSERV1dataModel opc = new UHSDMSQLSERV1dataModel();
        private UHSTRIZMAdataModel opd = new UHSTRIZMAdataModel();

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
            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeb = userTypeInt;

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66)))
            {

                ViewBag.custNo = opa.AGLINVIND1Dbs.Select(s => s.acctid).Distinct().Count();
                ViewBag.manuNo = opc.fctEquipmentManufacturersDbs.Where(s => s.sourceCD == 5).Count();
                ViewBag.typeNo = opc.fctEquipmentTypesDbs.Where(s => s.sourceCD == 5).Count();
                ViewBag.modlNo = opc.fctEquipmentModelsDbs.Where(s => s.sourceCD == 5).Count();
                ViewBag.svctr = 0;
                ViewBag.docList = opa.AGLINVIND1Dbs.ToList();
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        
        public ActionResult equipManuf(int ID)
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
            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeb = userTypeInt;

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66)))
            {
                
                if (ID == 1)
                {
                    ViewBag.control = ID;
                    ViewBag.data = opd.appEquipmentManufacturersDbs.OrderBy(s => s.Rnm).ToList();
                    
                    return View();
                }
                else
                if (ID == 2)
                {
                    ViewBag.control = ID;
                    ViewBag.data = opd.appEquipmentTypesDbs.OrderBy(s => s.Rnm).ToList();
                    return View();
                }
                else
                if (ID == 3)
                {
                    ViewBag.control = ID;
                    //ViewBag.data = opd.appEquipmentTypesDbs.OrderBy(s => s.Rnm).ToList();
                    //var data = opd.appEquipmentModelsDbs.OrderBy(s => s.Rnm).ToList();
                    return View();
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult searchModel(int id, string ida, string idb)
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
            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeb = userTypeInt;

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66)))
            {


                //if (ida == 1)
                //{
                //    var resp = opd.appEquipmentModelsDbs.Where(s => s.modelID1.Contains(idb) || s.ModelID2.Contains(idb)).OrderBy(s => s.ModelDescription).ToList();
                //    return Json(resp, JsonRequestBehavior.AllowGet);
                //}
                //else 
                //if (ida == 2)
                //{
                //    var resp = opd.appEquipmentModelsDbs.Where(s => s.ModelDescription.Contains(idb)).OrderBy(s => s.ModelDescription).ToList();
                //    return Json(resp, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //}
                if((ida == null || ida == "" || ida == " ") && (idb != null && idb != "" && idb != " "))
                {
                    var resp = opd.appEquipmentModelsDbs.Where(s => s.ModelDescription.Contains(idb)).OrderBy(s => s.ModelDescription).ToList();
                    return Json(resp, JsonRequestBehavior.AllowGet);
                }
                else
                    if((idb == null || idb == "" || idb == " ") && (ida != null && ida != "" && ida != " "))
                {
                    var resp = opd.appEquipmentModelsDbs.Where(s => s.modelID1.Contains(ida) || s.ModelID2.Contains(ida)).OrderBy(s => s.ModelDescription).ToList();
                    return Json(resp, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var resp = opd.appEquipmentModelsDbs.Where(s => (s.modelID1.Contains(ida) || s.ModelID2.Contains(ida)) && s.ModelDescription.Contains(idb)).OrderBy(s => s.ModelDescription).ToList();
                    return Json(resp, JsonRequestBehavior.AllowGet);
                }
               
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult SearchList(string ida, string idb, string idc)
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
            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeb = userTypeInt;

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66)))
            {
                var cnta = opd.appEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.ManufacturerNK == ida && s.equipmentTypeNK == idb && s.ModelNK == idc);
                if(idc == "0" || idc == null || idc == "" || idc == " ")
                {
                    var resp = from s in opd.appEquipmentModelsDbs where s.sourceCD == 5 && (s.ManufacturerNK == ida || s.equipmentTypeNK == idb) select new { s.ModelNK, s.ModelDescription, s.modelID1, s.ModelID2, s.Status, s.equipmentType, s.manufacturer };
                    //System.Diagnostics.Trace.WriteLine(ida);
                    return Json(resp, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var resp = from s in opd.appEquipmentModelsDbs where s.sourceCD == 5 && s.ModelNK == idc select new { s.ModelNK, s.ModelDescription, s.modelID1, s.ModelID2, s.Status, s.equipmentType, s.manufacturer };
                    //System.Diagnostics.Trace.WriteLine(ida);
                    return Json(resp, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult getSingle(string a)
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
            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeb = userTypeInt;

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66)))
            {
                var resp = opd.appEquipmentModelsDbs.Where(s => s.ModelNK == a).ToList();
                return Json(resp, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }           
        }


          
        public ActionResult editDocument(string ID)
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
            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeb = userTypeInt;

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66)))
            {
                ViewBag.manuNo = opa.AGLINVMFC1Dbs.Where(s => s.extDocID == ID).Count();
                ViewBag.modlNo = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID).Count();

                ViewBag.docList = opa.AGLINVIND1Dbs.Where(s => s.ID == ID).ToList();
                ViewBag.manuf = opa.AGLINVMFC1Dbs.Where(s => s.extDocID == ID).OrderBy(s => s.impID).ToList();

                var data = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID).OrderBy(s => s.Device_Category).Select(s => new
                {
                    modelImpID = s.modelImpID
                                                                                                                     ,
                    Device_Category = s.Device_Category
                                                                                                                     ,
                    Model = s.Model
                                                                                                                     ,
                    Manufacturer = s.Manufacturer
                                                                                                                     ,
                    matchSingle = s.matchSingle
                                                                                                                     ,
                    matchMultip = s.matchMultip
                                                                                                                     ,
                    matchConfrm = s.matchConfrm
                                                                                                                     ,
                    manualInput = s.manualInput
                                                                                                                     ,
                    Cnt = s.Cnt
                                                                                                                     ,
                    impTypeID = s.impTypeID
                }).ToList();

                var pgnr = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID).OrderBy(s => s.impTypeID).Select(s => new {
                    Device_Category = s.Device_Category
                                                                                                                     ,
                    impTypeID = s.impTypeID
                }).Distinct().ToList();

                List<AGLINVMDL1shDb> data01 = new List<AGLINVMDL1shDb>();
                foreach (var item in data)
                {
                    AGLINVMDL1shDb List1 = new AGLINVMDL1shDb();

                    List1.Device_Category = item.Device_Category;
                    List1.Model = item.Model;
                    List1.Manufacturer = item.Manufacturer;
                    List1.modelImpID = item.modelImpID;
                    List1.matchSingle = item.matchSingle;
                    List1.matchMultip = item.matchMultip;
                    List1.matchConfrm = item.matchConfrm;
                    List1.manualInput = item.manualInput;
                    List1.Cnt = item.Cnt;
                    List1.impTypeID = item.impTypeID;

                    data01.Add(List1);
                }
                List<AGLINVMDL1pgDb> data02 = new List<AGLINVMDL1pgDb>();
                foreach (var item in pgnr)
                {
                    var dta = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID && s.impTypeID == item.impTypeID && s.matchConfrm == true && s.manualInput == false).Count();
                    var dtb = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID && s.impTypeID == item.impTypeID && s.matchConfrm == true && s.manualInput == true).Count();
                    var dtc = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID && s.impTypeID == item.impTypeID && s.matchConfrm == false).Count();

                    AGLINVMDL1pgDb List1 = new AGLINVMDL1pgDb();
                    List1.Device_Category = item.Device_Category;
                    List1.impTypeID = item.impTypeID;
                    List1.cnta = dta;
                    List1.cntb = dtb;
                    List1.cntc = dtc;
                    data02.Add(List1);
                }

                List<mapDocPageDb> datag = new List<mapDocPageDb>();

                var man = opd.appEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.ManufacturerNK != null && s.ManufacturerNK != "" && s.ManufacturerNK != " " && s.manufacturer != null && s.manufacturer != "" && s.manufacturer != " ")
                                           .Select(s => new {
                                               ManufacturerNK = s.ManufacturerNK
                                                            ,
                                               manufacturer = s.manufacturer
                                           }).Distinct().OrderBy(s => s.manufacturer).ToList();

                var typ = opd.appEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.equipmentTypeNK != null && s.equipmentTypeNK != "" && s.equipmentTypeNK != " " && s.equipmentType != null && s.equipmentType != "" && s.equipmentType != " ")
                                           .Select(s => new {
                                               equipmentTypeNK = s.equipmentTypeNK
                                                            ,
                                               equipmentType = s.equipmentType
                                           }).Distinct().OrderBy(s => s.equipmentType).ToList();

                foreach (var item in man)
                {
                    mapDocPageDb List1 = new mapDocPageDb();

                    List1.ID = 1;
                    List1.IDNK = item.ManufacturerNK;
                    List1.Desc = item.manufacturer;
                    
                    datag.Add(List1);
                }
                foreach (var item in typ)
                {
                    mapDocPageDb List1 = new mapDocPageDb();

                    List1.ID = 2;
                    List1.IDNK = item.equipmentTypeNK;
                    List1.Desc = item.equipmentType;

                    datag.Add(List1);
                }

                ViewBag.docID = ID;
                ViewBag.svctr = 0;
                ViewBag.datab = data01.ToList();
                ViewBag.dataa = data02.ToList();
                ViewBag.datag = datag.ToList();
                //System.Diagnostics.Trace.WriteLine("OVDE BI TREBALO DA SE POJAVI");
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult editDocumentb(string ID)
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
            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeb = userTypeInt;

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66)))
            {
                ViewBag.manuNo = opa.AGLINVMFC1Dbs.Where(s => s.extDocID == ID).Count();
                ViewBag.modlNo = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID).Count();

                ViewBag.docList = opa.AGLINVIND1Dbs.Where(s => s.ID == ID).ToList();
                ViewBag.manuf = opa.AGLINVMFC1Dbs.Where(s => s.extDocID == ID).OrderBy(s => s.impID).ToList();

                var data = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID).OrderBy(s => s.Device_Category).Select(s => new
                {
                    modelImpID = s.modelImpID
                                                                                                                     ,
                    Device_Category = s.Device_Category
                                                                                                                     ,
                    Model = s.Model
                                                                                                                     ,
                    Manufacturer = s.Manufacturer
                                                                                                                     ,
                    matchSingle = s.matchSingle
                                                                                                                     ,
                    matchMultip = s.matchMultip
                                                                                                                     ,
                    matchConfrm = s.matchConfrm
                                                                                                                     ,
                    manualInput = s.manualInput
                                                                                                                     ,
                    Cnt = s.Cnt
                                                                                                                     ,
                    impTypeID = s.impTypeID
                }).ToList();

                var pgnr = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID).OrderBy(s => s.impTypeID).Select(s => new {
                    Device_Category = s.Device_Category
                                                                                                                     ,
                    impTypeID = s.impTypeID
                }).Distinct().ToList();

                List<AGLINVMDL1shDb> data01 = new List<AGLINVMDL1shDb>();
                foreach (var item in data)
                {
                    AGLINVMDL1shDb List1 = new AGLINVMDL1shDb();

                    List1.Device_Category = item.Device_Category;
                    List1.Model = item.Model;
                    List1.Manufacturer = item.Manufacturer;
                    List1.modelImpID = item.modelImpID;
                    List1.matchSingle = item.matchSingle;
                    List1.matchMultip = item.matchMultip;
                    List1.matchConfrm = item.matchConfrm;
                    List1.manualInput = item.manualInput;
                    List1.Cnt = item.Cnt;
                    List1.impTypeID = item.impTypeID;

                    data01.Add(List1);
                }
                List<AGLINVMDL1pgDb> data02 = new List<AGLINVMDL1pgDb>();
                foreach (var item in pgnr)
                {
                    var dta = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID && s.impTypeID == item.impTypeID && s.matchConfrm == true && s.manualInput == false).Count();
                    var dtb = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID && s.impTypeID == item.impTypeID && s.matchConfrm == true && s.manualInput == true).Count();
                    var dtc = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID && s.impTypeID == item.impTypeID && s.matchConfrm == false).Count();

                    AGLINVMDL1pgDb List1 = new AGLINVMDL1pgDb();
                    List1.Device_Category = item.Device_Category;
                    List1.impTypeID = item.impTypeID;
                    List1.cnta = dta;
                    List1.cntb = dtb;
                    List1.cntc = dtc;
                    data02.Add(List1);
                }



                //string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                //using (SqlConnection connection = new SqlConnection(CS))
                //{ 
                //    SqlCommand cmd = new SqlCommand();
                //    cmd.CommandType = System.Data.CommandType.Text;
                //    string textc = "SELECT Device_Category, Model, Manufacturer, modelImpID, matchSingle, matchMultip, matchConfrm, Cnt, impTypeID FROM AGLINVMDL1 where extDocID = '" + ID + "' ORDER BY modelImpID";
                //    cmd.CommandText = textc;                   
                //    connection.Open();                   
                //    using (SqlDataReader reader = cmd.ExecuteReader())
                //    {

                //        while (reader.Read())
                //        {
                //            AGLINVMDL1shDb item = new AGLINVMDL1shDb();
                //            item.Device_Category = reader.GetString(0);
                //            item.Model = reader.GetString(1);
                //            item.Manufacturer = reader.GetString(2);
                //            item.modelImpID = reader.GetInt32(3);
                //            item.matchSingle = reader.GetBoolean(4);
                //            item.matchMultip = reader.GetBoolean(5);
                //            item.matchConfrm = reader.GetBoolean(6);
                //            item.Cnt = reader.GetInt32(7);
                //            item.impTypeID = reader.GetInt32(8);

                //            data01.Add(item);
                //        }
                //    }
                //    connection.Close();

                //}

                ViewBag.docID = ID;

                ViewBag.datab = data01.ToList();
                ViewBag.dataa = data02.ToList();
                //System.Diagnostics.Trace.WriteLine("OVDE BI TREBALO DA SE POJAVI");
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult findSingle(string a)
        {
            var mannk = opc.fctEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.ModelNK == a).Select(s => s.ManufacturerNK).First();
            var tpank = opc.fctEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.ModelNK == a).Select(s => s.equipmentTypeNK).First();
            var md2 = opc.fctEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.ModelNK == a).Select(s => s.modelID1).First();
            var md3 = opc.fctEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.ModelNK == a).Select(s => s.ModelID2).First();
            
            List<fctEquipmentModelsshDb> data = new List<fctEquipmentModelsshDb>();
            fctEquipmentModelsshDb List1 = new fctEquipmentModelsshDb();
            List1.ModelNK = a;
            List1.ModelDescription = opc.fctEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.ModelNK == a).Select(s => s.ModelDescription).First();
            List1.modelID1 = md2 + "  (" + md3 + ")";
            List1.ManufacturerNK = mannk;
            List1.Manufacturer = opc.fctEquipmentManufacturersDbs.Where(s => s.sourceCD == 5 && s.ManufacturerNK == mannk).Select(s => s.ManufacturerName).First();
            List1.equipmentTypeNK = tpank;
            List1.equipmentType = opc.fctEquipmentTypesDbs.Where(s => s.sourceCD == 5 && s.equipmentTypeNK == tpank).Select(s => s.equipmentTypeDescr).First();
            data.Add(List1);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult comMap(int a, string b)
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
            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeb = userTypeInt;

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66)))
            {
                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procAGLINVCOM", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@iden", a);
                    cmd.Parameters.AddWithValue("@stra", b);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(conID);

                    return Json(ddID, JsonRequestBehavior.AllowGet);
                }
                
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult popDrop(string a, int b)
        {
            
            List<mapDocPageDb> data = new List<mapDocPageDb>();

            var ch = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == a && s.modelImpID == b)
                                      .Select(s => new {
                                          modelNK = s.modelNK,
                                          ModelDescription = s.ModelDescription,
                                          ManufacturerNK = s.ManufacturerNK,
                                          manufacturerName = s.manufacturerName,
                                          equipmentTypeNK = s.equipmentTypeNK,
                                          equipmentType = s.equipmentType,
                                          modelID1 = s.modelID1,
                                          matchConfrm = s.matchConfrm
                                      }).ToList();

            
            
            foreach (var item in ch)
                    {
                        mapDocPageDb List1 = new mapDocPageDb();

                        List1.ID = 11;
                        List1.IDNK = item.ManufacturerNK;
                        List1.Desc = item.manufacturerName;
                        data.Add(List1);
                    }

            foreach (var item in ch)
            {
                mapDocPageDb List1 = new mapDocPageDb();

                List1.ID = 12;
                List1.IDNK = item.equipmentTypeNK;
                List1.Desc = item.equipmentType;
                data.Add(List1);
            }
            foreach (var item in ch)
            {
                mapDocPageDb List1 = new mapDocPageDb();
                string mom = null;
                if(item.modelNK == null)
                {
                    mom = "";
                }
                else
                {
                    mom = "   (Model: " + item.modelID1 + ")";
                }
                List1.ID = 13;
                List1.IDNK = item.modelNK;
                List1.Desc = item.ModelDescription + mom;
                data.Add(List1);
            }
            foreach (var item in ch)
            {
                mapDocPageDb List1 = new mapDocPageDb();

                List1.ID = 14;
                List1.IDNK = item.modelNK;
                List1.Desc = item.modelID1;
                data.Add(List1);
            }
            foreach (var item in ch)
            {
                mapDocPageDb List1 = new mapDocPageDb();

                List1.ID = 15;
                List1.IDNK = null;
                List1.Desc = null;
                List1.chck = item.matchConfrm;
                data.Add(List1);
            }

            return Json(data, JsonRequestBehavior.AllowGet);
            
        }

        public ActionResult getAll(int a)
        {
            if(a == 1)
            {
                var data = opc.fctEquipmentManufacturersDbs.Where(s => s.sourceCD == 5 && s.ManufacturerName != null && s.ManufacturerName != "")
                                       .Select(s => new {
                                           ManufacturerNK = s.ManufacturerNK
                                                        ,
                                           ManufacturerName = s.ManufacturerName
                                       }).OrderBy(s => s.ManufacturerName).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
                if(a == 2)
            {
                var data = opc.fctEquipmentTypesDbs.Where(s => s.sourceCD == 5 && s.equipmentTypeDescr != null && s.equipmentTypeDescr != "")
                                          .Select(s => new {
                                              equipmentTypeNK = s.equipmentTypeNK
                                                           ,
                                              equipmentTypeDescr = s.equipmentTypeDescr
                                          }).OrderBy(s => s.equipmentTypeDescr).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);

            }
            else
                if (a == 3)
            {
                var data = opd.appEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.ModelDescription != null && s.ModelDescription != "")
                                          .Select(s => new {
                                              ModelNK = s.ModelNK
                                                           ,
                                              ModelApp = s.ModelApp
                                          }).OrderBy(s => s.ModelApp).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public ActionResult getModels(string a, string b)
        {
            List<mapDocPageDb> data = new List<mapDocPageDb>();

            if (a == "0" || a == "" || a == null)
            {
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (b == "0" || b == "" || b == null)
                {
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var mod = opd.appEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.ManufacturerNK == a && s.equipmentTypeNK == b).Select(s => new {
                                              ModelNK = s.ModelNK
                                                           ,
                                              ModelDescription = s.ModelDescription + "   (Model: " + s.modelID1 + ")"
                                          }).Distinct().OrderBy(s => s.ModelDescription).ToList();
                    foreach (var item in mod)
                    {
                        mapDocPageDb List1 = new mapDocPageDb();
                        List1.ID = 3;
                        List1.IDNK = item.ModelNK;
                        List1.Desc = item.ModelDescription;
                        data.Add(List1);
                    }
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
        }
        public ActionResult getDetail(string a)
        {
            var data = opc.fctEquipmentModelsDbs.OrderBy(s => s.ModelDescription)
                                       .Where(s => s.sourceCD == 5 && s.ModelNK == a)
                                       .Select(s => new {
                                           ModelNK = s.ModelNK,
                                           ModelDescription = s.ModelDescription,
                                           modelID1 = s.modelID1
                                       }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public ActionResult docOverview(string ID)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66)))
            {
                var lista = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID).Select(s => new { Device_Category = s.Device_Category, impTypeID = s.impTypeID }).Distinct().ToList();
                List<AGLINVMDL1pgDb> data02 = new List<AGLINVMDL1pgDb>();
                foreach (var item in lista)
                {
                    var dta = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID && s.impTypeID == item.impTypeID && s.matchConfrm == true && s.manualInput == false).Count();
                    var dtb = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID && s.impTypeID == item.impTypeID && s.matchConfrm == true && s.manualInput == true).Count();
                    var dtc = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID && s.impTypeID == item.impTypeID && s.matchConfrm == false).Count();

                    AGLINVMDL1pgDb List1 = new AGLINVMDL1pgDb();
                    List1.Device_Category = item.Device_Category;
                    List1.impTypeID = item.impTypeID;
                    List1.cnta = dta;
                    List1.cntb = dtb;
                    List1.cntc = dtc;
                    data02.Add(List1);
                }

                ViewBag.accountID = opa.AGLINVIND1Dbs.Where(s => s.ID == ID).Select(s => s.acctid).First();
                ViewBag.account = opa.AGLINVIND1Dbs.Where(s => s.ID == ID).Select(s => s.acctName).First();
                ViewBag.date = opa.AGLINVIND1Dbs.Where(s => s.ID == ID).Select(s => s.docDate).First();
                ViewBag.docID = ID;
                ViewBag.matccon = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID && s.matchConfrm == true && s.manualInput == false).Count();
                ViewBag.matcnew = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID && s.matchConfrm == true && s.manualInput == true).Count();
                ViewBag.matcnot = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID && s.matchConfrm == false).Count();
                ViewBag.data02 = data02;

                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }


        public ActionResult invCheckUp(int IDC, string ID)
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
            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeb = userTypeInt;

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66)))
            {
                ViewBag.accountID = opa.AGLINVIND1Dbs.Where(s => s.ID == ID).Select(s => s.acctid).First();
                ViewBag.account = opa.AGLINVIND1Dbs.Where(s => s.ID == ID).Select(s => s.acctName).First();
                ViewBag.date = opa.AGLINVIND1Dbs.Where(s => s.ID == ID).Select(s => s.docDate).First();
                ViewBag.docID = ID;

                return View();

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult checkFind(string ID, string a, string b, string c, string d, string e, string f, string g)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66)))
            {

                var parta = "select ID, Device_Category, Model, Manufacturer, ModelDescription, modelID1, modelID2, equipmentType, manufacturerName, checkUp, Control_Number, Owner_Department, Scheduling_Department, Serial_Number, SN_Modified, STATUS2, Risk_Group, Asset_Center from AGLINVMDLDATA where extDocID = '" + ID + "'";
                var partb = "";
                var seprt = " and ";

                
               
                
                if (a == null || a == "" || a == " ")
                {
                    seprt = " and ";
                }
                else
                {
                    partb = seprt + "(Model like '%" + a + "%' or modelID1 like '%" + a + "%' or modelID2 like '%" + a + "%')";
                }
                
                if (b == null || b == "" || b == " ")
                {
                    seprt = " and ";
                }
                else
                {
                    partb = partb + seprt + "(Device_Category like '%" + b + "%' or ModelDescription like '%" + b + "%')";
                }
                
                if (c == null || c == "" || c == " ")
                {
                    seprt = " and ";
                }
                else
                {
                    partb = partb + seprt + "(Manufacturer like '%" + c + "%' or manufacturerName like '%" + c + "%')";
                }
                
                if (d == null || d == "" || d == " ")
                {
                    seprt = " and ";
                }
                else
                {
                    partb = partb + seprt + "(Owner_Department like '%" + d + "%')";
                }
                
                if (e == null || e == "" || e == " ")
                {
                    seprt = " and ";
                }
                else
                {
                    partb = partb + seprt + "(Scheduling_Department like '%" + e + "%')";
                }
                
                if (f == null || f == "" || f == " ")
                {
                    seprt = " and ";
                }
                else
                {
                    partb = partb + seprt + "(Control_Number like '%" + f + "%')";
                }
                
                if (g == null || g == "" || g == " ")
                {
                    seprt = " and ";
                }
                else
                {
                    partb = partb + seprt + "(Serial_Number like '%" + g + "%' or SN_Modified like '%" + g + "%')";
                }

                string sqlStatment = parta + partb;
                string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constr))
                {
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlStatment, con))
                    {
                        cmd.Connection.Open();
                        System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                        List<AGLINVMDLDATApg> data = new List<AGLINVMDLDATApg>();
                        while (reader.Read())
                        {
                            AGLINVMDLDATApg fill = new AGLINVMDLDATApg();
                            fill.ID = reader.GetValue(0).ToString();
                            fill.DA = reader.GetValue(1).ToString();
                            fill.MA = reader.GetValue(2).ToString();
                            fill.TA = reader.GetValue(1).ToString();
                            fill.FA = reader.GetValue(3).ToString();
                            fill.DB = reader.GetValue(4).ToString();
                            fill.MB = reader.GetValue(5).ToString() + "  (" + reader.GetValue(6).ToString() + ")";
                            fill.TB = reader.GetValue(7).ToString();
                            fill.FB = reader.GetValue(8).ToString();
                            fill.CH = Convert.ToBoolean(reader.GetValue(9));
                            fill.RA = reader.GetValue(10).ToString();
                            fill.RB = reader.GetValue(11).ToString();
                            fill.RC = reader.GetValue(12).ToString();
                            fill.RD = reader.GetValue(13).ToString();
                            fill.RE = reader.GetValue(14).ToString();
                            fill.RF = reader.GetValue(15).ToString();
                            fill.RG = reader.GetValue(16).ToString();
                            fill.RH = reader.GetValue(17).ToString();
                            
                            data.Add(fill);
                        }

                        reader.Close();
                        cmd.Connection.Close();

                        //ViewBag.data = data.ToList();
                        return Json(data.ToList(), JsonRequestBehavior.AllowGet);
                    }
                }


            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult findTypeId(string ID, string a, string b, string c, string d, string e, string f)
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

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66)))
            {
                var parta = "select distinct impTypeID from AGLINVMDLDATA where extDocID = '" + ID + "'";
                var partb = "";
                var seprt = " and ";




                if (a == null || a == "" || a == " ")
                {
                    seprt = " and ";
                }
                else
                {
                    partb = seprt + "(Model like '%" + a + "%')";
                }

                if (b == null || b == "" || b == " ")
                {
                    seprt = " and ";
                }
                else
                {
                    partb = partb + seprt + "(Device_Category like '%" + b + "%')";
                }

                if (c == null || c == "" || c == " ")
                {
                    seprt = " and ";
                }
                else
                {
                    partb = partb + seprt + "(Manufacturer like '%" + c + "%')";
                }

                if (d == null || d == "" || d == " ")
                {
                    seprt = " and ";
                }
                else
                {
                    partb = partb + seprt + "(Owner_Department like '%" + d + "%' or Scheduling_Department like '%" + d + "%')";
                }

                if (e == null || e == "" || e == " ")
                {
                    seprt = " and ";
                }
                else
                {
                    partb = partb + seprt + "(Control_Number like '%" + e + "%')";
                }

                if (f == null || f == "" || f == " ")
                {
                    seprt = " and ";
                }
                else
                {
                    partb = partb + seprt + "(Serial_Number like '%" + f + "%' or SN_Modified like '%" + f + "%')";
                }

                string sqlStatment = parta + partb + " order by impTypeID";
                string constr = System.Configuration.ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constr))
                {
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlStatment, con))
                    {
                        cmd.Connection.Open();
                        System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                        List<AGLINVMDL1pgDb> data = new List<AGLINVMDL1pgDb>();
                        while (reader.Read())
                        {
                            AGLINVMDL1pgDb fill = new AGLINVMDL1pgDb();
                            fill.impTypeID = Convert.ToInt32(reader.GetValue(0));
                            
                            data.Add(fill);
                        }

                        reader.Close();
                        cmd.Connection.Close();

                        //ViewBag.data = data.ToList();
                        return Json(data.ToList(), JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult checkSingle(int IDC, string IDA)
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

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66))
            {
                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procAGLINVCHK", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDC", IDC);
                    cmd.Parameters.AddWithValue("@IDA", IDA);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(conID);

                    return Json(ddID, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        
        public ActionResult searchUnit(int id, string ida, string idb, string idc, string idd, string ide, string idf, string idg)
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
            ViewBag.userID = userIDselectInt;
            ViewBag.userTypeb = userTypeInt;

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66))
            {


                //if (ida == 1)
                //{
                //    var resp = opd.appEquipmentModelsDbs.Where(s => s.modelID1.Contains(idb) || s.ModelID2.Contains(idb)).OrderBy(s => s.ModelDescription).ToList();
                //    return Json(resp, JsonRequestBehavior.AllowGet);
                //}
                //else 
                //if (ida == 2)
                //{
                //    var resp = opd.appEquipmentModelsDbs.Where(s => s.ModelDescription.Contains(idb)).OrderBy(s => s.ModelDescription).ToList();
                //    return Json(resp, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //}
                if ((ida == null || ida == "" || ida == " ") && (idb != null && idb != "" && idb != " "))
                {
                    var resp = opd.appEquipmentModelsDbs.Where(s => s.ModelDescription.Contains(idb)).OrderBy(s => s.ModelDescription).ToList();
                    return Json(resp, JsonRequestBehavior.AllowGet);
                }
                else
                    if ((idb == null || idb == "" || idb == " ") && (ida != null && ida != "" && ida != " "))
                {
                    var resp = opd.appEquipmentModelsDbs.Where(s => s.modelID1.Contains(ida) || s.ModelID2.Contains(ida)).OrderBy(s => s.ModelDescription).ToList();
                    return Json(resp, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var resp = opd.appEquipmentModelsDbs.Where(s => (s.modelID1.Contains(ida) || s.ModelID2.Contains(ida)) && s.ModelDescription.Contains(idb)).OrderBy(s => s.ModelDescription).ToList();
                    return Json(resp, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }



        public ActionResult Delete(string IDc)
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

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66))
            {

                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procSSCYCCNTM1delete", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDc", IDc);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(conID);

                    return Json(ddID, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }



















        public ActionResult _tableIndexUserCycCnt1()
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
            ViewBag.userType = userTypeInt;

            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64)))
            {
                //System.Diagnostics.Debug.WriteLine("Uslo u IF");
                List<SSCYCCNTM1vDb> data01 = new List<SSCYCCNTM1vDb>();
                if(userTypeInt == 2)
                {
                    var itemdt = opb.SSCYCCNTM1vDbs.Select(s => new { IDc = s.IDc, comboDistrict = s.comboDistrict, comboName = s.comboName, crdate = s.crdate, lckdc = s.lckdc }).Distinct().ToList();
                    foreach (var item in itemdt)
                    {
                        SSCYCCNTM1vDb List1 = new SSCYCCNTM1vDb();
                        List1.IDc = item.IDc; List1.comboDistrict = item.comboDistrict; List1.comboName = item.comboName; List1.crdate = item.crdate; List1.lckdc = item.lckdc;
                        data01.Add(List1);
                    }
                }
                else
                {
                    var itemdt = opb.SSCYCCNTM1vDbs.Where(s => s.crusid == userIDselectInt).Select(s => new { IDc = s.IDc, comboDistrict = s.comboDistrict, comboName = s.comboName, crdate = s.crdate, lckdc = s.lckdc }).Distinct().ToList();      
                    foreach (var item in itemdt)
                    {
                        SSCYCCNTM1vDb List1 = new SSCYCCNTM1vDb();
                        List1.IDc = item.IDc; List1.comboDistrict = item.comboDistrict; List1.comboName = item.comboName; List1.crdate = item.crdate; List1.lckdc = item.lckdc;
                        data01.Add(List1);
                    }
                }

                return PartialView(data01);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        public ActionResult Create(string whsid, string userID)
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
            ViewBag.userTypeID = userTypeInt;
            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64)))
            {
                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procSSCYCCNTM1create", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@wrhsid", whsid);
                    cmd.Parameters.AddWithValue("@crusid", userID);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(conID);

                    return Json(ddID, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        public ActionResult Edit(string IDc)
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
            ViewBag.userTypeID = userTypeInt;
            if (userTypeInt == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64)))
            {
                //System.Diagnostics.Debug.WriteLine("Uslo u IF");
                var crdate = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.crdate).First();
                ViewBag.crdate = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.crdate).First();
                ViewBag.distid = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.DistID).First();

                ViewBag.comboDistrict = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.comboDistrict).First();
                ViewBag.whs = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.wareHouse).First();
                ViewBag.comboName = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.comboName).First();
                ViewBag.itstnos = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.ITSTNO).ToList();
                ViewBag.lckdc = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).Select(s => s.lckdc).First();
                ViewBag.userID = userIDselectInt;
                ViewBag.docID = IDc;
                ViewBag.mnth = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateID == crdate).Select(s => s.MonthName).First();
                var mnthNm = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateID == crdate).Select(s => s.MonthNbr).First();
                ViewBag.districts = new SelectList(opd.dimWhsDistDbs.OrderBy(c => c.WhseDistrictAssignment).Select(c => new { ID = c.WhseDistrictAssignment, Value = c.parentWhsDesc }).Distinct(), "ID", "Value").ToList();
                var datatable = opb.SSCYCCNTM1vDbs.Where(s => s.IDc == IDc).OrderBy(s => s.linnr).ToList();

                return View(datatable);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        public ActionResult Filldd1(int ID)
        {
            var dos = DateTime.Now.ToString("yyyyMM");
            int curdtymd = int.Parse(dos);
            List<string> whslist = opb.SSCYCCNTM1vDbs.Where(s => s.DistID == ID && s.cryymm == curdtymd)
                             .Select(s => s.wareHouse)
                             .ToList();

            var datatable = opd.dimWhsDistDbs.OrderBy(s => s.TechWhse).Where(s => (s.ID == 0 || s.WhseDistrictAssignment == ID) && !whslist.Contains(s.TechWhse)).Select(s => new { ID = s.TechWhse, Value = s.comboDrop });
            return Json(datatable, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Filldd2()
        {
            var datatable = opb.SSCYCCNTM1ssitstnoDbs.Select(s => new { ID = s.ITSTNO, comboName = s.comboName}).ToList();
            return Json(datatable, JsonRequestBehavior.AllowGet);
        }
        public ActionResult addNewIstno(int ID)
        {
            var datatable = opb.SSCYCCNTM1ssitstnoDbs.Where(s => s.ITSTNO == ID).ToList();
            return Json(datatable, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Save(string data)
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

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64))
            {
                
                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procSSCYCCNTM1update", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@data", data);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(conID);

                    return Json(ddID, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
              
        }
        

        public ActionResult DeleteSingle(string IDc)
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

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64))
            {

                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procSSCYCCNTM1deleteSingle", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDc", IDc);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int itstno = Int32.Parse(conID);

                    return Json(itstno, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }


        public ActionResult exportDoc(string IDc)
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

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64))
            {

                string CS = ConfigurationManager.ConnectionStrings["DATAOPBConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procSSCYCCNTM1export", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDc", IDc);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(conID);

                    return Json(ddID, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        public ActionResult lockDoc(string IDc, int Int1)
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

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(14) && returnTaskOrdersIDlist.Contains(64))
            {

                string CS = ConfigurationManager.ConnectionStrings["DATAOPAConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("procSSCYCCNTM1lockDoc", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDc", IDc);
                    cmd.Parameters.AddWithValue("@Int1", Int1);

                    SqlParameter outputParameter = new SqlParameter();
                    outputParameter.ParameterName = "@ID";
                    outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    string conID = outputParameter.Value.ToString();
                    int ddID = Int32.Parse(conID);

                    return Json(ddID, JsonRequestBehavior.AllowGet);
                }

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
        

    }
}
