using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupportMonitorBlazor.Models
{
    public class SystemValues
    {[Key]
        public int Id { get; set; }
       
        public string SystemName { get; set; }
        public string  SystemValue { get; set; }
    }
}
