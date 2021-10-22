using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SupportMonitorBlazor.Models
{
     public class TmsUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
