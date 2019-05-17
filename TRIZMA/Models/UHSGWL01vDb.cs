namespace TRIZMA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UHSGWL01v")]
    public partial class UHSGWL01vDb
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
        public int tstp01 { get; set; }
        public bool tstp011 { get; set; }
        public bool tstp012 { get; set; }
        public bool tstp013 { get; set; }
        public bool tstp014 { get; set; }
        public bool tstp015 { get; set; }
        public bool tstp016 { get; set; }
        public bool tstp017 { get; set; }

        public int tstp02 { get; set; }
        public bool tstp021 { get; set; }
        public bool tstp022 { get; set; }
        public bool tstp023 { get; set; }
        public bool tstp024 { get; set; }
        public bool tstp025 { get; set; }
        public bool tstp026 { get; set; }
        public bool tstp027 { get; set; }

        public int tstp03 { get; set; }
        public bool tstp031 { get; set; }
        public bool tstp032 { get; set; }
        public bool tstp033 { get; set; }
        public bool tstp034 { get; set; }
        public bool tstp035 { get; set; }
        public bool tstp036 { get; set; }
        public bool tstp037 { get; set; }

        public int tstp04 { get; set; }
        public bool tstp041 { get; set; }
        public bool tstp042 { get; set; }
        public bool tstp043 { get; set; }
        public bool tstp044 { get; set; }
        public bool tstp045 { get; set; }
        public bool tstp046 { get; set; }
        public bool tstp047 { get; set; }

        public int tstp05 { get; set; }
        public bool tstp051 { get; set; }
        public bool tstp052 { get; set; }
        public bool tstp053 { get; set; }
        public bool tstp054 { get; set; }
        public bool tstp055 { get; set; }
        public bool tstp056 { get; set; }
        public bool tstp057 { get; set; }

        public int tstp06 { get; set; }
        public bool tstp061 { get; set; }
        public bool tstp062 { get; set; }
        public bool tstp063 { get; set; }
        public bool tstp064 { get; set; }
        public bool tstp065 { get; set; }
        public bool tstp066 { get; set; }
        public bool tstp067 { get; set; }

        public int tstp07 { get; set; }
        public bool tstp071 { get; set; }
        public bool tstp072 { get; set; }
        public bool tstp073 { get; set; }
        public bool tstp074 { get; set; }
        public bool tstp075 { get; set; }
        public bool tstp076 { get; set; }
        public bool tstp077 { get; set; }

        public int tstp08 { get; set; }
        public bool tstp081 { get; set; }
        public bool tstp082 { get; set; }
        public bool tstp083 { get; set; }
        public bool tstp084 { get; set; }
        public bool tstp085 { get; set; }
        public bool tstp086 { get; set; }
        public bool tstp087 { get; set; }

        public int tstp09 { get; set; }
        public bool tstp091 { get; set; }
        public bool tstp092 { get; set; }
        public bool tstp093 { get; set; }
        public bool tstp094 { get; set; }
        public bool tstp095 { get; set; }
        public bool tstp096 { get; set; }
        public bool tstp097 { get; set; }

        public int tstp10 { get; set; }
        public bool tstp101 { get; set; }
        public bool tstp102 { get; set; }
        public bool tstp103 { get; set; }
        public bool tstp104 { get; set; }
        public bool tstp105 { get; set; }
        public bool tstp106 { get; set; }
        public bool tstp107 { get; set; }

        public int tstp11 { get; set; }
        public bool tstp111 { get; set; }
        public bool tstp112 { get; set; }
        public bool tstp113 { get; set; }
        public bool tstp114 { get; set; }
        public bool tstp115 { get; set; }
        public bool tstp116 { get; set; }
        public bool tstp117 { get; set; }

        public int tstp12 { get; set; }
        public bool tstp121 { get; set; }
        public bool tstp122 { get; set; }
        public bool tstp123 { get; set; }
        public bool tstp124 { get; set; }
        public bool tstp125 { get; set; }
        public bool tstp126 { get; set; }
        public bool tstp127 { get; set; }

        public int tstp13 { get; set; }
        public bool tstp131 { get; set; }
        public bool tstp132 { get; set; }
        public bool tstp133 { get; set; }
        public bool tstp134 { get; set; }
        public bool tstp135 { get; set; }
        public bool tstp136 { get; set; }
        public bool tstp137 { get; set; }

        public int tstp14 { get; set; }
        public bool tstp141 { get; set; }
        public bool tstp142 { get; set; }
        public bool tstp143 { get; set; }
        public bool tstp144 { get; set; }
        public bool tstp145 { get; set; }
        public bool tstp146 { get; set; }
        public bool tstp147 { get; set; }

        public int tstp15 { get; set; }
        public bool tstp151 { get; set; }
        public bool tstp152 { get; set; }
        public bool tstp153 { get; set; }
        public bool tstp154 { get; set; }
        public bool tstp155 { get; set; }
        public bool tstp156 { get; set; }
        public bool tstp157 { get; set; }

        public int tstp16 { get; set; }
        public bool tstp161 { get; set; }
        public bool tstp162 { get; set; }
        public bool tstp163 { get; set; }
        public bool tstp164 { get; set; }
        public bool tstp165 { get; set; }
        public bool tstp166 { get; set; }
        public bool tstp167 { get; set; }

        public int tstp17 { get; set; }
        public bool tstp171 { get; set; }
        public bool tstp172 { get; set; }
        public bool tstp173 { get; set; }
        public bool tstp174 { get; set; }
        public bool tstp175 { get; set; }
        public bool tstp176 { get; set; }
        public bool tstp177 { get; set; }

        public int tstp18 { get; set; }
        public bool tstp181 { get; set; }
        public bool tstp182 { get; set; }
        public bool tstp183 { get; set; }
        public bool tstp184 { get; set; }
        public bool tstp185 { get; set; }
        public bool tstp186 { get; set; }
        public bool tstp187 { get; set; }
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
        public int allCheck { get; set; }
        public int dayCheck { get; set; }
        public int weekCheck { get; set; }
        public int ts6s01 { get; set; }
        public bool ts6s011 { get; set; }
        public bool ts6s012 { get; set; }
        public bool ts6s013 { get; set; }
        public bool ts6s014 { get; set; }
        public bool ts6s015 { get; set; }
        public bool ts6s016 { get; set; }
        public bool ts6s017 { get; set; }
        public int ts6s02 { get; set; }
        public bool ts6s021 { get; set; }
        public bool ts6s022 { get; set; }
        public bool ts6s023 { get; set; }
        public bool ts6s024 { get; set; }
        public bool ts6s025 { get; set; }
        public bool ts6s026 { get; set; }
        public bool ts6s027 { get; set; }
        public int ts6s03 { get; set; }
        public bool ts6s031 { get; set; }
        public bool ts6s032 { get; set; }
        public bool ts6s033 { get; set; }
        public bool ts6s034 { get; set; }
        public bool ts6s035 { get; set; }
        public bool ts6s036 { get; set; }
        public bool ts6s037 { get; set; }
        public int ts6s04 { get; set; }
        public bool ts6s041 { get; set; }
        public bool ts6s042 { get; set; }
        public bool ts6s043 { get; set; }
        public bool ts6s044 { get; set; }
        public bool ts6s045 { get; set; }
        public bool ts6s046 { get; set; }
        public bool ts6s047 { get; set; }
        public int ts6s05 { get; set; }
        public bool ts6s051 { get; set; }
        public bool ts6s052 { get; set; }
        public bool ts6s053 { get; set; }
        public bool ts6s054 { get; set; }
        public bool ts6s055 { get; set; }
        public bool ts6s056 { get; set; }
        public bool ts6s057 { get; set; }
        public int ts6s06 { get; set; }
        public bool ts6s061 { get; set; }
        public bool ts6s062 { get; set; }
        public bool ts6s063 { get; set; }
        public bool ts6s064 { get; set; }
        public bool ts6s065 { get; set; }
        public bool ts6s066 { get; set; }
        public bool ts6s067 { get; set; }
        public int ts6s07 { get; set; }
        public bool ts6s071 { get; set; }
        public bool ts6s072 { get; set; }
        public bool ts6s073 { get; set; }
        public bool ts6s074 { get; set; }
        public bool ts6s075 { get; set; }
        public bool ts6s076 { get; set; }
        public bool ts6s077 { get; set; }
        public int ts6s08 { get; set; }
        public bool ts6s081 { get; set; }
        public bool ts6s082 { get; set; }
        public bool ts6s083 { get; set; }
        public bool ts6s084 { get; set; }
        public bool ts6s085 { get; set; }
        public bool ts6s086 { get; set; }
        public bool ts6s087 { get; set; }
        public int ts6s09 { get; set; }
        public bool ts6s091 { get; set; }
        public bool ts6s092 { get; set; }
        public bool ts6s093 { get; set; }
        public bool ts6s094 { get; set; }
        public bool ts6s095 { get; set; }
        public bool ts6s096 { get; set; }
        public bool ts6s097 { get; set; }
        public int ts6s10 { get; set; }
        public bool ts6s101 { get; set; }
        public bool ts6s102 { get; set; }
        public bool ts6s103 { get; set; }
        public bool ts6s104 { get; set; }
        public bool ts6s105 { get; set; }
        public bool ts6s106 { get; set; }
        public bool ts6s107 { get; set; }
        public int ts6s11 { get; set; }
        public bool ts6s111 { get; set; }
        public bool ts6s112 { get; set; }
        public bool ts6s113 { get; set; }
        public bool ts6s114 { get; set; }
        public bool ts6s115 { get; set; }
        public bool ts6s116 { get; set; }
        public bool ts6s117 { get; set; }
        public int sallCheck { get; set; }
        public int sdayCheck { get; set; }
        public int sweekCheck { get; set; }

    }
}
