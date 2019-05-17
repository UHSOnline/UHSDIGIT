


// Get the modal
var modal1010001 = document.getElementById('modal1010001');
var modal1010002 = document.getElementById('modal1010002');
var modal1010003 = document.getElementById('modal1010003');
var modal1010004 = document.getElementById('modal1010004');
var modal1010005d = document.getElementById('modal1010005d');


// Get the button that opens the modal
var btncr1010001 = document.getElementById("btncr1010001");
var btncr1010002 = document.getElementById("btncr1010002");
var btncr1010003 = document.getElementById("btncr1010003");
var btndl1010004 = document.getElementById("btndl1010004");
var btncr10100051 = document.getElementById("btncr10100051");



// Get the <span> element that closes the modal
var span1 = document.getElementsByClassName("close")[0];
var span2 = document.getElementsByClassName("closeb")[0];
var span3 = document.getElementsByClassName("closec")[0];
var span4 = document.getElementsByClassName("closed")[0];
var span5 = document.getElementsByClassName("close05d")[0];

// Get the button that opens the modal
var btnsv1010001 = document.getElementById("btnsv1010001");
var btnsv1010002 = document.getElementById("btnsv1010002");
var btnsv1010003 = document.getElementById("btnsv1010003");
var btnsv1010005d = document.getElementById("btnsv1010005d");

var lckbck = document.getElementsByClassName("lckbckscr")[0];
var mnpart = document.getElementsByClassName("mainpart")[0];


// btncr1010001 - button create new VWP Gemba Walk List , When the user clicks the button, open the modal
btncr1010001.onclick = function () {
    var docid = null;
    var distid = $('#dist1010001').val();
    var acctid = 0;
    if (distid == 1) {
        alert("Please select District (location)");
    }
    else {
        var actype = 2;
        $.ajax({
            type: "POST",
            data:
                {
                    distid: distid
                  , acctid: acctid
                  , actype: actype
                  , docid: docid
                },
            url: '/uhsCH/getCrPar1010001',
            dataType: "JSON",
            success: function (dtcr1010001) {
                //console.log(dtcr1010001);
                var distid = $('#dist1010001').val();
                var acctid = 0;
                if (dtcr1010001.ID == 0) {
                    alert("Message Info: Document already exists in database." + "\n" + "In Gemba Walk document list please check for >>" + "\n" + "District: " + dtcr1010001.zdist + "\n" + "Week: " + dtcr1010001.zweek + "\n" + "Created by user: " + dtcr1010001.zuser);
                }
                else {
                    // MODAL INFO DATA
                    $("#spn10100011").html(dtcr1010001.zdist)
                    $("#spn10100012").html(dtcr1010001.zperd)
                    $("#spn10100013").html(dtcr1010001.zweek)
                    $("#spn10100014").html(dtcr1010001.zuser)
                    // TRANSACTION TYPE
                    $("#doc1010001actype").val(dtcr1010001.actype)
                    // SET DOCUMENT DATA
                    $("#doc1010001id").val(dtcr1010001.docid)
                    $("#doc1010001projid").val(13)
                    $("#doc1010001tskoid").val(50)
                    $("#doc1010001dcgrid").val(1010)
                    $("#doc1010001dctpid").val(1010001)
                    $("#doc1010001tspdid").val(2)
                    $("#doc1010001distid").val(distid)
                    $("#doc1010001acctid").val(acctid)
                    $("#doc1010001userid").val(dtcr1010001.userid)
                    $("#doc1010001crusid").val(dtcr1010001.userid)
                    $("#doc1010001edusid").val(dtcr1010001.userid)
                    mnpart.style.display = "none";
                    lckbck.style.position = "fixed";
                    modal1010001.style.display = "block";
                }
            }
        })
    }
    // dovde ide if
}

// btncr1010002 - button create new VWP 6S List , When the user clicks the button, open the modal
btncr1010002.onclick = function () {
    var docid = null;
    var distid = $('#dist1010002').val();
    var acctid = 0;
    if (distid == 1) {
        alert("Please select District (location)");
    }
    else {
        var actype = 2;
        $.ajax({
            type: "POST",
            data:
                {
                    distid: distid
                  , acctid: acctid
                  , actype: actype
                  , docid: docid
                },
            url: '/uhsCH/getCrPar1010002',
            dataType: "JSON",
            success: function (dtcr1010002) {
                //console.log(dtcr1010001);
                var distid = $('#dist1010002').val();
                var acctid = 0;
                if (dtcr1010002.ID == 0) {
                    alert("Message Info: Document already exists in database." + "\n" + "In 6S document list please check for >>" + "\n" + "District: " + dtcr1010002.zdist + "\n" + "Period: " + dtcr1010002.zperd + "\n" + "Week: " + dtcr1010002.zweek + "\n" + "Created by user: " + dtcr1010002.zuser);
                }
                else {
                    // MODAL INFO DATA
                    $("#spn10100021").html(dtcr1010002.zdist)
                    $("#spn10100022").html(dtcr1010002.zperd)
                    $("#spn10100023").html(dtcr1010002.zweek)
                    $("#spn10100024").html(dtcr1010002.zuser)
                    // TRANSACTION TYPE
                    $("#doc1010002actype").val(dtcr1010002.actype)
                    // SET DOCUMENT DATA
                    $("#doc1010002id").val(dtcr1010002.docid)
                    $("#doc1010002projid").val(13)
                    $("#doc1010002tskoid").val(51)
                    $("#doc1010002dcgrid").val(1010)
                    $("#doc1010002dctpid").val(1010002)
                    $("#doc1010002tspdid").val(2)
                    $("#doc1010002distid").val(distid)
                    $("#doc1010002acctid").val(acctid)
                    $("#doc1010002userid").val(dtcr1010002.userid)
                    $("#doc1010002crusid").val(dtcr1010002.userid)
                    $("#doc1010002edusid").val(dtcr1010002.userid)
                    mnpart.style.display = "none";
                    lckbck.style.position = "fixed";
                    modal1010002.style.display = "block";
                }
            }
        })
    }
    // dovde ide if
}

btncr1010003.onclick = function () {
    var docid = null;
    var distid = $('#dist1010003').val();
    var acctid = 0;
    if (distid == 1) {
        alert("Please select District (location)");
    }
    else {
        var actype = 2;
        $.ajax({
            type: "POST",
            data:
                {
                    distid: distid
                  , acctid: acctid
                  , actype: actype
                  , docid: docid
                },
            url: '/uhsCH/getCrPar1010003',
            dataType: "JSON",
            success: function (dtcr1010003) {
                //console.log(dtcr1010003);
                if (dtcr1010003.ID == 0) {
                    alert("Message Info: Document already exists in database." + "\n" + "In VWP Assessment document list please check for >>" + "\n" + "District: " + dtcr1010003.zdist + "\n" + "Date: " + dtcr1010003.zdate + "\n" + "Created by user: " + dtcr1010003.zuser);
                }
                else {
                    var distid = $('#dist1010003').val();
                    var acctid = 0;
                    // MODAL INFO DATA
                    $("#spn10100031").html(dtcr1010003.zdist)
                    $("#spn10100032").html(dtcr1010003.zuser)
                    $("#spn10100033").html(dtcr1010003.zdate)
                    $("#spn10100034").html(dtcr1010003.zuser)
                    // TRANSACTION TYPE
                    $("#doc1010003actype").val(2)
                    // SET DOCUMENT DATA
                    $("#doc1010003id").val(dtcr1010003.docid)
                    $("#doc1010003projid").val(13)
                    $("#doc1010003tskoid").val(52)
                    $("#doc1010003dcgrid").val(1010)
                    $("#doc1010003dctpid").val(1010003)
                    $("#doc1010003tspdid").val(2)
                    $("#doc1010003distid").val(distid)
                    $("#doc1010003acctid").val(acctid)
                    $("#doc1010003userid").val(dtcr1010003.userid)
                    $("#doc1010003crusid").val(dtcr1010003.userid)
                    $("#doc1010003edusid").val(dtcr1010003.userid)
                    $("#doc1010003dimgid").val(dtcr1010003.userid)
                    mnpart.style.display = "none";
                    lckbck.style.position = "fixed";
                    modal1010003.style.display = "block";
                }
            }
        })
    }
}

$(document).on('click', '.cr1010005', function (e) {
    e.preventDefault();
    var docid = null;
    var doctpc = $(this).data('id');
    if (doctpc == 10100051) {
        var distid = $('#dist10100051').val();
        var acctid = 0;
        var dctpid = 1010005;
        var tspdid = 1;
    } else if (doctpc == 10100052) {
        var distid = $('#dist10100052').val();
        var acctid = 0;
        var dctpid = 1010005;
        var tspdid = 2;
    } else if (doctpc == 10100053) {
        var distid = $('#dist10100053').val();
        var acctid = 0;
        var dctpid = 1010005;
        var tspdid = 3;
    } else if (doctpc == 10100061) {
        var distid = $('#dist10100061').val();
        var acctid = 0;
        var dctpid = 1010006;
        var tspdid = 1;
    } else if (doctpc == 10100062) {
        var distid = $('#dist10100062').val();
        var acctid = 0;
        var dctpid = 1010006;
        var tspdid = 2;
    } else if (doctpc == 10100063) {
        var distid = $('#dist10100063').val();
        var acctid = 0;
        var dctpid = 1010006;
        var tspdid = 3;
    } else if (doctpc == 10100064) {
        var distid = $('#dist10100064').val();
        var acctid = 0;
        var dctpid = 1010006;
        var tspdid = 4;
    } else if (doctpc == 10100065) {
        var distid = $('#dist10100065').val();
        var acctid = 0;
        var dctpid = 1010006;
        var tspdid = 5;
    } else if (doctpc == 10100071) {
        var distid = $('#dist10100071').val();
        var acctid = 0;
        var dctpid = 1010007;
        var tspdid = 1;
    } else if (doctpc == 10100072) {
        var distid = $('#dist10100072').val();
        var acctid = 0;
        var dctpid = 1010007;
        var tspdid = 2;
    } else if (doctpc == 10100073) {
        var distid = $('#dist10100073').val();
        var acctid = 0;
        var dctpid = 1010007;
        var tspdid = 3;
    } else if (doctpc == 10100074) {
        var distid = $('#dist10100074').val();
        var acctid = 0;
        var dctpid = 1010007;
        var tspdid = 4;
    } else if (doctpc == 10100075) {
        var distid = $('#dist10100075').val();
        var acctid = 0;
        var dctpid = 1010007;
        var tspdid = 5;
    }
    if (distid == 1) {
        alert("Please select District (location)");
    }
    else {
        var actype = 2;
        $.ajax({
            type: "POST",
            data:
                {
                    distid: distid
                  , acctid: acctid
                  , actype: actype
                  , dctpid: dctpid
                  , tspdid: tspdid
                  , docid: docid
                },
            url: '/uhsCH/getCrPar1010005',
            dataType: "JSON",
            success: function (dtcr1010005) {
                //console.log(dtcr1010005);
                if (dtcr1010005.ID == 0) {
                    alert("Message Info: Document already exists in database." + "\n" + "In Document List please check for >>" + "\n" + "District: " + dtcr1010005.zdist + "\n" + "Date: " + dtcr1010005.zdate + "\n" + "Created by user: " + dtcr1010005.zuser);
                }
                else {
                    
                    $("#parmod1010005").load("/uhsCH/_modal1010005d", {
                          tpida: dtcr1010005.tspdid
                        , dctpida: dtcr1010005.dctpid
                        , distida: dtcr1010005.distid
                        , acctida: dtcr1010005.acctid
                        , datedt: dtcr1010005.zdate
                        , userida: dtcr1010005.userid
                        , period: dtcr1010005.period
                        , docid: dtcr1010005.ID
                    });
                    $("#doc1010005actype").val(2);
                    $("#doc1010005id").val(dtcr1010005.docid);
                    $("#doc1010005projid").val(13);
                    $("#doc1010005tskoid").val(53);
                    $("#doc1010005dcgrid").val(1010);
                    $("#doc1010005dctpid").val(dtcr1010005.dctpid);
                    $("#doc1010005tspdid").val(dtcr1010005.tspdid);
                    $("#doc1010005distid").val(dtcr1010005.distid);
                    $("#doc1010005acctid").val(dtcr1010005.acctid);
                    $("#doc1010005userid").val(dtcr1010005.userid);
                    $("#doc1010005crusid").val(dtcr1010005.userid);
                    $("#doc1010005edusid").val(dtcr1010005.userid);
                    $("#doc1010005dimgid").val(dtcr1010005.userid);
                    $("#spn10100051").html(dtcr1010005.zdist);
                    $("#spn10100052").html(dtcr1010005.zuser);
                    $("#spn10100053").html(dtcr1010005.zdate);
                    $("#spn10100054").html(dtcr1010005.zuser);                  
                    mnpart.style.display = "none";
                    lckbck.style.position = "fixed";
                    modal1010005d.style.display = "block";
                    
                }
            }
        })
    }
});
btnsv1010001.onclick = function () {
    //console.log("test");
    post1010001();
}
btnsv1010002.onclick = function () {
    post1010002()
}
btnsv1010003.onclick = function () {
    post1010003()
}
btnsv1010005d.onclick = function () {
    post1010005()
}
$(document).on('click', '.editgwdoc', function (e) {
    e.preventDefault();
    var docid = $(this).data('id');
    //console.log(docid)
    var actype = 3;
    $.ajax({
        type: "POST",
        data:
            {
                distid: 0
              , acctid: 0
              , actype: actype
              , docid: docid
            },
        url: '/uhsCH/getCrPar1010001',
        dataType: "JSON",
        success: function (dtcr1010001) {
            //console.log(dtcr1010001);
            // SET INFO HEADING DATA
            $("#spn10100011").html(dtcr1010001.zdist)
            $("#spn10100012").html(dtcr1010001.zperd)
            $("#spn10100013").html(dtcr1010001.zweek)
            $("#spn10100014").html(dtcr1010001.zuser)
            $("#supaprname").html(dtcr1010001.supap)
            // TRANSACTION TYPE
            $("#doc1010001actype").val(dtcr1010001.actype)
            // SET DOCUMENT DATA
            $("#doc1010001id").val(dtcr1010001.ID)
            $("#doc1010001projid").val(dtcr1010001.projid)
            $("#doc1010001tskoid").val(dtcr1010001.tskoid)
            $("#doc1010001dcgrid").val(dtcr1010001.dcgrid)
            $("#doc1010001dctpid").val(dtcr1010001.dctpid)
            $("#doc1010001tspdid").val(dtcr1010001.tspdid)
            $("#doc1010001distid").val(dtcr1010001.distid)
            $("#doc1010001acctid").val(dtcr1010001.acctid)
            $("#doc1010001userid").val(dtcr1010001.crusid)
            $("#doc1010001crusid").val(dtcr1010001.crusid)
            $("#doc1010001edusid").val(dtcr1010001.edusid)
            $("#doc1010001crdt").val(dtcr1010001.crdt)
            $("#doc1010001eddt").val(dtcr1010001.eddt)
            $("#doc1010001chck").prop("checked", dtcr1010001.chck)
            $("#doc1010001chckid").val(dtcr1010001.chckid)
            $("#doc1010001chckdt").val(dtcr1010001.chckdt)
            // SET ACTIVE CHECKS
            $("#tstp011").prop("checked", dtcr1010001.tstp011)
            $("#tstp012").prop("checked", dtcr1010001.tstp012)
            $("#tstp013").prop("checked", dtcr1010001.tstp013)
            $("#tstp014").prop("checked", dtcr1010001.tstp014)
            $("#tstp015").prop("checked", dtcr1010001.tstp015)
            $("#tstp016").prop("checked", dtcr1010001.tstp016)
            $("#tstp017").prop("checked", dtcr1010001.tstp017)
            $("#tstp021").prop("checked", dtcr1010001.tstp021)
            $("#tstp022").prop("checked", dtcr1010001.tstp022)
            $("#tstp023").prop("checked", dtcr1010001.tstp023)
            $("#tstp024").prop("checked", dtcr1010001.tstp024)
            $("#tstp025").prop("checked", dtcr1010001.tstp025)
            $("#tstp026").prop("checked", dtcr1010001.tstp026)
            $("#tstp027").prop("checked", dtcr1010001.tstp027)
            $("#tstp031").prop("checked", dtcr1010001.tstp031)
            $("#tstp032").prop("checked", dtcr1010001.tstp032)
            $("#tstp033").prop("checked", dtcr1010001.tstp033)
            $("#tstp034").prop("checked", dtcr1010001.tstp034)
            $("#tstp035").prop("checked", dtcr1010001.tstp035)
            $("#tstp036").prop("checked", dtcr1010001.tstp036)
            $("#tstp037").prop("checked", dtcr1010001.tstp037)
            $("#tstp041").prop("checked", dtcr1010001.tstp041)
            $("#tstp042").prop("checked", dtcr1010001.tstp042)
            $("#tstp043").prop("checked", dtcr1010001.tstp043)
            $("#tstp044").prop("checked", dtcr1010001.tstp044)
            $("#tstp045").prop("checked", dtcr1010001.tstp045)
            $("#tstp046").prop("checked", dtcr1010001.tstp046)
            $("#tstp047").prop("checked", dtcr1010001.tstp047)
            $("#tstp051").prop("checked", dtcr1010001.tstp051)
            $("#tstp052").prop("checked", dtcr1010001.tstp052)
            $("#tstp053").prop("checked", dtcr1010001.tstp053)
            $("#tstp054").prop("checked", dtcr1010001.tstp054)
            $("#tstp055").prop("checked", dtcr1010001.tstp055)
            $("#tstp056").prop("checked", dtcr1010001.tstp056)
            $("#tstp057").prop("checked", dtcr1010001.tstp057)
            $("#tstp061").prop("checked", dtcr1010001.tstp061)
            $("#tstp062").prop("checked", dtcr1010001.tstp062)
            $("#tstp063").prop("checked", dtcr1010001.tstp063)
            $("#tstp064").prop("checked", dtcr1010001.tstp064)
            $("#tstp065").prop("checked", dtcr1010001.tstp065)
            $("#tstp066").prop("checked", dtcr1010001.tstp066)
            $("#tstp067").prop("checked", dtcr1010001.tstp067)
            $("#tstp071").prop("checked", dtcr1010001.tstp071)
            $("#tstp072").prop("checked", dtcr1010001.tstp072)
            $("#tstp073").prop("checked", dtcr1010001.tstp073)
            $("#tstp074").prop("checked", dtcr1010001.tstp074)
            $("#tstp075").prop("checked", dtcr1010001.tstp075)
            $("#tstp076").prop("checked", dtcr1010001.tstp076)
            $("#tstp077").prop("checked", dtcr1010001.tstp077)
            $("#tstp081").prop("checked", dtcr1010001.tstp081)
            $("#tstp082").prop("checked", dtcr1010001.tstp082)
            $("#tstp083").prop("checked", dtcr1010001.tstp083)
            $("#tstp084").prop("checked", dtcr1010001.tstp084)
            $("#tstp085").prop("checked", dtcr1010001.tstp085)
            $("#tstp086").prop("checked", dtcr1010001.tstp086)
            $("#tstp087").prop("checked", dtcr1010001.tstp087)
            $("#tstp091").prop("checked", dtcr1010001.tstp091)
            $("#tstp092").prop("checked", dtcr1010001.tstp092)
            $("#tstp093").prop("checked", dtcr1010001.tstp093)
            $("#tstp094").prop("checked", dtcr1010001.tstp094)
            $("#tstp095").prop("checked", dtcr1010001.tstp095)
            $("#tstp096").prop("checked", dtcr1010001.tstp096)
            $("#tstp097").prop("checked", dtcr1010001.tstp097)
            $("#tstp101").prop("checked", dtcr1010001.tstp101)
            $("#tstp102").prop("checked", dtcr1010001.tstp102)
            $("#tstp103").prop("checked", dtcr1010001.tstp103)
            $("#tstp104").prop("checked", dtcr1010001.tstp104)
            $("#tstp105").prop("checked", dtcr1010001.tstp105)
            $("#tstp106").prop("checked", dtcr1010001.tstp106)
            $("#tstp107").prop("checked", dtcr1010001.tstp107)
            $("#tstp111").prop("checked", dtcr1010001.tstp111)
            $("#tstp112").prop("checked", dtcr1010001.tstp112)
            $("#tstp113").prop("checked", dtcr1010001.tstp113)
            $("#tstp114").prop("checked", dtcr1010001.tstp114)
            $("#tstp115").prop("checked", dtcr1010001.tstp115)
            $("#tstp116").prop("checked", dtcr1010001.tstp116)
            $("#tstp117").prop("checked", dtcr1010001.tstp117)
            $("#tstp121").prop("checked", dtcr1010001.tstp121)
            $("#tstp122").prop("checked", dtcr1010001.tstp122)
            $("#tstp123").prop("checked", dtcr1010001.tstp123)
            $("#tstp124").prop("checked", dtcr1010001.tstp124)
            $("#tstp125").prop("checked", dtcr1010001.tstp125)
            $("#tstp126").prop("checked", dtcr1010001.tstp126)
            $("#tstp127").prop("checked", dtcr1010001.tstp127)
            $("#tstp131").prop("checked", dtcr1010001.tstp131)
            $("#tstp132").prop("checked", dtcr1010001.tstp132)
            $("#tstp133").prop("checked", dtcr1010001.tstp133)
            $("#tstp134").prop("checked", dtcr1010001.tstp134)
            $("#tstp135").prop("checked", dtcr1010001.tstp135)
            $("#tstp136").prop("checked", dtcr1010001.tstp136)
            $("#tstp137").prop("checked", dtcr1010001.tstp137)
            $("#tstp141").prop("checked", dtcr1010001.tstp141)
            $("#tstp142").prop("checked", dtcr1010001.tstp142)
            $("#tstp143").prop("checked", dtcr1010001.tstp143)
            $("#tstp144").prop("checked", dtcr1010001.tstp144)
            $("#tstp145").prop("checked", dtcr1010001.tstp145)
            $("#tstp146").prop("checked", dtcr1010001.tstp146)
            $("#tstp147").prop("checked", dtcr1010001.tstp147)
            $("#tstp154").prop("checked", dtcr1010001.tstp154)
            $("#tstp164").prop("checked", dtcr1010001.tstp164)
            $("#tstp174").prop("checked", dtcr1010001.tstp174)
            $("#tstp184").prop("checked", dtcr1010001.tstp184)
            mnpart.style.display = "none";
            lckbck.style.position = "fixed";
            modal1010001.style.display = "block";
        }
    })
});

