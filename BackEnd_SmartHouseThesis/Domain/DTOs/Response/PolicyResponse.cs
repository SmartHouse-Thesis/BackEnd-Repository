using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public class PolicyResponse
    {
        public Guid? Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
