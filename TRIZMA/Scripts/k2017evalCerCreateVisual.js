
        $(document).ready(
            function () {
                getValues();
            });
function getValues() {
    var ItSel = parseInt(@ViewBag.Select);
    if (ItSel == 2)
    {
        getEval();
    }
    else if (ItSel == 3)
    {
        getCalib();
    }
}
function getEval(){
    var basicdd1 = $("#basicdd1").val();
    var basicdd2 = $("#basicdd2").val();
    var basicdd3 = $("#basicdd3").val();
    var basicdd4 = $("#basicdd4").val();
    var basicdd5 = $("#basicdd5").val();
    var basicdd6 = $("#basicdd6").val();
    var basicdd7 = $("#basicdd7").val();
    var basicdd8 = $("#basicdd8").val();
    var basicdd9 = $("#basicdd9").val();
    var basicdd10 = $("#basicdd10").val();
    var basicdd11 = $("#basicdd11").val();
    var bonusdd1 = $("#bonusdd1").val();
    var bonusdd2 = $("#bonusdd2").val();
    var bonusdd3 = $("#bonusdd3").val();
    var bonusdd4 = $("#bonusdd4").val();
    var bonusdd5 = $("#bonusdd5").val();
    It01 = parseInt(basicdd1) - 1;
    It02 = parseInt(basicdd2) - 1;
    It03 = parseInt(basicdd3) - 1;
    It04 = parseInt(basicdd4) - 1;
    It05 = parseInt(basicdd5) - 1;
    It06 = parseInt(basicdd6) - 1;
    It07 = parseInt(basicdd7) - 1;
    It08 = parseInt(basicdd8) - 1;
    It09 = parseInt(basicdd9) - 1;
    It10 = parseInt(basicdd10) - 1;
    It11 = parseInt(basicdd11) - 1;
    if (bonusdd1 == 1) { var Ut1 = 0, Up1 = 0 } else if (bonusdd1 == 7) { var Ut1 = 0.1, Up1 = 1.1 }
    if (bonusdd2 == 1) { var Ut2 = 0, Up2 = 0 } else if (bonusdd2 == 7) { var Ut2 = 0.1, Up2 = 1.1 }
    if (bonusdd3 == 1) { var Ut3 = 0, Up3 = 0 } else if (bonusdd3 == 7) { var Ut3 = 0.1, Up3 = 1.1 }
    if (bonusdd4 == 1) { var Ut4 = 0, Up4 = 0 } else if (bonusdd4 == 7) { var Ut4 = 0.1, Up4 = 1.1 }
    if (bonusdd5 == 1) { var Ut5 = 0, Up5 = 0 } else if (bonusdd5 == 7) { var Ut5 = 0.1, Up5 = 1.1 }
    var bsGr = ((parseInt(It01) + parseInt(It02) + parseInt(It03) + parseInt(It04) + parseInt(It05) + parseInt(It06) + parseInt(It07) + parseInt(It08) + parseInt(It09) + parseInt(It10) + parseInt(It11)) / 55) * 100 * (4.5 / 100);
    var bsPr = parseInt(It01) * 0.25 + parseInt(It02) * 2.3 + parseInt(It03) * 1 + parseInt(It04) * 2.3 + parseInt(It05) * 1.5 + parseInt(It06) * 2.1 + parseInt(It07) * 4.8 + parseInt(It08) * 0.25 + parseInt(It09) * 2 + parseInt(It10) * 1.5 + parseInt(It11) * 0.9;
    var bnGr = parseFloat(Ut1) + parseFloat(Ut2) + parseFloat(Ut3) + parseFloat(Ut4) + parseFloat(Ut5);
    var bnPr = parseFloat(Up1) + parseFloat(Up2) + parseFloat(Up3) + parseFloat(Up4) + parseFloat(Up5);
    if (bonusdd1 == 1 || bonusdd2 == 1 || bonusdd3 == 1 || bonusdd4 == 1 || bonusdd5 == 1) {
        var bnGr = 0
        var bnPr = 0
        var It21 = bsGr.toFixed(2);
        var It22 = bsPr.toFixed(2) + "%";
        var It23 = bnGr.toFixed(2);
        var It24 = bnPr.toFixed(2) + "%";
        var It25 = bsGr.toFixed(2);
        var It26 = bsPr.toFixed(2) + "%";
        $("#upScorea").html(It21);
        $("#upScoreb").html(It22);
        $("#upScorec").html(It23);
        $("#upScored").html(It24);
        $("#upScoree").html(It25);
        $("#upScoref").html(It26);
        $("#upScorea2").html(It21);
        $("#upScoreb2").html(It22);
        $("#upScorea3").html(It21);
        $("#upScoreb3").html(It22);
        $("#upScorec3").html(It23);
        $("#upScored3").html(It24);
        $("#upScoree3").html(It25);
        $("#upScoref3").html(It26);
    } else
        var bsbnGr = bsGr + bnGr;
    var bsbnPr = bsPr + bnPr;
    var It21 = bsGr.toFixed(2);
    var It22 = bsPr.toFixed(2) + "%";
    var It23 = bnGr.toFixed(2);
    var It24 = bnPr.toFixed(2) + "%";
    var It25 = bsbnGr.toFixed(2);
    var It26 = bsbnPr.toFixed(2) + "%";
    $("#upScorea").html(It21);
    $("#upScoreb").html(It22);
    $("#upScorec").html(It23);
    $("#upScored").html(It24);
    $("#upScoree").html(It25);
    $("#upScoref").html(It26);
    $("#upScorea2").html(It21);
    $("#upScoreb2").html(It22);
    $("#upScorea3").html(It21);
    $("#upScoreb3").html(It22);
    $("#upScorec3").html(It23);
    $("#upScored3").html(It24);
    $("#upScoree3").html(It25);
    $("#upScoref3").html(It26);
    //console.log(check1);
}

