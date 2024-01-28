using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request
{
    public  class PolicyRequest
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
