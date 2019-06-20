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
    public class uhsgw6sController : Controller
    {
        private CRUDdataModel db = new CRUDdataModel();
        private VIEWdataModel dbv = new VIEWdataModel();
        private DATAOPAdataModel opa = new DATAOPAdataModel();
        private DATAOPBdataModel opb = new DATAOPBdataModel();

        public ActionResult getCrPar1010001(int distid, int acctid, int actype, string docid)
        {
            // get user logged ID string
            string CurrentLoginID = User.Identity.GetUserId().ToString();

            // get user logged ID int
            int userid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.ID).First();          
            ViewBag.userIds = userid;
            // get userTypeid integer
            int userTypeid = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.userType).First();
            ViewBag.userTypeID = userTypeid;

            string userName = db.agentsDbs.Where(s => s.userID == CurrentLoginID).Select(s => s.agentName).First();
            ViewBag.userNm = userName;

            var dts = DateTime.Now.ToString("yyyyMMdd");
            int dt1 = int.Parse(dts);
            string dt2 = DateTime.Now.ToString("hhmmss");

            int dtt = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.wstymd).First();
            string dtt1 = dtt.ToString();

            int daynbr = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.daywnm).First();
            ViewBag.daynbr = daynbr;

            string wk1 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.weekDesc).First().ToString();
            string wk2 = opa.DATAOPATIME_FRAMEDbs.Where(s => s.dateYMD == dt1).Select(s => s.WeekNbr).First().ToString();

            var dsqa = "D" + distid.ToString();
            string dsq = dsqa;

            var check1 = opa.UHSGWL01Dbs.Where(s => s.ID.Contains(dtt1) && s.ID.Contains(wk2) && s.ID.Contains(dsq)).Count();

            string docNewid = dtt1 + wk2 + "D" + distid + "A" + acctid + "GR1010DC1010001";

            if(actype == 2)
            {
                string district = opa.DISTRICTSDbs.Where(s => s.compid == 1 && s.ID == distid).Select(s => s.district).First().ToString();
                //var check1 = opa.UHSGWL01Dbs.Where(s => s.ID.Contains(docNewid)).Count();
                if (check1 < 1)
                {
                    var dtcr1010001 = new
                    {
                        docid = docNewid
                     , userid = userid
                     , actype = 2
                     , zdist = district
                     , zperd = dtt1
                     , zweek = wk1
                     , zuser = userName
                    };
                    return Json(dtcr1010001, JsonRequestBehavior.AllowGet);
                }
                else
                {                  
                    var dtcr1010001 = new {
                        ID = 0
                      , zdist = district
                      , zweek = wk1
                      , zuser = userName
                    };
                    return Json(dtcr1010001, JsonRequestBehavior.AllowGet);
                }
            }
            else if (actype == 3)
            {

                var ont1 = opa.UHSGWL01Dbs.Where(s => s.distid == distid).OrderByDescending(s => s.crdt).Select(s => s.crdt).First();
                var ont2 = opa.UHSGWL01Dbs.Where(s => s.distid == distid && s.crdt == ont1).Select(s => s.ID).First();
                List<UHSGWL01Db> UHSGWL01Dbr = opa.UHSGWL01Dbs.Where(s => s.ID == ont2).ToList();
                ViewBag.wchk1 = opa.DISTRICTSDbs.Where(s => s.ID == distid).Select(s => s.wchk).First();
                string dID = ont2;
                var projid = UHSGWL01Dbr.Select(s => s.projid).First();
                var tskoid = UHSGWL01Dbr.Select(s => s.tskoid).First();
                var dcgrid = UHSGWL01Dbr.Select(s => s.dcgrid).First();
                var dctpid = UHSGWL01Dbr.Select(s => s.dctpid).First();
                var tspdid = UHSGWL01Dbr.Select(s => s.tspdid).First();
                var disid = UHSGWL01Dbr.Select(s => s.distid).First();
                var accid = UHSGWL01Dbr.Select(s => s.acctid).First();
                var usrid = UHSGWL01Dbr.Select(s => s.userid).First();
                var tstp011 = UHSGWL01Dbr.Select(s => s.tstp011).First();
                var tstp012 = UHSGWL01Dbr.Select(s => s.tstp012).First();
                var tstp013 = UHSGWL01Dbr.Select(s => s.tstp013).First();
                var tstp014 = UHSGWL01Dbr.Select(s => s.tstp014).First();
                var tstp015 = UHSGWL01Dbr.Select(s => s.tstp015).First();
                var tstp016 = UHSGWL01Dbr.Select(s => s.tstp016).First();
                var tstp017 = UHSGWL01Dbr.Select(s => s.tstp017).First();
                var tstp021 = UHSGWL01Dbr.Select(s => s.tstp021).First();
                var tstp022 = UHSGWL01Dbr.Select(s => s.tstp022).First();
                var tstp023 = UHSGWL01Dbr.Select(s => s.tstp023).First();
                var tstp024 = UHSGWL01Dbr.Select(s => s.tstp024).First();
                var tstp025 = UHSGWL01Dbr.Select(s => s.tstp025).First();
                var tstp026 = UHSGWL01Dbr.Select(s => s.tstp026).First();
                var tstp027 = UHSGWL01Dbr.Select(s => s.tstp027).First();
                var tstp031 = UHSGWL01Dbr.Select(s => s.tstp031).First();
                var tstp032 = UHSGWL01Dbr.Select(s => s.tstp032).First();
                var tstp033 = UHSGWL01Dbr.Select(s => s.tstp033).First();
                var tstp034 = UHSGWL01Dbr.Select(s => s.tstp034).First();
                var tstp035 = UHSGWL01Dbr.Select(s => s.tstp035).First();
                var tstp036 = UHSGWL01Dbr.Select(s => s.tstp036).First();
                var tstp037 = UHSGWL01Dbr.Select(s => s.tstp037).First();
                var tstp041 = UHSGWL01Dbr.Select(s => s.tstp041).First();
                var tstp042 = UHSGWL01Dbr.Select(s => s.tstp042).First();
                var tstp043 = UHSGWL01Dbr.Select(s => s.tstp043).First();
                var tstp044 = UHSGWL01Dbr.Select(s => s.tstp044).First();
                var tstp045 = UHSGWL01Dbr.Select(s => s.tstp045).First();
                var tstp046 = UHSGWL01Dbr.Select(s => s.tstp046).First();
                var tstp047 = UHSGWL01Dbr.Select(s => s.tstp047).First();
                var tstp051 = UHSGWL01Dbr.Select(s => s.tstp051).First();
                var tstp052 = UHSGWL01Dbr.Select(s => s.tstp052).First();
                var tstp053 = UHSGWL01Dbr.Select(s => s.tstp053).First();
                var tstp054 = UHSGWL01Dbr.Select(s => s.tstp054).First();
                var tstp055 = UHSGWL01Dbr.Select(s => s.tstp055).First();
                var tstp056 = UHSGWL01Dbr.Select(s => s.tstp056).First();
                var tstp057 = UHSGWL01Dbr.Select(s => s.tstp057).First();
                var tstp061 = UHSGWL01Dbr.Select(s => s.tstp061).First();
                var tstp062 = UHSGWL01Dbr.Select(s => s.tstp062).First();
                var tstp063 = UHSGWL01Dbr.Select(s => s.tstp063).First();
                var tstp064 = UHSGWL01Dbr.Select(s => s.tstp064).First();
                var tstp065 = UHSGWL01Dbr.Select(s => s.tstp065).First();
                var tstp066 = UHSGWL01Dbr.Select(s => s.tstp066).First();
                var tstp067 = UHSGWL01Dbr.Select(s => s.tstp067).First();
                var tstp071 = UHSGWL01Dbr.Select(s => s.tstp071).First();
                var tstp072 = UHSGWL01Dbr.Select(s => s.tstp072).First();
                var tstp073 = UHSGWL01Dbr.Select(s => s.tstp073).First();
                var tstp074 = UHSGWL01Dbr.Select(s => s.tstp074).First();
                var tstp075 = UHSGWL01Dbr.Select(s => s.tstp075).First();
                var tstp076 = UHSGWL01Dbr.Select(s => s.tstp076).First();
                var tstp077 = UHSGWL01Dbr.Select(s => s.tstp077).First();
                var tstp081 = UHSGWL01Dbr.Select(s => s.tstp081).First();
                var tstp082 = UHSGWL01Dbr.Select(s => s.tstp082).First();
                var tstp083 = UHSGWL01Dbr.Select(s => s.tstp083).First();
                var tstp084 = UHSGWL01Dbr.Select(s => s.tstp084).First();
                var tstp085 = UHSGWL01Dbr.Select(s => s.tstp085).First();
                var tstp086 = UHSGWL01Dbr.Select(s => s.tstp086).First();
                var tstp087 = UHSGWL01Dbr.Select(s => s.tstp087).First();
                var tstp091 = UHSGWL01Dbr.Select(s => s.tstp091).First();
                var tstp092 = UHSGWL01Dbr.Select(s => s.tstp092).First();
                var tstp093 = UHSGWL01Dbr.Select(s => s.tstp093).First();
                var tstp094 = UHSGWL01Dbr.Select(s => s.tstp094).First();
                var tstp095 = UHSGWL01Dbr.Select(s => s.tstp095).First();
                var tstp096 = UHSGWL01Dbr.Select(s => s.tstp096).First();
                var tstp097 = UHSGWL01Dbr.Select(s => s.tstp097).First();
                var tstp101 = UHSGWL01Dbr.Select(s => s.tstp101).First();
                var tstp102 = UHSGWL01Dbr.Select(s => s.tstp102).First();
                var tstp103 = UHSGWL01Dbr.Select(s => s.tstp103).First();
                var tstp104 = UHSGWL01Dbr.Select(s => s.tstp104).First();
                var tstp105 = UHSGWL01Dbr.Select(s => s.tstp105).First();
                var tstp106 = UHSGWL01Dbr.Select(s => s.tstp106).First();
                var tstp107 = UHSGWL01Dbr.Select(s => s.tstp107).First();
                var tstp111 = UHSGWL01Dbr.Select(s => s.tstp111).First();
                var tstp112 = UHSGWL01Dbr.Select(s => s.tstp112).First();
                var tstp113 = UHSGWL01Dbr.Select(s => s.tstp113).First();
                var tstp114 = UHSGWL01Dbr.Select(s => s.tstp114).First();
                var tstp115 = UHSGWL01Dbr.Select(s => s.tstp115).First();
                var tstp116 = UHSGWL01Dbr.Select(s => s.tstp116).First();
                var tstp117 = UHSGWL01Dbr.Select(s => s.tstp117).First();
                var tstp121 = UHSGWL01Dbr.Select(s => s.tstp121).First();
                var tstp122 = UHSGWL01Dbr.Select(s => s.tstp122).First();
                var tstp123 = UHSGWL01Dbr.Select(s => s.tstp123).First();
                var tstp124 = UHSGWL01Dbr.Select(s => s.tstp124).First();
                var tstp125 = UHSGWL01Dbr.Select(s => s.tstp125).First();
                var tstp126 = UHSGWL01Dbr.Select(s => s.tstp126).First();
                var tstp127 = UHSGWL01Dbr.Select(s => s.tstp127).First();
                var tstp131 = UHSGWL01Dbr.Select(s => s.tstp131).First();
                var tstp132 = UHSGWL01Dbr.Select(s => s.tstp132).First();
                var tstp133 = UHSGWL01Dbr.Select(s => s.tstp133).First();
                var tstp134 = UHSGWL01Dbr.Select(s => s.tstp134).First();
                var tstp135 = UHSGWL01Dbr.Select(s => s.tstp135).First();
                var tstp136 = UHSGWL01Dbr.Select(s => s.tstp136).First();
                var tstp137 = UHSGWL01Dbr.Select(s => s.tstp137).First();
                var tstp141 = UHSGWL01Dbr.Select(s => s.tstp141).First();
                var tstp142 = UHSGWL01Dbr.Select(s => s.tstp142).First();
                var tstp143 = UHSGWL01Dbr.Select(s => s.tstp143).First();
                var tstp144 = UHSGWL01Dbr.Select(s => s.tstp144).First();
                var tstp145 = UHSGWL01Dbr.Select(s => s.tstp145).First();
                var tstp146 = UHSGWL01Dbr.Select(s => s.tstp146).First();
                var tstp147 = UHSGWL01Dbr.Select(s => s.tstp147).First();
                var tstp151 = UHSGWL01Dbr.Select(s => s.tstp151).First();
                var tstp152 = UHSGWL01Dbr.Select(s => s.tstp152).First();
                var tstp153 = UHSGWL01Dbr.Select(s => s.tstp153).First();
                var tstp154 = UHSGWL01Dbr.Select(s => s.tstp154).First();
                var tstp155 = UHSGWL01Dbr.Select(s => s.tstp155).First();
                var tstp156 = UHSGWL01Dbr.Select(s => s.tstp156).First();
                var tstp157 = UHSGWL01Dbr.Select(s => s.tstp157).First();
                var tstp161 = UHSGWL01Dbr.Select(s => s.tstp161).First();
                var tstp162 = UHSGWL01Dbr.Select(s => s.tstp162).First();
                var tstp163 = UHSGWL01Dbr.Select(s => s.tstp163).First();
                var tstp164 = UHSGWL01Dbr.Select(s => s.tstp164).First();
                var tstp165 = UHSGWL01Dbr.Select(s => s.tstp165).First();
                var tstp166 = UHSGWL01Dbr.Select(s => s.tstp166).First();
                var tstp167 = UHSGWL01Dbr.Select(s => s.tstp167).First();
                var tstp171 = UHSGWL01Dbr.Select(s => s.tstp171).First();
                var tstp172 = UHSGWL01Dbr.Select(s => s.tstp172).First();
                var tstp173 = UHSGWL01Dbr.Select(s => s.tstp173).First();
                var tstp174 = UHSGWL01Dbr.Select(s => s.tstp174).First();
                var tstp175 = UHSGWL01Dbr.Select(s => s.tstp175).First();
                var tstp176 = UHSGWL01Dbr.Select(s => s.tstp176).First();
                var tstp177 = UHSGWL01Dbr.Select(s => s.tstp177).First();
                var tstp181 = UHSGWL01Dbr.Select(s => s.tstp181).First();
                var tstp182 = UHSGWL01Dbr.Select(s => s.tstp182).First();
                var tstp183 = UHSGWL01Dbr.Select(s => s.tstp183).First();
                var tstp184 = UHSGWL01Dbr.Select(s => s.tstp184).First();
                var tstp185 = UHSGWL01Dbr.Select(s => s.tstp185).First();
                var tstp186 = UHSGWL01Dbr.Select(s => s.tstp186).First();
                var tstp187 = UHSGWL01Dbr.Select(s => s.tstp187).First();
                var ts6s011 = UHSGWL01Dbr.Select(s => s.ts6s011).First();
                var ts6s012 = UHSGWL01Dbr.Select(s => s.ts6s012).First();
                var ts6s013 = UHSGWL01Dbr.Select(s => s.ts6s013).First();
                var ts6s014 = UHSGWL01Dbr.Select(s => s.ts6s014).First();
                var ts6s015 = UHSGWL01Dbr.Select(s => s.ts6s015).First();
                var ts6s016 = UHSGWL01Dbr.Select(s => s.ts6s016).First();
                var ts6s017 = UHSGWL01Dbr.Select(s => s.ts6s017).First();
                var ts6s021 = UHSGWL01Dbr.Select(s => s.ts6s021).First();
                var ts6s022 = UHSGWL01Dbr.Select(s => s.ts6s022).First();
                var ts6s023 = UHSGWL01Dbr.Select(s => s.ts6s023).First();
                var ts6s024 = UHSGWL01Dbr.Select(s => s.ts6s024).First();
                var ts6s025 = UHSGWL01Dbr.Select(s => s.ts6s025).First();
                var ts6s026 = UHSGWL01Dbr.Select(s => s.ts6s026).First();
                var ts6s027 = UHSGWL01Dbr.Select(s => s.ts6s027).First();
                var ts6s031 = UHSGWL01Dbr.Select(s => s.ts6s031).First();
                var ts6s032 = UHSGWL01Dbr.Select(s => s.ts6s032).First();
                var ts6s033 = UHSGWL01Dbr.Select(s => s.ts6s033).First();
                var ts6s034 = UHSGWL01Dbr.Select(s => s.ts6s034).First();
                var ts6s035 = UHSGWL01Dbr.Select(s => s.ts6s035).First();
                var ts6s036 = UHSGWL01Dbr.Select(s => s.ts6s036).First();
                var ts6s037 = UHSGWL01Dbr.Select(s => s.ts6s037).First();
                var ts6s041 = UHSGWL01Dbr.Select(s => s.ts6s041).First();
                var ts6s042 = UHSGWL01Dbr.Select(s => s.ts6s042).First();
                var ts6s043 = UHSGWL01Dbr.Select(s => s.ts6s043).First();
                var ts6s044 = UHSGWL01Dbr.Select(s => s.ts6s044).First();
                var ts6s045 = UHSGWL01Dbr.Select(s => s.ts6s045).First();
                var ts6s046 = UHSGWL01Dbr.Select(s => s.ts6s046).First();
                var ts6s047 = UHSGWL01Dbr.Select(s => s.ts6s047).First();
                var ts6s051 = UHSGWL01Dbr.Select(s => s.ts6s051).First();
                var ts6s052 = UHSGWL01Dbr.Select(s => s.ts6s052).First();
                var ts6s053 = UHSGWL01Dbr.Select(s => s.ts6s053).First();
                var ts6s054 = UHSGWL01Dbr.Select(s => s.ts6s054).First();
                var ts6s055 = UHSGWL01Dbr.Select(s => s.ts6s055).First();
                var ts6s056 = UHSGWL01Dbr.Select(s => s.ts6s056).First();
                var ts6s057 = UHSGWL01Dbr.Select(s => s.ts6s057).First();
                var ts6s061 = UHSGWL01Dbr.Select(s => s.ts6s061).First();
                var ts6s062 = UHSGWL01Dbr.Select(s => s.ts6s062).First();
                var ts6s063 = UHSGWL01Dbr.Select(s => s.ts6s063).First();
                var ts6s064 = UHSGWL01Dbr.Select(s => s.ts6s064).First();
                var ts6s065 = UHSGWL01Dbr.Select(s => s.ts6s065).First();
                var ts6s066 = UHSGWL01Dbr.Select(s => s.ts6s066).First();
                var ts6s067 = UHSGWL01Dbr.Select(s => s.ts6s067).First();
                var ts6s071 = UHSGWL01Dbr.Select(s => s.ts6s071).First();
                var ts6s072 = UHSGWL01Dbr.Select(s => s.ts6s072).First();
                var ts6s073 = UHSGWL01Dbr.Select(s => s.ts6s073).First();
                var ts6s074 = UHSGWL01Dbr.Select(s => s.ts6s074).First();
                var ts6s075 = UHSGWL01Dbr.Select(s => s.ts6s075).First();
                var ts6s076 = UHSGWL01Dbr.Select(s => s.ts6s076).First();
                var ts6s077 = UHSGWL01Dbr.Select(s => s.ts6s077).First();
                var ts6s081 = UHSGWL01Dbr.Select(s => s.ts6s081).First();
                var ts6s082 = UHSGWL01Dbr.Select(s => s.ts6s082).First();
                var ts6s083 = UHSGWL01Dbr.Select(s => s.ts6s083).First();
                var ts6s084 = UHSGWL01Dbr.Select(s => s.ts6s084).First();
                var ts6s085 = UHSGWL01Dbr.Select(s => s.ts6s085).First();
                var ts6s086 = UHSGWL01Dbr.Select(s => s.ts6s086).First();
                var ts6s087 = UHSGWL01Dbr.Select(s => s.ts6s087).First();
                var ts6s091 = UHSGWL01Dbr.Select(s => s.ts6s091).First();
                var ts6s092 = UHSGWL01Dbr.Select(s => s.ts6s092).First();
                var ts6s093 = UHSGWL01Dbr.Select(s => s.ts6s093).First();
                var ts6s094 = UHSGWL01Dbr.Select(s => s.ts6s094).First();
                var ts6s095 = UHSGWL01Dbr.Select(s => s.ts6s095).First();
                var ts6s096 = UHSGWL01Dbr.Select(s => s.ts6s096).First();
                var ts6s097 = UHSGWL01Dbr.Select(s => s.ts6s097).First();
                var ts6s101 = UHSGWL01Dbr.Select(s => s.ts6s101).First();
                var ts6s102 = UHSGWL01Dbr.Select(s => s.ts6s102).First();
                var ts6s103 = UHSGWL01Dbr.Select(s => s.ts6s103).First();
                var ts6s104 = UHSGWL01Dbr.Select(s => s.ts6s104).First();
                var ts6s105 = UHSGWL01Dbr.Select(s => s.ts6s105).First();
                var ts6s106 = UHSGWL01Dbr.Select(s => s.ts6s106).First();
                var ts6s107 = UHSGWL01Dbr.Select(s => s.ts6s107).First();
                var ts6s111 = UHSGWL01Dbr.Select(s => s.ts6s111).First();
                var ts6s112 = UHSGWL01Dbr.Select(s => s.ts6s112).First();
                var ts6s113 = UHSGWL01Dbr.Select(s => s.ts6s113).First();
                var ts6s114 = UHSGWL01Dbr.Select(s => s.ts6s114).First();
                var ts6s115 = UHSGWL01Dbr.Select(s => s.ts6s115).First();
                var ts6s116 = UHSGWL01Dbr.Select(s => s.ts6s116).First();
                var ts6s117 = UHSGWL01Dbr.Select(s => s.ts6s117).First();
                var chck = UHSGWL01Dbr.Select(s => s.chck).First();
                var chckid = UHSGWL01Dbr.Select(s => s.chckid).First();
                var chckdt = UHSGWL01Dbr.Select(s => s.chckdt).First();
                var crdt = UHSGWL01Dbr.Select(s => s.crdt).First();
                var eddt = UHSGWL01Dbr.Select(s => s.eddt).First();
                var crusid = UHSGWL01Dbr.Select(s => s.crusid).First();
                var edusid = UHSGWL01Dbr.Select(s => s.edusid).First();
                string supaprname = db.agentsDbs.Where(s => s.ID == chckid).Select(s => s.agentName).First();      
                string distrr = opa.DISTRICTSDbs.Where(s => s.compid == 1 && s.ID == disid).Select(s => s.district).First().ToString();         
                var zperd = opb.UHSGWL01vDbs.Where(s => s.ID == ont2).Select(s => s.yyyymm).First();
                var zweek = opb.UHSGWL01vDbs.Where(s => s.ID == ont2).Select(s => s.weekds).First();
                var zuser = opb.UHSGWL01vDbs.Where(s => s.ID == ont2).Select(s => s.usernm).First();
                var dtcr1010001 = new
                {
                   ID = ont2
                 , projid = projid
                 , tskoid = tskoid
                 , dcgrid = dcgrid
                 , dctpid = dctpid
                 , tspdid = tspdid
                 , distid = disid
                 , acctid = accid
                 , userid = usrid 
                 , tstp011 = tstp011
                 , tstp012 = tstp012
                 , tstp013 = tstp013
                 , tstp014 = tstp014
                 , tstp015 = tstp015
                 , tstp016 = tstp016
                 , tstp017 = tstp017
                 , tstp021 = tstp021
                 , tstp022 = tstp022
                 , tstp023 = tstp023
                 , tstp024 = tstp024
                 , tstp025 = tstp025
                 , tstp026 = tstp026
                 , tstp027 = tstp027
                 , tstp031 = tstp031
                 , tstp032 = tstp032
                 , tstp033 = tstp033
                 , tstp034 = tstp034
                 , tstp035 = tstp035
                 , tstp036 = tstp036
                 , tstp037 = tstp037
                 , tstp041 = tstp041
                 , tstp042 = tstp042
                 , tstp043 = tstp043
                 , tstp044 = tstp044
                 , tstp045 = tstp045
                 , tstp046 = tstp046
                 , tstp047 = tstp047 
                 , tstp051 = tstp051
                 , tstp052 = tstp052
                 , tstp053 = tstp053
                 , tstp054 = tstp054
                 , tstp055 = tstp055
                 , tstp056 = tstp056
                 , tstp057 = tstp057 
                 , tstp061 = tstp061
                 , tstp062 = tstp062
                 , tstp063 = tstp063
                 , tstp064 = tstp064
                 , tstp065 = tstp065
                 , tstp066 = tstp066
                 , tstp067 = tstp067
                 , tstp071 = tstp071
                 , tstp072 = tstp072
                 , tstp073 = tstp073
                 , tstp074 = tstp074
                 , tstp075 = tstp075
                 , tstp076 = tstp076
                 , tstp077 = tstp077 
                 , tstp081 = tstp081
                 , tstp082 = tstp082
                 , tstp083 = tstp083
                 , tstp084 = tstp084
                 , tstp085 = tstp085
                 , tstp086 = tstp086
                 , tstp087 = tstp087 
                 , tstp091 = tstp091
                 , tstp092 = tstp092
                 , tstp093 = tstp093
                 , tstp094 = tstp094
                 , tstp095 = tstp095
                 , tstp096 = tstp096
                 , tstp097 = tstp097
                 , tstp101 = tstp101
                 , tstp102 = tstp102
                 , tstp103 = tstp103
                 , tstp104 = tstp104
                 , tstp105 = tstp105
                 , tstp106 = tstp106
                 , tstp107 = tstp107 
                 , tstp111 = tstp111
                 , tstp112 = tstp112
                 , tstp113 = tstp113
                 , tstp114 = tstp114
                 , tstp115 = tstp115
                 , tstp116 = tstp116
                 , tstp117 = tstp117
                 , tstp121 = tstp121
                 , tstp122 = tstp122
                 , tstp123 = tstp123
                 , tstp124 = tstp124
                 , tstp125 = tstp125
                 , tstp126 = tstp126
                 , tstp127 = tstp127
                 , tstp131 = tstp131
                 , tstp132 = tstp132
                 , tstp133 = tstp133
                 , tstp134 = tstp134
                 , tstp135 = tstp135
                 , tstp136 = tstp136
                 , tstp137 = tstp137 
                 , tstp141 = tstp141
                 , tstp142 = tstp142
                 , tstp143 = tstp143
                 , tstp144 = tstp144
                 , tstp145 = tstp145
                 , tstp146 = tstp146
                 , tstp147 = tstp147 
                 , tstp151 = tstp151
                 , tstp152 = tstp152
                 , tstp153 = tstp153
                 , tstp154 = tstp154
                 , tstp155 = tstp155
                 , tstp156 = tstp156
                 , tstp157 = tstp157 
                 , tstp161 = tstp161
                 , tstp162 = tstp162
                 , tstp163 = tstp163
                 , tstp164 = tstp164
                 , tstp165 = tstp165
                 , tstp166 = tstp166
                 , tstp167 = tstp167 
                 , tstp171 = tstp171
                 , tstp172 = tstp172
                 , tstp173 = tstp173
                 , tstp174 = tstp174
                 , tstp175 = tstp175
                 , tstp176 = tstp176
                 , tstp177 = tstp177 
                 , tstp181 = tstp181
                 , tstp182 = tstp182
                 , tstp183 = tstp183
                 , tstp184 = tstp184
                 , tstp185 = tstp185
                 , tstp186 = tstp186
                 , tstp187 = tstp187
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
                 , zweek = wk1
                 , zuser = zuser
                 , supap = supaprname
                 , ts6s011 = ts6s011
                 , ts6s012 = ts6s012
                 , ts6s013 = ts6s013
                 , ts6s014 = ts6s014
                 , ts6s015 = ts6s015
                 , ts6s016 = ts6s016
                 , ts6s017 = ts6s017
                 , ts6s021 = ts6s021
                 , ts6s022 = ts6s022
                 , ts6s023 = ts6s023
                 , ts6s024 = ts6s024
                 , ts6s025 = ts6s025
                 , ts6s026 = ts6s026
                 , ts6s027 = ts6s027
                 , ts6s031 = ts6s031
                 , ts6s032 = ts6s032
                 , ts6s033 = ts6s033
                 , ts6s034 = ts6s034
                 , ts6s035 = ts6s035
                 , ts6s036 = ts6s036
                 , ts6s037 = ts6s037
                 , ts6s041 = ts6s041
                 , ts6s042 = ts6s042
                 , ts6s043 = ts6s043
                 , ts6s044 = ts6s044
                 , ts6s045 = ts6s045
                 , ts6s046 = ts6s046
                 , ts6s047 = ts6s047
                 , ts6s051 = ts6s051
                 , ts6s052 = ts6s052
                 , ts6s053 = ts6s053
                 , ts6s054 = ts6s054
                 , ts6s055 = ts6s055
                 , ts6s056 = ts6s056
                 , ts6s057 = ts6s057
                 , ts6s061 = ts6s061
                 , ts6s062 = ts6s062
                 , ts6s063 = ts6s063
                 , ts6s064 = ts6s064
                 , ts6s065 = ts6s065
                 , ts6s066 = ts6s066
                 , ts6s067 = ts6s067
                 , ts6s071 = ts6s071
                 , ts6s072 = ts6s072
                 , ts6s073 = ts6s073
                 , ts6s074 = ts6s074
                 , ts6s075 = ts6s075
                 , ts6s076 = ts6s076
                 , ts6s077 = ts6s077
                 , ts6s081 = ts6s081
                 , ts6s082 = ts6s082
                 , ts6s083 = ts6s083
                 , ts6s084 = ts6s084
                 , ts6s085 = ts6s085
                 , ts6s086 = ts6s086
                 , ts6s087 = ts6s087
                 , ts6s091 = ts6s091
                 , ts6s092 = ts6s092
                 , ts6s093 = ts6s093
                 , ts6s094 = ts6s094
                 , ts6s095 = ts6s095
                 , ts6s096 = ts6s096
                 , ts6s097 = ts6s097
                 , ts6s101 = ts6s101
                 , ts6s102 = ts6s102
                 , ts6s103 = ts6s103
                 , ts6s104 = ts6s104
                 , ts6s105 = ts6s105
                 , ts6s106 = ts6s106
                 , ts6s107 = ts6s107
                 , ts6s111 = ts6s111
                 , ts6s112 = ts6s112
                 , ts6s113 = ts6s113
                 , ts6s114 = ts6s114
                 , ts6s115 = ts6s115
                 , ts6s116 = ts6s116
                 , ts6s117 = tstp117
                };

                ViewBag.getCrPar1010001 = dtcr1010001;
                ViewBag.svctr = 1;
                return View();
            }
            else
            {
                var dtcr1010001 = new
                {

                };
                ViewBag.getCrPar1010001 = dtcr1010001;
                ViewBag.svctr = 1;
                return View();
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
