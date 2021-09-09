using System;
using System.Collections.Generic;
using System.Text;

namespace SupportMonitorBlazor.Models
{
     public class ErrorLogs
    {
        public int Id{ get; set; }
        public int ServiceId { get; set; }
        public int TmsId { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime LogTime { get; set; }
    }
}
