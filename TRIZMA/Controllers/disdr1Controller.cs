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
    public class disdr1Controller : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();
        // GET: disdr1
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult disdr1(int ID1, int ID2, int ID3)
        {
            var dts = DateTime.Now.ToString("yyyyMMdd");
            int dt1 = int.Parse(dts);
            int daych = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.daywnm).First();
            int periodch = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.YYYYMM).First();
            int weekch = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.WNumber).First();

            List<uhsdisdrp1> uhsdisdrp1s = new List<uhsdisdrp1>();
            uhsdisdrp1 ListObj01 = new uhsdisdrp1();

            if (ID1 <= periodch && ID2 < weekch)
            {
                if (ID3 == 1)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false
                                                                              || s.tstp013 == false
                                                                              || s.tstp014 == false
                                                                              || s.tstp015 == false
                                                                              || s.tstp016 == false
                                                                              || s.tstp017 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 2)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false
                                                                              || s.tstp023 == false
                                                                              || s.tstp024 == false
                                                                              || s.tstp025 == false
                                                                              || s.tstp026 == false
                                                                              || s.tstp027 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 3)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false
                                                                              || s.tstp033 == false
                                                                              || s.tstp034 == false
                                                                              || s.tstp035 == false
                                                                              || s.tstp036 == false
                                                                              || s.tstp037 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 4)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false
                                                                              || s.tstp043 == false
                                                                              || s.tstp044 == false
                                                                              || s.tstp045 == false
                                                                              || s.tstp046 == false
                                                                              || s.tstp047 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 5)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false
                                                                              || s.tstp053 == false
                                                                              || s.tstp054 == false
                                                                              || s.tstp055 == false
                                                                              || s.tstp056 == false
                                                                              || s.tstp057 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 6)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false
                                                                              || s.tstp063 == false
                                                                              || s.tstp064 == false
                                                                              || s.tstp065 == false
                                                                              || s.tstp066 == false
                                                                              || s.tstp067 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 7)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp071 == false || s.tstp072 == false
                                                                              || s.tstp073 == false
                                                                              || s.tstp074 == false
                                                                              || s.tstp075 == false
                                                                              || s.tstp076 == false
                                                                              || s.tstp077 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 8)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp081 == false || s.tstp082 == false
                                                                              || s.tstp083 == false
                                                                              || s.tstp084 == false
                                                                              || s.tstp085 == false
                                                                              || s.tstp086 == false
                                                                              || s.tstp087 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 9)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp091 == false || s.tstp092 == false
                                                                              || s.tstp093 == false
                                                                              || s.tstp094 == false
                                                                              || s.tstp095 == false
                                                                              || s.tstp096 == false
                                                                              || s.tstp097 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 10)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp101 == false || s.tstp102 == false
                                                                              || s.tstp103 == false
                                                                              || s.tstp104 == false
                                                                              || s.tstp105 == false
                                                                              || s.tstp106 == false
                                                                              || s.tstp107 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 11)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp111 == false || s.tstp112 == false
                                                                              || s.tstp113 == false
                                                                              || s.tstp114 == false
                                                                              || s.tstp115 == false
                                                                              || s.tstp116 == false
                                                                              || s.tstp117 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 12)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp121 == false || s.tstp122 == false
                                                                              || s.tstp123 == false
                                                                              || s.tstp124 == false
                                                                              || s.tstp125 == false
                                                                              || s.tstp126 == false
                                                                              || s.tstp127 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 13)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp131 == false || s.tstp132 == false
                                                                              || s.tstp133 == false
                                                                              || s.tstp134 == false
                                                                              || s.tstp135 == false
                                                                              || s.tstp136 == false
                                                                              || s.tstp137 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 14)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp141 == false || s.tstp142 == false
                                                                              || s.tstp143 == false
                                                                              || s.tstp144 == false
                                                                              || s.tstp145 == false
                                                                              || s.tstp146 == false
                                                                              || s.tstp147 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 15)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp154 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010001)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 16)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp164 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010001)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 17)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp174 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010001)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 18)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp184 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010001)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 111)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false
                                                                              || s.tstp013 == false
                                                                              || s.tstp014 == false
                                                                              || s.tstp015 == false
                                                                              || s.tstp016 == false
                                                                              || s.tstp017 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 112)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false
                                                                              || s.tstp023 == false
                                                                              || s.tstp024 == false
                                                                              || s.tstp025 == false
                                                                              || s.tstp026 == false
                                                                              || s.tstp027 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 113)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false
                                                                              || s.tstp033 == false
                                                                              || s.tstp034 == false
                                                                              || s.tstp035 == false
                                                                              || s.tstp036 == false
                                                                              || s.tstp037 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 114)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false
                                                                              || s.tstp043 == false
                                                                              || s.tstp044 == false
                                                                              || s.tstp045 == false
                                                                              || s.tstp046 == false
                                                                              || s.tstp047 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 115)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false
                                                                              || s.tstp053 == false
                                                                              || s.tstp054 == false
                                                                              || s.tstp055 == false
                                                                              || s.tstp056 == false
                                                                              || s.tstp057 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 116)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false
                                                                              || s.tstp063 == false
                                                                              || s.tstp064 == false
                                                                              || s.tstp065 == false
                                                                              || s.tstp066 == false
                                                                              || s.tstp067 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 121)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp073 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010002)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 122)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp083 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010002)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 123)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp093 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010002)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 124)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp103 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010002)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
            if (ID3 == 125)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp113 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010002)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {


                if (daych == 1 && ID3 == 1)
                {

                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp011 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 2)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp021 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 3)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp031 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 4)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp041 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 5)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp051 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 6)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp061 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 7)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp071 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 8)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp081 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 9)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp091 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 10)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp101 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 11)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp111 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 12)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp121 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 13)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp131 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 14)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp141 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 1)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                              && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 2)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 3)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 4)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 5)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 6)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 7)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp071 == false || s.tstp072 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 8)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp081 == false || s.tstp082 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 9)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp091 == false || s.tstp092 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 10)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp101 == false || s.tstp102 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 11)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp111 == false || s.tstp112 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 12)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp121 == false || s.tstp122 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 13)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp131 == false || s.tstp132 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 14)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp141 == false || s.tstp142 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 1)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false
                                                                              || s.tstp013 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 2)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false
                                                                              || s.tstp023 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 3)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false
                                                                              || s.tstp033 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 4)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false
                                                                              || s.tstp043 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 5)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false
                                                                              || s.tstp053 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 6)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false
                                                                              || s.tstp063 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 7)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp071 == false || s.tstp072 == false
                                                                              || s.tstp073 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 8)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp081 == false || s.tstp082 == false
                                                                              || s.tstp083 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 9)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp091 == false || s.tstp092 == false
                                                                              || s.tstp093 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 10)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp101 == false || s.tstp102 == false
                                                                              || s.tstp103 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 11)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp111 == false || s.tstp112 == false
                                                                              || s.tstp113 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 12)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp121 == false || s.tstp122 == false
                                                                              || s.tstp123 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 13)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp131 == false || s.tstp132 == false
                                                                              || s.tstp133 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 14)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp141 == false || s.tstp142 == false
                                                                              || s.tstp143 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 1)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false
                                                                              || s.tstp013 == false
                                                                              || s.tstp014 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 2)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false
                                                                              || s.tstp023 == false
                                                                              || s.tstp024 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 3)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false
                                                                              || s.tstp033 == false
                                                                              || s.tstp034 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 4)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false
                                                                              || s.tstp043 == false
                                                                              || s.tstp044 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 5)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false
                                                                              || s.tstp053 == false
                                                                              || s.tstp054 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 6)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false
                                                                              || s.tstp063 == false
                                                                              || s.tstp064 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 7)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp071 == false || s.tstp072 == false
                                                                              || s.tstp073 == false
                                                                              || s.tstp074 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 8)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp081 == false || s.tstp082 == false
                                                                              || s.tstp083 == false
                                                                              || s.tstp084 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 9)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp091 == false || s.tstp092 == false
                                                                              || s.tstp093 == false
                                                                              || s.tstp094 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 10)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp101 == false || s.tstp102 == false
                                                                              || s.tstp103 == false
                                                                              || s.tstp104 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 11)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp111 == false || s.tstp112 == false
                                                                              || s.tstp113 == false
                                                                              || s.tstp114 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 12)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp121 == false || s.tstp122 == false
                                                                              || s.tstp123 == false
                                                                              || s.tstp124 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 13)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp131 == false || s.tstp132 == false
                                                                              || s.tstp133 == false
                                                                              || s.tstp134 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 14)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp141 == false || s.tstp142 == false
                                                                              || s.tstp143 == false
                                                                              || s.tstp144 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 1)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false
                                                                              || s.tstp013 == false
                                                                              || s.tstp014 == false
                                                                              || s.tstp015 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 2)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false
                                                                              || s.tstp023 == false
                                                                              || s.tstp024 == false
                                                                              || s.tstp025 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 3)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false
                                                                              || s.tstp033 == false
                                                                              || s.tstp034 == false
                                                                              || s.tstp035 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 4)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false
                                                                              || s.tstp043 == false
                                                                              || s.tstp044 == false
                                                                              || s.tstp045 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 5)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false
                                                                              || s.tstp053 == false
                                                                              || s.tstp054 == false
                                                                              || s.tstp055 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 6)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false
                                                                              || s.tstp063 == false
                                                                              || s.tstp064 == false
                                                                              || s.tstp065 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 7)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp071 == false || s.tstp072 == false
                                                                              || s.tstp073 == false
                                                                              || s.tstp074 == false
                                                                              || s.tstp075 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 8)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp081 == false || s.tstp082 == false
                                                                              || s.tstp083 == false
                                                                              || s.tstp084 == false
                                                                              || s.tstp085 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 9)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp091 == false || s.tstp092 == false
                                                                              || s.tstp093 == false
                                                                              || s.tstp094 == false
                                                                              || s.tstp095 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 10)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp101 == false || s.tstp102 == false
                                                                              || s.tstp103 == false
                                                                              || s.tstp104 == false
                                                                              || s.tstp105 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 11)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp111 == false || s.tstp112 == false
                                                                              || s.tstp113 == false
                                                                              || s.tstp114 == false
                                                                              || s.tstp115 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 12)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp121 == false || s.tstp122 == false
                                                                              || s.tstp123 == false
                                                                              || s.tstp124 == false
                                                                              || s.tstp125 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 13)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp131 == false || s.tstp132 == false
                                                                              || s.tstp133 == false
                                                                              || s.tstp134 == false
                                                                              || s.tstp135 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 14)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp141 == false || s.tstp142 == false
                                                                              || s.tstp143 == false
                                                                              || s.tstp144 == false
                                                                              || s.tstp145 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 1)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false
                                                                              || s.tstp013 == false
                                                                              || s.tstp014 == false
                                                                              || s.tstp015 == false
                                                                              || s.tstp016 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 2)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false
                                                                              || s.tstp023 == false
                                                                              || s.tstp024 == false
                                                                              || s.tstp025 == false
                                                                              || s.tstp026 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 3)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false
                                                                              || s.tstp033 == false
                                                                              || s.tstp034 == false
                                                                              || s.tstp035 == false
                                                                              || s.tstp036 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 4)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false
                                                                              || s.tstp043 == false
                                                                              || s.tstp044 == false
                                                                              || s.tstp045 == false
                                                                              || s.tstp046 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 5)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false
                                                                              || s.tstp053 == false
                                                                              || s.tstp054 == false
                                                                              || s.tstp055 == false
                                                                              || s.tstp056 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 6)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false
                                                                              || s.tstp063 == false
                                                                              || s.tstp064 == false
                                                                              || s.tstp065 == false
                                                                              || s.tstp066 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 7)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp071 == false || s.tstp072 == false
                                                                              || s.tstp073 == false
                                                                              || s.tstp074 == false
                                                                              || s.tstp075 == false
                                                                              || s.tstp076 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 8)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp081 == false || s.tstp082 == false
                                                                              || s.tstp083 == false
                                                                              || s.tstp084 == false
                                                                              || s.tstp085 == false
                                                                              || s.tstp086 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 9)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp091 == false || s.tstp092 == false
                                                                              || s.tstp093 == false
                                                                              || s.tstp094 == false
                                                                              || s.tstp095 == false
                                                                              || s.tstp096 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 10)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp101 == false || s.tstp102 == false
                                                                              || s.tstp103 == false
                                                                              || s.tstp104 == false
                                                                              || s.tstp105 == false
                                                                              || s.tstp106 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 11)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp111 == false || s.tstp112 == false
                                                                              || s.tstp113 == false
                                                                              || s.tstp114 == false
                                                                              || s.tstp115 == false
                                                                              || s.tstp116 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 12)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp121 == false || s.tstp122 == false
                                                                              || s.tstp123 == false
                                                                              || s.tstp124 == false
                                                                              || s.tstp125 == false
                                                                              || s.tstp126 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 13)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp131 == false || s.tstp132 == false
                                                                              || s.tstp133 == false
                                                                              || s.tstp134 == false
                                                                              || s.tstp135 == false
                                                                              || s.tstp136 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 14)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp141 == false || s.tstp142 == false
                                                                              || s.tstp143 == false
                                                                              || s.tstp144 == false
                                                                              || s.tstp145 == false
                                                                              || s.tstp146 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 1)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false
                                                                              || s.tstp013 == false
                                                                              || s.tstp014 == false
                                                                              || s.tstp015 == false
                                                                              || s.tstp016 == false
                                                                              || s.tstp017 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 2)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false
                                                                              || s.tstp023 == false
                                                                              || s.tstp024 == false
                                                                              || s.tstp025 == false
                                                                              || s.tstp026 == false
                                                                              || s.tstp027 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 3)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false
                                                                              || s.tstp033 == false
                                                                              || s.tstp034 == false
                                                                              || s.tstp035 == false
                                                                              || s.tstp036 == false
                                                                              || s.tstp037 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 4)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false
                                                                              || s.tstp043 == false
                                                                              || s.tstp044 == false
                                                                              || s.tstp045 == false
                                                                              || s.tstp046 == false
                                                                              || s.tstp047 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 5)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false
                                                                              || s.tstp053 == false
                                                                              || s.tstp054 == false
                                                                              || s.tstp055 == false
                                                                              || s.tstp056 == false
                                                                              || s.tstp057 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 6)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false
                                                                              || s.tstp063 == false
                                                                              || s.tstp064 == false
                                                                              || s.tstp065 == false
                                                                              || s.tstp066 == false
                                                                              || s.tstp067 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 7)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp071 == false || s.tstp072 == false
                                                                              || s.tstp073 == false
                                                                              || s.tstp074 == false
                                                                              || s.tstp075 == false
                                                                              || s.tstp076 == false
                                                                              || s.tstp077 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 8)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp081 == false || s.tstp082 == false
                                                                              || s.tstp083 == false
                                                                              || s.tstp084 == false
                                                                              || s.tstp085 == false
                                                                              || s.tstp086 == false
                                                                              || s.tstp087 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 9)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp091 == false || s.tstp092 == false
                                                                              || s.tstp093 == false
                                                                              || s.tstp094 == false
                                                                              || s.tstp095 == false
                                                                              || s.tstp096 == false
                                                                              || s.tstp097 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 10)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp101 == false || s.tstp102 == false
                                                                              || s.tstp103 == false
                                                                              || s.tstp104 == false
                                                                              || s.tstp105 == false
                                                                              || s.tstp106 == false
                                                                              || s.tstp107 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 11)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp111 == false || s.tstp112 == false
                                                                              || s.tstp113 == false
                                                                              || s.tstp114 == false
                                                                              || s.tstp115 == false
                                                                              || s.tstp116 == false
                                                                              || s.tstp117 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 12)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp121 == false || s.tstp122 == false
                                                                              || s.tstp123 == false
                                                                              || s.tstp124 == false
                                                                              || s.tstp125 == false
                                                                              || s.tstp126 == false
                                                                              || s.tstp127 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 13)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp131 == false || s.tstp132 == false
                                                                              || s.tstp133 == false
                                                                              || s.tstp134 == false
                                                                              || s.tstp135 == false
                                                                              || s.tstp136 == false
                                                                              || s.tstp137 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 14)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp141 == false || s.tstp142 == false
                                                                              || s.tstp143 == false
                                                                              || s.tstp144 == false
                                                                              || s.tstp145 == false
                                                                              || s.tstp146 == false
                                                                              || s.tstp147 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010001)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (ID3 == 15)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp154 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010001)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (ID3 == 16)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp164 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010001)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (ID3 == 17)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp174 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010001)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (ID3 == 18)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp184 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010001)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 111)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp011 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 112)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp021 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 113)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp031 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 114)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp041 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 115)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp051 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 1 && ID3 == 116)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp061 == false && s.yyyymm == ID1
                                                                             && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else

                if (daych == 2 && ID3 == 111)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                              && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 112)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 113)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 114)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 115)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 2 && ID3 == 116)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 111)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false
                                                                              || s.tstp013 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 112)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false
                                                                              || s.tstp023 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 113)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false
                                                                              || s.tstp033 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 114)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false
                                                                              || s.tstp043 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 115)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false
                                                                              || s.tstp053 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 3 && ID3 == 116)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false
                                                                              || s.tstp063 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 111)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false
                                                                              || s.tstp013 == false
                                                                              || s.tstp014 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 112)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false
                                                                              || s.tstp023 == false
                                                                              || s.tstp024 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 113)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false
                                                                              || s.tstp033 == false
                                                                              || s.tstp034 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 114)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false
                                                                              || s.tstp043 == false
                                                                              || s.tstp044 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 115)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false
                                                                              || s.tstp053 == false
                                                                              || s.tstp054 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 4 && ID3 == 116)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false
                                                                              || s.tstp063 == false
                                                                              || s.tstp064 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 111)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false
                                                                              || s.tstp013 == false
                                                                              || s.tstp014 == false
                                                                              || s.tstp015 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 112)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false
                                                                              || s.tstp023 == false
                                                                              || s.tstp024 == false
                                                                              || s.tstp025 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 113)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false
                                                                              || s.tstp033 == false
                                                                              || s.tstp034 == false
                                                                              || s.tstp035 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 114)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false
                                                                              || s.tstp043 == false
                                                                              || s.tstp044 == false
                                                                              || s.tstp045 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 115)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false
                                                                              || s.tstp053 == false
                                                                              || s.tstp054 == false
                                                                              || s.tstp055 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 5 && ID3 == 116)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false
                                                                              || s.tstp063 == false
                                                                              || s.tstp064 == false
                                                                              || s.tstp065 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 111)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false
                                                                              || s.tstp013 == false
                                                                              || s.tstp014 == false
                                                                              || s.tstp015 == false
                                                                              || s.tstp016 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 112)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false
                                                                              || s.tstp023 == false
                                                                              || s.tstp024 == false
                                                                              || s.tstp025 == false
                                                                              || s.tstp026 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 113)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false
                                                                              || s.tstp033 == false
                                                                              || s.tstp034 == false
                                                                              || s.tstp035 == false
                                                                              || s.tstp036 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 114)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false
                                                                              || s.tstp043 == false
                                                                              || s.tstp044 == false
                                                                              || s.tstp045 == false
                                                                              || s.tstp046 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 115)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false
                                                                              || s.tstp053 == false
                                                                              || s.tstp054 == false
                                                                              || s.tstp055 == false
                                                                              || s.tstp056 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 6 && ID3 == 116)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false
                                                                              || s.tstp063 == false
                                                                              || s.tstp064 == false
                                                                              || s.tstp065 == false
                                                                              || s.tstp066 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 111)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp011 == false || s.tstp012 == false
                                                                              || s.tstp013 == false
                                                                              || s.tstp014 == false
                                                                              || s.tstp015 == false
                                                                              || s.tstp016 == false
                                                                              || s.tstp017 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 112)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp021 == false || s.tstp022 == false
                                                                              || s.tstp023 == false
                                                                              || s.tstp024 == false
                                                                              || s.tstp025 == false
                                                                              || s.tstp026 == false
                                                                              || s.tstp027 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 113)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp031 == false || s.tstp032 == false
                                                                              || s.tstp033 == false
                                                                              || s.tstp034 == false
                                                                              || s.tstp035 == false
                                                                              || s.tstp036 == false
                                                                              || s.tstp037 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 114)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp041 == false || s.tstp042 == false
                                                                              || s.tstp043 == false
                                                                              || s.tstp044 == false
                                                                              || s.tstp045 == false
                                                                              || s.tstp046 == false
                                                                              || s.tstp047 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 115)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp051 == false || s.tstp052 == false
                                                                              || s.tstp053 == false
                                                                              || s.tstp054 == false
                                                                              || s.tstp055 == false
                                                                              || s.tstp056 == false
                                                                              || s.tstp057 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (daych == 7 && ID3 == 116)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => (s.tstp061 == false || s.tstp062 == false
                                                                              || s.tstp063 == false
                                                                              || s.tstp064 == false
                                                                              || s.tstp065 == false
                                                                              || s.tstp066 == false
                                                                              || s.tstp067 == false)
                                                                              && s.yyyymm == ID1
                                                                              && s.weeknr == ID2
                                                                             && s.dctpid == 1010002)
                                           .Select(s => s.distid)
                                           .Distinct()
                                           .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (ID3 == 121)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp073 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010002)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (ID3 == 122)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp083 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010002)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (ID3 == 123)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp093 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010002)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (ID3 == 124)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp103 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010002)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }
                else
                if (ID3 == 125)
                {
                    var ids = opb.UHSGWL01vDbs.Where(s => s.tstp113 == false && s.yyyymm == ID1 && s.weeknr == ID2 && s.dctpid == 1010002)
                                            .Select(s => s.distid)
                                            .Distinct()
                                            .ToList();

                    var cnt = ids.Count();
                    if (cnt < 1)
                    {
                        ListObj01.ID = 1; ListObj01.district = "-";
                        uhsdisdrp1s.Add(ListObj01);
                    }
                    else
                    {
                        ListObj01.ID = 1; ListObj01.district = cnt.ToString();
                        uhsdisdrp1s.Add(ListObj01);
                    }

                    var list01 = opa.DISTRICTSDbs.Where(s => ids.Contains(s.ID)).OrderBy(s => s.ID).Select(s => new { ID = s.ID, Value = s.district }).ToList();
                    foreach (var item in list01)
                    {
                        uhsdisdrp1 ListObj02 = new uhsdisdrp1();
                        ListObj02.ID = item.ID; ListObj02.district = item.Value;
                        uhsdisdrp1s.Add(ListObj02);
                    }

                    return Json(uhsdisdrp1s, JsonRequestBehavior.AllowGet);
                }

                var list = 0;
                return Json(list, JsonRequestBehavior.AllowGet);

            }
        }

    }
}