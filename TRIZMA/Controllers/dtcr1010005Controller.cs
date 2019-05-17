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


namespace TRIZMA.Controllers
{
    public class dtcr1010005Controller : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();
        // GET: dtcr1010005
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getCrPar1010005(int distid, int acctid, int actype, int dctpid, int tspdid, string docid)
        {
            //System.Diagnostics.Debug.WriteLine(docid);

            // get user logged ID string
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            // get user logged ID int
            int userid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();

            // get userTypeid integer
            int userTypeid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.userType).First();
            ViewBag.userTypeID = userTypeid;

            string userName = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();

            var yer = DateTime.Now.ToString("yyyy");
            int yer1 = int.Parse(yer);

            var dtt = DateTime.Now.ToString("yyyyMM");
            int dtt1 = int.Parse(dtt);

            var dts = DateTime.Now.ToString("yyyyMMdd");
            int dt1 = int.Parse(dts);

            var zdate = DateTime.Now.ToString("yyyy-MM-dd");
            var daych = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateID == zdate).Select(s => s.wstymd).First();
            var weekch = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateID == zdate).Select(s => s.WeekNbr).First();
            var quatch = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateID == zdate).Select(s => s.QuarterExc).First();

            if (actype == 2)
            {

                if (dctpid == 1010005 && tspdid == 1)
                {
                    string docNewid = dt1 + "D" + distid + "A" + acctid + "GR1010DC1010005TS1";

                    string district = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSOMD01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010005 = new
                        {
                            docid = docNewid
                          ,
                            userid = userid
                          ,
                            actype = 2
                          ,
                            zdist = district
                          ,
                            zperd = dtt1
                          ,
                            zdate = zdate
                          ,
                            zuser = userName
                          ,
                            distid = distid
                          ,
                            dctpid = dctpid
                          ,
                            tspdid = tspdid
                          ,
                            acctid = acctid
                          ,
                            period = dtt1
                        };

                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var diid = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.distnm).First();
                        var period = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.yyyymm).First();
                        var date = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crdate).First();
                        var uname = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crusnm).First();

                        var dtcr1010005 = new
                        {
                            ID = 0
                          ,
                            zdist = diid
                          ,
                            zperd = period
                          ,
                            zdate = date
                          ,
                            zuser = uname
                          ,
                            distid = distid
                        };
                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                if (dctpid == 1010005 && tspdid == 2)
                {
                    string docNewid = daych + weekch + "D" + distid + "A" + acctid + "GR1010DC1010005TS2";

                    string district = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSOMD01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010005 = new
                        {
                            docid = docNewid
                          ,
                            userid = userid
                          ,
                            actype = 2
                          ,
                            zdist = district
                          ,
                            zperd = dtt1
                          ,
                            zdate = zdate
                          ,
                            zuser = userName
                          ,
                            distid = distid
                          ,
                            dctpid = dctpid
                          ,
                            tspdid = tspdid
                          ,
                            acctid = acctid
                          ,
                            period = dtt1
                        };

                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var diid = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.distnm).First();
                        var period = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.yyyymm).First();
                        var date = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crdate).First();
                        var uname = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crusnm).First();

                        var dtcr1010005 = new
                        {
                            ID = 0
                          ,
                            zdist = diid
                          ,
                            zperd = period
                          ,
                            zdate = date
                          ,
                            zuser = uname
                          ,
                            distid = distid
                        };
                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                if (dctpid == 1010005 && tspdid == 3)
                {
                    string docNewid = dtt + "D" + distid + "A" + acctid + "GR1010DC1010005TS3";

                    string district = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSOMD01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010005 = new
                        {
                            docid = docNewid
                          ,
                            userid = userid
                          ,
                            actype = 2
                          ,
                            zdist = district
                          ,
                            zperd = dtt1
                          ,
                            zdate = zdate
                          ,
                            zuser = userName
                          ,
                            distid = distid
                          ,
                            dctpid = dctpid
                          ,
                            tspdid = tspdid
                          ,
                            acctid = acctid
                          ,
                            period = dtt1
                        };

                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var diid = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.distnm).First();
                        var period = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.yyyymm).First();
                        var date = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crdate).First();
                        var uname = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crusnm).First();

                        var dtcr1010005 = new
                        {
                            ID = 0
                          ,
                            zdist = diid
                          ,
                            zperd = period
                          ,
                            zdate = date
                          ,
                            zuser = uname
                          ,
                            distid = distid
                        };
                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                    if (dctpid == 1010006 && tspdid == 1)
                {
                    string docNewid = dt1 + "D" + distid + "A" + acctid + "GR1010DC1010006TS1";

                    string district = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSOMD01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010005 = new
                        {
                            docid = docNewid
                          ,
                            userid = userid
                          ,
                            actype = 2
                          ,
                            zdist = district
                          ,
                            zperd = dtt1
                          ,
                            zdate = zdate
                          ,
                            zuser = userName
                          ,
                            distid = distid
                          ,
                            dctpid = dctpid
                          ,
                            tspdid = tspdid
                          ,
                            acctid = acctid
                          ,
                            period = dtt1
                        };

                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var diid = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.distnm).First();
                        var period = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.yyyymm).First();
                        var date = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crdate).First();
                        var uname = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crusnm).First();

                        var dtcr1010005 = new
                        {
                            ID = 0
                          ,
                            zdist = diid
                          ,
                            zperd = period
                          ,
                            zdate = date
                          ,
                            zuser = uname
                          ,
                            distid = distid
                        };
                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                    if (dctpid == 1010006 && tspdid == 2)
                {
                    string docNewid = daych + weekch + "D" + distid + "A" + acctid + "GR1010DC1010006TS2";

                    string district = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSOMD01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010005 = new
                        {
                            docid = docNewid
                          ,
                            userid = userid
                          ,
                            actype = 2
                          ,
                            zdist = district
                          ,
                            zperd = dtt1
                          ,
                            zdate = zdate
                          ,
                            zuser = userName
                          ,
                            distid = distid
                          ,
                            dctpid = dctpid
                          ,
                            tspdid = tspdid
                          ,
                            acctid = acctid
                          ,
                            period = dtt1
                        };

                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var diid = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.distnm).First();
                        var period = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.yyyymm).First();
                        var date = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crdate).First();
                        var uname = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crusnm).First();

                        var dtcr1010005 = new
                        {
                            ID = 0
                          ,
                            zdist = diid
                          ,
                            zperd = period
                          ,
                            zdate = date
                          ,
                            zuser = uname
                          ,
                            distid = distid
                        };
                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                    if (dctpid == 1010006 && tspdid == 3)
                {
                    string docNewid = dtt + "D" + distid + "A" + acctid + "GR1010DC1010006TS3";

                    string district = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSOMD01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010005 = new
                        {
                            docid = docNewid
                          ,
                            userid = userid
                          ,
                            actype = 2
                          ,
                            zdist = district
                          ,
                            zperd = dtt1
                          ,
                            zdate = zdate
                          ,
                            zuser = userName
                          ,
                            distid = distid
                          ,
                            dctpid = dctpid
                          ,
                            tspdid = tspdid
                          ,
                            acctid = acctid
                          ,
                            period = dtt1
                        };

                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var diid = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.distnm).First();
                        var period = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.yyyymm).First();
                        var date = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crdate).First();
                        var uname = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crusnm).First();

                        var dtcr1010005 = new
                        {
                            ID = 0
                          ,
                            zdist = diid
                          ,
                            zperd = period
                          ,
                            zdate = date
                          ,
                            zuser = uname
                          ,
                            distid = distid
                        };
                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                    if (dctpid == 1010006 && tspdid == 4)
                {
                    string docNewid = yer + quatch + "D" + distid + "A" + acctid + "GR1010DC1010006TS4";

                    string district = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSOMD01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010005 = new
                        {
                            docid = docNewid
                          ,
                            userid = userid
                          ,
                            actype = 2
                          ,
                            zdist = district
                          ,
                            zperd = dtt1
                          ,
                            zdate = zdate
                          ,
                            zuser = userName
                          ,
                            distid = distid
                          ,
                            dctpid = dctpid
                          ,
                            tspdid = tspdid
                          ,
                            acctid = acctid
                          ,
                            period = dtt1
                        };

                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var diid = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.distnm).First();
                        var period = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.yyyymm).First();
                        var date = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crdate).First();
                        var uname = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crusnm).First();

                        var dtcr1010005 = new
                        {
                            ID = 0
                          ,
                            zdist = diid
                          ,
                            zperd = period
                          ,
                            zdate = date
                          ,
                            zuser = uname
                          ,
                            distid = distid
                        };
                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                    if (dctpid == 1010006 && tspdid == 5)
                {
                    string docNewid = yer + "D" + distid + "A" + acctid + "GR1010DC1010006TS5";

                    string district = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSOMD01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010005 = new
                        {
                            docid = docNewid
                          ,
                            userid = userid
                          ,
                            actype = 2
                          ,
                            zdist = district
                          ,
                            zperd = dtt1
                          ,
                            zdate = zdate
                          ,
                            zuser = userName
                          ,
                            distid = distid
                          ,
                            dctpid = dctpid
                          ,
                            tspdid = tspdid
                          ,
                            acctid = acctid
                          ,
                            period = dtt1
                        };

                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var diid = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.distnm).First();
                        var period = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.yyyymm).First();
                        var date = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crdate).First();
                        var uname = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crusnm).First();

                        var dtcr1010005 = new
                        {
                            ID = 0
                          ,
                            zdist = diid
                          ,
                            zperd = period
                          ,
                            zdate = date
                          ,
                            zuser = uname
                          ,
                            distid = distid
                        };
                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                    if (dctpid == 1010007 && tspdid == 1)
                {
                    string docNewid = dt1 + "D" + distid + "A" + acctid + "GR1010DC1010007TS1";

                    string district = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSOMD01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010005 = new
                        {
                            docid = docNewid
                          ,
                            userid = userid
                          ,
                            actype = 2
                          ,
                            zdist = district
                          ,
                            zperd = dtt1
                          ,
                            zdate = zdate
                          ,
                            zuser = userName
                          ,
                            distid = distid
                          ,
                            dctpid = dctpid
                          ,
                            tspdid = tspdid
                          ,
                            acctid = acctid
                          ,
                            period = dtt1
                        };

                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var diid = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.distnm).First();
                        var period = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.yyyymm).First();
                        var date = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crdate).First();
                        var uname = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crusnm).First();

                        var dtcr1010005 = new
                        {
                            ID = 0
                          ,
                            zdist = diid
                          ,
                            zperd = period
                          ,
                            zdate = date
                          ,
                            zuser = uname
                          ,
                            distid = distid
                        };
                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                    if (dctpid == 1010007 && tspdid == 2)
                {
                    string docNewid = daych + weekch + "D" + distid + "A" + acctid + "GR1010DC1010007TS2";

                    string district = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSOMD01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010005 = new
                        {
                            docid = docNewid
                          ,
                            userid = userid
                          ,
                            actype = 2
                          ,
                            zdist = district
                          ,
                            zperd = dtt1
                          ,
                            zdate = zdate
                          ,
                            zuser = userName
                          ,
                            distid = distid
                          ,
                            dctpid = dctpid
                          ,
                            tspdid = tspdid
                          ,
                            acctid = acctid
                          ,
                            period = dtt1
                        };

                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var diid = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.distnm).First();
                        var period = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.yyyymm).First();
                        var date = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crdate).First();
                        var uname = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crusnm).First();

                        var dtcr1010005 = new
                        {
                            ID = 0
                          ,
                            zdist = diid
                          ,
                            zperd = period
                          ,
                            zdate = date
                          ,
                            zuser = uname
                          ,
                            distid = distid
                        };
                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                    if (dctpid == 1010007 && tspdid == 3)
                {
                    string docNewid = dtt + "D" + distid + "A" + acctid + "GR1010DC1010007TS3";

                    string district = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSOMD01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010005 = new
                        {
                            docid = docNewid
                          ,
                            userid = userid
                          ,
                            actype = 2
                          ,
                            zdist = district
                          ,
                            zperd = dtt1
                          ,
                            zdate = zdate
                          ,
                            zuser = userName
                          ,
                            distid = distid
                          ,
                            dctpid = dctpid
                          ,
                            tspdid = tspdid
                          ,
                            acctid = acctid
                          ,
                            period = dtt1
                        };

                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var diid = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.distnm).First();
                        var period = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.yyyymm).First();
                        var date = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crdate).First();
                        var uname = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crusnm).First();

                        var dtcr1010005 = new
                        {
                            ID = 0
                          ,
                            zdist = diid
                          ,
                            zperd = period
                          ,
                            zdate = date
                          ,
                            zuser = uname
                          ,
                            distid = distid
                        };
                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                    if (dctpid == 1010007 && tspdid == 4)
                {
                    string docNewid = yer + quatch + "D" + distid + "A" + acctid + "GR1010DC1010007TS4";

                    string district = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSOMD01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010005 = new
                        {
                            docid = docNewid
                          ,
                            userid = userid
                          ,
                            actype = 2
                          ,
                            zdist = district
                          ,
                            zperd = dtt1
                          ,
                            zdate = zdate
                          ,
                            zuser = userName
                          ,
                            distid = distid
                          ,
                            dctpid = dctpid
                          ,
                            tspdid = tspdid
                          ,
                            acctid = acctid
                          ,
                            period = dtt1
                        };

                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var diid = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.distnm).First();
                        var period = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.yyyymm).First();
                        var date = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crdate).First();
                        var uname = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crusnm).First();

                        var dtcr1010005 = new
                        {
                            ID = 0
                          ,
                            zdist = diid
                          ,
                            zperd = period
                          ,
                            zdate = date
                          ,
                            zuser = uname
                          ,
                            distid = distid
                        };
                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                    if (dctpid == 1010007 && tspdid == 5)
                {
                    string docNewid = yer + "D" + distid + "A" + acctid + "GR1010DC1010007TS5";

                    string district = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSOMD01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010005 = new
                        {
                            docid = docNewid
                          ,
                            userid = userid
                          ,
                            actype = 2
                          ,
                            zdist = district
                          ,
                            zperd = dtt1
                          ,
                            zdate = zdate
                          ,
                            zuser = userName
                          ,
                            distid = distid
                          ,
                            dctpid = dctpid
                          ,
                            tspdid = tspdid
                          ,
                            acctid = acctid
                          ,
                            period = dtt1
                        };

                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var diid = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.distnm).First();
                        var period = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.yyyymm).First();
                        var date = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crdate).First();
                        var uname = opb.UHSOMD01vDbs.Where(s => s.ID == docNewid).Select(s => s.crusnm).First();

                        var dtcr1010005 = new
                        {
                            ID = 0
                          ,
                            zdist = diid
                          ,
                            zperd = period
                          ,
                            zdate = date
                          ,
                            zuser = uname
                          ,
                            distid = distid
                        };
                        return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var dtcr1010005 = new
                    {

                    };

                    return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
                }
            }

            else if (actype == 3)
            {
                List<UHSOMD01Db> UHSOMD01Dbr = opa.UHSOMD01Dbs.Where(s => s.ID == docid).ToList();

                string dID = docid;
                var projid = UHSOMD01Dbr.Select(s => s.projid).First();
                var tskoid = UHSOMD01Dbr.Select(s => s.tskoid).First();
                var dcgrid = UHSOMD01Dbr.Select(s => s.dcgrid).First();
                var dctpida = UHSOMD01Dbr.Select(s => s.dctpid).First();
                var tspdida = UHSOMD01Dbr.Select(s => s.tspdid).First();
                var disid = UHSOMD01Dbr.Select(s => s.distid).First();
                var accid = UHSOMD01Dbr.Select(s => s.acctid).First();
                var usrid = UHSOMD01Dbr.Select(s => s.userid).First();
                var dimid = UHSOMD01Dbr.Select(s => s.dimgid).First();
                var smid111 = UHSOMD01Dbr.Select(s => s.smid111).First();
                var cmdt111 = UHSOMD01Dbr.Select(s => s.cmdt111).First();
                var verf111 = UHSOMD01Dbr.Select(s => s.verf111).First();
                var smid112 = UHSOMD01Dbr.Select(s => s.smid112).First();
                var cmdt112 = UHSOMD01Dbr.Select(s => s.cmdt112).First();
                var verf112 = UHSOMD01Dbr.Select(s => s.verf112).First();
                var smid113 = UHSOMD01Dbr.Select(s => s.smid113).First();
                var cmdt113 = UHSOMD01Dbr.Select(s => s.cmdt113).First();
                var verf113 = UHSOMD01Dbr.Select(s => s.verf113).First();
                var smid114 = UHSOMD01Dbr.Select(s => s.smid114).First();
                var cmdt114 = UHSOMD01Dbr.Select(s => s.cmdt114).First();
                var verf114 = UHSOMD01Dbr.Select(s => s.verf114).First();
                var smid115 = UHSOMD01Dbr.Select(s => s.smid115).First();
                var cmdt115 = UHSOMD01Dbr.Select(s => s.cmdt115).First();
                var verf115 = UHSOMD01Dbr.Select(s => s.verf115).First();
                var smid116 = UHSOMD01Dbr.Select(s => s.smid116).First();
                var cmdt116 = UHSOMD01Dbr.Select(s => s.cmdt116).First();
                var verf116 = UHSOMD01Dbr.Select(s => s.verf116).First();
                var smid117 = UHSOMD01Dbr.Select(s => s.smid117).First();
                var cmdt117 = UHSOMD01Dbr.Select(s => s.cmdt117).First();
                var verf117 = UHSOMD01Dbr.Select(s => s.verf117).First();
                var smid118 = UHSOMD01Dbr.Select(s => s.smid118).First();
                var cmdt118 = UHSOMD01Dbr.Select(s => s.cmdt118).First();
                var verf118 = UHSOMD01Dbr.Select(s => s.verf118).First();
                var smid119 = UHSOMD01Dbr.Select(s => s.smid119).First();
                var cmdt119 = UHSOMD01Dbr.Select(s => s.cmdt119).First();
                var verf119 = UHSOMD01Dbr.Select(s => s.verf119).First();
                var smid120 = UHSOMD01Dbr.Select(s => s.smid120).First();
                var cmdt120 = UHSOMD01Dbr.Select(s => s.cmdt120).First();
                var verf120 = UHSOMD01Dbr.Select(s => s.verf120).First();
                var smid121 = UHSOMD01Dbr.Select(s => s.smid121).First();
                var cmdt121 = UHSOMD01Dbr.Select(s => s.cmdt121).First();
                var verf121 = UHSOMD01Dbr.Select(s => s.verf121).First();
                var smid122 = UHSOMD01Dbr.Select(s => s.smid122).First();
                var cmdt122 = UHSOMD01Dbr.Select(s => s.cmdt122).First();
                var verf122 = UHSOMD01Dbr.Select(s => s.verf122).First();
                var smid123 = UHSOMD01Dbr.Select(s => s.smid123).First();
                var cmdt123 = UHSOMD01Dbr.Select(s => s.cmdt123).First();
                var verf123 = UHSOMD01Dbr.Select(s => s.verf123).First();
                var smid124 = UHSOMD01Dbr.Select(s => s.smid124).First();
                var cmdt124 = UHSOMD01Dbr.Select(s => s.cmdt124).First();
                var verf124 = UHSOMD01Dbr.Select(s => s.verf124).First();
                var smid125 = UHSOMD01Dbr.Select(s => s.smid125).First();
                var cmdt125 = UHSOMD01Dbr.Select(s => s.cmdt125).First();
                var verf125 = UHSOMD01Dbr.Select(s => s.verf125).First();
                var comm01 = UHSOMD01Dbr.Select(s => s.comm01).First();
                var comm02 = UHSOMD01Dbr.Select(s => s.comm02).First();
                var comm03 = UHSOMD01Dbr.Select(s => s.comm03).First();
                var comm04 = UHSOMD01Dbr.Select(s => s.comm04).First();
                var comm05 = UHSOMD01Dbr.Select(s => s.comm05).First();
                var comm06 = UHSOMD01Dbr.Select(s => s.comm06).First();
                var chck = UHSOMD01Dbr.Select(s => s.chck).First();
                var chckid = UHSOMD01Dbr.Select(s => s.chckid).First();
                var chckdt = UHSOMD01Dbr.Select(s => s.chckdt).First();
                var crdt = UHSOMD01Dbr.Select(s => s.crdt).First();
                var eddt = UHSOMD01Dbr.Select(s => s.eddt).First();
                var crusid = UHSOMD01Dbr.Select(s => s.crusid).First();
                var edusid = UHSOMD01Dbr.Select(s => s.edusid).First();

                var smnm111 = db.agentsDbs.Where(s => s.ID == smid111).Select(s => s.agentName).First();
                var smnm112 = db.agentsDbs.Where(s => s.ID == smid112).Select(s => s.agentName).First();
                var smnm113 = db.agentsDbs.Where(s => s.ID == smid113).Select(s => s.agentName).First();
                var smnm114 = db.agentsDbs.Where(s => s.ID == smid114).Select(s => s.agentName).First();
                var smnm115 = db.agentsDbs.Where(s => s.ID == smid115).Select(s => s.agentName).First();
                var smnm116 = db.agentsDbs.Where(s => s.ID == smid116).Select(s => s.agentName).First();
                var smnm117 = db.agentsDbs.Where(s => s.ID == smid117).Select(s => s.agentName).First();
                var smnm118 = db.agentsDbs.Where(s => s.ID == smid118).Select(s => s.agentName).First();
                var smnm119 = db.agentsDbs.Where(s => s.ID == smid119).Select(s => s.agentName).First();
                var smnm120 = db.agentsDbs.Where(s => s.ID == smid120).Select(s => s.agentName).First();
                var smnm121 = db.agentsDbs.Where(s => s.ID == smid121).Select(s => s.agentName).First();
                var smnm122 = db.agentsDbs.Where(s => s.ID == smid122).Select(s => s.agentName).First();
                var smnm123 = db.agentsDbs.Where(s => s.ID == smid123).Select(s => s.agentName).First();
                var smnm124 = db.agentsDbs.Where(s => s.ID == smid124).Select(s => s.agentName).First();
                var smnm125 = db.agentsDbs.Where(s => s.ID == smid125).Select(s => s.agentName).First();

                string dimgname = db.agentsDbs.Where(s => s.ID == dimid).Select(s => s.agentName).First();
                string assmname = db.agentsDbs.Where(s => s.ID == crusid).Select(s => s.agentName).First();
                string supaprname = db.agentsDbs.Where(s => s.ID == chckid).Select(s => s.agentName).First();

                string distrr = opa.DISTRICTSDbs.Where(s => s.ID == disid).Select(s => s.district).First().ToString();

                var zperd = opb.UHSOMD01vDbs.Where(s => s.ID == docid).Select(s => s.yyyymm).First();
                var zdte = opb.UHSOMD01vDbs.Where(s => s.ID == docid).Select(s => s.yyyymmdd).First();
                var zuser = opb.UHSOMD01vDbs.Where(s => s.ID == docid).Select(s => s.usernm).First();
                var datedt = opa.UHSOMD01Dbs.Where(s => s.ID == docid).Select(s => s.crdate).First();

                var dtcr1010005 = new
                {
                    ID = docid
                 ,
                    projid = projid
                 ,
                    tskoid = tskoid
                 ,
                    dcgrid = dcgrid
                 ,
                    dctpid = dctpida
                 ,
                    tspdid = tspdida
                 ,
                    distid = disid
                 ,
                    acctid = accid
                 ,
                    userid = usrid
                 ,
                    smid111 = smid111
                 ,
                    cmdt111 = cmdt111
                 ,
                    verf111 = verf111
                 ,
                    smid112 = smid112
                 ,
                    cmdt112 = cmdt112
                 ,
                    verf112 = verf112
                 ,
                    smid113 = smid113
                 ,
                    cmdt113 = cmdt113
                 ,
                    verf113 = verf113
                 ,
                    smid114 = smid114
                 ,
                    cmdt114 = cmdt114
                 ,
                    verf114 = verf114
                 ,
                    smid115 = smid115
                 ,
                    cmdt115 = cmdt115
                 ,
                    verf115 = verf115
                 ,
                    smid116 = smid116
                 ,
                    cmdt116 = cmdt116
                 ,
                    verf116 = verf116
                 ,
                    smid117 = smid117
                 ,
                    cmdt117 = cmdt117
                 ,
                    verf117 = verf117
                 ,
                    smid118 = smid118
                 ,
                    cmdt118 = cmdt118
                 ,
                    verf118 = verf118
                 ,
                    smid119 = smid119
                 ,
                    cmdt119 = cmdt119
                 ,
                    verf119 = verf119
                 ,
                    smid120 = smid120
                 ,
                    cmdt120 = cmdt120
                 ,
                    verf120 = verf120
                 ,
                    smid121 = smid121
                 ,
                    cmdt121 = cmdt121
                 ,
                    verf121 = verf121
                 ,
                    smid122 = smid122
                 ,
                    cmdt122 = cmdt122
                 ,
                    verf122 = verf122
                 ,
                    smid123 = smid123
                 ,
                    cmdt123 = cmdt123
                 ,
                    verf123 = verf123
                 ,
                    smid124 = smid124
                 ,
                    cmdt124 = cmdt124
                 ,
                    verf124 = verf124
                 ,
                    smid125 = smid125
                 ,
                    cmdt125 = cmdt125
                 ,
                    verf125 = verf125
                 ,
                    smnm111 = smnm111
                 ,
                    smnm112 = smnm112
                 ,
                    smnm113 = smnm113
                 ,
                    smnm114 = smnm114
                 ,
                    smnm115 = smnm115
                 ,
                    smnm116 = smnm116
                 ,
                    smnm117 = smnm117
                 ,
                    smnm118 = smnm118
                 ,
                    smnm119 = smnm119
                 ,
                    smnm120 = smnm120
                 ,
                    smnm121 = smnm121
                 ,
                    smnm122 = smnm122
                 ,
                    smnm123 = smnm123
                 ,
                    smnm124 = smnm124
                 ,
                    smnm125 = smnm125
                 ,
                    comm01 = comm01
                 ,
                    comm02 = comm02
                 ,
                    comm03 = comm03
                 ,
                    comm04 = comm04
                 ,
                    comm05 = comm05
                 ,
                    comm06 = comm06
                 ,
                    chck = chck
                 ,
                    chckid = chckid
                 ,
                    chckdt = chckdt
                 ,
                    crdt = crdt
                 ,
                    eddt = eddt
                 ,
                    crusid = crusid
                 ,
                    edusid = userid
                 ,
                    actype = 3
                 ,
                    zdist = distrr
                 ,
                    zperd = zperd
                 ,
                    zdate = datedt
                 ,
                    zuser = zuser
                 ,
                    chcknm = supaprname
                 ,
                    dimgid = dimid
                 ,
                    dimgnm = dimgname
                 ,
                    assmnm = assmname
                 ,
                    crdate = datedt
                };

                return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var dtcr1010005 = new
                {

                };

                return Json(dtcr1010005, JsonRequestBehavior.AllowGet);
            }
        }
    }
}