function getCalib() {
    var Ita1 = $("#addmGreetMessQat").val(); Ira1 = parseInt(Ita1) - 1;
    var Ita2 = $("#addmGreetMessQac").val(); Ira2 = parseInt(Ita2) - 1;
    var Ita3 = $("#addmGreetMessOpt").val(); Ira3 = parseInt(Ita3) - 1;
    var Ita4 = $("#addmGreetMessOpc").val(); Ira4 = parseInt(Ita4) - 1;
    var Itb1 = $("#addmCallFocusQat").val(); Irb1 = parseInt(Itb1) - 1;
    var Itb2 = $("#addmCallFocusQac").val(); Irb2 = parseInt(Itb2) - 1;
    var Itb3 = $("#addmCallFocusOpt").val(); Irb3 = parseInt(Itb3) - 1;
    var Itb4 = $("#addmCallFocusOpc").val(); Irb4 = parseInt(Itb4) - 1;
    var Itc1 = $("#mObtnVerifQat").val(); Irc1 = parseInt(Itc1) - 1;
    var Itc2 = $("#mObtnVerifQac").val(); Irc2 = parseInt(Itc2) - 1;
    var Itc3 = $("#mObtnVerifOpt").val(); Irc3 = parseInt(Itc3) - 1;
    var Itc4 = $("#mObtnVerifOpc").val(); Irc4 = parseInt(Itc4) - 1;
    var Itd1 = $("#mClarResolQat").val(); Ird1 = parseInt(Itd1) - 1;
    var Itd2 = $("#mClarResolQac").val(); Ird2 = parseInt(Itd2) - 1;
    var Itd3 = $("#mClarResolOpt").val(); Ird3 = parseInt(Itd3) - 1;
    var Itd4 = $("#mClarResolOpc").val(); Ird4 = parseInt(Itd4) - 1;
    var Ite1 = $("#mOvnrExpreQat").val(); Ire1 = parseInt(Ite1) - 1;
    var Ite2 = $("#mOvnrExpreQac").val(); Ire2 = parseInt(Ite2) - 1;
    var Ite3 = $("#mOvnrExpreOpt").val(); Ire3 = parseInt(Ite3) - 1;
    var Ite4 = $("#mOvnrExpreOpc").val(); Ire4 = parseInt(Ite4) - 1;
    var Itf1 = $("#mTactProbeQat").val(); Irf1 = parseInt(Itf1) - 1;
    var Itf2 = $("#mTactProbeQac").val(); Irf2 = parseInt(Itf2) - 1;
    var Itf3 = $("#mTactProbeOpt").val(); Irf3 = parseInt(Itf3) - 1;
    var Itf4 = $("#mTactProbeOpc").val(); Irf4 = parseInt(Itf4) - 1;
    var Itg1 = $("#mFollProceQat").val(); Irg1 = parseInt(Itg1) - 1;
    var Itg2 = $("#mFollProceQac").val(); Irg2 = parseInt(Itg2) - 1;
    var Itg3 = $("#mFollProceOpt").val(); Irg3 = parseInt(Itg3) - 1;
    var Itg4 = $("#mFollProceOpc").val(); Irg4 = parseInt(Itg4) - 1;
    var Ith1 = $("#mApprCloseQat").val(); Irh1 = parseInt(Ith1) - 1;
    var Ith2 = $("#mApprCloseQac").val(); Irh2 = parseInt(Ith2) - 1;
    var Ith3 = $("#mApprCloseOpt").val(); Irh3 = parseInt(Ith3) - 1;
    var Ith4 = $("#mApprCloseOpc").val(); Irh4 = parseInt(Ith4) - 1;
    var Iti1 = $("#mPoliCourtQat").val(); Iri1 = parseInt(Iti1) - 1;
    var Iti2 = $("#mPoliCourtQac").val(); Iri2 = parseInt(Iti2) - 1;
    var Iti3 = $("#mPoliCourtOpt").val(); Iri3 = parseInt(Iti3) - 1;
    var Iti4 = $("#mPoliCourtOpc").val(); Iri4 = parseInt(Iti4) - 1;
    var Itj1 = $("#mCleaAudibQat").val(); Irj1 = parseInt(Itj1) - 1;
    var Itj2 = $("#mCleaAudibQac").val(); Irj2 = parseInt(Itj2) - 1;
    var Itj3 = $("#mCleaAudibOpt").val(); Irj3 = parseInt(Itj3) - 1;
    var Itj4 = $("#mCleaAudibOpc").val(); Irj4 = parseInt(Itj4) - 1;
    var Itk1 = $("#mGramTermsQat").val(); Irk1 = parseInt(Itk1) - 1;
    var Itk2 = $("#mGramTermsQac").val(); Irk2 = parseInt(Itk2) - 1;
    var Itk3 = $("#mGramTermsOpt").val(); Irk3 = parseInt(Itk3) - 1;
    var Itk4 = $("#mGramTermsOpc").val(); Irk4 = parseInt(Itk4) - 1;
    var Itl1 = $("#nBonusaQat").val();
    var Itl2 = $("#nBonusaQac").val();
    var Itl3 = $("#nBonusaOpt").val();
    var Itl4 = $("#nBonusaOpc").val();
    var Itm1 = $("#nBonusbQat").val();
    var Itm2 = $("#nBonusbQac").val();
    var Itm3 = $("#nBonusbOpt").val();
    var Itm4 = $("#nBonusbOpc").val();
    var Itn1 = $("#nBonuscQat").val();
    var Itn2 = $("#nBonuscQac").val();
    var Itn3 = $("#nBonuscOpt").val();
    var Itn4 = $("#nBonuscOpc").val();
    var Ito1 = $("#nBonusdQat").val();
    var Ito2 = $("#nBonusdQac").val();
    var Ito3 = $("#nBonusdOpt").val();
    var Ito4 = $("#nBonusdOpc").val();
    var Itp1 = $("#nBonuseQat").val();
    var Itp2 = $("#nBonuseQac").val();
    var Itp3 = $("#nBonuseOpt").val();
    var Itp4 = $("#nBonuseOpc").val();
    var bsGr = ((parseFloat(Ira1 + Ira2 + Ira3 + Ira4) / 4 + parseFloat(Irb1 + Irb2 + Irb3 + Irb4) / 4 + parseFloat(Irc1 + Irc2 + Irc3 + Irc4) / 4 + parseFloat(Ird1 + Ird2 + Ird3 + Ird4) / 4 + parseFloat(Ire1 + Ire2 + Ire3 + Ire4) / 4 + parseFloat(Irf1 + Irf2 + Irf3 + Irf4) / 4 + parseFloat(Irg1 + Irg2 + Irg3 + Irg4) / 4 + parseFloat(Irh1 + Irh2 + Irh3 + Irh4) / 4 + parseFloat(Iri1 + Iri2 + Iri3 + Iri4) / 4 + parseFloat(Irj1 + Irj2 + Irj3 + Irj4) / 4 + parseFloat(Irk1 + Irk2 + Irk3 + Irk4) / 4) / 55) * 100 * (4.5 / 100);
    var bsPr = (parseFloat(Ira1 + Ira2 + Ira3 + Ira4) / 4) * 0.25 + (parseFloat(Irb1 + Irb2 + Irb3 + Irb4) / 4) * 2.3 + (parseFloat(Irc1 + Irc2 + Irc3 + Irc4) / 4) * 1 + (parseFloat(Ird1 + Ird2 + Ird3 + Ird4) / 4) * 2.3 + (parseFloat(Ire1 + Ire2 + Ire3 + Ire4) / 4) * 1.5 + (parseFloat(Irf1 + Irf2 + Irf3 + Irf4) / 4) * 2.1 + (parseFloat(Irg1 + Irg2 + Irg3 + Irg4) / 4) * 4.8 + (parseFloat(Irh1 + Irh2 + Irh3 + Irh4) / 4) * 0.25 + (parseFloat(Iri1 + Iri2 + Iri3 + Iri4) / 4) * 2 + (parseFloat(Irj1 + Irj2 + Irj3 + Irj4) / 4) * 1.5 + (parseFloat(Irk1 + Irk2 + Irk3 + Irk4) / 4) * 0.9;
    if (Itl1 == 1 || Itl2 == 1 || Itl3 == 1 || Itl4 == 1 ||
        Itm1 == 1 || Itm2 == 1 || Itm3 == 1 || Itm4 == 1 ||
        Itn1 == 1 || Itn2 == 1 || Itn3 == 1 || Itn4 == 1 ||
        Ito1 == 1 || Ito2 == 1 || Ito3 == 1 || Ito4 == 1 ||
        Itp1 == 1 || Itp2 == 1 || Itp3 == 1 || Itp4 == 1) {
        var bnGr = 0;
        var bnPr = 0;
        var It21 = bsGr.toFixed(2);
        var It22 = bsPr.toFixed(2) + "%";
        var It23 = bnGr.toFixed(2);
        var It24 = bnPr.toFixed(2) + "%";
        var It25 = bsGr.toFixed(2);
        var It26 = bsPr.toFixed(2) + "%";
        $("#upScorea").html(It21);
        $("#upScoreb").html(It22);
        $("#upScorec").html(It23);
        $("#upScored").html(It24);
        $("#upScoree").html(It25);
        $("#upScoref").html(It26);
        $("#upScorea2").html(It21);
        $("#upScoreb2").html(It22);
        $("#upScorea3").html(It21);
        $("#upScoreb3").html(It22);
        $("#upScorec3").html(It23);
        $("#upScored3").html(It24);
        $("#upScoree3").html(It25);
        $("#upScoref3").html(It26);
    } else
        var bsbnGr = bsGr + 0.5;
    var bsbnPr = bsPr + 5.5;
    var bnGr = 0.5;
    var bnPr = 5.5;
    var It21 = bsGr.toFixed(2);
    var It22 = bsPr.toFixed(2) + "%";
    var It23 = bnGr.toFixed(2);
    var It24 = bnPr.toFixed(2) + "%";
    var It25 = bsbnGr.toFixed(2);
    var It26 = bsbnPr.toFixed(2) + "%";
    $("#upScorea").html(It21);
    $("#upScoreb").html(It22);
    $("#upScorec").html(It23);
    $("#upScored").html(It24);
    $("#upScoree").html(It25);
    $("#upScoref").html(It26);
    $("#upScorea2").html(It21);
    $("#upScoreb2").html(It22);
    $("#upScorea3").html(It21);
    $("#upScoreb3").html(It22);
    $("#upScorec3").html(It23);
    $("#upScored3").html(It24);
    $("#upScoree3").html(It25);
    $("#upScoref3").html(It26);
    //console.log(check1);
}