$(document).on('click', '.edit6sdoc', function (e) {
    e.preventDefault();
    var docid = $(this).data('id');
    //console.log(docid)
    var actype = 3;
    $.ajax({
        type: "POST",
        data:
            {
                distid: 0
              , acctid: 0
              , actype: actype
              , docid: docid
            },
        url: '/uhsCH/getCrPar1010002',
        dataType: "JSON",
        success: function (dtcr1010002) {
            //console.log(dtcr1010001);
            // SET INFO HEADING DATA
            $("#spn10100021").html(dtcr1010002.zdist)
            $("#spn10100022").html(dtcr1010002.zperd)
            $("#spn10100023").html(dtcr1010002.zweek)
            $("#spn10100024").html(dtcr1010002.zuser)
            $("#supa6sname").html(dtcr1010002.supap)
            // TRANSACTION TYPE
            $("#doc1010002actype").val(3)
            // SET DOCUMENT DATA
            $("#doc1010002id").val(dtcr1010002.ID)
            $("#doc1010002projid").val(dtcr1010002.projid)
            $("#doc1010002tskoid").val(dtcr1010002.tskoid)
            $("#doc1010002dcgrid").val(dtcr1010002.dcgrid)
            $("#doc1010002dctpid").val(dtcr1010002.dctpid)
            $("#doc1010002tspdid").val(dtcr1010002.tspdid)
            $("#doc1010002distid").val(dtcr1010002.distid)
            $("#doc1010002acctid").val(dtcr1010002.acctid)
            $("#doc1010002userid").val(dtcr1010002.crusid)
            $("#doc1010002crusid").val(dtcr1010002.crusid)
            $("#doc1010002edusid").val(dtcr1010002.edusid)
            $("#doc1010002crdt").val(dtcr1010002.crdt)
            $("#doc1010002eddt").val(dtcr1010002.eddt)
            $("#doc1010002chck").prop("checked", dtcr1010002.chck)
            $("#doc1010002chckid").val(dtcr1010002.chckid)
            $("#doc1010002chckdt").val(dtcr1010002.chckdt)
            // SET ACTIVE CHECKS
            $("#ts6s011").prop("checked", dtcr1010002.tstp011)
            $("#ts6s012").prop("checked", dtcr1010002.tstp012)
            $("#ts6s013").prop("checked", dtcr1010002.tstp013)
            $("#ts6s014").prop("checked", dtcr1010002.tstp014)
            $("#ts6s015").prop("checked", dtcr1010002.tstp015)
            $("#ts6s016").prop("checked", dtcr1010002.tstp016)
            $("#ts6s017").prop("checked", dtcr1010002.tstp017)
            $("#ts6s021").prop("checked", dtcr1010002.tstp021)
            $("#ts6s022").prop("checked", dtcr1010002.tstp022)
            $("#ts6s023").prop("checked", dtcr1010002.tstp023)
            $("#ts6s024").prop("checked", dtcr1010002.tstp024)
            $("#ts6s025").prop("checked", dtcr1010002.tstp025)
            $("#ts6s026").prop("checked", dtcr1010002.tstp026)
            $("#ts6s027").prop("checked", dtcr1010002.tstp027)
            $("#ts6s031").prop("checked", dtcr1010002.tstp031)
            $("#ts6s032").prop("checked", dtcr1010002.tstp032)
            $("#ts6s033").prop("checked", dtcr1010002.tstp033)
            $("#ts6s034").prop("checked", dtcr1010002.tstp034)
            $("#ts6s035").prop("checked", dtcr1010002.tstp035)
            $("#ts6s036").prop("checked", dtcr1010002.tstp036)
            $("#ts6s037").prop("checked", dtcr1010002.tstp037)
            $("#ts6s041").prop("checked", dtcr1010002.tstp041)
            $("#ts6s042").prop("checked", dtcr1010002.tstp042)
            $("#ts6s043").prop("checked", dtcr1010002.tstp043)
            $("#ts6s044").prop("checked", dtcr1010002.tstp044)
            $("#ts6s045").prop("checked", dtcr1010002.tstp045)
            $("#ts6s046").prop("checked", dtcr1010002.tstp046)
            $("#ts6s047").prop("checked", dtcr1010002.tstp047)
            $("#ts6s051").prop("checked", dtcr1010002.tstp051)
            $("#ts6s052").prop("checked", dtcr1010002.tstp052)
            $("#ts6s053").prop("checked", dtcr1010002.tstp053)
            $("#ts6s054").prop("checked", dtcr1010002.tstp054)
            $("#ts6s055").prop("checked", dtcr1010002.tstp055)
            $("#ts6s056").prop("checked", dtcr1010002.tstp056)
            $("#ts6s057").prop("checked", dtcr1010002.tstp057)
            $("#ts6s061").prop("checked", dtcr1010002.tstp061)
            $("#ts6s062").prop("checked", dtcr1010002.tstp062)
            $("#ts6s063").prop("checked", dtcr1010002.tstp063)
            $("#ts6s064").prop("checked", dtcr1010002.tstp064)
            $("#ts6s065").prop("checked", dtcr1010002.tstp065)
            $("#ts6s066").prop("checked", dtcr1010002.tstp066)
            $("#ts6s067").prop("checked", dtcr1010002.tstp067)
            $("#ts6s071").prop("checked", dtcr1010002.tstp071)
            $("#ts6s072").prop("checked", dtcr1010002.tstp072)
            $("#ts6s073").prop("checked", dtcr1010002.tstp073)
            $("#ts6s074").prop("checked", dtcr1010002.tstp074)
            $("#ts6s075").prop("checked", dtcr1010002.tstp075)
            $("#ts6s076").prop("checked", dtcr1010002.tstp076)
            $("#ts6s077").prop("checked", dtcr1010002.tstp077)
            $("#ts6s081").prop("checked", dtcr1010002.tstp081)
            $("#ts6s082").prop("checked", dtcr1010002.tstp082)
            $("#ts6s083").prop("checked", dtcr1010002.tstp083)
            $("#ts6s084").prop("checked", dtcr1010002.tstp084)
            $("#ts6s085").prop("checked", dtcr1010002.tstp085)
            $("#ts6s086").prop("checked", dtcr1010002.tstp086)
            $("#ts6s087").prop("checked", dtcr1010002.tstp087)
            $("#ts6s091").prop("checked", dtcr1010002.tstp091)
            $("#ts6s092").prop("checked", dtcr1010002.tstp092)
            $("#ts6s093").prop("checked", dtcr1010002.tstp093)
            $("#ts6s094").prop("checked", dtcr1010002.tstp094)
            $("#ts6s095").prop("checked", dtcr1010002.tstp095)
            $("#ts6s096").prop("checked", dtcr1010002.tstp096)
            $("#ts6s097").prop("checked", dtcr1010002.tstp097)
            $("#ts6s101").prop("checked", dtcr1010002.tstp101)
            $("#ts6s102").prop("checked", dtcr1010002.tstp102)
            $("#ts6s103").prop("checked", dtcr1010002.tstp103)
            $("#ts6s104").prop("checked", dtcr1010002.tstp104)
            $("#ts6s105").prop("checked", dtcr1010002.tstp105)
            $("#ts6s106").prop("checked", dtcr1010002.tstp106)
            $("#ts6s107").prop("checked", dtcr1010002.tstp107)
            $("#ts6s111").prop("checked", dtcr1010002.tstp111)
            $("#ts6s112").prop("checked", dtcr1010002.tstp112)
            $("#ts6s113").prop("checked", dtcr1010002.tstp113)
            $("#ts6s114").prop("checked", dtcr1010002.tstp114)
            $("#ts6s115").prop("checked", dtcr1010002.tstp115)
            $("#ts6s116").prop("checked", dtcr1010002.tstp116)
            $("#ts6s117").prop("checked", dtcr1010002.tstp117)
            mnpart.style.display = "none";
            lckbck.style.position = "fixed";
            modal1010002.style.display = "block";
        }
    })
});

// delete
$(document).on('click', '.delvpass', function (e) {
    e.preventDefault();
    var docid = $(this).data('id');
    $.ajax({
        type: "POST",
        data: { docid: docid },
        url: '/uhsCH/delc1010003',
        dataType: "JSON",
        success: function (data) {        
            $("#doc1010003id").val(data.docid);
            $("#delassdoc").html(data.distnm);
            $("#delassdat").html(data.crdate);
            $("#deldctpid").val(data.dctpid);
            $("#deldcdesc").html("VWP Assessment");
            modal1010004.style.display = "block";
        }
    })
});
$(document).on('click', '.del1010005d', function (e) {
    e.preventDefault();
    var docid = $(this).data('id');
    $.ajax({
        type: "POST",
        data: { docid: docid },
        url: '/uhsCH/del1010005d',
        dataType: "JSON",
        success: function (data) {
            $("#doc1010005id").val(data.docid);
            $("#delassdoc").html(data.distnm);
            $("#delassdat").html(data.crdate);
            $("#deldctpid").val(data.dctpid);
            $("#deldcdesc").html(data.dcdesc);
            modal1010004.style.display = "block";
        }
    })
});
$(document).on('click', '.ed1010003', function (e) {
    e.preventDefault();
    var docid = $(this).data('id');
    $.ajax({
        type: "POST",
        data: {
            distid: 0
              , acctid: 0
              , actype: 3
              , docid: docid
        },
        url: '/uhsCH/getCrPar1010003',
        dataType: "JSON",
        success: function (dtcr1010003) {
            $("#doc1010003id").val(dtcr1010003.ID);
            $("#doc1010003projid").val(dtcr1010003.projid);
            $("#doc1010003tskoid").val(dtcr1010003.tskoid);
            $("#doc1010003dcgrid").val(dtcr1010003.dcgrid);
            $("#doc1010003dctpid").val(dtcr1010003.dctpid);
            $("#doc1010003tspdid").val(dtcr1010003.tspdid);
            $("#doc1010003distid").val(dtcr1010003.distid);
            $("#doc1010003acctid").val(dtcr1010003.acctid);
            $("#doc1010003userid").val(dtcr1010003.userid);
            $("#gr1010003001").val(dtcr1010003.GR001);
            $("#gr1010003002").val(dtcr1010003.GR002);
            $("#gr1010003003").val(dtcr1010003.GR003);
            $("#gr1010003004").val(dtcr1010003.GR004);
            $("#gr1010003005").val(dtcr1010003.GR005);
            $("#gr1010003006").val(dtcr1010003.GR006);
            $("#gr1010003007").val(dtcr1010003.GR007);
            $("#gr1010003008").val(dtcr1010003.GR008);
            $("#gr1010003009").val(dtcr1010003.GR009);
            $("#gr1010003010").val(dtcr1010003.GR010);
            $("#gr1010003011").val(dtcr1010003.GR011);
            $("#gr1010003012").val(dtcr1010003.GR012);
            $("#gr1010003013").val(dtcr1010003.GR013);
            $("#gr1010003014").val(dtcr1010003.GR014);
            $("#gr1010003015").val(dtcr1010003.GR015);
            $("#gr1010003016").val(dtcr1010003.GR016);
            $("#gr1010003017").val(dtcr1010003.GR017);
            $("#gr1010003018").val(dtcr1010003.GR018);
            $("#gr1010003019").val(dtcr1010003.GR019);
            $("#gr1010003020").val(dtcr1010003.GR020);
            $("#gr1010003021").val(dtcr1010003.GR021);
            $("#gr1010003022").val(dtcr1010003.GR022);
            $("#gr1010003023").val(dtcr1010003.GR023);
            $("#gr1010003024").val(dtcr1010003.GR024);
            $("#gr1010003025").val(dtcr1010003.GR025);
            $("#gr1010003026").val(dtcr1010003.GR026);
            $("#gr1010003027").val(dtcr1010003.GR027);
            $("#gr1010003028").val(dtcr1010003.GR028);
            $("#gr1010003029").val(dtcr1010003.GR029);
            $("#gr1010003030").val(dtcr1010003.GR030);
            $("#gr1010003031").val(dtcr1010003.GR031);
            $("#gr1010003032").val(dtcr1010003.GR032);
            $("#gr1010003033").val(dtcr1010003.GR033);
            $("#gr1010003034").val(dtcr1010003.GR034);
            $("#gr1010003035").val(dtcr1010003.GR035);
            $("#gr1010003036").val(dtcr1010003.GR036);
            $("#gr1010003037").val(dtcr1010003.GR037);
            $("#gr1010003038").val(dtcr1010003.GR038);
            $("#gr1010003039").val(dtcr1010003.GR039);
            $("#gr1010003040").val(dtcr1010003.GR040);
            $("#gr1010003041").val(dtcr1010003.GR041);
            $("#gr1010003042").val(dtcr1010003.GR042);
            $("#gr1010003043").val(dtcr1010003.GR043);
            $("#gr1010003044").val(dtcr1010003.GR044);
            $("#gr1010003045").val(dtcr1010003.GR045);
            $("#gr1010003046").val(dtcr1010003.GR046);
            $("#gr1010003047").val(dtcr1010003.GR047);
            $("#gr1010003048").val(dtcr1010003.GR048);
            $("#gr1010003049").val(dtcr1010003.GR049);
            $("#gr1010003050").val(dtcr1010003.GR050);
            $("#gr1010003051").val(dtcr1010003.GR051);
            $("#gr1010003052").val(dtcr1010003.GR052);
            $("#gr1010003053").val(dtcr1010003.GR053);
            $("#gr1010003054").val(dtcr1010003.GR054);
            $("#gr1010003055").val(dtcr1010003.GR055);
            $("#gr1010003056").val(dtcr1010003.GR056);
            $("#gr1010003057").val(dtcr1010003.GR057);
            $("#gr1010003058").val(dtcr1010003.GR058);
            $("#gr1010003059").val(dtcr1010003.GR059);
            $("#gr1010003060").val(dtcr1010003.GR060);
            $("#gr1010003061").val(dtcr1010003.GR061);
            $("#gr1010003062").val(dtcr1010003.GR062);
            $("#gr1010003063").val(dtcr1010003.GR063);
            $("#gr1010003064").val(dtcr1010003.GR064);
            $("#gr1010003065").val(dtcr1010003.GR065);
            $("#gr1010003066").val(dtcr1010003.GR066);
            $("#gr1010003067").val(dtcr1010003.GR067);
            $("#gr1010003068").val(dtcr1010003.GR068);
            $("#gr1010003069").val(dtcr1010003.GR069);
            $("#gr1010003070").val(dtcr1010003.GR070);
            $("#gr1010003071").val(dtcr1010003.GR071);
            $("#gr1010003072").val(dtcr1010003.GR072);
            $("#gr1010003073").val(dtcr1010003.GR073);
            $("#gr1010003074").val(dtcr1010003.GR074);
            $("#gr1010003075").val(dtcr1010003.GR075);
            $("#gr1010003076").val(dtcr1010003.GR076);
            $("#gr1010003077").val(dtcr1010003.GR077);
            $("#gr1010003078").val(dtcr1010003.GR078);
            $("#gr1010003079").val(dtcr1010003.GR079);
            $("#gr1010003080").val(dtcr1010003.GR080);
            $("#gr1010003081").val(dtcr1010003.GR081);
            $("#gr1010003082").val(dtcr1010003.GR082);
            $("#gr1010003083").val(dtcr1010003.GR083);
            $("#gr1010003084").val(dtcr1010003.GR084);
            $("#gr1010003085").val(dtcr1010003.GR085);
            $("#gr1010003086").val(dtcr1010003.GR086);
            $("#gr1010003087").val(dtcr1010003.GR087);
            $("#gr1010003088").val(dtcr1010003.GR088);
            $("#gr1010003089").val(dtcr1010003.GR089);
            $("#gr1010003090").val(dtcr1010003.GR090);
            $("#gr1010003091").val(dtcr1010003.GR091);
            $("#gr1010003092").val(dtcr1010003.GR092);
            $("#gr1010003093").val(dtcr1010003.GR093);
            $("#gr1010003094").val(dtcr1010003.GR094);
            $("#gr1010003095").val(dtcr1010003.GR095);
            $("#gr1010003096").val(dtcr1010003.GR096);
            $("#gr1010003097").val(dtcr1010003.GR097);
            $("#gr1010003098").val(dtcr1010003.GR098);
            $("#gr1010003099").val(dtcr1010003.GR099);
            $("#gr1010003100").val(dtcr1010003.GR100);
            $("#gr1010003101").val(dtcr1010003.GR101);
            $("#gr1010003102").val(dtcr1010003.GR102);
            $("#gr1010003103").val(dtcr1010003.GR103);
            $("#gr1010003104").val(dtcr1010003.GR104);
            $("#gr1010003105").val(dtcr1010003.GR105);
            $("#gr1010003106").val(dtcr1010003.GR106);
            $("#gr1010003107").val(dtcr1010003.GR107);
            $("#gr1010003108").val(dtcr1010003.GR108);
            $("#gr1010003109").val(dtcr1010003.GR109);
            $("#gr1010003110").val(dtcr1010003.GR110);
            $("#gr1010003111").val(dtcr1010003.GR111);
            $("#gr1010003112").val(dtcr1010003.GR112);
            $("#gr1010003113").val(dtcr1010003.GR113);
            $("#gr1010003114").val(dtcr1010003.GR114);
            $("#gr1010003115").val(dtcr1010003.GR115);
            $("#gr1010003116").val(dtcr1010003.GR116);
            $("#gr1010003117").val(dtcr1010003.GR117);
            $("#gr1010003118").val(dtcr1010003.GR118);
            $("#gr1010003119").val(dtcr1010003.GR119);
            $("#gr1010003120").val(dtcr1010003.GR120);
            $("#gr1010003121").val(dtcr1010003.GR121);
            $("#gr1010003122").val(dtcr1010003.GR122);
            $("#gr1010003123").val(dtcr1010003.GR123);
            $("#gr1010003124").val(dtcr1010003.GR124);
            $("#gr1010003125").val(dtcr1010003.GR125);
            $("#gr1010003126").val(dtcr1010003.GR126);
            $("#gr1010003127").val(dtcr1010003.GR127);
            $("#gr1010003128").val(dtcr1010003.GR128);
            $("#gr1010003129").val(dtcr1010003.GR129);
            $("#gr1010003130").val(dtcr1010003.GR130);
            $("#gr1010003131").val(dtcr1010003.GR131);
            $("#gr1010003132").val(dtcr1010003.GR132);
            $("#gr1010003133").val(dtcr1010003.GR133);
            $("#gr1010003134").val(dtcr1010003.GR134);
            $("#gr1010003135").val(dtcr1010003.GR135);
            $("#gr1010003136").val(dtcr1010003.GR136);
            $("#txt1010003001").val(dtcr1010003.TX001);
            $("#txt1010003002").val(dtcr1010003.TX002);
            $("#txt1010003003").val(dtcr1010003.TX003);
            $("#txt1010003004").val(dtcr1010003.TX004);
            $("#txt1010003005").val(dtcr1010003.TX005);
            $("#txt1010003006").val(dtcr1010003.TX006);
            $("#txt1010003007").val(dtcr1010003.TX007);
            $("#txt1010003008").val(dtcr1010003.TX008);
            $("#txt1010003009").val(dtcr1010003.TX009);
            $("#txt1010003010").val(dtcr1010003.TX010);
            $("#txt1010003011").val(dtcr1010003.TX011);
            $("#txt1010003012").val(dtcr1010003.TX012);
            $("#txt1010003013").val(dtcr1010003.TX013);
            $("#txt1010003014").val(dtcr1010003.TX014);
            $("#txt1010003015").val(dtcr1010003.TX015);
            $("#txt1010003016").val(dtcr1010003.TX016);
            $("#txt1010003017").val(dtcr1010003.TX017);
            $("#txt1010003018").val(dtcr1010003.TX018);
            $("#txt1010003019").val(dtcr1010003.TX019);
            $("#txt1010003020").val(dtcr1010003.TX020);
            $("#txt1010003021").val(dtcr1010003.TX021);
            $("#txt1010003022").val(dtcr1010003.TX022);
            $("#txt1010003023").val(dtcr1010003.TX023);
            $("#txt1010003024").val(dtcr1010003.TX024);
            $("#txt1010003025").val(dtcr1010003.TX025);
            $("#txt1010003026").val(dtcr1010003.TX026);
            $("#txt1010003027").val(dtcr1010003.TX027);
            $("#txt1010003028").val(dtcr1010003.TX028);
            $("#txt1010003029").val(dtcr1010003.TX029);
            $("#txt1010003030").val(dtcr1010003.TX030);
            $("#txt1010003031").val(dtcr1010003.TX031);
            $("#txt1010003032").val(dtcr1010003.TX032);
            $("#txt1010003033").val(dtcr1010003.TX033);
            $("#txt1010003034").val(dtcr1010003.TX034);
            $("#txt1010003035").val(dtcr1010003.TX035);
            $("#txt1010003036").val(dtcr1010003.TX036);
            $("#txt1010003037").val(dtcr1010003.TX037);
            $("#txt1010003038").val(dtcr1010003.TX038);
            $("#txt1010003039").val(dtcr1010003.TX039);
            $("#txt1010003040").val(dtcr1010003.TX040);
            $("#txt1010003041").val(dtcr1010003.TX041);
            $("#txt1010003042").val(dtcr1010003.TX042);
            $("#txt1010003043").val(dtcr1010003.TX043);
            $("#txt1010003044").val(dtcr1010003.TX044);
            $("#txt1010003045").val(dtcr1010003.TX045);
            $("#txt1010003046").val(dtcr1010003.TX046);
            $("#txt1010003047").val(dtcr1010003.TX047);
            $("#txt1010003048").val(dtcr1010003.TX048);
            $("#txt1010003049").val(dtcr1010003.TX049);
            $("#txt1010003050").val(dtcr1010003.TX050);
            $("#txt1010003051").val(dtcr1010003.TX051);
            $("#txt1010003052").val(dtcr1010003.TX052);
            $("#txt1010003053").val(dtcr1010003.TX053);
            $("#txt1010003054").val(dtcr1010003.TX054);
            $("#txt1010003055").val(dtcr1010003.TX055);
            $("#txt1010003056").val(dtcr1010003.TX056);
            $("#txt1010003057").val(dtcr1010003.TX057);
            $("#txt1010003058").val(dtcr1010003.TX058);
            $("#txt1010003059").val(dtcr1010003.TX059);
            $("#txt1010003060").val(dtcr1010003.TX060);
            $("#txt1010003061").val(dtcr1010003.TX061);
            $("#txt1010003062").val(dtcr1010003.TX062);
            $("#txt1010003063").val(dtcr1010003.TX063);
            $("#txt1010003064").val(dtcr1010003.TX064);
            $("#txt1010003065").val(dtcr1010003.TX065);
            $("#txt1010003066").val(dtcr1010003.TX066);
            $("#txt1010003067").val(dtcr1010003.TX067);
            $("#txt1010003068").val(dtcr1010003.TX068);
            $("#txt1010003069").val(dtcr1010003.TX069);
            $("#txt1010003070").val(dtcr1010003.TX070);
            $("#txt1010003071").val(dtcr1010003.TX071);
            $("#txt1010003072").val(dtcr1010003.TX072);
            $("#txt1010003073").val(dtcr1010003.TX073);
            $("#txt1010003074").val(dtcr1010003.TX074);
            $("#txt1010003075").val(dtcr1010003.TX075);
            $("#txt1010003076").val(dtcr1010003.TX076);
            $("#txt1010003077").val(dtcr1010003.TX077);
            $("#txt1010003078").val(dtcr1010003.TX078);
            $("#txt1010003079").val(dtcr1010003.TX079);
            $("#txt1010003080").val(dtcr1010003.TX080);
            $("#txt1010003081").val(dtcr1010003.TX081);
            $("#txt1010003082").val(dtcr1010003.TX082);
            $("#txt1010003083").val(dtcr1010003.TX083);
            $("#txt1010003084").val(dtcr1010003.TX084);
            $("#txt1010003085").val(dtcr1010003.TX085);
            $("#txt1010003086").val(dtcr1010003.TX086);
            $("#txt1010003087").val(dtcr1010003.TX087);
            $("#txt1010003088").val(dtcr1010003.TX088);
            $("#txt1010003089").val(dtcr1010003.TX089);
            $("#txt1010003090").val(dtcr1010003.TX090);
            $("#txt1010003091").val(dtcr1010003.TX091);
            $("#txt1010003092").val(dtcr1010003.TX092);
            $("#txt1010003093").val(dtcr1010003.TX093);
            $("#txt1010003094").val(dtcr1010003.TX094);
            $("#txt1010003095").val(dtcr1010003.TX095);
            $("#txt1010003096").val(dtcr1010003.TX096);
            $("#txt1010003097").val(dtcr1010003.TX097);
            $("#txt1010003098").val(dtcr1010003.TX098);
            $("#txt1010003099").val(dtcr1010003.TX099);
            $("#txt1010003100").val(dtcr1010003.TX100);
            $("#txt1010003101").val(dtcr1010003.TX101);
            $("#txt1010003102").val(dtcr1010003.TX102);
            $("#txt1010003103").val(dtcr1010003.TX103);
            $("#txt1010003104").val(dtcr1010003.TX104);
            $("#txt1010003105").val(dtcr1010003.TX105);
            $("#txt1010003106").val(dtcr1010003.TX106);
            $("#txt1010003107").val(dtcr1010003.TX107);
            $("#txt1010003108").val(dtcr1010003.TX108);
            $("#txt1010003109").val(dtcr1010003.TX109);
            $("#txt1010003110").val(dtcr1010003.TX110);
            $("#txt1010003111").val(dtcr1010003.TX111);
            $("#txt1010003112").val(dtcr1010003.TX112);
            $("#txt1010003113").val(dtcr1010003.TX113);
            $("#txt1010003114").val(dtcr1010003.TX114);
            $("#txt1010003115").val(dtcr1010003.TX115);
            $("#txt1010003116").val(dtcr1010003.TX116);
            $("#txt1010003117").val(dtcr1010003.TX117);
            $("#txt1010003118").val(dtcr1010003.TX118);
            $("#txt1010003119").val(dtcr1010003.TX119);
            $("#txt1010003120").val(dtcr1010003.TX120);
            $("#txt1010003121").val(dtcr1010003.TX121);
            $("#txt1010003122").val(dtcr1010003.TX122);
            $("#txt1010003123").val(dtcr1010003.TX123);
            $("#txt1010003124").val(dtcr1010003.TX124);
            $("#txt1010003125").val(dtcr1010003.TX125);
            $("#txt1010003126").val(dtcr1010003.TX126);
            $("#txt1010003127").val(dtcr1010003.TX127);
            $("#txt1010003128").val(dtcr1010003.TX128);
            $("#txt1010003129").val(dtcr1010003.TX129);
            $("#txt1010003130").val(dtcr1010003.TX130);
            $("#txt1010003131").val(dtcr1010003.TX131);
            $("#txt1010003132").val(dtcr1010003.TX132);
            $("#txt1010003133").val(dtcr1010003.TX133);
            $("#txt1010003134").val(dtcr1010003.TX134);
            $("#txt1010003135").val(dtcr1010003.TX135);
            $("#txt1010003136").val(dtcr1010003.TX136);
            $('#doc1010003chck').prop("checked", dtcr1010003.chck);
            $("#doc1010003chckid").val(dtcr1010003.chckid);
            $("#doc1010003chckdt").val(dtcr1010003.chckdt);
            $("#doc1010003crdt").val(dtcr1010003.crdt);
            $("#doc1010003eddt").val(dtcr1010003.eddt);
            $("#doc1010003crusid").val(dtcr1010003.crusid);
            $("#doc1010003edusid").val(dtcr1010003.edusid);
            $("#doc1010003actype").val(3);
            $("#spn10100031").html(dtcr1010003.zdist);
            $("#spn10100032").html(dtcr1010003.dimgnm);
            $("#doc1010003dimgid").val(dtcr1010003.dimgid);
            $("#spn10100033").html(dtcr1010003.zdate);
            $("#spn10100034").html(dtcr1010003.assmnm);
            $("#supassname").html(dtcr1010003.supap);
            mnpart.style.display = "none";
            lckbck.style.position = "fixed";
            modal1010003.style.display = "block";
        }
    })
});
$(document).on('click', '.ed1010005', function (e) {
    e.preventDefault();
    var docid = $(this).data('id');
    $.ajax({
        type: "POST",
        data: { docid: docid },
        url: '/uhsCH/modalcheck',
        dataType: "JSON",
        success: function (data) {
            $("#parmod1010005").load("/uhsCH/_modal1010005d", {
                        tpida: data.tspdid
                      , dctpida: data.dctpid
                      , distida: data.distid
                      , acctida: data.acctid
                      , datedt: data.datedt
                      , userida: data.userid
                      , period: data.period
                      , docid: docid
            });
            $.ajax({
                type: "POST",
                data: {
                        distid: data.distid
                      , acctid: data.acctid
                      , actype: 3
                      , dctpid: data.dctpid
                      , tspdid: data.tspdid
                      , docid: docid
                },
                url: '/uhsCH/getCrPar1010005',
                dataType: "JSON",
                success: function (dtcr1010005) {                 
                    $("#doc1010005id").val(dtcr1010005.ID);
                    $("#doc1010005projid").val(dtcr1010005.projid);
                    $("#doc1010005tskoid").val(dtcr1010005.tskoid);
                    $("#doc1010005dcgrid").val(dtcr1010005.dcgrid);
                    $("#doc1010005dctpid").val(dtcr1010005.dctpid);
                    $("#doc1010005tspdid").val(dtcr1010005.tspdid);
                    $("#doc1010005distid").val(dtcr1010005.distid);
                    $("#doc1010005acctid").val(dtcr1010005.acctid);
                    $("#doc1010005userid").val(dtcr1010005.userid);
                    
                    $("#cm1010005101").val(dtcr1010005.comm01);
                    $("#cm1010005102").val(dtcr1010005.comm02);
                    $("#cm1010005103").val(dtcr1010005.comm03);
                    $("#cm1010005104").val(dtcr1010005.comm04);
                    $("#cm1010005105").val(dtcr1010005.comm05);
                    $("#cm1010005106").val(dtcr1010005.comm06);
                    $('#doc1010005chck').prop("checked", dtcr1010005.chck);
                    $("#doc1010005chckid").val(dtcr1010005.chckid);
                    $("#doc1010005chckdt").val(dtcr1010005.chckdt);
                    $("#doc1010005crdt").val(dtcr1010005.crdt);
                    $("#doc1010005eddt").val(dtcr1010005.eddt);
                    $("#doc1010005crusid").val(dtcr1010005.crusid);
                    $("#doc1010005edusid").val(dtcr1010005.edusid);
                    $("#doc1010005actype").val(3);
                    $("#doc1010005dimgid").val(dtcr1010005.dimgid);
                    mnpart.style.display = "none";
                    lckbck.style.position = "fixed";
                    modal1010005d.style.display = "block";
                }
            })
        }
    });
});
btndl1010004.onclick = function (e) {
    e.preventDefault();
    var dctpid = $("#deldctpid").val();
    if (dctpid == 1010003) {
        var docid = $("#doc1010003id").val();
        $.ajax({
            type: "POST",
            data: { docid: docid },
            url: '/uhsCH/del1010003',
            dataType: "JSON",
            success: function (dr1010003) {
                if (dr1010003 == 1) {
                    modal1010004.style.display = "none";
                    location.reload();
                } else if (dr1010003 == 2) {
                    alert("Failed to delete document.");
                } else if (dr1010003 == 3) {
                    alert("Failed to authorize user.");
                } else {
                    alert("Unknow error.");
                }
            }
        })
    } else 
        if (dctpid == 1010005 || dctpid == 1010006 || dctpid == 1010007) {
            var docid = $("#doc1010005id").val();
            $.ajax({
                type: "POST",
                data: { docid: docid },
                url: '/uhsCH/del1010005',
                dataType: "JSON",
                success: function (dr1010005) {
                    if (dr1010005 == 1) {
                        modal1010004.style.display = "none";
                        location.reload();
                    } else if (dr1010005 == 2) {
                        alert("Failed to delete document.");
                    } else if (dr1010005 == 3) {
                        alert("Failed to authorize user.");
                    } else {
                        alert("Unknow error.");
                    }
                }
            })
    }  
};
$(window).load(function () {
    var It0 = 1;
    $.ajax({
        url: '/uhsCH/perdrop1',
        type: "GET",
        dataType: "JSON",
        data: { ID: It0 },
        success: function (populate) {
            //console.log(list);
            $("#perdrop1").html(""); // clear before appending new list
            $.each(populate, function (ID, list) {
                $("#perdrop1").append(
                    $('<option></option>').val(list.ID).html(list.Value));
            });
            weekdrop1();
        }
    });
});
$(window).load(function () {
    var It0 = 1;
    $.ajax({
        url: '/uhsCH/perd6op1',
        type: "GET",
        dataType: "JSON",
        data: { ID: It0 },
        success: function (populate) {
            //console.log(list);
            $("#perd6op1").html(""); // clear before appending new list
            $.each(populate, function (ID, list) {
                $("#perd6op1").append(
                    $('<option></option>').val(list.ID).html(list.Value));
            });
            wekd6op1();
        }
    });
});
$('#perdrop1').change(
    function () {
        var int1 = $("#perdrop1").val();
        $.ajax({
            url: '/uhsCH/wekdrop1',
            type: "GET",
            dataType: "JSON",
            data: { ID: int1 },
            success: function (populate) {
                //console.log(list);
                $("#wekdrop1").html(""); // clear before appending new list
                $.each(populate, function (ID, list) {
                    $("#wekdrop1").append(
                        $('<option></option>').val(list.ID).html(list.Value));
                });
                distdrop1();
                resv1();
                setdrops1();
            }
        });
    });
