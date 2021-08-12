using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupportMonitorBlazor.Models
{
  public class TmsProperties
    {

        [Key]
        public int Id{ get; set; }
        public int TmsId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
