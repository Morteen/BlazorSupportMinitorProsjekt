using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupportMonitorBlazor.Models
{
    public class TMS_Services
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TMS_Id { get; set; }
        public string DisplayName { get; set; }
        public string Status { get; set; }
        public DateTime RunningSince { get; set; }
    }
}