$('#perd6op1').change(
    function () {
        var int1 = $("#perd6op1").val();
        $.ajax({
            url: '/uhsCH/wekd6op1',
            type: "GET",
            dataType: "JSON",
            data: { ID: int1 },
            success: function (populate) {
                //console.log(list);
                $("#wekd6op1").html(""); // clear before appending new list
                $.each(populate, function (ID, list) {
                    $("#wekd6op1").append(
                        $('<option></option>').val(list.ID).html(list.Value));
                });
                disd6op1();
                resv2();
                setdrops2();
            }
        });
    });
$('#wekdrop1').change(
    function () {
        distdrop1();
        resv1();
        setdrops1();
    });
$('#wekdrop2').change(
    function () {
        disd6op1();
        resv2();
        setdrops2();
    });
$('#disdrop1').change(
    function (event) {
        var int1 = event.target.value;
        var int2 = 1;
        setview1(int1, int2);
        setdrops1();
    });
$('#disd6op1').change(
    function (event) {
        var int1 = event.target.value;
        var int2 = 1;
        setview2(int1, int2);
        setdrops2();
    });
$('.disdrside').change(
    function (event) {
        var int1 = event.target.value;
        var int2 = 2;
        setview1(int1, int2);
        $("#disdrop1").val(int1);
        $("#disdr001").val(1); // clear
        $("#disdr002").val(1); // clear
        $("#disdr003").val(1); // clear
        $("#disdr004").val(1); // clear
        $("#disdr005").val(1); // clear
        $("#disdr006").val(1); // clear
        $("#disdr007").val(1); // clear
        $("#disdr008").val(1); // clear
        $("#disdr009").val(1); // clear
        $("#disdr010").val(1); // clear
        $("#disdr011").val(1); // clear
        $("#disdr012").val(1); // clear
        $("#disdr013").val(1); // clear
        $("#disdr014").val(1); // clear
        $("#disdr201").val(1); // clear
        $("#disdr202").val(1); // clear
        $("#disdr203").val(1); // clear
        $("#disdr204").val(1); // clear
    });
$('.disd6side').change(
    function (event) {
        var int1 = event.target.value;
        var int2 = 2;
        setview2(int1, int2);
        $("#disd6op1").val(int1);
        $("#dis6r001").val(1); // clear
        $("#dis6r002").val(1); // clear
        $("#dis6r003").val(1); // clear
        $("#dis6r004").val(1); // clear
        $("#dis6r005").val(1); // clear
        $("#dis6r006").val(1); // clear
        $("#dis6r201").val(1); // clear
        $("#dis6r202").val(1); // clear
        $("#dis6r203").val(1); // clear
        $("#dis6r204").val(1); // clear
        $("#dis6r205").val(1); // clear
    });
