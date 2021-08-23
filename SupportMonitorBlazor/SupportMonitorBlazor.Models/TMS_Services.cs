using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SupportMonitorBlazor.Models
{
    public class TMS_Services
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TMS_Id { get; set; }
        public string DisplayName { get; set; }
        public string Status { get; set; }
        public DateTime RunningSince { get; set; }
        public  string StartType { get; set; }
    }
}
