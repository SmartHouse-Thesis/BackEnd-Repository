using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data.Models.Internal
{
    public class AuthModel
    {
        public Guid Id { get; set; }
        public string Role { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
