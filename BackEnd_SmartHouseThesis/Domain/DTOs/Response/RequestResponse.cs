using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public class RequestResponse
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? Status { get; set; }
    }
}
