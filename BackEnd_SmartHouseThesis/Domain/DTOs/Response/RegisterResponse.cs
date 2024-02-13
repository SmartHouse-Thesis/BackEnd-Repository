using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Response
{
    public class RegisterResponse
    {
        public string? Message { get; set; }
        public Guid? Id { get; set; }
    }
}
