using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupportMonitorBlazor.Models
{
    public class DiskSpace
    {
        [Key]
        public int Id { get; set; }
        public int TmsId { get; set; }
        public string  Name { get; set; }
        public string Type { get; set; }
        public int FreespacePercentMinimum  { get; set; }
        public int  FrespaceMinimumBytes { get; set; }
        public int Actualsize { get; set; }
        public int MaxSize { get; set; }
    }
}