function setdrops1() {
    disside01();
    disside02();
    disside03();
    disside04();
    disside05();
    disside06();
    disside07();
    disside08();
    disside09();
    disside10();
    disside11();
    disside12();
    disside13();
    disside14();
    disdr201();
    disdr202();
    disdr203();
    disdr204();
}
function setdrops2() {
    dis6ide01();
    dis6ide02();
    dis6ide03();
    dis6ide04();
    dis6ide05();
    dis6ide06();
    dis6ide21();
    dis6ide22();
    dis6ide23();
    dis6ide24();
    dis6ide25();
}
function setview1(int1, int2) {
    var intg1 = $("#perdrop1").val();
    var intg2 = $("#wekdrop1").val();
    if (int2 == 1) {      
        var intg3 = $("#disdrop1").val();
    } else if (int2 == 2){
        var intg3 = int1;
    }   
    $.ajax({
        url: '/uhsCH/viewres1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: intg1, ID2: intg2, ID3: intg3 },
        success: function (dtcr1010001) {
            var tstp011 = dtcr1010001.tstp011;
            var tstp012 = dtcr1010001.tstp012;
            var tstp013 = dtcr1010001.tstp013;
            var tstp014 = dtcr1010001.tstp014;
            var tstp015 = dtcr1010001.tstp015;
            var tstp016 = dtcr1010001.tstp016;
            var tstp017 = dtcr1010001.tstp017;
            var tstp021 = dtcr1010001.tstp021;
            var tstp022 = dtcr1010001.tstp022;
            var tstp023 = dtcr1010001.tstp023;
            var tstp024 = dtcr1010001.tstp024;
            var tstp025 = dtcr1010001.tstp025;
            var tstp026 = dtcr1010001.tstp026;
            var tstp027 = dtcr1010001.tstp027;
            var tstp031 = dtcr1010001.tstp031;
            var tstp032 = dtcr1010001.tstp032;
            var tstp033 = dtcr1010001.tstp033;
            var tstp034 = dtcr1010001.tstp034;
            var tstp035 = dtcr1010001.tstp035;
            var tstp036 = dtcr1010001.tstp036;
            var tstp037 = dtcr1010001.tstp037;
            var tstp041 = dtcr1010001.tstp041;
            var tstp042 = dtcr1010001.tstp042;
            var tstp043 = dtcr1010001.tstp043;
            var tstp044 = dtcr1010001.tstp044;
            var tstp045 = dtcr1010001.tstp045;
            var tstp046 = dtcr1010001.tstp046;
            var tstp047 = dtcr1010001.tstp047;
            var tstp051 = dtcr1010001.tstp051;
            var tstp052 = dtcr1010001.tstp052;
            var tstp053 = dtcr1010001.tstp053;
            var tstp054 = dtcr1010001.tstp054;
            var tstp055 = dtcr1010001.tstp055;
            var tstp056 = dtcr1010001.tstp056;
            var tstp057 = dtcr1010001.tstp057;
            var tstp061 = dtcr1010001.tstp061;
            var tstp062 = dtcr1010001.tstp062;
            var tstp063 = dtcr1010001.tstp063;
            var tstp064 = dtcr1010001.tstp064;
            var tstp065 = dtcr1010001.tstp065;
            var tstp066 = dtcr1010001.tstp066;
            var tstp067 = dtcr1010001.tstp067;
            var tstp071 = dtcr1010001.tstp071;
            var tstp072 = dtcr1010001.tstp072;
            var tstp073 = dtcr1010001.tstp073;
            var tstp074 = dtcr1010001.tstp074;
            var tstp075 = dtcr1010001.tstp075;
            var tstp076 = dtcr1010001.tstp076;
            var tstp077 = dtcr1010001.tstp077;
            var tstp081 = dtcr1010001.tstp081;
            var tstp082 = dtcr1010001.tstp082;
            var tstp083 = dtcr1010001.tstp083;
            var tstp084 = dtcr1010001.tstp084;
            var tstp085 = dtcr1010001.tstp085;
            var tstp086 = dtcr1010001.tstp086;
            var tstp087 = dtcr1010001.tstp087;
            var tstp091 = dtcr1010001.tstp091;
            var tstp092 = dtcr1010001.tstp092;
            var tstp093 = dtcr1010001.tstp093;
            var tstp094 = dtcr1010001.tstp094;
            var tstp095 = dtcr1010001.tstp095;
            var tstp096 = dtcr1010001.tstp096;
            var tstp097 = dtcr1010001.tstp097;
            var tstp101 = dtcr1010001.tstp101;
            var tstp102 = dtcr1010001.tstp102;
            var tstp103 = dtcr1010001.tstp103;
            var tstp104 = dtcr1010001.tstp104;
            var tstp105 = dtcr1010001.tstp105;
            var tstp106 = dtcr1010001.tstp106;
            var tstp107 = dtcr1010001.tstp107;
            var tstp111 = dtcr1010001.tstp111;
            var tstp112 = dtcr1010001.tstp112;
            var tstp113 = dtcr1010001.tstp113;
            var tstp114 = dtcr1010001.tstp114;
            var tstp115 = dtcr1010001.tstp115;
            var tstp116 = dtcr1010001.tstp116;
            var tstp117 = dtcr1010001.tstp117;
            var tstp121 = dtcr1010001.tstp121;
            var tstp122 = dtcr1010001.tstp122;
            var tstp123 = dtcr1010001.tstp123;
            var tstp124 = dtcr1010001.tstp124;
            var tstp125 = dtcr1010001.tstp125;
            var tstp126 = dtcr1010001.tstp126;
            var tstp127 = dtcr1010001.tstp127;
            var tstp131 = dtcr1010001.tstp131;
            var tstp132 = dtcr1010001.tstp132;
            var tstp133 = dtcr1010001.tstp133;
            var tstp134 = dtcr1010001.tstp134;
            var tstp135 = dtcr1010001.tstp135;
            var tstp136 = dtcr1010001.tstp136;
            var tstp137 = dtcr1010001.tstp137;
            var tstp141 = dtcr1010001.tstp141;
            var tstp142 = dtcr1010001.tstp142;
            var tstp143 = dtcr1010001.tstp143;
            var tstp144 = dtcr1010001.tstp144;
            var tstp145 = dtcr1010001.tstp145;
            var tstp146 = dtcr1010001.tstp146;
            var tstp147 = dtcr1010001.tstp147;
            var tstp151 = dtcr1010001.tstp151;
            var tstp152 = dtcr1010001.tstp152;
            var tstp153 = dtcr1010001.tstp153;
            var tstp154 = dtcr1010001.tstp154;
            var tstp155 = dtcr1010001.tstp155;
            var tstp156 = dtcr1010001.tstp156;
            var tstp157 = dtcr1010001.tstp157;
            var tstp161 = dtcr1010001.tstp161;
            var tstp162 = dtcr1010001.tstp162;
            var tstp163 = dtcr1010001.tstp163;
            var tstp164 = dtcr1010001.tstp164;
            var tstp165 = dtcr1010001.tstp165;
            var tstp166 = dtcr1010001.tstp166;
            var tstp167 = dtcr1010001.tstp167;
            var tstp171 = dtcr1010001.tstp171;
            var tstp172 = dtcr1010001.tstp172;
            var tstp173 = dtcr1010001.tstp173;
            var tstp174 = dtcr1010001.tstp174;
            var tstp175 = dtcr1010001.tstp175;
            var tstp176 = dtcr1010001.tstp176;
            var tstp177 = dtcr1010001.tstp177;
            var tstp181 = dtcr1010001.tstp181;
            var tstp182 = dtcr1010001.tstp182;
            var tstp183 = dtcr1010001.tstp183;
            var tstp184 = dtcr1010001.tstp184;
            var tstp185 = dtcr1010001.tstp185;
            var tstp186 = dtcr1010001.tstp186;
            var tstp187 = dtcr1010001.tstp187;
            if (tstp011 == 1) { $("#ic1010011").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010011").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp012 == 1) { $("#ic1010012").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010012").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp013 == 1) { $("#ic1010013").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010013").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp014 == 1) { $("#ic1010014").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010014").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp015 == 1) { $("#ic1010015").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010015").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp016 == 1) { $("#ic1010016").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010016").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp017 == 1) { $("#ic1010017").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010017").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp021 == 1) { $("#ic1010021").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010021").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp022 == 1) { $("#ic1010022").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010022").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp023 == 1) { $("#ic1010023").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010023").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp024 == 1) { $("#ic1010024").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010024").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp025 == 1) { $("#ic1010025").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010025").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp026 == 1) { $("#ic1010026").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010026").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp027 == 1) { $("#ic1010027").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010027").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp031 == 1) { $("#ic1010031").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010031").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp032 == 1) { $("#ic1010032").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010032").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp033 == 1) { $("#ic1010033").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010033").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp034 == 1) { $("#ic1010034").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010034").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp035 == 1) { $("#ic1010035").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010035").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp036 == 1) { $("#ic1010036").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010036").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp037 == 1) { $("#ic1010037").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010037").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp041 == 1) { $("#ic1010041").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010041").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp042 == 1) { $("#ic1010042").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010042").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp043 == 1) { $("#ic1010043").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010043").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp044 == 1) { $("#ic1010044").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010044").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp045 == 1) { $("#ic1010045").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010045").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp046 == 1) { $("#ic1010046").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010046").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp047 == 1) { $("#ic1010047").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010047").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp051 == 1) { $("#ic1010051").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010051").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp052 == 1) { $("#ic1010052").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010052").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp053 == 1) { $("#ic1010053").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010053").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp054 == 1) { $("#ic1010054").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010054").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp055 == 1) { $("#ic1010055").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010055").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp056 == 1) { $("#ic1010056").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010056").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp057 == 1) { $("#ic1010057").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010057").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp061 == 1) { $("#ic1010061").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010061").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp062 == 1) { $("#ic1010062").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010062").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp063 == 1) { $("#ic1010063").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010063").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp064 == 1) { $("#ic1010064").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010064").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp065 == 1) { $("#ic1010065").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010065").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp066 == 1) { $("#ic1010066").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010066").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp067 == 1) { $("#ic1010067").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010067").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp071 == 1) { $("#ic1010071").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010071").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp072 == 1) { $("#ic1010072").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010072").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp073 == 1) { $("#ic1010073").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010073").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp074 == 1) { $("#ic1010074").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010074").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp075 == 1) { $("#ic1010075").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010075").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp076 == 1) { $("#ic1010076").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010076").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp077 == 1) { $("#ic1010077").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010077").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp081 == 1) { $("#ic1010081").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010081").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp082 == 1) { $("#ic1010082").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010082").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp083 == 1) { $("#ic1010083").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010083").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp084 == 1) { $("#ic1010084").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010084").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp085 == 1) { $("#ic1010085").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010085").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp086 == 1) { $("#ic1010086").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010086").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp087 == 1) { $("#ic1010087").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010087").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp091 == 1) { $("#ic1010091").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010091").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp092 == 1) { $("#ic1010092").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010092").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp093 == 1) { $("#ic1010093").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010093").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp094 == 1) { $("#ic1010094").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010094").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp095 == 1) { $("#ic1010095").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010095").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp096 == 1) { $("#ic1010096").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010096").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp097 == 1) { $("#ic1010097").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010097").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp101 == 1) { $("#ic1010101").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010101").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp102 == 1) { $("#ic1010102").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010102").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp103 == 1) { $("#ic1010103").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010103").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp104 == 1) { $("#ic1010104").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010104").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp105 == 1) { $("#ic1010105").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010105").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp106 == 1) { $("#ic1010106").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010106").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp107 == 1) { $("#ic1010107").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010107").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp111 == 1) { $("#ic1010111").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010111").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp112 == 1) { $("#ic1010112").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010112").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp113 == 1) { $("#ic1010113").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010113").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp114 == 1) { $("#ic1010114").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010114").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp115 == 1) { $("#ic1010115").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010115").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp116 == 1) { $("#ic1010116").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010116").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp117 == 1) { $("#ic1010117").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010117").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp121 == 1) { $("#ic1010121").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010121").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp122 == 1) { $("#ic1010122").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010122").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp123 == 1) { $("#ic1010123").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010123").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp124 == 1) { $("#ic1010124").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010124").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp125 == 1) { $("#ic1010125").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010125").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp126 == 1) { $("#ic1010126").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010126").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp127 == 1) { $("#ic1010127").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010127").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp131 == 1) { $("#ic1010131").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010131").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp132 == 1) { $("#ic1010132").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010132").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp133 == 1) { $("#ic1010133").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010133").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp134 == 1) { $("#ic1010134").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010134").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp135 == 1) { $("#ic1010135").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010135").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp136 == 1) { $("#ic1010136").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010136").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp137 == 1) { $("#ic1010137").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010137").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp141 == 1) { $("#ic1010141").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010141").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp142 == 1) { $("#ic1010142").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010142").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp143 == 1) { $("#ic1010143").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010143").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp144 == 1) { $("#ic1010144").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010144").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp145 == 1) { $("#ic1010145").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010145").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp146 == 1) { $("#ic1010146").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010146").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp147 == 1) { $("#ic1010147").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010147").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp154 == 1) { $("#ic1010154").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010154").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp164 == 1) { $("#ic1010164").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010164").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp174 == 1) { $("#ic1010174").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010174").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp184 == 1) { $("#ic1010184").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1010184").removeClass().addClass('fa fa-check').css("color", "white"); }

            if (tstp011 == 0 && tstp021 == 0 && tstp031 == 0 && tstp041 == 0 && tstp051 == 0 && tstp061 == 0 && tstp071 == 0 && tstp081 == 0 && tstp091 == 0 && tstp101 == 0 && tstp111 == 0 && tstp121 == 0 && tstp131 == 0 && tstp141 == 0) {
                $("#ic101s01").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp011 == 1 && tstp021 == 1 && tstp031 == 1 && tstp041 == 1 && tstp051 == 1 && tstp061 == 1 && tstp071 == 1 && tstp081 == 1 && tstp091 == 1 && tstp101 == 1 && tstp111 == 1 && tstp121 == 1 && tstp131 == 1 && tstp141 == 1) {
                $("#ic101s01").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic101s01").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp012 == 0 && tstp022 == 0 && tstp032 == 0 && tstp042 == 0 && tstp052 == 0 && tstp062 == 0 && tstp072 == 0 && tstp082 == 0 && tstp092 == 0 && tstp102 == 0 && tstp112 == 0 && tstp122 == 0 && tstp132 == 0 && tstp142 == 0) {
                $("#ic101s02").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp012 == 1 && tstp022 == 1 && tstp032 == 1 && tstp042 == 1 && tstp052 == 1 && tstp062 == 1 && tstp072 == 1 && tstp082 == 1 && tstp092 == 1 && tstp102 == 1 && tstp112 == 1 && tstp122 == 1 && tstp132 == 1 && tstp142 == 1) {
                $("#ic101s02").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic101s02").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp013 == 0 && tstp023 == 0 && tstp033 == 0 && tstp043 == 0 && tstp053 == 0 && tstp063 == 0 && tstp073 == 0 && tstp083 == 0 && tstp093 == 0 && tstp103 == 0 && tstp113 == 0 && tstp123 == 0 && tstp133 == 0 && tstp143 == 0) {
                $("#ic101s03").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp013 == 1 && tstp023 == 1 && tstp033 == 1 && tstp043 == 1 && tstp053 == 1 && tstp063 == 1 && tstp073 == 1 && tstp083 == 1 && tstp093 == 1 && tstp103 == 1 && tstp113 == 1 && tstp123 == 1 && tstp133 == 1 && tstp143 == 1) {
                $("#ic101s03").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic101s03").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp014 == 0 && tstp024 == 0 && tstp034 == 0 && tstp044 == 0 && tstp054 == 0 && tstp064 == 0 && tstp074 == 0 && tstp084 == 0 && tstp094 == 0 && tstp104 == 0 && tstp114 == 0 && tstp124 == 0 && tstp134 == 0 && tstp144 == 0) {
                $("#ic101s04").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp014 == 1 && tstp024 == 1 && tstp034 == 1 && tstp044 == 1 && tstp054 == 1 && tstp064 == 1 && tstp074 == 1 && tstp084 == 1 && tstp094 == 1 && tstp104 == 1 && tstp114 == 1 && tstp124 == 1 && tstp134 == 1 && tstp144 == 1) {
                $("#ic101s04").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic101s04").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp015 == 0 && tstp025 == 0 && tstp035 == 0 && tstp045 == 0 && tstp055 == 0 && tstp065 == 0 && tstp075 == 0 && tstp085 == 0 && tstp095 == 0 && tstp105 == 0 && tstp115 == 0 && tstp125 == 0 && tstp135 == 0 && tstp145 == 0) {
                $("#ic101s05").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp015 == 1 && tstp025 == 1 && tstp035 == 1 && tstp045 == 1 && tstp055 == 1 && tstp065 == 1 && tstp075 == 1 && tstp085 == 1 && tstp095 == 1 && tstp105 == 1 && tstp115 == 1 && tstp125 == 1 && tstp135 == 1 && tstp145 == 1) {
                $("#ic101s05").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic101s05").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp016 == 0 && tstp026 == 0 && tstp036 == 0 && tstp046 == 0 && tstp056 == 0 && tstp066 == 0 && tstp076 == 0 && tstp086 == 0 && tstp096 == 0 && tstp106 == 0 && tstp116 == 0 && tstp126 == 0 && tstp136 == 0 && tstp146 == 0) {
                $("#ic101s06").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp016 == 1 && tstp026 == 1 && tstp036 == 1 && tstp046 == 1 && tstp056 == 1 && tstp066 == 1 && tstp076 == 1 && tstp086 == 1 && tstp096 == 1 && tstp106 == 1 && tstp116 == 1 && tstp126 == 1 && tstp136 == 1 && tstp146 == 1) {
                $("#ic101s06").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic101s06").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp017 == 0 && tstp027 == 0 && tstp037 == 0 && tstp047 == 0 && tstp057 == 0 && tstp067 == 0 && tstp077 == 0 && tstp087 == 0 && tstp097 == 0 && tstp107 == 0 && tstp117 == 0 && tstp127 == 0 && tstp137 == 0 && tstp147 == 0) {
                $("#ic101s07").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp017 == 1 && tstp027 == 1 && tstp037 == 1 && tstp047 == 1 && tstp057 == 1 && tstp067 == 1 && tstp077 == 1 && tstp087 == 1 && tstp097 == 1 && tstp107 == 1 && tstp117 == 1 && tstp127 == 1 && tstp137 == 1 && tstp147 == 1) {
                $("#ic101s07").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic101s07").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp154 == 0 && tstp164 == 0 && tstp174 == 0 && tstp184 == 0) {
                $("#ic102s04").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp154 == 1 && tstp164 == 1 && tstp174 == 1 && tstp184 == 1) {
                $("#ic102s04").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic102s04").removeClass().addClass('fa fa-close').css("color", "red");
            }

        }
    });       
};
function setview2(int1, int2) {
    var intg1 = $("#perd6op1").val();
    var intg2 = $("#wekd6op1").val();
    if (int2 == 1) {
        var intg3 = $("#disd6op1").val();
    } else if (int2 == 2) {
        var intg3 = int1;
    }
    $.ajax({
        url: '/uhsCH/viewres2',
        type: "GET",
        dataType: "JSON",
        data: { ID1: intg1, ID2: intg2, ID3: intg3 },
        success: function (dtcr1010001) {
            var tstp011 = dtcr1010001.tstp011;
            var tstp012 = dtcr1010001.tstp012;
            var tstp013 = dtcr1010001.tstp013;
            var tstp014 = dtcr1010001.tstp014;
            var tstp015 = dtcr1010001.tstp015;
            var tstp016 = dtcr1010001.tstp016;
            var tstp017 = dtcr1010001.tstp017;
            var tstp021 = dtcr1010001.tstp021;
            var tstp022 = dtcr1010001.tstp022;
            var tstp023 = dtcr1010001.tstp023;
            var tstp024 = dtcr1010001.tstp024;
            var tstp025 = dtcr1010001.tstp025;
            var tstp026 = dtcr1010001.tstp026;
            var tstp027 = dtcr1010001.tstp027;
            var tstp031 = dtcr1010001.tstp031;
            var tstp032 = dtcr1010001.tstp032;
            var tstp033 = dtcr1010001.tstp033;
            var tstp034 = dtcr1010001.tstp034;
            var tstp035 = dtcr1010001.tstp035;
            var tstp036 = dtcr1010001.tstp036;
            var tstp037 = dtcr1010001.tstp037;
            var tstp041 = dtcr1010001.tstp041;
            var tstp042 = dtcr1010001.tstp042;
            var tstp043 = dtcr1010001.tstp043;
            var tstp044 = dtcr1010001.tstp044;
            var tstp045 = dtcr1010001.tstp045;
            var tstp046 = dtcr1010001.tstp046;
            var tstp047 = dtcr1010001.tstp047;
            var tstp051 = dtcr1010001.tstp051;
            var tstp052 = dtcr1010001.tstp052;
            var tstp053 = dtcr1010001.tstp053;
            var tstp054 = dtcr1010001.tstp054;
            var tstp055 = dtcr1010001.tstp055;
            var tstp056 = dtcr1010001.tstp056;
            var tstp057 = dtcr1010001.tstp057;
            var tstp061 = dtcr1010001.tstp061;
            var tstp062 = dtcr1010001.tstp062;
            var tstp063 = dtcr1010001.tstp063;
            var tstp064 = dtcr1010001.tstp064;
            var tstp065 = dtcr1010001.tstp065;
            var tstp066 = dtcr1010001.tstp066;
            var tstp067 = dtcr1010001.tstp067;
            var tstp073 = dtcr1010001.tstp073;
            var tstp083 = dtcr1010001.tstp083;
            var tstp093 = dtcr1010001.tstp093;
            var tstp103 = dtcr1010001.tstp103;
            var tstp113 = dtcr1010001.tstp113;
            if (tstp011 == 1) { $("#ic1020011").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020011").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp012 == 1) { $("#ic1020012").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020012").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp013 == 1) { $("#ic1020013").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020013").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp014 == 1) { $("#ic1020014").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020014").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp015 == 1) { $("#ic1020015").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020015").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp016 == 1) { $("#ic1020016").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020016").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp017 == 1) { $("#ic1020017").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020017").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp021 == 1) { $("#ic1020021").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020021").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp022 == 1) { $("#ic1020022").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020022").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp023 == 1) { $("#ic1020023").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020023").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp024 == 1) { $("#ic1020024").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020024").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp025 == 1) { $("#ic1020025").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020025").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp026 == 1) { $("#ic1020026").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020026").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp027 == 1) { $("#ic1020027").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020027").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp031 == 1) { $("#ic1020031").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020031").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp032 == 1) { $("#ic1020032").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020032").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp033 == 1) { $("#ic1020033").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020033").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp034 == 1) { $("#ic1020034").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020034").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp035 == 1) { $("#ic1020035").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020035").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp036 == 1) { $("#ic1020036").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020036").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp037 == 1) { $("#ic1020037").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020037").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp041 == 1) { $("#ic1020041").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020041").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp042 == 1) { $("#ic1020042").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020042").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp043 == 1) { $("#ic1020043").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020043").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp044 == 1) { $("#ic1020044").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020044").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp045 == 1) { $("#ic1020045").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020045").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp046 == 1) { $("#ic1020046").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020046").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp047 == 1) { $("#ic1020047").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020047").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp051 == 1) { $("#ic1020051").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020051").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp052 == 1) { $("#ic1020052").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020052").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp053 == 1) { $("#ic1020053").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020053").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp054 == 1) { $("#ic1020054").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020054").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp055 == 1) { $("#ic1020055").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020055").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp056 == 1) { $("#ic1020056").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020056").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp057 == 1) { $("#ic1020057").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020057").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp061 == 1) { $("#ic1020061").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020061").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp062 == 1) { $("#ic1020062").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020062").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp063 == 1) { $("#ic1020063").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020063").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp064 == 1) { $("#ic1020064").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020064").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp065 == 1) { $("#ic1020065").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020065").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp066 == 1) { $("#ic1020066").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020066").removeClass().addClass('fa fa-check').css("color", "white"); }
            if (tstp067 == 1) { $("#ic1020067").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020067").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp073 == 1) { $("#ic1020073").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020073").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp083 == 1) { $("#ic1020083").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020083").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp093 == 1) { $("#ic1020093").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020093").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp103 == 1) { $("#ic1020103").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020103").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }
            if (tstp113 == 1) { $("#ic1020113").removeClass().addClass('fa fa-check').css("color", "green"); } else { $("#ic1020113").removeClass().addClass('fa fa-check').css("color", "#F8F8F8"); }

            if (tstp011 == 0 && tstp021 == 0 && tstp031 == 0 && tstp041 == 0 && tstp051 == 0 && tstp061 == 0) {
                $("#ic1020f11").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp011 == 1 && tstp021 == 1 && tstp031 == 1 && tstp041 == 1 && tstp051 == 1 && tstp061 == 1) {
                $("#ic1020f11").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic1020f11").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp012 == 0 && tstp022 == 0 && tstp032 == 0 && tstp042 == 0 && tstp052 == 0 && tstp062 == 0) {
                $("#ic1020f12").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp012 == 1 && tstp022 == 1 && tstp032 == 1 && tstp042 == 1 && tstp052 == 1 && tstp062 == 1) {
                $("#ic1020f12").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic1020f12").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp013 == 0 && tstp023 == 0 && tstp033 == 0 && tstp043 == 0 && tstp053 == 0 && tstp063 == 0) {
                $("#ic1020f13").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp013 == 1 && tstp023 == 1 && tstp033 == 1 && tstp043 == 1 && tstp053 == 1 && tstp063 == 1) {
                $("#ic1020f13").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic1020f13").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp014 == 0 && tstp024 == 0 && tstp034 == 0 && tstp044 == 0 && tstp054 == 0 && tstp064 == 0) {
                $("#ic1020f14").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp014 == 1 && tstp024 == 1 && tstp034 == 1 && tstp044 == 1 && tstp054 == 1 && tstp064 == 1) {
                $("#ic1020f14").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic1020f14").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp015 == 0 && tstp025 == 0 && tstp035 == 0 && tstp045 == 0 && tstp055 == 0 && tstp065 == 0) {
                $("#ic1020f15").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp015 == 1 && tstp025 == 1 && tstp035 == 1 && tstp045 == 1 && tstp055 == 1 && tstp065 == 1) {
                $("#ic1020f15").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic1020f15").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp016 == 0 && tstp026 == 0 && tstp036 == 0 && tstp046 == 0 && tstp056 == 0 && tstp066 == 0) {
                $("#ic1020f16").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp016 == 1 && tstp026 == 1 && tstp036 == 1 && tstp046 == 1 && tstp056 == 1 && tstp066 == 1) {
                $("#ic1020f16").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic1020f16").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp017 == 0 && tstp027 == 0 && tstp037 == 0 && tstp047 == 0 && tstp057 == 0 && tstp067 == 0) {
                $("#ic1020f17").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp017 == 1 && tstp027 == 1 && tstp037 == 1 && tstp047 == 1 && tstp057 == 1 && tstp067 == 1) {
                $("#ic1020f17").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic1020f17").removeClass().addClass('fa fa-close').css("color", "red");
            }

            if (tstp073 == 0 && tstp083 == 0 && tstp093 == 0 && tstp103 == 0 && tstp113 == 0) {
                $("#ic1020f20").removeClass().addClass('fa fa-check').css("color", "white");
            } else if (tstp073 == 1 && tstp083 == 1 && tstp093 == 1 && tstp103 == 1 && tstp113 == 1) {
                $("#ic1020f20").removeClass().addClass('fa fa-check').css("color", "green");
            } else {
                $("#ic1020f20").removeClass().addClass('fa fa-close').css("color", "red");
            }
        }
    });
};
function weekdrop1() {
    var int1 = $("#perdrop1").val();
    $.ajax({
        url: '/uhsCH/wekdrop1',
        type: "GET",
        dataType: "JSON",
        data: { ID: int1 },
        success: function (populate) {
            //console.log(list);
            $("#wekdrop1").html(""); // clear before appending new list
            $.each(populate, function (ID, list) {
                $("#wekdrop1").append(
                    $('<option></option>').val(list.ID).html(list.Value));
            });
            distdrop1();
        }
    });
}
function wekd6op1() {
    var int1 = $("#perd6op1").val();
    $.ajax({
        url: '/uhsCH/wekd6op1',
        type: "GET",
        dataType: "JSON",
        data: { ID: int1 },
        success: function (populate) {
            //console.log(list);
            $("#wekd6op1").html(""); // clear before appending new list
            $.each(populate, function (ID, list) {
                $("#wekd6op1").append(
                    $('<option></option>').val(list.ID).html(list.Value));
            });
            disd6op1();
        }
    });
}
function distdrop1() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdrop1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2 },
        success: function (populate) {
            //console.log(list);
            $("#disdrop1").html(""); // clear before appending new list
            $.each(populate, function (ID, list) {
                $("#disdrop1").append(
                    $('<option></option>').val(list.ID).html(list.Value));
            });
        }
    });
}
function disd6op1() {
    var int1 = $("#perd6op1").val();
    var int2 = $("#wekd6op1").val();
    $.ajax({
        url: '/uhsCH/disd6op1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2 },
        success: function (populate) {
            //console.log(list);
            $("#disd6op1").html(""); // clear before appending new list
            $.each(populate, function (ID, list) {
                $("#disd6op1").append(
                    $('<option></option>').val(list.ID).html(list.Value));
            });
        }
    });
}
function disside01() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 1  },
        success: function (populate) {
            $("#disdr001").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr001").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disside02() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 2 },
        success: function (populate) {       
            $("#disdr002").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr002").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disside03() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 3 },
        success: function (populate) {
            $("#disdr003").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr003").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disside04() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 4 },
        success: function (populate) {
            $("#disdr004").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr004").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disside05() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 5 },
        success: function (populate) {
            $("#disdr005").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr005").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disside06() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 6 },
        success: function (populate) {
            $("#disdr006").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr006").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disside07() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 7 },
        success: function (populate) {
            $("#disdr007").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr007").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disside08() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 8 },
        success: function (populate) {
            $("#disdr008").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr008").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disside09() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 9 },
        success: function (populate) {
            $("#disdr009").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr009").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disside10() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 10 },
        success: function (populate) {
            $("#disdr010").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr010").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disside11() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 11 },
        success: function (populate) {
            $("#disdr011").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr011").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disside12() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 12 },
        success: function (populate) {
            $("#disdr012").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr012").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disside13() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 13 },
        success: function (populate) {
            $("#disdr013").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr013").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disside14() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 14 },
        success: function (populate) {
            $("#disdr014").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr014").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disdr201() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 15 },
        success: function (populate) {
            $("#disdr201").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr201").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disdr202() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 16 },
        success: function (populate) {
            $("#disdr202").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr202").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disdr203() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 17 },
        success: function (populate) {
            $("#disdr203").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr203").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function disdr204() {
    var int1 = $("#perdrop1").val();
    var int2 = $("#wekdrop1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 18 },
        success: function (populate) {
            $("#disdr204").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#disdr204").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function dis6ide01() {
    var int1 = $("#perd6op1").val();
    var int2 = $("#wekd6op1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 111 },
        success: function (populate) {
            $("#dis6r001").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#dis6r001").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function dis6ide02() {
    var int1 = $("#perd6op1").val();
    var int2 = $("#wekd6op1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 112 },
        success: function (populate) {
            $("#dis6r002").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#dis6r002").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function dis6ide03() {
    var int1 = $("#perd6op1").val();
    var int2 = $("#wekd6op1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 113 },
        success: function (populate) {
            $("#dis6r003").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#dis6r003").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function dis6ide04() {
    var int1 = $("#perd6op1").val();
    var int2 = $("#wekd6op1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 114 },
        success: function (populate) {
            $("#dis6r004").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#dis6r004").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function dis6ide05() {
    var int1 = $("#perd6op1").val();
    var int2 = $("#wekd6op1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 115 },
        success: function (populate) {
            $("#dis6r005").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#dis6r005").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function dis6ide06() {
    var int1 = $("#perd6op1").val();
    var int2 = $("#wekd6op1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 116 },
        success: function (populate) {
            $("#dis6r006").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#dis6r006").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function dis6ide21() {
    var int1 = $("#perd6op1").val();
    var int2 = $("#wekd6op1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 121 },
        success: function (populate) {
            $("#dis6r201").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#dis6r201").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function dis6ide22() {
    var int1 = $("#perd6op1").val();
    var int2 = $("#wekd6op1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 122 },
        success: function (populate) {
            $("#dis6r202").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#dis6r202").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function dis6ide23() {
    var int1 = $("#perd6op1").val();
    var int2 = $("#wekd6op1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 123 },
        success: function (populate) {
            $("#dis6r203").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#dis6r203").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function dis6ide24() {
    var int1 = $("#perd6op1").val();
    var int2 = $("#wekd6op1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 124 },
        success: function (populate) {
            $("#dis6r204").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#dis6r204").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function dis6ide25() {
    var int1 = $("#perd6op1").val();
    var int2 = $("#wekd6op1").val();
    $.ajax({
        url: '/uhsCH/disdr1',
        type: "GET",
        dataType: "JSON",
        data: { ID1: int1, ID2: int2, ID3: 125 },
        success: function (populate) {
            $("#dis6r205").html(""); // clear before appending new list
            $.each(populate, function (ID, uhsdisdrp1s) {
                $("#dis6r205").append(
                    $('<option></option>').val(uhsdisdrp1s.ID).html(uhsdisdrp1s.district));
            });
        }
    });
}
function post1010001() {
    var docid = $("#doc1010001id").val();
    var projid = $("#doc1010001projid").val();
    var tskoid = $("#doc1010001tskoid").val();
    var dcgrid = $("#doc1010001dcgrid").val();
    var dctpid = $("#doc1010001dctpid").val();
    var tspdid = $("#doc1010001tspdid").val();
    var distid = $("#doc1010001distid").val();
    var acctid = $("#doc1010001acctid").val();
    var userid = $("#doc1010001userid").val();
    var crusid = $("#doc1010001crusid").val();
    var edusid = $("#doc1010001edusid").val();
    var d = new Date();
    var actpch = $("#doc1010001actype").val();
    var crdtch = $("#doc1010001crdt").val();
    var chck = $('#doc1010001chck').is(":checked");
    var checkedid = $("#doc1010001chckid").val();
    var checkeddt = $("#doc1010001chckdt").val();
    var eddt = d.toISOString(); // ISO "2013-12-08T17:55:38.130Z"
    if (actpch == 2) {
        // CHECK/ED DOCUMENT
        if (chck == true) { var chckid = userid; var chckdt = eddt }
        else { var chckid = 0; var chckdt = null }
        var crdt = d.toISOString(); // ISO "2013-12-08T17:55:38.130Z"
    }
    else if (actpch == 3) {
        if (chck == true) {
            if (checkedid == edusid) {
                var chckid = checkedid;
                var chckdt = checkeddt;
            }
            else {
                var chckid = edusid;
                var chckdt = d.toISOString();
                //console.log("proba");
            }
        }
        else {
            var chckid = 0; var chckdt = null
        }
        var crdt = crdtch; // ISO "2013-12-08T17:55:38.130Z"
    }
    // ALL CHECKS
    var tstp01 = 1;
    var tstp011 = $('#tstp011').is(":checked");
    var tstp012 = $('#tstp012').is(":checked");
    var tstp013 = $('#tstp013').is(":checked");
    var tstp014 = $('#tstp014').is(":checked");
    var tstp015 = $('#tstp015').is(":checked");
    var tstp016 = $('#tstp016').is(":checked");
    var tstp017 = $('#tstp017').is(":checked");
    var tstp02 = 2;
    var tstp021 = $('#tstp021').is(":checked");
    var tstp022 = $('#tstp022').is(":checked");
    var tstp023 = $('#tstp023').is(":checked");
    var tstp024 = $('#tstp024').is(":checked");
    var tstp025 = $('#tstp025').is(":checked");
    var tstp026 = $('#tstp026').is(":checked");
    var tstp027 = $('#tstp027').is(":checked");
    var tstp03 = 3;
    var tstp031 = $('#tstp031').is(":checked");
    var tstp032 = $('#tstp032').is(":checked");
    var tstp033 = $('#tstp033').is(":checked");
    var tstp034 = $('#tstp034').is(":checked");
    var tstp035 = $('#tstp035').is(":checked");
    var tstp036 = $('#tstp036').is(":checked");
    var tstp037 = $('#tstp037').is(":checked");
    var tstp04 = 4;
    var tstp041 = $('#tstp041').is(":checked");
    var tstp042 = $('#tstp042').is(":checked");
    var tstp043 = $('#tstp043').is(":checked");
    var tstp044 = $('#tstp044').is(":checked");
    var tstp045 = $('#tstp045').is(":checked");
    var tstp046 = $('#tstp046').is(":checked");
    var tstp047 = $('#tstp047').is(":checked");
    var tstp05 = 5;
    var tstp051 = $('#tstp051').is(":checked");
    var tstp052 = $('#tstp052').is(":checked");
    var tstp053 = $('#tstp053').is(":checked");
    var tstp054 = $('#tstp054').is(":checked");
    var tstp055 = $('#tstp055').is(":checked");
    var tstp056 = $('#tstp056').is(":checked");
    var tstp057 = $('#tstp057').is(":checked");
    var tstp06 = 6;
    var tstp061 = $('#tstp061').is(":checked");
    var tstp062 = $('#tstp062').is(":checked");
    var tstp063 = $('#tstp063').is(":checked");
    var tstp064 = $('#tstp064').is(":checked");
    var tstp065 = $('#tstp065').is(":checked");
    var tstp066 = $('#tstp066').is(":checked");
    var tstp067 = $('#tstp067').is(":checked");
    var tstp07 = 7;
    var tstp071 = $('#tstp071').is(":checked");
    var tstp072 = $('#tstp072').is(":checked");
    var tstp073 = $('#tstp073').is(":checked");
    var tstp074 = $('#tstp074').is(":checked");
    var tstp075 = $('#tstp075').is(":checked");
    var tstp076 = $('#tstp076').is(":checked");
    var tstp077 = $('#tstp077').is(":checked");
    var tstp08 = 8;
    var tstp081 = $('#tstp081').is(":checked");
    var tstp082 = $('#tstp082').is(":checked");
    var tstp083 = $('#tstp083').is(":checked");
    var tstp084 = $('#tstp084').is(":checked");
    var tstp085 = $('#tstp085').is(":checked");
    var tstp086 = $('#tstp086').is(":checked");
    var tstp087 = $('#tstp087').is(":checked");
    var tstp09 = 9;
    var tstp091 = $('#tstp091').is(":checked");
    var tstp092 = $('#tstp092').is(":checked");
    var tstp093 = $('#tstp093').is(":checked");
    var tstp094 = $('#tstp094').is(":checked");
    var tstp095 = $('#tstp095').is(":checked");
    var tstp096 = $('#tstp096').is(":checked");
    var tstp097 = $('#tstp097').is(":checked");
    var tstp10 = 10;
    var tstp101 = $('#tstp101').is(":checked");
    var tstp102 = $('#tstp102').is(":checked");
    var tstp103 = $('#tstp103').is(":checked");
    var tstp104 = $('#tstp104').is(":checked");
    var tstp105 = $('#tstp105').is(":checked");
    var tstp106 = $('#tstp106').is(":checked");
    var tstp107 = $('#tstp107').is(":checked");
    var tstp11 = 11;
    var tstp111 = $('#tstp111').is(":checked");
    var tstp112 = $('#tstp112').is(":checked");
    var tstp113 = $('#tstp113').is(":checked");
    var tstp114 = $('#tstp114').is(":checked");
    var tstp115 = $('#tstp115').is(":checked");
    var tstp116 = $('#tstp116').is(":checked");
    var tstp117 = $('#tstp117').is(":checked");
    var tstp12 = 12;
    var tstp121 = $('#tstp121').is(":checked");
    var tstp122 = $('#tstp122').is(":checked");
    var tstp123 = $('#tstp123').is(":checked");
    var tstp124 = $('#tstp124').is(":checked");
    var tstp125 = $('#tstp125').is(":checked");
    var tstp126 = $('#tstp126').is(":checked");
    var tstp127 = $('#tstp127').is(":checked");
    var tstp13 = 13;
    var tstp131 = $('#tstp131').is(":checked");
    var tstp132 = $('#tstp132').is(":checked");
    var tstp133 = $('#tstp133').is(":checked");
    var tstp134 = $('#tstp134').is(":checked");
    var tstp135 = $('#tstp135').is(":checked");
    var tstp136 = $('#tstp136').is(":checked");
    var tstp137 = $('#tstp137').is(":checked");
    var tstp14 = 14;
    var tstp141 = $('#tstp141').is(":checked");
    var tstp142 = $('#tstp142').is(":checked");
    var tstp143 = $('#tstp143').is(":checked");
    var tstp144 = $('#tstp144').is(":checked");
    var tstp145 = $('#tstp145').is(":checked");
    var tstp146 = $('#tstp146').is(":checked");
    var tstp147 = $('#tstp147').is(":checked");
    var tstp15 = 15;
    var tstp151 = false;
    var tstp152 = false;
    var tstp153 = false;
    var tstp154 = $('#tstp154').is(":checked");
    var tstp155 = false;
    var tstp156 = false;
    var tstp157 = false;
    var tstp16 = 16;
    var tstp161 = false;
    var tstp162 = false;
    var tstp163 = false;
    var tstp164 = $('#tstp164').is(":checked");
    var tstp165 = false;
    var tstp166 = false;
    var tstp167 = false;
    var tstp17 = 17;
    var tstp171 = false;
    var tstp172 = false;
    var tstp173 = false;
    var tstp174 = $('#tstp174').is(":checked");
    var tstp175 = false;
    var tstp176 = false;
    var tstp177 = false;
    var tstp18 = 18;
    var tstp181 = false;
    var tstp182 = false;
    var tstp183 = false;
    var tstp184 = $('#tstp184').is(":checked");
    var tstp185 = false;
    var tstp186 = false;
    var tstp187 = false;
    var data = {
        ID: docid
        , projid: projid
        , tskoid: tskoid
        , dcgrid: dcgrid
        , dctpid: dctpid
        , tspdid: tspdid
        , distid: distid
        , acctid: acctid
        , userid: userid
        , tstp01: tstp01
        , tstp011: tstp011
        , tstp012: tstp012
        , tstp013: tstp013
        , tstp014: tstp014
        , tstp015: tstp015
        , tstp016: tstp016
        , tstp017: tstp017
        , tstp02: tstp02
        , tstp021: tstp021
        , tstp022: tstp022
        , tstp023: tstp023
        , tstp024: tstp024
        , tstp025: tstp025
        , tstp026: tstp026
        , tstp027: tstp027
        , tstp03: tstp03
        , tstp031: tstp031
        , tstp032: tstp032
        , tstp033: tstp033
        , tstp034: tstp034
        , tstp035: tstp035
        , tstp036: tstp036
        , tstp037: tstp037
        , tstp04: tstp04
        , tstp041: tstp041
        , tstp042: tstp042
        , tstp043: tstp043
        , tstp044: tstp044
        , tstp045: tstp045
        , tstp046: tstp046
        , tstp047: tstp047
        , tstp05: tstp05
        , tstp051: tstp051
        , tstp052: tstp052
        , tstp053: tstp053
        , tstp054: tstp054
        , tstp055: tstp055
        , tstp056: tstp056
        , tstp057: tstp057
        , tstp06: tstp06
        , tstp061: tstp061
        , tstp062: tstp062
        , tstp063: tstp063
        , tstp064: tstp064
        , tstp065: tstp065
        , tstp066: tstp066
        , tstp067: tstp067
        , tstp07: tstp07
        , tstp071: tstp071
        , tstp072: tstp072
        , tstp073: tstp073
        , tstp074: tstp074
        , tstp075: tstp075
        , tstp076: tstp076
        , tstp077: tstp077
        , tstp08: tstp08
        , tstp081: tstp081
        , tstp082: tstp082
        , tstp083: tstp083
        , tstp084: tstp084
        , tstp085: tstp085
        , tstp086: tstp086
        , tstp087: tstp087
        , tstp09: tstp09
        , tstp091: tstp091
        , tstp092: tstp092
        , tstp093: tstp093
        , tstp094: tstp094
        , tstp095: tstp095
        , tstp096: tstp096
        , tstp097: tstp097
        , tstp10: tstp10
        , tstp101: tstp101
        , tstp102: tstp102
        , tstp103: tstp103
        , tstp104: tstp104
        , tstp105: tstp105
        , tstp106: tstp106
        , tstp107: tstp107
        , tstp11: tstp11
        , tstp111: tstp111
        , tstp112: tstp112
        , tstp113: tstp113
        , tstp114: tstp114
        , tstp115: tstp115
        , tstp116: tstp116
        , tstp117: tstp117
        , tstp12: tstp12
        , tstp121: tstp121
        , tstp122: tstp122
        , tstp123: tstp123
        , tstp124: tstp124
        , tstp125: tstp125
        , tstp126: tstp126
        , tstp127: tstp127
        , tstp13: tstp13
        , tstp131: tstp131
        , tstp132: tstp132
        , tstp133: tstp133
        , tstp134: tstp134
        , tstp135: tstp135
        , tstp136: tstp136
        , tstp137: tstp137
        , tstp14: tstp14
        , tstp141: tstp141
        , tstp142: tstp142
        , tstp143: tstp143
        , tstp144: tstp144
        , tstp145: tstp145
        , tstp146: tstp146
        , tstp147: tstp147
        , tstp15: tstp15
        , tstp151: tstp151
        , tstp152: tstp152
        , tstp153: tstp153
        , tstp154: tstp154
        , tstp155: tstp155
        , tstp156: tstp156
        , tstp157: tstp157
        , tstp16: tstp16
        , tstp161: tstp161
        , tstp162: tstp162
        , tstp163: tstp163
        , tstp164: tstp164
        , tstp165: tstp165
        , tstp166: tstp166
        , tstp167: tstp167
        , tstp17: tstp17
        , tstp171: tstp171
        , tstp172: tstp172
        , tstp173: tstp173
        , tstp174: tstp174
        , tstp175: tstp175
        , tstp176: tstp176
        , tstp177: tstp177
        , tstp18: tstp18
        , tstp181: tstp181
        , tstp182: tstp182
        , tstp183: tstp183
        , tstp184: tstp184
        , tstp185: tstp185
        , tstp186: tstp186
        , tstp187: tstp187
        , chck: chck
        , chckid: chckid
        , chckdt: chckdt
        , crdt: crdt
        , eddt: eddt
        , crusid: crusid
        , edusid: edusid
    };
    //console.log(data);
    if (actpch == 2) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            url: '/uhsCH/save1010001',
            dataType: "JSON",
            success: function (resp1010001) {
                if (resp1010001 == 1) {
                    modal1010001.style.display = "none";
                    location.reload();
                }
                else if (resp1010001 == 2) {
                    alert("Failed.");
                }
                else if (resp1010001 == 4) {
                    alert("The system exited with code: 3." + "\n" + "User has NOT been authorized.");
                }
                else if (resp1010001 == 3) {
                    alert("The system exited with code: 2." + "\n" + "User has been authorized but data model state is not valid.");
                }

            }
        })
    } else if (actpch == 3) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            url: '/uhsCH/edit1010001',
            dataType: "JSON",
            success: function (resp1010001) {
                if (resp1010001 == 1) {
                    modal1010001.style.display = "none";
                    location.reload();
                }
                else if (resp1010001 == 2) {
                    alert("Exception.");
                }
                else if (resp1010001 == 4) {
                    alert("The system exited with code: 3." + "\n" + "User has NOT been authorized.");
                }
                else if (resp1010001 == 3) {
                    alert("The system exited with code: 2." + "\n" + "User has been authorized but data model state is not valid.");
                }

            }
        })
    }

}

function post1010002() {  
    var docid = $("#doc1010002id").val();
    var projid = $("#doc1010002projid").val();
    var tskoid = $("#doc1010002tskoid").val();
    var dcgrid = $("#doc1010002dcgrid").val();
    var dctpid = $("#doc1010002dctpid").val();
    var tspdid = $("#doc1010002tspdid").val();
    var distid = $("#doc1010002distid").val();
    var acctid = $("#doc1010002acctid").val();
    var userid = $("#doc1010002userid").val();
    var crusid = $("#doc1010002crusid").val();
    var edusid = $("#doc1010002edusid").val();   
    var d = new Date();
    var actpch = $("#doc1010002actype").val();
    var crdtch = $("#doc1010002crdt").val();
    var chck = $('#doc1010002chck').is(":checked");
    var checkedid = $("#doc1010002chckid").val();
    var checkeddt = $("#doc1010002chckdt").val();
    var eddt = d.toISOString(); // ISO "2013-12-08T17:55:38.130Z"
    //console.log(actpch);
    if (actpch == 2) {
        // CHECK/ED DOCUMENT
        if (chck == true) { var chckid = userid; var chckdt = eddt }
        else { var chckid = 0; var chckdt = null }
        var crdt = d.toISOString(); // ISO "2013-12-08T17:55:38.130Z"
    }
    else if (actpch == 3) {
        if (chck == true) {
            if (checkedid == edusid) {
                var chckid = checkedid;
                var chckdt = checkeddt;
            }
            else {
                var chckid = edusid;
                var chckdt = d.toISOString();
                //console.log("proba");
            }
        }
        else {
            var chckid = 0; var chckdt = null
        }
        var crdt = crdtch; // ISO "2013-12-08T17:55:38.130Z"
    }
    // ALL CHECKS

    var ts6s01 = 1;
    var ts6s011 = $('#ts6s011').is(":checked");
    var ts6s012 = $('#ts6s012').is(":checked");
    var ts6s013 = $('#ts6s013').is(":checked");
    var ts6s014 = $('#ts6s014').is(":checked");
    var ts6s015 = $('#ts6s015').is(":checked");
    var ts6s016 = $('#ts6s016').is(":checked");
    var ts6s017 = $('#ts6s017').is(":checked");
    var ts6s02 = 2;
    var ts6s021 = $('#ts6s021').is(":checked");
    var ts6s022 = $('#ts6s022').is(":checked");
    var ts6s023 = $('#ts6s023').is(":checked");
    var ts6s024 = $('#ts6s024').is(":checked");
    var ts6s025 = $('#ts6s025').is(":checked");
    var ts6s026 = $('#ts6s026').is(":checked");
    var ts6s027 = $('#ts6s027').is(":checked");
    var ts6s03 = 3;
    var ts6s031 = $('#ts6s031').is(":checked");
    var ts6s032 = $('#ts6s032').is(":checked");
    var ts6s033 = $('#ts6s033').is(":checked");
    var ts6s034 = $('#ts6s034').is(":checked");
    var ts6s035 = $('#ts6s035').is(":checked");
    var ts6s036 = $('#ts6s036').is(":checked");
    var ts6s037 = $('#ts6s037').is(":checked");
    var ts6s04 = 4;
    var ts6s041 = $('#ts6s041').is(":checked");
    var ts6s042 = $('#ts6s042').is(":checked");
    var ts6s043 = $('#ts6s043').is(":checked");
    var ts6s044 = $('#ts6s044').is(":checked");
    var ts6s045 = $('#ts6s045').is(":checked");
    var ts6s046 = $('#ts6s046').is(":checked");
    var ts6s047 = $('#ts6s047').is(":checked");
    var ts6s05 = 5;
    var ts6s051 = $('#ts6s051').is(":checked");
    var ts6s052 = $('#ts6s052').is(":checked");
    var ts6s053 = $('#ts6s053').is(":checked");
    var ts6s054 = $('#ts6s054').is(":checked");
    var ts6s055 = $('#ts6s055').is(":checked");
    var ts6s056 = $('#ts6s056').is(":checked");
    var ts6s057 = $('#ts6s057').is(":checked");
    var ts6s06 = 6;
    var ts6s061 = $('#ts6s061').is(":checked");
    var ts6s062 = $('#ts6s062').is(":checked");
    var ts6s063 = $('#ts6s063').is(":checked");
    var ts6s064 = $('#ts6s064').is(":checked");
    var ts6s065 = $('#ts6s065').is(":checked");
    var ts6s066 = $('#ts6s066').is(":checked");
    var ts6s067 = $('#ts6s067').is(":checked");
    var ts6s07 = 7;
    var ts6s071 = false;
    var ts6s072 = false;
    var ts6s073 = $('#ts6s073').is(":checked");
    var ts6s074 = false;
    var ts6s075 = false;
    var ts6s076 = false;
    var ts6s077 = false;
    var ts6s08 = 8;
    var ts6s081 = false;
    var ts6s082 = false;
    var ts6s083 = $('#ts6s083').is(":checked");
    var ts6s084 = false;
    var ts6s085 = false;
    var ts6s086 = false;
    var ts6s087 = false;
    var ts6s09 = 9;
    var ts6s091 = false;
    var ts6s092 = false;
    var ts6s093 = $('#ts6s093').is(":checked");
    var ts6s094 = false;
    var ts6s095 = false;
    var ts6s096 = false;
    var ts6s097 = false;
    var ts6s10 = 10;
    var ts6s101 = false;
    var ts6s102 = false;
    var ts6s103 = $('#ts6s103').is(":checked");
    var ts6s104 = false;
    var ts6s105 = false;
    var ts6s106 = false;
    var ts6s107 = false;
    var ts6s11 = 11;
    var ts6s111 = false;
    var ts6s112 = false;
    var ts6s113 = $('#ts6s113').is(":checked");
    var ts6s114 = false;
    var ts6s115 = false;
    var ts6s116 = false;
    var ts6s117 = false;
    var ts6s12 = 12;
    var ts6s121 = false;
    var ts6s122 = false;
    var ts6s123 = false;
    var ts6s124 = false;
    var ts6s125 = false;
    var ts6s126 = false;
    var ts6s127 = false;
    var ts6s13 = 13;
    var ts6s131 = false;
    var ts6s132 = false;
    var ts6s133 = false;
    var ts6s134 = false;
    var ts6s135 = false;
    var ts6s136 = false;
    var ts6s137 = false;
    var ts6s14 = 14;
    var ts6s141 = false;
    var ts6s142 = false;
    var ts6s143 = false;
    var ts6s144 = false;
    var ts6s145 = false;
    var ts6s146 = false;
    var ts6s147 = false;
    var ts6s15 = 15;
    var ts6s151 = false;
    var ts6s152 = false;
    var ts6s153 = false;
    var ts6s154 = false;
    var ts6s155 = false;
    var ts6s156 = false;
    var ts6s157 = false;
    var ts6s16 = 16;
    var ts6s161 = false;
    var ts6s162 = false;
    var ts6s163 = false;
    var ts6s164 = false;
    var ts6s165 = false;
    var ts6s166 = false;
    var ts6s167 = false;
    var ts6s17 = 17;
    var ts6s171 = false;
    var ts6s172 = false;
    var ts6s173 = false;
    var ts6s174 = false;
    var ts6s175 = false;
    var ts6s176 = false;
    var ts6s177 = false;
    var ts6s18 = 18;
    var ts6s181 = false;
    var ts6s182 = false;
    var ts6s183 = false;
    var ts6s184 = false;
    var ts6s185 = false;
    var ts6s186 = false;
    var ts6s187 = false;
    var data = {
        ID: docid
            , projid: projid
            , tskoid: tskoid
            , dcgrid: dcgrid
            , dctpid: dctpid
            , tspdid: tspdid
            , distid: distid
            , acctid: acctid
            , userid: userid
            , tstp01: ts6s01
            , tstp011: ts6s011
            , tstp012: ts6s012
            , tstp013: ts6s013
            , tstp014: ts6s014
            , tstp015: ts6s015
            , tstp016: ts6s016
            , tstp017: ts6s017
            , tstp02: ts6s02
            , tstp021: ts6s021
            , tstp022: ts6s022
            , tstp023: ts6s023
            , tstp024: ts6s024
            , tstp025: ts6s025
            , tstp026: ts6s026
            , tstp027: ts6s027
            , tstp03: ts6s03
            , tstp031: ts6s031
            , tstp032: ts6s032
            , tstp033: ts6s033
            , tstp034: ts6s034
            , tstp035: ts6s035
            , tstp036: ts6s036
            , tstp037: ts6s037
            , tstp04: ts6s04
            , tstp041: ts6s041
            , tstp042: ts6s042
            , tstp043: ts6s043
            , tstp044: ts6s044
            , tstp045: ts6s045
            , tstp046: ts6s046
            , tstp047: ts6s047
            , tstp05: ts6s05
            , tstp051: ts6s051
            , tstp052: ts6s052
            , tstp053: ts6s053
            , tstp054: ts6s054
            , tstp055: ts6s055
            , tstp056: ts6s056
            , tstp057: ts6s057
            , tstp06: ts6s06
            , tstp061: ts6s061
            , tstp062: ts6s062
            , tstp063: ts6s063
            , tstp064: ts6s064
            , tstp065: ts6s065
            , tstp066: ts6s066
            , tstp067: ts6s067
            , tstp07: ts6s07
            , tstp071: ts6s071
            , tstp072: ts6s072
            , tstp073: ts6s073
            , tstp074: ts6s074
            , tstp075: ts6s075
            , tstp076: ts6s076
            , tstp077: ts6s077
            , tstp08: ts6s08
            , tstp081: ts6s081
            , tstp082: ts6s082
            , tstp083: ts6s083
            , tstp084: ts6s084
            , tstp085: ts6s085
            , tstp086: ts6s086
            , tstp087: ts6s087
            , tstp09: ts6s09
            , tstp091: ts6s091
            , tstp092: ts6s092
            , tstp093: ts6s093
            , tstp094: ts6s094
            , tstp095: ts6s095
            , tstp096: ts6s096
            , tstp097: ts6s097
            , tstp10: ts6s10
            , tstp101: ts6s101
            , tstp102: ts6s102
            , tstp103: ts6s103
            , tstp104: ts6s104
            , tstp105: ts6s105
            , tstp106: ts6s106
            , tstp107: ts6s107
            , tstp11: ts6s11
            , tstp111: ts6s111
            , tstp112: ts6s112
            , tstp113: ts6s113
            , tstp114: ts6s114
            , tstp115: ts6s115
            , tstp116: ts6s116
            , tstp117: ts6s117
            , tstp12: ts6s12
            , tstp121: ts6s121
            , tstp122: ts6s122
            , tstp123: ts6s123
            , tstp124: ts6s124
            , tstp125: ts6s125
            , tstp126: ts6s126
            , tstp127: ts6s127
            , tstp13: ts6s13
            , tstp131: ts6s131
            , tstp132: ts6s132
            , tstp133: ts6s133
            , tstp134: ts6s134
            , tstp135: ts6s135
            , tstp136: ts6s136
            , tstp137: ts6s137
            , tstp14: ts6s14
            , tstp141: ts6s141
            , tstp142: ts6s142
            , tstp143: ts6s143
            , tstp144: ts6s144
            , tstp145: ts6s145
            , tstp146: ts6s146
            , tstp147: ts6s147
            , tstp15: ts6s15
            , tstp151: ts6s151
            , tstp152: ts6s152
            , tstp153: ts6s153
            , tstp154: ts6s154
            , tstp155: ts6s155
            , tstp156: ts6s156
            , tstp157: ts6s157
            , tstp16: ts6s16
            , tstp161: ts6s161
            , tstp162: ts6s162
            , tstp163: ts6s163
            , tstp164: ts6s164
            , tstp165: ts6s165
            , tstp166: ts6s166
            , tstp167: ts6s167
            , tstp17: ts6s17
            , tstp171: ts6s171
            , tstp172: ts6s172
            , tstp173: ts6s173
            , tstp174: ts6s174
            , tstp175: ts6s175
            , tstp176: ts6s176
            , tstp177: ts6s177
            , tstp18: ts6s18
            , tstp181: ts6s181
            , tstp182: ts6s182
            , tstp183: ts6s183
            , tstp184: ts6s184
            , tstp185: ts6s185
            , tstp186: ts6s186
            , tstp187: ts6s187
            , chck: chck
            , chckid: chckid
            , chckdt: chckdt
            , crdt: crdt
            , eddt: eddt
            , crusid: crusid
            , edusid: edusid
    };
    //console.log(data);
    if (actpch == 2) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            url: '/uhsCH/save1010001',
            dataType: "JSON",
            success: function (resp1010001) {
                if (resp1010001 == 1) {
                    modal1010002.style.display = "none";
                    location.reload();
                }
                else if (resp1010001 == 2) {
                    alert("Failed.");
                }
                else if (resp1010001 == 4) {
                    alert("The system exited with code: 3." + "\n" + "User has NOT been authorized.");
                }
                else if (resp1010001 == 3) {
                    alert("The system exited with code: 2." + "\n" + "User has been authorized but data model state is not valid.");
                }
            }
        })
    } else if (actpch == 3) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            url: '/uhsCH/edit1010001',
            dataType: "JSON",
            success: function (resp1010001) {
                if (resp1010001 == 1) {
                    modal1010002.style.display = "none";
                    location.reload();
                }
                else if (resp1010001 == 2) {
                    alert("Exception.");
                }
                else if (resp1010001 == 4) {
                    alert("The system exited with code: 3." + "\n" + "User has NOT been authorized.");
                }
                else if (resp1010001 == 3) {
                    alert("The system exited with code: 2." + "\n" + "User has been authorized but data model state is not valid.");
                }

            }
        })
    }
}

function post1010003() {
    var docid = $("#doc1010003id").val();
    var projid = $("#doc1010003projid").val();
    var tskoid = $("#doc1010003tskoid").val();
    var dcgrid = $("#doc1010003dcgrid").val();
    var dctpid = $("#doc1010003dctpid").val();
    var tspdid = $("#doc1010003tspdid").val();
    var distid = $("#doc1010003distid").val();
    var acctid = $("#doc1010003acctid").val();
    var userid = $("#doc1010003userid").val();
    var crusid = $("#doc1010003crusid").val();
    var edusid = $("#doc1010003edusid").val();
    var dimgid = $("#doc1010003dimgid").val();
    var d = new Date();
    var actpch = $("#doc1010003actype").val();
    var crdtch = $("#doc1010003crdt").val();
    var chck = $('#doc1010003chck').is(":checked");
    var checkedid = $("#doc1010003chckid").val();
    var checkeddt = $("#doc1010003chckdt").val();
    var eddt = d.toISOString(); // ISO "2013-12-08T17:55:38.130Z"
    //console.log(actpch);
    if (actpch == 2) {
        // CHECK/ED DOCUMENT
        if (chck == true) { var chckid = userid; var chckdt = eddt }
        else { var chckid = 0; var chckdt = null }
        var crdt = d.toISOString(); // ISO "2013-12-08T17:55:38.130Z"
    }
    else if (actpch == 3) {
        if (chck == true) {
            if (checkedid == edusid) {
                var chckid = checkedid;
                var chckdt = checkeddt;
            }
            else {
                var chckid = edusid;
                var chckdt = d.toISOString();
                //console.log("proba");
            }
        }
        else {
            var chckid = 0; var chckdt = null
        }
        var crdt = crdtch; // ISO "2013-12-08T17:55:38.130Z"
    }
    // VALUE ELEMENTS
    GR001 = $("#gr1010003001").val();
    GR002 = $("#gr1010003002").val();
    GR003 = $("#gr1010003003").val();
    GR004 = $("#gr1010003004").val();
    GR005 = $("#gr1010003005").val();
    GR006 = $("#gr1010003006").val();
    GR007 = $("#gr1010003007").val();
    GR008 = $("#gr1010003008").val();
    GR009 = $("#gr1010003009").val();
    GR010 = $("#gr1010003010").val();
    GR011 = $("#gr1010003011").val();
    GR012 = $("#gr1010003012").val();
    GR013 = $("#gr1010003013").val();
    GR014 = $("#gr1010003014").val();
    GR015 = $("#gr1010003015").val();
    GR016 = $("#gr1010003016").val();
    GR017 = $("#gr1010003017").val();
    GR018 = $("#gr1010003018").val();
    GR019 = $("#gr1010003019").val();
    GR020 = $("#gr1010003020").val();
    GR021 = $("#gr1010003021").val();
    GR022 = $("#gr1010003022").val();
    GR023 = $("#gr1010003023").val();
    GR024 = $("#gr1010003024").val();
    GR025 = $("#gr1010003025").val();
    GR026 = $("#gr1010003026").val();
    GR027 = $("#gr1010003027").val();
    GR028 = $("#gr1010003028").val();
    GR029 = $("#gr1010003029").val();
    GR030 = $("#gr1010003030").val();
    GR031 = $("#gr1010003031").val();
    GR032 = $("#gr1010003032").val();
    GR033 = $("#gr1010003033").val();
    GR034 = $("#gr1010003034").val();
    GR035 = $("#gr1010003035").val();
    GR036 = $("#gr1010003036").val();
    GR037 = $("#gr1010003037").val();
    GR038 = $("#gr1010003038").val();
    GR039 = $("#gr1010003039").val();
    GR040 = $("#gr1010003040").val();
    GR041 = $("#gr1010003041").val();
    GR042 = $("#gr1010003042").val();
    GR043 = $("#gr1010003043").val();
    GR044 = $("#gr1010003044").val();
    GR045 = $("#gr1010003045").val();
    GR046 = $("#gr1010003046").val();
    GR047 = $("#gr1010003047").val();
    GR048 = $("#gr1010003048").val();
    GR049 = $("#gr1010003049").val();
    GR050 = $("#gr1010003050").val();
    GR051 = $("#gr1010003051").val();
    GR052 = $("#gr1010003052").val();
    GR053 = $("#gr1010003053").val();
    GR054 = $("#gr1010003054").val();
    GR055 = $("#gr1010003055").val();
    GR056 = $("#gr1010003056").val();
    GR057 = $("#gr1010003057").val();
    GR058 = $("#gr1010003058").val();
    GR059 = $("#gr1010003059").val();
    GR060 = $("#gr1010003060").val();
    GR061 = $("#gr1010003061").val();
    GR062 = $("#gr1010003062").val();
    GR063 = $("#gr1010003063").val();
    GR064 = $("#gr1010003064").val();
    GR065 = $("#gr1010003065").val();
    GR066 = $("#gr1010003066").val();
    GR067 = $("#gr1010003067").val();
    GR068 = $("#gr1010003068").val();
    GR069 = $("#gr1010003069").val();
    GR070 = $("#gr1010003070").val();
    GR071 = $("#gr1010003071").val();
    GR072 = $("#gr1010003072").val();
    GR073 = $("#gr1010003073").val();
    GR074 = $("#gr1010003074").val();
    GR075 = $("#gr1010003075").val();
    GR076 = $("#gr1010003076").val();
    GR077 = $("#gr1010003077").val();
    GR078 = $("#gr1010003078").val();
    GR079 = $("#gr1010003079").val();
    GR080 = $("#gr1010003080").val();
    GR081 = $("#gr1010003081").val();
    GR082 = $("#gr1010003082").val();
    GR083 = $("#gr1010003083").val();
    GR084 = $("#gr1010003084").val();
    GR085 = $("#gr1010003085").val();
    GR086 = $("#gr1010003086").val();
    GR087 = $("#gr1010003087").val();
    GR088 = $("#gr1010003088").val();
    GR089 = $("#gr1010003089").val();
    GR090 = $("#gr1010003090").val();
    GR091 = $("#gr1010003091").val();
    GR092 = $("#gr1010003092").val();
    GR093 = $("#gr1010003093").val();
    GR094 = $("#gr1010003094").val();
    GR095 = $("#gr1010003095").val();
    GR096 = $("#gr1010003096").val();
    GR097 = $("#gr1010003097").val();
    GR098 = $("#gr1010003098").val();
    GR099 = $("#gr1010003099").val();
    GR100 = $("#gr1010003100").val();
    GR101 = $("#gr1010003101").val();
    GR102 = $("#gr1010003102").val();
    GR103 = $("#gr1010003103").val();
    GR104 = $("#gr1010003104").val();
    GR105 = $("#gr1010003105").val();
    GR106 = $("#gr1010003106").val();
    GR107 = $("#gr1010003107").val();
    GR108 = $("#gr1010003108").val();
    GR109 = $("#gr1010003109").val();
    GR110 = $("#gr1010003110").val();
    GR111 = $("#gr1010003111").val();
    GR112 = $("#gr1010003112").val();
    GR113 = $("#gr1010003113").val();
    GR114 = $("#gr1010003114").val();
    GR115 = $("#gr1010003115").val();
    GR116 = $("#gr1010003116").val();
    GR117 = $("#gr1010003117").val();
    GR118 = $("#gr1010003118").val();
    GR119 = $("#gr1010003119").val();
    GR120 = $("#gr1010003120").val();
    GR121 = $("#gr1010003121").val();
    GR122 = $("#gr1010003122").val();
    GR123 = $("#gr1010003123").val();
    GR124 = $("#gr1010003124").val();
    GR125 = $("#gr1010003125").val();
    GR126 = $("#gr1010003126").val();
    GR127 = $("#gr1010003127").val();
    GR128 = $("#gr1010003128").val();
    GR129 = $("#gr1010003129").val();
    GR130 = $("#gr1010003130").val();
    GR131 = $("#gr1010003131").val();
    GR132 = $("#gr1010003132").val();
    GR133 = $("#gr1010003133").val();
    GR134 = $("#gr1010003134").val();
    GR135 = $("#gr1010003135").val();
    GR136 = $("#gr1010003136").val();
    TX001 = $("#txt1010003001").val();
    TX002 = $("#txt1010003002").val();
    TX003 = $("#txt1010003003").val();
    TX004 = $("#txt1010003004").val();
    TX005 = $("#txt1010003005").val();
    TX006 = $("#txt1010003006").val();
    TX007 = $("#txt1010003007").val();
    TX008 = $("#txt1010003008").val();
    TX009 = $("#txt1010003009").val();
    TX010 = $("#txt1010003010").val();
    TX011 = $("#txt1010003011").val();
    TX012 = $("#txt1010003012").val();
    TX013 = $("#txt1010003013").val();
    TX014 = $("#txt1010003014").val();
    TX015 = $("#txt1010003015").val();
    TX016 = $("#txt1010003016").val();
    TX017 = $("#txt1010003017").val();
    TX018 = $("#txt1010003018").val();
    TX019 = $("#txt1010003019").val();
    TX020 = $("#txt1010003020").val();
    TX021 = $("#txt1010003021").val();
    TX022 = $("#txt1010003022").val();
    TX023 = $("#txt1010003023").val();
    TX024 = $("#txt1010003024").val();
    TX025 = $("#txt1010003025").val();
    TX026 = $("#txt1010003026").val();
    TX027 = $("#txt1010003027").val();
    TX028 = $("#txt1010003028").val();
    TX029 = $("#txt1010003029").val();
    TX030 = $("#txt1010003030").val();
    TX031 = $("#txt1010003031").val();
    TX032 = $("#txt1010003032").val();
    TX033 = $("#txt1010003033").val();
    TX034 = $("#txt1010003034").val();
    TX035 = $("#txt1010003035").val();
    TX036 = $("#txt1010003036").val();
    TX037 = $("#txt1010003037").val();
    TX038 = $("#txt1010003038").val();
    TX039 = $("#txt1010003039").val();
    TX040 = $("#txt1010003040").val();
    TX041 = $("#txt1010003041").val();
    TX042 = $("#txt1010003042").val();
    TX043 = $("#txt1010003043").val();
    TX044 = $("#txt1010003044").val();
    TX045 = $("#txt1010003045").val();
    TX046 = $("#txt1010003046").val();
    TX047 = $("#txt1010003047").val();
    TX048 = $("#txt1010003048").val();
    TX049 = $("#txt1010003049").val();
    TX050 = $("#txt1010003050").val();
    TX051 = $("#txt1010003051").val();
    TX052 = $("#txt1010003052").val();
    TX053 = $("#txt1010003053").val();
    TX054 = $("#txt1010003054").val();
    TX055 = $("#txt1010003055").val();
    TX056 = $("#txt1010003056").val();
    TX057 = $("#txt1010003057").val();
    TX058 = $("#txt1010003058").val();
    TX059 = $("#txt1010003059").val();
    TX060 = $("#txt1010003060").val();
    TX061 = $("#txt1010003061").val();
    TX062 = $("#txt1010003062").val();
    TX063 = $("#txt1010003063").val();
    TX064 = $("#txt1010003064").val();
    TX065 = $("#txt1010003065").val();
    TX066 = $("#txt1010003066").val();
    TX067 = $("#txt1010003067").val();
    TX068 = $("#txt1010003068").val();
    TX069 = $("#txt1010003069").val();
    TX070 = $("#txt1010003070").val();
    TX071 = $("#txt1010003071").val();
    TX072 = $("#txt1010003072").val();
    TX073 = $("#txt1010003073").val();
    TX074 = $("#txt1010003074").val();
    TX075 = $("#txt1010003075").val();
    TX076 = $("#txt1010003076").val();
    TX077 = $("#txt1010003077").val();
    TX078 = $("#txt1010003078").val();
    TX079 = $("#txt1010003079").val();
    TX080 = $("#txt1010003080").val();
    TX081 = $("#txt1010003081").val();
    TX082 = $("#txt1010003082").val();
    TX083 = $("#txt1010003083").val();
    TX084 = $("#txt1010003084").val();
    TX085 = $("#txt1010003085").val();
    TX086 = $("#txt1010003086").val();
    TX087 = $("#txt1010003087").val();
    TX088 = $("#txt1010003088").val();
    TX089 = $("#txt1010003089").val();
    TX090 = $("#txt1010003090").val();
    TX091 = $("#txt1010003091").val();
    TX092 = $("#txt1010003092").val();
    TX093 = $("#txt1010003093").val();
    TX094 = $("#txt1010003094").val();
    TX095 = $("#txt1010003095").val();
    TX096 = $("#txt1010003096").val();
    TX097 = $("#txt1010003097").val();
    TX098 = $("#txt1010003098").val();
    TX099 = $("#txt1010003099").val();
    TX100 = $("#txt1010003100").val();
    TX101 = $("#txt1010003101").val();
    TX102 = $("#txt1010003102").val();
    TX103 = $("#txt1010003103").val();
    TX104 = $("#txt1010003104").val();
    TX105 = $("#txt1010003105").val();
    TX106 = $("#txt1010003106").val();
    TX107 = $("#txt1010003107").val();
    TX108 = $("#txt1010003108").val();
    TX109 = $("#txt1010003109").val();
    TX110 = $("#txt1010003110").val();
    TX111 = $("#txt1010003111").val();
    TX112 = $("#txt1010003112").val();
    TX113 = $("#txt1010003113").val();
    TX114 = $("#txt1010003114").val();
    TX115 = $("#txt1010003115").val();
    TX116 = $("#txt1010003116").val();
    TX117 = $("#txt1010003117").val();
    TX118 = $("#txt1010003118").val();
    TX119 = $("#txt1010003119").val();
    TX120 = $("#txt1010003120").val();
    TX121 = $("#txt1010003121").val();
    TX122 = $("#txt1010003122").val();
    TX123 = $("#txt1010003123").val();
    TX124 = $("#txt1010003124").val();
    TX125 = $("#txt1010003125").val();
    TX126 = $("#txt1010003126").val();
    TX127 = $("#txt1010003127").val();
    TX128 = $("#txt1010003128").val();
    TX129 = $("#txt1010003129").val();
    TX130 = $("#txt1010003130").val();
    TX131 = $("#txt1010003131").val();
    TX132 = $("#txt1010003132").val();
    TX133 = $("#txt1010003133").val();
    TX134 = $("#txt1010003134").val();
    TX135 = $("#txt1010003135").val();
    TX136 = $("#txt1010003136").val();   
    var data = {
              ID: docid
            , projid: projid
            , tskoid: tskoid
            , dcgrid: dcgrid
            , dctpid: dctpid
            , tspdid: tspdid
            , distid: distid
            , acctid: acctid
            , userid: userid
            , dimgid: dimgid
            , GR001: GR001
            , GR002: GR002
            , GR003: GR003
            , GR004: GR004
            , GR005: GR005
            , GR006: GR006
            , GR007: GR007
            , GR008: GR008
            , GR009: GR009
            , GR010: GR010
            , GR011: GR011
            , GR012: GR012
            , GR013: GR013
            , GR014: GR014
            , GR015: GR015
            , GR016: GR016
            , GR017: GR017
            , GR018: GR018
            , GR019: GR019
            , GR020: GR020
            , GR021: GR021
            , GR022: GR022
            , GR023: GR023
            , GR024: GR024
            , GR025: GR025
            , GR026: GR026
            , GR027: GR027
            , GR028: GR028
            , GR029: GR029
            , GR030: GR030
            , GR031: GR031
            , GR032: GR032
            , GR033: GR033
            , GR034: GR034
            , GR035: GR035
            , GR036: GR036
            , GR037: GR037
            , GR038: GR038
            , GR039: GR039
            , GR040: GR040
            , GR041: GR041
            , GR042: GR042
            , GR043: GR043
            , GR044: GR044
            , GR045: GR045
            , GR046: GR046
            , GR047: GR047
            , GR048: GR048
            , GR049: GR049
            , GR050: GR050
            , GR051: GR051
            , GR052: GR052
            , GR053: GR053
            , GR054: GR054
            , GR055: GR055
            , GR056: GR056
            , GR057: GR057
            , GR058: GR058
            , GR059: GR059
            , GR060: GR060
            , GR061: GR061
            , GR062: GR062
            , GR063: GR063
            , GR064: GR064
            , GR065: GR065
            , GR066: GR066
            , GR067: GR067
            , GR068: GR068
            , GR069: GR069
            , GR070: GR070
            , GR071: GR071
            , GR072: GR072
            , GR073: GR073
            , GR074: GR074
            , GR075: GR075
            , GR076: GR076
            , GR077: GR077
            , GR078: GR078
            , GR079: GR079
            , GR080: GR080
            , GR081: GR081
            , GR082: GR082
            , GR083: GR083
            , GR084: GR084
            , GR085: GR085
            , GR086: GR086
            , GR087: GR087
            , GR088: GR088
            , GR089: GR089
            , GR090: GR090
            , GR091: GR091
            , GR092: GR092
            , GR093: GR093
            , GR094: GR094
            , GR095: GR095
            , GR096: GR096
            , GR097: GR097
            , GR098: GR098
            , GR099: GR099
            , GR100: GR100
            , GR101: GR101
            , GR102: GR102
            , GR103: GR103
            , GR104: GR104
            , GR105: GR105
            , GR106: GR106
            , GR107: GR107
            , GR108: GR108
            , GR109: GR109
            , GR110: GR110
            , GR111: GR111
            , GR112: GR112
            , GR113: GR113
            , GR114: GR114
            , GR115: GR115
            , GR116: GR116
            , GR117: GR117
            , GR118: GR118
            , GR119: GR119
            , GR120: GR120
            , GR121: GR121
            , GR122: GR122
            , GR123: GR123
            , GR124: GR124
            , GR125: GR125
            , GR126: GR126
            , GR127: GR127
            , GR128: GR128
            , GR129: GR129
            , GR130: GR130
            , GR131: GR131
            , GR132: GR132
            , GR133: GR133
            , GR134: GR134
            , GR135: GR135
            , GR136: GR136
            , TX001: TX001
            , TX002: TX002
            , TX003: TX003
            , TX004: TX004
            , TX005: TX005
            , TX006: TX006
            , TX007: TX007
            , TX008: TX008
            , TX009: TX009
            , TX010: TX010
            , TX011: TX011
            , TX012: TX012
            , TX013: TX013
            , TX014: TX014
            , TX015: TX015
            , TX016: TX016
            , TX017: TX017
            , TX018: TX018
            , TX019: TX019
            , TX020: TX020
            , TX021: TX021
            , TX022: TX022
            , TX023: TX023
            , TX024: TX024
            , TX025: TX025
            , TX026: TX026
            , TX027: TX027
            , TX028: TX028
            , TX029: TX029
            , TX030: TX030
            , TX031: TX031
            , TX032: TX032
            , TX033: TX033
            , TX034: TX034
            , TX035: TX035
            , TX036: TX036
            , TX037: TX037
            , TX038: TX038
            , TX039: TX039
            , TX040: TX040
            , TX041: TX041
            , TX042: TX042
            , TX043: TX043
            , TX044: TX044
            , TX045: TX045
            , TX046: TX046
            , TX047: TX047
            , TX048: TX048
            , TX049: TX049
            , TX050: TX050
            , TX051: TX051
            , TX052: TX052
            , TX053: TX053
            , TX054: TX054
            , TX055: TX055
            , TX056: TX056
            , TX057: TX057
            , TX058: TX058
            , TX059: TX059
            , TX060: TX060
            , TX061: TX061
            , TX062: TX062
            , TX063: TX063
            , TX064: TX064
            , TX065: TX065
            , TX066: TX066
            , TX067: TX067
            , TX068: TX068
            , TX069: TX069
            , TX070: TX070
            , TX071: TX071
            , TX072: TX072
            , TX073: TX073
            , TX074: TX074
            , TX075: TX075
            , TX076: TX076
            , TX077: TX077
            , TX078: TX078
            , TX079: TX079
            , TX080: TX080
            , TX081: TX081
            , TX082: TX082
            , TX083: TX083
            , TX084: TX084
            , TX085: TX085
            , TX086: TX086
            , TX087: TX087
            , TX088: TX088
            , TX089: TX089
            , TX090: TX090
            , TX091: TX091
            , TX092: TX092
            , TX093: TX093
            , TX094: TX094
            , TX095: TX095
            , TX096: TX096
            , TX097: TX097
            , TX098: TX098
            , TX099: TX099
            , TX100: TX100
            , TX101: TX101
            , TX102: TX102
            , TX103: TX103
            , TX104: TX104
            , TX105: TX105
            , TX106: TX106
            , TX107: TX107
            , TX108: TX108
            , TX109: TX109
            , TX110: TX110
            , TX111: TX111
            , TX112: TX112
            , TX113: TX113
            , TX114: TX114
            , TX115: TX115
            , TX116: TX116
            , TX117: TX117
            , TX118: TX118
            , TX119: TX119
            , TX120: TX120
            , TX121: TX121
            , TX122: TX122
            , TX123: TX123
            , TX124: TX124
            , TX125: TX125
            , TX126: TX126
            , TX127: TX127
            , TX128: TX128
            , TX129: TX129
            , TX130: TX130
            , TX131: TX131
            , TX132: TX132
            , TX133: TX133
            , TX134: TX134
            , TX135: TX135
            , TX136: TX136
            , chck: chck
            , chckid: chckid
            , chckdt: chckdt
            , crdt: crdt
            , eddt: eddt
            , crusid: crusid
            , edusid: edusid
    };
    console.log(data);
    if (actpch == 2) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            url: '/uhsCH/save1010003',
            dataType: "JSON",
            success: function (resp1010003) {
                if (resp1010003 == 1) {
                    modal1010003.style.display = "none";
                    location.reload();
                }
                else if (resp1010003 == 2) {
                    alert("Failed.");
                }
                else if (resp1010003 == 4) {
                    alert("The system exited with code: 3." + "\n" + "User has NOT been authorized.");
                }
                else if (resp1010003 == 3) {
                    alert("The system exited with code: 2." + "\n" + "User has been authorized but data model state is not valid.");
                }
            }
        })
    } else if (actpch == 3) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            url: '/uhsCH/edit1010003',
            dataType: "JSON",
            success: function (resp1010003) {
                if (resp1010003 == 1) {
                    modal1010003.style.display = "none";
                    location.reload();
                }
                else if (resp1010003 == 2) {
                    alert("Exception.");
                }
                else if (resp1010003 == 4) {
                    alert("The system exited with code: 3." + "\n" + "User has NOT been authorized.");
                }
                else if (resp1010003 == 3) {
                    alert("The system exited with code: 2." + "\n" + "User has been authorized but data model state is not valid.");
                }

            }
        })
    }
}

function post1010005() {
    var docid = $("#doc1010005id").val();
    var projid = $("#doc1010005projid").val();
    var tskoid = $("#doc1010005tskoid").val();
    var dcgrid = $("#doc1010005dcgrid").val();
    var dctpid = $("#doc1010005dctpid").val();
    var tspdid = $("#doc1010005tspdid").val();
    var distid = $("#doc1010005distid").val();
    var acctid = $("#doc1010005acctid").val();
    var userid = $("#doc1010005userid").val();
    var crusid = $("#doc1010005crusid").val();
    var edusid = $("#doc1010005edusid").val();
    var dimgid = $("#doc1010005dimgid").val();
    var d = new Date();
    var actpch = $("#doc1010005actype").val();
    var crdtch = $("#doc1010005crdt").val();
    var chck = $('#doc1010005chck').is(":checked");
    var checkedid = $("#doc1010005chckid").val();
    var checkeddt = $("#doc1010005chckdt").val();
    var eddt = d.toISOString(); // ISO "2013-12-08T17:55:38.130Z"   
    //console.log(actpch);
    if (actpch == 2) {
        // CHECK/ED DOCUMENT
        if (chck == true) { var chckid = userid; var chckdt = eddt }
        else { var chckid = 0; var chckdt = null }
        var crdt = d.toISOString(); // ISO "2013-12-08T17:55:38.130Z"
        var crdate = crdt.slice(0, 10);
    }
    else if (actpch == 3) {
        if (chck == true) {
            if (checkedid == edusid) {
                var chckid = checkedid;
                var chckdt = checkeddt;
            }
            else {
                var chckid = edusid;
                var chckdt = d.toISOString();
                //console.log("proba");
            }
        }
        else {
            var chckid = 0; var chckdt = null
        }
        var crdt = crdtch; // ISO "2013-12-08T17:55:38.130Z"
        var crdate = crdt.slice(0, 10);
    }
    if (dctpid == 1010005 && tspdid == 1) {
        var smid111 = $("#sm1010005111").val();
        var cmdt111 = $("#cm1010005111").val();
        var verf111 = $('#vr1010005111').is(":checked");
        var smid112 = $("#sm1010005112").val();
        var cmdt112 = $("#cm1010005112").val();
        var verf112 = $("#vr1010005112").is(":checked");
        var smid113 = $("#sm1010005113").val();
        var cmdt113 = $("#cm1010005113").val();
        var verf113 = $("#vr1010005113").is(":checked");
        var smid114 = $("#sm1010005114").val();
        var cmdt114 = $("#cm1010005114").val();
        var verf114 = $("#vr1010005114").is(":checked");
        var smid115 = $("#sm1010005115").val();
        var cmdt115 = $("#cm1010005115").val();
        var verf115 = $("#vr1010005115").is(":checked");
        var smid116 = 0;
        var cmdt116 = null;
        var verf116 = false;
        var smid117 = 0;
        var cmdt117 = null;
        var verf117 = false;
        var smid118 = 0;
        var cmdt118 = null;
        var verf118 = false;
        var smid119 = 0;
        var cmdt119 = null;
        var verf119 = false;
        var smid120 = 0;
        var cmdt120 = null;
        var verf120 = false;
        var smid121 = 0;
        var cmdt121 = null;
        var verf121 = false;
        var smid122 = 0;
        var cmdt122 = null;
        var verf122 = false;
        var smid123 = 0;
        var cmdt123 = null;
        var verf123 = false;
        var smid124 = 0;
        var cmdt124 = null;
        var verf124 = false;
        var smid125 = 0;
        var cmdt125 = null;
        var verf125 = false;
        var comm01 = null;
        var comm02 = null;
        var comm03 = null;
        var comm04 = null;
        var comm05 = null;
        var comm06 = null;
    } else
    if (dctpid == 1010005 && tspdid == 2) {
        var smid111 = $("#sm1010005111").val();
        var cmdt111 = $("#cm1010005111").val();
        var verf111 = $("#vr1010005111").is(":checked");
        var smid112 = $("#sm1010005112").val();
        var cmdt112 = $("#cm1010005112").val();
        var verf112 = $("#vr1010005112").is(":checked");
        var smid113 = $("#sm1010005113").val();
        var cmdt113 = $("#cm1010005113").val();
        var verf113 = $("#vr1010005113").is(":checked");
        var smid114 = $("#sm1010005114").val();
        var cmdt114 = $("#cm1010005114").val();
        var verf114 = $("#vr1010005114").is(":checked");
        var smid115 = $("#sm1010005115").val();
        var cmdt115 = $("#cm1010005115").val();
        var verf115 = $("#vr1010005115").is(":checked");
        var smid116 = $("#sm1010005116").val();
        var cmdt116 = $("#cm1010005116").val();
        var verf116 = $("#vr1010005116").is(":checked");
        var smid117 = 0;
        var cmdt117 = null;
        var verf117 = 0;
        var smid118 = 0;
        var cmdt118 = null;
        var verf118 = 0;
        var smid119 = 0;
        var cmdt119 = null;
        var verf119 = 0;
        var smid120 = 0;
        var cmdt120 = null;
        var verf120 = 0;
        var smid121 = 0;
        var cmdt121 = null;
        var verf121 = 0;
        var smid122 = 0;
        var cmdt122 = null;
        var verf122 = 0;
        var smid123 = 0;
        var cmdt123 = null;
        var verf123 = 0;
        var smid124 = 0;
        var cmdt124 = null;
        var verf124 = 0;
        var smid125 = 0;
        var cmdt125 = null;
        var verf125 = 0;
        var comm01 = null;
        var comm02 = null;
        var comm03 = null;
        var comm04 = null;
        var comm05 = null;
        var comm06 = null;
    } else
        if (dctpid == 1010005 && tspdid == 3) {
            var smid111 = $("#sm1010005111").val();
            var cmdt111 = $("#cm1010005111").val();
            var verf111 = $("#vr1010005111").is(":checked");
            var smid112 = $("#sm1010005112").val();
            var cmdt112 = $("#cm1010005112").val();
            var verf112 = $("#vr1010005112").is(":checked");
            var smid113 = $("#sm1010005113").val();
            var cmdt113 = $("#cm1010005113").val();
            var verf113 = $("#vr1010005113").is(":checked");
            var smid114 = $("#sm1010005114").val();
            var cmdt114 = $("#cm1010005114").val();
            var verf114 = $("#vr1010005114").is(":checked");
            var smid115 = $("#sm1010005115").val();
            var cmdt115 = $("#cm1010005115").val();
            var verf115 = $("#vr1010005115").is(":checked");
            var smid116 = $("#sm1010005116").val();
            var cmdt116 = $("#cm1010005116").val();
            var verf116 = $("#vr1010005116").is(":checked");
            var smid117 = $("#sm1010005117").val();
            var cmdt117 = $("#cm1010005117").val();
            var verf117 = $("#vr1010005117").is(":checked");
            var smid118 = $("#sm1010005118").val();
            var cmdt118 = $("#cm1010005118").val();
            var verf118 = $("#vr1010005118").is(":checked");
            var smid119 = $("#sm1010005119").val();
            var cmdt119 = $("#cm1010005119").val();
            var verf119 = $("#vr1010005119").is(":checked");
            var smid120 = $("#sm1010005120").val();
            var cmdt120 = $("#cm1010005120").val();
            var verf120 = $("#vr1010005120").is(":checked");
            var smid121 = $("#sm1010005121").val();
            var cmdt121 = $("#cm1010005121").val();
            var verf121 = $("#vr1010005121").is(":checked");
            var smid122 = $("#sm1010005122").val();
            var cmdt122 = $("#cm1010005122").val();
            var verf122 = $("#vr1010005122").is(":checked");
            var smid123 = $("#sm1010005123").val();
            var cmdt123 = $("#cm1010005123").val();
            var verf123 = $("#vr1010005123").is(":checked");
            var smid124 = $("#sm1010005124").val();
            var cmdt124 = $("#cm1010005124").val();
            var verf124 = $("#vr1010005124").is(":checked");
            var smid125 = $("#sm1010005125").val();
            var cmdt125 = $("#cm1010005125").val();
            var verf125 = $("#vr1010005125").is(":checked");
            var comm01 = null;
            var comm02 = null;
            var comm03 = null;
            var comm04 = null;
            var comm05 = null;
            var comm06 = null;
        } else
    if (dctpid == 1010006 && tspdid == 1) {
        var smid111 = $("#sm1010005111").val();
        var cmdt111 = $("#cm1010005111").val();
        var verf111 = $("#vr1010005111").is(":checked");
        var smid112 = $("#sm1010005112").val();
        var cmdt112 = $("#cm1010005112").val();
        var verf112 = $("#vr1010005112").is(":checked");
        var smid113 = $("#sm1010005113").val();
        var cmdt113 = $("#cm1010005113").val();
        var verf113 = $("#vr1010005113").is(":checked");
        var smid114 = $("#sm1010005114").val();
        var cmdt114 = $("#cm1010005114").val();
        var verf114 = $("#vr1010005114").is(":checked");
        var smid115 = $("#sm1010005115").val();
        var cmdt115 = $("#cm1010005115").val();
        var verf115 = $("#vr1010005115").is(":checked");
        var smid116 = 0;
        var cmdt116 = null;
        var verf116 = false;
        var smid117 = 0;
        var cmdt117 = null;
        var verf117 = false;
        var smid118 = 0;
        var cmdt118 = null;
        var verf118 = false;
        var smid119 = 0;
        var cmdt119 = null;
        var verf119 = false;
        var smid120 = 0;
        var cmdt120 = null;
        var verf120 = false;
        var smid121 = 0;
        var cmdt121 = null;
        var verf121 = false;
        var smid122 = 0;
        var cmdt122 = null;
        var verf122 = false;
        var smid123 = 0;
        var cmdt123 = null;
        var verf123 = false;
        var smid124 = 0;
        var cmdt124 = null;
        var verf124 = false;
        var smid125 = 0;
        var cmdt125 = null;
        var verf125 = false;
        var comm01 = null;
        var comm02 = null;
        var comm03 = null;
        var comm04 = null;
        var comm05 = null;
        var comm06 = null;
    } else
        if (dctpid == 1010006 && tspdid == 2) {
            var smid111 = $("#sm1010005111").val();
            var cmdt111 = $("#cm1010005111").val();
            var verf111 = $("#vr1010005111").is(":checked");
            var smid112 = $("#sm1010005112").val();
            var cmdt112 = $("#cm1010005112").val();
            var verf112 = $("#vr1010005112").is(":checked");
            var smid113 = $("#sm1010005113").val();
            var cmdt113 = $("#cm1010005113").val();
            var verf113 = $("#vr1010005113").is(":checked");
            var smid114 = $("#sm1010005114").val();
            var cmdt114 = $("#cm1010005114").val();
            var verf114 = $("#vr1010005114").is(":checked");
            var smid115 = $("#sm1010005115").val();
            var cmdt115 = $("#cm1010005115").val();
            var verf115 = $("#vr1010005115").is(":checked");
            var smid116 = $("#sm1010005116").val();
            var cmdt116 = $("#cm1010005116").val();
            var verf116 = $("#vr1010005116").is(":checked");
            var smid117 = 0;
            var cmdt117 = null;
            var verf117 = false;
            var smid118 = 0;
            var cmdt118 = null;
            var verf118 = false;
            var smid119 = 0;
            var cmdt119 = null;
            var verf119 = false;
            var smid120 = 0;
            var cmdt120 = null;
            var verf120 = false;
            var smid121 = 0;
            var cmdt121 = null;
            var verf121 = false;
            var smid122 = 0;
            var cmdt122 = null;
            var verf122 = false;
            var smid123 = 0;
            var cmdt123 = null;
            var verf123 = false;
            var smid124 = 0;
            var cmdt124 = null;
            var verf124 = false;
            var smid125 = 0;
            var cmdt125 = null;
            var verf125 = false;
            var comm01 = null;
            var comm02 = null;
            var comm03 = null;
            var comm04 = null;
            var comm05 = null;
            var comm06 = null;
        } else
            if (dctpid == 1010006 && tspdid == 3) {
                var smid111 = $("#sm1010005111").val();
                var cmdt111 = $("#cm1010005111").val();
                var verf111 = $("#vr1010005111").is(":checked");
                var smid112 = $("#sm1010005112").val();
                var cmdt112 = $("#cm1010005112").val();
                var verf112 = $("#vr1010005112").is(":checked");
                var smid113 = $("#sm1010005113").val();
                var cmdt113 = $("#cm1010005113").val();
                var verf113 = $("#vr1010005113").is(":checked");
                var smid114 = $("#sm1010005114").val();
                var cmdt114 = $("#cm1010005114").val();
                var verf114 = $("#vr1010005114").is(":checked");
                var smid115 = $("#sm1010005115").val();
                var cmdt115 = $("#cm1010005115").val();
                var verf115 = $("#vr1010005115").is(":checked");
                var smid116 = $("#sm1010005116").val();
                var cmdt116 = $("#cm1010005116").val();
                var verf116 = $("#vr1010005116").is(":checked");
                var smid117 = 0;
                var cmdt117 = null;
                var verf117 = false;
                var smid118 = 0;
                var cmdt118 = null;
                var verf118 = false;
                var smid119 = 0;
                var cmdt119 = null;
                var verf119 = false;
                var smid120 = 0;
                var cmdt120 = null;
                var verf120 = false;
                var smid121 = 0;
                var cmdt121 = null;
                var verf121 = false;
                var smid122 = 0;
                var cmdt122 = null;
                var verf122 = false;
                var smid123 = 0;
                var cmdt123 = null;
                var verf123 = false;
                var smid124 = 0;
                var cmdt124 = null;
                var verf124 = false;
                var smid125 = 0;
                var cmdt125 = null;
                var verf125 = false;
                var comm01 = null;
                var comm02 = null;
                var comm03 = null;
                var comm04 = null;
                var comm05 = null;
                var comm06 = null;
            } else
                if (dctpid == 1010006 && tspdid == 4) {
                    var smid111 = $("#sm1010005111").val();
                    var cmdt111 = $("#cm1010005111").val();
                    var verf111 = $("#vr1010005111").is(":checked");
                    var smid112 = 0;
                    var cmdt112 = null;
                    var verf112 = false;
                    var smid113 = 0;
                    var cmdt113 = null;
                    var verf113 = false;
                    var smid114 = 0;
                    var cmdt114 = null;
                    var verf114 = false;
                    var smid115 = 0;
                    var cmdt115 = null;
                    var verf115 = false;
                    var smid116 = 0;
                    var cmdt116 = null;
                    var verf116 = false;
                    var smid117 = 0;
                    var cmdt117 = null;
                    var verf117 = false;
                    var smid118 = 0;
                    var cmdt118 = null;
                    var verf118 = false;
                    var smid119 = 0;
                    var cmdt119 = null;
                    var verf119 = false;
                    var smid120 = 0;
                    var cmdt120 = null;
                    var verf120 = false;
                    var smid121 = 0;
                    var cmdt121 = null;
                    var verf121 = false;
                    var smid122 = 0;
                    var cmdt122 = null;
                    var verf122 = false;
                    var smid123 = 0;
                    var cmdt123 = null;
                    var verf123 = false;
                    var smid124 = 0;
                    var cmdt124 = null;
                    var verf124 = false;
                    var smid125 = 0;
                    var cmdt125 = null;
                    var verf125 = false;
                    var comm01 = null;
                    var comm02 = null;
                    var comm03 = null;
                    var comm04 = null;
                    var comm05 = null;
                    var comm06 = null;
                } else
                    if (dctpid == 1010007 && tspdid == 1) {
                        var smid111 = $("#sm1010005111").val();
                        var cmdt111 = $("#cm1010005111").val();
                        var verf111 = $("#vr1010005111").is(":checked");
                        var smid112 = $("#sm1010005112").val();
                        var cmdt112 = $("#cm1010005112").val();
                        var verf112 = $("#vr1010005112").is(":checked");
                        var smid113 = $("#sm1010005113").val();
                        var cmdt113 = $("#cm1010005113").val();
                        var verf113 = $("#vr1010005113").is(":checked");
                        var smid114 = $("#sm1010005114").val();
                        var cmdt114 = $("#cm1010005114").val();
                        var verf114 = $("#vr1010005114").is(":checked");
                        var smid115 = $("#sm1010005115").val();
                        var cmdt115 = $("#cm1010005115").val();
                        var verf115 = $("#vr1010005115").is(":checked");
                        var smid116 = $("#sm1010005116").val();
                        var cmdt116 = $("#cm1010005116").val();
                        var verf116 = $("#vr1010005116").is(":checked");
                        var smid117 = $("#sm1010005117").val();
                        var cmdt117 = $("#cm1010005117").val();
                        var verf117 = $("#vr1010005117").is(":checked");
                        var smid118 = $("#sm1010005118").val();
                        var cmdt118 = $("#cm1010005118").val();
                        var verf118 = $("#vr1010005118").is(":checked");
                        var smid119 = 0;
                        var cmdt119 = null;
                        var verf119 = false;
                        var smid120 = 0;
                        var cmdt120 = null;
                        var verf120 = false;
                        var smid121 = 0;
                        var cmdt121 = null;
                        var verf121 = false;
                        var smid122 = 0;
                        var cmdt122 = null;
                        var verf122 = false;
                        var smid123 = 0;
                        var cmdt123 = null;
                        var verf123 = false;
                        var smid124 = 0;
                        var cmdt124 = null;
                        var verf124 = false;
                        var smid125 = 0;
                        var cmdt125 = null;
                        var verf125 = false;
                        var comm01 = $("#cm1010005101").val();
                        var comm02 = $("#cm1010005102").val();
                        var comm03 = null;
                        var comm04 = null;
                        var comm05 = null;
                        var comm06 = null;
                    } else
                        if (dctpid == 1010007 && tspdid == 2) {
                            var smid111 = $("#sm1010005111").val();
                            var cmdt111 = $("#cm1010005111").val();
                            var verf111 = $("#vr1010005111").is(":checked");
                            var smid112 = $("#sm1010005112").val();
                            var cmdt112 = $("#cm1010005112").val();
                            var verf112 = $("#vr1010005112").is(":checked");
                            var smid113 = $("#sm1010005113").val();
                            var cmdt113 = $("#cm1010005113").val();
                            var verf113 = $("#vr1010005113").is(":checked");
                            var smid114 = $("#sm1010005114").val();
                            var cmdt114 = $("#cm1010005114").val();
                            var verf114 = $("#vr1010005114").is(":checked");
                            var smid115 = $("#sm1010005115").val();
                            var cmdt115 = $("#cm1010005115").val();
                            var verf115 = $("#vr1010005115").is(":checked");
                            var smid116 = $("#sm1010005116").val();
                            var cmdt116 = $("#cm1010005116").val();
                            var verf116 = $("#vr1010005116").is(":checked");
                            var smid117 = $("#sm1010005117").val();
                            var cmdt117 = $("#cm1010005117").val();
                            var verf117 = $("#vr1010005117").is(":checked");
                            var smid118 = $("#sm1010005118").val();
                            var cmdt118 = $("#cm1010005118").val();
                            var verf118 = $("#vr1010005118").is(":checked");
                            var smid119 = $("#sm1010005119").val();
                            var cmdt119 = $("#cm1010005119").val();
                            var verf119 = $("#vr1010005119").is(":checked");
                            var smid120 = $("#sm1010005120").val();
                            var cmdt120 = $("#cm1010005120").val();
                            var verf120 = $("#vr1010005120").is(":checked");
                            var smid121 = 0;
                            var cmdt121 = null;
                            var verf121 = false;
                            var smid122 = 0;
                            var cmdt122 = null;
                            var verf122 = false;
                            var smid123 = 0;
                            var cmdt123 = null;
                            var verf123 = false;
                            var smid124 = 0;
                            var cmdt124 = null;
                            var verf124 = false;
                            var smid125 = 0;
                            var cmdt125 = null;
                            var verf125 = false;
                            var comm01 = $("#cm1010005101").val();
                            var comm02 = $("#cm1010005102").val();
                            var comm03 = null;
                            var comm04 = null;
                            var comm05 = null;
                            var comm06 = null;
                        } else
                            if (dctpid == 1010007 && tspdid == 3) {
                                var smid111 = $("#sm1010005111").val();
                                var cmdt111 = $("#cm1010005111").val();
                                var verf111 = $("#vr1010005111").is(":checked");
                                var smid112 = $("#sm1010005112").val();
                                var cmdt112 = $("#cm1010005112").val();
                                var verf112 = $("#vr1010005112").is(":checked");
                                var smid113 = $("#sm1010005113").val();
                                var cmdt113 = $("#cm1010005113").val();
                                var verf113 = $("#vr1010005113").is(":checked");
                                var smid114 = $("#sm1010005114").val();
                                var cmdt114 = $("#cm1010005114").val();
                                var verf114 = $("#vr1010005114").is(":checked");
                                var smid115 = $("#sm1010005115").val();
                                var cmdt115 = $("#cm1010005115").val();
                                var verf115 = $("#vr1010005115").is(":checked");
                                var smid116 = $("#sm1010005116").val();
                                var cmdt116 = $("#cm1010005116").val();
                                var verf116 = $("#vr1010005116").is(":checked");
                                var smid117 = 0;
                                var cmdt117 = null;
                                var verf117 = false;
                                var smid118 = 0;
                                var cmdt118 = null;
                                var verf118 = false;
                                var smid119 = 0;
                                var cmdt119 = null;
                                var verf119 = false;
                                var smid120 = 0;
                                var cmdt120 = null;
                                var verf120 = false;
                                var smid121 = 0;
                                var cmdt121 = null;
                                var verf121 = false;
                                var smid122 = 0;
                                var cmdt122 = null;
                                var verf122 = false;
                                var smid123 = 0;
                                var cmdt123 = null;
                                var verf123 = false;
                                var smid124 = 0;
                                var cmdt124 = null;
                                var verf124 = false;
                                var smid125 = 0;
                                var cmdt125 = null;
                                var verf125 = false;
                                var comm01 = null;
                                var comm02 = null;
                                var comm03 = null;
                                var comm04 = null;
                                var comm05 = null;
                                var comm06 = null;
                            } else
                                if (dctpid == 1010007 && tspdid == 4) {
                                    var smid111 = $("#sm1010005111").val();
                                    var cmdt111 = $("#cm1010005111").val();
                                    var verf111 = $("#vr1010005111").is(":checked");
                                    var smid112 = $("#sm1010005112").val();
                                    var cmdt112 = $("#cm1010005112").val();
                                    var verf112 = $("#vr1010005112").is(":checked");
                                    var smid113 = $("#sm1010005113").val();
                                    var cmdt113 = $("#cm1010005113").val();
                                    var verf113 = $("#vr1010005113").is(":checked");
                                    var smid114 = $("#sm1010005114").val();
                                    var cmdt114 = $("#cm1010005114").val();
                                    var verf114 = $("#vr1010005114").is(":checked");
                                    var smid115 = $("#sm1010005115").val();
                                    var cmdt115 = $("#cm1010005115").val();
                                    var verf115 = $("#vr1010005115").is(":checked");
                                    var smid116 = $("#sm1010005116").val();
                                    var cmdt116 = $("#cm1010005116").val();
                                    var verf116 = $("#vr1010005116").is(":checked");
                                    var smid117 = $("#sm1010005117").val();
                                    var cmdt117 = $("#cm1010005117").val();
                                    var verf117 = $("#vr1010005117").is(":checked");
                                    var smid118 = 0;
                                    var cmdt118 = null;
                                    var verf118 = false;
                                    var smid119 = 0;
                                    var cmdt119 = null;
                                    var verf119 = false;
                                    var smid120 = 0;
                                    var cmdt120 = null;
                                    var verf120 = false;
                                    var smid121 = 0;
                                    var cmdt121 = null;
                                    var verf121 = false;
                                    var smid122 = 0;
                                    var cmdt122 = null;
                                    var verf122 = false;
                                    var smid123 = 0;
                                    var cmdt123 = null;
                                    var verf123 = false;
                                    var smid124 = 0;
                                    var cmdt124 = null;
                                    var verf124 = false;
                                    var smid125 = 0;
                                    var cmdt125 = null;
                                    var verf125 = false;
                                    var comm01 = null;
                                    var comm02 = null;
                                    var comm03 = null;
                                    var comm04 = null;
                                    var comm05 = null;
                                    var comm06 = null;
                                } else
                                    if (dctpid == 1010007 && tspdid == 5) {
                                        var smid111 = $("#sm1010005111").val();
                                        var cmdt111 = $("#cm1010005111").val();
                                        var verf111 = $("#vr1010005111").is(":checked");
                                        var smid112 = $("#sm1010005112").val();
                                        var cmdt112 = $("#cm1010005112").val();
                                        var verf112 = $("#vr1010005112").is(":checked");
                                        var smid113 = $("#sm1010005113").val();
                                        var cmdt113 = $("#cm1010005113").val();
                                        var verf113 = $("#vr1010005113").is(":checked");
                                        var smid114 = 0;
                                        var cmdt114 = null;
                                        var verf114 = false;
                                        var smid115 = 0;
                                        var cmdt115 = null;
                                        var verf115 = false;
                                        var smid116 = 0;
                                        var cmdt116 = null;
                                        var verf116 = false;
                                        var smid117 = 0;
                                        var cmdt117 = null;
                                        var verf117 = false;
                                        var smid118 = 0;
                                        var cmdt118 = null;
                                        var verf118 = false;
                                        var smid119 = 0;
                                        var cmdt119 = null;
                                        var verf119 = false;
                                        var smid120 = 0;
                                        var cmdt120 = null;
                                        var verf120 = false;
                                        var smid121 = 0;
                                        var cmdt121 = null;
                                        var verf121 = false;
                                        var smid122 = 0;
                                        var cmdt122 = null;
                                        var verf122 = false;
                                        var smid123 = 0;
                                        var cmdt123 = null;
                                        var verf123 = false;
                                        var smid124 = 0;
                                        var cmdt124 = null;
                                        var verf124 = false;
                                        var smid125 = 0;
                                        var cmdt125 = null;
                                        var verf125 = false;
                                        var comm01 = null;
                                        var comm02 = null;
                                        var comm03 = null;
                                        var comm04 = null;
                                        var comm05 = null;
                                        var comm06 = null;
                                    }
    var data = {
              ID: docid
            , projid: projid
            , tskoid: tskoid
            , dcgrid: dcgrid
            , dctpid: dctpid
            , tspdid: tspdid
            , distid: distid
            , acctid: acctid
            , userid: userid
            , dimgid: dimgid
            , smid111: smid111
            , cmdt111: cmdt111
            , verf111: verf111
            , smid112: smid112
            , cmdt112: cmdt112
            , verf112: verf112
            , smid113: smid113
            , cmdt113: cmdt113
            , verf113: verf113
            , smid114: smid114
            , cmdt114: cmdt114
            , verf114: verf114
            , smid115: smid115
            , cmdt115: cmdt115
            , verf115: verf115
            , smid116: smid116
            , cmdt116: cmdt116
            , verf116: verf116
            , smid117: smid117
            , cmdt117: cmdt117
            , verf117: verf117
            , smid118: smid118
            , cmdt118: cmdt118
            , verf118: verf118
            , smid119: smid119
            , cmdt119: cmdt119
            , verf119: verf119
            , smid120: smid120
            , cmdt120: cmdt120
            , verf120: verf120
            , smid121: smid121
            , cmdt121: cmdt121
            , verf121: verf121
            , smid122: smid122
            , cmdt122: cmdt122
            , verf122: verf122
            , smid123: smid123
            , cmdt123: cmdt123
            , verf123: verf123
            , smid124: smid124
            , cmdt124: cmdt124
            , verf124: verf124
            , smid125: smid125
            , cmdt125: cmdt125
            , verf125: verf125
            , comm01: comm01
            , comm02: comm02
            , comm03: comm03
            , comm04: comm04
            , comm05: comm05
            , comm06: comm06         
            , chck: chck
            , chckid: chckid
            , chckdt: chckdt
            , crdate: crdate
            , crdt: crdt
            , eddt: eddt
            , crusid: crusid
            , edusid: edusid
    };
    //console.log(data);
    //alert("test");
    if (actpch == 2) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            url: '/uhsCH/save1010005',
            dataType: "JSON",
            success: function (resp1010005) {
                if (resp1010005 == 1) {
                    modal1010005d.style.display = "none";
                    location.reload();
                }
                else if (resp1010005 == 2) {
                    alert("Failed.");
                }
                else if (resp1010005 == 4) {
                    alert("The system exited with code: 3." + "\n" + "User has NOT been authorized.");
                }
                else if (resp1010005 == 3) {
                    alert("The system exited with code: 2." + "\n" + "User has been authorized but data model state is not valid.");
                }
            }
        })
    } else if (actpch == 3) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            url: '/uhsCH/edit1010005',
            dataType: "JSON",
            success: function (resp1010005) {
                if (resp1010005 == 1) {
                    modal1010005d.style.display = "none";
                    location.reload();
                }
                else if (resp1010005 == 2) {
                    alert("Exception.");
                }
                else if (resp1010005 == 4) {
                    alert("The system exited with code: 3." + "\n" + "User has NOT been authorized.");
                }
                else if (resp1010005 == 3) {
                    alert("The system exited with code: 2." + "\n" + "User has been authorized but data model state is not valid.");
                }

            }
        })
    }
}

// When the user clicks on <span> (x), close the modal
span1.onclick = function () {
    //modal1010001.style.display = "none";
    location.reload();
}
span2.onclick = function () {
    //modal1010002.style.display = "none";
    location.reload();
}
span3.onclick = function () {
    //modal1010003.style.display = "none";
    location.reload();
}
span4.onclick = function () {
    modal1010004.style.display = "none";
}
span5.onclick = function () {
    location.reload();
}
// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
    if (event.target == modal1010001) {
        modal.style.display = "none";
        resetChecks();
    } else
    if (event.target == modal1010002) {
        modal.style.display = "none";
        resetChecks();
    } else
        if (event.target == modal1010003) {
            modal.style.display = "none";
            resetChecks();
        }
}

function resetChecks() {
    $("#doc1010001id").val('');
    $("#doc1010001projid").val('');
    $("#doc1010001tskoid").val('');
    $("#doc1010001dcgrid").val('');
    $("#doc1010001dctpid").val('');
    $("#doc1010001tspdid").val('');
    $("#doc1010001distid").val('');
    $("#doc1010001acctid").val('');
    $("#doc1010001userid").val('');
    $("#doc1010001crusid").val('');
    $("#doc1010001edusid").val('');
    $("#doc1010001actype").val('');
    $("#doc1010001chckid").val('');
    $("#doc1010001chckdt").val('');
    $('#doc1010001chck').prop("checked", false);
    $('#tstp011').prop("checked", false);
    $('#tstp012').prop("checked", false);
    $('#tstp013').prop("checked", false);
    $('#tstp014').prop("checked", false);
    $('#tstp015').prop("checked", false);
    $('#tstp016').prop("checked", false);
    $('#tstp017').prop("checked", false);
    $('#tstp021').prop("checked", false);
    $('#tstp022').prop("checked", false);
    $('#tstp023').prop("checked", false);
    $('#tstp024').prop("checked", false);
    $('#tstp025').prop("checked", false);
    $('#tstp026').prop("checked", false);
    $('#tstp027').prop("checked", false);
    $('#tstp031').prop("checked", false);
    $('#tstp032').prop("checked", false);
    $('#tstp033').prop("checked", false);
    $('#tstp034').prop("checked", false);
    $('#tstp035').prop("checked", false);
    $('#tstp036').prop("checked", false);
    $('#tstp037').prop("checked", false);
    $('#tstp041').prop("checked", false);
    $('#tstp042').prop("checked", false);
    $('#tstp043').prop("checked", false);
    $('#tstp044').prop("checked", false);
    $('#tstp045').prop("checked", false);
    $('#tstp046').prop("checked", false);
    $('#tstp047').prop("checked", false);
    $('#tstp051').prop("checked", false);
    $('#tstp052').prop("checked", false);
    $('#tstp053').prop("checked", false);
    $('#tstp054').prop("checked", false);
    $('#tstp055').prop("checked", false);
    $('#tstp056').prop("checked", false);
    $('#tstp057').prop("checked", false);
    $('#tstp061').prop("checked", false);
    $('#tstp062').prop("checked", false);
    $('#tstp063').prop("checked", false);
    $('#tstp064').prop("checked", false);
    $('#tstp065').prop("checked", false);
    $('#tstp066').prop("checked", false);
    $('#tstp067').prop("checked", false);
    $('#tstp071').prop("checked", false);
    $('#tstp072').prop("checked", false);
    $('#tstp073').prop("checked", false);
    $('#tstp074').prop("checked", false);
    $('#tstp075').prop("checked", false);
    $('#tstp076').prop("checked", false);
    $('#tstp077').prop("checked", false);
    $('#tstp081').prop("checked", false);
    $('#tstp082').prop("checked", false);
    $('#tstp083').prop("checked", false);
    $('#tstp084').prop("checked", false);
    $('#tstp085').prop("checked", false);
    $('#tstp086').prop("checked", false);
    $('#tstp087').prop("checked", false);
    $('#tstp091').prop("checked", false);
    $('#tstp092').prop("checked", false);
    $('#tstp093').prop("checked", false);
    $('#tstp094').prop("checked", false);
    $('#tstp095').prop("checked", false);
    $('#tstp096').prop("checked", false);
    $('#tstp097').prop("checked", false);
    $('#tstp101').prop("checked", false);
    $('#tstp102').prop("checked", false);
    $('#tstp103').prop("checked", false);
    $('#tstp104').prop("checked", false);
    $('#tstp105').prop("checked", false);
    $('#tstp106').prop("checked", false);
    $('#tstp107').prop("checked", false);
    $('#tstp111').prop("checked", false);
    $('#tstp112').prop("checked", false);
    $('#tstp113').prop("checked", false);
    $('#tstp114').prop("checked", false);
    $('#tstp115').prop("checked", false);
    $('#tstp116').prop("checked", false);
    $('#tstp117').prop("checked", false);
    $('#tstp121').prop("checked", false);
    $('#tstp122').prop("checked", false);
    $('#tstp123').prop("checked", false);
    $('#tstp124').prop("checked", false);
    $('#tstp125').prop("checked", false);
    $('#tstp126').prop("checked", false);
    $('#tstp127').prop("checked", false);
    $('#tstp131').prop("checked", false);
    $('#tstp132').prop("checked", false);
    $('#tstp133').prop("checked", false);
    $('#tstp134').prop("checked", false);
    $('#tstp135').prop("checked", false);
    $('#tstp136').prop("checked", false);
    $('#tstp137').prop("checked", false);
    $('#tstp141').prop("checked", false);
    $('#tstp142').prop("checked", false);
    $('#tstp143').prop("checked", false);
    $('#tstp144').prop("checked", false);
    $('#tstp145').prop("checked", false);
    $('#tstp146').prop("checked", false);
    $('#tstp147').prop("checked", false);
    $('#tstp154').prop("checked", false);
    $('#tstp164').prop("checked", false);
    $('#tstp174').prop("checked", false);
    $('#tstp184').prop("checked", false);
    $("#doc1010002id").val('');
    $("#doc1010002projid").val('');
    $("#doc1010002tskoid").val('');
    $("#doc1010002dcgrid").val('');
    $("#doc1010002dctpid").val('');
    $("#doc1010002tspdid").val('');
    $("#doc1010002distid").val('');
    $("#doc1010002acctid").val('');
    $("#doc1010002userid").val('');
    $("#doc1010002crusid").val('');
    $("#doc1010002edusid").val('');
    $("#doc1010002actype").val('');
    $("#doc1010002chckid").val('');
    $("#doc1010002chckdt").val('');
    $('#doc1010002chck').prop("checked", false);
    $('#ts6s011').prop("checked", false);
    $('#ts6s012').prop("checked", false);
    $('#ts6s013').prop("checked", false);
    $('#ts6s014').prop("checked", false);
    $('#ts6s015').prop("checked", false);
    $('#ts6s016').prop("checked", false);
    $('#ts6s017').prop("checked", false);
    $('#ts6s021').prop("checked", false);
    $('#ts6s022').prop("checked", false);
    $('#ts6s023').prop("checked", false);
    $('#ts6s024').prop("checked", false);
    $('#ts6s025').prop("checked", false);
    $('#ts6s026').prop("checked", false);
    $('#ts6s027').prop("checked", false);
    $('#ts6s031').prop("checked", false);
    $('#ts6s032').prop("checked", false);
    $('#ts6s033').prop("checked", false);
    $('#ts6s034').prop("checked", false);
    $('#ts6s035').prop("checked", false);
    $('#ts6s036').prop("checked", false);
    $('#ts6s037').prop("checked", false);
    $('#ts6s041').prop("checked", false);
    $('#ts6s042').prop("checked", false);
    $('#ts6s043').prop("checked", false);
    $('#ts6s044').prop("checked", false);
    $('#ts6s045').prop("checked", false);
    $('#ts6s046').prop("checked", false);
    $('#ts6s047').prop("checked", false);
    $('#ts6s051').prop("checked", false);
    $('#ts6s052').prop("checked", false);
    $('#ts6s053').prop("checked", false);
    $('#ts6s054').prop("checked", false);
    $('#ts6s055').prop("checked", false);
    $('#ts6s056').prop("checked", false);
    $('#ts6s057').prop("checked", false);
    $('#ts6s061').prop("checked", false);
    $('#ts6s062').prop("checked", false);
    $('#ts6s063').prop("checked", false);
    $('#ts6s064').prop("checked", false);
    $('#ts6s065').prop("checked", false);
    $('#ts6s066').prop("checked", false);
    $('#ts6s067').prop("checked", false);
    $('#ts6s071').prop("checked", false);
    $('#ts6s072').prop("checked", false);
    $('#ts6s073').prop("checked", false);
    $('#ts6s074').prop("checked", false);
    $('#ts6s075').prop("checked", false);
    $('#ts6s076').prop("checked", false);
    $('#ts6s077').prop("checked", false);
    $('#ts6s081').prop("checked", false);
    $('#ts6s082').prop("checked", false);
    $('#ts6s083').prop("checked", false);
    $('#ts6s084').prop("checked", false);
    $('#ts6s085').prop("checked", false);
    $('#ts6s086').prop("checked", false);
    $('#ts6s087').prop("checked", false);
    $('#ts6s091').prop("checked", false);
    $('#ts6s092').prop("checked", false);
    $('#ts6s093').prop("checked", false);
    $('#ts6s094').prop("checked", false);
    $('#ts6s095').prop("checked", false);
    $('#ts6s096').prop("checked", false);
    $('#ts6s097').prop("checked", false);
    $('#ts6s101').prop("checked", false);
    $('#ts6s102').prop("checked", false);
    $('#ts6s103').prop("checked", false);
    $('#ts6s104').prop("checked", false);
    $('#ts6s105').prop("checked", false);
    $('#ts6s106').prop("checked", false);
    $('#ts6s107').prop("checked", false);
    $('#ts6s111').prop("checked", false);
    $('#ts6s112').prop("checked", false);
    $('#ts6s113').prop("checked", false);
    $('#ts6s114').prop("checked", false);
    $('#ts6s115').prop("checked", false);
    $('#ts6s116').prop("checked", false);
    $('#ts6s117').prop("checked", false);
    
}
function resv1() {
    $("#ic1010011").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010012").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1010013").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010014").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1010015").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010016").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010017").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010021").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010022").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010023").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010024").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010025").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010026").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010027").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010031").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010032").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010033").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010034").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010035").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010036").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010037").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010041").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010042").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010043").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010044").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010045").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010046").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010047").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010051").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010052").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010053").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010054").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010055").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010056").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010057").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010061").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010062").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010063").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010064").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010065").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010066").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010067").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010071").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010072").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010073").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010074").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010075").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010076").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010077").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010081").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010082").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010083").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010084").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010085").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010086").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010087").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010091").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010092").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010093").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010094").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010095").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010096").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010097").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010101").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010102").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010103").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010104").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010105").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010106").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010107").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010111").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010112").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010113").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010114").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010115").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010116").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010117").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010121").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010122").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010123").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010124").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010125").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010126").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010127").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010131").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010132").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010133").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010134").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010135").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010136").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010137").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010141").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010142").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010143").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010144").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010145").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010146").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010147").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1010154").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010164").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010174").removeClass().addClass('fa fa-check').css("color", "white"); 
    $("#ic1010184").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic101s01").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic101s02").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic101s03").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic101s04").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic101s05").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic101s06").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic101s07").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic102s04").removeClass().addClass('fa fa-check').css("color", "white");   
}
function resv2() {
    $("#ic1020011").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020012").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020013").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020014").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020015").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020016").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020017").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020021").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020022").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020023").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020024").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020025").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020026").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020027").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020031").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020032").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020033").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020034").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020035").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020036").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020037").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020041").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020042").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020043").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020044").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020045").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020046").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020047").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020051").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020052").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020053").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020054").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020055").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020056").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020057").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020061").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020062").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020063").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020064").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020065").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020066").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020067").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020073").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020083").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020093").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020103").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020113").removeClass().addClass('fa fa-check').css("color", "#F8F8F8");
    $("#ic1020f11").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020f12").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020f13").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020f14").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020f15").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020f16").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020f17").removeClass().addClass('fa fa-check').css("color", "white");
    $("#ic1020f20").removeClass().addClass('fa fa-check').css("color", "white");
};




