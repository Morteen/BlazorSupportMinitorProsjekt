using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupportMonitorBlazor.Models
{
    public class BlazorTMS
    {
       [Key]
        public int TmsId { get; set; }
       [Required]
       [MinLength(3)]
       public string Name { get; set; }
        public string Country { get; set; }
        public string  TmsCategory { get; set; }
        public int CriticalErrors { get; set; }
   
    }
   

}
