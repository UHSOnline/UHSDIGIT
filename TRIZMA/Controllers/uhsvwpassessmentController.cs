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

namespace TRIZMA.Controllers
{
    public class uhsvwpassessmentController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();

        // GET: clientsDbs
        public ActionResult Index()
        {
            string CurrentLoginID = User.Identity.GetUserId().ToString();
            var usID101 = from s in db.agentsDbs where s.userID == CurrentLoginID select s.userType;
            int usID102 = usID101.First();

            return View();
        }

        public ActionResult getCrPar1010003(int distid, int acctid, int actype, string docid)
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

            int cnt1 = opb.UHSUSAC1DISTRICTDbs.Where(s => s.MGRID == userid && s.DISTID == distid).Count();

            if (userTypeid == 2 || (CurrentLoginID == User.Identity.GetUserId().ToString() && returnProjectIDlist.Contains(13)
                                                                                && returnTaskOrdersIDlist.Contains(53)
                                                                                && cnt1 >= 1))
            {
                int usridb = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();
                ViewBag.userIds = usridb;
                // get userTypeid integer

                string userName = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();
                ViewBag.userName = userName;

                var dtt = DateTime.Now.ToString("yyyyMM");
                int dtt1 = int.Parse(dtt);

                var dts = DateTime.Now.ToString("yyyyMMdd");
                int dt1 = int.Parse(dts);

                var zdate = DateTime.Now.ToString("yyyy-MM-dd");

                string docNewid = dt1 + "D" + distid + "A" + acctid + "GR1010DC1010003";

                if(actype == 2)
                {
                    string district = opa.DISTRICTSDbs.Where(s => s.compid == 1 && s.ID == distid).Select(s => s.district).First().ToString();
                    var check1 = opa.UHSVAS01Dbs.Where(s => s.ID == docNewid).Count();

                    if (check1 < 1)
                    {
                        var dtcr1010003 = new
                        {
                            docid = docNewid
                         , userid = userid
                         , actype = 2
                         , zdist = district
                         , zperd = dtt1
                         , zdate = zdate
                         , zuser = userName
                        };

                        ViewBag.dtcr1010003 = dtcr1010003;
                        return View();
                    }

                    else
                    {
                        
                        var dtcr1010003 = new {
                            ID = 0
                          , zdist = district
                          , zperd = dtt1
                          , zdate = zdate
                          , zuser = userName
                        };
                        ViewBag.dtcr1010003 = dtcr1010003;
                        return View();
                    }
                                  
                }
                else if (actype == 3)
                {
                    string data = opb.UHSWEBAABvDbs.Where(s => s.ID == distid).Select(s => s.AASID).First();

                    ViewBag.satGrade = new SelectList(new[] {
                                                                new { Id = "0", Name = "0" },
                                                                new { Id = "1", Name = "1" },
                                                                new { Id = "2", Name = "2" }
                                                              }, "Id", "Name");

                    ViewBag.verify = new SelectList(new[] {
                                                                new { Id = "0", Name = "No" },
                                                                new { Id = "1", Name = "Yes" }
                                                              }, "Id", "Name");

                    var a11 = opa.UHSVAS01Dbs.Where(s => s.distid == distid).OrderByDescending(s => s.ID).Select(s => s.ID).First();
                    ViewBag.dayID = a11;

                    List<uhspageitemsDb> constrID = new List<uhspageitemsDb>();
                    uhspageitemsDb dyPar = new uhspageitemsDb();

                    List<UHSVAS01Db> UHSVAS01Dbr = opa.UHSVAS01Dbs.Where(s => s.ID == a11).ToList();

                    dyPar.modInt01 = opb.UHSVAS01vDbs.Where(s => s.ID == a11).Select(s => s.yyyymmdd).First();                   
                    dyPar.modInt02 = opb.UHSVAS01vDbs.Where(s => s.ID == a11).Select(s => s.weeknr).First();
                    dyPar.modInt03 = opb.UHSVAS01vDbs.Where(s => s.ID == a11).Select(s => s.yyyymm).First();
                    dyPar.modInt04 = opb.UHSVAS01vDbs.Where(s => s.ID == a11).Select(s => s.distid).First();
                    dyPar.modInt05 = opb.UHSVAS01vDbs.Where(s => s.ID == a11).Select(s => s.acctid).First();
                    dyPar.modInt06 = opb.UHSVAS01vDbs.Where(s => s.ID == a11).Select(s => s.dcgrid).First();
                    dyPar.modInt07 = opb.UHSVAS01vDbs.Where(s => s.ID == a11).Select(s => s.dctpid).First();
                    dyPar.modStr1 = a11;
                    constrID.Add(dyPar);

                    ViewBag.constrID = constrID;
                    ViewBag.projList = opb.UHSWOT01vDbs.Where(s => s.docmid == a11 && (userTypeid == 2 || s.crusid == userid)).ToList();

                    string dID = data;
                    var projid = UHSVAS01Dbr.Select(s => s.projid).First();
                    var tskoid = UHSVAS01Dbr.Select(s => s.tskoid).First();
                    var dcgrid = UHSVAS01Dbr.Select(s => s.dcgrid).First();
                    var dctpid = UHSVAS01Dbr.Select(s => s.dctpid).First();
                    var tspdid = UHSVAS01Dbr.Select(s => s.tspdid).First();
                    var disid = UHSVAS01Dbr.Select(s => s.distid).First();
                    var accid = UHSVAS01Dbr.Select(s => s.acctid).First();
                    var usrid = UHSVAS01Dbr.Select(s => s.userid).First();
                    var dimid = UHSVAS01Dbr.Select(s => s.dimgid).First();

                    var GR101 = UHSVAS01Dbr.Select(s => s.GR101).First();
                    var GR102 = UHSVAS01Dbr.Select(s => s.GR102).First();
                    var GR103 = UHSVAS01Dbr.Select(s => s.GR103).First();
                    var GR104 = UHSVAS01Dbr.Select(s => s.GR104).First();
                    var GR105 = UHSVAS01Dbr.Select(s => s.GR105).First();
                    var GR106 = UHSVAS01Dbr.Select(s => s.GR106).First();
                    var GR107 = UHSVAS01Dbr.Select(s => s.GR107).First();
                    var GR108 = UHSVAS01Dbr.Select(s => s.GR108).First();
                    var GR109 = UHSVAS01Dbr.Select(s => s.GR109).First();
                    var GR110 = UHSVAS01Dbr.Select(s => s.GR110).First();
                    var GR111 = UHSVAS01Dbr.Select(s => s.GR111).First();
                    var GR112 = UHSVAS01Dbr.Select(s => s.GR112).First();
                    var GR113 = UHSVAS01Dbr.Select(s => s.GR113).First();
                    var GR114 = UHSVAS01Dbr.Select(s => s.GR114).First();
                    var GR115 = UHSVAS01Dbr.Select(s => s.GR115).First();
                    var GR116 = UHSVAS01Dbr.Select(s => s.GR116).First();
                    var GR117 = UHSVAS01Dbr.Select(s => s.GR117).First();
                    var GR118 = UHSVAS01Dbr.Select(s => s.GR118).First();
                    var GR119 = UHSVAS01Dbr.Select(s => s.GR119).First();
                    var GR120 = UHSVAS01Dbr.Select(s => s.GR120).First();
                    var GR121 = UHSVAS01Dbr.Select(s => s.GR121).First();
                    var GR122 = UHSVAS01Dbr.Select(s => s.GR122).First();
                    var GR123 = UHSVAS01Dbr.Select(s => s.GR123).First();
                    var GR124 = UHSVAS01Dbr.Select(s => s.GR124).First();
                    var GR125 = UHSVAS01Dbr.Select(s => s.GR125).First();
                    var GR126 = UHSVAS01Dbr.Select(s => s.GR126).First();
                    var GR127 = UHSVAS01Dbr.Select(s => s.GR127).First();
                    var GR128 = UHSVAS01Dbr.Select(s => s.GR128).First();
                    var GR129 = UHSVAS01Dbr.Select(s => s.GR129).First();
                    var GR130 = UHSVAS01Dbr.Select(s => s.GR130).First();
                    var GR201 = UHSVAS01Dbr.Select(s => s.GR201).First();
                    var GR202 = UHSVAS01Dbr.Select(s => s.GR202).First();
                    var GR203 = UHSVAS01Dbr.Select(s => s.GR203).First();
                    var GR204 = UHSVAS01Dbr.Select(s => s.GR204).First();
                    var GR205 = UHSVAS01Dbr.Select(s => s.GR205).First();
                    var GR206 = UHSVAS01Dbr.Select(s => s.GR206).First();
                    var GR207 = UHSVAS01Dbr.Select(s => s.GR207).First();
                    var GR208 = UHSVAS01Dbr.Select(s => s.GR208).First();
                    var GR209 = UHSVAS01Dbr.Select(s => s.GR209).First();
                    var GR210 = UHSVAS01Dbr.Select(s => s.GR210).First();
                    var GR211 = UHSVAS01Dbr.Select(s => s.GR211).First();
                    var GR212 = UHSVAS01Dbr.Select(s => s.GR212).First();
                    var GR213 = UHSVAS01Dbr.Select(s => s.GR213).First();
                    var GR214 = UHSVAS01Dbr.Select(s => s.GR214).First();
                    var GR215 = UHSVAS01Dbr.Select(s => s.GR215).First();
                    var GR216 = UHSVAS01Dbr.Select(s => s.GR216).First();
                    var GR217 = UHSVAS01Dbr.Select(s => s.GR217).First();
                    var GR218 = UHSVAS01Dbr.Select(s => s.GR218).First();
                    var GR219 = UHSVAS01Dbr.Select(s => s.GR219).First();
                    var GR220 = UHSVAS01Dbr.Select(s => s.GR220).First();
                    var GR301 = UHSVAS01Dbr.Select(s => s.GR301).First();
                    var GR302 = UHSVAS01Dbr.Select(s => s.GR302).First();
                    var GR303 = UHSVAS01Dbr.Select(s => s.GR303).First();
                    var GR304 = UHSVAS01Dbr.Select(s => s.GR304).First();
                    var GR305 = UHSVAS01Dbr.Select(s => s.GR305).First();
                    var GR306 = UHSVAS01Dbr.Select(s => s.GR306).First();
                    var GR307 = UHSVAS01Dbr.Select(s => s.GR307).First();
                    var GR308 = UHSVAS01Dbr.Select(s => s.GR308).First();
                    var GR309 = UHSVAS01Dbr.Select(s => s.GR309).First();
                    var GR310 = UHSVAS01Dbr.Select(s => s.GR310).First();
                    var GR311 = UHSVAS01Dbr.Select(s => s.GR311).First();
                    var GR312 = UHSVAS01Dbr.Select(s => s.GR312).First();
                    var GR313 = UHSVAS01Dbr.Select(s => s.GR313).First();
                    var GR314 = UHSVAS01Dbr.Select(s => s.GR314).First();
                    var GR315 = UHSVAS01Dbr.Select(s => s.GR315).First();
                    var GR316 = UHSVAS01Dbr.Select(s => s.GR316).First();
                    var GR317 = UHSVAS01Dbr.Select(s => s.GR317).First();
                    var GR318 = UHSVAS01Dbr.Select(s => s.GR318).First();
                    var GR319 = UHSVAS01Dbr.Select(s => s.GR319).First();
                    var GR320 = UHSVAS01Dbr.Select(s => s.GR320).First();
                    var GR321 = UHSVAS01Dbr.Select(s => s.GR321).First();
                    var GR322 = UHSVAS01Dbr.Select(s => s.GR322).First();
                    var GR323 = UHSVAS01Dbr.Select(s => s.GR323).First();
                    var GR324 = UHSVAS01Dbr.Select(s => s.GR324).First();
                    var GR325 = UHSVAS01Dbr.Select(s => s.GR325).First();
                    var GR401 = UHSVAS01Dbr.Select(s => s.GR401).First();
                    var GR402 = UHSVAS01Dbr.Select(s => s.GR402).First();
                    var GR403 = UHSVAS01Dbr.Select(s => s.GR403).First();
                    var GR404 = UHSVAS01Dbr.Select(s => s.GR404).First();
                    var GR405 = UHSVAS01Dbr.Select(s => s.GR405).First();
                    var GR406 = UHSVAS01Dbr.Select(s => s.GR406).First();
                    var GR407 = UHSVAS01Dbr.Select(s => s.GR407).First();
                    var GR408 = UHSVAS01Dbr.Select(s => s.GR408).First();
                    var GR409 = UHSVAS01Dbr.Select(s => s.GR409).First();
                    var GR410 = UHSVAS01Dbr.Select(s => s.GR410).First();
                    var GR411 = UHSVAS01Dbr.Select(s => s.GR411).First();
                    var GR412 = UHSVAS01Dbr.Select(s => s.GR412).First();
                    var GR413 = UHSVAS01Dbr.Select(s => s.GR413).First();
                    var GR414 = UHSVAS01Dbr.Select(s => s.GR414).First();
                    var GR415 = UHSVAS01Dbr.Select(s => s.GR415).First();
                    var GR416 = UHSVAS01Dbr.Select(s => s.GR416).First();
                    var GR417 = UHSVAS01Dbr.Select(s => s.GR417).First();
                    var GR418 = UHSVAS01Dbr.Select(s => s.GR418).First();
                    var GR419 = UHSVAS01Dbr.Select(s => s.GR419).First();
                    var GR420 = UHSVAS01Dbr.Select(s => s.GR420).First();
                    var GR421 = UHSVAS01Dbr.Select(s => s.GR421).First();
                    var GR422 = UHSVAS01Dbr.Select(s => s.GR422).First();
                    var GR423 = UHSVAS01Dbr.Select(s => s.GR423).First();
                    var GR424 = UHSVAS01Dbr.Select(s => s.GR424).First();
                    var GR425 = UHSVAS01Dbr.Select(s => s.GR425).First();
                    var GR501 = UHSVAS01Dbr.Select(s => s.GR501).First();
                    var GR502 = UHSVAS01Dbr.Select(s => s.GR502).First();
                    var GR503 = UHSVAS01Dbr.Select(s => s.GR503).First();
                    var GR504 = UHSVAS01Dbr.Select(s => s.GR504).First();
                    var GR505 = UHSVAS01Dbr.Select(s => s.GR505).First();
                    var GR506 = UHSVAS01Dbr.Select(s => s.GR506).First();
                    var GR507 = UHSVAS01Dbr.Select(s => s.GR507).First();
                    var GR508 = UHSVAS01Dbr.Select(s => s.GR508).First();
                    var GR509 = UHSVAS01Dbr.Select(s => s.GR509).First();
                    var GR510 = UHSVAS01Dbr.Select(s => s.GR510).First();
                    var GR511 = UHSVAS01Dbr.Select(s => s.GR511).First();
                    var GR512 = UHSVAS01Dbr.Select(s => s.GR512).First();
                    var GR513 = UHSVAS01Dbr.Select(s => s.GR513).First();
                    var GR514 = UHSVAS01Dbr.Select(s => s.GR514).First();
                    var GR515 = UHSVAS01Dbr.Select(s => s.GR515).First();
                    var GR516 = UHSVAS01Dbr.Select(s => s.GR516).First();
                    var GR517 = UHSVAS01Dbr.Select(s => s.GR517).First();
                    var GR518 = UHSVAS01Dbr.Select(s => s.GR518).First();
                    var GR519 = UHSVAS01Dbr.Select(s => s.GR519).First();
                    var GR520 = UHSVAS01Dbr.Select(s => s.GR520).First();
                    var GR521 = UHSVAS01Dbr.Select(s => s.GR521).First();
                    var GR522 = UHSVAS01Dbr.Select(s => s.GR522).First();
                    var GR523 = UHSVAS01Dbr.Select(s => s.GR523).First();
                    var GR524 = UHSVAS01Dbr.Select(s => s.GR524).First();
                    var GR525 = UHSVAS01Dbr.Select(s => s.GR525).First();
                    var GR526 = UHSVAS01Dbr.Select(s => s.GR526).First();
                    var GR527 = UHSVAS01Dbr.Select(s => s.GR527).First();
                    var GR528 = UHSVAS01Dbr.Select(s => s.GR528).First();
                    var GR529 = UHSVAS01Dbr.Select(s => s.GR529).First();
                    var GR530 = UHSVAS01Dbr.Select(s => s.GR530).First();
                    var GR601 = UHSVAS01Dbr.Select(s => s.GR601).First();
                    var GR602 = UHSVAS01Dbr.Select(s => s.GR602).First();
                    var GR603 = UHSVAS01Dbr.Select(s => s.GR603).First();
                    var GR604 = UHSVAS01Dbr.Select(s => s.GR604).First();
                    var GR605 = UHSVAS01Dbr.Select(s => s.GR605).First();
                    var GR606 = UHSVAS01Dbr.Select(s => s.GR606).First();
                    var GR607 = UHSVAS01Dbr.Select(s => s.GR607).First();
                    var GR608 = UHSVAS01Dbr.Select(s => s.GR608).First();
                    var GR609 = UHSVAS01Dbr.Select(s => s.GR609).First();
                    var GR610 = UHSVAS01Dbr.Select(s => s.GR610).First();
                    var GR611 = UHSVAS01Dbr.Select(s => s.GR611).First();
                    var GR612 = UHSVAS01Dbr.Select(s => s.GR612).First();
                    var GR613 = UHSVAS01Dbr.Select(s => s.GR613).First();
                    var GR614 = UHSVAS01Dbr.Select(s => s.GR614).First();
                    var GR615 = UHSVAS01Dbr.Select(s => s.GR615).First();
                    var GR616 = UHSVAS01Dbr.Select(s => s.GR616).First();
                    var GR617 = UHSVAS01Dbr.Select(s => s.GR617).First();
                    var GR618 = UHSVAS01Dbr.Select(s => s.GR618).First();
                    var GR619 = UHSVAS01Dbr.Select(s => s.GR619).First();
                    var GR620 = UHSVAS01Dbr.Select(s => s.GR620).First();
                    var GR701 = UHSVAS01Dbr.Select(s => s.GR701).First();
                    var GR702 = UHSVAS01Dbr.Select(s => s.GR702).First();
                    var GR703 = UHSVAS01Dbr.Select(s => s.GR703).First();
                    var GR704 = UHSVAS01Dbr.Select(s => s.GR704).First();
                    var GR705 = UHSVAS01Dbr.Select(s => s.GR705).First();
                    var GR706 = UHSVAS01Dbr.Select(s => s.GR706).First();
                    var GR707 = UHSVAS01Dbr.Select(s => s.GR707).First();
                    var GR708 = UHSVAS01Dbr.Select(s => s.GR708).First();
                    var GR709 = UHSVAS01Dbr.Select(s => s.GR709).First();
                    var GR710 = UHSVAS01Dbr.Select(s => s.GR710).First();
                    var GR711 = UHSVAS01Dbr.Select(s => s.GR711).First();
                    var GR712 = UHSVAS01Dbr.Select(s => s.GR712).First();
                    var GR713 = UHSVAS01Dbr.Select(s => s.GR713).First();
                    var GR714 = UHSVAS01Dbr.Select(s => s.GR714).First();
                    var GR715 = UHSVAS01Dbr.Select(s => s.GR715).First();
                    var GR716 = UHSVAS01Dbr.Select(s => s.GR716).First();
                    var GR717 = UHSVAS01Dbr.Select(s => s.GR717).First();
                    var GR718 = UHSVAS01Dbr.Select(s => s.GR718).First();
                    var GR719 = UHSVAS01Dbr.Select(s => s.GR719).First();
                    var GR720 = UHSVAS01Dbr.Select(s => s.GR720).First();
                    var GR721 = UHSVAS01Dbr.Select(s => s.GR721).First();
                    var GR722 = UHSVAS01Dbr.Select(s => s.GR722).First();
                    var GR723 = UHSVAS01Dbr.Select(s => s.GR723).First();
                    var GR724 = UHSVAS01Dbr.Select(s => s.GR724).First();
                    var GR725 = UHSVAS01Dbr.Select(s => s.GR725).First();
                    var GR726 = UHSVAS01Dbr.Select(s => s.GR726).First();
                    var GR727 = UHSVAS01Dbr.Select(s => s.GR727).First();
                    var GR728 = UHSVAS01Dbr.Select(s => s.GR728).First();
                    var GR729 = UHSVAS01Dbr.Select(s => s.GR729).First();
                    var GR730 = UHSVAS01Dbr.Select(s => s.GR730).First();
                    var GR731 = UHSVAS01Dbr.Select(s => s.GR731).First();
                    var GR732 = UHSVAS01Dbr.Select(s => s.GR732).First();
                    var GR733 = UHSVAS01Dbr.Select(s => s.GR733).First();
                    var GR734 = UHSVAS01Dbr.Select(s => s.GR734).First();
                    var GR735 = UHSVAS01Dbr.Select(s => s.GR735).First();
                    var GR801 = UHSVAS01Dbr.Select(s => s.GR801).First();
                    var GR802 = UHSVAS01Dbr.Select(s => s.GR802).First();
                    var GR803 = UHSVAS01Dbr.Select(s => s.GR803).First();
                    var GR804 = UHSVAS01Dbr.Select(s => s.GR804).First();
                    var GR805 = UHSVAS01Dbr.Select(s => s.GR805).First();
                    var GR806 = UHSVAS01Dbr.Select(s => s.GR806).First();
                    var GR807 = UHSVAS01Dbr.Select(s => s.GR807).First();
                    var GR808 = UHSVAS01Dbr.Select(s => s.GR808).First();
                    var GR809 = UHSVAS01Dbr.Select(s => s.GR809).First();
                    var GR810 = UHSVAS01Dbr.Select(s => s.GR810).First();
                    var GR811 = UHSVAS01Dbr.Select(s => s.GR811).First();
                    var GR812 = UHSVAS01Dbr.Select(s => s.GR812).First();
                    var GR813 = UHSVAS01Dbr.Select(s => s.GR813).First();
                    var GR814 = UHSVAS01Dbr.Select(s => s.GR814).First();
                    var GR815 = UHSVAS01Dbr.Select(s => s.GR815).First();
                    var GR816 = UHSVAS01Dbr.Select(s => s.GR816).First();
                    var GR817 = UHSVAS01Dbr.Select(s => s.GR817).First();
                    var GR818 = UHSVAS01Dbr.Select(s => s.GR818).First();
                    var GR819 = UHSVAS01Dbr.Select(s => s.GR819).First();
                    var GR820 = UHSVAS01Dbr.Select(s => s.GR820).First();
                    var GR901 = UHSVAS01Dbr.Select(s => s.GR901).First();
                    var GR902 = UHSVAS01Dbr.Select(s => s.GR902).First();
                    var GR903 = UHSVAS01Dbr.Select(s => s.GR903).First();
                    var GR904 = UHSVAS01Dbr.Select(s => s.GR904).First();
                    var GR905 = UHSVAS01Dbr.Select(s => s.GR905).First();
                    var GR906 = UHSVAS01Dbr.Select(s => s.GR906).First();
                    var GR907 = UHSVAS01Dbr.Select(s => s.GR907).First();
                    var GR908 = UHSVAS01Dbr.Select(s => s.GR908).First();
                    var GR909 = UHSVAS01Dbr.Select(s => s.GR909).First();
                    var GR910 = UHSVAS01Dbr.Select(s => s.GR910).First();
                    var GR911 = UHSVAS01Dbr.Select(s => s.GR911).First();
                    var GR912 = UHSVAS01Dbr.Select(s => s.GR912).First();
                    var GR913 = UHSVAS01Dbr.Select(s => s.GR913).First();
                    var GR914 = UHSVAS01Dbr.Select(s => s.GR914).First();
                    var GR915 = UHSVAS01Dbr.Select(s => s.GR915).First();
                    var GR916 = UHSVAS01Dbr.Select(s => s.GR916).First();
                    var GR917 = UHSVAS01Dbr.Select(s => s.GR917).First();
                    var GR918 = UHSVAS01Dbr.Select(s => s.GR918).First();
                    var GR919 = UHSVAS01Dbr.Select(s => s.GR919).First();
                    var GR920 = UHSVAS01Dbr.Select(s => s.GR920).First();


                    var TX101 = UHSVAS01Dbr.Select(s => s.TX101).First();
                    var TX102 = UHSVAS01Dbr.Select(s => s.TX102).First();
                    var TX103 = UHSVAS01Dbr.Select(s => s.TX103).First();
                    var TX104 = UHSVAS01Dbr.Select(s => s.TX104).First();
                    var TX105 = UHSVAS01Dbr.Select(s => s.TX105).First();
                    var TX106 = UHSVAS01Dbr.Select(s => s.TX106).First();
                    var TX107 = UHSVAS01Dbr.Select(s => s.TX107).First();
                    var TX108 = UHSVAS01Dbr.Select(s => s.TX108).First();
                    var TX109 = UHSVAS01Dbr.Select(s => s.TX109).First();
                    var TX110 = UHSVAS01Dbr.Select(s => s.TX110).First();
                    var TX111 = UHSVAS01Dbr.Select(s => s.TX111).First();
                    var TX112 = UHSVAS01Dbr.Select(s => s.TX112).First();
                    var TX113 = UHSVAS01Dbr.Select(s => s.TX113).First();
                    var TX114 = UHSVAS01Dbr.Select(s => s.TX114).First();
                    var TX115 = UHSVAS01Dbr.Select(s => s.TX115).First();
                    var TX116 = UHSVAS01Dbr.Select(s => s.TX116).First();
                    var TX117 = UHSVAS01Dbr.Select(s => s.TX117).First();
                    var TX118 = UHSVAS01Dbr.Select(s => s.TX118).First();
                    var TX119 = UHSVAS01Dbr.Select(s => s.TX119).First();
                    var TX120 = UHSVAS01Dbr.Select(s => s.TX120).First();
                    var TX121 = UHSVAS01Dbr.Select(s => s.TX121).First();
                    var TX122 = UHSVAS01Dbr.Select(s => s.TX122).First();
                    var TX123 = UHSVAS01Dbr.Select(s => s.TX123).First();
                    var TX124 = UHSVAS01Dbr.Select(s => s.TX124).First();
                    var TX125 = UHSVAS01Dbr.Select(s => s.TX125).First();
                    var TX126 = UHSVAS01Dbr.Select(s => s.TX126).First();
                    var TX127 = UHSVAS01Dbr.Select(s => s.TX127).First();
                    var TX128 = UHSVAS01Dbr.Select(s => s.TX128).First();
                    var TX129 = UHSVAS01Dbr.Select(s => s.TX129).First();
                    var TX130 = UHSVAS01Dbr.Select(s => s.TX130).First();
                    var TX201 = UHSVAS01Dbr.Select(s => s.TX201).First();
                    var TX202 = UHSVAS01Dbr.Select(s => s.TX202).First();
                    var TX203 = UHSVAS01Dbr.Select(s => s.TX203).First();
                    var TX204 = UHSVAS01Dbr.Select(s => s.TX204).First();
                    var TX205 = UHSVAS01Dbr.Select(s => s.TX205).First();
                    var TX206 = UHSVAS01Dbr.Select(s => s.TX206).First();
                    var TX207 = UHSVAS01Dbr.Select(s => s.TX207).First();
                    var TX208 = UHSVAS01Dbr.Select(s => s.TX208).First();
                    var TX209 = UHSVAS01Dbr.Select(s => s.TX209).First();
                    var TX210 = UHSVAS01Dbr.Select(s => s.TX210).First();
                    var TX211 = UHSVAS01Dbr.Select(s => s.TX211).First();
                    var TX212 = UHSVAS01Dbr.Select(s => s.TX212).First();
                    var TX213 = UHSVAS01Dbr.Select(s => s.TX213).First();
                    var TX214 = UHSVAS01Dbr.Select(s => s.TX214).First();
                    var TX215 = UHSVAS01Dbr.Select(s => s.TX215).First();
                    var TX216 = UHSVAS01Dbr.Select(s => s.TX216).First();
                    var TX217 = UHSVAS01Dbr.Select(s => s.TX217).First();
                    var TX218 = UHSVAS01Dbr.Select(s => s.TX218).First();
                    var TX219 = UHSVAS01Dbr.Select(s => s.TX219).First();
                    var TX220 = UHSVAS01Dbr.Select(s => s.TX220).First();
                    var TX301 = UHSVAS01Dbr.Select(s => s.TX301).First();
                    var TX302 = UHSVAS01Dbr.Select(s => s.TX302).First();
                    var TX303 = UHSVAS01Dbr.Select(s => s.TX303).First();
                    var TX304 = UHSVAS01Dbr.Select(s => s.TX304).First();
                    var TX305 = UHSVAS01Dbr.Select(s => s.TX305).First();
                    var TX306 = UHSVAS01Dbr.Select(s => s.TX306).First();
                    var TX307 = UHSVAS01Dbr.Select(s => s.TX307).First();
                    var TX308 = UHSVAS01Dbr.Select(s => s.TX308).First();
                    var TX309 = UHSVAS01Dbr.Select(s => s.TX309).First();
                    var TX310 = UHSVAS01Dbr.Select(s => s.TX310).First();
                    var TX311 = UHSVAS01Dbr.Select(s => s.TX311).First();
                    var TX312 = UHSVAS01Dbr.Select(s => s.TX312).First();
                    var TX313 = UHSVAS01Dbr.Select(s => s.TX313).First();
                    var TX314 = UHSVAS01Dbr.Select(s => s.TX314).First();
                    var TX315 = UHSVAS01Dbr.Select(s => s.TX315).First();
                    var TX316 = UHSVAS01Dbr.Select(s => s.TX316).First();
                    var TX317 = UHSVAS01Dbr.Select(s => s.TX317).First();
                    var TX318 = UHSVAS01Dbr.Select(s => s.TX318).First();
                    var TX319 = UHSVAS01Dbr.Select(s => s.TX319).First();
                    var TX320 = UHSVAS01Dbr.Select(s => s.TX320).First();
                    var TX321 = UHSVAS01Dbr.Select(s => s.TX321).First();
                    var TX322 = UHSVAS01Dbr.Select(s => s.TX322).First();
                    var TX323 = UHSVAS01Dbr.Select(s => s.TX323).First();
                    var TX324 = UHSVAS01Dbr.Select(s => s.TX324).First();
                    var TX325 = UHSVAS01Dbr.Select(s => s.TX325).First();
                    var TX401 = UHSVAS01Dbr.Select(s => s.TX401).First();
                    var TX402 = UHSVAS01Dbr.Select(s => s.TX402).First();
                    var TX403 = UHSVAS01Dbr.Select(s => s.TX403).First();
                    var TX404 = UHSVAS01Dbr.Select(s => s.TX404).First();
                    var TX405 = UHSVAS01Dbr.Select(s => s.TX405).First();
                    var TX406 = UHSVAS01Dbr.Select(s => s.TX406).First();
                    var TX407 = UHSVAS01Dbr.Select(s => s.TX407).First();
                    var TX408 = UHSVAS01Dbr.Select(s => s.TX408).First();
                    var TX409 = UHSVAS01Dbr.Select(s => s.TX409).First();
                    var TX410 = UHSVAS01Dbr.Select(s => s.TX410).First();
                    var TX411 = UHSVAS01Dbr.Select(s => s.TX411).First();
                    var TX412 = UHSVAS01Dbr.Select(s => s.TX412).First();
                    var TX413 = UHSVAS01Dbr.Select(s => s.TX413).First();
                    var TX414 = UHSVAS01Dbr.Select(s => s.TX414).First();
                    var TX415 = UHSVAS01Dbr.Select(s => s.TX415).First();
                    var TX416 = UHSVAS01Dbr.Select(s => s.TX416).First();
                    var TX417 = UHSVAS01Dbr.Select(s => s.TX417).First();
                    var TX418 = UHSVAS01Dbr.Select(s => s.TX418).First();
                    var TX419 = UHSVAS01Dbr.Select(s => s.TX419).First();
                    var TX420 = UHSVAS01Dbr.Select(s => s.TX420).First();
                    var TX421 = UHSVAS01Dbr.Select(s => s.TX421).First();
                    var TX422 = UHSVAS01Dbr.Select(s => s.TX422).First();
                    var TX423 = UHSVAS01Dbr.Select(s => s.TX423).First();
                    var TX424 = UHSVAS01Dbr.Select(s => s.TX424).First();
                    var TX425 = UHSVAS01Dbr.Select(s => s.TX425).First();
                    var TX501 = UHSVAS01Dbr.Select(s => s.TX501).First();
                    var TX502 = UHSVAS01Dbr.Select(s => s.TX502).First();
                    var TX503 = UHSVAS01Dbr.Select(s => s.TX503).First();
                    var TX504 = UHSVAS01Dbr.Select(s => s.TX504).First();
                    var TX505 = UHSVAS01Dbr.Select(s => s.TX505).First();
                    var TX506 = UHSVAS01Dbr.Select(s => s.TX506).First();
                    var TX507 = UHSVAS01Dbr.Select(s => s.TX507).First();
                    var TX508 = UHSVAS01Dbr.Select(s => s.TX508).First();
                    var TX509 = UHSVAS01Dbr.Select(s => s.TX509).First();
                    var TX510 = UHSVAS01Dbr.Select(s => s.TX510).First();
                    var TX511 = UHSVAS01Dbr.Select(s => s.TX511).First();
                    var TX512 = UHSVAS01Dbr.Select(s => s.TX512).First();
                    var TX513 = UHSVAS01Dbr.Select(s => s.TX513).First();
                    var TX514 = UHSVAS01Dbr.Select(s => s.TX514).First();
                    var TX515 = UHSVAS01Dbr.Select(s => s.TX515).First();
                    var TX516 = UHSVAS01Dbr.Select(s => s.TX516).First();
                    var TX517 = UHSVAS01Dbr.Select(s => s.TX517).First();
                    var TX518 = UHSVAS01Dbr.Select(s => s.TX518).First();
                    var TX519 = UHSVAS01Dbr.Select(s => s.TX519).First();
                    var TX520 = UHSVAS01Dbr.Select(s => s.TX520).First();
                    var TX521 = UHSVAS01Dbr.Select(s => s.TX521).First();
                    var TX522 = UHSVAS01Dbr.Select(s => s.TX522).First();
                    var TX523 = UHSVAS01Dbr.Select(s => s.TX523).First();
                    var TX524 = UHSVAS01Dbr.Select(s => s.TX524).First();
                    var TX525 = UHSVAS01Dbr.Select(s => s.TX525).First();
                    var TX526 = UHSVAS01Dbr.Select(s => s.TX526).First();
                    var TX527 = UHSVAS01Dbr.Select(s => s.TX527).First();
                    var TX528 = UHSVAS01Dbr.Select(s => s.TX528).First();
                    var TX529 = UHSVAS01Dbr.Select(s => s.TX529).First();
                    var TX530 = UHSVAS01Dbr.Select(s => s.TX530).First();
                    var TX601 = UHSVAS01Dbr.Select(s => s.TX601).First();
                    var TX602 = UHSVAS01Dbr.Select(s => s.TX602).First();
                    var TX603 = UHSVAS01Dbr.Select(s => s.TX603).First();
                    var TX604 = UHSVAS01Dbr.Select(s => s.TX604).First();
                    var TX605 = UHSVAS01Dbr.Select(s => s.TX605).First();
                    var TX606 = UHSVAS01Dbr.Select(s => s.TX606).First();
                    var TX607 = UHSVAS01Dbr.Select(s => s.TX607).First();
                    var TX608 = UHSVAS01Dbr.Select(s => s.TX608).First();
                    var TX609 = UHSVAS01Dbr.Select(s => s.TX609).First();
                    var TX610 = UHSVAS01Dbr.Select(s => s.TX610).First();
                    var TX611 = UHSVAS01Dbr.Select(s => s.TX611).First();
                    var TX612 = UHSVAS01Dbr.Select(s => s.TX612).First();
                    var TX613 = UHSVAS01Dbr.Select(s => s.TX613).First();
                    var TX614 = UHSVAS01Dbr.Select(s => s.TX614).First();
                    var TX615 = UHSVAS01Dbr.Select(s => s.TX615).First();
                    var TX616 = UHSVAS01Dbr.Select(s => s.TX616).First();
                    var TX617 = UHSVAS01Dbr.Select(s => s.TX617).First();
                    var TX618 = UHSVAS01Dbr.Select(s => s.TX618).First();
                    var TX619 = UHSVAS01Dbr.Select(s => s.TX619).First();
                    var TX620 = UHSVAS01Dbr.Select(s => s.TX620).First();
                    var TX701 = UHSVAS01Dbr.Select(s => s.TX701).First();
                    var TX702 = UHSVAS01Dbr.Select(s => s.TX702).First();
                    var TX703 = UHSVAS01Dbr.Select(s => s.TX703).First();
                    var TX704 = UHSVAS01Dbr.Select(s => s.TX704).First();
                    var TX705 = UHSVAS01Dbr.Select(s => s.TX705).First();
                    var TX706 = UHSVAS01Dbr.Select(s => s.TX706).First();
                    var TX707 = UHSVAS01Dbr.Select(s => s.TX707).First();
                    var TX708 = UHSVAS01Dbr.Select(s => s.TX708).First();
                    var TX709 = UHSVAS01Dbr.Select(s => s.TX709).First();
                    var TX710 = UHSVAS01Dbr.Select(s => s.TX710).First();
                    var TX711 = UHSVAS01Dbr.Select(s => s.TX711).First();
                    var TX712 = UHSVAS01Dbr.Select(s => s.TX712).First();
                    var TX713 = UHSVAS01Dbr.Select(s => s.TX713).First();
                    var TX714 = UHSVAS01Dbr.Select(s => s.TX714).First();
                    var TX715 = UHSVAS01Dbr.Select(s => s.TX715).First();
                    var TX716 = UHSVAS01Dbr.Select(s => s.TX716).First();
                    var TX717 = UHSVAS01Dbr.Select(s => s.TX717).First();
                    var TX718 = UHSVAS01Dbr.Select(s => s.TX718).First();
                    var TX719 = UHSVAS01Dbr.Select(s => s.TX719).First();
                    var TX720 = UHSVAS01Dbr.Select(s => s.TX720).First();
                    var TX721 = UHSVAS01Dbr.Select(s => s.TX721).First();
                    var TX722 = UHSVAS01Dbr.Select(s => s.TX722).First();
                    var TX723 = UHSVAS01Dbr.Select(s => s.TX723).First();
                    var TX724 = UHSVAS01Dbr.Select(s => s.TX724).First();
                    var TX725 = UHSVAS01Dbr.Select(s => s.TX725).First();
                    var TX726 = UHSVAS01Dbr.Select(s => s.TX726).First();
                    var TX727 = UHSVAS01Dbr.Select(s => s.TX727).First();
                    var TX728 = UHSVAS01Dbr.Select(s => s.TX728).First();
                    var TX729 = UHSVAS01Dbr.Select(s => s.TX729).First();
                    var TX730 = UHSVAS01Dbr.Select(s => s.TX730).First();
                    var TX731 = UHSVAS01Dbr.Select(s => s.TX731).First();
                    var TX732 = UHSVAS01Dbr.Select(s => s.TX732).First();
                    var TX733 = UHSVAS01Dbr.Select(s => s.TX733).First();
                    var TX734 = UHSVAS01Dbr.Select(s => s.TX734).First();
                    var TX735 = UHSVAS01Dbr.Select(s => s.TX735).First();
                    var TX801 = UHSVAS01Dbr.Select(s => s.TX801).First();
                    var TX802 = UHSVAS01Dbr.Select(s => s.TX802).First();
                    var TX803 = UHSVAS01Dbr.Select(s => s.TX803).First();
                    var TX804 = UHSVAS01Dbr.Select(s => s.TX804).First();
                    var TX805 = UHSVAS01Dbr.Select(s => s.TX805).First();
                    var TX806 = UHSVAS01Dbr.Select(s => s.TX806).First();
                    var TX807 = UHSVAS01Dbr.Select(s => s.TX807).First();
                    var TX808 = UHSVAS01Dbr.Select(s => s.TX808).First();
                    var TX809 = UHSVAS01Dbr.Select(s => s.TX809).First();
                    var TX810 = UHSVAS01Dbr.Select(s => s.TX810).First();
                    var TX811 = UHSVAS01Dbr.Select(s => s.TX811).First();
                    var TX812 = UHSVAS01Dbr.Select(s => s.TX812).First();
                    var TX813 = UHSVAS01Dbr.Select(s => s.TX813).First();
                    var TX814 = UHSVAS01Dbr.Select(s => s.TX814).First();
                    var TX815 = UHSVAS01Dbr.Select(s => s.TX815).First();
                    var TX816 = UHSVAS01Dbr.Select(s => s.TX816).First();
                    var TX817 = UHSVAS01Dbr.Select(s => s.TX817).First();
                    var TX818 = UHSVAS01Dbr.Select(s => s.TX818).First();
                    var TX819 = UHSVAS01Dbr.Select(s => s.TX819).First();
                    var TX820 = UHSVAS01Dbr.Select(s => s.TX820).First();
                    var TX901 = UHSVAS01Dbr.Select(s => s.TX901).First();
                    var TX902 = UHSVAS01Dbr.Select(s => s.TX902).First();
                    var TX903 = UHSVAS01Dbr.Select(s => s.TX903).First();
                    var TX904 = UHSVAS01Dbr.Select(s => s.TX904).First();
                    var TX905 = UHSVAS01Dbr.Select(s => s.TX905).First();
                    var TX906 = UHSVAS01Dbr.Select(s => s.TX906).First();
                    var TX907 = UHSVAS01Dbr.Select(s => s.TX907).First();
                    var TX908 = UHSVAS01Dbr.Select(s => s.TX908).First();
                    var TX909 = UHSVAS01Dbr.Select(s => s.TX909).First();
                    var TX910 = UHSVAS01Dbr.Select(s => s.TX910).First();
                    var TX911 = UHSVAS01Dbr.Select(s => s.TX911).First();
                    var TX912 = UHSVAS01Dbr.Select(s => s.TX912).First();
                    var TX913 = UHSVAS01Dbr.Select(s => s.TX913).First();
                    var TX914 = UHSVAS01Dbr.Select(s => s.TX914).First();
                    var TX915 = UHSVAS01Dbr.Select(s => s.TX915).First();
                    var TX916 = UHSVAS01Dbr.Select(s => s.TX916).First();
                    var TX917 = UHSVAS01Dbr.Select(s => s.TX917).First();
                    var TX918 = UHSVAS01Dbr.Select(s => s.TX918).First();
                    var TX919 = UHSVAS01Dbr.Select(s => s.TX919).First();
                    var TX920 = UHSVAS01Dbr.Select(s => s.TX920).First();

                    var chck = UHSVAS01Dbr.Select(s => s.chck).First();
                    var chckid = UHSVAS01Dbr.Select(s => s.chckid).First();
                    var chckdt = UHSVAS01Dbr.Select(s => s.chckdt).First();
                    var crdt = UHSVAS01Dbr.Select(s => s.crdt).First();
                    var eddt = UHSVAS01Dbr.Select(s => s.eddt).First();
                    var crusid = UHSVAS01Dbr.Select(s => s.crusid).First();
                    var edusid = UHSVAS01Dbr.Select(s => s.edusid).First();


                    List<uhspageitemsDb> help01 = new List<uhspageitemsDb>();
                    var chkk01 = db.agentsDbs.Where(s => s.ID == dimid).Select(s => s.agentName).Count();
                    if (chkk01 == 1)
                    {
                        uhspageitemsDb List1 = new uhspageitemsDb();
                        List1.modStr1 = db.agentsDbs.Where(s => s.ID == dimid).Select(s => s.agentName).First();
                        help01.Add(List1);
                    } else
                    {
                        uhspageitemsDb List1 = new uhspageitemsDb();
                        List1.modStr1 = null;
                        help01.Add(List1);
                    }
                    string dimgname = help01.Select(s => s.modStr1).First();

                    string assmname = db.agentsDbs.Where(s => s.ID == crusid).Select(s => s.agentName).First();
                    string supaprname = db.agentsDbs.Where(s => s.ID == chckid).Select(s => s.agentName).First();

                    string distrr = opa.DISTRICTSDbs.Where(s => s.compid == 1 && s.ID == disid).Select(s => s.district).First().ToString();
                    
                    var zperd = opb.UHSVAS01vDbs.Where(s => s.ID == data).Select(s => s.yyyymm).First();
                    var zdtc = opb.UHSVAS01vDbs.Where(s => s.ID == data).Select(s => s.yyyymmdd).First();
                    var zdte = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == zdtc).Select(s => s.dateus).First();
                    var zuser = opb.UHSVAS01vDbs.Where(s => s.ID == data).Select(s => s.usernm).First();

                    var aas01 = opb.UHSVAS01vDbs.Where(s => s.ID == data).Select(s => s.AAS01).First();
                    var aas02 = opb.UHSVAS01vDbs.Where(s => s.ID == data).Select(s => s.AAS02).First();
                    var aas03 = opb.UHSVAS01vDbs.Where(s => s.ID == data).Select(s => s.AAS03).First();
                    var aas04 = opb.UHSVAS01vDbs.Where(s => s.ID == data).Select(s => s.AAS04).First();
                    var aas05 = opb.UHSVAS01vDbs.Where(s => s.ID == data).Select(s => s.AAS05).First();
                    var aas06 = opb.UHSVAS01vDbs.Where(s => s.ID == data).Select(s => s.AAS06).First();
                    var aas07 = opb.UHSVAS01vDbs.Where(s => s.ID == data).Select(s => s.AAS07).First();
                    var aas08 = opb.UHSVAS01vDbs.Where(s => s.ID == data).Select(s => s.AAS08).First();
                    var aas91 = string.Format("{0:n1}", (Convert.ToDouble(aas01) / 50)*100);
                    var aas92 = string.Format("{0:n1}", (Convert.ToDouble(aas02) / 28)*100);
                    var aas93 = string.Format("{0:n1}", (Convert.ToDouble(aas03) / 44)*100);
                    var aas94 = string.Format("{0:n1}", (Convert.ToDouble(aas04) / 42)*100);
                    var aas95 = string.Format("{0:n1}", (Convert.ToDouble(aas05) / 50)*100);
                    var aas96 = string.Format("{0:n1}", (Convert.ToDouble(aas06) / 22)*100);
                    var aas97 = string.Format("{0:n1}", (Convert.ToDouble(aas07) / 62)*100);
                    var aas98 = string.Format("{0:n1}", (Convert.ToDouble(aas08) / 26)*100);
                    var aas99 = "0.00";
                    var aasto = opb.UHSVAS01vDbs.Where(s => s.ID == data).Select(s => s.AASTO).First();
                    var aaspc = opb.UHSVAS01vDbs.Where(s => s.ID == data).Select(s => s.AASPC).First();

                    var ls111 = opb.UHSinquriesDbs.Where(s => s.L1ID == 111).Select(s => s.ID).ToList();
                    var ls112 = opb.UHSinquriesDbs.Where(s => s.L1ID == 112).Select(s => s.ID).ToList();
                    var ls113 = opb.UHSinquriesDbs.Where(s => s.L1ID == 113).Select(s => s.ID).ToList();
                    var ls114 = opb.UHSinquriesDbs.Where(s => s.L1ID == 114).Select(s => s.ID).ToList();
                    var ls115 = opb.UHSinquriesDbs.Where(s => s.L1ID == 115).Select(s => s.ID).ToList();
                    var ls116 = opb.UHSinquriesDbs.Where(s => s.L1ID == 116).Select(s => s.ID).ToList();
                    var ls117 = opb.UHSinquriesDbs.Where(s => s.L1ID == 117).Select(s => s.ID).ToList();
                    var ls118 = opb.UHSinquriesDbs.Where(s => s.L1ID == 118).Select(s => s.ID).ToList();

                    var lo111 = opb.UHSWOT01vDbs.Where(s => s.docmid == a11 && (userTypeid == 2 || s.crusid == userid) && ls111.Contains(s.L3ID)).Count();
                    var lo112 = opb.UHSWOT01vDbs.Where(s => s.docmid == a11 && (userTypeid == 2 || s.crusid == userid) && ls112.Contains(s.L3ID)).Count();
                    var lo113 = opb.UHSWOT01vDbs.Where(s => s.docmid == a11 && (userTypeid == 2 || s.crusid == userid) && ls113.Contains(s.L3ID)).Count();
                    var lo114 = opb.UHSWOT01vDbs.Where(s => s.docmid == a11 && (userTypeid == 2 || s.crusid == userid) && ls114.Contains(s.L3ID)).Count();
                    var lo115 = opb.UHSWOT01vDbs.Where(s => s.docmid == a11 && (userTypeid == 2 || s.crusid == userid) && ls115.Contains(s.L3ID)).Count();
                    var lo116 = opb.UHSWOT01vDbs.Where(s => s.docmid == a11 && (userTypeid == 2 || s.crusid == userid) && ls116.Contains(s.L3ID)).Count();
                    var lo117 = opb.UHSWOT01vDbs.Where(s => s.docmid == a11 && (userTypeid == 2 || s.crusid == userid) && ls117.Contains(s.L3ID)).Count();
                    var lo118 = opb.UHSWOT01vDbs.Where(s => s.docmid == a11 && (userTypeid == 2 || s.crusid == userid) && ls118.Contains(s.L3ID)).Count();
                    var lotot = opb.UHSWOT01vDbs.Where(s => s.docmid == a11 && (userTypeid == 2 || s.crusid == userid)).Count();


                    var dtcr1010003 = new
                    {
                        ID = data
                     , projid = projid
                     , tskoid = tskoid
                     , dcgrid = dcgrid
                     , dctpid = dctpid
                     , tspdid = tspdid
                     , distid = disid
                     , acctid = accid
                     , userid = usrid
                     , GR101 = GR101
                     , GR102 = GR102
                     , GR103 = GR103
                     , GR104 = GR104
                     , GR105 = GR105
                     , GR106 = GR106
                     , GR107 = GR107
                     , GR108 = GR108
                     , GR109 = GR109
                     , GR110 = GR110
                     , GR111 = GR111
                     , GR112 = GR112
                     , GR113 = GR113
                     , GR114 = GR114
                     , GR115 = GR115
                     , GR116 = GR116
                     , GR117 = GR117
                     , GR118 = GR118
                     , GR119 = GR119
                     , GR120 = GR120
                     , GR121 = GR121
                     , GR122 = GR122
                     , GR123 = GR123
                     , GR124 = GR124
                     , GR125 = GR125
                     , GR126 = GR126
                     , GR127 = GR127
                     , GR128 = GR128
                     , GR129 = GR129
                     , GR130 = GR130
                     , GR201 = GR201
                     , GR202 = GR202
                     , GR203 = GR203
                     , GR204 = GR204
                     , GR205 = GR205
                     , GR206 = GR206
                     , GR207 = GR207
                     , GR208 = GR208
                     , GR209 = GR209
                     , GR210 = GR210
                     , GR211 = GR211
                     , GR212 = GR212
                     , GR213 = GR213
                     , GR214 = GR214
                     , GR215 = GR215
                     , GR216 = GR216
                     , GR217 = GR217
                     , GR218 = GR218
                     , GR219 = GR219
                     , GR220 = GR220
                     , GR301 = GR301
                     , GR302 = GR302
                     , GR303 = GR303
                     , GR304 = GR304
                     , GR305 = GR305
                     , GR306 = GR306
                     , GR307 = GR307
                     , GR308 = GR308
                     , GR309 = GR309
                     , GR310 = GR310
                     , GR311 = GR311
                     , GR312 = GR312
                     , GR313 = GR313
                     , GR314 = GR314
                     , GR315 = GR315
                     , GR316 = GR316
                     , GR317 = GR317
                     , GR318 = GR318
                     , GR319 = GR319
                     , GR320 = GR320
                     , GR321 = GR321
                     , GR322 = GR322
                     , GR323 = GR323
                     , GR324 = GR324
                     , GR325 = GR325
                     , GR401 = GR401
                     , GR402 = GR402
                     , GR403 = GR403
                     , GR404 = GR404
                     , GR405 = GR405
                     , GR406 = GR406
                     , GR407 = GR407
                     , GR408 = GR408
                     , GR409 = GR409
                     , GR410 = GR410
                     , GR411 = GR411
                     , GR412 = GR412
                     , GR413 = GR413
                     , GR414 = GR414
                     , GR415 = GR415
                     , GR416 = GR416
                     , GR417 = GR417
                     , GR418 = GR418
                     , GR419 = GR419
                     , GR420 = GR420
                     , GR421 = GR421
                     , GR422 = GR422
                     , GR423 = GR423
                     , GR424 = GR424
                     , GR425 = GR425
                     , GR501 = GR501
                     , GR502 = GR502
                     , GR503 = GR503
                     , GR504 = GR504
                     , GR505 = GR505
                     , GR506 = GR506
                     , GR507 = GR507
                     , GR508 = GR508
                     , GR509 = GR509
                     , GR510 = GR510
                     , GR511 = GR511
                     , GR512 = GR512
                     , GR513 = GR513
                     , GR514 = GR514
                     , GR515 = GR515
                     , GR516 = GR516
                     , GR517 = GR517
                     , GR518 = GR518
                     , GR519 = GR519
                     , GR520 = GR520
                     , GR521 = GR521
                     , GR522 = GR522
                     , GR523 = GR523
                     , GR524 = GR524
                     , GR525 = GR525
                     , GR526 = GR526
                     , GR527 = GR527
                     , GR528 = GR528
                     , GR529 = GR529
                     , GR530 = GR530
                     , GR601 = GR601
                     , GR602 = GR602
                     , GR603 = GR603
                     , GR604 = GR604
                     , GR605 = GR605
                     , GR606 = GR606
                     , GR607 = GR607
                     , GR608 = GR608
                     , GR609 = GR609
                     , GR610 = GR610
                     , GR611 = GR611
                     , GR612 = GR612
                     , GR613 = GR613
                     , GR614 = GR614
                     , GR615 = GR615
                     , GR616 = GR616
                     , GR617 = GR617
                     , GR618 = GR618
                     , GR619 = GR619
                     , GR620 = GR620
                     , GR701 = GR701
                     , GR702 = GR702
                     , GR703 = GR703
                     , GR704 = GR704
                     , GR705 = GR705
                     , GR706 = GR706
                     , GR707 = GR707
                     , GR708 = GR708
                     , GR709 = GR709
                     , GR710 = GR710
                     , GR711 = GR711
                     , GR712 = GR712
                     , GR713 = GR713
                     , GR714 = GR714
                     , GR715 = GR715
                     , GR716 = GR716
                     , GR717 = GR717
                     , GR718 = GR718
                     , GR719 = GR719
                     , GR720 = GR720
                     , GR721 = GR721
                     , GR722 = GR722
                     , GR723 = GR723
                     , GR724 = GR724
                     , GR725 = GR725
                     , GR726 = GR726
                     , GR727 = GR727
                     , GR728 = GR728
                     , GR729 = GR729
                     , GR730 = GR730
                     , GR731 = GR731
                     , GR732 = GR732
                     , GR733 = GR733
                     , GR734 = GR734
                     , GR735 = GR735
                     , GR801 = GR801
                     , GR802 = GR802
                     , GR803 = GR803
                     , GR804 = GR804
                     , GR805 = GR805
                     , GR806 = GR806
                     , GR807 = GR807
                     , GR808 = GR808
                     , GR809 = GR809
                     , GR810 = GR810
                     , GR811 = GR811
                     , GR812 = GR812
                     , GR813 = GR813
                     , GR814 = GR814
                     , GR815 = GR815
                     , GR816 = GR816
                     , GR817 = GR817
                     , GR818 = GR818
                     , GR819 = GR819
                     , GR820 = GR820
                     , GR901 = GR901
                     , GR902 = GR902
                     , GR903 = GR903
                     , GR904 = GR904
                     , GR905 = GR905
                     , GR906 = GR906
                     , GR907 = GR907
                     , GR908 = GR908
                     , GR909 = GR909
                     , GR910 = GR910
                     , GR911 = GR911
                     , GR912 = GR912
                     , GR913 = GR913
                     , GR914 = GR914
                     , GR915 = GR915
                     , GR916 = GR916
                     , GR917 = GR917
                     , GR918 = GR918
                     , GR919 = GR919
                     , GR920 = GR920
                     , TX101 = TX101
                     , TX102 = TX102
                     , TX103 = TX103
                     , TX104 = TX104
                     , TX105 = TX105
                     , TX106 = TX106
                     , TX107 = TX107
                     , TX108 = TX108
                     , TX109 = TX109
                     , TX110 = TX110
                     , TX111 = TX111
                     , TX112 = TX112
                     , TX113 = TX113
                     , TX114 = TX114
                     , TX115 = TX115
                     , TX116 = TX116
                     , TX117 = TX117
                     , TX118 = TX118
                     , TX119 = TX119
                     , TX120 = TX120
                     , TX121 = TX121
                     , TX122 = TX122
                     , TX123 = TX123
                     , TX124 = TX124
                     , TX125 = TX125
                     , TX126 = TX126
                     , TX127 = TX127
                     , TX128 = TX128
                     , TX129 = TX129
                     , TX130 = TX130
                     , TX201 = TX201
                     , TX202 = TX202
                     , TX203 = TX203
                     , TX204 = TX204
                     , TX205 = TX205
                     , TX206 = TX206
                     , TX207 = TX207
                     , TX208 = TX208
                     , TX209 = TX209
                     , TX210 = TX210
                     , TX211 = TX211
                     , TX212 = TX212
                     , TX213 = TX213
                     , TX214 = TX214
                     , TX215 = TX215
                     , TX216 = TX216
                     , TX217 = TX217
                     , TX218 = TX218
                     , TX219 = TX219
                     , TX220 = TX220
                     , TX301 = TX301
                     , TX302 = TX302
                     , TX303 = TX303
                     , TX304 = TX304
                     , TX305 = TX305
                     , TX306 = TX306
                     , TX307 = TX307
                     , TX308 = TX308
                     , TX309 = TX309
                     , TX310 = TX310
                     , TX311 = TX311
                     , TX312 = TX312
                     , TX313 = TX313
                     , TX314 = TX314
                     , TX315 = TX315
                     , TX316 = TX316
                     , TX317 = TX317
                     , TX318 = TX318
                     , TX319 = TX319
                     , TX320 = TX320
                     , TX321 = TX321
                     , TX322 = TX322
                     , TX323 = TX323
                     , TX324 = TX324
                     , TX325 = TX325
                     , TX401 = TX401
                     , TX402 = TX402
                     , TX403 = TX403
                     , TX404 = TX404
                     , TX405 = TX405
                     , TX406 = TX406
                     , TX407 = TX407
                     , TX408 = TX408
                     , TX409 = TX409
                     , TX410 = TX410
                     , TX411 = TX411
                     , TX412 = TX412
                     , TX413 = TX413
                     , TX414 = TX414
                     , TX415 = TX415
                     , TX416 = TX416
                     , TX417 = TX417
                     , TX418 = TX418
                     , TX419 = TX419
                     , TX420 = TX420
                     , TX421 = TX421
                     , TX422 = TX422
                     , TX423 = TX423
                     , TX424 = TX424
                     , TX425 = TX425
                     , TX501 = TX501
                     , TX502 = TX502
                     , TX503 = TX503
                     , TX504 = TX504
                     , TX505 = TX505
                     , TX506 = TX506
                     , TX507 = TX507
                     , TX508 = TX508
                     , TX509 = TX509
                     , TX510 = TX510
                     , TX511 = TX511
                     , TX512 = TX512
                     , TX513 = TX513
                     , TX514 = TX514
                     , TX515 = TX515
                     , TX516 = TX516
                     , TX517 = TX517
                     , TX518 = TX518
                     , TX519 = TX519
                     , TX520 = TX520
                     , TX521 = TX521
                     , TX522 = TX522
                     , TX523 = TX523
                     , TX524 = TX524
                     , TX525 = TX525
                     , TX526 = TX526
                     , TX527 = TX527
                     , TX528 = TX528
                     , TX529 = TX529
                     , TX530 = TX530
                     , TX601 = TX601
                     , TX602 = TX602
                     , TX603 = TX603
                     , TX604 = TX604
                     , TX605 = TX605
                     , TX606 = TX606
                     , TX607 = TX607
                     , TX608 = TX608
                     , TX609 = TX609
                     , TX610 = TX610
                     , TX611 = TX611
                     , TX612 = TX612
                     , TX613 = TX613
                     , TX614 = TX614
                     , TX615 = TX615
                     , TX616 = TX616
                     , TX617 = TX617
                     , TX618 = TX618
                     , TX619 = TX619
                     , TX620 = TX620
                     , TX701 = TX701
                     , TX702 = TX702
                     , TX703 = TX703
                     , TX704 = TX704
                     , TX705 = TX705
                     , TX706 = TX706
                     , TX707 = TX707
                     , TX708 = TX708
                     , TX709 = TX709
                     , TX710 = TX710
                     , TX711 = TX711
                     , TX712 = TX712
                     , TX713 = TX713
                     , TX714 = TX714
                     , TX715 = TX715
                     , TX716 = TX716
                     , TX717 = TX717
                     , TX718 = TX718
                     , TX719 = TX719
                     , TX720 = TX720
                     , TX721 = TX721
                     , TX722 = TX722
                     , TX723 = TX723
                     , TX724 = TX724
                     , TX725 = TX725
                     , TX726 = TX726
                     , TX727 = TX727
                     , TX728 = TX728
                     , TX729 = TX729
                     , TX730 = TX730
                     , TX731 = TX731
                     , TX732 = TX732
                     , TX733 = TX733
                     , TX734 = TX734
                     , TX735 = TX735
                     , TX801 = TX801
                     , TX802 = TX802
                     , TX803 = TX803
                     , TX804 = TX804
                     , TX805 = TX805
                     , TX806 = TX806
                     , TX807 = TX807
                     , TX808 = TX808
                     , TX809 = TX809
                     , TX810 = TX810
                     , TX811 = TX811
                     , TX812 = TX812
                     , TX813 = TX813
                     , TX814 = TX814
                     , TX815 = TX815
                     , TX816 = TX816
                     , TX817 = TX817
                     , TX818 = TX818
                     , TX819 = TX819
                     , TX820 = TX820
                     , TX901 = TX901
                     , TX902 = TX902
                     , TX903 = TX903
                     , TX904 = TX904
                     , TX905 = TX905
                     , TX906 = TX906
                     , TX907 = TX907
                     , TX908 = TX908
                     , TX909 = TX909
                     , TX910 = TX910
                     , TX911 = TX911
                     , TX912 = TX912
                     , TX913 = TX913
                     , TX914 = TX914
                     , TX915 = TX915
                     , TX916 = TX916
                     , TX917 = TX917
                     , TX918 = TX918
                     , TX919 = TX919
                     , TX920 = TX920
                     , chck = chck
                     , chckid = chckid
                     , chckdt = chckdt
                     , crdt = crdt
                     , eddt = eddt
                     , crusid = crusid
                     , edusid = userid
                     , actype = 3
                     , zdist = distrr
                     , zperd = zperd
                     , zdate = zdte
                     , zuser = zuser
                     , supap = supaprname
                     , dimgid = dimid
                     , dimgnm = dimgname
                     , assmnm = assmname
                     , AAS01 = aas01
                     , AAS02 = aas02
                     , AAS03 = aas03
                     , AAS04 = aas04
                     , AAS05 = aas05
                     , AAS06 = aas06
                     , AAS07 = aas07
                     , AAS08 = aas08
                     , AAS91 = aas91
                     , AAS92 = aas92
                     , AAS93 = aas93
                     , AAS94 = aas94
                     , AAS95 = aas95
                     , AAS96 = aas96
                     , AAS97 = aas97
                     , AAS98 = aas98
                     , AAS99 = aas99
                     , AASTO = aasto
                     , AASPC = aaspc
                     , lo111 = lo111
                     , lo112 = lo112
                     , lo113 = lo113
                     , lo114 = lo114
                     , lo115 = lo115
                     , lo116 = lo116
                     , lo117 = lo117
                     , lo118 = lo118
                     , lotot = lotot
                    };

                    ViewBag.dtcr1010003 = dtcr1010003;
                    return View();
            }
            else
            {
                var dtcr1010003 = new
                {

                };
                ViewBag.dtcr1010003 = dtcr1010003;
                return View();
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
