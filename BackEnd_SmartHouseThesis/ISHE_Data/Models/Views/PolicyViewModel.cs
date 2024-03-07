using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISHE_Data.Models.Views
{
    public class PolicyViewModel
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreateAt { get; set; }
    }
}