//if (GWDAY == 0 || GWWEE == 0 || S6DAY == 0 || S6WEE == 0) {
//    markeri.push(L.marker([aclat, aclng], { icon: redIcon }).bindPopup("District:<a href='#' class='pop'> " + dist + "</a><br><span>Region:</span><a class='pop'> " + region + "</a><br><span>Division:</span><a class='pop'> " + divNm + "</a><br><span>State:</span><a class='pop'> " + disSt + "</a><span> City:</span><a class='pop'> " + disCi + "</a><span> ZIP:</span><a class='pop'> " + disZp + "</a><br /><span> Address:</span><a class='pop'> " + disAd + "<br /><span style='color:black !important'>DOD:</span><a class='pop'> " + DOD + "</a><br></a><h5>Tasks:</h5><table><thead><tr><th>Task:</th><th style='padding-left:5px'>Doc:</th><th style='padding-left:10px'>D:</th><th style='padding-left:5px'>W:</th><th style='padding-left:5px'>Due:</th><th style='padding-left:10px'>Ap:</th></tr></thead><tbody><tr><td><span>GW:</span></td><td style='padding-left:5px'><a href='#' onClick='proba(" + distid + ")'>" + GWLIDc + "</a></td><td><i class='fa fa-check' style='color:lightseagreen; padding-left:10px'></i></td><td><i class='fa fa-check' style='color:lightseagreen; padding-left:5px'></i></td><td style='padding-left:5px'>" + dtby1 + "</td><td style='padding-left:5px'><i class='fa fa-check' style='color:lightseagreen; padding-left:5px'></i></td></tr><tr><td><span>6S:</span></td><td style='padding-left:5px'><a href='#' onClick='probb(" + distid + ")'>" + S6LIDc + "</a></td><td><i class='fa fa-check' style='color:lightseagreen; padding-left:10px'></i></td><td><i class='fa fa-check' style='color:lightseagreen; padding-left:5px'></i></td><td style='padding-left:5px'>" + dtby2 + "</td><td><i class='fa fa-check' style='color:lightseagreen; padding-left:10px'></i></tr></tbody></table><h5>Assessment:</h5><span>Doc:</span><a href='#' onClick='probc(" + distid + ")'> " + AASIDc + " </a><span> Date: </span><a> " + asdate + " </a><table><thead><tr style='border-bottom:solid; border-bottom-width:thin; border-bottom-color:lightblue'><th>Area:</th><th style='text-align:center; padding-left:5px'>Score</th><th style='text-align:center; padding-left:5px'>Max</th><th style='color:white'>.</th><th style='color:white'>.</th></tr></thead><tbody><tr><td>Patient Ready Area</td><td style='text-align:center'>" + AAS01 + "</td><td style='text-align:center; color:#367EAD'>40</td><td style='text-align:right; padding-left:10px'>" + AAS91 + "</td><td style='padding-left:2px'>%</td></tr><tr><td>Inspection / Testing Station</td><td style='text-align:center'>" + AAS02 + "</td><td style='text-align:center; color:#367EAD'>26</td><td style='text-align:right; padding-left:10px'>" + AAS92 + "</td><td style='padding-left:2px'>%</td></tr><tr><td>Cleaning Station</td><td style='text-align:center'>" + AAS03 + "</td><td style='text-align:center; color:#367EAD'>48</td><td style='text-align:right; padding-left:10px'>" + AAS93 + "</td><td style='padding-left:2px'>%</td></tr><tr><td>Shipping / Receiving</td><td style='text-align:center'>" + AAS04 + "</td><td style='text-align:center; color:#367EAD'>20</td><td style='text-align:right; padding-left:10px'>" + AAS94 + "</td><td style='padding-left:2px'>%</td></tr><tr><td>Biomed Department BERD</td><td style='text-align:center'>" + AAS05 + "</td><td style='text-align:center; color:#367EAD'>36</td><td style='text-align:right; padding-left:10px'>" + AAS95 + "</td><td style='padding-left:2px'>%</td></tr><tr><td>Surgical Services</td><td style='text-align:center'>" + AAS06 + "</td><td style='text-align:center; color:#367EAD'>24</td><td style='text-align:right; padding-left:10px'>" + AAS96 + "</td><td style='padding-left:2px'>%</td></tr><tr><td>Overall Building</td><td style='text-align:center'>" + AAS07 + "</td><td style='text-align:center; color:#367EAD'>58</td><td style='text-align:right; padding-left:10px'>" + AAS97 + "</td><td style='padding-left:2px'>%</td></tr><tr><td>Other</td><td style='text-align:center'>" + AAS08 + "</td><td style='text-align:center; color:#367EAD'>20</td><td style='text-align:right; padding-left:10px'>" + AAS98 + "</td><td style='padding-left:2px'>%</td></tr><tr style='border-top:solid; border-top-width:thin; border-top-color:lightblue'><td style='text-align:right; padding-right:2px; color:#367EAD'>Total:</td><td style='text-align:center'>" + AASTO + "</td><td style='text-align:center; color:#367EAD'>272</td><td style='text-align:right'>" + AASPC + "</td><td style='padding-left:2px'>%</td></tr></tbody></table>").openPopup());
//} else if {
//}
//else {
//    markeri.push(L.marker([aclat, aclng]).bindPopup("<b>Hello world!</b><br /><a href='#' class='pop'>" + dist + "</a>").openPopup());
//}