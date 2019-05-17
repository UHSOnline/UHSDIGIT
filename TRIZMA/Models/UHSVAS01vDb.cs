namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSVAS01v")]
    public partial class UHSVAS01vDb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string ID { get; set; }
        public int projid { get; set; }
        public int tskoid { get; set; }
        public int dcgrid { get; set; }
        public int dctpid { get; set; }
        public int tspdid { get; set; }
        public int distid { get; set; }
        public string distnm { get; set; }
        public int acctid { get; set; }
        public int userid { get; set; }
        public string usernm { get; set; }
        public int dimgid { get; set; }
        public string dimgnm { get; set; }

        public int GR101 { get; set; }
        public int GR102 { get; set; }
        public int GR103 { get; set; }
        public int GR104 { get; set; }
        public int GR105 { get; set; }
        public int GR106 { get; set; }
        public int GR107 { get; set; }
        public int GR108 { get; set; }
        public int GR109 { get; set; }
        public int GR110 { get; set; }
        public int GR111 { get; set; }
        public int GR112 { get; set; }
        public int GR113 { get; set; }
        public int GR114 { get; set; }
        public int GR115 { get; set; }
        public int GR116 { get; set; }
        public int GR117 { get; set; }
        public int GR118 { get; set; }
        public int GR119 { get; set; }
        public int GR120 { get; set; }
        public int GR121 { get; set; }
        public int GR122 { get; set; }
        public int GR123 { get; set; }
        public int GR124 { get; set; }
        public int GR125 { get; set; }
        public int GR126 { get; set; }
        public int GR127 { get; set; }
        public int GR128 { get; set; }
        public int GR129 { get; set; }
        public int GR130 { get; set; }
        public int GR201 { get; set; }
        public int GR202 { get; set; }
        public int GR203 { get; set; }
        public int GR204 { get; set; }
        public int GR205 { get; set; }
        public int GR206 { get; set; }
        public int GR207 { get; set; }
        public int GR208 { get; set; }
        public int GR209 { get; set; }
        public int GR210 { get; set; }
        public int GR211 { get; set; }
        public int GR212 { get; set; }
        public int GR213 { get; set; }
        public int GR214 { get; set; }
        public int GR215 { get; set; }
        public int GR216 { get; set; }
        public int GR217 { get; set; }
        public int GR218 { get; set; }
        public int GR219 { get; set; }
        public int GR220 { get; set; }
        public int GR301 { get; set; }
        public int GR302 { get; set; }
        public int GR303 { get; set; }
        public int GR304 { get; set; }
        public int GR305 { get; set; }
        public int GR306 { get; set; }
        public int GR307 { get; set; }
        public int GR308 { get; set; }
        public int GR309 { get; set; }
        public int GR310 { get; set; }
        public int GR311 { get; set; }
        public int GR312 { get; set; }
        public int GR313 { get; set; }
        public int GR314 { get; set; }
        public int GR315 { get; set; }
        public int GR316 { get; set; }
        public int GR317 { get; set; }
        public int GR318 { get; set; }
        public int GR319 { get; set; }
        public int GR320 { get; set; }
        public int GR321 { get; set; }
        public int GR322 { get; set; }
        public int GR323 { get; set; }
        public int GR324 { get; set; }
        public int GR325 { get; set; }
        public int GR401 { get; set; }
        public int GR402 { get; set; }
        public int GR403 { get; set; }
        public int GR404 { get; set; }
        public int GR405 { get; set; }
        public int GR406 { get; set; }
        public int GR407 { get; set; }
        public int GR408 { get; set; }
        public int GR409 { get; set; }
        public int GR410 { get; set; }
        public int GR411 { get; set; }
        public int GR412 { get; set; }
        public int GR413 { get; set; }
        public int GR414 { get; set; }
        public int GR415 { get; set; }
        public int GR416 { get; set; }
        public int GR417 { get; set; }
        public int GR418 { get; set; }
        public int GR419 { get; set; }
        public int GR420 { get; set; }
        public int GR421 { get; set; }
        public int GR422 { get; set; }
        public int GR423 { get; set; }
        public int GR424 { get; set; }
        public int GR425 { get; set; }
        public int GR501 { get; set; }
        public int GR502 { get; set; }
        public int GR503 { get; set; }
        public int GR504 { get; set; }
        public int GR505 { get; set; }
        public int GR506 { get; set; }
        public int GR507 { get; set; }
        public int GR508 { get; set; }
        public int GR509 { get; set; }
        public int GR510 { get; set; }
        public int GR511 { get; set; }
        public int GR512 { get; set; }
        public int GR513 { get; set; }
        public int GR514 { get; set; }
        public int GR515 { get; set; }
        public int GR516 { get; set; }
        public int GR517 { get; set; }
        public int GR518 { get; set; }
        public int GR519 { get; set; }
        public int GR520 { get; set; }
        public int GR521 { get; set; }
        public int GR522 { get; set; }
        public int GR523 { get; set; }
        public int GR524 { get; set; }
        public int GR525 { get; set; }
        public int GR526 { get; set; }
        public int GR527 { get; set; }
        public int GR528 { get; set; }
        public int GR529 { get; set; }
        public int GR530 { get; set; }
        public int GR601 { get; set; }
        public int GR602 { get; set; }
        public int GR603 { get; set; }
        public int GR604 { get; set; }
        public int GR605 { get; set; }
        public int GR606 { get; set; }
        public int GR607 { get; set; }
        public int GR608 { get; set; }
        public int GR609 { get; set; }
        public int GR610 { get; set; }
        public int GR611 { get; set; }
        public int GR612 { get; set; }
        public int GR613 { get; set; }
        public int GR614 { get; set; }
        public int GR615 { get; set; }
        public int GR616 { get; set; }
        public int GR617 { get; set; }
        public int GR618 { get; set; }
        public int GR619 { get; set; }
        public int GR620 { get; set; }
        public int GR701 { get; set; }
        public int GR702 { get; set; }
        public int GR703 { get; set; }
        public int GR704 { get; set; }
        public int GR705 { get; set; }
        public int GR706 { get; set; }
        public int GR707 { get; set; }
        public int GR708 { get; set; }
        public int GR709 { get; set; }
        public int GR710 { get; set; }
        public int GR711 { get; set; }
        public int GR712 { get; set; }
        public int GR713 { get; set; }
        public int GR714 { get; set; }
        public int GR715 { get; set; }
        public int GR716 { get; set; }
        public int GR717 { get; set; }
        public int GR718 { get; set; }
        public int GR719 { get; set; }
        public int GR720 { get; set; }
        public int GR721 { get; set; }
        public int GR722 { get; set; }
        public int GR723 { get; set; }
        public int GR724 { get; set; }
        public int GR725 { get; set; }
        public int GR726 { get; set; }
        public int GR727 { get; set; }
        public int GR728 { get; set; }
        public int GR729 { get; set; }
        public int GR730 { get; set; }
        public int GR731 { get; set; }
        public int GR732 { get; set; }
        public int GR733 { get; set; }
        public int GR734 { get; set; }
        public int GR735 { get; set; }
        public int GR801 { get; set; }
        public int GR802 { get; set; }
        public int GR803 { get; set; }
        public int GR804 { get; set; }
        public int GR805 { get; set; }
        public int GR806 { get; set; }
        public int GR807 { get; set; }
        public int GR808 { get; set; }
        public int GR809 { get; set; }
        public int GR810 { get; set; }
        public int GR811 { get; set; }
        public int GR812 { get; set; }
        public int GR813 { get; set; }
        public int GR814 { get; set; }
        public int GR815 { get; set; }
        public int GR816 { get; set; }
        public int GR817 { get; set; }
        public int GR818 { get; set; }
        public int GR819 { get; set; }
        public int GR820 { get; set; }
        public int GR901 { get; set; }
        public int GR902 { get; set; }
        public int GR903 { get; set; }
        public int GR904 { get; set; }
        public int GR905 { get; set; }
        public int GR906 { get; set; }
        public int GR907 { get; set; }
        public int GR908 { get; set; }
        public int GR909 { get; set; }
        public int GR910 { get; set; }
        public int GR911 { get; set; }
        public int GR912 { get; set; }
        public int GR913 { get; set; }
        public int GR914 { get; set; }
        public int GR915 { get; set; }
        public int GR916 { get; set; }
        public int GR917 { get; set; }
        public int GR918 { get; set; }
        public int GR919 { get; set; }
        public int GR920 { get; set; }
        public string TX101 { get; set; }
        public string TX102 { get; set; }
        public string TX103 { get; set; }
        public string TX104 { get; set; }
        public string TX105 { get; set; }
        public string TX106 { get; set; }
        public string TX107 { get; set; }
        public string TX108 { get; set; }
        public string TX109 { get; set; }
        public string TX110 { get; set; }
        public string TX111 { get; set; }
        public string TX112 { get; set; }
        public string TX113 { get; set; }
        public string TX114 { get; set; }
        public string TX115 { get; set; }
        public string TX116 { get; set; }
        public string TX117 { get; set; }
        public string TX118 { get; set; }
        public string TX119 { get; set; }
        public string TX120 { get; set; }
        public string TX121 { get; set; }
        public string TX122 { get; set; }
        public string TX123 { get; set; }
        public string TX124 { get; set; }
        public string TX125 { get; set; }
        public string TX126 { get; set; }
        public string TX127 { get; set; }
        public string TX128 { get; set; }
        public string TX129 { get; set; }
        public string TX130 { get; set; }
        public string TX201 { get; set; }
        public string TX202 { get; set; }
        public string TX203 { get; set; }
        public string TX204 { get; set; }
        public string TX205 { get; set; }
        public string TX206 { get; set; }
        public string TX207 { get; set; }
        public string TX208 { get; set; }
        public string TX209 { get; set; }
        public string TX210 { get; set; }
        public string TX211 { get; set; }
        public string TX212 { get; set; }
        public string TX213 { get; set; }
        public string TX214 { get; set; }
        public string TX215 { get; set; }
        public string TX216 { get; set; }
        public string TX217 { get; set; }
        public string TX218 { get; set; }
        public string TX219 { get; set; }
        public string TX220 { get; set; }
        public string TX301 { get; set; }
        public string TX302 { get; set; }
        public string TX303 { get; set; }
        public string TX304 { get; set; }
        public string TX305 { get; set; }
        public string TX306 { get; set; }
        public string TX307 { get; set; }
        public string TX308 { get; set; }
        public string TX309 { get; set; }
        public string TX310 { get; set; }
        public string TX311 { get; set; }
        public string TX312 { get; set; }
        public string TX313 { get; set; }
        public string TX314 { get; set; }
        public string TX315 { get; set; }
        public string TX316 { get; set; }
        public string TX317 { get; set; }
        public string TX318 { get; set; }
        public string TX319 { get; set; }
        public string TX320 { get; set; }
        public string TX321 { get; set; }
        public string TX322 { get; set; }
        public string TX323 { get; set; }
        public string TX324 { get; set; }
        public string TX325 { get; set; }
        public string TX401 { get; set; }
        public string TX402 { get; set; }
        public string TX403 { get; set; }
        public string TX404 { get; set; }
        public string TX405 { get; set; }
        public string TX406 { get; set; }
        public string TX407 { get; set; }
        public string TX408 { get; set; }
        public string TX409 { get; set; }
        public string TX410 { get; set; }
        public string TX411 { get; set; }
        public string TX412 { get; set; }
        public string TX413 { get; set; }
        public string TX414 { get; set; }
        public string TX415 { get; set; }
        public string TX416 { get; set; }
        public string TX417 { get; set; }
        public string TX418 { get; set; }
        public string TX419 { get; set; }
        public string TX420 { get; set; }
        public string TX421 { get; set; }
        public string TX422 { get; set; }
        public string TX423 { get; set; }
        public string TX424 { get; set; }
        public string TX425 { get; set; }
        public string TX501 { get; set; }
        public string TX502 { get; set; }
        public string TX503 { get; set; }
        public string TX504 { get; set; }
        public string TX505 { get; set; }
        public string TX506 { get; set; }
        public string TX507 { get; set; }
        public string TX508 { get; set; }
        public string TX509 { get; set; }
        public string TX510 { get; set; }
        public string TX511 { get; set; }
        public string TX512 { get; set; }
        public string TX513 { get; set; }
        public string TX514 { get; set; }
        public string TX515 { get; set; }
        public string TX516 { get; set; }
        public string TX517 { get; set; }
        public string TX518 { get; set; }
        public string TX519 { get; set; }
        public string TX520 { get; set; }
        public string TX521 { get; set; }
        public string TX522 { get; set; }
        public string TX523 { get; set; }
        public string TX524 { get; set; }
        public string TX525 { get; set; }
        public string TX526 { get; set; }
        public string TX527 { get; set; }
        public string TX528 { get; set; }
        public string TX529 { get; set; }
        public string TX530 { get; set; }
        public string TX601 { get; set; }
        public string TX602 { get; set; }
        public string TX603 { get; set; }
        public string TX604 { get; set; }
        public string TX605 { get; set; }
        public string TX606 { get; set; }
        public string TX607 { get; set; }
        public string TX608 { get; set; }
        public string TX609 { get; set; }
        public string TX610 { get; set; }
        public string TX611 { get; set; }
        public string TX612 { get; set; }
        public string TX613 { get; set; }
        public string TX614 { get; set; }
        public string TX615 { get; set; }
        public string TX616 { get; set; }
        public string TX617 { get; set; }
        public string TX618 { get; set; }
        public string TX619 { get; set; }
        public string TX620 { get; set; }
        public string TX701 { get; set; }
        public string TX702 { get; set; }
        public string TX703 { get; set; }
        public string TX704 { get; set; }
        public string TX705 { get; set; }
        public string TX706 { get; set; }
        public string TX707 { get; set; }
        public string TX708 { get; set; }
        public string TX709 { get; set; }
        public string TX710 { get; set; }
        public string TX711 { get; set; }
        public string TX712 { get; set; }
        public string TX713 { get; set; }
        public string TX714 { get; set; }
        public string TX715 { get; set; }
        public string TX716 { get; set; }
        public string TX717 { get; set; }
        public string TX718 { get; set; }
        public string TX719 { get; set; }
        public string TX720 { get; set; }
        public string TX721 { get; set; }
        public string TX722 { get; set; }
        public string TX723 { get; set; }
        public string TX724 { get; set; }
        public string TX725 { get; set; }
        public string TX726 { get; set; }
        public string TX727 { get; set; }
        public string TX728 { get; set; }
        public string TX729 { get; set; }
        public string TX730 { get; set; }
        public string TX731 { get; set; }
        public string TX732 { get; set; }
        public string TX733 { get; set; }
        public string TX734 { get; set; }
        public string TX735 { get; set; }
        public string TX801 { get; set; }
        public string TX802 { get; set; }
        public string TX803 { get; set; }
        public string TX804 { get; set; }
        public string TX805 { get; set; }
        public string TX806 { get; set; }
        public string TX807 { get; set; }
        public string TX808 { get; set; }
        public string TX809 { get; set; }
        public string TX810 { get; set; }
        public string TX811 { get; set; }
        public string TX812 { get; set; }
        public string TX813 { get; set; }
        public string TX814 { get; set; }
        public string TX815 { get; set; }
        public string TX816 { get; set; }
        public string TX817 { get; set; }
        public string TX818 { get; set; }
        public string TX819 { get; set; }
        public string TX820 { get; set; }
        public string TX901 { get; set; }
        public string TX902 { get; set; }
        public string TX903 { get; set; }
        public string TX904 { get; set; }
        public string TX905 { get; set; }
        public string TX906 { get; set; }
        public string TX907 { get; set; }
        public string TX908 { get; set; }
        public string TX909 { get; set; }
        public string TX910 { get; set; }
        public string TX911 { get; set; }
        public string TX912 { get; set; }
        public string TX913 { get; set; }
        public string TX914 { get; set; }
        public string TX915 { get; set; }
        public string TX916 { get; set; }
        public string TX917 { get; set; }
        public string TX918 { get; set; }
        public string TX919 { get; set; }
        public string TX920 { get; set; }

        public bool chck { get; set; }
        public int chckid { get; set; }
        public string chcknm { get; set; }
        public string chckdt { get; set; }
        public int yyyy { get; set; }
        public int yyyymm { get; set; }
        public int weeknr { get; set; }
        public string weekds { get; set; }
        public int yyyymmdd { get; set; }
        public int hhmmss { get; set; }
        public string crdt { get; set; }
        public string eddt { get; set; }
        public int crusid { get; set; }
        public int edusid { get; set; }
        public string crusnm { get; set; }
        public string edusnm { get; set; }
        public int AAS01 { get; set; }
        public int AAS02 { get; set; }
        public int AAS03 { get; set; }
        public int AAS04 { get; set; }
        public int AAS05 { get; set; }
        public int AAS06 { get; set; }
        public int AAS07 { get; set; }
        public int AAS08 { get; set; }
        public int AAS09 { get; set; }
        public int AASTO { get; set; }
        public string AASPC { get; set; }
    }
}
