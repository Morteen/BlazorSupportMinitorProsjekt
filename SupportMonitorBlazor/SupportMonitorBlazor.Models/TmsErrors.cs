using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupportMonitorBlazor.Models
{
   public class TmsErrors
	{
        /* {
             "Kunde": "TdxLog Wiklunds",
             "Status": "Kritisk",
             "Kritisk": 1,
             "Feil": 1,
             "OK": 4,
             "FeilInformasjon": "ImportEksport har stoppet",
             "SystemFunksjonalitet":"ImportEksport",
             "FeilDetalj": "TdxExt har stoppet 2021-06-22 07:05",
             "Aksjon": "Logg inn på Wicklunds server og restart TdxLogContoller tjenestene",
             "Oppdatert": "2021-06-22 07:34",
             "StatusVerdier": "PROGRAM_RUNNING=CRASH,NETWORK=OK,MOBILE=OK"
         },*/
        [Key]
       
        public int TmsErrorId { get; set; }
        [Required]
        public int TMSid { get; set; }
        public string ErrorInformation { get; set; }
        public string SystemFunction { get; set; }
        public string ErrorDetail { get; set; }
        public string RequiredAction { get; set; }
    }
  
}
