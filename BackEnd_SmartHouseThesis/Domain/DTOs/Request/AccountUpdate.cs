using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Request
{
    public  class AccountUpdate
    {
        public Guid Id { get; set; }
        public string Email { get; set; }         
    }
}
