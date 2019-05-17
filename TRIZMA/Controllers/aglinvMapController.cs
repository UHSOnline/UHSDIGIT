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

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66))
            {

                ViewBag.custNo = opa.AGLINVIND1Dbs.Select(s => s.acctid).Distinct().Count();
                ViewBag.manuNo = opc.fctEquipmentManufacturersDbs.Where(s => s.sourceCD == 5).Count();
                ViewBag.typeNo = opc.fctEquipmentTypesDbs.Where(s => s.sourceCD == 5).Count();
                ViewBag.modlNo = opc.fctEquipmentModelsDbs.Where(s => s.sourceCD == 5).Count();

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

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66))
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

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66))
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

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66))
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

                var pgnr = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == ID).OrderBy(s => s.impTypeID).Select(s => new { Device_Category = s.Device_Category
                                                                                                                     , impTypeID = s.impTypeID }).Distinct().ToList();

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
                    var dta = opa.AGLINVMDL1Dbs.Where(s => s.impTypeID == item.impTypeID && s.matchConfrm == true && s.manualInput == false).Count();
                    var dtb = opa.AGLINVMDL1Dbs.Where(s => s.impTypeID == item.impTypeID && s.matchConfrm == true && s.manualInput == true).Count();
                    var dtc = opa.AGLINVMDL1Dbs.Where(s => s.impTypeID == item.impTypeID && s.matchConfrm == false).Count();

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
            var tpank = opc.fctEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.ModelNK == a).Select(s => s.equipmentTypeNK).First();
            var mannk = opc.fctEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.ModelNK == a).Select(s => s.ManufacturerNK).First();
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

            if (userTypeInt == 2 || CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(15) && returnTaskOrdersIDlist.Contains(66))
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

                    var datab = opa.AGLINVMDL2Dbs.OrderBy(s => s.equipmentTypeDescr).Where(s => s.extDocID == a && s.impID == b)
                                                                      .Select(s => new { modelNK = s.modelNK
                                                                                       , dpDesc = s.dpDesc}).ToList();

                    var man = opa.AGLINVMDL2Dbs.Where(s => s.extDocID == a && s.impID == b)
                                               .Select(s => new { manufacturerNK = s.manufacturerNK
                                                                , ManufacturerName = s.ManufacturerName }).Distinct().OrderBy(s => s.ManufacturerName).ToList();

                    var typ = opa.AGLINVMDL2Dbs.OrderBy(s => s.equipmentTypeDescr)
                                               .Where(s => s.extDocID == a && s.impID == b)
                                               .Select(s => new { equipmentTypeNK = s.equipmentTypeNK
                                                                , equipmentTypeDescr = s.equipmentTypeDescr }).Distinct().ToList();

                    var mdd = opa.AGLINVMDL2Dbs.OrderBy(s => s.ModelDescription)
                                               .Where(s => s.extDocID == a && s.impID == b)
                                               .Select(s => new { modelNK = s.modelNK
                                                                , ModelDescription = s.ModelDescription + "     Model: " + s.modelID1
                                               }).ToList();

                    var dss = opa.AGLINVMDL2Dbs.OrderBy(s => s.ModelDescription)
                                               .Where(s => s.extDocID == a && s.impID == b)
                                               .Select(s => s.modelNK).ToList();

                    var mdl = opd.appEquipmentModelsDbs.OrderBy(s => s.modelID1)
                                               .Where(s => dss.Contains(s.ModelNK))
                                               .Select(s => new {
                                                   modelNK = s.ModelNK,
                                                   modelID1 = s.modelID1 + "   (" + s.ModelID2 + ")"
                                               }).ToList();

            

            var ch = opa.AGLINVMDL1Dbs.Where(s => s.extDocID == a && s.modelImpID == b)
                                      .Select(s => new {
                                          modelNK = s.modelNK,
                                          ModelDescription = s.ModelDescription,
                                          ManufacturerNK = s.ManufacturerNK,
                                          manufacturerName = s.manufacturerName,
                                          equipmentTypeNK = s.equipmentTypeNK,
                                          equipmentType = s.equipmentType,
                                          modelID1 = s.modelID1
                                      }).ToList();

            
            foreach (var item in man)
                    {
                        mapDocPageDb List1 = new mapDocPageDb();

                        List1.ID = 1;
                        List1.IDNK = item.manufacturerNK;
                        List1.Desc = item.ManufacturerName;
                        
                        data.Add(List1);
                    }
                    foreach (var item in typ)
                    {
                        mapDocPageDb List1 = new mapDocPageDb();

                        List1.ID = 2;
                        List1.IDNK = item.equipmentTypeNK;
                        List1.Desc = item.equipmentTypeDescr;

                        data.Add(List1);
                    }
                    foreach (var item in mdd)
                    {
                        mapDocPageDb List1 = new mapDocPageDb();

                        List1.ID = 3;
                        List1.IDNK = item.modelNK;
                        List1.Desc = item.ModelDescription;

                        data.Add(List1);
                    }
                    foreach (var item in mdl)
                    {
                        mapDocPageDb List1 = new mapDocPageDb();

                        List1.ID = 4;
                        List1.IDNK = item.modelNK;
                        List1.Desc = item.modelID1;

                        data.Add(List1);
                    }
            

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
                    foreach(var item in ch)
                    {
                        mapDocPageDb List1 = new mapDocPageDb();

                        List1.ID = 13;
                        List1.IDNK = item.modelNK;
                        List1.Desc = item.ModelDescription;
                        data.Add(List1);
                    }
                    foreach(var item in ch)
                    {
                        mapDocPageDb List1 = new mapDocPageDb();

                        List1.ID = 14;
                        List1.IDNK = item.modelNK;
                        List1.Desc = item.modelID1;
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

        public ActionResult getModels(string b, int c)
        {

            if(c == 1)
            {
                var mani = opc.fctEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.ManufacturerNK == b).Select(s => s.equipmentTypeNK).Distinct().ToList();
                var data = opc.fctEquipmentTypesDbs.Where(s => s.sourceCD == 5 && mani.Contains(s.equipmentTypeNK) && s.equipmentTypeDescr != null && s.equipmentTypeDescr != "")
                                                          .Select(s => new {
                                                              equipmentTypeNK = s.equipmentTypeNK
                                                           ,  equipmentTypeDescr = s.equipmentTypeDescr
                                       }).OrderBy(s => s.equipmentTypeDescr).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else if(c == 2)
            {
                var data = opc.fctEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.equipmentTypeNK == b && s.ModelDescription != null && s.ModelDescription != "")
                                                          .Select(s => new {
                                                              ModelNK = s.ModelNK
                                                           ,  ModelDescription = s.ModelDescription + "     Model: " + s.modelID1 + "  (" + s.ModelID2 + ")"
                                                          }).Distinct().OrderBy(s => s.ModelDescription).ToList();

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else if (c == 3)
            {
                var data = opc.fctEquipmentModelsDbs.Where(s => s.sourceCD == 5 && s.ModelNK == b)
                                                          .Select(s => new {
                                                              ModelNK = s.ModelNK
                                                           ,  ModelDescription = s.ModelDescription
                                                           ,  modelID1 = s.modelID1 + "   (" + s.ModelID2 + ")"
                                                          }).Distinct().OrderBy(s => s.ModelDescription).ToList();

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
