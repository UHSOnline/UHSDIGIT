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
    public class uhsb360Controller : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();
        // GET: clientsDbs

        public ActionResult b360(int projectID, int taskOrderID, int Int1)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            // get user logged ID int
            int userid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();

            // get userTypeid integer
            int userTypeid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.userType).First();
            ViewBag.userTypeID = userTypeid;

            int userTitle = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.titlid).First();
            ViewBag.userTitleID = userTitle;

            string userName = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();

            ViewBag.ItemSelect = 12;

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userid)
                             .Select(s => s.projectID)
                             .ToList();

            List<int> returnTaskOrdersIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userid)
                             .Select(s => s.taskOrderID)
                             .ToList();

            int helpint = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            ViewBag.currdate = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == helpint).Select(s => s.dateus).First();

            var dos = DateTime.Now.ToString("yyyyMMdd");
            int curdtymd = int.Parse(dos);
            ViewBag.curdtymd = curdtymd;
            var dateh = DateTime.Now;
            ViewBag.dateh = dateh.Hour;
            ViewBag.chkInt = Int1;

            if (userTypeid == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                            && returnTaskOrdersIDlist.Contains(56)))
            {

                ViewBag.districts = new SelectList(opa.DISTRICTSDbs.Where(s => s.ID == 0 || (s.divID != 0 && s.compid == 1)).OrderBy(s => s.ID), "ID", "district");
                var dtt = DateTime.Now.ToString("yyyyMM");
                int dtt1 = int.Parse(dtt);
                var dts = DateTime.Now.ToString("yyyyMMdd");
                int dt1 = int.Parse(dts);
                int week = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.WNumber).First();

                int daynbr = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.daywnm).First();
                ViewBag.daynbr = daynbr;

                int dych1 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.daywnm).First();

                int distid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.distid).First();
                int usertitle = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.titlid).First();

                var daychk = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYYMM == dtt1 && s.daywnm == 5).OrderByDescending(s => s.dateYMD).Select(s => s.dateYMD).First();

                var wekc = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.WNumber).First();
                var weekc = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYYMM == dtt1 && s.WNumber == wekc && s.daywnm == 5 && s.dateYMD == dt1).Count();

                var perchk = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYYMM == dtt1 && s.daywnm != 5 && s.daywnm != 6 && s.daywnm != 7).OrderByDescending(s => s.dateYMD).Select(s => s.dateYMD).First();
                var perchkb = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYYMM == dtt1).OrderByDescending(s => s.dateYMD).Select(s => s.dateYMD).First();

                var qtch1 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYYMM == dtt1).Select(s => s.Quarter).First();
                var qtch2 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.Quarter == qtch1 && s.daywnm == 5).OrderByDescending(s => s.dateYMD).Select(s => s.dateYMD).First();
                var qtchk = opa.DATAOPATIME_FRAMEDbs.Where(s => s.Quarter == qtch1 && qtch2 == dt1).Count();
                var yrch1 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYYMM == dtt1).Select(s => s.YYYY).First();
                var yrch2 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == yrch1 && s.daywnm == 5).OrderByDescending(s => s.dateYMD).Select(s => s.dateYMD).First();
                var yrchk = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == yrch1 && yrch2 == dt1).Count();

                if (yrchk < 1)
                {
                    ViewBag.yrchk = 0;
                }
                else
                {
                    ViewBag.yrchk = 1;
                }
                if (qtchk < 1)
                {
                    ViewBag.qtchk = 0;
                }
                else
                {
                    ViewBag.qtchk = 1;
                }
                if (dt1 == perchk)
                {
                    ViewBag.prchk = 1;
                }
                else
                {
                    ViewBag.prchk = 0;
                }
                if (dt1 == daychk && dt1 == perchkb)
                {
                    ViewBag.prchkb = 1;
                }
                else
                {
                    ViewBag.prchkb = 0;
                }
                if (weekc < 1)
                {
                    ViewBag.wchk = 0;
                }
                else
                {
                    ViewBag.wchk = 1;
                }

                ViewBag.svctr = 0;

                if (userTypeid == 2)
                {
                    List<int> list1 = new List<int>(opa.DISTRICTSDbs.Where(s => s.compid == 1).Select(s => s.divID).Distinct());
                    List<int> list2 = new List<int>(opa.DISTRICTSDbs.Where(s => s.compid == 1).Select(s => s.ID).Distinct());
                    ViewBag.division = new SelectList(opb.dimDivisionDbs.Where(s => (s.ID == 0 || list1.Contains(s.ID)) && s.ID != 1 && s.ID != 2).OrderBy(s => s.DivisionName), "ID", "DivisionName").ToList();
                    ViewBag.dists = new SelectList(opa.DISTRICTSDbs.Where(s => s.ID == 0 || (s.divID == 1 && s.compid == 1)).Select(s => new { ID = s.ID, district = s.district }).Distinct(), "ID", "district").ToList();
                    ViewBag.headdef1 = "All Agiliti";
                    ViewBag.headdef2 = "Administration Level";
                    List<int> list3 = new List<int>(opa.DISTRICTSDbs.Where(s => s.compid == 1).Select(s => s.ID));
                    List<int> list32 = new List<int>(opb.UHSWEBOMD21vDbs.Where(s => list3.Contains(s.DISTID)).Select(s => s.IDc));
                    var list4 = opa.UHSACCTSDbs.Where(s => list32.Contains(s.IDc) && s.typeid == 2).Select(s => new { IDc = s.IDc, CSTNM = s.CSTNM }).ToList();
                    List<UHSACCTSDb> accts03 = new List<UHSACCTSDb>();
                    UHSACCTSDb set0 = new UHSACCTSDb();
                    set0.IDc = 0;
                    set0.CSTNM = "-";
                    accts03.Add(set0);
                    foreach (var item in list4)
                    {
                        UHSACCTSDb set1 = new UHSACCTSDb();
                        set1.IDc = item.IDc;
                        set1.CSTNM = item.CSTNM;
                        accts03.Add(set1);
                    }
                    ViewBag.accts1 = opb.UHSWEBAVG01vDbs.Where(s => s.dctpid == 1010007).ToList();
                    ViewBag.accts2 = new SelectList(accts03, "IDc", "CSTNM").ToList();
                    ViewBag.accts3 = accts03.ToList();

                    if (yrchk == 1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1 && s.a360qtc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0 || s.a360qtc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (qtchk == 1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1 && s.a360qtc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0 || s.a360qtc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (perchk == dt1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1 && s.a360prc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360prc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (daychk == dt1 && dt1 == perchkb)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (daychk == dt1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 2)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 3)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 4)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 5)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 6 || dych1 == 7)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.wchk == 1).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.wchk == 1 && s.a360dyc == 1 && s.a360wkc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.wchk == 1 && (s.a360dyc == 0 || s.a360wkc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID) && s.wchk == 1).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID) && s.wchk == 1).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID) && s.wchk == 1).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID) && s.wchk == 1).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }


                }
                else if (usertitle == 1)
                {

                    int itn1 = db.agentsDbs.Where(s => s.ID == userid).Select(s => s.divid).First();

                    List<int> list1 = new List<int>(opa.DISTRICTSDbs.Where(s => s.compid == 1 && s.divID == itn1).Select(s => s.ID).Distinct().ToList());
                    List<int> list2 = new List<int>(opa.DISTRICTSDbs.Where(s => s.compid == 1 && list1.Contains(s.ID)).Select(s => s.divID).Distinct().ToList());
                    List<int> list3 = new List<int>(opa.UHSACCTSDbs.Where(s => s.typeid == 2 && list1.Contains(s.DISTID)).Select(s => s.IDc).ToList());
                    ViewBag.division = new SelectList(opb.dimDivisionDbs.Where(s => (s.ID == 0 || s.ID == itn1) && s.ID != 1 && s.ID != 2).OrderBy(s => s.DivisionName), "ID", "DivisionName").ToList();
                    ViewBag.accts1 = opb.UHSWEBAVG01vDbs.Where(s => s.dctpid == 1010007 && list3.Contains(s.acctid)).ToList();
                    ViewBag.headdef1 = opb.dimDivisionDbs.Where(s => s.ID == itn1).Select(s => s.DivisionName).First();
                    ViewBag.headdef2 = "Division Level";
                    ViewBag.division = new SelectList(opb.dimDivisionDbs.Where(s => s.ID == 0 || s.ID == itn1).OrderBy(s => s.DivisionName), "ID", "DivisionName").ToList();

                    if (yrchk == 1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1 && s.a360qtc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0 || s.a360qtc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (qtchk == 1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1 && s.a360qtc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0 || s.a360qtc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (perchk == dt1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1 && s.a360prc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360prc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (daychk == dt1 && perchkb == dt1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (daychk == dt1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 2)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 3)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 4)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 5)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 6 || dych1 == 7)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.wchk == 1).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.wchk == 1 && s.a360dyc == 1 && s.a360wkc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.wchk == 1 && (s.a360dyc == 0 || s.a360wkc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID) && s.wchk == 1).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID) && s.wchk == 1).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID) && s.wchk == 1).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID) && s.wchk == 1).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }

                }
                else if (usertitle == 2 || usertitle == 3)
                {
                    List<int> list1 = new List<int>(db.agentsDbs.Where(s => s.ID == userid).Select(s => s.distid).Distinct().ToList());
                    List<int> list2 = new List<int>(opa.DISTRICTSDbs.Where(s => s.compid == 1 && list1.Contains(s.ID)).Select(s => s.divID).Distinct().ToList());
                    List<int> list3 = new List<int>(opa.UHSACCTSDbs.Where(s => s.typeid == 2 && list1.Contains(s.DISTID)).Select(s => s.IDc).ToList());
                    ViewBag.division = new SelectList(opb.dimDivisionDbs.Where(s => (s.ID == 0 || list2.Contains(s.ID)) && s.ID != 1 && s.ID != 2).OrderBy(s => s.DivisionName), "ID", "DivisionName").ToList();
                    ViewBag.accts1 = opb.UHSWEBAVG01vDbs.Where(s => s.dctpid == 1010007 && list3.Contains(s.acctid)).ToList();
                    var pre01 = db.agentsDbs.Where(s => s.ID == userid).Select(s => s.distid).First();
                    ViewBag.headdef1 = opa.DISTRICTSDbs.Where(s => s.compid == 1 && s.ID == pre01).Select(s => s.district).First();
                    ViewBag.headdef2 = "Account Level";

                    if (yrchk == 1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1 && s.a360qtc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0 || s.a360qtc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (qtchk == 1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1 && s.a360qtc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0 || s.a360qtc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (perchk == dt1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1 && s.a360prc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360prc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (daychk == dt1 && perchkb == dt1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (daychk == dt1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 2)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 3)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 4)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 5)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 6 || dych1 == 7)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.wchk == 1).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.wchk == 1 && s.a360dyc == 1 && s.a360wkc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID) && s.wchk == 1 && (s.a360dyc == 0 || s.a360wkc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list1.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list1.Contains(s.DISTID) && s.wchk == 1).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list1.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list1.Contains(s.DISTID) && s.wchk == 1).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list1.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list1.Contains(s.DISTID) && s.wchk == 1).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list1.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list1.Contains(s.DISTID) && s.wchk == 1).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }


                }
                else
                {
                    List<int> list1 = new List<int>(opa.DISTRICTSDbs.Where(s => s.compid == 1).Select(s => s.divID).Distinct());
                    List<int> list2 = new List<int>(opa.DISTRICTSDbs.Where(s => s.compid == 1).Select(s => s.ID).Distinct());
                    ViewBag.division = new SelectList(opb.dimDivisionDbs.Where(s => (s.ID == 0 || list1.Contains(s.ID)) && s.ID != 1 && s.ID != 2).OrderBy(s => s.DivisionName), "ID", "DivisionName").ToList();
                    //ViewBag.division = new SelectList(opa.DISTRICTSDbs.Where(s => s.ID == 0).OrderBy(s => s.ID).Select(s => new { ID = s.divID, divisionName = s.divisionName} ).Distinct(), "ID", "divisionName");
                    if (yrchk == 1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1 && s.a360qtc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0 || s.a360qtc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (qtchk == 1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1 && s.a360qtc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0 || s.a360qtc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (perchk == dt1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1 && s.a360prc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360prc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (daychk == dt1 && perchkb == dt1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (daychk == dt1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1 && s.a360prc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0 || s.a360prc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 1)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 2)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 3)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 4)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 0).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 5)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID)).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.a360dyc == 1 && s.a360wkc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && (s.a360dyc == 0 || s.a360wkc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID)).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID)).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID)).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID)).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID)).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID)).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                    else
                    if (dych1 == 6 || dych1 == 7)
                    {
                        int countTotal = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.wchk == 1).Count(); ViewBag.countTotalb = countTotal;
                        int countGood = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.wchk == 1 && s.a360dyc == 1 && s.a360wkc == 1).Count(); ViewBag.countGoodb = countGood;
                        int countBad = opb.UHSWEBOMD21vDbs.Where(s => list2.Contains(s.DISTID) && s.wchk == 1 && (s.a360dyc == 0 || s.a360wkc == 0)).Count(); ViewBag.countBadb = countBad;
                        var cntperc = string.Format("{0:n2}", ((float)(int)countGood / (float)(int)countTotal) * 100); ViewBag.cntperc = cntperc;
                        var cntperc2 = string.Format("{0:n2}", ((float)(int)countBad / (float)(int)countTotal) * 100); ViewBag.cntperc2 = cntperc2;
                        int acng1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 1 && list2.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb1 = opb.UHSWEBOMD21vDbs.Where(s => s.a360dyc == 0 && list2.Contains(s.DISTID) && s.wchk == 1).Count();
                        int acng2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 1 && list2.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb2 = opb.UHSWEBOMD21vDbs.Where(s => s.a360wkc == 0 && list2.Contains(s.DISTID) && s.wchk == 1).Count();
                        int acng3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 1 && list2.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb3 = opb.UHSWEBOMD21vDbs.Where(s => s.a360prc == 0 && list2.Contains(s.DISTID) && s.wchk == 1).Count();
                        int acng4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 1 && list2.Contains(s.DISTID) && s.wchk == 1).Count(); int acnb4 = opb.UHSWEBOMD21vDbs.Where(s => s.a360qtc == 0 && list2.Contains(s.DISTID) && s.wchk == 1).Count();

                        List<uhspageitemsDb> pageModel3 = new List<uhspageitemsDb>();
                        uhspageitemsDb List3 = new uhspageitemsDb();

                        List3.modInt01 = acng1;
                        List3.modInt02 = acng2;
                        List3.modInt03 = acng3;
                        List3.modInt04 = acng4;
                        List3.modInt06 = acnb1;
                        List3.modInt07 = acnb2;
                        List3.modInt08 = acnb3;
                        List3.modInt09 = acnb4;

                        pageModel3.Add(List3);

                        ViewBag.pageData3 = pageModel3.ToList();
                    }
                }



                return View();
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }

        public ActionResult _bck10100076()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            // get user logged ID int
            int userid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();

            // get userTypeid integer
            int userTypeid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.userType).First();
            ViewBag.userTypeID = userTypeid;

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userid)
                             .Select(s => s.projectID)
                             .ToList();

            List<int> returnTaskOrdersIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userid)
                             .Select(s => s.taskOrderID)
                             .ToList();

            int distids = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.distid).First();
            int usertitle = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.titlid).First();

            if (userTypeid == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                && returnTaskOrdersIDlist.Contains(56)))
            {
                var dtt = DateTime.Now;
                DateTime pastmnt = dtt.AddMonths(-1);
                DateTime l2wek = dtt.AddDays(-7);
                var l2wes = l2wek.ToString("yyyyMMdd");
                var l2week = int.Parse(l2wes);
                //var ptm = pastmnt.ToString("yyyyMM");

                var ptm = DateTime.Now.ToString("yyyyMM");
                var ptmn = int.Parse(ptm);

                var dtr = DateTime.Now.ToString("yyyyMMdd");
                int dti = int.Parse(dtr);
                var dts = DateTime.Now.ToString("yyyy-MM-dd");
                var yer = DateTime.Now.ToString("yyyy");
                var yer1 = int.Parse(yer);

                if (userTypeid == 2)
                {
                    List<int> list1 = new List<int>(opa.UHSACCTSDbs.Where(s => s.typeid == 2).Select(s => s.IDc).Distinct());
                    var itemdt = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 1 && list1.Contains(s.acctid) && s.yyyymmdd >= l2week)
                                                 .Select(s => new { ID = s.ID, crdate = s.crdate, yyyymm = s.yyyymm, weeknr = s.weeknr, dctpid = s.dctpid, distid = s.distid, distnm = s.distnm, acctid = s.acctid, CSTNM = s.CSTNM });
                    List<UHSOMD11vDb> data = new List<UHSOMD11vDb>();
                    foreach (var item in itemdt)
                    {
                        UHSOMD11vDb List1 = new UHSOMD11vDb();
                        List1.ID = item.ID; List1.crdate = item.crdate; List1.yyyymm = item.yyyymm; List1.weeknr = item.weeknr; List1.dctpid = item.dctpid; List1.distid = item.distid; List1.distnm = item.distnm; List1.acctid = item.acctid; List1.CSTNM = item.CSTNM;
                        data.Add(List1);
                    }
                    //ViewBag.testic1 = data.ToList();
                    return PartialView("_bck10100076", data.ToList());

                }
                else if (usertitle == 1)
                {
                    int itn1 = db.agentsDbs.Where(s => s.ID == userid).Select(s => s.divid).First();

                    List<int> list1 = new List<int>(opa.DISTRICTSDbs.Where(s => s.compid == 1 && s.divID == itn1).Select(s => s.ID).Distinct().ToList());

                    var itemdt = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 1 && list1.Contains(s.distid) && s.yyyymmdd >= l2week)
                                                .Select(s => new { ID = s.ID, crdate = s.crdate, yyyymm = s.yyyymm, weeknr = s.weeknr, dctpid = s.dctpid, distid = s.distid, distnm = s.distnm, acctid = s.acctid, CSTNM = s.CSTNM });
                    List<UHSOMD11vDb> data = new List<UHSOMD11vDb>();
                    foreach (var item in itemdt)
                    {
                        UHSOMD11vDb List1 = new UHSOMD11vDb();
                        List1.ID = item.ID; List1.crdate = item.crdate; List1.yyyymm = item.yyyymm; List1.weeknr = item.weeknr; List1.dctpid = item.dctpid; List1.distid = item.distid; List1.distnm = item.distnm; List1.acctid = item.acctid; List1.CSTNM = item.CSTNM;
                        data.Add(List1);
                    }
                    return PartialView("_bck10100076", data.ToList());




                }
                else if (usertitle == 2 || usertitle == 3)
                {
                    List<int> list1 = new List<int>(db.agentsDbs.Where(s => s.ID == userid).Select(s => s.distid).Distinct().ToList());

                    var itemdt = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 1 && list1.Contains(s.distid) && s.yyyymmdd >= l2week)
                                                .Select(s => new { ID = s.ID, crdate = s.crdate, yyyymm = s.yyyymm, weeknr = s.weeknr, dctpid = s.dctpid, distid = s.distid, distnm = s.distnm, acctid = s.acctid, CSTNM = s.CSTNM });
                    List<UHSOMD11vDb> data = new List<UHSOMD11vDb>();
                    foreach (var item in itemdt)
                    {
                        UHSOMD11vDb List1 = new UHSOMD11vDb();
                        List1.ID = item.ID; List1.crdate = item.crdate; List1.yyyymm = item.yyyymm; List1.weeknr = item.weeknr; List1.dctpid = item.dctpid; List1.distid = item.distid; List1.distnm = item.distnm; List1.acctid = item.acctid; List1.CSTNM = item.CSTNM;
                        data.Add(List1);
                    }
                    return PartialView("_bck10100076", data.ToList());
                }
            }

            return PartialView("_bck10100076");
        }

        public ActionResult getEditPar10100076(int dctp, int id1, int id2, string id3)
        {
            //System.Diagnostics.Debug.WriteLine(docid);

            // get user logged ID string
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            // get user logged ID int
            int userid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();

            // get userTypeid integer
            int userTypeid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.userType).First();
            ViewBag.userTypeID = userTypeid;

            List<int> returnProjectIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userid)
                             .Select(s => s.projectID)
                             .ToList();

            List<int> returnTaskOrdersIDlist = db.agentsTaskOrdersDbs.Where(s => s.agentID == userid)
                             .Select(s => s.taskOrderID)
                             .ToList();

            int cnt1 = opb.UHSUSAC1B360Dbs.Where(s => s.MGRID == userid && s.IDc == id1).Count();

            if (userTypeid == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                && returnTaskOrdersIDlist.Contains(56)
                                                                                && cnt1 >= 1))
            {
                int usrid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();
                ViewBag.userIds = usrid;
                // get userTypeid integer

                string userName = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();
                ViewBag.userNm = userName;

                var dtr = DateTime.Now.ToString("yyyyMMdd");
                int dti = int.Parse(dtr);
                var dts = DateTime.Now.ToString("yyyy-MM-dd");
                var dtus01 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateID == dts).Select(s => s.dateus).First();
                var yer = DateTime.Now.ToString("yyyy");
                var yer1 = int.Parse(yer);
                var qtr1 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dti).Select(s => s.Quarter).First();
                var per1 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dti).Select(s => s.wstymd).First();
                var per2 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dti).Select(s => s.YYYYMM).First();
                var wek1 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dti).Select(s => s.WNumber).First();
                var curmnt = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dti).Select(s => s.MonthNbr).First();

                ViewBag.prefix = new SelectList(opb.UHSPREFIXDbs.OrderBy(s => s.prefixid), "ID", "prefixid");
                ViewBag.rates = new SelectList(new[] {
                                                                new { Id = "0", Name = "-" },
                                                                new { Id = "1", Name = "D" },
                                                                new { Id = "2", Name = "W" }
                                                              }, "Id", "Name");

                ViewBag.qday = 1;
                ViewBag.qwek = 1;
                ViewBag.qper = 1;
                ViewBag.qqtr = 1;
                ViewBag.qyer = 1;
                ViewBag.qwekb = 1;

                ViewBag.svctr = 1;

                var qtrdate = from s in opa.DATAOPATIME_FRAMEDbs where s.YYYY == yer1 && s.Quarter == qtr1 select s.dateID;
                List<string> qtrdates = qtrdate.ToList();

                List<uhspageitemsDb> constrID = new List<uhspageitemsDb>();
                uhspageitemsDb dyPar = new uhspageitemsDb();
                uhspageitemsDb wkPar = new uhspageitemsDb();
                uhspageitemsDb mnPar = new uhspageitemsDb();
                uhspageitemsDb qtPar = new uhspageitemsDb();
                uhspageitemsDb yrPar = new uhspageitemsDb();
                uhspageitemsDb bwPar = new uhspageitemsDb();

                if (id2 == 1)
                {

                    var wchk1 = opa.UHSACCTSDbs.Where(s => s.IDc == id1 && s.typeid == 2).Select(s => s.wchk).First();
                    List<uhspageitemsDb> Data1 = new List<uhspageitemsDb>();
                    var dtDu01 = dtus01;

                    if (wchk1 == 1)
                    {
                        uhspageitemsDb lista1 = new uhspageitemsDb();
                        lista1.modStr1 = opa.DATAOPATIME_FRAMEDbs.Where(s => (s.YYYY == yer1 && s.WNumber == wek1 && s.daywnm == 5) || (s.YYYY == yer1 && curmnt == 12)).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr2 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYYMM == per2 && s.daywnm != 6 && s.daywnm != 7).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr3 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == yer1 && s.Quarter == qtr1 && s.daywnm != 6 && s.daywnm != 7).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        //lista1.modStr4 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == yer1 && s.daywnm != 6 && s.daywnm != 7).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        Data1.Add(lista1);
                    }
                    else
                    if (wchk1 == 2)
                    {
                        uhspageitemsDb lista1 = new uhspageitemsDb();
                        lista1.modStr1 = opa.DATAOPATIME_FRAMEDbs.Where(s => (s.YYYY == yer1 && s.WNumber == wek1 && s.daywnm == 6) || (s.YYYY == yer1 && curmnt == 12)).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr2 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYYMM == per2 && s.daywnm != 7).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr3 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == yer1 && s.Quarter == qtr1 && s.daywnm != 7).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        //lista1.modStr4 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == yer1 && s.daywnm != 7).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        Data1.Add(lista1);
                    }
                    else
                    if (wchk1 == 3)
                    {
                        uhspageitemsDb lista1 = new uhspageitemsDb();
                        lista1.modStr1 = opa.DATAOPATIME_FRAMEDbs.Where(s => (s.YYYY == yer1 && s.WNumber == wek1 && s.daywnm == 7) || (s.YYYY == yer1 && curmnt == 12)).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr2 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYYMM == per2).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr3 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == yer1 && s.Quarter == qtr1).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        //lista1.modStr4 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == yer1).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        Data1.Add(lista1);
                    }

                    List<UHSOMD11vDb> UHSOMD11vDbA = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 1 && s.acctid == id1 && s.crdate == dts).ToList();
                    var a11 = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 1 && s.acctid == id1 && s.crdate == dts).Select(s => s.ID).First();
                    List<UHSOMD11Db> UHSOMD11Db = opa.UHSOMD11Dbs.Where(s => s.ID == a11).ToList();

                    dyPar.modInt01 = opb.UHSOMD11vDbs.Where(s => s.ID == a11).Select(s => s.yyyymmdd).First();
                    dyPar.modInt02 = opb.UHSOMD11vDbs.Where(s => s.ID == a11).Select(s => s.weeknr).First();
                    dyPar.modInt03 = opb.UHSOMD11vDbs.Where(s => s.ID == a11).Select(s => s.yyyymm).First();
                    dyPar.modInt04 = opb.UHSOMD11vDbs.Where(s => s.ID == a11).Select(s => s.distid).First();
                    dyPar.modInt05 = opb.UHSOMD11vDbs.Where(s => s.ID == a11).Select(s => s.acctid).First();
                    dyPar.modInt06 = opb.UHSOMD11vDbs.Where(s => s.ID == a11).Select(s => s.dcgrid).First();
                    dyPar.modInt07 = opb.UHSOMD11vDbs.Where(s => s.ID == a11).Select(s => s.dctpid).First();
                    dyPar.modStr1 = a11;
                    constrID.Add(dyPar);

                    List<UHSOMD11vDb> UHSOMD11vDbB = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 2 && s.acctid == id1 && s.yyyymm == per1 && s.weeknr == wek1).ToList();
                    var a12 = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 2 && s.acctid == id1 && s.yyyymm == per1 && s.weeknr == wek1).Select(s => s.ID).First();
                    List<UHSOMD12Db> UHSOMD12Db = opa.UHSOMD12Dbs.Where(s => s.ID == a12).ToList();

                    wkPar.modInt01 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.yyyymmdd).First();
                    wkPar.modInt02 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.weeknr).First();
                    wkPar.modInt03 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.yyyymm).First();
                    wkPar.modInt04 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.distid).First();
                    wkPar.modInt05 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.acctid).First();
                    wkPar.modInt06 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.dcgrid).First();
                    wkPar.modInt07 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.dctpid).First();
                    wkPar.modStr1 = a12;
                    constrID.Add(wkPar);

                    List<UHSOMD11vDb> UHSOMD11vDbC = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 3 && s.acctid == id1 && s.yyyymm == per2).ToList();
                    var a13 = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 3 && s.acctid == id1 && s.yyyymm == per2).Select(s => s.ID).First();
                    List<UHSOMD13Db> UHSOMD13Db = opa.UHSOMD13Dbs.Where(s => s.ID == a13).ToList();

                    mnPar.modInt01 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.yyyymmdd).First();
                    mnPar.modInt02 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.weeknr).First();
                    mnPar.modInt03 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.yyyymm).First();
                    mnPar.modInt04 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.distid).First();
                    mnPar.modInt05 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.acctid).First();
                    mnPar.modInt06 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.dcgrid).First();
                    mnPar.modInt07 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.dctpid).First();
                    mnPar.modStr1 = a13;
                    constrID.Add(mnPar);

                    List<UHSOMD11vDb> UHSOMD11vDbD = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 4 && s.acctid == id1 && qtrdates.Contains(s.crdate)).ToList();
                    var a14 = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 4 && s.acctid == id1 && qtrdates.Contains(s.crdate)).Select(s => s.ID).First();
                    List<UHSOMD14Db> UHSOMD14Db = opa.UHSOMD14Dbs.Where(s => s.ID == a14).ToList();

                    qtPar.modInt01 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.yyyymmdd).First();
                    qtPar.modInt02 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.weeknr).First();
                    qtPar.modInt03 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.yyyymm).First();
                    qtPar.modInt04 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.distid).First();
                    qtPar.modInt05 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.acctid).First();
                    qtPar.modInt06 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.dcgrid).First();
                    qtPar.modInt07 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.dctpid).First();
                    qtPar.modStr1 = a14;
                    constrID.Add(qtPar);

                    //List<UHSOMD11vDb> UHSOMD11vDbE = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 5 && s.acctid == id1 && s.yyyy == yer1).ToList();
                    //var a15 = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 5 && s.acctid == id1 && s.yyyy == yer1).Select(s => s.ID).First();
                    //List<UHSOMD15Db> UHSOMD15Db = opa.UHSOMD15Dbs.Where(s => s.ID == a15).ToList();

                    ViewBag.constrID = constrID;
                    ViewBag.projList = opb.UHSWOT01vDbs.Where(s => (s.docmid == a11
                                                                 || s.docmid == a12
                                                                 || s.docmid == a13
                                                                 || s.docmid == a14) && (userTypeid == 2 || s.crusid == userid)).ToList();

                    var id111 = UHSOMD11Db.Select(s => s.smid111).First();
                    var id112 = UHSOMD11Db.Select(s => s.smid112).First();
                    var id113 = UHSOMD11Db.Select(s => s.smid113).First();
                    var id114 = UHSOMD11Db.Select(s => s.smid114).First();
                    var id115 = UHSOMD11Db.Select(s => s.smid115).First();
                    var id116 = UHSOMD11Db.Select(s => s.smid116).First();
                    var id117 = UHSOMD11Db.Select(s => s.smid117).First();
                    var id118 = UHSOMD11Db.Select(s => s.smid118).First();
                    var id119 = UHSOMD11Db.Select(s => s.smid119).First();
                    var id120 = UHSOMD11Db.Select(s => s.smid120).First();
                    var id121 = UHSOMD11Db.Select(s => s.smid121).First();
                    var id122 = UHSOMD11Db.Select(s => s.smid122).First();
                    var id123 = UHSOMD11Db.Select(s => s.smid123).First();
                    var id124 = UHSOMD11Db.Select(s => s.smid124).First();
                    var id125 = UHSOMD11Db.Select(s => s.smid125).First();

                    var id211 = UHSOMD12Db.Select(s => s.smid111).First();
                    var id212 = UHSOMD12Db.Select(s => s.smid112).First();
                    var id213 = UHSOMD12Db.Select(s => s.smid113).First();
                    var id214 = UHSOMD12Db.Select(s => s.smid114).First();
                    var id215 = UHSOMD12Db.Select(s => s.smid115).First();
                    var id216 = UHSOMD12Db.Select(s => s.smid116).First();
                    var id217 = UHSOMD12Db.Select(s => s.smid117).First();
                    var id218 = UHSOMD12Db.Select(s => s.smid118).First();
                    var id219 = UHSOMD12Db.Select(s => s.smid119).First();
                    var id220 = UHSOMD12Db.Select(s => s.smid120).First();
                    var id221 = UHSOMD12Db.Select(s => s.smid121).First();
                    var id222 = UHSOMD12Db.Select(s => s.smid122).First();
                    var id223 = UHSOMD12Db.Select(s => s.smid123).First();
                    var id224 = UHSOMD12Db.Select(s => s.smid124).First();
                    var id225 = UHSOMD12Db.Select(s => s.smid125).First();

                    var id311 = UHSOMD13Db.Select(s => s.smid111).First();
                    var id312 = UHSOMD13Db.Select(s => s.smid112).First();
                    var id313 = UHSOMD13Db.Select(s => s.smid113).First();
                    var id314 = UHSOMD13Db.Select(s => s.smid114).First();
                    var id315 = UHSOMD13Db.Select(s => s.smid115).First();
                    var id316 = UHSOMD13Db.Select(s => s.smid116).First();
                    var id317 = UHSOMD13Db.Select(s => s.smid117).First();
                    var id318 = UHSOMD13Db.Select(s => s.smid118).First();
                    var id319 = UHSOMD13Db.Select(s => s.smid119).First();
                    var id320 = UHSOMD13Db.Select(s => s.smid120).First();
                    var id321 = UHSOMD13Db.Select(s => s.smid121).First();
                    var id322 = UHSOMD13Db.Select(s => s.smid122).First();
                    var id323 = UHSOMD13Db.Select(s => s.smid123).First();
                    var id324 = UHSOMD13Db.Select(s => s.smid124).First();
                    var id325 = UHSOMD13Db.Select(s => s.smid125).First();

                    var id411 = UHSOMD14Db.Select(s => s.smid111).First();
                    var id412 = UHSOMD14Db.Select(s => s.smid112).First();
                    var id413 = UHSOMD14Db.Select(s => s.smid113).First();
                    var id414 = UHSOMD14Db.Select(s => s.smid114).First();
                    var id415 = UHSOMD14Db.Select(s => s.smid115).First();
                    var id416 = UHSOMD14Db.Select(s => s.smid116).First();
                    var id417 = UHSOMD14Db.Select(s => s.smid117).First();
                    var id418 = UHSOMD14Db.Select(s => s.smid118).First();
                    var id419 = UHSOMD14Db.Select(s => s.smid119).First();
                    var id420 = UHSOMD14Db.Select(s => s.smid120).First();
                    var id421 = UHSOMD14Db.Select(s => s.smid121).First();
                    var id422 = UHSOMD14Db.Select(s => s.smid122).First();
                    var id423 = UHSOMD14Db.Select(s => s.smid123).First();
                    var id424 = UHSOMD14Db.Select(s => s.smid124).First();
                    var id425 = UHSOMD14Db.Select(s => s.smid125).First();

                    //var id511 = UHSOMD15Db.Select(s => s.smid111).First();
                    //var id512 = UHSOMD15Db.Select(s => s.smid112).First();
                    //var id513 = UHSOMD15Db.Select(s => s.smid113).First();
                    //var id514 = UHSOMD15Db.Select(s => s.smid114).First();
                    //var id515 = UHSOMD15Db.Select(s => s.smid115).First();
                    //var id516 = UHSOMD15Db.Select(s => s.smid116).First();
                    //var id517 = UHSOMD15Db.Select(s => s.smid117).First();
                    //var id518 = UHSOMD15Db.Select(s => s.smid118).First();
                    //var id519 = UHSOMD15Db.Select(s => s.smid119).First();
                    //var id520 = UHSOMD15Db.Select(s => s.smid120).First();
                    //var id521 = UHSOMD15Db.Select(s => s.smid121).First();
                    //var id522 = UHSOMD15Db.Select(s => s.smid122).First();
                    //var id523 = UHSOMD15Db.Select(s => s.smid123).First();
                    //var id524 = UHSOMD15Db.Select(s => s.smid124).First();
                    //var id525 = UHSOMD15Db.Select(s => s.smid125).First();

                    var dtDue01 = opb.UHSWEBOMD21vDbs.Where(s => s.IDc == id1).Select(s => s.a360dyd).First();
                    var dtDue02 = opb.UHSWEBOMD21vDbs.Where(s => s.IDc == id1).Select(s => s.a360wkd).First();
                    var dtDue03 = opb.UHSWEBOMD21vDbs.Where(s => s.IDc == id1).Select(s => s.a360prd).First();
                    var dtDue04 = opb.UHSWEBOMD21vDbs.Where(s => s.IDc == id1).Select(s => s.a360qtd).First();
                    //var dtDue05 = opb.UHSWEBOMD21vDbs.Where(s => s.IDc == id1).Select(s => s.a360yrd).First();

                    List<uhsA360pagemodelDb> pageModel = new List<uhsA360pagemodelDb>();
                    uhsA360pagemodelDb List1 = new uhsA360pagemodelDb();

                    List1.AYID = UHSOMD11vDbA.Select(s => s.ID).First();
                    List1.AYprojid = UHSOMD11vDbA.Select(s => s.projid).First();
                    List1.AYtskoid = UHSOMD11vDbA.Select(s => s.tskoid).First();
                    List1.AYdcgrid = UHSOMD11vDbA.Select(s => s.dcgrid).First();
                    List1.AYdctpid = UHSOMD11vDbA.Select(s => s.dctpid).First();
                    List1.AYtspdid = UHSOMD11vDbA.Select(s => s.tspdid).First();
                    List1.AYdistid = UHSOMD11vDbA.Select(s => s.distid).First();
                    List1.AYdistnm = UHSOMD11vDbA.Select(s => s.distnm).First();
                    List1.AYacctid = UHSOMD11vDbA.Select(s => s.acctid).First();
                    List1.AYuserid = UHSOMD11vDbA.Select(s => s.userid).First();
                    List1.AYusernm = UHSOMD11vDbA.Select(s => s.usernm).First();
                    List1.AYdimgid = UHSOMD11vDbA.Select(s => s.dimgid).First();
                    List1.AYdimgnm = UHSOMD11vDbA.Select(s => s.dimgnm).First();
                    List1.AYsmid111 = UHSOMD11vDbA.Select(s => s.smid111).First();
                    List1.AYcmdt111 = UHSOMD11vDbA.Select(s => s.cmdt111).First();
                    List1.AYverf111 = UHSOMD11vDbA.Select(s => s.verf111).First();
                    List1.AYsmid112 = UHSOMD11vDbA.Select(s => s.smid112).First();
                    List1.AYcmdt112 = UHSOMD11vDbA.Select(s => s.cmdt112).First();
                    List1.AYverf112 = UHSOMD11vDbA.Select(s => s.verf112).First();
                    List1.AYsmid113 = UHSOMD11vDbA.Select(s => s.smid113).First();
                    List1.AYcmdt113 = UHSOMD11vDbA.Select(s => s.cmdt113).First();
                    List1.AYverf113 = UHSOMD11vDbA.Select(s => s.verf113).First();
                    List1.AYsmid114 = UHSOMD11vDbA.Select(s => s.smid114).First();
                    List1.AYcmdt114 = UHSOMD11vDbA.Select(s => s.cmdt114).First();
                    List1.AYverf114 = UHSOMD11vDbA.Select(s => s.verf114).First();
                    List1.AYsmid115 = UHSOMD11vDbA.Select(s => s.smid115).First();
                    List1.AYcmdt115 = UHSOMD11vDbA.Select(s => s.cmdt115).First();
                    List1.AYverf115 = UHSOMD11vDbA.Select(s => s.verf115).First();
                    List1.AYsmid116 = UHSOMD11vDbA.Select(s => s.smid116).First();
                    List1.AYcmdt116 = UHSOMD11vDbA.Select(s => s.cmdt116).First();
                    List1.AYverf116 = UHSOMD11vDbA.Select(s => s.verf116).First();
                    List1.AYsmid117 = UHSOMD11vDbA.Select(s => s.smid117).First();
                    List1.AYcmdt117 = UHSOMD11vDbA.Select(s => s.cmdt117).First();
                    List1.AYverf117 = UHSOMD11vDbA.Select(s => s.verf117).First();
                    List1.AYsmid118 = UHSOMD11vDbA.Select(s => s.smid118).First();
                    List1.AYcmdt118 = UHSOMD11vDbA.Select(s => s.cmdt118).First();
                    List1.AYverf118 = UHSOMD11vDbA.Select(s => s.verf118).First();
                    List1.AYsmid119 = UHSOMD11vDbA.Select(s => s.smid119).First();
                    List1.AYcmdt119 = UHSOMD11vDbA.Select(s => s.cmdt119).First();
                    List1.AYverf119 = UHSOMD11vDbA.Select(s => s.verf119).First();
                    List1.AYsmid120 = UHSOMD11vDbA.Select(s => s.smid120).First();
                    List1.AYcmdt120 = UHSOMD11vDbA.Select(s => s.cmdt120).First();
                    List1.AYverf120 = UHSOMD11vDbA.Select(s => s.verf120).First();
                    List1.AYsmid121 = UHSOMD11vDbA.Select(s => s.smid121).First();
                    List1.AYcmdt121 = UHSOMD11vDbA.Select(s => s.cmdt121).First();
                    List1.AYverf121 = UHSOMD11vDbA.Select(s => s.verf121).First();
                    List1.AYsmid122 = UHSOMD11vDbA.Select(s => s.smid122).First();
                    List1.AYcmdt122 = UHSOMD11vDbA.Select(s => s.cmdt122).First();
                    List1.AYverf122 = UHSOMD11vDbA.Select(s => s.verf122).First();
                    List1.AYsmid123 = UHSOMD11vDbA.Select(s => s.smid123).First();
                    List1.AYcmdt123 = UHSOMD11vDbA.Select(s => s.cmdt123).First();
                    List1.AYverf123 = UHSOMD11vDbA.Select(s => s.verf123).First();
                    List1.AYsmid124 = UHSOMD11vDbA.Select(s => s.smid124).First();
                    List1.AYcmdt124 = UHSOMD11vDbA.Select(s => s.cmdt124).First();
                    List1.AYverf124 = UHSOMD11vDbA.Select(s => s.verf124).First();
                    List1.AYsmid125 = UHSOMD11vDbA.Select(s => s.smid125).First();
                    List1.AYcmdt125 = UHSOMD11vDbA.Select(s => s.cmdt125).First();
                    List1.AYverf125 = UHSOMD11vDbA.Select(s => s.verf125).First();
                    List1.AYnote01 = UHSOMD11vDbA.Select(s => s.note01).First();
                    List1.AYnote02 = UHSOMD11vDbA.Select(s => s.note02).First();
                    List1.AYnote03 = UHSOMD11vDbA.Select(s => s.note03).First();
                    List1.AYnote04 = UHSOMD11vDbA.Select(s => s.note04).First();
                    List1.AYnote05 = UHSOMD11vDbA.Select(s => s.note05).First();
                    List1.AYnote06 = UHSOMD11vDbA.Select(s => s.note06).First();
                    List1.AYnote07 = UHSOMD11vDbA.Select(s => s.note07).First();
                    List1.AYnote08 = UHSOMD11vDbA.Select(s => s.note08).First();
                    List1.AYnote09 = UHSOMD11vDbA.Select(s => s.note09).First();
                    List1.AYnote10 = UHSOMD11vDbA.Select(s => s.note10).First();
                    List1.AYnote11 = UHSOMD11vDbA.Select(s => s.note11).First();
                    List1.AYnote12 = UHSOMD11vDbA.Select(s => s.note12).First();
                    List1.AYnote13 = UHSOMD11vDbA.Select(s => s.note13).First();
                    List1.AYnote14 = UHSOMD11vDbA.Select(s => s.note14).First();
                    List1.AYnote15 = UHSOMD11vDbA.Select(s => s.note15).First();
                    List1.AYtask01 = UHSOMD11vDbA.Select(s => s.task01).First();
                    List1.AYtask02 = UHSOMD11vDbA.Select(s => s.task02).First();
                    List1.AYtask03 = UHSOMD11vDbA.Select(s => s.task03).First();
                    List1.AYtask04 = UHSOMD11vDbA.Select(s => s.task04).First();
                    List1.AYtask05 = UHSOMD11vDbA.Select(s => s.task05).First();
                    List1.AYacit01 = UHSOMD11vDbA.Select(s => s.acit01).First();
                    List1.AYacit02 = UHSOMD11vDbA.Select(s => s.acit02).First();
                    List1.AYacit03 = UHSOMD11vDbA.Select(s => s.acit03).First();
                    List1.AYacit04 = UHSOMD11vDbA.Select(s => s.acit04).First();
                    List1.AYacit05 = UHSOMD11vDbA.Select(s => s.acit05).First();
                    List1.AYtool01 = UHSOMD11vDbA.Select(s => s.tool01).First();
                    List1.AYtool02 = UHSOMD11vDbA.Select(s => s.tool02).First();
                    List1.AYtool03 = UHSOMD11vDbA.Select(s => s.tool03).First();
                    List1.AYtool04 = UHSOMD11vDbA.Select(s => s.tool04).First();
                    List1.AYtool05 = UHSOMD11vDbA.Select(s => s.tool05).First();
                    List1.AYdocn01 = UHSOMD11vDbA.Select(s => s.docn01).First();
                    List1.AYdocn02 = UHSOMD11vDbA.Select(s => s.docn02).First();
                    List1.AYdocn03 = UHSOMD11vDbA.Select(s => s.docn03).First();
                    List1.AYdocn04 = UHSOMD11vDbA.Select(s => s.docn04).First();
                    List1.AYdocn05 = UHSOMD11vDbA.Select(s => s.docn05).First();
                    List1.AYprfx01 = UHSOMD11vDbA.Select(s => s.prfx01).First();
                    List1.AYprfx02 = UHSOMD11vDbA.Select(s => s.prfx02).First();
                    List1.AYprfx03 = UHSOMD11vDbA.Select(s => s.prfx03).First();
                    List1.AYprfx04 = UHSOMD11vDbA.Select(s => s.prfx04).First();
                    List1.AYprfx05 = UHSOMD11vDbA.Select(s => s.prfx05).First();
                    List1.AYrate01 = UHSOMD11vDbA.Select(s => s.rate01).First();
                    List1.AYrate02 = UHSOMD11vDbA.Select(s => s.rate02).First();
                    List1.AYrate03 = UHSOMD11vDbA.Select(s => s.rate03).First();
                    List1.AYrate04 = UHSOMD11vDbA.Select(s => s.rate04).First();
                    List1.AYrate05 = UHSOMD11vDbA.Select(s => s.rate05).First();
                    List1.AYpref01 = UHSOMD11vDbA.Select(s => s.pref01).First();
                    List1.AYpref02 = UHSOMD11vDbA.Select(s => s.pref02).First();
                    List1.AYpref03 = UHSOMD11vDbA.Select(s => s.pref03).First();
                    List1.AYpref04 = UHSOMD11vDbA.Select(s => s.pref04).First();
                    List1.AYpref05 = UHSOMD11vDbA.Select(s => s.pref05).First();
                    List1.AYratd01 = UHSOMD11vDbA.Select(s => s.ratd01).First();
                    List1.AYratd02 = UHSOMD11vDbA.Select(s => s.ratd02).First();
                    List1.AYratd03 = UHSOMD11vDbA.Select(s => s.ratd03).First();
                    List1.AYratd04 = UHSOMD11vDbA.Select(s => s.ratd04).First();
                    List1.AYratd05 = UHSOMD11vDbA.Select(s => s.ratd05).First();
                    List1.AYallch1c = UHSOMD11vDbA.Select(s => s.allch1c).First();
                    List1.AYwekday = UHSOMD11vDbA.Select(s => s.wekday).First();
                    List1.AYwekdnm = UHSOMD11vDbA.Select(s => s.wekdnm).First();
                    List1.AYchck = UHSOMD11vDbA.Select(s => s.chck).First();
                    List1.AYchckid = UHSOMD11vDbA.Select(s => s.chckid).First();
                    List1.AYchcknm = UHSOMD11vDbA.Select(s => s.chcknm).First();
                    List1.AYchckdt = UHSOMD11vDbA.Select(s => s.chckdt).First();
                    List1.AYyyyy = UHSOMD11vDbA.Select(s => s.yyyy).First();
                    List1.AYyyyymm = UHSOMD11vDbA.Select(s => s.yyyymm).First();
                    List1.AYweeknr = UHSOMD11vDbA.Select(s => s.weeknr).First();
                    List1.AYweekds = UHSOMD11vDbA.Select(s => s.weekds).First();
                    List1.AYyyyymmdd = UHSOMD11vDbA.Select(s => s.yyyymmdd).First();
                    List1.AYhhmmss = UHSOMD11vDbA.Select(s => s.hhmmss).First();
                    List1.AYcrdt = UHSOMD11vDbA.Select(s => s.crdt).First();
                    List1.AYeddt = UHSOMD11vDbA.Select(s => s.eddt).First();
                    List1.AYcrusid = UHSOMD11vDbA.Select(s => s.crusid).First();
                    List1.AYedusid = UHSOMD11vDbA.Select(s => s.edusid).First();
                    List1.AYcrusnm = UHSOMD11vDbA.Select(s => s.crusnm).First();
                    List1.AYedusnm = UHSOMD11vDbA.Select(s => s.edusnm).First();
                    List1.AYcrdate = UHSOMD11vDbA.Select(s => s.crdate).First();
                    List1.BYID = UHSOMD11vDbB.Select(s => s.ID).First();
                    List1.BYprojid = UHSOMD11vDbB.Select(s => s.projid).First();
                    List1.BYtskoid = UHSOMD11vDbB.Select(s => s.tskoid).First();
                    List1.BYdcgrid = UHSOMD11vDbB.Select(s => s.dcgrid).First();
                    List1.BYdctpid = UHSOMD11vDbB.Select(s => s.dctpid).First();
                    List1.BYtspdid = UHSOMD11vDbB.Select(s => s.tspdid).First();
                    List1.BYdistid = UHSOMD11vDbB.Select(s => s.distid).First();
                    List1.BYdistnm = UHSOMD11vDbB.Select(s => s.distnm).First();
                    List1.BYacctid = UHSOMD11vDbB.Select(s => s.acctid).First();
                    List1.BYuserid = UHSOMD11vDbB.Select(s => s.userid).First();
                    List1.BYusernm = UHSOMD11vDbB.Select(s => s.usernm).First();
                    List1.BYdimgid = UHSOMD11vDbB.Select(s => s.dimgid).First();
                    List1.BYdimgnm = UHSOMD11vDbB.Select(s => s.dimgnm).First();
                    List1.BYsmid111 = UHSOMD11vDbB.Select(s => s.smid111).First();
                    List1.BYcmdt111 = UHSOMD11vDbB.Select(s => s.cmdt111).First();
                    List1.BYverf111 = UHSOMD11vDbB.Select(s => s.verf111).First();
                    List1.BYsmid112 = UHSOMD11vDbB.Select(s => s.smid112).First();
                    List1.BYcmdt112 = UHSOMD11vDbB.Select(s => s.cmdt112).First();
                    List1.BYverf112 = UHSOMD11vDbB.Select(s => s.verf112).First();
                    List1.BYsmid113 = UHSOMD11vDbB.Select(s => s.smid113).First();
                    List1.BYcmdt113 = UHSOMD11vDbB.Select(s => s.cmdt113).First();
                    List1.BYverf113 = UHSOMD11vDbB.Select(s => s.verf113).First();
                    List1.BYsmid114 = UHSOMD11vDbB.Select(s => s.smid114).First();
                    List1.BYcmdt114 = UHSOMD11vDbB.Select(s => s.cmdt114).First();
                    List1.BYverf114 = UHSOMD11vDbB.Select(s => s.verf114).First();
                    List1.BYsmid115 = UHSOMD11vDbB.Select(s => s.smid115).First();
                    List1.BYcmdt115 = UHSOMD11vDbB.Select(s => s.cmdt115).First();
                    List1.BYverf115 = UHSOMD11vDbB.Select(s => s.verf115).First();
                    List1.BYsmid116 = UHSOMD11vDbB.Select(s => s.smid116).First();
                    List1.BYcmdt116 = UHSOMD11vDbB.Select(s => s.cmdt116).First();
                    List1.BYverf116 = UHSOMD11vDbB.Select(s => s.verf116).First();
                    List1.BYsmid117 = UHSOMD11vDbB.Select(s => s.smid117).First();
                    List1.BYcmdt117 = UHSOMD11vDbB.Select(s => s.cmdt117).First();
                    List1.BYverf117 = UHSOMD11vDbB.Select(s => s.verf117).First();
                    List1.BYsmid118 = UHSOMD11vDbB.Select(s => s.smid118).First();
                    List1.BYcmdt118 = UHSOMD11vDbB.Select(s => s.cmdt118).First();
                    List1.BYverf118 = UHSOMD11vDbB.Select(s => s.verf118).First();
                    List1.BYsmid119 = UHSOMD11vDbB.Select(s => s.smid119).First();
                    List1.BYcmdt119 = UHSOMD11vDbB.Select(s => s.cmdt119).First();
                    List1.BYverf119 = UHSOMD11vDbB.Select(s => s.verf119).First();
                    List1.BYsmid120 = UHSOMD11vDbB.Select(s => s.smid120).First();
                    List1.BYcmdt120 = UHSOMD11vDbB.Select(s => s.cmdt120).First();
                    List1.BYverf120 = UHSOMD11vDbB.Select(s => s.verf120).First();
                    List1.BYsmid121 = UHSOMD11vDbB.Select(s => s.smid121).First();
                    List1.BYcmdt121 = UHSOMD11vDbB.Select(s => s.cmdt121).First();
                    List1.BYverf121 = UHSOMD11vDbB.Select(s => s.verf121).First();
                    List1.BYsmid122 = UHSOMD11vDbB.Select(s => s.smid122).First();
                    List1.BYcmdt122 = UHSOMD11vDbB.Select(s => s.cmdt122).First();
                    List1.BYverf122 = UHSOMD11vDbB.Select(s => s.verf122).First();
                    List1.BYsmid123 = UHSOMD11vDbB.Select(s => s.smid123).First();
                    List1.BYcmdt123 = UHSOMD11vDbB.Select(s => s.cmdt123).First();
                    List1.BYverf123 = UHSOMD11vDbB.Select(s => s.verf123).First();
                    List1.BYsmid124 = UHSOMD11vDbB.Select(s => s.smid124).First();
                    List1.BYcmdt124 = UHSOMD11vDbB.Select(s => s.cmdt124).First();
                    List1.BYverf124 = UHSOMD11vDbB.Select(s => s.verf124).First();
                    List1.BYsmid125 = UHSOMD11vDbB.Select(s => s.smid125).First();
                    List1.BYcmdt125 = UHSOMD11vDbB.Select(s => s.cmdt125).First();
                    List1.BYverf125 = UHSOMD11vDbB.Select(s => s.verf125).First();
                    List1.BYnote01 = UHSOMD11vDbB.Select(s => s.note01).First();
                    List1.BYnote02 = UHSOMD11vDbB.Select(s => s.note02).First();
                    List1.BYnote03 = UHSOMD11vDbB.Select(s => s.note03).First();
                    List1.BYnote04 = UHSOMD11vDbB.Select(s => s.note04).First();
                    List1.BYnote05 = UHSOMD11vDbB.Select(s => s.note05).First();
                    List1.BYnote06 = UHSOMD11vDbB.Select(s => s.note06).First();
                    List1.BYnote07 = UHSOMD11vDbB.Select(s => s.note07).First();
                    List1.BYnote08 = UHSOMD11vDbB.Select(s => s.note08).First();
                    List1.BYnote09 = UHSOMD11vDbB.Select(s => s.note09).First();
                    List1.BYnote10 = UHSOMD11vDbB.Select(s => s.note10).First();
                    List1.BYnote11 = UHSOMD11vDbB.Select(s => s.note11).First();
                    List1.BYnote12 = UHSOMD11vDbB.Select(s => s.note12).First();
                    List1.BYnote13 = UHSOMD11vDbB.Select(s => s.note13).First();
                    List1.BYnote14 = UHSOMD11vDbB.Select(s => s.note14).First();
                    List1.BYnote15 = UHSOMD11vDbB.Select(s => s.note15).First();
                    List1.BYtask01 = UHSOMD11vDbB.Select(s => s.task01).First();
                    List1.BYtask02 = UHSOMD11vDbB.Select(s => s.task02).First();
                    List1.BYtask03 = UHSOMD11vDbB.Select(s => s.task03).First();
                    List1.BYtask04 = UHSOMD11vDbB.Select(s => s.task04).First();
                    List1.BYtask05 = UHSOMD11vDbB.Select(s => s.task05).First();
                    List1.BYacit01 = UHSOMD11vDbB.Select(s => s.acit01).First();
                    List1.BYacit02 = UHSOMD11vDbB.Select(s => s.acit02).First();
                    List1.BYacit03 = UHSOMD11vDbB.Select(s => s.acit03).First();
                    List1.BYacit04 = UHSOMD11vDbB.Select(s => s.acit04).First();
                    List1.BYacit05 = UHSOMD11vDbB.Select(s => s.acit05).First();
                    List1.BYtool01 = UHSOMD11vDbB.Select(s => s.tool01).First();
                    List1.BYtool02 = UHSOMD11vDbB.Select(s => s.tool02).First();
                    List1.BYtool03 = UHSOMD11vDbB.Select(s => s.tool03).First();
                    List1.BYtool04 = UHSOMD11vDbB.Select(s => s.tool04).First();
                    List1.BYtool05 = UHSOMD11vDbB.Select(s => s.tool05).First();
                    List1.BYdocn01 = UHSOMD11vDbB.Select(s => s.docn01).First();
                    List1.BYdocn02 = UHSOMD11vDbB.Select(s => s.docn02).First();
                    List1.BYdocn03 = UHSOMD11vDbB.Select(s => s.docn03).First();
                    List1.BYdocn04 = UHSOMD11vDbB.Select(s => s.docn04).First();
                    List1.BYdocn05 = UHSOMD11vDbB.Select(s => s.docn05).First();
                    List1.BYprfx01 = UHSOMD11vDbB.Select(s => s.prfx01).First();
                    List1.BYprfx02 = UHSOMD11vDbB.Select(s => s.prfx02).First();
                    List1.BYprfx03 = UHSOMD11vDbB.Select(s => s.prfx03).First();
                    List1.BYprfx04 = UHSOMD11vDbB.Select(s => s.prfx04).First();
                    List1.BYprfx05 = UHSOMD11vDbB.Select(s => s.prfx05).First();
                    List1.BYrate01 = UHSOMD11vDbB.Select(s => s.rate01).First();
                    List1.BYrate02 = UHSOMD11vDbB.Select(s => s.rate02).First();
                    List1.BYrate03 = UHSOMD11vDbB.Select(s => s.rate03).First();
                    List1.BYrate04 = UHSOMD11vDbB.Select(s => s.rate04).First();
                    List1.BYrate05 = UHSOMD11vDbB.Select(s => s.rate05).First();
                    List1.BYpref01 = UHSOMD11vDbB.Select(s => s.pref01).First();
                    List1.BYpref02 = UHSOMD11vDbB.Select(s => s.pref02).First();
                    List1.BYpref03 = UHSOMD11vDbB.Select(s => s.pref03).First();
                    List1.BYpref04 = UHSOMD11vDbB.Select(s => s.pref04).First();
                    List1.BYpref05 = UHSOMD11vDbB.Select(s => s.pref05).First();
                    List1.BYratd01 = UHSOMD11vDbB.Select(s => s.ratd01).First();
                    List1.BYratd02 = UHSOMD11vDbB.Select(s => s.ratd02).First();
                    List1.BYratd03 = UHSOMD11vDbB.Select(s => s.ratd03).First();
                    List1.BYratd04 = UHSOMD11vDbB.Select(s => s.ratd04).First();
                    List1.BYratd05 = UHSOMD11vDbB.Select(s => s.ratd05).First();
                    List1.BYallch1c = UHSOMD11vDbB.Select(s => s.allch1c).First();
                    List1.BYwekday = UHSOMD11vDbB.Select(s => s.wekday).First();
                    List1.BYwekdnm = UHSOMD11vDbB.Select(s => s.wekdnm).First();
                    List1.BYchck = UHSOMD11vDbB.Select(s => s.chck).First();
                    List1.BYchckid = UHSOMD11vDbB.Select(s => s.chckid).First();
                    List1.BYchcknm = UHSOMD11vDbB.Select(s => s.chcknm).First();
                    List1.BYchckdt = UHSOMD11vDbB.Select(s => s.chckdt).First();
                    List1.BYyyyy = UHSOMD11vDbB.Select(s => s.yyyy).First();
                    List1.BYyyyymm = UHSOMD11vDbB.Select(s => s.yyyymm).First();
                    List1.BYweeknr = UHSOMD11vDbB.Select(s => s.weeknr).First();
                    List1.BYweekds = UHSOMD11vDbB.Select(s => s.weekds).First();
                    List1.BYyyyymmdd = UHSOMD11vDbB.Select(s => s.yyyymmdd).First();
                    List1.BYhhmmss = UHSOMD11vDbB.Select(s => s.hhmmss).First();
                    List1.BYcrdt = UHSOMD11vDbB.Select(s => s.crdt).First();
                    List1.BYeddt = UHSOMD11vDbB.Select(s => s.eddt).First();
                    List1.BYcrusid = UHSOMD11vDbB.Select(s => s.crusid).First();
                    List1.BYedusid = UHSOMD11vDbB.Select(s => s.edusid).First();
                    List1.BYcrusnm = UHSOMD11vDbB.Select(s => s.crusnm).First();
                    List1.BYedusnm = UHSOMD11vDbB.Select(s => s.edusnm).First();
                    List1.BYcrdate = UHSOMD11vDbB.Select(s => s.crdate).First();
                    List1.CYID = UHSOMD11vDbC.Select(s => s.ID).First();
                    List1.CYprojid = UHSOMD11vDbC.Select(s => s.projid).First();
                    List1.CYtskoid = UHSOMD11vDbC.Select(s => s.tskoid).First();
                    List1.CYdcgrid = UHSOMD11vDbC.Select(s => s.dcgrid).First();
                    List1.CYdctpid = UHSOMD11vDbC.Select(s => s.dctpid).First();
                    List1.CYtspdid = UHSOMD11vDbC.Select(s => s.tspdid).First();
                    List1.CYdistid = UHSOMD11vDbC.Select(s => s.distid).First();
                    List1.CYdistnm = UHSOMD11vDbC.Select(s => s.distnm).First();
                    List1.CYacctid = UHSOMD11vDbC.Select(s => s.acctid).First();
                    List1.CYuserid = UHSOMD11vDbC.Select(s => s.userid).First();
                    List1.CYusernm = UHSOMD11vDbC.Select(s => s.usernm).First();
                    List1.CYdimgid = UHSOMD11vDbC.Select(s => s.dimgid).First();
                    List1.CYdimgnm = UHSOMD11vDbC.Select(s => s.dimgnm).First();
                    List1.CYsmid111 = UHSOMD11vDbC.Select(s => s.smid111).First();
                    List1.CYcmdt111 = UHSOMD11vDbC.Select(s => s.cmdt111).First();
                    List1.CYverf111 = UHSOMD11vDbC.Select(s => s.verf111).First();
                    List1.CYsmid112 = UHSOMD11vDbC.Select(s => s.smid112).First();
                    List1.CYcmdt112 = UHSOMD11vDbC.Select(s => s.cmdt112).First();
                    List1.CYverf112 = UHSOMD11vDbC.Select(s => s.verf112).First();
                    List1.CYsmid113 = UHSOMD11vDbC.Select(s => s.smid113).First();
                    List1.CYcmdt113 = UHSOMD11vDbC.Select(s => s.cmdt113).First();
                    List1.CYverf113 = UHSOMD11vDbC.Select(s => s.verf113).First();
                    List1.CYsmid114 = UHSOMD11vDbC.Select(s => s.smid114).First();
                    List1.CYcmdt114 = UHSOMD11vDbC.Select(s => s.cmdt114).First();
                    List1.CYverf114 = UHSOMD11vDbC.Select(s => s.verf114).First();
                    List1.CYsmid115 = UHSOMD11vDbC.Select(s => s.smid115).First();
                    List1.CYcmdt115 = UHSOMD11vDbC.Select(s => s.cmdt115).First();
                    List1.CYverf115 = UHSOMD11vDbC.Select(s => s.verf115).First();
                    List1.CYsmid116 = UHSOMD11vDbC.Select(s => s.smid116).First();
                    List1.CYcmdt116 = UHSOMD11vDbC.Select(s => s.cmdt116).First();
                    List1.CYverf116 = UHSOMD11vDbC.Select(s => s.verf116).First();
                    List1.CYsmid117 = UHSOMD11vDbC.Select(s => s.smid117).First();
                    List1.CYcmdt117 = UHSOMD11vDbC.Select(s => s.cmdt117).First();
                    List1.CYverf117 = UHSOMD11vDbC.Select(s => s.verf117).First();
                    List1.CYsmid118 = UHSOMD11vDbC.Select(s => s.smid118).First();
                    List1.CYcmdt118 = UHSOMD11vDbC.Select(s => s.cmdt118).First();
                    List1.CYverf118 = UHSOMD11vDbC.Select(s => s.verf118).First();
                    List1.CYsmid119 = UHSOMD11vDbC.Select(s => s.smid119).First();
                    List1.CYcmdt119 = UHSOMD11vDbC.Select(s => s.cmdt119).First();
                    List1.CYverf119 = UHSOMD11vDbC.Select(s => s.verf119).First();
                    List1.CYsmid120 = UHSOMD11vDbC.Select(s => s.smid120).First();
                    List1.CYcmdt120 = UHSOMD11vDbC.Select(s => s.cmdt120).First();
                    List1.CYverf120 = UHSOMD11vDbC.Select(s => s.verf120).First();
                    List1.CYsmid121 = UHSOMD11vDbC.Select(s => s.smid121).First();
                    List1.CYcmdt121 = UHSOMD11vDbC.Select(s => s.cmdt121).First();
                    List1.CYverf121 = UHSOMD11vDbC.Select(s => s.verf121).First();
                    List1.CYsmid122 = UHSOMD11vDbC.Select(s => s.smid122).First();
                    List1.CYcmdt122 = UHSOMD11vDbC.Select(s => s.cmdt122).First();
                    List1.CYverf122 = UHSOMD11vDbC.Select(s => s.verf122).First();
                    List1.CYsmid123 = UHSOMD11vDbC.Select(s => s.smid123).First();
                    List1.CYcmdt123 = UHSOMD11vDbC.Select(s => s.cmdt123).First();
                    List1.CYverf123 = UHSOMD11vDbC.Select(s => s.verf123).First();
                    List1.CYsmid124 = UHSOMD11vDbC.Select(s => s.smid124).First();
                    List1.CYcmdt124 = UHSOMD11vDbC.Select(s => s.cmdt124).First();
                    List1.CYverf124 = UHSOMD11vDbC.Select(s => s.verf124).First();
                    List1.CYsmid125 = UHSOMD11vDbC.Select(s => s.smid125).First();
                    List1.CYcmdt125 = UHSOMD11vDbC.Select(s => s.cmdt125).First();
                    List1.CYverf125 = UHSOMD11vDbC.Select(s => s.verf125).First();
                    List1.CYnote01 = UHSOMD11vDbC.Select(s => s.note01).First();
                    List1.CYnote02 = UHSOMD11vDbC.Select(s => s.note02).First();
                    List1.CYnote03 = UHSOMD11vDbC.Select(s => s.note03).First();
                    List1.CYnote04 = UHSOMD11vDbC.Select(s => s.note04).First();
                    List1.CYnote05 = UHSOMD11vDbC.Select(s => s.note05).First();
                    List1.CYnote06 = UHSOMD11vDbC.Select(s => s.note06).First();
                    List1.CYnote07 = UHSOMD11vDbC.Select(s => s.note07).First();
                    List1.CYnote08 = UHSOMD11vDbC.Select(s => s.note08).First();
                    List1.CYnote09 = UHSOMD11vDbC.Select(s => s.note09).First();
                    List1.CYnote10 = UHSOMD11vDbC.Select(s => s.note10).First();
                    List1.CYnote11 = UHSOMD11vDbC.Select(s => s.note11).First();
                    List1.CYnote12 = UHSOMD11vDbC.Select(s => s.note12).First();
                    List1.CYnote13 = UHSOMD11vDbC.Select(s => s.note13).First();
                    List1.CYnote14 = UHSOMD11vDbC.Select(s => s.note14).First();
                    List1.CYnote15 = UHSOMD11vDbC.Select(s => s.note15).First();
                    List1.CYtask01 = UHSOMD11vDbC.Select(s => s.task01).First();
                    List1.CYtask02 = UHSOMD11vDbC.Select(s => s.task02).First();
                    List1.CYtask03 = UHSOMD11vDbC.Select(s => s.task03).First();
                    List1.CYtask04 = UHSOMD11vDbC.Select(s => s.task04).First();
                    List1.CYtask05 = UHSOMD11vDbC.Select(s => s.task05).First();
                    List1.CYacit01 = UHSOMD11vDbC.Select(s => s.acit01).First();
                    List1.CYacit02 = UHSOMD11vDbC.Select(s => s.acit02).First();
                    List1.CYacit03 = UHSOMD11vDbC.Select(s => s.acit03).First();
                    List1.CYacit04 = UHSOMD11vDbC.Select(s => s.acit04).First();
                    List1.CYacit05 = UHSOMD11vDbC.Select(s => s.acit05).First();
                    List1.CYtool01 = UHSOMD11vDbC.Select(s => s.tool01).First();
                    List1.CYtool02 = UHSOMD11vDbC.Select(s => s.tool02).First();
                    List1.CYtool03 = UHSOMD11vDbC.Select(s => s.tool03).First();
                    List1.CYtool04 = UHSOMD11vDbC.Select(s => s.tool04).First();
                    List1.CYtool05 = UHSOMD11vDbC.Select(s => s.tool05).First();
                    List1.CYdocn01 = UHSOMD11vDbC.Select(s => s.docn01).First();
                    List1.CYdocn02 = UHSOMD11vDbC.Select(s => s.docn02).First();
                    List1.CYdocn03 = UHSOMD11vDbC.Select(s => s.docn03).First();
                    List1.CYdocn04 = UHSOMD11vDbC.Select(s => s.docn04).First();
                    List1.CYdocn05 = UHSOMD11vDbC.Select(s => s.docn05).First();
                    List1.CYprfx01 = UHSOMD11vDbC.Select(s => s.prfx01).First();
                    List1.CYprfx02 = UHSOMD11vDbC.Select(s => s.prfx02).First();
                    List1.CYprfx03 = UHSOMD11vDbC.Select(s => s.prfx03).First();
                    List1.CYprfx04 = UHSOMD11vDbC.Select(s => s.prfx04).First();
                    List1.CYprfx05 = UHSOMD11vDbC.Select(s => s.prfx05).First();
                    List1.CYrate01 = UHSOMD11vDbC.Select(s => s.rate01).First();
                    List1.CYrate02 = UHSOMD11vDbC.Select(s => s.rate02).First();
                    List1.CYrate03 = UHSOMD11vDbC.Select(s => s.rate03).First();
                    List1.CYrate04 = UHSOMD11vDbC.Select(s => s.rate04).First();
                    List1.CYrate05 = UHSOMD11vDbC.Select(s => s.rate05).First();
                    List1.CYpref01 = UHSOMD11vDbC.Select(s => s.pref01).First();
                    List1.CYpref02 = UHSOMD11vDbC.Select(s => s.pref02).First();
                    List1.CYpref03 = UHSOMD11vDbC.Select(s => s.pref03).First();
                    List1.CYpref04 = UHSOMD11vDbC.Select(s => s.pref04).First();
                    List1.CYpref05 = UHSOMD11vDbC.Select(s => s.pref05).First();
                    List1.CYratd01 = UHSOMD11vDbC.Select(s => s.ratd01).First();
                    List1.CYratd02 = UHSOMD11vDbC.Select(s => s.ratd02).First();
                    List1.CYratd03 = UHSOMD11vDbC.Select(s => s.ratd03).First();
                    List1.CYratd04 = UHSOMD11vDbC.Select(s => s.ratd04).First();
                    List1.CYratd05 = UHSOMD11vDbC.Select(s => s.ratd05).First();
                    List1.CYallch1c = UHSOMD11vDbC.Select(s => s.allch1c).First();
                    List1.CYwekday = UHSOMD11vDbC.Select(s => s.wekday).First();
                    List1.CYwekdnm = UHSOMD11vDbC.Select(s => s.wekdnm).First();
                    List1.CYchck = UHSOMD11vDbC.Select(s => s.chck).First();
                    List1.CYchckid = UHSOMD11vDbC.Select(s => s.chckid).First();
                    List1.CYchcknm = UHSOMD11vDbC.Select(s => s.chcknm).First();
                    List1.CYchckdt = UHSOMD11vDbC.Select(s => s.chckdt).First();
                    List1.CYyyyy = UHSOMD11vDbC.Select(s => s.yyyy).First();
                    List1.CYyyyymm = UHSOMD11vDbC.Select(s => s.yyyymm).First();
                    List1.CYweeknr = UHSOMD11vDbC.Select(s => s.weeknr).First();
                    List1.CYweekds = UHSOMD11vDbC.Select(s => s.weekds).First();
                    List1.CYyyyymmdd = UHSOMD11vDbC.Select(s => s.yyyymmdd).First();
                    List1.CYhhmmss = UHSOMD11vDbC.Select(s => s.hhmmss).First();
                    List1.CYcrdt = UHSOMD11vDbC.Select(s => s.crdt).First();
                    List1.CYeddt = UHSOMD11vDbC.Select(s => s.eddt).First();
                    List1.CYcrusid = UHSOMD11vDbC.Select(s => s.crusid).First();
                    List1.CYedusid = UHSOMD11vDbC.Select(s => s.edusid).First();
                    List1.CYcrusnm = UHSOMD11vDbC.Select(s => s.crusnm).First();
                    List1.CYedusnm = UHSOMD11vDbC.Select(s => s.edusnm).First();
                    List1.CYcrdate = UHSOMD11vDbC.Select(s => s.crdate).First();
                    List1.DYID = UHSOMD11vDbD.Select(s => s.ID).First();
                    List1.DYprojid = UHSOMD11vDbD.Select(s => s.projid).First();
                    List1.DYtskoid = UHSOMD11vDbD.Select(s => s.tskoid).First();
                    List1.DYdcgrid = UHSOMD11vDbD.Select(s => s.dcgrid).First();
                    List1.DYdctpid = UHSOMD11vDbD.Select(s => s.dctpid).First();
                    List1.DYtspdid = UHSOMD11vDbD.Select(s => s.tspdid).First();
                    List1.DYdistid = UHSOMD11vDbD.Select(s => s.distid).First();
                    List1.DYdistnm = UHSOMD11vDbD.Select(s => s.distnm).First();
                    List1.DYacctid = UHSOMD11vDbD.Select(s => s.acctid).First();
                    List1.DYuserid = UHSOMD11vDbD.Select(s => s.userid).First();
                    List1.DYusernm = UHSOMD11vDbD.Select(s => s.usernm).First();
                    List1.DYdimgid = UHSOMD11vDbD.Select(s => s.dimgid).First();
                    List1.DYdimgnm = UHSOMD11vDbD.Select(s => s.dimgnm).First();
                    List1.DYsmid111 = UHSOMD11vDbD.Select(s => s.smid111).First();
                    List1.DYcmdt111 = UHSOMD11vDbD.Select(s => s.cmdt111).First();
                    List1.DYverf111 = UHSOMD11vDbD.Select(s => s.verf111).First();
                    List1.DYsmid112 = UHSOMD11vDbD.Select(s => s.smid112).First();
                    List1.DYcmdt112 = UHSOMD11vDbD.Select(s => s.cmdt112).First();
                    List1.DYverf112 = UHSOMD11vDbD.Select(s => s.verf112).First();
                    List1.DYsmid113 = UHSOMD11vDbD.Select(s => s.smid113).First();
                    List1.DYcmdt113 = UHSOMD11vDbD.Select(s => s.cmdt113).First();
                    List1.DYverf113 = UHSOMD11vDbD.Select(s => s.verf113).First();
                    List1.DYsmid114 = UHSOMD11vDbD.Select(s => s.smid114).First();
                    List1.DYcmdt114 = UHSOMD11vDbD.Select(s => s.cmdt114).First();
                    List1.DYverf114 = UHSOMD11vDbD.Select(s => s.verf114).First();
                    List1.DYsmid115 = UHSOMD11vDbD.Select(s => s.smid115).First();
                    List1.DYcmdt115 = UHSOMD11vDbD.Select(s => s.cmdt115).First();
                    List1.DYverf115 = UHSOMD11vDbD.Select(s => s.verf115).First();
                    List1.DYsmid116 = UHSOMD11vDbD.Select(s => s.smid116).First();
                    List1.DYcmdt116 = UHSOMD11vDbD.Select(s => s.cmdt116).First();
                    List1.DYverf116 = UHSOMD11vDbD.Select(s => s.verf116).First();
                    List1.DYsmid117 = UHSOMD11vDbD.Select(s => s.smid117).First();
                    List1.DYcmdt117 = UHSOMD11vDbD.Select(s => s.cmdt117).First();
                    List1.DYverf117 = UHSOMD11vDbD.Select(s => s.verf117).First();
                    List1.DYsmid118 = UHSOMD11vDbD.Select(s => s.smid118).First();
                    List1.DYcmdt118 = UHSOMD11vDbD.Select(s => s.cmdt118).First();
                    List1.DYverf118 = UHSOMD11vDbD.Select(s => s.verf118).First();
                    List1.DYsmid119 = UHSOMD11vDbD.Select(s => s.smid119).First();
                    List1.DYcmdt119 = UHSOMD11vDbD.Select(s => s.cmdt119).First();
                    List1.DYverf119 = UHSOMD11vDbD.Select(s => s.verf119).First();
                    List1.DYsmid120 = UHSOMD11vDbD.Select(s => s.smid120).First();
                    List1.DYcmdt120 = UHSOMD11vDbD.Select(s => s.cmdt120).First();
                    List1.DYverf120 = UHSOMD11vDbD.Select(s => s.verf120).First();
                    List1.DYsmid121 = UHSOMD11vDbD.Select(s => s.smid121).First();
                    List1.DYcmdt121 = UHSOMD11vDbD.Select(s => s.cmdt121).First();
                    List1.DYverf121 = UHSOMD11vDbD.Select(s => s.verf121).First();
                    List1.DYsmid122 = UHSOMD11vDbD.Select(s => s.smid122).First();
                    List1.DYcmdt122 = UHSOMD11vDbD.Select(s => s.cmdt122).First();
                    List1.DYverf122 = UHSOMD11vDbD.Select(s => s.verf122).First();
                    List1.DYsmid123 = UHSOMD11vDbD.Select(s => s.smid123).First();
                    List1.DYcmdt123 = UHSOMD11vDbD.Select(s => s.cmdt123).First();
                    List1.DYverf123 = UHSOMD11vDbD.Select(s => s.verf123).First();
                    List1.DYsmid124 = UHSOMD11vDbD.Select(s => s.smid124).First();
                    List1.DYcmdt124 = UHSOMD11vDbD.Select(s => s.cmdt124).First();
                    List1.DYverf124 = UHSOMD11vDbD.Select(s => s.verf124).First();
                    List1.DYsmid125 = UHSOMD11vDbD.Select(s => s.smid125).First();
                    List1.DYcmdt125 = UHSOMD11vDbD.Select(s => s.cmdt125).First();
                    List1.DYverf125 = UHSOMD11vDbD.Select(s => s.verf125).First();
                    List1.DYnote01 = UHSOMD11vDbD.Select(s => s.note01).First();
                    List1.DYnote02 = UHSOMD11vDbD.Select(s => s.note02).First();
                    List1.DYnote03 = UHSOMD11vDbD.Select(s => s.note03).First();
                    List1.DYnote04 = UHSOMD11vDbD.Select(s => s.note04).First();
                    List1.DYnote05 = UHSOMD11vDbD.Select(s => s.note05).First();
                    List1.DYnote06 = UHSOMD11vDbD.Select(s => s.note06).First();
                    List1.DYnote07 = UHSOMD11vDbD.Select(s => s.note07).First();
                    List1.DYnote08 = UHSOMD11vDbD.Select(s => s.note08).First();
                    List1.DYnote09 = UHSOMD11vDbD.Select(s => s.note09).First();
                    List1.DYnote10 = UHSOMD11vDbD.Select(s => s.note10).First();
                    List1.DYnote11 = UHSOMD11vDbD.Select(s => s.note11).First();
                    List1.DYnote12 = UHSOMD11vDbD.Select(s => s.note12).First();
                    List1.DYnote13 = UHSOMD11vDbD.Select(s => s.note13).First();
                    List1.DYnote14 = UHSOMD11vDbD.Select(s => s.note14).First();
                    List1.DYnote15 = UHSOMD11vDbD.Select(s => s.note15).First();
                    List1.DYtask01 = UHSOMD11vDbD.Select(s => s.task01).First();
                    List1.DYtask02 = UHSOMD11vDbD.Select(s => s.task02).First();
                    List1.DYtask03 = UHSOMD11vDbD.Select(s => s.task03).First();
                    List1.DYtask04 = UHSOMD11vDbD.Select(s => s.task04).First();
                    List1.DYtask05 = UHSOMD11vDbD.Select(s => s.task05).First();
                    List1.DYacit01 = UHSOMD11vDbD.Select(s => s.acit01).First();
                    List1.DYacit02 = UHSOMD11vDbD.Select(s => s.acit02).First();
                    List1.DYacit03 = UHSOMD11vDbD.Select(s => s.acit03).First();
                    List1.DYacit04 = UHSOMD11vDbD.Select(s => s.acit04).First();
                    List1.DYacit05 = UHSOMD11vDbD.Select(s => s.acit05).First();
                    List1.DYtool01 = UHSOMD11vDbD.Select(s => s.tool01).First();
                    List1.DYtool02 = UHSOMD11vDbD.Select(s => s.tool02).First();
                    List1.DYtool03 = UHSOMD11vDbD.Select(s => s.tool03).First();
                    List1.DYtool04 = UHSOMD11vDbD.Select(s => s.tool04).First();
                    List1.DYtool05 = UHSOMD11vDbD.Select(s => s.tool05).First();
                    List1.DYdocn01 = UHSOMD11vDbD.Select(s => s.docn01).First();
                    List1.DYdocn02 = UHSOMD11vDbD.Select(s => s.docn02).First();
                    List1.DYdocn03 = UHSOMD11vDbD.Select(s => s.docn03).First();
                    List1.DYdocn04 = UHSOMD11vDbD.Select(s => s.docn04).First();
                    List1.DYdocn05 = UHSOMD11vDbD.Select(s => s.docn05).First();
                    List1.DYprfx01 = UHSOMD11vDbD.Select(s => s.prfx01).First();
                    List1.DYprfx02 = UHSOMD11vDbD.Select(s => s.prfx02).First();
                    List1.DYprfx03 = UHSOMD11vDbD.Select(s => s.prfx03).First();
                    List1.DYprfx04 = UHSOMD11vDbD.Select(s => s.prfx04).First();
                    List1.DYprfx05 = UHSOMD11vDbD.Select(s => s.prfx05).First();
                    List1.DYrate01 = UHSOMD11vDbD.Select(s => s.rate01).First();
                    List1.DYrate02 = UHSOMD11vDbD.Select(s => s.rate02).First();
                    List1.DYrate03 = UHSOMD11vDbD.Select(s => s.rate03).First();
                    List1.DYrate04 = UHSOMD11vDbD.Select(s => s.rate04).First();
                    List1.DYrate05 = UHSOMD11vDbD.Select(s => s.rate05).First();
                    List1.DYpref01 = UHSOMD11vDbD.Select(s => s.pref01).First();
                    List1.DYpref02 = UHSOMD11vDbD.Select(s => s.pref02).First();
                    List1.DYpref03 = UHSOMD11vDbD.Select(s => s.pref03).First();
                    List1.DYpref04 = UHSOMD11vDbD.Select(s => s.pref04).First();
                    List1.DYpref05 = UHSOMD11vDbD.Select(s => s.pref05).First();
                    List1.DYratd01 = UHSOMD11vDbD.Select(s => s.ratd01).First();
                    List1.DYratd02 = UHSOMD11vDbD.Select(s => s.ratd02).First();
                    List1.DYratd03 = UHSOMD11vDbD.Select(s => s.ratd03).First();
                    List1.DYratd04 = UHSOMD11vDbD.Select(s => s.ratd04).First();
                    List1.DYratd05 = UHSOMD11vDbD.Select(s => s.ratd05).First();
                    List1.DYallch1c = UHSOMD11vDbD.Select(s => s.allch1c).First();
                    List1.DYwekday = UHSOMD11vDbD.Select(s => s.wekday).First();
                    List1.DYwekdnm = UHSOMD11vDbD.Select(s => s.wekdnm).First();
                    List1.DYchck = UHSOMD11vDbD.Select(s => s.chck).First();
                    List1.DYchckid = UHSOMD11vDbD.Select(s => s.chckid).First();
                    List1.DYchcknm = UHSOMD11vDbD.Select(s => s.chcknm).First();
                    List1.DYchckdt = UHSOMD11vDbD.Select(s => s.chckdt).First();
                    List1.DYyyyy = UHSOMD11vDbD.Select(s => s.yyyy).First();
                    List1.DYyyyymm = UHSOMD11vDbD.Select(s => s.yyyymm).First();
                    List1.DYweeknr = UHSOMD11vDbD.Select(s => s.weeknr).First();
                    List1.DYweekds = UHSOMD11vDbD.Select(s => s.weekds).First();
                    List1.DYyyyymmdd = UHSOMD11vDbD.Select(s => s.yyyymmdd).First();
                    List1.DYhhmmss = UHSOMD11vDbD.Select(s => s.hhmmss).First();
                    List1.DYcrdt = UHSOMD11vDbD.Select(s => s.crdt).First();
                    List1.DYeddt = UHSOMD11vDbD.Select(s => s.eddt).First();
                    List1.DYcrusid = UHSOMD11vDbD.Select(s => s.crusid).First();
                    List1.DYedusid = UHSOMD11vDbD.Select(s => s.edusid).First();
                    List1.DYcrusnm = UHSOMD11vDbD.Select(s => s.crusnm).First();
                    List1.DYedusnm = UHSOMD11vDbD.Select(s => s.edusnm).First();
                    List1.DYcrdate = UHSOMD11vDbD.Select(s => s.crdate).First();
                    //List1.EYID = UHSOMD11vDbE.Select(s => s.ID).First();
                    //List1.EYprojid = UHSOMD11vDbE.Select(s => s.projid).First();
                    //List1.EYtskoid = UHSOMD11vDbE.Select(s => s.tskoid).First();
                    //List1.EYdcgrid = UHSOMD11vDbE.Select(s => s.dcgrid).First();
                    //List1.EYdctpid = UHSOMD11vDbE.Select(s => s.dctpid).First();
                    //List1.EYtspdid = UHSOMD11vDbE.Select(s => s.tspdid).First();
                    //List1.EYdistid = UHSOMD11vDbE.Select(s => s.distid).First();
                    //List1.EYdistnm = UHSOMD11vDbE.Select(s => s.distnm).First();
                    //List1.EYacctid = UHSOMD11vDbE.Select(s => s.acctid).First();
                    //List1.EYuserid = UHSOMD11vDbE.Select(s => s.userid).First();
                    //List1.EYusernm = UHSOMD11vDbE.Select(s => s.usernm).First();
                    //List1.EYdimgid = UHSOMD11vDbE.Select(s => s.dimgid).First();
                    //List1.EYdimgnm = UHSOMD11vDbE.Select(s => s.dimgnm).First();
                    //List1.EYsmid111 = UHSOMD11vDbE.Select(s => s.smid111).First();
                    //List1.EYcmdt111 = UHSOMD11vDbE.Select(s => s.cmdt111).First();
                    //List1.EYverf111 = UHSOMD11vDbE.Select(s => s.verf111).First();
                    //List1.EYsmid112 = UHSOMD11vDbE.Select(s => s.smid112).First();
                    //List1.EYcmdt112 = UHSOMD11vDbE.Select(s => s.cmdt112).First();
                    //List1.EYverf112 = UHSOMD11vDbE.Select(s => s.verf112).First();
                    //List1.EYsmid113 = UHSOMD11vDbE.Select(s => s.smid113).First();
                    //List1.EYcmdt113 = UHSOMD11vDbE.Select(s => s.cmdt113).First();
                    //List1.EYverf113 = UHSOMD11vDbE.Select(s => s.verf113).First();
                    //List1.EYsmid114 = UHSOMD11vDbE.Select(s => s.smid114).First();
                    //List1.EYcmdt114 = UHSOMD11vDbE.Select(s => s.cmdt114).First();
                    //List1.EYverf114 = UHSOMD11vDbE.Select(s => s.verf114).First();
                    //List1.EYsmid115 = UHSOMD11vDbE.Select(s => s.smid115).First();
                    //List1.EYcmdt115 = UHSOMD11vDbE.Select(s => s.cmdt115).First();
                    //List1.EYverf115 = UHSOMD11vDbE.Select(s => s.verf115).First();
                    //List1.EYsmid116 = UHSOMD11vDbE.Select(s => s.smid116).First();
                    //List1.EYcmdt116 = UHSOMD11vDbE.Select(s => s.cmdt116).First();
                    //List1.EYverf116 = UHSOMD11vDbE.Select(s => s.verf116).First();
                    //List1.EYsmid117 = UHSOMD11vDbE.Select(s => s.smid117).First();
                    //List1.EYcmdt117 = UHSOMD11vDbE.Select(s => s.cmdt117).First();
                    //List1.EYverf117 = UHSOMD11vDbE.Select(s => s.verf117).First();
                    //List1.EYsmid118 = UHSOMD11vDbE.Select(s => s.smid118).First();
                    //List1.EYcmdt118 = UHSOMD11vDbE.Select(s => s.cmdt118).First();
                    //List1.EYverf118 = UHSOMD11vDbE.Select(s => s.verf118).First();
                    //List1.EYsmid119 = UHSOMD11vDbE.Select(s => s.smid119).First();
                    //List1.EYcmdt119 = UHSOMD11vDbE.Select(s => s.cmdt119).First();
                    //List1.EYverf119 = UHSOMD11vDbE.Select(s => s.verf119).First();
                    //List1.EYsmid120 = UHSOMD11vDbE.Select(s => s.smid120).First();
                    //List1.EYcmdt120 = UHSOMD11vDbE.Select(s => s.cmdt120).First();
                    //List1.EYverf120 = UHSOMD11vDbE.Select(s => s.verf120).First();
                    //List1.EYsmid121 = UHSOMD11vDbE.Select(s => s.smid121).First();
                    //List1.EYcmdt121 = UHSOMD11vDbE.Select(s => s.cmdt121).First();
                    //List1.EYverf121 = UHSOMD11vDbE.Select(s => s.verf121).First();
                    //List1.EYsmid122 = UHSOMD11vDbE.Select(s => s.smid122).First();
                    //List1.EYcmdt122 = UHSOMD11vDbE.Select(s => s.cmdt122).First();
                    //List1.EYverf122 = UHSOMD11vDbE.Select(s => s.verf122).First();
                    //List1.EYsmid123 = UHSOMD11vDbE.Select(s => s.smid123).First();
                    //List1.EYcmdt123 = UHSOMD11vDbE.Select(s => s.cmdt123).First();
                    //List1.EYverf123 = UHSOMD11vDbE.Select(s => s.verf123).First();
                    //List1.EYsmid124 = UHSOMD11vDbE.Select(s => s.smid124).First();
                    //List1.EYcmdt124 = UHSOMD11vDbE.Select(s => s.cmdt124).First();
                    //List1.EYverf124 = UHSOMD11vDbE.Select(s => s.verf124).First();
                    //List1.EYsmid125 = UHSOMD11vDbE.Select(s => s.smid125).First();
                    //List1.EYcmdt125 = UHSOMD11vDbE.Select(s => s.cmdt125).First();
                    //List1.EYverf125 = UHSOMD11vDbE.Select(s => s.verf125).First();
                    //List1.EYnote01 = UHSOMD11vDbE.Select(s => s.note01).First();
                    //List1.EYnote02 = UHSOMD11vDbE.Select(s => s.note02).First();
                    //List1.EYnote03 = UHSOMD11vDbE.Select(s => s.note03).First();
                    //List1.EYnote04 = UHSOMD11vDbE.Select(s => s.note04).First();
                    //List1.EYnote05 = UHSOMD11vDbE.Select(s => s.note05).First();
                    //List1.EYnote06 = UHSOMD11vDbE.Select(s => s.note06).First();
                    //List1.EYnote07 = UHSOMD11vDbE.Select(s => s.note07).First();
                    //List1.EYnote08 = UHSOMD11vDbE.Select(s => s.note08).First();
                    //List1.EYnote09 = UHSOMD11vDbE.Select(s => s.note09).First();
                    //List1.EYnote10 = UHSOMD11vDbE.Select(s => s.note10).First();
                    //List1.EYnote11 = UHSOMD11vDbE.Select(s => s.note11).First();
                    //List1.EYnote12 = UHSOMD11vDbE.Select(s => s.note12).First();
                    //List1.EYnote13 = UHSOMD11vDbE.Select(s => s.note13).First();
                    //List1.EYnote14 = UHSOMD11vDbE.Select(s => s.note14).First();
                    //List1.EYnote15 = UHSOMD11vDbE.Select(s => s.note15).First();
                    //List1.EYtask01 = UHSOMD11vDbE.Select(s => s.task01).First();
                    //List1.EYtask02 = UHSOMD11vDbE.Select(s => s.task02).First();
                    //List1.EYtask03 = UHSOMD11vDbE.Select(s => s.task03).First();
                    //List1.EYtask04 = UHSOMD11vDbE.Select(s => s.task04).First();
                    //List1.EYtask05 = UHSOMD11vDbE.Select(s => s.task05).First();
                    //List1.EYacit01 = UHSOMD11vDbE.Select(s => s.acit01).First();
                    //List1.EYacit02 = UHSOMD11vDbE.Select(s => s.acit02).First();
                    //List1.EYacit03 = UHSOMD11vDbE.Select(s => s.acit03).First();
                    //List1.EYacit04 = UHSOMD11vDbE.Select(s => s.acit04).First();
                    //List1.EYacit05 = UHSOMD11vDbE.Select(s => s.acit05).First();
                    //List1.EYtool01 = UHSOMD11vDbE.Select(s => s.tool01).First();
                    //List1.EYtool02 = UHSOMD11vDbE.Select(s => s.tool02).First();
                    //List1.EYtool03 = UHSOMD11vDbE.Select(s => s.tool03).First();
                    //List1.EYtool04 = UHSOMD11vDbE.Select(s => s.tool04).First();
                    //List1.EYtool05 = UHSOMD11vDbE.Select(s => s.tool05).First();
                    //List1.EYdocn01 = UHSOMD11vDbE.Select(s => s.docn01).First();
                    //List1.EYdocn02 = UHSOMD11vDbE.Select(s => s.docn02).First();
                    //List1.EYdocn03 = UHSOMD11vDbE.Select(s => s.docn03).First();
                    //List1.EYdocn04 = UHSOMD11vDbE.Select(s => s.docn04).First();
                    //List1.EYdocn05 = UHSOMD11vDbE.Select(s => s.docn05).First();
                    //List1.EYprfx01 = UHSOMD11vDbE.Select(s => s.prfx01).First();
                    //List1.EYprfx02 = UHSOMD11vDbE.Select(s => s.prfx02).First();
                    //List1.EYprfx03 = UHSOMD11vDbE.Select(s => s.prfx03).First();
                    //List1.EYprfx04 = UHSOMD11vDbE.Select(s => s.prfx04).First();
                    //List1.EYprfx05 = UHSOMD11vDbE.Select(s => s.prfx05).First();
                    //List1.EYrate01 = UHSOMD11vDbE.Select(s => s.rate01).First();
                    //List1.EYrate02 = UHSOMD11vDbE.Select(s => s.rate02).First();
                    //List1.EYrate03 = UHSOMD11vDbE.Select(s => s.rate03).First();
                    //List1.EYrate04 = UHSOMD11vDbE.Select(s => s.rate04).First();
                    //List1.EYrate05 = UHSOMD11vDbE.Select(s => s.rate05).First();
                    //List1.EYpref01 = UHSOMD11vDbE.Select(s => s.pref01).First();
                    //List1.EYpref02 = UHSOMD11vDbE.Select(s => s.pref02).First();
                    //List1.EYpref03 = UHSOMD11vDbE.Select(s => s.pref03).First();
                    //List1.EYpref04 = UHSOMD11vDbE.Select(s => s.pref04).First();
                    //List1.EYpref05 = UHSOMD11vDbE.Select(s => s.pref05).First();
                    //List1.EYratd01 = UHSOMD11vDbE.Select(s => s.ratd01).First();
                    //List1.EYratd02 = UHSOMD11vDbE.Select(s => s.ratd02).First();
                    //List1.EYratd03 = UHSOMD11vDbE.Select(s => s.ratd03).First();
                    //List1.EYratd04 = UHSOMD11vDbE.Select(s => s.ratd04).First();
                    //List1.EYratd05 = UHSOMD11vDbE.Select(s => s.ratd05).First();
                    //List1.EYallch1c = UHSOMD11vDbE.Select(s => s.allch1c).First();
                    //List1.EYwekday = UHSOMD11vDbE.Select(s => s.wekday).First();
                    //List1.EYwekdnm = UHSOMD11vDbE.Select(s => s.wekdnm).First();
                    //List1.EYchck = UHSOMD11vDbE.Select(s => s.chck).First();
                    //List1.EYchckid = UHSOMD11vDbE.Select(s => s.chckid).First();
                    //List1.EYchcknm = UHSOMD11vDbE.Select(s => s.chcknm).First();
                    //List1.EYchckdt = UHSOMD11vDbE.Select(s => s.chckdt).First();
                    //List1.EYyyyy = UHSOMD11vDbE.Select(s => s.yyyy).First();
                    //List1.EYyyyymm = UHSOMD11vDbE.Select(s => s.yyyymm).First();
                    //List1.EYweeknr = UHSOMD11vDbE.Select(s => s.weeknr).First();
                    //List1.EYweekds = UHSOMD11vDbE.Select(s => s.weekds).First();
                    //List1.EYyyyymmdd = UHSOMD11vDbE.Select(s => s.yyyymmdd).First();
                    //List1.EYhhmmss = UHSOMD11vDbE.Select(s => s.hhmmss).First();
                    //List1.EYcrdt = UHSOMD11vDbE.Select(s => s.crdt).First();
                    //List1.EYeddt = UHSOMD11vDbE.Select(s => s.eddt).First();
                    //List1.EYcrusid = UHSOMD11vDbE.Select(s => s.crusid).First();
                    //List1.EYedusid = UHSOMD11vDbE.Select(s => s.edusid).First();
                    //List1.EYcrusnm = UHSOMD11vDbE.Select(s => s.crusnm).First();
                    //List1.EYedusnm = UHSOMD11vDbE.Select(s => s.edusnm).First();
                    //List1.EYcrdate = UHSOMD11vDbE.Select(s => s.crdate).First();
                    List1.AZsmid111 = db.agentsDbs.Where(s => s.ID == id111).Select(s => s.agentName).First();
                    List1.AZsmid112 = db.agentsDbs.Where(s => s.ID == id112).Select(s => s.agentName).First();
                    List1.AZsmid113 = db.agentsDbs.Where(s => s.ID == id113).Select(s => s.agentName).First();
                    List1.AZsmid114 = db.agentsDbs.Where(s => s.ID == id114).Select(s => s.agentName).First();
                    List1.AZsmid115 = db.agentsDbs.Where(s => s.ID == id115).Select(s => s.agentName).First();
                    List1.AZsmid116 = db.agentsDbs.Where(s => s.ID == id116).Select(s => s.agentName).First();
                    List1.AZsmid117 = db.agentsDbs.Where(s => s.ID == id117).Select(s => s.agentName).First();
                    List1.AZsmid118 = db.agentsDbs.Where(s => s.ID == id118).Select(s => s.agentName).First();
                    List1.AZsmid119 = db.agentsDbs.Where(s => s.ID == id119).Select(s => s.agentName).First();
                    List1.AZsmid120 = db.agentsDbs.Where(s => s.ID == id120).Select(s => s.agentName).First();
                    List1.AZsmid121 = db.agentsDbs.Where(s => s.ID == id121).Select(s => s.agentName).First();
                    List1.AZsmid122 = db.agentsDbs.Where(s => s.ID == id122).Select(s => s.agentName).First();
                    List1.AZsmid123 = db.agentsDbs.Where(s => s.ID == id123).Select(s => s.agentName).First();
                    List1.AZsmid124 = db.agentsDbs.Where(s => s.ID == id124).Select(s => s.agentName).First();
                    List1.AZsmid125 = db.agentsDbs.Where(s => s.ID == id125).Select(s => s.agentName).First();
                    List1.BZsmid111 = db.agentsDbs.Where(s => s.ID == id211).Select(s => s.agentName).First();
                    List1.BZsmid112 = db.agentsDbs.Where(s => s.ID == id212).Select(s => s.agentName).First();
                    List1.BZsmid113 = db.agentsDbs.Where(s => s.ID == id213).Select(s => s.agentName).First();
                    List1.BZsmid114 = db.agentsDbs.Where(s => s.ID == id214).Select(s => s.agentName).First();
                    List1.BZsmid115 = db.agentsDbs.Where(s => s.ID == id215).Select(s => s.agentName).First();
                    List1.BZsmid116 = db.agentsDbs.Where(s => s.ID == id216).Select(s => s.agentName).First();
                    List1.BZsmid117 = db.agentsDbs.Where(s => s.ID == id217).Select(s => s.agentName).First();
                    List1.BZsmid118 = db.agentsDbs.Where(s => s.ID == id218).Select(s => s.agentName).First();
                    List1.BZsmid119 = db.agentsDbs.Where(s => s.ID == id219).Select(s => s.agentName).First();
                    List1.BZsmid120 = db.agentsDbs.Where(s => s.ID == id220).Select(s => s.agentName).First();
                    List1.BZsmid121 = db.agentsDbs.Where(s => s.ID == id221).Select(s => s.agentName).First();
                    List1.BZsmid122 = db.agentsDbs.Where(s => s.ID == id222).Select(s => s.agentName).First();
                    List1.BZsmid123 = db.agentsDbs.Where(s => s.ID == id223).Select(s => s.agentName).First();
                    List1.BZsmid124 = db.agentsDbs.Where(s => s.ID == id224).Select(s => s.agentName).First();
                    List1.BZsmid125 = db.agentsDbs.Where(s => s.ID == id225).Select(s => s.agentName).First();
                    List1.CZsmid111 = db.agentsDbs.Where(s => s.ID == id311).Select(s => s.agentName).First();
                    List1.CZsmid112 = db.agentsDbs.Where(s => s.ID == id312).Select(s => s.agentName).First();
                    List1.CZsmid113 = db.agentsDbs.Where(s => s.ID == id313).Select(s => s.agentName).First();
                    List1.CZsmid114 = db.agentsDbs.Where(s => s.ID == id314).Select(s => s.agentName).First();
                    List1.CZsmid115 = db.agentsDbs.Where(s => s.ID == id315).Select(s => s.agentName).First();
                    List1.CZsmid116 = db.agentsDbs.Where(s => s.ID == id316).Select(s => s.agentName).First();
                    List1.CZsmid117 = db.agentsDbs.Where(s => s.ID == id317).Select(s => s.agentName).First();
                    List1.CZsmid118 = db.agentsDbs.Where(s => s.ID == id318).Select(s => s.agentName).First();
                    List1.CZsmid119 = db.agentsDbs.Where(s => s.ID == id319).Select(s => s.agentName).First();
                    List1.CZsmid120 = db.agentsDbs.Where(s => s.ID == id320).Select(s => s.agentName).First();
                    List1.CZsmid121 = db.agentsDbs.Where(s => s.ID == id321).Select(s => s.agentName).First();
                    List1.CZsmid122 = db.agentsDbs.Where(s => s.ID == id322).Select(s => s.agentName).First();
                    List1.CZsmid123 = db.agentsDbs.Where(s => s.ID == id323).Select(s => s.agentName).First();
                    List1.CZsmid124 = db.agentsDbs.Where(s => s.ID == id324).Select(s => s.agentName).First();
                    List1.CZsmid125 = db.agentsDbs.Where(s => s.ID == id325).Select(s => s.agentName).First();
                    List1.DZsmid111 = db.agentsDbs.Where(s => s.ID == id411).Select(s => s.agentName).First();
                    List1.DZsmid112 = db.agentsDbs.Where(s => s.ID == id412).Select(s => s.agentName).First();
                    List1.DZsmid113 = db.agentsDbs.Where(s => s.ID == id413).Select(s => s.agentName).First();
                    List1.DZsmid114 = db.agentsDbs.Where(s => s.ID == id414).Select(s => s.agentName).First();
                    List1.DZsmid115 = db.agentsDbs.Where(s => s.ID == id415).Select(s => s.agentName).First();
                    List1.DZsmid116 = db.agentsDbs.Where(s => s.ID == id416).Select(s => s.agentName).First();
                    List1.DZsmid117 = db.agentsDbs.Where(s => s.ID == id417).Select(s => s.agentName).First();
                    List1.DZsmid118 = db.agentsDbs.Where(s => s.ID == id418).Select(s => s.agentName).First();
                    List1.DZsmid119 = db.agentsDbs.Where(s => s.ID == id419).Select(s => s.agentName).First();
                    List1.DZsmid120 = db.agentsDbs.Where(s => s.ID == id420).Select(s => s.agentName).First();
                    List1.DZsmid121 = db.agentsDbs.Where(s => s.ID == id421).Select(s => s.agentName).First();
                    List1.DZsmid122 = db.agentsDbs.Where(s => s.ID == id422).Select(s => s.agentName).First();
                    List1.DZsmid123 = db.agentsDbs.Where(s => s.ID == id423).Select(s => s.agentName).First();
                    List1.DZsmid124 = db.agentsDbs.Where(s => s.ID == id424).Select(s => s.agentName).First();
                    List1.DZsmid125 = db.agentsDbs.Where(s => s.ID == id425).Select(s => s.agentName).First();
                    //List1.EZsmid111 = db.agentsDbs.Where(s => s.ID == id511).Select(s => s.agentName).First();
                    //List1.EZsmid112 = db.agentsDbs.Where(s => s.ID == id512).Select(s => s.agentName).First();
                    //List1.EZsmid113 = db.agentsDbs.Where(s => s.ID == id513).Select(s => s.agentName).First();
                    //List1.EZsmid114 = db.agentsDbs.Where(s => s.ID == id514).Select(s => s.agentName).First();
                    //List1.EZsmid115 = db.agentsDbs.Where(s => s.ID == id515).Select(s => s.agentName).First();
                    //List1.EZsmid116 = db.agentsDbs.Where(s => s.ID == id516).Select(s => s.agentName).First();
                    //List1.EZsmid117 = db.agentsDbs.Where(s => s.ID == id517).Select(s => s.agentName).First();
                    //List1.EZsmid118 = db.agentsDbs.Where(s => s.ID == id518).Select(s => s.agentName).First();
                    //List1.EZsmid119 = db.agentsDbs.Where(s => s.ID == id519).Select(s => s.agentName).First();
                    //List1.EZsmid120 = db.agentsDbs.Where(s => s.ID == id520).Select(s => s.agentName).First();
                    //List1.EZsmid121 = db.agentsDbs.Where(s => s.ID == id521).Select(s => s.agentName).First();
                    //List1.EZsmid122 = db.agentsDbs.Where(s => s.ID == id522).Select(s => s.agentName).First();
                    //List1.EZsmid123 = db.agentsDbs.Where(s => s.ID == id523).Select(s => s.agentName).First();
                    //List1.EZsmid124 = db.agentsDbs.Where(s => s.ID == id524).Select(s => s.agentName).First();
                    //List1.EZsmid125 = db.agentsDbs.Where(s => s.ID == id525).Select(s => s.agentName).First();
                    List1.AZcmdt111 = UHSOMD11Db.Select(s => s.cmdt111).First();
                    List1.AZcmdt112 = UHSOMD11Db.Select(s => s.cmdt112).First();
                    List1.AZcmdt113 = UHSOMD11Db.Select(s => s.cmdt113).First();
                    List1.AZcmdt114 = UHSOMD11Db.Select(s => s.cmdt114).First();
                    List1.AZcmdt115 = UHSOMD11Db.Select(s => s.cmdt115).First();
                    List1.AZcmdt116 = UHSOMD11Db.Select(s => s.cmdt116).First();
                    List1.AZcmdt117 = UHSOMD11Db.Select(s => s.cmdt117).First();
                    List1.AZcmdt118 = UHSOMD11Db.Select(s => s.cmdt118).First();
                    List1.AZcmdt119 = UHSOMD11Db.Select(s => s.cmdt119).First();
                    List1.AZcmdt120 = UHSOMD11Db.Select(s => s.cmdt120).First();
                    List1.AZcmdt121 = UHSOMD11Db.Select(s => s.cmdt121).First();
                    List1.AZcmdt122 = UHSOMD11Db.Select(s => s.cmdt122).First();
                    List1.AZcmdt123 = UHSOMD11Db.Select(s => s.cmdt123).First();
                    List1.AZcmdt124 = UHSOMD11Db.Select(s => s.cmdt124).First();
                    List1.AZcmdt125 = UHSOMD11Db.Select(s => s.cmdt125).First();
                    List1.BZcmdt111 = UHSOMD12Db.Select(s => s.cmdt111).First();
                    List1.BZcmdt112 = UHSOMD12Db.Select(s => s.cmdt112).First();
                    List1.BZcmdt113 = UHSOMD12Db.Select(s => s.cmdt113).First();
                    List1.BZcmdt114 = UHSOMD12Db.Select(s => s.cmdt114).First();
                    List1.BZcmdt115 = UHSOMD12Db.Select(s => s.cmdt115).First();
                    List1.BZcmdt116 = UHSOMD12Db.Select(s => s.cmdt116).First();
                    List1.BZcmdt117 = UHSOMD12Db.Select(s => s.cmdt117).First();
                    List1.BZcmdt118 = UHSOMD12Db.Select(s => s.cmdt118).First();
                    List1.BZcmdt119 = UHSOMD12Db.Select(s => s.cmdt119).First();
                    List1.BZcmdt120 = UHSOMD12Db.Select(s => s.cmdt120).First();
                    List1.BZcmdt121 = UHSOMD12Db.Select(s => s.cmdt121).First();
                    List1.BZcmdt122 = UHSOMD12Db.Select(s => s.cmdt122).First();
                    List1.BZcmdt123 = UHSOMD12Db.Select(s => s.cmdt123).First();
                    List1.BZcmdt124 = UHSOMD12Db.Select(s => s.cmdt124).First();
                    List1.BZcmdt125 = UHSOMD12Db.Select(s => s.cmdt125).First();
                    List1.CZcmdt111 = UHSOMD13Db.Select(s => s.cmdt111).First();
                    List1.CZcmdt112 = UHSOMD13Db.Select(s => s.cmdt112).First();
                    List1.CZcmdt113 = UHSOMD13Db.Select(s => s.cmdt113).First();
                    List1.CZcmdt114 = UHSOMD13Db.Select(s => s.cmdt114).First();
                    List1.CZcmdt115 = UHSOMD13Db.Select(s => s.cmdt115).First();
                    List1.CZcmdt116 = UHSOMD13Db.Select(s => s.cmdt116).First();
                    List1.CZcmdt117 = UHSOMD13Db.Select(s => s.cmdt117).First();
                    List1.CZcmdt118 = UHSOMD13Db.Select(s => s.cmdt118).First();
                    List1.CZcmdt119 = UHSOMD13Db.Select(s => s.cmdt119).First();
                    List1.CZcmdt120 = UHSOMD13Db.Select(s => s.cmdt120).First();
                    List1.CZcmdt121 = UHSOMD13Db.Select(s => s.cmdt121).First();
                    List1.CZcmdt122 = UHSOMD13Db.Select(s => s.cmdt122).First();
                    List1.CZcmdt123 = UHSOMD13Db.Select(s => s.cmdt123).First();
                    List1.CZcmdt124 = UHSOMD13Db.Select(s => s.cmdt124).First();
                    List1.CZcmdt125 = UHSOMD13Db.Select(s => s.cmdt125).First();
                    List1.DZcmdt111 = UHSOMD14Db.Select(s => s.cmdt111).First();
                    List1.DZcmdt112 = UHSOMD14Db.Select(s => s.cmdt112).First();
                    List1.DZcmdt113 = UHSOMD14Db.Select(s => s.cmdt113).First();
                    List1.DZcmdt114 = UHSOMD14Db.Select(s => s.cmdt114).First();
                    List1.DZcmdt115 = UHSOMD14Db.Select(s => s.cmdt115).First();
                    List1.DZcmdt116 = UHSOMD14Db.Select(s => s.cmdt116).First();
                    List1.DZcmdt117 = UHSOMD14Db.Select(s => s.cmdt117).First();
                    List1.DZcmdt118 = UHSOMD14Db.Select(s => s.cmdt118).First();
                    List1.DZcmdt119 = UHSOMD14Db.Select(s => s.cmdt119).First();
                    List1.DZcmdt120 = UHSOMD14Db.Select(s => s.cmdt120).First();
                    List1.DZcmdt121 = UHSOMD14Db.Select(s => s.cmdt121).First();
                    List1.DZcmdt122 = UHSOMD14Db.Select(s => s.cmdt122).First();
                    List1.DZcmdt123 = UHSOMD14Db.Select(s => s.cmdt123).First();
                    List1.DZcmdt124 = UHSOMD14Db.Select(s => s.cmdt124).First();
                    List1.DZcmdt125 = UHSOMD14Db.Select(s => s.cmdt125).First();
                    //List1.EZcmdt111 = UHSOMD15Db.Select(s => s.cmdt111).First();
                    //List1.EZcmdt112 = UHSOMD15Db.Select(s => s.cmdt112).First();
                    //List1.EZcmdt113 = UHSOMD15Db.Select(s => s.cmdt113).First();
                    //List1.EZcmdt114 = UHSOMD15Db.Select(s => s.cmdt114).First();
                    //List1.EZcmdt115 = UHSOMD15Db.Select(s => s.cmdt115).First();
                    //List1.EZcmdt116 = UHSOMD15Db.Select(s => s.cmdt116).First();
                    //List1.EZcmdt117 = UHSOMD15Db.Select(s => s.cmdt117).First();
                    //List1.EZcmdt118 = UHSOMD15Db.Select(s => s.cmdt118).First();
                    //List1.EZcmdt119 = UHSOMD15Db.Select(s => s.cmdt119).First();
                    //List1.EZcmdt120 = UHSOMD15Db.Select(s => s.cmdt120).First();
                    //List1.EZcmdt121 = UHSOMD15Db.Select(s => s.cmdt121).First();
                    //List1.EZcmdt122 = UHSOMD15Db.Select(s => s.cmdt122).First();
                    //List1.EZcmdt123 = UHSOMD15Db.Select(s => s.cmdt123).First();
                    //List1.EZcmdt124 = UHSOMD15Db.Select(s => s.cmdt124).First();
                    //List1.EZcmdt125 = UHSOMD15Db.Select(s => s.cmdt125).First();

                    List1.zacc = opa.UHSACCTSDbs.Where(s => s.IDc == id1 && s.typeid == 2).Select(s => s.CSTNM).First();
                    List1.zdiv = opa.UHSACCTSDbs.Where(s => s.IDc == id1 && s.typeid == 2).Select(s => s.DIV).First();
                    List1.zomh = opa.UHSACCTSDbs.Where(s => s.IDc == id1 && s.typeid == 2).Select(s => s.MGR).First();
                    List1.zdod = opa.UHSACCTSDbs.Where(s => s.IDc == id1 && s.typeid == 2).Select(s => s.DOD).First();
                    List1.zdis = opa.UHSACCTSDbs.Where(s => s.IDc == id1 && s.typeid == 2).Select(s => s.DIST).First();

                    List1.dtDue1 = dtDu01;
                    List1.dtDue2 = Data1.Select(s => s.modStr1).First();
                    List1.dtDue3 = Data1.Select(s => s.modStr2).First();
                    List1.dtDue4 = Data1.Select(s => s.modStr3).First();
                    //List1.dtDue5 = dtDue05;

                    pageModel.Add(List1);

                    ViewBag.dayID = a11;
                    ViewBag.wID = a12;
                    ViewBag.mID = a13;
                    ViewBag.qID = a14;

                    return View("getEditPar10100076", pageModel);
                }
                else if (id2 == 2)
                {

                    List<UHSOMD11vDb> UHSOMD11vDbA = opb.UHSOMD11vDbs.Where(s => s.ID == id3).ToList();
                    var datr01 = opb.UHSOMD11vDbs.Where(s => s.ID == id3).Select(s => s.crdate).First();
                    var date01 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateID == datr01).Select(s => s.dateus).First();
                    var week01 = opb.UHSOMD11vDbs.Where(s => s.ID == id3).Select(s => s.weeknr).First();
                    var mnth01 = opb.UHSOMD11vDbs.Where(s => s.ID == id3).Select(s => s.yyyymm).First();
                    var mnth02 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateID == datr01).Select(s => s.YYYYMM).First();
                    var qotr01 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateID == datr01).Select(s => s.Quarter).First();
                    var year01 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateID == datr01).Select(s => s.YYYY).First();

                    if (datr01 == dts) { ViewBag.qday = 1; } else { ViewBag.qday = 0; }
                    if (year01 == yer1 && week01 == wek1) { ViewBag.qwek = 1; } else { ViewBag.qwek = 0; }
                    if (mnth02 == per2) { ViewBag.qper = 1; } else { ViewBag.qper = 0; }
                    if (year01 == yer1 && qotr01 == qtr1) { ViewBag.qqtr = 1; } else { ViewBag.qqtr = 0; }
                    if (year01 == yer1) { ViewBag.qyer = 1; } else { ViewBag.qyer = 0; }

                    var wchk1 = opa.UHSACCTSDbs.Where(s => s.IDc == id1 && s.typeid == 2).Select(s => s.wchk).First();
                    List<uhspageitemsDb> Data1 = new List<uhspageitemsDb>();
                    var dtDu01 = date01;

                    if (wchk1 == 1)
                    {
                        uhspageitemsDb lista1 = new uhspageitemsDb();
                        lista1.modStr1 = opa.DATAOPATIME_FRAMEDbs.Where(s => (s.YYYY == year01 && s.WNumber == week01 && s.daywnm == 5) || (s.YYYY == year01 && curmnt == 12)).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr2 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYYMM == mnth02 && s.daywnm != 6 && s.daywnm != 7).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr3 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == year01 && s.Quarter == qotr01 && s.daywnm != 6 && s.daywnm != 7).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr4 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == year01 && s.daywnm != 6 && s.daywnm != 7).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        Data1.Add(lista1);
                    }
                    else
                    if (wchk1 == 2)
                    {
                        uhspageitemsDb lista1 = new uhspageitemsDb();
                        lista1.modStr1 = opa.DATAOPATIME_FRAMEDbs.Where(s => (s.YYYY == year01 && s.WNumber == week01 && s.daywnm == 6) || (s.YYYY == year01 && curmnt == 12)).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr2 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYYMM == mnth02 && s.daywnm != 7).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr3 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == year01 && s.Quarter == qotr01 && s.daywnm != 7).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr4 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == year01 && s.daywnm != 7).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        Data1.Add(lista1);
                    }
                    else
                    if (wchk1 == 3)
                    {
                        uhspageitemsDb lista1 = new uhspageitemsDb();
                        lista1.modStr1 = opa.DATAOPATIME_FRAMEDbs.Where(s => (s.YYYY == year01 && s.WNumber == week01 && s.daywnm == 7) || (s.YYYY == year01 && curmnt == 12)).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr2 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYYMM == mnth02).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr3 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == year01 && s.Quarter == qotr01).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        lista1.modStr4 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.YYYY == year01).OrderByDescending(s => s.dateID).Select(s => s.dateus).First();
                        Data1.Add(lista1);
                    }

                    var itemq = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateID == datr01).Select(s => s.Quarter).First();
                    var itemz = from s in opa.DATAOPATIME_FRAMEDbs where s.YYYY == year01 && s.Quarter == itemq select s.dateID;
                    List<string> qutr01 = itemz.ToList();

                    //var a11 = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010006 && s.tspdid == 1 && s.acctid == id1 && s.crdate == date01).Select(s => s.ID).First();
                    List<UHSOMD11Db> UHSOMD11Db = opa.UHSOMD11Dbs.Where(s => s.ID == id3).ToList();

                    dyPar.modInt01 = opb.UHSOMD11vDbs.Where(s => s.ID == id3).Select(s => s.yyyymmdd).First();
                    dyPar.modInt02 = opb.UHSOMD11vDbs.Where(s => s.ID == id3).Select(s => s.weeknr).First();
                    dyPar.modInt03 = opb.UHSOMD11vDbs.Where(s => s.ID == id3).Select(s => s.yyyymm).First();
                    dyPar.modInt04 = opb.UHSOMD11vDbs.Where(s => s.ID == id3).Select(s => s.distid).First();
                    dyPar.modInt05 = opb.UHSOMD11vDbs.Where(s => s.ID == id3).Select(s => s.acctid).First();
                    dyPar.modInt06 = opb.UHSOMD11vDbs.Where(s => s.ID == id3).Select(s => s.dcgrid).First();
                    dyPar.modInt07 = opb.UHSOMD11vDbs.Where(s => s.ID == id3).Select(s => s.dctpid).First();
                    dyPar.modStr1 = id3;
                    constrID.Add(dyPar);

                    List<UHSOMD11vDb> UHSOMD11vDbB = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 2 && s.acctid == id1 && s.yyyy == year01 && s.weeknr == week01).ToList();
                    var a12 = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 2 && s.acctid == id1 && s.yyyy == year01 && s.weeknr == week01).Select(s => s.ID).First();
                    List<UHSOMD12Db> UHSOMD12Db = opa.UHSOMD12Dbs.Where(s => s.ID == a12).ToList();

                    wkPar.modInt01 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.yyyymmdd).First();
                    wkPar.modInt02 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.weeknr).First();
                    wkPar.modInt03 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.yyyymm).First();
                    wkPar.modInt04 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.distid).First();
                    wkPar.modInt05 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.acctid).First();
                    wkPar.modInt06 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.dcgrid).First();
                    wkPar.modInt07 = opb.UHSOMD11vDbs.Where(s => s.ID == a12).Select(s => s.dctpid).First();
                    wkPar.modStr1 = a12;
                    constrID.Add(wkPar);

                    List<UHSOMD11vDb> UHSOMD11vDbC = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 3 && s.acctid == id1 && s.yyyymm == mnth02).ToList();
                    var a13 = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 3 && s.acctid == id1 && s.yyyymm == mnth02).Select(s => s.ID).First();
                    List<UHSOMD13Db> UHSOMD13Db = opa.UHSOMD13Dbs.Where(s => s.ID == a13).ToList();

                    mnPar.modInt01 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.yyyymmdd).First();
                    mnPar.modInt02 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.weeknr).First();
                    mnPar.modInt03 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.yyyymm).First();
                    mnPar.modInt04 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.distid).First();
                    mnPar.modInt05 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.acctid).First();
                    mnPar.modInt06 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.dcgrid).First();
                    mnPar.modInt07 = opb.UHSOMD11vDbs.Where(s => s.ID == a13).Select(s => s.dctpid).First();
                    mnPar.modStr1 = a13;
                    constrID.Add(mnPar);

                    List<UHSOMD11vDb> UHSOMD11vDbD = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 4 && s.acctid == id1 && qutr01.Contains(s.crdate)).ToList();
                    var a14 = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 4 && s.acctid == id1 && qutr01.Contains(s.crdate)).Select(s => s.ID).First();
                    List<UHSOMD14Db> UHSOMD14Db = opa.UHSOMD14Dbs.Where(s => s.ID == a14).ToList();

                    qtPar.modInt01 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.yyyymmdd).First();
                    qtPar.modInt02 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.weeknr).First();
                    qtPar.modInt03 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.yyyymm).First();
                    qtPar.modInt04 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.distid).First();
                    qtPar.modInt05 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.acctid).First();
                    qtPar.modInt06 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.dcgrid).First();
                    qtPar.modInt07 = opb.UHSOMD11vDbs.Where(s => s.ID == a14).Select(s => s.dctpid).First();
                    qtPar.modStr1 = a14;
                    constrID.Add(qtPar);

                    //List<UHSOMD11vDb> UHSOMD11vDbE = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 5 && s.acctid == id1 && s.yyyy == year01).ToList();
                    //var a15 = opb.UHSOMD11vDbs.Where(s => s.dctpid == 1010007 && s.tspdid == 5 && s.acctid == id1 && s.yyyy == year01).Select(s => s.ID).First();
                    //ViewBag.yerID = a15;
                    //List<UHSOMD15Db> UHSOMD15Db = opa.UHSOMD15Dbs.Where(s => s.ID == a15).ToList();

                    ViewBag.constrID = constrID;
                    ViewBag.projList = opb.UHSWOT01vDbs.Where(s => (s.docmid == id3
                                                                 || s.docmid == a12
                                                                 || s.docmid == a13
                                                                 || s.docmid == a14) && (userTypeid == 2 || s.crusid == userid)).ToList();

                    var id111 = UHSOMD11Db.Select(s => s.smid111).First();
                    var id112 = UHSOMD11Db.Select(s => s.smid112).First();
                    var id113 = UHSOMD11Db.Select(s => s.smid113).First();
                    var id114 = UHSOMD11Db.Select(s => s.smid114).First();
                    var id115 = UHSOMD11Db.Select(s => s.smid115).First();
                    var id116 = UHSOMD11Db.Select(s => s.smid116).First();
                    var id117 = UHSOMD11Db.Select(s => s.smid117).First();
                    var id118 = UHSOMD11Db.Select(s => s.smid118).First();
                    var id119 = UHSOMD11Db.Select(s => s.smid119).First();
                    var id120 = UHSOMD11Db.Select(s => s.smid120).First();
                    var id121 = UHSOMD11Db.Select(s => s.smid121).First();
                    var id122 = UHSOMD11Db.Select(s => s.smid122).First();
                    var id123 = UHSOMD11Db.Select(s => s.smid123).First();
                    var id124 = UHSOMD11Db.Select(s => s.smid124).First();
                    var id125 = UHSOMD11Db.Select(s => s.smid125).First();

                    var id211 = UHSOMD12Db.Select(s => s.smid111).First();
                    var id212 = UHSOMD12Db.Select(s => s.smid112).First();
                    var id213 = UHSOMD12Db.Select(s => s.smid113).First();
                    var id214 = UHSOMD12Db.Select(s => s.smid114).First();
                    var id215 = UHSOMD12Db.Select(s => s.smid115).First();
                    var id216 = UHSOMD12Db.Select(s => s.smid116).First();
                    var id217 = UHSOMD12Db.Select(s => s.smid117).First();
                    var id218 = UHSOMD12Db.Select(s => s.smid118).First();
                    var id219 = UHSOMD12Db.Select(s => s.smid119).First();
                    var id220 = UHSOMD12Db.Select(s => s.smid120).First();
                    var id221 = UHSOMD12Db.Select(s => s.smid121).First();
                    var id222 = UHSOMD12Db.Select(s => s.smid122).First();
                    var id223 = UHSOMD12Db.Select(s => s.smid123).First();
                    var id224 = UHSOMD12Db.Select(s => s.smid124).First();
                    var id225 = UHSOMD12Db.Select(s => s.smid125).First();

                    var id311 = UHSOMD13Db.Select(s => s.smid111).First();
                    var id312 = UHSOMD13Db.Select(s => s.smid112).First();
                    var id313 = UHSOMD13Db.Select(s => s.smid113).First();
                    var id314 = UHSOMD13Db.Select(s => s.smid114).First();
                    var id315 = UHSOMD13Db.Select(s => s.smid115).First();
                    var id316 = UHSOMD13Db.Select(s => s.smid116).First();
                    var id317 = UHSOMD13Db.Select(s => s.smid117).First();
                    var id318 = UHSOMD13Db.Select(s => s.smid118).First();
                    var id319 = UHSOMD13Db.Select(s => s.smid119).First();
                    var id320 = UHSOMD13Db.Select(s => s.smid120).First();
                    var id321 = UHSOMD13Db.Select(s => s.smid121).First();
                    var id322 = UHSOMD13Db.Select(s => s.smid122).First();
                    var id323 = UHSOMD13Db.Select(s => s.smid123).First();
                    var id324 = UHSOMD13Db.Select(s => s.smid124).First();
                    var id325 = UHSOMD13Db.Select(s => s.smid125).First();

                    var id411 = UHSOMD14Db.Select(s => s.smid111).First();
                    var id412 = UHSOMD14Db.Select(s => s.smid112).First();
                    var id413 = UHSOMD14Db.Select(s => s.smid113).First();
                    var id414 = UHSOMD14Db.Select(s => s.smid114).First();
                    var id415 = UHSOMD14Db.Select(s => s.smid115).First();
                    var id416 = UHSOMD14Db.Select(s => s.smid116).First();
                    var id417 = UHSOMD14Db.Select(s => s.smid117).First();
                    var id418 = UHSOMD14Db.Select(s => s.smid118).First();
                    var id419 = UHSOMD14Db.Select(s => s.smid119).First();
                    var id420 = UHSOMD14Db.Select(s => s.smid120).First();
                    var id421 = UHSOMD14Db.Select(s => s.smid121).First();
                    var id422 = UHSOMD14Db.Select(s => s.smid122).First();
                    var id423 = UHSOMD14Db.Select(s => s.smid123).First();
                    var id424 = UHSOMD14Db.Select(s => s.smid124).First();
                    var id425 = UHSOMD14Db.Select(s => s.smid125).First();

                    //var id511 = UHSOMD15Db.Select(s => s.smid111).First();
                    //var id512 = UHSOMD15Db.Select(s => s.smid112).First();
                    //var id513 = UHSOMD15Db.Select(s => s.smid113).First();
                    //var id514 = UHSOMD15Db.Select(s => s.smid114).First();
                    //var id515 = UHSOMD15Db.Select(s => s.smid115).First();
                    //var id516 = UHSOMD15Db.Select(s => s.smid116).First();
                    //var id517 = UHSOMD15Db.Select(s => s.smid117).First();
                    //var id518 = UHSOMD15Db.Select(s => s.smid118).First();
                    //var id519 = UHSOMD15Db.Select(s => s.smid119).First();
                    //var id520 = UHSOMD15Db.Select(s => s.smid120).First();
                    //var id521 = UHSOMD15Db.Select(s => s.smid121).First();
                    //var id522 = UHSOMD15Db.Select(s => s.smid122).First();
                    //var id523 = UHSOMD15Db.Select(s => s.smid123).First();
                    //var id524 = UHSOMD15Db.Select(s => s.smid124).First();
                    //var id525 = UHSOMD15Db.Select(s => s.smid125).First();

                    List<uhsA360pagemodelDb> pageModel = new List<uhsA360pagemodelDb>();
                    uhsA360pagemodelDb List1 = new uhsA360pagemodelDb();

                    List1.AYID = UHSOMD11vDbA.Select(s => s.ID).First();
                    List1.AYprojid = UHSOMD11vDbA.Select(s => s.projid).First();
                    List1.AYtskoid = UHSOMD11vDbA.Select(s => s.tskoid).First();
                    List1.AYdcgrid = UHSOMD11vDbA.Select(s => s.dcgrid).First();
                    List1.AYdctpid = UHSOMD11vDbA.Select(s => s.dctpid).First();
                    List1.AYtspdid = UHSOMD11vDbA.Select(s => s.tspdid).First();
                    List1.AYdistid = UHSOMD11vDbA.Select(s => s.distid).First();
                    List1.AYdistnm = UHSOMD11vDbA.Select(s => s.distnm).First();
                    List1.AYacctid = UHSOMD11vDbA.Select(s => s.acctid).First();
                    List1.AYuserid = UHSOMD11vDbA.Select(s => s.userid).First();
                    List1.AYusernm = UHSOMD11vDbA.Select(s => s.usernm).First();
                    List1.AYdimgid = UHSOMD11vDbA.Select(s => s.dimgid).First();
                    List1.AYdimgnm = UHSOMD11vDbA.Select(s => s.dimgnm).First();
                    List1.AYsmid111 = UHSOMD11vDbA.Select(s => s.smid111).First();
                    List1.AYcmdt111 = UHSOMD11vDbA.Select(s => s.cmdt111).First();
                    List1.AYverf111 = UHSOMD11vDbA.Select(s => s.verf111).First();
                    List1.AYsmid112 = UHSOMD11vDbA.Select(s => s.smid112).First();
                    List1.AYcmdt112 = UHSOMD11vDbA.Select(s => s.cmdt112).First();
                    List1.AYverf112 = UHSOMD11vDbA.Select(s => s.verf112).First();
                    List1.AYsmid113 = UHSOMD11vDbA.Select(s => s.smid113).First();
                    List1.AYcmdt113 = UHSOMD11vDbA.Select(s => s.cmdt113).First();
                    List1.AYverf113 = UHSOMD11vDbA.Select(s => s.verf113).First();
                    List1.AYsmid114 = UHSOMD11vDbA.Select(s => s.smid114).First();
                    List1.AYcmdt114 = UHSOMD11vDbA.Select(s => s.cmdt114).First();
                    List1.AYverf114 = UHSOMD11vDbA.Select(s => s.verf114).First();
                    List1.AYsmid115 = UHSOMD11vDbA.Select(s => s.smid115).First();
                    List1.AYcmdt115 = UHSOMD11vDbA.Select(s => s.cmdt115).First();
                    List1.AYverf115 = UHSOMD11vDbA.Select(s => s.verf115).First();
                    List1.AYsmid116 = UHSOMD11vDbA.Select(s => s.smid116).First();
                    List1.AYcmdt116 = UHSOMD11vDbA.Select(s => s.cmdt116).First();
                    List1.AYverf116 = UHSOMD11vDbA.Select(s => s.verf116).First();
                    List1.AYsmid117 = UHSOMD11vDbA.Select(s => s.smid117).First();
                    List1.AYcmdt117 = UHSOMD11vDbA.Select(s => s.cmdt117).First();
                    List1.AYverf117 = UHSOMD11vDbA.Select(s => s.verf117).First();
                    List1.AYsmid118 = UHSOMD11vDbA.Select(s => s.smid118).First();
                    List1.AYcmdt118 = UHSOMD11vDbA.Select(s => s.cmdt118).First();
                    List1.AYverf118 = UHSOMD11vDbA.Select(s => s.verf118).First();
                    List1.AYsmid119 = UHSOMD11vDbA.Select(s => s.smid119).First();
                    List1.AYcmdt119 = UHSOMD11vDbA.Select(s => s.cmdt119).First();
                    List1.AYverf119 = UHSOMD11vDbA.Select(s => s.verf119).First();
                    List1.AYsmid120 = UHSOMD11vDbA.Select(s => s.smid120).First();
                    List1.AYcmdt120 = UHSOMD11vDbA.Select(s => s.cmdt120).First();
                    List1.AYverf120 = UHSOMD11vDbA.Select(s => s.verf120).First();
                    List1.AYsmid121 = UHSOMD11vDbA.Select(s => s.smid121).First();
                    List1.AYcmdt121 = UHSOMD11vDbA.Select(s => s.cmdt121).First();
                    List1.AYverf121 = UHSOMD11vDbA.Select(s => s.verf121).First();
                    List1.AYsmid122 = UHSOMD11vDbA.Select(s => s.smid122).First();
                    List1.AYcmdt122 = UHSOMD11vDbA.Select(s => s.cmdt122).First();
                    List1.AYverf122 = UHSOMD11vDbA.Select(s => s.verf122).First();
                    List1.AYsmid123 = UHSOMD11vDbA.Select(s => s.smid123).First();
                    List1.AYcmdt123 = UHSOMD11vDbA.Select(s => s.cmdt123).First();
                    List1.AYverf123 = UHSOMD11vDbA.Select(s => s.verf123).First();
                    List1.AYsmid124 = UHSOMD11vDbA.Select(s => s.smid124).First();
                    List1.AYcmdt124 = UHSOMD11vDbA.Select(s => s.cmdt124).First();
                    List1.AYverf124 = UHSOMD11vDbA.Select(s => s.verf124).First();
                    List1.AYsmid125 = UHSOMD11vDbA.Select(s => s.smid125).First();
                    List1.AYcmdt125 = UHSOMD11vDbA.Select(s => s.cmdt125).First();
                    List1.AYverf125 = UHSOMD11vDbA.Select(s => s.verf125).First();
                    List1.AYnote01 = UHSOMD11vDbA.Select(s => s.note01).First();
                    List1.AYnote02 = UHSOMD11vDbA.Select(s => s.note02).First();
                    List1.AYnote03 = UHSOMD11vDbA.Select(s => s.note03).First();
                    List1.AYnote04 = UHSOMD11vDbA.Select(s => s.note04).First();
                    List1.AYnote05 = UHSOMD11vDbA.Select(s => s.note05).First();
                    List1.AYnote06 = UHSOMD11vDbA.Select(s => s.note06).First();
                    List1.AYnote07 = UHSOMD11vDbA.Select(s => s.note07).First();
                    List1.AYnote08 = UHSOMD11vDbA.Select(s => s.note08).First();
                    List1.AYnote09 = UHSOMD11vDbA.Select(s => s.note09).First();
                    List1.AYnote10 = UHSOMD11vDbA.Select(s => s.note10).First();
                    List1.AYnote11 = UHSOMD11vDbA.Select(s => s.note11).First();
                    List1.AYnote12 = UHSOMD11vDbA.Select(s => s.note12).First();
                    List1.AYnote13 = UHSOMD11vDbA.Select(s => s.note13).First();
                    List1.AYnote14 = UHSOMD11vDbA.Select(s => s.note14).First();
                    List1.AYnote15 = UHSOMD11vDbA.Select(s => s.note15).First();
                    List1.AYtask01 = UHSOMD11vDbA.Select(s => s.task01).First();
                    List1.AYtask02 = UHSOMD11vDbA.Select(s => s.task02).First();
                    List1.AYtask03 = UHSOMD11vDbA.Select(s => s.task03).First();
                    List1.AYtask04 = UHSOMD11vDbA.Select(s => s.task04).First();
                    List1.AYtask05 = UHSOMD11vDbA.Select(s => s.task05).First();
                    List1.AYacit01 = UHSOMD11vDbA.Select(s => s.acit01).First();
                    List1.AYacit02 = UHSOMD11vDbA.Select(s => s.acit02).First();
                    List1.AYacit03 = UHSOMD11vDbA.Select(s => s.acit03).First();
                    List1.AYacit04 = UHSOMD11vDbA.Select(s => s.acit04).First();
                    List1.AYacit05 = UHSOMD11vDbA.Select(s => s.acit05).First();
                    List1.AYtool01 = UHSOMD11vDbA.Select(s => s.tool01).First();
                    List1.AYtool02 = UHSOMD11vDbA.Select(s => s.tool02).First();
                    List1.AYtool03 = UHSOMD11vDbA.Select(s => s.tool03).First();
                    List1.AYtool04 = UHSOMD11vDbA.Select(s => s.tool04).First();
                    List1.AYtool05 = UHSOMD11vDbA.Select(s => s.tool05).First();
                    List1.AYdocn01 = UHSOMD11vDbA.Select(s => s.docn01).First();
                    List1.AYdocn02 = UHSOMD11vDbA.Select(s => s.docn02).First();
                    List1.AYdocn03 = UHSOMD11vDbA.Select(s => s.docn03).First();
                    List1.AYdocn04 = UHSOMD11vDbA.Select(s => s.docn04).First();
                    List1.AYdocn05 = UHSOMD11vDbA.Select(s => s.docn05).First();
                    List1.AYprfx01 = UHSOMD11vDbA.Select(s => s.prfx01).First();
                    List1.AYprfx02 = UHSOMD11vDbA.Select(s => s.prfx02).First();
                    List1.AYprfx03 = UHSOMD11vDbA.Select(s => s.prfx03).First();
                    List1.AYprfx04 = UHSOMD11vDbA.Select(s => s.prfx04).First();
                    List1.AYprfx05 = UHSOMD11vDbA.Select(s => s.prfx05).First();
                    List1.AYrate01 = UHSOMD11vDbA.Select(s => s.rate01).First();
                    List1.AYrate02 = UHSOMD11vDbA.Select(s => s.rate02).First();
                    List1.AYrate03 = UHSOMD11vDbA.Select(s => s.rate03).First();
                    List1.AYrate04 = UHSOMD11vDbA.Select(s => s.rate04).First();
                    List1.AYrate05 = UHSOMD11vDbA.Select(s => s.rate05).First();
                    List1.AYpref01 = UHSOMD11vDbA.Select(s => s.pref01).First();
                    List1.AYpref02 = UHSOMD11vDbA.Select(s => s.pref02).First();
                    List1.AYpref03 = UHSOMD11vDbA.Select(s => s.pref03).First();
                    List1.AYpref04 = UHSOMD11vDbA.Select(s => s.pref04).First();
                    List1.AYpref05 = UHSOMD11vDbA.Select(s => s.pref05).First();
                    List1.AYratd01 = UHSOMD11vDbA.Select(s => s.ratd01).First();
                    List1.AYratd02 = UHSOMD11vDbA.Select(s => s.ratd02).First();
                    List1.AYratd03 = UHSOMD11vDbA.Select(s => s.ratd03).First();
                    List1.AYratd04 = UHSOMD11vDbA.Select(s => s.ratd04).First();
                    List1.AYratd05 = UHSOMD11vDbA.Select(s => s.ratd05).First();
                    List1.AYallch1c = UHSOMD11vDbA.Select(s => s.allch1c).First();
                    List1.AYwekday = UHSOMD11vDbA.Select(s => s.wekday).First();
                    List1.AYwekdnm = UHSOMD11vDbA.Select(s => s.wekdnm).First();
                    List1.AYchck = UHSOMD11vDbA.Select(s => s.chck).First();
                    List1.AYchckid = UHSOMD11vDbA.Select(s => s.chckid).First();
                    List1.AYchcknm = UHSOMD11vDbA.Select(s => s.chcknm).First();
                    List1.AYchckdt = UHSOMD11vDbA.Select(s => s.chckdt).First();
                    List1.AYyyyy = UHSOMD11vDbA.Select(s => s.yyyy).First();
                    List1.AYyyyymm = UHSOMD11vDbA.Select(s => s.yyyymm).First();
                    List1.AYweeknr = UHSOMD11vDbA.Select(s => s.weeknr).First();
                    List1.AYweekds = UHSOMD11vDbA.Select(s => s.weekds).First();
                    List1.AYyyyymmdd = UHSOMD11vDbA.Select(s => s.yyyymmdd).First();
                    List1.AYhhmmss = UHSOMD11vDbA.Select(s => s.hhmmss).First();
                    List1.AYcrdt = UHSOMD11vDbA.Select(s => s.crdt).First();
                    List1.AYeddt = UHSOMD11vDbA.Select(s => s.eddt).First();
                    List1.AYcrusid = UHSOMD11vDbA.Select(s => s.crusid).First();
                    List1.AYedusid = UHSOMD11vDbA.Select(s => s.edusid).First();
                    List1.AYcrusnm = UHSOMD11vDbA.Select(s => s.crusnm).First();
                    List1.AYedusnm = UHSOMD11vDbA.Select(s => s.edusnm).First();
                    List1.AYcrdate = UHSOMD11vDbA.Select(s => s.crdate).First();
                    List1.BYID = UHSOMD11vDbB.Select(s => s.ID).First();
                    List1.BYprojid = UHSOMD11vDbB.Select(s => s.projid).First();
                    List1.BYtskoid = UHSOMD11vDbB.Select(s => s.tskoid).First();
                    List1.BYdcgrid = UHSOMD11vDbB.Select(s => s.dcgrid).First();
                    List1.BYdctpid = UHSOMD11vDbB.Select(s => s.dctpid).First();
                    List1.BYtspdid = UHSOMD11vDbB.Select(s => s.tspdid).First();
                    List1.BYdistid = UHSOMD11vDbB.Select(s => s.distid).First();
                    List1.BYdistnm = UHSOMD11vDbB.Select(s => s.distnm).First();
                    List1.BYacctid = UHSOMD11vDbB.Select(s => s.acctid).First();
                    List1.BYuserid = UHSOMD11vDbB.Select(s => s.userid).First();
                    List1.BYusernm = UHSOMD11vDbB.Select(s => s.usernm).First();
                    List1.BYdimgid = UHSOMD11vDbB.Select(s => s.dimgid).First();
                    List1.BYdimgnm = UHSOMD11vDbB.Select(s => s.dimgnm).First();
                    List1.BYsmid111 = UHSOMD11vDbB.Select(s => s.smid111).First();
                    List1.BYcmdt111 = UHSOMD11vDbB.Select(s => s.cmdt111).First();
                    List1.BYverf111 = UHSOMD11vDbB.Select(s => s.verf111).First();
                    List1.BYsmid112 = UHSOMD11vDbB.Select(s => s.smid112).First();
                    List1.BYcmdt112 = UHSOMD11vDbB.Select(s => s.cmdt112).First();
                    List1.BYverf112 = UHSOMD11vDbB.Select(s => s.verf112).First();
                    List1.BYsmid113 = UHSOMD11vDbB.Select(s => s.smid113).First();
                    List1.BYcmdt113 = UHSOMD11vDbB.Select(s => s.cmdt113).First();
                    List1.BYverf113 = UHSOMD11vDbB.Select(s => s.verf113).First();
                    List1.BYsmid114 = UHSOMD11vDbB.Select(s => s.smid114).First();
                    List1.BYcmdt114 = UHSOMD11vDbB.Select(s => s.cmdt114).First();
                    List1.BYverf114 = UHSOMD11vDbB.Select(s => s.verf114).First();
                    List1.BYsmid115 = UHSOMD11vDbB.Select(s => s.smid115).First();
                    List1.BYcmdt115 = UHSOMD11vDbB.Select(s => s.cmdt115).First();
                    List1.BYverf115 = UHSOMD11vDbB.Select(s => s.verf115).First();
                    List1.BYsmid116 = UHSOMD11vDbB.Select(s => s.smid116).First();
                    List1.BYcmdt116 = UHSOMD11vDbB.Select(s => s.cmdt116).First();
                    List1.BYverf116 = UHSOMD11vDbB.Select(s => s.verf116).First();
                    List1.BYsmid117 = UHSOMD11vDbB.Select(s => s.smid117).First();
                    List1.BYcmdt117 = UHSOMD11vDbB.Select(s => s.cmdt117).First();
                    List1.BYverf117 = UHSOMD11vDbB.Select(s => s.verf117).First();
                    List1.BYsmid118 = UHSOMD11vDbB.Select(s => s.smid118).First();
                    List1.BYcmdt118 = UHSOMD11vDbB.Select(s => s.cmdt118).First();
                    List1.BYverf118 = UHSOMD11vDbB.Select(s => s.verf118).First();
                    List1.BYsmid119 = UHSOMD11vDbB.Select(s => s.smid119).First();
                    List1.BYcmdt119 = UHSOMD11vDbB.Select(s => s.cmdt119).First();
                    List1.BYverf119 = UHSOMD11vDbB.Select(s => s.verf119).First();
                    List1.BYsmid120 = UHSOMD11vDbB.Select(s => s.smid120).First();
                    List1.BYcmdt120 = UHSOMD11vDbB.Select(s => s.cmdt120).First();
                    List1.BYverf120 = UHSOMD11vDbB.Select(s => s.verf120).First();
                    List1.BYsmid121 = UHSOMD11vDbB.Select(s => s.smid121).First();
                    List1.BYcmdt121 = UHSOMD11vDbB.Select(s => s.cmdt121).First();
                    List1.BYverf121 = UHSOMD11vDbB.Select(s => s.verf121).First();
                    List1.BYsmid122 = UHSOMD11vDbB.Select(s => s.smid122).First();
                    List1.BYcmdt122 = UHSOMD11vDbB.Select(s => s.cmdt122).First();
                    List1.BYverf122 = UHSOMD11vDbB.Select(s => s.verf122).First();
                    List1.BYsmid123 = UHSOMD11vDbB.Select(s => s.smid123).First();
                    List1.BYcmdt123 = UHSOMD11vDbB.Select(s => s.cmdt123).First();
                    List1.BYverf123 = UHSOMD11vDbB.Select(s => s.verf123).First();
                    List1.BYsmid124 = UHSOMD11vDbB.Select(s => s.smid124).First();
                    List1.BYcmdt124 = UHSOMD11vDbB.Select(s => s.cmdt124).First();
                    List1.BYverf124 = UHSOMD11vDbB.Select(s => s.verf124).First();
                    List1.BYsmid125 = UHSOMD11vDbB.Select(s => s.smid125).First();
                    List1.BYcmdt125 = UHSOMD11vDbB.Select(s => s.cmdt125).First();
                    List1.BYverf125 = UHSOMD11vDbB.Select(s => s.verf125).First();
                    List1.BYnote01 = UHSOMD11vDbB.Select(s => s.note01).First();
                    List1.BYnote02 = UHSOMD11vDbB.Select(s => s.note02).First();
                    List1.BYnote03 = UHSOMD11vDbB.Select(s => s.note03).First();
                    List1.BYnote04 = UHSOMD11vDbB.Select(s => s.note04).First();
                    List1.BYnote05 = UHSOMD11vDbB.Select(s => s.note05).First();
                    List1.BYnote06 = UHSOMD11vDbB.Select(s => s.note06).First();
                    List1.BYnote07 = UHSOMD11vDbB.Select(s => s.note07).First();
                    List1.BYnote08 = UHSOMD11vDbB.Select(s => s.note08).First();
                    List1.BYnote09 = UHSOMD11vDbB.Select(s => s.note09).First();
                    List1.BYnote10 = UHSOMD11vDbB.Select(s => s.note10).First();
                    List1.BYnote11 = UHSOMD11vDbB.Select(s => s.note11).First();
                    List1.BYnote12 = UHSOMD11vDbB.Select(s => s.note12).First();
                    List1.BYnote13 = UHSOMD11vDbB.Select(s => s.note13).First();
                    List1.BYnote14 = UHSOMD11vDbB.Select(s => s.note14).First();
                    List1.BYnote15 = UHSOMD11vDbB.Select(s => s.note15).First();
                    List1.BYtask01 = UHSOMD11vDbB.Select(s => s.task01).First();
                    List1.BYtask02 = UHSOMD11vDbB.Select(s => s.task02).First();
                    List1.BYtask03 = UHSOMD11vDbB.Select(s => s.task03).First();
                    List1.BYtask04 = UHSOMD11vDbB.Select(s => s.task04).First();
                    List1.BYtask05 = UHSOMD11vDbB.Select(s => s.task05).First();
                    List1.BYacit01 = UHSOMD11vDbB.Select(s => s.acit01).First();
                    List1.BYacit02 = UHSOMD11vDbB.Select(s => s.acit02).First();
                    List1.BYacit03 = UHSOMD11vDbB.Select(s => s.acit03).First();
                    List1.BYacit04 = UHSOMD11vDbB.Select(s => s.acit04).First();
                    List1.BYacit05 = UHSOMD11vDbB.Select(s => s.acit05).First();
                    List1.BYtool01 = UHSOMD11vDbB.Select(s => s.tool01).First();
                    List1.BYtool02 = UHSOMD11vDbB.Select(s => s.tool02).First();
                    List1.BYtool03 = UHSOMD11vDbB.Select(s => s.tool03).First();
                    List1.BYtool04 = UHSOMD11vDbB.Select(s => s.tool04).First();
                    List1.BYtool05 = UHSOMD11vDbB.Select(s => s.tool05).First();
                    List1.BYdocn01 = UHSOMD11vDbB.Select(s => s.docn01).First();
                    List1.BYdocn02 = UHSOMD11vDbB.Select(s => s.docn02).First();
                    List1.BYdocn03 = UHSOMD11vDbB.Select(s => s.docn03).First();
                    List1.BYdocn04 = UHSOMD11vDbB.Select(s => s.docn04).First();
                    List1.BYdocn05 = UHSOMD11vDbB.Select(s => s.docn05).First();
                    List1.BYprfx01 = UHSOMD11vDbB.Select(s => s.prfx01).First();
                    List1.BYprfx02 = UHSOMD11vDbB.Select(s => s.prfx02).First();
                    List1.BYprfx03 = UHSOMD11vDbB.Select(s => s.prfx03).First();
                    List1.BYprfx04 = UHSOMD11vDbB.Select(s => s.prfx04).First();
                    List1.BYprfx05 = UHSOMD11vDbB.Select(s => s.prfx05).First();
                    List1.BYrate01 = UHSOMD11vDbB.Select(s => s.rate01).First();
                    List1.BYrate02 = UHSOMD11vDbB.Select(s => s.rate02).First();
                    List1.BYrate03 = UHSOMD11vDbB.Select(s => s.rate03).First();
                    List1.BYrate04 = UHSOMD11vDbB.Select(s => s.rate04).First();
                    List1.BYrate05 = UHSOMD11vDbB.Select(s => s.rate05).First();
                    List1.BYpref01 = UHSOMD11vDbB.Select(s => s.pref01).First();
                    List1.BYpref02 = UHSOMD11vDbB.Select(s => s.pref02).First();
                    List1.BYpref03 = UHSOMD11vDbB.Select(s => s.pref03).First();
                    List1.BYpref04 = UHSOMD11vDbB.Select(s => s.pref04).First();
                    List1.BYpref05 = UHSOMD11vDbB.Select(s => s.pref05).First();
                    List1.BYratd01 = UHSOMD11vDbB.Select(s => s.ratd01).First();
                    List1.BYratd02 = UHSOMD11vDbB.Select(s => s.ratd02).First();
                    List1.BYratd03 = UHSOMD11vDbB.Select(s => s.ratd03).First();
                    List1.BYratd04 = UHSOMD11vDbB.Select(s => s.ratd04).First();
                    List1.BYratd05 = UHSOMD11vDbB.Select(s => s.ratd05).First();
                    List1.BYallch1c = UHSOMD11vDbB.Select(s => s.allch1c).First();
                    List1.BYwekday = UHSOMD11vDbB.Select(s => s.wekday).First();
                    List1.BYwekdnm = UHSOMD11vDbB.Select(s => s.wekdnm).First();
                    List1.BYchck = UHSOMD11vDbB.Select(s => s.chck).First();
                    List1.BYchckid = UHSOMD11vDbB.Select(s => s.chckid).First();
                    List1.BYchcknm = UHSOMD11vDbB.Select(s => s.chcknm).First();
                    List1.BYchckdt = UHSOMD11vDbB.Select(s => s.chckdt).First();
                    List1.BYyyyy = UHSOMD11vDbB.Select(s => s.yyyy).First();
                    List1.BYyyyymm = UHSOMD11vDbB.Select(s => s.yyyymm).First();
                    List1.BYweeknr = UHSOMD11vDbB.Select(s => s.weeknr).First();
                    List1.BYweekds = UHSOMD11vDbB.Select(s => s.weekds).First();
                    List1.BYyyyymmdd = UHSOMD11vDbB.Select(s => s.yyyymmdd).First();
                    List1.BYhhmmss = UHSOMD11vDbB.Select(s => s.hhmmss).First();
                    List1.BYcrdt = UHSOMD11vDbB.Select(s => s.crdt).First();
                    List1.BYeddt = UHSOMD11vDbB.Select(s => s.eddt).First();
                    List1.BYcrusid = UHSOMD11vDbB.Select(s => s.crusid).First();
                    List1.BYedusid = UHSOMD11vDbB.Select(s => s.edusid).First();
                    List1.BYcrusnm = UHSOMD11vDbB.Select(s => s.crusnm).First();
                    List1.BYedusnm = UHSOMD11vDbB.Select(s => s.edusnm).First();
                    List1.BYcrdate = UHSOMD11vDbB.Select(s => s.crdate).First();
                    List1.CYID = UHSOMD11vDbC.Select(s => s.ID).First();
                    List1.CYprojid = UHSOMD11vDbC.Select(s => s.projid).First();
                    List1.CYtskoid = UHSOMD11vDbC.Select(s => s.tskoid).First();
                    List1.CYdcgrid = UHSOMD11vDbC.Select(s => s.dcgrid).First();
                    List1.CYdctpid = UHSOMD11vDbC.Select(s => s.dctpid).First();
                    List1.CYtspdid = UHSOMD11vDbC.Select(s => s.tspdid).First();
                    List1.CYdistid = UHSOMD11vDbC.Select(s => s.distid).First();
                    List1.CYdistnm = UHSOMD11vDbC.Select(s => s.distnm).First();
                    List1.CYacctid = UHSOMD11vDbC.Select(s => s.acctid).First();
                    List1.CYuserid = UHSOMD11vDbC.Select(s => s.userid).First();
                    List1.CYusernm = UHSOMD11vDbC.Select(s => s.usernm).First();
                    List1.CYdimgid = UHSOMD11vDbC.Select(s => s.dimgid).First();
                    List1.CYdimgnm = UHSOMD11vDbC.Select(s => s.dimgnm).First();
                    List1.CYsmid111 = UHSOMD11vDbC.Select(s => s.smid111).First();
                    List1.CYcmdt111 = UHSOMD11vDbC.Select(s => s.cmdt111).First();
                    List1.CYverf111 = UHSOMD11vDbC.Select(s => s.verf111).First();
                    List1.CYsmid112 = UHSOMD11vDbC.Select(s => s.smid112).First();
                    List1.CYcmdt112 = UHSOMD11vDbC.Select(s => s.cmdt112).First();
                    List1.CYverf112 = UHSOMD11vDbC.Select(s => s.verf112).First();
                    List1.CYsmid113 = UHSOMD11vDbC.Select(s => s.smid113).First();
                    List1.CYcmdt113 = UHSOMD11vDbC.Select(s => s.cmdt113).First();
                    List1.CYverf113 = UHSOMD11vDbC.Select(s => s.verf113).First();
                    List1.CYsmid114 = UHSOMD11vDbC.Select(s => s.smid114).First();
                    List1.CYcmdt114 = UHSOMD11vDbC.Select(s => s.cmdt114).First();
                    List1.CYverf114 = UHSOMD11vDbC.Select(s => s.verf114).First();
                    List1.CYsmid115 = UHSOMD11vDbC.Select(s => s.smid115).First();
                    List1.CYcmdt115 = UHSOMD11vDbC.Select(s => s.cmdt115).First();
                    List1.CYverf115 = UHSOMD11vDbC.Select(s => s.verf115).First();
                    List1.CYsmid116 = UHSOMD11vDbC.Select(s => s.smid116).First();
                    List1.CYcmdt116 = UHSOMD11vDbC.Select(s => s.cmdt116).First();
                    List1.CYverf116 = UHSOMD11vDbC.Select(s => s.verf116).First();
                    List1.CYsmid117 = UHSOMD11vDbC.Select(s => s.smid117).First();
                    List1.CYcmdt117 = UHSOMD11vDbC.Select(s => s.cmdt117).First();
                    List1.CYverf117 = UHSOMD11vDbC.Select(s => s.verf117).First();
                    List1.CYsmid118 = UHSOMD11vDbC.Select(s => s.smid118).First();
                    List1.CYcmdt118 = UHSOMD11vDbC.Select(s => s.cmdt118).First();
                    List1.CYverf118 = UHSOMD11vDbC.Select(s => s.verf118).First();
                    List1.CYsmid119 = UHSOMD11vDbC.Select(s => s.smid119).First();
                    List1.CYcmdt119 = UHSOMD11vDbC.Select(s => s.cmdt119).First();
                    List1.CYverf119 = UHSOMD11vDbC.Select(s => s.verf119).First();
                    List1.CYsmid120 = UHSOMD11vDbC.Select(s => s.smid120).First();
                    List1.CYcmdt120 = UHSOMD11vDbC.Select(s => s.cmdt120).First();
                    List1.CYverf120 = UHSOMD11vDbC.Select(s => s.verf120).First();
                    List1.CYsmid121 = UHSOMD11vDbC.Select(s => s.smid121).First();
                    List1.CYcmdt121 = UHSOMD11vDbC.Select(s => s.cmdt121).First();
                    List1.CYverf121 = UHSOMD11vDbC.Select(s => s.verf121).First();
                    List1.CYsmid122 = UHSOMD11vDbC.Select(s => s.smid122).First();
                    List1.CYcmdt122 = UHSOMD11vDbC.Select(s => s.cmdt122).First();
                    List1.CYverf122 = UHSOMD11vDbC.Select(s => s.verf122).First();
                    List1.CYsmid123 = UHSOMD11vDbC.Select(s => s.smid123).First();
                    List1.CYcmdt123 = UHSOMD11vDbC.Select(s => s.cmdt123).First();
                    List1.CYverf123 = UHSOMD11vDbC.Select(s => s.verf123).First();
                    List1.CYsmid124 = UHSOMD11vDbC.Select(s => s.smid124).First();
                    List1.CYcmdt124 = UHSOMD11vDbC.Select(s => s.cmdt124).First();
                    List1.CYverf124 = UHSOMD11vDbC.Select(s => s.verf124).First();
                    List1.CYsmid125 = UHSOMD11vDbC.Select(s => s.smid125).First();
                    List1.CYcmdt125 = UHSOMD11vDbC.Select(s => s.cmdt125).First();
                    List1.CYverf125 = UHSOMD11vDbC.Select(s => s.verf125).First();
                    List1.CYnote01 = UHSOMD11vDbC.Select(s => s.note01).First();
                    List1.CYnote02 = UHSOMD11vDbC.Select(s => s.note02).First();
                    List1.CYnote03 = UHSOMD11vDbC.Select(s => s.note03).First();
                    List1.CYnote04 = UHSOMD11vDbC.Select(s => s.note04).First();
                    List1.CYnote05 = UHSOMD11vDbC.Select(s => s.note05).First();
                    List1.CYnote06 = UHSOMD11vDbC.Select(s => s.note06).First();
                    List1.CYnote07 = UHSOMD11vDbC.Select(s => s.note07).First();
                    List1.CYnote08 = UHSOMD11vDbC.Select(s => s.note08).First();
                    List1.CYnote09 = UHSOMD11vDbC.Select(s => s.note09).First();
                    List1.CYnote10 = UHSOMD11vDbC.Select(s => s.note10).First();
                    List1.CYnote11 = UHSOMD11vDbC.Select(s => s.note11).First();
                    List1.CYnote12 = UHSOMD11vDbC.Select(s => s.note12).First();
                    List1.CYnote13 = UHSOMD11vDbC.Select(s => s.note13).First();
                    List1.CYnote14 = UHSOMD11vDbC.Select(s => s.note14).First();
                    List1.CYnote15 = UHSOMD11vDbC.Select(s => s.note15).First();
                    List1.CYtask01 = UHSOMD11vDbC.Select(s => s.task01).First();
                    List1.CYtask02 = UHSOMD11vDbC.Select(s => s.task02).First();
                    List1.CYtask03 = UHSOMD11vDbC.Select(s => s.task03).First();
                    List1.CYtask04 = UHSOMD11vDbC.Select(s => s.task04).First();
                    List1.CYtask05 = UHSOMD11vDbC.Select(s => s.task05).First();
                    List1.CYacit01 = UHSOMD11vDbC.Select(s => s.acit01).First();
                    List1.CYacit02 = UHSOMD11vDbC.Select(s => s.acit02).First();
                    List1.CYacit03 = UHSOMD11vDbC.Select(s => s.acit03).First();
                    List1.CYacit04 = UHSOMD11vDbC.Select(s => s.acit04).First();
                    List1.CYacit05 = UHSOMD11vDbC.Select(s => s.acit05).First();
                    List1.CYtool01 = UHSOMD11vDbC.Select(s => s.tool01).First();
                    List1.CYtool02 = UHSOMD11vDbC.Select(s => s.tool02).First();
                    List1.CYtool03 = UHSOMD11vDbC.Select(s => s.tool03).First();
                    List1.CYtool04 = UHSOMD11vDbC.Select(s => s.tool04).First();
                    List1.CYtool05 = UHSOMD11vDbC.Select(s => s.tool05).First();
                    List1.CYdocn01 = UHSOMD11vDbC.Select(s => s.docn01).First();
                    List1.CYdocn02 = UHSOMD11vDbC.Select(s => s.docn02).First();
                    List1.CYdocn03 = UHSOMD11vDbC.Select(s => s.docn03).First();
                    List1.CYdocn04 = UHSOMD11vDbC.Select(s => s.docn04).First();
                    List1.CYdocn05 = UHSOMD11vDbC.Select(s => s.docn05).First();
                    List1.CYprfx01 = UHSOMD11vDbC.Select(s => s.prfx01).First();
                    List1.CYprfx02 = UHSOMD11vDbC.Select(s => s.prfx02).First();
                    List1.CYprfx03 = UHSOMD11vDbC.Select(s => s.prfx03).First();
                    List1.CYprfx04 = UHSOMD11vDbC.Select(s => s.prfx04).First();
                    List1.CYprfx05 = UHSOMD11vDbC.Select(s => s.prfx05).First();
                    List1.CYrate01 = UHSOMD11vDbC.Select(s => s.rate01).First();
                    List1.CYrate02 = UHSOMD11vDbC.Select(s => s.rate02).First();
                    List1.CYrate03 = UHSOMD11vDbC.Select(s => s.rate03).First();
                    List1.CYrate04 = UHSOMD11vDbC.Select(s => s.rate04).First();
                    List1.CYrate05 = UHSOMD11vDbC.Select(s => s.rate05).First();
                    List1.CYpref01 = UHSOMD11vDbC.Select(s => s.pref01).First();
                    List1.CYpref02 = UHSOMD11vDbC.Select(s => s.pref02).First();
                    List1.CYpref03 = UHSOMD11vDbC.Select(s => s.pref03).First();
                    List1.CYpref04 = UHSOMD11vDbC.Select(s => s.pref04).First();
                    List1.CYpref05 = UHSOMD11vDbC.Select(s => s.pref05).First();
                    List1.CYratd01 = UHSOMD11vDbC.Select(s => s.ratd01).First();
                    List1.CYratd02 = UHSOMD11vDbC.Select(s => s.ratd02).First();
                    List1.CYratd03 = UHSOMD11vDbC.Select(s => s.ratd03).First();
                    List1.CYratd04 = UHSOMD11vDbC.Select(s => s.ratd04).First();
                    List1.CYratd05 = UHSOMD11vDbC.Select(s => s.ratd05).First();
                    List1.CYallch1c = UHSOMD11vDbC.Select(s => s.allch1c).First();
                    List1.CYwekday = UHSOMD11vDbC.Select(s => s.wekday).First();
                    List1.CYwekdnm = UHSOMD11vDbC.Select(s => s.wekdnm).First();
                    List1.CYchck = UHSOMD11vDbC.Select(s => s.chck).First();
                    List1.CYchckid = UHSOMD11vDbC.Select(s => s.chckid).First();
                    List1.CYchcknm = UHSOMD11vDbC.Select(s => s.chcknm).First();
                    List1.CYchckdt = UHSOMD11vDbC.Select(s => s.chckdt).First();
                    List1.CYyyyy = UHSOMD11vDbC.Select(s => s.yyyy).First();
                    List1.CYyyyymm = UHSOMD11vDbC.Select(s => s.yyyymm).First();
                    List1.CYweeknr = UHSOMD11vDbC.Select(s => s.weeknr).First();
                    List1.CYweekds = UHSOMD11vDbC.Select(s => s.weekds).First();
                    List1.CYyyyymmdd = UHSOMD11vDbC.Select(s => s.yyyymmdd).First();
                    List1.CYhhmmss = UHSOMD11vDbC.Select(s => s.hhmmss).First();
                    List1.CYcrdt = UHSOMD11vDbC.Select(s => s.crdt).First();
                    List1.CYeddt = UHSOMD11vDbC.Select(s => s.eddt).First();
                    List1.CYcrusid = UHSOMD11vDbC.Select(s => s.crusid).First();
                    List1.CYedusid = UHSOMD11vDbC.Select(s => s.edusid).First();
                    List1.CYcrusnm = UHSOMD11vDbC.Select(s => s.crusnm).First();
                    List1.CYedusnm = UHSOMD11vDbC.Select(s => s.edusnm).First();
                    List1.CYcrdate = UHSOMD11vDbC.Select(s => s.crdate).First();
                    List1.DYID = UHSOMD11vDbD.Select(s => s.ID).First();
                    List1.DYprojid = UHSOMD11vDbD.Select(s => s.projid).First();
                    List1.DYtskoid = UHSOMD11vDbD.Select(s => s.tskoid).First();
                    List1.DYdcgrid = UHSOMD11vDbD.Select(s => s.dcgrid).First();
                    List1.DYdctpid = UHSOMD11vDbD.Select(s => s.dctpid).First();
                    List1.DYtspdid = UHSOMD11vDbD.Select(s => s.tspdid).First();
                    List1.DYdistid = UHSOMD11vDbD.Select(s => s.distid).First();
                    List1.DYdistnm = UHSOMD11vDbD.Select(s => s.distnm).First();
                    List1.DYacctid = UHSOMD11vDbD.Select(s => s.acctid).First();
                    List1.DYuserid = UHSOMD11vDbD.Select(s => s.userid).First();
                    List1.DYusernm = UHSOMD11vDbD.Select(s => s.usernm).First();
                    List1.DYdimgid = UHSOMD11vDbD.Select(s => s.dimgid).First();
                    List1.DYdimgnm = UHSOMD11vDbD.Select(s => s.dimgnm).First();
                    List1.DYsmid111 = UHSOMD11vDbD.Select(s => s.smid111).First();
                    List1.DYcmdt111 = UHSOMD11vDbD.Select(s => s.cmdt111).First();
                    List1.DYverf111 = UHSOMD11vDbD.Select(s => s.verf111).First();
                    List1.DYsmid112 = UHSOMD11vDbD.Select(s => s.smid112).First();
                    List1.DYcmdt112 = UHSOMD11vDbD.Select(s => s.cmdt112).First();
                    List1.DYverf112 = UHSOMD11vDbD.Select(s => s.verf112).First();
                    List1.DYsmid113 = UHSOMD11vDbD.Select(s => s.smid113).First();
                    List1.DYcmdt113 = UHSOMD11vDbD.Select(s => s.cmdt113).First();
                    List1.DYverf113 = UHSOMD11vDbD.Select(s => s.verf113).First();
                    List1.DYsmid114 = UHSOMD11vDbD.Select(s => s.smid114).First();
                    List1.DYcmdt114 = UHSOMD11vDbD.Select(s => s.cmdt114).First();
                    List1.DYverf114 = UHSOMD11vDbD.Select(s => s.verf114).First();
                    List1.DYsmid115 = UHSOMD11vDbD.Select(s => s.smid115).First();
                    List1.DYcmdt115 = UHSOMD11vDbD.Select(s => s.cmdt115).First();
                    List1.DYverf115 = UHSOMD11vDbD.Select(s => s.verf115).First();
                    List1.DYsmid116 = UHSOMD11vDbD.Select(s => s.smid116).First();
                    List1.DYcmdt116 = UHSOMD11vDbD.Select(s => s.cmdt116).First();
                    List1.DYverf116 = UHSOMD11vDbD.Select(s => s.verf116).First();
                    List1.DYsmid117 = UHSOMD11vDbD.Select(s => s.smid117).First();
                    List1.DYcmdt117 = UHSOMD11vDbD.Select(s => s.cmdt117).First();
                    List1.DYverf117 = UHSOMD11vDbD.Select(s => s.verf117).First();
                    List1.DYsmid118 = UHSOMD11vDbD.Select(s => s.smid118).First();
                    List1.DYcmdt118 = UHSOMD11vDbD.Select(s => s.cmdt118).First();
                    List1.DYverf118 = UHSOMD11vDbD.Select(s => s.verf118).First();
                    List1.DYsmid119 = UHSOMD11vDbD.Select(s => s.smid119).First();
                    List1.DYcmdt119 = UHSOMD11vDbD.Select(s => s.cmdt119).First();
                    List1.DYverf119 = UHSOMD11vDbD.Select(s => s.verf119).First();
                    List1.DYsmid120 = UHSOMD11vDbD.Select(s => s.smid120).First();
                    List1.DYcmdt120 = UHSOMD11vDbD.Select(s => s.cmdt120).First();
                    List1.DYverf120 = UHSOMD11vDbD.Select(s => s.verf120).First();
                    List1.DYsmid121 = UHSOMD11vDbD.Select(s => s.smid121).First();
                    List1.DYcmdt121 = UHSOMD11vDbD.Select(s => s.cmdt121).First();
                    List1.DYverf121 = UHSOMD11vDbD.Select(s => s.verf121).First();
                    List1.DYsmid122 = UHSOMD11vDbD.Select(s => s.smid122).First();
                    List1.DYcmdt122 = UHSOMD11vDbD.Select(s => s.cmdt122).First();
                    List1.DYverf122 = UHSOMD11vDbD.Select(s => s.verf122).First();
                    List1.DYsmid123 = UHSOMD11vDbD.Select(s => s.smid123).First();
                    List1.DYcmdt123 = UHSOMD11vDbD.Select(s => s.cmdt123).First();
                    List1.DYverf123 = UHSOMD11vDbD.Select(s => s.verf123).First();
                    List1.DYsmid124 = UHSOMD11vDbD.Select(s => s.smid124).First();
                    List1.DYcmdt124 = UHSOMD11vDbD.Select(s => s.cmdt124).First();
                    List1.DYverf124 = UHSOMD11vDbD.Select(s => s.verf124).First();
                    List1.DYsmid125 = UHSOMD11vDbD.Select(s => s.smid125).First();
                    List1.DYcmdt125 = UHSOMD11vDbD.Select(s => s.cmdt125).First();
                    List1.DYverf125 = UHSOMD11vDbD.Select(s => s.verf125).First();
                    List1.DYnote01 = UHSOMD11vDbD.Select(s => s.note01).First();
                    List1.DYnote02 = UHSOMD11vDbD.Select(s => s.note02).First();
                    List1.DYnote03 = UHSOMD11vDbD.Select(s => s.note03).First();
                    List1.DYnote04 = UHSOMD11vDbD.Select(s => s.note04).First();
                    List1.DYnote05 = UHSOMD11vDbD.Select(s => s.note05).First();
                    List1.DYnote06 = UHSOMD11vDbD.Select(s => s.note06).First();
                    List1.DYnote07 = UHSOMD11vDbD.Select(s => s.note07).First();
                    List1.DYnote08 = UHSOMD11vDbD.Select(s => s.note08).First();
                    List1.DYnote09 = UHSOMD11vDbD.Select(s => s.note09).First();
                    List1.DYnote10 = UHSOMD11vDbD.Select(s => s.note10).First();
                    List1.DYnote11 = UHSOMD11vDbD.Select(s => s.note11).First();
                    List1.DYnote12 = UHSOMD11vDbD.Select(s => s.note12).First();
                    List1.DYnote13 = UHSOMD11vDbD.Select(s => s.note13).First();
                    List1.DYnote14 = UHSOMD11vDbD.Select(s => s.note14).First();
                    List1.DYnote15 = UHSOMD11vDbD.Select(s => s.note15).First();
                    List1.DYtask01 = UHSOMD11vDbD.Select(s => s.task01).First();
                    List1.DYtask02 = UHSOMD11vDbD.Select(s => s.task02).First();
                    List1.DYtask03 = UHSOMD11vDbD.Select(s => s.task03).First();
                    List1.DYtask04 = UHSOMD11vDbD.Select(s => s.task04).First();
                    List1.DYtask05 = UHSOMD11vDbD.Select(s => s.task05).First();
                    List1.DYacit01 = UHSOMD11vDbD.Select(s => s.acit01).First();
                    List1.DYacit02 = UHSOMD11vDbD.Select(s => s.acit02).First();
                    List1.DYacit03 = UHSOMD11vDbD.Select(s => s.acit03).First();
                    List1.DYacit04 = UHSOMD11vDbD.Select(s => s.acit04).First();
                    List1.DYacit05 = UHSOMD11vDbD.Select(s => s.acit05).First();
                    List1.DYtool01 = UHSOMD11vDbD.Select(s => s.tool01).First();
                    List1.DYtool02 = UHSOMD11vDbD.Select(s => s.tool02).First();
                    List1.DYtool03 = UHSOMD11vDbD.Select(s => s.tool03).First();
                    List1.DYtool04 = UHSOMD11vDbD.Select(s => s.tool04).First();
                    List1.DYtool05 = UHSOMD11vDbD.Select(s => s.tool05).First();
                    List1.DYdocn01 = UHSOMD11vDbD.Select(s => s.docn01).First();
                    List1.DYdocn02 = UHSOMD11vDbD.Select(s => s.docn02).First();
                    List1.DYdocn03 = UHSOMD11vDbD.Select(s => s.docn03).First();
                    List1.DYdocn04 = UHSOMD11vDbD.Select(s => s.docn04).First();
                    List1.DYdocn05 = UHSOMD11vDbD.Select(s => s.docn05).First();
                    List1.DYprfx01 = UHSOMD11vDbD.Select(s => s.prfx01).First();
                    List1.DYprfx02 = UHSOMD11vDbD.Select(s => s.prfx02).First();
                    List1.DYprfx03 = UHSOMD11vDbD.Select(s => s.prfx03).First();
                    List1.DYprfx04 = UHSOMD11vDbD.Select(s => s.prfx04).First();
                    List1.DYprfx05 = UHSOMD11vDbD.Select(s => s.prfx05).First();
                    List1.DYrate01 = UHSOMD11vDbD.Select(s => s.rate01).First();
                    List1.DYrate02 = UHSOMD11vDbD.Select(s => s.rate02).First();
                    List1.DYrate03 = UHSOMD11vDbD.Select(s => s.rate03).First();
                    List1.DYrate04 = UHSOMD11vDbD.Select(s => s.rate04).First();
                    List1.DYrate05 = UHSOMD11vDbD.Select(s => s.rate05).First();
                    List1.DYpref01 = UHSOMD11vDbD.Select(s => s.pref01).First();
                    List1.DYpref02 = UHSOMD11vDbD.Select(s => s.pref02).First();
                    List1.DYpref03 = UHSOMD11vDbD.Select(s => s.pref03).First();
                    List1.DYpref04 = UHSOMD11vDbD.Select(s => s.pref04).First();
                    List1.DYpref05 = UHSOMD11vDbD.Select(s => s.pref05).First();
                    List1.DYratd01 = UHSOMD11vDbD.Select(s => s.ratd01).First();
                    List1.DYratd02 = UHSOMD11vDbD.Select(s => s.ratd02).First();
                    List1.DYratd03 = UHSOMD11vDbD.Select(s => s.ratd03).First();
                    List1.DYratd04 = UHSOMD11vDbD.Select(s => s.ratd04).First();
                    List1.DYratd05 = UHSOMD11vDbD.Select(s => s.ratd05).First();
                    List1.DYallch1c = UHSOMD11vDbD.Select(s => s.allch1c).First();
                    List1.DYwekday = UHSOMD11vDbD.Select(s => s.wekday).First();
                    List1.DYwekdnm = UHSOMD11vDbD.Select(s => s.wekdnm).First();
                    List1.DYchck = UHSOMD11vDbD.Select(s => s.chck).First();
                    List1.DYchckid = UHSOMD11vDbD.Select(s => s.chckid).First();
                    List1.DYchcknm = UHSOMD11vDbD.Select(s => s.chcknm).First();
                    List1.DYchckdt = UHSOMD11vDbD.Select(s => s.chckdt).First();
                    List1.DYyyyy = UHSOMD11vDbD.Select(s => s.yyyy).First();
                    List1.DYyyyymm = UHSOMD11vDbD.Select(s => s.yyyymm).First();
                    List1.DYweeknr = UHSOMD11vDbD.Select(s => s.weeknr).First();
                    List1.DYweekds = UHSOMD11vDbD.Select(s => s.weekds).First();
                    List1.DYyyyymmdd = UHSOMD11vDbD.Select(s => s.yyyymmdd).First();
                    List1.DYhhmmss = UHSOMD11vDbD.Select(s => s.hhmmss).First();
                    List1.DYcrdt = UHSOMD11vDbD.Select(s => s.crdt).First();
                    List1.DYeddt = UHSOMD11vDbD.Select(s => s.eddt).First();
                    List1.DYcrusid = UHSOMD11vDbD.Select(s => s.crusid).First();
                    List1.DYedusid = UHSOMD11vDbD.Select(s => s.edusid).First();
                    List1.DYcrusnm = UHSOMD11vDbD.Select(s => s.crusnm).First();
                    List1.DYedusnm = UHSOMD11vDbD.Select(s => s.edusnm).First();
                    List1.DYcrdate = UHSOMD11vDbD.Select(s => s.crdate).First();
                    //List1.EYID = UHSOMD11vDbE.Select(s => s.ID).First();
                    //List1.EYprojid = UHSOMD11vDbE.Select(s => s.projid).First();
                    //List1.EYtskoid = UHSOMD11vDbE.Select(s => s.tskoid).First();
                    //List1.EYdcgrid = UHSOMD11vDbE.Select(s => s.dcgrid).First();
                    //List1.EYdctpid = UHSOMD11vDbE.Select(s => s.dctpid).First();
                    //List1.EYtspdid = UHSOMD11vDbE.Select(s => s.tspdid).First();
                    //List1.EYdistid = UHSOMD11vDbE.Select(s => s.distid).First();
                    //List1.EYdistnm = UHSOMD11vDbE.Select(s => s.distnm).First();
                    //List1.EYacctid = UHSOMD11vDbE.Select(s => s.acctid).First();
                    //List1.EYuserid = UHSOMD11vDbE.Select(s => s.userid).First();
                    //List1.EYusernm = UHSOMD11vDbE.Select(s => s.usernm).First();
                    //List1.EYdimgid = UHSOMD11vDbE.Select(s => s.dimgid).First();
                    //List1.EYdimgnm = UHSOMD11vDbE.Select(s => s.dimgnm).First();
                    //List1.EYsmid111 = UHSOMD11vDbE.Select(s => s.smid111).First();
                    //List1.EYcmdt111 = UHSOMD11vDbE.Select(s => s.cmdt111).First();
                    //List1.EYverf111 = UHSOMD11vDbE.Select(s => s.verf111).First();
                    //List1.EYsmid112 = UHSOMD11vDbE.Select(s => s.smid112).First();
                    //List1.EYcmdt112 = UHSOMD11vDbE.Select(s => s.cmdt112).First();
                    //List1.EYverf112 = UHSOMD11vDbE.Select(s => s.verf112).First();
                    //List1.EYsmid113 = UHSOMD11vDbE.Select(s => s.smid113).First();
                    //List1.EYcmdt113 = UHSOMD11vDbE.Select(s => s.cmdt113).First();
                    //List1.EYverf113 = UHSOMD11vDbE.Select(s => s.verf113).First();
                    //List1.EYsmid114 = UHSOMD11vDbE.Select(s => s.smid114).First();
                    //List1.EYcmdt114 = UHSOMD11vDbE.Select(s => s.cmdt114).First();
                    //List1.EYverf114 = UHSOMD11vDbE.Select(s => s.verf114).First();
                    //List1.EYsmid115 = UHSOMD11vDbE.Select(s => s.smid115).First();
                    //List1.EYcmdt115 = UHSOMD11vDbE.Select(s => s.cmdt115).First();
                    //List1.EYverf115 = UHSOMD11vDbE.Select(s => s.verf115).First();
                    //List1.EYsmid116 = UHSOMD11vDbE.Select(s => s.smid116).First();
                    //List1.EYcmdt116 = UHSOMD11vDbE.Select(s => s.cmdt116).First();
                    //List1.EYverf116 = UHSOMD11vDbE.Select(s => s.verf116).First();
                    //List1.EYsmid117 = UHSOMD11vDbE.Select(s => s.smid117).First();
                    //List1.EYcmdt117 = UHSOMD11vDbE.Select(s => s.cmdt117).First();
                    //List1.EYverf117 = UHSOMD11vDbE.Select(s => s.verf117).First();
                    //List1.EYsmid118 = UHSOMD11vDbE.Select(s => s.smid118).First();
                    //List1.EYcmdt118 = UHSOMD11vDbE.Select(s => s.cmdt118).First();
                    //List1.EYverf118 = UHSOMD11vDbE.Select(s => s.verf118).First();
                    //List1.EYsmid119 = UHSOMD11vDbE.Select(s => s.smid119).First();
                    //List1.EYcmdt119 = UHSOMD11vDbE.Select(s => s.cmdt119).First();
                    //List1.EYverf119 = UHSOMD11vDbE.Select(s => s.verf119).First();
                    //List1.EYsmid120 = UHSOMD11vDbE.Select(s => s.smid120).First();
                    //List1.EYcmdt120 = UHSOMD11vDbE.Select(s => s.cmdt120).First();
                    //List1.EYverf120 = UHSOMD11vDbE.Select(s => s.verf120).First();
                    //List1.EYsmid121 = UHSOMD11vDbE.Select(s => s.smid121).First();
                    //List1.EYcmdt121 = UHSOMD11vDbE.Select(s => s.cmdt121).First();
                    //List1.EYverf121 = UHSOMD11vDbE.Select(s => s.verf121).First();
                    //List1.EYsmid122 = UHSOMD11vDbE.Select(s => s.smid122).First();
                    //List1.EYcmdt122 = UHSOMD11vDbE.Select(s => s.cmdt122).First();
                    //List1.EYverf122 = UHSOMD11vDbE.Select(s => s.verf122).First();
                    //List1.EYsmid123 = UHSOMD11vDbE.Select(s => s.smid123).First();
                    //List1.EYcmdt123 = UHSOMD11vDbE.Select(s => s.cmdt123).First();
                    //List1.EYverf123 = UHSOMD11vDbE.Select(s => s.verf123).First();
                    //List1.EYsmid124 = UHSOMD11vDbE.Select(s => s.smid124).First();
                    //List1.EYcmdt124 = UHSOMD11vDbE.Select(s => s.cmdt124).First();
                    //List1.EYverf124 = UHSOMD11vDbE.Select(s => s.verf124).First();
                    //List1.EYsmid125 = UHSOMD11vDbE.Select(s => s.smid125).First();
                    //List1.EYcmdt125 = UHSOMD11vDbE.Select(s => s.cmdt125).First();
                    //List1.EYverf125 = UHSOMD11vDbE.Select(s => s.verf125).First();
                    //List1.EYnote01 = UHSOMD11vDbE.Select(s => s.note01).First();
                    //List1.EYnote02 = UHSOMD11vDbE.Select(s => s.note02).First();
                    //List1.EYnote03 = UHSOMD11vDbE.Select(s => s.note03).First();
                    //List1.EYnote04 = UHSOMD11vDbE.Select(s => s.note04).First();
                    //List1.EYnote05 = UHSOMD11vDbE.Select(s => s.note05).First();
                    //List1.EYnote06 = UHSOMD11vDbE.Select(s => s.note06).First();
                    //List1.EYnote07 = UHSOMD11vDbE.Select(s => s.note07).First();
                    //List1.EYnote08 = UHSOMD11vDbE.Select(s => s.note08).First();
                    //List1.EYnote09 = UHSOMD11vDbE.Select(s => s.note09).First();
                    //List1.EYnote10 = UHSOMD11vDbE.Select(s => s.note10).First();
                    //List1.EYnote11 = UHSOMD11vDbE.Select(s => s.note11).First();
                    //List1.EYnote12 = UHSOMD11vDbE.Select(s => s.note12).First();
                    //List1.EYnote13 = UHSOMD11vDbE.Select(s => s.note13).First();
                    //List1.EYnote14 = UHSOMD11vDbE.Select(s => s.note14).First();
                    //List1.EYnote15 = UHSOMD11vDbE.Select(s => s.note15).First();
                    //List1.EYtask01 = UHSOMD11vDbE.Select(s => s.task01).First();
                    //List1.EYtask02 = UHSOMD11vDbE.Select(s => s.task02).First();
                    //List1.EYtask03 = UHSOMD11vDbE.Select(s => s.task03).First();
                    //List1.EYtask04 = UHSOMD11vDbE.Select(s => s.task04).First();
                    //List1.EYtask05 = UHSOMD11vDbE.Select(s => s.task05).First();
                    //List1.EYacit01 = UHSOMD11vDbE.Select(s => s.acit01).First();
                    //List1.EYacit02 = UHSOMD11vDbE.Select(s => s.acit02).First();
                    //List1.EYacit03 = UHSOMD11vDbE.Select(s => s.acit03).First();
                    //List1.EYacit04 = UHSOMD11vDbE.Select(s => s.acit04).First();
                    //List1.EYacit05 = UHSOMD11vDbE.Select(s => s.acit05).First();
                    //List1.EYtool01 = UHSOMD11vDbE.Select(s => s.tool01).First();
                    //List1.EYtool02 = UHSOMD11vDbE.Select(s => s.tool02).First();
                    //List1.EYtool03 = UHSOMD11vDbE.Select(s => s.tool03).First();
                    //List1.EYtool04 = UHSOMD11vDbE.Select(s => s.tool04).First();
                    //List1.EYtool05 = UHSOMD11vDbE.Select(s => s.tool05).First();
                    //List1.EYdocn01 = UHSOMD11vDbE.Select(s => s.docn01).First();
                    //List1.EYdocn02 = UHSOMD11vDbE.Select(s => s.docn02).First();
                    //List1.EYdocn03 = UHSOMD11vDbE.Select(s => s.docn03).First();
                    //List1.EYdocn04 = UHSOMD11vDbE.Select(s => s.docn04).First();
                    //List1.EYdocn05 = UHSOMD11vDbE.Select(s => s.docn05).First();
                    //List1.EYprfx01 = UHSOMD11vDbE.Select(s => s.prfx01).First();
                    //List1.EYprfx02 = UHSOMD11vDbE.Select(s => s.prfx02).First();
                    //List1.EYprfx03 = UHSOMD11vDbE.Select(s => s.prfx03).First();
                    //List1.EYprfx04 = UHSOMD11vDbE.Select(s => s.prfx04).First();
                    //List1.EYprfx05 = UHSOMD11vDbE.Select(s => s.prfx05).First();
                    //List1.EYrate01 = UHSOMD11vDbE.Select(s => s.rate01).First();
                    //List1.EYrate02 = UHSOMD11vDbE.Select(s => s.rate02).First();
                    //List1.EYrate03 = UHSOMD11vDbE.Select(s => s.rate03).First();
                    //List1.EYrate04 = UHSOMD11vDbE.Select(s => s.rate04).First();
                    //List1.EYrate05 = UHSOMD11vDbE.Select(s => s.rate05).First();
                    //List1.EYpref01 = UHSOMD11vDbE.Select(s => s.pref01).First();
                    //List1.EYpref02 = UHSOMD11vDbE.Select(s => s.pref02).First();
                    //List1.EYpref03 = UHSOMD11vDbE.Select(s => s.pref03).First();
                    //List1.EYpref04 = UHSOMD11vDbE.Select(s => s.pref04).First();
                    //List1.EYpref05 = UHSOMD11vDbE.Select(s => s.pref05).First();
                    //List1.EYratd01 = UHSOMD11vDbE.Select(s => s.ratd01).First();
                    //List1.EYratd02 = UHSOMD11vDbE.Select(s => s.ratd02).First();
                    //List1.EYratd03 = UHSOMD11vDbE.Select(s => s.ratd03).First();
                    //List1.EYratd04 = UHSOMD11vDbE.Select(s => s.ratd04).First();
                    //List1.EYratd05 = UHSOMD11vDbE.Select(s => s.ratd05).First();
                    //List1.EYallch1c = UHSOMD11vDbE.Select(s => s.allch1c).First();
                    //List1.EYwekday = UHSOMD11vDbE.Select(s => s.wekday).First();
                    //List1.EYwekdnm = UHSOMD11vDbE.Select(s => s.wekdnm).First();
                    //List1.EYchck = UHSOMD11vDbE.Select(s => s.chck).First();
                    //List1.EYchckid = UHSOMD11vDbE.Select(s => s.chckid).First();
                    //List1.EYchcknm = UHSOMD11vDbE.Select(s => s.chcknm).First();
                    //List1.EYchckdt = UHSOMD11vDbE.Select(s => s.chckdt).First();
                    //List1.EYyyyy = UHSOMD11vDbE.Select(s => s.yyyy).First();
                    //List1.EYyyyymm = UHSOMD11vDbE.Select(s => s.yyyymm).First();
                    //List1.EYweeknr = UHSOMD11vDbE.Select(s => s.weeknr).First();
                    //List1.EYweekds = UHSOMD11vDbE.Select(s => s.weekds).First();
                    //List1.EYyyyymmdd = UHSOMD11vDbE.Select(s => s.yyyymmdd).First();
                    //List1.EYhhmmss = UHSOMD11vDbE.Select(s => s.hhmmss).First();
                    //List1.EYcrdt = UHSOMD11vDbE.Select(s => s.crdt).First();
                    //List1.EYeddt = UHSOMD11vDbE.Select(s => s.eddt).First();
                    //List1.EYcrusid = UHSOMD11vDbE.Select(s => s.crusid).First();
                    //List1.EYedusid = UHSOMD11vDbE.Select(s => s.edusid).First();
                    //List1.EYcrusnm = UHSOMD11vDbE.Select(s => s.crusnm).First();
                    //List1.EYedusnm = UHSOMD11vDbE.Select(s => s.edusnm).First();
                    //List1.EYcrdate = UHSOMD11vDbE.Select(s => s.crdate).First();
                    List1.AZsmid111 = db.agentsDbs.Where(s => s.ID == id111).Select(s => s.agentName).First();
                    List1.AZsmid112 = db.agentsDbs.Where(s => s.ID == id112).Select(s => s.agentName).First();
                    List1.AZsmid113 = db.agentsDbs.Where(s => s.ID == id113).Select(s => s.agentName).First();
                    List1.AZsmid114 = db.agentsDbs.Where(s => s.ID == id114).Select(s => s.agentName).First();
                    List1.AZsmid115 = db.agentsDbs.Where(s => s.ID == id115).Select(s => s.agentName).First();
                    List1.AZsmid116 = db.agentsDbs.Where(s => s.ID == id116).Select(s => s.agentName).First();
                    List1.AZsmid117 = db.agentsDbs.Where(s => s.ID == id117).Select(s => s.agentName).First();
                    List1.AZsmid118 = db.agentsDbs.Where(s => s.ID == id118).Select(s => s.agentName).First();
                    List1.AZsmid119 = db.agentsDbs.Where(s => s.ID == id119).Select(s => s.agentName).First();
                    List1.AZsmid120 = db.agentsDbs.Where(s => s.ID == id120).Select(s => s.agentName).First();
                    List1.AZsmid121 = db.agentsDbs.Where(s => s.ID == id121).Select(s => s.agentName).First();
                    List1.AZsmid122 = db.agentsDbs.Where(s => s.ID == id122).Select(s => s.agentName).First();
                    List1.AZsmid123 = db.agentsDbs.Where(s => s.ID == id123).Select(s => s.agentName).First();
                    List1.AZsmid124 = db.agentsDbs.Where(s => s.ID == id124).Select(s => s.agentName).First();
                    List1.AZsmid125 = db.agentsDbs.Where(s => s.ID == id125).Select(s => s.agentName).First();
                    List1.BZsmid111 = db.agentsDbs.Where(s => s.ID == id211).Select(s => s.agentName).First();
                    List1.BZsmid112 = db.agentsDbs.Where(s => s.ID == id212).Select(s => s.agentName).First();
                    List1.BZsmid113 = db.agentsDbs.Where(s => s.ID == id213).Select(s => s.agentName).First();
                    List1.BZsmid114 = db.agentsDbs.Where(s => s.ID == id214).Select(s => s.agentName).First();
                    List1.BZsmid115 = db.agentsDbs.Where(s => s.ID == id215).Select(s => s.agentName).First();
                    List1.BZsmid116 = db.agentsDbs.Where(s => s.ID == id216).Select(s => s.agentName).First();
                    List1.BZsmid117 = db.agentsDbs.Where(s => s.ID == id217).Select(s => s.agentName).First();
                    List1.BZsmid118 = db.agentsDbs.Where(s => s.ID == id218).Select(s => s.agentName).First();
                    List1.BZsmid119 = db.agentsDbs.Where(s => s.ID == id219).Select(s => s.agentName).First();
                    List1.BZsmid120 = db.agentsDbs.Where(s => s.ID == id220).Select(s => s.agentName).First();
                    List1.BZsmid121 = db.agentsDbs.Where(s => s.ID == id221).Select(s => s.agentName).First();
                    List1.BZsmid122 = db.agentsDbs.Where(s => s.ID == id222).Select(s => s.agentName).First();
                    List1.BZsmid123 = db.agentsDbs.Where(s => s.ID == id223).Select(s => s.agentName).First();
                    List1.BZsmid124 = db.agentsDbs.Where(s => s.ID == id224).Select(s => s.agentName).First();
                    List1.BZsmid125 = db.agentsDbs.Where(s => s.ID == id225).Select(s => s.agentName).First();
                    List1.CZsmid111 = db.agentsDbs.Where(s => s.ID == id311).Select(s => s.agentName).First();
                    List1.CZsmid112 = db.agentsDbs.Where(s => s.ID == id312).Select(s => s.agentName).First();
                    List1.CZsmid113 = db.agentsDbs.Where(s => s.ID == id313).Select(s => s.agentName).First();
                    List1.CZsmid114 = db.agentsDbs.Where(s => s.ID == id314).Select(s => s.agentName).First();
                    List1.CZsmid115 = db.agentsDbs.Where(s => s.ID == id315).Select(s => s.agentName).First();
                    List1.CZsmid116 = db.agentsDbs.Where(s => s.ID == id316).Select(s => s.agentName).First();
                    List1.CZsmid117 = db.agentsDbs.Where(s => s.ID == id317).Select(s => s.agentName).First();
                    List1.CZsmid118 = db.agentsDbs.Where(s => s.ID == id318).Select(s => s.agentName).First();
                    List1.CZsmid119 = db.agentsDbs.Where(s => s.ID == id319).Select(s => s.agentName).First();
                    List1.CZsmid120 = db.agentsDbs.Where(s => s.ID == id320).Select(s => s.agentName).First();
                    List1.CZsmid121 = db.agentsDbs.Where(s => s.ID == id321).Select(s => s.agentName).First();
                    List1.CZsmid122 = db.agentsDbs.Where(s => s.ID == id322).Select(s => s.agentName).First();
                    List1.CZsmid123 = db.agentsDbs.Where(s => s.ID == id323).Select(s => s.agentName).First();
                    List1.CZsmid124 = db.agentsDbs.Where(s => s.ID == id324).Select(s => s.agentName).First();
                    List1.CZsmid125 = db.agentsDbs.Where(s => s.ID == id325).Select(s => s.agentName).First();
                    List1.DZsmid111 = db.agentsDbs.Where(s => s.ID == id411).Select(s => s.agentName).First();
                    List1.DZsmid112 = db.agentsDbs.Where(s => s.ID == id412).Select(s => s.agentName).First();
                    List1.DZsmid113 = db.agentsDbs.Where(s => s.ID == id413).Select(s => s.agentName).First();
                    List1.DZsmid114 = db.agentsDbs.Where(s => s.ID == id414).Select(s => s.agentName).First();
                    List1.DZsmid115 = db.agentsDbs.Where(s => s.ID == id415).Select(s => s.agentName).First();
                    List1.DZsmid116 = db.agentsDbs.Where(s => s.ID == id416).Select(s => s.agentName).First();
                    List1.DZsmid117 = db.agentsDbs.Where(s => s.ID == id417).Select(s => s.agentName).First();
                    List1.DZsmid118 = db.agentsDbs.Where(s => s.ID == id418).Select(s => s.agentName).First();
                    List1.DZsmid119 = db.agentsDbs.Where(s => s.ID == id419).Select(s => s.agentName).First();
                    List1.DZsmid120 = db.agentsDbs.Where(s => s.ID == id420).Select(s => s.agentName).First();
                    List1.DZsmid121 = db.agentsDbs.Where(s => s.ID == id421).Select(s => s.agentName).First();
                    List1.DZsmid122 = db.agentsDbs.Where(s => s.ID == id422).Select(s => s.agentName).First();
                    List1.DZsmid123 = db.agentsDbs.Where(s => s.ID == id423).Select(s => s.agentName).First();
                    List1.DZsmid124 = db.agentsDbs.Where(s => s.ID == id424).Select(s => s.agentName).First();
                    List1.DZsmid125 = db.agentsDbs.Where(s => s.ID == id425).Select(s => s.agentName).First();
                    //List1.EZsmid111 = db.agentsDbs.Where(s => s.ID == id511).Select(s => s.agentName).First();
                    //List1.EZsmid112 = db.agentsDbs.Where(s => s.ID == id512).Select(s => s.agentName).First();
                    //List1.EZsmid113 = db.agentsDbs.Where(s => s.ID == id513).Select(s => s.agentName).First();
                    //List1.EZsmid114 = db.agentsDbs.Where(s => s.ID == id514).Select(s => s.agentName).First();
                    //List1.EZsmid115 = db.agentsDbs.Where(s => s.ID == id515).Select(s => s.agentName).First();
                    //List1.EZsmid116 = db.agentsDbs.Where(s => s.ID == id516).Select(s => s.agentName).First();
                    //List1.EZsmid117 = db.agentsDbs.Where(s => s.ID == id517).Select(s => s.agentName).First();
                    //List1.EZsmid118 = db.agentsDbs.Where(s => s.ID == id518).Select(s => s.agentName).First();
                    //List1.EZsmid119 = db.agentsDbs.Where(s => s.ID == id519).Select(s => s.agentName).First();
                    //List1.EZsmid120 = db.agentsDbs.Where(s => s.ID == id520).Select(s => s.agentName).First();
                    //List1.EZsmid121 = db.agentsDbs.Where(s => s.ID == id521).Select(s => s.agentName).First();
                    //List1.EZsmid122 = db.agentsDbs.Where(s => s.ID == id522).Select(s => s.agentName).First();
                    //List1.EZsmid123 = db.agentsDbs.Where(s => s.ID == id523).Select(s => s.agentName).First();
                    //List1.EZsmid124 = db.agentsDbs.Where(s => s.ID == id524).Select(s => s.agentName).First();
                    //List1.EZsmid125 = db.agentsDbs.Where(s => s.ID == id525).Select(s => s.agentName).First();
                    List1.AZcmdt111 = UHSOMD11Db.Select(s => s.cmdt111).First();
                    List1.AZcmdt112 = UHSOMD11Db.Select(s => s.cmdt112).First();
                    List1.AZcmdt113 = UHSOMD11Db.Select(s => s.cmdt113).First();
                    List1.AZcmdt114 = UHSOMD11Db.Select(s => s.cmdt114).First();
                    List1.AZcmdt115 = UHSOMD11Db.Select(s => s.cmdt115).First();
                    List1.AZcmdt116 = UHSOMD11Db.Select(s => s.cmdt116).First();
                    List1.AZcmdt117 = UHSOMD11Db.Select(s => s.cmdt117).First();
                    List1.AZcmdt118 = UHSOMD11Db.Select(s => s.cmdt118).First();
                    List1.AZcmdt119 = UHSOMD11Db.Select(s => s.cmdt119).First();
                    List1.AZcmdt120 = UHSOMD11Db.Select(s => s.cmdt120).First();
                    List1.AZcmdt121 = UHSOMD11Db.Select(s => s.cmdt121).First();
                    List1.AZcmdt122 = UHSOMD11Db.Select(s => s.cmdt122).First();
                    List1.AZcmdt123 = UHSOMD11Db.Select(s => s.cmdt123).First();
                    List1.AZcmdt124 = UHSOMD11Db.Select(s => s.cmdt124).First();
                    List1.AZcmdt125 = UHSOMD11Db.Select(s => s.cmdt125).First();
                    List1.BZcmdt111 = UHSOMD12Db.Select(s => s.cmdt111).First();
                    List1.BZcmdt112 = UHSOMD12Db.Select(s => s.cmdt112).First();
                    List1.BZcmdt113 = UHSOMD12Db.Select(s => s.cmdt113).First();
                    List1.BZcmdt114 = UHSOMD12Db.Select(s => s.cmdt114).First();
                    List1.BZcmdt115 = UHSOMD12Db.Select(s => s.cmdt115).First();
                    List1.BZcmdt116 = UHSOMD12Db.Select(s => s.cmdt116).First();
                    List1.BZcmdt117 = UHSOMD12Db.Select(s => s.cmdt117).First();
                    List1.BZcmdt118 = UHSOMD12Db.Select(s => s.cmdt118).First();
                    List1.BZcmdt119 = UHSOMD12Db.Select(s => s.cmdt119).First();
                    List1.BZcmdt120 = UHSOMD12Db.Select(s => s.cmdt120).First();
                    List1.BZcmdt121 = UHSOMD12Db.Select(s => s.cmdt121).First();
                    List1.BZcmdt122 = UHSOMD12Db.Select(s => s.cmdt122).First();
                    List1.BZcmdt123 = UHSOMD12Db.Select(s => s.cmdt123).First();
                    List1.BZcmdt124 = UHSOMD12Db.Select(s => s.cmdt124).First();
                    List1.BZcmdt125 = UHSOMD12Db.Select(s => s.cmdt125).First();
                    List1.CZcmdt111 = UHSOMD13Db.Select(s => s.cmdt111).First();
                    List1.CZcmdt112 = UHSOMD13Db.Select(s => s.cmdt112).First();
                    List1.CZcmdt113 = UHSOMD13Db.Select(s => s.cmdt113).First();
                    List1.CZcmdt114 = UHSOMD13Db.Select(s => s.cmdt114).First();
                    List1.CZcmdt115 = UHSOMD13Db.Select(s => s.cmdt115).First();
                    List1.CZcmdt116 = UHSOMD13Db.Select(s => s.cmdt116).First();
                    List1.CZcmdt117 = UHSOMD13Db.Select(s => s.cmdt117).First();
                    List1.CZcmdt118 = UHSOMD13Db.Select(s => s.cmdt118).First();
                    List1.CZcmdt119 = UHSOMD13Db.Select(s => s.cmdt119).First();
                    List1.CZcmdt120 = UHSOMD13Db.Select(s => s.cmdt120).First();
                    List1.CZcmdt121 = UHSOMD13Db.Select(s => s.cmdt121).First();
                    List1.CZcmdt122 = UHSOMD13Db.Select(s => s.cmdt122).First();
                    List1.CZcmdt123 = UHSOMD13Db.Select(s => s.cmdt123).First();
                    List1.CZcmdt124 = UHSOMD13Db.Select(s => s.cmdt124).First();
                    List1.CZcmdt125 = UHSOMD13Db.Select(s => s.cmdt125).First();
                    List1.DZcmdt111 = UHSOMD14Db.Select(s => s.cmdt111).First();
                    List1.DZcmdt112 = UHSOMD14Db.Select(s => s.cmdt112).First();
                    List1.DZcmdt113 = UHSOMD14Db.Select(s => s.cmdt113).First();
                    List1.DZcmdt114 = UHSOMD14Db.Select(s => s.cmdt114).First();
                    List1.DZcmdt115 = UHSOMD14Db.Select(s => s.cmdt115).First();
                    List1.DZcmdt116 = UHSOMD14Db.Select(s => s.cmdt116).First();
                    List1.DZcmdt117 = UHSOMD14Db.Select(s => s.cmdt117).First();
                    List1.DZcmdt118 = UHSOMD14Db.Select(s => s.cmdt118).First();
                    List1.DZcmdt119 = UHSOMD14Db.Select(s => s.cmdt119).First();
                    List1.DZcmdt120 = UHSOMD14Db.Select(s => s.cmdt120).First();
                    List1.DZcmdt121 = UHSOMD14Db.Select(s => s.cmdt121).First();
                    List1.DZcmdt122 = UHSOMD14Db.Select(s => s.cmdt122).First();
                    List1.DZcmdt123 = UHSOMD14Db.Select(s => s.cmdt123).First();
                    List1.DZcmdt124 = UHSOMD14Db.Select(s => s.cmdt124).First();
                    List1.DZcmdt125 = UHSOMD14Db.Select(s => s.cmdt125).First();
                    //List1.EZcmdt111 = UHSOMD15Db.Select(s => s.cmdt111).First();
                    //List1.EZcmdt112 = UHSOMD15Db.Select(s => s.cmdt112).First();
                    //List1.EZcmdt113 = UHSOMD15Db.Select(s => s.cmdt113).First();
                    //List1.EZcmdt114 = UHSOMD15Db.Select(s => s.cmdt114).First();
                    //List1.EZcmdt115 = UHSOMD15Db.Select(s => s.cmdt115).First();
                    //List1.EZcmdt116 = UHSOMD15Db.Select(s => s.cmdt116).First();
                    //List1.EZcmdt117 = UHSOMD15Db.Select(s => s.cmdt117).First();
                    //List1.EZcmdt118 = UHSOMD15Db.Select(s => s.cmdt118).First();
                    //List1.EZcmdt119 = UHSOMD15Db.Select(s => s.cmdt119).First();
                    //List1.EZcmdt120 = UHSOMD15Db.Select(s => s.cmdt120).First();
                    //List1.EZcmdt121 = UHSOMD15Db.Select(s => s.cmdt121).First();
                    //List1.EZcmdt122 = UHSOMD15Db.Select(s => s.cmdt122).First();
                    //List1.EZcmdt123 = UHSOMD15Db.Select(s => s.cmdt123).First();
                    //List1.EZcmdt124 = UHSOMD15Db.Select(s => s.cmdt124).First();
                    //List1.EZcmdt125 = UHSOMD15Db.Select(s => s.cmdt125).First();

                    List1.zacc = opa.UHSACCTSDbs.Where(s => s.IDc == id1 && s.typeid == 2).Select(s => s.CSTNM).First();
                    List1.zdiv = opa.UHSACCTSDbs.Where(s => s.IDc == id1 && s.typeid == 2).Select(s => s.DIV).First();
                    List1.zomh = opa.UHSACCTSDbs.Where(s => s.IDc == id1 && s.typeid == 2).Select(s => s.MGR).First();
                    List1.zdod = opa.UHSACCTSDbs.Where(s => s.IDc == id1 && s.typeid == 2).Select(s => s.DOD).First();
                    List1.zdis = opa.UHSACCTSDbs.Where(s => s.IDc == id1 && s.typeid == 2).Select(s => s.DIST).First();

                    List1.dtDue1 = dtDu01;
                    List1.dtDue2 = Data1.Select(s => s.modStr1).First();
                    List1.dtDue3 = Data1.Select(s => s.modStr2).First();
                    List1.dtDue4 = Data1.Select(s => s.modStr3).First();
                    //List1.dtDue5 = dtDue05;

                    pageModel.Add(List1);

                    ViewBag.dayID = id3;
                    ViewBag.wID = a12;
                    ViewBag.mID = a13;
                    ViewBag.qID = a14;

                    return View("getEditPar10100076", pageModel);

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
        public ActionResult _getb360data(int IDa, int IDb)
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            // get user logged ID int
            int userid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();

            // get userTypeid integer
            int userTypeid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.userType).First();
            ViewBag.userTypeID = userTypeid;

            int distid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.distid).First();
            int usertitle = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.titlid).First();

            if (IDa == 0 && IDb == 0)
            {
                if (userTypeid == 2)
                {
                    var datatable = opb.UHSWEBOMD21vDbs.OrderBy(s => s.IDc).ToList();
                    return PartialView("_getb360data", datatable);
                }
                else if (usertitle == 1)
                {
                    int itn1 = db.agentsDbs.Where(s => s.ID == userid).Select(s => s.divid).First();
                    var list1 = opa.DISTRICTSDbs.Where(s => s.compid == 1 && s.divID == itn1).Select(s => s.ID).Distinct().ToList();
                    var datatable = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).OrderBy(s => s.IDc).ToList();
                    return PartialView("_getb360data", datatable);
                }
                else if (usertitle == 2 || usertitle == 3)
                {
                    var list1 = db.agentsDbs.Where(s => s.ID == userid).Select(s => s.distid).Distinct().ToList();
                    var datatable = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).OrderBy(s => s.IDc).ToList();
                    return PartialView("_getb360data", datatable);
                }
                else
                {
                    var datatable = opb.UHSWEBOMD21vDbs.OrderBy(s => s.IDc).ToList();
                    return PartialView("_getb360data", datatable);
                }
            }
            else
            {
                var datatable = opb.UHSWEBOMD21vDbs.OrderBy(s => s.IDc).ToList();
                return PartialView("_getb360data", datatable);
            }
        }

        public ActionResult getb360dist(int ID)
        {
            List<int> list1 = new List<int>(opa.DISTRICTSDbs.Where(s => s.compid == 1 && s.divID == ID).Select(s => s.ID).Distinct());
            List<int> list2 = new List<int>(opa.UHSACCTSDbs.Where(s => s.typeid == 2).Select(s => s.DISTID).Distinct());

            List<DISTRICTSDb> DISTRICTSDb = new List<DISTRICTSDb>();
            DISTRICTSDb list11 = new DISTRICTSDb();

            var item1 = opa.DISTRICTSDbs.Where(s => s.ID == 0 || (s.divID == ID && s.compid == 1 && list2.Contains(s.DISTID))).Select(s => new { ID = s.ID, district = s.district }).ToList();
            foreach (var item in item1)
            {
                DISTRICTSDb list12 = new DISTRICTSDb();
                list12.ID = item.ID;
                list12.district = item.district;
                DISTRICTSDb.Add(list12);
            }

            var datatable = DISTRICTSDb.OrderBy(s => s.ID).ToList();
            return Json(datatable, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getb360acdv(int ID)
        {
            List<UHSACCTSDb> UHSACCTSDb = new List<UHSACCTSDb>();

            UHSACCTSDb list11 = new UHSACCTSDb();
            list11.IDc = 0;
            list11.CSTNM = "-";
            UHSACCTSDb.Add(list11);

            List<int> it01 = new List<int>(opa.DISTRICTSDbs.Where(s => s.compid == 1 && s.divID == ID).Select(s => s.ID).ToList());
            var item1 = opa.UHSACCTSDbs.Where(s => s.typeid == 2 && it01.Contains(s.DISTID)).Select(s => new { IDc = s.IDc, CSTNM = s.CSTNM }).ToList();
            foreach (var item in item1)
            {
                UHSACCTSDb list12 = new UHSACCTSDb();
                list12.IDc = item.IDc;
                list12.CSTNM = item.CSTNM;
                UHSACCTSDb.Add(list12);
            }

            var datatable = UHSACCTSDb.OrderBy(s => s.IDc).ToList();
            return Json(datatable, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getb360acct(int ID)
        {
            List<UHSACCTSDb> UHSACCTSDb = new List<UHSACCTSDb>();

            UHSACCTSDb list11 = new UHSACCTSDb();
            list11.IDc = 0;
            list11.CSTNM = "-";
            UHSACCTSDb.Add(list11);

            var item1 = opa.UHSACCTSDbs.Where(s => s.typeid == 2 && s.DISTID == ID).Select(s => new { IDc = s.IDc, CSTNM = s.CSTNM }).ToList();
            foreach (var item in item1)
            {
                UHSACCTSDb list12 = new UHSACCTSDb();
                list12.IDc = item.IDc;
                list12.CSTNM = item.CSTNM;
                UHSACCTSDb.Add(list12);
            }

            var datatable = UHSACCTSDb.OrderBy(s => s.IDc).ToList();
            return Json(datatable, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getB360map(int ID)
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
                var datatable = opb.UHSWEBOMD21vDbs.ToList();
                return Json(datatable, JsonRequestBehavior.AllowGet);
            }
            else if (usertitle == 1)
            {
                int itn1 = db.agentsDbs.Where(s => s.ID == userid).Select(s => s.divid).First();
                var list1 = opa.DISTRICTSDbs.Where(s => s.compid == 1 && s.divID == itn1).Select(s => s.ID).Distinct().ToList();
                var datatable = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).ToList();
                return Json(datatable, JsonRequestBehavior.AllowGet);
            }
            else if (usertitle == 2 || usertitle == 3)
            {
                var list1 = db.agentsDbs.Where(s => s.ID == userid).Select(s => s.distid).Distinct().ToList();
                var datatable = opb.UHSWEBOMD21vDbs.Where(s => list1.Contains(s.DISTID)).ToList();
                return Json(datatable, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var datatable = opb.UHSWEBOMD21vDbs.ToList();
                return Json(datatable, JsonRequestBehavior.AllowGet);
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
